using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace PSC_ERP.ThanhToan
{
    public partial class frmPhieuDeNghiChuyenKhoan_Edit : Form
    {
        #region Properties

        private bool OK = false;
        private ERP_Library.ThanhToan.DeNghiChuyenKhoan _data;
        internal string MaPhanHe = "";
        private Nullable<int> OldMaTaiKhoan;
        private bool _IsDichVu = false;

        #endregion

        #region Loads
        public frmPhieuDeNghiChuyenKhoan_Edit()
        {
            InitializeComponent();
        }

        public frmPhieuDeNghiChuyenKhoan_Edit(bool DichVu)
        {
            InitializeComponent();
            _IsDichVu = DichVu;
        }

        private void frmPhieuDeNghiChuyenKhoan_Edit_Load(object sender, EventArgs e)
        {
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                this.Text = "Phiếu chuyển cho tài chính";
            TatMoNganHang(!_IsDichVu);

        }
        #endregion

        #region Process
        public bool EditData(ERP_Library.ThanhToan.DeNghiChuyenKhoan data)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            bdTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmbCongTy.DataSource = ERP_Library.CongTyList.GetCongTyList();
            HamDungChung.VisibleColumn(cmbCongTy.DisplayLayout.Bands[0], "MaCongTyQuanLy", "TenCongTy");
            _data = data;
            _data.ChungTu.BeginEdit();
            _data.BeginEdit();
            _data.Loai = false;
            bdData.DataSource = _data;
            lblHoanTat.Visible = _data.DaDuyet;
            btnDongY.Enabled = !_data.DaDuyet;
            OldMaTaiKhoan = _data.MaTaiKhoanChuyen;
            this.ShowDialog();
            return OK;
        }

        private void CapNhatTongSoTien()
        {
            //cập nhật lại tổng tiền
            decimal tong = 0;
            foreach (ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu item in _data.ChungTu)
            {
                tong += item.SoTien;
            }
            _data.SoTien = tong;
        }

        private bool MoChungTu(ERP_Library.ThanhToan.LoaiChungTuGoc loai, ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu chungtu, bool isnew)
        {
            System.Type t = System.Type.GetType("PSC_ERP.ThanhToan." + loai.TenForm);
            frmChungTuGoc f = (frmChungTuGoc)Activator.CreateInstance(t);
            f._denghi = _data;
            bool GiaTri = f.MoChungTu(loai, chungtu, isnew);

            //Tải dữ liệu từ Hóa Đơn Dịch Vụ vừa chọn
            _data.TenNguoiNhan = f.strTenDoiTac;
            _data.NganHangNhan = f.strTenNganHang;
            _data.SoTaiKhoanNhan = f.strTaiKhoan;
            return GiaTri;
        }

        private void TatMoNganHang(bool bAction)
        {
            cmbTaiKhoan.Visible = bAction;
            lblTenNganHang.Visible = bAction;
            lblTaiKhoanChuyen.Visible = bAction;
            txtNganHang.Visible = bAction;
        }
        #endregion

        #region Event
        private void btnKhong_Click(object sender, EventArgs e)
        {
            _data.ChungTu.CancelEdit();
            _data.CancelEdit();
            this.Close();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value != null)
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            grdChungTu.DeleteSelectedRows();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0) && !_IsDichVu )
            {
                MessageBox.Show("Ngân hàng không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmChonLoaiChungTuGoc f = new frmChonLoaiChungTuGoc();
            if (f.ChonLoaiChungTuGoc(MaPhanHe, "ChuyenKhoan"))
            {
                ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu _chungtu = _data.ChungTu.AddNew();
                if (MoChungTu(f.LoaiChungTu, _chungtu, true))
                {

                    _data.ChungTu.EndNew(_data.ChungTu.IndexOf(_chungtu));
                    if (_data.LyDo == "")
                        _data.LyDo = _chungtu.DienGiai;
                    CapNhatTongSoTien();
                }
                else
                {
                    _data.ChungTu.CancelNew(_data.ChungTu.IndexOf(_chungtu));
                    _data.ChungTu.Remove(_chungtu);
                }
            }
        }
           
        private void btnDongY_Click(object sender, EventArgs e)
        {
            if ((cmbTaiKhoan.Value == null || (int)cmbTaiKhoan.Value == 0) && !_IsDichVu)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản ngân hàng chuyển!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bdData.EndEdit();
                _data.Loai = false;
                _data.ChungTu.ApplyEdit();
                _data.ApplyEdit();
                OK = true;
                this.Close();
            }
            catch (Exception ex)
            {
                OK = false;
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void grdChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int MaLoaiChungTu = (int)e.Row.Cells["MaLoaiChungTu"].Value;
            ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu = ERP_Library.ThanhToan.LoaiChungTuGoc.GetLoaiChungTuGoc(MaLoaiChungTu);
            if (MoChungTu(LoaiChungTu, (ERP_Library.ThanhToan.DeNghiChuyenKhoan_ChungTu)e.Row.ListObject, false))
            {
                CapNhatTongSoTien();
            }
        }

        private void grdChungTu_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ gốc này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void grdChungTu_AfterRowsDeleted(object sender, EventArgs e)
        {
            CapNhatTongSoTien();
        }

        private void cmbTaiKhoan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbTaiKhoan.Value != null)
            {
                txtNganHang.Text = ((ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild)cmbTaiKhoan.SelectedRow.ListObject).TenNganHang;
            }
            else
                txtNganHang.Text = "";
        }

        private void cmbTaiKhoan_Validating(object sender, CancelEventArgs e)
        {
            if (grdChungTu.Rows.Count > 0 && !cmbTaiKhoan.Value.Equals(OldMaTaiKhoan))
            {
                MessageBox.Show("Không thể thay đổi sau khi đã chọn chứng từ gốc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            OldMaTaiKhoan = (Nullable<int>)cmbTaiKhoan.Value;
        }

        private void ultraButton_Exprot_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdChungTu);
        }
        #endregion
    }
}
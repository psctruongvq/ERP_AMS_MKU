using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmPhieuDeNghiThanhToan_Edit : Form
    {
        private bool OK = false;
        private ERP_Library.ThanhToan.DeNghiThanhToan _data;
        internal string MaPhanHe = "";
        ERP_Library.ThanhToan.LoaiChungTuGoc _defLoai;
        public frmPhieuDeNghiThanhToan_Edit()
        {
            InitializeComponent();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            _data.ChungTu.CancelEdit();
            _data.CancelEdit();
            this.Close();
        }

        public bool EditData(ERP_Library.ThanhToan.DeNghiThanhToan data)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            _data = data;
            _data.ChungTu.BeginEdit();
            _data.BeginEdit();
            bdData.DataSource = _data;
            this.ShowDialog();
            return OK;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                bdData.EndEdit();
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

        private void frmPhieuDeNghiThanhToan_Edit_Load(object sender, EventArgs e)
        {
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
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
            //xử lý chỉ chọn 1 loại chứng từ thanh toán
            ERP_Library.ThanhToan.LoaiChungTuGoc _loaichungtu;
            if (_data.ChungTu.Count == 0)
            {
                frmChonLoaiChungTuGoc f = new frmChonLoaiChungTuGoc();
                if (f.ChonLoaiChungTuGoc(MaPhanHe, "ThanhToan"))
                {
                    _loaichungtu = f.LoaiChungTu;
                    _defLoai = _loaichungtu;
                    _data.PhanLoai = _loaichungtu.MaLoaiChungTu;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (_defLoai == null)
                {
                    _defLoai = ERP_Library.ThanhToan.LoaiChungTuGoc.GetLoaiChungTuGoc(_data.PhanLoai);
                }
                _loaichungtu = _defLoai;
            }

            ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu _chungtu = _data.ChungTu.AddNew();
            if (MoChungTu(_loaichungtu, _chungtu, true))
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

        private void grdChungTu_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            int MaLoaiChungTu = (int)e.Row.Cells["MaLoaiChungTu"].Value;
            ERP_Library.ThanhToan.LoaiChungTuGoc LoaiChungTu = ERP_Library.ThanhToan.LoaiChungTuGoc.GetLoaiChungTuGoc(MaLoaiChungTu);
            if (MoChungTu(LoaiChungTu, (ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu)e.Row.ListObject, false))
            {
                CapNhatTongSoTien();
            }
        }

        private void CapNhatTongSoTien()
        {
            //cập nhật lại tổng tiền
            decimal tong = 0;
            foreach (ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu item in _data.ChungTu)
            {
                tong += item.SoTien;
            }
            _data.SoTien = tong;
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

        private bool MoChungTu(ERP_Library.ThanhToan.LoaiChungTuGoc loai, ERP_Library.ThanhToan.DeNghiThanhToan_ChungTu chungtu, bool isnew)
        {
            System.Type t = System.Type.GetType("PSC_ERP.ThanhToan." + loai.TenForm);
            frmChungTuGoc f = (frmChungTuGoc)Activator.CreateInstance(t);
            return f.MoChungTu(loai, chungtu, isnew);
        }
    }
}
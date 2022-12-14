using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmPhieuDeNghiChuyenKhoan_CacQuyEdit : Form
    {
        #region Properties

        private bool OK = false;
        private ERP_Library.DeNghiChuyenKhoan_ChungTuNgoai _data;
        internal string MaPhanHe = "";
        private Nullable<int> OldMaTaiKhoan;
        private bool _IsDichVu = false;
        public DoiTacList _doiTacList;
        public LoaiTienList _loaiTienList;
        

        bool Active = false;

        #endregion

        #region Loads
        public frmPhieuDeNghiChuyenKhoan_CacQuyEdit()
        {
            InitializeComponent();
        }

        private void frmPhieuDeNghiChuyenKhoan_Edit_Load(object sender, EventArgs e)
        {
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 30)
                this.Text = "Phiếu chuyển cho tài chính";
        }

        private void cmbDoiTac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbDoiTac.DisplayLayout.Bands[0],
            new string[3] { "TenDoiTac", "MaSoThue", "DiaChi" },
            new string[3] { "Tên đối tác", "Mã số thuế", "Đơn vị" },
            new int[3] { 250, 120, 250 },
            new Control[3] { null, null, null },
            new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[3] { false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbDoiTac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmbDoiTac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmbDoiTac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmbDoiTac, "TenDoiTac");
        }

        private void cmb_NganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmb_NganHang.DisplayLayout.Bands[0],
                    new string[2] { "TenNganHang", "SoTk" },
                    new string[2] { "Tên ngân hàng", "Số tài khoản" },
                    new int[2] { 300, 100 },
                    new Control[2] { null, null },
                    new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                    new bool[2] { false, false }); //màu và font chữ
            foreach (UltraGridColumn col in this.cmb_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                col.CellAppearance.TextHAlign = HAlign.Left;
            }
            //màu nền
            this.cmb_NganHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.cmb_NganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            FilterCombo filter = new FilterCombo(cmb_NganHang, "TenNganHang");
        }
        #endregion

        #region Process
        public bool EditData(ERP_Library.DeNghiChuyenKhoan_ChungTuNgoai data, int LoaiDeNghi)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            bdTaiKhoan.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            cmbCongTy.DataSource = ERP_Library.CongTyList.GetCongTyList();

            HamDungChung.VisibleColumn(cmbCongTy.DisplayLayout.Bands[0], "MaCongTyQuanLy", "TenCongTy");
            _data = data;
            _data.BeginEdit();
            _data.LoaiDeNghi = LoaiDeNghi; //1: Quỹ ; 2: Công Đoàn

            bdData.DataSource = _data;
            lblHoanTat.Visible = _data.DaDuyet;
            btnDongY.Enabled = !_data.DaDuyet;
            OldMaTaiKhoan = _data.MaTaiKhoanChuyen;

            cmbDoiTac.DataSource = _doiTacList;
            cmbu_LoaiTien.DataSource = _loaiTienList;
            //-----------------------------------------------

            this.ShowDialog();
            return OK;
        }
        #endregion

        #region Event
        private void btnKhong_Click(object sender, EventArgs e)
        {
            _data.CancelEdit();
            this.Close();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value != null)
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDoiTac.ActiveRow == null)
                {
                    MessageBox.Show(this, "Vui lòng chọn tên đối tác.", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbDoiTac.Focus();
                    return;
                }

                if (cmb_NganHang.ActiveRow == null)
                {
                    MessageBox.Show(this, "Vui lòng chọn ngân hàng.", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmb_NganHang.Focus();
                    return;
                }

                long lMaDoiTac = Convert.ToInt64(cmbDoiTac.Value);
                int iMaNganHang = Convert.ToInt32(cmb_NganHang.Value);
                _data.TenDoiTac = DoiTac.GetDoiTac(lMaDoiTac).TenDoiTac;
                _data.SoTaiKhoan = TK_NganHang.GetSoTaiKhoan((int)lMaDoiTac, iMaNganHang);

                bdData.EndEdit();
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

        private void cmb_NganHang_ValueChanged(object sender, EventArgs e)
        {
            int iMaDoiTac = 0;
            int iMaNganHang = 0;
           
            if (cmb_NganHang.ActiveRow != null)
            {
                iMaDoiTac = Convert.ToInt32(cmbDoiTac.Value);
                iMaNganHang = Convert.ToInt32(cmb_NganHang.Value);
                _data.MaTaiKhoanNhan = iMaNganHang;
                txtTaiKhoan.Text = TK_NganHang.GetSoTaiKhoan(iMaDoiTac, iMaNganHang);
                txt_MST.Text = DoiTac.GetDoiTac(iMaDoiTac).MaSoThue;
                bdData.EndEdit();
            }
        }

        private void cmbDoiTac_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDoiTac.ActiveRow != null)
                {
                    DoiTac doitac = DoiTac.GetDoiTac(Convert.ToInt64(cmbDoiTac.Value));
                    tKNganHangListBindingSource.DataSource = doitac.TK_NganHangList;
                    bdData.EndEdit();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


    }
}
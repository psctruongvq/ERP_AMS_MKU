using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmSoDuDauKy_NganHang : Form
    {
        #region Properties
        public bool _isSave = false;
        public bool _isShowFromParent = false;
        public int _maKy = 0;

        SoDuDauKy_NganHangList _soDuDauKyList;
        #endregion

        #region Loads
        public frmSoDuDauKy_NganHang()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[5] { "TenNganHang", "TaiKhoanNH", "LoaiTien", "SoDuDauKy", "SoDuDauKy_NgoaiTe" },
                new string[5] { "Tên ngân hàng", "Số TK", "Loại tiền", "Số dư đầu kỳ", "Số dư ngoại tệ" },
                new int[5] { 300, 120, 80, 160, 160 },
                new Control[5] { null, null, cmb_LoaiTien, null,null },
                new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.NullCanhGiua, KieuDuLieu.TienLe, KieuDuLieu.TienLe },
                new bool[5] { false, false, false, true, true });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdData.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            //this.grdData.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }

        private void cbu_KyKetChuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_KyKetChuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_KyKetChuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            foreach (UltraGridColumn col in this.cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                //x =  //= System.Drawing.w;//RoyalBlue
            }
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Mã Kỳ";
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 1;
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["MaKy"].Hidden = false;

            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 2;
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày Bắt Đầu";
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.VisiblePosition = 3;
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;

            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày Kết Thúc";
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.VisiblePosition = 4;
            cmbu_KyKetChuyen.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            kyListBindingSource.DataSource = KyList.GetKyList();
            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
        }

        private void Load_DanhSach()
        {
            if (cmbu_KyKetChuyen.ActiveRow != null)
            {
                int iMaKy = Convert.ToInt32(cmbu_KyKetChuyen.Value);
                this._maKy = iMaKy;
                _soDuDauKyList = SoDuDauKy_NganHangList.GetSoDuDauKy_NganHangList(iMaKy);
                bdData.DataSource = _soDuDauKyList;
            }
        }
        #endregion

        private void bt_NhapSoDu_Click(object sender, EventArgs e)
        {
            Load_DanhSach();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            Load_DanhSach();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                bdData.EndEdit();
                _soDuDauKyList.ApplyEdit();
                _soDuDauKyList.Save();
                SoDuDauKy_NganHang.UpdateSoDuTaiKhoan_BySoDuTheoNganHang(this._maKy, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                MessageBox.Show(this, "Cập nhật thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this._isShowFromParent == true)
                {
                    this._isSave = true;
                    this.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count <= 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdData.DeleteSelectedRows();
            grdData.UpdateData();
        }

        private void frmSoDuDauKy_NganHang_Load(object sender, EventArgs e)
        {
            if (_isShowFromParent == true)
            {
                cmbu_KyKetChuyen.Value = this._maKy;
                Load_DanhSach();
            }
        }

        #region Event
        #endregion




    }
}

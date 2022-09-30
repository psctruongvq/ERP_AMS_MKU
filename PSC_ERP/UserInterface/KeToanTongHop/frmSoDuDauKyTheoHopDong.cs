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
    public partial class frmSoDuDauKyTheoHopDong : Form
    {
        #region Properties
        SoDuDauKyHopDongList _soDuDauKyList;
        #endregion

        #region Loads
        public frmSoDuDauKyTheoHopDong()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[6] { "SoHopDong", "TenDoiTac", "MaTaiKhoan", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo" },
                new string[6] { "Số hợp đồng", "Tên đối tác", "Số hiệu TK", "Tên tài khoản", "Số Dư ĐK Nợ", "Số Dư ĐK Có" },
                new int[6] { 150, 350, 150, 250, 150, 150 },
                new Control[6] { null, null, cbu_SoHieuTK, null, null, null },
                new KieuDuLieu[6] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.TienLe },
                new bool[6] { false, false, true, true, true, true, });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }

            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
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
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
        }

        private void Load_DanhSach()
        {
            if (cmbu_KyKetChuyen.ActiveRow != null)
            {
                int iMaKy = Convert.ToInt32(cmbu_KyKetChuyen.Value);
                _soDuDauKyList = SoDuDauKyHopDongList.GetSoDuDauKyHopDongList(iMaKy);
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

                MessageBox.Show(this, "Cập nhật thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cbu_SoHieuTK_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbu_SoHieuTK.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu Tài Khoản";
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;

            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            cbu_SoHieuTK.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 250;

            this.cbu_SoHieuTK.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_SoHieuTK.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }

        #region Event
        #endregion
    }
}

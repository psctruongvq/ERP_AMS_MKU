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
    public partial class frmSoDuDauKy_CacQuy : Form
    {
        #region Properties
        SoDuDauKy_CacQuyList _soDuDauKyList;
        #endregion

        #region Loads
        public frmSoDuDauKy_CacQuy()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[3] { "TenCacQuy", "SoDuDauKyNo", "SoDuDauKyCo" },
                new string[3] { "Tên Quỹ", "Số Dư ĐK Nợ", "Số Dư ĐK Có"},
                new int[3] {  400, 180, 180 },
                new Control[3] { null, null, null },
                new KieuDuLieu[3] { KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.TienLe },
                new bool[3] { false, true, true,});

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }
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
        }

        private void Load_DanhSach()
        {
            if (cmbu_KyKetChuyen.ActiveRow != null)
            {
                int iMaKy = Convert.ToInt32(cmbu_KyKetChuyen.Value);
                _soDuDauKyList = SoDuDauKy_CacQuyList.GetSoDuDauKy_CacQuyList(iMaKy);
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

        #region Event
        #endregion




    }
}

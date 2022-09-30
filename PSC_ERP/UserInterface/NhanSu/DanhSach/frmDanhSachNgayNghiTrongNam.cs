using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmDanhSachNgayNghiTrongNam : Form
    {
        NgayHolidayList _NgayHolidayList;
        NgayHoliday _NgayHoliday;
        Util _Util = new Util();

        private void LayDuLieu()
        {
            _NgayHolidayList = NgayHolidayList.GetNgayHolidayList();
            NgayHoliday_BindingSource.DataSource = _NgayHolidayList;
        }

        public frmDanhSachNgayNghiTrongNam()
        {
            InitializeComponent();
            LayDuLieu();
        }

        #region grdu_BacLuongCoBan_InitializeLayout
        private void grdu_BacLuongCoBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["MaNgayHoliday"].Hidden = true;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["Ngay"].Header.Caption = "Ngày Nghĩ";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["Ngay"].Header.VisiblePosition = 0;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["Ngay"].Width = 190;

            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgayHoliday"].Header.Caption = "Tên Ngày Nghĩ";
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgayHoliday"].Header.VisiblePosition = 1;
            grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns["TenNgayHoliday"].Width = 365;

            grdu_BacLuongCoBan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_BacLuongCoBan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_BacLuongCoBan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }
        #endregion

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            grdu_BacLuongCoBan.UpdateData();
            _NgayHolidayList.ApplyEdit();
            _NgayHolidayList.Save();
            MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_BacLuongCoBan.DeleteSelectedRows();
        }
        private void New()
        {
            _NgayHoliday = NgayHoliday.NewNgayHoliday();
            _NgayHolidayList.Add(_NgayHoliday);
            NgayHoliday_BindingSource.DataSource = _NgayHolidayList;
            grdu_BacLuongCoBan.ActiveRow = grdu_BacLuongCoBan.Rows[_NgayHolidayList.Count - 1];
        }
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhSachNgayNghiTrongNam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                New();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                LayDuLieu();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Csla;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHinhThucKhenThuong : Form
    {
        Util util = new Util();
        HinhThucKhenThuongList _HinhThucKhenThuongList;
        HinhThucKhenThuong _HinhThucKhenThuong;
        public frmHinhThucKhenThuong()
        {
            InitializeComponent();
            this.Load_Form();
        }
        #region Load
        private void Load_Form()
        {
            try
            {
                _HinhThucKhenThuongList = HinhThucKhenThuongList.GetHinhThucKhenThuongList();
                HinhThucKhenThuong_bindingSource.DataSource = _HinhThucKhenThuongList;
            }
            catch (ApplicationException)
            {

            }
        }

        private void ultragrdHinhThucKhenThuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdHinhThucKhenThuong.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdHinhThucKhenThuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["MaKhenThuong"].Hidden = true;
            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Khen Thưởng";
            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["TenKhenThuong"].Header.Caption = "Tên Khen Thưởng";
            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["TenKhenThuong"].Header.VisiblePosition = 1;
            ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns["TenKhenThuong"].Width = 200;

            foreach (UltraGridColumn col in ultragrdHinhThucKhenThuong.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }
        #endregion

        #region Event
        private void ultragrdHinhThucKhenThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  ultragrdHinhThucKhenThuong.UpdateData();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraMaQuanLy() == true)
                {
                    _HinhThucKhenThuongList.ApplyEdit();
                    _HinhThucKhenThuongList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Form();
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHinhThucKhenThuong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ultragrdHinhThucKhenThuong.DeleteSelectedRows();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Load_Form();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnshinhthuckhenthuongAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthuckhenthuong(), new frmHienThiReport(), false);

        }
        #endregion

        #region Process
        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _HinhThucKhenThuongList.Count; i++)
            {
                for (int j = 0; j < _HinhThucKhenThuongList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_HinhThucKhenThuongList[i].MaQuanLy.Trim() == _HinhThucKhenThuongList[j].MaQuanLy.Trim())
                        {
                            HinhThucKhenThuong qg = HinhThucKhenThuong.GetHinhThucKhenThuong(_HinhThucKhenThuongList[i].MaKhenThuong);
                            MessageBox.Show(this, "Hình thức khen thưởng " + qg.TenKhenThuong.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHinhThucKhenThuong.ActiveRow = ultragrdHinhThucKhenThuong.Rows[i + 1];
                            ultragrdHinhThucKhenThuong.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void ultragrdHinhThucKhenThuong_Leave(object sender, EventArgs e)
        {
            ultragrdHinhThucKhenThuong.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHinhThucKhenThuong);
        }
     

    }
}
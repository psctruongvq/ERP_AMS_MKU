using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmChuyenMonNghiepVu : Form
    {
        Util util=new Util();
        ChuyenMonNghiepVuClassList list;

        public frmChuyenMonNghiepVu()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = ChuyenMonNghiepVuClassList.GetChuyenMonNghiepVuClassList();
                ChuyenMonNghiepVu_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }

        }

        private void frmChuyenMonNghiepVu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdChuyenMonNghiepVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdChuyenMonNghiepVu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdChuyenMonNghiepVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["MaChuyenMonNV"].Hidden = true;
            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenMonNghiepVu"].Header.Caption = "Chuyên Môn Nghiệp Vụ";
            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenMonNghiepVu"].Header.VisiblePosition = 1;
            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenMonNghiepVu"].Width = 220;

            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            foreach (UltraGridColumn col in ultragrdChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].MaQuanLy == "")
                {
                    MessageBox.Show(this, "Vui lòng nhập mã CMNV", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (list[i].ChuyenMonNghiepVu == "")
                {
                    MessageBox.Show(this, "Vui lòng nhập tên CMNV", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                }
                catch (ApplicationException)
                {

                }
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdChuyenMonNghiepVu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdChuyenMonNghiepVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnschuyenmonnghiepvuAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptChuyenmonnghiepvu(), new frmHienThiReport(), false);

        }
        #endregion

        #region Process
        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].MaQuanLy.Trim() == list[j].MaQuanLy.Trim())
                        {
                            ChuyenMonNghiepVuClass qg = ChuyenMonNghiepVuClass.GetChuyenMonNghiepVuClass(list[i].MaChuyenMonNV);
                            MessageBox.Show(this, "Chuyên môn nghiệp vụ " + qg.ChuyenMonNghiepVu.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdChuyenMonNghiepVu.ActiveRow = ultragrdChuyenMonNghiepVu.Rows[i + 1];
                            ultragrdChuyenMonNghiepVu.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion  

        private void ultragrdChuyenMonNghiepVu_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdChuyenMonNghiepVu.UpdateData();
        }

        private void ultragrdChuyenMonNghiepVu_Leave(object sender, EventArgs e)
        {
            ultragrdChuyenMonNghiepVu.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChuyenMonNghiepVu);
        }
    }
}
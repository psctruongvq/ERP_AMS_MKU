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
    public partial class frmTrinhDoHocVan : Form
    {
        Util util=new Util();
        TrinhDoHocVanClassList list;
        public delegate void PassData(TrinhDoHocVanClassList value);
        public PassData getData;
        public frmTrinhDoHocVan()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
                TrinhDoHocVan_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }
        private void ultragrdTrinhDoHocVan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdTrinhDoHocVan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdTrinhDoHocVan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaTrinhDoHocVan"].Hidden = true;
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.Caption = "Trình độ học vấn";
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.VisiblePosition = 1;
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Width = 220;

            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            foreach (UltraGridColumn col in ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        private void frmTrinhDoHocVan_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }  
        #endregion

        #region Event
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTrinhDoHocVan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTrinhDoHocVan.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            //this.Load_Luoi();
            list = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            TrinhDoHocVan_bindingSource.DataSource = list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < ultragrdTrinhDoHocVan.Rows.Count; i++)
                {
                    if (ultragrdTrinhDoHocVan.Rows[i].Cells["MaQuanLy"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTrinhDoHocVan.ActiveRow = ultragrdTrinhDoHocVan.Rows[i];
                        return;
                    }
                    if (ultragrdTrinhDoHocVan.Rows[i].Cells["TrinhDoHocVan"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTrinhDoHocVan.ActiveRow = ultragrdTrinhDoHocVan.Rows[i];
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
                        if (getData != null)
                        {
                            getData(list);
                        }

                    }
                    catch (ApplicationException)
                    {

                    }
                }
          
        }

        private void ultragrdTrinhDoHocVan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdTrinhDoHocVan.UpdateData();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnstrinhdohocvanAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTrinhdohocvan(), new frmHienThiReport(), false);
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
                            TrinhDoHocVanClass qg = TrinhDoHocVanClass.GetTrinhDoHocVanClass(list[i].MaTrinhDoHocVan);
                            MessageBox.Show(this, "Trình độ học vấn " + qg.TrinhDoHocVan.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdTrinhDoHocVan.ActiveRow = ultragrdTrinhDoHocVan.Rows[i + 1];
                            ultragrdTrinhDoHocVan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void ultragrdTrinhDoHocVan_Leave(object sender, EventArgs e)
        {
            ultragrdTrinhDoHocVan.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTrinhDoHocVan);
        }


    }
}
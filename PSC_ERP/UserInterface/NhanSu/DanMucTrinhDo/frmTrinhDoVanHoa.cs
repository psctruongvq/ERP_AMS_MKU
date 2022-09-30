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
    public partial class frmTrinhDoVanHoa : Form
    {
        Util util=new Util();
        
        TrinhDoVanHoaList list;
        public delegate void PassData(TrinhDoVanHoaList value);
        public PassData getData;
        public frmTrinhDoVanHoa()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = TrinhDoVanHoaList.GetTrinhDoVanHoaList();
                TrinhDoVanHoa_bindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ultragrdTrinhDoHocVan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdTrinhDoHocVan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdTrinhDoHocVan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }

            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Hidden = false;
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Header.Caption = "Trình độ văn hóa";
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Header.VisiblePosition = 1;
            ultragrdTrinhDoHocVan.DisplayLayout.Bands[0].Columns["TenTrinhVanHoa"].Width = 220;         

        }
        private void frmTrinhDoVanHoa_Load(object sender, EventArgs e)
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
            list = TrinhDoVanHoaList.GetTrinhDoVanHoaList();
            TrinhDoVanHoa_bindingSource.DataSource = list;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
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
                    catch (Exception ex)
                    {
                        throw ex;
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

    
        private void ultragrdTrinhDoHocVan_Leave(object sender, EventArgs e)
        {
            ultragrdTrinhDoHocVan.UpdateData();
        }

        private void frmTrinhDoVanHoa_Load_1(object sender, EventArgs e)
        {
            Load_Luoi();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTrinhDoHocVan);
        }
    }
}
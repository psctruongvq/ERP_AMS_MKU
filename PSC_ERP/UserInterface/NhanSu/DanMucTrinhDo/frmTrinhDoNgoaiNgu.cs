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
    public partial class frmTrinhDoNgoaiNgu : Form
    {
        Util util=new Util();
        TrinhDoNgoaiNguClassList list;
        public delegate void PassData(TrinhDoNgoaiNguClassList value);
        public PassData getData;
        public frmTrinhDoNgoaiNgu()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            
                list = TrinhDoNgoaiNguClassList.GetTrinhDoNgoaiNguClassList();
                TrinhDoNgoaiNgu_bindingSource.DataSource = list;
          
        }
        private void frmTrinhDoNgoaiNgu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        private void ultragrdTrinhDoNgoaiNgu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung f = new HamDungChung();
            f.ultragrdEmail_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Hidden = false;
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.Caption = "Trình Độ Ngoại Ngữ";
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Header.VisiblePosition = 1;
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["TrinhDoNgoaiNgu"].Width = 200;
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTrinhDoNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

        }
        #endregion

        #region Event

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTrinhDoNgoaiNgu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTrinhDoNgoaiNgu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

     
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            ultragrdTrinhDoNgoaiNgu.UpdateData();
            TrinhDoNgoaiNgu_bindingSource.EndEdit();
            list.ApplyEdit();
            list.Save();
            MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Load_Luoi();
            if (getData != null)
            {
                getData(list);
            }


        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnstrinhdongoainguAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTrinhdongoaingu(), new frmHienThiReport(), false);
        }
        #endregion

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTrinhDoNgoaiNgu);
        }

     
     
    }
}
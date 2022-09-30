using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using PSC_ERPNew.Main.Reports;

namespace PSC_ERPNew.Main.Reports
{
    public partial class frmReportPreviewer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        XtraReport _xtraReport;
        public frmReportPreviewer(DevExpress.XtraReports.UI.XtraReport xtraReport, String formTitle = null)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Text = formTitle;
            xtraReport.ExportOptions.PrintPreview.DefaultFileName = formTitle;
            this.printControl1.PrintingSystem = xtraReport.PrintingSystem;
            xtraReport.CreateDocument();
            _xtraReport = xtraReport;
        }
        private void btnRunDesigner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmReportDesigner frm = new frmReportDesigner(_xtraReport);
            frm.Show();
            this.Close();
        }
    }
}

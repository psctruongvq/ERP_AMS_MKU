using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using PSC_ERP_Business.Main.Model;


namespace PSC_ERPNew.Main.Reports
{
    public partial class frmFillReportInfo : Form
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        Report _rpt = null;
        DevExpress.XtraReports.UI.XtraReport _xtraReport = null;
        int _userId = 1;//tam thoi sd gia tri 1
        public frmFillReportInfo(String maPhanHe, Report rpt, DevExpress.XtraReports.UI.XtraReport xtraReport, String reportKey = "")
        {
            InitializeComponent();
            _rpt = rpt;
            _xtraReport = xtraReport;
            this.dteCreateDate.EditValue = DateTime.Today;
            txtKey.Text = reportKey;
            txtMaPhanHe.Text = maPhanHe;
        }

        private void frmThemMoiReport_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //kiem tra truoc khi luu
            Boolean duocPhepLuu = true;
            //kiem tra trung report key da ton tai truoc do
            duocPhepLuu = !PSC_ERP_Business.Main.Factory.Report_Factory.New().CheckContainReportKey(this.txtKey.Text.Trim());

            if (duocPhepLuu)
            {
                try
                {

                    String layoutPath = this.txtLayoutPath.Text.Trim();
                    if (layoutPath != "" && File.Exists(layoutPath))//neu chon tu layout co san
                    {
                        //load report layout da ton tai o dang file
                        _xtraReport.LoadLayout(layoutPath);
                    }

                    _xtraReport.Name = this.txtKey.Text.Trim();
                    //fill cac thong tin co ban
                    _rpt.ReportKey = this.txtKey.Text.Trim();
                    _rpt.ReportName = this.txtName.Text.Trim();
                    _rpt.DataSourceMethod = this.txtDataSourceMethod.Text.Trim();
                    _rpt.UserID = PSC_ERP_Global.Main.UserID;
                    _rpt.ModifiedDate = this.dteCreateDate.DateTime.Date;
                    _rpt.Idx = (int)this.numIdx.Value;
                    _rpt.MaPhanHe = this.txtMaPhanHe.Text.Trim();
                    _rpt.IsRoot = true;
                    //
                    using (MemoryStream stream = new MemoryStream())
                    {
                        //dua report mau layout vao MemoryStrem
                        _xtraReport.SaveLayout(stream);
                        //dua du layout bytes vao Entity Report
                        _rpt.ReportLayoutData = stream.ToArray();
                    }
                    //DialogResult is OK
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //tro ve form truoc, xu ly tiep
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra! Không lưu được");
                }
            }
            else
            { PSC_ERP_Common.DialogUtil.ShowError("Trùng key."); }


        }

        private void btnChooseLayout_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Xtra Report Layout File (*.repx)|*.repx|All File (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.txtLayoutPath.Text = dlg.FileName;
            }
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            //DialogResult is Cancel
            //DialogResult is OK
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //tro ve form truoc, xu ly tiep
            this.Close();
        }
    }
}

using System;
using DevExpress.XtraEditors;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.Parameters;
using System.Collections.Generic;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmReport : XtraForm
    {
        string Id = string.Empty;
        private int userid = 43;
        private DateTime denngay;
        private string tenphuongthuc = string.Empty;
        private int thuMuc = 0;
        private int soTTSapXep = 0;
        private string tenBaoCao = string.Empty;
        private XtraReport XReport = new XtraReport();
        private ReportTemplate objReport;
        public bool EditReport = false;

        public frmReport()
        {
            InitializeComponent();
        }

        public void HienThiReport(ReportTemplate item)
        {
            //XReport = Report;
            objReport = item;
            Id = objReport.Id;
            userid = objReport.UserID;
            denngay = DateTime.Today;
            OpenLayout(XReport, userid, denngay);
            tenphuongthuc = objReport.TenPhuongThuc;            
            printControl.PrintingSystem = XReport.PrintingSystem;
            XReport.CreateDocument();
        }

        public void HienThiReport(ReportTemplate item, DataSet dataset)
        {
            //XReport = Report;
            objReport = item;
            Id = objReport.Id;
            userid = objReport.UserID;
            denngay = DateTime.Today;
            OpenLayout(XReport, userid, denngay, dataset);
            tenphuongthuc = objReport.TenPhuongThuc;
            printControl.PrintingSystem = XReport.PrintingSystem;
            XReport.CreateDocument();
        }

        public void InTrucTiepReport(ReportTemplate item, DataSet dataset)
        {
            objReport = item;
            Id = objReport.Id;
            userid = objReport.UserID;
            denngay = DateTime.Today;
            OpenLayout(XReport, userid, denngay, dataset);
            tenphuongthuc = objReport.TenPhuongThuc;
            printControl.PrintingSystem = XReport.PrintingSystem;
            XReport.CreateDocument();
            XReport.Print();
        }

        /// <summary>
        /// OpenLayout report
        /// </summary>
        /// <param name="report"></param>
        private void OpenLayout(XtraReport report, int userid,  DateTime denngay)
        {
            if (objReport.Data == null)
                objReport = ERP_Library.ReportTemplate.GetReportTemplate(objReport.Id);
            if (objReport.Data != null)
            {
                //set Datasource cho report
                XReport.LoadLayout(new MemoryStream(objReport.Data));

                //ReportMain rptMain = new ReportMain();
                //XReport.DataSource = rptMain.FillDataTable(objReport.TenPhuongThuc);
            }
            //Hide panel parameter
            foreach (Parameter p in XReport.Parameters)
                p.Visible = false;

        }

        /// <summary>
        /// OpenLayout report
        /// </summary>
        /// <param name="report"></param>
        private void OpenLayout(XtraReport report, int userid, DateTime denngay, DataSet dataset)
        {
            if (objReport.Data == null)
                objReport = ERP_Library.ReportTemplate.GetReportTemplate(objReport.Id);
            if (objReport.Data != null)
            {
                //set Datasource cho report
                XReport.LoadLayout(new MemoryStream(objReport.Data));

                XReport.DataSource = dataset;
            }
            //Hide panel parameter
            foreach (Parameter p in XReport.Parameters)
                p.Visible = false;

        }

        /// <summary>
        /// Get report path
        /// </summary>
        /// <param name="fReport"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        private static string GetReportPath(XtraReport fReport, string ext)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string repName = fReport.Name;
            if (repName.Length == 0)
                repName = fReport.GetType().Name;
            string dirName = Path.GetDirectoryName(asm.Location);
            return Path.Combine(dirName, String.Format("{0}.{1}", repName, ext));
        }

        /// <summary>
        /// Show from design
        /// </summary>
        /// <param name="designForm"></param>
        /// <param name="parentForm"></param>
        private static void ShowDesignerForm(Form designForm, Form parentForm)
        {
            designForm.MinimumSize = parentForm.MinimumSize;
            if (parentForm.WindowState == FormWindowState.Normal)
                designForm.Bounds = parentForm.Bounds;
            designForm.WindowState = parentForm.WindowState;
            parentForm.Visible = false;
            designForm.ShowDialog();
            parentForm.Visible = true;
        }

        /// <summary>
        /// Desing report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesignReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string saveFileName = GetReportPath(XReport, "sav");
                XReport.PrintingSystem.ExecCommand(PrintingSystemCommand.StopPageBuilding);
                XReport.SaveLayout(saveFileName);
                ReportDesigner.MainForm designForm = new ReportDesigner.MainForm();
                designForm.OpenReport(XReport);
                designForm.ActiveXRDesignPanel.FileName = saveFileName;
                ShowDesignerForm(designForm, this.FindForm());
                if (designForm.ActiveXRDesignPanel.FileName != saveFileName && File.Exists(designForm.ActiveXRDesignPanel.FileName))
                    File.Copy(designForm.ActiveXRDesignPanel.FileName, saveFileName, true);
                designForm.Dispose();

                if (File.Exists(saveFileName))
                {
                    XReport.LoadLayout(saveFileName);
                    File.Delete(saveFileName);
                    XReport.CreateDocument(true);
                }
                File.Delete(saveFileName);

                EditReport = true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// Save layout report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Chắc chắn muốn lưu lại mẫu báo cáo này ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    thuMuc = objReport.ThuMuc;
                    tenBaoCao = objReport.TenBaoCao;
                    soTTSapXep = objReport.SoTTSapXep;
                    tenphuongthuc = objReport.TenPhuongThuc;

                    objReport = ERP_Library.ReportTemplate.GetReportTemplateExit(Id, userid, denngay);
                    if (objReport.Data != null && objReport.UserID==userid)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            XReport.SaveLayout(ms);
                            objReport.Data = ms.ToArray();
                            objReport.Save();
                            XtraMessageBox.Show("Báo cáo đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            objReport = ERP_Library.ReportTemplate.NewReportTemplate(Id, userid, denngay, tenphuongthuc, thuMuc, tenBaoCao, soTTSapXep);
                            XReport.SaveLayout(ms);

                            byte[] b=ms.ToArray();
                            objReport.Data = ms.ToArray();
                            objReport.Save();
                            XtraMessageBox.Show("Báo cáo đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    EditReport = false;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set default report design.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDefault_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show("Do you want to set default ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (objReport.Data != null)
                    {
                        objReport.Delete();
                        objReport.Save();
                        XtraMessageBox.Show("This report has been set default successful.", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EditReport)
            {
                if (MessageBox.Show(this, "Report chưa được lưu. Bạn có muốn lưu trước khi thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    btnSaveLayout.PerformClick();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;

namespace PSC_ERPNew.Main.Reports
{
    public class ReportHelper
    {
        public delegate DataSet ReportHelperDelegate();
        public static void ShowReport(String reportKey, ReportHelper.ReportHelperDelegate action, String maPhanHe, Boolean inList, Boolean onForm, Boolean designMode = false, Report report = null)
        {
            using (DialogUtil.Wait())
            {
                Report_Factory report_Factory = Report_Factory.New();

                XtraReport xtraReport = new XtraReport();//khoi tao


                if (report == null)
                {
                    if (!String.IsNullOrWhiteSpace(reportKey))
                        report = report_Factory.Get_Report_ByReportKey(reportKey, PSC_ERP_Global.Main.UserID);
                    if (report == null)
                    {
                        designMode = true;
                        report = report_Factory.CreateManagedObject();//new Report();
                        report.InList = inList;//report gắn trên list
                        report.OnForm = onForm;//report gắn trên form   

                        frmFillReportInfo frm = new frmFillReportInfo(maPhanHe, report, xtraReport, reportKey);
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)//chap nhan tao moi report
                        {
                            report_Factory.SaveChangesWithoutTrackingLog();//luu lai thay doi
                            DialogUtil.ShowInfo("Tạo và lưu báo cáo mới thành công, tiếp theo sẽ chuyển sang design");
                            xtraReport.Tag = new object[] { report, report_Factory };//dinh kem

                        }
                    }
                }
                else
                {
                    //Lấy lại đối tượng mới nhất (admin nếu admin mới nhất hoặc user nếu user mới nhất) không phụ thuộc vào factory cũ
                    report = report_Factory.Get_Report_ByReportKey(report.ReportKey, PSC_ERP_Global.Main.UserID);
                }

                /////////////////////////////////////
                if (report != null)
                {


                    if (report.ReportLayoutData != null)
                    {
                        //Load layout
                        MemoryStream newMemoryStream = new MemoryStream(report.ReportLayoutData);
                        xtraReport.LoadLayout(newMemoryStream);
                    }


                    //cung cap du lieu cho report
                    {
                        DataSet dataSet = new DataSet();
                        if (action != null)
                        {
                            dataSet = action.Invoke();
                        }
                        //bổ sung header and footer
                        using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
                        {

                            //tao bang_ReportHeaderAndFooter
                            using (SqlCommand cm = cn.CreateCommand())
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.CommandTimeout = 10 * 60;
                                cm.CommandText = "spd_ReportHeaderAndFooter";
                                cm.Parameters.AddWithValue("@MaNguoiLap", PSC_ERPNew.Main.BasicInfo.User.UserID);
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(dataSet, "ReportHeaderAndFooter");
                            }

                        }//
                        xtraReport.DataSource = dataSet;
                    }
                    //
                    xtraReport.Tag = new object[] { report, report_Factory };
                    //
                    //_xtraReport.CreateDocument();
                    //xem hoac thiet ke
                    if (!designMode)
                    {
                        frmReportPreviewer frm = new frmReportPreviewer(xtraReport, report.ReportName);
                        frm.Show();
                        //xtraReport.ShowPreview();//mo de xem
                    }
                    else
                    {

                        //_xtraReport.ShowDesigner();//mo thiet ke
                        frmReportDesigner frm = new frmReportDesigner(xtraReport);
                        frm.Show();
                    }
                }//
            }
        }//
        public static void ShowReportCustomNameFile(String nameFile, 
                                                    String reportKey, 
                                                    ReportHelper.ReportHelperDelegate action, 
                                                    String maPhanHe, 
                                                    Boolean inList, 
                                                    Boolean onForm, 
                                                    Boolean designMode = false, 
                                                    Report report = null)
        {
            using (DialogUtil.Wait())
            {
                Report_Factory report_Factory = Report_Factory.New();

                XtraReport xtraReport = new XtraReport();//khoi tao
                //xtraReport.Name = nameFile;
                xtraReport.DisplayName = nameFile;
                xtraReport.ExportOptions.PrintPreview.DefaultFileName = nameFile;
                if (report == null)
                {
                    if (!String.IsNullOrWhiteSpace(reportKey))
                        report = report_Factory.Get_Report_ByReportKey(reportKey, PSC_ERP_Global.Main.UserID);
                    if (report == null)
                    {
                        designMode = true;
                        report = report_Factory.CreateManagedObject();//new Report();
                        report.InList = inList;//report gắn trên list
                        report.OnForm = onForm;//report gắn trên form   

                        frmFillReportInfo frm = new frmFillReportInfo(maPhanHe, report, xtraReport, reportKey);
                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)//chap nhan tao moi report
                        {
                            report_Factory.SaveChangesWithoutTrackingLog();//luu lai thay doi
                            DialogUtil.ShowInfo("Tạo và lưu báo cáo mới thành công, tiếp theo sẽ chuyển sang design");
                            xtraReport.Tag = new object[] { report, report_Factory };//dinh kem

                        }
                    }
                }
                else
                {
                    //Lấy lại đối tượng mới nhất (admin nếu admin mới nhất hoặc user nếu user mới nhất) không phụ thuộc vào factory cũ
                    report = report_Factory.Get_Report_ByReportKey(report.ReportKey, PSC_ERP_Global.Main.UserID);
                }

                /////////////////////////////////////
                if (report != null)
                {
                    report.ReportName = nameFile;

                    if (report.ReportLayoutData != null)
                    {
                        //Load layout
                        MemoryStream newMemoryStream = new MemoryStream(report.ReportLayoutData);
                        xtraReport.LoadLayout(newMemoryStream);
                        
                    }


                    //cung cap du lieu cho report
                    {
                        DataSet dataSet = new DataSet();
                        if (action != null)
                        {
                            dataSet = action.Invoke();
                        }
                        //bổ sung header and footer
                        using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
                        {

                            //tao bang_ReportHeaderAndFooter
                            using (SqlCommand cm = cn.CreateCommand())
                            {
                                cm.CommandType = CommandType.StoredProcedure;
                                cm.CommandTimeout = 10 * 60;
                                cm.CommandText = "spd_ReportHeaderAndFooter";
                                cm.Parameters.AddWithValue("@MaNguoiLap", PSC_ERPNew.Main.BasicInfo.User.UserID);
                                SqlDataAdapter da = new SqlDataAdapter(cm);
                                da.Fill(dataSet, "ReportHeaderAndFooter");
                            }

                        }//
                        xtraReport.DataSource = dataSet;
                    }
                    //
                    xtraReport.Tag = new object[] { report, report_Factory };
                    //
                    //_xtraReport.CreateDocument();
                    //xem hoac thiet ke
                    if (!designMode)
                    {
                        frmReportPreviewer frm = new frmReportPreviewer(xtraReport, report.ReportName);
                        frm.Show();
                        //xtraReport.ShowPreview();//mo de xem
                    }
                    else
                    {

                        //_xtraReport.ShowDesigner();//mo thiet ke
                        frmReportDesigner frm = new frmReportDesigner(xtraReport);
                        frm.Show();
                    }
                }//
            }
        }//

    }
}

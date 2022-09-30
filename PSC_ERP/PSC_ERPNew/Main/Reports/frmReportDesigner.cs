using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;

namespace PSC_ERPNew.Main.Reports
{
    public partial class frmReportDesigner : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        DevExpress.XtraReports.UI.XtraReport _xtraReport;
        Object[] _tag = null;
        public frmReportDesigner(DevExpress.XtraReports.UI.XtraReport xtraReport)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            _xtraReport = xtraReport;
            _tag = (Object[])_xtraReport.Tag;//giu lien ket
            _xtraReport.Tag = null;

            this.xrDesignMdiController1.OpenReport(_xtraReport);
            // _xtraReport.PrintingSystem.ExecCommand(PrintingSystemCommand.StopPageBuilding);
            xrDesignMdiController1.ActiveDesignPanel.FileName = _xtraReport.Name + ".repx";//chi dinh ten file de khi save ko bat save dialog

            btnSave.ItemClick += btnSave_ItemClick;
        }


        private void btnGroupSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Save();

        }
        void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //save
            if (_tag != null)
            {
                if (DialogResult.Yes == MessageBox.Show(String.Format("Bạn muốn lưu report <{0}>?", _xtraReport.Name), "Hỏi ý kiến", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                {
                    Report reportOld = (Report)_tag[0];                  
                    //NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities db = (NPCSimpleReportStorage.Model.NPCSimpleReportStorageEntities)_tag[1];
                    Report_Factory factory = (Report_Factory)_tag[1];

                    using (MemoryStream m = new MemoryStream())
                    {
                        _xtraReport.SaveLayout(m);

                        //Nếu mà ngày lưu mới nhất khác với ngày lưu trước đó thì tạo mới mộ dòng dữ liệu
                        if (
                            (reportOld.ModifiedDate.Value.Date != app_users_Factory.New().SystemDateTime.Date

                            || (reportOld.ModifiedDate.Value.Date == app_users_Factory.New().SystemDateTime.Date
                                && reportOld.UserID != PSC_ERP_Global.Main.UserID
                            ))
                          )
                        {
                            //Khởi tạo factory mới
                            factory = Report_Factory.New();
                            //Khởi tạo report mới
                            Report reportNew = factory.CreateManagedObject();
                            reportNew.MaPhanHe = reportOld.MaPhanHe;
                            reportNew.ModifiedDate = app_users_Factory.New().SystemDateTime;
                            reportNew.Idx = reportOld.Idx;
                            reportNew.ReportKey = reportOld.ReportKey;
                            reportNew.UserID = PSC_ERP_Global.Main.UserID;
                            reportNew.Note = reportOld.Note;

                            //Lấy rootID
                            if (reportOld.RootID == null && reportOld.IsRoot == true)
                            {
                                reportNew.RootID = reportOld.ReportID;
                            }
                            else
                            {
                                reportNew.RootID = reportOld.RootID;
                            }
                           //Lấy parentID
                            reportNew.ParentID = reportOld.ReportID;

                            reportNew.DataSourceMethod = reportOld.DataSourceMethod;
                            reportNew.ReportName = reportOld.ReportName;
                            reportNew.Description = reportOld.Description;
                            reportNew.InList = reportOld.InList;
                            reportNew.OnForm = reportOld.OnForm;

                            //Lấy design mới nhất
                            reportNew.ReportLayoutData = m.ToArray();

                            //Lấy report mới nhất
                            _tag[0] = reportNew;
                            //Đổi factory mới
                            _tag[1] = factory;
                        }
                        else //Nếu cùng một ngày
                        {
                            //Lấy design mới nhất
                            reportOld.ReportLayoutData = m.ToArray();
                        }
                    }
                    factory.SaveChangesWithoutTrackingLog();
                    //factory.SaveChanges(BusinessCodeEnum.TSCD_Report.ToString());

                    MessageBox.Show("Đã lưu report");
                }

            }
        }
        void btnSaveAs_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //save as
        }
        private void btnSaveAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }


        private void btnChangeLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Xtra Report Layout File (*.repx)|*.repx|All File (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                //load report layout da ton tai o dang file

                _xtraReport.LoadLayout(dlg.FileName);

                foreach (Form item in this.MdiChildren)
                {
                    item.Close();
                }
                this.xrDesignMdiController1.OpenReport(_xtraReport);
                xrDesignMdiController1.ActiveDesignPanel.FileName = _xtraReport.Name + ".repx";//chi dinh ten file de khi save ko bat save dialog
                DialogUtil.ShowInfo("Hãy bấm nút Save bên trên để cập nhật thay đổi!");
            }
        }
    }
}

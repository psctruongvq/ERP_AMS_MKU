using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using System.Runtime.Remoting.Contexts;
using PSC_ERP_Business.Main.Factory;
using DevExpress.Office.Utils;
using System.Linq;
using PSC_ERP_Global;
using PSC_ERP_Util.Serialize;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace PSC_ERPNew.Main.Reports
{
    public partial class frmReportManager : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmReportManager singleton_ = null;
        public static frmReportManager Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmReportManager();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field
        IQueryable<app_users> _userList = null;
        List<Report> _reportList = null;
        IQueryable<Object> _maPhanHeList = null;
        app_users _userCurrent = null;
        string _maPhanHe = "";
        Boolean _loadXong = false;
        #endregion

        //Member Constructor
        #region Member Constructor


        public frmReportManager()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void GanBindingSource()
        {
            //
            appusersBindingSource.DataSource = _userList;
            //
            MaPhanHe_BindingSource.DataSource = _maPhanHeList;
        }

        private void ExportData()
        {
            //Thay đổi focus
            this.ChangeFocus();

            Boolean daChonReport = false;
            List<Report> reportExprotList = new List<Report>();

            foreach (Report item in _reportList)//Duyệt qua tất cả report
            {
                if (item.Chon == true) // Nếu đã chọn report
                {
                    daChonReport = true;

                    //Thêm vào danh sách report
                    reportExprotList.Add(item);
                }
            }

            if (daChonReport == false)
            {
                DialogUtil.ShowWarning("Chọn báo cáo cần [Export].");
                return;
            }

            //Tiến hành export dữ liệu
            try
            {

                using (SaveFileDialog dlg = new SaveFileDialog())
                {
                    dlg.Filter = "Report Data|*." + TSCD.BackupReportExtension.Trim() + "|All file|*.*";
                    dlg.AddExtension = true;

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        SerializeUtil.SerializeToXmlFile<List<Report>>(reportExprotList, dlg.FileName);

                        //Thông báo xuất dữ liệu thành công
                        DialogUtil.ShowSaveSuccessful("[Export] thành công.");
                    }
                }

            }
            catch (Exception ex)
            {
                //Thông báo xuất dữ liệu không thành công và xuất ra lỗi
                DialogUtil.ShowNotSaveSuccessful("[Export] không thành công " + ex.Message);
                return;
            }
        }

        private void ImportData()
        {
            try
            {
                if (_userCurrent == null) // Nếu user bằng null thì thoát
                    return;

                if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn có thật sự muốn Import dữ liệu cho user [" + _userCurrent.TenDangNhap.ToUpper() + "] không?"))
                {
                    using (OpenFileDialog dlg = new OpenFileDialog())
                    {
                        dlg.Filter = "Report Data|*." + TSCD.BackupReportExtension.Trim() + "|All file|*.*";
                        dlg.AddExtension = true;

                        if (dlg.ShowDialog() == DialogResult.OK)
                        {
                            _reportList = SerializeUtil.DeserializeFromXmlFile<List<Report>>(dlg.FileName);

                            if (_reportList != null)
                            {
                                //Khởi tạo factory
                                Report_Factory factory = Report_Factory.New();

                                //Tiến hành import dữ liệu
                                foreach (Report item in _reportList)
                                {
                                    //Lấy report mới nhất theo user và reportkey đã thêm vào database
                                    Report reportAdded = factory.Get_Report_ByReportKey(item.ReportKey, _userCurrent.UserID);

                                    // Nếu đã tồn tại report này trong database và ngày tạo bằng ngày tạo của report vừa import thì tiến hành cập nhật lại
                                    if (reportAdded != null && reportAdded.ModifiedDate.Value.Date == app_users_Factory.New().SystemDate.Date)//item.ModifiedDate.Value.Date)
                                    {
                                        reportAdded.DataSourceMethod = item.DataSourceMethod;
                                        reportAdded.ReportName = item.ReportName;
                                        if (item.Description != null)
                                            reportAdded.Description = item.Description;
                                        reportAdded.ReportLayoutData = item.ReportLayoutData;
                                        reportAdded.Note = item.Note;

                                    }
                                    else // Nếu không có trong database thì tiến hành thêm mới
                                    {
                                        //Khởi tạo đối tượng quản lý bởi factory
                                        Report reportNew = factory.CreateManagedObject();
                                        reportNew.MaPhanHe = item.MaPhanHe;
                                        reportNew.ModifiedDate = app_users_Factory.New().SystemDate.Date;
                                        reportNew.Idx = item.Idx;
                                        reportNew.ReportKey = item.ReportKey;
                                        reportNew.DataSourceMethod = item.DataSourceMethod;
                                        reportNew.ReportName = item.ReportName;
                                        reportNew.Description = item.Description;
                                        reportNew.InList = item.InList;
                                        reportNew.OnForm = item.OnForm;
                                        reportNew.ReportLayoutData = item.ReportLayoutData;
                                        reportNew.Note = item.Note;
                                        if (reportAdded == null)//Nếu không có report nào trong database
                                        {
                                            //Set isRoot
                                            reportNew.IsRoot = true;

                                            //Lấy admin
                                            app_users admin = app_users_Factory.New().Get_AppUserAdmin_PhucVuReport();
                                            //Set userID cho báo cáo
                                            reportNew.UserID = admin.UserID;
                                        }
                                        else // Nếu đã có report trong database rồi
                                        {
                                            //Lấy rootID cho report mới nhất
                                            if (reportAdded.RootID == null && reportAdded.IsRoot == true)
                                            {
                                                reportNew.RootID = reportAdded.ReportID;
                                            }
                                            else
                                            {
                                                reportNew.RootID = reportAdded.RootID;
                                            }

                                            //Lấy parentID cho report mới nhất
                                            reportNew.ParentID = reportAdded.ReportID;

                                            //Set userID cho báo cáo
                                            reportNew.UserID = _userCurrent.UserID;
                                        }
                                    }
                                }
                                //Tiến hành lưu dữ liệu
                                factory.SaveChangesWithoutTrackingLog();
                                //factory.SaveChanges(BusinessCodeEnum.TSCD_Report.ToString());
                            }
                            DialogUtil.ShowSaveSuccessful("[Import] thành công.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowNotSaveSuccessful("[Import] không thành công." + ex.Message);
                return;
            }

            //Load lại dữ liệu cho danh sách report
            LayDanhSachReport();

        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private void SetHeaderGridview_Report()
        {
            //Hiện thông báo danh sách report trên theo user
            gridView_Report.OptionsView.ShowGroupPanel = true; // Show header của lưới
            // gridView_Report.Appearance.GroupPanel.Options.UseFont = true; // Sử dụng font
            gridView_Report.Appearance.GroupPanel.Options.UseForeColor = true; // sử dụng màu chữ
            gridView_Report.Appearance.GroupPanel.Options.UseTextOptions = true; //sử dụng canh lề text của header
            gridView_Report.GroupPanelText = "Danh cách cáo cáo của user " + _userCurrent.TenDangNhap.ToUpper(); // Set tiêu đề của lưới
            // gridView_Report.Appearance.GroupPanel.Font = new Font("Time New Roman", 10, FontStyle.Regular); //Set font tiêu đề lưới
            gridView_Report.Appearance.GroupPanel.ForeColor = Color.SteelBlue; // Set màu tiêu đề lưới
            gridView_Report.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;//canh giữa text của header

        }
        #endregion

        //Event Method
        #region Event Method
        private void frmReportManager_Load(object sender, EventArgs e)
        {
            //Lấy mã phân hệ
            _maPhanHeList = Report_Factory.New().GetMaPhanHeList();
            //Lấy danh sach người dùng
            _userList = app_users_Factory.New().Get_DanhSachUser_PhucVuReportManager();


            //Set mã phân hệ mặc định khi load form
            cbMaPhanHe.EditValue = PSC_ERP_Global.TSCD.MaPhanHeTSCD;

            //Đưa checkbox lên lưới
            PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView_Report, colChon);

            // Set số thứ tự cho lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(gridView_UserList);
            PSC_ERP_Common.GridUtil.SetSTTForGridView(gridView_Report);

            //Đưa vào datasource
            this.GanBindingSource();

            ///////
            _loadXong = true;

        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void appusersBindingSource_CurrentChanged(object sender, EventArgs e)
        {


            LayDanhSachReport();

            //if (_loadXong)
            //{
            //    LayDanhSachReport();
            //}
        }

        private void LayDanhSachReport()
        {
            if (cbMaPhanHe.EditValue == null)//Nếu null thì return
                return;

            //Lấy mã phân hệ 
            _maPhanHe = cbMaPhanHe.EditValue.ToString();

            //Lấy người dùng hiện tại
            _userCurrent = appusersBindingSource.Current as app_users;

            if (_userCurrent == null)//Nếu null thì return
                return;

            //Lấy danh sách report theo user và mã phân hệ
            _reportList = Report_Factory.New().Get_DanhSachReportList_ByMaPhanHeAndUserID(_maPhanHe, _userCurrent.UserID).ToList();

            //Gán bindingSource
            this.reportBindingSource.DataSource = _reportList;

            //Cài đặt text cho hearder của lưới
            SetHeaderGridview_Report();
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Import dữ liệu
            this.ImportData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Export dữ liệu
            this.ExportData();
        }
        #endregion

        private void gridView_UserList_DoubleClick(object sender, EventArgs e)
        {
            //gridView_Report.OptionsView.ShowGroupPanel = false;
            //GridView gridView = sender as GridView;
            //GridHitInfo hi = gridView.CalcHitInfo(gridView.GridControl.PointToClient(Control.MousePosition));
            //if (hi.InRow)
            //{
            //    LayDanhSachReport();
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraScheduler;
using DevExpress.XtraEditors;

namespace PSC_ERP.Main
{
    public partial class frmKeHoachBaoTriBaoDuong : XtraForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Singleton
        #region Singleton
        private static frmKeHoachBaoTriBaoDuong singleton_ = null;
        public static frmKeHoachBaoTriBaoDuong Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmKeHoachBaoTriBaoDuong();
                return singleton_;
            }
        }

        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        //Private Member field
        #region Private Member field
        Project_Factory _factory = null;
        Project _project = null;
        int _projectID = 0;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmKeHoachBaoTriBaoDuong()
        {
            InitializeComponent();
        }
        public frmKeHoachBaoTriBaoDuong(int projectID)
        {
            InitializeComponent();
            //Lấy projectid hiện tại
            _projectID = projectID;
        }
        #endregion
        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (string.IsNullOrEmpty(_project.Name))
            {
                DialogUtil.ShowWarning("Nhập tên!");
                txtName.Focus();
                return duocPhepLuu = false;
            }
            return duocPhepLuu;
        }
        private Boolean Save()
        {
            txtBlackHole.Focus();
            //
            if (DuocPhepLuu())

                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        if (_factory.IsDirty)
                        {
                            _factory.SaveChangesWithoutTrackingLog();//lưu lại
                        }
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;//lưu thành công
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Không lưu được!\n" + ex.Message + "\n" + ex.InnerException);
                }
            return false;//lưu không thành công hoặc không được phép lưu
        }
        private void LoadData()
        {
            if (_projectID == 0)
            {
                //Thêm mới project
                Them();
            }
            else
            {
                _project = _factory.Get_ProjectByProjectID(_projectID);
            }
            //Gán bindingSource
            GanBindingSource();

            //Cài đặt caption của nút thêm resource
            SetButtonCaption();
        }
        private void Them()
        {
            //Khởi tạo factory mới
            _factory = Project_Factory.New();

            //Khởi tạo project mới
            _project = _factory.CreateManagedObject();
            _project.CreateDate = app_users_Factory.New().SystemDate;
            _project.UserID = PSC_ERP_Global.Main.UserID;
            //Cài đặt caption của nút thêm resource
            SetButtonCaption();
        }
        private void GanBindingSource()
        {
            taskBindingSource.DataSource = _project.Tasks;//_taskList;
            //
            taskDependencyBindingSource.DataSource = _project.TaskDependencies;
            //
            resourceBindingSource.DataSource = _project.Resources;
            //
            projectBindingSource.DataSource = _project;
            //
            projectEmployeeResourceBindingSource.DataSource = _project.ProjectEmployeeResources;
        }
        private void SetButtonCaption()
        {
            if (_project.Resources.Count > 0)
                btnThemResource.Caption = "Chỉnh sữa resource";
            else
                btnThemResource.Caption = "Thêm resource";
        }
        private void GetDataAppointmentLables()
        {
            //Lấy dữ liệu taskjob
            IQueryable<TaskJob> taskJobList = TaskJob_Factory.New().GetAll_SortTaskJobIndexAsc();

            {//
                this.schedulerStorageTask.Appointments.Labels.Clear();//Xóa tất cả dữ liệu mặc định
                foreach (TaskJob item in taskJobList)
                {
                    DevExpress.XtraScheduler.AppointmentLabel newLabel = null;
                    if (item.IntColor == null)
                    {
                        newLabel = new AppointmentLabel(System.Drawing.SystemColors.Window, item.Name, "&" + item.Name);
                    }
                    else
                    {
                        Color mausac = Color.FromArgb((Int32)item.IntColor);
                        newLabel = new AppointmentLabel(System.Drawing.Color.FromArgb(((int)(((byte)mausac.R))), ((int)(((byte)mausac.B))), ((int)(((byte)mausac.G)))), item.Name, "&" + item.Name);
                    }
                    //            
                    this.schedulerStorageTask.Appointments.Labels.Add(newLabel);
                }
            }
        }
        private void Xoa()
        {
            if (_project == null)
            {
                DialogUtil.ShowWarning("Project không tồn tại.");
                return;
            }

            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn thật sự muốn xóa project [" + _project.Name + "] ?"))
            {
                using (DialogUtil.WaitForDelete(this))
                {
                    //Xóa project
                    Project_Factory.FullDelete(_factory.Context, _project);
                    //Lưu dữ liệu
                    _factory.SaveChanges();
                }
                DialogUtil.ShowDeleteSuccessful();
                this.Close();
            }
        }
        private void DeleteProjectEmployeeResource()
        {
            //
            this.txtBlackHole.Focus();

            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewProjectEmployeeResource.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewProjectEmployeeResource.GetRow(index));
                        }
                        //
                        foreach (ProjectEmployeeResource item in deleteList)
                        {
                            Task task = null;
                            if (_project.Tasks != null)
                            {   //Lấy task
                                task = (from o in _project.Tasks
                                        where o.Task_Asset.Any(x => x.ProjectEmployeeResourceID == item.ID)
                                        select o).FirstOrDefault();
                            }
                            if (task != null)//Nếu có task thì không được xóa nhân viên này
                            {
                                DialogUtil.ShowError("Nhân viên [" + item.tblnsNhanVien.TenNhanVien + "] đã thực hiện công việc!.");
                                return;
                            }

                            //Xóa trong factory
                            ProjectEmployeeResource_Factory.FullDelete(_factory.Context, deleteList: item);
                            //
                            _project.ProjectEmployeeResources.Remove(item);
                        }
                    }
                    //Nếu không còn nhân viên project thì ẩn các tab thêm công việc đi
                    TabPageEnabled();
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                }
            }
        }
        private void DeleteChildResourceAll(Guid id)
        {
            List<PSC_ERP_Business.Main.Model.Resource> deleteList = (from o in _project.Resources where o.ParentID == id select o).ToList();

            foreach (PSC_ERP_Business.Main.Model.Resource item in deleteList)
            {
                //Gọi đệ qui
                DeleteChildResourceAll(item.ID);
                //
                _project.Resources.Remove(item);
            }
        }
        private void XoaTask(Task task)
        {
            //Xóa trong factory
            Task_Factory.FullDelete(_factory.Context, deleteList: task);

            //Xóa task            
            _project.Tasks.Remove(task);
            //
        }
        private void TabPageEnabled()
        {
            if (_project.ProjectEmployeeResources.Count > 0)
            {
                tabControlProject.TabPages[1].PageEnabled = true;//Dạng lịch
                tabControlProject.TabPages[2].PageEnabled = true;//Dạng lưới
            }
            else
            {
                tabControlProject.TabPages[1].PageEnabled = false;//Dạng lịch
                tabControlProject.TabPages[2].PageEnabled = false;//Dạng lưới
            }
            tabControlProject.Refresh();
        }
        private static void SetSchedulerMenuItem(DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            //
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {
                { //Xóa các item của popup menu mặc định không dùng nữa
                    // 
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
                    //
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
                    // 
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu);
                    //
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);
                    //
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleVisible);
                    //
                    e.Menu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleEnable);
                    //
                }

                //{//Ẩn Các popup menu mặc định không dùng nữa

                //    SchedulerMenuItem itemNewRecurringAppointment = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringAppointment);
                //    if (itemNewRecurringAppointment != null)
                //        itemNewRecurringAppointment.Visible = false;
                //    //
                //    SchedulerMenuItem itemNewRecurringEvent = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewRecurringEvent);
                //    if (itemNewRecurringEvent != null)
                //        itemNewRecurringEvent.Visible = false;
                //    //
                //    SchedulerMenuItem itemNewAllDayEvent = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAllDayEvent);
                //    if (itemNewAllDayEvent != null)
                //        itemNewAllDayEvent.Visible = false;
                //    //
                //    SchedulerMenuItem itemChangeTimelineScaleWidthUI = e.Menu.GetMenuItemById(SchedulerMenuItemId.SwitchViewMenu);
                //    if (itemChangeTimelineScaleWidthUI != null)
                //        itemChangeTimelineScaleWidthUI.Visible = false;
                //}

                {//Tìm và rename các sự kiện cần dùng

                    SchedulerMenuItem itemNewAppointment = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
                    if (itemNewAppointment != null) itemNewAppointment.Caption = "Thêm công việc";
                    //
                    SchedulerMenuItem itemGotoToday = e.Menu.GetMenuItemById(SchedulerMenuItemId.GotoToday);
                    if (itemGotoToday != null) itemGotoToday.Caption = "Đến ngày hiện tại";
                    //
                    SchedulerMenuItem itemGotoDate = e.Menu.GetMenuItemById(SchedulerMenuItemId.GotoDate);
                    if (itemGotoDate != null) itemGotoDate.Caption = "Đến ngày...?";
                    //
                }

                //{//Tạo mới và thêm sự kiện vào
                //     ISchedulerCommandFactoryService service =
                //         (ISchedulerCommandFactoryService)schedulerControl1.GetService(typeof(ISchedulerCommandFactoryService));
                //         SchedulerCommand cmd = service.CreateCommand(SchedulerCommandId.SwitchToGroupByResource);
                //         SchedulerMenuItemCommandWinAdapter menuItemCommandAdapter =
                //             new SchedulerMenuItemCommandWinAdapter(cmd);
                //         DXMenuItem menuItem = (DXMenuItem)menuItemCommandAdapter.CreateMenuItem();
                //         menuItem.BeginGroup = true;
                //         e.Menu.Items.Add(menuItem);

                //         // Insert a new item into the Scheduler popup menu and handle its click event.
                //         e.Menu.Items.Add(new SchedulerMenuItem("Click me!", MyClickHandler));

                // public void MyClickHandler(object sender, EventArgs e)
                // {
                //     MessageBox.Show("My Menu Item Clicked!");
                // }
                // }
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmKeHoachBaoTriBaoDuong_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Khởi tạo factory
                _factory = Project_Factory.New();

                //Load dữ liệu
                LoadData();

                //Lấy dữ liệu cho storage appointment labels(Lấy công việc của task)
                GetDataAppointmentLables();

                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, false, false, gridView_Task);

                //Xóa Task_ProjectEmployeeResource bằng control
                GridUtil.DeleteHelper.Setup_ManualType(grdViewProjectEmployeeResource, (GridView gridView, List<Object> deleteList) =>
                {
                    //
                    foreach (ProjectEmployeeResource item in deleteList)
                    {
                        Task task = null;
                        if (_project.Tasks != null)
                        {   //Lấy task
                            task = (from o in _project.Tasks
                                    where o.Task_Asset.Any(x => x.ProjectEmployeeResourceID == item.ID)
                                    select o).FirstOrDefault();
                        }
                        if (task != null)//Nếu có task thì không được xóa nhân viên này
                        {
                            DialogUtil.ShowError("Nhân viên [" + item.tblnsNhanVien.TenNhanVien + "] đã thực hiện công việc!.");
                            return;
                        }

                        //Xóa trong factory
                        ProjectEmployeeResource_Factory.FullDelete(_factory.Context, deleteList: item);
                        //
                        _project.ProjectEmployeeResources.Remove(item);
                    }

                    //Nếu đã xóa hết nhân viên project thì ân các tab thêm task đi
                    TabPageEnabled();
                });

                //Set thời gian xuất hiện trên form của schedule
                schedulerTask.Start = app_users_Factory.New().SystemDate;
                //Set cây
                TreeList_Resource.ExpandAll();
                //Cho phép nhập task
                TabPageEnabled();
            };
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void frmKeHoachBaoTriBaoDuong_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }
        private void resTreeList_Resource_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu.ShowPopup(Control.MousePosition);
            }
        }
        private void btnThemResource_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
            using (frmDialogResource frm = new frmDialogResource(_project.Resources.ToList()))
            {
                if (frm.ShowDialog(this) == DialogResult.Yes)
                {
                    //Thêm resource vừa thêm mới vào project.Resources
                    foreach (PSC_ERP_Business.Main.Model.Resource item in frm.ResourceList)
                    {
                        if (!_project.Resources.Any(x => Object.ReferenceEquals(x, item) == true) && item.ID != Guid.Empty)
                        {
                            _project.Resources.Add(item);
                        }
                    }
                    //Bỏ những resource đã xóa ra project.Resources
                    {
                        List<object> deletedList = new List<object>();

                        foreach (PSC_ERP_Business.Main.Model.Resource item in _project.Resources)
                        {
                            if (item.ParentID == Guid.Empty) // Set lại parent cho các resource là con của root
                                item.ParentID = null;

                            if (!frm.ResourceList.Any(x => Object.ReferenceEquals(x, item) == true))//Tìm 
                            {
                                //Đưa vào danh sách cần xóa
                                deletedList.Add(item);
                            }
                        }
                        //Tiến hành xóa
                        foreach (PSC_ERP_Business.Main.Model.Resource item in deletedList)
                        {
                            //Xóa trong factory
                            Resource_Factory.FullDelete(_factory.Context, deleteList: item);
                            //Xóa các con của resource
                            DeleteChildResourceAll(item.ID);
                            //Xóa resource 
                            _project.Resources.Remove(item);
                        }
                    }
                    {//Set caption của nút thêm resource
                        SetButtonCaption();
                    }
                    //Refesh lại cây
                    TreeList_Resource.RefreshDataSource();
                    TreeList_Resource.ExpandAll();
                }
            }
        }

        private void btnTimChonNhanVien_Click(object sender, EventArgs e)
        {
            using (frmDialogTimChonNhanVien frm = new frmDialogTimChonNhanVien(_project))
            {//show form tìm chọn nhân viên

                if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (tblnsNhanVien item in frm.NhanVienDuocChonList)
                    {
                        ProjectEmployeeResource projectEmployeeResource = (from o in _project.ProjectEmployeeResources
                                                                           where o.EmployeeID == item.MaNhanVien
                                                                           select o).SingleOrDefault();
                        if (projectEmployeeResource == null)
                        {
                            ProjectEmployeeResource projectEmployeeResourceNew = ProjectEmployeeResource_Factory.New().CreateAloneObject();
                            projectEmployeeResourceNew.EmployeeID = item.MaNhanVien;
                            //
                            _project.ProjectEmployeeResources.Add(projectEmployeeResourceNew);
                        }
                    }
                    //Cho phép nhập task
                    TabPageEnabled();
                }
            }
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tiến hành lưu dữ liệu
            Save();
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Tiến hành xóa project
            Xoa();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm mới ptoject
            Them();
            //GánbindingSource
            this.GanBindingSource();
        }
        private void btnThemTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_project.Resources.Count == 0)
            {
                DialogUtil.ShowWarning("Thêm nhóm công việc!");
                return;
            }

            //Thêm task mới
            using (frmChiTietCongViec frm = new frmChiTietCongViec(_factory, _project))
            {//show form task
                if (frm.ShowDialog(this) == DialogResult.No)
                {
                    //Xóa task
                    XoaTask(frm.CurrentTask);
                }
            }
        }
        private void TreeList_Resource_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu.ShowPopup(Control.MousePosition);
            }
        }
        private void gridControl_Task_DoubleClick(object sender, EventArgs e)
        {
            //Lấy task hiện tại
            Task currentTask = taskBindingSource.Current as Task;

            //Thêm task mới
            using (frmChiTietCongViec frm = new frmChiTietCongViec(_factory, _project, currentTask))
            {//show form task
                if (frm.ShowDialog(this) == DialogResult.No)
                {
                    //Xóa task
                    XoaTask(frm.CurrentTask);
                }
            }
        }
        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            //Xóa nhân viên ra khỏi project
            DeleteProjectEmployeeResource();
        }
        private void btnTaskReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_project == null)
            {
                DialogUtil.ShowWarning("Vẫn chưa có kế hoạch bào trì nào?");
                return;
            };
            using (frmKeHoachBaoTriBaoDuongBaoCao frm = new frmKeHoachBaoTriBaoDuongBaoCao(new List<Project> { _project }))
            {//show form task
                frm.ShowDialog(this);
            }
        }
        private void btnDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //
            frmDSKeHoachBaoTriBaoDuong.ShowSingleton(null, this.MdiParent);
        }
        private void schedulerTask_PopupMenuShowing(object sender, DevExpress.XtraScheduler.PopupMenuShowingEventArgs e)
        {
            //
            SetSchedulerMenuItem(e);
        }
        private void schedulerTask_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            //Tắt form mặc định của schduler
            e.Handled = true;
            if (_project.Resources.Count == 0)
            {
                DialogUtil.ShowWarning("Thêm nhóm công việc!");
                return;
            }
            //Lấy resourid hiện tại
            object currentResourceId = e.Appointment.ResourceId ;
            //
           SchedulerControl scheduler = ((SchedulerControl)(sender));

            Appointment app = null;
            if (string.IsNullOrEmpty(e.Appointment.Subject))
            {
                // Delete all appointments.
                scheduler.Storage.Appointments.Clear();
                // Select time interval
                scheduler.ActiveView.SetSelection(new TimeInterval(DateTime.Now, TimeSpan.FromDays(1)), scheduler.ActiveView.GetResources()[1]);
                // Group by resource.
                scheduler.GroupType = SchedulerGroupType.Resource;
                // Create a new appointment.
                app = scheduler.Storage.CreateAppointment(AppointmentType.Normal);
                // Set the appointment's time interval to the selected time interval.
                app.Start = app_users_Factory.New().SystemDate;
                app.End = app_users_Factory.New().SystemDate;
                // Set the appointment's resource to the resource which contains
                // the currently selected time interval.
                app.ResourceId = scheduler.SelectedResource.Id;
                // Add the new appointment to the appointment collection.
                scheduler.Storage.Appointments.Add(app);                
            }
            else
            {
                app = e.Appointment;
            }
            //Lấy task hiện tại
            Task currentTask = app.GetSourceObject(scheduler.Storage) as Task;
            //Lấy resource hiện tại đưa vào task
            if (currentTask.Resource == null && currentTask.ResourceID != Guid.Empty)
            {
                PSC_ERP_Business.Main.Model.Resource resource = (from o in _project.Resources
                                                                 where o.ID == currentTask.ResourceID
                                                                 select o).SingleOrDefault();
                if (resource != null)
                    currentTask.Resource = resource;
            }
            //

            //Thêm task mới
            using (frmChiTietCongViec frm = new frmChiTietCongViec(_factory, _project, currentTask))
            {//show form task
                if (frm.ShowDialog(this) == DialogResult.No)
                {
                    //Xóa task
                    XoaTask(frm.CurrentTask);
                }
            }
            //frmDefaultTask form = new frmDefaultTask(scheduler, app, e.OpenRecurrenceForm, _factory, _project, currentTask, currentResource);
            //try
            //{
            //    if (form.ShowDialog(this) == DialogResult.OK)
            //    {
            //        //Đưa task vào project
            //        _project.Tasks.Add(form.CurrentTask);
            //    }
            //    else
            //    {
            //        //Xóa task trong factory
            //        Task_Factory.FullDelete(_factory.Context, deleteList: form.CurrentTask);
            //    }
            //    e.Handled = true;
            //}
            //finally
            //{
            //    form.Dispose();
            //}

        }     
        #endregion


    }
}

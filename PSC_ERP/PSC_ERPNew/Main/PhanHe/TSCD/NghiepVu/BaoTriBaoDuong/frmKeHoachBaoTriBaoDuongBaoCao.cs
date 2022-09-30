using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using PSC_ERP_Business.Main.Model;
using DevExpress.XtraNavBar;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Business.Main.Predefined;

namespace PSC_ERP.Main
{
    public partial class frmKeHoachBaoTriBaoDuongBaoCao : RibbonForm
    {

        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Singleton
        #region Singleton
        private static frmKeHoachBaoTriBaoDuongBaoCao singleton_ = null;
        public static frmKeHoachBaoTriBaoDuongBaoCao Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmKeHoachBaoTriBaoDuongBaoCao();
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
        List<Project> _projectList = null;
        Project _selectedProject = null;
        Resource _selectedResource = null;
        Task _selectedTask = null;
        int _reportType = 0;
        Boolean _daLoadXong = false;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmKeHoachBaoTriBaoDuongBaoCao()
        {
            InitializeComponent();
        }
        public frmKeHoachBaoTriBaoDuongBaoCao(List<Project> projectList)
        {
            InitializeComponent();
            //
            _projectList = projectList;
        }
        #endregion
        //Private Member Function
        #region Private Member Function
        private void SetDataToTreeList()
        {
            //Thêm node root cho cây danh mục
            TreeListNode rootNode = null;
            rootNode = ProjectTreeList.AppendNode(new object[] { "Tất cả kế hoạch" }, rootNode);
            rootNode.Tag = new ProjectReportTreeNodeTagInfo() { NodeType = ProjectReportTreeNodeEnum.Project };
            ProjectTreeList.ExpandAll();
            //
            foreach (Project item in _projectList)
            {
                TreeListNode projectNode = null;
                projectNode = ProjectTreeList.AppendNode(new object[] { item.Name }, rootNode);
                projectNode.Tag = new ProjectReportTreeNodeTagInfo() { NodeType = ProjectReportTreeNodeEnum.Project, NodeObject = item };//item;
                ProjectTreeList.ExpandAll();
                //Thêm reourcre
                AddChildNodeOfProject(item.Resources.ToList(), projectNode);
            }
        }
        private void AddChildNodeOfProject(List<Resource> resourceList, TreeListNode projectNode)
        {
            foreach (Resource item in resourceList)
            {
                TreeListNode resourceNode = null;
                resourceNode = ProjectTreeList.AppendNode(new object[] { item.Description }, projectNode);
                resourceNode.Tag = new ProjectReportTreeNodeTagInfo() { NodeType = ProjectReportTreeNodeEnum.Resource, NodeObject = item };//item;;
                ProjectTreeList.ExpandAll();
                //Thêm task
                AddChildNodeOfResource(item.Tasks.ToList(), resourceNode);
            }
        }
        private void AddChildNodeOfResource(List<Task> taskList, TreeListNode resourceNode)
        {
            foreach (Task item in taskList)
            {
                TreeListNode taskNode = null;
                taskNode = ProjectTreeList.AppendNode(new object[] { item.Subject }, resourceNode);
                taskNode.Tag = new ProjectReportTreeNodeTagInfo() { NodeType = ProjectReportTreeNodeEnum.Task, NodeObject = item };//item;;
                ProjectTreeList.ExpandAll();
                //
            }
        }
        private void SetDataToNavBarMenu(NavBarControl navBarMenu, Project project)
        {
            {//NavBarGroup Kế hoạch bảo trì

                NavBarGroup navBarGroup = new NavBarGroup();
                navBarGroup.Appearance.Options.UseFont = true;
                navBarGroup.Appearance.Options.UseForeColor = true;
                navBarGroup.Appearance.Options.UseTextOptions = true;
                navBarGroup.Caption = "Kế Hoạch Bảo Trì";
                navBarGroup.Appearance.ForeColor = Color.SteelBlue;
                navBarGroup.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                navBarGroup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                navBarGroup.Expanded = true;
                //
                NavBarItem navBarItem = new NavBarItem();
                navBarItem.Caption = project.Name;
                navBarItem.Appearance.ForeColor = Color.SteelBlue;
                navBarItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                navBarItem.Tag = _projectList;
                navBarItem.LinkClicked += navBarItem_LinkClicked;
                //Đưa vào group
                navBarGroup.ItemLinks.Add(navBarItem);
                //Đưa vào navBarMenu
                navBarMenu.Groups.Add(navBarGroup);
            }
            {//NavBarGroup Nhóm công việc

                NavBarGroup navBarGroup = new NavBarGroup();
                navBarGroup.Appearance.Options.UseFont = true;
                navBarGroup.Appearance.Options.UseForeColor = true;
                navBarGroup.Appearance.Options.UseTextOptions = true;
                navBarGroup.Caption = "Nhóm Công Việc";
                navBarGroup.Appearance.ForeColor = Color.SteelBlue;
                navBarGroup.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                navBarGroup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                navBarGroup.Expanded = true;
                //
                foreach (Resource item in project.Resources)
                {
                    NavBarItem navBarItem = new NavBarItem();
                    navBarItem.Caption = item.Description;
                    navBarItem.Appearance.ForeColor = Color.SteelBlue;
                    navBarItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    navBarItem.Tag = item;
                    navBarItem.LinkClicked += navBarItem_LinkClicked;
                    //Đưa vào group
                    navBarGroup.ItemLinks.Add(navBarItem);
                }
                //Đưa vào navBarMenu
                navBarMenu.Groups.Add(navBarGroup);
            }
            {//NavBarGroup công việc

                NavBarGroup navBarGroup = new NavBarGroup();
                navBarGroup.Appearance.Options.UseFont = true;
                navBarGroup.Appearance.Options.UseForeColor = true;
                navBarGroup.Appearance.Options.UseTextOptions = true;
                navBarGroup.Caption = "Công Việc";
                navBarGroup.Appearance.ForeColor = Color.SteelBlue;
                navBarGroup.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
                navBarGroup.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                navBarGroup.Expanded = true;
                foreach (Task item in project.Tasks)
                {
                    NavBarItem navBarItem = new NavBarItem();
                    navBarItem.Caption = item.Subject;
                    navBarItem.Appearance.ForeColor = Color.SteelBlue;
                    navBarItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    navBarItem.Tag = item;
                    navBarItem.LinkClicked += navBarItem_LinkClicked;
                    //Đưa vào group
                    navBarGroup.ItemLinks.Add(navBarItem);
                }
                //Đưa vào navBarMenu
                navBarMenu.Groups.Add(navBarGroup);
            }
        }
        private Series CreateSeries(string title, ViewType type, string dataMember, string valueMember)
        {
            //Khởi tạo
            Series series = new Series(title, type);
            series.Label.PointOptions.PointView = PointView.ArgumentAndValues;
            series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            //
            series.ArgumentDataMember = dataMember;
            series.ValueDataMembers.AddRange(new string[] { valueMember });

            return series;
        }
        private void SetChartControl(BindingSource bindingSource, Int32 reportType, string dataMember, string valueMember, string title)
        {
            {//Refesh lại datasource
                txtBlackHole.Focus();
                chartProjectReport.DataSource = null;
                chartProjectReport.Update();
            }
            {//Thêm Series vào chartcontrol

                //Xóa Series mặc định
                chartProjectReport.Series.Clear();

                if (reportType == (Int32)LoaiBaoCaoDuAnEnum.Task || reportType == (Int32)LoaiBaoCaoDuAnEnum.Employee)
                {
                    //Khởi tạo một Series
                    Series series = CreateSeries("Tỉ lệ(%)", ViewType.Bar, dataMember, valueMember);

                    //Thêm vào chartControl
                    chartProjectReport.Series.Add(series);
                }
                else if (reportType == (Int32)LoaiBaoCaoDuAnEnum.Asset)
                {
                    //Khởi tạo Series
                    Series series1 = CreateSeries("Hoàn thành", ViewType.StackedBar, dataMember, "AmountComplete");//Set cứng valueMember khi thay đổi phải sữa
                    //series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;//Ẩn tên của series1

                    Series series2 = CreateSeries("Chưa hoàn thành", ViewType.StackedBar, dataMember, "AmountNotComplete"); //Set cứng valueMember khi thay đổi phải sữa
                    //series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False; //Ẩn tên của series1

                    //Độ rộng của series1
                    //StackedBarSeriesView myView =((StackedBarSeriesView)series1.View);
                    //myView.BarWidth = 0.8;

                    //Thêm vào chartControl
                    chartProjectReport.Series.AddRange(new Series[] { series1, series2 });
                }
                else
                {
                    //Chưa biết
                }
            }
            {//Lấy tiêu đề 

                //Xóa tiêu đề cũ
                chartProjectReport.Titles.Clear();
                //
                ChartTitle chartTitle = new ChartTitle();
                chartTitle.Text = title;
                chartProjectReport.Titles.Add(chartTitle);
            }
            //
            //Gán vào bindingSource
            chartProjectReport.DataSource = bindingSource;
        }
        private void navBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Khởi tạo 
            Project project = null;
            Resource resource = null;
            Task task = null;
            //Lấy dữ liệu
            NavBarItem mn = (NavBarItem)sender;

            //Lấy project
            try
            {
                if (mn.Tag != null)
                    project = (Project)mn.Tag;
            }
            catch (Exception ex) { }

            //Lấy resource
            try
            {
                if (mn.Tag != null)
                    resource = (Resource)mn.Tag;
            }
            catch (Exception ex) { }

            //Lấy task
            if (mn.Tag != null)
                task = (Task)mn.Tag;

            //////////////////////Báo cáo////////////////////////////////

            if (project != null)//Báo cáo phần trăm hoàn tất công việc theo project
            {
                //Lấy danh sách task theo project
                List<Task> taskList = project.Tasks.ToList();
                //Gán bingdingSource
                taskBindingSource.DataSource = taskList;

                //Cài đặt chart control
                SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + project.Name + "]");
            }
            if (resource != null)//Báo cáo phần trăm hoàn tất công việc theo reosure
            {
                //Lấy danh sách task theo project
                List<Task> taskList = resource.Tasks.ToList();
                //Gán bingdingSource
                taskBindingSource.DataSource = taskList;

                //Cài đặt chart control
                SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + resource.Description + "]");
            }
            if (task != null)///Báo cáo phần trăm hoàn tất theo công việc
            {
                //Gán bingdingSource
                taskBindingSource.DataSource = task;

                //Cài đặt chart control
                SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + task.Subject + "]");
            }
        }
        private void ProjectReportView()
        {
            //
            if (_selectedProject != null)
            {
                //Báo cáo hoàn thành công việc theo project
                TaskOfProjectReport(_selectedProject);

            }
            else if (_selectedResource != null)
            {
                //Báo cáo hoàn thành công việc theo resource
                TaskOfResourceReport(_selectedResource);
            }
            else if (_selectedTask != null)
            {
                //Hoàn thành công việc theo task
                TaskReport(_selectedTask);
            }
            else
            {
                //Hoàn thành công việc theo tất cả project
                TaskOfProjectReportAll(_projectList);
            }
        }
        private void TaskOfProjectReportAll(List<Project> projectList)
        {
            switch (_reportType)
            {
                case (int)LoaiBaoCaoDuAnEnum.Task://Công việc

                    List<Task> taskList_Project = new List<Task>();
                    foreach (Project item in projectList)
                    {
                        //Lấy danh sách task theo project
                        List<Task> taskList = item.Tasks.ToList();

                        foreach (Task itemTask in taskList)
                        {
                            if (!taskList_Project.Any(x => Object.ReferenceEquals(x, itemTask) == true))
                            {
                                taskList_Project.Add(itemTask);
                            }
                        }
                    }
                    //Gán bingdingSource
                    taskBindingSource.DataSource = taskList_Project;

                    //Cài đặt chart control
                    SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành tất cả kế hoạch");

                    break;
                case (int)LoaiBaoCaoDuAnEnum.Employee://Nhân viên

                    //Lấy danh sách nhân viên đã hoàn thành công việc của tất cả project
                    List<tblnsNhanVien> nhanVienList = GetPercentCompletedOfEmployeeList_ProjectAll(projectList);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành tất cả kế hoạch");
                    break;

                case (int)LoaiBaoCaoDuAnEnum.Asset://Tài sản cố định

                    //Lấy danh sách nhân viên và số lượng tài sản đã hoàn thành của nhân viên theo tất cả project
                    List<tblnsNhanVien> nhanVienList_Asset = GetAmountAssetOfEmployeeList_ProjectAll(projectList);
                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList_Asset;
                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành tất cả kế hoạch");
                    break;
                default:
                    chartProjectReport.DataSource = null;
                    break;
            }

        }
        private void TaskOfProjectReport(Project project)
        {
            switch (_reportType)
            {
                case (int)LoaiBaoCaoDuAnEnum.Task://Công việc

                    //Lấy danh sách task theo project
                    List<Task> taskList = project.Tasks.ToList();
                    //Gán bingdingSource
                    taskBindingSource.DataSource = taskList;

                    //Cài đặt chart control
                    SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + project.Name + "]");

                    break;
                case (int)LoaiBaoCaoDuAnEnum.Employee://Nhân viên

                    //Lấy danh sách nhân viên đã hoàn thành công việc của project
                    List<tblnsNhanVien> nhanVienList = GetPercentCompletedOfEmployeeList_Project(project);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành [" + project.Name + "]");
                    break;

                case (int)LoaiBaoCaoDuAnEnum.Asset://Tài sản cố định

                    //Lấy danh sách nhân viên và số lượng tài sản đã hoàn thành của nhân viên 
                    List<tblnsNhanVien> nhanVienList_Asset = GetAmountAssetOfEmployeeList_Project(project);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList_Asset;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành [" + project.Name + "]");

                    break;
                default:
                    chartProjectReport.DataSource = null;
                    break;
            }

        }
        private void TaskOfResourceReport(Resource resource)
        {
            switch (_reportType)
            {
                case (int)LoaiBaoCaoDuAnEnum.Task://Công việc

                    //Lấy danh sách task theo project
                    List<Task> taskList = resource.Tasks.ToList();
                    //Gán bingdingSource
                    taskBindingSource.DataSource = taskList;

                    //Cài đặt chart control
                    SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + resource.Description + "]");
                    break;

                case (int)LoaiBaoCaoDuAnEnum.Employee://Nhân viên

                    //Lấy danh sách nhân viên đã hoàn thành công việc của resource
                    List<tblnsNhanVien> nhanVienList = GetPercentCompletedOfEmployeeList_Reource(resource);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành [" + resource.Description + "]");
                    break;

                case (int)LoaiBaoCaoDuAnEnum.Asset://Tài sản cố định

                    //Lấy danh sách nhân viên và số lượng tài sản đã hoàn thành của nhân viên theo resource
                    List<tblnsNhanVien> nhanVienList_Asset = GetAmountAssetOfEmployeeList_Resource(resource);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList_Asset;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành [" + resource.Description + "]");

                    break;
                default:
                    chartProjectReport.DataSource = null;
                    break;
            }

        }
        private void TaskReport(Task task)
        {
            switch (_reportType)
            {
                case (int)LoaiBaoCaoDuAnEnum.Task://Công việc

                    //Gán bingdingSource
                    taskBindingSource.DataSource = task;

                    //Cài đặt chart control
                    SetChartControl(taskBindingSource, _reportType, "Subject", "PercentComplete", "Tiến độ hoàn thành [" + task.Subject + "]");

                    break;
                case (int)LoaiBaoCaoDuAnEnum.Employee://Nhân viên

                    //Lấy danh sách nhân viên đã hoàn thành công việc của task
                    List<tblnsNhanVien> nhanVienList_PercentCompleted = GetPercentCompletedOfEmployeeList_Task(task);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList_PercentCompleted;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "PercentComplete", "Tiến độ hoàn thành [" + task.Subject + "]");

                    break;
                case (int)LoaiBaoCaoDuAnEnum.Asset://Tài sản cố định

                    //Lấy danh sách nhân viên và số lượng tài sản đã hoàn thành của nhân viên 
                    List<tblnsNhanVien> nhanVienList_Asset = GetAmountAssetOfEmployeeList_Task(task);

                    //Gán bingdingSource
                    nhanVienBindingSource.DataSource = nhanVienList_Asset;

                    //Cài đặt chart control
                    SetChartControl(nhanVienBindingSource, _reportType, "TenNhanVien", "", "Tiến độ hoàn thành [" + task.Subject + "]");

                    break;
                
                default:
                    chartProjectReport.DataSource = null;
                    break;

            }

        }
        private List<tblnsNhanVien> GetPercentCompletedOfEmployeeList_ProjectAll(List<Project> projectList)
        {
            List<tblnsNhanVien> nhanVienList_ProjectAll = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của porject

                foreach (Project itemProject in projectList)
                {
                    foreach (Task itemTask in itemProject.Tasks)
                    {
                        //Lấy danh sách nhân viên của task
                        List<tblnsNhanVien> nhanVienList_Task = (from o in itemTask.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                        foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                        {
                            tblnsNhanVien nhanVien = (from o in nhanVienList_ProjectAll
                                                 where o.MaNhanVien == itemNhanVien.MaNhanVien
                                                 select o).SingleOrDefault();
                            if (nhanVien == null)
                            {
                                //
                                nhanVienList_ProjectAll.Add(itemNhanVien);
                            }
                        }
                    }
                }
            }
            {//Tính phần trăm hoàn tất của nhân viên

                foreach (tblnsNhanVien itemNhanVien in nhanVienList_ProjectAll)
                {
                    decimal tongTaiSan = 0;
                    decimal soLuongHoanTat = 0;
                    decimal phanTramHoanTat = 0;

                    //Duyệt qua các task của porject All
                    foreach (Project itemProject in projectList)
                    {
                        foreach (Task itemTask in itemProject.Tasks)
                        {
                            //Lấy tổng số tài sản của nhân viên trong task
                            tongTaiSan += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                           select o).Count();
                            //Lấy số tài sản mà nhân viên đó đã hoàn thành
                            soLuongHoanTat += (from o in itemTask.Task_Asset
                                               where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                     && o.Completed == true
                                               select o).Count();
                        }

                        //Tính phần trăm hoàn tất
                        if (tongTaiSan > 0)
                        {
                            phanTramHoanTat = Math.Round(((soLuongHoanTat / tongTaiSan) * 100));
                        }
                        else
                        {
                            phanTramHoanTat = 0;
                        }
                        //
                        if (soLuongHoanTat > tongTaiSan)
                        {
                            phanTramHoanTat = 100;
                        }
                    }
                    //Cập nhật phần trăm hoàn tất của nhân viên
                    itemNhanVien.PercentComplete = (int)phanTramHoanTat;
                }
            }
            return nhanVienList_ProjectAll;
        }
        private List<tblnsNhanVien> GetPercentCompletedOfEmployeeList_Project(Project project)
        {
            List<tblnsNhanVien> nhanVienList_Project = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của porject

                foreach (Task itemTask in project.Tasks)
                {
                    //Lấy danh sách nhân viên của task
                    List<tblnsNhanVien> nhanVienList_Task = (from o in itemTask.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                    foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                    {
                        tblnsNhanVien nhanVien = (from o in nhanVienList_Project
                                             where o.MaNhanVien == itemNhanVien.MaNhanVien
                                             select o).SingleOrDefault();
                        if (nhanVien == null)
                        {
                            //
                            nhanVienList_Project.Add(itemNhanVien);
                        }
                    }
                }
            }
            {//Tính phần trăm hoàn tất của nhân viên

                foreach (tblnsNhanVien itemNhanVien in nhanVienList_Project)
                {
                    decimal tongTaiSan = 0;
                    decimal soLuongHoanTat = 0;
                    decimal phanTramHoanTat = 0;

                    //Duyệt qua các task của porject
                    foreach (Task itemTask in project.Tasks)
                    {
                        //Lấy tổng số tài sản của nhân viên trong task
                        tongTaiSan += (from o in itemTask.Task_Asset
                                       where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                       select o).Count();
                        //Lấy số tài sản mà nhân viên đó đã hoàn thành
                        soLuongHoanTat += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                 && o.Completed == true
                                           select o).Count();
                    }

                    //Tính phần trăm hoàn tất
                    if (tongTaiSan > 0)
                    {
                        phanTramHoanTat = Math.Round(((soLuongHoanTat / tongTaiSan) * 100));
                    }
                    else
                    {
                        phanTramHoanTat = 0;
                    }
                    //
                    if (soLuongHoanTat > tongTaiSan)
                    {
                        phanTramHoanTat = 100;
                    }
                    //Cập nhật phần trăm hoàn tất của nhân viên
                    itemNhanVien.PercentComplete = (int)phanTramHoanTat;
                }
            }
            return nhanVienList_Project;
        }
        private List<tblnsNhanVien> GetPercentCompletedOfEmployeeList_Reource(Resource resource)
        {
            List<tblnsNhanVien> nhanVienList_Resource = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của resource

                foreach (Task item in resource.Tasks)
                {
                    //Lấy danh sách nhân viên của task
                    List<tblnsNhanVien> nhanVienList_Task = (from o in item.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                    foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                    {
                        tblnsNhanVien nhanVien = (from o in nhanVienList_Resource
                                             where o.MaNhanVien == itemNhanVien.MaNhanVien
                                             select o).SingleOrDefault();
                        if (nhanVien == null)
                        {
                            //
                            nhanVienList_Resource.Add(itemNhanVien);
                        }
                    }

                }

                {//Tính phần trăm hoàn tất của nhân viên

                    foreach (tblnsNhanVien itemNhanVien in nhanVienList_Resource)
                    {
                        decimal tongTaiSan = 0;
                        decimal soLuongHoanTat = 0;
                        decimal phanTramHoanTat = 0;

                        //Duyệt qua các task của resource
                        foreach (Task itemTask in resource.Tasks)
                        {
                            //Lấy tổng số tài sản của nhân viên trong task
                            tongTaiSan += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                           select o).Count();
                            //Lấy số tài sản mà nhân viên đó đã hoàn thành
                            soLuongHoanTat += (from o in itemTask.Task_Asset
                                               where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                     && o.Completed == true
                                               select o).Count();
                        }

                        //Tính phần trăm hoàn tất
                        if (tongTaiSan > 0)
                        {
                            phanTramHoanTat = Math.Round(((soLuongHoanTat / tongTaiSan) * 100));
                        }
                        else
                        {
                            phanTramHoanTat = 0;
                        }
                        //
                        if (soLuongHoanTat > tongTaiSan)
                        {
                            phanTramHoanTat = 100;
                        }

                        //Cập nhật phần trăm hoàn tất của nhân viên
                        itemNhanVien.PercentComplete = (int)phanTramHoanTat;
                    }
                }
            }
            return nhanVienList_Resource;
        }
        private List<tblnsNhanVien> GetPercentCompletedOfEmployeeList_Task(Task task)
        {
            List<tblnsNhanVien> nhanVienList_Task = null;

            //Lấy danh sách nhân viên của task
            nhanVienList_Task = (from o in task.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

            {//Tính phần trăm hoàn thành công việc của từng nhân viên

                foreach (tblnsNhanVien item in nhanVienList_Task)
                {
                    decimal phanTramHoanTat = 0;
                    decimal tongTaiSan = 0;
                    decimal soLuongHoanTat = 0;

                    //Lấy tổng số tài sản của nhân viên trong task
                    tongTaiSan = (from o in task.Task_Asset
                                  where o.ProjectEmployeeResource.EmployeeID == item.MaNhanVien
                                  select o).Count();
                    //Lấy số tài sản mà nhân viên đó đã hoàn thành
                    soLuongHoanTat = (from o in task.Task_Asset
                                      where o.ProjectEmployeeResource.EmployeeID == item.MaNhanVien
                                            && o.Completed == true
                                      select o).Count();

                    //Tính phần trăm hoàn tất
                    if (tongTaiSan > 0)
                    {
                        phanTramHoanTat = Math.Round(((soLuongHoanTat / tongTaiSan) * 100));
                    }
                    else
                    {
                        phanTramHoanTat = 0;
                    }
                    //
                    if (soLuongHoanTat > tongTaiSan)
                    {
                        phanTramHoanTat = 100;

                    }

                    //Cập nhật phần trăm hoàn tất cho nhân viên
                    item.PercentComplete = (int)phanTramHoanTat;
                }
            }

            return nhanVienList_Task;
        }
        private List<tblnsNhanVien> GetAmountAssetOfEmployeeList_ProjectAll(List<Project> projectList)
        {
            List<tblnsNhanVien> nhanVienList_ProjectAll = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của porject

                foreach (Project itemProject in projectList)
                {
                    foreach (Task itemTask in itemProject.Tasks)
                    {
                        //Lấy danh sách nhân viên của task
                        List<tblnsNhanVien> nhanVienList_Task = (from o in itemTask.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                        foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                        {
                            tblnsNhanVien nhanVien = (from o in nhanVienList_ProjectAll
                                                 where o.MaNhanVien == itemNhanVien.MaNhanVien
                                                 select o).SingleOrDefault();
                            if (nhanVien == null)
                            {
                                //
                                nhanVienList_ProjectAll.Add(itemNhanVien);
                            }
                        }
                    }
                }
            }
            {//Tính phần trăm hoàn tất của nhân viên

                foreach (tblnsNhanVien itemNhanVien in nhanVienList_ProjectAll)
                {
                    int tongTaiSan = 0;
                    int soLuongHoanTat = 0;

                    //Duyệt qua các task của porject All
                    foreach (Project itemProject in projectList)
                    {
                        foreach (Task itemTask in itemProject.Tasks)
                        {
                            //Lấy tổng số tài sản của nhân viên trong task
                            tongTaiSan += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                           select o).Count();
                            //Lấy số tài sản mà nhân viên đó đã hoàn thành
                            soLuongHoanTat += (from o in itemTask.Task_Asset
                                               where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                     && o.Completed == true
                                               select o).Count();
                        }
                    }

                    //Cập nhật số lượng đã hoàn thành
                    itemNhanVien.AmountComplete = soLuongHoanTat;
                    //Cập nhật số lượng chưa hoàn thành
                    itemNhanVien.AmountNotComplete = tongTaiSan - soLuongHoanTat;
                }
            }
            return nhanVienList_ProjectAll;
        }
        private List<tblnsNhanVien> GetAmountAssetOfEmployeeList_Project(Project project)
        {
            List<tblnsNhanVien> nhanVienList_Project = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của porject

                foreach (Task itemTask in project.Tasks)
                {
                    //Lấy danh sách nhân viên của task
                    List<tblnsNhanVien> nhanVienList_Task = (from o in itemTask.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                    foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                    {
                        tblnsNhanVien nhanVien = (from o in nhanVienList_Project
                                             where o.MaNhanVien == itemNhanVien.MaNhanVien
                                             select o).SingleOrDefault();
                        if (nhanVien == null)
                        {
                            //
                            nhanVienList_Project.Add(itemNhanVien);
                        }
                    }
                }
            }
            {//Tính phần trăm hoàn tất của nhân viên

                foreach (tblnsNhanVien itemNhanVien in nhanVienList_Project)
                {
                    int tongTaiSan = 0;
                    int soLuongHoanTat = 0;

                    //Duyệt qua các task 
                    foreach (Task itemTask in project.Tasks)
                    {
                        //Lấy tổng số tài sản của nhân viên trong task
                        tongTaiSan += (from o in itemTask.Task_Asset
                                       where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                       select o).Count();
                        //Lấy số tài sản mà nhân viên đó đã hoàn thành
                        soLuongHoanTat += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                 && o.Completed == true
                                           select o).Count();
                    }

                    //Cập nhật số lượng đã hoàn thành
                    itemNhanVien.AmountComplete = soLuongHoanTat;
                    //Cập nhật số lượng chưa hoàn thành
                    itemNhanVien.AmountNotComplete = tongTaiSan - soLuongHoanTat;
                }
            }
            return nhanVienList_Project;
        }
        private List<tblnsNhanVien> GetAmountAssetOfEmployeeList_Resource(Resource resource)
        {
            List<tblnsNhanVien> nhanVienList_Resource = new List<tblnsNhanVien>();

            {//Lấy danh sách nhân viên của resource

                foreach (Task item in resource.Tasks)
                {
                    //Lấy danh sách nhân viên của task
                    List<tblnsNhanVien> nhanVienList_Task = (from o in item.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

                    foreach (tblnsNhanVien itemNhanVien in nhanVienList_Task)
                    {
                        tblnsNhanVien nhanVien = (from o in nhanVienList_Resource
                                             where o.MaNhanVien == itemNhanVien.MaNhanVien
                                             select o).SingleOrDefault();
                        if (nhanVien == null)
                        {
                            //
                            nhanVienList_Resource.Add(itemNhanVien);
                        }
                    }

                }
            }
            {//Tính số lượng tài sản hoàn tất của nhân viên

                foreach (tblnsNhanVien itemNhanVien in nhanVienList_Resource)
                {
                    int tongTaiSan = 0;
                    int soLuongHoanTat = 0;

                    //Duyệt qua các task của resource
                    foreach (Task itemTask in resource.Tasks)
                    {
                        //Lấy tổng số tài sản của nhân viên trong task
                        tongTaiSan += (from o in itemTask.Task_Asset
                                       where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                       select o).Count();
                        //Lấy số tài sản mà nhân viên đó đã hoàn thành
                        soLuongHoanTat += (from o in itemTask.Task_Asset
                                           where o.ProjectEmployeeResource.EmployeeID == itemNhanVien.MaNhanVien
                                                 && o.Completed == true
                                           select o).Count();
                    }

                    //Cập nhật số lượng đã hoàn thành
                    itemNhanVien.AmountComplete = soLuongHoanTat;
                    //Cập nhật số lượng chưa hoàn thành
                    itemNhanVien.AmountNotComplete = tongTaiSan - soLuongHoanTat;
                }
            }
            return nhanVienList_Resource;
        }
        private List<tblnsNhanVien> GetAmountAssetOfEmployeeList_Task(Task task)
        {
            List<tblnsNhanVien> nhanVienList_Task = null;

            //Lấy danh sách nhân viên của task
            nhanVienList_Task = (from o in task.Task_Asset select o.ProjectEmployeeResource.tblnsNhanVien).Distinct().ToList();

            {//Lấy số lượng hoàn thành công việc của từng nhân viên

                foreach (tblnsNhanVien item in nhanVienList_Task)
                {
                    int tongTaiSan = 0;
                    int soLuongHoanTat = 0;

                    //Lấy tổng số tài sản của nhân viên trong task
                    tongTaiSan = (from o in task.Task_Asset
                                  where o.ProjectEmployeeResource.EmployeeID == item.MaNhanVien
                                  select o).Count();
                    //Lấy số tài sản mà nhân viên đó đã hoàn thành
                    soLuongHoanTat = (from o in task.Task_Asset
                                      where o.ProjectEmployeeResource.EmployeeID == item.MaNhanVien
                                            && o.Completed == true
                                      select o).Count();

                    //Cập nhật số lượng đã hoàn thành
                    item.AmountComplete = soLuongHoanTat;
                    //Cập nhật số lượng chưa hoàn thành
                    item.AmountNotComplete = tongTaiSan - soLuongHoanTat;
                }
            }

            return nhanVienList_Task;
        }
        #endregion
        //Event Method
        #region Event Method
        private void frmKeHoachBaoTriBaoDuongBaoCao_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Cài đặt dữ liệu cho Treelist
                SetDataToTreeList();

                //Set mặc định cho group
                radioGroupLoaiBaoCao.EditValue = 0;
                _daLoadXong = true;
                radioGroupLoaiBaoCao.EditValue = (int)LoaiBaoCaoDuAnEnum.Task;
            };
        }
        private void ProjectTreeList_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            //Lấy dữ liệu vừa chọn trên cây
            try
            {
                _selectedProject = (e.Node.Tag as ProjectReportTreeNodeTagInfo).NodeObject as Project;
                _selectedResource = (e.Node.Tag as ProjectReportTreeNodeTagInfo).NodeObject as Resource;
                _selectedTask = (e.Node.Tag as ProjectReportTreeNodeTagInfo).NodeObject as Task;

                //Hiển thị báo cáo
                ProjectReportView();
            }
            catch (Exception ex) { }
        }
        private void radioGroupLoaiBaoCao_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                //Lấy loại báo vừa chọn
                _reportType = (Int32)radioGroupLoaiBaoCao.EditValue;

                //Hiển thị báo cáo
                ProjectReportView();
            }
        }
        #endregion
    }
}

using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;

namespace PSC_ERP.Main
{
    public partial class frmDialogProjectEmployeeResource : XtraForm
    {
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Private Member fieldxxxxxxxxxxxxxx
        #region Private Member field
        Project _project = null;
        IQueryable<ProjectEmployeeResource> _projectEmployeeResourceList = null;
        Task _currentTask = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogProjectEmployeeResource(Task task, Project project)
        {
            InitializeComponent();

            //Lấy task hiện tại
            _currentTask = task;
            //
            _project = project;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            //Gán bindingSource
            this.GanBindingSource();
        }
        private void GanBindingSource()
        {
            projectEmployeeResourceBindingSource.DataSource = _project.ProjectEmployeeResources;
            //
        }
        private void LayDanhSachNhanVienDaChonDuaVaoTask_ProjectEmployeeResource()
        {
            this.txtBlackHole.Focus();
            foreach (ProjectEmployeeResource item in _project.ProjectEmployeeResources)
            {
                if (item.Chon)
                {
                    if (!_currentTask.Task_ProjectEmployeeResource.Any(x => Object.ReferenceEquals(x.ProjectEmployeeResource, item) == true))
                    {
                        Task_ProjectEmployeeResource task_ProjectEmployeeResourceNew = Task_ProjectEmployeeResource_Factory.New().CreateAloneObject();
                        item.Task_ProjectEmployeeResource.Add(task_ProjectEmployeeResourceNew);
                        //
                        _currentTask.Task_ProjectEmployeeResource.Add(task_ProjectEmployeeResourceNew);
                        //Set lại nút chọn
                        item.Chon = false;
                    }
                    else
                    {
                        item.Chon = false;
                    }
                }
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogProjectEmployeeResource_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load dữ liệu
                LoadData();
                // Đưa checkbox lên lưới
                GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewProjectEmployeeResource, colChon);

                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewProjectEmployeeResource);
            };
        }
        private void btnDuaDuLieuVeTask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lấy danh sách nhân viên đưa về task
            LayDanhSachNhanVienDaChonDuaVaoTask_ProjectEmployeeResource();
            //
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
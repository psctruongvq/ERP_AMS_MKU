using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using System.Linq;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using DevExpress.XtraEditors.Repository;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP.Main
{
    public partial class frmChiTietCongViec : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmChiTietCongViec singleton_ = null;
        public static frmChiTietCongViec Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmChiTietCongViec();
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
        Task _currentTask = null;
        Project _project = null;
        Boolean _daLoadXong = false;
        Project_Factory _factory = null;
        Boolean _checkEndDate = true;
        Boolean _checkActualEndDate = true;
        #endregion
        //Public Member Property
        #region Public Member Property
        public Task CurrentTask
        {
            get { return _currentTask; }
        }
        #endregion
        //Member Constructor
        #region Member Constructor
        public frmChiTietCongViec()
        {
            InitializeComponent();
        }
        public frmChiTietCongViec(Project_Factory factory, Project project)
        {
            InitializeComponent();
            //Lấy project
            _project = project;
            //Lấy factory
            _factory = factory;
        }
        public frmChiTietCongViec(Project_Factory factory, Project project, Task task)
        {
            InitializeComponent();
            //Lấy project
            _project = project;
            //Lấy task
            _currentTask = task;
            //Lấy factory
            _factory = factory;

        }
        #endregion
        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            if (_currentTask == null)
            {
                _currentTask = Task_Factory.NewTask();
                _currentTask.StartTime = _currentTask.EndTime = _currentTask.ActualStartTime = _currentTask.ActualEndTime = app_users_Factory.New().SystemDate;
                //Đưa task vào project
                _project.Tasks.Add(_currentTask);
            }
            else
            {
                {//Trường hợp thêm bằng control scheduler thì mới set giá trị mặc định

                    if (_currentTask.ActualCost == null)
                    {
                        _currentTask.ActualCost = 0;
                    }
                    if (_currentTask.Cost == null)
                    {
                        _currentTask.Cost = 0;
                    }
                    if (_currentTask.EndTime == null)
                    { 
                        _currentTask.EndTime = app_users_Factory.New().SystemDate; 
                        //_currentTask.EndTime = DateTime.Now;
                    }
                    if (_currentTask.ActualStartTime == null)
                    {
                        _currentTask.ActualStartTime = app_users_Factory.New().SystemDate; 
                        //_currentTask.ActualStartTime = DateTime.Now;
                    }
                    if (_currentTask.ActualEndTime == null)
                    {
                        _currentTask.ActualEndTime = app_users_Factory.New().SystemDate;
                        //_currentTask.ActualEndTime = DateTime.Now;
                    }
                }
            }
            //Gán bindingSource
            this.GanBindingSource();
        }
        private void GanBindingSource()
        {
            taskBindingSource.DataSource = new List<Task>() { _currentTask };
            taskBindingSource.MoveLast();
            //
            taskProjectEmployeeResourceBindingSource.DataSource = _currentTask.Task_ProjectEmployeeResource;
            //
            taskAssetBindingSource.DataSource = _currentTask.Task_Asset;
            //
            taskJobBindingSource.DataSource = TaskJob_Factory.New().GetAll_SortTaskJobIndexAsc();
            //
            resourceBindingSource.DataSource = _project.Resources;
        }
        private void AddValuePercentComplete()
        {
            { //Tất cả giá trị
                trackPercentComplete.Properties.Maximum = 100;
                trackPercentComplete.Properties.Minimum = 0;
                trackPercentComplete.Properties.ShowValueToolTip = true;
                trackPercentComplete.Properties.Labels.Clear();
                for (int i = 1; i <= 100; i++)
                {
                    trackPercentComplete.Properties.Labels.Add(new TrackBarLabel(i.ToString(), i));
                }
                trackPercentComplete.Properties.ShowLabels = true;
                trackPercentComplete.Properties.DistanceFromTickToLabel = 0;
                trackPercentComplete.Properties.SmallChange = 1;
                trackPercentComplete.Properties.LargeChange = 1;
                trackPercentComplete.Properties.AutoHeight = true;
                trackPercentComplete.Properties.AutoSize = true;
                trackPercentComplete.Height = trackPercentComplete.CalcMinHeight();
                trackPercentComplete.Height = 15;
            }
            // if(_currentTask.PercentComplete != null)
            ////Set phần trăm cho task
            //trackPercentComplete.EditValue = _currentTask.PercentComplete;
        }
        private void DeleteTask_ProjectEmployeeResource()
        {
            //
            this.txtBlackHole.Focus();

            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewTask_ProjectEmployeeResource.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewTask_ProjectEmployeeResource.GetRow(index));
                        }
                        //
                        foreach (Task_ProjectEmployeeResource item in deleteList)
                        {
                            //Xóa trong factory
                            Task_ProjectEmployeeResource_Factory.FullDelete(_factory.Context, deleteList: item);
                            //
                            taskProjectEmployeeResourceBindingSource.Remove(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!\n" + ex.Message + "\n" + ex.InnerException);
                }
            }
        }
        private void DeleteTask_Asset()
        {
            //
            this.txtBlackHole.Focus();

            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewTask_Asset.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewTask_Asset.GetRow(index));
                        }
                        foreach (Task_Asset item in deleteList)
                        {
                            //Xóa trong factory
                            Task_Asset_Factory.FullDelete(_factory.Context, deleteList: item);
                            //
                            taskAssetBindingSource.Remove(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!\n" + ex.Message + "\n" + ex.InnerException);
                }
            }
        }
        private Boolean KiemTraHopLe()
        {
            bool duocPhepLuu = true;
            if (!_checkEndDate)
            {
                DialogUtil.ShowError("Kiểm tra ngày kết thúc!");
                return duocPhepLuu = false;
            }
            if (!_checkActualEndDate)
            {
                DialogUtil.ShowError("Kiểm tra ngày kết thúc thực tế!");
                return duocPhepLuu = false;
            }
            if (_currentTask.ResourceID == null)
            {
                DialogUtil.ShowWarning("Chọn nhóm công việc!");
                cbResource.Focus();
                return duocPhepLuu = false;
            }
            if (string.IsNullOrEmpty(_currentTask.Subject))
            {
                DialogUtil.ShowWarning("Nhập tiêu đề!");
                txtSubject.Focus();
                return duocPhepLuu = false;
            }

            return duocPhepLuu;
        }
        private List<Int32> GetTaiSanCoDinhCaBietThuocProjectList()
        {
            List<Int32> taiSanCoDinhThuocProjectList = new List<Int32>();

            foreach (Task item in _project.Tasks)
            {
                foreach (Task_Asset itemTask_Asset in item.Task_Asset)
                {
                    if (itemTask_Asset.tblTaiSanCoDinhCaBiet != null)
                    {
                        //
                        taiSanCoDinhThuocProjectList.Add(itemTask_Asset.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet);
                    }
                }
            }

            return taiSanCoDinhThuocProjectList;
        }
        private void CheckEndDate()
        {
            TimeSpan diffResult = Convert.ToDateTime(dteEndDate.EditValue).Subtract(Convert.ToDateTime(dteStartDate.EditValue));
            if (diffResult.Days < 0)
            {
                errorNgayKetThuc.SetError(dteEndDate, "Kiểm tra lại ngày kết thúc!");
                _checkEndDate = false;
            }
            else
            {
                errorNgayKetThuc.SetError(dteEndDate, string.Empty);
                _checkEndDate = true;
            }
        }
        private void CheckActualEndDate()
        {
            TimeSpan diffResult = Convert.ToDateTime(dteActualEndDate.EditValue).Subtract(Convert.ToDateTime(dteActualStartDate.EditValue));
            if (diffResult.Days < 0)
            {
                errorNgayKetThuc.SetError(dteActualEndDate, "Kiểm tra lại ngày kết thúc thực tế!");
                _checkActualEndDate = false;
            }
            else
            {
                errorNgayKetThuc.SetError(dteActualEndDate, string.Empty);
                _checkActualEndDate = true;
            }
        }
        #endregion
        //Event Method
        #region Event Method
        private void trackPercentComplete_EditValueChanged(object sender, EventArgs e)
        {
            //if (_daLoadXong)
            //{
            //    //Lấy giá trị hiện tại
            //    int phanTram = trackPercentComplete.EditValue == null ? 0 : Convert.ToInt32(trackPercentComplete.EditValue);
            //    _currentTask.PercentComplete = phanTram;
            //}
        }
        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            //Xóa Task_ProjectEmployeeResource
            DeleteTask_ProjectEmployeeResource();
        }
        private void btnXoaTSCDCaBiet_Click(object sender, EventArgs e)
        {
            //Xóa Task_Asset
            DeleteTask_Asset();
        }
        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnTimChonTaiSanCDCaBiet_Click(object sender, EventArgs e)
        {
            if (_project.ProjectEmployeeResources.Count == 0)
            {
                DialogUtil.ShowWarning("Chọn nhân viên!");
                return;
            }
            //Lấy danh sách tài sản cố định cá biệt thuộc project
            List<Int32> taiSanCoDinhCaBietThuocProjectList = GetTaiSanCoDinhCaBietThuocProjectList();
            //
            using (frmDialogChonNhanVien frm = new frmDialogChonNhanVien(_project))
            {//show form 
                if (frm.ShowDialog(this) == DialogResult.Yes)
                {
                    using (frmDialogTimChonTaiSanCoDinhCaBiet form = new frmDialogTimChonTaiSanCoDinhCaBiet(taiSanCoDinhCaBietThuocProjectList))
                    {//show form tai san co dinh ca biet
                        if (form.ShowDialog(this) == DialogResult.Yes)
                        {
                            foreach (tblTaiSanCoDinhCaBiet item in form.TaiSanCoDinhCaBietDuocChonList)
                            {
                                Task_Asset task_Asset = (from o in _currentTask.Task_Asset
                                                         where o.AssetID == item.MaTSCDCaBiet
                                                         select o).SingleOrDefault();
                                if (task_Asset == null)
                                {
                                    Task_Asset task_AssetNew = Task_Asset_Factory.New().CreateAloneObject();
                                    task_AssetNew.AssetID = item.MaTSCDCaBiet;
                                    task_AssetNew.Completed = false;
                                    //task_Asset.CompletedDate = DateTime.Now;
                                    //Lấy ProjectEmployeeResource gán vào Task_Asset
                                    ProjectEmployeeResource projectEmployeeResource = (from o in _project.ProjectEmployeeResources
                                                                                       where o.EmployeeID == frm.NhanVienDaChon.MaNhanVien
                                                                                       select o).SingleOrDefault();
                                    if (projectEmployeeResource != null)
                                        projectEmployeeResource.Task_Asset.Add(task_AssetNew);
                                    //
                                    _currentTask.Task_Asset.Add(task_AssetNew);
                                    //Cập nhật phần trăm hoàn tất của task
                                    _currentTask.PercentComplete = (Int32)_currentTask.CapNhatPhanTramHoanTat();
                                }
                            }
                        }
                    }
                }
            }
        }
        private void btnTimChonNhanVien_Click(object sender, EventArgs e)
        {
            using (frmDialogProjectEmployeeResource frm = new frmDialogProjectEmployeeResource(_currentTask, _project))
            {//show form nhân viên project
                frm.ShowDialog(this);
            }
        }
        private void frmGridTask_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Lấy giá trị của Percentcomplete
                AddValuePercentComplete();
                //Load dữ liệu
                LoadData();

                //Đưa checkbox lên lưới
                GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTask_Asset, colCompleted);
                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewTask_Asset, grdViewTask_ProjectEmployeeResource);
                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewTask_ProjectEmployeeResource, grdViewTask_Asset);
                //Xóa Task_ProjectEmployeeResource bằng control
                GridUtil.DeleteHelper.Setup_ManualType(grdViewTask_ProjectEmployeeResource, (GridView gridView, List<Object> deleteList) =>
                {
                    foreach (Task_ProjectEmployeeResource item in deleteList)
                    {
                        //Xóa trong factory
                        Task_ProjectEmployeeResource_Factory.FullDelete(_factory.Context, deleteList: item);
                        //
                        taskProjectEmployeeResourceBindingSource.Remove(item);
                    }
                });

                //Xóa Task_Asset bằng control
                GridUtil.DeleteHelper.Setup_ManualType(grdViewTask_Asset, (GridView gridView, List<Object> deleteList) =>
                {
                    foreach (Task_Asset item in deleteList)
                    {
                        //Xóa trong factory
                        Task_Asset_Factory.FullDelete(_factory.Context, deleteList: item);
                        //
                        taskAssetBindingSource.Remove(item);
                    }
                });
                //
                _daLoadXong = true;
            };
        }
        private void btnDuaDuLieuVeTask_ItemClick(object sender, ItemClickEventArgs e)
        {
            //
            txtBlackHole.Focus();

            if (KiemTraHopLe())
            {
                //
                this.DialogResult = DialogResult.Yes;
                //
                this.Close();
            }
        }
        private void cbResource_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                //Lấy resource vừa chọn
                Resource currentReource = cbResource.GetSelectedDataRow() as Resource;
                //Thêm task vào resource hiện tại
                _currentTask.Resource = currentReource;
            }
        }
        private void btnDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void dteEndDate_Validating(object sender, CancelEventArgs e)
        {
            //Kiểm tra ngày kết thúc
            CheckEndDate();
        }
        private void dteActualEndDate_Validating(object sender, CancelEventArgs e)
        {
            //Kiểm tra ngày kết thúc thực tế
            CheckActualEndDate();
        }
        private void dteStartDate_Validating(object sender, CancelEventArgs e)
        {
            //Kiểm tra ngày kết thúc
            CheckEndDate();
        }
        private void dteActualStartDate_Validating(object sender, CancelEventArgs e)
        {
            //Kiểm tra ngày kết thúc thực tế
            CheckActualEndDate();
        }
        #endregion

        private void btn_Thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
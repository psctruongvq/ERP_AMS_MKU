using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using System.Transactions;
using DevExpress.XtraEditors;

namespace PSC_ERP.Main
{
    public partial class frmCongViecBaoTri : XtraForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Singleton
        #region Singleton
        private static frmCongViecBaoTri singleton_ = null;
        public static frmCongViecBaoTri Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmCongViecBaoTri();
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
        TaskJob_Factory _factory = null;
        List<TaskJob> _taskJobList = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmCongViecBaoTri()
        {
            InitializeComponent();
        }
        #endregion
        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;

            foreach (TaskJob item in _taskJobList)
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    DialogUtil.ShowWarning("Nhập tên công việc!");
                    return duocPhepLuu = false;
                }
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
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            return false;//lưu không thành công hoặc không được phép lưu
        }
        private void LoadData()
        {
            ////Khởi tạo factory
            _factory = TaskJob_Factory.New();

            ////Lấy danh sách đối tượng
            _taskJobList = _factory.GetAll().ToList();

            ////Gán bindingSource
            GanBindingSource();
        }
        private void GanBindingSource()
        {
            taskJobBindingSource.DataSource = _taskJobList;
        }
        private void Them()
        {
            TaskJob taskJobNew = _factory.CreateManagedObject();
            //Lấy id lớn nhất trong taskjob
            taskJobNew.TaskJobIndex = GetNextTaskJobIndexOfTaskJob();
            _taskJobList.Add(taskJobNew);

            //Gán bindingSource
            taskJobBindingSource.DataSource = _taskJobList;
            grdViewTaskJob.RefreshData();
            grdViewTaskJob.MoveLast();
            // taskJobBindingSource.MoveLast();

        }
        private void Xoa()
        {
            //
            this.txtBlackHole.Focus();

            //Yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn? Cảnh báo: Chương trình sẽ tự động lưu sau khi xóa, dữ liệu sẽ không thể phục hồi như ban đầu");
            if (dlgResult == DialogResult.Yes)
            {
                DialogResult dlgResult2 = DialogUtil.ShowYesNo("Hỏi lại lần cuối! Bạn muốn xóa những dòng đang chọn? Cảnh báo: Chương trình sẽ tự động lưu sau khi xóa, dữ liệu sẽ không thể phục hồi như ban đầu");
                if (dlgResult2 == DialogResult.Yes)
                {
                    try
                    {
                        Int32[] rowHandleList = this.grdViewTaskJob.GetSelectedRows();
                        if (rowHandleList.Count() > 0)
                        {
                            List<object> deletedList = new List<object>();
                            foreach (var index in rowHandleList)
                            {
                                deletedList.Add(this.grdViewTaskJob.GetRow(index));//Đưa vào danh sách tạm
                            }
                            //Tiến hành xóa
                            foreach (TaskJob item in deletedList)
                            {
                                if (item.TaskJobIndex == 0)//Chỉ cho chep xóa taskjob != 0
                                    return;
                                //Xóa fatory
                                TaskJob_Factory.FullDelete(context: _factory.Context, deleteList: item);
                                //
                                taskJobBindingSource.Remove(item);
                            }
                            //
                            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                        TimeSpan.FromSeconds(180)))
                            {
                                //save truoc khi Don TaskJobIndex
                                _factory.SaveChanges();

                                //Dồn TaskJobIndex
                                this.DonTaskJobIndex();
                                _factory.SaveChanges();//bat buoc save lan 2 de set lai TaskJobIndex
                                //hoàn tất giao tác
                                transaction.Complete();
                                DialogUtil.ShowInfo("Đã xóa và tự động lưu thành công!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //thông báo không xóa được
                        DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                    }
                }
            }
        }
        private Int32 GetNextTaskJobIndexOfTaskJob()
        {
            int maxTaskJobIndex = -1;
            //foreach (TaskJob item in _taskJobList)
            //{
            //    if (item.ID > maxID)//
            //        maxID = item.ID;
            //}

            for (int i = 0; i < _taskJobList.Count; i++)
            {
                if (_taskJobList[i].TaskJobIndex > maxTaskJobIndex)
                    maxTaskJobIndex = _taskJobList[i].TaskJobIndex.Value;
            }

            return maxTaskJobIndex + 1;
        }
        private void DonTaskJobIndex()
        {
            for (int i = 0; i < _taskJobList.Count; i++)
            {
                _taskJobList[i].TaskJobIndex = i;
            }

            //int totalItemCount = _taskJobList.Count;
            //Stack
            //Queue<Int32> danhSachBoQua = new Queue<int>();

            //for (int i = 0; i < totalItemCount; i++)
            //{
            //    int indexOfMinID = i;
            //    int minID = 0;

            //    for (int j = i + 1; j < totalItemCount; j++)
            //    {
            //        if (danhSachBoQua.Any(x => x == j) == false)
            //        {
            //            if (_taskJobList[j].ID <= minID)
            //            {
            //                //ghi nhan minID
            //                minID = _taskJobList[j].ID;
            //                //luu vi tri min
            //                indexOfMinID = j;
            //            }
            //        }

            //    }
            //    danhSachBoQua.Enqueue(indexOfMinID);
            //    //
            //    //gan id moi
            //    _taskJobList[indexOfMinID].ID = i;
            //}
        }
        #endregion
        //Event Method
        #region Event Method
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Lưu dữ liệu
            Save();
        }
        private void frmCongViecBaoTri_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //Load dữ liệu
                LoadData();

                //Cấu hình lưới
                GridUtil.ConfigGridView1(true, false, false, true, false, grdViewTaskJob);
            };
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm mới dữ liệu
            Them();            
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xóa dữ liệu
            Xoa();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thoát
            this.Close();
        }
        private void btnRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Load dữ liệu
            LoadData();
        }
        #endregion
    }
}

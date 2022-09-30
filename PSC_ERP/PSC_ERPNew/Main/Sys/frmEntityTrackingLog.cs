/*Công dụng:
*
*
*
*Người tạo: 
*Ngày tạo:
*Ngày cập nhât:
*/

using System;
using System.Data;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using System.IO;
using PSC_ERP_Business.Main.Predefined;
using DevExpress.XtraGrid;
using PSC_ERP_Common;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main.Sys
{
    public partial class frmEntityTrackingLog : XtraForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Singleton
        #region Singleton
        private static frmEntityTrackingLog singleton_ = null;
        public static frmEntityTrackingLog Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmEntityTrackingLog();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        public static void ShowSingleton(object owner, BusinessCodeEnum businessCode = BusinessCodeEnum.ALL, Form mdiParent = null)
        {
            if (Singleton.BusinessCode != businessCode)
            {
                singleton_.Close();
                singleton_ = new frmEntityTrackingLog(businessCode);
            }
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }
        #endregion

        EntityTrackingLog_Factory _ETLFactory = new EntityTrackingLog_Factory();
       
        BusinessCodeEnum _businessCode = BusinessCodeEnum.ALL;

        public BusinessCodeEnum BusinessCode
        {
            get { return _businessCode; }
            //set { _businessCode = value; }
        }
        public frmEntityTrackingLog()
        {
            _businessCode = BusinessCodeEnum.ALL;
            InitializeComponent();
        }
        public frmEntityTrackingLog(BusinessCodeEnum businessCode)
        {
            _businessCode = businessCode;
            InitializeComponent();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tim();
        }        

        private void Tim()
        {//đọc dữ liệu
            //app_users focusedUser = appusersBindingSource.Current as app_users;
            try
            {
                Int32 userID = Convert.ToInt32(cbUserList.EditValue);
                DateTime tuNgay = ((DateTime)editTuNgay.EditValue).Date;
                DateTime denNgay = ((DateTime)editDenNgay.EditValue).Date;
                //lấy danh sách thêm
                entityTrackingLogBindingSource_Them.DataSource = _ETLFactory.Get_EntityTrackingList_Added_byUser_TuNgayDenNgay(userID
                    , tuNgay, denNgay, _businessCode);
                //lấy danh sách sửa
                entityTrackingLogBindingSource_Sua.DataSource = _ETLFactory.Get_EntityTrackingList_Modified_byUser_TuNgayDenNgay(userID
                     , tuNgay, denNgay, _businessCode);
                //lấy danh sách xoa
                entityTrackingLogBindingSource_Xoa.DataSource = _ETLFactory.Get_EntityTrackingList_Deleted_byUser_TuNgayDenNgay(userID
                    , tuNgay, denNgay, _businessCode);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }        

        private void entityTrackingLogBindingSource_Them_PositionChanged(object sender, EventArgs e)
        {
            LoadCurrentPropertyValues(entityTrackingLogBindingSource_Them, gridControlCurrentPropertyValues_Them);
        }
        private void entityTrackingLogBindingSource_Sua_PositionChanged(object sender, EventArgs e)
        {
            LoadOldAndNewPropertyValues(entityTrackingLogBindingSource_Sua, gridControlOldPropertyValues_Sua, gridControlNewPropertyValues_Sua);
        }
        private void entityTrackingLogBindingSource_Xoa_PositionChanged(object sender, EventArgs e)
        {
            LoadCurrentPropertyValues(entityTrackingLogBindingSource_Xoa, gridControlCurrentPropertyValues_Xoa);
        }
        private void LoadOldAndNewPropertyValues(BindingSource bindingSource, GridControl gridOldPropertyValues, GridControl gridNewPropertyValues)
        {
            try
            {
                gridOldPropertyValues.DataSource = null;
                gridNewPropertyValues.DataSource = null;

                EntityTrackingLog obj = bindingSource.Current as EntityTrackingLog;
                if (obj != null)
                {
                    //
                    StringReader reader = new StringReader(obj.OldPropertyValues);
                    DataSet xmlDataSet_forOld = new DataSet();
                    xmlDataSet_forOld.ReadXml(reader);
                    // Bind the grid to the DataSet. 
                    gridOldPropertyValues.DataSource = xmlDataSet_forOld.Tables[0];                    
                    //
                    reader = new StringReader(obj.NewPropertyValues);
                    DataSet xmlDataSet_forNew = new DataSet();
                    xmlDataSet_forNew.ReadXml(reader);
                    // Bind the grid to the DataSet. 
                    gridNewPropertyValues.DataSource = xmlDataSet_forNew.Tables[0];
                }
            }
            catch
            {
                gridOldPropertyValues.DataSource = null;
                gridNewPropertyValues.DataSource = null;
            }

        }
        private void LoadCurrentPropertyValues(BindingSource bindingSource, GridControl grid)
        {
            try
            {
                grid.DataSource = null;
                EntityTrackingLog obj = bindingSource.Current as EntityTrackingLog;
                if (obj != null)
                {
                    DataSet xmlDataSet = new DataSet();
                    StringReader reader = new StringReader(obj.CurrentPropertyValues);
                    xmlDataSet.ReadXml(reader);
                    // Bind the grid to the DataSet. 
                    grid.DataSource = xmlDataSet.Tables[0];
                }
            }
            catch
            {
                grid.DataSource = null;
            }
        }

        private void frmEntityTrackingLog_Load(object sender, EventArgs e)
        {
            //nếu admin thì lấy hết danh sách user, nếu là user thường thì lấy danh sách có 1 user
            appusersBindingSource.DataSource = app_users_Factory.New().Get_DanhSachUser_PhucVuTrackingForm();
            cbUserList.EditValue = BasicInfo.User.UserID;
            //di chuyển đến user hiện tại
            {
                //IQueryable<app_users> list = appusersBindingSource.DataSource as IQueryable<app_users>;
                //Object user = list.SingleOrDefault(x => x.UserID == BasicInfo.User.UserID);
                //appusersBindingSource.Position = appusersBindingSource.IndexOf(user);
                
                //gridView_UserList.GridControl.ForceInitialize();
                //int rowHandle = this.gridView_UserList.LocateByValue(app_users.UserID_PropertyName, BasicInfo.User.UserID);
                //if (rowHandle != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
                //{
                //    this.gridView_UserList.FocusedRowHandle = rowHandle;
                //}
            }
            //gán từ ngày và đến ngày
            this.editTuNgay.EditValue = DateTime.Today.AddDays(-10);
            this.editDenNgay.EditValue = DateTime.Today;
            //
            //caption theo businessCode
            this.Text = "Log: " + AttributeUtil.GetEnumFieldDescription(_businessCode);

            //cấu hình grid
            GridUtil.HidePlusButtonForGridView(
                gridViewCurrentPropertyValues_Them
                , this.gridViewOldPropertyValues_Sua
                , this.gridViewNewPropertyValues_Sua
                , gridViewCurrentPropertyValues_Xoa);
        }
        
        private void cbUserList_EditValueChanged(object sender, EventArgs e)
        {
            this.Tim();
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using System.Linq;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Predefined;

namespace PSC_ERPNew.Main
{
    public partial class frmListKyKeToan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmListKyKeToan singleton_ = null;
        public static frmListKyKeToan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmListKyKeToan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner);
        }

        #endregion
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Public Static Field
        #region Public Static Field
        //static readonly log4net.ILog TracingLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion
        //Private Static Property
        #region Private Static Property

        #endregion
        //Public Static Property
        #region Public Static Property

        #endregion
        //Static Constructor
        #region Static Constructor

        #endregion

        //Private Static Function
        #region Private Static Function

        #endregion

        //Public Static Function
        #region Public Static Function

        #endregion

        //Private Member field
        #region Private Member field
        Ky_Factory _ky_Factory = null;
        IQueryable<tblKy> _kyList = null;
        List<tblKy> _kyThemMoiList = null;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property

        #endregion

        //Member Constructor
        #region Member Constructor


        public frmListKyKeToan()
        {
            InitializeComponent();
        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            this._kyThemMoiList = new List<tblKy>();
            _ky_Factory = Ky_Factory.New();
            // Lấy tất cả kỳ kế toán
            _kyList = _ky_Factory.GetAll();
            tblKyBindingSource.DataSource = _kyList;
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            foreach (tblKy kyMoi in _kyThemMoiList)
            {
                if (String.IsNullOrWhiteSpace(kyMoi.TenKy))
                {
                    DialogUtil.ShowWarning("Tên kỳ không được trống.");
                    duocPhepLuu = false;
                }
            }
            return duocPhepLuu;
        }
        private Boolean Save()
        {
            txtBlackHole.Focus();
            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    tblKyBindingSource.EndEdit();
                    
                    //Tiến hành lưu dữ liệu
                    _ky_Factory.SaveChangesWithoutTrackingLog();
                    //_ky_Factory.SaveChanges(BusinessCodeEnum.TSCD_KyKeToan.ToString());

                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                }
            }
            return false;
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmListKyKeToan_Load(object sender, EventArgs e)
        {
            LoadData();

            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewKy);
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }


        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void grdViewKy_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            tblKy kyLonNhat = _ky_Factory.Get_Ky_CoMaKyLonNhat();

            tblKy kyMoi = this.grdViewKy.GetRow(e.RowHandle) as tblKy;

            if (kyLonNhat == null)
                kyMoi.MaKy = 1;
            else if (_kyThemMoiList.Count() != 0 || kyLonNhat != null)
            {

                foreach (tblKy ky in _kyThemMoiList)
                {
                    if (ky.MaKy > kyLonNhat.MaKy)
                        kyLonNhat = ky;
                }
                
                kyMoi.MaKy = kyLonNhat.MaKy + 1;
            }
            
            //tu dong thiet lap ngay dau tien, ngay ket thuc
            kyMoi.NgayBatDau = PSC_ERP_Common.DateTimeUtil.GetFirstDayOfMonth(kyLonNhat.NgayBatDau.AddMonths(1));
            kyMoi.NgayKetThuc = PSC_ERP_Common.DateTimeUtil.GetLastDayOfMonth(kyLonNhat.NgayBatDau.AddMonths(1));
            this.grdViewKy.SetRowCellValue(e.RowHandle, this.colTenKy, "Tháng " + kyMoi.NgayBatDau.ToString("MM/yyyy"));

            _kyThemMoiList.Add(kyMoi);

        }
        #endregion

        private void frmListKyKeToan_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_ky_Factory.IsDirty)
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





    }
}
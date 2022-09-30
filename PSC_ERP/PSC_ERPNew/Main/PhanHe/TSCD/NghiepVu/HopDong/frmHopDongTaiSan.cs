using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;

namespace PSC_ERPNew.Main
{
    public partial class frmHopDongTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmHopDongTaiSan singleton_ = null;
        public static frmHopDongTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmHopDongTaiSan();
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
        HopDongTaiSan_DerivedFactory _hopDongTaiSan_DerivedFactory = HopDongTaiSan_DerivedFactory.New();
        IQueryable<tblHopDong> _hopDongTaiSanList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        Boolean _yeuCauTaoHopDongRongKhiFormLoad = false;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property

        #endregion

        //Member Constructor
        #region Member Constructor

        public frmHopDongTaiSan()
        {
            InitializeComponent();
            _yeuCauTaoHopDongRongKhiFormLoad = false;
        }
        public frmHopDongTaiSan(Boolean taoHopDongMoi)
        {
            InitializeComponent();
            _yeuCauTaoHopDongRongKhiFormLoad = taoHopDongMoi;
        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LayDanhSachHopDong()
        {
            _hopDongTaiSanList = _hopDongTaiSan_DerivedFactory.GetAll();


            GanBindingSource();
        }
        void LoadDoiTac()
        {
            _doiTacList = DoiTac_Factory.New().GetAll();
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private void GanBindingSource()
        {
            tblHopDongBindingSource.DataSource = _hopDongTaiSanList;
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private void Save()
        {
            this.txtBlackHole.Focus();
            if (DuocPhepLuu())
                try
                {
                    _hopDongTaiSan_DerivedFactory.SaveChangesWithoutTrackingLog();//lưu lại
                    //
                    DialogUtil.ShowSaveSuccessful();
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }

        }
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;


            return duocPhepLuu;
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmHopDongTaiSan_Load(object sender, EventArgs e)
        {
            Thread thr = new Thread(() =>
            {
                if (this.InvokeRequired)
                {
                    PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTac);
                    this.Invoke(dele);
                }
                else
                {
                    this.LoadDoiTac();
                }
            }
               );
            thr.Start();

            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewHopDong);

            LayDanhSachHopDong();
            if (_yeuCauTaoHopDongRongKhiFormLoad == true)
                this.btnThemMoi.PerformClick();//tạo mới hợp đồng
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {



            PSC_ERP.frmHopDongMuaSam frm = new PSC_ERP.frmHopDongMuaSam();
            frm.MdiParent = this.MdiParent;
            frm.Show();


        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Save();
        }
        private void tblHopDongBindingSource_CurrentChanged(object sender, EventArgs e)
        {

            tblHopDongMuaBanBindingSource_Single.DataSource = (tblHopDongBindingSource.Current as tblHopDong).tblHopDongMuaBan;
        }
        private void frmHopDongTaiSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
            //if (DialogResult.Yes == dlgResult)
            //{
            //    this.Save();

            //}
            //else if (DialogResult.No == dlgResult)
            //{
            //    //không làm gì cả
            //}
            //else if (DialogResult.Cancel == dlgResult)
            //{
            //    e.Cancel = true;

            //}
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.txtBlackHole.Focus();
            //DialogResult dlgResult = DialogUtil.ShowDelete(this);
            //if (dlgResult == DialogResult.Yes)
            //{
            //    try
            //    {
            //        this.grdViewHopDong.DeleteSelectedRows();
            //    }
            //    catch (Exception)
            //    {
            //        DialogUtil.ShowNotDeleteSuccessful();
            //    }
            //}
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayDanhSachHopDong();
        }
        #endregion











    }
}
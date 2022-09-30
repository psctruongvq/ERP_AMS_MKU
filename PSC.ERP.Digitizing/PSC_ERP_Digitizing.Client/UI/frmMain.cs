using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Objects;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

using PSC_ERP_Business.Main.Model;
using PSC_ERP_Digitizing.Client.Util;
using PSC_ERP_Digitizing.Client.Sys;


namespace PSC_ERP_Digitizing.Client.UI
{
    public partial class frmMain : RibbonForm
    {


        #region Singleton
        private static frmMain singleton_ = null;
        public static frmMain Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmMain();
                return singleton_;
            }
        }

        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            //giup khoi tao user lan dau
            //BasicInfo.CopyDuLieuDangNhapTuHeThongCuSangHeThongMoi();
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
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

        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property

        #endregion

        //Member Constructor
        #region Member Constructor
        public frmMain()
        {
            //giup khoi tao user lan dau
            //BasicInfo.CopyDuLieuDangNhapTuHeThongCuSangHeThongMoi();
            //test log
            //TracingLog_.Debug("Mo phan he tscd");
            //
            InitializeComponent();
            BasicConfig();

        }



        #endregion

        //Private Member Function
        #region Private Member Function
        private void BasicConfig()
        {
            //Cau Hinh log
            //PSC_ERPNew.Main.Util.LogConfiguration.Config();
            //
            Util.UserThemeConfiguration.RegisterBonusSkins();
            /////////////////////////////////
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(themeChooser_RibbonGalleryBarItem, true, true);
            //load theme
            Util.UserThemeConfiguration.ReloadUserInterfaceTheme();



            //ribbonControl1.Minimized = true;//thu nhỏ ribbon
            this.WindowState = FormWindowState.Maximized;
            this.ribbonControl1.Minimized = true;
            //load menu
            LoadMenu.LoadMenuChoPhanHe(maPhanHeQL: "DIGITIZING", owner: this, ribbon: this.ribbonControl1);
            //PSC_ERP_Common.RibbonUtil.AutoSelectedRibbonPage.SetUp(ribbonControl1);
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method

        private void ribbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //Save theme
            Util.UserThemeConfiguration.SetTheme(e.Item.Caption);
        }

        private void themeChooser_RibbonGalleryBarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Name);
        }
        //private void btnMenuAndFunctionManager_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    frmMenuAndFunctionManager.ShowSingleton(null, this);

        //    //load menu
        //    LoadMenu.LoadMenuChoPhanHe(maPhanHeQL: "TSCD", owner: this, ribbon: this.ribbonControl1);

        //}


        private void frmPhanHeTSCD_Load(object sender, EventArgs e)
        {

        }
        private void btnThoatPhanHe_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnThoatHeThongERP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Environment.Exit(0);
        }




        #endregion



















        //






    }
}

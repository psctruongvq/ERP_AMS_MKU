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
using PSC_ERPNew.Main.Sys;
using PSC_ERPNew.Main.Util;
using PSC_ERP_Business.Main.Model;


namespace PSC_ERPNew.Main
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
            InitializeComponent();
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(themeChooser_RibbonGalleryBarItem, true, true);
            //ribbonControl1.Minimized = true;//thu nhỏ ribbonD:\WORKING\ERPCollection\ERP_HTV\PSC_ERPNew\PSC.ERPNew\Main\PhanHe\TSCD\DanhMuc\
            this.WindowState = FormWindowState.Maximized;

            LoadMenu.LoadMenuChoPhanHe(maPhanHeQL: "TSCD", owner: this, ribbon: this.ribbonControl1);


        }

        #endregion

        //Private Member Function
        #region Private Member Function

        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void btnMenuAndFunctionManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMenuAndFunctionManager.ShowSingleton(this);
        }

        private void navBarItem1_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("navBarItem1_LinkPressed");
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("navBarItem1_LinkClicked");
        }
        #endregion

        private void themeChooser_RibbonGalleryBarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Name);
        }

        private void ribbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //MessageBox.Show(e.Item.Caption);
            MessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName);
        }


        //






    }
}

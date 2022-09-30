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
using DevExpress.XtraBars.Ribbon.ViewInfo;
using PSC_ERPNew.Main;
using PSC_ERP_Common;

namespace PSC_ERP.Main
{
    public partial class frmMainTongHop : RibbonForm
    {

        #region Singleton
        private static frmMainTongHop singleton_ = null;
        public static frmMainTongHop Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmMainTongHop();
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
        static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmMainTongHop()
        {
            //test log
            //TracingLog_.Debug("Mo phan he tscd");
            //
            InitializeComponent();
            //BasicConfig();
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void BasicConfig()
        {
            //Cau Hinh log
            PSC_ERPNew.Main.Util.LogConfiguration.Config();
            //
            PSC_ERPNew.Main.Util.UserThemeConfiguration.RegisterBonusSkins();
            /////////////////////////////////
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(themeChooser_RibbonGalleryBarItem, true, true);
            //load theme
            PSC_ERPNew.Main.Util.UserThemeConfiguration.ReloadUserInterfaceTheme();

            //ribbonControl1.Minimized = true;//thu nhỏ ribbon
            this.WindowState = FormWindowState.Maximized;
            this.ribbonControl1.Minimized = true;
            //load menu
            LoadMenu.LoadMenuChoPhanHe(maPhanHeQL: "SYS", owner: this, ribbon: this.ribbonControl1);
            //PSC_ERP_Common.RibbonUtil.AutoSelectedRibbonPage.SetUp(ribbonControl1);
        }
        #endregion

        //Event Method
        #region Event Method

        private void DangNhap()
        {
            frmDangNhap f = new frmDangNhap();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                foreach (Form o in this.MdiChildren)
                {
                    o.Close();
                }
                //giup khoi tao user lan dau
              //  BasicInfo.CopyDuLieuDangNhapTuHeThongCuSangHeThongMoi();  //đã được gọi tại FrmDangNhap
                Text = string.Format("Xin chào: " + ERP_Library.Security.CurrentUser.Info.TenDangNhap + " - Hôm nay ngày {0} - {1:hh:mm:ss tt}", DateTime.Now.Date.ToShortDateString(), DateTime.Now);
                //lblUser.Text = "Người sử dụng : " + ERP_Library.Security.CurrentUser.Info.TenDangNhap;
                ////
                //LoadForm();
                BasicConfig();
            }
            else
                if (!ERP_Library.Security.CurrentUser.IsLogIn)
                    this.Close();
        }

        private void ribbonGalleryBarItem1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            //Save theme
            PSC_ERPNew.Main.Util.UserThemeConfiguration.SetTheme(e.Item.Caption);
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

        private void btnThoatHeThongERP_ItemClick(object sender, ItemClickEventArgs e)
        {
            //Environment.Exit(0);
            this.Close();
        }

        #endregion

        private void frmMainTongHop_Shown(object sender, EventArgs e)
        {
            //thay đổi định dạng
            System.Globalization.CultureInfo cul = new System.Globalization.CultureInfo("vi-VN"); 

            Application.CurrentCulture = cul;

            if (!ERP_Library.Security.CurrentUser.IsLogIn)
                DangNhap();
        }

        private void btnDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            DangNhap();
        }

        private void frmMainTongHop_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn có chắc chắn muốn thoát chương trình?");
            if (DialogResult.Yes == dlgResult)
            {
                using (DialogUtil.Wait())
                foreach (Form o in this.MdiChildren)
                {
                    o.Close();
                }
            }
            else if (DialogResult.No == dlgResult)
            {
                e.Cancel = true;
            }
            
        }
        //
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NPCSimpleDynamicMenu
{
    public partial class frmTest : Form
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        public static void Show1(object owner)
        {
            if (Singleton.Visible)
            {

                if (Singleton.WindowState == FormWindowState.Minimized)
                    PSC_ERP_Common.FormUtil.ShowWindow(Singleton.Handle, PSC_ERP_Common.FormUtil.SW_RESTORE);
                else
                    Singleton.BringToFront();
            }
            else
                Singleton.Show((IWin32Window)owner);

        }
        private static frmTest singleton_ = null;
        public static frmTest Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmTest();
                return singleton_;
            }
        }
        public frmTest()
        {
            InitializeComponent();
        }
        public void Init1()
        {

        }
  

    }
}

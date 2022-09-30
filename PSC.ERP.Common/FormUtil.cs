using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP_Common
{
    public class FormUtil
    {
        public const uint SW_RESTORE = 0x09;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int ShowWindow(IntPtr hWnd, uint Msg);
        public static void ShowForm_Helper(Form frm, object owner, Form mdiParent = null)
        {
            if (mdiParent != null)
            {
                //DevExpress.XtraEditors.XtraForm 
                frm.MdiParent = mdiParent as Form;

            }
            if (frm.Visible)
                if (frm.WindowState == FormWindowState.Minimized)
                    PSC_ERP_Common.FormUtil.ShowWindow(frm.Handle, PSC_ERP_Common.FormUtil.SW_RESTORE);
                else
                    frm.BringToFront();
            else
                if (owner == null || mdiParent != null)
                    frm.Show();
                else
                    frm.Show((IWin32Window)owner);

        }
    }
}

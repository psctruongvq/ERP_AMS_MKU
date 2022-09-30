using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP_Common
{
    public class ControlUtil
    {

        public static void HideControls(Control.ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                item.Visible = false;
            }
        }

        public static void HideControls(Control[] controls)
        {
            foreach (Control item in controls)
            {
                item.Visible = false;
            }
        }

        public static void ShowControls(Control.ControlCollection controls)
        {
            foreach (Control item in controls)
            {
                item.Visible = true;
            }
        }

        public static void ShowControls(Control[] controls)
        {
            foreach (Control item in controls)
            {
                item.Visible = true;
            }
        }
        public static void HideControl_LayoutGroup(LayoutControlGroup controls)
        {
            foreach (LayoutControlItem item in controls.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        public static void ShowControl_LayoutGroup(LayoutControlItem[] controls)
        {
            foreach (LayoutControlItem item in controls)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always; 
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;

namespace PSC_ERP_Common
{
    public class ComboUtil
    {
        public static void HideColumnHeaders(GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.View.OptionsView.ShowColumnHeaders = false;
        }
        public static void ShowColumnHeaders(GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.View.OptionsView.ShowColumnHeaders = true;
        }
    }
}

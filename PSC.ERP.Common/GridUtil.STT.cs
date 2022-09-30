using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
namespace PSC_ERP_Common
{
    public partial class GridUtil
    {
    
        public static void SetSTTForGridView(GridView[] gridViews, int width = 40)
        {//Cuong
            foreach (GridView item in gridViews)
            {
                SetSTTForGridView(item, width);
            }

        }
        public static void SetSTTForGridView(GridView gridView, int width = 40)
        {//Cuong
            gridView.IndicatorWidth = width;
            gridView.CustomDrawRowIndicator -= new RowIndicatorCustomDrawEventHandler(SetSTTForGridView_Helper);
            gridView.CustomDrawRowIndicator += new RowIndicatorCustomDrawEventHandler(SetSTTForGridView_Helper);

        }
        static void SetSTTForGridView_Helper(object sender, RowIndicatorCustomDrawEventArgs e)
        {//Cuong
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                    e.Info.DisplayText = (e.RowHandle + 1).ToString();

            }
        }

    }
}

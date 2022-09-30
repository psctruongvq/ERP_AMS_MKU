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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace PSC_ERP_Common
{
    public partial class GridUtil
    {

        public static void HidePlusButtonForGridView(params GridView[] gridViews)
        {
            foreach (GridView item in gridViews)
            {
                HidePlusButtonForGridView(item);
            }

        }
        public static void HidePlusButtonWhenMasterRowHasNoChildForGridView(params GridView[] gridViews)
        {
            foreach (GridView item in gridViews)
            {
                HidePlusButtonWhenMasterRowHasNoChildForGridView(item);
            }

        }

        public static void HidePlusButtonForGridView(GridView gridView)
        {

            gridView.CustomDrawCell -= new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(HidePlusButton);
            gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(HidePlusButton);

        }
        static void HidePlusButton(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column.VisibleIndex == 0)
                (e.Cell as GridCellInfo).CellButtonRect = Rectangle.Empty;
        }

        public static void HidePlusButtonWhenMasterRowHasNoChildForGridView(GridView gridView)
        {

            gridView.CustomDrawCell -= new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(HidePlusButtonWhenMasterRowHasNoChild);
            gridView.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(HidePlusButtonWhenMasterRowHasNoChild);

        }

        static void HidePlusButtonWhenMasterRowHasNoChild(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Column.VisibleIndex == 0 && view.IsMasterRowEmpty(e.RowHandle))
                (e.Cell as GridCellInfo).CellButtonRect = Rectangle.Empty;
        }

    }
}

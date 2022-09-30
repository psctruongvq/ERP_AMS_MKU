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

        public static void InitMultiCellSelectForGridView(params GridView[] gridViews)
        {//Cuong
            foreach (var item in gridViews)
            {
                InitMultiCellSelectForGridView(item);
            }
        }
        public static void InitMultiCellSelectForGridView(GridView gridView)
        {//Cuong
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
        }


        public static void InitMultiRowSelectForGridView(params GridView[] gridViews)
        {//Cuong
            foreach (var item in gridViews)
            {
                InitMultiRowSelectForGridView(item);
            }
        }
        public static void InitMultiRowSelectForGridView(GridView gridView)
        {//Cuong
            gridView.OptionsSelection.MultiSelect = true;
            gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }

    }
}

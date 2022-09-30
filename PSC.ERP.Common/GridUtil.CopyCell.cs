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
        public static void InitCopyCellForGridView(params GridView[] gridViews)
        {//Cuong
            foreach (GridView item in gridViews)
            {
                InitCopyCellForGridView(item);
            }

        }
 
        public static void InitCopyCellForGridView(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {//Cuong
            gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = false;
            gridView.KeyDown -= new KeyEventHandler(InitCopyCell_Helper);
            gridView.KeyDown += new KeyEventHandler(InitCopyCell_Helper);
        }
        private static void InitCopyCell_Helper(object sender, KeyEventArgs e)
        {//Cuong
            //DevExpress.XtraGrid.Views.Grid.GridView gridView = sender as GridView;
            //gridView.OptionsBehavior.CopyToClipboardWithColumnHeaders = NeedCopyHeaders(gridView);
            //
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {

                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.UnicodeText))
                {

                    string text = (string)iData.GetData(DataFormats.UnicodeText);
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = sender as GridView;
                    Array.ForEach(gridView.GetSelectedCells(), cell =>
                    {
                        try
                        {
                            cell.Column.View.SetRowCellValue(cell.RowHandle, cell.Column, text);
                            cell.Column.View.RefreshData();
                        }
                        catch { return; }
                    });
                }
            }
        }

    }
}

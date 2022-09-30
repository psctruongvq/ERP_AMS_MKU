using System;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP_Common
{
    public partial class GridUtil
    {
        public static void ExportToExcel(GridView gridView, Boolean showOpenFilePrompt = false)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|*.xls|All file (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView.ExportToXls(dlg.FileName);
                if (showOpenFilePrompt)
                    PSC_ERP_Util.ProcessUtil.OpenFilePrompt(dlg.FileName);
            }
        }
        public static void ExportToExcelXlsx(GridView gridView, Boolean showOpenFilePrompt = false)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xlsx)|*.xlsx|All file (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView.ExportToXlsx(dlg.FileName);
                if (showOpenFilePrompt)
                    PSC_ERP_Util.ProcessUtil.OpenFilePrompt(dlg.FileName);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
//using PSC_ERP.DataAccess.Model;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using DevExpress.Utils.Drawing;

namespace PSC_ERP_Common
{
    public partial class TreeUtils
    {
        public static void ExportToExcel(TreeList treeList, Boolean showOpenFilePrompt = false)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                treeList.ExportToXls(dlg.FileName);
                if (showOpenFilePrompt)
                    PSC_ERP_Util.ProcessUtil.OpenFilePrompt(dlg.FileName);
            }
        }
        public static void SetSTTForTreeListView(TreeList tree, int width = 35)
        {
            tree.IndicatorWidth = width;
            tree.CustomDrawNodeIndicator -= new CustomDrawNodeIndicatorEventHandler(SetSTTForTreeView_Helper);
            tree.CustomDrawNodeIndicator += new CustomDrawNodeIndicatorEventHandler(SetSTTForTreeView_Helper);
        }

        static void SetSTTForTreeView_Helper(object sender, CustomDrawNodeIndicatorEventArgs e)
        {
            
            try
            {
                if (e.IsNodeIndicator)
                {
                    TreeList tree = sender as DevExpress.XtraTreeList.TreeList;
                    IndicatorObjectInfoArgs args = e.ObjectArgs as IndicatorObjectInfoArgs;
                   
                    if (args.Kind == IndicatorKind.Row && e.Node != tree.Nodes.AutoFilterNode)
                    { 
                        e.ImageIndex = -1;
                        args.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        args.DisplayText = Convert.ToString(tree.GetVisibleIndexByNode(e.Node) + 1);
                     }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
//using PSC.ERP.DataAccess.Model;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraTreeList.Nodes;

namespace PSC_ERP.Utils
{
    public class TreeUtils
    {
        public static void FilterTreeNode(DevExpress.XtraTreeList.TreeList tree, String pattern)
        {
         
            tree.ExpandAll();
            FilterNodeOperation operation = new FilterNodeOperation(pattern != null ? pattern.ToLower() : "");
            tree.NodesIterator.DoOperation(operation);
        }
        public class FilterNodeOperation : DevExpress.XtraTreeList.Nodes.Operations.TreeListOperation
        {

            string pattern;

            public FilterNodeOperation(string pattern)
            { this.pattern = pattern; }

            public override void Execute(TreeListNode node)
            {
                if (NodeContainsPattern(node, pattern))
                {
                    node.Visible = true;

                    ShowParentNode_Helper(node);
                }
                else
                {
                    node.Visible = false;
                    if (XacDinhParentsContainsPattern(node.ParentNode, pattern))
                        node.Visible = true;
                }

            }
            bool XacDinhParentsContainsPattern(TreeListNode node, String pattern)
            {
                if (node == null)
                    return false;
                else
                    if (NodeContainsPattern(node, pattern))
                    {
                        node.Expanded = false;
                        if (node.ParentNode != null) ExpandParent(node.ParentNode);
                        return true;
                    }
                    else return XacDinhParentsContainsPattern(node.ParentNode, pattern);

            }
            private static void ExpandParent(TreeListNode node)
            {
                node.Expanded = true;
                if (node.ParentNode != null) ExpandParent(node.ParentNode);
            }
            bool NodeContainsPattern(TreeListNode node, string pattern)
            {
                
                foreach (DevExpress.XtraTreeList.Columns.TreeListColumn col in node.TreeList.Columns)
                {

                    Object obj = node.GetValue(col);
                    if (obj != null && obj.ToString().ToLower().Contains(pattern))
                    {
                        return true;
                    }

                }

                return false;
            }

        }

        private static void ShowParentNode_Helper(TreeListNode node)
        {
            if (node.ParentNode != null)
            {
                node.ParentNode.Visible = true;
                ShowParentNode_Helper(node.ParentNode);
            }
        }      
    }
}

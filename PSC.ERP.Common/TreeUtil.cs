using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
//using PSC_ERP.DataAccess.Model;
using System.Windows.Forms;
using System.Reflection;

using DevExpress.XtraTreeList.Nodes;

namespace PSC_ERP_Common
{
    public partial class TreeUtils
    {
        public static void FilterTreeNode(DevExpress.XtraTreeList.TreeList tree, String pattern)
        {
            //cách sử dụng
            /*private void txtFilterTree_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyData == Keys.Enter)
                {
                   
                    TextEdit txt = sender as TextEdit;
                    FilterTreeNode(treeList1, txt.Text);
                    
                }
            }
            */
            tree.ExpandAll();
            FilterNodeOperation operation = new FilterNodeOperation(pattern != null ? pattern.ToLower() : "");
            tree.NodesIterator.DoOperation(operation);
        }
        private class FilterNodeOperation : DevExpress.XtraTreeList.Nodes.Operations.TreeListOperation
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
        // ///////////////////////////////////////////////////////////////
        public static void LockAll_TreeListColumn(DevExpress.XtraTreeList.TreeList treeList)
        {
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn item in treeList.Columns)
            {
                item.OptionsColumn.AllowEdit = false;
                item.OptionsColumn.ReadOnly = true;
            }
        }
        public static void UnlockAll_TreeListColumn(DevExpress.XtraTreeList.TreeList treeList)
        {
            foreach (DevExpress.XtraTreeList.Columns.TreeListColumn item in treeList.Columns)
            {
                item.OptionsColumn.AllowEdit = true;
                item.OptionsColumn.ReadOnly = false;
            }
        }
        // //////////////////////////////////////////////////////////////////
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Security
{
    public partial class frmRights : Form
    {
        private ERP_Library.Security.UserRightList _data;

        public frmRights()
        {
            InitializeComponent();
        }

        private void itDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            //load dữ liệu phân quyền
            if (cmbGroup.Value == null)
            {
                treeMenus.Nodes.Clear();
            }
            else
            {
                _data = ERP_Library.Security.UserRightList.GetUserRightList((int)cmbGroup.Value);
                LoadNode();
            }
        }

        private void LoadNode()
        {
            treeMenus.SuspendLayout();
            treeMenus.Nodes.Clear();
            foreach (ERP_Library.Security.UserRightItem item in _data)
                if (item.ParentID == 0)
                {
                    TreeNode n = new TreeNode(item.TenChucNang);
                    n.Tag = item;
                    n.Checked = item.SuDung;
                    AddChildNode(n);
                    treeMenus.Nodes.Add(n);
                }
            treeMenus.ExpandAll();
            treeMenus.ResumeLayout(true);
        }

        private void AddChildNode(TreeNode node)
        {
            int parentid = 0;
            parentid = ((ERP_Library.Security.UserRightItem)node.Tag).MenuID;
            foreach (ERP_Library.Security.UserRightItem item in _data)
                if (item.ParentID == parentid)
                {
                    TreeNode n = new TreeNode(item.TenChucNang);
                    n.Tag = item;
                    n.Checked = item.SuDung;
                    AddChildNode(n);
                    node.Nodes.Add(n);
                }
        }

        private void SaveData()
        {
            if (_data == null) return;

            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
            MessageBox.Show("Dữ liệu đã lưu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void frmRights_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }
        }

        private void itUndo_Click(object sender, EventArgs e)
        {
            //load dữ liệu combo
            object v = cmbGroup.Value;
            cmbGroup.DataSource = ERP_Library.Security.GroupList.GetGroupListNotAdmin();
            cmbGroup.Value = v;

            LoadData();
        }

        private void itSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void cmbGroup_ValueChanged(object sender, EventArgs e)
        {
            if (_data != null && _data.IsDirty)
                if (MessageBox.Show("Dữ liệu đã thay đổi. Bạn có muốn lưu lại không?", "Lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveData();
                }

            LoadData();
        }

        private void frmRights_Load(object sender, EventArgs e)
        {
            //load dữ liệu combo
            cmbGroup.DataSource = ERP_Library.Security.GroupList.GetGroupListNotAdmin();
        }

        private void treeMenus_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse)
            {
                ((ERP_Library.Security.UserRightItem)e.Node.Tag).SuDung = e.Node.Checked;
                //check node cha
                if (e.Node.Checked)
                    CheckParentNode(e.Node);
                //check các node con
                if (e.Node.Nodes.Count > 0)
                    CheckChildNode(e.Node, e.Node.Checked);
            }
        }

        private void CheckChildNode(TreeNode node, bool b)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = b;
                ((ERP_Library.Security.UserRightItem)item.Tag).SuDung = b;

                if (item.Nodes.Count > 0)
                    CheckChildNode(item, b);
            }
        }

        private void CheckParentNode(TreeNode node)
        {
            if (node.Parent != null && !node.Parent.Checked)
            {
                node.Parent.Checked = true;
                ((ERP_Library.Security.UserRightItem)node.Parent.Tag).SuDung = true;
                CheckParentNode(node.Parent);
            }
        }
    }
}
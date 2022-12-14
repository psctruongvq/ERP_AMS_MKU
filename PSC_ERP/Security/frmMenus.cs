using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP.Security
{
    public partial class frmMenus : Form
    {
        private ERP_Library.Security.MenuList _data;
        private ERP_Library.Security.MenuItem _current;
        private FilterCombo cfTenForm;
        private bool IsAutoSave = false;

        public frmMenus()
        {
            InitializeComponent();
        }

        private void itDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenus_Load(object sender, EventArgs e)
        {
            LoadData();
            //tìm tất cả kiểu form cho combobox
            DataTable tbl = new DataTable("Forms");
            tbl.Columns.Add("FullName", typeof(string));
            tbl.Columns.Add("FormName", typeof(string));
            tbl.Rows.Add("", "");
            foreach (System.Type t in System.Reflection.Assembly.GetEntryAssembly().GetTypes())
            {
                if (t.BaseType == typeof(Form) || t.BaseType.BaseType == typeof(Form) || t.BaseType == typeof(DevExpress.XtraEditors.XtraForm) || t.BaseType.BaseType == typeof(DevExpress.XtraEditors.XtraForm)) //trường hợp nếu kế thừa từ 1 form cấu trúc cũng hợp lệ
                {
                    tbl.Rows.Add(t.FullName, t.Name);
                }
            }
            cmbTenForm.DataSource = tbl;
            cmbTenForm.DisplayMember = "FormName";
            cmbTenForm.ValueMember = "FullName";
            cmbTenForm.DisplayLayout.Bands[0].ColHeadersVisible = false;
            cmbTenForm.DisplayLayout.Bands[0].Columns["FullName"].Hidden = true;
            cmbTenForm.DisplayLayout.Bands[0].SortedColumns.Add(cmbTenForm.DisplayLayout.Bands[0].Columns["FormName"], false);
            cmbTenForm.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            cfTenForm = new FilterCombo(cmbTenForm, "FormName");
        }

        private void LoadData()
        {
            _data = ERP_Library.Security.MenuList.GetMenuList();
            _current = null;
            LoadNode();
        }

        private void LoadNode()
        {
            //tạo cấu trúc treeview
            treeMenus.Nodes.Clear();
            treeMenus.SuspendLayout();
            foreach (ERP_Library.Security.MenuItem item in _data)
                if (item.ParentID == 0)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode n = new Infragistics.Win.UltraWinTree.UltraTreeNode(item.MenuID.ToString(), item.TenChucNang);
                    n.Tag = item;
                    treeMenus.Nodes.Add(n);
                    n.Cells["MaChucNang"].Value = item.MaChucNang;
                    n.Cells["TenChucNang"].Value = item.TenChucNang;
                    n.Cells["STT"].Value = item.STT;
                    if (item.An)
                        n.Cells["An"].Appearance.Image = imgList.Images[0];
                    else
                        n.Cells["An"].Appearance.Image = null;

                    if (item.HinhAnh != null)
                    {
                        System.IO.MemoryStream m = new System.IO.MemoryStream();
                        m.Write(item.HinhAnh, 0, item.HinhAnh.Length);
                        Image img = Image.FromStream(m);
                        m.Close();
                        n.Cells["HinhAnh"].Appearance.Image = img;
                    }
                    AddChildNode(n);
                }
            treeMenus.ResumeLayout(true);
            treeMenus.ExpandAll();
        }

        private void AddChildNode(Infragistics.Win.UltraWinTree.UltraTreeNode node)
        {
            int parentid = ((ERP_Library.Security.MenuItem)node.Tag).MenuID;
            foreach (ERP_Library.Security.MenuItem item in _data)
                if (item.ParentID == parentid)
                {
                    Infragistics.Win.UltraWinTree.UltraTreeNode n = new Infragistics.Win.UltraWinTree.UltraTreeNode(item.MenuID.ToString(), item.TenChucNang); n.Tag = item;
                    node.Nodes.Add(n);
                    n.Cells["MaChucNang"].Value = item.MaChucNang;
                    n.Cells["TenChucNang"].Value = item.TenChucNang;
                    n.Cells["STT"].Value = item.STT;
                    if (item.An)
                        n.Cells["An"].Appearance.Image = imgList.Images[0];
                    else
                        n.Cells["An"].Appearance.Image = null;
                    if (item.HinhAnh != null)
                    {
                        System.IO.MemoryStream m = new System.IO.MemoryStream();
                        m.Write(item.HinhAnh, 0, item.HinhAnh.Length);
                        Image img = Image.FromStream(m);
                        m.Close();
                        n.Cells["HinhAnh"].Appearance.Image = img;
                    }
                    AddChildNode(n);
                }
        }
        private bool SaveData()
        {
            bdData.EndEdit();
            if ((_current != null && _current.IsDirty) || IsAutoSave)
            {
                if (IsAutoSave || _current.IsValid)
                {
                    IsAutoSave = false;//loại bỏ do đệ qui khi set active node ở dưới sẽ chạy lại save
                    try
                    {
                        _data.Save();
                        int id = 0;
                        if (treeMenus.ActiveNode != null)
                            id = ((ERP_Library.Security.MenuItem)treeMenus.ActiveNode.Tag).MenuID;
                        LoadNode();
                        if (id != 0)
                            treeMenus.ActiveNode = treeMenus.GetNodeByKey(id.ToString());
                    }
                    catch (Exception ex)
                    {
                        frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _current);
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void EditData()
        {
            if (treeMenus.ActiveNode != null)
            {
                ERP_Library.Security.MenuItem item = (ERP_Library.Security.MenuItem)treeMenus.ActiveNode.Tag;
                if (SaveData())
                {
                    _current = item;
                    bdData.DataSource = _current;
                    AddItemParent(item.MenuID);
                    picHinhAnh.Image = (System.Drawing.Image)treeMenus.ActiveNode.Cells["HinhAnh"].Appearance.Image;
                    treeMenus.GetNodeByKey(item.MenuID.ToString()).Selected = true;
                }
            }
        }

        private void itThem_Click(object sender, EventArgs e)
        {
            int parentid = 0;
            if (treeMenus.ActiveNode != null)
            {
                parentid = ((ERP_Library.Security.MenuItem)treeMenus.ActiveNode.Tag).MenuID;
            }
            if (SaveData())
            {
                _current = _data.AddNew();
                bdData.DataSource = _current;
                AddItemParent(_current.MenuID);
                _current.ParentID = parentid;
                txtSTT.Focus();
                txtSTT.SelectAll();
            }
        }

        private void itSua_Click(object sender, EventArgs e)
        {
            EditData();
        }

        private void itXoa_Click(object sender, EventArgs e)
        {
            if (treeMenus.ActiveNode != null)
            {
                bool b = false;
                if (treeMenus.ActiveNode.Nodes.Count > 0)
                    b = MessageBox.Show("Bạn có muốn xóa chức năng này và các chức năng con không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                else
                    b = MessageBox.Show("Bạn có muốn xóa chức năng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

                if (b)
                    DelChildNode(treeMenus.ActiveNode);
                LoadData();
            }
        }

        private void DelChildNode(Infragistics.Win.UltraWinTree.UltraTreeNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode n in node.Nodes)
                    DelChildNode(n);
            }
            ERP_Library.Security.MenuItem.DeleteMenuItem(((ERP_Library.Security.MenuItem)node.Tag).MenuID);
        }

        private void AddItemParent(int IDFilter)
        {
            cmbParentID.Items.Clear();
            cmbParentID.Items.Add(0, "(Không có)");
            foreach (ERP_Library.Security.MenuItem item in _data)
                if (item.MenuID != IDFilter && item.ParentID == 0)
                {
                    cmbParentID.Items.Add(item.MenuID, item.TenChucNang);
                    AddChildItemParent(1, item.MenuID, IDFilter);
                }
        }

        private void AddChildItemParent(int level, int IDParent, int IDFilter)
        {
            foreach (ERP_Library.Security.MenuItem item in _data)
                if (item.MenuID != IDFilter && item.ParentID == IDParent)
                {
                    cmbParentID.Items.Add(item.MenuID, item.TenChucNang);
                    AddChildItemParent(level + 1, item.MenuID, IDFilter);
                }
        }

        private void frmMenus_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !SaveData();
        }

        private void itSave_Click(object sender, EventArgs e)
        {
            SaveData();
            MessageBox.Show("Dữ liệu đã lưu thành công", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void itUndo_Click(object sender, EventArgs e)
        {
            LoadData();
            if (treeMenus.Nodes.Count > 0)//chọn node đầu tiên
            {
                treeMenus.ActiveNode = treeMenus.Nodes[0];
                EditData();
            }
        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            if (_current != null && dlgOpen.ShowDialog(this) == DialogResult.OK)
            {
                Image img = Image.FromFile(dlgOpen.FileName);
                picHinhAnh.Image = img;
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                img.Save(m, img.RawFormat);
                _current.HinhAnh = m.GetBuffer();
                m.Close();
            }
        }

        private void treeMenus_AfterActivate(object sender, Infragistics.Win.UltraWinTree.NodeEventArgs e)
        {
            EditData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (treeMenus.ActiveNode != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode n1, n2;
                n1 = treeMenus.ActiveNode;
                n2 = n1.GetSibling(Infragistics.Win.UltraWinTree.NodePosition.Previous);
                if (n2 == null) return;
                if (n1.Parent == n2.Parent)
                {
                    int tmp = ((ERP_Library.Security.MenuItem)n1.Tag).STT;
                    int id = ((ERP_Library.Security.MenuItem)n1.Tag).MenuID;
                    ((ERP_Library.Security.MenuItem)n1.Tag).STT = ((ERP_Library.Security.MenuItem)n2.Tag).STT;
                    ((ERP_Library.Security.MenuItem)n2.Tag).STT = tmp;
                    SaveData();
                    treeMenus.ActiveNode = treeMenus.GetNodeByKey(id.ToString());
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (treeMenus.ActiveNode != null)
            {
                Infragistics.Win.UltraWinTree.UltraTreeNode n1, n2;
                n1 = treeMenus.ActiveNode;
                n2 = n1.GetSibling(Infragistics.Win.UltraWinTree.NodePosition.Next);
                if (n2 == null) return;
                if (n1.Parent == n2.Parent)
                {
                    int tmp = ((ERP_Library.Security.MenuItem)n1.Tag).STT;
                    int id = ((ERP_Library.Security.MenuItem)n1.Tag).MenuID;
                    ((ERP_Library.Security.MenuItem)n1.Tag).STT = ((ERP_Library.Security.MenuItem)n2.Tag).STT;
                    ((ERP_Library.Security.MenuItem)n2.Tag).STT = tmp;
                    SaveData();
                    treeMenus.ActiveNode = treeMenus.GetNodeByKey(id.ToString());
                }
            }
        }

        private void itSort_Click(object sender, EventArgs e)
        {
            //xắp lại số stt
            if (MessageBox.Show("Chương trình sẽ tạo lại số thứ tự cho các chức năng \r\nBạn có muốn thực hiện không?", "Sắp xếp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int stt = 1;
                foreach (Infragistics.Win.UltraWinTree.UltraTreeNode item in treeMenus.Nodes)
                {
                    ((ERP_Library.Security.MenuItem)item.Tag).STT = stt;
                    stt++;
                    if (item.Nodes.Count > 0)
                        SortChildNode(item);
                }
                IsAutoSave = true;
                SaveData();
                IsAutoSave = false;
                MessageBox.Show("Đã sắp xếp thành công", "Sắp xếp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SortChildNode(Infragistics.Win.UltraWinTree.UltraTreeNode node)
        {
            int stt = 1;
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode item in node.Nodes)
            {
                ((ERP_Library.Security.MenuItem)item.Tag).STT = stt;
                stt++;
                if (item.Nodes.Count > 0)
                    SortChildNode(item);
            }
        }

        private void itIDAuto_Click(object sender, EventArgs e)
        {
            //tạo lại số mã chức năng của node đang chọn
            if (treeMenus.ActiveNode != null && MessageBox.Show("Chương trình sẽ tạo lại mã các chức năng của menu đang chọn \r\nBạn có muốn thực hiện không?", "Tạo mã cn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ma = ((ERP_Library.Security.MenuItem)treeMenus.ActiveNode.Tag).MaChucNang + 1;
                MaCNChildNode(ref ma, treeMenus.ActiveNode);
                IsAutoSave = true;
                SaveData();
                IsAutoSave = false;
                MessageBox.Show("Đã tạo lại mã chức năng thành công", "Sắp xếp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MaCNChildNode(ref int ma , Infragistics.Win.UltraWinTree.UltraTreeNode node)
        {
            foreach (Infragistics.Win.UltraWinTree.UltraTreeNode item in node.Nodes)
            {
                ((ERP_Library.Security.MenuItem)item.Tag).MaChucNang = ma;
                ma++;
                if (item.Nodes.Count > 0)
                    MaCNChildNode(ref ma, item);
            }
        }
    }
}
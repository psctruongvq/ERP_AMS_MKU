using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmDSChuongTrinh : Form
    {


        NguonList _nguonList;
        int maNguon = 0;
        int _hoanTat =0;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        string tenNguon = string.Empty;
        int maChuongTrinhCha = 0;
        int maChuongTrinhSearch = 0;
        string tenChuongTrinhCha = string.Empty;
        private ChuongTrinhList _chuongTrinhList_Null;
        private ChuongTrinhList _chuongTrinhList_Con;
        private ChuongTrinhList _chuongTrinhList_Cha;
        private ChuongTrinhList _chuongTrinhList_TimKiem;

        private ChuongTrinh _chuongTrinh;
        private ChuongTrinhList _chuongTrinhList;
        public static string strMaBoPhanCha = "";
        public static int maChuongTrinh = 0;
        private int maCongTy = 0;
        Util util = new Util();
        public frmDSChuongTrinh()
        {
            InitializeComponent();
            this.bindingSource1_ChuongTrinhCha.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_ChuongTrinhTimKiem.DataSource = typeof(ChuongTrinhList);          
            this.bindingSource1_MaNguon.DataSource = typeof(NguonList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
        }

        public void MyTreeView(TreeView myTreeView)
        {
            myTreeView.Nodes.Clear();
            _chuongTrinhList_Null = ChuongTrinhList.GetChuongTrinhList_ChaNull(_hoanTat,_maCongTy,maChuongTrinhSearch);
            foreach (ChuongTrinh bp in _chuongTrinhList_Null)
            {
                myTreeView.Nodes.Add(bp.MaChuongTrinh.ToString(), bp.TenChuongTrinh.ToString());

                ThemNode(myTreeView.Nodes[bp.MaChuongTrinh.ToString()]);
            }
            myTreeView.Refresh();
           // myTreeView.ExpandAll();
        }

        private void ThemNode(TreeNode nodeCha)
        {
            _chuongTrinhList_Con = ChuongTrinhList.ChuongTrinhList_Con(_hoanTat,maCongTy, Convert.ToInt32(nodeCha.Name));
            foreach (ChuongTrinh bp in _chuongTrinhList_Con)
            {
                nodeCha.Nodes.Add(bp.MaChuongTrinh.ToString(), bp.TenChuongTrinh.ToString());
                ThemNode(nodeCha.Nodes[bp.MaChuongTrinh.ToString()]);
            }
        }

        private void BoPhan_Load(object sender, EventArgs e)
        {

            LoadForm();
        }
        private void LoadForm()
        {
            _chuongTrinhList_Cha = ChuongTrinhList.GetChuongTrinhList(_hoanTat);
            ChuongTrinh itemAdd = ChuongTrinh.NewChuongTrinh("Không có");
            _chuongTrinhList_Cha.Insert(0,itemAdd);
            this.bindingSource1_ChuongTrinhCha.DataSource = _chuongTrinhList_Cha;

            _chuongTrinhList_TimKiem = _chuongTrinhList_Cha;
            //_chuongTrinhList_TimKiem = ChuongTrinhList.GetChuongTrinhList(_hoanTat);
            //ChuongTrinh itemAddSr = ChuongTrinh.NewChuongTrinh("Tất Cả");
            //_chuongTrinhList_TimKiem.Insert(0, itemAddSr);
            this.bindingSource1_ChuongTrinhTimKiem.DataSource = _chuongTrinhList_TimKiem;

            _nguonList = NguonList.GetNguonList();
            Nguon itemNguon = Nguon.NewNguon("Không có");
            _nguonList.Insert(0, itemNguon);
            this.bindingSource1_MaNguon.DataSource = _nguonList;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(_hoanTat, ERP_Library.Security.CurrentUser.Info.UserID);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            MyTreeView(treeView_ChuongTrinh);
           // this.groupBox1.Visible = false;
        }
        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(_hoanTat);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
            this.button2.Visible = false;
            this.button1.Visible = true;
            groupBox1.Visible = true;
            this.tbMaQL.Text = "";
            this.tbTenCT.Text = "";

            try
            {
               
                _chuongTrinh = ChuongTrinh.NewChuongTrinh();
                if (treeView_ChuongTrinh.SelectedNode != null)
                {
                    maChuongTrinh = Convert.ToInt32(treeView_ChuongTrinh.SelectedNode.Name);
                }
                cbChuongTrinhCha.Value = maChuongTrinh;
                int max = 0;
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22 || ERP_Library.Security.CurrentUser.Info.MaBoPhan == 26)
                {
                    foreach (ChuongTrinh ct in _chuongTrinhList)
                    {
                        if (ct.MaChuongTrinh > max)
                            max = ct.MaChuongTrinh;
                    }
                    if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 22)
                    {
                        tbMaQL.Text = "TFS_" + DateTime.Today.Date.ToShortDateString() + "_" + max.ToString();
                    }
                   else if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 26)
                    {
                        tbMaQL.Text = "HTVC_" + DateTime.Today.Date.ToShortDateString() + "_" + max.ToString();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeView_PhanXuong_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            maChuongTrinh = Convert.ToInt32(e.Node.Name);
            

            UpdateTreeview(maChuongTrinh);
        }

        private bool KiemTraControl()
        {
            if (tbMaQL.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mã Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (tbTenCT.Text == "")
            {
                MessageBox.Show("Chưa Nhập Tên Chương Trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
          
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KiemTraControl() == false)
            {
                return;
            }
            try
            {
                
                maChuongTrinh = 0;                
                _chuongTrinh.MaChuongTrinhCha = maChuongTrinhCha;
                _chuongTrinh.TenChuongTrinhCha = tenChuongTrinhCha;
                _chuongTrinh.MaQL = tbMaQL.Text;
                _chuongTrinh.TenChuongTrinh = tbTenCT.Text;
                _chuongTrinh.MaNguon = maNguon;
                _chuongTrinh.TenNguon = tenNguon;
                _chuongTrinh.DungChung = cbDungChung.Checked;
                _chuongTrinh.NgayLap = DateTime.Today.Date;
                _chuongTrinh.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _chuongTrinh.MaPhanCap = (int)cbMaPhanCap.Value;

                _chuongTrinh.Save();
               
                MessageBox.Show("Tạo Mới Thành Công", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateTreeview(_chuongTrinh.MaChuongTrinh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           // this.groupBox1.Visible = false;
            MyTreeView(treeView_ChuongTrinh);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maChuongTrinh = Convert.ToInt32(treeView_ChuongTrinh.SelectedNode.Name);
                DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa " + treeView_ChuongTrinh.SelectedNode.Text + " và các chương trình con?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ((result) == DialogResult.Yes)
                {
                    DeleteNode(maChuongTrinh);
                    ChuongTrinh.DeleteChuongTrinh(maChuongTrinh);
                    MessageBox.Show("Xóa Thành Công", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MyTreeView(treeView_ChuongTrinh);
        }

        private void DeleteNode(int maChuongTrinh)
        {
            _chuongTrinhList_Con = ChuongTrinhList.ChuongTrinhList_Con(_hoanTat,maCongTy, maChuongTrinh);
            if (_chuongTrinhList_Con.Count == 0)
                return;
            foreach (ChuongTrinh ct in _chuongTrinhList_Con)
            {
                DeleteNode(ct.MaChuongTrinh);
                ChuongTrinh.DeleteChuongTrinh(ct.MaChuongTrinh);
            }
        }
        private void UpdateTreeview(int maChuongTrinh)
        {
            this.groupBox1.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = true;
            try
            {
                _chuongTrinh = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                this.tbMaQL.Text = _chuongTrinh.MaQL;
                this.tbTenCT.Text = _chuongTrinh.TenChuongTrinh;
                this.cbMaNguon.Value = _chuongTrinh.MaNguon;
                this.cbDungChung.Checked = _chuongTrinh.DungChung;
                this.cbHoanTat.Checked = _chuongTrinh.HoanTat;
                this.cbChuongTrinhCha.Value = _chuongTrinh.MaChuongTrinhCha;
                this.cbMaPhanCap.Value = _chuongTrinh.MaPhanCap;
               // ChuongTrinh ct = ChuongTrinh.ChuongTrinhList_Con(_hoanTat, maCongTy, _chuongTrinh.MaChuongTrinhCha);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void mớiLướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTreeView(treeView_ChuongTrinh);
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!KiemTraControl())
                return;
            try
            {


               
                _chuongTrinh.MaQL = tbMaQL.Text;
                _chuongTrinh.TenChuongTrinh = tbTenCT.Text;
                _chuongTrinh.MaNguon = maNguon;
                _chuongTrinh.TenNguon = tenNguon;
                _chuongTrinh.DungChung = cbDungChung.Checked;
                _chuongTrinh.NgayLap = DateTime.Today.Date;
                _chuongTrinh.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _chuongTrinh.MaChuongTrinhCha = maChuongTrinhCha;
                _chuongTrinh.TenChuongTrinhCha = tenChuongTrinhCha;
                _chuongTrinh.HoanTat = cbHoanTat.Checked;
                _chuongTrinh.MaPhanCap = (int)cbMaPhanCap.Value;
                _chuongTrinh.Save();
                MyTreeView(treeView_ChuongTrinh);
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.groupBox1.Visible = false;
            }
            //this.groupBox1.Visible = false;
        }

        private void cậpNhậtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateTreeview(maChuongTrinh);

        }

        private void cmbu_TangCaGianCa_ValueChanged(object sender, EventArgs e)
        {


        }

    
        private void tbCancel_Click(object sender, EventArgs e)
        {

        }

       
       
        private void cbMaNguon_ValueChanged(object sender, EventArgs e)
        {
            if (cbMaNguon.ActiveRow!= null)
            {
                maNguon = Convert.ToInt32(cbMaNguon.ActiveRow.Cells["MaNguon"].Value);
                tenNguon = Convert.ToString(cbMaNguon.ActiveRow.Cells["TenNguon"].Value);
            }
        }

        private void cbChuongTrinhCha_ValueChanged(object sender, EventArgs e)
        {
            if (cbChuongTrinhCha.ActiveRow!= null)
            {
                maChuongTrinhCha = Convert.ToInt32(cbChuongTrinhCha.ActiveRow.Cells["MaChuongTrinh"].Value);

                tenChuongTrinhCha = Convert.ToString(cbChuongTrinhCha.ActiveRow.Cells["TenChuongTrinh"].Value);
            }
        }

        private void rbChuaHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChuaHoanTat.Checked == true)
                _hoanTat = 0;
            MyTreeView(treeView_ChuongTrinh);
        }

        private void rbHoanTat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbHoanTat.Checked == true)
                _hoanTat = 1;
            MyTreeView(treeView_ChuongTrinh);
        }

        private void rbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTatCa.Checked == true)
                _hoanTat = -1;
            MyTreeView(treeView_ChuongTrinh);

        }

        private void cbChuongTrinhSearch_ValueChanged(object sender, EventArgs e)
        {
            if (cbChuongTrinhSearch.ActiveRow != null)
            {
                maChuongTrinhSearch = Convert.ToInt32(cbChuongTrinhSearch.ActiveRow.Cells["MaChuongTrinh"].Value);
                UpdateTreeview(maChuongTrinhSearch);
                MyTreeView(treeView_ChuongTrinh);

            }
        }

        private void cbChuongTrinhSearch_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChuongTrinhSearch, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cbChuongTrinhSearch.Width;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cbChuongTrinhCha_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChuongTrinhCha, "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cbChuongTrinhCha.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cbChuongTrinhSearch.Width;
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cbChuongTrinhSearch.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbChuongTrinhCha.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;
        }

        private void cbMaNguon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbMaNguon, "TenNguon");
            foreach (UltraGridColumn col in this.cbMaNguon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cbMaNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbMaNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cbMaNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 0;
            cbMaNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Width = cbMaNguon.Width;
        }

       

        private void treeView_ChuongTrinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maChuongTrinh = Convert.ToInt32(treeView_ChuongTrinh.SelectedNode.Name);
                UpdateTreeview(maChuongTrinh);
            }
        }



    }
}
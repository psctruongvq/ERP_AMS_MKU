using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
namespace PSC_ERP
{
    public partial class frmBoPhan : Form
    {

        Default_Ngay default_ngay;
      
        int maPhanCap = 0;
        private LoaiBoPhanList _loaiBoPhanList;
        TTNhanVienRutGonList _ttNVList,_list_temp;
        private BoPhanList _boPhanList_Null;
        private BoPhanList _boPhanList_Con;
        private CongTyList _congTyList;
        private BoPhan _boPhan;
        private BoPhanList _boPhanList;        
        public static string strMaBoPhanCha="";
       public static int maBoPhan = 0;
        private int maCongTy = 0;
        Util util = new Util();
        public frmBoPhan()
        {
            InitializeComponent();
          
        }

        public void MyTreeView(TreeView myTreeView)
        {
            myTreeView.Nodes.Clear();
            _boPhanList_Null = BoPhanList.GetBoPhanList_ChaNull();
            foreach (BoPhan bp in _boPhanList_Null)
            {
                myTreeView.Nodes.Add(bp.MaBoPhan.ToString(), bp.TenBoPhan.ToString());
               
                ThemNode(myTreeView.Nodes[bp.MaBoPhan.ToString()]);
            }
            myTreeView.Refresh();
            myTreeView.ExpandAll();
        }

        private void ThemNode(TreeNode nodeCha)
        {
            _boPhanList_Con = BoPhanList.GetBoPhanList_Con(Convert.ToInt32(nodeCha.Name));
            foreach (BoPhan bp in _boPhanList_Con )
            {
                nodeCha.Nodes.Add(bp.MaBoPhan.ToString(), bp.TenBoPhan.ToString());
                ThemNode(nodeCha.Nodes[bp.MaBoPhan.ToString()]);
            }
        }

        private void BoPhan_Load(object sender, EventArgs e)
        {

            LoadForm();
        }
        private void LoadForm()
        {
            _ttNVList = TTNhanVienRutGonList.GetNhanVienListBoPhan(0);
            _loaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();
            this.bindingSource1_LoaiBoPhan.DataSource = _loaiBoPhanList;

            _congTyList = CongTyList.GetCongTyList();
            this.bindingSource1_CongTy.DataSource = _congTyList;

            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;

            MyTreeView(treeView_PhanXuong);
            this.groupBox1.Visible = false;
        }
        private void theemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList; 
            this.button2.Visible = false;
            this.button1.Visible = true;
            groupBox1.Visible = true;
            this.tbMaQL.Text = "";
            this.tbTenBP.Text = "";
            
            try
            {
                for (int i = 0; i < _boPhanList.Count; i++)
                {
                    _boPhan = _boPhanList[i];
                    if (_boPhan.MaBoPhanQL == "")
                    {
                        return;
                    }
                }
                _boPhan = BoPhan.NewBoPhan();
                _boPhanList.Add(_boPhan);
            }catch(Exception ex)
            {
                MessageBox.Show(util.thatbai,util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void treeView_PhanXuong_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            maBoPhan = Convert.ToInt32(e.Node.Name);
            UpdateTreeview(maBoPhan);
        }

        private bool KiemTraControl()
        {
            if (tbMaQL.Text == "")
            {
                MessageBox.Show("Chưa Nhập Mã Bộ Phận","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (tbTenBP.Text == "")
            {
                MessageBox.Show("Chưa Nhập Tên Bộ Phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32( cbLoaiBP.Value)==0)
            {
                MessageBox.Show("Chưa Chọn Loại Bộ Phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(cbCongTy.Value) == 0)
            {
                MessageBox.Show("Chưa Chọn Công Ty", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (Convert.ToInt32(ultraComboEditor1.Value) == 0)
            {
                MessageBox.Show("Chưa Chọn Phân Cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                maBoPhan = 0;
                if (treeView_PhanXuong.SelectedNode != null)
                {
                    maBoPhan = Convert.ToInt32(treeView_PhanXuong.SelectedNode.Name);
                }
                _boPhan.MaCongTy = Convert.ToInt32(cbCongTy.Value);
                _boPhan.MaBoPhanCha = maBoPhan;
                _boPhan.MaBoPhanQL = tbMaQL.Text;
                _boPhan.TenBoPhan = tbTenBP.Text;
                _boPhan.MaLoaiBoPhan = Convert.ToInt32(cbLoaiBP.Value);
                
                _boPhan.MaCongTy = Convert.ToInt32(cbCongTy.Value);
                _boPhan.NgayTao = DateTime.Today;
                _boPhan.MaPhanCap = maPhanCap;
                _boPhanList.ApplyEdit();
                _boPhanList.Save();
                MessageBox.Show("Tạo Mới Thành Công",util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo Mới Thất Bại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.groupBox1.Visible = false;
            MyTreeView(treeView_PhanXuong);
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                maBoPhan = Convert.ToInt32(treeView_PhanXuong.SelectedNode.Name);
                DialogResult result = MessageBox.Show("Bạn thật sự muốn xóa " + treeView_PhanXuong.SelectedNode.Text + " và các bộ phận con?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if ((result) == DialogResult.Yes)
                {
                    DeleteNode(maBoPhan);
                    BoPhan.DeleteBoPhan(maBoPhan);
                    MessageBox.Show("Xóa Thành Công", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            MyTreeView(treeView_PhanXuong);
        }

        private void DeleteNode(int maBoPhan)
        {            
            _boPhanList_Con = BoPhanList.GetBoPhanList_Con(maBoPhan);
            if (_boPhanList_Con.Count == 0)
                return;
            foreach (BoPhan bp in _boPhanList_Con)
            {
                DeleteNode(bp.MaBoPhan);
                BoPhan.DeleteBoPhan(bp.MaBoPhan);
            }
        }
        private void UpdateTreeview(int maBoPhan)
        {
            this.groupBox1.Visible = true;
            this.button1.Visible = false;
            this.button2.Visible = true;
            try
            {
               
                _boPhanList = BoPhanList.GetBoPhan(maBoPhan);
                this.tbMaQL.Text = _boPhanList[0].MaBoPhanQL;
                this.tbTenBP.Text = _boPhanList[0].TenBoPhan;
                this.cbLoaiBP.Value = (object)_boPhanList[0].MaLoaiBoPhan;
                this.cbCongTy.Value = (object)_boPhanList[0].MaCongTy;
                this.ultraComboEditor1.Value = (object)_boPhanList[0].MaPhanCap;
             

            }
            catch (Exception ex)
            {
                this.groupBox1.Visible = false;
                return;
            }
        }
       
        private void mớiLướiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyTreeView(treeView_PhanXuong);
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(!KiemTraControl())
               return;
            try
            {
                BoPhan.UpdateBoPhan(maBoPhan, tbMaQL.Text, tbTenBP.Text, Convert.ToDateTime(DateTime.Today), Convert.ToInt32(cbLoaiBP.Value), maCongTy, false, maPhanCap,0);

                MyTreeView(treeView_PhanXuong);
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.groupBox1.Visible = false;
            }
            this.groupBox1.Visible = false;
        }

        private void cậpNhậtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            UpdateTreeview(maBoPhan);
         
        }

        private void cmbu_TangCaGianCa_ValueChanged(object sender, EventArgs e)
        {
            
          
        }

        private void địnhVịBộPhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView_PhanXuong.SelectedNode != null)
            {
                maBoPhan = Convert.ToInt32(treeView_PhanXuong.SelectedNode.Name);
            }
            frmSapXepBoPhan f = new frmSapXepBoPhan();
            f.ShowDialog(this);
            MyTreeView(treeView_PhanXuong);
        }

        private void tbCancel_Click(object sender, EventArgs e)
        {

        }

        private void ultraComboEditor1_ValueChanged(object sender, EventArgs e)
        {
            if (ultraComboEditor1.Value != null)
            {
                maPhanCap = Convert.ToInt32(ultraComboEditor1.Value);
            }
        }

        private void cbCongTy_ValueChanged(object sender, EventArgs e)
        {
            if (cbCongTy.Value != null)
            {
                maCongTy = Convert.ToInt32(cbCongTy.Value);
            }
        }

      
       
    }
}
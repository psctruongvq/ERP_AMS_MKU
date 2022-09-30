using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmCongThucBangKQHDKD : Form
    {
        BangKQHDKDH _bangKQ;
        BangKQHDKDHList _bangKQList;
        private int _thongTu = 0;
        private int _loaiBM = 0;
        private bool indicatorIcon = true;

        int intKeyOfTree = 0;

        public frmCongThucBangKQHDKD(int tt, int loaibm)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.btnThemChiTiet.Click += btnThemChiTiet_Click;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.lueLoaiMuc.TextChanged += lueLoaiMuc_TextChanged;
            this.btnCopy.ItemClick += btnCopy_ItemClick;
            this.gvBangKQHDKD.CustomDrawRowIndicator +=gvBangKQHDKD_CustomDrawRowIndicator;
            this.gvBangKQHDKD.RowCountChanged += gvBangKQHDKD_RowCountChanged;
            this.btnThoat.ItemClick += btnThoat_ItemClick;

            _thongTu = tt;
            _loaiBM = loaibm;
            Ini();
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void gvBangKQHDKD_RowCountChanged(object sender, EventArgs e)
        {
            try
            {
                GridView gridview = ((GridView)sender);
                if (!gridview.GridControl.IsHandleCreated) return;
                Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
                SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
                gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 14;
            }
            catch
            {

            }
        }

        void gvBangKQHDKD_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                GridView view = (GridView)sender;
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    string sText = (e.RowHandle + 1).ToString();
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    e.Info.DisplayText = sText;
                }
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;

                if (e.RowHandle == GridControl.InvalidRowHandle)
                {
                    Graphics gr = e.Info.Graphics;
                    gr.PageUnit = GraphicsUnit.Pixel;
                    GridView gridView = ((GridView)sender);
                    SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
                    int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
                    if (gridView.IndicatorWidth < nNewSize)
                    {
                        gridView.IndicatorWidth = nNewSize;
                    }

                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    e.Info.DisplayText = "STT";
                    e.Info.Appearance.Font = new Font(e.Info.Appearance.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTuApDung1 _frmThongTuApDung1 = new frmThongTuApDung1(Convert.ToByte(1));
            if (_frmThongTuApDung1.ShowDialog() != DialogResult.OK)
            {

                _bangKQList = BangKQHDKDHList.NewBangKQHDKDHList();
                BangKQHDKDHList listForCopy = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _frmThongTuApDung1._TT);

                foreach (BangKQHDKDH bangCopy in listForCopy)
                {
                    BangKQHDKDH bangKQ = BangKQHDKDH.NewBCKQHDKDChildH(bangCopy, Convert.ToByte(_loaiBM));
                    //if (_isNHNN == 1)
                    //{
                    //    bangCanDoiKeToan.isNHNN = DBNull.Value;
                    //}
                    //else if (_isNHNN == 0)
                    //{
                    //    bangCanDoiKeToan.isNHNN = 0;
                    //}
                    bangKQ.MaThongTu = _thongTu;
                    _bangKQList.Add(bangKQ);
                }
                tblBangKQKDHD.DataSource = _bangKQList;
                btnLuu_ItemClick(sender, e);
            }
        }

        void lueLoaiMuc_TextChanged(object sender, EventArgs e)
        {
            label1.Text = lueLoaiMuc.Text;
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _bangKQList.ApplyEdit();
                tblBangKQKDHD.EndEdit();
                _bangKQList.Save();

                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                _bangKQList = BangKQHDKDHList.GetBangKQHDKDHList_ForTree(Convert.ToByte(_loaiBM), _thongTu);
                treeList.Refresh();
                //tblBangKQKDHD.DataSource = _bangKQList;
                //gcBangKQHDKD.DataSource = tblBangKQKDHD;

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    if (gvBangKQHDKD.GetFocusedRow() != null)
            //    {
            //        gvBangKQHDKD.DeleteSelectedRows();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
            //    }
            //}
            //catch { }

            try
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node;
                node = treeList.FocusedNode;
                if (node != null)
                {
                    BangKQHDKDH obj = (BangKQHDKDH)tblBangKQKDHD.Current;
                    if (obj.MaChiTiet != 0)
                    {
                        MessageBox.Show("Vui Lòng chọn dòng chỉ tiêu có mã số để xóa!");
                        return;
                    }
                   
                    //treeList.Nodes.Remove(node);                    
                    treeList.DeleteSelectedNodes();
                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                intKeyOfTree = intKeyOfTree - 1;
                _bangKQ = BangKQHDKDH.NewBangKQHDKDHChild();
                _bangKQ.MaThongTu = _thongTu;
                _bangKQ.LoaiBaoCao = Convert.ToByte(_loaiBM);
                _bangKQ.KeyOfTree = intKeyOfTree;
                _bangKQList.Insert(0, _bangKQ);
                tblBangKQKDHD.DataSource = _bangKQList;
                treeList.DataSource = tblBangKQKDHD;
                treeList.ExpandAll();
                treeList.MoveFirst();               
                txtMaSo.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_BangCanDoiKeToan1 dlg = new frmCT_BangCanDoiKeToan1((BangKQHDKDH)(tblBangKQKDHD.Current));
            dlg.ShowDialog();
        }

        private void Ini()
        {
            try
            {
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                tblLoaiMuc.DataSource = DTLoaiMuc();


                lueLoaiMuc.Properties.DataSource = tblLoaiMuc;
                lueLoaiMuc.Properties.ValueMember = "Ma";
                lueLoaiMuc.Properties.DisplayMember = "Ten";

                //gvBangKQHDKD.OptionsBehavior.ReadOnly = true;
                //_bangKQList = BangKQHDKDHList.GetBangKQHDKDHList(Convert.ToByte(_loaiBM), _thongTu);
                _bangKQList = BangKQHDKDHList.GetBangKQHDKDHList_ForTree(Convert.ToByte(_loaiBM), _thongTu);
                tblBangKQKDHD.DataSource = _bangKQList;
                //gcBangKQHDKD.DataSource = tblBangKQKDHD;

                if (tblBangKQKDHD.Count == 0)
                {
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    lueLoaiMuc.ItemIndex = 0;
                }
                /*
                gvBangKQHDKD.Columns["LoaiBaoCao"].Visible = false;
                gvBangKQHDKD.Columns["MaMucCha"].Visible = false;
                //gvBangKQHDKD.Columns["isNHNN"].Visible = false;
                gvBangKQHDKD.Columns["MaThongTu"].Visible = false;
                gvBangKQHDKD.Columns["MaMucDoiUng"].Visible = false;
                gvBangKQHDKD.Columns["DienGiai"].Visible = false;
                gvBangKQHDKD.Columns["MaMuc"].Visible = false;

                gvBangKQHDKD.Columns["TenMuc"].Caption = "Tên mục";
                gvBangKQHDKD.Columns["ThuyetMinh"].Caption = "Thuyết minh";
                gvBangKQHDKD.Columns["Loai"].Caption = "Loại";
                gvBangKQHDKD.Columns["MaSo"].Caption = "Mã số";
                */

                repositoryItemGridLookUpEdit2.DataSource = tblLoaiMuc;
                repositoryItemGridLookUpEdit2.ValueMember = "Ma";
                repositoryItemGridLookUpEdit2.DisplayMember = "Ten";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        
        }

        public DataTable DTLoaiMuc()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Ma");
            dt.Columns.Add("Ten");
            dt.Rows.Add("0", "Không có");
            dt.Rows.Add("1", "Tính theo mã tài khoản");
            dt.Rows.Add("2", "Tính từ mục khác");
            return dt;
        }


        #region Event contextMenu
        private void menuItemThemCongThuc_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = treeList.FocusedNode;
            if (node == null)
                return;

            //MessageBox.Show(node.GetValue("MaMucTaiKhoan") + "");
            int MaChiTiet = (int)node.GetValue("MaChiTiet");
            frmCT_BangCanDoiKeToan1 frm = new frmCT_BangCanDoiKeToan1();
            BangKQHDKDH obj;
            if (MaChiTiet == 0) //node của bảng cha
            {
                obj = (BangKQHDKDH)(tblBangKQKDHD.Current);
                frm = new frmCT_BangCanDoiKeToan1(obj);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else //node của bảng con
            {
                //DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
                node = node.ParentNode;
                obj = (BangKQHDKDH)(_bangKQList[node.Id]);
                frm = new frmCT_BangCanDoiKeToan1(obj);
                frm.ShowDialog();
            }

            if (frm.isSave)
            {
                ResetChildNode(node, obj.CT_MauBangBaoCaoListH);
                tblBangKQKDHD.DataSource = _bangKQList;
                treeList.DataSource = tblBangKQKDHD;
                treeList.ExpandAll();
                node.ExpandAll();
            }
        }

        private void menuItemSuaCongThuc_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = treeList.FocusedNode;
            if (node == null)
                return;

            //MessageBox.Show(node.GetValue("MaMucTaiKhoan") + "");
            int MaChiTiet = (int)node.GetValue("MaChiTiet");
            frmCT_BangCanDoiKeToan1 frm = new frmCT_BangCanDoiKeToan1();
            BangKQHDKDH obj;
            DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
            if (MaChiTiet == 0) //node của bảng cha
            {
                MessageBox.Show("Vui lòng chọn công thức để sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //node của bảng con
            {
                //xóa dòng trên tree, đồng thời remove Item trong list của node cha

                nodeParent = node.ParentNode;
                obj = (BangKQHDKDH)(_bangKQList[nodeParent.Id]);

                int indexChildNode = 0;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode nodeChild in nodeParent.Nodes)
                {
                    if (nodeChild == node)
                        break;
                    indexChildNode += 1;
                }
                frm = new frmCT_BangCanDoiKeToan1(obj, "SUA", indexChildNode);
                frm.ShowDialog();

                if (frm.isSave)
                {
                    ResetChildNode(nodeParent, obj.CT_MauBangBaoCaoListH);
                    if (node.ParentNode != null)
                        node.ParentNode.ExpandAll();
                    node.ExpandAll();
                }
            }

        }

        private void menuItemXoaCongThuc_Click(object sender, EventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = treeList.FocusedNode;
            if (node == null)
                return;

            //MessageBox.Show(node.GetValue("MaMucTaiKhoan") + "");
            int MaChiTiet = (int)node.GetValue("MaChiTiet");
            frmCT_BangCanDoiKeToan1 frm = new frmCT_BangCanDoiKeToan1();
            BangKQHDKDH obj;
            if (MaChiTiet == 0) //node của bảng cha
            {
                MessageBox.Show("Vui lòng chọn công thức để xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //node của bảng con
            {
                //xóa dòng trên tree, đồng thời remove Item trong list của node cha
                DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
                nodeParent = node.ParentNode;
                obj = (BangKQHDKDH)(_bangKQList[nodeParent.Id]);

                int indexChildNode = 0;
                foreach (DevExpress.XtraTreeList.Nodes.TreeListNode nodeChild in nodeParent.Nodes)
                {
                    if (nodeChild == node)
                        break;
                    indexChildNode += 1;
                }
                obj.CT_MauBangBaoCaoListH.RemoveAt(indexChildNode);
                treeList.DeleteSelectedNodes();
            }
        }

        #endregion

        #region Sub
        private void ResetChildNode(DevExpress.XtraTreeList.Nodes.TreeListNode node, CT_MauBangBaoCaoListH list)
        {
            try
            {
                int x;
                DevExpress.XtraTreeList.Nodes.TreeListNode nodeChild;
                for (x = node.Nodes.Count - 1; x >= 0; x--)
                {
                    nodeChild = node.Nodes[x];
                    if ((int)nodeChild["MaChiTiet"] != 0)
                    {
                        node.Nodes.RemoveAt(x);
                    }
                }


                int i = 0;
                int maMucTKCha = (int)node["KeyOfTree"];
                foreach (CT_MauBangBaoCaoH objCT in list)
                {
                    BangKQHDKDH obj = BangKQHDKDH.NewBangKQHDKDHChild();
                    this.intKeyOfTree -= 1;
                    obj.KeyOfTree = this.intKeyOfTree;
                    obj.MaMuc = this.intKeyOfTree;
                    obj.MaChiTiet = objCT.MaChiTiet != 0 ? objCT.MaChiTiet : this.intKeyOfTree;
                    obj.MaMucCha = maMucTKCha;
                    obj.SoHieuTK = objCT.SoHieu;
                    obj.SoHieuTKDoiUng = objCT.SoHieuTKDU;
                    obj.MaThongTu = this._thongTu;

                    if (objCT.MaMucLienQuan != 0)
                    {
                        obj.TenMucLienQuan = BangKQHDKDH.GetBangKQHDKDH(objCT.MaMucLienQuan).TenMucLienQuan;
                    }

                    if (objCT.NoCo == 1)
                        obj.BenNoCo = "Nợ";
                    else if (objCT.NoCo == 2)
                        obj.BenNoCo = "Có";

                    if (objCT.Loai == 1)
                        obj.KieuLaySoDu = "Lấy theo số dư";
                    else if (objCT.Loai == 2)
                        obj.KieuLaySoDu = "Lấy theo số phát sinh";
                    else if (objCT.Loai == 3)
                        obj.KieuLaySoDu = "Lấy theo số dư đầu";

                    if (objCT.CongTru == 1)
                        obj.DauCongThuc = "Cộng";
                    else if (objCT.CongTru == 2)
                        obj.DauCongThuc = "Trừ";
                    else if (objCT.CongTru == 3)
                        obj.DauCongThuc = "Nhân";
                    else if (objCT.CongTru == 4)
                        obj.DauCongThuc = "Chia";

                    _bangKQList.Insert(node.Id + i, obj);

                    i += 1;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = e.Node;          
            int maChiTiet = (int)node.GetValue("MaChiTiet");
            if (maChiTiet == 0)
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void frmCongThucBangKQHDKD_Load(object sender, EventArgs e)
        {
            treeList.ExpandAll();
        }

        private void btnThemChiTiet_Click_1(object sender, EventArgs e)
        {

        }       

       
       
    }
}

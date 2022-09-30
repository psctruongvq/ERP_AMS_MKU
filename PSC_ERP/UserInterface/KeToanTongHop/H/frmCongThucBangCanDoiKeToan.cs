using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
    public partial class frmCongThucBangCanDoiKeToan : DevExpress.XtraEditors.XtraForm
    {
        int _iD = 0;
        int _maMucTaikhoan = 0;

        CT_MauBangBaoCaoH CT_BangCanDoi1;
        CT_MauBangBaoCaoListH CT_BangCanDoi1List;

        BangCanDoiKeToanListH _bangCanDoiList;
        BangCanDoiKeToanH _bangCanDoi;
        CT_MauBangBaoCaoListH _CTBangCanDoiList;

        private byte _checkUpdateMucCha = 0;
        private bool indicatorIcon = true;

        public frmCongThucBangCanDoiKeToan(int id)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _iD = id;
            this.Load += frmBangCanDoiKeToanChoThongTu_Load;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoa.ItemClick += btnXoa_ItemClick;
            this.btnThemChiTiet.Click += btnThemChiTiet_Click;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.btnCopy.ItemClick += btnCopy_ItemClick;
            gvBangCanDoi.FocusedRowChanged += gvBangCanDoi_FocusedRowChanged;
            gvBangCanDoi.MouseDown += gvBangCanDoi_MouseDown;
            this.gvBangCanDoi.CustomDrawRowIndicator += gvBangCanDoi_CustomDrawRowIndicator;
            this.gvBangCanDoi.RowCountChanged += gvBangCanDoi_RowCountChanged;
        }

        void gvBangCanDoi_RowCountChanged(object sender, EventArgs e)
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

        void gvBangCanDoi_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        void gvBangCanDoi_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hi = view.CalcHitInfo(e.Location);
            if (hi.RowHandle >= 0)
            {
                string a = gvBangCanDoi.GetRowCellValue(hi.RowHandle, "MaMucTaiKhoan").ToString();
                _maMucTaikhoan = Convert.ToInt32(a);
            }
        }

        void gvBangCanDoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (e.FocusedRowHandle >= 0)
            //{
            //    string a = gvBangCanDoi.GetFocusedRowCellValue("MaMucTaiKhoan").ToString();
            //    _maMucTaikhoan = Convert.ToInt32(a);
            //}
        }

        void btnCopy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThongTuApDung1 _frmThongTuApDung1 = new frmThongTuApDung1(Convert.ToByte(1));
            _frmThongTuApDung1.ShowDialog();
            if (_frmThongTuApDung1._checkOK == DialogResult.OK)
            {

                _bangCanDoiList = BangCanDoiKeToanListH.NewBangCanDoiKeToanListH();
                BangCanDoiKeToanListH listForCopy = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_frmThongTuApDung1._TT);

                foreach (BangCanDoiKeToanH bangCopy in listForCopy)
                {
                    BangCanDoiKeToanH bangCanDoiKeToan = BangCanDoiKeToanH.NewBangCanDoiKeToanChildH(bangCopy);
                    //if (_isNHNN == 1)
                    //{
                    //    bangCanDoiKeToan.isNHNN = DBNull.Value;
                    //}
                    //else if (_isNHNN == 0)
                    //{
                    //    bangCanDoiKeToan.isNHNN = 0;
                    //}
                    bangCanDoiKeToan.MaThongTu = _iD;
                    _bangCanDoiList.Add(bangCanDoiKeToan);
                }
                tblBangCanDoi.DataSource = _bangCanDoiList;

                BangCanDoiKeToanH bangCDKTCha = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
                BangCanDoiKeToanListH _bangCanDoiListCha = BangCanDoiKeToanListH.NewBangCanDoiKeToanListHLoadMucCha(_frmThongTuApDung1._TT);
                _bangCanDoiListCha.Insert(0, bangCDKTCha);
                tblMucCha.DataSource = _bangCanDoiListCha;
                lueTaiKhoanCha.Properties.DataSource = tblMucCha;

                glue_MaTaiKhoanCha.DataSource = tblMucCha;
                glue_MaTaiKhoanCha.DisplayMember = "TenMucTaiKhoan";
                glue_MaTaiKhoanCha.ValueMember = "MaMucTaiKhoan";

                btnLuu_ItemClick(sender, e);

            }


        }


        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        void btnThemChiTiet_Click(object sender, EventArgs e)
        {
            frmCT_BangCanDoiKeToan1 dlg = new frmCT_BangCanDoiKeToan1((BangCanDoiKeToanH)(tblBangCanDoi.Current));
            if (dlg.ShowDialog() == DialogResult.OK)
            {

            }
        }

        void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
            try
            {
                if (gvBangCanDoi.GetFocusedRow() != null)
                {
                    //BangCanDoiKeToanListH _checkChaBCD = BangCanDoiKeToanListH.GetBangCanDoiKeToanListHCheckCha(_maMucTaikhoan);
                    //if (_checkChaBCD.Count == 0)
                    //{
                    BangCanDoiKeToanListH _bangCanDoiListCheck = BangCanDoiKeToanListH.GetBangCanDoiKeToanListHCheckChild(_maMucTaikhoan);
                    if (_bangCanDoiListCheck.Count != 0)
                    {
                        DialogResult result = MessageBox.Show(this, "Tài khoản có tài khoản con đang sử dụng ?? !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (result == DialogResult.OK)
                            //gvBangCanDoi.DeleteSelectedRows();
                            //else
                            return;
                    }
                    else
                        gvBangCanDoi.DeleteSelectedRows();
                    //}
                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn dòng cần xóa!");
                }
            }
            catch (Exception ex) { throw ex; }
            return;
            */
            try
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node;
                node = treeList.FocusedNode;
                if (node != null)
                {
                    BangCanDoiKeToanH obj = (BangCanDoiKeToanH)tblBangCanDoi.Current;
                    if (obj.MaChiTiet > 0)
                    {
                        MessageBox.Show("Vui Lòng chọn dòng chỉ tiêu có tên cấp mục để xóa!");
                        return;
                    }

                    BangCanDoiKeToanListH _bangCanDoiListCheck = BangCanDoiKeToanListH.GetBangCanDoiKeToanListHCheckChild(obj.MaMucTaiKhoan);
                    if ((_bangCanDoiListCheck.Count != 0) || (obj.CT_MauBangBaoCaoListH.Count != 0))
                    {
                        DialogResult result = MessageBox.Show(this, "Mục chỉ tiêu đang có chỉ tiêu chi tiết hoặc công thức chi tiết đang sử dụng, Bạn có chắc chắn xóa ?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.No)
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

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                _bangCanDoiList.ApplyEdit();
                tblBangCanDoi.EndEdit();
                _bangCanDoiList.Save();

                if (_checkUpdateMucCha == 1)
                {
                    _bangCanDoiList.UpdateMucCha(_iD);
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }

                LoadMucCha();
                _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH(_iD);
                treeList.Refresh();

                MessageBox.Show(this, "Đã lưu thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể lưu");
            }
        }

        int intKeyOfTree = 0;
        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                /*
                _bangCanDoi = BangCanDoiKeToanH.NewBangCanDoiKeToanHChild();
                _bangCanDoi.MaThongTu = _iD;
                _bangCanDoi.KeyOfTree = intKeyOfTree - 1;
                _bangCanDoiList.Insert(0, _bangCanDoi);
                
                tblBangCanDoi.DataSource = _bangCanDoiList;
                gcBangCanDoi.DataSource = tblBangCanDoi;
                gvBangCanDoi.MoveFirst();
                txtMaSo.Focus();
                //_bangCanDoiList.EndNew(0);
                return;
                 */

                intKeyOfTree = intKeyOfTree - 1;
                _bangCanDoi = BangCanDoiKeToanH.NewBangCanDoiKeToanHChild();
                _bangCanDoi.MaThongTu = _iD;
                _bangCanDoi.KeyOfTree = intKeyOfTree;
                _bangCanDoiList.Insert(0, _bangCanDoi);
                tblBangCanDoi.DataSource = _bangCanDoiList;
                treeList.DataSource = tblBangCanDoi;
                treeList.ExpandAll();
                treeList.MoveFirst();
                txtMaSo.Focus();
                _bangCanDoiList.ApplyEdit();
                tblBangCanDoi.EndEdit();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboSPGrid()
        {
            var editor = (RepositoryItemGridLookUpEdit)gcBangCanDoi.RepositoryItems.Add("GridLookUpEdit");
            editor.DataSource = tblBangCanDoi;
            editor.ValueMember = "MaMucTaiKhoanCha";
            editor.DisplayMember = "TenMucTaiKhoanCha";

            gvBangCanDoi.Columns["TenMucTaiKhoanCha"].ColumnEdit = editor;
            //gridView1.Columns["MaSP"].Visible = false;
        }

        private void LoadMucCha()
        {
            BangCanDoiKeToanH bangCDKTCha = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
            BangCanDoiKeToanListH _bangCanDoiListCha = BangCanDoiKeToanListH.NewBangCanDoiKeToanListHLoadMucCha(_iD);
            _bangCanDoiListCha.Insert(0, bangCDKTCha);
            tblMucCha.DataSource = _bangCanDoiListCha;
            lueTaiKhoanCha.Properties.DataSource = tblMucCha;
        }

        void frmBangCanDoiKeToanChoThongTu_Load(object sender, EventArgs e)
        {
            //int loaiChungTu = 0;
            //long maChungTu = 0;
            //bool isShowFromReport = true;
            //switch (loaiChungTu)
            //{
            //    case 2:
            //        PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu, isShowFromReport);
            //        frm.WindowState = FormWindowState.Maximized;
            //        frm.ShowDialog();
            //        break;
            //    default:
            //        MessageBox.Show("Không tìm thấy Form chứng từ");
            //        break;
            //}

            try
            {

                LoadMucCha();
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH_ForTree(_iD);
                tblBangCanDoi.DataSource = _bangCanDoiList;
                if (tblBangCanDoi.Count == 0)
                {
                    btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    _checkUpdateMucCha = 1;
                    lueTaiKhoanCha.EditValue = 1;
                }

                treeList.ExpandAll();

                //gvBangCanDoi.Columns["MaSo"].Caption = "Mã số";
                //gvBangCanDoi.Columns["TenMucTaiKhoan"].Caption = "Tên mục tài khoản";
                //gvBangCanDoi.Columns["ThuyetMinh"].Caption = "Thuyết minh";
                //gvBangCanDoi.Columns["TenMucTaiKhoanCha"].Caption = "Tên mục tài khoản cha";
                //gvBangCanDoi.Columns["TenTaiKhoan"].Caption = "Tên tài khoản";
                //gvBangCanDoi.Columns["CapMuc"].Caption = "Cấp";
                //gvBangCanDoi.Columns["MaMucTaiKhoanCha"].Caption = "Mã mục tài khoản cha";

                //cboSPGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void treeList_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

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
            BangCanDoiKeToanH obj;
            if (MaChiTiet == 0) //node của bảng cha
            {
                obj = (BangCanDoiKeToanH)(tblBangCanDoi.Current);
                frm = new frmCT_BangCanDoiKeToan1(obj,"THEM",0);
                if (frm.ShowDialog() == DialogResult.OK)
                {

                }
            }
            else //node của bảng con
            {
                //DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
                node = node.ParentNode;
                obj = (BangCanDoiKeToanH)(tblBangCanDoi[node.Id]);
                frm = new frmCT_BangCanDoiKeToan1(obj,"THEM",0);
                frm.ShowDialog();
            }

            if (frm.isSave)
            {
                ResetChildNode(node, obj.CT_MauBangBaoCaoListH);
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
            BangCanDoiKeToanH obj;
            DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
            if (MaChiTiet == 0) //node của bảng cha
            {
                MessageBox.Show("Vui lòng chọn công thức để sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //node của bảng con
            {             
                
                nodeParent = node.ParentNode;
                obj = (BangCanDoiKeToanH)(tblBangCanDoi[nodeParent.Id]);

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
            BangCanDoiKeToanH obj;
            if (MaChiTiet == 0) //node của bảng cha
            {
                MessageBox.Show("Vui lòng chọn công thức để xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //node của bảng con
            {
                //xóa dòng trên tree, đồng thời remove Item trong list của node cha
                DevExpress.XtraTreeList.Nodes.TreeListNode nodeParent;
                nodeParent = node.ParentNode;
                obj = (BangCanDoiKeToanH)(tblBangCanDoi[nodeParent.Id]);

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
                    BangCanDoiKeToanH obj = BangCanDoiKeToanH.NewBangCanDoiKeToanHChild();
                    this.intKeyOfTree -= 1;
                    obj.KeyOfTree = this.intKeyOfTree;
                    obj.MaMucTaiKhoan = this.intKeyOfTree;
                    obj.MaChiTiet = objCT.MaChiTiet != 0 ? objCT.MaChiTiet : this.intKeyOfTree;
                    obj.MaMucTaiKhoanCha = maMucTKCha;
                    obj.SoHieuTK = objCT.SoHieu;
                    obj.SoHieuTKDoiUng = objCT.SoHieuTKDU;
                    obj.MaThongTu = this._iD;
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

                    _bangCanDoiList.Insert(node.Id + i, obj);

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
            int capMuc = (int)node.GetValue("CapMuc");
            int maChiTiet = (int)node.GetValue("MaChiTiet");
            if ((capMuc > 0 && capMuc <= 2) || (capMuc == 0 && maChiTiet == 0))
            {
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }
        }

        private void txtCapMuc_EditValueChanged(object sender, EventArgs e)
        {
            //BangCanDoiKeToanH obj = (BangCanDoiKeToanH)tblBangCanDoi.Current;
            //if (obj == null)
            //    return;

            //if (txtCapMuc.Text == "0" || txtCapMuc.Text == "")
            //{
            //    obj.StrCapMuc = "";
            //}
            //else
            //{
            //    obj.StrCapMuc = txtCapMuc.Text;
            //}
        }

        private void txtCapMuc_TextChanged(object sender, EventArgs e)
        {
            BangCanDoiKeToanH obj = (BangCanDoiKeToanH)tblBangCanDoi.Current;
            if (obj == null)
                return;

            if (txtCapMuc.Text == "0" || txtCapMuc.Text == "")
            {
                obj.StrCapMuc = "";
            }
            else
            {
                obj.StrCapMuc = txtCapMuc.Text;
            }
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadMucCha();
            btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            _bangCanDoiList = BangCanDoiKeToanListH.GetBangCanDoiKeToanListH_ForTree(_iD);
            tblBangCanDoi.DataSource = _bangCanDoiList;
            if (tblBangCanDoi.Count == 0)
            {
                btnCopy.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                _checkUpdateMucCha = 1;
                lueTaiKhoanCha.EditValue = 1;
            }

            treeList.ExpandAll();

        }

    }
}

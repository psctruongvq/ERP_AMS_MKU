using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;

namespace PSC_ERP
{
    public partial class frmDanhMucCongThucMauBieuBaoCao : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        CongThucMauBieuBaoCaoList _CongThucMauBieuBaoCaoList = CongThucMauBieuBaoCaoList.NewCongThucMauBieuBaoCaoList();
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private byte _loaiMauBaoCao = 0;
        private int _maThongTu = 0;

        ContextMenuStrip _contextMenuStripForgridControl1 = new ContextMenuStrip();
        #endregion properties

        #region Constructors
        public frmDanhMucCongThucMauBieuBaoCao()
        {
            InitializeComponent();
            KhoiTao();
            //DesignGridView();
            LoadData();
        }

        public frmDanhMucCongThucMauBieuBaoCao(byte loaibieumau, int mathongtu)
        {
            InitializeComponent();
            _loaiMauBaoCao = loaibieumau;
            _maThongTu = mathongtu;
            KhoiTao();
            //DesignGridView();
            LoadData();
        }
        #endregion Constructors

        #region Function

        private void KhoiTao()
        {
            CongThucMauBieuBaoCaoList_bindingSource1.DataSource = typeof(CongThucMauBieuBaoCaoList);
            //btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            CongThucMauBieuBaoCaoList_bindingSource1.DataSource = _CongThucMauBieuBaoCaoList;
            treeList.DataSource = CongThucMauBieuBaoCaoList_bindingSource1;
            //gridControl1.DataSource = CongThucMauBieuBaoCaoList_bindingSource1;
            InitMenuStrip();
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
        }
        private void LoadData()
        {
            _CongThucMauBieuBaoCaoList = CongThucMauBieuBaoCaoList.GetCongThucMauBieuBaoCaoList_ForTree(_loaiMauBaoCao, _maThongTu);
            CongThucMauBieuBaoCaoList_bindingSource1.DataSource = _CongThucMauBieuBaoCaoList;
            treeList.Refresh();
            treeList.ExpandAll();
        }

        //private void DesignGridView()
        //{
        //    HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
        //    HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaNguonKinhPhiQuanLy", "TenNguonKinhPhi", "TenNguonKPCha", "TenTCNguonKP", "TenMaNguonNSNN", "TenHTCP","MaLoaiKhoanQuanLy", "MaSoCapNS", "NgungTheoDoi" },
        //                        new string[] { "Mã nguồn KP", "Tên nguồn KP", "Thuộc nguồn KP", "Tính chất nguồn KP", "Mã nguồn NSNN", "Cấp phát ngầm định","Mã loại khoản", "Mã số cấp NS", "Ngừng theo dõi" },
        //                                     new int[] { 100, 150, 150, 150, 150, 150,150, 100, 100 });
        //    HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaNguonKinhPhiQuanLy", "TenNguonKinhPhi", "TenNguonKPCha", "TenTCNguonKP", "TenMaNguonNSNN", "TenHTCP", "MaLoaiKhoanQuanLy", "MaSoCapNS", "NgungTheoDoi" }, DevExpress.Utils.HorzAlignment.Center);


        //    HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

        //    Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

        //    gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        //    gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        //}

        private bool TestBeforeDelete()
        {
            return true;
        }

        private void DeleteObject()
        {
            //if (TestBeforeDelete())
            //{
            //    HamDungChung.DeleteSelectedRowsGridViewDev(gridView1);
            //}
        }

        private void InitMenuStrip()
        {
            _contextMenuStripForgridControl1.Size = new System.Drawing.Size(193, 114);
            //Item0
            System.Windows.Forms.ToolStripItem tsItemEditSeries0 = new System.Windows.Forms.ToolStripMenuItem();
            tsItemEditSeries0.Name = "CapNhatCTCongThucToolStripMenuItem";
            tsItemEditSeries0.Tag = "CapNhatCTCongThuc";
            tsItemEditSeries0.Size = new System.Drawing.Size(192, 22);
            tsItemEditSeries0.Text = "Cập nhật/Thêm chi tiết công thức";
            tsItemEditSeries0.Click += new System.EventHandler(this.editSeriesToolStripMenuItem_Click);
            _contextMenuStripForgridControl1.Items.Add(tsItemEditSeries0);
            //Item1
            System.Windows.Forms.ToolStripItem tsItemEditSeries1 = new System.Windows.Forms.ToolStripMenuItem();
            tsItemEditSeries1.Name = "ThemMucConToolStripMenuItem";
            tsItemEditSeries1.Tag = "ThemMucCon";
            tsItemEditSeries1.Size = new System.Drawing.Size(192, 22);
            tsItemEditSeries1.Text = "Thêm Mục Con";
            tsItemEditSeries1.Click += new System.EventHandler(this.editSeriesToolStripMenuItem_Click);
            _contextMenuStripForgridControl1.Items.Add(tsItemEditSeries1);
            //Item2
            System.Windows.Forms.ToolStripItem tsItemEditSeries2 = new System.Windows.Forms.ToolStripMenuItem();
            tsItemEditSeries2.Name = "XoaMucToolStripMenuItem";
            tsItemEditSeries2.Tag = "XoaMuc";
            tsItemEditSeries2.Size = new System.Drawing.Size(192, 22);
            tsItemEditSeries2.Text = "Xóa mục";
            tsItemEditSeries2.Click += new System.EventHandler(this.editSeriesToolStripMenuItem_Click);
            _contextMenuStripForgridControl1.Items.Add(tsItemEditSeries2);
           

            //gridControl1.ContextMenuStrip = _contextMenuStripForgridControl1;
            treeList.ContextMenuStrip = _contextMenuStripForgridControl1;
        }

        private void ThemMucCon()
        {
            //#region GridControl
            //if (IsMucCongThucBieuMau())
            //{
            //    CongThucMauBieuBaoCao congthuc = gridView1.GetFocusedRow() as CongThucMauBieuBaoCao;
            //    frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(congthuc, _loaiMauBaoCao, _maThongTu, true);
            //    //frm.ShowDialog();
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        LoadData();

            //    }//New
            //}
            //#endregion GridControl
            #region TreeList
            if (IsMucCongThucBieuMau())
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node;
                node = treeList.FocusedNode;
                int mamuc = (int)node.GetValue("MaMuc");
                CongThucMauBieuBaoCao congthuc = CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao(mamuc);
                frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(congthuc, _loaiMauBaoCao, _maThongTu, true);
                //frm.ShowDialog();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();

                }//New
            }
            else MessageBox.Show("Vui lòng chọn đúng mục để thực hiện (không chọn công thức)!");
            #endregion TreeList

        }

        private void CapNhatCongthucLaySo()
        {
            #region GridControl
            //if (IsMucCongThucBieuMau())
            //{
            //    CongThucMauBieuBaoCao congthuc = gridView1.GetFocusedRow() as CongThucMauBieuBaoCao;
            //    frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(congthuc, _loaiMauBaoCao, _maThongTu, false);
            //    //frm.ShowDialog();
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        LoadData();

            //    }//New
            //}
            #endregion GridControl

            #region TreeList
            if (IsMucCongThucBieuMau())
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode node;
                node = treeList.FocusedNode;
                int mamuc = (int)node.GetValue("MaMuc");
                CongThucMauBieuBaoCao congthuc = CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao(mamuc);
                frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(congthuc, _loaiMauBaoCao, _maThongTu, false);
                //frm.ShowDialog();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();

                }//New
            }
            else MessageBox.Show("Vui lòng chọn đúng mục để thực hiện (không chọn công thức)!");
            #endregion TreeList
        }

        private void XoaMucCongThuc()
        {
            if (IsMucCongThucBieuMau())
            {
                if (MessageBox.Show("Bạn muốn xóa mục đang chọn không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
                DevExpress.XtraTreeList.Nodes.TreeListNode node;
                node = treeList.FocusedNode;
                int mamuc = (int)node.GetValue("MaMuc");
                CongThucMauBieuBaoCao congthuc = CongThucMauBieuBaoCao.GetCongThucMauBieuBaoCao(mamuc);
                CongThucMauBieuBaoCao.DeleteCongThucMauBieuBaoCao(congthuc);
                LoadData();
            }
            else MessageBox.Show("Vui lòng chọn đúng mục để thực hiện (không chọn công thức)!");
        }

        private bool IsMucCongThucBieuMau()
        {
            #region GridControl
            //if (gridView1.GetFocusedRow() != null)
            //{
            //    CongThucMauBieuBaoCao congthuc = gridView1.GetFocusedRow() as CongThucMauBieuBaoCao;
            //    if (congthuc.MaMuc > 0)
            //    {
            //        return true;
            //    }
            //}
            //return false;
            #endregion GridControl

            #region TreeList
            DevExpress.XtraTreeList.Nodes.TreeListNode node;
            node = treeList.FocusedNode;
            if (node == null)
                return false;
            int mamuc;
            if (int.TryParse(node.GetValue("MaMuc").ToString(), out mamuc))
            {
                if (mamuc > 0)
                {
                    return true;
                }
            }
            return false;
            #endregion TreeList
        }


        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(_loaiMauBaoCao, _maThongTu);

            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //gridView1.ExportToXls(dlg.FileName);
                treeList.ExportToXlsx(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CongThucMauBieuBaoCaoList_bindingSource1.EndEdit();
                _CongThucMauBieuBaoCaoList.ApplyEdit();
                _CongThucMauBieuBaoCaoList.Save();
                //btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //LoadData();
                MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editSeriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem toolstripItem = (ToolStripItem)sender;
            if (toolstripItem.Tag != null)
            {
                if (toolstripItem.Tag.ToString() == "ThemMucCon")
                {
                    ThemMucCon();
                }
                else if (toolstripItem.Tag.ToString() == "CapNhatCTCongThuc")
                {
                    CapNhatCongthucLaySo();
                }
                else if (toolstripItem.Tag.ToString() == "XoaMuc")
                {
                    XoaMucCongThuc();
                }

            }
        }

        #endregion

        #region eventHandles
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    DeleteObject();
            //    btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}

        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            //if (gridView1.GetFocusedRow() != null)
            //{
            //    CongThucMauBieuBaoCao congthuc = gridView1.GetFocusedRow() as CongThucMauBieuBaoCao;

            //    frmCongThucMauBieuBaoCaoEdit frm = new frmCongThucMauBieuBaoCaoEdit(congthuc, _loaiMauBaoCao, _maThongTu);
            //    //frm.ShowDialog();
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        LoadData();

            //    }//New

            //}
        }
        #endregion eventHandles

        private void treeList_DoubleClick(object sender, EventArgs e)
        {
            CapNhatCongthucLaySo();
        }

    }
}
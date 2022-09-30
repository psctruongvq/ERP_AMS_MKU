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
    public partial class FrmCauTrucDoanhThuChiPhi : DevExpress.XtraEditors.XtraForm
    {
        CauTrucDoanhThuChiPhiList _CauTrucDoanhThuChiPhiList = CauTrucDoanhThuChiPhiList.NewCauTrucDoanhThuChiPhiList();
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        public FrmCauTrucDoanhThuChiPhi()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridView();
            LoadData();
        }

        private void KhoiTao()
        {
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = _CauTrucDoanhThuChiPhiList;
            gridControl1.DataSource = CauTrucDoanhThuChiPhiList_bindingSource1;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function


        private void LoadData()
        {
            _CauTrucDoanhThuChiPhiList = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_MaCongTy);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = _CauTrucDoanhThuChiPhiList;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "Ten", "MaQL", "EnglishName", "ParentIDString", "HoatDongString", "TinhChatSring", "NgungSuDung" },
                                new string[] { "Khoản mục", "Mã", "Tên tiếng anh", "Thuộc khoản mục", "thuộc hoạt động", "Thuộc", "Ngưng sử dụng" },
                                             new int[] { 200, 100, 100, 200,200,100,75});
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Ten", "MaQL", "EnglishName", "ParentIDString", "HoatDongString", "TinhChatSring", "NgungSuDung" }, DevExpress.Utils.HorzAlignment.Center);
           

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
        }

        private bool KiemTraChonDinhKhoanTuDongRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn định khoản cần thực hiện!");
                return false;
            }
            return true;
        }


        private bool TestBeforeDelete()
        {
            return true;
        }

        private void DeleteObject()
        {
            if (TestBeforeDelete())
            {
                HamDungChung.DeleteSelectedRowsGridViewDev(gridView1);
            }
        }
        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCauTrucDoanhThuChiPhiEdit frm = new FrmCauTrucDoanhThuChiPhiEdit();

            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }

        #endregion

        #region eventHandles
        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteObject();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                CauTrucDoanhThuChiPhi cautrucDTCP = gridView1.GetFocusedRow() as CauTrucDoanhThuChiPhi;

                FrmCauTrucDoanhThuChiPhiEdit frm = new FrmCauTrucDoanhThuChiPhiEdit(cautrucDTCP);
                //frm.ShowDialog();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();

                }//New

            }
        }
        #endregion eventHandles
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
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                CauTrucDoanhThuChiPhiList_bindingSource1.EndEdit();
                _CauTrucDoanhThuChiPhiList.ApplyEdit();
                _CauTrucDoanhThuChiPhiList.Save();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                MessageBox.Show("Lưu Thành Công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
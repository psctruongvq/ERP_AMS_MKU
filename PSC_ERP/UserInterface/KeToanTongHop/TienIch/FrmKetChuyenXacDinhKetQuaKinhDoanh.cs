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
    public partial class FrmKetChuyenXacDinhKetQuaKinhDoanh : DevExpress.XtraEditors.XtraForm
    {
        KetChuyenXacDinhKetQuaKinhDoanhList _ketchuyenXacDinhKetQuaKinhDoanhList = KetChuyenXacDinhKetQuaKinhDoanhList.NewKetChuyenXacDinhKetQuaKinhDoanhList();
        
        public FrmKetChuyenXacDinhKetQuaKinhDoanh()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridView();
            LoadData();

        }

        private void KhoiTao()
        {
            KetChuyenXacDinhKetQuaKinhDoanh_bindingSource.DataSource = _ketchuyenXacDinhKetQuaKinhDoanhList;
            gridControl1.DataSource = KetChuyenXacDinhKetQuaKinhDoanh_bindingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function


        private void LoadData()
        {
            _ketchuyenXacDinhKetQuaKinhDoanhList = KetChuyenXacDinhKetQuaKinhDoanhList.GetKetChuyenXacDinhKetQuaKinhDoanhList();  
            KetChuyenXacDinhKetQuaKinhDoanh_bindingSource.DataSource = _ketchuyenXacDinhKetQuaKinhDoanhList;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "ThuTuKC", "TenMaLoaiKetChuyen", "TaiKhoanKCString", "TaiKhoanNhanString", "LoaiKetChuyenString", "DienGiai", "NgungSuDung" },
                                new string[] { "Thứ tự kết chuyển", "Loại kết chuyển", "Kết chuyển từ", "Kết chuyển đến", "Bên kết chuyển", "Diễn giải", "Ngưng sử dụng" },
                                             new int[] { 100, 150, 100, 100,150,100,75});
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "ThuTuKC", "TenMaLoaiKetChuyen", "TaiKhoanKCString", "TaiKhoanNhanString", "LoaiKetChuyenString", "DienGiai", "NgungSuDung" }, DevExpress.Utils.HorzAlignment.Center);
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" },"#,###.#");
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            ////
            //RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            //LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            //LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            //LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            //HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien"}, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150}, true);
            //HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            //LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            //HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            ////
            //HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
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
            FrmKetChuyenXacDinhKetQuaKinhDoanhEdit frm = new FrmKetChuyenXacDinhKetQuaKinhDoanhEdit();

            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadData();
            }
        }


        
        #endregion

        #region eventHandles
        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                KetChuyenXacDinhKetQuaKinhDoanh congthucketchuyen = gridView1.GetFocusedRow() as KetChuyenXacDinhKetQuaKinhDoanh;
                congthucketchuyen = KetChuyenXacDinhKetQuaKinhDoanh.GetKetChuyenXacDinhKetQuaKinhDoanh(congthucketchuyen.Id);

                FrmKetChuyenXacDinhKetQuaKinhDoanhEdit frm = new FrmKetChuyenXacDinhKetQuaKinhDoanhEdit(congthucketchuyen);
                //frm.ShowDialog();
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    LoadData();

                }//New

            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteObject();
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
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
                KetChuyenXacDinhKetQuaKinhDoanh_bindingSource.EndEdit();
                _ketchuyenXacDinhKetQuaKinhDoanhList.ApplyEdit();
                _ketchuyenXacDinhKetQuaKinhDoanhList.Save();
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
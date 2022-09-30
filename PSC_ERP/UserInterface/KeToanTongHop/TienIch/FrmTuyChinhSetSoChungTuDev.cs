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
    public partial class FrmTuyChinhSetSoChungTuDev : DevExpress.XtraEditors.XtraForm
    {
        TuyChinhSetSoChungTuList _tuyChinhSetSoChungTu = TuyChinhSetSoChungTuList.NewTuyChinhSetSoChungTuList();
        int _userCurrent = ERP_Library.Security.CurrentUser.Info.UserID;
        public FrmTuyChinhSetSoChungTuDev()
        {
            InitializeComponent();
            KhoiTao();
            DesignGridView();
            LoadData();
        }

        private void KhoiTao()
        {
            TuyChinhSetSoChungTuList_bindingSource.DataSource = typeof(TuyChinhSetSoChungTuList);
            TuyChinhSetSoChungTuList_bindingSource.DataSource = _tuyChinhSetSoChungTu;
            gridControl1.DataSource = TuyChinhSetSoChungTuList_bindingSource;
            //gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function


        private void LoadData()
        {
            _tuyChinhSetSoChungTu = TuyChinhSetSoChungTuList.GetTuyChinhSetSoChungTuList(_userCurrent);  
            TuyChinhSetSoChungTuList_bindingSource.DataSource = _tuyChinhSetSoChungTu;
        }

        private void DesignGridView()
        {
            HamDungChung.InitGridViewDev(gridView1,true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false,true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "TenLoaiCT", "TienTo" ,"TrungTo" ,"HauTo" ,"TongKyTuPhanSo" ,"KyTuSoBatDau" },
                                new string[] { "loại chứng từ", "Tiền tố", "Trung tố", "Hậu tố", "Tổng ký tự phần sô", "Ký tự số bắt đầu" },
                                             new int[] { 150, 80, 80, 80, 80, 80 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "TenLoaiCT", "TienTo", "TrungTo", "HauTo", "TongKyTuPhanSo", "KyTuSoBatDau" }, DevExpress.Utils.HorzAlignment.Center);
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
            FrmTuyChinhSetSoChungTuDevEdit frm = new FrmTuyChinhSetSoChungTuDevEdit();

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
                TuyChinhSetSoChungTu tuychinhsetsct = gridView1.GetFocusedRow() as TuyChinhSetSoChungTu;

                FrmTuyChinhSetSoChungTuDevEdit frm = new FrmTuyChinhSetSoChungTuDevEdit(tuychinhsetsct);
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
                TuyChinhSetSoChungTuList_bindingSource.EndEdit();
                _tuyChinhSetSoChungTu.ApplyEdit();
                _tuyChinhSetSoChungTu.Save();
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
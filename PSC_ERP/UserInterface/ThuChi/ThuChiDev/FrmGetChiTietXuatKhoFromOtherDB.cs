using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmGetChiTietXuatKhoFromOtherDB : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        List<ChiTietXuatKhoFromOtherDB> _chitietxuatkhoList = new List<ChiTietXuatKhoFromOtherDB>();
        List<ChiTietXuatKhoFromOtherDB> _chitietxuatkhoaListSelected = new List<ChiTietXuatKhoFromOtherDB>();
        BindingSource ChiTietXuatKho_BindingSource = new BindingSource();

        public List<ChiTietXuatKhoFromOtherDB> ChiTietXuatKhoListSelected
        {
            get { return _chitietxuatkhoaListSelected; }

        }
        #endregion//Properties

        #region Function

        private void FormatForm()
        {
        }

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = ChiTietXuatKho_BindingSource;

            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TenTruong", "TenKhoi", "TenLop", "GhiChu" },
                               new string[] { "Chọn", "Số biên lai", "Ngày lập", "Mã học sinh", "Tên đối tượng", "Nội dung thu", "Số lượng", "Đơn giá", "Số tiền", "Trường", "Khối", "Lớp", "Ghi chú" },
                                            new int[] { 80, 100, 80, 80, 100, 100, 80, 100, 100, 100, 100, 100, 100 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TenTruong", "TenKhoi", "TenLop", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoLuong", "DonGia", "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoLuong", "SoTien"}, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TenTruong", "TenKhoi", "TenLop", "GhiChu" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            #endregion//Design Gridview

        }

        private void loadForm(string tenDoiTuong)
        {
            ChiTietXuatKho_BindingSource.DataSource = typeof(ChiTietXuatKhoFromOtherDB);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _chitietxuatkhoList = ChiTietXuatKhoFromOtherDB.LoadChiTietXuatBanDongPhucKhoFromOtherDBList(tenDoiTuong);
            ChiTietXuatKho_BindingSource.DataSource = _chitietxuatkhoList;
            DesignGridView();
        }

        public FrmGetChiTietXuatKhoFromOtherDB(string tenDoiTuong)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            FormatForm();
            loadForm(tenDoiTuong);

        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }


        #endregion //Function

        #region Events

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FocustextBox1.Focus();
            ChiTietXuatKho_BindingSource.EndEdit();
            foreach (ChiTietXuatKhoFromOtherDB gptg in _chitietxuatkhoList)
            {
                if (gptg.Check == true)
                {
                    _chitietxuatkhoaListSelected = ChiTietXuatKhoFromOtherDB.GetChiTietXuatBanDongPhucFromOtherDBList(gptg.MaBienLaiInt);
                }
            }
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


        private void btnExportDataExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        #endregion Events

    }
}
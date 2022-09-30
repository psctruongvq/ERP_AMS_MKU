using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
//13/04/2013
namespace PSC_ERP
{
    public partial class FrmGetBienLaiFronOtherDB : XtraForm
    {
        #region Properties
        List<ChiTietBienLaiFromOtherDB> _ctbienLaiList = new List<ChiTietBienLaiFromOtherDB>();
        List<ChiTietBienLaiFromOtherDB> _ctbienLaiListSelected = new List<ChiTietBienLaiFromOtherDB>();
        BindingSource DSBienLai_BindingSource = new BindingSource();

        public List<ChiTietBienLaiFromOtherDB> ChiTietBienLaiListSelected
        {
            get { return _ctbienLaiListSelected; }
        }

        private byte _kieuThuPhi = 1;//1: ThuPhí; 2: Hoàn Phí; 3: Phí dư
        #endregion//Properties

        #region Function

        private void FormatForm()
        {
            if (_kieuThuPhi == 1)//Thu Phí
            {
                this.Text = "Danh Sách Biên Lai";
            }
            else if (_kieuThuPhi == 2)//Hoàn Phí
            {
                this.Text = "Danh Sách Hoàn Phí";
            }
            else if (_kieuThuPhi == 3)//Phí Dư
            {
                this.Text = "Danh Sách Phí Dư";
            }
        }

        private void DesignGridView()
        {
            #region Design Gridview
            gridControl1.DataSource = DSBienLai_BindingSource;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            //        ,NULL AS PhanTramPhiPOS
            //,NULL AS TienPOSHoaDon
            HamDungChung.ShowFieldGridViewDev_Modify(gridView1, new string[] { "Check", "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TongTienNgoaiTe", "TienNgoaiTe", "TyGia", "MaNgoaiTe", "TienPos", "PhanTramPhiPOS", "TienPOSHoaDon", "SoTaiKhoan", "TenNganHang", "SoSeri", "TenGoiPhi", "TenTruong", "TenKhoi", "TenLop", "NamHoc", "NoiDungThu", "TenHinhThucThanhToan", "GhiChu" },
                                new string[] { "Chọn", "Số biên lai", "Ngày lập", "Mã học sinh", "Tên đối tượng", "Loại phí", "Số lượng", "Đơn giá", "Số tiền", "Tổng ngoại tệ", "Tiền ngoại tệ", "Tỷ giá", "Mã ngoại tệ", "Phí NH", "% phí NH", "Tổng Phí/Hóa đơn", "Số TK nhận", "Ngân hàng", "Số Seri", "Tên gói phí", "Trường", "Khối", "Lớp", "Năm học", "Nội dung thu", "Hình thức TT", "Ghi chú" },
                                             new int[] { 50, 70, 90, 90, 170, 170, 50, 100, 100, 80, 80, 80, 50, 50, 50, 50, 100, 80, 80, 50, 50, 50, 50, 80, 150, 80, 80 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "Check", "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TongTienNgoaiTe", "TienNgoaiTe", "TyGia","MaNgoaiTe", "TienPos", "PhanTramPhiPOS", "TienPOSHoaDon", "SoTaiKhoan", "TenNganHang", "SoSeri", "TenGoiPhi", "TenTruong", "TenKhoi", "TenLop", "NamHoc", "NoiDungThu", "TenHinhThucThanhToan", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoLuong", "DonGia", "SoTien", "TienPos", "PhanTramPhiPOS", "TienPOSHoaDon", "TongTienNgoaiTe", "TienNgoaiTe", "TyGia" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoLuong", "SoTien", "TienPos" }, "{0:#,###.#}");
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridView1, new string[] { "SoBienLai", "NgayLap", "MaQLDoiTuong", "TenDoiTuong", "DienGiai", "SoLuong", "DonGia", "SoTien", "TongTienNgoaiTe", "TienNgoaiTe", "TyGia", "MaNgoaiTe", "TienPos", "PhanTramPhiPOS", "TienPOSHoaDon", "SoTaiKhoan", "TenNganHang", "SoSeri", "TenGoiPhi", "TenTruong", "TenKhoi", "TenLop", "NamHoc", "NoiDungThu", "TenHinhThucThanhToan", "GhiChu" });
            HamDungChung.AllowEditColumnChooseGridViewDev(gridView1, new string[] { "Check" });
            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            #endregion//Design Gridview
        }

        private void loadForm(string tendoituong, int hinhthucthanhtoan, byte kieulap)//HinhThucThanhToan: 1-> Tiền mặt; 2 -> Chuyển Khoản
        {
            DSBienLai_BindingSource.DataSource = typeof(ChiTietBienLaiFromOtherDB);
            // chi lay nhung hoa don cua nguoi lap chung tu
            _ctbienLaiList = ChiTietBienLaiFromOtherDB.LoadChiTietBienLaiFromOtherDBList(tendoituong, hinhthucthanhtoan, kieulap);
            DSBienLai_BindingSource.DataSource = _ctbienLaiList;
            DesignGridView();
        }

        public FrmGetBienLaiFronOtherDB(string tendoituong, int hinhthucthanhtoan, byte kieulap)
        {//--kieulap=1: Thu Phí; kieulap=2: Hoàn Phí; 3: Phí dư
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _kieuThuPhi = kieulap;
            FormatForm();
            loadForm(tendoituong, hinhthucthanhtoan, kieulap);
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
            DSBienLai_BindingSource.EndEdit();
            foreach (ChiTietBienLaiFromOtherDB ctbl in _ctbienLaiList)
            {
                if (ctbl.Check == true)
                {
                    _ctbienLaiListSelected.Add(ctbl);
                }
            }
            this.Close();
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            HoaDon hd = (HoaDon)DSBienLai_BindingSource.Current;
            CheckEdit check = (CheckEdit)sender;
            hd.Check = (bool)check.EditValue;
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row = gridView1.GetDataRow(i);
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], true);
                }
                gridControl1.Select();
            }
            else
            {
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row = gridView1.GetDataRow(i);
                    gridView1.SetRowCellValue(i, gridView1.Columns["Check"], false);
                }
                gridControl1.Select();
            }
            gridControl1.RefreshDataSource();
        }
    }
}
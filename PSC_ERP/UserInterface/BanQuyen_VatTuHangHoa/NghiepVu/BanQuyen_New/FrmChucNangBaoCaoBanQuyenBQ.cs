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
using System.Data.SqlClient;
//05_08_2014
namespace PSC_ERP
{
    public partial class FrmChucNangBaoCaoBanQuyenBQ : DevExpress.XtraEditors.XtraForm
    {
        static int _hoanTat = -1;
        static int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        int _maBoPhan;
        long _maHopDong;
        int _maChuongTrinh;
        bool _timTheoNgay;
        bool _timTheoNgayPage2;
        DataTable _tableSourcePage1;
        DataTable _tableSourcePage2;
        public FrmChucNangBaoCaoBanQuyenBQ()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            HopDongMuaBanList _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);//M
            HopDongMuaBan hdmb = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _hopDongMuaBanList.Insert(0, hdmb);
            HopDongMuaBanList_BindingSource.DataSource = _hopDongMuaBanList;

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList_BQ(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewList;

            _tableSourcePage1 = new DataTable();
        }
        #region Function
        private void GetThongTinSearchPage1()
        {

            if (grdLU_BoPhan.EditValue != null)
            {
                _maBoPhan = Convert.ToInt32(grdLU_BoPhan.EditValue);
            }
            else
            {
                _maBoPhan = 0;
            }


            if (checkEdit_Ngay.EditValue != null)
            {
                _timTheoNgay = checkEdit_Ngay.Checked;

            }
            else
            {
                _timTheoNgay = false;
            }

        }

        private void GetThongTinSearchPage2()
        {

            if (gridU_HopDong.EditValue != null)
            {
                _maHopDong = Convert.ToInt64(gridU_HopDong.EditValue);
            }
            else
            {
                _maHopDong = 0;
            }


            if (gridLU_ChuongTrinh.EditValue != null)
            {
                _maChuongTrinh = Convert.ToInt32(gridLU_ChuongTrinh.EditValue);
            }
            else
            {
                _maChuongTrinh = 0;
            }


            if (checkEdit_Ngay2.EditValue != null)
            {
                _timTheoNgayPage2 = checkEdit_Ngay2.Checked;

            }
            else
            {
                _timTheoNgayPage2 = false;
            }

        }

        private DataTable Table_ChucNangBaoCaoBanQuyen(bool timTheoNgay, DateTime tuNgay, DateTime denNgay, int maBoPhan)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ChucNangBaoCaoBanQuyen_BQ";
                    cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        private DataTable Table_ChucNangTheoDoiChuongTrinhTheoHopDong_BQ(bool timTheoNgay, DateTime tuNgay, DateTime denNgay, long maHopDong, int maChuongTrinh)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ChucNangTheoDoiChuongTrinhTheoHopDong_BQ";
                    cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        private void LoadData()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                GetThongTinSearchPage1();
                _tableSourcePage1 = Table_ChucNangBaoCaoBanQuyen(_timTheoNgay, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maBoPhan);
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                GetThongTinSearchPage2();
                _tableSourcePage2 = Table_ChucNangTheoDoiChuongTrinhTheoHopDong_BQ(_timTheoNgay, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maHopDong, _maChuongTrinh);
            }

        }


        private void DesignGridViewPage1()
        {
            HamDungChung.InitGridViewDev(gridViewPage1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridViewPage1, new string[] { "MaQL", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "TenDoiTac", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "NgayNhap", "PhieuNhap", "NgayPS", "NgayXuat", "SoPhieuXuat", "NghiemThu", "TenNguon", "DienGiaiChiTiet", "TenBoPhan" },
                                new string[] { "Mã chương trình", "Tên chương trình", "ĐVT", "Nước SX", "TLượng", "Đơn giá", "Slg Đầu kỳ", "Giá trị Đầu kỳ", "Slg Nhập", "Giá trị Nhập", "Slg Xuất", "Giá trị Xuất", "Slg cuối", "Giá trị cuối", "Đối tác", "Số Hợp Đồng", "Ngày HĐồng", "Số hóa đơn", "Ngày hóa đơn", "Ngày nhập", "Số phiếu nhập", "Ngày PS", "Ngày xuất", "Số phiếu xuất", "Nghiệm thu", "Nguồn", "Ghi Chú", "Thuộc Bộ phận" },
                                             new int[] { 110, 120, 65, 85, 65, 100, 70, 120, 70, 120, 70, 120, 100, 120, 120, 100, 80, 120, 120, 80, 100, 80, 80, 120, 100, 120, 120, 100 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridViewPage1, new string[] { "MaQL", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "TenDoiTac", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "NgayNhap", "PhieuNhap", "NgayPS", "NgayXuat", "SoPhieuXuat", "NghiemThu", "TenNguon", "DienGiaiChiTiet", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage1, new string[] { "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage1, new string[] { "ThoiLuong" }, "{0:N1}");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridViewPage1, new string[] { "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "{0:n0}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridViewPage1);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage1, new string[] { "ThoiLuong", "DonGia", "SoLuongTonDau", "GiaTriTonDau", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage1, new string[] { "ThoiLuong" }, "{0:N1}");
            Utils.GridUtils.SetSTTForGridView(gridViewPage1, 40);//M
            gridViewPage1.GroupPanelText = "Danh Sách Chương Trình Nhập Xuất Tồn Bản Quyền";
        }

        private void DesignGridViewPage2()
        {
            HamDungChung.InitGridViewDev(gridViewPage2, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(gridViewPage2, new string[] { "MaQL", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuong", "GiaTri", "PhieuNhap", "NgayNhap", "DienGiaiChiTiet", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "TenDoiTac", "TenNguon", "TenBoPhan", "HinhThucCT" },
                                new string[] { "Mã chương trình", "Tên chương trình", "ĐVT", "Nước SX", "TLượng", "Đơn giá", "Số lượng", "Giá trị", "Số phiếu nhập", "Ngày nhập", "Ghi Chú", "Số Hợp Đồng", "Ngày HĐồng", "Số hóa đơn", "Ngày hóa đơn", "Đối tác", "Nguồn", "Thuộc Bộ phận", "Hình thức CT" },
                                             new int[] { 110, 120, 65, 85, 65, 100, 70, 120, 90, 85, 120, 90, 85, 90, 85, 120, 120, 120, 120 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridViewPage2, new string[] { "MaQL", "TenChuongTrinh", "TenDonViTinh", "TenQuocGia", "ThoiLuong", "DonGia", "SoLuong", "GiaTri", "PhieuNhap", "NgayNhap", "DienGiaiChiTiet", "SoHopDong", "NgayHopDong", "SoHoaDon", "NgayHoaDon", "TenDoiTac", "TenNguon", "TenBoPhan", "HinhThucCT" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage2, new string[] { "DonGia", "SoLuong", "GiaTri" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage2, new string[] { "ThoiLuong" }, "{0:N1}");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridViewPage2, new string[] { "SoLuong", "GiaTri" }, "{0:n0}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridViewPage2);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage2, new string[] { "DonGia", "SoLuong", "GiaTri" }, "#,###");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridViewPage2, new string[] { "ThoiLuong" }, "{0:N1}");
            Utils.GridUtils.SetSTTForGridView(gridViewPage2, 40);//M
            gridViewPage2.GroupPanelText = "Theo Dõi Chương Trình Theo Hợp Đồng";
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                gridViewPage1.Columns.Clear();
                _tableSourcePage1 = new DataTable();
                LoadData();
                gridControl1.DataSource = _tableSourcePage1;
                DesignGridViewPage1();
                if (_tableSourcePage1.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                gridViewPage2.Columns.Clear();
                _tableSourcePage2 = new DataTable();
                LoadData();
                gridControl2.DataSource = _tableSourcePage2;
                DesignGridViewPage2();
                if (_tableSourcePage2.Rows.Count == 0)//M
                    MessageBox.Show("Danh Sách Rỗng");
            }
        }


        #endregion

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
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridViewPage1.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    gridViewPage2.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            }
        }





        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_TuNgay2.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay2.EditValue = (object)DateTime.Today.Date;
        }
    }
}
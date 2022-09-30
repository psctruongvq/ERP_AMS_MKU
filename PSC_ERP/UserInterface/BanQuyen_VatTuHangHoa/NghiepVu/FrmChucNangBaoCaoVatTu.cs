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

namespace PSC_ERP
{
    public partial class FrmChucNangBaoCaoVatTu : DevExpress.XtraEditors.XtraForm
    {
        int _maKho;
        int _maBoPhan;
        bool _timTheoNgay;
        DataTable _tableSource;
        public FrmChucNangBaoCaoVatTu()
        {
            InitializeComponent();
            KhoiTao();

        }

        private void KhoiTao()
        {
            KhoBQ_VTList _KhoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            KhoBQ_VT _KhoBQ_VT = KhoBQ_VT.NewKhoBQ_VT();
            _KhoBQ_VT.TenKho = "Không Chọn";
            _KhoBQ_VTList.Insert(0, _KhoBQ_VT);
            khoBQVTListBindingSource.DataSource = _KhoBQ_VTList;

            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            _tableSource = new DataTable();
        }
        #region Function
        private void GetThongTinSearch()
        {

            if (grdLU_Kho.EditValue != null)
            {
                _maKho = Convert.ToInt32(grdLU_Kho.EditValue);
            }
            else
            {
                _maKho = 0;
            }

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
                _timTheoNgay =checkEdit_Ngay.Checked;

            }
            else
            {
                _timTheoNgay = false;
            }

        }

        private DataTable Table_ChucNangBaoCaoVatTu(bool timTheoNgay, DateTime tuNgay, DateTime denNgay, int maKho,int maBoPhan)
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
                    if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNhapXuatTonKhoVatTuHangHoa")
                    {
                        cm.CommandText = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru";
                    }
                    else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiDSPhieuXuatTheoDonVi")
                    {
                        cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat_DonVi";
                        cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    }
                    else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNXT")
                    {
                        cm.CommandText = "Spd_ChucNangTheoDoiVatTuNXT";
                        cm.Parameters.AddWithValue("@TimTheoNgay", timTheoNgay);
                        cm.Parameters.AddWithValue("@MaKho", maKho);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        

                    }
                   
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    
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
            GetThongTinSearch();
            _tableSource = Table_ChucNangBaoCaoVatTu(_timTheoNgay, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maKho,_maBoPhan); 
            
        }


        private void DesignGridView()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNhapXuatTonKhoVatTuHangHoa")
            {
                HamDungChung.InitGridViewDev(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
                HamDungChung.ShowFieldGridViewDev2(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, new string[] { "TenVTHH", "MaVatTu", "DVT", "SLTonDauThang", "gtTonDauThang", "SLNhapMoiTrongThang", "gtNhapMoiTrongThang", "SLXuatTrongThang", "gtXuatTrongThang", "SLTonKhoCuoiThang", "gtTonKhoCuoiThang", "TenNhomHangHoa", "TenKho" },
                                    new string[] { "Tên vật tư hàng hóa dự trữ", "Mã vật tư", "ĐVT", "Số lượng Tồn Đầu", "Giá trị Tồn Đầu", "Số lượng Nhập", "Giá trị Nhập", "Số lượng Xuất", "Giá trị Xuất", "Số Lượng Tồn Cuối", "Giá Trị Tồn Cuối", "Thuộc Nhóm Vật Tư", "Thuộc Kho" },
                                                 new int[] { 120, 85, 75, 100, 120, 100, 120, 100, 120, 100, 120,120,120 }, false);
                HamDungChung.AlignHeaderColumnGridViewDev(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, new string[] { "TenVTHH", "MaVatTu", "DVT", "SLTonDauThang", "gtTonDauThang", "SLNhapMoiTrongThang", "gtNhapMoiTrongThang", "SLXuatTrongThang", "gtXuatTrongThang", "SLTonKhoCuoiThang", "gtTonKhoCuoiThang", "TenNhomHangHoa", "TenKho" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, new string[] { "SLTonDauThang", "gtTonDauThang", "SLNhapMoiTrongThang", "gtNhapMoiTrongThang", "SLXuatTrongThang", "gtXuatTrongThang", "SLTonKhoCuoiThang", "gtTonKhoCuoiThang" }, "#,###.#");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, new string[] { "SLTonDauThang", "gtTonDauThang", "SLNhapMoiTrongThang", "gtNhapMoiTrongThang", "SLXuatTrongThang", "gtXuatTrongThang", "SLTonKhoCuoiThang", "gtTonKhoCuoiThang" }, "{0:#,###.#}");

                HamDungChung.ReadOnlyColumnGridViewDev(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa);

                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, new string[] { "SLTonDauThang", "gtTonDauThang", "SLNhapMoiTrongThang", "gtNhapMoiTrongThang", "SLXuatTrongThang", "gtXuatTrongThang", "SLTonKhoCuoiThang", "gtTonKhoCuoiThang" }, "#,###.#");
                Utils.GridUtils.SetSTTForGridView(gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa, 40);//M
                gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa.GroupPanelText = "Danh Sách Theo Dõi Nhập Xuất Tồn Kho Vật Tư Hàng Hóa";
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiDSPhieuXuatTheoDonVi")
            {
                HamDungChung.InitGridViewDev(gridView_TheoDoiDSPhieuXuatTheoDonVi, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
                HamDungChung.ShowFieldGridViewDev2(gridView_TheoDoiDSPhieuXuatTheoDonVi, new string[] {"TenDonVi", "NgayChungTu", "SoChungTu", "TenVatTu", "DVT", "SoLuong", "DonGia", "ThanhTien", "TenNguoiNhan", "LyDoSuDung" },
                                    new string[] {"Đơn vị", "Ngày C.từ", "Số chứng từ", "Tên Vật tư - Thiết vị - Công cụ", "ĐVT", "S.Lượng", "Đơn giá", "Thành tiền", "Người nhận", "Lý do sử dụng" },
                                                 new int[] {100, 85, 100, 150, 85, 85, 120, 120, 120, 200 }, false);
                HamDungChung.AlignHeaderColumnGridViewDev(gridView_TheoDoiDSPhieuXuatTheoDonVi, new string[] { "TenDonVi", "NgayChungTu", "SoChungTu", "TenVatTu", "DVT", "SoLuong", "DonGia", "ThanhTien", "TenNguoiNhan", "LyDoSuDung" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiDSPhieuXuatTheoDonVi, new string[] { "SoLuong", "DonGia", "ThanhTien" }, "#,###.#");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_TheoDoiDSPhieuXuatTheoDonVi, new string[] { "SoLuong", "ThanhTien" }, "{0:#,###.#}");

                HamDungChung.ReadOnlyColumnGridViewDev(gridView_TheoDoiDSPhieuXuatTheoDonVi);

                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiDSPhieuXuatTheoDonVi, new string[] { "SoLuong", "DonGia", "ThanhTien" }, "#,###.#");
                Utils.GridUtils.SetSTTForGridView(gridView_TheoDoiDSPhieuXuatTheoDonVi, 40);//M
                gridView_TheoDoiDSPhieuXuatTheoDonVi.GroupPanelText = "Danh Sách Chi Tiết Vật Tư Phiếu Xuất Theo Đơn Vị";
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNXT")
            {
                HamDungChung.InitGridViewDev(gridView_TheoDoiNXT, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
                HamDungChung.ShowFieldGridViewDev2(gridView_TheoDoiNXT, new string[] { "TenHangHoa", "TenDonViTinh", "DonGia", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "NgayNhap", "PhieuNhap", "TenDoiTac", "SoHoaDon", "NgayHoaDon", "NgayXuat", "SoPhieuXuat" },
                                    new string[] { "Tên vật tư", "ĐVT", "Đơn giá", "SLg Nhập", "Giá trị Nhập", "SLg Xuất","Giá trị Xuất","Slg còn","Giá trị còn", "Ngày nhập","Số phiếu nhập","Đối tác","Số hóa đơn","Ngày hóa đơn","Ngày xuất","Số phiếu Xuất" },
                                                 new int[] {100, 85, 100, 85, 120, 85, 120, 85, 120, 85,100,120,120,120,150,150 }, false);
                HamDungChung.AlignHeaderColumnGridViewDev(gridView_TheoDoiNXT, new string[] { "TenHangHoa", "TenDonViTinh", "DonGia", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi", "NgayNhap", "PhieuNhap", "TenDoiTac", "SoHoaDon", "NgayHoaDon", "NgayXuat", "SoPhieuXuat" }, DevExpress.Utils.HorzAlignment.Center);
                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiNXT, new string[] { "DonGia", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###.#");
                HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_TheoDoiNXT, new string[] { "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "{0:#,###.#}");

                HamDungChung.ReadOnlyColumnGridViewDev(gridView_TheoDoiNXT);

                HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_TheoDoiNXT, new string[] { "DonGia", "SoLuongNhap", "GiaTriNhap", "SoLuongXuat", "GiaTriXuat", "SoLuongTonCuoi", "GiaTriTonCuoi" }, "#,###.#");
                Utils.GridUtils.SetSTTForGridView(gridView_TheoDoiNXT, 40);//M
                gridView_TheoDoiNXT.GroupPanelText = "Thông Tin Danh Sách Chi Tiết Vật Tư Phiếu Nhập";
            }
            
        }

        private void LoadControlDieuKien()
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNhapXuatTonKhoVatTuHangHoa")
            {
                labelControl6.Visible = false;
                grdLU_BoPhan.Visible = false;
                labelControl5.Visible = false;
                grdLU_Kho.Visible = false;
                checkEdit_Ngay.Visible = false;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiDSPhieuXuatTheoDonVi")
            {
                labelControl6.Visible = true;
                grdLU_BoPhan.Visible = true;
                labelControl5.Visible = false;
                grdLU_Kho.Visible = false;
                checkEdit_Ngay.Visible = false;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNXT")
            {
                labelControl6.Visible = false;
                grdLU_BoPhan.Visible = false;
                labelControl5.Visible = true;
                grdLU_Kho.Visible = true;
                checkEdit_Ngay.Visible = true;
            }
        }

        #endregion

        #region Event

        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
           
            _tableSource = new DataTable();
            LoadData();
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNhapXuatTonKhoVatTuHangHoa")
            {
                gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa.Columns.Clear();
                gridControl_TheoDoiNhapXuatTonKhoVatTuHangHoa.DataSource = _tableSource;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiDSPhieuXuatTheoDonVi")
            {
                gridView_TheoDoiDSPhieuXuatTheoDonVi.Columns.Clear();
                gridControl3.DataSource = _tableSource;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNXT")
            {
                gridView_TheoDoiNXT.Columns.Clear();
                gridControl1.DataSource = _tableSource;
            }

            DesignGridView();
            if (_tableSource.Rows.Count == 0)//M
                MessageBox.Show("Danh Sách Rỗng");
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
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNhapXuatTonKhoVatTuHangHoa")
                {
                    gridView_TheoDoiNhapXuatTonKhoVatTuHangHoa.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
                else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiDSPhieuXuatTheoDonVi")
                {
                    gridView_TheoDoiDSPhieuXuatTheoDonVi.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
                else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage_TheoDoiNXT")
                {
                    gridView_TheoDoiNXT.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }

            }
        }



     

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            LoadControlDieuKien();

            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadControlDieuKien();
        }
    }
}
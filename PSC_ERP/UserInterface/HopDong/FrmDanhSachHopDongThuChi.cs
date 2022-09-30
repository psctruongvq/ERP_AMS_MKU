using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.OleDb;
using PSC_ERP_Common;

namespace PSC_ERP
{
    public partial class FrmDanhSachHopDongThuChi : XtraForm
    {
        HopDongThuChiList _hopDongThuChiList = HopDongThuChiList.NewHopDongMuaBanList();
        string _maLoaiHDQL;
        int _maLoaiHopDong;
        //Thong Tin Search
        int _maPhanLoaiHD = 0;
        int _maDuAn = 0;
        int _maBoPhanChuQuan = 0;
        long _maDoiTac = 0;
        long _maHopDong = 0;

        private bool _isNam2014 = false;
        string _FileNameImport = "";
        DataSet _dataSet = new DataSet();
        private DataTable tblHopDong;
        public FrmDanhSachHopDongThuChi()
        {
            InitializeComponent();
        }

        public void ShowHopDongBanQuyen()
        {
            _maLoaiHDQL = "HDBQ";
            _isNam2014 = false;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            KhoiTao();
            DesignGridView_HDBQ();
            this.Text = "Danh Sách Hợp Đồng Bản Quyền";
            this.Show();

            FormatThongTinTimKiem(true);
        }

        public void ShowHopDongDoanhThu()
        {
            _maLoaiHDQL = "HDDT";
            _isNam2014 = false;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            KhoiTao();
            DesignGridView_HDDT();
            this.Text = "Danh Sách Hợp Đồng DoanhThu";
            this.Show();

            FormatThongTinTimKiem(true);
        }

        public void ShowHopDongMuaSam()
        {
            _maLoaiHDQL = "HDMS";
            _isNam2014 = false;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            KhoiTao();
            DesignGridView_HDMS();
            this.Text = "Danh Sách Hợp Đồng Mua Sắm";
            this.Show();

            FormatThongTinTimKiem(true);
        }

        public void ShowHopDongDuAn()
        {
            _maLoaiHDQL = "HDDA";
            _isNam2014 = false;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            KhoiTao();
            DesignGridView_HDDA();
            this.Text = "Danh Sách Hợp Đồng Dự Án";
            this.Show();

            FormatThongTinTimKiem(true);
        }

        public void ShowHopDongNam2014()
        {
            _maLoaiHDQL = "HDBQ";
            _isNam2014 = true;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            KhoiTao();
            DesignGridView_HDDT();
            this.Text = "Danh Sách Hợp Đồng trong đài Năm 2014";
            this.Show();

            FormatThongTinTimKiem(false);
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            DoiTacList _doiTacList = DoiTacList.GetDoiTacList("", 0);
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _doiTacList.Insert(0, _doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;

            PhanLoaiHopDongList _phanLoaiHopDongList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDong _pLHD = PhanLoaiHopDong.NewPhanLoaiHopDong(0, "Không chọn");
            _phanLoaiHopDongList.Insert(0, _pLHD);
            PhanLoaiHopDongList_bindingSource.DataSource = _phanLoaiHopDongList;

            //boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanListBy_All();
            //doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            HeThongTaiKhoan1List _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("Không chọn");
            _taiKhoanList.Insert(0, httk);
            heThongTaiKhoan1ListBindingSource.DataSource = _taiKhoanList;
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll(); ;

            HopDongThuChi hopdong = HopDongThuChi.NewHopDongMuaBan(0, "Không chọn");
            HopDongThuChiList hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanByUserID_MaLoaiHopDong(_maLoaiHopDong);
            hopDongThuChiList.Insert(0, hopdong);
            HopDongThuChiList_bindingSource1.DataSource = hopDongThuChiList;

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;
            gridControl1.DataSource = HopDongThuChiList_bindingSource;
            gridControl1.ContextMenuStrip = contextMenuStrip1;
        }

        #region Function
        private void FormatThongTinTimKiem(bool isUnLock)
        {
            groupControl1.Enabled = isUnLock;
        }

        private void GetThongTinSearch()
        {
            if (grdLU_MaPhanLoaiHD.EditValue != null)
            {
                _maPhanLoaiHD = (int)grdLU_MaPhanLoaiHD.EditValue;
            }
            else
            {
                _maPhanLoaiHD = 0;
            }

            if (GrdLU_MaDuAn.EditValue != null)
            {
                _maDuAn = (int)GrdLU_MaDuAn.EditValue;
            }
            else
            {
                _maDuAn = 0;
            }

            if (lookUpEdit_PhongBan.EditValue != null)
            {
                _maBoPhanChuQuan = Convert.ToInt32(lookUpEdit_PhongBan.EditValue);//(int) lookUpEdit_PhongBan.EditValue;
            }
            else
            {
                _maBoPhanChuQuan = 0;
            }

            if (grdLU_MaDoiTac.EditValue != null)
            {
                _maDoiTac = Convert.ToInt64(grdLU_MaDoiTac.EditValue);// (long)grdLU_MaDoiTac.EditValue;
            }
            else
            {
                _maDoiTac = 0;
            }

            if (grdLU_MaHopDong.EditValue != null)
            {
                _maHopDong = (long)grdLU_MaHopDong.EditValue;
            }
            else
            {
                _maHopDong = 0;
            }
        }

        private void LoadData()
        {
            if (_isNam2014)
            {
                _hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanTuFileExcelNam2014();
            }
            else
            {
                GetThongTinSearch();
                if (_maHopDong != 0)
                {
                    _hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBan_PhuLucByMaHopDong(_maHopDong);
                }
                else if (checkEdit_Ngay.Checked == true)
                {
                    _hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanByNgayKy((Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _maLoaiHopDong, _maPhanLoaiHD, _maDoiTac, _maBoPhanChuQuan, _maDuAn);
                }
                else
                {
                    _hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanByWithoutNgayKy(_maLoaiHopDong, _maPhanLoaiHD, _maDoiTac, _maBoPhanChuQuan, _maDuAn);
                }
            }
            HopDongThuChiList_bindingSource.DataSource = _hopDongThuChiList;
        }

        private void LoadDSLocTheoSoHopDong()
        {
            HopDongThuChi hopdong = HopDongThuChi.NewHopDongMuaBan(0, "Không chọn");
            HopDongThuChiList hopDongThuChiList = HopDongThuChiList.GetHopDongMuaBanByUserID_MaLoaiHopDong(_maLoaiHopDong);
            hopDongThuChiList.Insert(0, hopdong);
            HopDongThuChiList_bindingSource1.DataSource = hopDongThuChiList;
        }

        private void DesignGridView_HDBQ()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "SoThamDinh", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng/Phụ lục", "Nội dung", "Số thẩm định", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Từ ngày", "Ngày hết hạn", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 120, 100, 90, 100, 75, 70, 70, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "SoThamDinh", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGridView_HDDT()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng/Phụ lục", "Nội dung", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Từ ngày", "Ngày hết hạn", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 120, 100, 100, 75, 70, 70, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGridView_HDDA()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "MaDuAn", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng/Phụ lục", "Nội dung", "Thuộc dự án", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Từ ngày", "Ngày hết hạn", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 120, 100, 75, 100, 75, 70, 70, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "MaDuAn", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit MaDuAn_GrdLU = new RepositoryItemGridLookUpEdit();
            MaDuAn_GrdLU.DataSource = heThongTaiKhoan1ListBindingSource1;
            MaDuAn_GrdLU.DisplayMember = "SoHieuTK";
            MaDuAn_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(MaDuAn_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(MaDuAn_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Tài khoản", "Tên tài khoản" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(MaDuAn_GrdLU);
            MaDuAn_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaDuAn", MaDuAn_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGridView_HDMS()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "SoThamDinh", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac", "GhiChu" },
                                new string[] { "Số hợp đồng/Phụ lục", "Nội dung", "Số thẩm định", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Từ ngày", "Ngày hết hạn", "Đơn vị chủ quản", "Đối tác", "Người liên lạc", "Ghi chú" },
                                             new int[] { 120, 100, 90, 100, 75, 70, 70, 70, 100, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "SoThamDinh", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private void DesignGridView_HDNam2014()
        {
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" },
                                new string[] { "Số hợp đồng/Phụ lục", "Nội dung", "Giá trị HĐ", "Loại tiền", "Ngày ký", "Từ ngày", "Ngày hết hạn", "Đơn vị chủ quản", "Đối tác", "Người liên lạc" },
                                             new int[] { 120, 100, 100, 75, 70, 70, 70, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "SoHopDong", "TenHopDong", "TongTien", "MaLoaiTien", "NgayKy", "TuNgay", "NgayHetHan", "DonViChuQuan", "TenDoiTac", "TenNguoiLienLac" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "{0:#,###.#}");

            HamDungChung.ReadOnlyColumnGridViewDev(gridView1);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien" }, new string[] { "Mã", "Loại tiền" }, new int[] { 100, 150 }, true);
            HamDungChung.AddButtonForRepositoryItemGridLookUpDev(LoaiTien_GrdLU);
            LoaiTien_GrdLU.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.GridLookUpEdit_MaDuAn_ButtonClick);

            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaLoaiTien", LoaiTien_GrdLU);
            //

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "TongTien" }, "#,###.#");
            gridView1.DoubleClick += new System.EventHandler(this.GrdView1_DoubleClick);
        }

        private bool KiemTraChonHopDongRow()
        {
            if (gridView1.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng cần thực hiện!");
                return false;
            }
            return true;
        }

        private void KhoaControl()
        {
            grdLU_MaPhanLoaiHD.Enabled = false;
            GrdLU_MaDuAn.Enabled = false;
            lookUpEdit_PhongBan.Enabled = false;
            grdLU_MaDoiTac.Enabled = false;
            checkEdit_Ngay.Enabled = false;
            dtEdit_TuNgay.Enabled = false;
            dtEdit_DenNgay.Enabled = false;
        }

        private void MoKhoaControl()
        {
            grdLU_MaPhanLoaiHD.Enabled = true;
            GrdLU_MaDuAn.Enabled = true;
            lookUpEdit_PhongBan.Enabled = true;
            grdLU_MaDoiTac.Enabled = true;
            checkEdit_Ngay.Enabled = true;
            dtEdit_TuNgay.Enabled = true;
            dtEdit_DenNgay.Enabled = true;
        }

        #endregion

        #region Event
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = new XtraForm();
            if (_maLoaiHDQL == "HDBQ")
            {
                frm = new FrmHopDongBanQuyen();
            }
            else if (_maLoaiHDQL == "HDDT")
            {
                frm = new FrmHopDongDoanhThu();
            }
            else if (_maLoaiHDQL == "HDDA")
            {
                frm = new frmHopDongDuAn();
            }
            else if (_maLoaiHDQL == "HDMS")
            {
                frm = new frmHopDongMuaSam();
            }

            if (frm.ShowDialog() != DialogResult.OK)
            {
                LoadData();
                LoadDSLocTheoSoHopDong();
            }
        }
        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
            if (_hopDongThuChiList.Count == 0)//M
                MessageBox.Show("Danh Sách Hợp đồng rỗng!");
        }

        private void GridLookUpEdit_MaDuAn_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void GrdView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRow() != null)
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);

                XtraForm frm = new XtraForm();
                if (_isNam2014)
                {
                    if (hopDongThuChi.LaPhuLuc)
                        frm = new FrmPhuLucHopDongBanQuyen(hopDongThuChi, true, true, "Phụ Lục Hợp Đồng từ Hợp Đồng của file excel của năm 2014");
                    else
                        frm = new FrmHopDongBanQuyen(hopDongThuChi, true, "Hợp Đồng từ file Excel của năm 2014");
                }
                else
                {
                    if (_maLoaiHDQL == "HDBQ")
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new FrmPhuLucHopDongBanQuyen(hopDongThuChi, true);
                        else
                            frm = new FrmHopDongBanQuyen(hopDongThuChi);
                    }
                    else if (_maLoaiHDQL == "HDMS")
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new FrmPhuLucHopDongMuaSam(hopDongThuChi, true);
                        else
                            frm = new frmHopDongMuaSam(hopDongThuChi);
                    }
                    else if (_maLoaiHDQL == "HDDA")
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new FrmPhuLucHopDongDuAn(hopDongThuChi, true);
                        else
                            frm = new frmHopDongDuAn(hopDongThuChi);
                    }
                    else if (_maLoaiHDQL == "HDDT")
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new FrmPhuLucHopDongDoanhThu(hopDongThuChi, true);
                        else
                            frm = new FrmHopDongDoanhThu(hopDongThuChi);
                    }
                }

                //frm.ShowDialog();
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    btn_Tim.PerformClick();
                    LoadDSLocTheoSoHopDong();
                }//New
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
            //HamDungChung.ExportToExcelFromGridViewDev(gridView1);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                gridView1.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void PhuLucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(hopDongThuChi.MaHopDong);

                if (hopDongThuChi.LaPhuLuc == true)
                {
                    MessageBox.Show("Không chọn Phụ lục để phát sinh phụ lục mới.\n Hãy chọn Hợp đồng để phát sinh phụ lục tiếp theo!");
                }
                //else if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(hopDongThuChi.MaHopDong))
                //{
                //    MessageBox.Show("Hợp đồng đã Nghiệm thu Thanh lý, không thể phát sinh Phụ lục!");
                //}
                else
                {
                    //
                    XtraForm frm = new XtraForm();
                    if (_isNam2014)
                    {
                        frm = new FrmPhuLucHopDongBanQuyen(hopDongThuChi, false, _isNam2014, "");
                    }
                    else
                    {
                        if (_maLoaiHDQL == "HDBQ")
                        {
                            frm = new FrmPhuLucHopDongBanQuyen(hopDongThuChi, false);
                        }
                        else if (_maLoaiHDQL == "HDDT")
                        {
                            frm = new FrmPhuLucHopDongDoanhThu(hopDongThuChi, false);
                        }
                        else if (_maLoaiHDQL == "HDDA")
                        {
                            frm = new FrmPhuLucHopDongDuAn(hopDongThuChi, false);
                        }
                        else if (_maLoaiHDQL == "HDMS")
                        {
                            frm = new FrmPhuLucHopDongMuaSam(hopDongThuChi, false);
                        }
                    }

                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                    //
                }
            }
        }

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void NghiemThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                if (hopDongThuChi.LaPhuLuc == true)
                {
                    MessageBox.Show("Không chọn Phụ lục để Nghiệm thu.\n Hãy chọn Hợp đồng để Nghiệm thu!");
                }
                //else if (HopDongThuChi.KiemTraHopDongDaThanhly(hopDongThuChi.MaHopDong))
                //{
                //    MessageBox.Show("Hợp đồng đã Nghiệm thu Thanh lý hay đã Thanh Lý. Không thể thực hiện!");
                //}
                else
                {
                    //
                    XtraForm frm = new XtraForm();
                    frm = new FrmThanhLy(hopDongThuChi.MaHopDong, 1);
                    frm.Show();
                    //
                }
            }
        }

        private void NghiemThuThanhLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                if (hopDongThuChi.LaPhuLuc == true)
                {
                    MessageBox.Show("Không chọn Phụ lục để Nghiệm thu Thanh lý.\n Hãy chọn Hợp đồng để Nghiệm thu Thanh lý!");
                }
                else if (HopDongThuChi.KiemTraHopDongDaThanhly(hopDongThuChi.MaHopDong))
                {
                    MessageBox.Show("Hợp đồng đã Nghiệm thu Thanh lý hay đã Thanh Lý. Không thể thực hiện!");
                }
                else
                {
                    //

                    XtraForm frm = new XtraForm();
                    frm = new FrmThanhLy(hopDongThuChi.MaHopDong, 3);
                    frm.Show();
                    //
                }
            }
        }

        private void ThanhLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonHopDongRow())
            {
                HopDongThuChi hopDongThuChi = gridView1.GetFocusedRow() as HopDongThuChi;
                if (hopDongThuChi.LaPhuLuc == true)
                {
                    MessageBox.Show("Không chọn Phụ lục để Thanh lý.\n Hãy chọn Hợp đồng để Thanh lý!");
                }
                else if (HopDongThuChi.KiemTraHopDongDaThanhly(hopDongThuChi.MaHopDong))
                {
                    MessageBox.Show("Hợp đồng đã Nghiệm thu Thanh lý hay đã Thanh Lý. Không thể thực hiện!");
                }
                else
                {
                    //

                    XtraForm frm = new XtraForm();
                    frm = new FrmThanhLy(hopDongThuChi.MaHopDong, 2);
                    frm.Show();
                    //
                }
            }
        }

        private void grdLU_MaHopDong_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLU_MaHopDong.EditValue != null)
            {
                long maHopDong;
                if (long.TryParse(grdLU_MaHopDong.EditValue.ToString(), out maHopDong))
                {
                    if (maHopDong != 0)
                    {
                        KhoaControl();
                    }
                    else
                    {
                        MoKhoaControl();
                    }
                    btn_Tim.PerformClick();
                }
                else
                {
                    MoKhoaControl();
                }
            }
            else
            {
                MoKhoaControl();
            }
        }
        private long KiemTraTonTaiDoiTac(string MaQLDoiTac)
        {
            DoiTacList doiTacListFull = DoiTacList.GetDoiTacList("", 0);
            foreach (DoiTac item in doiTacListFull)
            {
                if (item.MaQLDoiTac.ToUpper() == MaQLDoiTac.ToUpper())
                {
                    return item.MaDoiTac;
                }
            }
            return 0;
        }
        private int KiemTraTonTaiLoaiHopDong(string MaQLLoaiHD)
        {
            LoaiHopDongList loaiHopDongListFull = LoaiHopDongList.GetLoaiHopDongList();
            foreach (LoaiHopDong item in loaiHopDongListFull)
            {
                if (item.MaQuanLy.ToUpper() == MaQLLoaiHD.ToUpper())
                {
                    return item.MaLoaiHopDong;
                }
            }
            return 0;
        }
        private int KiemTraTonTaiPhanLoaiHopDong(string MaQLPhanLoaiHD)
        {
            PhanLoaiHopDongList loaiHopDongListFull = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            foreach (PhanLoaiHopDong item in loaiHopDongListFull)
            {
                if (item.MaPhanLoaiHDQL.ToUpper() == MaQLPhanLoaiHD.ToUpper())
                {
                    return item.MaPhanLoaiHD;
                }
            }
            return 0;
        }
        private int KiemTraTonTaiBoPhan(string MaQLBoPhan)
        {
            foreach (BoPhan boPhan in BoPhanList.GetBoPhanListKeCaBoPhanMoRong())
            {
                if (boPhan.MaBoPhanQL.ToUpper() == MaQLBoPhan.ToUpper())
                {
                    return boPhan.MaBoPhan;
                }
            }
            return 0;
        }
        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            _dataSet = new DataSet();
            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (sheet == "Sheet1$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A1:N]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "HopDong";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return _dataSet;
        }
       
        private void ImportToHangHoaFromDataSet(DataSet dsresult)
        {         
            StringBuilder mainLog = new StringBuilder();
            int STT = 0, STTLoi = 0;
            decimal giaTri, giaTriQuyetToan;
            String SoHopDong, SoThamDinh, SoKeToanTheoDoi, NgayKyString, NoiDungHopDong,
                MaQLLoaiHopDong;
            DateTime? ngayKy = null;
            if (dsresult.Tables.Count == 0) 
                return;
            tblHopDong = new DataTable();
            tblHopDong = dsresult.Tables["HopDong"];
            if (tblHopDong.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblHopDong.Rows)
                {
                    STT++;                  
                    long maDoiTac = 0;
                    int  maPhanLoaiHopDong=0, maBoPhan = 0;
                    giaTri = 0; giaTriQuyetToan = 0;
                    SoHopDong = String.Empty; SoKeToanTheoDoi = String.Empty; SoThamDinh = String.Empty;
                    NoiDungHopDong = String.Empty; MaQLLoaiHopDong = String.Empty;
                    ngayKy = null;
                    StringBuilder errorLog = new StringBuilder();
                    if (rowhd[10].ToString().Trim().Length == 0)
                    {
                        errorLog.AppendLine("Mã đối tác hợp đồng không được để trống!");
                    }
                    else
                    {
                        maDoiTac = KiemTraTonTaiDoiTac(rowhd[10].ToString().Trim());
                        if (maDoiTac == 0)
                        {
                            errorLog.AppendLine("Mã đối tác Chưa có trong phần mềm!\nVui lòng nhập đối tác vào phần mềm!");
                        }
                    }
                    //if (rowhd[4].ToString().Trim().Length == 0)//số lượng
                    //{
                    //    errorLog.AppendLine("Số lượng hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}
                    //else
                    //{
                    //    bool kq = int.TryParse(rowhd[4].ToString().Trim(), out soLuong);
                    //    if (kq == false)
                    //        errorLog.AppendLine("Số lượng không đúng định dạng!");
                    //}
                    if (rowhd[4].ToString().Trim().Length != 0)//giá trị hợp đồng
                    {
                        bool kq = decimal.TryParse(rowhd[4].ToString().Trim(), out giaTri);
                        if (kq == false)
                            errorLog.AppendLine("Giá trị hợp đồng không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Đơn giá hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}
                    if (rowhd[5].ToString().Trim().Length != 0)//giá trị quyết toán
                    {
                        bool kq = decimal.TryParse(rowhd[5].ToString().Trim(), out giaTriQuyetToan);
                        if (kq == false)
                            errorLog.AppendLine("Giá trị quyết toán không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Thành tiền hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}
                 
                    if (rowhd[8].ToString().Trim().Length != 0)//bộ phận
                    {
                        maBoPhan = KiemTraTonTaiBoPhan(rowhd[8].ToString().Trim());
                        if (maBoPhan == 0)
                            errorLog.AppendLine("Không tồn tại mã phòng ban trong phần mềm!");
                    }
                    SoHopDong = rowhd[0].ToString().Trim();
                    SoThamDinh = rowhd[1].ToString().Trim();                   
                    NgayKyString  = rowhd[2].ToString().Trim();
                    if (!string.IsNullOrWhiteSpace(NgayKyString))
                    {
                        ngayKy = null;
                        try
                        {
                            ngayKy = Convert.ToDateTime(NgayKyString);
                        }
                        catch (Exception ex)
                        {
                            errorLog.AppendLine(" + Ngày nhận không đúng định dạng dd/MM/yyyy.");
                        }

                        if (ngayKy != null)
                        {
                            if (ngayKy != DateTime.MinValue)
                            {
                                ngayKy = ngayKy;
                            }
                            else
                                errorLog.AppendLine(string.Format(" + Ngày ký  không hợp lệ: {0:dd/MM/yyyy}", ngayKy.Value));
                        }                       
                    }              
                    NoiDungHopDong = rowhd[3].ToString().Trim();
                    MaQLLoaiHopDong = rowhd[6].ToString().Trim();
                    if (rowhd[6].ToString().Trim().Length == 0)
                    {
                        errorLog.AppendLine("Mã loại hợp đồng không được để trống!");
                    }
                    else
                    {
                        maPhanLoaiHopDong = KiemTraTonTaiPhanLoaiHopDong(MaQLLoaiHopDong);
                        if (maPhanLoaiHopDong == 0)
                        {
                            errorLog.AppendLine("Mã loại hợp đồng Chưa có trong phần mềm!\nVui lòng nhập loại hợp đồng vào phần mềm!");
                        }
                    }
                    SoKeToanTheoDoi = rowhd[12].ToString().Trim();

                    if (!KiemTraSoHopDongHopLe(0, SoHopDong))
                    {
                        errorLog.AppendLine("Số hợp đồng không hợp lệ!\nVui lòng kiểm tra lại số hợp đồng!");
                    }
                    if (!KiemTraSoThamDinhHopDongHopLe(0, SoHopDong))
                    {
                        errorLog.AppendLine("Số thẩm định không hợp lệ!\nVui lòng kiểm tra lại số thẩm định hợp đồng!");
                    }                       
                    if (errorLog.Length > 0)
                    {
                        STTLoi++;
                        mainLog.AppendLine(STTLoi + ") -------------------------------");
                        mainLog.AppendLine("- STT: " + STT + " có mã :" + rowhd[0].ToString().Trim());
                        mainLog.AppendLine(errorLog.ToString());
                    }
                    else
                    {
                        HopDongThuChi _HopDongMuaBanNew = HopDongThuChi.NewHopDongMuaBan();
                        _HopDongMuaBanNew.SoHopDong = SoHopDong;
                        _HopDongMuaBanNew.SoThamDinh = SoThamDinh;
                        _HopDongMuaBanNew.TenHopDong = NoiDungHopDong;
                        _HopDongMuaBanNew.MaDoiTac = maDoiTac;
                        DoiTac doiTac = DoiTac.GetDoiTac(maDoiTac);
                        if (doiTac != null)
                        {
                            _HopDongMuaBanNew.TenDoiTac = doiTac.TenDoiTac;
                            _HopDongMuaBanNew.MaQLDoiTac = doiTac.MaQLDoiTac;
                        }
                        _HopDongMuaBanNew.MaBoPhanChuQuan = maBoPhan;
                        _HopDongMuaBanNew.NgayKy = ngayKy;
                        _HopDongMuaBanNew.MaLoaiHopDong = 3;
                        _HopDongMuaBanNew.MaPhanLoaiHD = maPhanLoaiHopDong;                        
                        _HopDongMuaBanNew.TongTien = giaTri;
                        _HopDongMuaBanNew.GiaTriQuyetToan = giaTriQuyetToan;
                        _HopDongMuaBanNew.SoKeToanTheoDoi = SoKeToanTheoDoi;
                        _hopDongThuChiList.Add(_HopDongMuaBanNew);
                    }
                }//end forech
                if (mainLog.Length > 0)
                {                   
                    LoadData();
                    const string tenFile = "Import_Log.txt";
                    //FileStream fileStream = File.Open(tenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    StreamWriter writer = new StreamWriter(tenFile);
                    writer.WriteLine(mainLog.ToString());
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    //mở file log
                    Process.Start(tenFile);
                }
                else
                {
                    _hopDongThuChiList.ApplyEdit();
                    _hopDongThuChiList.Save();
                    DialogUtil.ShowInfo("Import thành công!");
                }                
            }            
        }

        private void btn_Import_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _FileNameImport = "";
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToHangHoaFromDataSet(dsRerult);
            }
            catch
            {
                MessageBox.Show("Không thể đọc file!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool KiemTraSoHopDongHopLe(long maHopDong, string sohopdong)
        {
            if (sohopdong.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào Số hợp đồng!");               
                return false;
            }

            if (HopDongThuChi.KiemTraTrungSoHopDong(maHopDong, sohopdong))
            {
                MessageBox.Show("Trùng số hợp đồng! Vui lòng chỉnh lại!");
                return false;
            }
            return true;
        }

        private bool KiemTraSoThamDinhHopDongHopLe(long maHopDong, string sothamdinh)
        {
            if (sothamdinh.Length > 0)
            {
                if (HopDongThuChi.KiemTraTrungSoThamDinhHopDong(maHopDong, sothamdinh))
                {
                    MessageBox.Show("Trùng số thẩm định! Vui lòng chỉnh lại!");                 
                    return false;
                }
            }
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao.Controllers;
using DevExpress.XtraLayout;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraEditors.Repository;
//20/10/2014
namespace PSC_ERP.UserInterface.NhanSu.QuanLyDaoTao
{
    public partial class frmQuanLyDaoTao : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private DeCuList _deCuList = DeCuList.NewDeCuList();
        private ChiTietDeCuNhanVienList _chiTietDeCuNhanVienList = ChiTietDeCuNhanVienList.NewChiTietDeCuNhanVienList();
        private QuaTrinhDaoTaoNhanLucList _quaTrinhDaoTaoNhanLucList = QuaTrinhDaoTaoNhanLucList.NewQuaTrinhDaoTaoNhanLucList();
        private DataTable _tblThoiDoiNopVanBang;
        #region Properties TabDeCu
        private int _maLopHoc = 0;
        private int _maTruongDaoTao = 0;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maChuyenNganhDaoTao = 0;
        private int _nam = 0;
        private byte _sapHetHan = 0;
        private int _thoigiandecusaphethan = 0;
        private DeCu _deCu;
        private int _maDeCu = 0;
        private bool _laDanhSachDeCu = true;
        #endregion
        #region Properties TabQuanLyDiHoc
        private byte _ketQuaDaoTao = 0;
        private DataTable _ketQuaDaoTaoList;
        #endregion
        #region Properties TabTheoDoiNopBang
        private byte _phuongThucTim = 0;
        private byte _trongNuocNgoaiNuoc = 0;
        private int _maDonViDaoTao = 0;
        #endregion
        private UCMenuTabQuanLyDiHoc _uCMenuTabQuanLyDiHoc;
        #endregion

        #region Function
        private void FormatTabDeCu()
        {
            bsCTDeCuNhanVienList.DataSource = typeof(ChiTietDeCuNhanVienList);
            bsDeCuList.DataSource = typeof(DeCuList);
            bsLoaiLopDaoTaoList.DataSource = typeof(LoaiLopDaoTaoList);
            bsLopHocList.DataSource = typeof(LopHocList);
            bsTruongDaoTao.DataSource = typeof(TruongDaoTaoList);
            bsTrinhDoHocVan.DataSource = typeof(TrinhDoHocVanClassList);
            bsQuocGia.DataSource = typeof(QuocGiaList);
            bsChuyenNganhDaoTao.DataSource = typeof(ChuyenNganhDaoTaoClassList);
            bsDonViDaoTaoList.DataSource = typeof(DonViDaoTaoList);
        }

        private void FormatTabQuanLyDiHoc()
        {
            LoadUserControTabQuanLyDiHoc();
            bsQuaTrinhDaoTaoList.DataSource = typeof(QuaTrinhDaoTaoNhanLucList);
            //
            _ketQuaDaoTaoList = new DataTable();
            _ketQuaDaoTaoList.Columns.Add("Ma", typeof(byte));
            _ketQuaDaoTaoList.Columns.Add("MoTa", typeof(string));
            DataRow dr = _ketQuaDaoTaoList.NewRow();
            dr["Ma"] = 0;
            dr["MoTa"] = "<Chưa có>";
            _ketQuaDaoTaoList.Rows.Add(dr);
            dr = _ketQuaDaoTaoList.NewRow();
            dr["Ma"] = 1;
            dr["MoTa"] = "Không đạt";
            _ketQuaDaoTaoList.Rows.Add(dr);
            dr = _ketQuaDaoTaoList.NewRow();
            dr["Ma"] = 2;
            dr["MoTa"] = "Đạt";
            _ketQuaDaoTaoList.Rows.Add(dr);



        }

        private void FormatTabTheoDoiNopBang()
        {
            //bsQuaTrinhDaoTaoTabTheoDoiList.DataSource = typeof(QuaTrinhDaoTaoNhanLucList);
            TheoDoiNopVanBangGrdV.GroupPanelText = "Theo Dõi Nộp Văn Bằng";
        }

        private void LoadUserControTabQuanLyDiHoc()
        {
            _uCMenuTabQuanLyDiHoc = new UCMenuTabQuanLyDiHoc();
            pCMenuTabQuanLyDiHoc.Controls.Add(_uCMenuTabQuanLyDiHoc);
            _uCMenuTabQuanLyDiHoc.Dock = DockStyle.Fill;
        }

        private void AnHienGridConTrolTheoYeuCau_TabDeCu()
        {
            if (_laDanhSachDeCu)
            {
                DeCuListGrdC.Visible = true;
                if (DeCuListGrdV.Columns.Count == 0)
                    DesignGridTabDeCu_DeCuList();
                CTNhanVienDeCuGrdC.Visible = false;
            }
            else
            {
                DeCuListGrdC.Visible = false;
                CTNhanVienDeCuGrdC.Visible = true;
                if (CTNhanVienDeCuGrdV.Columns.Count == 0)
                    DesignGridTabDeCu_CTNhanVienDeCuList();
            }
        }

        private void LoadDataGridDeCu()
        {
            GetDieuKienTimTabDeCu();
            AnHienGridConTrolTheoYeuCau_TabDeCu();
            if (_laDanhSachDeCu)
            {
                _deCuList = DeCuList.GetDeCuList(_maLopHoc, _loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao, _nam, _sapHetHan, _thoigiandecusaphethan, _maDonViDaoTao);
                bsDeCuList.DataSource = _deCuList;
                if (_deCuList.Count == 0)
                    MessageBox.Show("Danh sách rỗng!");
            }
            else
            {
                _chiTietDeCuNhanVienList = ChiTietDeCuNhanVienList.GetChiTietDeCuNhanVienList(_maDeCu, _maLopHoc, _loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao, _nam, _sapHetHan, _thoigiandecusaphethan, _maDonViDaoTao);
                bsCTDeCuNhanVienList.DataSource = _chiTietDeCuNhanVienList;
                if (_chiTietDeCuNhanVienList.Count == 0)
                    MessageBox.Show("Danh sách rỗng!");
            }
        }

        private void LoadDataGridQuanLyDiHoc()
        {
            GetDieuKienTimTabQuanLyDiHoc();
            _quaTrinhDaoTaoNhanLucList = QuaTrinhDaoTaoNhanLucList.GetQuaTrinhDaoTaoNhanLucList(_maLopHoc, _loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao, _nam, _ketQuaDaoTao, _maDonViDaoTao);
            bsQuaTrinhDaoTaoList.DataSource = _quaTrinhDaoTaoNhanLucList;
            if (_quaTrinhDaoTaoNhanLucList.Count == 0)
                MessageBox.Show("Danh sách rỗng!");
        }

        private void LoadDataGridTheoDoiNopVanBang()
        {
            _tblThoiDoiNopVanBang = new DataTable();
            GetDieuKienTimTabTheoDoiNopBang();
            _tblThoiDoiNopVanBang = QuaTrinhDaoTaoNhanLuc.GetDSThoiDoiNopVanBang(_maLopHoc, _loaiVanBang, _maQuocGiaCap, _maTruongDaoTao, _maChuyenNganhDaoTao, _trongNuocNgoaiNuoc, _phuongThucTim, _nam, _maDonViDaoTao);
            TheoDoiNopVanBangGrdV.Columns.Clear();
            DesignGridTabTheoDoiNopVanBang();
            if (_tblThoiDoiNopVanBang.Rows.Count == 0)//M
                MessageBox.Show("Danh Sách Rỗng");
        }

        private void DesignGridTabDeCu_DeCuList()
        {
            //DeCuListGrdV.OptionsView.ShowGroupPanel
            DeCuListGrdC.Dock = DockStyle.Fill;

            DeCuListGrdC.DataSource = bsDeCuList;
            HamDungChung.InitGridViewDev(DeCuListGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev2(DeCuListGrdV, new string[] { "LoaiLop", "TenvanbangChungchi", "DonVi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "QuocGiaCap", "NgayBatDau", "NgayKetThuc", "SoNguoiDeCu", "SoNguoiDiHoc" ,"NguoiPTThanhToan","SoHopDong","TongTien","ConLai"},
                                new string[] { "Thuộc loại lớp", "Tên lớp học", "Đơn vị đào tạo", "Ngày BĐ chính thức", "Ngày KT chính thức", "Quốc gia cấp", "Ngày BĐ dự kiến", "Ngày KT dự kiến", "Số người đề cử", "Số người đi học", "Người protected thanh toán","Số hợp đồng","Tổng tiền","Còn lại" },
                                             new int[] { 300, 300, 120, 90, 90, 100, 90, 90, 80, 80,100,100,90,90 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(DeCuListGrdV, new string[] { "LoaiLop", "TenvanbangChungchi", "DonVi", "NgayBatDau", "NgayKetThuc", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "QuocGiaCap", "SoNguoiDeCu", "SoNguoiDiHoc", "NguoiPTThanhToan", "SoHopDong", "TongTien", "ConLai" }, DevExpress.Utils.HorzAlignment.Center);
            
            Utils.GridUtils.SetSTTForGridView(DeCuListGrdV, 35);//M
            HamDungChung.ReadOnlyColumnChoseGridViewDev(DeCuListGrdV, new string[] { "LoaiLop", "TenvanbangChungchi", "DonVi", "NgayBatDau", "NgayKetThuc", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "QuocGiaCap", "SoNguoiDeCu", "SoNguoiDiHoc", "NguoiPTThanhToan", "SoHopDong", "TongTien", "ConLai" });
            
            //
            DeCuListGrdV.DoubleClick += new System.EventHandler(this.DeCuGrdV_DoubleClick);
            DeCuListGrdC.ContextMenuStrip = contextMenuStrip_TabDeCu;

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(DeCuListGrdV, new string[] { "SoNguoiDeCu", "TongTien", "ConLai" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(DeCuListGrdV, new string[] { "SoNguoiDeCu", "SoNguoiDiHoc", "TongTien", "ConLai" }, "{0:#,###.#}");


            DeCuListGrdV.GroupPanelText = "Danh Sách Đề Cử";
            DeCuListGrdV.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            DeCuListGrdV.Appearance.GroupPanel.Options.UseFont = true;
            
        }

        private void DesignGridTabDeCu_CTNhanVienDeCuList()
        {
            CTNhanVienDeCuGrdC.Dock = DockStyle.Fill;

            CTNhanVienDeCuGrdC.DataSource = bsCTDeCuNhanVienList;
           
            HamDungChung.InitGridViewDev(CTNhanVienDeCuGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev2(CTNhanVienDeCuGrdV, new string[] { "Chon", "TenNhanVien", "MaQLNhanVien", "BoPhanNhanVien", "TinhTrangDaoTao", "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString", "NgayBatDau", "NgayKetThuc", "SoGioHoc", "SoNgayHoc", "QuocGiaCap", "TenDonViDaoTao", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChuLopHoc" },
                                new string[] { "Chọn", "Tên nhân viên", "Mã nhân viên", "Bộ phận", "Tình trạng đào tạo", "Tên lớp học", "Loại Văn bằng/Chứng chỉ", "Văn bằng/ Chứng chỉ", "Ngày bắt đầu", "Ngày kết thúc","Số giờ học", "Số ngày học", "Quốc gia cấp", "Đơn vị đào tạo", "Trường đào tạo", "Chuyên ngành đào tạo", "Đào tạo", "Ghi chú" },
                                             new int[] { 40, 130, 90, 100, 100, 150, 75, 75, 75, 75,75, 75, 75, 100, 100, 100, 100, 150 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(CTNhanVienDeCuGrdV, new string[] { "Chon", "TenNhanVien", "MaQLNhanVien", "BoPhanNhanVien", "TinhTrangDaoTao", "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString", "NgayBatDau", "NgayKetThuc", "SoGioHoc", "SoNgayHoc", "QuocGiaCap", "TenDonViDaoTao", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChuLopHoc" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(CTNhanVienDeCuGrdV, new string[] { "SoGioHoc", "SoNgayHoc" }, "#,###.##");
            Utils.GridUtils.SetSTTForGridView(CTNhanVienDeCuGrdV, 35);//M
            HamDungChung.ReadOnlyColumnChoseGridViewDev(CTNhanVienDeCuGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "BoPhanNhanVien", "TinhTrangDaoTao", "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString", "NgayBatDau", "NgayKetThuc", "SoGioHoc", "SoNgayHoc", "QuocGiaCap", "TenDonViDaoTao", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChuLopHoc" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(CTNhanVienDeCuGrdV, new string[] { "SoGioHoc", "SoNgayHoc" }, "#,###.##");
            //
            //CTNhanVienDeCuGrdV.DoubleClick += new System.EventHandler(this.DeCuGrdV_DoubleClick);

            CTNhanVienDeCuGrdV.GroupPanelText = "Danh Sách Chi Tiết Nhân viên Đề Cử";
            CTNhanVienDeCuGrdV.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            CTNhanVienDeCuGrdV.Appearance.GroupPanel.Options.UseFont = true;

        }

        private void DesignGridTabQuanLyDiHoc()
        {
            QuanLyDiHocGrdC.DataSource = bsQuaTrinhDaoTaoList;
           
            HamDungChung.InitGridViewDev(QuanLyDiHocGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            HamDungChung.ShowFieldGridViewDev2(QuanLyDiHocGrdV, new string[] { "Chon", "TenNhanVien", "MaQLNhanVien", "KetQuaDaoTao", "DaNopBangString", "TenvanbangChungchi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "VanbangChungchiString", "LoaiVanBangString", "QuocGiaCapString", "TenDonViDaoTao", "TruongDaoTaostring", "ChuyenNganhDaoTaoString", "SoGioHoc", "SoNgayHoc", "NamTotNghiep", "XepLoai", "NguoiKy", "SovanbangChungchi", "GhiChu" },
                                new string[] { "Chọn", "Tên nhân viên", "Mã nhân viên", "Kết quả đào tạo", "Hiện tại", "Tên lớp học", "Ngày bắt đầu chính thức", "Ngày kết thúc chính thức", "Thuộc", "Loại văn bằng", "Quốc gia cấp", "Đơn vị đào tạo", "Trường đào tạo", "Chuyên ngành đào tạo","Số giờ học", "Số ngày học", "Năm TN", "Xếp loại", "Người ký", "Số văn bằng/chứng chỉ", "Ghi chú" },
                                             new int[] { 40, 130, 90, 90, 80, 100, 100, 100, 80, 90, 80, 100, 100, 100,80, 80, 70, 80, 90, 90, 120 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(QuanLyDiHocGrdV, new string[] { "Chon", "TenNhanVien", "MaQLNhanVien", "KetQuaDaoTao", "TenvanbangChungchi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "VanbangChungchiString", "LoaiVanBangString", "QuocGiaCapString", "TenDonViDaoTao", "TruongDaoTaostring", "ChuyenNganhDaoTaoString", "SoGioHoc", "SoNgayHoc", "DaNopBangString", "NamTotNghiep", "XepLoai", "NguoiKy", "SovanbangChungchi", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(QuanLyDiHocGrdV, new string[] { "SoGioHoc", "SoNgayHoc" }, "#,###.##");
            //
            RepositoryItemGridLookUpEdit KetQuaDaoTaoList_GrdLU = new RepositoryItemGridLookUpEdit();
            KetQuaDaoTaoList_GrdLU.DataSource = _ketQuaDaoTaoList;
            KetQuaDaoTaoList_GrdLU.DisplayMember = "MoTa";
            KetQuaDaoTaoList_GrdLU.ValueMember = "Ma";
            HamDungChung.InitRepositoryItemGridLookUpDev(KetQuaDaoTaoList_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(KetQuaDaoTaoList_GrdLU, new string[] { "MoTa" }, new string[] { "Kết quả" }, new int[] { 100 }, true);

            HamDungChung.RegisterControlFieldGridViewDev(QuanLyDiHocGrdV, "KetQuaDaoTao", KetQuaDaoTaoList_GrdLU);
            //

            Utils.GridUtils.SetSTTForGridView(QuanLyDiHocGrdV, 35);//M
            HamDungChung.ReadOnlyColumnChoseGridViewDev(QuanLyDiHocGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "TenLoaiLop", "TenvanbangChungchi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "VanbangChungchiString", "LoaiVanBangString", "QuocGiaCapString", "TruongDaoTaostring", "ChuyenNganhDaoTaoString", "SoGioHoc", "SoNgayHoc", "DaNopBangString", "NamTotNghiep", "XepLoai", "NguoiKy", "SovanbangChungchi", "GhiChu" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(QuanLyDiHocGrdV, new string[] {  "SoGioHoc","SoNgayHoc" }, "#,###.##");
            //HamDungChung.ReadOnlyColumnChoseGridViewDev(QuanLyDiHocGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "BoPhanNhanVien", "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString", "NgayBatDau", "NgayKetThuc", "QuocGiaCap", "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChuLopHoc" });
            QuanLyDiHocGrdV.DoubleClick += new System.EventHandler(this.QuanLyDiHocGrdV_DoubleClick);
            QuanLyDiHocGrdV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuanLyDiHocGrdV_KeyDown);
            QuanLyDiHocGrdV.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.QuanLyDiHocGrdV_CellValueChanged);

            QuanLyDiHocGrdV.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            QuanLyDiHocGrdV.Appearance.GroupPanel.Options.UseFont = true;
        }

        private void DesignGridTabTheoDoiNopVanBang()
        {
            SetTieuDeGridForTabTheoDoiNopVanBang();
            TheoDoiNopVanBangGrdC.DataSource = _tblThoiDoiNopVanBang;
            HamDungChung.InitGridViewDev(TheoDoiNopVanBangGrdV, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            //HamDungChung.ShowFieldGridViewDev2(TheoDoiNopVanBangGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan", "DaNopBang", "TenLoaiLop", "TenVanBang_ChungChi", "TenDonViDaoTao", "TenTruongDaoTao", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc" },
            //                    new string[] { "Tên nhân viên", "Mã nhân viên", "Bộ phận", "Hiện tại", "Tên loại lớp học", "Tên lớp học", "Đơn vị đào tạo", "Trường đào tạo", "Ngày bắt đầu học", "Ngày phải nộp bằng" },
            //                                 new int[] { 150, 90, 150, 90, 150, 150, 150, 100, 100, 100 }, false);
            //HamDungChung.AlignHeaderColumnGridViewDev(TheoDoiNopVanBangGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan", "DaNopBang", "TenLoaiLop", "TenVanBang_ChungChi", "TenDonViDaoTao", "TenTruongDaoTao", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc" }, DevExpress.Utils.HorzAlignment.Center);
            //
            HamDungChung.ShowFieldGridViewDev2(TheoDoiNopVanBangGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan", "KetQuaDaoTao", "DaNopBang", "TenVanBang_ChungChi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "TenDonViDaoTao", "TenTruongDaoTao" },
                                new string[] { "Tên nhân viên", "Mã nhân viên", "Bộ phận", "Kết quả đào tạo", "Hiện tại", "Tên lớp học", "Ngày bắt đầu học", "Ngày phải nộp bằng", "Đơn vị đào tạo", "Trường đào tạo" },
                                             new int[] { 150, 90, 150, 90, 90, 150, 100, 100, 150, 100 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(TheoDoiNopVanBangGrdV, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan", "KetQuaDaoTao", "DaNopBang", "TenVanBang_ChungChi", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "TenDonViDaoTao", "TenTruongDaoTao" }, DevExpress.Utils.HorzAlignment.Center);
            //

            Utils.GridUtils.SetSTTForGridView(TheoDoiNopVanBangGrdV, 35);//M
            HamDungChung.ReadOnlyColumnGridViewDev(TheoDoiNopVanBangGrdV);
            //QuanLyDiHocGrdV.DoubleClick += new System.EventHandler(this.QuanLyDiHocGrdV_DoubleClick);
            //QuanLyDiHocGrdV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuanLyDiHocGrdV_KeyDown);

            TheoDoiNopVanBangGrdV.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            TheoDoiNopVanBangGrdV.Appearance.GroupPanel.Options.UseFont = true;
        }

        private void GetDieuKienTimTabDeCu()
        {
            if (MaLopHocTabDeCuGLU.EditValue != null)
            {
                _maLopHoc = (int)MaLopHocTabDeCuGLU.EditValue;
            }
            else
            {
                _maLopHoc = 0;
            }

            if (MaTruongDaoTaoGLU.EditValue != null)
            {
                _maTruongDaoTao = (int)MaTruongDaoTaoGLU.EditValue;
            }
            else
            {
                _maTruongDaoTao = 0;
            }
            if (LoaiVanBangGLU.EditValue != null)
            {
                _loaiVanBang = (int)LoaiVanBangGLU.EditValue;
            }
            else
            {
                _loaiVanBang = 0;
            }
            if (MaQuocGiaCapGLU.EditValue != null)
            {
                _maQuocGiaCap = (int)MaQuocGiaCapGLU.EditValue;
            }
            else
            {
                _maQuocGiaCap = 0;
            }
            if (MaChuyenNganhDaoTaoGLU.EditValue != null)
            {
                _maChuyenNganhDaoTao = (int)MaChuyenNganhDaoTaoGLU.EditValue;
            }
            else
            {
                _maChuyenNganhDaoTao = 0;
            }
            int tryint;
            if (int.TryParse(txt_nam.Text, out tryint))
            {
                _nam = tryint;
            }
            else
            {
                _nam = 0;
            }
            if (SapHetHanTabDeCurd.EditValue != null)
            {
                _sapHetHan = (byte)SapHetHanTabDeCurd.EditValue;
            }
            else
                _sapHetHan = 0;

            if (txt_Thoigiansaphethan.EditValue != null)
            {
                int val;
                if (int.TryParse(txt_Thoigiansaphethan.EditValue.ToString(), out val))
                {
                    _thoigiandecusaphethan = val;
                }
                else _thoigiandecusaphethan = 0;
            }
            else _thoigiandecusaphethan = 0;

            int tryintMaDV;
            if (int.TryParse(DonViDaoTaoGrLUTabDeCu.EditValue.ToString(), out tryintMaDV))
            {
                _maDonViDaoTao = tryintMaDV;
            }
            else _maDonViDaoTao = 0;

        }

        private void GetDieuKienTimTabQuanLyDiHoc()
        {
            if (MaLopHocTabQuanLyDiHocGLU.EditValue != null)
            {
                _maLopHoc = (int)MaLopHocTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maLopHoc = 0;
            }

            if (TruongDaoTaoTabQuanLyDiHocGLU.EditValue != null)
            {
                _maTruongDaoTao = (int)TruongDaoTaoTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maTruongDaoTao = 0;
            }
            if (LoaiVanBangTabQuanLyDiHocGLU.EditValue != null)
            {
                _loaiVanBang = (int)LoaiVanBangTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _loaiVanBang = 0;
            }
            if (QuocGiaCapTabQuanLyDiHocGLU.EditValue != null)
            {
                _maQuocGiaCap = (int)QuocGiaCapTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maQuocGiaCap = 0;
            }
            if (ChuyenNganhDaoTaoTabQuanLyDiHocGLU.EditValue != null)
            {
                _maChuyenNganhDaoTao = (int)ChuyenNganhDaoTaoTabQuanLyDiHocGLU.EditValue;
            }
            else
            {
                _maChuyenNganhDaoTao = 0;
            }
            int tryint;
            if (int.TryParse(txtNamTabQuanLyDiHoc.Text, out tryint))
            {
                _nam = tryint;
            }
            else
            {
                _nam = 0;
            }
            if (KetQuaDaoTaord.EditValue != null)
            {
                _ketQuaDaoTao = (byte)KetQuaDaoTaord.EditValue;
            }
            else
            {
                _ketQuaDaoTao = 0;
            }

            int tryintMaDV;
            if (int.TryParse(DonViDaoTaoGrLUTabQuanLyDiHoc.EditValue.ToString(), out tryintMaDV))
            {
                _maDonViDaoTao = tryintMaDV;
            }
            else _maDonViDaoTao = 0;

        }

        private void GetDieuKienTimTabTheoDoiNopBang()
        {
            if (MaLopHocTabTheoDoiGLU.EditValue != null)
            {
                _maLopHoc = (int)MaLopHocTabTheoDoiGLU.EditValue;
            }
            else
            {
                _maLopHoc = 0;
            }

            if (MaTruongDaoTaoTabTheoDoiGLU.EditValue != null)
            {
                _maTruongDaoTao = (int)MaTruongDaoTaoTabTheoDoiGLU.EditValue;
            }
            else
            {
                _maTruongDaoTao = 0;
            }
            if (LoaiVanBangTabTheoDoiGLU.EditValue != null)
            {
                _loaiVanBang = (int)LoaiVanBangTabTheoDoiGLU.EditValue;
            }
            else
            {
                _loaiVanBang = 0;
            }
            if (MaQuocGiaTabTheoDoiGLU.EditValue != null)
            {
                _maQuocGiaCap = (int)MaQuocGiaTabTheoDoiGLU.EditValue;
            }
            else
            {
                _maQuocGiaCap = 0;
            }
            if (MaChuyenNganhDaoTabTheoDoiGLU.EditValue != null)
            {
                _maChuyenNganhDaoTao = (int)MaChuyenNganhDaoTabTheoDoiGLU.EditValue;
            }
            else
            {
                _maChuyenNganhDaoTao = 0;
            }
            if (TrongnuocNgoainuocrd.EditValue != null)
            {
                _trongNuocNgoaiNuoc = (byte)TrongnuocNgoainuocrd.EditValue;
            }
            else
            {
                _trongNuocNgoaiNuoc = 0;
            }
            if (TimTabThoiDoird.EditValue != null)
            {
                _phuongThucTim = (byte)TimTabThoiDoird.EditValue;
            }
            else
            {
                _phuongThucTim = 0;
            }

            int tryint;
            if (int.TryParse(txtNamTabTheoDoiNopVanBang.Text, out tryint))
            {
                _nam = tryint;
            }
            else
            {
                _nam = 0;
            }

            int tryintMaDV;
            if (int.TryParse(DonViDaoTaoGrLUTabTheoDoi.EditValue.ToString(), out tryintMaDV))
            {
                _maDonViDaoTao = tryintMaDV;
            }
            else _maDonViDaoTao = 0;

        }

        private void SetTieuDeGridForTabTheoDoiNopVanBang()
        {
            //PhuongThucTim 1:DaQuaHanNopBang; 2:DaNopBang; 3: ChuaNopBang; 4: TatCa
            if (_phuongThucTim == 1)
                TheoDoiNopVanBangGrdV.GroupPanelText = "Danh sách nhân viên đã quá hạn nộp văn bằng/chứng chỉ";
            else if (_phuongThucTim == 2)
                TheoDoiNopVanBangGrdV.GroupPanelText = "Danh sách nhân viên đã nộp văn bằng/chứng chỉ";
            else if (_phuongThucTim == 3)
                TheoDoiNopVanBangGrdV.GroupPanelText = "Danh sách nhân viên chưa nộp văn bằng/chứng chỉ";
            else
                TheoDoiNopVanBangGrdV.GroupPanelText = "Theo Dõi Nộp Văn Bằng";
        }

        private bool KiemTraChonDeCuRow()
        {
            if (DeCuListGrdV.GetFocusedRow() == null)
            {
                MessageBox.Show("Vui lòng chọn Đề cử cần thực hiện!");
                return false;
            }
            return true;
        }

        private bool KiemTraChonQuanLyDiHocRow()
        {
            ChangeFocusTabQuanLyDiHoctextEdit.Focus();
            foreach (QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc in _quaTrinhDaoTaoNhanLucList)
            {
                if (quaTrinhDaoTaoNhanLuc.Chon)
                    return true;
            }
            MessageBox.Show("Vui lòng chọn quản lý đi học cần thực hiện!");
            return false;
        }

        private void FormatMainMenuTabDeCu()
        {
            if (_laDanhSachDeCu)
            {
                ucMenuDeCu1.btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                ucMenuDeCu1.btnQuyetDinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                ucMenuDeCu1.btnTroVeDSDeCu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                ucMenuDeCu1.btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                ucMenuDeCu1.btnQuyetDinh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                ucMenuDeCu1.btnTroVeDSDeCu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void LoadForTabDeCu()
        {
            FormatTabDeCu();
            AnHienGridConTrolTheoYeuCau_TabDeCu();
            //if (_laDanhSachDeCu)
            //{
            //    DesignGridTabDeCu_DeCuList();
            //    bsDeCuList.DataSource = _deCuList;
            //}
            //else
            //{
            //    DesignGridTabDeCu_CTNhanVienDeCuList();
            //    bsCTDeCuNhanVienList.DataSource = _chiTietDeCuNhanVienList;
            //}

            LoaiLopDaoTao loailop = LoaiLopDaoTao.NewLoaiLopDaoTao("<Không chọn>");
            LoaiLopDaoTaoList loaiLopDaoTaoList;
            loaiLopDaoTaoList = LoaiLopDaoTaoList.GetLoaiLopDaoTaoList(0, 0, 0, 0);
            loaiLopDaoTaoList.Insert(0, loailop);
            bsLoaiLopDaoTaoList.DataSource = loaiLopDaoTaoList;

            LopHoc lophoc = LopHoc.NewLopHoc("<Không chọn>");
            LopHocList lophocList = LopHocList.GetLopHocList(0, 0, 0, 0, 0, 0, 0);
            lophocList.Insert(0, lophoc);
            bsLopHocList.DataSource = lophocList;

            TruongDaoTao truongdaotao = TruongDaoTao.NewTruongDaoTao("<Không chọn>");
            TruongDaoTaoList truongdaotaolist;
            truongdaotaolist = TruongDaoTaoList.GetTruongDaoTaoList();
            truongdaotaolist.Insert(0, truongdaotao);
            bsTruongDaoTao.DataSource = truongdaotaolist;

            TrinhDoHocVanClass trinhdo = TrinhDoHocVanClass.NewTrinhDoHocVanClass(0, "<Không chọn>");
            TrinhDoHocVanClassList trinhdoList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            trinhdoList.Insert(0, trinhdo);
            bsTrinhDoHocVan.DataSource = trinhdoList;

            QuocGia qg = QuocGia.NewQuocGia(0, "<Không chọn>");
            QuocGiaList quocgiaList = QuocGiaList.GetQuocGiaList();
            quocgiaList.Insert(0, qg);
            bsQuocGia.DataSource = quocgiaList;

            ChuyenNganhDaoTaoClass chuyennganh = ChuyenNganhDaoTaoClass.NewChuyenNganhDaoTaoClass(0, "<Không chọn>");
            ChuyenNganhDaoTaoClassList chuyennganhList = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            chuyennganhList.Insert(0, chuyennganh);
            bsChuyenNganhDaoTao.DataSource = chuyennganhList;

            DonViDaoTao dvdt = DonViDaoTao.NewDonViDaoTao("<Không chọn>");
            DonViDaoTaoList _donViDaoTaoList = DonViDaoTaoList.GetDonViDaoTaoList();
            _donViDaoTaoList.Insert(0, dvdt);
            bsDonViDaoTaoList.DataSource = _donViDaoTaoList;
            //Event
            ucMenuDeCu1.btnThemMoi.ItemClick += btnThemMoiTabDeCu_ItemClick;
            ucMenuDeCu1.btnTim.ItemClick += btnTimTabDeCu_ItemClick;
            ucMenuDeCu1.btnQuyetDinh.ItemClick += btnQuyetDinhTabDeCu_ItemClick;
            ucMenuDeCu1.btnXuatRaExcel.ItemClick += btnXuatRaExcelTabDeCu_ItemClick;
            ucMenuDeCu1.btnTroVeDSDeCu.ItemClick += btnTroVeDSDeCuTabDeCu_ItemClick;

            FormatMainMenuTabDeCu();
        }

        private void LoadForTabQuanLyDiHoc()
        {
            FormatTabQuanLyDiHoc();
            DesignGridTabQuanLyDiHoc();
            bsQuaTrinhDaoTaoList.DataSource = _quaTrinhDaoTaoNhanLucList;
            //Event
            _uCMenuTabQuanLyDiHoc.btnLuu.ItemClick += btnLuuTabQuanLyDiHoc_ItemClick;
            _uCMenuTabQuanLyDiHoc.btnTim.ItemClick += btnTimTabQuanLyDiHoc_ItemClick;
            _uCMenuTabQuanLyDiHoc.btnXuatRaExcel.ItemClick += btnXuatRaExcelTabQuanLyDiHoc_ItemClick;
            _uCMenuTabQuanLyDiHoc.btnXoa.ItemClick += btnXoaTabQuanLyDiHoc_ItemClick;
        }

        private void LoadForTabTheoDoiNopVanBang()
        {
            FormatTabTheoDoiNopBang();
        }

        private bool CoChonNhanVienDeCu()
        {
            foreach (ChiTietDeCuNhanVien chiTietDeCuNhanVien in _chiTietDeCuNhanVienList)
            {
                if (chiTietDeCuNhanVien.Chon)
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraNhanVienDavaDangDiHoc(ChiTietDeCuNhanVienList chiTietDeCuNhanVienList)
        {
            foreach (ChiTietDeCuNhanVien chiTietDeCuNhanVien in chiTietDeCuNhanVienList)
            {
                if (_laDanhSachDeCu)
                {
                    if (ChiTietDeCuNhanVien.KiemTraCTDeCudaDiHoc(chiTietDeCuNhanVien.MaChiTiet))
                    {
                        MessageBox.Show("Đề cử này đã có người được đi học, không thể quyết định tiếp.\n Xin vui lòng xem lại Chi tiết đề cử để kiểm tra.", "Yêu Cầu");
                        return false;
                    }
                }
                else
                {
                    if (chiTietDeCuNhanVien.Chon)
                    {
                        if (ChiTietDeCuNhanVien.KiemTraCTDeCudaDiHoc(chiTietDeCuNhanVien.MaChiTiet))
                        {
                            MessageBox.Show("Bạn hãy chọn những người chưa đi học để quyết định đi học", "Yêu Cầu");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void QuyetDinhNhanVienTrongDeCuDiHoc(DeCu deCu)
        {
            if (KiemTraNhanVienDavaDangDiHoc(deCu.chiTietDeCuNhanVienList))
            {
                if (MessageBox.Show(string.Format("Bạn quyết định tất cả những người trong Đề cử lớp [{0}] được đi học?", _deCu.TenvanbangChungchi), "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (ChiTietDeCuNhanVien chiTietDeCuNhanVien in deCu.chiTietDeCuNhanVienList)
                    {
                        QuaTrinhDaoTaoNhanLuc quaTrinhdaoTao = QuaTrinhDaoTaoNhanLuc.NewQuaTrinhDaoTaoNhanLuc(chiTietDeCuNhanVien);
                        bsQuaTrinhDaoTaoList.Add(quaTrinhdaoTao as object);
                    }
                    try
                    {
                        LuuQuaTrinhDaoTao();
                        xtraTabControl1.SelectedTabPage = TabPageQuanLyDiHoc;
                        MessageBox.Show("Quyết định thành công!", "Thông Báo");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể thực hiện!", "Thông Báo");
                    }
                }
            }

        }

        private void QuyetDinhDuocDiHoc()
        {
            ChangeFocusTabDeCutextEdit.Focus();
            bsCTDeCuNhanVienList.EndEdit();
            if (CoChonNhanVienDeCu())
            {
                if (KiemTraNhanVienDavaDangDiHoc(_chiTietDeCuNhanVienList))
                {

                    if (MessageBox.Show("Bạn quyết định những người được chọn đi học?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (ChiTietDeCuNhanVien chiTietDeCuNhanVien in _chiTietDeCuNhanVienList)
                        {
                            if (chiTietDeCuNhanVien.Chon)
                            {
                                QuaTrinhDaoTaoNhanLuc quaTrinhdaoTao = QuaTrinhDaoTaoNhanLuc.NewQuaTrinhDaoTaoNhanLuc(chiTietDeCuNhanVien);
                                bsQuaTrinhDaoTaoList.Add(quaTrinhdaoTao as object);
                            }
                        }
                        try
                        {
                            LuuQuaTrinhDaoTao();
                            xtraTabControl1.SelectedTabPage = TabPageQuanLyDiHoc;
                            MessageBox.Show("Quyết định thành công!", "Thông Báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Không thể thực hiện!", "Thông Báo");
                        }

                    }

                }
            }
            else MessageBox.Show("Vui lòng chọn nhân viên để quyết định.", "Yêu Cầu");

        }

        private bool KiemTraTruocKhiXoaQuaTrinhDaoTao()
        {
            int[] deleteRows = QuanLyDiHocGrdV.GetSelectedRows();
            foreach (int deleteRow in deleteRows)
            {
                QuaTrinhDaoTaoNhanLuc qtDaoTao = QuanLyDiHocGrdV.GetRow(deleteRow) as QuaTrinhDaoTaoNhanLuc;
                if (qtDaoTao.DaNopBang)
                {
                    MessageBox.Show("Đã có Quá trình đào tạo nộp bằng, không thể xóa", "Thông Báo");
                    return false;
                }

            }
            return true;
        }

        private void ResetTinhTrangNopBangCuaQuanLyDiHoc()
        {
            //if(QuanLyDiHocGrdV.FocusedColumn.FieldName=="KetQuaDaoTao")
            //{
            QuaTrinhDaoTaoNhanLuc qtdaotao = QuanLyDiHocGrdV.GetFocusedRow() as QuaTrinhDaoTaoNhanLuc;
            if (qtdaotao != null)
                if (qtdaotao.KetQuaDaoTao == 0 || qtdaotao.KetQuaDaoTao == 1)
                {
                    qtdaotao.DaNopBang = false;
                    qtdaotao.DaNopBangString = "Chưa nộp bằng";
                    qtdaotao.SovanbangChungchi = string.Empty;
                    qtdaotao.NgayCap = DateTime.MinValue;
                    qtdaotao.NamTotNghiep = 0;
                    qtdaotao.XepLoai = string.Empty;
                    qtdaotao.NguoiKy = string.Empty;
                    qtdaotao.GhiChu = string.Empty;
                }
            //}
        }

        private void LuuQuaTrinhDaoTao()
        {
            bsQuaTrinhDaoTaoList.EndEdit();
            _quaTrinhDaoTaoNhanLucList.ApplyEdit();
            _quaTrinhDaoTaoNhanLucList.Save();
            LoadDataGridDeCu();
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void LoadDaTabyTab()
        {
            //if(xtraTabControl1.SelectedTabPage==TabPageTheoDoiNopVanBang)
            //{
            //    btnTimTabTheoDoi.PerformClick();
            //}
            // else if(xtraTabControl1.SelectedTabPage==TabPageDeCu)
            //{
            //    ucMenuDeCu1.btnTim.PerformClick(); 
            //}
            //else if (xtraTabControl1.SelectedTabPage == TabPageQuanLyDiHoc)
            //{
            //    _uCMenuTabQuanLyDiHoc.btnTim.PerformClick();
            //}

            if (xtraTabControl1.SelectedTabPage == TabPageDeCu)
            {
                ucMenuDeCu1.btnTim.PerformClick();
            }


        }

        #endregion

        #region Event

        #region Event TabDeCu
        void btnThemMoiTabDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDeCuDiHoc frm = new frmDeCuDiHoc();
            frm.WindowState = FormWindowState.Maximized;
            frm.LoadData(null);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                LoadDataGridDeCu();

            }//New
        }

        void btnTimTabDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _maDeCu = 0;
            LoadDataGridDeCu();
        }

        void btnXuatRaExcelTabDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (_laDanhSachDeCu)
                {
                    DeCuListGrdV.ExportToXls(dlg.FileName);
                }
                else
                {
                    CTNhanVienDeCuGrdV.ExportToXls(dlg.FileName);
                }
                OpenFile(dlg.FileName);
            }
        }

        void btnTroVeDSDeCuTabDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _laDanhSachDeCu = true;
            LoadDataGridDeCu();
            FormatMainMenuTabDeCu();
        }

        void btnQuyetDinhTabDeCu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            QuyetDinhDuocDiHoc();
        }

        private void DeCuGrdV_DoubleClick(object sender, EventArgs e)
        {
            //_deCuList = DeCuList.NewDeCuList();
            //bsDeCuList.DataSource = _deCuList;

            //if (CTNhanVienDeCuGrdV.GetFocusedRow() != null)
            //{
            //    ChiTietDeCuNhanVien ctdc = CTNhanVienDeCuGrdV.GetFocusedRow() as ChiTietDeCuNhanVien;
            //    if (ctdc != null)
            //    {
            //        _deCu = DeCu.GetDeCu(ctdc.MaDeCu);
            //        frmDeCuDiHoc frm = new frmDeCuDiHoc();
            //        frm.WindowState = FormWindowState.Maximized;
            //        frm.LoadData(_deCu);
            //        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //        {
            //            LoadDataGridDeCu();

            //        }//New

            //    }
            //}

            if (_laDanhSachDeCu)
            {
                if (DeCuListGrdV.GetFocusedRow() != null)
                {
                    DeCu dc = DeCuListGrdV.GetFocusedRow() as DeCu;
                    if (dc != null)
                    {
                        _deCu = DeCu.GetDeCu(dc.MaDeCu);
                        frmDeCuDiHoc frm = new frmDeCuDiHoc();
                        frm.WindowState = FormWindowState.Maximized;
                        frm.LoadData(_deCu);
                        if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            LoadDataGridDeCu();

                        }//New
                    }
                }
            }
        }

        private void xemchitietnhanviendecuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonDeCuRow())
            {
                _laDanhSachDeCu = false;
                _deCu = DeCuListGrdV.GetFocusedRow() as DeCu;
                if (_deCu != null)
                {
                    _maDeCu = _deCu.MaDeCu;
                    LoadDataGridDeCu();
                    FormatMainMenuTabDeCu();
                }
            }
        }

        private void QuyetdinhdihocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KiemTraChonDeCuRow())
            {
                DeCu dc = DeCuListGrdV.GetFocusedRow() as DeCu;
                _deCu = DeCu.GetDeCu(dc.MaDeCu);
                if (_deCu != null)
                {
                    QuyetDinhNhanVienTrongDeCuDiHoc(_deCu);
                }
            }
        }

        private void SapHetHanTabDeCurd_EditValueChanged(object sender, EventArgs e)
        {
            if (SapHetHanTabDeCurd.EditValue != null)
            {
                byte val;
                if (byte.TryParse(SapHetHanTabDeCurd.EditValue.ToString(), out val))
                {
                    if (val == 1)
                    {
                        txt_Thoigiansaphethan.Enabled = true;
                        txt_Thoigiansaphethan.EditValue = 4;
                    }
                    else
                        txt_Thoigiansaphethan.Enabled = false;
                }
                else
                    txt_Thoigiansaphethan.Enabled = false;
            }
            else
                txt_Thoigiansaphethan.Enabled = false;
        }
        #endregion

        #region Event TabQuanLyDiHoc
        private void btnTimTabQuanLyDiHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDataGridQuanLyDiHoc();
        }

        private void btnLuuTabQuanLyDiHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChangeFocusTabQuanLyDiHoctextEdit.Focus();
            try
            {
                LuuQuaTrinhDaoTao();
                MessageBox.Show("Cập nhật thành công!", "Thông Báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện!", "Thông Báo");
            }
        }

        void btnXuatRaExcelTabQuanLyDiHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                QuanLyDiHocGrdV.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }


        void btnXoaTabQuanLyDiHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTruocKhiXoaQuaTrinhDaoTao())
            {
                if (QuanLyDiHocGrdV.RowCount > 0)
                {
                    if (QuanLyDiHocGrdV.GetSelectedRows().Length > 0)
                    {
                        if (XtraMessageBox.Show(String.Format("Bạn có chắc muốn xóa {0} dòng đang chọn ?", QuanLyDiHocGrdV.GetSelectedRows().Length), "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            QuanLyDiHocGrdV.DeleteSelectedRows();
                        }
                    }
                }
            }
        }

        private void QuanLyDiHocGrdV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (KiemTraTruocKhiXoaQuaTrinhDaoTao())
                    HamDungChung.DeleteSelectedRowsGridViewDev(QuanLyDiHocGrdV, e);
        }

        private void QuanLyDiHocGrdV_DoubleClick(object sender, EventArgs e)
        {
            if (QuanLyDiHocGrdV.GetFocusedRow() != null)
            {
                QuaTrinhDaoTaoNhanLuc qtdaotao = QuanLyDiHocGrdV.GetFocusedRow() as QuaTrinhDaoTaoNhanLuc;
                if (qtdaotao != null)
                {
                    QuaTrinhDaoTaoNhanLuc quaTrinhDaoTao = QuaTrinhDaoTaoNhanLuc.GetQuaTrinhDaoTaoNhanLuc(qtdaotao.MaQuaTrinhDaoTao);
                    frmQuanLyDiHoc frm = new frmQuanLyDiHoc(quaTrinhDaoTao);
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        LoadDataGridQuanLyDiHoc();
                    }//New
                }
            }
        }

        private void QuanLyDiHocGrdV_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (QuanLyDiHocGrdV.FocusedColumn.FieldName == "KetQuaDaoTao")
            {
                ResetTinhTrangNopBangCuaQuanLyDiHoc();
            }
        }


        private void rdGKetQuaDaoTao_TabQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            if (rdGKetQuaDaoTao_TabQuanLy.EditValue != null)
            {
                byte ketquadt;
                if (byte.TryParse(rdGKetQuaDaoTao_TabQuanLy.EditValue.ToString(), out ketquadt))
                {
                    if (KiemTraChonQuanLyDiHocRow())
                    {
                        foreach (QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc in _quaTrinhDaoTaoNhanLucList)
                        {
                            if (quaTrinhDaoTaoNhanLuc.Chon)
                            {
                                quaTrinhDaoTaoNhanLuc.KetQuaDaoTao = ketquadt;
                            }
                        }
                        bsQuaTrinhDaoTaoList.DataSource = _quaTrinhDaoTaoNhanLucList;
                    }
                }
            }
        }

        private void rdGDaNopBang_TabQuanLy_EditValueChanged(object sender, EventArgs e)
        {
            if (rdGDaNopBang_TabQuanLy.EditValue != null)
            {
                bool danopbang;
                if (bool.TryParse(rdGDaNopBang_TabQuanLy.EditValue.ToString(), out danopbang))
                {
                    if (KiemTraChonQuanLyDiHocRow())
                    {
                        foreach (QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc in _quaTrinhDaoTaoNhanLucList)
                        {
                            if (quaTrinhDaoTaoNhanLuc.Chon)
                            {
                                quaTrinhDaoTaoNhanLuc.DaNopBang = danopbang;
                            }
                        }
                        bsQuaTrinhDaoTaoList.DataSource = _quaTrinhDaoTaoNhanLucList;
                    }
                }
            }
        }

        private void checkAll_TabQuanLy_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll_TabQuanLy.Checked == true)
            {
                foreach (QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc in _quaTrinhDaoTaoNhanLucList)
                {
                    quaTrinhDaoTaoNhanLuc.Chon = true;
                }
            }
            else
            {
                foreach (QuaTrinhDaoTaoNhanLuc quaTrinhDaoTaoNhanLuc in _quaTrinhDaoTaoNhanLucList)
                {
                    quaTrinhDaoTaoNhanLuc.Chon = false;
                }
            }
            bsQuaTrinhDaoTaoList.DataSource = _quaTrinhDaoTaoNhanLucList;
            QuanLyDiHocGrdV.RefreshData();
        }

        private void btnRefesh_TabQuanLy_Click(object sender, EventArgs e)
        {
            if (rdGKetQuaDaoTao_TabQuanLy.EditValue != null)
            {
                rdGKetQuaDaoTao_TabQuanLy.EditValue = null;
            }

            if (rdGDaNopBang_TabQuanLy.EditValue != null)
            {
                rdGDaNopBang_TabQuanLy.EditValue = null;
            }
        }


        #endregion

        #region TabTheoDoiNopVanBang

        private void TimTabThoiDoird_EditValueChanged(object sender, EventArgs e)
        {
            //LoadDataGridTheoDoiNopVanBang();
        }

        private void btnXuatLuoiraExcelTabThoiDoi_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TheoDoiNopVanBangGrdV.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void btnTimTabTheoDoi_Click(object sender, EventArgs e)
        {
            LoadDataGridTheoDoiNopVanBang();
        }

        #endregion


        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadDaTabyTab();
        }

        #endregion
        public frmQuanLyDaoTao()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadForTabDeCu();
            LoadForTabQuanLyDiHoc();
            LoadForTabTheoDoiNopVanBang();
            //LoadDaTabyTab();

        }


        










    }
}
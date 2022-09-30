using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using System.Data;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;

namespace PSC_ERPNew.Main
{
    public partial class frmNhapTaiSanCoDinhCaBietCu : XtraForm
    {
        //Private Member field
        #region Private Member field
        DanhMucTSCD_Factory _danhMucTSCD_Factory = null;// DanhMucTSCD_Factory.New();
        TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_Factory = null;// TaiSanCoDinhCaBiet_Factory.New();
        IQueryable<tblTaiKhoan> _taiKhoanList;
        IQueryable<tblnsBoPhan> _phongBanList;
        IQueryable<tblNguon> _nguonList;
        IQueryable<tblDonViTinh> _donViTinhList;
        IQueryable<tblQuocGia> _quocGiaList;

       // List<tblHinhThucMuaSam> _hinhThucMuaSamList = null;
        List<tblDoiTac> _doiTacList = null;
        //List<tblCoSo> _coSoList = null;
        List<spd_LichSuDieuChuyenTaiSanCoDinhCaBiet_Result> _lichSuDieuChuyenNoiBo = new List<spd_LichSuDieuChuyenTaiSanCoDinhCaBiet_Result>();
        List<spd_TSCD_LichSuTongQuatSuDungTaiSan_Result> _lichSuTongQuat = new List<spd_TSCD_LichSuTongQuatSuDungTaiSan_Result>();

        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
        tblDanhMucTSCD _taiSanCoDinh = DanhMucTSCD_Factory.New().CreateAloneObject();// null;

        string soHieu = "";
        Boolean _suaTaiSanCaBietCu = false;
        public Boolean _nhapTiep = false;
        Boolean _taiSanLaDat = false;
        #endregion

        //Public Member Property
        #region Public Member Property
        public tblTaiSanCoDinhCaBiet TaiSanCoDinhCaBiet
        {
            get
            {
                //số hiệu tự động nhảy, ko bind được nên dùng cách này để gán
                _taiSanCoDinhCaBiet.SoHieu = txtSoHieuCaBiet.EditValue.ToString();
                //_taiSanCoDinhCaBiet.MaTSCD = (Int32)cbTaiSanCoDinh.EditValue;
                return _taiSanCoDinhCaBiet;
            }
            //set { _taiSanCoDinhCaBiet = value; }
        }
        public Decimal NguyenGiaTinhHaoMon
        {
            get
            {
                Decimal NguyenGiaTinhHaoMon = Convert.ToDecimal(txt_NguyenGiaTinhHaoMon.EditValue);
                return NguyenGiaTinhHaoMon;
            }
        }
        public Decimal NguyenGiaMua
        {
            get
            {
                Decimal NguyenGiaMua = Convert.ToDecimal(txt_NguyenGiaMua.EditValue);
                return NguyenGiaMua;
            }
        }
        public Decimal NguyenGiaConLai
        {
            get
            {
                Decimal NguyenGiaConLai = Convert.ToDecimal(txt_NguyenGiaConLai.EditValue);
                return NguyenGiaConLai;
            }
        }

        public Int32 SoLuongTaiSanCaBiet
        {
            get { return (Int32)this.numSoLuong.Value; }//trả về số lượng tài sản cần ghi tăng
        }

        public Int32 MaBoPhan
        {
            get
            {
                return (Int32)cmb_BoPhan.EditValue;//trả về mã phòng ban được chọn
            }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmNhapTaiSanCoDinhCaBietCu()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
        }

        //sửa ngày 11/01/2016
        //nhập mới tài sản cũ
        public frmNhapTaiSanCoDinhCaBietCu(tblDanhMucTSCD taiSanCoDinh, Boolean _laDat)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;

            _taiSanLaDat = _laDat;
            _suaTaiSanCaBietCu = false;
            _taiSanCoDinh = taiSanCoDinh;

            _taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
            _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();

            tblDanhMucTSCD loaiTS = _danhMucTSCD_Factory.Get_LoaiTaiSan_ByMaLoaiTaiSan(taiSanCoDinh.ParentID.Value);
            tblDanhMucTSCD nhomTS = _danhMucTSCD_Factory.Get_NhomTaiSan_ByMaNhomTaiSan(loaiTS.LoaiTaiSanThuocNhomTaiSan.Value);
            txtTenNhomTaiSan.EditValue = nhomTS.Ten;
            txtTenLoaiTaiSan.EditValue = loaiTS.Ten;
            txtTenTSCD.EditValue = taiSanCoDinh.Ten;
            txtModelTSCD.EditValue = taiSanCoDinh.ModelTSCD;
            btn_Xoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.Text = string.Format("Nhập tài sản cá biệt cũ cho tài sản {0} - {1}", taiSanCoDinh.Ten, taiSanCoDinh.ModelTSCD);

            //lấy số hiệu tự phát sinh không cho nhập - muốn nhập chỉnh lại sau vì tùy vào mỗi công ty sẽ có cách quản lý só hiệu khác nhau
            soHieu = _taiSanCoDinhCaBiet_Factory.Get_NextSoHieuTSCDCaBiet_ByMaTSCD(taiSanCoDinh.ID);
            //txtSoHieuCaBiet.Text = soHieu;
            LoadData();

           // _taiSanCoDinhCaBiet.TaiKhoanDoiUng = taiSanCoDinh.TaiKhoanTuongUng;
            _taiSanCoDinhCaBiet.ThoiGianSuDung = taiSanCoDinh.TGSuDungToiTHieuTSCD;
           // _taiSanCoDinhCaBiet.KhauHaoNam = taiSanCoDinh.TyLeHaoMon;
            //cập nhật tài khoản mặc định
            cmb_DonViTinh.EditValue = taiSanCoDinh.MaDonViTinhTSCD;
            cmb_QuocGia.EditValue = taiSanCoDinh.MaNuocSxTSCD;
            //cmb_BoPhan.EditValue = 2;//gán mặc định là phòng quản trị vật tư cơ sở 1
        }

        //load lại tài sản cũ  -tạm thời không sử dụng - dùng from bên chứng từ ghi tăng -- sau này thêm loại tài sản không có chứng từ, tài sản không có chứng từ, tài sản cũ (tài sản cũ có thể chứng từ hay không chứng từ).
        //sửa tài sản cá biệt cũ
        public frmNhapTaiSanCoDinhCaBietCu(tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet, Boolean _laDat)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            _taiSanLaDat = _laDat;
            _suaTaiSanCaBietCu = true;
            _taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
            _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();

            _taiSanCoDinhCaBiet = _taiSanCoDinhCaBiet_Factory.Get_TrucTiepTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaTSCDCB(taiSanCoDinhCaBiet.MaTSCDCaBiet);
            _taiSanCoDinh = taiSanCoDinhCaBiet.tblDanhMucTSCD;

            tblDanhMucTSCD loaiTS = _danhMucTSCD_Factory.Get_LoaiTaiSan_ByMaLoaiTaiSan(_taiSanCoDinh.ParentID.Value);
            tblDanhMucTSCD nhomTS = _danhMucTSCD_Factory.Get_NhomTaiSan_ByMaNhomTaiSan(loaiTS.LoaiTaiSanThuocNhomTaiSan.Value);
            txtTenNhomTaiSan.EditValue = nhomTS.Ten;
            txtTenLoaiTaiSan.EditValue = loaiTS.Ten;
            txtTenTSCD.EditValue = _taiSanCoDinh.Ten;
            txtModelTSCD.EditValue = _taiSanCoDinh.ModelTSCD;
            //btn_Xoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.Text = string.Format("Sửa thông tin tài sản cá biệt cũ cho tài sản {0} - {1}", _taiSanCoDinh.Ten, _taiSanCoDinh.ModelTSCD);

            LoadData();
            //gán lại thông tin của tài sản cá biệt
            txtSoHieuCaBiet.Text = _taiSanCoDinhCaBiet.SoHieu;
            txtSerialTSCDCaBiet.Text = _taiSanCoDinhCaBiet.Serial;
            cmb_DonViTinh.EditValue = _taiSanCoDinh.MaDonViTinhTSCD;
            cmb_QuocGia.EditValue = _taiSanCoDinh.MaNuocSxTSCD;
            cmb_BoPhan.EditValue = _taiSanCoDinhCaBiet.PhanBoSauCung_RefObj.MaPhongBan;
            //cmb_BoPhan.Enabled = false;
        }
        //
        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            //lấy danh sách tài khoản
            _taiKhoanList = TaiKhoan_Factory.New().GetAll();
            //_taiKhoanList = TaiKhoan_Factory.New().Get_TaiKhoanbyMaLoai(3);//3 là tài khoản của tài sản cố định
            //lấy danh sách phòng ban
            _phongBanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
            //lấy danh sách nguồn
            _nguonList = Nguon_Factory.New().GetAll();
            //lấy danh sách đơn vị tính
            _donViTinhList = DonViTinh_Factory.New().GetAll();
            //lấy danh sách quốc gia
            _quocGiaList = QuocGia_Factory.New().GetAll();
            //lấy hình thức mua sắm
          //  _hinhThucMuaSamList = tblHinhThucMuaSam_Factory.New().GetAll().ToList();
            //lấy danh sách đối tác - khách hàng
            _doiTacList = DoiTac_Factory.New().GetAll().ToList();
            //lấy danh sách cơ sở
           // _coSoList = tblCoSo_Factory.New().GetAll().ToList();

            //tạo mới đối tượng tài sản cá biệt ko được quản lý
            //_taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
            if (!_suaTaiSanCaBietCu)
            {
                _taiSanCoDinhCaBiet = _taiSanCoDinhCaBiet_Factory.CreateManagedObject();//CreateAloneObject();

                _taiSanCoDinhCaBiet.NgayNhan = app_users_Factory.New().SystemDate;
                _taiSanCoDinhCaBiet.NgaySuDung = app_users_Factory.New().SystemDate;

                _taiSanCoDinhCaBiet.SoHieu = soHieu;
                _taiSanCoDinhCaBiet.MaTSCD = _taiSanCoDinh.ID;

                //gán nguồn mua mặc định là lẻ
                //_taiSanCoDinhCaBiet.NguonMua = ((int)LoaiNguonMuaEnum.Le == 1 ? true : false);//false lẻ
                //gán mặc định tài sản khởi tạo là tính hao mòn
                //if (_taiSanLaDat)//là đất thì không tính khấu hao với hao mòn
                //    _taiSanCoDinhCaBiet.KHHM = null;
                //else
                //    _taiSanCoDinhCaBiet.KHHM = false;

                _taiSanCoDinhCaBiet.NguyenGiaMua = 0;
                _taiSanCoDinhCaBiet.LuyKeHaoMon = 0;
                _taiSanCoDinhCaBiet.LuyKeKhauHao = 0;
                _taiSanCoDinhCaBiet.LaTaiSanCu = true;
            }           
            _lichSuDieuChuyenNoiBo = _taiSanCoDinhCaBiet_Factory.Context.spd_LichSuDieuChuyenTaiSanCoDinhCaBiet(_taiSanCoDinhCaBiet.MaTSCDCaBiet).ToList();
            _lichSuTongQuat = _taiSanCoDinhCaBiet_Factory.Context.spd_TSCD_LichSuTongQuatSuDungTaiSan(_taiSanCoDinhCaBiet.MaTSCDCaBiet).ToList();
            GanBindingSource();
        }
        private void GanBindingSource()
        {
            //tài khoản
            tblTaiKhoanBindingSource.DataSource = _taiKhoanList;
            //phòng ban
            tblnsBoPhan_BindingSource.DataSource = _phongBanList;
            //cbBoPhan.EditValue = 42;//gán chết kho nhận tài sản -- không auto phát sinh nghiệp vụ điều chuyển lần đầu
            //nguồn
            tblNguonBindingSource.DataSource = _nguonList;
            //đơn vị tính
            tblDonViTinhBindingSource.DataSource = _donViTinhList;
            //quốc gia
            tblQuocGiaBindingSource.DataSource = _quocGiaList;

            //hình thức mua sắm
            //tblHinhThucMuaSam_BindingSource.DataSource = _hinhThucMuaSamList;
            //danh sách khách hàng - đối tác
            tblDoiTacBindingSource.DataSource = _doiTacList;           
            //lịch sử sửa chữa tài sản
            tblLichSuSuaChuaTaiSanBindingSource.DataSource = _taiSanCoDinhCaBiet.tblLichSuSuaChuaTaiSans;
            tblTaiSanCoDinhCaBietBindingSource_Single.DataSource = _taiSanCoDinhCaBiet;
            //chi tiết tài sản
            tblChiTietTaiSanCaBietBindingSource.DataSource = _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets;
            //dụng cụ phụ tùng
            tblBoSungDungCuPhuTungBindingSource.DataSource = _taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs;
            //lịch sử điều chuyển
            tblLichSuDieuChuyenTaiSanbindingSource.DataSource = _lichSuDieuChuyenNoiBo;
            //lịch sử điều chuyển tổng quát
            tblLichSuSuDungTaiSan.DataSource = _lichSuTongQuat;
        }

        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;
            //Kiểm tra chọn tài sản cố định
            //if ((_taiSanCoDinhCaBiet.MaTSCD ?? 0) == 0)
            //{
            //    DialogUtil.ShowWarning("Chưa chọn tài sản cố định");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    cbTaiSanCoDinh.Focus();
            //    hopLe = false;
            //    return hopLe;
            //}
            //kiểm tra số hiệu
            if (txtSoHieuCaBiet.EditValue == null || String.IsNullOrWhiteSpace(txtSoHieuCaBiet.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Số hiệu tài sản cá biệt rỗng");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                txtSoHieuCaBiet.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra tài khoản
            if (_taiSanCoDinhCaBiet.TaiKhoanDoiUng == null)
            {
                DialogUtil.ShowWarning("Chưa chọn tài khoản");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                cbTaiKhoan.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra phòng ban
            //cbBoPhan.EditValue = 42;//gán mặc định tất cả tài sản về kho tiếp nhận ghi tăng
            if (cmb_BoPhan.EditValue == null || (Int32)cmb_BoPhan.EditValue == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận sử dụng");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                cmb_BoPhan.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra lũy kế KH
            if ((_taiSanCoDinhCaBiet.LuyKeKhauHao ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Lũy kế khấu hao phải là số dương");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                txtLuyKeKH.Focus();
                hopLe = false;
                return hopLe;
            }
            //Kiểm tra lũy kế HM
            if ((_taiSanCoDinhCaBiet.LuyKeHaoMon ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Lũy kế hao mòn phải là số dương");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                txtLuyKeHM.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra số lượng
            if (Convert.ToInt32(numSoLuong.EditValue) < 1)
            {
                DialogUtil.ShowWarning("Cần nhập số lượng. Số lượng tối thiểu = 1");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                numSoLuong.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra nguyên giá
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa nhập nguyên giá");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                txt_NguyenGiaMua.Focus();
                hopLe = false;
                return hopLe;
            }
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Nguyên giá phải là số dương");
                //focus đến vị trí
                xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                txt_NguyenGiaMua.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra ngày thanh lý
            if ((_taiSanCoDinhCaBiet.ThanhLy ?? false) && (_taiSanCoDinhCaBiet.NgayThanhLy == null || _taiSanCoDinhCaBiet.NgayThanhLy > _taiSanCoDinhCaBiet.NgaySuDung))
            {
                DialogUtil.ShowWarning("Chưa có ngày thanh lý!\nHay ngày thanh lý không hợp lệ (không được lớn hơn ngày sử dụng)\nVui lòng nhập ngày thanh lý!");
                hopLe = false;
                return hopLe;
            }
            ////kiểm tra chi phí
            //if ((_taiSanCoDinhCaBiet.ChiPhi ?? 0) < 0)
            //{
            //    DialogUtil.ShowWarning("Chi phí phải là số dương");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    txtChiPhiCaBiet.Focus();
            //    hopLe = false;
            //    return hopLe;
            //}
            //Kiểm tra chi tiết////////////////////////////////////////////////////////
            foreach (tblChiTietTaiSanCaBiet chiTiet in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
            {
                if (String.IsNullOrWhiteSpace(chiTiet.TenChiTiet))
                {
                    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. \nTên của chi tiết không được rỗng!");
                    //focus đến vị trí
                    xtraTabControl_TaiSan.SelectedTabPage = tabChiTietTaiSan;
                    hopLe = false;
                    return hopLe;
                }
                if (String.IsNullOrWhiteSpace(chiTiet.SoHieu))
                {
                    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. \nSố hiệu của chi tiết không được rỗng!");
                    //focus đến vị trí
                    xtraTabControl_TaiSan.SelectedTabPage = tabChiTietTaiSan;
                    hopLe = false;
                    return hopLe;
                }
            }
            _taiSanCoDinhCaBiet.NgayChungTu = _taiSanCoDinhCaBiet.NgayChungTu;//gán ngày chứng từ là ngày nhận vì không có chứng từ ghi tăng
            //return ở trong if là vì code chạy từ trên xuống lỗi thì thoát ra khỏi đoạn code đang chạy 
            return hopLe;
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmNhapTaiSanCoDinhCaBietCu_Load(object sender, EventArgs e)
        {
            //this.LoadData();
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewChiTietTaiSanCaBiet);
            GridUtil.SetSTTForGridView(this.grdViewDungCuPhuTung);
            //cài đặt filter để ko hiển thị các dòng dụng cụ phụ tùng từ nghiệp vụ sữa chữa lớn
            this.colLaDCPTSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaDCPTSuaChuaLon.FieldName + " = false");
            //cài đặt filter để ko hiển thị các dòng bổ sung chi tiết tài sản sữa chữa lớn
            this.colLaChiTietSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaChiTietSuaChuaLon.FieldName + " = false");
            //mặc định năm sản xuất
            if (_taiSanCoDinhCaBiet.NamSX == null)
                numNamSX.Value = (Decimal)app_users_Factory.New().SystemDate.Year;
            //Delete helper
            GridUtil.DeleteHelper.Setup_AutoType(grdViewChiTietTaiSanCaBiet);
            //Delete helper
            GridUtil.DeleteHelper.Setup_AutoType(grdViewDungCuPhuTung);
            //Delete helper
            GridUtil.DeleteHelper.Setup_AutoType(gridView_LichSuSuaChuaTS);
                       
            //đóng mở các control không cần thiết cho loại tài sản là đất
            txtLuyKeHM.Visible = lbl_LuyKeHM.Visible = radioKHHM.Visible = false;
            txtLuyKeKH.Visible = lbl_LuyKeKH.Visible = numSoNamSD.Visible = lbl_SoNamSD.Visible = lbl_PTHM.Visible = txt_PhanTramKhauHao.Visible = chk_ThanhLy.Visible = lbl_NgayThanhLy.Visible = date_NgayThanhLy.Visible = !_taiSanLaDat;
           if (KiemTraTaiSanDaPhatSinhNghiepVu(false))
           {               
           }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (KiemTraHopLe())
            {
                TaoTaiSanCoDinhCaBiet();
                try
                {
                    //if (_taiSanCoDinhCaBiet_Factory.IsDirty)
                    //tblTaiSanCoDinhCaBietBindingSource_Single.EndEdit();
                    _taiSanCoDinhCaBiet_Factory.SaveChangesWithoutTrackingLog();
                    //_taiSanCoDinhCaBiet_Factory.SaveChanges();//lưu lại
                    if (!_suaTaiSanCaBietCu)
                    {
                        if (DialogUtil.ShowYesNo("Bạn có muốn nhập tiếp tài sản cá biệt cho tài sản " + _taiSanCoDinh.Ten) == DialogResult.Yes)
                            _nhapTiep = true;
                        else
                        {
                            _nhapTiep = false;
                            DialogUtil.ShowSaveSuccessful();
                        }
                    }
                    else
                    {
                        DialogUtil.ShowSaveSuccessful();
                        _nhapTiep = false;
                    }
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;//thoát mà không làm gì hết
            this.Close();
        }

        private void numSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            Int32 soLuong = (Int32)numSoLuong.Value;
            if (soLuong == 1)//chỉ cho phép nhập serial của tài sản cá biệt nếu số lượng =1
            {
                txtSerialTSCDCaBiet.Enabled = true;
            }
            else
            {
                txtSerialTSCDCaBiet.EditValue = null;
                txtSerialTSCDCaBiet.Enabled = false;
            }
        }

        //nhập chi tiết tài sản
        private void grdViewChiTietTaiSanCaBiet_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy chi tiết mới
            tblChiTietTaiSanCaBiet chiTietMoi = grdViewChiTietTaiSanCaBiet.GetRow(e.RowHandle) as tblChiTietTaiSanCaBiet;
            if (chiTietMoi != null)
            {
                Int32 maxNum = 0;
                foreach (tblChiTietTaiSanCaBiet chiTietTruocDo in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
                {
                    if (String.IsNullOrWhiteSpace(chiTietTruocDo.SoHieu) == false)
                    {
                        Int32 maxNumTemp = Int32.Parse(chiTietTruocDo.SoHieu.Substring(chiTietTruocDo.SoHieu.Length - PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart));
                        if (maxNumTemp > maxNum)
                            maxNum = maxNumTemp;
                    }
                }

                String soHieuCapTren = txtSoHieuCaBiet.Text;
                //tạo số hiệu
                String soHieuMoi = "";
                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.CreateFirst_SoHieuChiTietTaiSanCaBiet(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.Create_SoHieuChiTietTaiSanCaBiet(soHieuCapTren, maxNum + 1);

                //gán số hiệu mới cho chi tiết
                chiTietMoi.SoHieu = soHieuMoi;
                chiTietMoi.TenChiTiet = "";
                chiTietMoi.SoLuong = 1;
                chiTietMoi.DonGia = 0;
                chiTietMoi.ChiPhi = 0;
                chiTietMoi.NguyenGia = 0;
                //chiTietMoi.GhiChu = txtGhiChu.Text.Trim();
            }
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabChiTietTaiSan)
            {
                if (String.IsNullOrWhiteSpace(txtSoHieuCaBiet.Text))
                {
                    DialogUtil.ShowWarning(String.Format("Cần nhập thông tin bên thẻ [{0}] trước!", tabTaiSanChinh.Text));
                    //focus về tab tài sản chính
                    xtraTabControl_TaiSan.SelectedTabPage = tabTaiSanChinh;
                }
            }
        }

        private void grdViewDungCuPhuTung_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy đối tượng vừa tạo mới trên lưới
            tblBoSungDungCuPhuTung doiTuong = grdViewDungCuPhuTung.GetRow(e.RowHandle) as tblBoSungDungCuPhuTung;
            if (doiTuong != null)
            {
                //mặc định số lượng =1
                doiTuong.SoLuong = 1;
                doiTuong.DonGia = 0;
                doiTuong.ChiPhi = 0;
                doiTuong.TongGiaTri = 0;
                //doiTuong.GhiChu = txtGhiChu.Text.Trim();
                doiTuong.Ten = "";
                doiTuong.MaQuanLy = "";
                //doiTuong.UserID = PSC_ERP_Global.Main.UserID;
            }
        }

        private void ThemChiTietNguyenGiaTheoTaiSanCaBiet(tblTaiSanCoDinhCaBiet taiSanCaBiet)
        {
            tblChiTietNguyenGiaTSCD chiTietNguyenGia = ChiTietNguyenGiaTSCD_Factory.New().CreateAloneObject();
            chiTietNguyenGia.SoTien = taiSanCaBiet.NguyenGiaMua;
            chiTietNguyenGia.LuyKeKhauHao = taiSanCaBiet.LuyKeKhauHao;
            chiTietNguyenGia.LuyKeHaoMon = taiSanCaBiet.LuyKeHaoMon;

            //chiTietNguyenGia.NgayThucHien = (DateTime?)dteNgayChungTu.DateTime.Date;
            chiTietNguyenGia.NgayThucHien = (DateTime?)date_NgaySuDung.DateTime.Date;
            chiTietNguyenGia.LoaiPhanBietNV = (Byte)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.TaiSanGoc;//tài sản gốc
            //đưa vào danh sách
            // _chungTu.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGia);
            taiSanCaBiet.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGia);
        }

        private void TaoMoiPhanBoTaiSanCaBiet(tblTaiSanCoDinhCaBiet taiSanCaBiet, Int32 maPhongBan)
        {
            tblTaiSanCoDinhCaBiet_PhongBan ts_pb = TaiSanCoDinhCaBiet_PhongBan_Factory.New().CreateAloneObject();
            //gán mã phòng ban
            ts_pb.MaPhongBan = maPhongBan;
            //gán ngày phân bổ là ngày chứng từ
            //ts_pb.NgayPhanBo = _chungTu.NgayLap;
            ts_pb.NgayPhanBo = taiSanCaBiet.NgaySuDung;//date_NgayNhan.DateTime.Date;
            //gán user tạo
            ts_pb.UserID = PSC_ERP_Global.Main.UserID;
            //đưa phân bổ vào danh sách phân bổ của tài sản
            taiSanCaBiet.tblTaiSanCoDinhCaBiet_PhongBan.Add(ts_pb);
        }

        //bổ sung ngày 12/01/2016
        public void TaoTaiSanCoDinhCaBiet()
        {
            //lấy mã phòng ban
            Int32 maPhongBan = this.MaBoPhan;

            //tạo mới chi tiết nguyên giá
            if (!_suaTaiSanCaBietCu)
                ThemChiTietNguyenGiaTheoTaiSanCaBiet(_taiSanCoDinhCaBiet);

            //tạo phân bổ cho tài sản đầu tiên
            if (!_suaTaiSanCaBietCu)
                TaoMoiPhanBoTaiSanCaBiet(_taiSanCoDinhCaBiet, maPhongBan);

            //thêm tài sản đầu tiên vào danh sách
            //tblTaiSanCoDinhCaBietBindingSource.Add(taiSanDauTien);
        }

        private void btnSaoChepDungCuPhuTung_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = this.grdViewDungCuPhuTung.GetSelectedRows();
            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0)
                {
                    tblBoSungDungCuPhuTung dungCuPhuTung = this.grdViewDungCuPhuTung.GetRow(rowHandle) as tblBoSungDungCuPhuTung;
                    //copy
                    tblBoSungDungCuPhuTung dungCuPhuTungNew = BoSungDungCuPhuTung_Factory.BasicClonePhuTungGhiTang(dungCuPhuTung);
                    //dua vao tai san
                    _taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs.Add(dungCuPhuTungNew);
                }
            }
        }
        private void btnSaoChepChiTietTaiSan_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = this.grdViewChiTietTaiSanCaBiet.GetSelectedRows();
            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0)
                {
                    tblChiTietTaiSanCaBiet chiTiet = this.grdViewChiTietTaiSanCaBiet.GetRow(rowHandle) as tblChiTietTaiSanCaBiet;
                    //copy
                    tblChiTietTaiSanCaBiet chiTietNew = ChiTietTaiSanCaBiet_Factory.BasicCloneChiTietTaiSan(chiTiet);
                    //tao moi so hieu cho chi tiet
                    {
                        Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;
                        //lay max so hieu trong danh sách
                        String maxSoHieuChiTiet = (from o in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets
                                                   orderby o.SoHieu.Substring(o.SoHieu.Length - sizeOfNumber, sizeOfNumber) descending
                                                   select o.SoHieu).FirstOrDefault();
                        if (maxSoHieuChiTiet != null)
                            chiTietNew.SoHieu = ChiTietTaiSanCaBiet_Factory.IncreaseSoHieuChiTietTaiSanCaBiet(maxSoHieuChiTiet);
                    }
                    //dua vao tai san
                    _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets.Add(chiTietNew);
                }
            }
        }
        #endregion

        private void chk_ThanhLy_CheckedChanged(object sender, EventArgs e)
        {
            date_NgayThanhLy.EditValue = null;
            date_NgayThanhLy.Enabled = chk_ThanhLy.Checked;
        }

        private void cmb_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            if (_suaTaiSanCaBietCu)
            {
                tblnsBoPhan boPhan = cmb_BoPhan.GetSelectedDataRow() as tblnsBoPhan;
                if (boPhan != null && boPhan.MaBoPhan != _taiSanCoDinhCaBiet.MaBoPhanDauTien_RefObj)
                {
                    DialogResult dlg = DialogUtil.ShowYesNo("Bạn có muốn thay đổi bộ phận đầu tiên của tài sản này?");
                    if (dlg == DialogResult.Yes)
                    {
                        TaiSanCoDinhCaBiet_PhongBan_Factory _taiSanCoDinhCaBiet_PhongBan_factory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
                        tblTaiSanCoDinhCaBiet_PhongBan taiSanCoDinhCaBiet_PhongBan = _taiSanCoDinhCaBiet_PhongBan_factory.Get_PhanBoDauTien_ByMaTSCDCaBiet(_taiSanCoDinhCaBiet.MaTSCDCaBiet);
                        taiSanCoDinhCaBiet_PhongBan.MaPhongBan = boPhan.MaBoPhan;
                        try
                        {
                            using (DialogUtil.WaitForSave(this))
                            {
                                _taiSanCoDinhCaBiet_PhongBan_factory.SaveChangesWithoutTrackingLog();
                            }
                            DialogUtil.ShowSaveSuccessful();
                            _taiSanCoDinhCaBiet.MaBoPhanDauTien_RefObj = boPhan.MaBoPhan;
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowError(string.Format("Lỗi :{0}", ex.Message));
                        }
                    }
                    else
                    {
                        cmb_BoPhan.EditValue = _taiSanCoDinhCaBiet.MaBoPhanDauTien_RefObj;
                    }
                }
            }
        }

        private void btn_InChiTietSuDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("In_ChiTietSuDungTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spd_TSCD_LichSuTongQuatSuDungTaiSan", "@MaTSCDCB", _taiSanCoDinhCaBiet.MaTSCDCaBiet);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }      

        public Boolean KiemTraTaiSanDaPhatSinhNghiepVu(Boolean hienthongbao)
        {
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepLapDeNghi(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                 DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ lập duyệt đề nghị!");
                return true;
            }
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepThanhLy(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                 DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ thanh lý!");
                return true;
            }
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChinhGiaTri(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                    DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ điều chỉnh giá trị!");
                return true;
            }
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuSuaChuaLon(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                    DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ sửa chữa lớn!");
                return true;
            }
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuDieuChuyenNoiBo(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                    DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ điều chuyển!");
                return true;
            }
            if (TaiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietDaPhatSinhNghiepVuInMaVach(TaiSanCoDinhCaBiet.MaTSCDCaBiet))
            {
                if (hienthongbao)
                    DialogUtil.ShowWarning("Không được xóa/sửa nguyên giá tài sản này vì đã phát sinh nghiệp vụ in mã vạch!");
                return true;
            }
            return false;
        }

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraTaiSanDaPhatSinhNghiepVu(true) == false)
            {
                if (DialogUtil.ShowYesNo("Bạn có muốn xóa tài sản" + _taiSanCoDinh.Ten + " " + _taiSanCoDinhCaBiet.GhiChu + " \nSố hiệu:" + _taiSanCoDinhCaBiet.SoHieu + "\nra khỏi hệ thống?") == DialogResult.Yes)
                {
                    TaiSanCoDinhCaBiet_Factory.DeleteTSCDCaBiet(_taiSanCoDinhCaBiet_Factory.Context, TaiSanCoDinhCaBiet);
                    tblTaiSanCoDinhCaBietBindingSource_Single.EndEdit();
                    _taiSanCoDinhCaBiet_Factory.SaveChangesWithoutTrackingLog();
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
        }
    }
}
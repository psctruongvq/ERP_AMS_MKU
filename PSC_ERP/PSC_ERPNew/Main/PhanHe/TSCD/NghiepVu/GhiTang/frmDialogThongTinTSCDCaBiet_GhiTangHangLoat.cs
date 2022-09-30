using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using System.Collections.Generic;
using ERP_Library.Security;

namespace PSC_ERPNew.Main
{
    public partial class frmDialogThongTinTSCDCaBiet_GhiTangHangLoat : XtraForm
    {
        //Private Member field
        #region Private Member field
        DanhMucTSCD_Factory _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
        IQueryable<tblDanhMucTSCD> _nhomList;
        IQueryable<tblDanhMucTSCD> _loaiList;
        IQueryable<tblDanhMucTSCD> _TSCDList;
        List<tblDanhMucTSCD> _TSCDorCCDCList;
        IQueryable<tblTaiKhoan> _taiKhoanList;
        IQueryable<tblnsBoPhan> _phongBanList;
        IQueryable<tblBoPhanERPNew> _viTriList;
        IQueryable<tblNguon> _nguonList;
        IQueryable<tblDonViTinh> _donViTinhList;
        IQueryable<tblQuocGia> _quocGiaList;
        UserInfo user = ERP_Library.Security.CurrentUser.Info;
        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        decimal _donGia = 0,_nguyenGiaMua=0, _tongDonGia = 0, _tongNguyenGia = 0, _tongChiPhi = 0, _phanTramThue = 0, _tongTienThue = 0;
        int _soLuong = 1;
        string _soHoaDonCu = string.Empty, _soHopDongCu = string.Empty;
        public DateTime _NgayChungtu = DateTime.Now.Date;
        #endregion

        //Public Member Property
        #region Public Member Property
        public tblTaiSanCoDinhCaBiet TaiSanCoDinhCaBiet
        {
            get
            {
                //số hiệu tự động nhảy, ko bind được nên dùng cách này để gán
                _taiSanCoDinhCaBiet.SoHieu = txtSoHieuCaBiet.EditValue.ToString();
                _taiSanCoDinhCaBiet.MaTSCD = (Int32)cbTaiSanCoDinh.EditValue;
                return _taiSanCoDinhCaBiet;
            }
            //set { _taiSanCoDinhCaBiet = value; }
        }
        public Decimal NguyenGiaTaiSanSauCung
        {
            get
            {
                Decimal soLuong = this.numSoLuong.Value;
                //Decimal tongNguyenGia = Convert.ToDecimal(txtTongNguyenGia.EditValue);
                Decimal nguyenGiaLamTronXuong = Convert.ToDecimal(txtNguyenGia.EditValue);
                Decimal tongNguyenGiaLamTron = soLuong * nguyenGiaLamTronXuong;
                Decimal chenhLech = _tongNguyenGia - tongNguyenGiaLamTron;

                return nguyenGiaLamTronXuong + chenhLech;
            }
        }
        public Decimal DonGiaTaiSanSanSauCung
        {
            get
            {
                Decimal soLuong = this.numSoLuong.Value;
                Decimal tongDonGia = Convert.ToDecimal(txtTongDonGia.EditValue);
                Decimal donGiaLamTronXuong = Convert.ToDecimal(txtDonGiaCaBiet.EditValue);               
                Decimal tongDonGiaLamTron = soLuong * donGiaLamTronXuong;
                Decimal chenhLech = tongDonGia - tongDonGiaLamTron;

                return donGiaLamTronXuong + chenhLech;
            }
        }
        public Decimal ChiPhiTaiSanSanSauCung
        {
            get
            {
                Decimal soLuong = this.numSoLuong.Value;
                Decimal tongChiPhi = Convert.ToDecimal(txtTongChiPhi.EditValue);
                Decimal chiPhiLamTronXuong = Math.Floor(_tongChiPhi / _soLuong);
                Decimal tongChiPhiLamTron = soLuong * chiPhiLamTronXuong;
                Decimal chenhLech = tongChiPhi - tongChiPhiLamTron;

                return chiPhiLamTronXuong + chenhLech;
            }
        }
        public Decimal TienThueSanSauCung
        {
            get
            {
                Decimal soLuong = this.numSoLuong.Value;
                Decimal tienthueLamTronXuong = Convert.ToDecimal(txt_TienThue.EditValue);

                Decimal tongTienThueLamTron = soLuong * tienthueLamTronXuong;
                Decimal chenhLech = _tongTienThue - tongTienThueLamTron;

                return tienthueLamTronXuong + chenhLech;
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
                return (Int32)treeListLookUpEdit_BoPhan.EditValue;//(Int32)cbBoPhan.EditValue;//trả về mã phòng ban được chọn
            }
        }

        public Int32 MaViTri
        {
            get
            {
                return (Int32)(Int32)cbBoPhan.EditValue;//trả về mã phòng ban được chọn
            }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogThongTinTSCDCaBiet_GhiTangHangLoat()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;       
        }
        public frmDialogThongTinTSCDCaBiet_GhiTangHangLoat(string _soHoaDon="",string _soHopDong="")
        {
            InitializeComponent();
            this.DialogResult = DialogResult.No;
            _soHoaDonCu = _soHoaDon;
            _soHopDongCu = _soHopDong;
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _nhomList = _danhMucTSCD_Factory.Get_DanhSachNhomTaiSan();
            _loaiList = _danhMucTSCD_Factory.Get_DanhSachLoaiTaiSan();
            _TSCDList = null;
            //lấy danh sách tài khoản
            _taiKhoanList = TaiKhoan_Factory.New().GetAll();
            //lấy danh sách phòng ban
            _phongBanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy);
            //_viTriList = BoPhanERPNew_Factory.New().GetAll();
            _viTriList = BoPhanERPNew_Factory.New().GetAllByDate(_NgayChungtu);
            //lấy danh sách nguồn
            _nguonList = Nguon_Factory.New().GetAll();
            //lấy danh sách đơn vị tính
            _donViTinhList = DonViTinh_Factory.New().GetAll();
            //lấy danh sách quốc gia
            _quocGiaList = QuocGia_Factory.New().GetAll();

            //tạo mới đối tượng tài sản cá biệt ko được quản lý
            _taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().CreateAloneObject();
            _taiSanCoDinhCaBiet.LoaiTang = (byte?)LoaiGhiTangTSCDCaBietEnum.TangMoi;
            _taiSanCoDinhCaBiet.NgayNhan = app_users_Factory.New().SystemDate;
            _taiSanCoDinhCaBiet.NgaySuDung = app_users_Factory.New().SystemDate;

            //gán nguồn mua mặc định là lẻ
            _taiSanCoDinhCaBiet.NguonMua = ((int)LoaiNguonMuaEnum.Le == 1 ? true : false);//false lẻ
            _taiSanCoDinhCaBiet.ChiPhi = 0;
            _taiSanCoDinhCaBiet.DonGia = 0;
            _taiSanCoDinhCaBiet.NguyenGiaMua = 0;
            _taiSanCoDinhCaBiet.SoHopDong = _soHopDongCu;
            _taiSanCoDinhCaBiet.SoHoaDon = _soHoaDonCu;
            GanBindingSource();
            LayDanhSachTSCD();
        }
        private void GanBindingSource()
        {
            tblTaiSanCoDinhCaBietBindingSource_Single.DataSource = _taiSanCoDinhCaBiet;
            //tblDanhMucTSCDBindingSource_Nhom_Single.DataSource = _nhom;
            //tblDanhMucTSCDBindingSource_Loai_Single.DataSource = _loai;
            //nhóm tài sản
            tblDanhMucTSCDBindingSource_Nhom.DataSource = _nhomList;
            //loại tài sản
            tblDanhMucTSCDBindingSource_Loai.DataSource = _loaiList;
            //tài sản cố định
            tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDList;
            //tài khoản
            tblTaiKhoanBindingSource.DataSource = _taiKhoanList;
            //phòng ban
            tblBoPhanBindingSource.DataSource = _phongBanList;
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            //loại ghi tăng
            loaiGhiTangTSCDCaBietBindingSource.DataSource = LoaiGhiTangTSCDCaBiet.LoaiGhiTangTSCDCaBietList;
            //nguồn
            tblNguonBindingSource.DataSource = _nguonList;
            //đơn vị tính
            tblDonViTinhBindingSource.DataSource = _donViTinhList;
            //quốc gia
            tblQuocGiaBindingSource.DataSource = _quocGiaList;
            //chi tiết tài sản
            tblChiTietTaiSanCaBietBindingSource.DataSource = _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets;
            //dụng cụ phụ tùng
            tblBoSungDungCuPhuTungBindingSource.DataSource = _taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs;
            //thuế suất VAT
            ThueSuatVAT_bindingSource.DataSource = ThueSuatVAT.ThueSuatVATList;    
        }
        private void LayDanhSachLoaiTaiSan()
        {
            tblDanhMucTSCD nhom = cbNhomTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;

            if (nhom != null)
            {
                _loaiList = _danhMucTSCD_Factory.Get_DanhSachLoaiTaiSan_ByMaNhomTaiSan(nhom.ID);
                tblDanhMucTSCDBindingSource_Loai.DataSource = _loaiList;
            }
        }
        private void LayDanhSachTSCD()
        {
            //đọc lại danh sách tài sản cố định
            tblDanhMucTSCD loai = treeListLookUpEdit_LoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (loai != null)
            {
                _TSCDList = _danhMucTSCD_Factory.Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(loai.ID);             
                tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDList;
                cbTaiSanCoDinh.Properties.DataSource = tblDanhMucTSCDBindingSource_TSCD;
            }
            else
            {
                _TSCDorCCDCList = _danhMucTSCD_Factory.Context.spd_TSCD_LayDanhSachDanhMucTSCDorCCDCTheoCapCha(0,_maCongTy).ToList();
                tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDorCCDCList;
                cbTaiSanCoDinh.Properties.DataSource = tblDanhMucTSCDBindingSource_TSCD;
            }           
        }
        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;
            //Kiểm tra chọn tài sản cố định
            if ((_taiSanCoDinhCaBiet.MaTSCD ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn tài sản cố định");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                cbTaiSanCoDinh.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra số hiệu
            if (txtSoHieuCaBiet.EditValue == null || String.IsNullOrWhiteSpace(txtSoHieuCaBiet.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Số hiệu tài sản cá biệt trống!");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtSoHieuCaBiet.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra tên cá biệt
            if (txt_TenCaBiet.EditValue == null || String.IsNullOrWhiteSpace(txt_TenCaBiet.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Tên tài sản cá biệt trống");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txt_TenCaBiet.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra số hiệu
            if (textEdit_SoHoaDon.EditValue == null || String.IsNullOrWhiteSpace(textEdit_SoHoaDon.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Số hóa đơn tài sản không được để trống!");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                textEdit_SoHoaDon.Focus();
                hopLe = false;
                return hopLe;
            }
            if (textEdit_SoHopDong.EditValue == null || String.IsNullOrWhiteSpace(textEdit_SoHopDong.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Số hợp đồng tài sản không được để trống!");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                textEdit_SoHopDong.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra tài khoản
            //if ((Int32)cbTaiKhoan.EditValue == 0 || cbTaiKhoan.Text == "<<Không chọn>>")
            //{
            //    DialogUtil.ShowWarning("Chưa chọn tài khoản!\nVui lòng chọn tài khoản!");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    cbTaiKhoan.Focus();
            //    hopLe = false;
            //    return hopLe;
            //}
            if (treeListLookUpEdit_BoPhan.EditValue.ToString() == "" || (Int32)treeListLookUpEdit_BoPhan.EditValue == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn bộ phận khấu hao!\nVui lòng chọn bộ phận khấu hao!");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                //cbBoPhan.Focus();
                treeListLookUpEdit_BoPhan.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra phòng ban
            if (cbBoPhan.EditValue.ToString() == "Vui lòng chọn" || (Int32)cbBoPhan.EditValue == 0 )
            {
                DialogUtil.ShowWarning("Chưa chọn vị trí đơn vị sử dụng!\nVui lòng chọn vị trí đơn vị sử dụng!");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                //cbBoPhan.Focus();
                cbBoPhan.Focus();
                hopLe = false;
                return hopLe;
            }
          
            //kiểm tra lũy kế KH
            //if ((_taiSanCoDinhCaBiet.LuyKeKhauHao ?? 0) < 0)
            //{
            //    DialogUtil.ShowWarning("Lũy kế khấu hao phải là số dương!");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    txt_PhanTramThue.Focus();
            //    hopLe = false;
            //    return hopLe;
            //}

            //Kiểm tra lũy kế HM
            //if ((_taiSanCoDinhCaBiet.LuyKeHaoMon ?? 0) < 0)
            //{
            //    DialogUtil.ShowWarning("Lũy kế hao mòn phải là số dương!");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    txt_TienThue.Focus();
            //    hopLe = false;
            //    return hopLe;
            //}
            //kiểm tra số lượng
            if (Convert.ToInt32(numSoLuong.EditValue) < 1)
            {
                DialogUtil.ShowWarning("Cần nhập số lượng. Số lượng tối thiểu = 1");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                numSoLuong.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra nguyên giá
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa nhập thành tiền không VAT");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtTongDonGia.Focus();
                hopLe = false;
                return hopLe;
            }
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Nguyên giá phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtTongNguyenGia.Focus();
                hopLe = false;
                return hopLe;
            }
            //kiểm tra chi phí
            if ((_taiSanCoDinhCaBiet.ChiPhi ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Chi phí phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtChiPhiCaBiet.Focus();
                hopLe = false;
                return hopLe;
            }
            //Kiểm tra chi tiết////////////////////////////////////////////////////////
            foreach (tblChiTietTaiSanCaBiet chiTiet in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
            {
                if (String.IsNullOrWhiteSpace(chiTiet.TenChiTiet))
                {
                    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. Tên của chi tiết không được rỗng!");
                    //focus đến vị trí
                    xtraTabControl1.SelectedTabPage = tabChiTietTaiSan;
                    hopLe = false;
                    return hopLe;
                }
                if (String.IsNullOrWhiteSpace(chiTiet.SoHieu))
                {
                    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. Số hiệu của chi tiết không được rỗng!");
                    //focus đến vị trí
                    xtraTabControl1.SelectedTabPage = tabChiTietTaiSan;
                    hopLe = false;
                    return hopLe;
                }
            }
            return hopLe;
        }

        private void TinhTongNguyenGia_Bang_SL_Nhan_NguyenGiaCaBiet()
        {
            if (_pause1 == false)
            {
                lblGhiChuNguyenGia.Text = "";
                Int32 soLuong = (Int32)numSoLuong.Value;
                Decimal nguyenGia = Decimal.Parse(txtNguyenGia.EditValue.ToString() == "" ? "0" : txtNguyenGia.EditValue.ToString());

                Decimal tongNguyenGia = soLuong * nguyenGia;
                _pause1 = true;
                txtTongDonGia.EditValue = tongNguyenGia;
                _pause1 = false;
            }
        }
        private void TinhTongNguyenGia_Bang_TongDonGia_Cong_TongChiPhi()
        {
            //if (_pause1 == false)
            {
                Int32 soLuong = (Int32)numSoLuong.Value;
                Decimal DonGia = Decimal.Parse(txtTongNguyenGia.EditValue.ToString() == "" ? "0" : txtTongNguyenGia.EditValue.ToString());
                Decimal tongChiPhi = Decimal.Parse(txtTongChiPhi.EditValue.ToString() == "" ? "0" : txtTongChiPhi.EditValue.ToString());
                Decimal tienThue = Decimal.Parse(txt_TienThue.EditValue.ToString() == "" ? "0" : txt_TienThue.EditValue.ToString());
                Decimal tongNguyenGia = DonGia * soLuong + tongChiPhi + tienThue * soLuong;
                //_pause1 = true;
                txtTongDonGia.EditValue = tongNguyenGia;
                //_pause1 = false;
            }
        }
        private void TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet()
        {
            _soLuong = (Int32)numSoLuong.Value;
            _tongDonGia = Decimal.Parse(txtTongDonGia.EditValue.ToString() == "" ? "0" : txtTongDonGia.EditValue.ToString());          
            _tongChiPhi = Decimal.Parse(txtTongChiPhi.EditValue.ToString() == "" ? "0" : txtTongChiPhi.EditValue.ToString());
            _phanTramThue = Decimal.Parse(gridLookUpEdit_ThueSuatVAT.EditValue.ToString() == "" ? "0" : gridLookUpEdit_ThueSuatVAT.EditValue.ToString());
            _taiSanCoDinhCaBiet.PhanTramThue = _phanTramThue;
            _tongTienThue = Math.Floor(_phanTramThue * _tongDonGia / 100);//Decimal.Parse(txt_TienThue.EditValue.ToString() == "" ? "0" : txt_TienThue.EditValue.ToString());
            if (_soLuong < 1)
            {
                DialogUtil.ShowError("Số lượng không hợp lệ!\nVui lòng nhập số lương lớn hơn 0!");
                return;
            }
            //làm tròn xuống
            _donGia = Math.Floor(_tongDonGia / _soLuong);
            if (_tongChiPhi > 0)
                _taiSanCoDinhCaBiet.ChiPhi = Math.Floor(_tongChiPhi / _soLuong);
            if (_tongTienThue >= 0)
            {
                txt_TienThue.EditValue = Math.Floor(_tongTienThue / _soLuong);
                _taiSanCoDinhCaBiet.TienThue = Math.Floor(_tongTienThue / _soLuong);
            }
            txtDonGiaCaBiet.EditValue = _donGia;
            _tongNguyenGia = _tongDonGia + _tongTienThue + _tongChiPhi;
            _nguyenGiaMua = _donGia + Math.Floor(_tongTienThue / _soLuong);
            if (_donGia < 0)
            {
                DialogUtil.ShowError("Đơn giá không hợp lệ!");
                return;
            }
     
            if (_donGia > 0)
            {
                _taiSanCoDinhCaBiet.DonGia = _donGia;
                _taiSanCoDinhCaBiet.NguyenGiaMua = _nguyenGiaMua;
                _taiSanCoDinhCaBiet.NguyenGiaConLai = _nguyenGiaMua;
            }
           
        }
        private void TinhTongDonGia()
        {
            if (_pause3 == false)
            {
                lblGhiChuDonGia.Text = "";
                Int32 soLuong = (Int32)numSoLuong.Value;
                Decimal donGia = Decimal.Parse(txtDonGiaCaBiet.EditValue.ToString() == "" ? "0" : txtDonGiaCaBiet.Text);

                Decimal tongDonGia = soLuong * donGia;
                _pause3 = true;
                txtTongNguyenGia.EditValue = tongDonGia;
                _pause3 = false;
            }
        }
        private void TinhTongChiPhi()
        {
            if (_pause2 == false)
            {
                lblGhiChuChiPhi.Text = "";
                Int32 soLuong = (Int32)numSoLuong.Value;
                Decimal chiPhi = Decimal.Parse(txtChiPhiCaBiet.EditValue.ToString() == "" ? "0" : txtChiPhiCaBiet.Text);

                Decimal tongChiPhi = soLuong * chiPhi;
                _pause2 = true;
                txtTongChiPhi.EditValue = tongChiPhi;
                _pause2 = false;
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogThongTinTSCDCaBiet_GhiTangHangLoat_Load(object sender, EventArgs e)
        {
            if (user.TenDangNhap.ToLower().Equals("admin") || user.GroupID == 38)
            {
                cbNguonMua.Enabled = true;
                numSoNamSD.Enabled = true;
            }
            //
            this.LoadData();
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewChiTietTaiSanCaBiet);
            GridUtil.SetSTTForGridView(this.grdViewDungCuPhuTung);
            //cài đặt filter để ko hiển thị các dòng dụng cụ phụ tùng từ nghiệp vụ sữa chữa lớn
            this.colLaDCPTSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaDCPTSuaChuaLon.FieldName + " = false");
            //cài đặt filter để ko hiển thị các dòng bổ sung chi tiết tài sản sữa chữa lớn
            this.colLaChiTietSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaChiTietSuaChuaLon.FieldName + " = false");
            //mặc định năm sản xuất
            numNamSX.Value = (Decimal)app_users_Factory.New().SystemDate.Year;
            //Delete helper
            GridUtil.DeleteHelper.Setup_AutoType(grdViewChiTietTaiSanCaBiet);
            //Delete helper
            GridUtil.DeleteHelper.Setup_AutoType(grdViewDungCuPhuTung);          
        }
      
        private void cbNhomTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD nhom = cbNhomTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (nhom != null)
            {
                txtTenNhomTaiSan.Text = nhom.Ten;
                //Int32 maNhom = (Int32)cbNhomTaiSan.EditValue;
                //_loaiList = _danhMucTSCD_Factory.Get_DanhSachLoaiTaiSan_CoTSCD_ByMaNhomTaiSan(nhom.ID);
                //tblDanhMucTSCDBindingSource_Loai.DataSource = _loaiList;
            }
            //LayDanhSachLoaiTaiSan();
        }
       
        private void cbLoaiTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD loai = cbLoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (loai != null)
            {
                txtTenLoaiTaiSan.Text = loai.Ten;
                cbLoaiTaiSan.EditValue = loai.LoaiTaiSanThuocNhomTaiSan;
                //_TSCDList = _danhMucTSCD_Factory.Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(loai.ID);
                //tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDList;
            }
            //LayDanhSachTSCD();
            //Int32 maLoai = (Int32)cbLoaiTaiSan.EditValue;
            //lấy danh sách tài sản
        }
        private void cbTaiSanCoDinh_EditValueChanged(object sender, EventArgs e)
        {
            //Thread thr = new Thread(() =>
            //{
            //    if (this.InvokeRequired)
            //    {
            //        PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.XuLy1);
            //        this.Invoke(dele);
            //    }
            //    else
            //    {
            //        this.XuLy1();
            //    }
            //});
            //thr.Start();
            tblDanhMucTSCD tscd = cbTaiSanCoDinh.GetSelectedDataRow() as tblDanhMucTSCD;

            if (tscd != null)
            {
                //gán mã tài sản
                _taiSanCoDinhCaBiet.MaTSCD = tscd.ID;
                _taiSanCoDinhCaBiet.MaTaiKhoanPhanBo = tscd.TaiKhoanPhanBo;
                txtTenTSCD.Text = tscd.Ten;
                txtModelTSCD.Text = tscd.ModelTSCD;
                cbLoaiTaiSan.EditValue = tscd.ParentID;
                treeListLookUpEdit_LoaiTaiSan.EditValue = tscd.ParentID;
                cbDonViTinh.EditValue = tscd.MaDonViTinhTSCD;
                cbNuocSanXuat.EditValue = tscd.MaNuocSxTSCD;
                //lấy số hiệu mới
                txtSoHieuCaBiet.EditValue = TaiSanCoDinhCaBiet_Factory.New().Get_NextSoHieuTSCDCaBiet_ByMaTSCD(tscd.ID);
                if (tscd.MaQuanLy.ToUpper().Contains("CD"))
                    _taiSanCoDinhCaBiet.LaCCDC = true;
                numSoNamSD.Value = (decimal)(tscd.TGSuDungToiDaTSCD ?? 60);
                _taiSanCoDinhCaBiet.ThoiGianSuDung = tscd.TGSuDungToiTHieuTSCD;
                if (tscd.TaiKhoanTuongUng != null)
                {
                    cbTaiKhoan.EditValue = tscd.TaiKhoanTuongUng;
                    _taiSanCoDinhCaBiet.MaTaiKhoan = tscd.TaiKhoanTuongUng;
                }
            }
            else
            {
                txtTenTSCD.Text = "";
                txtModelTSCD.Text = "";
                txtSoHieuCaBiet.Text = "";
            }
        }

        private void btnDuaDuLieuVeChungTuGhiTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (KiemTraHopLe())
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;//thoát mà không làm gì hết
            this.Close();
        }

        private void numSoLuong_EditValueChanged(object sender, EventArgs e)
        {
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
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

        Boolean _pause1 = false;
        Boolean _pause2 = false;
        Boolean _pause3 = false;
      
        private void txtTongNguyenGia_EditValueChanged(object sender, EventArgs e)
        {        
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
        }

        private void txtTongChiPhi_EditValueChanged(object sender, EventArgs e)
        {           
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
        }

        private void grdViewChiTietTaiSanCaBiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
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
                    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                }
            }
        }

        private void grdViewDungCuPhuTung_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
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
        private void cbLoaiTang_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoaiGhiTangTSCDCaBietEnum loaiTang = (LoaiGhiTangTSCDCaBietEnum)(Int32)cbLoaiTang.EditValue;
                if (loaiTang == LoaiGhiTangTSCDCaBietEnum.TangMoi)
                {
                    txt_PhanTramThue.EditValue = 0;
                    txt_TienThue.EditValue = 0;
                    //không cho phép nhập lũy kế
                    //txtLuyKeKH.Properties.ReadOnly = true;
                    //txtLuyKeHM.Properties.ReadOnly = true;
                    txt_PhanTramThue.Enabled = false;
                    txt_TienThue.Enabled = false;
                }
                else if (loaiTang == LoaiGhiTangTSCDCaBietEnum.KhongTangMoi)
                {
                    //cho phép nhập lũy kế
                    txt_PhanTramThue.Enabled = true;
                    txt_TienThue.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                //DialogUtil.ShowError("Lỗi hệ thống!\n" + ex.Message + "\n" + ex.InnerException);
            }
        }
        private void cbLoaiTaiSan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách loại tài sản
            {
               // LayDanhSachLoaiTaiSan();
            }
        }

        private void cbTaiSanCoDinh_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                LayDanhSachTSCD();
            }
            else if (e.Button.Index == 2)//mở form cây danh mục
            {
                //frmCayTaiSan.Singleton.ShowDialog();
                //tblDanhMucTSCD loai = treeListLookUpEdit_LoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
                //if (loai != null)
                //{
                //    Form frm = new frmDanhMucTaiSan(loai.ID);
                //    frm.ShowDialog();
                //    LayDanhSachTSCD();
                //}
                //else
                //    DialogUtil.ShowInfo("Cần chọn loại tài sản");
            }
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

        private void cbDonViTinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListDonViTinh frm = new frmListDonViTinh();
                frm.ShowDialog();
                _donViTinhList = DonViTinh_Factory.New().GetAll();
                tblDonViTinhBindingSource.DataSource = _donViTinhList;
            }
        }

        private void cbNuocSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListQuocGia frm = new frmListQuocGia();
                frm.ShowDialog();
                _quocGiaList = QuocGia_Factory.New().GetAll();
            }
        }

        private void gridLookUpEdit_ThueSuatVAT_EditValueChanged(object sender, EventArgs e)
        {
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
        }

        private void cbTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            //Thread thr = new Thread(() =>
            //{
            //    if (this.InvokeRequired)
            //    {
            //        PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.TinhSoNamSuDung);
            //        this.Invoke(dele);
            //    }
            //    else
            //    {
            //        this.TinhSoNamSuDung();
            //    }
            //});
            //thr.Start();
        }
        private void TinhSoNamSuDung()
        {
            tblTaiKhoan taiKhoan = cbTaiKhoan.GetSelectedDataRow() as tblTaiKhoan;
            if (taiKhoan != null)
            {
                DateTime ngay = app_users_Factory.New().SystemDate;
                tblTiLeKhauHaoTheoTaiKhoan tileKHTheoTaiKhoan = TiLeKhauHaoTheoTaiKhoan_Factory.New().GetLast_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNgayChot(taiKhoan.SoHieuTK, ngay);
                if (tileKHTheoTaiKhoan != null)
                    _taiSanCoDinhCaBiet.ThoiGianSuDung = (Int32)(100 / tileKHTheoTaiKhoan.PhanTram);
                else
                    _taiSanCoDinhCaBiet.ThoiGianSuDung = 0;
            }
        }
        #endregion

        private void txt_PhanTramThue_EditValueChanged(object sender, EventArgs e)
        {
            //_tongNguyenGia = Decimal.Parse(txtTongNguyenGia.EditValue.ToString() == "" ? "0" : txtTongNguyenGia.EditValue.ToString());
            ////_donGia = Decimal.Parse(txtTongDonGia.EditValue.ToString() == "" ? "0" : txtTongDonGia.EditValue.ToString());
            // _phanTramThue = Decimal.Parse(txt_PhanTramThue.EditValue.ToString() == "" ? "0" : txt_PhanTramThue.EditValue.ToString());
            //if(_phanTramThue!=0)
            //    _tienThue = _tongNguyenGia * (_phanTramThue / 100);
            // _taiSanCoDinhCaBiet.TienThue = _tienThue;
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
        }

        private void txt_TienThue_EditValueChanged(object sender, EventArgs e)
        {
            TinhNguyenGiaMuaBanDauCho1TaiSanCoDinhCaBiet();
        }

        private void treeListLookUpEdit_LoaiTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD loai = treeListLookUpEdit_LoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (loai != null)
            {
                txtTenLoaiTaiSan.Text = loai.Ten;
                cbNhomTaiSan.EditValue = loai.LoaiTaiSanThuocNhomTaiSan;
                //LayDanhSachTSCD();
            }
        }
    }
}
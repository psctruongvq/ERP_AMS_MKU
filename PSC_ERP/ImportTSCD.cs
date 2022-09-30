using DevExpress.Utils;
using ERP_Library.Security;
using ExcelDataReader;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    internal static class StringEx
    {
        internal static String FullTrim(this String source)
        {
            return source.Trim().Replace("  ", " ");
        }

        internal static String RemoveEmpty(this String source)
        {
            return source.Trim().Replace(" ", "");
        }
    }
    class ImportTSCD
    {
        private static string PhatSinhMaQuanLyMoi(tblDanhMucTSCD parentObject, DanhMucTSCD_Factory _danhMucTSCD_Factory, Boolean phatSinhMaQuanLyLoaiTaiSan = false)
        {
            Int32 sizeOfIncreasePart = 0;
            //xác định size
            if (phatSinhMaQuanLyLoaiTaiSan)
                sizeOfIncreasePart = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;
            else
                sizeOfIncreasePart = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
            //
            String soHieuMoi = "";
            Int32 maxNum = 0;
            String soHieuCapTren = parentObject.MaQuanLy;
            //lựa chọn phương thức
            if (phatSinhMaQuanLyLoaiTaiSan)//phát sinh mã quản lý loại tài sản mới
            {
                String maxSoHieu = _danhMucTSCD_Factory.Get_MaxSoHieuLoaiTS_ByMaCapTrenTrucTiep(parentObject.ID);
                if (!String.IsNullOrWhiteSpace(maxSoHieu))
                {
                    maxNum = Int32.Parse(maxSoHieu.Substring(maxSoHieu.Length - sizeOfIncreasePart));
                }

                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = _danhMucTSCD_Factory.CreateFirst_MaQuanLyLoaiTaiSan(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = _danhMucTSCD_Factory.Create_MaQuanLyLoaiTaiSan(soHieuCapTren, maxNum + 1);
            }
            else//phát sinh mã quản lý tài sản cố định mới
            {
                String maxSoHieu = _danhMucTSCD_Factory.Get_MaxSoHieuTSCD_ByMaLoaiCapTrenTrucTiep(parentObject.ID);
                if (!String.IsNullOrWhiteSpace(maxSoHieu))
                {
                    maxNum = Int32.Parse(maxSoHieu.Substring(maxSoHieu.Length - sizeOfIncreasePart));
                }

                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = _danhMucTSCD_Factory.CreateFirst_MaQuanLyTSCD(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = _danhMucTSCD_Factory.Create_MaQuanLyTSCD(soHieuCapTren, maxNum + 1);
            }

            return soHieuMoi;
        }
        public static void ImportTSCDCaBietNew(bool TSorCCDC = true)
        {
            DataSet ds;
            DanhMucTSCD_Factory _danhMucTSCD_Factory = null;
            TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_Factory = null;
            CongTy_Factory _congTy_factory = null;
            BoPhanERPNew_Factory _viTri_facory = null;
            BoPhan_Factory _boPhan_Factory = null;
            TaiSanCoDinhCaBiet_PhongBan_Factory _taiSanCDCB_PhongBan_Factory = null;
            //Nguon_Factory _nguon_Factory = null;
            ChungTu_Factory _chungTu_Factory = null;
            DonViTinh_Factory _donViTinh_Factory = null;
            TaiKhoan_Factory _taiKhoan_Factory = null;
            //ChungTuGhiTangTaiSan_DerivedFactory _nghiepVu_GhiTang_Factory = null;
            ChiTietNguyenGiaTSCD_Factory _chiTietNguyenGiaTSCDCB_factory = null;

            IQueryable<tblDanhMucTSCD> _danhMucTSCDList = null;
            IQueryable<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;

            OpenFileDialog oFD = new OpenFileDialog() { Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx" };

            var mainLog = new StringBuilder();
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm wait = new WaitDialogForm("Đang import dữ liệu từ file excel...", "Vui lòng chờ"))
                {
                    string importPackage = DateTime.Now.ToString();
                    //khởi tạo factory
                    _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
                    _taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
                    _viTri_facory = BoPhanERPNew_Factory.New();
                    _congTy_factory = CongTy_Factory.New();
                    _boPhan_Factory = BoPhan_Factory.New();
                    _taiSanCDCB_PhongBan_Factory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
                    _chungTu_Factory = ChungTu_Factory.New();

                    _donViTinh_Factory = DonViTinh_Factory.New();
                    _taiKhoan_Factory = TaiKhoan_Factory.New();

                    _chiTietNguyenGiaTSCDCB_factory = ChiTietNguyenGiaTSCD_Factory.New();

                    //lấy hết cây danh mục
                    _danhMucTSCDList = _danhMucTSCD_Factory.GetAll();
                    //lấy hết tài sản cố định cá biệt
                    _taiSanCoDinhCaBietList = _taiSanCoDinhCaBiet_Factory.GetAll();

                    tblDanhMucTSCD _loaiTanSan;
                    tblDanhMucTSCD _taiSanCoDinh = null;

                    //những bảng liên quan
                    tblCongTy _congTy = null;
                    tblBoPhanERPNew _viTri = null;
                    tblnsBoPhan _boPhan = null;
                    tblTaiSanCoDinhCaBiet_PhongBan _taiSanCDCB_PhongBan = null;
                    tblChiTietNguyenGiaTSCD chiTietNguyenGia = null;
                    tblDonViTinh _donViTinh = null;
                    tblTaiKhoan _taiKhoan = null;
                    tblTaiKhoan _taiKhoanPhanBo = null;
                    tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
                    DateTime? _ngayMua = null;

                    using (var stream = File.Open(oFD.FileName, FileMode.Open, FileAccess.ReadWrite))
                    {
                        // Auto-detect format, supports:
                        //  - Binary Excel files (2.0-2003 format; *.xls)
                        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                UseColumnDataType = false,
                                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });

                            if (reader.Name == "TSCD")
                            {
                                #region old
                                foreach (DataRow dr in ds.Tables["TSCD"].Rows)
                                {
                                    var errorLog = new StringBuilder();
                                    bool _luuPSTSCD = false;
                                    bool _daLuuXong = true;
                                    #region khởi tạo các cột
                                    //số thứ tự 0
                                    String _soTT = dr[0].ToString().FullTrim(); //0
                                                                                //ngày mua
                                    String ngayMua = dr[1].ToString().FullTrim(); //1
                                                                                  //tên tài sản 2 
                                    String tenTaiSan = dr[2].ToString().FullTrim(); //2
                                                                                    //mã loại tài sản cố định 3
                                    String maLoaiTaiSanCoDinh = dr[3].ToString().FullTrim(); //3
                                                                                             //số hiệu 4 -- mã quản lý cá biệt
                                    String soHieuTSCDCB = dr[4].ToString().FullTrim();//4                        
                                                                                      //đơn vị tính 5
                                    String donViTinh = dr[5].ToString().FullTrim();//5
                                                                                   // đơn giá chưa Vat 6
                                    String donGia = dr[6].ToString().FullTrim(); //6
                                                                                 // số lượng 7
                                    String soLuong = dr[7].ToString().FullTrim();//7
                                                                                 //thuế suất 8
                                    String thueSuat = dr[8].ToString().FullTrim(); //8
                                                                                   //tiền thuế 9
                                    String tienThue = dr[9].ToString().FullTrim(); //9
                                                                                   //thành tiền có Vat 10
                                    String thanhTien = dr[10].ToString().FullTrim();//10
                                                                                    //model 11
                                    String model = dr[11].ToString().FullTrim(); //11
                                                                                 //serial 12
                                    String serial = dr[12].ToString().FullTrim(); //12
                                                                                  //chi tiết kỹ thuật 13
                                    String chiTietKyThuat = dr[13].ToString().FullTrim(); //13
                                                                                          //ngày sử dụng 14
                                    String ngaySuDung = dr[14].ToString().FullTrim();//14
                                                                                     //thời gian sử dụng  15
                                    String thoiGianSuDung = dr[15].ToString().FullTrim();//15                                      
                                                                                         //nguyên giá 16
                                    String nguyenGia = dr[16].ToString().FullTrim(); //16
                                                                                     //lũy kế hao mòn 17
                                    String luyKeHaoMon = dr[17].ToString().FullTrim(); //17                          
                                                                                       //giá trị còn lại 18
                                    String giaTriConLai = dr[18].ToString().FullTrim(); //18
                                                                                        //số hợp đồng 19
                                    String soHopDong = dr[19].ToString().FullTrim(); //19
                                                                                     //số hóa đơn 20
                                    String soHoaDon = dr[20].ToString().FullTrim(); //20
                                                                                    //mã nhà cung cấp 21
                                    String maNhaCungCap = dr[21].ToString().FullTrim(); //21                        
                                                                                        //tên nhà cung cấp 22
                                    String tenNhaCungCap = dr[22].ToString().FullTrim(); //22                     
                                                                                         //tên công ty 23
                                    String tenCongTy = dr[23].ToString().FullTrim(); //23                            
                                                                                     //mã công ty 24
                                    String maCongTy = dr[24].ToString().FullTrim(); //24
                                                                                    //tên bộ phận 25
                                    String tenBoPhan = dr[25].ToString().FullTrim(); //25
                                                                                     //mã bộ phận 26
                                    String maBoPhan = dr[26].ToString().FullTrim(); //26
                                                                                    //tên vị trí 27
                                    String tenViTri = dr[27].ToString().FullTrim(); //27
                                                                                    //tên vị trí 28
                                    String maViTri = dr[28].ToString().FullTrim(); //28
                                                                                   //tên vị trí 29
                                    String CPU = dr[29].ToString().FullTrim(); //29
                                                                               //tên vị trí 30
                                    String Ram = dr[30].ToString().FullTrim(); //30
                                                                               //tên vị trí 31
                                    String SoHieuTKKhauHaoLuyKe = dr[31].ToString().FullTrim(); //31
                                    #endregion

                                    if (String.IsNullOrEmpty(maLoaiTaiSanCoDinh))
                                    {
                                        errorLog.AppendLine(" Không có mã loại tài sản không được trống - cần gán tài sản vào file.");
                                    }
                                    else if (!_danhMucTSCD_Factory.Context.tblDanhMucTSCDs.Any(o=>o.MaQuanLy == maLoaiTaiSanCoDinh && o.LaTaiSanCoDinh == true ))
                                    {
                                        errorLog.AppendLine(" Không có mã loại tài sản - cần gán tài sản vào file.");
                                        continue;
                                    }
                                    else
                                    {
                                        _loaiTanSan = _danhMucTSCD_Factory.Get_DanhMuc_ByMaQuanLy_And_MaCongTy(maLoaiTaiSanCoDinh, CurrentUser.Info.MaCongTy);
                                        _congTy = _congTy_factory.Get_ByID(CurrentUser.Info.MaCongTy);
                                        if (_loaiTanSan == null)
                                        {
                                            errorLog.AppendLine("Chưa có loại tài sản này vui lòng tạo mã cho tài sản này!");
                                        }
                                        else
                                        {
                                            //lưu bộ phận trước khi phát sinh tài sản cố định cá biệt
                                            #region kiểm tra xem có tồn tại bộ phận này chưa nếu chưa thì khởi tạo bộ phận
                                            if (String.IsNullOrEmpty(maBoPhan))
                                            {
                                                errorLog.AppendLine(" Chưa có thông tin bộ phận phòng ban của tài sản vui lòng bổ sung thông tin bộ phận phòng ban.");
                                            }
                                            else
                                            {
                                                if (!String.IsNullOrEmpty(maViTri))
                                                {
                                                    _viTri = _viTri_facory.Get_BoPhanTheoMaBoPhanQL(maViTri);
                                                    if (_viTri == null)
                                                    {
                                                        errorLog.AppendLine(" Chưa có thông tin vị trí của tài sản vui lòng bổ sung thông tin vị trí.");
                                                    }
                                                }
                                                else
                                                {
                                                    errorLog.AppendLine(" Vị trí không được bỏ trống! Vui lòng điền mã vị trí!");
                                                }
                                                _boPhan = _boPhan_Factory.LayBoPhan_TheoMaQuanLy(maBoPhan);
                                                if (_boPhan == null)
                                                {
                                                    errorLog.AppendLine(" Chưa có thông tin phòng ban của tài sản vui lòng bổ sung thông tin phòng ban này.");
                                                }
                                                if (_viTri == null)
                                                {
                                                    errorLog.AppendLine(" Chưa có thông tin vị trí phòng ban của tài sản vui lòng bổ sung thông tin vị trí phòng ban này.");
                                                }
                                                if (_loaiTanSan == null)
                                                {
                                                    errorLog.AppendLine(" Chưa có thông CCDC này trong hệ thống!");
                                                }
                                                #endregion
                                                //phát sinh tài sản cố định cá biệt 
                                                #region phát sinh tài sản cố định cá biệt
                                                //----------                                           
                                                decimal donGiaLamTron, nguyenGiaConLai, giaTriHaoMonPhanBo, tienThueLamTron = 0;
                                                int soLuongTS = 0;
                                                soLuongTS = int.Parse(soLuong);
                                                if (_loaiTanSan.TaiKhoanTuongUng != null)
                                                    _taiKhoan = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_loaiTanSan.TaiKhoanTuongUng.Value);
                                                //if (_loaiTanSan.TaiKhoanPhanBo != null)
                                                //    _taiKhoanPhanBo = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_loaiTanSan.TaiKhoanPhanBo.Value);
                                                if (SoHieuTKKhauHaoLuyKe != null)
                                                    _taiKhoanPhanBo = _taiKhoan_Factory.Get_TaiKhoan_BySoHieu(SoHieuTKKhauHaoLuyKe);

                                                if (soLuongTS == 1)
                                                {
                                                    donGiaLamTron = decimal.Parse(nguyenGia);
                                                }
                                                else
                                                {
                                                    donGiaLamTron = Math.Round(decimal.Parse(nguyenGia) / soLuongTS);
                                                }
                                                if (!String.IsNullOrEmpty(tienThue))
                                                {
                                                    tienThueLamTron = Math.Round(decimal.Parse(tienThue) / soLuongTS);
                                                }
                                                if (String.IsNullOrEmpty(giaTriConLai) || soLuongTS <= 0)
                                                    nguyenGiaConLai = 0;
                                                else
                                                    nguyenGiaConLai = Math.Round(decimal.Parse(giaTriConLai) / soLuongTS);
                                                if (String.IsNullOrEmpty(luyKeHaoMon))
                                                    giaTriHaoMonPhanBo = donGiaLamTron - nguyenGiaConLai;
                                                else
                                                    giaTriHaoMonPhanBo = Math.Round(decimal.Parse(luyKeHaoMon) / soLuongTS);
                                                for (int i = 0; i < soLuongTS; i++)
                                                {
                                                    _luuPSTSCD = false;
                                                    _taiSanCoDinhCaBiet = _taiSanCoDinhCaBiet_Factory.CreateManagedObject();
                                                    if (i == (soLuongTS - 1))
                                                    {
                                                        donGiaLamTron = decimal.Parse(nguyenGia) - donGiaLamTron * (soLuongTS - 1);
                                                        if (nguyenGiaConLai != 0)
                                                            nguyenGiaConLai = decimal.Parse(giaTriConLai) - nguyenGiaConLai * (soLuongTS - 1);
                                                        if (!String.IsNullOrEmpty(luyKeHaoMon))
                                                            giaTriHaoMonPhanBo = decimal.Parse(luyKeHaoMon) - giaTriHaoMonPhanBo * (soLuongTS - 1);
                                                        else
                                                            giaTriHaoMonPhanBo = donGiaLamTron - nguyenGiaConLai;
                                                        if (!String.IsNullOrEmpty(tienThue))
                                                        {
                                                            tienThueLamTron = decimal.Parse(tienThue) - tienThueLamTron * (soLuongTS - 1);
                                                        }
                                                    }
                                                    _taiSanCoDinhCaBiet.DonGia = _taiSanCoDinhCaBiet.NguyenGiaTinhKhauHao = _taiSanCoDinhCaBiet.NguyenGiaMua = (decimal)donGiaLamTron;
                                                    _taiSanCoDinhCaBiet.LuyKeKhauHao = (decimal)giaTriHaoMonPhanBo;
                                                    _taiSanCoDinhCaBiet.NguyenGiaConLai = nguyenGiaConLai;
                                                    if (!String.IsNullOrEmpty(thueSuat))
                                                        _taiSanCoDinhCaBiet.PhanTramThue = decimal.Parse(thueSuat);
                                                    _taiSanCoDinhCaBiet.TienThue = tienThueLamTron;
                                                    _taiSanCoDinhCaBiet.GhiChu = chiTietKyThuat;
                                                    _taiSanCoDinhCaBiet.LaTaiSanCu = true;
                                                    _taiSanCoDinhCaBiet.SoHopDong = soHopDong;
                                                    _taiSanCoDinhCaBiet.SoHoaDon = soHoaDon;
                                                    _taiSanCoDinhCaBiet.Model = model;
                                                    _taiSanCoDinhCaBiet.Serial = serial;
                                                    _taiSanCoDinhCaBiet.STT = _soTT;
                                                    _taiSanCoDinhCaBiet.SuDung = true;
                                                    _taiSanCoDinhCaBiet.MaCongTy = _congTy.MaCongTy;
                                                    _taiSanCoDinhCaBiet.TenCaBiet = tenTaiSan;
                                                    _taiSanCoDinhCaBiet.CPU = CPU;
                                                    _taiSanCoDinhCaBiet.RAM = Ram;
                                                    if( _danhMucTSCD_Factory.Context.tblDonViTinhs.Any(o => o.MaQuanLy == maNhaCungCap)

                                                        )
                                                         _taiSanCoDinhCaBiet.MaDonViTinh = _danhMucTSCD_Factory.Context.tblDonViTinhs.Where(o => o.TenDonViTinh == donViTinh).Select(o => o.MaDonViTinh).First();
                                                    if (_danhMucTSCD_Factory.Context.tblDoiTacs.Any(o => o.MaQLDoiTac == maNhaCungCap))
                                                        _taiSanCoDinhCaBiet.MaNhaCungCap = _danhMucTSCD_Factory.Context.tblDoiTacs.Where(o => o.MaQLDoiTac == maNhaCungCap).Select(o => o.MaDoiTac).First();
                                                    //if (!TSorCCDC)
                                                    if (_loaiTanSan.MaQuanLy.ToUpper().Contains("CD"))
                                                        _taiSanCoDinhCaBiet.LaCCDC = true;
                                                    _taiSanCoDinhCaBiet.ThoiGianSuDung = Int32.Parse(thoiGianSuDung);
                                                    if (_taiKhoan != null)
                                                    {
                                                        _taiSanCoDinhCaBiet.TaiKhoanDoiUng = _taiKhoan.SoHieuTK;
                                                        _taiSanCoDinhCaBiet.MaTaiKhoan = _taiKhoan.MaTaiKhoan;
                                                    }
                                                    if (_taiKhoanPhanBo != null)                                                    
                                                        _taiSanCoDinhCaBiet.MaTaiKhoanPhanBo = _taiKhoanPhanBo.MaTaiKhoan;                                                    
                                                    else
                                                        errorLog.AppendLine(" + không có mã tài khoản khấu hao lũy kế không đúng hoặc không tồn tại .");
                                                    //gán khóa ngoại
                                                    _taiSanCoDinhCaBiet.MaTSCD = _loaiTanSan.ID;
                                                    //gán nguồn -- đang gán mặc định là nguồn ngân sách có mã là 1, 2: nguồn viện trợ, biếu tặng, 3 là nguồn của trường BUH
                                                    //_taiSanCoDinhCaBiet.MaNguon = 1;
                                                    //lưu lại số hiệu cũ
                                                    _taiSanCoDinhCaBiet.SoHieuCu = soHieuTSCDCB;
                                                    _taiSanCoDinhCaBiet.STT = _soTT;
                                                    _taiSanCoDinhCaBiet.UserIDImport = CurrentUser.Info.UserID;
                                                    _taiSanCoDinhCaBiet.ImportPackage = importPackage;
                                                    //phát sinh số hiệu quan trọng cần chỉnh sửa dựa theo yêu cầu bên khách hàng
                                                    //if (soHieuMoiTSCDCB == "")
                                                    String soHieuMoiTSCDCB = "";
                                                    soHieuMoiTSCDCB = _taiSanCoDinhCaBiet_Factory.Get_NextSoHieuTSCDCaBiet_ByMaTSCD(_loaiTanSan.ID);//_taiSanCoDinh.MaQuanLy + "0001";
                                                    while (_taiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietTrungSoHieu(soHieuMoiTSCDCB, _congTy.MaCongTy))
                                                    {
                                                        soHieuMoiTSCDCB = PhatSinhTaiSanCoDinhCaBiet(soHieuMoiTSCDCB);
                                                    }
                                                    _taiSanCoDinhCaBiet.SoHieu = soHieuMoiTSCDCB;
                                                    //ngày mua
                                                    if (!string.IsNullOrWhiteSpace(ngayMua))
                                                    {
                                                        _ngayMua = null;
                                                        try
                                                        {
                                                            _ngayMua = Convert.ToDateTime(ngayMua);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            errorLog.AppendLine(" + Ngày nhận không đúng định dạng dd/MM/yyyy.");
                                                        }

                                                        if (_ngayMua != null)
                                                        {
                                                            if (_ngayMua != DateTime.MinValue)
                                                            {
                                                                _taiSanCoDinhCaBiet.NgayNhan = _ngayMua;
                                                                _taiSanCoDinhCaBiet.NgayChungTu = _ngayMua;
                                                            }
                                                            else
                                                                errorLog.AppendLine(string.Format(" + Ngày mua không hợp lệ: {0:dd/MM/yyyy}", _ngayMua.Value));
                                                        }
                                                    }
                                                    //ngày sử dụng
                                                    if (!string.IsNullOrWhiteSpace(ngaySuDung))
                                                    {
                                                        DateTime? _ngaySuDung = null;
                                                        try
                                                        {
                                                           _ngaySuDung = Convert.ToDateTime(ngaySuDung);
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            errorLog.AppendLine(" + Ngày nhận không đúng định dạng dd/MM/yyyy.");
                                                        }

                                                        if (_ngaySuDung != null)
                                                        {
                                                            if (_ngaySuDung != DateTime.MinValue)
                                                            {
                                                                  _taiSanCoDinhCaBiet.NgaySuDung = _ngaySuDung;
                                                            }
                                                            else
                                                                errorLog.AppendLine(string.Format(" + Ngày sử dụng không hợp lệ: {0:dd/MM/yyyy}", _ngaySuDung.Value));
                                                        }
                                                    }
                                                    _taiSanCoDinhCaBiet_Factory.AddObject(_taiSanCoDinhCaBiet);
                                                    _taiSanCoDinhCaBiet_Factory.SaveChanges();
                                                    _luuPSTSCD = true;

                                                    #region Phát sinh chi tiết nguyên giá
                                                    if (_luuPSTSCD)
                                                    {
                                                        chiTietNguyenGia = _chiTietNguyenGiaTSCDCB_factory.CreateManagedObject();
                                                        chiTietNguyenGia.MaTSCDCaBiet = _taiSanCoDinhCaBiet.MaTSCDCaBiet;
                                                        chiTietNguyenGia.SoTien = _taiSanCoDinhCaBiet.NguyenGiaMua;
                                                        chiTietNguyenGia.LuyKeKhauHao = _taiSanCoDinhCaBiet.LuyKeKhauHao;
                                                        chiTietNguyenGia.LuyKeHaoMon = _taiSanCoDinhCaBiet.LuyKeHaoMon;
                                                        chiTietNguyenGia.NgayThucHien = _taiSanCoDinhCaBiet.NgaySuDung;
                                                        chiTietNguyenGia.LoaiPhanBietNV = 1;
                                                        _chiTietNguyenGiaTSCDCB_factory.SaveChanges();
                                                    }
                                                    #endregion

                                                    #region phân bổ tài sản vào bộ phận lần đầu
                                                    if (_luuPSTSCD)
                                                    {
                                                        _taiSanCDCB_PhongBan = _taiSanCDCB_PhongBan_Factory.CreateManagedObject();
                                                        if (_viTri != null)
                                                            _taiSanCDCB_PhongBan.MaViTri = _viTri.MaBoPhan;
                                                        if (_boPhan != null)
                                                            _taiSanCDCB_PhongBan.MaPhongBan = _boPhan.MaBoPhan;
                                                        _taiSanCDCB_PhongBan.MaTSCDCaBiet = _taiSanCoDinhCaBiet.MaTSCDCaBiet;
                                                        _taiSanCDCB_PhongBan.NgayPhanBo = _taiSanCoDinhCaBiet.NgaySuDung;
                                                        _taiSanCDCB_PhongBan_Factory.SaveChangesWithoutTrackingLog();
                                                    }
                                                    #endregion
                                                    #endregion
                                                } //end else kiểm tra mã loại tài sản
                                            }
                                        }
                                    }

                                    //kiểm tra xem tài sản nào không import vào phần mềm
                                    if (errorLog.Length > 0)
                                    {
                                        mainLog.AppendLine("- STT: " + _soTT);
                                        mainLog.AppendLine(string.Format("- Tài sản {0} thông tin chi tiết {1} không import được vào phần mềm", tenTaiSan, chiTietKyThuat));
                                        mainLog.AppendLine(errorLog.ToString());
                                    }
                                }
                                #endregion old
                            }
                        } //end using dialog waiting
                    }  //end if open file
                       //ghi lại thông tin lỗi khi import tài sản
                    if (mainLog.Length > 0)
                    {
                        string tenFile = DateTime.Now.ToLongDateString() + "ImportTSCDCB_Log.txt";
                        StreamWriter writer = new StreamWriter(tenFile);
                        writer.WriteLine(mainLog.ToString());
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                        //mở file log
                        System.Diagnostics.Process.Start(tenFile);
                    }
                    DialogUtil.ShowInfo("Kết Thúc Quá Trình Import!");
                }
            }
        }

        public static void ImportTSCDCaBiet(bool TSorCCDC = true)
        {
            DanhMucTSCD_Factory _danhMucTSCD_Factory = null;
            TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_Factory = null;
            CongTy_Factory _congTy_factory = null;
            BoPhanERPNew_Factory _viTri_facory = null;
            BoPhan_Factory _boPhan_Factory = null;
            TaiSanCoDinhCaBiet_PhongBan_Factory _taiSanCDCB_PhongBan_Factory = null;
            //Nguon_Factory _nguon_Factory = null;
            ChungTu_Factory _chungTu_Factory = null;
            DonViTinh_Factory _donViTinh_Factory = null;
            TaiKhoan_Factory _taiKhoan_Factory = null;
            //ChungTuGhiTangTaiSan_DerivedFactory _nghiepVu_GhiTang_Factory = null;
            ChiTietNguyenGiaTSCD_Factory _chiTietNguyenGiaTSCDCB_factory = null;

            IQueryable<tblDanhMucTSCD> _danhMucTSCDList = null;
            IQueryable<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;

            OpenFileDialog oFD = new OpenFileDialog() { Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx" };

            var mainLog = new StringBuilder();
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm wait = new WaitDialogForm("Đang import dữ liệu từ file excel...", "Vui lòng chờ"))
                {
                    //khởi tạo factory
                    _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
                    _taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
                    _viTri_facory = BoPhanERPNew_Factory.New();
                    _congTy_factory = CongTy_Factory.New();
                    _boPhan_Factory = BoPhan_Factory.New();
                    _taiSanCDCB_PhongBan_Factory = TaiSanCoDinhCaBiet_PhongBan_Factory.New();
                    _chungTu_Factory = ChungTu_Factory.New();
                    //_nguon_Factory = Nguon_Factory.New();
                    _donViTinh_Factory = DonViTinh_Factory.New();
                    _taiKhoan_Factory = TaiKhoan_Factory.New();
                    //_nghiepVu_GhiTang_Factory = ChungTuGhiTangTaiSan_DerivedFactory.New();
                    _chiTietNguyenGiaTSCDCB_factory = ChiTietNguyenGiaTSCD_Factory.New();

                    //lấy hết cây danh mục
                    _danhMucTSCDList = _danhMucTSCD_Factory.GetAll();
                    //lấy hết tài sản cố định cá biệt
                    _taiSanCoDinhCaBietList = _taiSanCoDinhCaBiet_Factory.GetAll();

                    tblDanhMucTSCD _loaiTanSan;
                    tblDanhMucTSCD _taiSanCoDinh = null;

                    //những bảng liên quan
                    tblCongTy _congTy = null;
                    tblBoPhanERPNew _viTri = null;
                    tblnsBoPhan _boPhan = null;
                    tblTaiSanCoDinhCaBiet_PhongBan _taiSanCDCB_PhongBan = null;
                    tblChiTietNguyenGiaTSCD chiTietNguyenGia = null;
                    tblDonViTinh _donViTinh = null;
                    tblTaiKhoan _taiKhoan = null;
                    tblTaiKhoan _taiKhoanPhanBo = null;
                    tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
                    DateTime? _ngayMua = null;
                    string tenSheeet = "[TSCD$A1:AE]";
                    //if(TSorCCDC)
                    //    tenSheeet = "[TaiSanCoDinhCaBiet$A1:AB]";
                    //else
                    //    tenSheeet = "[CCDC$A1:AB]";
                    using (DataTable dt = GetDataTable(oFD.FileName, tenSheeet))
                    {
                        const int sttIdx = 0;
                        const int ngayMuaIdx = 1;

                        #region thông tin tài sản cố định
                        const int tenTaiSanIdx = 2;
                        const int maLoaiTaiSanCoDinhIdx = 3;
                        #endregion

                        #region thông tin tài sản cá biệt
                        const int soHieuIdx = 4;
                        const int donViTinhIdx = 5;
                        const int donGiaIdx = 6;//chưa VAT
                        const int soLuongIdx = 7;
                        const int thueSuatIdx = 8;
                        const int tienThueIdx = 9;
                        const int thanhTienIdx = 10;
                        const int modelIdx = 11;
                        const int serialIdx = 12;
                        const int chiTietKyThuatIdx = 13;
                        const int ngaySuDungIdx = 14;
                        const int thoiGianSuDungIdx = 15;
                        const int nguyenGiaIdx = 16;
                        const int luyKeHaoMonIdx = 17;
                        const int giaTriConLaiIdx = 18;
                        const int soHopDongIdx = 19;
                        const int soHoaDonIdx = 20;
                        const int maNhaCungCapIdx = 21;
                        const int tenNhaCungCapIdx = 22;
                        const int tenCongTyIdx = 23;
                        const int maCongTyIdx = 24;
                        const int tenPhongBanIdx = 25;
                        const int maPhongBanIdx = 26;
                        const int tenViTriIdx = 27;
                        const int maViTriIdx = 28;
                        const int CPUIdx = 29;
                        const int RamIdx = 30;
                        #endregion

                        foreach (DataRow dr in dt.Rows)
                        {
                            var errorLog = new StringBuilder();
                            bool _luuPSTSCD = false;
                            bool _daLuuXong = true;
                            #region khởi tạo các cột
                            //số thứ tự 0
                            String _soTT = dr[sttIdx].ToString().FullTrim(); //0
                            //ngày mua
                            String ngayMua = dr[ngayMuaIdx].ToString().FullTrim(); //1
                            //tên tài sản 2 
                            String tenTaiSan = dr[tenTaiSanIdx].ToString().FullTrim(); //2
                            //mã loại tài sản cố định 3
                            String maLoaiTaiSanCoDinh = dr[maLoaiTaiSanCoDinhIdx].ToString().FullTrim(); //3
                            //số hiệu 4 -- mã quản lý cá biệt
                            String soHieuTSCDCB = dr[soHieuIdx].ToString().FullTrim();//4                        
                            //đơn vị tính 5
                            String donViTinh = dr[donViTinhIdx].ToString().FullTrim();//5
                            // đơn giá chưa Vat 6
                            String donGia = dr[donGiaIdx].ToString().FullTrim(); //6
                            // số lượng 7
                            String soLuong = dr[soLuongIdx].ToString().FullTrim();//7
                            //thuế suất 8
                            String thueSuat = dr[thueSuatIdx].ToString().FullTrim(); //8
                            //tiền thuế 9
                            String tienThue = dr[tienThueIdx].ToString().FullTrim(); //9
                            //thành tiền có Vat 10
                            String thanhTien = dr[thanhTienIdx].ToString().FullTrim();//10
                            //model 11
                            String model = dr[modelIdx].ToString().FullTrim(); //11
                            //serial 12
                            String serial = dr[serialIdx].ToString().FullTrim(); //12
                            //chi tiết kỹ thuật 13
                            String chiTietKyThuat = dr[chiTietKyThuatIdx].ToString().FullTrim(); //13
                            //ngày sử dụng 14
                            String ngaySuDung = dr[ngaySuDungIdx].ToString().FullTrim();//14
                            //thời gian sử dụng  15
                            String thoiGianSuDung = dr[thoiGianSuDungIdx].ToString().FullTrim();//15                                      
                            //nguyên giá 16
                            String nguyenGia = dr[nguyenGiaIdx].ToString().FullTrim(); //16
                            //lũy kế hao mòn 17
                            String luyKeHaoMon = dr[luyKeHaoMonIdx].ToString().FullTrim(); //17                          
                            //giá trị còn lại 18
                            String giaTriConLai = dr[giaTriConLaiIdx].ToString().FullTrim(); //18
                            //số hợp đồng 19
                            String soHopDong = dr[soHopDongIdx].ToString().FullTrim(); //19
                            //số hóa đơn 20
                            String soHoaDon = dr[soHoaDonIdx].ToString().FullTrim(); //20
                            //mã nhà cung cấp 21
                            String maNhaCungCap = dr[maNhaCungCapIdx].ToString().FullTrim(); //21                        
                            //tên nhà cung cấp 22
                            String tenNhaCungCap = dr[tenNhaCungCapIdx].ToString().FullTrim(); //22                     
                            //tên công ty 23
                            String tenCongTy = dr[tenCongTyIdx].ToString().FullTrim(); //23                            
                            //mã công ty 24
                            String maCongTy = dr[maCongTyIdx].ToString().FullTrim(); //24
                            //tên bộ phận 25
                            String tenBoPhan = dr[tenPhongBanIdx].ToString().FullTrim(); //25
                            //mã bộ phận 26
                            String maBoPhan = dr[maPhongBanIdx].ToString().FullTrim(); //26
                            //tên vị trí 27
                            String tenViTri = dr[tenViTriIdx].ToString().FullTrim(); //27
                            //tên vị trí 28
                            String maViTri = dr[maViTriIdx].ToString().FullTrim(); //28
                            //tên vị trí 29
                            String CPU = dr[CPUIdx].ToString().FullTrim(); //29
                            //tên vị trí 30
                            String Ram = dr[RamIdx].ToString().FullTrim(); //30
                            #endregion

                            if (String.IsNullOrEmpty(maLoaiTaiSanCoDinh))
                            {
                                errorLog.AppendLine(" Không có mã loại tài sản - cần gán tài sản vào file.");
                            }
                            else
                            {
                                _loaiTanSan = _danhMucTSCD_Factory.Get_DanhMuc_ByMaQuanLy_And_MaCongTy(maLoaiTaiSanCoDinh, CurrentUser.Info.MaCongTy);
                                _congTy = _congTy_factory.Get_ByID(CurrentUser.Info.MaCongTy);//_congTy_factory.GetCongTy_TheoMaQuanLy(maCongTy);
                                if (_loaiTanSan == null)
                                {
                                    errorLog.AppendLine("Chưa có loại tài sản này vui lòng tạo mã cho tài sản này!");
                                }
                                else
                                {
                                    //lưu bộ phận trước khi phát sinh tài sản cố định cá biệt
                                    #region kiểm tra xem có tồn tại bộ phận này chưa nếu chưa thì khởi tạo bộ phận
                                    if (String.IsNullOrEmpty(maBoPhan))
                                    {
                                        errorLog.AppendLine(" Chưa có thông tin bộ phận phòng ban của tài sản vui lòng bổ sung thông tin bộ phận phòng ban.");
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(maViTri))
                                        {
                                            _viTri = _viTri_facory.Get_BoPhanTheoMaBoPhanQL(maViTri);
                                            //tblBoPhanERPNew viTriCha = _viTri_facory.Get_BoPhanTheoMaBoPhanQL(maViTri);
                                            //nếu chưa có bộ phận này thì cần khởi tạo
                                            if (_viTri == null)
                                            {
                                                errorLog.AppendLine(" Chưa có thông tin vị trí của tài sản vui lòng bổ sung thông tin vị trí.");
                                                //_viTri = _viTri_facory.CreateManagedObject();
                                                //if (viTriCha != null)
                                                //    _viTri.MaBoPhanCha = viTriCha.MaBoPhan;
                                                //_viTri.MaBoPhanQL = maViTri;
                                                //_viTri.TenBoPhan = tenViTri;
                                                ////boPhanCha.OidUniq = Guid.NewGuid();
                                                //_viTri_facory.SaveChanges();
                                            }
                                        }
                                        else
                                        {
                                            errorLog.AppendLine(" Vị trí không được bỏ trống! Vui lòng điền mã vị trí!");
                                            //_viTri = _viTri_facory.Get_BoPhanTheoMaBoPhanQL("KHO");
                                        }
                                        _boPhan = _boPhan_Factory.LayBoPhan_TheoMaQuanLy(maBoPhan);
                                        if (_boPhan == null)
                                        {
                                            errorLog.AppendLine(" Chưa có thông tin phòng ban của tài sản vui lòng bổ sung thông tin phòng ban này.");
                                        }
                                        if (_viTri == null)
                                        {
                                            errorLog.AppendLine(" Chưa có thông tin vị trí phòng ban của tài sản vui lòng bổ sung thông tin vị trí phòng ban này.");
                                        }
                                        #endregion
                                        //lưu tài sản cố định
                                        #region lưu tài sản cố định lên cây tài sản và kiểm có tài cố định thuộc loại này chưa nếu có rồi thì tự thêm cá biệt vào còn chưa thì tự phát sinh tài sản cố định
                                        //if(TSorCCDC)
                                        //    _taiSanCoDinh = _danhMucTSCD_Factory.Get_TaiSanCoDinh_ByTenTaiSan_And_MaLoaiTaiSan(tenTaiSan, _loaiTanSan.ID);
                                        //else
                                        //_taiSanCoDinh = _danhMucTSCD_Factory.Get_TaiSanCoDinh_ByMaQuanLy(maLoaiTaiSanCoDinh,_congTy.MaCongTy);
                                        //if (_taiSanCoDinh == null && TSorCCDC) //if import vào cây danh mục tài sản
                                        //{
                                        //    _daLuuXong = false;
                                        //    //lưu tài sản lên cây
                                        //    _taiSanCoDinh = _danhMucTSCD_Factory.CreateManagedObject();
                                        //    _taiSanCoDinh.ParentID = _loaiTanSan.ID;
                                        //    _taiSanCoDinh.TGSuDungToiTHieuTSCD = Int32.Parse(thoiGianSuDung);
                                        //    _taiSanCoDinh.TGSuDungToiDaTSCD = Int32.Parse(thoiGianSuDung);
                                        //    _taiSanCoDinh.Ten = tenTaiSan;
                                        //    _donViTinh = _donViTinh_Factory.get_DonViTinh_ByTen(donViTinh);
                                        //    if (_donViTinh == null)
                                        //    {
                                        //        _donViTinh = _donViTinh_Factory.CreateManagedObject();
                                        //        _donViTinh.MaQuanLy = donViTinh;
                                        //        _donViTinh.TenDonViTinh = donViTinh;
                                        //        _donViTinh_Factory.SaveChanges();
                                        //    }
                                        //    _taiSanCoDinh.MaDonViTinhTSCD = _donViTinh.MaDonViTinh;
                                        //    if (_taiSanCoDinh.TaiKhoanTuongUng != null)
                                        //        _taiKhoan = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_taiSanCoDinh.TaiKhoanTuongUng.Value);
                                        //    else
                                        //        _taiKhoan = _taiKhoan_Factory.Get_TaiKhoan_BySoHieu(taiKhoanKeToan);
                                        //    if (_taiKhoan != null)
                                        //        _taiSanCoDinh.TaiKhoanTuongUng = _taiKhoan.MaTaiKhoan;
                                        //    if (_taiSanCoDinh.TaiKhoanPhanBo != null)
                                        //        _taiKhoanPhanBo = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_taiSanCoDinh.TaiKhoanPhanBo.Value);
                                        //    else
                                        //        _taiKhoanPhanBo = _taiKhoan_Factory.Get_TaiKhoan_BySoHieu(taiKhoanPhanBo);
                                        //    if(_taiKhoanPhanBo !=null)
                                        //        _taiSanCoDinh.TaiKhoanPhanBo = _taiKhoanPhanBo.MaTaiKhoan;
                                        //    _taiSanCoDinh.LaTaiSanCoDinh = true;
                                        //    _taiSanCoDinh.MaQuanLy = PhatSinhMaQuanLyMoi(parentObject: _loaiTanSan, _danhMucTSCD_Factory: _danhMucTSCD_Factory);

                                        //    _danhMucTSCD_Factory.AddObject(_taiSanCoDinh);
                                        //    _danhMucTSCD_Factory.SaveChangesWithoutTrackingLog();

                                        //    _daLuuXong = true;
                                        // }//end lưu tài sản cố định vào danh mục tài sản
                                        if (_loaiTanSan == null)
                                        {
                                            errorLog.AppendLine(" Chưa có thông CCDC này trong hệ thống!");
                                        }
                                        #endregion
                                        //phát sinh tài sản cố định cá biệt 
                                        #region phát sinh tài sản cố định cá biệt
                                        //----------                                           
                                        decimal donGiaLamTron, nguyenGiaConLai, giaTriHaoMonPhanBo, tienThueLamTron = 0;
                                        int soLuongTS = 0;
                                        soLuongTS = int.Parse(soLuong);
                                        if (_loaiTanSan.TaiKhoanTuongUng != null)
                                            _taiKhoan = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_loaiTanSan.TaiKhoanTuongUng.Value);
                                        if (_loaiTanSan.TaiKhoanPhanBo != null)
                                            _taiKhoanPhanBo = _taiKhoan_Factory.Get_TaiKhoan_ByMaTaiKhoan(_loaiTanSan.TaiKhoanPhanBo.Value);
                                        if (soLuongTS == 1)
                                        {
                                            donGiaLamTron = decimal.Parse(nguyenGia);
                                            //if (_congTy.CongThue.Value)
                                            //{
                                            //    donGiaLamTron = decimal.Parse(thanhTien);
                                            //}
                                            //else
                                            //{
                                            //    donGiaLamTron = decimal.Parse(thanhTien);
                                            //}
                                        }
                                        else
                                        {
                                            donGiaLamTron = Math.Round(decimal.Parse(nguyenGia) / soLuongTS);
                                            //if (_congTy.CongThue.Value)
                                            //{
                                            //    donGiaLamTron = Math.Round(decimal.Parse(thanhTien) / soLuongTS);
                                            //}
                                            //else
                                            //{
                                            //    donGiaLamTron = Math.Round(decimal.Parse(thanhTien) / soLuongTS);
                                            //}
                                        }
                                        if (!String.IsNullOrEmpty(tienThue))
                                        {
                                            tienThueLamTron = Math.Round(decimal.Parse(tienThue) / soLuongTS);
                                        }
                                        if (String.IsNullOrEmpty(giaTriConLai) || soLuongTS <= 0)
                                            nguyenGiaConLai = 0;
                                        else
                                            nguyenGiaConLai = Math.Round(decimal.Parse(giaTriConLai) / soLuongTS);
                                        if (String.IsNullOrEmpty(luyKeHaoMon))
                                            giaTriHaoMonPhanBo = donGiaLamTron - nguyenGiaConLai;
                                        else
                                            giaTriHaoMonPhanBo = Math.Round(decimal.Parse(luyKeHaoMon) / soLuongTS);
                                        for (int i = 0; i < soLuongTS; i++)
                                        {
                                            _luuPSTSCD = false;
                                            _taiSanCoDinhCaBiet = _taiSanCoDinhCaBiet_Factory.CreateManagedObject();
                                            if (i == (soLuongTS - 1))
                                            {
                                                //if (_congTy.CongThue.Value)
                                                //{
                                                //    donGiaLamTron = decimal.Parse(thanhTien) - donGiaLamTron * (soLuongTS - 1);
                                                //}
                                                //else
                                                //{
                                                //    donGiaLamTron = decimal.Parse(donGia) - donGiaLamTron * (soLuongTS - 1);
                                                //}
                                                donGiaLamTron = decimal.Parse(nguyenGia) - donGiaLamTron * (soLuongTS - 1);
                                                if (nguyenGiaConLai != 0)
                                                    nguyenGiaConLai = decimal.Parse(giaTriConLai) - nguyenGiaConLai * (soLuongTS - 1);
                                                if (!String.IsNullOrEmpty(luyKeHaoMon))
                                                    giaTriHaoMonPhanBo = decimal.Parse(luyKeHaoMon) - giaTriHaoMonPhanBo * (soLuongTS - 1);
                                                else
                                                    giaTriHaoMonPhanBo = donGiaLamTron - nguyenGiaConLai;
                                                if (!String.IsNullOrEmpty(tienThue))
                                                {
                                                    tienThueLamTron = decimal.Parse(tienThue) - tienThueLamTron * (soLuongTS - 1);
                                                }
                                            }
                                            _taiSanCoDinhCaBiet.DonGia = _taiSanCoDinhCaBiet.NguyenGiaTinhKhauHao = _taiSanCoDinhCaBiet.NguyenGiaMua = (decimal)donGiaLamTron;
                                            _taiSanCoDinhCaBiet.LuyKeKhauHao = (decimal)giaTriHaoMonPhanBo;
                                            _taiSanCoDinhCaBiet.NguyenGiaConLai = nguyenGiaConLai;
                                            if (!String.IsNullOrEmpty(thueSuat))
                                                _taiSanCoDinhCaBiet.PhanTramThue = decimal.Parse(thueSuat);
                                            _taiSanCoDinhCaBiet.TienThue = tienThueLamTron;
                                            _taiSanCoDinhCaBiet.GhiChu = chiTietKyThuat;
                                            _taiSanCoDinhCaBiet.LaTaiSanCu = true;
                                            _taiSanCoDinhCaBiet.SoHopDong = soHopDong;
                                            _taiSanCoDinhCaBiet.SoHoaDon = soHoaDon;
                                            _taiSanCoDinhCaBiet.Model = model;
                                            _taiSanCoDinhCaBiet.Serial = serial;
                                            _taiSanCoDinhCaBiet.STT = _soTT;
                                            _taiSanCoDinhCaBiet.SuDung = true;
                                            _taiSanCoDinhCaBiet.MaCongTy = _congTy.MaCongTy;
                                            _taiSanCoDinhCaBiet.TenCaBiet = tenTaiSan;
                                            _taiSanCoDinhCaBiet.CPU = CPU;
                                            _taiSanCoDinhCaBiet.RAM = Ram;
                                            //if (!TSorCCDC)
                                            if (_loaiTanSan.MaQuanLy.ToUpper().Contains("CD"))
                                                _taiSanCoDinhCaBiet.LaCCDC = true;
                                            _taiSanCoDinhCaBiet.ThoiGianSuDung = Int32.Parse(thoiGianSuDung);
                                            if (_taiKhoan != null)
                                            {
                                                _taiSanCoDinhCaBiet.TaiKhoanDoiUng = _taiKhoan.SoHieuTK;
                                                _taiSanCoDinhCaBiet.MaTaiKhoan = _taiKhoan.MaTaiKhoan;
                                            }
                                            if (_taiKhoanPhanBo != null)
                                            {
                                                _taiSanCoDinhCaBiet.MaTaiKhoanPhanBo = _taiKhoanPhanBo.MaTaiKhoan;
                                            }
                                            //gán khóa ngoại
                                            _taiSanCoDinhCaBiet.MaTSCD = _loaiTanSan.ID;
                                            //gán nguồn -- đang gán mặc định là nguồn ngân sách có mã là 1, 2: nguồn viện trợ, biếu tặng, 3 là nguồn của trường BUH
                                            //_taiSanCoDinhCaBiet.MaNguon = 1;
                                            //lưu lại số hiệu cũ
                                            _taiSanCoDinhCaBiet.SoHieuCu = soHieuTSCDCB;
                                            _taiSanCoDinhCaBiet.STT = _soTT;
                                            //phát sinh số hiệu quan trọng cần chỉnh sửa dựa theo yêu cầu bên khách hàng
                                            //if (soHieuMoiTSCDCB == "")
                                            String soHieuMoiTSCDCB = "";
                                            soHieuMoiTSCDCB = _taiSanCoDinhCaBiet_Factory.Get_NextSoHieuTSCDCaBiet_ByMaTSCD(_loaiTanSan.ID);//_taiSanCoDinh.MaQuanLy + "0001";
                                            while (_taiSanCoDinhCaBiet_Factory.KiemTraTSCDCaBietTrungSoHieu(soHieuMoiTSCDCB, _congTy.MaCongTy))
                                            {
                                                soHieuMoiTSCDCB = PhatSinhTaiSanCoDinhCaBiet(soHieuMoiTSCDCB);
                                            }
                                            _taiSanCoDinhCaBiet.SoHieu = soHieuMoiTSCDCB;
                                            //ngày nhận
                                            if (!string.IsNullOrWhiteSpace(ngayMua))
                                            {
                                                _ngayMua = null;
                                                try
                                                {
                                                    _ngayMua = Convert.ToDateTime(ngayMua);
                                                }
                                                catch (Exception ex)
                                                {
                                                    errorLog.AppendLine(" + Ngày nhận không đúng định dạng dd/MM/yyyy.");
                                                }

                                                if (_ngayMua != null)
                                                {
                                                    if (_ngayMua != DateTime.MinValue)
                                                    {
                                                        _taiSanCoDinhCaBiet.NgayNhan = _ngayMua;
                                                        _taiSanCoDinhCaBiet.NgaySuDung = _ngayMua;
                                                        _taiSanCoDinhCaBiet.NgayChungTu = _ngayMua;
                                                    }
                                                    else
                                                        errorLog.AppendLine(string.Format(" + Ngày nhận  không hợp lệ: {0:dd/MM/yyyy}", _ngayMua.Value));
                                                }
                                                //else
                                                //{
                                                //    errorLog.AppendLine(" + Ngày nhận không đúng định dạng dd/MM/yyyy.");
                                                //}
                                            }

                                            _taiSanCoDinhCaBiet_Factory.AddObject(_taiSanCoDinhCaBiet);
                                            _taiSanCoDinhCaBiet_Factory.SaveChanges();
                                            _luuPSTSCD = true;

                                            #region Phát sinh chi tiết nguyên giá
                                            if (_luuPSTSCD)
                                            {
                                                chiTietNguyenGia = _chiTietNguyenGiaTSCDCB_factory.CreateManagedObject();
                                                chiTietNguyenGia.MaTSCDCaBiet = _taiSanCoDinhCaBiet.MaTSCDCaBiet;
                                                chiTietNguyenGia.SoTien = _taiSanCoDinhCaBiet.NguyenGiaMua;
                                                chiTietNguyenGia.LuyKeKhauHao = _taiSanCoDinhCaBiet.LuyKeKhauHao;
                                                chiTietNguyenGia.LuyKeHaoMon = _taiSanCoDinhCaBiet.LuyKeHaoMon;
                                                chiTietNguyenGia.NgayThucHien = _taiSanCoDinhCaBiet.NgaySuDung;
                                                chiTietNguyenGia.LoaiPhanBietNV = 1;
                                                _chiTietNguyenGiaTSCDCB_factory.SaveChanges();
                                            }
                                            #endregion

                                            #region phân bổ tài sản vào bộ phận lần đầu
                                            if (_luuPSTSCD)
                                            {
                                                _taiSanCDCB_PhongBan = _taiSanCDCB_PhongBan_Factory.CreateManagedObject();
                                                if (_viTri != null)
                                                    _taiSanCDCB_PhongBan.MaViTri = _viTri.MaBoPhan;
                                                if (_boPhan != null)
                                                    _taiSanCDCB_PhongBan.MaPhongBan = _boPhan.MaBoPhan;
                                                _taiSanCDCB_PhongBan.MaTSCDCaBiet = _taiSanCoDinhCaBiet.MaTSCDCaBiet;
                                                _taiSanCDCB_PhongBan.NgayPhanBo = _taiSanCoDinhCaBiet.NgaySuDung;
                                                _taiSanCDCB_PhongBan_Factory.SaveChangesWithoutTrackingLog();
                                            }
                                            #endregion
                                            #endregion
                                        } //end else kiểm tra mã loại tài sản
                                    }
                                }
                            }
                            //kiểm tra xem tài sản nào không import vào phần mềm
                            if (errorLog.Length > 0)
                            {
                                mainLog.AppendLine("- STT: " + _soTT);
                                mainLog.AppendLine(string.Format("- Tài sản {0} thông tin chi tiết {1} không import được vào phần mềm", tenTaiSan, chiTietKyThuat));
                                mainLog.AppendLine(errorLog.ToString());
                            }
                        }//end for
                    }
                } //end using dialog waiting
            }  //end if open file
            //ghi lại thông tin lỗi khi import tài sản
            if (mainLog.Length > 0)
            {
                string tenFile = DateTime.Now.ToLongDateString() + "ImportTSCDCB_Log.txt";
                //FileStream fileStream = File.Open(tenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                StreamWriter writer = new StreamWriter(tenFile);
                writer.WriteLine(mainLog.ToString());
                writer.Flush();
                writer.Close();
                writer.Dispose();
                //mở file log
                System.Diagnostics.Process.Start(tenFile);
            }
            DialogUtil.ShowInfo("Đã Import xong!");
        }

        public static DataTable GetDataTable(string excelFilePath, string tableName)
        {
            //string connectionString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;", excelFilePath);
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", excelFilePath);
            using (OleDbConnection cnn = new OleDbConnection(connectionString))
            {
                string query = String.Format("Select * from {0}", tableName);
                using (OleDbDataAdapter da = new OleDbDataAdapter(query, cnn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static String PhatSinhTaiSanCoDinhCaBiet(String SoHieu)
        {
            String hauTo = SoHieu.Substring(SoHieu.Length - 4);
            String tienTo = SoHieu.Substring(0, SoHieu.Length - 4);
            int stt = int.Parse(hauTo);
            stt++;
            switch (stt.ToString().Length)
            {
                case 1:
                    hauTo = "000" + stt;
                    break;
                case 2:
                    hauTo = "00" + stt;
                    break;
                case 3:
                    hauTo = "0" + stt;
                    break;
                case 4:
                    hauTo = stt.ToString();
                    break;
                default://tự động thêm số 0 vào trước
                    hauTo = "0" + stt;
                    break;
            }
            return tienTo + hauTo;
        }

        public static void WriteLog(string path, string data)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(data);
            writer.Flush();
            writer.Close();
            writer.Dispose();
        }

        public static void ImportTSCoDinh()
        {
            DanhMucTSCD_Factory _danhMucTSCD_Factory = null;
            TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_Factory = null;
            BoPhan_Factory _boPhan_Factory = null;
            TaiSanCoDinhCaBiet_PhongBan_Factory _taiSanCDCB_PhongBan_Factory = null;
            //Nguon_Factory _nguon_Factory = null;
            ChungTu_Factory _chungTu_Factory = null;
            DonViTinh_Factory _donViTinh_Factory = null;
            TaiKhoan_Factory _taiKhoan_Factory = null;
            //ChungTuGhiTangTaiSan_DerivedFactory _nghiepVu_GhiTang_Factory = null;
            ChiTietNguyenGiaTSCD_Factory _chiTietNguyenGiaTSCDCB_factory = null;

            IQueryable<tblDanhMucTSCD> _danhMucTSCDList = null;
            IQueryable<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;

            OpenFileDialog oFD = new OpenFileDialog() { Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx" };

            var mainLog = new StringBuilder();
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm wait = new WaitDialogForm("Đang import dữ liệu từ file excel...", "Vui lòng chờ"))
                {
                    //khởi tạo factory
                    _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
                    //_nguon_Factory = Nguon_Factory.New();
                    _donViTinh_Factory = DonViTinh_Factory.New();
                    //lấy hết cây danh mục
                    _danhMucTSCDList = _danhMucTSCD_Factory.GetAll();
                    tblDanhMucTSCD _loaiTanSan;
                    tblDanhMucTSCD _taiSanCoDinh = null;
                    tblDonViTinh _donViTinh = null;
                    using (DataTable dt = GetDataTable(oFD.FileName, "[TSCD$A1:D]"))
                    {
                        const int sttIdx = 0;
                        #region thông tin tài sản cố định
                        const int tenTaiSanIdx = 1;
                        const int donViTinhIdx = 2;
                        const int maLoaiTaiSanIdx = 3;
                        #endregion

                        foreach (DataRow dr in dt.Rows)
                        {
                            var errorLog = new StringBuilder();
                            bool _luuPSTSCD = false;
                            bool _daLuuXong = true;
                            #region khởi tạo các cột
                            //số thứ tự 0
                            String _soTT = dr[sttIdx].ToString().FullTrim(); //0
                            //tên tài sản 2 
                            String tenTaiSan = dr[tenTaiSanIdx].ToString().FullTrim(); //1
                            //đơn vị tính 2
                            String donViTinh = dr[donViTinhIdx].ToString().FullTrim();//2
                            _donViTinh = _donViTinh_Factory.get_DonViTinh_ByTen(donViTinh);
                            //mã loại tài sản 3
                            String maLoaiTaiSan = dr[maLoaiTaiSanIdx].ToString().FullTrim(); //3
                            #endregion

                            if (String.IsNullOrEmpty(maLoaiTaiSan))
                            {
                                errorLog.AppendLine(" Không có loại tài sản - cần gán tài sản vào loại tài sản.");
                            }
                            else
                            {
                                _loaiTanSan = _danhMucTSCD_Factory.Get_LoaiTaiSan_ByMaQuanLy(maLoaiTaiSan);
                                if (_loaiTanSan == null)
                                {
                                    errorLog.AppendLine(" Loại tài sản không hợp lệ - không tồn tại loại tài sản này.");
                                }
                                else
                                {
                                    #region lưu tài sản cố định lên cây tài sản và kiểm có tài cố định thuộc loại này chưa nếu có rồi thì tự thêm cá biệt vào còn chưa thì tự phát sinh tài sản cố định
                                    _taiSanCoDinh = _danhMucTSCD_Factory.Get_TaiSanCoDinh_ByTenTaiSan_And_MaLoaiTaiSan(tenTaiSan, _loaiTanSan.ID);
                                    if (_taiSanCoDinh == null) //if import vào cây danh mục tài sản
                                    {
                                        _daLuuXong = false;
                                        //lưu tài sản lên cây
                                        _taiSanCoDinh = _danhMucTSCD_Factory.CreateManagedObject();
                                        _taiSanCoDinh.ParentID = _loaiTanSan.ID;
                                        //_taiSanCoDinh.TyLeHaoMon = _loaiTanSan.TyLeHaoMon;
                                        _taiSanCoDinh.TGSuDungToiDaTSCD = _loaiTanSan.TGSuDungToiDaTSCD;
                                        _taiSanCoDinh.Ten = tenTaiSan;
                                        _taiSanCoDinh.LaTaiSanCoDinh = true;
                                        _taiSanCoDinh.MaQuanLy = PhatSinhMaQuanLyMoi(parentObject: _loaiTanSan, _danhMucTSCD_Factory: _danhMucTSCD_Factory);
                                        if (_donViTinh != null)
                                            _taiSanCoDinh.MaDonViTinhTSCD = _donViTinh.MaDonViTinh;
                                        else
                                            _taiSanCoDinh.MaDonViTinhTSCD = 4;//đơn vị tính là cái
                                        _danhMucTSCD_Factory.AddObject(_taiSanCoDinh);
                                        _danhMucTSCD_Factory.SaveChangesWithoutTrackingLog();

                                        _daLuuXong = true;
                                    }//end lưu tài sản cố định vào danh mục tài sản
                                    else
                                    {
                                        errorLog.AppendLine(" Tài sản này đã có! STT: " + _soTT + ", Tên: " + tenTaiSan);
                                    }
                                    #endregion
                                } //end else kiểm tra mã loại tài sản
                            }
                            //kiểm tra xem tài sản nào không import vào phần mềm
                            if (errorLog.Length > 0)
                            {
                                mainLog.AppendLine("- STT: " + _soTT);
                                mainLog.AppendLine(string.Format("- Tài sản {0} thông tin chi tiết {1} không import được vào phần mềm", tenTaiSan, maLoaiTaiSan));
                                mainLog.AppendLine(errorLog.ToString());
                            }
                        }//end for
                    }
                } //end using dialog waiting
            }  //end if open file
            //ghi lại thông tin lỗi khi import tài sản
            if (mainLog.Length > 0)
            {
                string tenFile = DateTime.Now.ToLongDateString() + "ImportTSCD_Log.txt";
                //FileStream fileStream = File.Open(tenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                StreamWriter writer = new StreamWriter(tenFile);
                writer.WriteLine(mainLog.ToString());
                writer.Flush();
                writer.Close();
                writer.Dispose();
                //mở file log
                System.Diagnostics.Process.Start(tenFile);
            }
            DialogUtil.ShowInfo("Đã Import xong!");
        }
    }
}

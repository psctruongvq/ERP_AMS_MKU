using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class TinhLuongNhanVien
    {

        //tính lương cho 1 nhân viên
        //Hiền Trung - 25/12/2008
        public DateTime _NgayTinhThamNien = DateTime.Today;

        private KyTinhLuong _KyLuong;
        private ThongTinNhanVienTinhLuongChild _NhanVien;
        private SqlConnection _connect;
        private SqlTransaction _trans;
        private ThongTinNhanVienTinhLuongList _list;
        private long _MaNhanVien = 0;
        private int _MaBoPhan = 0;

        //các thông tin dùng chung
        //private Default_Ngay _default;
        private decimal _LuongCoBan = 540000;
        private decimal _NgayCong = 26;
        private decimal _SoGioTrongNgay = 8;
        private decimal _LuongNoiBo = 700000;
        private decimal _LuongThamNien = 15000;
        private decimal _PTBHXH = 6M;
        private decimal _PTBHYT = 1.5M;
        private decimal _PTBHTN = 1;
        private decimal _PTCongDoan = 1;
        //private decimal _TienAnThang = 450000;
        //private decimal _PhucCapHanhChinh = 100000;
        //private decimal _PTTangCaNgayThuong = 150;
        //private decimal _PTTangCaT7CN = 200;
        //private decimal _PTTangCaNgayLe = 300;
        private int _SoNgayTrongThang = 0;
        private int _NghiTruLuong = 0, _NghiBHXH = 0, _TongSoNgayNghi = 0, _NghiKhongLuongDot1 = 0, _NghiKhongLuongDot2 = 0;
        private decimal _HeSoVuotKhung = 0;
        private decimal _HeSoVuotKhungBH = 0;
        private List<DateTime> _ListHoliday = new List<DateTime>();
        private DateTime _ngayBDTinhLuong;
        private DateTime _ngayKTTinhLuong;
        private int _loai;
             

        public DateTime NgayBDTinhLuong
        {
            get
            {
                return _ngayBDTinhLuong;
            }
            set
            {
            	
                _ngayBDTinhLuong= value;
            }

        }
        public DateTime NgayKTTinhLuong
        {
            get
            {
                return _ngayKTTinhLuong;
            }
            set
            {

                _ngayKTTinhLuong = value;
            }

        }
        public Int32 Loai
        {
            get
            {
                return _loai;
            }
            set
            {

                _loai = value;
            }

        }

        //các số khi tính toán
        int ThamNien;


        public TinhLuongNhanVien(KyTinhLuong KyLuong)
        {
            _KyLuong = KyLuong;
        }

        public void Begin()
        {
            _connect = new SqlConnection(Database.ERP_Connection);
            _connect.Open();
            _trans = _connect.BeginTransaction();

            //lấy danh sách ngày holiday
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandText = "Select Ngay From tblnsNgayHoliday";
                cm.CommandType = System.Data.CommandType.Text;
                using (Csla.Data.SafeDataReader dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        _ListHoliday.Add(dr.GetDateTime("Ngay"));
                    }
                }
            }

            //tính số ngày trong 1 tháng
            for (DateTime ngay = _KyLuong.NgayBatDau; ngay <= _KyLuong.NgayKetThuc; ngay = ngay.AddDays(1))
                if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday && !_ListHoliday.Contains(ngay))
                    _SoNgayTrongThang += 1;


            //các dữ liệu config
            ERP_Library.Default_Ngay d = ERP_Library.Default_Ngay.GetDefault_Ngay();
            _LuongCoBan = d.LuongCoBan;
            _LuongNoiBo = d.LuongNoiBo;
            _LuongThamNien = d.PhuCapThamNien;
            _NgayCong = d.SoNgayLamViecTrongThang;
            _SoGioTrongNgay = d.SoGioTrongNgay;

            _PTBHXH = d.PhanTramBHXH;
            _PTBHYT = d.PhanTramBHYT;
            _PTBHTN = d.PhanTramBHTN;
            _PTCongDoan = d.PhanTramCongDoan;

        }
        public void XoaDuLieuCu_TinhLuongKy1()
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandTimeout = 0;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_BangLuongKy1";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.ExecuteNonQuery();
            }
        }
        public void XoaDuLieuCu_TinhLuongKy2()
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandTimeout = 0;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                //nếu là admin thì tính hết, ngược lại kế toán ban chỉ tính lương khoán
                if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                {
                    cm.CommandText = "spd_Delete_BangLuongKy2";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", _loai );
                }
                else
                {
                    cm.CommandText = "spd_Delete_BangLuongKy2_LuongKhoan";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                cm.ExecuteNonQuery();
            }
        }
        //public void XoaDuLieuCu()
        //{
        //    //từ bảng lương tháng 11 không sử dụng, ngày sửa : 21/10/2009
        //    //xóa dữ liệu bảng lương
        //    using (SqlCommand cm = _connect.CreateCommand())
        //    {
        //        cm.Transaction = _trans;
        //        cm.CommandType = System.Data.CommandType.Text;
        //        if (_DelAll)
        //        {

        //            cm.CommandText = "Delete From tblnsBangLuong Where MaKyTinhLuong = @MaKyTinhLuong";
        //            cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
        //        }
        //        else if (_DelBoPhan != 0)
        //        {
        //            cm.CommandText = "Delete From tblnsBangLuong Where MaKyTinhLuong = @MaKyTinhLuong AND MaBoPhan = @MaBoPhan";
        //            cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
        //            cm.Parameters.AddWithValue("@MaBoPhan", _DelBoPhan);
        //        }
        //        else
        //        {
        //            cm.CommandText = "Delete From tblnsBangLuong Where MaKyTinhLuong = @MaKyTinhLuong AND MaNhanVien = @MaNhanVien";
        //            cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
        //            cm.Parameters.AddWithValue("@MaNhanVien", _DelNhanVien);
        //        }
        //        cm.ExecuteNonQuery();
        //    }
        //}

        public void End()
        {
            if (_trans != null)
                _trans.Commit();
            if (_connect != null)
                _connect.Close();
        }

        public void Cancel()
        {
            if (_trans != null)
                _trans.Rollback();
            if (_connect != null)
                _connect.Close();
        }

        public void GetListData(int MaBoPhan, long MaNhanVien, int Kieu)
        {
            _list = ThongTinNhanVienTinhLuongList.GetThongTinNhanVienTinhLuongList(MaBoPhan, MaNhanVien, Kieu);
            _MaBoPhan = MaBoPhan;
            _MaNhanVien = MaNhanVien;

        }

        public ThongTinNhanVienTinhLuongList List
        {
            get
            {
                return _list;
            }
        }

        public void TinhLuongDot1(ThongTinNhanVienTinhLuongChild nv)
        {
            _NhanVien = nv;
            if (_NhanVien.LoaiNV >= 5) return;

            TinhSoNgayNghi();
            if (_NghiKhongLuongDot1 == _SoNgayTrongThang) return;

            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;

                decimal PTLuongV1 = TinhPTLuongV1();

                _HeSoVuotKhung = Math.Round(nv.HeSoVuotKhung * nv.HeSoLuong / 100, 3, MidpointRounding.AwayFromZero);
                _HeSoVuotKhungBH = Math.Round(nv.HeSoVuotKhungBH * nv.HeSoLuongBaoHiem / 100, 3, MidpointRounding.AwayFromZero);
                //tính số ngày nghỉ, ngày làm việc
                int SoNgayNghi, SoNgayLamViec;
                SoNgayNghi = _NghiTruLuong;
                SoNgayLamViec = _SoNgayTrongThang - _TongSoNgayNghi;

                //tính lương lương cơ bản V1
                decimal HesoV1, LuongV1;
                HesoV1 = nv.HeSoLuong + nv.HeSoPhuCapChucVu + _HeSoVuotKhung;
                
                LuongV1 = Math.Round(_LuongCoBan * HesoV1 * PTLuongV1 / 100, 0, MidpointRounding.AwayFromZero);

                //lương ngày nghỉ
                decimal LuongNgayNghi = 0;
                LuongNgayNghi = Math.Round(SoNgayNghi * _LuongCoBan * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhungBH) / _NgayCong, 0, MidpointRounding.AwayFromZero);

    
                //các khoản trừ
                decimal BHXH = 0, BHYT = 0, CongDoan = 0, BHTN = 0;
                if (nv.KhongTinhBaoHiem == false)
                {
                    BHXH = Math.Round(_PTBHXH / 100 * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhungBH) * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                    BHYT = Math.Round(_PTBHYT / 100 * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhungBH) * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                    BHTN = Math.Round(_PTBHTN / 100 * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhungBH) * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                    CongDoan = Math.Round(_PTCongDoan / 100 * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhungBH) * _LuongCoBan, 0, MidpointRounding.AwayFromZero);

                }
                //lương BHXH
                int BHXHNgay = _NghiBHXH;
                decimal BHXHLuong = 0;
                BHXHLuong = Math.Round(BHXHNgay * _LuongCoBan * (nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + _HeSoVuotKhung) / _NgayCong, 0, MidpointRounding.AwayFromZero);

                //cập nhật lại lương ngày nghỉ, lương BHXH, tiền BHXH nếu trường hợp nghỉ bh tròn 1 tháng
                if (BHXHNgay == _SoNgayTrongThang)
                {
                    LuongNgayNghi = LuongBaoHiem();
                    LuongV1 = LuongNgayNghi;
                    BHXHLuong = LuongNgayNghi;
                    BHXH = 0;
                    BHTN = 0;
                    BHYT = 0;
                }

                //thực lãnh V1
                decimal ThucLanhLuongV1;
                decimal Tru_Cong;
                // cho nay tru cong doan ne
                if (Security.CurrentUser.Info.MaCongTy == 3)//TFS tính thu tiền công đoàn va tính thuế tạm thu
                {
                    Tru_Cong = BHXH + LuongNgayNghi + CongDoan + BHYT + BHTN;
                    ThucLanhLuongV1 = LuongV1 - Tru_Cong;
                }
                else
                {
                    Tru_Cong = BHXH + LuongNgayNghi+BHYT+BHTN;
                    ThucLanhLuongV1 = LuongV1 - Tru_Cong;
                }
                //
                //-----------------------------------------
                //lưu dữ liệu, lưu tất cả tiền mặt sau đó cập nhật lại ngân hàng chuyển theo tài khoản đăng ký
                cm.CommandText = "spd_Insert_BangLuongKy1";
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhan", nv.MaBoPhan);
                cm.Parameters.AddWithValue("@CMND", nv.CMND);
                cm.Parameters.AddWithValue("@LoaiNV", nv.LoaiNV);
                cm.Parameters.AddWithValue("@MaNgachLuong", nv.TenNgachLuongCoBan);
                cm.Parameters.AddWithValue("@HeSoCoBan", nv.HeSoLuong);
                cm.Parameters.AddWithValue("@HeSoBaoHiem", nv.HeSoLuongBaoHiem);
                cm.Parameters.AddWithValue("@HeSoNoiBo", nv.HeSoLuongNoiBo);
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", nv.HeSoVuotKhung);
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _HeSoVuotKhung);
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", nv.HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoPhuCap", nv.HeSoPhuCapChucVu);
                cm.Parameters.AddWithValue("@HeSoDocHai", nv.HeSoDocHai);
                cm.Parameters.AddWithValue("@HeSoBu", nv.HeSoBu);
                cm.Parameters.AddWithValue("@HeSoBoSung", nv.HeSoBoSung);
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", nv.PhuCapHC);
                cm.Parameters.AddWithValue("@LuongKhoan", nv.LuongKhoan);
                cm.Parameters.AddWithValue("@PhanTramNhan", PTLuongV1);
                cm.Parameters.AddWithValue("@HeSoLuong", HesoV1);
                cm.Parameters.AddWithValue("@LuongCoBanNN", _LuongCoBan);
                cm.Parameters.AddWithValue("@TienLuong", LuongV1);
                cm.Parameters.AddWithValue("@Nghi_SoNgay", SoNgayNghi);
                cm.Parameters.AddWithValue("@Nghi_Luong", LuongNgayNghi);
                cm.Parameters.AddWithValue("@BHXH_SoNgay", BHXHNgay);
                cm.Parameters.AddWithValue("@BHXH_Luong", BHXHLuong);
                cm.Parameters.AddWithValue("@Tru_BHXH", BHXH);
                cm.Parameters.AddWithValue("@Tru_BHYT", BHYT);
                cm.Parameters.AddWithValue("@Tru_BHTN", BHTN);
                cm.Parameters.AddWithValue("@Tru_CongDoan", CongDoan);
                cm.Parameters.AddWithValue("@Tru_Cong", Tru_Cong);
                cm.Parameters.AddWithValue("@ThucLanh", ThucLanhLuongV1);
               
                cm.ExecuteNonQuery();
            }
        }

        private decimal LuongBaoHiem()
        {
            //lấy số tiền lương do bảo hiểm trả để báo cáo trên bảng lương kỳ 1
            decimal luong = 0;
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandTimeout = 0;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_LuongBaoHiem";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                try
                {
                    luong = Convert.ToDecimal(cm.ExecuteScalar());
                }
                catch
                {
                    luong = 0;
                }
            }
            return luong;
        }

        private void TinhLuongLoaiKhoan()
        {

            TinhSoNgayNghi();
            if (_NghiKhongLuongDot1 == _SoNgayTrongThang) return;

            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;

                decimal PTLuongV1 = TinhPTLuongV1();
                _HeSoVuotKhungBH = Math.Round(_NhanVien.HeSoVuotKhungBH * _NhanVien.HeSoLuongBaoHiem / 100, 3, MidpointRounding.AwayFromZero);
                int SoNgayNghi, SoNgayLamViec;
                SoNgayNghi = _NghiTruLuong;
                SoNgayLamViec = _SoNgayTrongThang - _TongSoNgayNghi;

                decimal LuongThamNien = 0;
                ThamNien = 0;
                ThamNien = _NgayTinhThamNien.Year - _NhanVien.NgayTinhThamNien.Year;
                if (_NgayTinhThamNien.Month < _NhanVien.NgayTinhThamNien.Month || (_NgayTinhThamNien.Month == _NhanVien.NgayTinhThamNien.Month && _NgayTinhThamNien.Day < _NhanVien.NgayTinhThamNien.Day))
                    ThamNien--;
                if (ThamNien < 0) ThamNien = 0;
                decimal PTLuongV2 = TinhPTLuongV2();
                if (_NhanVien.LoaiNV == 5)
                    LuongThamNien = Math.Round(ThamNien * _LuongThamNien * PTLuongV2 / 100, 0, MidpointRounding.AwayFromZero);
                else
                    LuongThamNien = 0;

                //tính lương lương cơ bản V1
                decimal HesoV1, LuongV1;
                HesoV1 = _NhanVien.HeSoLuongBaoHiem + _NhanVien.HeSoPhuCapChucVu + _HeSoVuotKhungBH;
                if (PTLuongV1 > 0)
                    LuongV1 = Math.Round(_NhanVien.LuongKhoan * PTLuongV1 / 100, 0, MidpointRounding.AwayFromZero);
                else
                    LuongV1 = _NhanVien.LuongKhoan;

                //lương ngày nghỉ
                
                decimal LuongNgayNghi = 0;
                if (_NhanVien.LoaiNV != 7)
                {
                    LuongNgayNghi = Math.Round((_NhanVien.HeSoLuongBaoHiem*_LuongCoBan*Convert.ToDecimal(0.75)/ _NgayCong)*SoNgayNghi, 0, MidpointRounding.AwayFromZero);
                }
                else
                {

                    LuongNgayNghi = Math.Round(_NhanVien.LuongKhoan * SoNgayNghi / _NgayCong, 0, MidpointRounding.AwayFromZero);
                }
                //các khoản trừ
                decimal BHXH = 0, BHYT = 0, CongDoan = 0, BHTN = 0;
                BHXH = Math.Round(_PTBHXH / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                BHYT = Math.Round(_PTBHYT / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                BHTN = Math.Round(_PTBHTN / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                //if (_NhanVien.LoaiNV == 5)
                //{
                //    BHYT = Math.Round(_PTBHYT / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                //    BHTN = Math.Round(_PTBHTN / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);
                //}
                // cai cu
                //CongDoan = Math.Round(_PTCongDoan / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);

                //tam sua
                if (Security.CurrentUser.Info.MaBoPhan == 22)
                {

                    CongDoan = Math.Round(_PTCongDoan / 100 * HesoV1 * _LuongCoBan, 0, MidpointRounding.AwayFromZero);


                }
                else
                {
                    CongDoan = 0;
                }
                ////;....................

                //decimal CongKhauTru = BHXH + BHYT + BHTN;//anh Trung
                decimal CongKhauTru = BHXH + BHYT + BHTN + CongDoan;//Nhân
                //lương BHXH
                int BHXHNgay = _NghiBHXH;
                decimal BHXHLuong = 0;
                BHXHLuong = Math.Round(BHXHNgay * _LuongCoBan * HesoV1 / _NgayCong, 0, MidpointRounding.AwayFromZero);

                //cập nhật lại lương ngày nghỉ, lương BHXH, tiền BHXH nếu trường hợp nghỉ bh tròn 1 tháng
                if (BHXHNgay == _SoNgayTrongThang)
                {
                    decimal l = LuongBaoHiem();
                    if (l > LuongV1) l = LuongV1;
                    LuongNgayNghi = l;
                    BHXHLuong = LuongNgayNghi;
                    BHXH = 0;
                    BHYT = 0;
                    BHTN = 0;
                    CongKhauTru = CongDoan;
                }

                //if (Security.CurrentUser.Info.MaCongTy == 3)//TFS tính thu tiền công đoàn va tính thuế tạm thu
                //{
                //    Tru_Cong = BHXH + LuongNgayNghi + CongDoan + BHYT + BHTN;
                //    ThucLanhLuongV1 = LuongV1 - Tru_Cong;
                //}
                //else
                //{
                //    Tru_Cong = BHXH + LuongNgayNghi + BHYT + BHTN;
                //    ThucLanhLuongV1 = LuongV1 - Tru_Cong;
                //}
                //thực lãnh V1
                decimal ThucLanhKhoan;

                ThucLanhKhoan = LuongV1 - LuongNgayNghi - BHXH - BHYT - BHTN - CongDoan ;


                //
                //-----------------------------------------
                //lưu dữ liệu
                cm.CommandText = "spd_Insert_BangLuong_Ky2";
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhan", _NhanVien.MaBoPhan);
                cm.Parameters.AddWithValue("@CMND", _NhanVien.CMND);
                cm.Parameters.AddWithValue("@LoaiNV", _NhanVien.LoaiNV);
                cm.Parameters.AddWithValue("@MaNgachLuong", _NhanVien.TenNgachLuongCoBan);
                cm.Parameters.AddWithValue("@HeSoCoBan", _NhanVien.HeSoLuong);
                cm.Parameters.AddWithValue("@HeSoBaoHiem", _NhanVien.HeSoLuongBaoHiem);
                cm.Parameters.AddWithValue("@HeSoNoiBo", _NhanVien.HeSoLuongNoiBo);
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", _NhanVien.HeSoVuotKhung);
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _HeSoVuotKhung);
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _NhanVien.HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoPhuCap", _NhanVien.HeSoPhuCapChucVu);
                cm.Parameters.AddWithValue("@HeSoDocHai", _NhanVien.HeSoDocHai);
                cm.Parameters.AddWithValue("@HeSoBu", _NhanVien.HeSoBu);
                cm.Parameters.AddWithValue("@HeSoBoSung", _NhanVien.HeSoBoSung);
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _NhanVien.PhuCapHC);
                cm.Parameters.AddWithValue("@LuongKhoan", _NhanVien.LuongKhoan);
                cm.Parameters.AddWithValue("@PhanTramNhan", PTLuongV2);
                cm.Parameters.AddWithValue("@LuongNoiBo", _LuongNoiBo);
                cm.Parameters.AddWithValue("@LuongCoBanNN", _LuongCoBan);
                cm.Parameters.AddWithValue("@DonGiaThamNien", _LuongThamNien);
                cm.Parameters.AddWithValue("@SoNamThamNien", ThamNien);
                cm.Parameters.AddWithValue("@LuongThamNien", LuongThamNien);
                cm.Parameters.AddWithValue("@HeSoLuong", HesoV1);
                cm.Parameters.AddWithValue("@LuongHeSo", 0);
                cm.Parameters.AddWithValue("@TruThueTNCN", _KyLuong.TruThueTNCN);
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", SoNgayNghi);
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", LuongNgayNghi);
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", BHXHNgay);
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", BHXHLuong);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", BHXH);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", BHYT);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", BHTN);
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", CongKhauTru);
                cm.Parameters.AddWithValue("@Tru_CongDoan", CongDoan);
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", ThucLanhKhoan);
                cm.Parameters.AddWithValue("@NgayBDTinhLuong", _ngayBDTinhLuong);
                cm.Parameters.AddWithValue("@NgayKTTinhLuong", _ngayKTTinhLuong);
                cm.ExecuteNonQuery();
            }
        }

        private void TinhLuongLoaiKhoanNew()
        {
         
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;

                decimal PTLuongV1 = TinhPTLuongV1();
                _HeSoVuotKhungBH = Math.Round(_NhanVien.HeSoVuotKhungBH * _NhanVien.HeSoLuongBaoHiem / 100, 3, MidpointRounding.AwayFromZero);
                int SoNgayNghi, SoNgayLamViec;
                SoNgayNghi = _NghiTruLuong;
                SoNgayLamViec = _SoNgayTrongThang - _TongSoNgayNghi;

                decimal LuongThamNien = 0;
                ThamNien = 0;            
                decimal PTLuongV2 = TinhPTLuongV2();
                    LuongThamNien = 0;

                //tính lương lương cơ bản V1
                decimal HesoV1, LuongV1;
                HesoV1 = 0;
                if (PTLuongV1 > 0)
                    LuongV1 = Math.Round(_NhanVien.LuongKhoan * PTLuongV1 / 100, 0, MidpointRounding.AwayFromZero);
                else
                    LuongV1 = _NhanVien.LuongKhoan;

                //lương ngày nghỉ

                decimal LuongNgayNghi = 0;
               
                //các khoản trừ
                decimal BHXH = 0, BHYT = 0, CongDoan = 0, BHTN = 0;
               
            
                
                //decimal CongKhauTru = BHXH + BHYT + BHTN;//anh Trung
                decimal CongKhauTru = BHXH + BHYT + BHTN + CongDoan;//Nhân
                //lương BHXH
                int BHXHNgay = _NghiBHXH;
                decimal BHXHLuong = 0;

                //thực lãnh V1
                decimal ThucLanhKhoan;

                ThucLanhKhoan = LuongV1 - LuongNgayNghi - BHXH - BHYT - BHTN - CongDoan;


                //
                //-----------------------------------------
                //lưu dữ liệu
                cm.CommandText = "spd_Insert_BangLuong_Ky2";
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhan", _NhanVien.MaBoPhan);
                cm.Parameters.AddWithValue("@CMND", _NhanVien.CMND);
                cm.Parameters.AddWithValue("@LoaiNV", _NhanVien.LoaiNV);
                cm.Parameters.AddWithValue("@MaNgachLuong", _NhanVien.TenNgachLuongCoBan);
                cm.Parameters.AddWithValue("@HeSoCoBan", _NhanVien.HeSoLuong);
                cm.Parameters.AddWithValue("@HeSoBaoHiem", _NhanVien.HeSoLuongBaoHiem);
                cm.Parameters.AddWithValue("@HeSoNoiBo", _NhanVien.HeSoLuongNoiBo);
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", _NhanVien.HeSoVuotKhung);
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _HeSoVuotKhung);
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", _NhanVien.HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoPhuCap", _NhanVien.HeSoPhuCapChucVu);
                cm.Parameters.AddWithValue("@HeSoDocHai", _NhanVien.HeSoDocHai);
                cm.Parameters.AddWithValue("@HeSoBu", _NhanVien.HeSoBu);
                cm.Parameters.AddWithValue("@HeSoBoSung", _NhanVien.HeSoBoSung);
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", _NhanVien.PhuCapHC);
                cm.Parameters.AddWithValue("@LuongKhoan", _NhanVien.LuongKhoan);
                cm.Parameters.AddWithValue("@PhanTramNhan", PTLuongV2);
                cm.Parameters.AddWithValue("@LuongNoiBo", _LuongNoiBo);
                cm.Parameters.AddWithValue("@LuongCoBanNN", _LuongCoBan);
                cm.Parameters.AddWithValue("@DonGiaThamNien", _LuongThamNien);
                cm.Parameters.AddWithValue("@SoNamThamNien", ThamNien);
                cm.Parameters.AddWithValue("@LuongThamNien", LuongThamNien);
                cm.Parameters.AddWithValue("@HeSoLuong", HesoV1);
                cm.Parameters.AddWithValue("@LuongHeSo", 0);
                cm.Parameters.AddWithValue("@TruThueTNCN", _KyLuong.TruThueTNCN);
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", SoNgayNghi);
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", LuongNgayNghi);
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", BHXHNgay);
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", BHXHLuong);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", BHXH);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", BHYT);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", BHTN);
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", CongKhauTru);
                cm.Parameters.AddWithValue("@Tru_CongDoan", CongDoan);
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", ThucLanhKhoan);
                cm.Parameters.AddWithValue("@NgayBDTinhLuong", this._KyLuong.NgayBatDau);
                cm.Parameters.AddWithValue("@NgayKTTinhLuong", this._KyLuong.NgayKetThuc);
                cm.ExecuteNonQuery();
            }
        }
        public void TinhLuongDot2Khoan(ThongTinNhanVienTinhLuongChild nv)
        {
            _NhanVien = nv;

            if (_NhanVien.LoaiNV == 7 ||_NhanVien.LoaiNV == 8)
            {
                TinhLuongLoaiKhoanNew();
                return;
            }
        }
        
         public void TinhLuongDot2(ThongTinNhanVienTinhLuongChild nv)
        {
            _NhanVien = nv;

            if (_NhanVien.LoaiNV == 5 || _NhanVien.LoaiNV == 6 || _NhanVien.LoaiNV==7 ||_NhanVien.LoaiNV==8)
            {
                TinhLuongLoaiKhoan();
                return;
            }
            if (!ERP_Library.Security.CurrentUser.IsAdminNhanSu) return;//mở ra chỉ cho các bộ phận tính lương khoán ở trên

            TinhSoNgayNghi();
            if (_NghiKhongLuongDot2 == _SoNgayTrongThang) return;

            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;

                //chỉ tính lương hệ số và thâm niên, các dữ liệu tổng khác xử lý bằng store
                decimal PTLuongV2 = TinhPTLuongV2();
                _HeSoVuotKhung = Math.Round(nv.HeSoVuotKhung * nv.HeSoLuong/ 100, 3, MidpointRounding.AwayFromZero);
                _HeSoVuotKhungBH = Math.Round(nv.HeSoVuotKhungBH * nv.HeSoLuongBaoHiem / 100, 3, MidpointRounding.AwayFromZero);

                decimal HeSoV2 = 0, LuongHeSo = 0, LuongThamNien = 0;
                ThamNien = 0;

                if (nv.LoaiNV == 2 || nv.LoaiNV == 3)
                {
                    HeSoV2 = nv.HeSoLuong + nv.HeSoPhuCapChucVu + nv.HeSoLuongNoiBo + _HeSoVuotKhung + nv.HeSoBu;
                }
                else
                    HeSoV2 = nv.HeSoLuongBaoHiem + nv.HeSoPhuCapChucVu + nv.HeSoLuongNoiBo + _HeSoVuotKhung + _NhanVien.HeSoBu;
                LuongHeSo = Math.Round(HeSoV2 * _LuongNoiBo * PTLuongV2 / 100, 0, MidpointRounding.AwayFromZero);

                ThamNien = _NgayTinhThamNien.Year - nv.NgayTinhThamNien.Year;
                if (_NgayTinhThamNien.Month < nv.NgayTinhThamNien.Month || (_NgayTinhThamNien.Month == nv.NgayTinhThamNien.Month && _NgayTinhThamNien.Day < nv.NgayTinhThamNien.Day))
                    ThamNien--;
                if (ThamNien < 0) ThamNien = 0;
                LuongThamNien = Math.Round(ThamNien * _LuongThamNien * PTLuongV2 / 100, 0, MidpointRounding.AwayFromZero);
                //-----------------------------------------
                //lưu dữ liệu
                cm.CommandText = "spd_Insert_BangLuong_Ky2";
                cm.CommandTimeout = 0;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@MaBoPhan", nv.MaBoPhan);
                cm.Parameters.AddWithValue("@CMND", nv.CMND);
                cm.Parameters.AddWithValue("@LoaiNV", nv.LoaiNV);
                cm.Parameters.AddWithValue("@MaNgachLuong", nv.TenNgachLuongCoBan);
                cm.Parameters.AddWithValue("@HeSoCoBan", nv.HeSoLuong);
                cm.Parameters.AddWithValue("@HeSoBaoHiem", nv.HeSoLuongBaoHiem);
                cm.Parameters.AddWithValue("@HeSoNoiBo", nv.HeSoLuongNoiBo);
                cm.Parameters.AddWithValue("@PhanTramVuotKhung", nv.HeSoVuotKhung);
                cm.Parameters.AddWithValue("@HeSoVuotKhung", _HeSoVuotKhung);
                cm.Parameters.AddWithValue("@PhanTramVuotKhungBH", nv.HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoVuotKhungBH", _HeSoVuotKhungBH);
                cm.Parameters.AddWithValue("@HeSoPhuCap", nv.HeSoPhuCapChucVu);
                cm.Parameters.AddWithValue("@HeSoDocHai", nv.HeSoDocHai);
                cm.Parameters.AddWithValue("@HeSoBu", nv.HeSoBu);
                cm.Parameters.AddWithValue("@HeSoBoSung", nv.HeSoBoSung);
                cm.Parameters.AddWithValue("@PhuCapHanhChinh", nv.PhuCapHC);
                cm.Parameters.AddWithValue("@LuongKhoan", nv.LuongKhoan);
                cm.Parameters.AddWithValue("@PhanTramNhan", PTLuongV2);
                cm.Parameters.AddWithValue("@LuongNoiBo", _LuongNoiBo);
                cm.Parameters.AddWithValue("@LuongCoBanNN", _LuongCoBan); 
                cm.Parameters.AddWithValue("@DonGiaThamNien", _LuongThamNien);
                cm.Parameters.AddWithValue("@SoNamThamNien", ThamNien);
                cm.Parameters.AddWithValue("@LuongThamNien", LuongThamNien);
                cm.Parameters.AddWithValue("@HeSoLuong", HeSoV2);
                cm.Parameters.AddWithValue("@LuongHeSo", LuongHeSo);
                cm.Parameters.AddWithValue("@TruThueTNCN", _KyLuong.TruThueTNCN);
                cm.Parameters.AddWithValue("@Khoan_Nghi_SoNgay", 0);
                cm.Parameters.AddWithValue("@Khoan_Nghi_Luong", 0);
                cm.Parameters.AddWithValue("@Khoan_BHXH_SoNgay", 0);
                cm.Parameters.AddWithValue("@Khoan_BHXH_Luong", 0);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHXH", 0);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHYT", 0);
                cm.Parameters.AddWithValue("@Khoan_Tru_BHTN", 0);
                cm.Parameters.AddWithValue("@Khoan_Tru_Cong", 0);
                cm.Parameters.AddWithValue("@Tru_CongDoan", 0);
                cm.Parameters.AddWithValue("@Khoan_ThucLanh", 0);
                cm.Parameters.AddWithValue("@NgayBDTinhLuong", _ngayBDTinhLuong);
                cm.Parameters.AddWithValue("@NgayKTTinhLuong", _ngayKTTinhLuong);
                cm.ExecuteNonQuery();
            }
        }

        public void TinhTongThuNhapKy2()
        {
            //thêm vào tổng thu nhập kỳ 2 các số : lương kỳ 1, thù lao, khen thưởng, phụ cấp,... sau đó tính thuế TNCN và cập nhật lại ngân hàng chuyển khoản
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandTimeout = 0;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                {
                    cm.CommandText = "spd_TinhTongThuNhapKy2";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else
                {
                    cm.CommandText = "spd_TinhTongThuNhapKy2_LuongKhoan";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                cm.ExecuteNonQuery();
            }
        }

        public void TinhThueTNCNKy1()
        {
            if (Security.CurrentUser.Info.MaCongTy == 3) //TFS
            {
                using (SqlCommand cm = _connect.CreateCommand())
                {
                    cm.Transaction = _trans;
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandTimeout = 0;
                    cm.CommandText = "spd_TinhThueTNCNKy1";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Ngay", DateTime.Today);
                    cm.ExecuteNonQuery();
                }
            }
        }

        private void TinhSoNgayNghi()
        {
            //tính số ngày nghỉ trừ lương và nhận lương BHXH
            DateTime tungay, denngay;
            bool truluong, bhxh, khongluong1, khongluong2;
            _NghiTruLuong = 0;
            _NghiBHXH = 0;
            _TongSoNgayNghi = 0;
            _NghiKhongLuongDot1 = 0;
            _NghiKhongLuongDot2 = 0;
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandText = "spd_CacNgayNghiTruLuong";
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                cm.Parameters.AddWithValue("@TuNgay", _KyLuong.NgayBatDau);
                cm.Parameters.AddWithValue("@DenNgay", _KyLuong.NgayKetThuc);
                using (Csla.Data.SafeDataReader dr = new Csla.Data.SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        tungay = dr.GetDateTime("TuNgay");
                        denngay = dr.GetDateTime("DenNgay");
                        //if (tungay < _KyLuong.NgayBatDau) tungay = _KyLuong.NgayBatDau;
                        //if (denngay > _KyLuong.NgayKetThuc) denngay = _KyLuong.NgayKetThuc;                      

                        truluong = dr.GetBoolean("TruLuong");
                        bhxh = dr.GetBoolean("BHXH");
                        khongluong1 = dr.GetBoolean("KhongLuongDot1");
                        khongluong2 = dr.GetBoolean("KhongLuongDot2");

                        for (DateTime ngay = tungay; ngay <= denngay; ngay = ngay.AddDays(1))
                            if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday && !_ListHoliday.Contains(ngay))
                            {
                                if (truluong)
                                    _NghiTruLuong += 1;
                                if (bhxh)
                                    _NghiBHXH += 1;
                                if (khongluong1)
                                    _NghiKhongLuongDot1 += 1;
                                if (khongluong2)
                                    _NghiKhongLuongDot2 += 1;

                                _TongSoNgayNghi += 1;
                            }
                    }
                }
            }
        }

        private decimal TinhPTLuongV1()
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Select PhanTram From tblnsPhanTramLuongCoBan Where MaKyTinhLuong=@MaKyTinhLuong AND MaNhanVien = @MaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                try
                {
                    return (decimal)cm.ExecuteScalar();
                }
                catch
                {
                    return 100;
                }
            }
        }

        private decimal TinhPTLuongV2()
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Select PhanTramV2 From tblnsPhanTramLuongCoBan Where MaKyTinhLuong=@MaKyTinhLuong AND MaNhanVien = @MaNhanVien";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                try
                {
                    return (decimal)cm.ExecuteScalar();
                }
                catch
                {
                    return 100;
                }
            }
        }

        /// <summary>
        /// Cập nhật tài khoản ngân hàng chuyển khoản lương đợt 1 cho nhân viên
        /// </summary>
        public void CapNhatNganHangLuongDot1()
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_CapNhatTaiKhoanChuyenLuongDot1";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                cm.Parameters.AddWithValue("@MaNhanVien", _MaNhanVien);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.ExecuteNonQuery();
            }
        }
    }
}

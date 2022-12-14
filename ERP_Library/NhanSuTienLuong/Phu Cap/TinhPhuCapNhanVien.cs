using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
              
namespace ERP_Library
{
    public class TinhPhuCapNhanVien
    {
        private KyTinhLuong _KyLuong, _KyPhuCap;
        private ThongTinNhanVienTinhLuongChild _NhanVien;
        private PhuCapList _phucap;
        private PhuCapFieldList _fieldCongThuc;
        private SqlConnection _connect;
        private SqlTransaction _trans;
        private ThongTinNhanVienTinhLuongList _list;
        private int _DelBoPhan = 0;
        private long _DelNhanVien = 0;
        private List<DateTime> _ListHoliday = new List<DateTime>();
        private List<string> _ListNgoaiGio = new List<string>();
        private NhanVien_CauHinhList _CauHinh;
        
        private decimal _LuongCoBan = 540000;
        private decimal _NgayCong = 26;
        private decimal _SoGioTrongNgay = 8;
        private decimal _LuongNoiBo = 700000;
        private decimal _LuongThamNien = 15000;
        private decimal _PhuCapAnTruaKCT = 0;

        int ThamNien = 0;
        public DateTime _NgayTinhThamNien;
        private int _NhomPhuCap = 0;
        private int _MaLoaiPhuCap = 0;
        decimal sogio = 0;
        decimal soTienMotGio = 0;
        public TinhPhuCapNhanVien(KyTinhLuong KyLuong, KyTinhLuong KyPhuCap, int NhomPhuCap, int MaLoaiPhuCap)
        {
            _KyLuong = KyLuong;
            _NhomPhuCap = NhomPhuCap;
            _MaLoaiPhuCap = MaLoaiPhuCap;
            _KyPhuCap = KyPhuCap;
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
            //tên chấm ngoài giờ
            foreach (ERP_Library.HinhThucTangCaChild i in ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList())
            {
                _ListNgoaiGio.Add("Số " + i.ThoiGian.ToLower() + " " + i.TenLoaiTangCa + "|" + i._maLoaiTangCa);
            }
            _CauHinh = NhanVien_CauHinhList.GetNhanVien_CauHinhList();

            if (_NhomPhuCap == 0)
                _phucap = PhuCapList.GetPhuCapListAll();
            else
            {
                if (_MaLoaiPhuCap == 0)
                    _phucap = PhuCapList.GetPhuCapListByNhomPhuCap(_NhomPhuCap);
                else
                    _phucap = PhuCapList.GetPhuCapListByLoaiPhuCap(_MaLoaiPhuCap);
            }
            _fieldCongThuc = PhuCapFieldList.GetPhuCapFieldListCongThuc();

            //các dữ liệu config
            ERP_Library.Default_Ngay d = ERP_Library.Default_Ngay.GetDefault_Ngay();
            _LuongCoBan = d.LuongCoBan;
            _LuongNoiBo = d.LuongNoiBo;
            _LuongThamNien = d.PhuCapThamNien;
            _NgayCong = d.SoNgayLamViecTrongThang;
            _SoGioTrongNgay = d.SoGioTrongNgay;
            _PhuCapAnTruaKCT = d.PhuCapAnTrua;
        }

        public void XoaDuLieuCu()
        {
            //xóa dữ liệu bảng phụ cấp
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_DuLieuPhuCapCu";
                cm.CommandTimeout = 0;
                cm.Parameters.AddWithValue("@MaBoPhan", _DelBoPhan);
                cm.Parameters.AddWithValue("@MaNhanVien", _DelNhanVien);
                cm.Parameters.AddWithValue("@MaNhomPhuCap", _NhomPhuCap);
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _MaLoaiPhuCap);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                cm.Parameters.AddWithValue("@MaKyPhuCap", _KyPhuCap.MaKy);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.ExecuteNonQuery();
            }
        }

        public void CapNhatTinhTrangChamNgoaiGio()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.CommandText = "spd_CapNhatTinhTrang";
                    cm.Parameters.AddWithValue("@MaNhanVien", _DelNhanVien);
                    cm.Parameters.AddWithValue("@MaLoai", _MaLoaiPhuCap);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", _KyPhuCap.MaKy);
                    cm.Parameters.AddWithValue("@TinhTrang", 0);
                    cm.ExecuteNonQuery();
                }
            }
        }

     
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

        public void GetListData(int MaBoPhan, long MaNhanVien)
        {
            //lấy về danh sách cần tính toán, lưu vào _list
            _list = ThongTinNhanVienTinhLuongList.GetThongTinNhanVienTinhPhuCap(MaBoPhan, MaNhanVien, _KyLuong.MaKy);
            _DelBoPhan = MaBoPhan;
            _DelNhanVien = MaNhanVien;
        }

        public ThongTinNhanVienTinhLuongList List
        {
            get
            {
                return _list;
            }
        }


        public void TinhPhuCap(ThongTinNhanVienTinhLuongChild nv)
        {
            _NhanVien = nv;
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;
                cm.CommandType = System.Data.CommandType.Text;

                //tính số năm thâm niên
                ThamNien = _NgayTinhThamNien.Year - _NhanVien.NgayTinhThamNien.Year;
                TinhPhuCap();
            }
        }

        private void TinhPhuCap()
        {
            //duyệt qua tất cả phụ cấp, nếu hợp lệ thì insert vào database
            foreach (PhuCapChild pc in _phucap)
            {
                //kiểm tra điều kiện của phụ cấp
                bool dkok = true;
                foreach (DieuKienPhuCapChild dk in pc.CongThucDieuKien)
                {
                    try
                    {
                        dkok = KiemTraDieuKienPhuCap(dk);
                    }
                    catch (Exception ex)
                    {
                        dkok = false;
                        System.Windows.Forms.MessageBox.Show("Có lỗi kiểm tra điều kiện của nhân viên " + _NhanVien.TenNhanVien + "\r\n" + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    if (!dkok) break; //các dk AND với nhau, nếu có 1 False thì thoát
                }

                //điều kiện hợp lệ, tính số tiền phụ cấp và insert số tiền vào database
                if (dkok)
                {
                    decimal SoTien = 0;
                    string CongThuc = pc.CongThuc;
                    //foreach (PhuCapFieldChild i in _fieldCongThuc)
                    //{
                    //    CongThuc = CongThuc.Replace("[" + i.TenField + "]", "@(" + i.TenField + ")");
                    //}
                    CongThuc = CongThuc.Replace("[", "@(");
                    CongThuc = CongThuc.Replace("]", ")");
                    try
                    {
                        SoTien = TinhSoTienPhuCap(CongThuc);
                    }
                    catch (Exception ex)
                    {
                        SoTien = 0;
                        System.Windows.Forms.MessageBox.Show("Có lỗi trong công thức tính của nhân viên " + _NhanVien.TenNhanVien + "\r\n" + ex.Message, "Lỗi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);                       
                    }


                    if (SoTien > 0)
                        using (SqlCommand cm = _connect.CreateCommand())
                        {
                            cm.Transaction = _trans;
                            cm.CommandType = System.Data.CommandType.Text;
                            cm.CommandText = "Insert into tblnsBangLuong_PhuCap (MaKyTinhLuong, MaKyPhuCap, MaNhanVien, TenPhuCap, SoTien, TinhThueTNCN, PhuCap, ThueSuat, MaBoPhan, MaLoaiPhuCap, TienThue, UserInput, CongThuc, NgayLap, UserID, TenBoPhan, TenNhanVien, TongSoGio, TienMotGio, SoGioLo, SoGioDung, SoTienChiuThue, ThanhToan) " +
                                    "Values (@MaKyTinhLuong, @MaKyPhuCAp, @MaNhanVien, @TenPhuCap, @SoTien, @TinhThueTNCN, @SoTien, 0, @MaBoPhan, @MaLoaiPhuCap, 0, 0, @CongThuc, @NgayLap, @UserID, @TenBoPhan, @TenNhanVien,@TongSoGio, @TienMotGio, @SoGioLo, @SoGioDung, @SoTienChiuThue, @ThanhToan )";

                            cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                            cm.Parameters.AddWithValue("@MaKyPhuCap", _KyPhuCap.MaKy);
                            cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                            cm.Parameters.AddWithValue("@TenPhuCap", pc.TenLoaiPhuCap);
                            cm.Parameters.AddWithValue("@SoTien", SoTien);
                            cm.Parameters.AddWithValue("@TinhThueTNCN", pc.TinhThueTNCN);
                            cm.Parameters.AddWithValue("@MaBoPhan", _NhanVien.MaBoPhan);                            
                            cm.Parameters.AddWithValue("@MaLoaiPhuCap", pc.MaLoaiPhuCap);
                            cm.Parameters.AddWithValue("@ThanhToan", 0);

                            // them cot so tien chiu thue
                            if (pc.MaLoaiPhuCap == 9)// phu cấp ăn trưa
                            {
                                cm.Parameters.AddWithValue("@SoTienChiuThue", SoTien -_PhuCapAnTruaKCT);
                            }
                            else if (pc.MaLoaiPhuCap == 21)// ngoai gio ngay thuong
                            { 
                                 cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(SoTien * Convert.ToDecimal(0.5)/Convert.ToDecimal(1.5),0));
                            }
                            else if (pc.MaLoaiPhuCap == 22)//ngoài gio t7,cn
                            {
                                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(SoTien / Convert.ToDecimal(2), 0));
                            }
                            else if (pc.MaLoaiPhuCap == 23)// ngoai gio ngay le
                            {
                                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(SoTien * Convert.ToDecimal(2) / Convert.ToDecimal(3), 0));
                            }
                            else
                            {
                                foreach( LoaiPhuCapChild loaipc in LoaiPhuCapList.GetLoaiPhuCapList())
                                    if (pc.MaLoaiPhuCap == loaipc.MaLoaiPhuCap)
                                    {
                                        cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(SoTien *loaipc.PTThuNhapTinhThue/100,0));
                                    }
                            }

                            //end so tien chiu thue
                            cm.Parameters.AddWithValue("@CongThuc", CongThuc);
                            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                            cm.Parameters.AddWithValue("@NgayLap", DateTime.Today);
                            cm.Parameters.AddWithValue("@TenBoPhan", _NhanVien.TenBoPhan);
                            cm.Parameters.AddWithValue("@TenNhanVien", _NhanVien.TenNhanVien);

                            decimal TongSoGio = 0;
                            TongSoGio = TinhTongSoGioVaTien(_KyLuong.MaKy, _KyPhuCap.MaKy, _NhanVien.MaNhanVien, pc.MaLoaiPhuCap);
                            cm.Parameters.AddWithValue("@TongSoGio", TongSoGio);
                            if (TongSoGio != 0)
                                cm.Parameters.AddWithValue("@TienMotGio", SoTien / TongSoGio);//Math.Round(SoTien / TongSoGio, 0, MidpointRounding.AwayFromZero));
                            else
                                cm.Parameters.AddWithValue("@TienMotGio", 0);
                            Decimal TongSoGioTrongNam = 0;
                            TongSoGioTrongNam = TinhTongSoGioTrongNam(_NhanVien.MaNhanVien, _KyLuong.Nam, _KyLuong.MaKy, _KyPhuCap.MaKy,pc.MaLoaiPhuCap);
                            if (TongSoGioTrongNam > 200)
                            {
                                cm.Parameters.AddWithValue("@SoGioLo", TongSoGio);
                                cm.Parameters.AddWithValue("@SoGioDung", 0);
                            }
                            else if (TongSoGioTrongNam + TongSoGio > 200)
                            {
                                cm.Parameters.AddWithValue("@SoGioLo", (TongSoGioTrongNam + TongSoGio) - 200);
                                cm.Parameters.AddWithValue("@SoGioDung", 200 - TongSoGioTrongNam);
                            }
                            else
                            {
                                cm.Parameters.AddWithValue("@SoGioLo", 0);
                                cm.Parameters.AddWithValue("@SoGioDung", TongSoGio);
                            }
                            cm.ExecuteNonQuery();
                            CapNhatSoGioDaThanhToan(_KyLuong.MaKy, _KyPhuCap.MaKy, _NhanVien.MaNhanVien, pc.MaLoaiPhuCap);
                            //CapNhatThanhToanChoPhuCap(_KyLuong.MaKy, _NhanVien.MaNhanVien, pc.MaLoaiPhuCap);
                
                        }
                }
            }
        }

        public decimal TinhTongSoGioVaTien(int MaKyTinhLuong, int MaKyPhuCap, long MaNhanVien, int MaLoaiPhuCap)
        {
            decimal kiemtra = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "[spd_ChamCongTinhPhuCap_SoGio]";
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@MaKyTinhLuong",MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cm.Parameters.AddWithValue("@MaLoai", MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@MaKyPhuCap",MaKyPhuCap);
                        try
                        {
                            kiemtra = Convert.ToDecimal(cm.ExecuteScalar());
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kiemtra;
        }

        public void CapNhatSoGioDaThanhToan(int MaKyTinhLuong, int MaKyPhuCap, long MaNhanVien, int MaLoaiPhuCap)
        {           
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "[spd_CapNhatTinhTrang]";
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cm.Parameters.AddWithValue("@MaLoai", MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", MaKyPhuCap);
                        cm.Parameters.AddWithValue("@TinhTrang", 1);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }


        public decimal TinhTongSoGioTrongNam(long MaNhanVien, int Nam, int MaKyTinhLuong, int MaKyPhuCap, int MaLoaiPhuCap)
        {
            decimal kiemtra = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "[TinhTongSoGioTangCa]";
                        cm.CommandType = System.Data.CommandType.StoredProcedure;                        
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cm.Parameters.AddWithValue("@Nam", Nam);
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", MaKyPhuCap);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", MaLoaiPhuCap);
                        cm.Parameters.AddWithValue("@SoGioOut", kiemtra);
                        cm.Parameters["@SoGioOut"].Direction = ParameterDirection.Output;
                        try
                        {
                            cm.ExecuteNonQuery();
                            kiemtra = (decimal)cm.Parameters["@SoGioOut"].Value;
                        }
                       catch
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return kiemtra;
        }
        public void CapNhatThanhToanChoPhuCap(int MaKyTinhLuong, long MaNhanVien, int MaLoaiPhuCap)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "spd_CapNhatTaiThanhToanChoPhuCap";
                        cm.CommandTimeout = 0;
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", MaLoaiPhuCap);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private decimal TinhSoTienPhuCap(string CongThuc)
        {
            ExpressionEvaluation.ExpressionEval ex = new ERP_Library.ExpressionEvaluation.ExpressionEval();
            ex.Expression = CongThuc;
            if (CongThuc.Contains("Lương cơ bản NN"))
                ex.SetVariable("Lương cơ bản NN", _LuongCoBan);
            
            if (CongThuc.Contains("Lương đợt 1"))
            {
                using (SqlCommand cm = _connect.CreateCommand())
                {
                    cm.Transaction = _trans;
                    cm.CommandText = "Select ThucLanhLuongV1 From tblnsBangLuong Where MaKyTinhLuong = @MaKyTinhLuong AND MaNhanVien = @MaNhanVien";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                    cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                    ex.SetVariable("Lương đợt 1", cm.ExecuteScalar());
                }
            }
            
            if (CongThuc.Contains("Đơn giá lương nội bộ"))
                ex.SetVariable("Đơn giá lương nội bộ", _LuongNoiBo);
            
            if (CongThuc.Contains("Đơn giá lương thâm niên"))
                ex.SetVariable("Đơn giá lương thâm niên", _LuongThamNien);
            
            if (CongThuc.Contains("Số năm thâm niên"))
                ex.SetVariable("Số năm thâm niên", ThamNien);
            
            if (CongThuc.Contains("Hệ số lương"))
                ex.SetVariable("Hệ số lương", _NhanVien.HeSoLuong);
            
            if (CongThuc.Contains("Hệ số nội bộ"))
                ex.SetVariable("Hệ số nội bộ", _NhanVien.HeSoLuongNoiBo);
            
            if (CongThuc.Contains("Hệ số phụ cấp"))
                ex.SetVariable("Hệ số phụ cấp", _NhanVien.HeSoPhuCapChucVu);
            
            if (CongThuc.Contains("Phần trăm vượt khung lương"))
                ex.SetVariable("Phần trăm vượt khung lương", _NhanVien.HeSoVuotKhung);
                      
            if (CongThuc.Contains("Hệ số vượt khung lương"))
                ex.SetVariable("Hệ số vượt khung lương", Math.Round(_NhanVien.HeSoVuotKhung * _NhanVien.HeSoLuong / 100,3, MidpointRounding.AwayFromZero));

            if (CongThuc.Contains("Phần trăm vượt khung bảo hiểm"))
                ex.SetVariable("Phần trăm vượt khung bảo hiểm", _NhanVien.HeSoVuotKhungBH);

            if (CongThuc.Contains("Hệ số vượt khung bảo hiểm"))
                ex.SetVariable("Hệ số vượt khung bảo hiểm", Math.Round(_NhanVien.HeSoVuotKhungBH * _NhanVien.HeSoLuongBaoHiem / 100,3, MidpointRounding.AwayFromZero));

            if (CongThuc.Contains("Số ngày làm việc trong tháng"))
                ex.SetVariable("Số ngày làm việc trong tháng", TinhSoNgayLamViec());
            
            if (CongThuc.Contains("Hệ số bổ sung"))
                ex.SetVariable("Hệ số bổ sung", _NhanVien.HeSoLuongBoSung);

            if (CongThuc.Contains("Hệ số độc hại"))
                ex.SetVariable("Hệ số độc hại", _NhanVien.HeSoDocHai);
            
            if (CongThuc.Contains("Hệ số bù"))
                ex.SetVariable("Hệ số bù", _NhanVien.HeSoBu);

            if (CongThuc.Contains("Hệ số BHXH"))
                ex.SetVariable("Hệ số BHXH", _NhanVien.HeSoLuongBaoHiem + Math.Round((_NhanVien.HeSoVuotKhungBH * _NhanVien.HeSoLuongBaoHiem / 100),0, MidpointRounding.AwayFromZero));

            if (CongThuc.Contains("Tổng hệ số lương cơ bản"))
                ex.SetVariable("Tổng hệ số lương cơ bản", _NhanVien.HeSoLuong + _NhanVien.HeSoPhuCapChucVu + Math.Round(_NhanVien.HeSoVuotKhung * _NhanVien.HeSoLuong / 100, 3, MidpointRounding.AwayFromZero) + _NhanVien.HeSoBu);

            if (CongThuc.Contains("Tổng hệ số lương nội bộ"))
                ex.SetVariable("Tổng hệ số lương nội bộ", _NhanVien.HeSoLuongNoiBo + _NhanVien.HeSoLuong + _NhanVien.HeSoPhuCapChucVu + Math.Round(_NhanVien.HeSoVuotKhung * _NhanVien.HeSoLuong / 100, 3, MidpointRounding.AwayFromZero) + _NhanVien.HeSoBu);
            //giá trị chấm ngoài giờ
            foreach (string s in _ListNgoaiGio)
            {
                string[] arr = s.Split("|".ToCharArray());
                int maloai = Convert.ToInt32(arr[1]);
                sogio = 0;
                if (CongThuc.Contains(arr[0]))
                {
                    string v = LoaiBoKyTuDacBiet(arr[0]);
                    CongThuc = CongThuc.Replace(arr[0], v);
                    ex.Expression = CongThuc;

                    using (SqlCommand cm = _connect.CreateCommand())
                    {
                        cm.Transaction = _trans;
                        cm.CommandText = "spd_ChamCongTinhPhuCap";
                        cm.CommandType = System.Data.CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", _KyLuong.MaKy);
                        cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                        cm.Parameters.AddWithValue("@MaLoai", maloai);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", _KyPhuCap.MaKy);
                        try
                        {                            
                            sogio = Convert.ToDecimal(cm.ExecuteScalar());
                        }
                        catch
                        {
                        }
                    }
                    ex.SetVariable(v, sogio);
                }
            }

            try
            {
                return Math.Round(Convert.ToDecimal(ex.Evaluate()), 0, MidpointRounding.AwayFromZero);
            }
            catch 
            {
                return 0;
            }
        }

        private string LoaiBoKyTuDacBiet(string s)
        {
            string kq = "";
            kq = s.Replace(".", "");
            kq = kq.Replace(",", "");
            kq = kq.Replace(";", "");
            kq = kq.Replace("+", "");
            kq = kq.Replace("-", "");
            kq = kq.Replace("*", "");
            kq = kq.Replace("/", "");
            kq = kq.Replace(":", "");
            kq = kq.Replace(@"\", "");
            kq = kq.Replace(@"(", "");
            kq = kq.Replace(@")", "");
            return kq;
        }

        private bool KiemTraDieuKienPhuCap(DieuKienPhuCapChild dk)
        {
            if (dk.DieuKien == "Toàn đài")
                return true;
            else
            {
                ExpressionEvaluation.ExpressionEval ex = new ERP_Library.ExpressionEvaluation.ExpressionEval();
                ex.Expression = "@(DieuKien)" + dk.CongThuc + "@(GiaTri)";
                ex.SetVariable("GiaTri", LoaiBoKyTuDacBiet(dk.GiaTri));
                switch (dk.DieuKien)
                {
                    case "Bộ phận":
                        ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(_NhanVien.TenBoPhan));
                        break;
                    case "Chức vụ":
                        ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(_NhanVien.TenChucVu));
                        break;
                    case "Chức danh":
                        ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(_NhanVien.TenChucDanh));
                        break;
                    case "Trách nhiệm":
                        break;
                    case "Công việc":
                        break;
                    case "Ngày vào Đài":
                        try
                        {
                            ex.SetVariable("DieuKien", _NhanVien.NgayTinhThamNien);
                            ex.SetVariable("GiaTri", DateTime.ParseExact(dk.GiaTri, "dd/MM/yy", null));
                        }
                        catch
                        {
                        }
                        break;
                    case "Số năm thâm niên":
                        ex.SetVariable("DieuKien", this.ThamNien);
                        break;
                    case "Loại nhân viên":
                        foreach (LoaiNhanVienChild item in LoaiNhanVienList.GetLoaiNhanVienList())
                            if (item.MaLoaiNhanVien == _NhanVien.LoaiNV)
                            {
                                ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(item.TenLoaiNhanVien));
                                break;
                            }
                        break;
                    case "Phụ cấp hành chính":
                        if (_NhanVien.PhuCapHC)
                            ex.SetVariable("DieuKien", "True");
                        else
                            ex.SetVariable("DieuKien", "False");
                        break;
                    case "Giới Tính":
                        ex.SetVariable("DieuKien",_NhanVien.TenGioiTinh);
                        break;
                    case "Số ngày làm việc trong tháng":
                        ex.SetVariable("DieuKien", TinhSoNgayLamViec());
                        break;
                    case "Kỳ tính lương":
                        ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(_KyLuong.TenKy));
                        break;
                    case "Nhân viên":
                        ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(_NhanVien.MaQLNhanVien + " - " + _NhanVien.TenNhanVien));
                        break;
                    case "Loại độc hại":
                        using (SqlCommand cm = _connect.CreateCommand())
                        {
                            cm.Transaction = _trans;
                            cm.CommandText = "Select B.Ten From tblnsNhanVien A Inner Join tblnsNhanVien_DocHai B On A.MaDocHai = B.MaDocHai Where MaNhanVien=@MaNhanVien";
                            cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                            try
                            {
                                ex.SetVariable("DieuKien", LoaiBoKyTuDacBiet(Convert.ToString(cm.ExecuteScalar())));
                            }
                            catch
                            {
                                ex.SetVariable("DieuKien", "");
                            }
                        }
                        break;
                    case "Hệ số phụ cấp":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoPhuCapChucVu);
                        break;
                    case "Hệ số nội bộ":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoLuongNoiBo);
                        break;
                    case "Hệ số bù":
                        ex.SetVariable("GiaTri",dk.GiaTri);
                        ex.SetVariable("DieuKien", _NhanVien.HeSoBu);
                        break;
                    case "Hệ số độc hại":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoDocHai);
                        break;
                    case "Hệ số bổ sung":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoBoSung);
                        break;
                    case "Hệ số BHXH":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoLuongBaoHiem);
                        break;
                    case "Hệ số vượt khung lương":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoVuotKhung);
                        break;
                    case "Hệ số vượt khung bảo hiểm":
                        ex.SetVariable("DieuKien", _NhanVien.HeSoVuotKhungBH);
                        break;    
                    default:
                        foreach (NhanVien_CauHinh item in _CauHinh)
                            if (item.Ten == dk.DieuKien)
                            {
                                //lấy dữ liệu nhân viên
                                using (SqlCommand cm = _connect.CreateCommand())
                                {
                                    cm.Transaction = _trans;
                                    cm.CommandText = "Select IsNull(DuLieu, '') From tblnsNhanVien_DuLieu Where MaNhanVien = @MaNhanVien AND MaCauHinh = @MaCauHinh";
                                    cm.Parameters.AddWithValue("@MaNhanVien", _NhanVien.MaNhanVien);
                                    cm.Parameters.AddWithValue("@MaCauHinh", item.MaCauHinh);
                                    try
                                    {
                                        string s = Convert.ToString(cm.ExecuteScalar());
                                        s = LoaiBoKyTuDacBiet(s);
                                        ex.SetVariable("DieuKien", s);
                                    }
                                    catch 
                                    {
                                        ex.SetVariable("DieuKien", "");
                                    }
                                }
                            }
                        break;
                }

                try
                {
                    return ex.EvaluateBool();
                }
                catch
                {
                    return false;
                }
            }
        }

        private int TinhSoNgayLamViec()
        {
            int kq = 0;
            kq = _KyLuong.SoNgay;
            DateTime tungay, denngay;

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
                        if (tungay < _KyLuong.NgayBatDau) tungay = _KyLuong.NgayBatDau;
                        if (denngay > _KyLuong.NgayKetThuc) denngay = _KyLuong.NgayKetThuc;
                        if (tungay == _KyLuong.NgayBatDau && denngay == _KyLuong.NgayKetThuc)
                            return 0;

                        for (DateTime ngay = tungay; ngay <= denngay; ngay = ngay.AddDays(1))
                            if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday && !_ListHoliday.Contains(ngay))
                                kq--;
                    }
                }
            }
           return kq;

        }
    }
}

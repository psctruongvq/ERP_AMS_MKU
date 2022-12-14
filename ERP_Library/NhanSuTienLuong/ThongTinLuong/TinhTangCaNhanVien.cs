using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Csla.Data;

namespace ERP_Library
{
    public class TinhTangCaNhanVien
    {
        public class NhanVien
        {
            public long MaNhanVien;
            public int MaBoPhan;
            public NhanVien(int maBoPhan, long maNhanVien)
            {
                MaBoPhan = maBoPhan;
                MaNhanVien = maNhanVien;
            }
        }

        private KyTinhLuong _KyLuong;
        private SqlConnection _connect;
        private SqlTransaction _trans;
        private List<NhanVien> _list = new List<NhanVien>();
        private List<DateTime> _ListHoliday = new List<DateTime>();

        public TinhTangCaNhanVien(KyTinhLuong KyLuong)
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

        //lấy về danh sách cần tính toán, lưu vào _list

        public void GetListData()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = "Select DISTINCT MaBoPhan, MaNhanVien From tblnsBangTangCa Where NgayTangCa >= @TuNgay AND NgayTangCa <= @DenNgay";
                    cm.Parameters.AddWithValue("@TuNgay", _KyLuong.NgayBatDau);
                    cm.Parameters.AddWithValue("@DenNgay", _KyLuong.NgayKetThuc);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            _list.Add(new NhanVien(dr.GetInt32("MaBoPhan"), dr.GetInt64("MaNhanVien")));
                    }
                }
                cn.Close();
            }
        }

        public void GetListByBoPhan(int MaBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = "Select DISTINCT MaBoPhan, MaNhanVien From tblnsBangTangCa Where NgayTangCa >= @TuNgay AND NgayTangCa <= @DenNgay AND MaBoPhan = @MaBoPhan";
                    cm.Parameters.AddWithValue("@TuNgay", _KyLuong.NgayBatDau);
                    cm.Parameters.AddWithValue("@DenNgay", _KyLuong.NgayKetThuc);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            _list.Add(new NhanVien(dr.GetInt32("MaBoPhan"), dr.GetInt64("MaNhanVien")));
                    }
                }
                cn.Close();
            }
        }

        public void GetListByNhanVien(long MaNhanVien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = System.Data.CommandType.Text;
                    cm.CommandText = "Select DISTINCT MaBoPhan, MaNhanVien From tblnsBangTangCa Where NgayTangCa >= @TuNgay AND NgayTangCa <= @DenNgay AND MaNhanVien = @MaNhanVien";
                    cm.Parameters.AddWithValue("@TuNgay", _KyLuong.NgayBatDau);
                    cm.Parameters.AddWithValue("@DenNgay", _KyLuong.NgayKetThuc);
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            _list.Add(new NhanVien(dr.GetInt32("MaBoPhan"), dr.GetInt64("MaNhanVien")));
                    }
                }
                cn.Close();
            }
        }

        public List<NhanVien> List
        {
            get
            {
                return _list;
            }
        }

        public void TinhTangCa(NhanVien nv)
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;

                //xóa dữ liệu cũ
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Delete From tblnsBaoCaoTangCa Where MaNhanVien=@MaNhanVien AND MaKyTinhLuong=@KyLuong";
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@KyLuong", _KyLuong.MaKy);
                cm.ExecuteNonQuery();

                //tìm trạng thái của 31 ngày tăng ca
                decimal[] s = new decimal[31];
                cm.CommandText = "Select IsNull(Sum(SoGio),0) From tblnsBangTangCa Where MaNhanVien = @MaNhanVien AND NgayTangCa = @Ngay";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@Ngay", DateTime.Today);
                decimal SoGioNgayThuong, SoGioNgayLe, SoGioT7CN;
                SoGioNgayThuong = 0;
                SoGioNgayLe = 0;
                SoGioT7CN = 0;
                for (DateTime ngay = _KyLuong.NgayBatDau; ngay <= _KyLuong.NgayKetThuc; ngay = ngay.AddDays(1))
                {
                    cm.Parameters["@Ngay"].Value = ngay;
                    s[ngay.Day - 1] = Convert.ToDecimal(cm.ExecuteScalar());
                    if (_ListHoliday.Contains(ngay))
                        SoGioNgayLe += s[ngay.Day - 1];
                    else if (ngay.DayOfWeek == DayOfWeek.Saturday || ngay.DayOfWeek == DayOfWeek.Sunday)
                        SoGioT7CN += s[ngay.Day - 1];
                    else
                        SoGioNgayThuong += s[ngay.Day - 1];
                }

                //thêm dữ liệu mới
                string sSQL = "Insert into tblnsBaoCaoTangCa (MaBoPhan, MaNhanVien, MaKyTinhLuong";
                for (int i = 1; i <= 31; i++)
                    sSQL += ", Ngay" + i;
                sSQL += ", SoGioTangCaNgayThuong, SoGioTangCaT7CN, SoGioTangCaNgayLe, TongSoGioTangCa) Values (" + nv.MaBoPhan + ", " + nv.MaNhanVien + ", " + _KyLuong.MaKy;

                cm.Parameters.Clear();
                for (int i = 1; i <= 31; i++)
                {
                    sSQL += ", @Ngay" + i;
                    cm.Parameters.AddWithValue("@Ngay" + i, s[i - 1]);
                }
                sSQL += ", @SoGioTangCaNgayThuong, @SoGioTangCaT7CN, @SoGioTangCaNgayLe, @TongSoGioTangCa)";
                cm.CommandText = sSQL;
                cm.Parameters.AddWithValue("@SoGioTangCaNgayThuong", SoGioNgayThuong);
                cm.Parameters.AddWithValue("@SoGioTangCaNgayLe", SoGioNgayLe);
                cm.Parameters.AddWithValue("@SoGioTangCaT7CN", SoGioT7CN);
                cm.Parameters.AddWithValue("@TongSoGioTangCa", SoGioNgayThuong + SoGioNgayLe + SoGioT7CN);
                cm.ExecuteNonQuery();
            }
        }
    }
}

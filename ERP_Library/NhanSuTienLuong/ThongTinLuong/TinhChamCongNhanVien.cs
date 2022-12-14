using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Csla.Data;

namespace ERP_Library
{
    public class TinhChamCongNhanVien
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

        public TinhChamCongNhanVien(KyTinhLuong KyLuong)
        {
            _KyLuong = KyLuong;
        }

        public void Begin()
        {
            _connect = new SqlConnection(Database.ERP_Connection);
            _connect.Open();
            _trans = _connect.BeginTransaction();
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
                    cm.CommandText = "Select MaBoPhan, MaNhanVien From tblnsNhanVien";
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
                    cm.CommandText = "Select MaBoPhan, MaNhanVien From tblnsNhanVien Where MaBoPhan = @MaBoPhan";
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
                    cm.CommandText = "Select MaBoPhan, MaNhanVien From tblnsNhanVien Where MaNhanVien = @MaNhanVien";
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

        public void TinhCong(NhanVien nv)
        {
            using (SqlCommand cm = _connect.CreateCommand())
            {
                cm.Transaction = _trans;

                //xóa dữ liệu cũ
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "Delete From tblnsBangCong Where MaNhanVien=@MaNhanVien AND MaKyTinhLuong=@KyLuong";
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@KyLuong", _KyLuong.MaKy);
                cm.ExecuteNonQuery();

                //tìm trạng thái của 31 ngày công
                string[] s = new string[31];
                cm.CommandText = "Select dbo.fn_MaNgayCongNhanVien(@MaNhanVien, @Ngay)";
                cm.Parameters.Clear();
                cm.Parameters.AddWithValue("@MaNhanVien", nv.MaNhanVien);
                cm.Parameters.AddWithValue("@Ngay", DateTime.Today);
                for (DateTime ngay = _KyLuong.NgayBatDau; ngay <= _KyLuong.NgayKetThuc; ngay = ngay.AddDays(1))
                {
                    cm.Parameters["@Ngay"].Value = ngay;
                    if (ngay.DayOfWeek == DayOfWeek.Saturday || ngay.DayOfWeek == DayOfWeek.Sunday)
                        s[ngay.Day - 1] = "";
                    else
                        s[ngay.Day - 1] = (string)cm.ExecuteScalar();
                }

                //thêm dữ liệu mới
                string sSQL = "Insert into tblnsBangCong (MaBoPhan, MaNhanVien, MaKyTinhLuong";
                for (int i = 1; i <= 31; i++)
                    sSQL += ", Ngay" + i;
                sSQL += ") Values (" + nv.MaBoPhan + ", " + nv.MaNhanVien + ", " + _KyLuong.MaKy;
                for (int i = 0; i < 31; i++)
                    sSQL += ", N'" + s[i] + "'";
                sSQL += ")";
                cm.CommandText = sSQL;
                cm.Parameters.Clear();
                cm.ExecuteNonQuery();
            }
        }
    }
}

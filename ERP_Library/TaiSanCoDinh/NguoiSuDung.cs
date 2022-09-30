using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NguoiSuDung: BusinessBase<NguoiSuDung>
    {
        protected override object GetIdValue()
        {
            return _MaNguoiSuDung;
        }

        #region Khai Báo Biến

        long _MaNguoiSuDung;
        public long MaNguoiSuDung
        {
            get
            {
                CanReadProperty(true);
                return _MaNguoiSuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNguoiSuDung.Equals(value))
                {
                    _MaNguoiSuDung = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenDangNhap;
        public String TenDangNhap
        {
            get
            {
                CanReadProperty(true);
                return _TenDangNhap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenDangNhap.Equals(value))
                {
                    _TenDangNhap = value;
                    PropertyHasChanged();
                }
            }
        }

        long _maNhanVien;
        public long MaNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MatKhau;
        public String MatKhau
        {
            get
            {
                CanReadProperty(true);
                return _MatKhau;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MatKhau.Equals(value))
                {
                    _MatKhau = value;
                    PropertyHasChanged();
                }
            }
        }
        
        #endregion       

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public long MaNguoiSuDung;

            public Criteria(long maNguoiSuDung)
            {
                MaNguoiSuDung = maNguoiSuDung;
            }
        }

        #endregion

        #region Static Methods

        public override NguoiSuDung Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNguoiSuDung));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }

        private NguoiSuDung(SafeDataReader dr)
        {
            MarkAsChild();
            _MaNguoiSuDung = dr.GetInt64("MaNguoiSuDung");
            _TenDangNhap = dr.GetString("TenDangNhap");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _MatKhau = dr.GetString("MatKhau");
            MarkOld();
        }

        public static NguoiSuDung NewNguoiSuDung()
        {
            return new NguoiSuDung();
        }

        public static NguoiSuDung NewNguoiSuDung(long maNguoiSuDung, string tenDangNhap, int maNhanVien, string matKhau)
        {
            NguoiSuDung nsd = new NguoiSuDung();
            nsd._MaNguoiSuDung = maNguoiSuDung;
            nsd._TenDangNhap = tenDangNhap;
            nsd._maNhanVien = maNhanVien;
            nsd._MatKhau = matKhau;
            nsd.MarkOld();
            return nsd;
        }

        public static NguoiSuDung GetNguoiSuDung(long maNguoiSuDung)
        {
            return (NguoiSuDung)DataPortal.Fetch<NguoiSuDung>(new Criteria(maNguoiSuDung));
        }

        public static NguoiSuDung GetNguoiSuDung(SafeDataReader dr)
        {
            return new NguoiSuDung(dr);            
        }

        public static void DeleteNguoiSuDung(long maNguoiSuDung)
        {
            DataPortal.Delete(new Criteria(maNguoiSuDung));
        }

        #endregion

        #region Constructors

        private NguoiSuDung()
        {
            // Prevent direct creation
            _MaNguoiSuDung = 0;
            _TenDangNhap = String.Empty;
            _maNhanVien = 0;
            _MatKhau = String.Empty;
            MarkAsChild();
        }

        #endregion

        #region Data Access

        #region load tất cả cả

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                Criteria crit = (Criteria)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_NguoiSuDung";
                        cm.Parameters.AddWithValue("@MaNguoiSuDung", crit.MaNguoiSuDung);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaNguoiSuDung = dr.GetInt64("MaNguoiSuDung");
                                _TenDangNhap = dr.GetString("TenDangNhap");
                                if (dr.GetInt64("MaNhanVien") != 0)
                                {
                                    _maNhanVien = dr.GetInt64("MaNhanVien");
                                }
                                _MatKhau = dr.GetString("MatKhau");
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_NguoiSuDung";
                    cm.Parameters.AddWithValue("@MaNguoiSuDung", _MaNguoiSuDung);
                    cm.Parameters.AddWithValue("@TenDangNhap", _TenDangNhap);
                    cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                    cm.Parameters.AddWithValue("@MatKhau", _MatKhau);
                    cm.ExecuteNonQuery();
                }
            }
        }

        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_NguoiSuDung";
                    cm.Parameters.AddWithValue("@MaNguoiSuDung", _MaNguoiSuDung);
                    cm.Parameters.AddWithValue("@TenDangNhap", _TenDangNhap);
                    cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                    cm.Parameters.AddWithValue("@MatKhau", _MatKhau);
                    
                    cm.ExecuteNonQuery();
                    // make sure we're marked as an old object
                    MarkOld();
                }
            }
        }

        #region Delete

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_NguoiSuDung";
                    cm.Parameters.AddWithValue("@MaNguoiSuDung", crit.MaNguoiSuDung);
                    cm.ExecuteNonQuery();
                }
            }
        }
        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNguoiSuDung));
        }
        #endregion

        #endregion

        #endregion

    }
}

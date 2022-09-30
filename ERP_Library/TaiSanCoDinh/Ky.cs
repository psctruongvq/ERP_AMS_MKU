using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class Ky : BusinessBase<Ky>
    {
        protected override object GetIdValue()
        {
            return _MaKy;
        }

        #region Khai báo biến

        int _MaKy;
        public int MaKy
        {
            get
            {
                CanReadProperty(true);
                return _MaKy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaKy.Equals(value))
                {
                    _MaKy = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenKy;
        public String TenKy
        {
            get
            {
                CanReadProperty(true);
                return _TenKy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenKy.Equals(value))
                {
                    _TenKy = value;
                    PropertyHasChanged();
                }
            }
        }

        Boolean _KhoaSo;
        public Boolean KhoaSo
        {
            get
            {
                CanReadProperty(true);
                return _KhoaSo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_KhoaSo.Equals(value))
                {
                    _KhoaSo = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayBatDau;
        public DateTime NgayBatDau
        {
            get
            {
                CanReadProperty(true);
                return _NgayBatDau;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayBatDau.Equals(value))
                {
                    _NgayBatDau = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayKetThuc;
        public DateTime NgayKetThuc
        {
            get
            {
                CanReadProperty(true);
                return _NgayKetThuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayKetThuc.Equals(value))
                {
                    _NgayKetThuc = value;
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
            public int MaKy;

            public Criteria(int maKy)
            {
                MaKy = maKy ;
            }
        }

        private class Criteria_maPhieuKiemKeTonKho
        {
            // Add criteria here
            public long _maPhieuKiemKeTonKho;

            public Criteria_maPhieuKiemKeTonKho(long maPhieuKiemKeTonKho)
            {
                _maPhieuKiemKeTonKho = maPhieuKiemKeTonKho;
            }
        }

        #endregion

        #region Constructors

        private Ky()
        {
             // Prevent direct creation
            _MaKy = 0;
            _TenKy = String.Empty;
            _KhoaSo = false;
            _NgayBatDau = DateTime.Today;
            _NgayKetThuc = DateTime.Today;
            MarkAsChild();        
        }

        #endregion

        #region Static Methods
        public override Ky Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaKy));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    
         
        private Ky(SafeDataReader dr)
        {
            MarkAsChild();           
            _MaKy = dr.GetInt32("MaKy");
            _TenKy = dr.GetString("TenKy");
            _KhoaSo = dr.GetBoolean("KhoaSo");
            _NgayBatDau = dr.GetDateTime("NgayBatDau");
            _NgayKetThuc = dr.GetDateTime("NgayKetThuc");
            MarkOld();
        }

        public static Ky NewKy()
        {
            return new Ky();
        }
        public static Ky NewKy(int maKy, string tenKy, bool khoaSo, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            Ky k = new Ky();
            k._MaKy = maKy;
            k._TenKy = tenKy;
            k._KhoaSo = khoaSo;
            k._NgayBatDau = ngayBatDau;
            k._NgayKetThuc = ngayKetThuc;
            k.MarkOld();
            return k;
        }

        public static Ky GetKy(int maKy)
        {
            return (Ky)DataPortal.Fetch<Ky>(new Criteria(maKy));
        }

        public static Ky GetKy_maPhieuKiemKeTonKho(long maPhieuKiemKeTonKho)
        {
            return (Ky)DataPortal.Fetch<Ky>(new Criteria_maPhieuKiemKeTonKho(maPhieuKiemKeTonKho));
        }

        internal static Ky GetKy(SafeDataReader dr)
        {
            return new Ky(dr);            
        }

        public static void DeleteKy(int maKy)
        {
            DataPortal.Delete(new Criteria(maKy));
        }

        public static Int32 GetMaKyDauCuaNam(int nam)
        {
            Int32 result = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetMaKyDauCuaNam";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    SqlParameter outPara = new SqlParameter("@MaKy", SqlDbType.Int);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (Int32)outPara.Value;
                }
            }//end using
            return result;
        }//end function
        #endregion

        #region Data Access

        public static void KhoaSoKeToan(int maKy)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KHOASOKETOAN";
                        cm.Parameters.AddWithValue("@MaKy", maKy);                        
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static void MoSoKeToan(int maKy)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_MOSOKETOAN";
                        cm.Parameters.AddWithValue("@MaKy", maKy);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region load tất cả cả
        protected override void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        if (criteria is Criteria)
                        {
                            cm.CommandText = "spd_LoadMaCaBiet_Ky";
                            cm.Parameters.AddWithValue("@MaKy", ((Criteria)criteria).MaKy);
                        }
                        if (criteria is Criteria_maPhieuKiemKeTonKho)
                        {
                            cm.CommandText = "spd_SelecttblKy_tblPhieuNX_KKTK_MaPhieuKiemKeTK";
                            cm.Parameters.AddWithValue("@MaPhieuKiemKeTK", ((Criteria_maPhieuKiemKeTonKho)criteria)._maPhieuKiemKeTonKho);
                        }

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaKy = dr.GetInt32("MaKy");
                                _TenKy = dr.GetString("TenKy");
                                _KhoaSo = dr.GetBoolean("KhoaSo");
                                _NgayBatDau = dr.GetDateTime("NgayBatDau");
                                _NgayKetThuc = dr.GetDateTime("NgayKetThuc");
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_Ky";
                        cm.Parameters.AddWithValue("@MaKy", _MaKy.ToString());
                        cm.Parameters.AddWithValue("@TenKy", _TenKy);
                        cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);
                        cm.Parameters.AddWithValue("@NgayBatDau", _NgayBatDau);
                        cm.Parameters.AddWithValue("@NgayKetThuc", _NgayKetThuc);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_Ky";
                        cm.Parameters.AddWithValue("@MaKy", _MaKy.ToString());
                        cm.Parameters.AddWithValue("@TenKy", _TenKy);
                        cm.Parameters.AddWithValue("@KhoaSo", _KhoaSo);
                        cm.Parameters.AddWithValue("@NgayBatDau", _NgayBatDau);
                        cm.Parameters.AddWithValue("@NgayKetThuc", _NgayKetThuc);

                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #region Delete

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_Ky";
                        cm.Parameters.AddWithValue("@MaKy", crit.MaKy);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaKy));
        }
        #endregion

        #endregion

        #endregion

    }
}

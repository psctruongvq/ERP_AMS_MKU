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
    public class SoDuDauKy: BusinessBase<SoDuDauKy>
    {
        //
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaSoDuDauKy;
        }

        #region Khai Báo biến

        int _MaSoDuDauKy;
        public int MaSoDuDauKy
        {
            get
            {
                CanReadProperty(true);               
                return _MaSoDuDauKy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaSoDuDauKy.Equals(value))
                {
                    _MaSoDuDauKy = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _SoDuDauKyNo;    
        public Decimal SoDuDauKyNo
        {
            get
            {
                CanReadProperty(true);
                return _SoDuDauKyNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoDuDauKyNo.Equals(value))
                {
                    _SoDuDauKyNo = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _SoDuDauKyCo;
        public Decimal SoDuDauKyCo
        {
            get
            {
                CanReadProperty(true);
                return _SoDuDauKyCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoDuDauKyCo.Equals(value))
                {
                    _SoDuDauKyCo = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _PhatSinhTrongKyNo;
        public Decimal PhatSinhTrongKyNo
        {
            get
            {
                CanReadProperty(true);
                return _PhatSinhTrongKyNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhatSinhTrongKyNo.Equals(value))
                {
                    _PhatSinhTrongKyNo = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _PhatSinhTrongKyCo;
        public Decimal PhatSinhTrongKyCo
        {
            get
            {
                CanReadProperty(true);
                return _PhatSinhTrongKyCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhatSinhTrongKyCo.Equals(value))
                {
                    _PhatSinhTrongKyCo = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _LuyKeNo;
        public Decimal LuyKeNo
        {
            get
            {
                CanReadProperty(true);
                return _LuyKeNo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LuyKeNo.Equals(value))
                {
                    _LuyKeNo = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _LuyKeCo;
        public Decimal LuyKeCo
        {
            get
            {
                CanReadProperty(true);
                return _LuyKeCo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LuyKeCo.Equals(value))
                {
                    _LuyKeCo = value;
                    PropertyHasChanged();
                }
            }
        }
        
        int _MaTaiKhoan;
        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _MaTaiKhoan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTaiKhoan.Equals(value))
                {
                    _MaTaiKhoan = value;
                    _TenTaiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_MaTaiKhoan).TenTaiKhoan;
                    PropertyHasChanged();
                }
            }
        }

        string _SoHieuTK;
        public string SoHieuTK
        {
            get
            {
                CanReadProperty(true);
                return _SoHieuTK;
            }            
        }

        string _TenTaiKhoan;
        public string TenTaiKhoan
        {
            get
            {
                CanReadProperty(true);
                return _TenTaiKhoan;
            }
        }

        int _MaBoPhan;
        public int MaBoPhan
        {
            get
            {
                CanReadProperty(true);
                return _MaBoPhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaBoPhan.Equals(value))
                {
                    _MaBoPhan = value;
                    PropertyHasChanged();
                }
            }
        }

        int  _Ky;
        public int Ky
        {
            get
            {
                CanReadProperty(true);
                return _Ky;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Ky.Equals(value))
                {
                    _Ky = value;
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
            public int MaSoDuDauKy;

            public Criteria(int maSoDuDauKy)
            {
                MaSoDuDauKy = maSoDuDauKy;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override SoDuDauKy Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaSoDuDauKy));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    

        private SoDuDauKy(SafeDataReader dr, bool kiemtra)
        {
            MarkAsChild();
            try
            {     
              
                _MaSoDuDauKy = dr.GetInt32("MaSoDuDauKy");               
                _Ky = dr.GetInt32("MaKy");                
                _MaTaiKhoan = dr.GetInt32("MaTaiKhoan");
                _SoDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
                _SoDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
                _PhatSinhTrongKyCo = dr.GetDecimal("PhatSinhTrongKyCo");
                _PhatSinhTrongKyNo = dr.GetDecimal("PhatSinhTrongKyNo");
                _LuyKeCo = dr.GetDecimal("LuyKeCo");
                _LuyKeNo = dr.GetDecimal("LuyKeNo");
                _MaBoPhan = dr.GetInt32("MaBoPhan");
                _SoHieuTK= dr.GetString("SoHieuTK");
                _TenTaiKhoan= dr.GetString("TenTaiKhoan");
                _idSet = true;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (kiemtra == false)
                MarkNew();
            else MarkOld(); 
        }

        public static SoDuDauKy NewSoDuDauKy()
        {
            return new SoDuDauKy();
        }

        public static SoDuDauKy NewSoDuDauKy(int maKy, int maTaiKhoan, Decimal soDuDauKyCo, Decimal soDuDauKyNo, Decimal phatSinhTrongKyCo, Decimal phatSinhTrongKyNo, Decimal luyKeCo, Decimal luyKeNo)
        {
            SoDuDauKy sddk = new SoDuDauKy();
            sddk._Ky = maKy;// Ky.GetKy(maKy);
            sddk.MaTaiKhoan = maTaiKhoan;
            sddk._SoDuDauKyCo = soDuDauKyCo;
            sddk._SoDuDauKyNo = soDuDauKyNo;
            sddk._PhatSinhTrongKyCo = phatSinhTrongKyCo;
            sddk._PhatSinhTrongKyNo = phatSinhTrongKyNo;
            sddk._LuyKeCo = luyKeCo;
            sddk._LuyKeNo = luyKeNo;
            return sddk;
        }

        public static SoDuDauKy GetSoDuDauKy(int maSoDuDauKy)
        {
            return (SoDuDauKy)DataPortal.Fetch<SoDuDauKy>(new Criteria(maSoDuDauKy));
        }

        public static SoDuDauKy GetSoDuDauKy(SafeDataReader dr, bool kiemTra)
        {
            return new SoDuDauKy(dr, kiemTra);
        }

       
        public static void DeleteSoDauDauKy(int maSoDuDauKy)
        {
            DataPortal.Delete(new Criteria(maSoDuDauKy));
        }

        #endregion

        #region Constructors

        private SoDuDauKy()
        {
            // Prevent direct creation
            _MaSoDuDauKy = 0;
            _Ky = 0;//Ky.NewKy();
            _MaTaiKhoan = 0;
            _SoDuDauKyCo = 0;
            _SoDuDauKyNo = 0;
            _PhatSinhTrongKyCo = 0;
            _PhatSinhTrongKyNo = 0;
            _LuyKeCo = 0;
            _LuyKeNo = 0;
            _MaBoPhan = 0;
            MarkAsChild();
        }

        #endregion

        #region Data Access

        #region load tất cả cả

        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_SoDuDauKy";
                    cm.Parameters.AddWithValue("@MaSoDuDauKy", crit.MaSoDuDauKy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaSoDuDauKy = dr.GetInt32("MaSoDuDauKy");
                            _Ky = dr.GetInt32("MaKy");
                            _MaTaiKhoan = dr.GetInt32("MaTaiKhoan");
                            _SoDuDauKyNo = dr.GetDecimal("SoDuDauKyCo");
                            _SoDuDauKyCo = dr.GetDecimal("SoDuDauKyNo");
                            _PhatSinhTrongKyNo = dr.GetDecimal("PhatSinhTrongKyNo");
                            _PhatSinhTrongKyCo = dr.GetDecimal("PhatSinhTrongKyCo");
                            _LuyKeNo = dr.GetDecimal("LuyKeNo");
                            _LuyKeCo = dr.GetDecimal("LuyKeCo");
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
                MarkOld();
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
                        cm.CommandText = "spd_InserttblSoDuDauKy";
                        cm.Parameters.AddWithValue("@MaSoDuDauKy", _MaSoDuDauKy);
                        cm.Parameters.AddWithValue("@MaKy", _Ky);
                        
                        cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                        
                        cm.Parameters.AddWithValue("@SoDuDauKyNo", _SoDuDauKyNo);
                        cm.Parameters.AddWithValue("@SoDuDauKyCo", _SoDuDauKyCo);
                        cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", _PhatSinhTrongKyNo);
                        cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", _PhatSinhTrongKyCo);
                        cm.Parameters.AddWithValue("@LuyKeNo", _LuyKeNo);
                        cm.Parameters.AddWithValue("@LuyKeCo", _LuyKeCo);
                        cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                        cm.Parameters["@MaSoDuDauKy"].Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();
                        _MaSoDuDauKy= (int)cm.Parameters["@MaSoDuDauKy"].Value;
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
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_UpdatetblSoDuDauKy";
                    cm.Parameters.AddWithValue("@MaSoDuDauKy", _MaSoDuDauKy);
                    cm.Parameters.AddWithValue("@MaKy", _Ky);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@SoDuDauKyNo", _SoDuDauKyNo);
                    cm.Parameters.AddWithValue("@SoDuDauKyCo", _SoDuDauKyCo);
                    cm.Parameters.AddWithValue("@PhatSinhTrongKyNo", PhatSinhTrongKyNo);
                    cm.Parameters.AddWithValue("@PhatSinhTrongKyCo", _PhatSinhTrongKyCo);
                    cm.Parameters.AddWithValue("@LuyKeNo", _LuyKeNo);
                    cm.Parameters.AddWithValue("@LuyKeCo", _LuyKeCo);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
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
                    cm.CommandText = "spd_DeletetblSoDuDauKy";
                    cm.Parameters.AddWithValue("@MaSoDuDauKy", _MaSoDuDauKy);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaSoDuDauKy));
        }
        #endregion

        #endregion

        #endregion

        #region KiemTraKyKetChuyen
        public static int KiemTraKyKetChuyen(int MaKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuTaiKhoan";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion 
        #region KiemTraKyKetChuyen
        public static int KiemTraNamKetChuyen(int Nam, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoDuTaiKhoanTheoNam";
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }

        public static int IsTonTaiSoDuKyKeTiep(int maKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTonTaiKyKetChuyen";
                    cm.Parameters.AddWithValue("@maKy", maKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }

        public static int KiemTraNamKetChuyenSoDuTaiKhoanDoiTuong(int Nam, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraDaKetChuyenSoDuTaiKhoanDoiTuongTheoNam";
                    cm.Parameters.AddWithValue("@Nam", Nam);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    GiaTriTrave = (int)prmGiaTriTraVe.Value;

                }
            }
            return GiaTriTrave;
        }
        #endregion 
    }
}

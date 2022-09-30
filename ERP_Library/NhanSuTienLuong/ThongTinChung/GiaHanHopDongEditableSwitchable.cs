
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiaHanHopDong : Csla.BusinessBase<GiaHanHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private long _maGiaHangHopDong = 0;
        private long _maHopDongLaoDong = 0;
        private string _SoHDLD = string.Empty;
        private string _tenNhanVien = string.Empty;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private int _maHinhThucHopDong = 0;
        private string _TenHinhthucHD = string.Empty;
        private long _maNguoiLap = 0;
        private double _phanTramBHXH = 0;
        private double _phanTramBHYT = 0;
        private decimal _soTienCongDoan = 0;
        private string _congViecPhaiLam = string.Empty;
        private string _ngheNghiep = string.Empty;


        [System.ComponentModel.DataObjectField(true, true)]
        public long MaGiaHangHopDong
        {
            get
            {
                CanReadProperty("MaGiaHangHopDong", true);
                return _maGiaHangHopDong;
            }
        }

        public long MaHopDongLaoDong
        {
            get
            {
                CanReadProperty("MaHopDongLaoDong", true);
                return _maHopDongLaoDong;
            }
            set
            {
                CanWriteProperty("MaHopDongLaoDong", true);
                if (!_maHopDongLaoDong.Equals(value))
                {
                    _maHopDongLaoDong = value;
                    PropertyHasChanged("MaHopDongLaoDong");
                }
            }
        }

        public string SoHDLD
        {
            get
            {
                CanReadProperty(true);
                return _SoHDLD;
            }           
        }
        public string Tennhanvien
        {
            get
            {
                CanReadProperty( true);
                return _tenNhanVien;
            }           
        }
        public string TenHinhthucHopdong
        {
            get
            {
                CanReadProperty(true);
                _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
                return _TenHinhthucHD;
            }
        }
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged("TuNgay");
                }
            }
        }
        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay=new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
        }     
        public DateTime NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty("NgayKy", true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
        }   
        public int MaHinhThucHopDong
        {
            get
            {
                CanReadProperty("MaHinhThucHopDong", true);
                return _maHinhThucHopDong;
            }
            set
            {
                CanWriteProperty("MaHinhThucHopDong", true);
                if (!_maHinhThucHopDong.Equals(value))
                {
                    _maHinhThucHopDong = value;
                    _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
                    PropertyHasChanged("MaHinhThucHopDong");
                }
            }
        }

        public long MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty("MaNguoiLap", true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
                }
            }
        }

        public double PhanTramBHXH
        {
            get
            {
                CanReadProperty("PhanTramBHXH", true);
                return _phanTramBHXH;
            }
            set
            {
                CanWriteProperty("PhanTramBHXH", true);
                if (!_phanTramBHXH.Equals(value))
                {
                    _phanTramBHXH = value;
                    PropertyHasChanged("PhanTramBHXH");
                }
            }
        }

        public double PhanTramBHYT
        {
            get
            {
                CanReadProperty("PhanTramBHYT", true);
                return _phanTramBHYT;
            }
            set
            {
                CanWriteProperty("PhanTramBHYT", true);
                if (!_phanTramBHYT.Equals(value))
                {
                    _phanTramBHYT = value;
                    PropertyHasChanged("PhanTramBHYT");
                }
            }
        }

        public decimal SoTienCongDoan
        {
            get
            {
                CanReadProperty("SoTienCongDoan", true);
                return _soTienCongDoan;
            }
            set
            {
                CanWriteProperty("SoTienCongDoan", true);
                if (!_soTienCongDoan.Equals(value))
                {
                    _soTienCongDoan = value;
                    PropertyHasChanged("SoTienCongDoan");
                }
            }
        }

        public string CongViecPhaiLam
        {
            get
            {
                CanReadProperty("CongViecPhaiLam", true);
                return _congViecPhaiLam;
            }
            set
            {
                CanWriteProperty("CongViecPhaiLam", true);
                if (value == null) value = string.Empty;
                if (!_congViecPhaiLam.Equals(value))
                {
                    _congViecPhaiLam = value;
                    PropertyHasChanged("CongViecPhaiLam");
                }
            }
        }

        public string NgheNghiep
        {
            get
            {
                CanReadProperty("NgheNghiep", true);
                return _ngheNghiep;
            }
            set
            {
                CanWriteProperty("NgheNghiep", true);
                if (value == null) value = string.Empty;
                if (!_ngheNghiep.Equals(value))
                {
                    _ngheNghiep = value;
                    PropertyHasChanged("NgheNghiep");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maGiaHangHopDong;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // CongViecPhaiLam
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongViecPhaiLam", 50));
            //
            // NgheNghiep
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NgheNghiep", 50));

        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in GiaHanHopDong
            //AuthorizationRules.AllowRead("MaGiaHangHopDong", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaHopDongLaoDong", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("NguoiKy", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayKy", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayKyString", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaChucVu", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaChucDanh", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaHinhThucHopDong", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("DieuKhoanKhac", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("PhanTramBHXH", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("PhanTramBHYT", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("SoTienCongDoan", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("ThoiGianLamViec", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("DungCuLamViec", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("PhuongTienDiLamViec", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("CheDoDaoTao", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("CongViecPhaiLam", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgheNghiep", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("MucLuongChinhTienCong", "GiaHanHopDongReadGroup");
            //AuthorizationRules.AllowRead("HinhThucTraLuong", "GiaHanHopDongReadGroup");

            //AuthorizationRules.AllowWrite("MaHopDongLaoDong", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiKy", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKyString", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaChucVu", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaChucDanh", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaHinhThucHopDong", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("DieuKhoanKhac", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramBHXH", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTramBHYT", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienCongDoan", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiGianLamViec", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("DungCuLamViec", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("PhuongTienDiLamViec", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("CheDoDaoTao", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("CongViecPhaiLam", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NgheNghiep", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MucLuongChinhTienCong", "GiaHanHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("HinhThucTraLuong", "GiaHanHopDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiaHanHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiaHanHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiaHanHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiaHanHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiaHanHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiaHanHopDong()
        { /* require use of factory method */ }

        public static GiaHanHopDong NewGiaHanHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiaHanHopDong");
            return DataPortal.Create<GiaHanHopDong>();
        }

        public static GiaHanHopDong GetGiaHanHopDong(long maGiaHangHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiaHanHopDong");
            return DataPortal.Fetch<GiaHanHopDong>(new Criteria(maGiaHangHopDong));
        }

        public static void DeleteGiaHanHopDong(long maGiaHangHopDong)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiaHanHopDong");
            DataPortal.Delete(new Criteria(maGiaHangHopDong));
        }

        public override GiaHanHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiaHanHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiaHanHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiaHanHopDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static GiaHanHopDong NewGiaHanHopDongChild()
        {
            GiaHanHopDong child = new GiaHanHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiaHanHopDong GetGiaHanHopDong(SafeDataReader dr)
        {
            GiaHanHopDong child = new GiaHanHopDong();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaGiaHangHopDong;

            public Criteria(long maGiaHangHopDong)
            {
                this.MaGiaHangHopDong = maGiaHangHopDong;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsGiaHangHopDong";

                cm.Parameters.AddWithValue("@MaGiaHangHopDong", criteria.MaGiaHangHopDong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maGiaHangHopDong));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsGiaHangHopDong";

                cm.Parameters.AddWithValue("@MaGiaHangHopDong", criteria.MaGiaHangHopDong);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maGiaHangHopDong = dr.GetInt64("MaGiaHangHopDong");
            _maHopDongLaoDong = dr.GetInt64("MaHopDongLaoDong");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _maHinhThucHopDong = dr.GetInt32("MaHinhThucHopDong");
            _TenHinhthucHD = HinhThucHopDong.GetHinhThucHopDong(_maHinhThucHopDong).TenHinhThucHopDong;
            _phanTramBHXH = dr.GetDouble("PhanTramBHXH");
            _phanTramBHYT = dr.GetDouble("PhanTramBHYT");
            _soTienCongDoan = dr.GetDecimal("SoTienCongDoan");
            _congViecPhaiLam = dr.GetString("CongViecPhaiLam");
            _ngheNghiep = dr.GetString("NgheNghiep");
            _SoHDLD = dr.GetString("SoHopdong");
            _tenNhanVien = dr.GetString("TenNhanVien");
            
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsGiaHanHopDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maGiaHangHopDong = (long)cm.Parameters["@MaGiaHangHopDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaHopDongLaoDong", _maHopDongLaoDong);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);          
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_maHinhThucHopDong != 0)
                cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
            else
                cm.Parameters.AddWithValue("@MaHinhThucHopDong", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_phanTramBHXH != 0)
                cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
            else
                cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
            if (_phanTramBHYT != 0)
                cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
            else
                cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
            if (_soTienCongDoan != 0)
                cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
            else
                cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
           
            if (_congViecPhaiLam.Length > 0)
                cm.Parameters.AddWithValue("@CongViecPhaiLam", _congViecPhaiLam);
            else
                cm.Parameters.AddWithValue("@CongViecPhaiLam", DBNull.Value);
            if (_ngheNghiep.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiep", _ngheNghiep);
            else
                cm.Parameters.AddWithValue("@NgheNghiep", DBNull.Value);

            cm.Parameters.AddWithValue("@MaGiaHangHopDong", _maGiaHangHopDong);
            cm.Parameters["@MaGiaHangHopDong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsGiaHangHopDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaGiaHangHopDong", _maGiaHangHopDong);
            cm.Parameters.AddWithValue("@MaHopDongLaoDong", _maHopDongLaoDong);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_maHinhThucHopDong != 0)
                cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
            else
                cm.Parameters.AddWithValue("@MaHinhThucHopDong", DBNull.Value);
            if (_phanTramBHXH != 0)
                cm.Parameters.AddWithValue("@PhanTramBHXH", _phanTramBHXH);
            else
                cm.Parameters.AddWithValue("@PhanTramBHXH", DBNull.Value);
            if (_phanTramBHYT != 0)
                cm.Parameters.AddWithValue("@PhanTramBHYT", _phanTramBHYT);
            else
                cm.Parameters.AddWithValue("@PhanTramBHYT", DBNull.Value);
            if (_soTienCongDoan != 0)
                cm.Parameters.AddWithValue("@SoTienCongDoan", _soTienCongDoan);
            else
                cm.Parameters.AddWithValue("@SoTienCongDoan", DBNull.Value);
            if (_congViecPhaiLam.Length > 0)
                cm.Parameters.AddWithValue("@CongViecPhaiLam", _congViecPhaiLam);
            else
                cm.Parameters.AddWithValue("@CongViecPhaiLam", DBNull.Value);
            if (_ngheNghiep.Length > 0)
                cm.Parameters.AddWithValue("@NgheNghiep", _ngheNghiep);
            else
                cm.Parameters.AddWithValue("@NgheNghiep", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maGiaHangHopDong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
        public static void ThemvaoHopDong(long maHDLD,int maHinhThucHD, DateTime Ngayky, DateTime TuNgay, DateTime DenNgay, string Nghenghiep, string Congviec)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsGiaHanhopDongList";
                    cm.Parameters.AddWithValue("@MaHDLD", maHDLD);
                    cm.Parameters.AddWithValue("@mahinhthucHD", maHinhThucHD);
                    cm.Parameters.AddWithValue("@Ngayky", Ngayky);
                    cm.Parameters.AddWithValue("@Tungay", TuNgay);
                    if (DateTime.Parse(DenNgay.ToLongDateString()).ToString("dd/MM/yyyy") == "01/01/0001")
                        cm.Parameters.AddWithValue("@Denngay", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@Denngay", DenNgay);
                    cm.Parameters.AddWithValue("@Nghenghiep", Nghenghiep);
                    cm.Parameters.AddWithValue("@CongViec", Congviec);
                    cm.ExecuteNonQuery();
                }
            }
        }
    }
}

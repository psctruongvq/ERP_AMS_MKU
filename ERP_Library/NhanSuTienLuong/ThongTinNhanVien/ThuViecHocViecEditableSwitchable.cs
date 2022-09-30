
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThuViecHocViec : Csla.BusinessBase<ThuViecHocViec>
    {
        #region Business Properties and Methods

        //declare members
        private long _maThuViecHocViec = 0;
        private SmartDate _ngay = new SmartDate(DateTime.Today);
        private long _maNhanVien = 0;
        private string _tennhanvien = string.Empty;
        private string _Maqlnhanvien = string.Empty;
        private SmartDate _Ngayvaolam = new SmartDate(DateTime.Today);
        private SmartDate _NgaySinh = new SmartDate(DateTime.Today);        
        private string _Chucvu = string.Empty;
        private int _maKyTinhLuong = 0;
        private string _kyitnhluong = string.Empty;
        private string _ghiChu = string.Empty;
        private bool _loai = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaThuViecHocViec
        {
            get
            {
                CanReadProperty("MaThuViecHocViec", true);
                return _maThuViecHocViec;
            }
        }

        public DateTime Ngay
        {
            get
            {
                CanReadProperty("Ngay", true);
                return _ngay.Date;
            }
            set
            {
                CanWriteProperty("Ngay", true);
                if (!_ngay.Equals(value))
                {
                    _ngay = new SmartDate(value);
                    PropertyHasChanged("Ngay");
                }
            }
        }
        public DateTime NgayVaoLam
        {
            get
            {
                CanReadProperty( true);
                return _Ngayvaolam.Date;
            }           
        }
        public DateTime NgaySinh
        {
            get
            {
                CanReadProperty(true);
                return _NgaySinh.Date;
            }
        }
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }
        public string TenNhanVien
        {
            get
            {
                CanReadProperty( true);
                return _tennhanvien;
            }          
        }
        public string MaQLNhanvien
        {
            get
            {
                CanReadProperty(true);
                return _Maqlnhanvien;
            }
        }
        public string Chucvu
        {
            get
            {
                CanReadProperty(true);
                return _Chucvu;
            }
        }
        public string KyTinhLuong
        {
            get
            {
                CanReadProperty(true);
                return _kyitnhluong;
            }
        }
        public bool Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maThuViecHocViec;
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
            // GhiChu
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
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
            //TODO: Define authorization rules in ThuViecHocViec
            //AuthorizationRules.AllowRead("MaThuViecHocViec", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ThuViecHocViecReadGroup");
            //AuthorizationRules.AllowRead("Loai", "ThuViecHocViecReadGroup");

            //AuthorizationRules.AllowWrite("NgayString", "ThuViecHocViecWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "ThuViecHocViecWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "ThuViecHocViecWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ThuViecHocViecWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "ThuViecHocViecWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThuViecHocViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThuViecHocViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThuViecHocViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThuViecHocViec
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThuViecHocViecDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThuViecHocViec()
        { /* require use of factory method */ }

        public static ThuViecHocViec NewThuViecHocViec()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThuViecHocViec");
            return DataPortal.Create<ThuViecHocViec>();
        }

        public static ThuViecHocViec GetThuViecHocViec(long maThuViecHocViec)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViec");
            return DataPortal.Fetch<ThuViecHocViec>(new Criteria(maThuViecHocViec));
        }

        public static void DeleteThuViecHocViec(long maThuViecHocViec)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThuViecHocViec");
            DataPortal.Delete(new Criteria(maThuViecHocViec));
        }

        public override ThuViecHocViec Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThuViecHocViec");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThuViecHocViec");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThuViecHocViec");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThuViecHocViec NewThuViecHocViecChild()
        {
            ThuViecHocViec child = new ThuViecHocViec();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThuViecHocViec GetThuViecHocViec(SafeDataReader dr)
        {
            ThuViecHocViec child = new ThuViecHocViec();
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
            public long MaThuViecHocViec;

            public Criteria(long maThuViecHocViec)
            {
                this.MaThuViecHocViec = maThuViecHocViec;
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
                cm.CommandText = "spd_SelecttblnsThuViecHocViec";

                cm.Parameters.AddWithValue("@MaThuViecHocViec", criteria.MaThuViecHocViec);

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
            DataPortal_Delete(new Criteria(_maThuViecHocViec));
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
                cm.CommandText = "spd_DeletetblnsThuViecHocViec";
                cm.Parameters.AddWithValue("@MaThuViecHocViec", criteria.MaThuViecHocViec);
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
            _maThuViecHocViec = dr.GetInt64("MaThuViecHocViec");
            _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tennhanvien = dr.GetString("Tennhanvien");
            _Maqlnhanvien = dr.GetString("MaQLNhanvien");
            _Ngayvaolam = dr.GetSmartDate("Ngayvaonganh", _Ngayvaolam.EmptyIsMin);    
            _ghiChu = dr.GetString("GhiChu");

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
                cm.CommandText = "spd_InserttblnsThuViecHocViec";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maThuViecHocViec = (long)cm.Parameters["@MaThuViecHocViec"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_loai != false)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThuViecHocViec", _maThuViecHocViec);
            cm.Parameters["@MaThuViecHocViec"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsThuViecHocViec";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaThuViecHocViec", _maThuViecHocViec);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_loai != false)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maThuViecHocViec));
            MarkNew();
        }
        #endregion //Data Access - Delete
        public static void Themvaothuviec(long manhanvien, int Ngay, int Loai, string Ghichu)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsThuViecHocViecList";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@Ngay", Ngay);
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    cm.Parameters.AddWithValue("@ghichu", Ghichu);
                    cm.ExecuteNonQuery();
                }
            }//us          
        }
        public static void XulyNghi(int Thang, int Nam)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    try
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_XulylainghivieccuaNVhocviec";
                        cm.Parameters.AddWithValue("@Thang", Thang);
                        cm.Parameters.AddWithValue("@nam", Nam);
                        cm.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {

                    }
                }
            }//us          
        }

        #endregion //Data Access
    }
}

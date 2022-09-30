
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTayNghe : Csla.BusinessBase<PhuCapTayNghe>
    {
        #region Business Properties and Methods

        //declare members
        private int _maPhuCap = 0;
        private int _maChucVu = 0;
        private string _Tenchucvu = string.Empty;
        private int _maCongViec = 0;
        private string _Tencongviec = string.Empty;
        private int _maTayNghe = 0;
        private string _tenTaynghe = string.Empty;
        private decimal _soTienPhuCap = 0;
        private string _tennguoilap = string.Empty;
        private string _ghiChu = string.Empty;
        private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhuCap
        {
            get
            {
                CanReadProperty("MaPhuCap", true);
                return _maPhuCap;
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
            set
            {
                CanWriteProperty("MaChucVu", true);
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }

        public int MaCongViec
        {
            get
            {
                CanReadProperty("MaCongViec", true);
                return _maCongViec;
            }
            set
            {
                CanWriteProperty("MaCongViec", true);
                if (!_maCongViec.Equals(value))
                {
                    _maCongViec = value;
                    PropertyHasChanged("MaCongViec");
                }
            }
        }

        public int MaTayNghe
        {
            get
            {
                CanReadProperty("MaTayNghe", true);
                return _maTayNghe;
            }
            set
            {
                CanWriteProperty("MaTayNghe", true);
                if (!_maTayNghe.Equals(value))
                {
                    _maTayNghe = value;
                    PropertyHasChanged("MaTayNghe");
                }
            }
        }

        public decimal SoTienPhuCap
        {
            get
            {
                CanReadProperty("SoTienPhuCap", true);
                return _soTienPhuCap;
            }
            set
            {
                CanWriteProperty("SoTienPhuCap", true);
                if (!_soTienPhuCap.Equals(value))
                {
                    _soTienPhuCap = value;
                    PropertyHasChanged("SoTienPhuCap");
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
        public string Tennguoilap
        {
            get
            {
                CanReadProperty( true);
                return _tennguoilap;
            }
            set
            {
                CanWriteProperty( true);
                if (value == null) value = string.Empty;
                if (!_tennguoilap.Equals(value))
                {
                    _tennguoilap = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tenchucvu
        {
            get
            {
                CanReadProperty(true);
                return _Tenchucvu;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_Tenchucvu.Equals(value))
                {
                    _Tenchucvu = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tencongviec
        {
            get
            {
                CanReadProperty(true);
                return _Tencongviec;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_Tencongviec.Equals(value))
                {
                    _Tencongviec = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Tentaynghe
        {
            get
            {
                CanReadProperty(true);
                return _tenTaynghe;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tenTaynghe.Equals(value))
                {
                    _tenTaynghe = value;
                    PropertyHasChanged();
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maPhuCap;
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
            //TODO: Define authorization rules in PhuCapTayNghe
            //AuthorizationRules.AllowRead("MaPhuCap", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("MaChucVu", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("MaCongViec", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("MaTayNghe", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("SoTienPhuCap", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "PhuCapTayNgheReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "PhuCapTayNgheReadGroup");

            //AuthorizationRules.AllowWrite("MaChucVu", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongViec", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("MaTayNghe", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienPhuCap", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "PhuCapTayNgheWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "PhuCapTayNgheWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTayNghe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTayNghe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTayNghe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTayNghe
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTayNgheDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTayNghe()
        { /* require use of factory method */ }

        public static PhuCapTayNghe NewPhuCapTayNghe()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNghe");
            return DataPortal.Create<PhuCapTayNghe>();
        }

        public static PhuCapTayNghe GetPhuCapTayNghe(int maPhuCap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe");
            return DataPortal.Fetch<PhuCapTayNghe>(new Criteria(maPhuCap));
        }
        public static PhuCapTayNghe GetPhuCapTayNghe(int Machucvu, int Macongviec, int Mataynghe)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTayNghe");
            return DataPortal.Fetch<PhuCapTayNghe>(new CriteriaFilter(Machucvu, Macongviec, Mataynghe));
        }


        public static void DeletePhuCapTayNghe(int maPhuCap)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTayNghe");
            DataPortal.Delete(new Criteria(maPhuCap));
        }

        public override PhuCapTayNghe Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTayNghe");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTayNghe");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhuCapTayNghe");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static PhuCapTayNghe NewPhuCapTayNgheChild()
        {
            PhuCapTayNghe child = new PhuCapTayNghe();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static PhuCapTayNghe GetPhuCapTayNghe(SafeDataReader dr)
        {
            PhuCapTayNghe child = new PhuCapTayNghe();
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
            public int MaPhuCap;

            public Criteria(int maPhuCap)
            {
                this.MaPhuCap = maPhuCap;
            }
        }
        private class CriteriaFilter
        {
            public int _maChucVu;
            public int _maCongViec;
            public int _maTayNghe;

            public CriteriaFilter(int MaChucvu, int Macongviec, int Mataynghe)
            {
                this._maChucVu = MaChucvu;
                this._maCongViec = Macongviec;
                this._maTayNghe = Mataynghe;
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {  
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsPhucaptaynghe";
                    cm.Parameters.AddWithValue("@MaPhuCap", ((Criteria)criteria).MaPhuCap);
                }
                else if (criteria is CriteriaFilter)
                {
                    //cm.CommandText = "spd_SelecttblnsPhucaptaynghe";
                    //cm.Parameters.AddWithValue("@MaPhuCap", criteria.MaPhuCap);
                }
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
            DataPortal_Delete(new Criteria(_maPhuCap));
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
                cm.CommandText = "spd_DeletetblnsPhuCapTayNghe";

                cm.Parameters.AddWithValue("@MaPhuCap", criteria.MaPhuCap);

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
            _maPhuCap = dr.GetInt32("MaPhuCap");
            _maChucVu = dr.GetInt32("MaChucVu");
            _maCongViec = dr.GetInt32("MaCongViec");
            _maTayNghe = dr.GetInt32("MaTayNghe");
            _soTienPhuCap = dr.GetDecimal("SoTienPhuCap");
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _tennguoilap = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNguoiLap).TenNhanVien;
            _Tenchucvu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
            _Tencongviec = CongViec.GetCongViec(_maCongViec).TenCongViec;
            _tenTaynghe = TayNghe.GetTayNghe(_maTayNghe).TenTayNghe;
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
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
                cm.CommandText = "spd_InserttblnsPhucaptaynghe";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maPhuCap = (int)cm.Parameters["@MaPhuCap"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
            if (_soTienPhuCap != 0)
                cm.Parameters.AddWithValue("@SoTienPhuCap", _soTienPhuCap);
            else
                cm.Parameters.AddWithValue("@SoTienPhuCap", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
            cm.Parameters["@MaPhuCap"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsPhucaptaynghe";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhuCap", _maPhuCap);
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
            cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
            if (_soTienPhuCap != 0)
                cm.Parameters.AddWithValue("@SoTienPhuCap", _soTienPhuCap);
            else
                cm.Parameters.AddWithValue("@SoTienPhuCap", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

            ExecuteDelete(tr, new Criteria(_maPhuCap));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

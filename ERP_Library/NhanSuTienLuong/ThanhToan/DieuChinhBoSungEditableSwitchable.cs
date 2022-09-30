
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DieuChinhBoSung : Csla.BusinessBase<DieuChinhBoSung>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private long _maNhanVien = 0;
        private int _maKyTinhLuong = 0;
        private int _thang = 0;
        private int _nam = 0;
        private decimal _soTien = 0;
        private string _dienGiai = string.Empty;
        private int _loaiDieuChinh = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
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
                    _thang = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong).Thang;
                    _nam = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong).Nam;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public int Thang
        {
            get
            {
                CanReadProperty("Thang", true);
                return _thang;
            }
            set
            {
                CanWriteProperty("Thang", true);
                if (!_thang.Equals(value))
                {
                    _thang = value;
                    PropertyHasChanged("Thang");
                }
            }
        }

        public int Nam
        {
            get
            {
                CanReadProperty("Nam", true);
                return _nam;
            }
            set
            {
                CanWriteProperty("Nam", true);
                if (!_nam.Equals(value))
                {
                    _nam = value;
                    PropertyHasChanged("Nam");
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public int LoaiDieuChinh
        {
            get
            {
                CanReadProperty("LoaiDieuChinh", true);
                return _loaiDieuChinh;
            }
            set
            {
                CanWriteProperty("LoaiDieuChinh", true);
                if (!_loaiDieuChinh.Equals(value))
                {
                    _loaiDieuChinh = value;
                    PropertyHasChanged("LoaiDieuChinh");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in DieuChinhBoSung
            //AuthorizationRules.AllowRead("MaChiTiet", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("Thang", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("Nam", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DieuChinhBoSungReadGroup");
            //AuthorizationRules.AllowRead("LoaiDieuChinh", "DieuChinhBoSungReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("Thang", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("Nam", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DieuChinhBoSungWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDieuChinh", "DieuChinhBoSungWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DieuChinhBoSung
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DieuChinhBoSung
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DieuChinhBoSung
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DieuChinhBoSung
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DieuChinhBoSungDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DieuChinhBoSung()
        { /* require use of factory method */ }

        public static DieuChinhBoSung NewDieuChinhBoSung()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChinhBoSung");
            return DataPortal.Create<DieuChinhBoSung>();
        }

        public static DieuChinhBoSung GetDieuChinhBoSung(int maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChinhBoSung");
            return DataPortal.Fetch<DieuChinhBoSung>(new Criteria(maChiTiet));
        }

        public static void DeleteDieuChinhBoSung(int maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DieuChinhBoSung");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override DieuChinhBoSung Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DieuChinhBoSung");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DieuChinhBoSung");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DieuChinhBoSung");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DieuChinhBoSung NewDieuChinhBoSungChild()
        {
            DieuChinhBoSung child = new DieuChinhBoSung();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DieuChinhBoSung GetDieuChinhBoSung(SafeDataReader dr)
        {
            DieuChinhBoSung child = new DieuChinhBoSung();
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
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_SelecttblDieuChinhBoSung";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
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
                    ExecuteInsert(tr, null);

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
                        ExecuteUpdate(tr, null);
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
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                cm.CommandText = "spd_DeletetblDieuChinhBoSung";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _thang = dr.GetInt32("Thang");
            _nam = dr.GetInt32("Nam");
            _soTien = dr.GetDecimal("SoTien");
            _dienGiai = dr.GetString("DienGiai");
            _loaiDieuChinh = dr.GetInt32("LoaiDieuChinh");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DieuChinhBoSungList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DieuChinhBoSungList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDieuChinhBoSung";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DieuChinhBoSungList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@Thang", _thang);
            cm.Parameters.AddWithValue("@Nam", _nam);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiDieuChinh", _loaiDieuChinh);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DieuChinhBoSungList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, DieuChinhBoSungList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDieuChinhBoSung";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DieuChinhBoSungList parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@Thang", _thang);
            cm.Parameters.AddWithValue("@Nam", _nam);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiDieuChinh", _loaiDieuChinh);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class PhuCapTrachNhiem : Csla.BusinessBase<PhuCapTrachNhiem>
    {
        #region Business Properties and Methods

        //declare members
        private int _maPhuCapTrachNhiem = 0;
        private int _maChucVu = 0;
        private string _tenchucvu = string.Empty;
        private decimal _soTien = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhuCapTrachNhiem
        {
            get
            {
                CanReadProperty("MaPhuCapTrachNhiem", true);
                return _maPhuCapTrachNhiem;
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
                //_tenchucvu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
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
        public string Tenchucvu
        {
            get
            {
                CanReadProperty(true);
                return _tenchucvu;
            }
            set
            {
                _tenchucvu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
            }
        }

        protected override object GetIdValue()
        {
            return _maPhuCapTrachNhiem;
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
            // NgayLap
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayLap");
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
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
            //TODO: Define authorization rules in PhuCapTrachNhiem
            //AuthorizationRules.AllowRead("MaPhuCapTrachNhiem", "PhuCapTrachNhiemReadGroup");
            //AuthorizationRules.AllowRead("MaChucVu", "PhuCapTrachNhiemReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "PhuCapTrachNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "PhuCapTrachNhiemReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "PhuCapTrachNhiemReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "PhuCapTrachNhiemReadGroup");

            //AuthorizationRules.AllowWrite("MaChucVu", "PhuCapTrachNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "PhuCapTrachNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "PhuCapTrachNhiemWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "PhuCapTrachNhiemWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhuCapTrachNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhuCapTrachNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhuCapTrachNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhuCapTrachNhiem
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhuCapTrachNhiemDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhuCapTrachNhiem()
        { /* require use of factory method */ }

        public static PhuCapTrachNhiem NewPhuCapTrachNhiem()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTrachNhiem");
            return DataPortal.Create<PhuCapTrachNhiem>();
        }

        public static PhuCapTrachNhiem GetPhuCapTrachNhiem(int maPhuCapTrachNhiem)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhuCapTrachNhiem");
            return DataPortal.Fetch<PhuCapTrachNhiem>(new Criteria(maPhuCapTrachNhiem));
        }

        public static void DeletePhuCapTrachNhiem(int maPhuCapTrachNhiem)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTrachNhiem");
            DataPortal.Delete(new Criteria(maPhuCapTrachNhiem));
        }

        public override PhuCapTrachNhiem Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a PhuCapTrachNhiem");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhuCapTrachNhiem");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a PhuCapTrachNhiem");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static PhuCapTrachNhiem NewPhuCapTrachNhiemChild()
        {
            PhuCapTrachNhiem child = new PhuCapTrachNhiem();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static PhuCapTrachNhiem GetPhuCapTrachNhiem(SafeDataReader dr)
        {
            PhuCapTrachNhiem child = new PhuCapTrachNhiem();
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
            public int MaPhuCapTrachNhiem;

            public Criteria(int maPhuCapTrachNhiem)
            {
                this.MaPhuCapTrachNhiem = maPhuCapTrachNhiem;
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
                cm.CommandText = "spd_SelecttblnsPhuCapTrachNhiem";

                cm.Parameters.AddWithValue("@MaPhuCapTrachNhiem", criteria.MaPhuCapTrachNhiem);

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
            DataPortal_Delete(new Criteria(_maPhuCapTrachNhiem));
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
                cm.CommandText = "spd_DeletetblnsPhuCapTrachNhiem";

                cm.Parameters.AddWithValue("@MaPhuCapTrachNhiem", criteria.MaPhuCapTrachNhiem);

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
            _maPhuCapTrachNhiem = dr.GetInt32("MaPhuCapTrachNhiem");
            _maChucVu = dr.GetInt32("MaChucVu");
            _tenchucvu =ChucVu.GetChucVu(_maChucVu).TenChucVu;
            _soTien = dr.GetDecimal("SoTien");
            _ngayLap = dr.GetSmartDate("NgayLap",_ngayLap.EmptyIsMin);
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
                cm.CommandText = "spd_inserttblnsPhuCapTrachNhiem";

                AddInsertParameters(cm);
                cm.ExecuteNonQuery();
                _maPhuCapTrachNhiem = (int)cm.Parameters["@MaPhuCapTrachNhiem"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@NgayLap",  _ngayLap.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhuCapTrachNhiem", _maPhuCapTrachNhiem);
            cm.Parameters["@MaPhuCapTrachNhiem"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsPhuCapTrachNhiem";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhuCapTrachNhiem", _maPhuCapTrachNhiem);
            cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maPhuCapTrachNhiem));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

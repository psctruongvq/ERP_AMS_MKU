
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class QuocGiaBQ_VT : Csla.BusinessBase<QuocGiaBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuocGia = 0;
        private string _maQuocGiaQuanLy = string.Empty;
        private string _tenQuocGia = string.Empty;
        private string _tenVietTat = string.Empty;
        private string _dienGiai = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
        }

        public string MaQuocGiaQuanLy
        {
            get
            {
                CanReadProperty("MaQuocGiaQuanLy", true);
                return _maQuocGiaQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuocGiaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuocGiaQuanLy.Equals(value))
                {
                    _maQuocGiaQuanLy = value;
                    PropertyHasChanged("MaQuocGiaQuanLy");
                }
            }
        }

        public string TenQuocGia
        {
            get
            {
                CanReadProperty("TenQuocGia", true);
                return _tenQuocGia;
            }
            set
            {
                CanWriteProperty("TenQuocGia", true);
                if (value == null) value = string.Empty;
                if (!_tenQuocGia.Equals(value))
                {
                    _tenQuocGia = value;
                    PropertyHasChanged("TenQuocGia");
                }
            }
        }

        public string TenVietTat
        {
            get
            {
                CanReadProperty("TenVietTat", true);
                return _tenVietTat;
            }
            set
            {
                CanWriteProperty("TenVietTat", true);
                if (value == null) value = string.Empty;
                if (!_tenVietTat.Equals(value))
                {
                    _tenVietTat = value;
                    PropertyHasChanged("TenVietTat");
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

        protected override object GetIdValue()
        {
            return _maQuocGia;
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
            // MaQuocGiaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuocGiaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuocGiaQuanLy", 20));
            //
            // TenQuocGia
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenQuocGia");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuocGia", 500));
            //
            // TenVietTat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 50));
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
            //TODO: Define authorization rules in QuocGiaBQ_VT
            //AuthorizationRules.AllowRead("MaQuocGia", "QuocGiaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGiaQuanLy", "QuocGiaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenQuocGia", "QuocGiaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenVietTat", "QuocGiaBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "QuocGiaBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuocGiaQuanLy", "QuocGiaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenQuocGia", "QuocGiaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenVietTat", "QuocGiaBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "QuocGiaBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuocGiaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuocGiaBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuocGiaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuocGiaBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuocGiaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuocGiaBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuocGiaBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuocGiaBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuocGiaBQ_VT()
        { /* require use of factory method */ }

        public static QuocGiaBQ_VT NewQuocGiaBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuocGiaBQ_VT");
            return DataPortal.Create<QuocGiaBQ_VT>();
        }
        public static QuocGiaBQ_VT NewQuocGiaBQ_VT(string tenQG)
        {
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT();
            qg._tenQuocGia = tenQG;
            return qg;
        }
        public static QuocGiaBQ_VT GetQuocGiaBQ_VT(int maQuocGia)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuocGiaBQ_VT");
            return DataPortal.Fetch<QuocGiaBQ_VT>(new Criteria(maQuocGia));
        }

        public static QuocGiaBQ_VT GetQuocGiaBQ_VT(string tenQuocGia)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuocGiaBQ_VT");
            return DataPortal.Fetch<QuocGiaBQ_VT>(new Criteria_TenQuocGia(tenQuocGia));
        }

        public static void DeleteQuocGiaBQ_VT(int maQuocGia)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuocGiaBQ_VT");
            DataPortal.Delete(new Criteria(maQuocGia));
        }

        public override QuocGiaBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuocGiaBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuocGiaBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuocGiaBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static QuocGiaBQ_VT NewQuocGiaBQ_VTChild()
        {
            QuocGiaBQ_VT child = new QuocGiaBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static QuocGiaBQ_VT GetQuocGiaBQ_VT(SafeDataReader dr)
        {
            QuocGiaBQ_VT child = new QuocGiaBQ_VT();
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
            public int MaQuocGia;

            public Criteria(int maQuocGia)
            {
                this.MaQuocGia = maQuocGia;
            }
        }

        [Serializable()]
        private class Criteria_TenQuocGia
        {
            public string TenQuocGia;

            public Criteria_TenQuocGia(string tenQuocGia)
            {
                this.TenQuocGia = tenQuocGia;
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

        private void ExecuteFetch(SqlTransaction tr, object criteria) //Thang
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblQuocGia";
                    cm.Parameters.AddWithValue("@MaQuocGia", ((Criteria)criteria).MaQuocGia);
                }
                if (criteria is Criteria_TenQuocGia)
                {
                    cm.CommandText = "spd_SelecttblQuocGia_TenQuocGia";
                    cm.Parameters.AddWithValue("@TenQuocGia", ((Criteria_TenQuocGia)criteria).TenQuocGia);
                }

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
            DataPortal_Delete(new Criteria(_maQuocGia));
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
                cm.CommandText = "spd_DeletetblQuocGium";

                cm.Parameters.AddWithValue("@MaQuocGia", criteria.MaQuocGia);

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
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _maQuocGiaQuanLy = dr.GetString("MaQuocGiaQuanLy");
            _tenQuocGia = dr.GetString("TenQuocGia");
            _tenVietTat = dr.GetString("TenVietTat");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, QuocGiaBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, QuocGiaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblQuocGium";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maQuocGia = (int)cm.Parameters["@MaQuocGia"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, QuocGiaBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuocGiaQuanLy", _maQuocGiaQuanLy);
            cm.Parameters.AddWithValue("@TenQuocGia", _tenQuocGia);
            if (_tenVietTat.Length > 0)
                cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            else
                cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            cm.Parameters["@MaQuocGia"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, QuocGiaBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, QuocGiaBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblQuocGium";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, QuocGiaBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            cm.Parameters.AddWithValue("@MaQuocGiaQuanLy", _maQuocGiaQuanLy);
            cm.Parameters.AddWithValue("@TenQuocGia", _tenQuocGia);
            if (_tenVietTat.Length > 0)
                cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
            else
                cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maQuocGia));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

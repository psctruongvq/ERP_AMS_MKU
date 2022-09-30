
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhomPhuCap : Csla.BusinessBase<NhomPhuCap>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maNhom = 0;  // phai sua
        private string _ma = string.Empty;
        private string _ten = string.Empty;
        private int _userID = 0;
        private bool _dangKiemTra = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNhom
        {
            get
            {
                CanReadProperty("MaNhom", true);
                return _maNhom;
            }
        }

        public string Ma
        {
            get
            {
                CanReadProperty("Ma", true);
                return _ma;
            }
            set
            {
                CanWriteProperty("Ma", true);
                if (value == null) value = string.Empty;
                if (!_ma.Equals(value))
                {
                    _ma = value;
                    PropertyHasChanged("Ma");
                }
            }
        }

        public string Ten
        {
            get
            {
                CanReadProperty("Ten", true);
                return _ten;
            }
            set
            {
                CanWriteProperty("Ten", true);
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }

        public int UserID
        {
            get
            {
                CanReadProperty("UserID", true);
                return _userID;
            }
            set
            {
                CanWriteProperty("UserID", true);
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        public bool DangKiemTra
        {
            get
            {
                return _dangKiemTra;
            }
            set
            {
                if (!_dangKiemTra.Equals(value))
                {
                    _dangKiemTra = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNhom;
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
            // Ma
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ma", 20));
            //
            // Ten
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "Ten");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ten", 100));
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
            //TODO: Define authorization rules in NhomPhuCap
            //AuthorizationRules.AllowRead("MaNhom", "NhomPhuCapReadGroup");
            //AuthorizationRules.AllowRead("Ma", "NhomPhuCapReadGroup");
            //AuthorizationRules.AllowRead("Ten", "NhomPhuCapReadGroup");
            //AuthorizationRules.AllowRead("UserID", "NhomPhuCapReadGroup");

            //AuthorizationRules.AllowWrite("Ma", "NhomPhuCapWriteGroup");
            //AuthorizationRules.AllowWrite("Ten", "NhomPhuCapWriteGroup");
            //AuthorizationRules.AllowWrite("UserID", "NhomPhuCapWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhomPhuCap
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhomPhuCap
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhomPhuCap
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhomPhuCap
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomPhuCapDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public NhomPhuCap() // phai chinh sua
        { /* require use of factory method */ }

        public static NhomPhuCap NewNhomPhuCap()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomPhuCap");
            return DataPortal.Create<NhomPhuCap>();
        }

        public static NhomPhuCap GetNhomPhuCap(int maNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomPhuCap");
            return DataPortal.Fetch<NhomPhuCap>(new Criteria(maNhom));
        }

        public static NhomPhuCap GetNhomPhuCapByMaQL(string maQLNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomPhuCap");
            return DataPortal.Fetch<NhomPhuCap>(new CriteriabyMaQLNhom(maQLNhom));
        }

        public static void DeleteNhomPhuCap(int maNhom)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomPhuCap");
            DataPortal.Delete(new Criteria(maNhom));
        }

        public override NhomPhuCap Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomPhuCap");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomPhuCap");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomPhuCap");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhomPhuCap NewNhomPhuCapChild()
        {
            NhomPhuCap child = new NhomPhuCap();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhomPhuCap GetNhomPhuCap(SafeDataReader dr)
        {
            NhomPhuCap child = new NhomPhuCap();
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
            public int MaNhom;

            public Criteria(int maNhom)
            {
                this.MaNhom = maNhom;
            }
        }

        [Serializable()]
        private class CriteriabyMaQLNhom
        {
            public string MaQLNhom;

            public CriteriabyMaQLNhom(string maQLNhom)
            {
                this.MaQLNhom = maQLNhom;
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
                    cm.CommandText = "spd_SelecttblnsPC_NhomPhuCapbyMaNhom";

                    cm.Parameters.AddWithValue("@MaNhom", ((Criteria)criteria).MaNhom);
                }
                else if(criteria is CriteriabyMaQLNhom)
                {
                    cm.CommandText = "spd_SelecttblnsPC_NhomPhuCapbyMaQLNhom";

                    cm.Parameters.AddWithValue("@MaQLNhom", ((CriteriabyMaQLNhom)criteria).MaQLNhom);
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
            DataPortal_Delete(new Criteria(_maNhom));
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
                cm.CommandText = "sp_NhomPCDeletetblnsPC_NhomPhuCap";

                cm.Parameters.AddWithValue("@MaNhom", criteria.MaNhom);

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
            _maNhom = dr.GetInt32("MaNhom");
            _ma = dr.GetString("Ma");
            _ten = dr.GetString("Ten");
            _userID = dr.GetInt32("UserID");
            _dangKiemTra = dr.GetBoolean("DangKiemTra");
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
                cm.CommandText = "sp_NhomPCInserttblnsPC_NhomPhuCap";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNhom = (int)cm.Parameters["@MaNhom"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_ma.Length > 0)
                cm.Parameters.AddWithValue("@Ma", _ma);
            else
                cm.Parameters.AddWithValue("@Ma", DBNull.Value);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaNhom", _maNhom);
            cm.Parameters.AddWithValue("@DangKiemTra", _dangKiemTra);
            cm.Parameters["@MaNhom"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_NhomPCUpdatetblnsPC_NhomPhuCap";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhom", _maNhom);
            if (_ma.Length > 0)
                cm.Parameters.AddWithValue("@Ma", _ma);
            else
                cm.Parameters.AddWithValue("@Ma", DBNull.Value);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@DangKiemTra", _dangKiemTra);
            cm.Parameters.AddWithValue("@UserID", _userID);
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

            ExecuteDelete(tr, new Criteria(_maNhom));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

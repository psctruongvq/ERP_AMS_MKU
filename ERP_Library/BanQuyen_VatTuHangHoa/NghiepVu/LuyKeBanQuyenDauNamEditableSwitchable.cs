
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LuyKeBanQuyenDauNam : Csla.BusinessBase<LuyKeBanQuyenDauNam>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _nam = DateTime.Today.Year;
        private decimal _tonDauNam = 0;
        private decimal _luyKeNhapDauNam = 0;
        private decimal _luyKeXuatDauNam = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
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

        public decimal TonDauNam
        {
            get
            {
                CanReadProperty("TonDauNam", true);
                return _tonDauNam;
            }
            set
            {
                CanWriteProperty("TonDauNam", true);
                if (!_tonDauNam.Equals(value))
                {
                    _tonDauNam = value;
                    PropertyHasChanged("TonDauNam");
                }
            }
        }

        public decimal LuyKeNhapDauNam
        {
            get
            {
                CanReadProperty("LuyKeNhapDauNam", true);
                return _luyKeNhapDauNam;
            }
            set
            {
                CanWriteProperty("LuyKeNhapDauNam", true);
                if (!_luyKeNhapDauNam.Equals(value))
                {
                    _luyKeNhapDauNam = value;
                    PropertyHasChanged("LuyKeNhapDauNam");
                }
            }
        }

        public decimal LuyKeXuatDauNam
        {
            get
            {
                CanReadProperty("LuyKeXuatDauNam", true);
                return _luyKeXuatDauNam;
            }
            set
            {
                CanWriteProperty("LuyKeXuatDauNam", true);
                if (!_luyKeXuatDauNam.Equals(value))
                {
                    _luyKeXuatDauNam = value;
                    PropertyHasChanged("LuyKeXuatDauNam");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _id;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in LuyKeBanQuyenDauNam
            //AuthorizationRules.AllowRead("Id", "LuyKeBanQuyenDauNamReadGroup");
            //AuthorizationRules.AllowRead("Nam", "LuyKeBanQuyenDauNamReadGroup");
            //AuthorizationRules.AllowRead("TonDauNam", "LuyKeBanQuyenDauNamReadGroup");
            //AuthorizationRules.AllowRead("LuyKeNhapDauNam", "LuyKeBanQuyenDauNamReadGroup");
            //AuthorizationRules.AllowRead("LuyKeXuatDauNam", "LuyKeBanQuyenDauNamReadGroup");

            //AuthorizationRules.AllowWrite("Nam", "LuyKeBanQuyenDauNamWriteGroup");
            //AuthorizationRules.AllowWrite("TonDauNam", "LuyKeBanQuyenDauNamWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeNhapDauNam", "LuyKeBanQuyenDauNamWriteGroup");
            //AuthorizationRules.AllowWrite("LuyKeXuatDauNam", "LuyKeBanQuyenDauNamWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LuyKeBanQuyenDauNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuyKeBanQuyenDauNamViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LuyKeBanQuyenDauNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuyKeBanQuyenDauNamAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LuyKeBanQuyenDauNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuyKeBanQuyenDauNamEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LuyKeBanQuyenDauNam
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuyKeBanQuyenDauNamDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LuyKeBanQuyenDauNam()
        { /* require use of factory method */ }

        public static LuyKeBanQuyenDauNam NewLuyKeBanQuyenDauNam()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuyKeBanQuyenDauNam");
            return DataPortal.Create<LuyKeBanQuyenDauNam>();
        }

        public static LuyKeBanQuyenDauNam GetLuyKeBanQuyenDauNam(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuyKeBanQuyenDauNam");
            return DataPortal.Fetch<LuyKeBanQuyenDauNam>(new Criteria(id));
        }
        public static LuyKeBanQuyenDauNam GetLuyKeBanQuyenDauNamTheoNam(int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuyKeBanQuyenDauNam");
            return DataPortal.Fetch<LuyKeBanQuyenDauNam>(new CriteriaNam(nam));
        }

        public static void DeleteLuyKeBanQuyenDauNam(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LuyKeBanQuyenDauNam");
            DataPortal.Delete(new Criteria(id));
        }

        public override LuyKeBanQuyenDauNam Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LuyKeBanQuyenDauNam");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuyKeBanQuyenDauNam");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LuyKeBanQuyenDauNam");

            return base.Save();
        }

        public static bool CheckTonTaiNamLuyKeBanQuyen(int nam)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckTonTaiNamLuyKeBanQuyen";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    SqlParameter outPara = new SqlParameter("@TonTai", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LuyKeBanQuyenDauNam NewLuyKeBanQuyenDauNamChild()
        {
            LuyKeBanQuyenDauNam child = new LuyKeBanQuyenDauNam();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LuyKeBanQuyenDauNam GetLuyKeBanQuyenDauNam(SafeDataReader dr)
        {
            LuyKeBanQuyenDauNam child = new LuyKeBanQuyenDauNam();
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
            public int Id;

            public Criteria(int id)
            {
                this.Id = id;
            }
        }

        private class CriteriaNam
        {
            public int Nam;

            public CriteriaNam(int nam)
            {
                this.Nam = nam;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelectLuyKeBanQuyenDauNam";

                    cm.Parameters.AddWithValue("@id", ((Criteria)criteria).Id);
                }
                else if(criteria is CriteriaNam)
                {
                    cm.CommandText = "spd_SelectLuyKeBanQuyenDauNamTheoNam";

                    cm.Parameters.AddWithValue("@Nam", ((CriteriaNam)criteria).Nam);
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_id));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeleteLuyKeBanQuyenDauNam";

                cm.Parameters.AddWithValue("@id", criteria.Id);

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
            _id = dr.GetInt32("id");
            _nam = dr.GetInt32("Nam");
            _tonDauNam = dr.GetDecimal("TonDauNam");
            _luyKeNhapDauNam = dr.GetDecimal("LuyKeNhapDauNam");
            _luyKeXuatDauNam = dr.GetDecimal("LuyKeXuatDauNam");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertLuyKeBanQuyenDauNam";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@id"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            if (_tonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _tonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);
            if (_luyKeNhapDauNam != 0)
                cm.Parameters.AddWithValue("@LuyKeNhapDauNam", _luyKeNhapDauNam);
            else
                cm.Parameters.AddWithValue("@LuyKeNhapDauNam", DBNull.Value);
            if (_luyKeXuatDauNam != 0)
                cm.Parameters.AddWithValue("@LuyKeXuatDauNam", _luyKeXuatDauNam);
            else
                cm.Parameters.AddWithValue("@LuyKeXuatDauNam", DBNull.Value);
            cm.Parameters.AddWithValue("@id", _id);
            cm.Parameters["@id"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateLuyKeBanQuyenDauNam";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@id", _id);
            if (_nam != 0)
                cm.Parameters.AddWithValue("@Nam", _nam);
            else
                cm.Parameters.AddWithValue("@Nam", DBNull.Value);
            if (_tonDauNam != 0)
                cm.Parameters.AddWithValue("@TonDauNam", _tonDauNam);
            else
                cm.Parameters.AddWithValue("@TonDauNam", DBNull.Value);
            if (_luyKeNhapDauNam != 0)
                cm.Parameters.AddWithValue("@LuyKeNhapDauNam", _luyKeNhapDauNam);
            else
                cm.Parameters.AddWithValue("@LuyKeNhapDauNam", DBNull.Value);
            if (_luyKeXuatDauNam != 0)
                cm.Parameters.AddWithValue("@LuyKeXuatDauNam", _luyKeXuatDauNam);
            else
                cm.Parameters.AddWithValue("@LuyKeXuatDauNam", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

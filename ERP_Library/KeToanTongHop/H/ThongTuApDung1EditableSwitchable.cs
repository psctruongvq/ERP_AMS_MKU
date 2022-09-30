using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTuApDung1 : Csla.BusinessBase<ThongTuApDung1>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _maKy = 0;
        private string _noiDung = string.Empty;
        private string _ghiChu = string.Empty;
        private SmartDate _ngayApDung = new SmartDate(false);
        //private DateTime _ngayApDung = DateTime.Today;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
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

        public DateTime NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                return _ngayApDung.Date;
            }
            //get
            //{
            //    CanReadProperty("NgayApDung", true);
            //    return _ngayApDung;
            //}
            //set
            //{
            //    CanWriteProperty("NgayApDung", true);
            //    if (!_ngayApDung.Equals(value))
            //    {
            //        _ngayApDung = value;
            //        PropertyHasChanged("NgayApDung");
            //    }
            //}
        }

        public string NgayApDungString
        {
            get
            {
                CanReadProperty("NgayApDungString", true);
                return _ngayApDung.Text;
            }
            set
            {
                CanWriteProperty("NgayApDungString", true);
                if (value == null) value = string.Empty;
                if (!_ngayApDung.Equals(value))
                {
                    _ngayApDung.Text = value;
                    PropertyHasChanged("NgayApDungString");
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
            //TODO: Define authorization rules in ThongTuApDung1
            //AuthorizationRules.AllowRead("Id", "ThongTuApDung1ReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "ThongTuApDung1ReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "ThongTuApDung1ReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ThongTuApDung1ReadGroup");
            //AuthorizationRules.AllowRead("NgayApDung", "ThongTuApDung1ReadGroup");
            //AuthorizationRules.AllowRead("NgayApDungString", "ThongTuApDung1ReadGroup");

            //AuthorizationRules.AllowWrite("MaKy", "ThongTuApDung1WriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "ThongTuApDung1WriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ThongTuApDung1WriteGroup");
            //AuthorizationRules.AllowWrite("NgayApDungString", "ThongTuApDung1WriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ThongTuApDung1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1ViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ThongTuApDung1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1AddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ThongTuApDung1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1EditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ThongTuApDung1
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ThongTuApDung1DeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTuApDung1()
        { /* require use of factory method */ }

        public static ThongTuApDung1 NewThongTuApDung1()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTuApDung1");
            return DataPortal.Create<ThongTuApDung1>();
        }

        public static ThongTuApDung1 GetThongTuApDung1(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTuApDung1");
            return DataPortal.Fetch<ThongTuApDung1>(new Criteria(id));
        }

        public static void DeleteThongTuApDung1(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTuApDung1");
            DataPortal.Delete(new Criteria(id));
        }

        public override ThongTuApDung1 Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ThongTuApDung1");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ThongTuApDung1");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ThongTuApDung1");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ThongTuApDung1 NewThongTuApDung1Child()
        {
            ThongTuApDung1 child = new ThongTuApDung1();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ThongTuApDung1 GetThongTuApDung1(SafeDataReader dr)
        {
            ThongTuApDung1 child = new ThongTuApDung1();
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_GetThongTuApDung1";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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

                MarkAsChild();
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
                cm.CommandText = "spd_DeleteThongTuApDung1";

                cm.Parameters.AddWithValue("@Id", criteria.Id);

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
            _id = dr.GetInt32("Id");
            _maKy = dr.GetInt32("MaKy");
            _noiDung = dr.GetString("NoiDung");
            _ghiChu = dr.GetString("GhiChu");
            _ngayApDung = dr.GetSmartDate("NgayApDung", _ngayApDung.EmptyIsMin);
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
                cm.CommandText = "spd_AddThongTuApDung1";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@Id"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            cm.Parameters.AddWithValue("@Id", _id);
            cm.Parameters["@Id"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdateThongTuApDung1";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@Id", _id);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
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

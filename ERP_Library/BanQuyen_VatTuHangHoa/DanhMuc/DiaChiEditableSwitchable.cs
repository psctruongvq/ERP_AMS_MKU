
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DiaChiBQ_VT : Csla.BusinessBase<DiaChiBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDiaChi = 0;
        private string _tenDiaChi = string.Empty;
        private string _quanHuyen = string.Empty;
        private int _maQuanHuyen = 0;
        private int _maTinhThanh = 0;
        private string _tinhTP = string.Empty;
        private int _maQuocGia = 0;
        private string _quocGia = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDiaChi
        {
            get
            {
                CanReadProperty("MaDiaChi", true);
                return _maDiaChi;
            }
        }

        public string TenDiaChi
        {
            get
            {
                CanReadProperty("TenDiaChi", true);
                return _tenDiaChi;
            }
            set
            {
                CanWriteProperty("TenDiaChi", true);
                if (value == null) value = string.Empty;
                if (!_tenDiaChi.Equals(value))
                {
                    _tenDiaChi = value;
                    PropertyHasChanged("TenDiaChi");
                }
            }
        }

        public string QuanHuyen
        {
            get
            {
                CanReadProperty("QuanHuyen", true);
                return _quanHuyen;
            }
            set
            {
                CanWriteProperty("QuanHuyen", true);
                if (value == null) value = string.Empty;
                if (!_quanHuyen.Equals(value))
                {
                    _quanHuyen = value;
                    PropertyHasChanged("QuanHuyen");
                }
            }
        }

        public int MaQuanHuyen
        {
            get
            {
                CanReadProperty("MaQuanHuyen", true);
                return _maQuanHuyen;
            }
            set
            {
                CanWriteProperty("MaQuanHuyen", true);
                if (!_maQuanHuyen.Equals(value))
                {
                    _maQuanHuyen = value;
                    PropertyHasChanged("MaQuanHuyen");
                }
            }
        }

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
                return _maTinhThanh;
            }
            set
            {
                CanWriteProperty("MaTinhThanh", true);
                if (!_maTinhThanh.Equals(value))
                {
                    _maTinhThanh = value;
                    PropertyHasChanged("MaTinhThanh");
                }
            }
        }

        public string TinhTP
        {
            get
            {
                CanReadProperty("TinhTP", true);
                return _tinhTP;
            }
            set
            {
                CanWriteProperty("TinhTP", true);
                if (value == null) value = string.Empty;
                if (!_tinhTP.Equals(value))
                {
                    _tinhTP = value;
                    PropertyHasChanged("TinhTP");
                }
            }
        }

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public string QuocGia
        {
            get
            {
                CanReadProperty("QuocGia", true);
                return _quocGia;
            }
            set
            {
                CanWriteProperty("QuocGia", true);
                if (value == null) value = string.Empty;
                if (!_quocGia.Equals(value))
                {
                    _quocGia = value;
                    PropertyHasChanged("QuocGia");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDiaChi;
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
            // TenDiaChi
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenDiaChi");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDiaChi", 500));
            //
            // QuanHuyen
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "QuanHuyen");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHuyen", 50));
            //
            // TinhTP
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TinhTP");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTP", 50));
            //
            // QuocGia
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "QuocGia");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuocGia", 50));
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
            //TODO: Define authorization rules in DiaChiBQ_VT
            //AuthorizationRules.AllowRead("MaDiaChi", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenDiaChi", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("QuanHuyen", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanHuyen", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaTinhThanh", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTP", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGia", "DiaChiBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("QuocGia", "DiaChiBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("TenDiaChi", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("QuanHuyen", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuanHuyen", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaTinhThanh", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTP", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGia", "DiaChiBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("QuocGia", "DiaChiBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DiaChiBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DiaChiBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DiaChiBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DiaChiBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DiaChiBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DiaChiBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DiaChiBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DiaChiBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DiaChiBQ_VT()
        { /* require use of factory method */ }

        public static DiaChiBQ_VT NewDiaChiBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DiaChiBQ_VT");
            return DataPortal.Create<DiaChiBQ_VT>();
        }

        public static DiaChiBQ_VT GetDiaChiBQ_VT(int maDiaChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DiaChiBQ_VT");
            return DataPortal.Fetch<DiaChiBQ_VT>(new Criteria(maDiaChi));
        }

        public static void DeleteDiaChiBQ_VT(int maDiaChi)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DiaChiBQ_VT");
            DataPortal.Delete(new Criteria(maDiaChi));
        }

        public override DiaChiBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DiaChiBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DiaChiBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DiaChiBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DiaChiBQ_VT NewDiaChiBQ_VTChild()
        {
            DiaChiBQ_VT child = new DiaChiBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DiaChiBQ_VT GetDiaChiBQ_VT(SafeDataReader dr)
        {
            DiaChiBQ_VT child = new DiaChiBQ_VT();
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
            public int MaDiaChi;

            public Criteria(int maDiaChi)
            {
                this.MaDiaChi = maDiaChi;
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
                cm.CommandText = "GetDiaChiBQ_VT";

                cm.Parameters.AddWithValue("@MaDiaChi", criteria.MaDiaChi);

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
            DataPortal_Delete(new Criteria(_maDiaChi));
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
                cm.CommandText = "DeleteDiaChiBQ_VT";

                cm.Parameters.AddWithValue("@MaDiaChi", criteria.MaDiaChi);

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
            _maDiaChi = dr.GetInt32("MaDiaChi");
            _tenDiaChi = dr.GetString("TenDiaChi");
            _quanHuyen = dr.GetString("QuanHuyen");
            _maQuanHuyen = dr.GetInt32("MaQuanHuyen");
            _maTinhThanh = dr.GetInt32("MaTinhThanh");
            _tinhTP = dr.GetString("TinhTP");
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _quocGia = dr.GetString("QuocGia");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DiaChiBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DiaChiBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddDiaChiBQ_VT";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maDiaChi = (int)cm.Parameters["@NewMaDiaChi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DiaChiBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            if (_maQuanHuyen != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyen", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            cm.Parameters.AddWithValue("@QuocGia", _quocGia);
            cm.Parameters.AddWithValue("@NewMaDiaChi", _maDiaChi);
            cm.Parameters["@NewMaDiaChi"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DiaChiBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DiaChiBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateDiaChiBQ_VT";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DiaChiBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            if (_maQuanHuyen != 0)
                cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
            else
                cm.Parameters.AddWithValue("@MaQuanHuyen", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            cm.Parameters.AddWithValue("@QuocGia", _quocGia);
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

            ExecuteDelete(tr, new Criteria(_maDiaChi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

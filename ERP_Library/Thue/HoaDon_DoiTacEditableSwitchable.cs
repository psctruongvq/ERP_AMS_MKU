
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HoaDon_DoiTac : Csla.BusinessBase<HoaDon_DoiTac>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _maHoaDon = 0;
        private string _tenDoiTac = string.Empty;
        private string _diaChi = string.Empty;
        private string _mSThue = string.Empty;
        private string _nguoiLienHe = string.Empty;
        private string _dienThoai = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
                }
            }
        }

        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public string MSThue
        {
            get
            {
                CanReadProperty("MSThue", true);
                return _mSThue;
            }
            set
            {
                CanWriteProperty("MSThue", true);
                if (value == null) value = string.Empty;
                if (!_mSThue.Equals(value))
                {
                    _mSThue = value;
                    PropertyHasChanged("MSThue");
                }
            }
        }

        public string NguoiLienHe
        {
            get
            {
                CanReadProperty("NguoiLienHe", true);
                return _nguoiLienHe;
            }
            set
            {
                CanWriteProperty("NguoiLienHe", true);
                if (value == null) value = string.Empty;
                if (!_nguoiLienHe.Equals(value))
                {
                    _nguoiLienHe = value;
                    PropertyHasChanged("NguoiLienHe");
                }
            }
        }

        public string DienThoai
        {
            get
            {
                CanReadProperty("DienThoai", true);
                return _dienThoai;
            }
            set
            {
                CanWriteProperty("DienThoai", true);
                if (value == null) value = string.Empty;
                if (!_dienThoai.Equals(value))
                {
                    _dienThoai = value;
                    PropertyHasChanged("DienThoai");
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
            //
            // TenDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTac", 500));
            //
            // DiaChi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 4000));
            //
            // MSThue
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MSThue", 50));
            //
            // NguoiLienHe
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiLienHe", 500));
            //
            // DienThoai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 500));
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
            //TODO: Define authorization rules in HoaDon_DoiTac
            //AuthorizationRules.AllowRead("Id", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTac", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("DiaChi", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MSThue", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("NguoiLienHe", "HoaDon_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("DienThoai", "HoaDon_DoiTacReadGroup");

            //AuthorizationRules.AllowWrite("MaHoaDon", "HoaDon_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTac", "HoaDon_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("DiaChi", "HoaDon_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("MSThue", "HoaDon_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLienHe", "HoaDon_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("DienThoai", "HoaDon_DoiTacWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HoaDon_DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HoaDon_DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HoaDon_DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HoaDon_DoiTac
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HoaDon_DoiTacDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HoaDon_DoiTac()
        { /* require use of factory method */ }

        public static HoaDon_DoiTac NewHoaDon_DoiTac()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDon_DoiTac");
            return DataPortal.Create<HoaDon_DoiTac>();
        }

        public static HoaDon_DoiTac GetHoaDon_DoiTac(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon_DoiTac");
            return DataPortal.Fetch<HoaDon_DoiTac>(new Criteria(id));
        }
        public static HoaDon_DoiTac GetHoaDon_DoiTacByHoaDon(long mahoadon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon_DoiTac");
            return DataPortal.Fetch<HoaDon_DoiTac>(new CriteriaByMaHoaDon(mahoadon));
        }
        public static void DeleteHoaDon_DoiTac(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoaDon_DoiTac");
            DataPortal.Delete(new Criteria(id));
        }

        public override HoaDon_DoiTac Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HoaDon_DoiTac");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HoaDon_DoiTac");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HoaDon_DoiTac");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HoaDon_DoiTac NewHoaDon_DoiTacChild()
        {
            HoaDon_DoiTac child = new HoaDon_DoiTac();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HoaDon_DoiTac GetHoaDon_DoiTac(SafeDataReader dr)
        {
            HoaDon_DoiTac child = new HoaDon_DoiTac();
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
            public long Id;

            public Criteria(long id)
            {
                this.Id = id;
            }
        }
        private class CriteriaByMaHoaDon
        {
            public long mahoadon;

            public CriteriaByMaHoaDon(long mahoadon)
            {
                this.mahoadon = mahoadon;
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
                    cm.CommandText = "[spd_SelecttblHoaDon_DoiTac]";
                    cm.Parameters.AddWithValue("@ID", ((Criteria)criteria).Id);
                }
                else if (criteria is CriteriaByMaHoaDon)
                {
                    cm.CommandText = "spd_SelecttblHoaDon_DoiTacByMaHoaDon";
                    cm.Parameters.AddWithValue("@mahoadon", ((CriteriaByMaHoaDon)criteria).mahoadon);

                }

               

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        //dr.Read();
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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeleteHoaDon_DoiTac";

                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);

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
            _id = dr.GetInt64("ID");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _diaChi = dr.GetString("DiaChi");
            _mSThue = dr.GetString("MSThue");
            _nguoiLienHe = dr.GetString("NguoiLienHe");
            _dienThoai = dr.GetString("DienThoai");
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
                cm.CommandText = "[spd_InserttblHoaDon_DoiTac]";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_mSThue.Length > 0)
                cm.Parameters.AddWithValue("@MSThue", _mSThue);
            else
                cm.Parameters.AddWithValue("@MSThue", DBNull.Value);
            if (_nguoiLienHe.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLienHe", _nguoiLienHe);
            else
                cm.Parameters.AddWithValue("@NguoiLienHe", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "[spd_UpdatetblHoaDon_DoiTac]";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            if (_tenDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", _tenDoiTac);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_mSThue.Length > 0)
                cm.Parameters.AddWithValue("@MSThue", _mSThue);
            else
                cm.Parameters.AddWithValue("@MSThue", DBNull.Value);
            if (_nguoiLienHe.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLienHe", _nguoiLienHe);
            else
                cm.Parameters.AddWithValue("@NguoiLienHe", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

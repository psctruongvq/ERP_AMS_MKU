
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BiaBHXH : Csla.BusinessBase<BiaBHXH>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBiaBHXH = 0;
        private string _maBiaBHXHQuanLy = string.Empty;
        private string _tenBiaBHXH = string.Empty;
        private int _soLuongChua = 0;
        private int _soLuongToiDa = 0;
        private SmartDate _ngayTao = new SmartDate(DateTime.Today);
        private long _nguoiTao = Security.CurrentUser.Info.UserID;
        private short _loai = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBiaBHXH
        {
            get
            {
                CanReadProperty("MaBiaBHXH", true);
                return _maBiaBHXH;
            }
        }

        public string MaBiaBHXHQuanLy
        {
            get
            {
                CanReadProperty("MaBiaBHXHQuanLy", true);
                return _maBiaBHXHQuanLy;
            }
            set
            {
                CanWriteProperty("MaBiaBHXHQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maBiaBHXHQuanLy.Equals(value))
                {
                    _maBiaBHXHQuanLy = value;
                    PropertyHasChanged("MaBiaBHXHQuanLy");
                }
            }
        }

        public string TenBiaBHXH
        {
            get
            {
                CanReadProperty("TenBiaBHXH", true);
                return _tenBiaBHXH;
            }
            set
            {
                CanWriteProperty("TenBiaBHXH", true);
                if (value == null) value = string.Empty;
                if (!_tenBiaBHXH.Equals(value))
                {
                    _tenBiaBHXH = value;
                    PropertyHasChanged("TenBiaBHXH");
                }
            }
        }

        public int SoLuongChua
        {
            get
            {
                CanReadProperty("SoLuongChua", true);
                return _soLuongChua;
            }
            set
            {
                CanWriteProperty("SoLuongChua", true);
                if (!_soLuongChua.Equals(value))
                {
                    _soLuongChua = value;
                    PropertyHasChanged("SoLuongChua");
                }
            }
        }

        public int SoLuongToiDa
        {
            get
            {
                CanReadProperty("SoLuongToiDa", true);
                return _soLuongToiDa;
            }
            set
            {
                CanWriteProperty("SoLuongToiDa", true);
                if (!_soLuongToiDa.Equals(value))
                {
                    _soLuongToiDa = value;
                    PropertyHasChanged("SoLuongToiDa");
                }
            }
        }

        public DateTime NgayTao
        {
            get
            {
                CanReadProperty("NgayTao", true);
                return _ngayTao.Date;
            }
            set
            {
                CanWriteProperty("NgayTao", true);
                if (!_ngayTao.Equals(value))
                {
                    _ngayTao = new SmartDate(value);
                    PropertyHasChanged("NgayTao");
                }
            }
        }

        public long NguoiTao
        {
            get
            {
                CanReadProperty("NguoiTao", true);
                return _nguoiTao;
            }
            set
            {
                CanWriteProperty("NguoiTao", true);
                if (!_nguoiTao.Equals(value))
                {
                    _nguoiTao = value;
                    PropertyHasChanged("NguoiTao");
                }
            }
        }

        public short Loai
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
            return _maBiaBHXH;
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
            // MaBiaBHXHQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBiaBHXHQuanLy", 50));
            //
            // TenBiaBHXH
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBiaBHXH", 50));
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
            //TODO: Define authorization rules in BiaBHXH
            //AuthorizationRules.AllowRead("MaBiaBHXH", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("MaBiaBHXHQuanLy", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("TenBiaBHXH", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("SoLuongChua", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("SoLuongToiDa", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("NgayTao", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("NgayTaoString", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("NguoiTao", "BiaBHXHReadGroup");
            //AuthorizationRules.AllowRead("Loai", "BiaBHXHReadGroup");

            //AuthorizationRules.AllowWrite("MaBiaBHXHQuanLy", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("TenBiaBHXH", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongChua", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongToiDa", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTaoString", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiTao", "BiaBHXHWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "BiaBHXHWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BiaBHXH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaBHXHViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BiaBHXH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaBHXHAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BiaBHXH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaBHXHEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BiaBHXH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaBHXHDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BiaBHXH()
        { /* require use of factory method */ }

        public static BiaBHXH NewBiaBHXH()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaBHXH");
            return DataPortal.Create<BiaBHXH>();
        }

        public static BiaBHXH GetBiaBHXH(int maBiaBHXH)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BiaBHXH");
            return DataPortal.Fetch<BiaBHXH>(new Criteria(maBiaBHXH));
        }

        public static void DeleteBiaBHXH(int maBiaBHXH)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaBHXH");
            DataPortal.Delete(new Criteria(maBiaBHXH));
        }

        public override BiaBHXH Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaBHXH");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaBHXH");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BiaBHXH");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BiaBHXH NewBiaBHXHChild()
        {
            BiaBHXH child = new BiaBHXH();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BiaBHXH GetBiaBHXH(SafeDataReader dr)
        {
            BiaBHXH child = new BiaBHXH();
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
            public int MaBiaBHXH;

            public Criteria(int maBiaBHXH)
            {
                this.MaBiaBHXH = maBiaBHXH;
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
                cm.CommandText = "spd_SelecttblnsBiaBHXH";
                cm.Parameters.AddWithValue("@MaBiaBHXH", criteria.MaBiaBHXH);

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
            DataPortal_Delete(new Criteria(_maBiaBHXH));
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
                cm.CommandText = "spd_DeletetblnsBiaBHXH";

                cm.Parameters.AddWithValue("@MaBiaBHXH", criteria.MaBiaBHXH);

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
            _maBiaBHXH = dr.GetInt32("MaBiaBHXH");
            _maBiaBHXHQuanLy = dr.GetString("MaBiaBHXHQuanLy");
            _tenBiaBHXH = dr.GetString("TenBiaBHXH");
            _soLuongChua = dr.GetInt32("SoLuongChua");
            _soLuongToiDa = dr.GetInt32("SoLuongToiDa");
            _ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
            _nguoiTao = dr.GetInt64("NguoiTao");
            _loai = dr.GetInt16("Loai");
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
                cm.CommandText = "spd_InserttblnsBiaBHXH";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBiaBHXH = (int)cm.Parameters["@MaBiaBHXH"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maBiaBHXHQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaBiaBHXHQuanLy", _maBiaBHXHQuanLy);
            else
                cm.Parameters.AddWithValue("@MaBiaBHXHQuanLy", DBNull.Value);
            if (_tenBiaBHXH.Length > 0)
                cm.Parameters.AddWithValue("@TenBiaBHXH", _tenBiaBHXH);
            else
                cm.Parameters.AddWithValue("@TenBiaBHXH", DBNull.Value);
            if (_soLuongChua != 0)
                cm.Parameters.AddWithValue("@SoLuongChua", _soLuongChua);
            else
                cm.Parameters.AddWithValue("@SoLuongChua", DBNull.Value);
            if (_soLuongToiDa != 0)
                cm.Parameters.AddWithValue("@SoLuongToiDa", _soLuongToiDa);
            else
                cm.Parameters.AddWithValue("@SoLuongToiDa", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
            if (_nguoiTao != 0)
                cm.Parameters.AddWithValue("@NguoiTao", _nguoiTao);
            else
                cm.Parameters.AddWithValue("@NguoiTao", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBiaBHXH", _maBiaBHXH);
            cm.Parameters["@MaBiaBHXH"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsBiaBHXH";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBiaBHXH", _maBiaBHXH);
            if (_maBiaBHXHQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaBiaBHXHQuanLy", _maBiaBHXHQuanLy);
            else
                cm.Parameters.AddWithValue("@MaBiaBHXHQuanLy", DBNull.Value);
            if (_tenBiaBHXH.Length > 0)
                cm.Parameters.AddWithValue("@TenBiaBHXH", _tenBiaBHXH);
            else
                cm.Parameters.AddWithValue("@TenBiaBHXH", DBNull.Value);
            if (_soLuongChua != 0)
                cm.Parameters.AddWithValue("@SoLuongChua", _soLuongChua);
            else
                cm.Parameters.AddWithValue("@SoLuongChua", DBNull.Value);
            if (_soLuongToiDa != 0)
                cm.Parameters.AddWithValue("@SoLuongToiDa", _soLuongToiDa);
            else
                cm.Parameters.AddWithValue("@SoLuongToiDa", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
            if (_nguoiTao != 0)
                cm.Parameters.AddWithValue("@NguoiTao", _nguoiTao);
            else
                cm.Parameters.AddWithValue("@NguoiTao", DBNull.Value);
            if (_loai != 0)
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

            ExecuteDelete(tr, new Criteria(_maBiaBHXH));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

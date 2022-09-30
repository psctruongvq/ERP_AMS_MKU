
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BiaHoSo : Csla.BusinessBase<BiaHoSo>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBiaHoSo = 0;
        private string _maBiaHoSoQuanLy = string.Empty;
        private string _tenBiaHoSo = string.Empty;
        private int _soLuongChua = 0;
        private int _soLuongToiDa = 0;
        private SmartDate _ngayTao = new SmartDate(DateTime.Today);
        private long _nguoiTao = Security.CurrentUser.Info.UserID;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaBiaHoSo
        {
            get
            {
                CanReadProperty("MaBiaHoSo", true);
                return _maBiaHoSo;
            }
        }

        public string MaBiaHoSoQuanLy
        {
            get
            {
                CanReadProperty("MaBiaHoSoQuanLy", true);
                return _maBiaHoSoQuanLy;
            }
            set
            {
                CanWriteProperty("MaBiaHoSoQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maBiaHoSoQuanLy.Equals(value))
                {
                    _maBiaHoSoQuanLy = value;
                    PropertyHasChanged("MaBiaHoSoQuanLy");
                }
            }
        }

        public string TenBiaHoSo
        {
            get
            {
                CanReadProperty("TenBiaHoSo", true);
                return _tenBiaHoSo;
            }
            set
            {
                CanWriteProperty("TenBiaHoSo", true);
                if (value == null) value = string.Empty;
                if (!_tenBiaHoSo.Equals(value))
                {
                    _tenBiaHoSo = value;
                    PropertyHasChanged("TenBiaHoSo");
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
                    _ngayTao = new SmartDate (value);
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

        protected override object GetIdValue()
        {
            return _maBiaHoSo;
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
            // MaBiaHoSoQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBiaHoSoQuanLy", 50));
            //
            // TenBiaHoSo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBiaHoSo", 50));
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
            //TODO: Define authorization rules in BiaHoSo
            //AuthorizationRules.AllowRead("MaBiaHoSo", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("MaBiaHoSoQuanLy", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("TenBiaHoSo", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("SoLuongChua", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("SoLuongToiDa", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NgayTao", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NgayTaoString", "BiaHoSoReadGroup");
            //AuthorizationRules.AllowRead("NguoiTao", "BiaHoSoReadGroup");

            //AuthorizationRules.AllowWrite("MaBiaHoSoQuanLy", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("TenBiaHoSo", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongChua", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongToiDa", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("NgayTaoString", "BiaHoSoWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiTao", "BiaHoSoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BiaHoSo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BiaHoSoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BiaHoSo()
        { /* require use of factory method */ }

        public static BiaHoSo NewBiaHoSo()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaHoSo");
            return DataPortal.Create<BiaHoSo>();
        }

        public static BiaHoSo GetBiaHoSo(int maBiaHoSo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BiaHoSo");
            return DataPortal.Fetch<BiaHoSo>(new Criteria(maBiaHoSo));
        }

        public static void DeleteBiaHoSo(int maBiaHoSo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaHoSo");
            DataPortal.Delete(new Criteria(maBiaHoSo));
        }

        public override BiaHoSo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BiaHoSo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BiaHoSo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BiaHoSo");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static BiaHoSo NewBiaHoSoChild()
        {
            BiaHoSo child = new BiaHoSo();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BiaHoSo GetBiaHoSo(SafeDataReader dr)
        {
            BiaHoSo child = new BiaHoSo();
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
            public int MaBiaHoSo;

            public Criteria(int maBiaHoSo)
            {
                this.MaBiaHoSo = maBiaHoSo;
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
                cm.CommandText = "spd_selecttblnsBiahoso";

                cm.Parameters.AddWithValue("@MaBiaHoSo", criteria.MaBiaHoSo);

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
            DataPortal_Delete(new Criteria(_maBiaHoSo));
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
                cm.CommandText = "spd_deletetblnsbiahoso";

                cm.Parameters.AddWithValue("@MaBiaHoSo", criteria.MaBiaHoSo);

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
            _maBiaHoSo = dr.GetInt32("MaBiaHoSo");
            _maBiaHoSoQuanLy = dr.GetString("MaBiaHoSoQuanLy");
            _tenBiaHoSo = dr.GetString("TenBiaHoSo");
            _soLuongChua = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByMabia(_maBiaHoSo).Count;
            _soLuongToiDa = dr.GetInt32("SoLuongToiDa");
            _ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
            _nguoiTao = dr.GetInt64("NguoiTao");
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
                cm.CommandText = "spd_inserttblnsbiahoso";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maBiaHoSo = (int)cm.Parameters["@MaBiaHoSo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maBiaHoSoQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", _maBiaHoSoQuanLy);
            else
                cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", DBNull.Value);
            if (_tenBiaHoSo.Length > 0)
                cm.Parameters.AddWithValue("@TenBiaHoSo", _tenBiaHoSo);
            else
                cm.Parameters.AddWithValue("@TenBiaHoSo", DBNull.Value);
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
            cm.Parameters.AddWithValue("@MaBiaHoSo", _maBiaHoSo);
            cm.Parameters["@MaBiaHoSo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_updatetblnsbiahoso";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBiaHoSo", _maBiaHoSo);
            if (_maBiaHoSoQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", _maBiaHoSoQuanLy);
            else
                cm.Parameters.AddWithValue("@MaBiaHoSoQuanLy", DBNull.Value);
            if (_tenBiaHoSo.Length > 0)
                cm.Parameters.AddWithValue("@TenBiaHoSo", _tenBiaHoSo);
            else
                cm.Parameters.AddWithValue("@TenBiaHoSo", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maBiaHoSo));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

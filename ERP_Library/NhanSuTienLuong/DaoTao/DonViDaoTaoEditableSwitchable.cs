using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DonViDaoTao : Csla.BusinessBase<DonViDaoTao>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDonViDaoTao = 0;
        private string _maQuanLy = string.Empty;
        private string _tenDonViDaoTao = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDonViDaoTao
        {
            get
            {
                CanReadProperty("MaDonViDaoTao", true);
                return _maDonViDaoTao;
            }
        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public string TenDonViDaoTao
        {
            get
            {
                CanReadProperty("TenDonViDaoTao", true);
                return _tenDonViDaoTao;
            }
            set
            {
                CanWriteProperty("TenDonViDaoTao", true);
                if (value == null) value = string.Empty;
                if (!_tenDonViDaoTao.Equals(value))
                {
                    _tenDonViDaoTao = value;
                    PropertyHasChanged("TenDonViDaoTao");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDonViDaoTao;
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
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // TenDonViDaoTao
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenDonViDaoTao");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDonViDaoTao", 500));
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
            //TODO: Define authorization rules in DonViDaoTao
            //AuthorizationRules.AllowRead("MaDonViDaoTao", "DonViDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "DonViDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("TenDonViDaoTao", "DonViDaoTaoReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "DonViDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("TenDonViDaoTao", "DonViDaoTaoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DonViDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViDaoTaoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DonViDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViDaoTaoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DonViDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViDaoTaoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DonViDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DonViDaoTaoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DonViDaoTao()
        { /* require use of factory method */ }

        public static DonViDaoTao NewDonViDaoTao()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViDaoTao");
            return DataPortal.Create<DonViDaoTao>();
        }

        public static DonViDaoTao NewDonViDaoTao(string tenDonViDaoTao)
        {
            DonViDaoTao donvi = new DonViDaoTao();
            donvi._tenDonViDaoTao = tenDonViDaoTao;
            return donvi;
        }

        public static DonViDaoTao GetDonViDaoTao(int maDonViDaoTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DonViDaoTao");
            return DataPortal.Fetch<DonViDaoTao>(new Criteria(maDonViDaoTao));
        }

        public static void DeleteDonViDaoTao(int maDonViDaoTao)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DonViDaoTao");
            DataPortal.Delete(new Criteria(maDonViDaoTao));
        }

        public static void DeleteDonViDaoTao(DonViDaoTao donViDaoTao)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblnsDonViDaoTao";

                        cm.Parameters.AddWithValue("@MaDonViDaoTao", donViDaoTao.MaDonViDaoTao);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                }

            }//using
        }

        public override DonViDaoTao Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DonViDaoTao");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DonViDaoTao");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DonViDaoTao");

            return base.Save();
        }

        #region Bo Sung
        public static bool KiemTraDonViDaoTaoDaSuDung(int maDonViDaoTao)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckDonViDaoTaoDaSuDung";
                    cm.Parameters.AddWithValue("@MaDonViDaoTao", maDonViDaoTao);
                    SqlParameter outPara = new SqlParameter("@DaSuDung", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }

        #endregion

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DonViDaoTao NewDonViDaoTaoChild()
        {
            DonViDaoTao child = new DonViDaoTao();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DonViDaoTao GetDonViDaoTao(SafeDataReader dr)
        {
            DonViDaoTao child = new DonViDaoTao();
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
            public int MaDonViDaoTao;

            public Criteria(int maDonViDaoTao)
            {
                this.MaDonViDaoTao = maDonViDaoTao;
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
                cm.CommandText = "spd_SelecttblnsDonViDaoTao";

                cm.Parameters.AddWithValue("@MaDonViDaoTao", criteria.MaDonViDaoTao);

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
            DataPortal_Delete(new Criteria(_maDonViDaoTao));
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
                cm.CommandText = "spd_DeletetblnsDonViDaoTao";

                cm.Parameters.AddWithValue("@MaDonViDaoTao", criteria.MaDonViDaoTao);

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
            _maDonViDaoTao = dr.GetInt32("MaDonViDaoTao");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenDonViDaoTao = dr.GetString("TenDonViDaoTao");
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
                cm.CommandText = "spd_InserttblnsDonViDaoTao";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDonViDaoTao = (int)cm.Parameters["@MaDonViDaoTao"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDonViDaoTao", _tenDonViDaoTao);
            cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            cm.Parameters["@MaDonViDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsDonViDaoTao";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDonViDaoTao", _tenDonViDaoTao);
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

            ExecuteDelete(cn, new Criteria(_maDonViDaoTao));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

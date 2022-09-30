using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiChungTuDev : Csla.BusinessBase<LoaiChungTuDev>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiCT = 0;
        private string _tenLoaiCT = string.Empty;
        private string _maLoaiCTQuanLy = string.Empty;
        private string _tienTo = string.Empty;
        private int _tongKyTuPhanSo = 0;
        private string _trungTo = string.Empty;
        private string _hauTo = string.Empty;
        private int _tKNo = 0;
        private int _tKCo = 0;
        private string _dienGiai = string.Empty;

        private string _TKNoString = string.Empty;
        private string _TKCoString = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiCT
        {
            get
            {
                CanReadProperty("MaLoaiCT", true);
                return _maLoaiCT;
            }
        }

        public string TenLoaiCT
        {
            get
            {
                CanReadProperty("TenLoaiCT", true);
                return _tenLoaiCT;
            }
            set
            {
                CanWriteProperty("TenLoaiCT", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiCT.Equals(value))
                {
                    _tenLoaiCT = value;
                    PropertyHasChanged("TenLoaiCT");
                }
            }
        }

        public string MaLoaiCTQuanLy
        {
            get
            {
                CanReadProperty("MaLoaiCTQuanLy", true);
                return _maLoaiCTQuanLy;
            }
            set
            {
                CanWriteProperty("MaLoaiCTQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maLoaiCTQuanLy.Equals(value))
                {
                    _maLoaiCTQuanLy = value;
                    PropertyHasChanged("MaLoaiCTQuanLy");
                }
            }
        }

        public string TienTo
        {
            get
            {
                CanReadProperty("TienTo", true);
                return _tienTo;
            }
            set
            {
                CanWriteProperty("TienTo", true);
                if (value == null) value = string.Empty;
                if (!_tienTo.Equals(value))
                {
                    _tienTo = value;
                    PropertyHasChanged("TienTo");
                }
            }
        }

        public int TongKyTuPhanSo
        {
            get
            {
                CanReadProperty("TongKyTuPhanSo", true);
                return _tongKyTuPhanSo;
            }
            set
            {
                CanWriteProperty("TongKyTuPhanSo", true);
                if (!_tongKyTuPhanSo.Equals(value))
                {
                    _tongKyTuPhanSo = value;
                    PropertyHasChanged("TongKyTuPhanSo");
                }
            }
        }

        public string TrungTo
        {
            get
            {
                CanReadProperty("TrungTo", true);
                return _trungTo;
            }
            set
            {
                CanWriteProperty("TrungTo", true);
                if (value == null) value = string.Empty;
                if (!_trungTo.Equals(value))
                {
                    _trungTo = value;
                    PropertyHasChanged("TrungTo");
                }
            }
        }

        public string HauTo
        {
            get
            {
                CanReadProperty("HauTo", true);
                return _hauTo;
            }
            set
            {
                CanWriteProperty("HauTo", true);
                if (value == null) value = string.Empty;
                if (!_hauTo.Equals(value))
                {
                    _hauTo = value;
                    PropertyHasChanged("HauTo");
                }
            }
        }

        public int TKNo
        {
            get
            {
                CanReadProperty("TKNo", true);
                return _tKNo;
            }
            set
            {
                CanWriteProperty("TKNo", true);
                if (!_tKNo.Equals(value))
                {
                    _tKNo = value;
                    PropertyHasChanged("TKNo");
                }
            }
        }

        public int TKCo
        {
            get
            {
                CanReadProperty("TKCo", true);
                return _tKCo;
            }
            set
            {
                CanWriteProperty("TKCo", true);
                if (!_tKCo.Equals(value))
                {
                    _tKCo = value;
                    PropertyHasChanged("TKCo");
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


        public string TKNoString
        {
            get
            {
                CanReadProperty("TKNoString", true);
                return _TKNoString;
            }
        }

        public string TKCoString
        {
            get
            {
                CanReadProperty("TKCoString", true);
                return _TKCoString;
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiCT;
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
            // TenLoaiCT
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiCT");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiCT", 4000));
            //
            // MaLoaiCTQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaLoaiCTQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiCTQuanLy", 50));
            //
            // TienTo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TienTo", 50));
            //
            // TrungTo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrungTo", 10));
            //
            // HauTo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HauTo", 20));
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
            //TODO: Define authorization rules in LoaiChungTuDev
            //AuthorizationRules.AllowRead("MaLoaiCT", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiCT", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiCTQuanLy", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TienTo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TongKyTuPhanSo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TrungTo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("HauTo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TKNo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("TKCo", "LoaiChungTuDevReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "LoaiChungTuDevReadGroup");

            //AuthorizationRules.AllowWrite("TenLoaiCT", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiCTQuanLy", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("TienTo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("TongKyTuPhanSo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("TrungTo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("HauTo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("TKNo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("TKCo", "LoaiChungTuDevWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "LoaiChungTuDevWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiChungTuDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiChungTuDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiChungTuDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiChungTuDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiChungTuDevDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiChungTuDev()
        { /* require use of factory method */ }

        public static LoaiChungTuDev NewLoaiChungTuDev()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiChungTuDev");
            return DataPortal.Create<LoaiChungTuDev>();
        }

        public static LoaiChungTuDev GetLoaiChungTuDev(int maLoaiCT)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiChungTuDev");
            return DataPortal.Fetch<LoaiChungTuDev>(new Criteria(maLoaiCT));
        }
        public static LoaiChungTuDev GetLoaiChungTuDevByMaQuanLy(string maquanly)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiChungTuDev");
            return DataPortal.Fetch<LoaiChungTuDev>(new CriteriaByMaQuanLy(maquanly));
        }

        public static void DeleteLoaiChungTuDev(int maLoaiCT)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiChungTuDev");
            DataPortal.Delete(new Criteria(maLoaiCT));
        }

        public override LoaiChungTuDev Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiChungTuDev");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiChungTuDev");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiChungTuDev");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiChungTuDev NewLoaiChungTuDevChild()
        {
            LoaiChungTuDev child = new LoaiChungTuDev();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiChungTuDev GetLoaiChungTuDev(SafeDataReader dr)
        {
            LoaiChungTuDev child = new LoaiChungTuDev();
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
            public int MaLoaiCT;

            public Criteria(int maLoaiCT)
            {
                this.MaLoaiCT = maLoaiCT;
            }
        }

        [Serializable()]
        private class CriteriaByMaQuanLy
        {
            public string MaQuanLy;

            public CriteriaByMaQuanLy(string maql)
            {
                this.MaQuanLy = maql;
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
                    cm.CommandText = "spd_SelecttblLoaiChungTuDev";
                    cm.Parameters.AddWithValue("@MaLoaiCT",((Criteria) criteria).MaLoaiCT);
                }
                else if (criteria is CriteriaByMaQuanLy)
                {
                    cm.CommandText = "spd_SelecttblLoaiChungTuDevByMaQuanLy";
                    cm.Parameters.AddWithValue("@MaQuanLy", ((CriteriaByMaQuanLy)criteria).MaQuanLy);
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
            DataPortal_Delete(new Criteria(_maLoaiCT));
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
                cm.CommandText = "spd_DeletetblLoaiChungTuDev";

                cm.Parameters.AddWithValue("@MaLoaiCT", criteria.MaLoaiCT);

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
            _maLoaiCT = dr.GetInt32("MaLoaiCT");
            _tenLoaiCT = dr.GetString("TenLoaiCT");
            _maLoaiCTQuanLy = dr.GetString("MaLoaiCTQuanLy");
            _tienTo = dr.GetString("TienTo");
            _tongKyTuPhanSo = dr.GetInt32("TongKyTuPhanSo");
            _trungTo = dr.GetString("TrungTo");
            _hauTo = dr.GetString("HauTo");
            _tKNo = dr.GetInt32("TKNo");
            _tKCo = dr.GetInt32("TKCo");
            _dienGiai = dr.GetString("DienGiai");
            _TKNoString = dr.GetString("TKNoString");
            _TKCoString = dr.GetString("TKCoString");
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
                cm.CommandText = "spd_InserttblLoaiChungTuDev";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiCT = (int)cm.Parameters["@MaLoaiCT"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenLoaiCT", _tenLoaiCT);
            cm.Parameters.AddWithValue("@MaLoaiCTQuanLy", _maLoaiCTQuanLy);
            if (_tienTo.Length > 0)
                cm.Parameters.AddWithValue("@TienTo", _tienTo);
            else
                cm.Parameters.AddWithValue("@TienTo", DBNull.Value);
            if (_tongKyTuPhanSo != 0)
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", _tongKyTuPhanSo);
            else
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", DBNull.Value);
            if (_trungTo.Length > 0)
                cm.Parameters.AddWithValue("@TrungTo", _trungTo);
            else
                cm.Parameters.AddWithValue("@TrungTo", DBNull.Value);
            if (_hauTo.Length > 0)
                cm.Parameters.AddWithValue("@HauTo", _hauTo);
            else
                cm.Parameters.AddWithValue("@HauTo", DBNull.Value);
           
            if (_tKNo != 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo != 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLoaiCT", _maLoaiCT);
            cm.Parameters["@MaLoaiCT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblLoaiChungTuDev";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiCT", _maLoaiCT);
            cm.Parameters.AddWithValue("@TenLoaiCT", _tenLoaiCT);
            cm.Parameters.AddWithValue("@MaLoaiCTQuanLy", _maLoaiCTQuanLy);
            if (_tienTo.Length > 0)
                cm.Parameters.AddWithValue("@TienTo", _tienTo);
            else
                cm.Parameters.AddWithValue("@TienTo", DBNull.Value);
            if (_tongKyTuPhanSo != 0)
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", _tongKyTuPhanSo);
            else
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", DBNull.Value);
            if (_trungTo.Length > 0)
                cm.Parameters.AddWithValue("@TrungTo", _trungTo);
            else
                cm.Parameters.AddWithValue("@TrungTo", DBNull.Value);
            if (_hauTo.Length > 0)
                cm.Parameters.AddWithValue("@HauTo", _hauTo);
            else
                cm.Parameters.AddWithValue("@HauTo", DBNull.Value);
            
            if (_tKNo != 0)
                cm.Parameters.AddWithValue("@TKNo", _tKNo);
            else
                cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
            if (_tKCo != 0)
                cm.Parameters.AddWithValue("@TKCo", _tKCo);
            else
                cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

            ExecuteDelete(cn, new Criteria(_maLoaiCT));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

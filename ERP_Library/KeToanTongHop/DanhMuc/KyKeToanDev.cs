using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KyKeToanDev : Csla.BusinessBase<KyKeToanDev>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKy = 0;
        private string _tenKy = string.Empty;
        private bool _khoaSo = false;
        private int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
        }

        public string TenKy
        {
            get
            {
                CanReadProperty("TenKy", true);
                return _tenKy;
            }
            set
            {
                CanWriteProperty("TenKy", true);
                if (value == null) value = string.Empty;
                if (!_tenKy.Equals(value))
                {
                    _tenKy = value;
                    PropertyHasChanged("TenKy");
                }
            }
        }

        public bool KhoaSo
        {
            get
            {
                CanReadProperty("KhoaSo", true);
                return _khoaSo;
            }
            set
            {
                CanWriteProperty("KhoaSo", true);
                if (!_khoaSo.Equals(value))
                {
                    _khoaSo = value;
                    PropertyHasChanged("KhoaSo");
                }
            }
        }

        DateTime _NgayBatDau;
        public DateTime NgayBatDau
        {
            get
            {
                CanReadProperty(true);
                return _NgayBatDau;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayBatDau.Equals(value))
                {
                    _NgayBatDau = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayKetThuc;
        public DateTime NgayKetThuc
        {
            get
            {
                CanReadProperty(true);
                return _NgayKetThuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayKetThuc.Equals(value))
                {
                    _NgayKetThuc = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKy;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ////
            //// TenKy
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenKy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKy", 4000));
            ////
            //// NgayBatDau
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayBatDauString");
            ////
            //// NgayKetThuc
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayKetThucString");
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
            //TODO: Define authorization rules in KyKeToanDev
            //AuthorizationRules.AllowRead("MaKy", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("TenKy", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("KhoaSo", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("NgayBatDau", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("NgayBatDauString", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThuc", "KyKeToanDevReadGroup");
            //AuthorizationRules.AllowRead("NgayKetThucString", "KyKeToanDevReadGroup");

            //AuthorizationRules.AllowWrite("TenKy", "KyKeToanDevWriteGroup");
            //AuthorizationRules.AllowWrite("KhoaSo", "KyKeToanDevWriteGroup");
            //AuthorizationRules.AllowWrite("NgayBatDauString", "KyKeToanDevWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKetThucString", "KyKeToanDevWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KyKeToanDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KyKeToanDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KyKeToanDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KyKeToanDev
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KyKeToanDevDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KyKeToanDev()
        { /* require use of factory method */ }

        public static KyKeToanDev NewKyKeToanDev()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KyKeToanDev");
            return DataPortal.Create<KyKeToanDev>();
        }

        public static KyKeToanDev GetKyKeToanDev(int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyKeToanDev");
            return DataPortal.Fetch<KyKeToanDev>(new Criteria(maKy));
        }

        public static void DeleteKyKeToanDev(int maKy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KyKeToanDev");
            DataPortal.Delete(new Criteria(maKy));
        }

        public override KyKeToanDev Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KyKeToanDev");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KyKeToanDev");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KyKeToanDev");

            return base.Save();
        }

        public static bool KiemTraTrungNgayBatDauKyKeToan(int maKy, DateTime ngayBatDau)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraTrungNgayBatDauKyKeToan";
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@NgayBatDau", ngayBatDau);
                    SqlParameter outPara = new SqlParameter("@RS", SqlDbType.Bit);
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
        internal static KyKeToanDev NewKyKeToanDevChild()
        {
            KyKeToanDev child = new KyKeToanDev();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KyKeToanDev GetKyKeToanDev(SafeDataReader dr)
        {
            KyKeToanDev child = new KyKeToanDev();
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
            public int MaKy;

            public Criteria(int maKy)
            {
                this.MaKy = maKy;
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
                cm.CommandText = "spd_SelecttblKyKeToanDev";

                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
            DataPortal_Delete(new Criteria(_maKy));
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
                cm.CommandText = "spd_DeletetblKyKeToanDev";

                cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
            _maKy = dr.GetInt32("MaKy");
            _tenKy = dr.GetString("TenKy");
            _khoaSo = dr.GetBoolean("KhoaSo");
            _NgayBatDau = dr.GetDateTime("NgayBatDau");
            _NgayKetThuc = dr.GetDateTime("NgayKetThuc");
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
                cm.CommandText = "spd_InserttblKyKeToanDev";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKy = (int)cm.Parameters["@MaKy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenKy", _tenKy);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBatDau", _NgayBatDau);
            cm.Parameters.AddWithValue("@NgayKetThuc", _NgayKetThuc);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTyCurrent);
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters["@MaKy"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKyKeToanDev";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@TenKy", _tenKy);
            if (_khoaSo != false)
                cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            else
                cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBatDau", _NgayBatDau);
            cm.Parameters.AddWithValue("@NgayKetThuc", _NgayKetThuc);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTyCurrent);
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

            ExecuteDelete(cn, new Criteria(_maKy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

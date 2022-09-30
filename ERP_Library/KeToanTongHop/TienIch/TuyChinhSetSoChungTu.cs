using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TuyChinhSetSoChungTu : Csla.BusinessBase<TuyChinhSetSoChungTu>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _maLoaiCT = 0;
        private string _tienTo = string.Empty;
        private string _trungTo = string.Empty;
        private string _hauTo = string.Empty;
        private int _tongKyTuPhanSo = 0;
        private int _kyTuSoBatDau = 0;
        private int _userLap = 0;
        private string _tenLoaiCT = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int MaLoaiCT
        {
            get
            {
                CanReadProperty("MaLoaiCT", true);
                return _maLoaiCT;
            }
            set
            {
                CanWriteProperty("MaLoaiCT", true);
                if (!_maLoaiCT.Equals(value))
                {
                    _maLoaiCT = value;
                    PropertyHasChanged("MaLoaiCT");
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

        public int KyTuSoBatDau
        {
            get
            {
                CanReadProperty("KyTuSoBatDau", true);
                return _kyTuSoBatDau;
            }
            set
            {
                CanWriteProperty("KyTuSoBatDau", true);
                if (!_kyTuSoBatDau.Equals(value))
                {
                    _kyTuSoBatDau = value;
                    PropertyHasChanged("KyTuSoBatDau");
                }
            }
        }

        public int UserLap
        {
            get
            {
                CanReadProperty("UserLap", true);
                return _userLap;
            }
            set
            {
                CanWriteProperty("UserLap", true);
                if (!_userLap.Equals(value))
                {
                    _userLap = value;
                    PropertyHasChanged("UserLap");
                }
            }
        }

        public string TenLoaiCT
        {
            get
            {
                CanReadProperty("TenLoaiCT", true);
                return _tenLoaiCT;
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
            //TODO: Define authorization rules in TuyChinhSetSoChungTu
            //AuthorizationRules.AllowRead("Id", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiCT", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("TienTo", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("TrungTo", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("HauTo", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("TongKyTuPhanSo", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("KyTuSoBatDau", "TuyChinhSetSoChungTuReadGroup");
            //AuthorizationRules.AllowRead("UserLap", "TuyChinhSetSoChungTuReadGroup");

            //AuthorizationRules.AllowWrite("MaLoaiCT", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("TienTo", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("TrungTo", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("HauTo", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("TongKyTuPhanSo", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("KyTuSoBatDau", "TuyChinhSetSoChungTuWriteGroup");
            //AuthorizationRules.AllowWrite("UserLap", "TuyChinhSetSoChungTuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TuyChinhSetSoChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TuyChinhSetSoChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TuyChinhSetSoChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TuyChinhSetSoChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TuyChinhSetSoChungTuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TuyChinhSetSoChungTu()
        { /* require use of factory method */ }

        public static TuyChinhSetSoChungTu NewTuyChinhSetSoChungTu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TuyChinhSetSoChungTu");
            return DataPortal.Create<TuyChinhSetSoChungTu>();
        }

        public static TuyChinhSetSoChungTu GetTuyChinhSetSoChungTu(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TuyChinhSetSoChungTu");
            return DataPortal.Fetch<TuyChinhSetSoChungTu>(new Criteria(id));
        }

        public static void DeleteTuyChinhSetSoChungTu(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TuyChinhSetSoChungTu");
            DataPortal.Delete(new Criteria(id));
        }

        public override TuyChinhSetSoChungTu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TuyChinhSetSoChungTu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TuyChinhSetSoChungTu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a TuyChinhSetSoChungTu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static TuyChinhSetSoChungTu NewTuyChinhSetSoChungTuChild()
        {
            TuyChinhSetSoChungTu child = new TuyChinhSetSoChungTu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static TuyChinhSetSoChungTu GetTuyChinhSetSoChungTu(SafeDataReader dr)
        {
            TuyChinhSetSoChungTu child = new TuyChinhSetSoChungTu();
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
                cm.CommandText = "spd_SelecttblTuyChinhSetSoChungTu";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
                cm.CommandText = "spd_DeletetblTuyChinhSetSoChungTu";

                cm.Parameters.AddWithValue("@ID", criteria.Id);
                cm.Parameters.AddWithValue("@UserLap", ERP_Library.Security.CurrentUser.Info.UserID);
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
            _id = dr.GetInt32("ID");
            _maLoaiCT = dr.GetInt32("MaLoaiCT");
            _tienTo = dr.GetString("TienTo");
            _trungTo = dr.GetString("TrungTo");
            _hauTo = dr.GetString("HauTo");
            _tongKyTuPhanSo = dr.GetInt32("TongKyTuPhanSo");
            _kyTuSoBatDau = dr.GetInt32("KyTuSoBatDau");
            _userLap = dr.GetInt32("UserLap");
            _tenLoaiCT = dr.GetString("TenLoaiCT");
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
                cm.CommandText = "spd_InserttblTuyChinhSetSoChungTu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiCT", _maLoaiCT);
            if (_tienTo.Length > 0)
                cm.Parameters.AddWithValue("@TienTo", _tienTo);
            else
                cm.Parameters.AddWithValue("@TienTo", DBNull.Value);
            if (_trungTo.Length > 0)
                cm.Parameters.AddWithValue("@TrungTo", _trungTo);
            else
                cm.Parameters.AddWithValue("@TrungTo", DBNull.Value);
            if (_hauTo.Length > 0)
                cm.Parameters.AddWithValue("@HauTo", _hauTo);
            else
                cm.Parameters.AddWithValue("@HauTo", DBNull.Value);
            if (_tongKyTuPhanSo != 0)
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", _tongKyTuPhanSo);
            else
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", DBNull.Value);
            if (_kyTuSoBatDau != 0)
                cm.Parameters.AddWithValue("@KyTuSoBatDau", _kyTuSoBatDau);
            else
                cm.Parameters.AddWithValue("@KyTuSoBatDau", DBNull.Value);
            if (_userLap != 0)
                cm.Parameters.AddWithValue("@UserLap", _userLap);
            else
                cm.Parameters.AddWithValue("@UserLap", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblTuyChinhSetSoChungTu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters.AddWithValue("@MaLoaiCT", _maLoaiCT);
            if (_tienTo.Length > 0)
                cm.Parameters.AddWithValue("@TienTo", _tienTo);
            else
                cm.Parameters.AddWithValue("@TienTo", DBNull.Value);
            if (_trungTo.Length > 0)
                cm.Parameters.AddWithValue("@TrungTo", _trungTo);
            else
                cm.Parameters.AddWithValue("@TrungTo", DBNull.Value);
            if (_hauTo.Length > 0)
                cm.Parameters.AddWithValue("@HauTo", _hauTo);
            else
                cm.Parameters.AddWithValue("@HauTo", DBNull.Value);
            if (_tongKyTuPhanSo != 0)
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", _tongKyTuPhanSo);
            else
                cm.Parameters.AddWithValue("@TongKyTuPhanSo", DBNull.Value);
            if (_kyTuSoBatDau != 0)
                cm.Parameters.AddWithValue("@KyTuSoBatDau", _kyTuSoBatDau);
            else
                cm.Parameters.AddWithValue("@KyTuSoBatDau", DBNull.Value);
            if (_userLap != 0)
                cm.Parameters.AddWithValue("@UserLap", _userLap);
            else
                cm.Parameters.AddWithValue("@UserLap", DBNull.Value);
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

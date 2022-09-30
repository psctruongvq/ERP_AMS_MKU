
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KeHoachHopDong : Csla.BusinessBase<KeHoachHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKeHoach = 0;
        private string _tenQLKeHoach = string.Empty;
        private string _tenKeHoach = string.Empty;
        private int _maPhongBan = 0;
        private string _tenBoPhan = string.Empty;
        private decimal _soTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKeHoach
        {
            get
            {
                CanReadProperty("MaKeHoach", true);
                return _maKeHoach;
            }
        }

        public string TenQLKeHoach
        {
            get
            {
                CanReadProperty("TenQLKeHoach", true);
                return _tenQLKeHoach;
            }
            set
            {
                CanWriteProperty("TenQLKeHoach", true);
                if (value == null) value = string.Empty;
                if (!_tenQLKeHoach.Equals(value))
                {
                    _tenQLKeHoach = value;
                    PropertyHasChanged("TenQLKeHoach");
                }
            }
        }

        public string TenKeHoach
        {
            get
            {
                CanReadProperty("TenKeHoach", true);
                return _tenKeHoach;
            }
            set
            {
                CanWriteProperty("TenKeHoach", true);
                if (value == null) value = string.Empty;
                if (!_tenKeHoach.Equals(value))
                {
                    _tenKeHoach = value;
                    PropertyHasChanged("TenKeHoach");
                }
            }
        }

        public int MaPhongBan
        {
            get
            {
                CanReadProperty("MaPhongBan", true);
                return _maPhongBan;
            }
            set
            {
                CanWriteProperty("MaPhongBan", true);
                if (!_maPhongBan.Equals(value))
                {
                    _maPhongBan = value;
                    if (_maPhongBan != 0)
                    {
                        _tenBoPhan = BoPhan.GetBoPhan(_maPhongBan).TenBoPhan;
                    }
                    else
                    {
                        _tenBoPhan = string.Empty;
                    }
                    PropertyHasChanged("MaPhongBan");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }

        }

        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKeHoach;
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
            // TenQLKeHoach
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQLKeHoach", 100));
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
            //TODO: Define authorization rules in KeHoachHopDong
            //AuthorizationRules.AllowRead("MaKeHoach", "KeHoachHopDongReadGroup");
            //AuthorizationRules.AllowRead("TenQLKeHoach", "KeHoachHopDongReadGroup");
            //AuthorizationRules.AllowRead("TenKeHoach", "KeHoachHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaPhongBan", "KeHoachHopDongReadGroup");

            //AuthorizationRules.AllowWrite("TenQLKeHoach", "KeHoachHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TenKeHoach", "KeHoachHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhongBan", "KeHoachHopDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KeHoachHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KeHoachHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KeHoachHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KeHoachHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KeHoachHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KeHoachHopDong()
        { /* require use of factory method */ }

        public static KeHoachHopDong NewKeHoachHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KeHoachHopDong");
            return DataPortal.Create<KeHoachHopDong>();
        }

        public static KeHoachHopDong NewKeHoachHopDong(string tenKeHoach)
        {
            KeHoachHopDong kh = KeHoachHopDong.NewKeHoachHopDong();
            kh.TenKeHoach = tenKeHoach;
            return kh;
        }

        public static KeHoachHopDong GetKeHoachHopDong(int maKeHoach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KeHoachHopDong");
            return DataPortal.Fetch<KeHoachHopDong>(new Criteria(maKeHoach));
        }

        public static void DeleteKeHoachHopDong(int maKeHoach)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KeHoachHopDong");
            DataPortal.Delete(new Criteria(maKeHoach));
        }

        public override KeHoachHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KeHoachHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KeHoachHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KeHoachHopDong");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KeHoachHopDong NewKeHoachHopDongChild()
        {
            KeHoachHopDong child = new KeHoachHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KeHoachHopDong GetKeHoachHopDong(SafeDataReader dr)
        {
            KeHoachHopDong child = new KeHoachHopDong();
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
            public int MaKeHoach;

            public Criteria(int maKeHoach)
            {
                this.MaKeHoach = maKeHoach;
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
                cm.CommandText = "spd_SelecttblKeHoachHopDong";

                cm.Parameters.AddWithValue("@MaKeHoach", criteria.MaKeHoach);

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
            DataPortal_Delete(new Criteria(_maKeHoach));
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
                cm.CommandText = "spd_DeletetblKeHoachHopDong";

                cm.Parameters.AddWithValue("@MaKeHoach", criteria.MaKeHoach);

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
            _maKeHoach = dr.GetInt32("MaKeHoach");
            _tenQLKeHoach = dr.GetString("TenQLKeHoach");
            _tenKeHoach = dr.GetString("TenKeHoach");
            _maPhongBan = dr.GetInt32("MaPhongBan");
            _soTien = dr.GetDecimal("SoTien");
            if (_maPhongBan != 0)
            {
                _tenBoPhan = BoPhan.GetBoPhan(_maPhongBan).TenBoPhan;
            }
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
                cm.CommandText = "spd_InserttblKeHoachHopDong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKeHoach = (int)cm.Parameters["@MaKeHoach"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenQLKeHoach.Length > 0)
                cm.Parameters.AddWithValue("@TenQLKeHoach", _tenQLKeHoach);
            else
                cm.Parameters.AddWithValue("@TenQLKeHoach", DBNull.Value);
            if (_tenKeHoach.Length > 0)
                cm.Parameters.AddWithValue("@TenKeHoach", _tenKeHoach);
            else
                cm.Parameters.AddWithValue("@TenKeHoach", DBNull.Value);
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKeHoach", _maKeHoach);
            cm.Parameters["@MaKeHoach"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKeHoachHopDong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKeHoach", _maKeHoach);
            if (_tenQLKeHoach.Length > 0)
                cm.Parameters.AddWithValue("@TenQLKeHoach", _tenQLKeHoach);
            else
                cm.Parameters.AddWithValue("@TenQLKeHoach", DBNull.Value);
            if (_tenKeHoach.Length > 0)
                cm.Parameters.AddWithValue("@TenKeHoach", _tenKeHoach);
            else
                cm.Parameters.AddWithValue("@TenKeHoach", DBNull.Value);
            if (_maPhongBan != 0)
                cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
            else
                cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maKeHoach));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class HinhThucTangCaChild : Csla.BusinessBase<HinhThucTangCaChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maLoaiTangCa = 0;
        private string _maQuanLy = string.Empty;
        private string _tenLoaiTangCa = string.Empty;
        private string _ghiChu = string.Empty;
        private string _thoiGian = "";
        private int _maNhomPhuCap = 0;
        private int _maLoaiPhuCap = 0;
        private bool _chon = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiTangCa
        {
            get
            {
                CanReadProperty("MaLoaiTangCa", true);
                return _maLoaiTangCa;
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

        public string TenLoaiTangCa
        {
            get
            {
                CanReadProperty("TenLoaiTangCa", true);
                return _tenLoaiTangCa;
            }
            set
            {
                CanWriteProperty("TenLoaiTangCa", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiTangCa.Equals(value))
                {
                    _tenLoaiTangCa = value;
                    PropertyHasChanged("TenLoaiTangCa");
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

        public string ThoiGian
        {
            get
            {
                return _thoiGian;
            }
            set
            {
                if (!_thoiGian.Equals(value))
                {
                    _thoiGian = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaNhomPhuCap
        {
            get
            {
                return _maNhomPhuCap;
            }
            set
            {
                if (!_maNhomPhuCap.Equals(value))
                {
                    _maNhomPhuCap = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaLoaiPhuCap
        {
            get
            {
                return _maLoaiPhuCap;
            }
            set
            {
                if (!_maLoaiPhuCap.Equals(value))
                {
                    _maLoaiPhuCap = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool Chon
        {
            get
            {
                return _chon;
            }
            set
            {
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiTangCa;
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
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // TenLoaiTangCa
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiTangCa");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiTangCa", 500));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
            //TODO: Define authorization rules in HinhThucTangCaChild
            //AuthorizationRules.AllowRead("MaLoaiTangCa", "HinhThucTangCaChildReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "HinhThucTangCaChildReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiTangCa", "HinhThucTangCaChildReadGroup");
            //AuthorizationRules.AllowRead("PhanTram", "HinhThucTangCaChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "HinhThucTangCaChildReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucTangCaChildWriteGroup");
            //AuthorizationRules.AllowWrite("TenLoaiTangCa", "HinhThucTangCaChildWriteGroup");
            //AuthorizationRules.AllowWrite("PhanTram", "HinhThucTangCaChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "HinhThucTangCaChildWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HinhThucTangCaChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaChildViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HinhThucTangCaChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaChildAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HinhThucTangCaChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaChildEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HinhThucTangCaChild
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HinhThucTangCaChildDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HinhThucTangCaChild()
        { /* require use of factory method */ }

        public static HinhThucTangCaChild NewHinhThucTangCaChild()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HinhThucTangCaChild");
            return DataPortal.Create<HinhThucTangCaChild>();
        }

        public static HinhThucTangCaChild GetHinhThucTangCaChild(int maLoaiTangCa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HinhThucTangCaChild");
            return DataPortal.Fetch<HinhThucTangCaChild>(new Criteria(maLoaiTangCa));
        }

        public static void DeleteHinhThucTangCaChild(int maLoaiTangCa)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HinhThucTangCaChild");
            DataPortal.Delete(new Criteria(maLoaiTangCa));
        }

        public override HinhThucTangCaChild Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a HinhThucTangCaChild");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HinhThucTangCaChild");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a HinhThucTangCaChild");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static HinhThucTangCaChild NewHinhThucTangCaChildChild()
        {
            HinhThucTangCaChild child = new HinhThucTangCaChild();
            //child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static HinhThucTangCaChild GetHinhThucTangCaChild(SafeDataReader dr)
        {
            HinhThucTangCaChild child = new HinhThucTangCaChild();
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
            public int MaLoaiTangCa;

            public Criteria(int maLoaiTangCa)
            {
                this.MaLoaiTangCa = maLoaiTangCa;
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
                cm.CommandText = "spd_Select_HinhThucTangCaChild";

                cm.Parameters.AddWithValue("@MaLoaiTangCa", criteria.MaLoaiTangCa);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    //ValidationRules.CheckRules();

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
            DataPortal_Delete(new Criteria(_maLoaiTangCa));
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
                cm.CommandText = "spd_Delete_HinhThucTangCaChild";

                cm.Parameters.AddWithValue("@MaLoaiTangCa", criteria.MaLoaiTangCa);

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
            _maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenLoaiTangCa = dr.GetString("TenLoaiTangCa");
            _ghiChu = dr.GetString("GhiChu");
            _thoiGian = dr.GetString("ThoiGian");
            _maNhomPhuCap = dr.GetInt32("MaNhomPhuCap");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _chon = dr.GetBoolean("Chon");
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
                cm.CommandText = "spd_Insert_HinhThucTangCaChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiTangCa = (int)cm.Parameters["@MaLoaiTangCa"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiTangCa", _tenLoaiTangCa);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNhomPhuCap == 0)
                cm.Parameters.AddWithValue("@MaNhomPhuCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
            if (_maLoaiPhuCap == 0)
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@ThoiGian", _thoiGian);
            cm.Parameters["@MaLoaiTangCa"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@Chon", _chon);
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
                cm.CommandText = "spd_Update_HinhThucTangCaChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenLoaiTangCa", _tenLoaiTangCa);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNhomPhuCap == 0)
                cm.Parameters.AddWithValue("@MaNhomPhuCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
            if (_maLoaiPhuCap == 0)
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@ThoiGian", _thoiGian);
            cm.Parameters.AddWithValue("@Chon", _chon);
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

            ExecuteDelete(tr, new Criteria(_maLoaiTangCa));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public void AsChild()
        {
            base.MarkAsChild();
        }
    }
}

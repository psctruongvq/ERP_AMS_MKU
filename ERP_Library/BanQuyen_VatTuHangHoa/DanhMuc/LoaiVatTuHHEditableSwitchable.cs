
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiVatTuHHBQ_VT : Csla.BusinessBase<LoaiVatTuHHBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiVatTuHH = 0;
        private string _maQuanLy = string.Empty;
        private string _tenLoaiVatTuHH = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _tinhTrang = true;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLoaiVatTuHH
        {
            get
            {
                CanReadProperty("MaLoaiVatTuHH", true);
                return _maLoaiVatTuHH;
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

        public string TenLoaiVatTuHH
        {
            get
            {
                CanReadProperty("TenLoaiVatTuHH", true);
                return _tenLoaiVatTuHH;
            }
            set
            {
                CanWriteProperty("TenLoaiVatTuHH", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiVatTuHH.Equals(value))
                {
                    _tenLoaiVatTuHH = value;
                    PropertyHasChanged("TenLoaiVatTuHH");
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

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiVatTuHH;
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
            // TenLoaiVatTuHH
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiVatTuHH");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiVatTuHH", 100));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
            //TODO: Define authorization rules in LoaiVatTuHHBQ_VT
            //AuthorizationRules.AllowRead("MaLoaiVatTuHH", "LoaiVatTuHHBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "LoaiVatTuHHBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiVatTuHH", "LoaiVatTuHHBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "LoaiVatTuHHBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "LoaiVatTuHHBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "LoaiVatTuHHBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenLoaiVatTuHH", "LoaiVatTuHHBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "LoaiVatTuHHBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "LoaiVatTuHHBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiVatTuHHBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiVatTuHHBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiVatTuHHBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiVatTuHHBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiVatTuHHBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiVatTuHHBQ_VT()
        { /* require use of factory method */
            base.MarkAsChild();
        }
        public static int DemNhomHangHoaCon(int maLoai)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DemNhomHangHoaCon";
                        cm.Parameters.AddWithValue("@MaLoai", maLoai);
                        int gtTraVe = (int)cm.ExecuteScalar();
                        return gtTraVe;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }//using
        }
        public static bool KiemTraNhom_CoTonTaiNhomHangHoaCon(int maLoai)
        {
            bool gt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_XacDinhLoaiVTHH_CoTonTaiNhomHangHoaCon";
                        cm.Parameters.AddWithValue("@MaLoai", maLoai);
                        object gtTraVe = cm.ExecuteScalar();
                        if (gtTraVe != null)
                            return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        public static LoaiVatTuHHBQ_VT NewLoaiVatTuHHBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiVatTuHHBQ_VT");
            return DataPortal.Create<LoaiVatTuHHBQ_VT>();
        }

        public static LoaiVatTuHHBQ_VT GetLoaiVatTuHHBQ_VT(int maLoaiVatTuHH)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiVatTuHHBQ_VT");
            return DataPortal.Fetch<LoaiVatTuHHBQ_VT>(new Criteria(maLoaiVatTuHH));
        }

        public static void DeleteLoaiVatTuHHBQ_VT(int maLoaiVatTuHH)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiVatTuHHBQ_VT");
            DataPortal.Delete(new Criteria(maLoaiVatTuHH));
        }

        public override LoaiVatTuHHBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiVatTuHHBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiVatTuHHBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiVatTuHHBQ_VT");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiVatTuHHBQ_VT NewLoaiVatTuHHBQ_VTChild()
        {
            LoaiVatTuHHBQ_VT child = new LoaiVatTuHHBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiVatTuHHBQ_VT GetLoaiVatTuHHBQ_VT(SafeDataReader dr)
        {
            LoaiVatTuHHBQ_VT child = new LoaiVatTuHHBQ_VT();
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
            public int MaLoaiVatTuHH;

            public Criteria(int maLoaiVatTuHH)
            {
                this.MaLoaiVatTuHH = maLoaiVatTuHH;
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
                cm.CommandText = "spd_SelecttblLoaiVatTuHH";

                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", criteria.MaLoaiVatTuHH);

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
            DataPortal_Delete(new Criteria(_maLoaiVatTuHH));
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
                cm.CommandText = "spd_DeletetblLoaiVatTuHH";

                cm.Parameters.AddWithValue("@MaLoaiVatTuHH", criteria.MaLoaiVatTuHH);

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
            _maLoaiVatTuHH = dr.GetInt32("MaLoaiVatTuHH");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenLoaiVatTuHH = dr.GetString("TenLoaiVatTuHH");
            _dienGiai = dr.GetString("DienGiai");
            _tinhTrang = dr.GetBoolean("TinhTrang");

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LoaiVatTuHHBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LoaiVatTuHHBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiVatTuHH";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLoaiVatTuHH = (int)cm.Parameters["@MaLoaiVatTuHH"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LoaiVatTuHHBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenLoaiVatTuHH", _tenLoaiVatTuHH);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            cm.Parameters["@MaLoaiVatTuHH"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LoaiVatTuHHBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LoaiVatTuHHBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiVatTuHH";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LoaiVatTuHHBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaLoaiVatTuHH", _maLoaiVatTuHH);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@TenLoaiVatTuHH", _tenLoaiVatTuHH);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
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

            ExecuteDelete(tr, new Criteria(_maLoaiVatTuHH));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DoiTuongThuChi : Csla.BusinessBase<DoiTuongThuChi>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDoiTuongThuChi = 0;
        private string _tenDoiTuongThuChi = string.Empty;
        private byte _loaiDoiTuong = 0;
        private int _stt = 0;
        private bool _suDung = false;
        private int _maCongTy = 0;
        private int _maNhomDoiTuong = 0;
        private decimal _soDuCuoiKy = 0;

       
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDoiTuongThuChi
        {
            get
            {
                CanReadProperty("MaDoiTuongThuChi", true);
                return _maDoiTuongThuChi;
            }
        }

        public string TenDoiTuongThuChi
        {
            get
            {
                CanReadProperty("TenDoiTuongThuChi", true);
                return _tenDoiTuongThuChi;
            }
            set
            {
                CanWriteProperty("TenDoiTuongThuChi", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTuongThuChi.Equals(value))
                {
                    _tenDoiTuongThuChi = value;
                    PropertyHasChanged("TenDoiTuongThuChi");
                }
            }
        }

        public byte LoaiDoiTuong
        {
            get
            {
                CanReadProperty("LoaiDoiTuong", true);
                return _loaiDoiTuong;
            }
            set
            {
                CanWriteProperty("LoaiDoiTuong", true);
                if (!_loaiDoiTuong.Equals(value))
                {
                    _loaiDoiTuong = value;
                    PropertyHasChanged("LoaiDoiTuong");
                }
            }
        }
        public decimal SoDuCuoiKy
        {
            get {
                CanReadProperty("SoDuCuoiKy", true);
                return _soDuCuoiKy; }
            set { _soDuCuoiKy = value;
            PropertyHasChanged("SoDuCuoiKy");
            }
        }
        public int Stt
        {
            get
            {
                CanReadProperty("Stt", true);
                return _stt;
            }
            set
            {
                CanWriteProperty("Stt", true);
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged("Stt");
                }
            }
        }

        public bool SuDung
        {
            get
            {
                CanReadProperty("SuDung", true);
                return _suDung;
            }
            set
            {
                CanWriteProperty("SuDung", true);
                if (!_suDung.Equals(value))
                {
                    _suDung = value;
                    PropertyHasChanged("SuDung");
                }
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }
        public int MaNhomDoiTuong
        {
            get
            {
                CanReadProperty("MaNhomDoiTuong", true);
                return _maNhomDoiTuong;
            }
            set
            {
                CanWriteProperty("MaNhomDoiTuong", true);
                if (!_maNhomDoiTuong.Equals(value))
                {
                    _maNhomDoiTuong = value;
                    PropertyHasChanged("MaNhomDoiTuong");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _maDoiTuongThuChi;
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
            // TenDoiTuongThuChi
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenDoiTuongThuChi");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuongThuChi", 500));
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
            //TODO: Define authorization rules in DoiTuongThuChi
            //AuthorizationRules.AllowRead("MaDoiTuongThuChi", "DoiTuongThuChiReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTuongThuChi", "DoiTuongThuChiReadGroup");
            //AuthorizationRules.AllowRead("LoaiDoiTuong", "DoiTuongThuChiReadGroup");
            //AuthorizationRules.AllowRead("Stt", "DoiTuongThuChiReadGroup");
            //AuthorizationRules.AllowRead("SuDung", "DoiTuongThuChiReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "DoiTuongThuChiReadGroup");

            //AuthorizationRules.AllowWrite("TenDoiTuongThuChi", "DoiTuongThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDoiTuong", "DoiTuongThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("Stt", "DoiTuongThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("SuDung", "DoiTuongThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "DoiTuongThuChiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DoiTuongThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DoiTuongThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DoiTuongThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DoiTuongThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongThuChiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DoiTuongThuChi()
        { /* require use of factory method */ }

        public static DoiTuongThuChi NewDoiTuongThuChi()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongThuChi");
            return DataPortal.Create<DoiTuongThuChi>();
        }
        public static DoiTuongThuChi NewDoiTuongThuChi(string s)
        {
            DoiTuongThuChi item = new DoiTuongThuChi();
            item.TenDoiTuongThuChi = s;
            return item;
        }
        public static DoiTuongThuChi GetDoiTuongThuChi(int maDoiTuongThuChi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongThuChi");
            return DataPortal.Fetch<DoiTuongThuChi>(new Criteria(maDoiTuongThuChi));
        }

        public static void DeleteDoiTuongThuChi(int maDoiTuongThuChi)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTuongThuChi");
            DataPortal.Delete(new Criteria(maDoiTuongThuChi));
        }

        public override DoiTuongThuChi Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTuongThuChi");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongThuChi");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DoiTuongThuChi");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DoiTuongThuChi NewDoiTuongThuChiChild()
        {
            DoiTuongThuChi child = new DoiTuongThuChi();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DoiTuongThuChi GetDoiTuongThuChi(SafeDataReader dr)
        {
            DoiTuongThuChi child = new DoiTuongThuChi();
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
            public int MaDoiTuongThuChi;

            public Criteria(int maDoiTuongThuChi)
            {
                this.MaDoiTuongThuChi = maDoiTuongThuChi;
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
                cm.CommandText = "spd_SelecttblcnLoaiDoiTuong";

                cm.Parameters.AddWithValue("@MaDoiTuongThuChi", criteria.MaDoiTuongThuChi);

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
            DataPortal_Delete(new Criteria(_maDoiTuongThuChi));
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
                cm.CommandText = "spd_DeletetblcnLoaiDoiTuong";

                cm.Parameters.AddWithValue("@MaDoiTuongThuChi", criteria.MaDoiTuongThuChi);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            //ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
            _tenDoiTuongThuChi = dr.GetString("TenDoiTuongThuChi");
            _loaiDoiTuong = dr.GetByte("LoaiDoiTuong");
            _stt = dr.GetInt32("STT");
            _suDung = dr.GetBoolean("SuDung");
            _maCongTy = dr.GetInt32("MaCongTy");
            _maNhomDoiTuong = dr.GetInt32("MaNhomDoiTuong");
            _soDuCuoiKy = dr.GetDecimal("SoDuCuoiKy");
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
                cm.CommandText = "spd_InserttblcnLoaiDoiTuong";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDoiTuongThuChi = (int)cm.Parameters["@MaDoiTuongThuChi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            cm.Parameters.AddWithValue("@TenDoiTuongThuChi", _tenDoiTuongThuChi);
            cm.Parameters.AddWithValue("@LoaiDoiTuong", _loaiDoiTuong);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maNhomDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaNhomDoiTuong", _maNhomDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaNhomDoiTuong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
            cm.Parameters.AddWithValue("@SoDuCuoiKy", _soDuCuoiKy);
            cm.Parameters["@MaDoiTuongThuChi"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblcnLoaiDoiTuong";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
            cm.Parameters.AddWithValue("@TenDoiTuongThuChi", _tenDoiTuongThuChi);
            cm.Parameters.AddWithValue("@LoaiDoiTuong", _loaiDoiTuong);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maNhomDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaNhomDoiTuong", _maNhomDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaNhomDoiTuong", DBNull.Value);
            cm.Parameters.AddWithValue("@SoDuCuoiKy", _soDuCuoiKy);
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

            ExecuteDelete(tr, new Criteria(_maDoiTuongThuChi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

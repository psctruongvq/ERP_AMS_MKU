
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKy_NganHang : Csla.BusinessBase<SoDuDauKy_NganHang>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private decimal _soDuDauKy = 0;
        private int _maNganHang = 0;
        private int _loaiTien = 0;
        private int _maKy = 0;
        private string _TKNganHang = string.Empty;
        private NganHang _nganHang;
        private decimal _soDuDauKy_NgoaiTe = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public decimal SoDuDauKy
        {
            get
            {
                CanReadProperty("SoDuDauKy", true);
                return _soDuDauKy;
            }
            set
            {
                CanWriteProperty("SoDuDauKy", true);
                if (!_soDuDauKy.Equals(value))
                {
                    _soDuDauKy = value;
                    PropertyHasChanged("SoDuDauKy");
                }
            }
        }

        public decimal SoDuDauKy_NgoaiTe
        {
            get
            {
                CanReadProperty("SoDuDauKy_NgoaiTe", true);
                return _soDuDauKy_NgoaiTe;
            }
            set
            {
                CanWriteProperty("SoDuDauKy_NgoaiTe", true);
                if (!_soDuDauKy_NgoaiTe.Equals(value))
                {
                    _soDuDauKy_NgoaiTe = value;
                    PropertyHasChanged("SoDuDauKy_NgoaiTe");
                }
            }

        }
        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
                }
            }
        }

        public int MaKy
        {
            get
            {
                CanReadProperty("MaKy", true);
                return _maKy;
            }
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _nganHang.TenNganHang;
            }
        }

        public string TaiKhoanNH
        {
            get
            {
                CanReadProperty("TaiKhoanNH", true);
                return _TKNganHang;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {

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
            //TODO: Define authorization rules in SoDuDauKy_NganHang
            //AuthorizationRules.AllowRead("MaChiTiet", "SoDuDauKy_NganHangReadGroup");
            //AuthorizationRules.AllowRead("SoDuDauKy", "SoDuDauKy_NganHangReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "SoDuDauKy_NganHangReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "SoDuDauKy_NganHangReadGroup");
            //AuthorizationRules.AllowRead("MaKy", "SoDuDauKy_NganHangReadGroup");

            //AuthorizationRules.AllowWrite("SoDuDauKy", "SoDuDauKy_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "SoDuDauKy_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "SoDuDauKy_NganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaKy", "SoDuDauKy_NganHangWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKy_NganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKy_NganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKy_NganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKy_NganHang
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKy_NganHangDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKy_NganHang()
        { /* require use of factory method */ }

        public static SoDuDauKy_NganHang NewSoDuDauKy_NganHang()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_NganHang");
            return DataPortal.Create<SoDuDauKy_NganHang>();
        }

        public static SoDuDauKy_NganHang GetSoDuDauKy_NganHang(long maChiTiet)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKy_NganHang");
            return DataPortal.Fetch<SoDuDauKy_NganHang>(new Criteria(maChiTiet));
        }

        public static void DeleteSoDuDauKy_NganHang(long maChiTiet)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKy_NganHang");
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        public override SoDuDauKy_NganHang Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a SoDuDauKy_NganHang");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKy_NganHang");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a SoDuDauKy_NganHang");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static SoDuDauKy_NganHang NewSoDuDauKy_NganHangChild()
        {
            SoDuDauKy_NganHang child = new SoDuDauKy_NganHang();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuDauKy_NganHang GetSoDuDauKy_NganHang(SafeDataReader dr)
        {
            SoDuDauKy_NganHang child = new SoDuDauKy_NganHang();
            child.MarkAsChild();
            child.Fetch(dr);
            if (child.MaChiTiet == 0)
                child.MarkNew();
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaChiTiet;

            public Criteria(long maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_SelecttblSoDuDauKy_NganHang";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                cm.CommandText = "spd_DeletetblSoDuDauKy_NganHang";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _soDuDauKy = dr.GetDecimal("SoDuDauKy");
            _maNganHang = dr.GetInt32("MaNganHang");
            _maKy = dr.GetInt32("MaKy");
            _soDuDauKy_NgoaiTe = dr.GetDecimal("soDuDauKy_NgoaiTe");
            CongTy_NganHang nh = CongTy_NganHang.GetCongTy_NganHang(_maNganHang);
            _nganHang = NganHang.GetNganHang(nh.MaNganHang);
            
            _TKNganHang = nh.SoTaiKhoan;
            _loaiTien = nh.LoaiTien;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, SoDuDauKy_NganHangList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, SoDuDauKy_NganHangList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblSoDuDauKy_NganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, SoDuDauKy_NganHangList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_soDuDauKy != 0)
                cm.Parameters.AddWithValue("@SoDuDauKy", _soDuDauKy);
            else
                cm.Parameters.AddWithValue("@SoDuDauKy", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_soDuDauKy_NgoaiTe != 0)
                cm.Parameters.AddWithValue("@soDuDauKy_NgoaiTe", _soDuDauKy_NgoaiTe);
            else
                cm.Parameters.AddWithValue("@soDuDauKy_NgoaiTe", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, SoDuDauKy_NganHangList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, SoDuDauKy_NganHangList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblSoDuDauKy_NganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, SoDuDauKy_NganHangList parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_soDuDauKy != 0)
                cm.Parameters.AddWithValue("@SoDuDauKy", _soDuDauKy);
            else
                cm.Parameters.AddWithValue("@SoDuDauKy", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_soDuDauKy_NgoaiTe != 0)
                cm.Parameters.AddWithValue("@soDuDauKy_NgoaiTe", _soDuDauKy_NgoaiTe);
            else
                cm.Parameters.AddWithValue("@soDuDauKy_NgoaiTe", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        #region ket chuyen so du doi tuong qua so du tai khoan
        public static void UpdateSoDuTaiKhoan_BySoDuTheoNganHang(int MaKy, int MaBoPhan)
        {
            int GiaTriTrave;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdateSoDuTaiKhoan_BySoDuTheoNganHang";
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
            }
        }
        #endregion
    }
}

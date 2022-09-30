
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KhoBQ_VT : Csla.BusinessBase<KhoBQ_VT>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKho = 0;
        private string _maQuanLy = string.Empty;
        private string _tenKho = string.Empty;
        private int _maLoaiKho = 0;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private string _dienGiai = string.Empty;
        private int _maTaiKhoan = 0;
        private int _maCongTy = 0;
        private string _maDiaChi = string.Empty;
        private bool _tinhTrang = true;
        private SmartDate _ngayLap = new SmartDate(false);

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKho
        {
            get
            {
                CanReadProperty("MaKho", true);
                return _maKho;
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

        public string TenKho
        {
            get
            {
                CanReadProperty("TenKho", true);
                return _tenKho;
            }
            set
            {
                CanWriteProperty("TenKho", true);
                if (value == null) value = string.Empty;
                if (!_tenKho.Equals(value))
                {
                    _tenKho = value;
                    PropertyHasChanged("TenKho");
                }
            }
        }

        

        public int MaLoaiKho
        {
            get
            {
                CanReadProperty("MaLoaiKho", true);
                return _maLoaiKho;
            }
            set
            {
                CanWriteProperty("MaLoaiKho", true);
                if (!_maLoaiKho.Equals(value))
                {
                    _maLoaiKho = value;
                    PropertyHasChanged("MaLoaiKho");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
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

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged("MaTaiKhoan");
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

        public string MaDiaChi
        {
            get
            {
                CanReadProperty("MaDiaChi", true);
                return _maDiaChi;
            }
            set
            {
                CanWriteProperty("MaDiaChi", true);
                if (!_maDiaChi.Equals(value))
                {
                    _maDiaChi = value;
                    PropertyHasChanged("MaDiaChi");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
        }

        public string NgayLapString
        {
            get
            {
                CanReadProperty("NgayLapString", true);
                return _ngayLap.Text;
            }
            set
            {
                CanWriteProperty("NgayLapString", true);
                if (value == null) value = string.Empty;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap.Text = value;
                    PropertyHasChanged("NgayLapString");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maKho;
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
            // TenKho
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenKho");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKho", 100));
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
            //TODO: Define authorization rules in KhoBQ_VT
            //AuthorizationRules.AllowRead("MaKho", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TenKho", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiKho", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("MaDiaChi", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "KhoBQ_VTReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "KhoBQ_VTReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TenKho", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiKho", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("MaDiaChi", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "KhoBQ_VTWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "KhoBQ_VTWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KhoBQ_VT
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KhoBQ_VTDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KhoBQ_VT()
        { /* require use of factory method */ }

        public static KhoBQ_VT NewKhoBQ_VT()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoBQ_VT");
            return DataPortal.Create<KhoBQ_VT>();
        }

        public static KhoBQ_VT GetKhoBQ_VT(int maKho, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoBQ_VT");
            return DataPortal.Fetch<KhoBQ_VT>(new Criteria(maKho, maCongTy));
        }


        public static KhoBQ_VT GetKhoBQ_VT(string maQuanLy, int maCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KhoBQ_VT");
            return DataPortal.Fetch<KhoBQ_VT>(new Criteria(maQuanLy, maCongTy));
        }

        public static void DeleteKhoBQ_VT(int maKho, int maCongTy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoBQ_VT");
            DataPortal.Delete(new Criteria(maKho, maCongTy));
        }

        public override KhoBQ_VT Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a KhoBQ_VT");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KhoBQ_VT");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a KhoBQ_VT");

            return base.Save();
        }

        public static bool KiemTraTrungMaMaQuanLyKho(int maKho, string maQuanLy)
        {
            bool trungMaQuanLy = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungMaQuanLyKho";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@MaQuanLy", maQuanLy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungMaQuanLy", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungMaQuanLy = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungMaQuanLy;
        }


        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KhoBQ_VT NewKhoBQ_VTChild()
        {
            KhoBQ_VT child = new KhoBQ_VT();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KhoBQ_VT GetKhoBQ_VT(SafeDataReader dr)
        {
            KhoBQ_VT child = new KhoBQ_VT();
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
            public int MaKho;
            public string MaQuanLy;
            public int MaCongTy;
            public Criteria(int maKho, int maCongTy)
            {
                this.MaKho = maKho;
                this.MaCongTy = maCongTy;
            }

            public Criteria(string maQuanLy, int maCongTy)
            {
                this.MaQuanLy = maQuanLy;
                this.MaCongTy = maCongTy;
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
                if (criteria.MaKho != 0)
                {
                    cm.CommandText = "spd_SelecttblKhobyMaCongTy";
                    cm.Parameters.AddWithValue("@MaKho", criteria.MaKho);
                    cm.Parameters.AddWithValue("@MaCongTy", criteria.MaCongTy);
                }
                else
                {
                    cm.CommandText = "spd_SelecttblKhoByMaQuanLy";
                    cm.Parameters.AddWithValue("@MaQuanLy", criteria.MaQuanLy);
                    cm.Parameters.AddWithValue("@MaCongTy", criteria.MaCongTy);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        MarkOld();
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
            DataPortal_Delete(new Criteria(_maKho, _maCongTy));
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
                cm.CommandText = "spd_DeletetblKho";

                cm.Parameters.AddWithValue("@MaKho", criteria.MaKho);

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
            _maKho = dr.GetInt32("MaKho");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenKho = dr.GetString("TenKho");
            _maLoaiKho = dr.GetInt32("MaLoaiKho");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _dienGiai = dr.GetString("DienGiai");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _maCongTy = dr.GetInt32("MaCongTy");
            _maDiaChi = dr.GetString("MaDiaChi");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KhoBQ_VTList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KhoBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblKho";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maKho = (int)cm.Parameters["@MaKho"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KhoBQ_VTList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenKho", _tenKho);
            if (_maLoaiKho != 0)
                cm.Parameters.AddWithValue("@MaLoaiKho", _maLoaiKho);
            else
                cm.Parameters.AddWithValue("@MaLoaiKho", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maDiaChi.Length > 0)
                cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            else
                cm.Parameters.AddWithValue("@MaDiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaKho", _maKho);
            cm.Parameters["@MaKho"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KhoBQ_VTList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KhoBQ_VTList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblKho";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KhoBQ_VTList parent)
        {
            cm.Parameters.AddWithValue("@MaKho", _maKho);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@TenKho", _tenKho);
            if (_maLoaiKho != 0)
                cm.Parameters.AddWithValue("@MaLoaiKho", _maLoaiKho);
            else
                cm.Parameters.AddWithValue("@MaLoaiKho", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_maDiaChi.Length > 0)
                cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            else
                cm.Parameters.AddWithValue("@MaDiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

            ExecuteDelete(tr, new Criteria(_maKho, _maCongTy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

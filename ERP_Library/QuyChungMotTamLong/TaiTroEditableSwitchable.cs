
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class TaiTro : Csla.BusinessBase<TaiTro>
    {
        #region Business Properties and Methods

        //declare members
        private long _maTaiTro = 0;
        private string _so = string.Empty;
        private DateTime _ngayLap = DateTime.Today.Date;
        private long _maDoiTuong = 0;
        private int _maChuongTrinh = 0;
        private decimal _soTien = 0;
        private int _loaiTien = 1;
        private string _dienGiai = string.Empty;
        private DateTime _ngayHeThong = DateTime.Today.Date;
        private bool _isHuy = false;
        private int _userId = 0;
        private DateTime? _ngayPhatSong = null;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaTaiTro
        {
            get
            {
                CanReadProperty("MaTaiTro", true);
                return _maTaiTro;
            }
        }

        public string So
        {
            get
            {
                CanReadProperty("So", true);
                return _so;
            }
            set
            {
                CanWriteProperty("So", true);
                if (value == null) value = string.Empty;
                if (!_so.Equals(value))
                {
                    _so = value;
                    PropertyHasChanged("So");
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
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public DateTime? NgayPhatSong
        {
            get
            {
                CanReadProperty("NgayPhatSong", true);
                return _ngayPhatSong;
            }
            set
            {
                CanWriteProperty("NgayPhatSong", true);
                if (!_ngayPhatSong.Equals(value))
                {
                    _ngayPhatSong = value;
                    PropertyHasChanged("NgayPhatSong");
                }
            }
        }

        public long MaDoiTuong
        {
            get
            {
                CanReadProperty("MaDoiTuong", true);
                return _maDoiTuong;
            }
            set
            {
                CanWriteProperty("MaDoiTuong", true);
                if (!_maDoiTuong.Equals(value))
                {
                    _maDoiTuong = value;
                    PropertyHasChanged("MaDoiTuong");
                }
            }
        }

        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaChuongTrinh", true);
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged("MaChuongTrinh");
                }
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

        public bool IsHuy
        {
            get
            {
                CanReadProperty("IsHuy", true);
                return _isHuy;
            }
            set
            {
                CanWriteProperty("IsHuy", true);
                if (!_isHuy.Equals(value))
                {
                    _isHuy = value;
                    PropertyHasChanged("IsHuy");
                }
            }
        }

        public int UserId
        {
            get
            {
                CanReadProperty("UserId", true);
                return _userId;
            }
            set
            {
                CanWriteProperty("UserId", true);
                if (!_userId.Equals(value))
                {
                    _userId = value;
                    PropertyHasChanged("UserId");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maTaiTro;
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
            // So
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 50));
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
            //TODO: Define authorization rules in TaiTro
            //AuthorizationRules.AllowRead("MaTaiTro", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("So", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuong", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinh", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThong", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("NgayHeThongString", "TaiTroReadGroup");
            //AuthorizationRules.AllowRead("IsHuy", "TaiTroReadGroup");

            //AuthorizationRules.AllowWrite("So", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("MaDoiTuong", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuongTrinh", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHeThongString", "TaiTroWriteGroup");
            //AuthorizationRules.AllowWrite("IsHuy", "TaiTroWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TaiTro
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TaiTro
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TaiTro
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TaiTro
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TaiTroDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TaiTro()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static TaiTro NewTaiTro()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiTro");
            return DataPortal.Create<TaiTro>();
        }

        public static TaiTro GetTaiTro(long maTaiTro)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiTro");
            return DataPortal.Fetch<TaiTro>(new Criteria(maTaiTro));
        }

        public static void DeleteTaiTro(long maTaiTro)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TaiTro");
            DataPortal.Delete(new Criteria(maTaiTro));
        }

        public override TaiTro Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a TaiTro");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TaiTro");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a TaiTro");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static TaiTro NewTaiTroChild()
        {
            TaiTro child = new TaiTro();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static TaiTro GetTaiTro(SafeDataReader dr)
        {
            TaiTro child = new TaiTro();
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
            public long MaTaiTro;

            public Criteria(long maTaiTro)
            {
                this.MaTaiTro = maTaiTro;
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
                cm.CommandText = "spd_SelecttblTaiTro";

                cm.Parameters.AddWithValue("@MaTaiTro", criteria.MaTaiTro);

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
            DataPortal_Delete(new Criteria(_maTaiTro));
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
                cm.CommandText = "spd_DeletetblTaiTro";

                cm.Parameters.AddWithValue("@MaTaiTro", criteria.MaTaiTro);

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
            _maTaiTro = dr.GetInt64("MaTaiTro");
            _so = dr.GetString("So");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _soTien = dr.GetDecimal("SoTien");
            _loaiTien = dr.GetInt32("LoaiTien");
            _dienGiai = dr.GetString("DienGiai");
            _ngayHeThong = dr.GetDateTime("NgayHeThong");
            _isHuy = dr.GetBoolean("IsHuy");
            _userId = dr.GetInt32("UserId");
            if (dr.GetDateTime("NgayPhatSong") != DateTime.MinValue)
                _ngayPhatSong = dr.GetDateTime("NgayPhatSong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, TaiTroList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, TaiTroList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblTaiTro";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maTaiTro = (long)cm.Parameters["@MaTaiTro"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, TaiTroList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
            if (_isHuy != false)
                cm.Parameters.AddWithValue("@IsHuy", _isHuy);
            else
                cm.Parameters.AddWithValue("@IsHuy", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_ngayPhatSong != null & _ngayPhatSong != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong);
            else
                cm.Parameters.AddWithValue("@NgayPhatSong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTaiTro", _maTaiTro);
            cm.Parameters["@MaTaiTro"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, TaiTroList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, TaiTroList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblTaiTro";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, TaiTroList parent)
        {
            cm.Parameters.AddWithValue("@MaTaiTro", _maTaiTro);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", DateTime.Now);
            if (_isHuy != false)
                cm.Parameters.AddWithValue("@IsHuy", _isHuy);
            else
                cm.Parameters.AddWithValue("@IsHuy", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_ngayPhatSong != null & _ngayPhatSong != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgayPhatSong", _ngayPhatSong);
            else
                cm.Parameters.AddWithValue("@NgayPhatSong", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maTaiTro));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

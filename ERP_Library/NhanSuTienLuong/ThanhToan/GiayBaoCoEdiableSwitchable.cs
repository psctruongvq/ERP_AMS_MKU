
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayBaoCo : Csla.BusinessBase<GiayBaoCo>
    {
        #region Business Properties and Methods

        //declare members
        private int _maGiayBaoCo = 0;
        private string _soChungTu = string.Empty;
        private DateTime _ngayNhan = DateTime.Now.Date;
        private DateTime _ngayLap = DateTime.Now.Date;
        private string _dienGiai = string.Empty;
        private string _ghiChu = string.Empty;
        private decimal _soTien = 0;
        private int _userId = 0;
        private long _maDoiTac = 0;
        private int _lapBangKe = 0;
        private bool _hoanTat = false;
        private int _taiKhoanNhan = 0;
        private decimal _tyGia = 0;
        private int _loaiTien = 1;
        private int _loaiGBC = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaGiayBaoCo
        {
            get
            {
                CanReadProperty("MaGiayBaoCo", true);
                return _maGiayBaoCo;
            }
        }

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public DateTime NgayNhan
        {
            get
            {
                CanReadProperty("NgayNhan", true);
                return _ngayNhan.Date;
            }
            set
            {
                CanWriteProperty("NgayNhan", true);
                if (!_ngayNhan.Equals(value))
                {
                    _ngayNhan = value;
                    PropertyHasChanged("NgayNhan");
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

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
                }
            }
        }

        public int LapBangKe
        {
            get
            {
                CanReadProperty("LapBangKe", true);
                return _lapBangKe;
            }
            set
            {
                CanWriteProperty("LapBangKe", true);
                if (!_lapBangKe.Equals(value))
                {
                    _lapBangKe = value;
                    PropertyHasChanged("LapBangKe");
                }
            }
        }

        public bool HoanTat
        {
            get
            {
                CanReadProperty("HoanTat", true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty("HoanTat", true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged("HoanTat");
                }
            }
        }

        public int TaiKhoanNhan
        {
            get
            {
                CanReadProperty("TaiKhoanNhan", true);
                return _taiKhoanNhan;
            }
            set
            {
                CanWriteProperty("TaiKhoanNhan", true);
                if (!_taiKhoanNhan.Equals(value))
                {
                    _taiKhoanNhan = value;
                    PropertyHasChanged("TaiKhoanNhan");
                }
            }
        }

        public decimal TyGia
        {
            get
            {
                CanReadProperty("TyGia", true);
                return _tyGia;
            }
            set
            {
                CanWriteProperty("TyGia", true);
                if (!_tyGia.Equals(value))
                {
                    _tyGia = value;
                    PropertyHasChanged("TyGia");
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

        public int LoaiGiayBaoCo
        {
            get
            {
                CanReadProperty("LoaiGiayBaoCo", true);
                return _loaiGBC;
            }
            set
            {
                CanWriteProperty("LoaiGiayBaoCo", true);
                if (!_loaiGBC.Equals(value))
                {
                    _loaiGBC = value;
                    PropertyHasChanged("LoaiGiayBaoCo");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maGiayBaoCo;
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
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 200));
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
            //TODO: Define authorization rules in GiayBaoCo
            //AuthorizationRules.AllowRead("MaGiayBaoCo", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("NgayNhan", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("NgayNhanString", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("UserId", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("LapBangKe", "GiayBaoCoReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "GiayBaoCoReadGroup");

            //AuthorizationRules.AllowWrite("SoChungTu", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNhanString", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("LapBangKe", "GiayBaoCoWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "GiayBaoCoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayBaoCo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayBaoCo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayBaoCo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayBaoCo
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayBaoCoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayBaoCo()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static GiayBaoCo NewGiayBaoCo()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCo");
            return DataPortal.Create<GiayBaoCo>();
        }

        public static GiayBaoCo GetGiayBaoCo(int maGiayBaoCo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayBaoCo");
            return DataPortal.Fetch<GiayBaoCo>(new Criteria(maGiayBaoCo));
        }

        public static void DeleteGiayBaoCo(int maGiayBaoCo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayBaoCo");
            DataPortal.Delete(new Criteria(maGiayBaoCo));
        }

        public override GiayBaoCo Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayBaoCo");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayBaoCo");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayBaoCo");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static GiayBaoCo NewGiayBaoCoChild()
        {
            GiayBaoCo child = new GiayBaoCo();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiayBaoCo GetGiayBaoCo(SafeDataReader dr)
        {
            GiayBaoCo child = new GiayBaoCo();
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
            public int MaGiayBaoCo;

            public Criteria(int maGiayBaoCo)
            {
                this.MaGiayBaoCo = maGiayBaoCo;
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
                cm.CommandText = "spd_SelecttblGiayBaoCo";

                cm.Parameters.AddWithValue("@MaGiayBaoCo", criteria.MaGiayBaoCo);

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
            DataPortal_Delete(new Criteria(_maGiayBaoCo));
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
                cm.CommandText = "spd_DeletetblGiayBaoCo";

                cm.Parameters.AddWithValue("@MaGiayBaoCo", criteria.MaGiayBaoCo);

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
            _maGiayBaoCo = dr.GetInt32("MaGiayBaoCo");
            _soChungTu = dr.GetString("SoChungTu");
            _ngayNhan = dr.GetDateTime("NgayNhan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _dienGiai = dr.GetString("DienGiai");
            _ghiChu = dr.GetString("GhiChu");
            _soTien = dr.GetDecimal("SoTien");
            _userId = dr.GetInt32("UserId");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _lapBangKe = dr.GetInt32("LapBangKe");
            _hoanTat = dr.GetBoolean("HoanTat");
            _taiKhoanNhan = dr.GetInt32("TaiKhoanNhan");
            _tyGia = dr.GetDecimal("TyGia");
            _loaiTien = dr.GetInt32("LoaiTien");
            _loaiGBC = dr.GetInt32("LoaiGBC");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayBaoCoList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayBaoCoList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblGiayBaoCo";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maGiayBaoCo = (int)cm.Parameters["@MaGiayBaoCo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayBaoCoList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_lapBangKe != 0)
                cm.Parameters.AddWithValue("@LapBangKe", _lapBangKe);
            else
                cm.Parameters.AddWithValue("@LapBangKe", DBNull.Value);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_taiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiGBC", _loaiGBC);
            cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            cm.Parameters["@MaGiayBaoCo"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayBaoCoList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayBaoCoList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblGiayBaoCo";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayBaoCoList parent)
        {
            cm.Parameters.AddWithValue("@MaGiayBaoCo", _maGiayBaoCo);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_lapBangKe != 0)
                cm.Parameters.AddWithValue("@LapBangKe", _lapBangKe);
            else
                cm.Parameters.AddWithValue("@LapBangKe", DBNull.Value);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_taiKhoanNhan != 0)
                cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@TaiKhoanNhan", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            cm.Parameters.AddWithValue("@LoaiGBC", _loaiGBC);
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

            ExecuteDelete(tr, new Criteria(_maGiayBaoCo));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

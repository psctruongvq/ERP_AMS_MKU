using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{
    [Serializable()]
    public class GiayXacNhanTongHop : Csla.BusinessBase<GiayXacNhanTongHop>
    {
        #region Business Properties and Methods

        //declare members
        private int _maGiayXacNhan = 0;
        private string _maGiayXacNhanQL = string.Empty;
        private string _tenGiayXacNhan = string.Empty;
        private int _maChuongTrinh = 0;
        private string _maChuongTrinhQL = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private SmartDate _ngayLap = new SmartDate(false);
        private int _maBoPhanDi = 0;
        private int _maBoPhanDen = 0;
        private Nullable<decimal> _soTien = null;
        private decimal _soTienConLai = 0;
        private SmartDate _ngayHoanTat = new SmartDate(false);
        private bool _hoanTat = false;
        private bool _duocNhapHo = false;
        private string _ghiChu = string.Empty;
        //
        //declare members
        private SmartDate _ngayPhatSong = new SmartDate(DateTime.Today.Date);
        private string _soHopDong = string.Empty;
        private int _maDonViXacNhanDi = 0;
        private string _tenDonViXacNhanDi = string.Empty;
        private int _nguoiLap = 0;
        private bool _trangThai = false;
        private string _soChuongTrinh = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaGiayXacNhan
        {
            get
            {
                CanReadProperty("MaGiayXacNhan", true);
                return _maGiayXacNhan;
            }
        }

        public bool TrangThai
        {
            get
            {
                return _trangThai;
            }
            set
            {
                if (!_trangThai.Equals(value))
                {
                    _trangThai = value;
                    PropertyHasChanged("TrangThai");
                }
            }
        }
        public string SoChuongTrinh
        {
            get
            {
                return _soChuongTrinh;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soChuongTrinh.Equals(value))
                {
                    _soChuongTrinh = value;
                    PropertyHasChanged("SoChuongTrinh");
                }
            }
        }

        public int NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
            set
            {
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public int MaDonViXacNhanDi
        {
            get
            {
                return _maDonViXacNhanDi;
            }
            set
            {
                if (!_maDonViXacNhanDi.Equals(value))
                {
                    _maDonViXacNhanDi = value;
                    PropertyHasChanged("MaDonViXacNhanDi");
                }
            }
        }

        public string TenDonViXacNhanDi
        {
            get
            {

                return _tenDonViXacNhanDi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenDonViXacNhanDi.Equals(value))
                {
                    _tenDonViXacNhanDi = value;
                    PropertyHasChanged("TenDonViXacNhanDi");
                }
            }
        }
        public string SoHopDong
        {
            get
            {
                return _soHopDong;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soHopDong.Equals(value))
                {
                    _soHopDong = value;
                    PropertyHasChanged("SoHopDong");
                }
            }
        }
        public DateTime NgayPhatSong
        {
            get
            {
                return _ngayPhatSong.Date;
            }
            set
            {
                CanWriteProperty("NgayPhatSong", true);
                if (!_ngayPhatSong.Equals(value))
                {
                    _ngayPhatSong = new SmartDate(value);
                    PropertyHasChanged("NgayPhatSong");
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

        public string MaGiayXacNhanQL
        {
            get
            {
                CanReadProperty("MaGiayXacNhanQL", true);
                return _maGiayXacNhanQL;
            }
            set
            {
                CanWriteProperty("MaGiayXacNhanQL", true);
                if (value == null) value = string.Empty;
                if (!_maGiayXacNhanQL.Equals(value))
                {
                    _maGiayXacNhanQL = value;
                    PropertyHasChanged("MaGiayXacNhanQL");
                }
            }
        }

        public string TenGiayXacNhan
        {
            get
            {
                CanReadProperty("TenGiayXacNhan", true);
                return _tenGiayXacNhan;
            }
            set
            {
                CanWriteProperty("TenGiayXacNhan", true);
                if (value == null) value = string.Empty;
                if (!_tenGiayXacNhan.Equals(value))
                {
                    _tenGiayXacNhan = value;
                    PropertyHasChanged("TenGiayXacNhan");
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

        public string MaChuongTrinhQL
        {
            get
            {
                CanReadProperty("MaChuongTrinhQL", true);
                return _maChuongTrinhQL;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhQL", true);
                if (value == null) value = string.Empty;
                if (!_maChuongTrinhQL.Equals(value))
                {
                    _maChuongTrinhQL = value;
                    PropertyHasChanged("MaChuongTrinhQL");
                }
            }
        }

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
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

        public int MaBoPhanDi
        {
            get
            {
                CanReadProperty("MaBoPhanDi", true);
                return _maBoPhanDi;
            }
            set
            {
                CanWriteProperty("MaBoPhanDi", true);
                if (!_maBoPhanDi.Equals(value))
                {
                    _maBoPhanDi = value;
                    PropertyHasChanged("MaBoPhanDi");
                }
            }
        }

        public int MaBoPhanDen
        {
            get
            {
                CanReadProperty("MaBoPhanDen", true);
                return _maBoPhanDen;
            }
            set
            {
                CanWriteProperty("MaBoPhanDen", true);
                if (!_maBoPhanDen.Equals(value))
                {
                    _maBoPhanDen = value;
                    PropertyHasChanged("MaBoPhanDen");
                }
            }
        }

        public Nullable<decimal> SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public decimal SoTienConLai
        {
            get
            {
                CanReadProperty("SoTienConLai", true);
                return _soTienConLai;
            }
            set
            {
                CanWriteProperty("SoTienConLai", true);
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }

        public DateTime NgayHoanTat
        {
            get
            {
                CanReadProperty("NgayHoanTat", true);
                return _ngayHoanTat.Date;
            }
        }

        public string NgayHoanTatString
        {
            get
            {
                CanReadProperty("NgayHoanTatString", true);
                return _ngayHoanTat.Text;
            }
            set
            {
                CanWriteProperty("NgayHoanTatString", true);
                if (value == null) value = string.Empty;
                if (!_ngayHoanTat.Equals(value))
                {
                    _ngayHoanTat.Text = value;
                    PropertyHasChanged("NgayHoanTatString");
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

        public bool DuocNhapHo
        {
            get
            {
                CanReadProperty("DuocNhapHo", true);
                return _duocNhapHo;
            }
            set
            {
                CanWriteProperty("DuocNhapHo", true);
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maGiayXacNhan;
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
            // MaGiayXacNhanQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaGiayXacNhanQL", 50));
            //
            // TenGiayXacNhan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenGiayXacNhan", 400));
            //
            // MaChuongTrinhQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChuongTrinhQL", 50));
            //
            // TenChuongTrinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 500));
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
            //TODO: Define authorization rules in GiayXacNhanTongHop
            //AuthorizationRules.AllowRead("MaGiayXacNhan", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("MaGiayXacNhanQL", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("TenGiayXacNhan", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinh", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinhQL", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("TenChuongTrinh", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanDi", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhanDen", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("SoTienConLai", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayHoanTat", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayHoanTatString", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("HoanTat", "GiayXacNhanTongHopReadGroup");
            //AuthorizationRules.AllowRead("DuocNhapHo", "GiayXacNhanTongHopReadGroup");

            //AuthorizationRules.AllowWrite("MaGiayXacNhanQL", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("TenGiayXacNhan", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuongTrinh", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("MaChuongTrinhQL", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("TenChuongTrinh", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhanDi", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhanDen", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienConLai", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("NgayHoanTatString", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("HoanTat", "GiayXacNhanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("DuocNhapHo", "GiayXacNhanTongHopWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayXacNhanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayXacNhanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayXacNhanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayXacNhanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayXacNhanTongHop()
        { /* require use of factory method */ }

        public static GiayXacNhanTongHop NewGiayXacNhanTongHop(int maGiayXacNhan)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayXacNhanTongHop");
            return DataPortal.Create<GiayXacNhanTongHop>(new Criteria(maGiayXacNhan));
        }

        private GiayXacNhanTongHop(int maChuongTrinh, string tenGiayXacNhan)
        {
            _maChuongTrinh = maChuongTrinh;
            _tenGiayXacNhan = tenGiayXacNhan;
        }
        public static GiayXacNhanTongHop NewGiayXacNhanTongHop(int maChuongTrinh, string tenGiayXacNhan)
        {
            return new GiayXacNhanTongHop(maChuongTrinh, tenGiayXacNhan);
        }

        public static GiayXacNhanTongHop GetGiayXacNhanTongHop(int maGiayXacNhan, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHop");
            return DataPortal.Fetch<GiayXacNhanTongHop>(new CriteriaByBoPhan(maGiayXacNhan, maBoPhan));
        }

        public static GiayXacNhanTongHop GetGiayXacNhanChuongTrinh(int maGiayXacNhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHop");
            return DataPortal.Fetch<GiayXacNhanTongHop>(new Criteria(maGiayXacNhan));
        }

        public static void DeleteGiayXacNhanTongHop(int maGiayXacNhan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhanTongHop");
            DataPortal.Delete(new Criteria(maGiayXacNhan));
        }

        public override GiayXacNhanTongHop Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayXacNhanTongHop");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayXacNhanTongHop");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayXacNhanTongHop");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        private GiayXacNhanTongHop(int maGiayXacNhan)
        {
            this._maGiayXacNhan = maGiayXacNhan;
        }

        internal static GiayXacNhanTongHop NewGiayXacNhanTongHopChild(int maGiayXacNhan)
        {
            GiayXacNhanTongHop child = new GiayXacNhanTongHop(maGiayXacNhan);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static GiayXacNhanTongHop GetGiayXacNhanTongHop(SafeDataReader dr)
        {
            GiayXacNhanTongHop child = new GiayXacNhanTongHop();
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
            public int MaGiayXacNhan;

            public Criteria(int maGiayXacNhan)
            {
                this.MaGiayXacNhan = maGiayXacNhan;
            }
        }

        private class CriteriaByBoPhan
        {
            public int MaGiayXacNhan;
            public int MaBoPhan;

            public CriteriaByBoPhan(int maGiayXacNhan, int maBoPhan)
            {
                this.MaGiayXacNhan = maGiayXacNhan;
                this.MaBoPhan = maBoPhan;
            }
        }
        private void DataPortal_Create(Criteria criteria)
        {
            _maGiayXacNhan = criteria.MaGiayXacNhan;
            ValidationRules.CheckRules();
        }
        #endregion //Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (criteria is CriteriaByBoPhan)
                    {
                        ExecuteFetch(tr, criteria);
                    }
                    else
                    {
                        ExecuteFetchGiayXacNhan(tr, criteria);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

       private void ExecuteFetchGiayXacNhan(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinh";

                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((Criteria)criteria).MaGiayXacNhan);
                
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObjectGiayXacNhan(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                if (criteria is CriteriaByBoPhan)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanTongHop";

                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((CriteriaByBoPhan)criteria).MaGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByBoPhan)criteria).MaBoPhan);
                }
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

        private void FetchObjectGiayXacNhan(SafeDataReader dr)
        {
            _maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
            _maGiayXacNhanQL = dr.GetString("MaGiayXacNhanQL");
            _tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _soChuongTrinh = dr.GetString("SoChuongTrinh");
            _ngayPhatSong = dr.GetSmartDate("NgayPhatSong", _ngayPhatSong.EmptyIsMin);
            _soHopDong = dr.GetString("SoHopDong");
            _maDonViXacNhanDi = dr.GetInt32("MaDonViXacNhanDi");

            _nguoiLap = dr.GetInt32("NguoiLap");
            object soTien = dr.GetValue("SoTien");

            if (soTien != null)
                _soTien = (decimal)soTien;
            else
                _soTien = null;
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _trangThai = dr.GetBoolean("TrangThai");
            _ghiChu = dr.GetString("GhiChu");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
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
            DataPortal_Delete(new Criteria(_maGiayXacNhan));
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
                cm.CommandText = "DeleteGiayXacNhanTongHop";

                cm.Parameters.AddWithValue("@MaGiayXacNhan", criteria.MaGiayXacNhan);

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
            _maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
            _maGiayXacNhanQL = dr.GetString("MaGiayXacNhanQL");
            _tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _maChuongTrinhQL = dr.GetString("MaChuongTrinhQL");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maBoPhanDi = dr.GetInt32("MaBoPhanDi");
            _maBoPhanDen = dr.GetInt32("MaBoPhanDen");
            _soTien = dr.GetDecimal("SoTien");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _ngayHoanTat = dr.GetSmartDate("NgayHoanTat", _ngayHoanTat.EmptyIsMin);
            _hoanTat = dr.GetBoolean("HoanTat");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayXacNhanTongHopList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayXacNhanTongHopList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "AddGiayXacNhanTongHop";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayXacNhanTongHopList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            if (_maGiayXacNhanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhanQL", _maGiayXacNhanQL);
            else
                cm.Parameters.AddWithValue("@MaGiayXacNhanQL", DBNull.Value);
            if (_tenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_maChuongTrinhQL.Length > 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhQL", _maChuongTrinhQL);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhQL", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maBoPhanDi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDi", _maBoPhanDi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
            if (_maBoPhanDen != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDen", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soTienConLai != 0)
                cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            else
                cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_duocNhapHo != false)
                cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            else
                cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayXacNhanTongHopList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, GiayXacNhanTongHopList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateGiayXacNhanTongHop";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayXacNhanTongHopList parent)
        {
            cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            if (_maGiayXacNhanQL.Length > 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhanQL", _maGiayXacNhanQL);
            else
                cm.Parameters.AddWithValue("@MaGiayXacNhanQL", DBNull.Value);
            if (_tenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_maChuongTrinhQL.Length > 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhQL", _maChuongTrinhQL);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhQL", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maBoPhanDi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDi", _maBoPhanDi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
            if (_maBoPhanDen != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDen", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soTienConLai != 0)
                cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            else
                cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
            if (_hoanTat != false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            if (_duocNhapHo != false)
                cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            else
                cm.Parameters.AddWithValue("@DuocNhapHo", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maGiayXacNhan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


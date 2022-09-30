using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DuyetCCDC : Csla.BusinessBase<DuyetCCDC>
    {
        #region Business Properties and Methods
        //reference object
        private CCDC _congCuDungCu;
        public CCDC CongCuDungCu
        {
            get
            {
                if ((_congCuDungCu == null && _maCongCuDungCu != 0) || (_congCuDungCu != null && _congCuDungCu.MaCongCuDungCu != _maCongCuDungCu))
                {
                    _congCuDungCu = CCDC.GetCongCuDungCu(_maCongCuDungCu);
                }
                return _congCuDungCu;

            }
            //set { _congCuDungCu = value; }
        }
        //declare members
        private int _maDuyetCongCuDungCu = 0;
        private int _maCongCuDungCu = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private byte _loaiNghiepVu = 0;
        private bool _daDuyet = false;
        private SmartDate _ngayDuyet = new SmartDate(false);
        private bool _daThucHienNghiepVu = false;
        private int _maUserLap = 0;
        private int _maUserDuyet = 0;
        //private int _maChiTietThanhLy = 0;
        private int _maChiTietDieuChuyenNoiBo = 0;
        //private int _maChiTietDieuChuyenNgoai = 0;
        private string _dienGiai = string.Empty;
        private bool _Chon = false;

        private string _tenHangHoa = string.Empty;
        private string _MaQuanLy = string.Empty;

        private int _MaBoPhanHienTai = 0;
        public int MaBoPhanHienTai
        {
            get
            {
                return _MaBoPhanHienTai;
            }
        }
        private string _MaBoPhanQLHienTai = string.Empty;
        public string MaBoPhanQLHienTai
        {
            get
            {
                return _MaBoPhanQLHienTai;
            }
        }
        private string _TenBoPhanHienTai = string.Empty;
        public string TenBoPhanHienTai
        {
            get
            {
                return _TenBoPhanHienTai;
            }
        }

        public bool Chon
        {
            get { return _Chon; }
            set { _Chon = value; }
        }

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDuyetCongCuDungCu
        {
            get
            {
                CanReadProperty("MaDuyetCongCuDungCu", true);
                return _maDuyetCongCuDungCu;
            }
        }

        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaCongCuDungCu", true);
                if (!_maCongCuDungCu.Equals(value))
                {
                    _maCongCuDungCu = value;
                    PropertyHasChanged("MaCongCuDungCu");
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
                if (!_ngayLap.Date.Equals(value))
                {
                    _ngayLap.Date = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public byte LoaiNghiepVu
        {
            get
            {
                CanReadProperty("LoaiNghiepVu", true);
                return _loaiNghiepVu;
            }
            set
            {
                CanWriteProperty("LoaiNghiepVu", true);
                if (!_loaiNghiepVu.Equals(value))
                {
                    _loaiNghiepVu = value;
                    PropertyHasChanged("LoaiNghiepVu");
                }
            }
        }

        public bool DaDuyet
        {
            get
            {
                CanReadProperty("DaDuyet", true);
                return _daDuyet;
            }
            set
            {
                CanWriteProperty("DaDuyet", true);
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged("DaDuyet");
                }
            }
        }

        public bool DaThucHienNghiepVu
        {
            get
            {
                CanReadProperty("DaThucHienNghiepVu", true);
                return _daThucHienNghiepVu;
            }
            set
            {
                CanWriteProperty("DaThucHienNghiepVu", true);
                if (!_daThucHienNghiepVu.Equals(value))
                {
                    _daThucHienNghiepVu = value;
                    PropertyHasChanged("DaThucHienNghiepVu");
                }
            }
        }
        public DateTime NgayDuyet
        {
            get
            {
                CanReadProperty("NgayDuyet", true);
                return _ngayDuyet.Date;
            }
            set
            {
                CanWriteProperty("NgayDuyet", true);
                if (!_ngayDuyet.Date.Equals(value))
                {
                    _ngayDuyet.Date = value;
                    PropertyHasChanged("NgayDuyet");
                }
            }
        }



        public int MaUserLap
        {
            get
            {
                CanReadProperty("MaUserLap", true);
                return _maUserLap;
            }
            set
            {
                CanWriteProperty("MaUserLap", true);
                if (!_maUserLap.Equals(value))
                {
                    _maUserLap = value;
                    PropertyHasChanged("MaUserLap");
                }
            }
        }

        public int MaUserDuyet
        {
            get
            {
                CanReadProperty("MaUserDuyet", true);
                return _maUserDuyet;
            }
            set
            {
                CanWriteProperty("MaUserDuyet", true);
                if (!_maUserDuyet.Equals(value))
                {
                    _maUserDuyet = value;
                    PropertyHasChanged("MaUserDuyet");
                }
            }
        }

        //public int MaChiTietThanhLy
        //{
        //    get
        //    {
        //        CanReadProperty("MaThanhLy", true);
        //        return _maChiTietThanhLy;
        //    }
        //    set
        //    {
        //        CanWriteProperty("MaThanhLy", true);
        //        if (!_maChiTietThanhLy.Equals(value))
        //        {
        //            _maChiTietThanhLy = value;
        //            PropertyHasChanged("MaThanhLy");
        //        }
        //    }
        //}

        public int MaChiTietDieuChuyenNoiBo
        {
            get
            {
                CanReadProperty("MaDieuChuyenNoiBo", true);
                return _maChiTietDieuChuyenNoiBo;
            }
            set
            {
                CanWriteProperty("MaDieuChuyenNoiBo", true);
                if (!_maChiTietDieuChuyenNoiBo.Equals(value))
                {
                    _maChiTietDieuChuyenNoiBo = value;
                    PropertyHasChanged("MaDieuChuyenNoiBo");
                }
            }
        }

        //public int MaChiTietDieuChuyenNgoai
        //{
        //    get
        //    {
        //        CanReadProperty("MaDieuChuyenNgoai", true);
        //        return _maChiTietDieuChuyenNgoai;
        //    }
        //    set
        //    {
        //        CanWriteProperty("MaDieuChuyenNgoai", true);
        //        if (!_maChiTietDieuChuyenNgoai.Equals(value))
        //        {
        //            _maChiTietDieuChuyenNgoai = value;
        //            PropertyHasChanged("MaDieuChuyenNgoai");
        //        }
        //    }
        //}

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

        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                return _tenHangHoa;
            }
        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _MaQuanLy;
            }
        }

        protected override object GetIdValue()
        {
            return _maDuyetCongCuDungCu;
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
            //TODO: Define authorization rules in DuyetCongCuDungCu
            //AuthorizationRules.AllowRead("MaDuyetCongCuDungCu", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("LoaiNghiepVu", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("DaDuyet", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayDuyet", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayDuyetString", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaUserLap", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaUserDuyet", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaThanhLy", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaDieuChuyenNoiBo", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaDieuChuyenNgoai", "DuyetCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DuyetCongCuDungCuReadGroup");

            //AuthorizationRules.AllowWrite("MaCongCuDungCu", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiNghiepVu", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("DaDuyet", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayDuyetString", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaUserLap", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaUserDuyet", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaThanhLy", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaDieuChuyenNoiBo", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaDieuChuyenNgoai", "DuyetCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DuyetCongCuDungCuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DuyetCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DuyetCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DuyetCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DuyetCongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DuyetCCDC()
        { /* require use of factory method */ }

        public static DuyetCCDC NewDuyetCongCuDungCu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DuyetCongCuDungCu");
            return DataPortal.Create<DuyetCCDC>();
        }
        public static DuyetCCDC GetDuyetCongCuDungCu(int maDuyetCongCuDungCu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCu");
            return DataPortal.Fetch<DuyetCCDC>(new Criteria(maDuyetCongCuDungCu));
        }
        public static DuyetCCDC GetDuyetCongCuDungCu_ByMaChiTietDieuChuyenNoiBo(int maChiTietDieuChuyenNoiBo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCu");
            return DataPortal.Fetch<DuyetCCDC>(new Criteria_ByMaChiTietDieuChuyenNoiBo(maChiTietDieuChuyenNoiBo));
        }

        public static void DeleteDuyetCongCuDungCu(int maDuyetCongCuDungCu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DuyetCongCuDungCu");
            DataPortal.Delete(new Criteria(maDuyetCongCuDungCu));
        }

        public override DuyetCCDC Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DuyetCongCuDungCu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DuyetCongCuDungCu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DuyetCongCuDungCu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DuyetCCDC NewDuyetCongCuDungCuChild()
        {
            DuyetCCDC child = new DuyetCCDC();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DuyetCCDC GetDuyetCongCuDungCu(SafeDataReader dr)
        {
            DuyetCCDC child = new DuyetCCDC();
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
            public int MaDuyetCongCuDungCu;

            public Criteria(int maDuyetCongCuDungCu)
            {
                this.MaDuyetCongCuDungCu = maDuyetCongCuDungCu;
            }
        }

        [Serializable()]
        private class Criteria_ByMaChiTietDieuChuyenNoiBo
        {
            public int MaChiTietDieuChuyenNoiBo;

            public Criteria_ByMaChiTietDieuChuyenNoiBo(int maChiTietDieuChuyenNoiBo)
            {
                this.MaChiTietDieuChuyenNoiBo = maChiTietDieuChuyenNoiBo;
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
        private void DataPortal_Fetch(object criteria)
        {
            if (criteria is Criteria)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch(tr, criteria as Criteria);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is Criteria_ByMaChiTietDieuChuyenNoiBo)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_ByMaChiTietDieuChuyenNoiBo(tr, criteria as Criteria_ByMaChiTietDieuChuyenNoiBo);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
        }
        private void ExecuteFetch_ByMaChiTietDieuChuyenNoiBo(SqlTransaction tr, Criteria_ByMaChiTietDieuChuyenNoiBo criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCu_ByMaChiTietDieuChuyenNoiBo";

                cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNoiBo", criteria.MaChiTietDieuChuyenNoiBo);

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
        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCu";

                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", criteria.MaDuyetCongCuDungCu);

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
            DataPortal_Delete(new Criteria(_maDuyetCongCuDungCu));
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
                cm.CommandText = "spd_DeleteDuyetCongCuDungCu";

                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", criteria.MaDuyetCongCuDungCu);

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
            _maDuyetCongCuDungCu = dr.GetInt32("MaDuyetCongCuDungCu");
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _loaiNghiepVu = dr.GetByte("LoaiNghiepVu");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _daThucHienNghiepVu = dr.GetBoolean("DaThucHienNghiepVu");
            _ngayDuyet = dr.GetSmartDate("NgayDuyet", _ngayDuyet.EmptyIsMin);
            _maUserLap = dr.GetInt32("MaUserLap");
            _maUserDuyet = dr.GetInt32("MaUserDuyet");
            //_maChiTietThanhLy = dr.GetInt32("MaChiTietThanhLy");
            _maChiTietDieuChuyenNoiBo = dr.GetInt32("MaChiTietDieuChuyenNoiBo");
            //_maChiTietDieuChuyenNgoai = dr.GetInt32("MaChiTietDieuChuyenNgoai");
            _dienGiai = dr.GetString("DienGiai");

            _tenHangHoa = dr.GetString("TenHangHoa");
            _MaQuanLy = dr.GetString("MaQuanLy");

            _MaBoPhanHienTai = dr.GetInt32("MaBoPhanHienTai");
            _MaBoPhanQLHienTai = dr.GetString("MaBoPhanQLHienTai");
            _TenBoPhanHienTai = dr.GetString("TenBoPhanHienTai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DuyetCCDCList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DuyetCCDCList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertDuyetCongCuDungCu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maDuyetCongCuDungCu = (int)cm.Parameters["@MaDuyetCongCuDungCu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DuyetCCDCList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_loaiNghiepVu != 0)
                cm.Parameters.AddWithValue("@LoaiNghiepVu", _loaiNghiepVu);
            else
                cm.Parameters.AddWithValue("@LoaiNghiepVu", DBNull.Value);
            if (_daDuyet != false)
                cm.Parameters.AddWithValue("@DaDuyet", _daDuyet);
            else
                cm.Parameters.AddWithValue("@DaDuyet", DBNull.Value);

            if (_daThucHienNghiepVu != false)
                cm.Parameters.AddWithValue("@DaThucHienNghiepVu", _daThucHienNghiepVu);
            else
                cm.Parameters.AddWithValue("@DaThucHienNghiepVu", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayDuyet", _ngayDuyet.DBValue);
            cm.Parameters.AddWithValue("@MaUserLap", Security.CurrentUser.Info.UserID);  
           
            if (_maUserDuyet != 0)
                cm.Parameters.AddWithValue("@MaUserDuyet", _maUserDuyet);
            else
                cm.Parameters.AddWithValue("@MaUserDuyet", DBNull.Value);
            //if (_maChiTietThanhLy != 0)
            //    cm.Parameters.AddWithValue("@MaChiTietThanhLy", _maChiTietThanhLy);
            //else
            //    cm.Parameters.AddWithValue("@MaChiTietThanhLy", DBNull.Value);
            if (_maChiTietDieuChuyenNoiBo != 0)
                cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNoiBo", _maChiTietDieuChuyenNoiBo);
            else
                cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNoiBo", DBNull.Value);
            //if (_maChiTietDieuChuyenNgoai != 0)
            //    cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNgoai", _maChiTietDieuChuyenNgoai);
            //else
            //    cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNgoai", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            cm.Parameters["@MaDuyetCongCuDungCu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DuyetCCDCList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DuyetCCDCList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateDuyetCongCuDungCu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DuyetCCDCList parent)
        {
            cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_loaiNghiepVu != 0)
                cm.Parameters.AddWithValue("@LoaiNghiepVu", _loaiNghiepVu);
            else
                cm.Parameters.AddWithValue("@LoaiNghiepVu", DBNull.Value);

            if (_daDuyet != false)
                cm.Parameters.AddWithValue("@DaDuyet", _daDuyet);
            else
                cm.Parameters.AddWithValue("@DaDuyet", DBNull.Value);
            //
            if (_daThucHienNghiepVu != false)
                cm.Parameters.AddWithValue("@DaThucHienNghiepVu", _daThucHienNghiepVu);
            else
                cm.Parameters.AddWithValue("@DaThucHienNghiepVu", DBNull.Value);
            //
            cm.Parameters.AddWithValue("@NgayDuyet", _ngayDuyet.DBValue);
            cm.Parameters.AddWithValue("@MaUserLap", Security.CurrentUser.Info.UserID);  
            if (_maUserDuyet != 0)
                cm.Parameters.AddWithValue("@MaUserDuyet", _maUserDuyet);
            else
                cm.Parameters.AddWithValue("@MaUserDuyet", DBNull.Value);
            //if (_maChiTietThanhLy != 0)
            //    cm.Parameters.AddWithValue("@MaChiTietThanhLy", _maChiTietThanhLy);
            //else
            //    cm.Parameters.AddWithValue("@MaChiTietThanhLy", DBNull.Value);
            if (_maChiTietDieuChuyenNoiBo != 0)
                cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNoiBo", _maChiTietDieuChuyenNoiBo);
            else
                cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNoiBo", DBNull.Value);
            //if (_maChiTietDieuChuyenNgoai != 0)
            //    cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNgoai", _maChiTietDieuChuyenNgoai);
            //else
            //    cm.Parameters.AddWithValue("@MaChiTietDieuChuyenNgoai", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maDuyetCongCuDungCu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

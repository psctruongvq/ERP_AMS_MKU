
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LenhChuyenTienNuocNgoai : Csla.BusinessBase<LenhChuyenTienNuocNgoai>
    {
        #region Business Properties and Methods

        //declare members
        private long _maLenhCT = 0;
        private string _so = string.Empty;
        private DateTime? _ngayXacNhan = null;
        private string _dienGiai = string.Empty;
        private string _ghiChu = string.Empty;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _nganHangChuyen = 0;
        private int _nganHangNhan = 0;
        private int _soDeNghi = 0;
        private int _soChungTu = 0;
        private int _userId = 0;
        private int _hinhThucChuyen = 0;
        private int _loaiTien = 0;
        private string _soTienBangChu = string.Empty;
        private string _noiDungThanhToan = string.Empty;
        private int _loaiPhiDichVu = 0;
        private decimal _soTien = 0;
        private int _maDoiTac = 0;
        private decimal _tyGia = 0;
        private bool _chon = false;

        //declare child member(s)
        private ChiTietDeNghi_LenhChuyenTienList _chiTietDeNghi_LenhChuyenTienList = ChiTietDeNghi_LenhChuyenTienList.NewChiTietDeNghi_LenhChuyenTienList();

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaLenhCT
        {
            get
            {
                CanReadProperty("MaLenhCT", true);
                return _maLenhCT;
            }
        }

        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
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

        public DateTime? NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                CanReadProperty("NgayXacNhan", true);
                if (_ngayXacNhan == DateTime.MinValue)
                {
                    _ngayXacNhan = null;
                }
                return _ngayXacNhan;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                if (!_ngayXacNhan.Equals(value))
                {
                    if (value == null)
                        _ngayXacNhan = null;
                    else if (value != DateTime.MinValue & value != DateTime.MaxValue & ((DateTime)value).Year != 1753)
                    {
                        _ngayXacNhan = value;
                        PropertyHasChanged("NgayXacNhan");
                    }
                    PropertyHasChanged("NgayXacNhan");
                }
            }
        }

        public int NganHangChuyen
        {
            get
            {
                CanReadProperty("NganHangChuyen", true);
                return _nganHangChuyen;
            }
            set
            {
                CanWriteProperty("NganHangChuyen", true);
                if (!_nganHangChuyen.Equals(value))
                {
                    _nganHangChuyen = value;
                    PropertyHasChanged("NganHangChuyen");
                }
            }
        }

        public int NganHangNhan
        {
            get
            {
                CanReadProperty("NganHangNhan", true);
                return _nganHangNhan;
            }
            set
            {
                CanWriteProperty("NganHangNhan", true);
                if (!_nganHangNhan.Equals(value))
                {
                    _nganHangNhan = value;
                    PropertyHasChanged("NganHangNhan");
                }
            }
        }

        public int SoDeNghi
        {
            get
            {
                CanReadProperty("SoDeNghi", true);
                return _soDeNghi;
            }
            set
            {
                CanWriteProperty("SoDeNghi", true);
                if (!_soDeNghi.Equals(value))
                {
                    _soDeNghi = value;
                    PropertyHasChanged("SoDeNghi");
                }
            }
        }

        public int SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
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

        public int HinhThucChuyen
        {
            get
            {
                CanReadProperty("HinhThucChuyen", true);
                return _hinhThucChuyen;
            }
            set
            {
                CanWriteProperty("HinhThucChuyen", true);
                if (!_hinhThucChuyen.Equals(value))
                {
                    _hinhThucChuyen = value;
                    PropertyHasChanged("HinhThucChuyen");
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

        public string SoTienBangChu
        {
            get
            {
                CanReadProperty("SoTienBangChu", true);
                return _soTienBangChu;
            }
            set
            {
                CanWriteProperty("SoTienBangChu", true);
                if (value == null) value = string.Empty;
                if (!_soTienBangChu.Equals(value))
                {
                    _soTienBangChu = value;
                    PropertyHasChanged("SoTienBangChu");
                }
            }
        }

        public string NoiDungThanhToan
        {
            get
            {
                CanReadProperty("NoiDungThanhToan", true);
                return _noiDungThanhToan;
            }
            set
            {
                CanWriteProperty("NoiDungThanhToan", true);
                if (value == null) value = string.Empty;
                if (!_noiDungThanhToan.Equals(value))
                {
                    _noiDungThanhToan = value;
                    PropertyHasChanged("NoiDungThanhToan");
                }
            }
        }

        public int LoaiPhiDichVu
        {
            get
            {
                CanReadProperty("LoaiPhiDichVu", true);
                return _loaiPhiDichVu;
            }
            set
            {
                CanWriteProperty("LoaiPhiDichVu", true);
                if (!_loaiPhiDichVu.Equals(value))
                {
                    _loaiPhiDichVu = value;
                    PropertyHasChanged("LoaiPhiDichVu");
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

        public int MaDoiTac
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

        public ChiTietDeNghi_LenhChuyenTienList ChiTietDeNghi_LenhChuyenTienList
        {
            get
            {
                CanReadProperty("ChiTietDeNghi_LenhChuyenTienList", true);
                return _chiTietDeNghi_LenhChuyenTienList;
            }
            set
            {
                CanWriteProperty("ChiTietDeNghi_LenhChuyenTienList", true);
                if (!_chiTietDeNghi_LenhChuyenTienList.Equals(value))
                {
                    _chiTietDeNghi_LenhChuyenTienList = value;
                    PropertyHasChanged("ChiTietDeNghi_LenhChuyenTienList");
                }
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chiTietDeNghi_LenhChuyenTienList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiTietDeNghi_LenhChuyenTienList.IsDirty; }
        }


        protected override object GetIdValue()
        {
            return _maLenhCT;
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
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 50));
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 200));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
            ////
            //// SoTienBangChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTienBangChu", 200));
        }

        protected override void AddBusinessRules()
        {
            //AddCommonRules();
            //AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in LenhChuyenTienNuocNgoai
            //AuthorizationRules.AllowRead("MaLenhCT", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("So", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhan", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayXacNhanString", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NganHangChuyen", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NganHangNhan", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoDeNghi", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("UserId", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("HinhThucChuyen", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoTienBangChu", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NoiDungThanhToan", "LenhChuyenTienNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LoaiPhiDichVu", "LenhChuyenTienNuocNgoaiReadGroup");

            //AuthorizationRules.AllowWrite("So", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayXacNhanString", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NganHangChuyen", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NganHangNhan", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoDeNghi", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("UserId", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("HinhThucChuyen", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienBangChu", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDungThanhToan", "LenhChuyenTienNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiPhiDichVu", "LenhChuyenTienNuocNgoaiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LenhChuyenTienNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LenhChuyenTienNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LenhChuyenTienNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LenhChuyenTienNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LenhChuyenTienNuocNgoai()
        { 
            /* require use of factory method */
            MarkAsChild();
        }

        public static LenhChuyenTienNuocNgoai NewLenhChuyenTienNuocNgoai()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LenhChuyenTienNuocNgoai");
            return DataPortal.Create<LenhChuyenTienNuocNgoai>();
        }

        public static LenhChuyenTienNuocNgoai GetLenhChuyenTienNuocNgoai(long maLenhCT)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LenhChuyenTienNuocNgoai");
            return DataPortal.Fetch<LenhChuyenTienNuocNgoai>(new Criteria(maLenhCT));
        }

        public static void DeleteLenhChuyenTienNuocNgoai(long maLenhCT)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LenhChuyenTienNuocNgoai");
            DataPortal.Delete(new Criteria(maLenhCT));
        }

        public override LenhChuyenTienNuocNgoai Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LenhChuyenTienNuocNgoai");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LenhChuyenTienNuocNgoai");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LenhChuyenTienNuocNgoai");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LenhChuyenTienNuocNgoai NewLenhChuyenTienNuocNgoaiChild()
        {
            LenhChuyenTienNuocNgoai child = new LenhChuyenTienNuocNgoai();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LenhChuyenTienNuocNgoai GetLenhChuyenTienNuocNgoai(SafeDataReader dr)
        {
            LenhChuyenTienNuocNgoai child = new LenhChuyenTienNuocNgoai();
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
            public long MaLenhCT;

            public Criteria(long maLenhCT)
            {
                this.MaLenhCT = maLenhCT;
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
                cm.CommandText = "spd_SelecttblLenhChuyenTienNuocNgoai";

                cm.Parameters.AddWithValue("@MaLenhCT", criteria.MaLenhCT);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read())
                    {
                        FetchObject(dr);
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
            DataPortal_Delete(new Criteria(_maLenhCT));
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
                cm.CommandText = "spd_DeletetblLenhChuyenTienNuocNgoai";

                cm.Parameters.AddWithValue("@MaLenhCT", criteria.MaLenhCT);

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
            _maLenhCT = dr.GetInt64("MaLenhCT");
            _so = dr.GetString("So");
            _ngayLap = dr.GetDateTime("NgayLap");
            _dienGiai = dr.GetString("DienGiai");
            _ghiChu = dr.GetString("GhiChu");
            NgayXacNhan = dr.GetDateTime("NgayXacNhan");
            _nganHangChuyen = dr.GetInt32("NganHangChuyen");
            _nganHangNhan = dr.GetInt32("NganHangNhan");
            _soDeNghi = dr.GetInt32("SoDeNghi");
            _soChungTu = dr.GetInt32("SoChungTu");
            _userId = dr.GetInt32("UserId");
            _hinhThucChuyen = dr.GetInt32("HinhThucChuyen");
            _loaiTien = dr.GetInt32("LoaiTien");
            _soTienBangChu = dr.GetString("SoTienBangChu");
            _noiDungThanhToan = dr.GetString("NoiDungThanhToan");
            _loaiPhiDichVu = dr.GetInt32("LoaiPhiDichVu");
            _soTien = dr.GetDecimal("SoTien");
            _maDoiTac = dr.GetInt32("MaDoiTac");
            _tyGia = dr.GetDecimal("TyGia");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _chiTietDeNghi_LenhChuyenTienList = ChiTietDeNghi_LenhChuyenTienList.GetChungTu_LenhChuyenTienNNChildList(_maLenhCT);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LenhChuyenTienNuocNgoaiList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LenhChuyenTienNuocNgoaiList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLenhChuyenTienNuocNgoai";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLenhCT = (long)cm.Parameters["@MaLenhCT"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LenhChuyenTienNuocNgoaiList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            if (_nganHangChuyen != 0)
                cm.Parameters.AddWithValue("@NganHangChuyen", _nganHangChuyen);
            else
                cm.Parameters.AddWithValue("@NganHangChuyen", DBNull.Value);
            if (_nganHangNhan != 0)
                cm.Parameters.AddWithValue("@NganHangNhan", _nganHangNhan);
            else
                cm.Parameters.AddWithValue("@NganHangNhan", DBNull.Value);
            if (_soDeNghi != 0)
                cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            else
                cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
            if (_soChungTu != 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_hinhThucChuyen != 0)
                cm.Parameters.AddWithValue("@HinhThucChuyen", _hinhThucChuyen);
            else
                cm.Parameters.AddWithValue("@HinhThucChuyen", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_soTienBangChu.Length > 0)
                cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
            else
                cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
            if (_noiDungThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@NoiDungThanhToan", _noiDungThanhToan);
            else
                cm.Parameters.AddWithValue("@NoiDungThanhToan", DBNull.Value);
            if (_loaiPhiDichVu != 0)
                cm.Parameters.AddWithValue("@LoaiPhiDichVu", _loaiPhiDichVu);
            else
                cm.Parameters.AddWithValue("@LoaiPhiDichVu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            cm.Parameters["@MaLenhCT"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LenhChuyenTienNuocNgoaiList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LenhChuyenTienNuocNgoaiList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLenhChuyenTienNuocNgoai";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LenhChuyenTienNuocNgoaiList parent)
        {
            cm.Parameters.AddWithValue("@MaLenhCT", _maLenhCT);
            if (_so.Length > 0)
                cm.Parameters.AddWithValue("@So", _so);
            else
                cm.Parameters.AddWithValue("@So", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            if (_nganHangChuyen != 0)
                cm.Parameters.AddWithValue("@NganHangChuyen", _nganHangChuyen);
            else
                cm.Parameters.AddWithValue("@NganHangChuyen", DBNull.Value);
            if (_nganHangNhan != 0)
                cm.Parameters.AddWithValue("@NganHangNhan", _nganHangNhan);
            else
                cm.Parameters.AddWithValue("@NganHangNhan", DBNull.Value);
            if (_soDeNghi != 0)
                cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            else
                cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
            if (_soChungTu != 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
            if (_hinhThucChuyen != 0)
                cm.Parameters.AddWithValue("@HinhThucChuyen", _hinhThucChuyen);
            else
                cm.Parameters.AddWithValue("@HinhThucChuyen", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_soTienBangChu.Length > 0)
                cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
            else
                cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
            if (_noiDungThanhToan.Length > 0)
                cm.Parameters.AddWithValue("@NoiDungThanhToan", _noiDungThanhToan);
            else
                cm.Parameters.AddWithValue("@NoiDungThanhToan", DBNull.Value);
            if (_loaiPhiDichVu != 0)
                cm.Parameters.AddWithValue("@LoaiPhiDichVu", _loaiPhiDichVu);
            else
                cm.Parameters.AddWithValue("@LoaiPhiDichVu", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (_tyGia != 0)
                cm.Parameters.AddWithValue("@TyGia", _tyGia);
            else
                cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chiTietDeNghi_LenhChuyenTienList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _chiTietDeNghi_LenhChuyenTienList.DataPortal_Delete(tr);
            ExecuteDelete(tr, new Criteria(_maLenhCT));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public string GetMaLenhChuyenTien()
        {
            string strLenhChuyen = "E";//string.Empty;
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{
            //    cn.Open();
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_LayMaUNCNganHang";
            //        cm.Parameters.AddWithValue("@MaNganHang", _nganHangBan);

            //        strMaUNC = Convert.ToString(cm.ExecuteScalar());
            //    }

            //    cn.Close();
            //}
            return strLenhChuyen;
        }

        public string GetSoChungTu(ref int iSoChungTu)
        {
            string strSoChungTu = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoChungTuMax_LenhChuyenTien";
                    cm.Parameters.AddWithValue("@MaNganHang", _nganHangChuyen);
                    cm.Parameters.AddWithValue("@Nam", _ngayLap.Year);

                    //Do công ty khác nhau cung sử dụng 1 TK ngân hàng nên phải lấy thêm từng công ty
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    iSoChungTu = Convert.ToInt32(cm.ExecuteScalar());
                }
                cn.Close();
            }
            iSoChungTu++;
            if (iSoChungTu.ToString().Length == 1)
                strSoChungTu = "000" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 2)
                strSoChungTu = "00" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 3)
                strSoChungTu = "0" + iSoChungTu.ToString();
            else
                strSoChungTu = iSoChungTu.ToString();

            return strSoChungTu;
        }
    }
}

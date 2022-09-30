
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CongCuDungCu : Csla.BusinessBase<CongCuDungCu>
    {
        #region Business Properties and Methods
        //reference object
        HangHoaBQ_VT _hangHoaBQ_VT = null;
        public HangHoaBQ_VT HangHoaBQ_VT
        {
            get
            {
                if ((_hangHoaBQ_VT == null && _maHangHoa != 0) || (_hangHoaBQ_VT != null && _hangHoaBQ_VT.MaHangHoa != _maHangHoa))
                {
                    _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa);
                }
                return _hangHoaBQ_VT;
            }

        }
        //declare members
        private bool _chon = false;
        private int _maCongCuDungCu = 0;
        private string _soSerial = string.Empty;
        private decimal _nguyenGia = 0;
        private string _maQuanLy = string.Empty;
        private SmartDate _ngayNhan = new SmartDate(true);
        private bool _thanhLy = false;
        private SmartDate _ngayThanhLy = new SmartDate(true);
        private string _viTri = string.Empty;
        private int _maHangHoa = 0;
        private byte _tinhTrang = 0;
        private long _maPhieuNhapXuat = 0;
        private decimal _chiPhiDaPhanBo = 0;
        private decimal _chiPhiPBLanDau = 0;
        private decimal _phanTramPBLanDau = 0;
        private long _maThanhLy = 0;
        private int _maDuyetCongCuDungCu = 0;//su dung cho nghiep vu thanh ly va dieu chuyen ngoai, dung khi update, ko dung khi insert
        private int _maTaiKhoan = 0;

        private string _TenHangHoa = string.Empty;
        //child member
        private CongCuDungCu_PhongBan _congCuDungCu_PhongBan = CongCuDungCu_PhongBan.NewCongCuDungCu_PhongBan();

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
                    //PropertyHasChanged("Chon");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
        }

        public string SoSerial
        {
            get
            {
                CanReadProperty("SoSerial", true);
                return _soSerial;
            }
            set
            {
                CanWriteProperty("SoSerial", true);
                if (value == null) value = string.Empty;
                if (!_soSerial.Equals(value))
                {
                    _soSerial = value;
                    PropertyHasChanged("SoSerial");
                }
            }
        }

        public decimal NguyenGia
        {
            get
            {
                CanReadProperty("NguyenGia", true);
                return _nguyenGia;
            }
            set
            {
                CanWriteProperty("NguyenGia", true);
                if (!_nguyenGia.Equals(value))
                {
                    _nguyenGia = value;
                    _chiPhiPBLanDau = Math.Round(_phanTramPBLanDau * _nguyenGia / 100);
                    _chiPhiDaPhanBo = Math.Round(_phanTramPBLanDau * _nguyenGia / 100);
                    PropertyHasChanged("NguyenGia");
                }
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
                _ngayNhan.Date = value;
                _congCuDungCu_PhongBan.NgayNhan = value;
                PropertyHasChanged("NgayNhan");
            }
        }
        public string NgayNhanString
        {
            get
            {
                CanReadProperty("NgayNhanString", true);
                return _ngayNhan.Text;
            }
            set
            {
                CanWriteProperty("NgayNhanString", true);
                if (value == null) value = string.Empty;
                if (!_ngayNhan.Equals(value))
                {
                    _ngayNhan.Text = value;
                    _congCuDungCu_PhongBan.NgayNhan = _ngayNhan.Date;
                    PropertyHasChanged("NgayNhanString");
                }
            }
        }
        public bool ThanhLy
        {
            get
            {
                CanReadProperty("ThanhLy", true);
                return _thanhLy;
            }
            set
            {
                CanWriteProperty("ThanhLy", true);
                if (!_thanhLy.Equals(value))
                {
                    _thanhLy = value;
                    PropertyHasChanged("ThanhLy");
                }
            }
        }

        public DateTime NgayThanhLy
        {
            get
            {
                CanReadProperty("NgayThanhLy", true);
                return _ngayThanhLy.Date;
            }
            set
            {
                CanWriteProperty("NgayThanhLy", true);
                if (!_ngayThanhLy.Date.Equals(value))
                {
                    _ngayThanhLy.Date = value;
                    PropertyHasChanged("NgayThanhLy");
                }
            }
        }

        public string NgayThanhLyString
        {
            get
            {
                CanReadProperty("NgayThanhLyString", true);
                return _ngayThanhLy.Text;
            }
            set
            {
                CanWriteProperty("NgayThanhLyString", true);
                if (value == null) value = string.Empty;
                if (!_ngayThanhLy.Equals(value))
                {
                    _ngayThanhLy.Text = value;
                    PropertyHasChanged("NgayThanhLyString");
                }
            }
        }

        public string ViTri
        {
            get
            {
                CanReadProperty("ViTri", true);
                return _viTri;
            }
            set
            {
                CanWriteProperty("ViTri", true);
                if (value == null) value = string.Empty;
                if (!_viTri.Equals(value))
                {
                    _viTri = value;
                    PropertyHasChanged("ViTri");
                }
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }
        public int MaDuyetCongCuDungCu
        {
            get
            {
                CanReadProperty("MaDuyetCongCuDungCu", true);
                return _maDuyetCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaDuyetCongCuDungCu", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maDuyetCongCuDungCu = value;
                    PropertyHasChanged("MaDuyetCongCuDungCu");
                }
            }
        }
        public byte TinhTrang
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

        public long MaPhieuNhapXuat
        {
            get
            {
                CanReadProperty("MaPhieuNhapXuat", true);
                return _maPhieuNhapXuat;
            }
            set
            {
                CanWriteProperty("MaPhieuNhapXuat", true);
                if (!_maPhieuNhapXuat.Equals(value))
                {
                    _maPhieuNhapXuat = value;
                    PropertyHasChanged("MaPhieuNhapXuat");
                }
            }
        }

        public decimal ChiPhiDaPhanBo
        {
            get
            {
                CanReadProperty("ChiPhiDaPhanBo", true);
                return _chiPhiDaPhanBo;
            }
            set
            {
                CanWriteProperty("ChiPhiDaPhanBo", true);
                if (!_chiPhiDaPhanBo.Equals(value))
                {
                    _chiPhiDaPhanBo = value;
                    PropertyHasChanged("ChiPhiDaPhanBo");
                }
            }
        }

        public decimal ChiPhiPBLanDau
        {
            get
            {
                CanReadProperty("ChiPhiPBLanDau", true);
                return _chiPhiPBLanDau;
            }
            set
            {
                CanWriteProperty("ChiPhiPBLanDau", true);
                if (!_chiPhiPBLanDau.Equals(value))
                {
                    _chiPhiPBLanDau = value;
                    _chiPhiDaPhanBo = value;
                    PropertyHasChanged("ChiPhiPBLanDau");
                }
            }
        }

        public decimal PhanTramPBLanDau
        {
            get
            {
                CanReadProperty("PhanTramPBLanDau", true);
                return _phanTramPBLanDau;
            }
            set
            {
                CanWriteProperty("PhanTramPBLanDau", true);
                if (!_phanTramPBLanDau.Equals(value))
                {
                    _phanTramPBLanDau = value;
                    _chiPhiPBLanDau = Math.Round(_phanTramPBLanDau * _nguyenGia / 100);
                    _chiPhiDaPhanBo = Math.Round(_phanTramPBLanDau * _nguyenGia / 100);
                    PropertyHasChanged("PhanTramPBLanDau");
                }
            }
        }

        public string TenHangHoa
        {
            get
            {
                if (_maCongCuDungCu != 0)
                    _TenHangHoa = GetTenHangHoabyMaCCDC(_maCongCuDungCu);
                return _TenHangHoa;
            }
        }

        public CongCuDungCu_PhongBan CongCuDungCu_PhongBan
        {
            get
            {
                CanReadProperty("CongCuDungCu_PhongBanList", true);
                return _congCuDungCu_PhongBan;
            }
        }

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _congCuDungCu_PhongBan.MaBoPhan;
            }
        }
        public long MaThanhLy
        {
            get
            {
                CanReadProperty("MaThanhLy", true);
                return _maThanhLy;
            }
            set
            {
                CanWriteProperty("MaThanhLy", true);
                if (!_maThanhLy.Equals(value))
                {
                    _maThanhLy = value;
                    PropertyHasChanged("MaThanhLy");
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
        public override bool IsValid
        {
            get { return base.IsValid && _congCuDungCu_PhongBan.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _congCuDungCu_PhongBan.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maCongCuDungCu;
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
            // SoSerial
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoSerial", 255));
            //
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            //
            // ViTri
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ViTri", 500));
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
            //TODO: Define authorization rules in CongCuDungCu
            //AuthorizationRules.AllowRead("CongCuDungCu_PhongBanList", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("SoSerial", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NguyenGia", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayNhan", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayNhanString", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("ThanhLy", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhLy", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("NgayThanhLyString", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("ViTri", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "CongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaPhieuNhapXuat", "CongCuDungCuReadGroup");

            //AuthorizationRules.AllowWrite("SoSerial", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NguyenGia", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuanLy", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNhanString", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhLy", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("NgayThanhLyString", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("ViTri", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "CongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "CongCuDungCuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongCuDungCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongCuDungCu()
        { /* require use of factory method */ this.MarkAsChild(); }

        public static CongCuDungCu NewCongCuDungCu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongCuDungCu");
            return DataPortal.Create<CongCuDungCu>();
        }

        public static CongCuDungCu NewCongCuDungCu(string maQuanLy, string viTri, int maBoPhan, int maHangHoa, decimal nguyenGia, DateTime ngayNhan, decimal PhanTramPhanBo)
        {
            CongCuDungCu congCuDungCu = new CongCuDungCu();
            congCuDungCu.MaQuanLy = maQuanLy;
            congCuDungCu.ViTri = viTri;
            congCuDungCu.CongCuDungCu_PhongBan.MaBoPhan = maBoPhan;
            congCuDungCu.MaHangHoa = maHangHoa;
            congCuDungCu.NguyenGia = nguyenGia;
            congCuDungCu.NgayNhan = ngayNhan;
            congCuDungCu.PhanTramPBLanDau = PhanTramPhanBo;
            congCuDungCu.ChiPhiPBLanDau = Math.Round(nguyenGia * PhanTramPhanBo / 100);
            congCuDungCu.MarkAsChild();
            return congCuDungCu;
        }

        public static CongCuDungCu GetCongCuDungCu(int maCongCuDungCu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongCuDungCu");
            return DataPortal.Fetch<CongCuDungCu>(new Criteria(maCongCuDungCu));
        }

        public static CongCuDungCu GetCongCuDungCuByMaHangHoa(int maHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongCuDungCu");
            return DataPortal.Fetch<CongCuDungCu>(new CriteriaByMaHangHoa(maHangHoa));
        }

        public static void DeleteCongCuDungCu(int maCongCuDungCu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongCuDungCu");
            DataPortal.Delete(new Criteria(maCongCuDungCu));
        }

        public override CongCuDungCu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongCuDungCu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongCuDungCu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CongCuDungCu");

            return base.Save();
        }

        private string GetTenHangHoabyMaCCDC(int maCCDC)
        {
            string tenhanghoa = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTenHangHoabyCCDC";
                    cm.Parameters.AddWithValue("@MaCCDC", maCCDC);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.NVarChar, 1000);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    tenhanghoa = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return tenhanghoa;
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CongCuDungCu NewCongCuDungCuChild()
        {
            CongCuDungCu child = new CongCuDungCu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CongCuDungCu GetCongCuDungCu(SafeDataReader dr)
        {
            CongCuDungCu child = new CongCuDungCu();
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
            public int MaCongCuDungCu;

            public Criteria(int maCongCuDungCu)
            {
                this.MaCongCuDungCu = maCongCuDungCu;
            }
        }

        private class CriteriaByMaHangHoa
        {
            public int MaHangHoa;

            public CriteriaByMaHangHoa(int maHangHoa)
            {
                this.MaHangHoa = maHangHoa;
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
        private void DataPortal_Fetch(Object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblCongCuDungCu";
                    cm.Parameters.AddWithValue("@MaCongCuDungCu", ((Criteria)criteria).MaCongCuDungCu);
                }
                else if (criteria is CriteriaByMaHangHoa)
                {
                    cm.CommandText = "spd_SelecttblCongCuDungCuByMaHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", ((CriteriaByMaHangHoa)criteria).MaHangHoa);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
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
            DataPortal_Delete(new Criteria(_maCongCuDungCu));
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
                    _congCuDungCu_PhongBan.DeleteSelf(tr);
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
                cm.CommandText = "spd_DeletetblCongCuDungCu";

                cm.Parameters.AddWithValue("@MaCongCuDungCu", criteria.MaCongCuDungCu);

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
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _soSerial = dr.GetString("SoSerial");
            _nguyenGia = dr.GetDecimal("NguyenGia");
            _maQuanLy = dr.GetString("MaQuanLy");
            _ngayNhan = dr.GetSmartDate("NgayNhan", _ngayNhan.EmptyIsMin);
            _thanhLy = dr.GetBoolean("ThanhLy");
            _ngayThanhLy = dr.GetSmartDate("NgayThanhLy", _ngayThanhLy.EmptyIsMin);
            _viTri = dr.GetString("ViTri");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            try
            {
                _maDuyetCongCuDungCu = dr.GetInt32("MaDuyetCongCuDungCu");
            }
            catch (System.Exception ex)
            {

            }
            _tinhTrang = dr.GetByte("TinhTrang");
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _chiPhiDaPhanBo = dr.GetDecimal("ChiPhiDaPhanBo");
            _chiPhiPBLanDau = dr.GetDecimal("ChiPhiPBLanDau");
            _phanTramPBLanDau = dr.GetDecimal("PhanTramPBLanDau");
            _maThanhLy = dr.GetInt64("MaThanhLy");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
        }

        private void FetchChildren(SafeDataReader dr)
        {

            _congCuDungCu_PhongBan = CongCuDungCu_PhongBan.GetCongCuDungCu_PhongBan(this._maCongCuDungCu);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuat parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuat parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongCuDungCu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCongCuDungCu = (int)cm.Parameters["@MaCongCuDungCu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuat parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhapXuat = parent.MaPhieuNhapXuat;
            if (_soSerial.Length > 0)
                cm.Parameters.AddWithValue("@SoSerial", _soSerial);
            else
                cm.Parameters.AddWithValue("@SoSerial", DBNull.Value);
            cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan.DBValue);
            if (_thanhLy != false)
                cm.Parameters.AddWithValue("@ThanhLy", _thanhLy);
            else
                cm.Parameters.AddWithValue("@ThanhLy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayThanhLy", _ngayThanhLy.DBValue);
            if (_viTri.Length > 0)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);
            //
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            //
            //if (_maDuyetCongCuDungCu != 0)
            //    cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            //else
            //    cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", DBNull.Value);
            //
            if (_tinhTrang != 0)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);


            cm.Parameters.AddWithValue("@ChiPhiDaPhanBo", _chiPhiDaPhanBo);
            cm.Parameters.AddWithValue("@ChiPhiPBLanDau", _chiPhiPBLanDau);
            cm.Parameters.AddWithValue("@PhanTramPBLanDau", _phanTramPBLanDau);

            cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            //
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            //
            cm.Parameters["@MaCongCuDungCu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuat parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongCuDungCu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
        {
            //
            if (_maThanhLy != 0)
                cm.Parameters.AddWithValue("@MaThanhLy", _maThanhLy);//khong lay parent.MaPhieuNhapXuat tai day, ma duoc gan bang parent.MaPhieuNhapXuat o class CongCuDungCuList;
            else
                cm.Parameters.AddWithValue("@MaThanhLy", DBNull.Value);
            //
            cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            if (_soSerial.Length > 0)
                cm.Parameters.AddWithValue("@SoSerial", _soSerial);
            else
                cm.Parameters.AddWithValue("@SoSerial", DBNull.Value);
            cm.Parameters.AddWithValue("@NguyenGia", _nguyenGia);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan.DBValue);
            if (_thanhLy != false)
                cm.Parameters.AddWithValue("@ThanhLy", _thanhLy);
            else
                cm.Parameters.AddWithValue("@ThanhLy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayThanhLy", _ngayThanhLy.DBValue);
            if (_viTri.Length > 0)
                cm.Parameters.AddWithValue("@ViTri", _viTri);
            else
                cm.Parameters.AddWithValue("@ViTri", DBNull.Value);
            //
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            //
            if (_maDuyetCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", DBNull.Value);
            //

            if (_tinhTrang != 0)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            //

            //
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            //
            cm.Parameters.AddWithValue("@ChiPhiDaPhanBo", _chiPhiDaPhanBo);
            cm.Parameters.AddWithValue("@ChiPhiPBLanDau", _chiPhiPBLanDau);
            cm.Parameters.AddWithValue("@PhanTramPBLanDau", _phanTramPBLanDau);

            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);

        }

        private void UpdateChildren(SqlTransaction tr)
        {
            if (_congCuDungCu_PhongBan.IsNew)
                _congCuDungCu_PhongBan.Insert(tr, this);
            else _congCuDungCu_PhongBan.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _congCuDungCu_PhongBan.DeleteSelf(tr);
            ExecuteDelete(tr, new Criteria(_maCongCuDungCu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

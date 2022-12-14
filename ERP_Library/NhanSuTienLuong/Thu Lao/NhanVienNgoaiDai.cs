
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Threading;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVienNgoaiDai : Csla.BusinessBase<NhanVienNgoaiDai>
    {
        #region Business Properties and Methods

        //declare members
        private long _MaChungTu;
        internal long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private SmartDate _ngayCap = new SmartDate(DateTime.MinValue);
       // private DateTime _ngayCap = DateTime.Today;
        private string _noiCap = string.Empty;
        private string _cmnd = string.Empty;
        private string _mst = string.Empty;
        private string _diaChi = string.Empty;
        private int _maQuocGia = 0;
        private int _maUNC = 0;
        private string _dienThoai = string.Empty;
        private bool _suDung = false;
        private bool _suDungChinh = false;
        private string _ghiChu = string.Empty;
        private int _maBoPhan = 0;
        private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private DateTime _ngayLap = DateTime.Today;
        private decimal _soTien = 0;
        private bool _caNhanCuTru = false;
        private bool _chon = false;

        private string _tenBoPhan = string.Empty;
        private int _maNganHang = 0;
        private string _tenNganHang = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private int _loaiNhanVien = 0;
        private long _maNhanVienChuyenTien = 0;
    
        //Phục vụ quản lý biên lai
        private decimal _soTienTraThuNhap = 0;
        private decimal _soTienThuNhapChiuThue = 0;
        private decimal _soTienDaKhauTru = 0;
        private decimal _soTienConLai = 0;
        private DateTime _ngayTraThuNhap = DateTime.Today;
        private bool _tinhTrangIn = false;
        private string _kyHieu = string.Empty;
        private string _quyen = string.Empty;
        private int _Stt = 0;
        private string _So = string.Empty;

        private string _tenQuocGia = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }
        public string KyHieu
        {
            get
            {
                return _kyHieu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_kyHieu.Equals(value))
                {
                    _kyHieu = value;
                    PropertyHasChanged("KyHieu");
                }
            }
        }
        public string Quyen
        {
            get
            {
                return _quyen;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_quyen.Equals(value))
                {
                    _quyen = value;
                    PropertyHasChanged("Quyen");
                }
            }
        }
        public decimal SoTien
        {
            get { return _soTien; }
            set { _soTien = value; }
        }

        public decimal SoTienTraThuNhap
        {
            get { return _soTienTraThuNhap; }
            set { _soTienTraThuNhap = value; }
        }

        public decimal SoTienDaKhauTru
        {
            get { return _soTienDaKhauTru; }
            set { _soTienDaKhauTru = value; }
        }

        public decimal SoTienThuNhapChiuThue
        {
            get { return _soTienThuNhapChiuThue; }
            set { _soTienThuNhapChiuThue = value; }
        }

        public decimal SoTienConLai
        {
            get { return _soTienConLai; }
            set { _soTienConLai = value; }
        }
        public string TenBoPhan
        {
            get
            {
                //_tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
                return _tenBoPhan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                   // _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public string TenQuocGia
        {
            get { return _tenQuocGia; }
        }



        public string Cmnd
        {
            get
            {
                return _cmnd;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public string Mst
        {
            get
            {
                return _mst;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_mst.Equals(value))
                {
                    _mst = value;
                    PropertyHasChanged("Mst");
                }
            }
        }

        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public string So
        {
            get
            {
                return _So;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_So.Equals(value))
                {
                    _So = value;
                    PropertyHasChanged("So");
                }
            }
        }
        public string NoiCap
        {
            get
            {
                return _noiCap;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_noiCap.Equals(value))
                {
                    _noiCap = value;
                    PropertyHasChanged("NoiCap");
                }
            }
        }

        public string DienThoai
        {
            get
            {
                return _dienThoai;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienThoai.Equals(value))
                {
                    _dienThoai = value;
                    PropertyHasChanged("DienThoai");
                }
            }
        }

        public bool SuDung
        {
            get
            {
                return _suDung;
            }
            set
            {
                if (!_suDung.Equals(value))
                {
                    _suDung = value;
                    PropertyHasChanged("SuDung");
                }
            }
        }

        public bool CaNhanCuTru
        {
            get
            {
                return _caNhanCuTru;
            }
            set
            {
                if (!_caNhanCuTru.Equals(value))
                {
                    _caNhanCuTru = value;
                    PropertyHasChanged("CaNhanCuTru");
                }
            }
        }

        public bool TinhTrangIn
        {
            get
            {
                return _tinhTrangIn;
            }
            set
            {
                if (!_tinhTrangIn.Equals(value))
                {
                    _tinhTrangIn = value;
                    PropertyHasChanged("TinhTrangIn");
                }
            }
        }
        public bool Chon
        {
            get
            {
                return _chon;
            }
            set
            {
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }


        public bool SuDungChinh
        {
            get
            {
                return _suDungChinh;
            }
            set
            {
                if (!_suDungChinh.Equals(value))
                {
                    _suDungChinh = value;
                    PropertyHasChanged("SuDungChinh");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;//BS
                    PropertyHasChanged("MaBoPhan");
                }
               
            }
           
        }
        public int STT
        {
            get
            {
                return _Stt;
            }
            set
            {
                if (!_Stt.Equals(value))
                {
                    _Stt = value;
                    PropertyHasChanged("STT");
                }

            }

        }
        public int MaQuocGia
        {
            get
            {
                return _maQuocGia;
            }
            set
            {
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    _tenQuocGia = QuocGia.GetQuocGia(_maQuocGia).TenQuocGia;
                    PropertyHasChanged("MaQuocGia");
                }

            }

        }
        public int MaUNC
        {
            get
            {
                return _maUNC;
            }
            set
            {
                if (!_maUNC.Equals(value))
                {
                    _maUNC = value;
                    PropertyHasChanged("MaUNC");
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

        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }
        public DateTime NgayTraThuNhap
        {
            get
            {
                return _ngayTraThuNhap;
            }
            set
            {
                if (!_ngayTraThuNhap.Equals(value))
                {
                    _ngayTraThuNhap = value;
                    PropertyHasChanged("NgayTraThuNhap");
                }
            }
        }


        public DateTime? NgayCap
        {
            //get
            //{
            //    return _ngayCap;
            //}
            //set
            //{
            //    if (!_ngayCap.Equals(value))
            //    {
            //        _ngayCap = value;
            //        PropertyHasChanged("NgayCap");
            //    }
            //}
            get
            {
                CanReadProperty(true);
                if (_ngayCap.Date == DateTime.MinValue)
                    return null;
                return _ngayCap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayCap.Equals(value))
                {
                    if (value == null)
                        _ngayCap = new SmartDate(DateTime.MinValue);
                    else
                        _ngayCap = new SmartDate(value.Value.Date);
                    
                    PropertyHasChanged();
                }
            }
        }
        public int MaNganHang
        {
            get
            {

                return _maNganHang;
            }
            set
            {
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }
        public string TenNganHang
        {
            get
            {
               // _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                return _tenNganHang;
            }
           
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public long MaNhanVienChuyenTien
        {
            get
            {

                return _maNhanVienChuyenTien;
            }
            set
            {
                if (!_maNhanVienChuyenTien.Equals(value))
                {
                    _maNhanVienChuyenTien = value;

                    PropertyHasChanged("MaNhanVienChuyenTien");
                }
            }
        }
        /// <summary>
        /// 1: CTV Thường xuyên;2: Không thường xuyên
        /// </summary>
        public int LoaiNhanVien
        {
            get { return _loaiNhanVien; }
            set { _loaiNhanVien = value; }
        }


        public long MaChungTu
        {
            get { return _MaChungTu; }
            set
            {
                _MaChungTu = value;
            }
        }
        
        
        protected override object GetIdValue()
        {
            return _maNhanVien;
        }
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty;
            }
        }
        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ////
            //// TenNhanVien
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenNhanVien");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 100));
            ////
            //// Cmnd
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            ////
            //// Mst
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Mst", 50));
            ////
            //// DiaChi
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 50));
            ////
            //// DienThoai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 50));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        public NhanVienNgoaiDai()
        { /* require use of factory method */ }

        public static NhanVienNgoaiDai NewNhanVienNgoaiDai()
        {
            NhanVienNgoaiDai nd = new NhanVienNgoaiDai();
            nd.MarkAsChild();
            return nd;
        }
        public static NhanVienNgoaiDai NewNhanVienNgoaiDai(string tenNhanVien)
        {
            NhanVienNgoaiDai item = new NhanVienNgoaiDai();
            item.TenNhanVien = tenNhanVien;
            item.MarkAsChild();
            return item;
        }
        public static NhanVienNgoaiDai GetNhanVienNgoaiDai(long maNhanVien)
        {
            return DataPortal.Fetch<NhanVienNgoaiDai>(new Criteria(maNhanVien));
        }
        public static NhanVienNgoaiDai GetNhanVienNgoaiDaiByCMND(string chungMinh)
        {
            return DataPortal.Fetch<NhanVienNgoaiDai>(new CriteriaByCMND(chungMinh));
        }
        public static NhanVienNgoaiDai GopNhapVienNgoaiDai(long maNhanVienChinh, long maNhanVienBo)
        {
            return DataPortal.Fetch<NhanVienNgoaiDai>(new CriteriaByGop(maNhanVienChinh, maNhanVienBo));
        }

        public static void DeleteNhanVienNgoaiDai(long maNhanVien)
        {
            DataPortal.Delete(new Criteria(maNhanVien));
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid;
            }
        }

       
        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NhanVienNgoaiDai NewNhanVienNgoaiDaiChild()
        {
            NhanVienNgoaiDai child = new NhanVienNgoaiDai();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NhanVienNgoaiDai GetNhanVienNgoaiDai(SafeDataReader dr)
        {
            NhanVienNgoaiDai child = new NhanVienNgoaiDai();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        internal static NhanVienNgoaiDai GetChungTuKhauTruThueNhanVienNgoaiDai(SafeDataReader dr)
        {
            NhanVienNgoaiDai child = new NhanVienNgoaiDai();
            child.MarkAsChild();
            child.FetchChungTuKhauTruThueNhanVienNgoaiDai(dr);
            return child;
        }

        internal static NhanVienNgoaiDai GetChungTuKhauTruThueNhanVienNgoaiDai_TienMat(SafeDataReader dr)
        {
            NhanVienNgoaiDai child = new NhanVienNgoaiDai();
            child.MarkAsChild();
            child.FetchChungTuKhauTruThueNhanVienNgoaiDai_TienMat(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaNhanVien;

            public Criteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }
        private class CriteriaByCMND
        {
            public string ChungMinh;

            public CriteriaByCMND(string chungMinh)
            {
                this.ChungMinh = chungMinh;
            }
        }
        [Serializable()]
        private class CriteriaByGop
        {
            public long MaNhanVienChinh;
            public long MaNhanVienBo;
            public CriteriaByGop(long maNhanVienChinh, long maNhanVienBo)
            {
                this.MaNhanVienChinh = maNhanVienChinh;
                this.MaNhanVienBo = maNhanVienBo;

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
                    cm.CommandText = "spd_Select_NhanVienNgoaiDai";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((Criteria)criteria).MaNhanVien);
                }

                if (criteria is CriteriaByCMND)
                {
                    cm.CommandText = "spd_Select_NhanVienNgoaiDaiByCMND";
                    cm.Parameters.AddWithValue("@CMND", ((CriteriaByCMND)criteria).ChungMinh);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                   // ValidationRules.CheckRules();

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
            DataPortal_Delete(new Criteria(_maNhanVien));
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
                cm.CommandText = "spd_Delete_NhanVienNgoaiDai";
                cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            this.MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchChungTuKhauTruThueNhanVienNgoaiDai(SafeDataReader dr)
        {
            FetchObjectChungTuKhauTruThueNhanVienNgoaiDai(dr);
            this.MarkOld();
            ValidationRules.CheckRules();
        }

        private void FetchChungTuKhauTruThueNhanVienNgoaiDai_TienMat(SafeDataReader dr)
        {
            FetchObjectChungTuKhauTruThueNhanVienNgoaiDai_TienMat(dr);
            this.MarkOld();
            ValidationRules.CheckRules();
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cmnd = dr.GetString("CMND");
            _mst = dr.GetString("MST");
            _diaChi = dr.GetString("DiaChi");
            _dienThoai = dr.GetString("DienThoai");
            _suDung = dr.GetBoolean("SuDung");
            _ghiChu = dr.GetString("GhiChu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maNganHang = dr.GetInt32("MaNganHang");
            _tenNganHang = dr.GetString("TenNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _loaiNhanVien = dr.GetInt32("LoaiNhanVien");
            _maNhanVienChuyenTien = dr.GetInt64("MaNVChuyenTien");
            //Mới thêm vô
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            _noiCap = dr.GetString("NoiCap");
            _caNhanCuTru = dr.GetBoolean("CaNhanCuTru");
            _MaChungTu = dr.GetInt64("MaChungTu");

            _tenQuocGia = dr.GetString("TenQuocGia");
        }

        private void FetchObjectChungTuKhauTruThueNhanVienNgoaiDai(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cmnd = dr.GetString("CMND");
            _mst = dr.GetString("MST");
            _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            //_ngayCap = dr.GetDateTime("NgayCap");
            _noiCap = dr.GetString("NoiCap");
            _caNhanCuTru = dr.GetBoolean("CaNhanCuTru");
            _soTien = dr.GetDecimal("SoTien");
            _soTienDaKhauTru = dr.GetDecimal("SoTienDaKhauTru");
            _soTienThuNhapChiuThue = dr.GetDecimal("SoTienThuNhapChiuThue");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _ngayTraThuNhap = dr.GetDateTime("NgayTraThuNhap");
            _tinhTrangIn = dr.GetBoolean("TinhTrangIn");
            _kyHieu = dr.GetString("KyHieu");
            _quyen = dr.GetString("Quyen");
            _So = dr.GetString("So");
            _Stt = dr.GetInt32("STT");
            _maBoPhan = dr.GetInt32("MaBoPhan");
             _maUNC = dr.GetInt32("MaUNC");
            _tenBoPhan = dr.GetString("TenBoPhan");
        }

        private void FetchObjectChungTuKhauTruThueNhanVienNgoaiDai_TienMat(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cmnd = dr.GetString("CMND");
            _mst = dr.GetString("MST");
            _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            //_ngayCap = dr.GetDateTime("NgayCap");
            _noiCap = dr.GetString("NoiCap");
            _caNhanCuTru = dr.GetBoolean("CaNhanCuTru");
            _soTien = dr.GetDecimal("SoTien");
            _soTienDaKhauTru = dr.GetDecimal("SoTienDaKhauTru");
            _soTienThuNhapChiuThue = dr.GetDecimal("SoTienThuNhapChiuThue");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _ngayTraThuNhap = dr.GetDateTime("NgayTraThuNhap");
            _tinhTrangIn = dr.GetBoolean("TinhTrangIn");
            _kyHieu = dr.GetString("KyHieu");
            _quyen = dr.GetString("Quyen");
            _So = dr.GetString("So");
            _Stt = dr.GetInt32("STT");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _MaChungTu = dr.GetInt64("MaChungTu");//
            _tenNganHang = dr.GetString("TenNganHang");
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
            //if (!KiemTraTrungSoCMND(_maNhanVien,_cmnd)) return;

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_NhanVienNgoaiDai";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNhanVien = (long)cm.Parameters["@MaNhanVien"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_mst.Length > 0)
                cm.Parameters.AddWithValue("@MST", _mst);
            else
                cm.Parameters.AddWithValue("@MST", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            _ngayLap = DateTime.Today;
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
          
         
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);

            if (_maNganHang!= 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_loaiNhanVien != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVien", _loaiNhanVien);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVien", DBNull.Value);
            cm.Parameters["@MaNhanVien"].Direction = ParameterDirection.Output;

            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNVChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNVChuyenTien", DBNull.Value);
            //Mới thêm vô
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
           // _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            //if (_ngayCap == DateTime.MinValue)
            //{
            //    cm.Parameters.AddWithValue("@NgayCap", DBNull.Value);
            //}
            //else
            //{
            //    cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            //}
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            cm.Parameters.AddWithValue("@CaNhanCuTru", _caNhanCuTru);
    
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            
                ExecuteUpdate(tr);
                MarkOld();
          

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
           // if (!KiemTraTrungSoCMND(_maNhanVien,_cmnd)) return;

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_NhanVienNgoaiDai";
              
                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_mst.Length > 0)
                cm.Parameters.AddWithValue("@MST", _mst);
            else
                cm.Parameters.AddWithValue("@MST", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            cm.Parameters.AddWithValue("@SuDung", _suDung);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            _ngayLap = DateTime.Today;
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);

            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_soTaiKhoan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", _soTaiKhoan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_loaiNhanVien != 0)
                cm.Parameters.AddWithValue("@LoaiNhanVien", _loaiNhanVien);
            else
                cm.Parameters.AddWithValue("@LoaiNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNVChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNVChuyenTien", DBNull.Value);
            //Mới thêm vô
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
           // _ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
            //if (_ngayCap == DateTime.MinValue)
            //{
            //    cm.Parameters.AddWithValue("@NgayCap", DBNull.Value);
            //}
            //else
            //{
            //    cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
            //}
            if (_noiCap.Length > 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            cm.Parameters.AddWithValue("@CaNhanCuTru", _caNhanCuTru); 
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
            
            ExecuteDelete(tr, new Criteria(_maNhanVien));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
        /// <summary>
        /// True: Trùng; False: Không Trùng
        /// </summary>
        /// <param name="maNhanVien"></param>
        /// <param name="CMND"></param>
        /// <returns></returns>
        public static bool KiemTraTrungSoCMND(long maNhanVien,string CMND)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            cm.CommandText = "spd_KiemTraTrungSoCMND";
            cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
            cm.Parameters.AddWithValue("@CMND", CMND);
            bool kq = false;
            try
            {
                kq = Convert.ToBoolean(cm.ExecuteScalar());
            }
            catch
            {
            }
            cn.Close();
            if (!kq) throw new Exception("Trùng số chứng minh nhân dân!");
            return kq;
        }

        public static bool KiemTraCMND(string soChungMinh)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraCMNDTrongNhanVienNgoaiDai";
                        if (soChungMinh.Length > 0)
                            cm.Parameters.AddWithValue("@SoChungMinh", soChungMinh);
                        else
                            cm.Parameters.AddWithValue("@SoChungMinh", DBNull.Value);

                        cm.Parameters.AddWithValue("@KetQua", kq);
                        cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return kq;
            }//using
        }

        public static bool GopNhanVienNgoaiDai(long MaNhanVienChinh, string MaNhanVienBo)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_UpdatetblnsNhanVienNgoaiDai_DungChinh";
                        cm.Parameters.AddWithValue("@MaNhanVienChinh", MaNhanVienChinh);
                        cm.Parameters.AddWithValue("@MaNhanVienBo", MaNhanVienBo);
                        cm.ExecuteNonQuery();

                    }//using
                    tr.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                    return false;
                  
                }
            }

        }
        
    }
}

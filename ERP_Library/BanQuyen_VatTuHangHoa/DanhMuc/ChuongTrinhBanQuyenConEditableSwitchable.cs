
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//24/04/2013
namespace ERP_Library
{
    [Serializable()]
    public class ChuongTrinhBanQuyenCon : Csla.BusinessBase<ChuongTrinhBanQuyenCon>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChuongTrinhCon = 0;
        private string _maQLChuongTrinhCon = string.Empty;
        private decimal _thoiLuong = 0;
        private bool _tinhTrang = true;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _dienGiai = string.Empty;
        private int _maHangHoa = 0;
        private int _maQuocGia = 0;
        private string _tenChuongTrinh = string.Empty;//M
        private bool _checkChon=false;
        private decimal _soLuongTon = 0;
        private long _maHopDong = 0;//M
        private int _maNguon = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChuongTrinhCon
        {
            get
            {
                CanReadProperty("MaChuongTrinhCon", true);
                return _maChuongTrinhCon;
            }
        }

        public string MaQLChuongTrinhCon
        {
            get
            {
                CanReadProperty("MaQLChuongTrinhCon", true);
                return _maQLChuongTrinhCon;
            }
            set
            {
                CanWriteProperty("MaQLChuongTrinhCon", true);
                if (value == null) value = string.Empty;
                if (!_maQLChuongTrinhCon.Equals(value))
                {
                    _maQLChuongTrinhCon = value;
                    PropertyHasChanged("MaQLChuongTrinhCon");
                }
            }
        }

        public decimal ThoiLuong
        {
            get
            {
                CanReadProperty("ThoiLuong", true);
                return _thoiLuong;
            }
            set
            {
                CanWriteProperty("ThoiLuong", true);
                if (!_thoiLuong.Equals(value))
                {
                    _thoiLuong = value;
                    PropertyHasChanged("ThoiLuong");
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

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                if (_maHangHoa != 0)
                    _tenChuongTrinh = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa+" "+_dienGiai;
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
                _tenChuongTrinh = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa + " " + _dienGiai;
            }
        }

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public String TenChuongTrinh
        {
            get
            {

                return _tenChuongTrinh;
            }
        }
        public bool CheckChon
        {
            get { return _checkChon; }
            set { _checkChon = value; }
        }
        public decimal SoLuongTon
        {
            get { return _soLuongTon; }
        }
        public long MaHopDong
        {
            get { return _maHopDong; }
        }
        public int MaNguon
        {
            get { return _maNguon; }
        }
        protected override object GetIdValue()
        {
            return _maChuongTrinhCon;
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
            // MaQLChuongTrinhCon
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLChuongTrinhCon", 100));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
            //TODO: Define authorization rules in ChuongTrinhBanQuyenCon
            //AuthorizationRules.AllowRead("MaChuongTrinhCon", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("MaQLChuongTrinhCon", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("ThoiLuong", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "ChuongTrinhBanQuyenConReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "ChuongTrinhBanQuyenConReadGroup");

            //AuthorizationRules.AllowWrite("MaQLChuongTrinhCon", "ChuongTrinhBanQuyenConWriteGroup");
            //AuthorizationRules.AllowWrite("ThoiLuong", "ChuongTrinhBanQuyenConWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "ChuongTrinhBanQuyenConWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ChuongTrinhBanQuyenConWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "ChuongTrinhBanQuyenConWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "ChuongTrinhBanQuyenConWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuongTrinhBanQuyenCon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuongTrinhBanQuyenCon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuongTrinhBanQuyenCon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuongTrinhBanQuyenCon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuongTrinhBanQuyenCon()
        { /* require use of factory method */ }

        public static ChuongTrinhBanQuyenCon NewChuongTrinhBanQuyenCon()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinhBanQuyenCon");
            return DataPortal.Create<ChuongTrinhBanQuyenCon>();
        }

        public static ChuongTrinhBanQuyenCon GetChuongTrinhBanQuyenCon(string maQLChuongTrinhCon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhBanQuyenCon");
            return DataPortal.Fetch<ChuongTrinhBanQuyenCon>(new Criteria_MaQLChuongTrinhCon(maQLChuongTrinhCon));
        }

        public static ChuongTrinhBanQuyenCon GetChuongTrinhBanQuyenCon(int maChuongTrinhCon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhBanQuyenCon");
            return DataPortal.Fetch<ChuongTrinhBanQuyenCon>(new Criteria(maChuongTrinhCon));
        }

        public static void DeleteChuongTrinhBanQuyenCon(int maChuongTrinhCon)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinhBanQuyenCon");
            DataPortal.Delete(new Criteria(maChuongTrinhCon));
        }

        public override ChuongTrinhBanQuyenCon Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinhBanQuyenCon");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinhBanQuyenCon");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChuongTrinhBanQuyenCon");

            return base.Save();
        }
        //
        public static bool CheckMaQuanLyChuongTrinhKhongTrung(int _maChuongTrinhCon, string _maQuanLy, bool _laMoi)
        {
            bool Kt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraMaQuanLyChuongTrinhKhongTrung";
                    cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
                    cm.Parameters.AddWithValue("@LaMoi", _laMoi);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    Kt = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return Kt;

        }
        public static string SetMaQuanLyChuongTrinhCon(int maHangHoa, string maQLHangHoa)
        {
            string _maQLChuongTrinhCon = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetMaQuanLyChuongTrinhCon";
                    cm.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@MaQLHangHoa", maQLHangHoa);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _maQLChuongTrinhCon = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _maQLChuongTrinhCon;

        }
        #region Nhap Xuat Thang
        public static decimal GetSoLuongChuongTrinhBanQuyen_NXT(long maPhieuXuat, int maBoPhan,int maKho,int phuongPhapNX, long maPhieuNhap, int maChuongTrinhCon, long maHopDong,int maNguon, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongChuongTrinhBanQuyen_NXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@phuongPhapNX", phuongPhapNX);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maChuongTrinhCon", maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@maNguon", maNguon);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        public static decimal GetGiaTriChuongTrinhBanQuyen_NXT(long maPhieuXuat, int maBoPhan,int maKho, int phuongPhapNX, long maPhieuNhap, int maChuongTrinhCon, long maHopDong,int maNguon, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriChuongTrinhBanQuyen_NXT";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@phuongPhapNX", phuongPhapNX);
                    cm.Parameters.AddWithValue("@maPhieuNhap", maPhieuNhap);
                    cm.Parameters.AddWithValue("@maChuongTrinhCon", maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@maNguon", maNguon);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        #endregion //Nhap Xuat Thang
        #region Binh Quan
        #region Lay So Luong cua Chuong Trinh Ban Quyen
        public static decimal GetSoLuongChuongTrinhBanQuyen(long maPhieuXuat, int maBoPhan, int maKho, int maChuongTrinhCon, long maHopDong,int maNguon, DateTime ngay)//M
        {
            decimal kqSoLuong = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetSoLuongChuongTrinhBanQuyen";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maChuongTrinhCon", maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@maNguon", maNguon);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmSoLuongTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmSoLuongTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmSoLuongTraVe);
                    cm.ExecuteNonQuery();
                    kqSoLuong = (decimal)prmSoLuongTraVe.Value;
                }
            }//us

            return kqSoLuong;

        }
        #endregion//Lay gia So Luong cua Chuong Trinh BQ
        #region Lay gia tri cua Chuong Trinh Ban Quyen
        public static decimal GetGiaTriChuongTrinhBanQuyen(long maPhieuXuat, int maBoPhan, int maKho, int maChuongTrinhCon, long maHopDong,int maNguon, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriChuongTrinhBanQuyen ";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maChuongTrinhCon", maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@maNguon", maNguon);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia tri cua Chuong Trinh Ban Quyen
        #region Lay gia Binh Quan cua Chuong Trinh Ban Quyen
        public static decimal GetGiaBinhQuanChuongTrinhBanQuyen(long maPhieuXuat, int maBoPhan, int maKho, int maChuongTrinhCon, long maHopDong,int maNguon, DateTime ngay)
        {
            decimal kqGiaBinhQuan = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetGiaTriBinhQuanChuongTrinhBanQuyen";
                    cm.Parameters.AddWithValue("@maPhieuXuat", maPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@maKho", maKho);
                    cm.Parameters.AddWithValue("@maChuongTrinhCon", maChuongTrinhCon);
                    cm.Parameters.AddWithValue("@maHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@maNguon", maNguon);
                    cm.Parameters.AddWithValue("@ngay", ngay);
                    SqlParameter prmGiaTriBQTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Decimal, 16);
                    prmGiaTriBQTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriBQTraVe);
                    cm.ExecuteNonQuery();
                    kqGiaBinhQuan = (decimal)prmGiaTriBQTraVe.Value;
                }
            }//us

            return kqGiaBinhQuan;

        }
        #endregion//Lay gia Binh Quan cua Chuong Trinh BQ
        #endregion //Binh Quan

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChuongTrinhBanQuyenCon NewChuongTrinhBanQuyenConChild()
        {
            ChuongTrinhBanQuyenCon child = new ChuongTrinhBanQuyenCon();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChuongTrinhBanQuyenCon GetChuongTrinhBanQuyenCon(SafeDataReader dr)
        {
            ChuongTrinhBanQuyenCon child = new ChuongTrinhBanQuyenCon();
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
            public int MaChuongTrinhCon;

            public Criteria(int maChuongTrinhCon)
            {
                this.MaChuongTrinhCon = maChuongTrinhCon;
            }
        }

        [Serializable()]
        private class Criteria_MaQLChuongTrinhCon
        {
            public string MaQLChuongTrinhCon;

            public Criteria_MaQLChuongTrinhCon(string maQLChuongTrinhCon)
            {
                this.MaQLChuongTrinhCon = maQLChuongTrinhCon;
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenCon";
                    cm.Parameters.AddWithValue("@MaChuongTrinhCon", ((Criteria)criteria).MaChuongTrinhCon);
                }
                if (criteria is Criteria_MaQLChuongTrinhCon)
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenCon_MaQLChuongTrinhCon";
                    cm.Parameters.AddWithValue("@MaQLChuongTrinhCon", ((Criteria_MaQLChuongTrinhCon)criteria).MaQLChuongTrinhCon);
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
            DataPortal_Delete(new Criteria(_maChuongTrinhCon));
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
                cm.CommandText = "spd_DeletetblChuongTrinhBanQuyenCon";

                cm.Parameters.AddWithValue("@MaChuongTrinhCon", criteria.MaChuongTrinhCon);

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
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");
            _maQLChuongTrinhCon = dr.GetString("MaQLChuongTrinhCon");
            _thoiLuong = dr.GetDecimal("ThoiLuong");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _dienGiai = dr.GetString("DienGiai");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _soLuongTon = dr.GetDecimal("SoLuongTon");
            _maHopDong = dr.GetInt64("MaHopDong");
            _maNguon = dr.GetInt32("MaNguon");
            _tenChuongTrinh = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa + " " + _dienGiai;//M
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChuongTrinhBanQuyenConList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChuongTrinhBanQuyenConList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChuongTrinhBanQuyenCon";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChuongTrinhCon = (int)cm.Parameters["@MaChuongTrinhCon"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChuongTrinhBanQuyenConList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maQLChuongTrinhCon.Length > 0)
                cm.Parameters.AddWithValue("@MaQLChuongTrinhCon", _maQLChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaQLChuongTrinhCon", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_tinhTrang != false)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            cm.Parameters["@MaChuongTrinhCon"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChuongTrinhBanQuyenConList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChuongTrinhBanQuyenConList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChuongTrinhBanQuyenCon";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChuongTrinhBanQuyenConList parent)
        {
            cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            if (_maQLChuongTrinhCon.Length > 0)
                cm.Parameters.AddWithValue("@MaQLChuongTrinhCon", _maQLChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaQLChuongTrinhCon", DBNull.Value);
            if (_thoiLuong != 0)
                cm.Parameters.AddWithValue("@ThoiLuong", _thoiLuong);
            else
                cm.Parameters.AddWithValue("@ThoiLuong", DBNull.Value);
            if (_tinhTrang != false)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maQuocGia != 0)
                cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            else
                cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maChuongTrinhCon));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

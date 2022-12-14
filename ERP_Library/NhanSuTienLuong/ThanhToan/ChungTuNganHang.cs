
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//fix
namespace ERP_Library
{
    [Serializable()]
    public class ChungTuNganHang : Csla.BusinessBase<ChungTuNganHang>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maChungTu = 0;
        private string _so = string.Empty;
        private DateTime _ngay = DateTime.Today;
        private string _dienGiai = string.Empty;
        private string _ghiChu = string.Empty;
        private int _soDeNghi = 0;
        private decimal _soTien = 0;
        private DateTime _ngayLap = DateTime.Today;
        private int _userID = Security.CurrentUser.Info.UserID;
        private int _maNganHang = 0;
        private int _loaiChungTu = 0;

        //declare child member(s)
        private ChungTuNganHang_DeNghiList _deNghi = ChungTuNganHang_DeNghiList.NewChungTuNganHang_DeNghiList();
        
        // tran
        private decimal _soTienConLai = 0;

        
        private bool _hoanTat = false;
        private decimal _soTienThanhToan = 0;
        private decimal _tongTien = 0;
        private Boolean _check = false;
        private long _maCTDNCK = 0;
        private string _tenNganHang = string.Empty;
        private string _tenBoPhan = string.Empty;

        //Thành Thêm (14/04/2012) : Ngày Chuyển Của Ngân Hàng
        private DateTime? _ngayXacNhan = null;
        private int _soChungTu = 0;
        private ChiTietChungTuNganHangList _chiTietChungTuList = ChiTietChungTuNganHangList.NewChiTietChungTuNganHangList();
        private string _tenDoiTac = string.Empty;

        private DieuChuyenTaiKhoan_NoiBo _dieuChuyen = DieuChuyenTaiKhoan_NoiBo.NewDieuChuyenTaiKhoan_NoiBo(0);
       
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public string So
        {
            get
            {
                return _so;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_so.Equals(value))
                {
                    _so = value;
                    PropertyHasChanged("So");
                }
            }
        }

        public DateTime Ngay
        {
            get
            {
                return _ngay;
            }
            set
            {
                if (!_ngay.Equals(value))
                {
                    _ngay = value;
                    PropertyHasChanged("Ngay");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
            set
            {
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

        public int SoDeNghi
        {
            get
            {
                return _soDeNghi;
            }
            set
            {
                if (!_soDeNghi.Equals(value))
                {
                    _soDeNghi = value;
                    PropertyHasChanged("SoDeNghi");
                }
            }
        }

        public int SoChungTu //Đề nghị chuyển khoản
        {
            get
            {
                return _soChungTu;
            }
            set
            {
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public decimal SoTien
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

        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                if (!_userID.Equals(value))
                {
                    _userID = value;
                    PropertyHasChanged("UserID");
                }
            }
        }

        public int LoaiChungTu
        {
            get
            {
                return _loaiChungTu;
            }
            set
            {
                if (!_loaiChungTu.Equals(value))
                {
                    _loaiChungTu = value;
                    PropertyHasChanged("LoaiChungTu");
                }
            }
        }

        public ChungTuNganHang_DeNghiList DeNghi
        {
            get
            {
                return _deNghi;
            }
        }

        //Cái này chế nè
        public int TaiKhoanNhan
        {
            get
            {
                CanReadProperty("TaiKhoanNhan", true);
                return _dieuChuyen.TaiKhoanNhan;
            }
            set
            {
                CanWriteProperty("TaiKhoanNhan", true);
                if (!_dieuChuyen.TaiKhoanNhan.Equals(value))
                {
                    _dieuChuyen.TaiKhoanNhan = value;
                    PropertyHasChanged("NoTaiKhoan");
                }
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && ChiTietChungTuList.IsValid && _dieuChuyen.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || ChiTietChungTuList.IsDirty || _dieuChuyen.IsDirty; }
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
                    PropertyHasChanged();
                }
            }
        }
        public decimal SoTienConLai
        {
            get { return _soTienConLai; }
            
            set
            {
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }
        public bool HoanTat
        {
            get { return _hoanTat; }
            //set
            //{
            //    if (!_hoanTat.Equals(value))
            //    {
            //        _hoanTat = value;
            //        PropertyHasChanged();
            //    }
            //}
        }
        protected override object GetIdValue()
        {
            return _maChungTu;
        }
        public decimal SoTienThanhToan
        {
            get { return _soTienThanhToan; }
            set { _soTienThanhToan = value; }
        }
        public decimal TongTien
        {
            get { return _tongTien; }
            set { _tongTien = value; }
        }
        public Boolean Check
        {
            get { return _check; }
            set
            {
                _check = value;
            }
        }
    

        public long MaCTDNCK
        {
            get { return _maCTDNCK; }
            set { _maCTDNCK = value; }
        }
        public string TenNganHang
        {
            get {
               
                return _tenNganHang; }
            set { _tenNganHang = value; }
        }
        public string TenBoPhan
        {
            get {
                return _tenBoPhan; }
            set { _tenBoPhan = value; }
        }
        public string TenDoiTac
        {
            get
            {
                return _tenDoiTac;
            }
        }

        public DateTime? NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
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

        public ChiTietChungTuNganHangList ChiTietChungTuList
        {
            get
            {
                CanReadProperty("ChiTietChungTuList", true);
                return _chiTietChungTuList;
            }
            set
            {
                CanWriteProperty("ChiTietChungTuList", true);
                if (!_chiTietChungTuList.Equals(value))
                {
                    _chiTietChungTuList = value;
                    PropertyHasChanged("ChiTietChungTuList");
                }
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
            //
            // So
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "So");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 20));
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "DienGiai");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 100));

            //ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNganHang", "Ngân hàng không được để trống"));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        public ChungTuNganHang()
        { /* require use of factory method */ }

        public static ChungTuNganHang NewChungTuNganHang()
        {
            return DataPortal.Create<ChungTuNganHang>();
        }
        public static ChungTuNganHang NewChungTuNganHang(string TenChungTu)
        {
            ChungTuNganHang item = new ChungTuNganHang();
            item.So = TenChungTu;
            return item;
        }

        public static ChungTuNganHang GetChungTuNganHang(int maChungTu)
        {
            return DataPortal.Fetch<ChungTuNganHang>(new Criteria(maChungTu));
        }

        public static void DeleteChungTuNganHang(int maChungTu)
        {
            DataPortal.Delete(new Criteria(maChungTu));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTuNganHang NewChungTuNganHangChild()
        {
            ChungTuNganHang child = new ChungTuNganHang();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTuNganHang GetChungTuNganHang(SafeDataReader dr)
        {
            ChungTuNganHang child = new ChungTuNganHang();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static ChungTuNganHang GetChungTuNganHang_ByDoiTac(SafeDataReader dr)
        {
            ChungTuNganHang child = new ChungTuNganHang();
            child.MarkAsChild();
            child.Fetch_New(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaChungTu;

            public Criteria(int maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                cm.CommandText = "spd_Select_ChungTuNganHang";

                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
            DataPortal_Delete(new Criteria(_maChungTu));
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
                cm.CommandText = "spd_Delete_ChungTuNganHang";

                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt32("MaChungTu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _dienGiai = dr.GetString("DienGiai");
            _ghiChu = dr.GetString("GhiChu");
            _soDeNghi = dr.GetInt32("SoDeNghi");
            _soTien = dr.GetDecimal("SoTien");
            _ngayLap = dr.GetDateTime("NgayLap");
            _userID = dr.GetInt32("UserID");
            _maNganHang = dr.GetInt32("MaNganHang");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _hoanTat = dr.GetBoolean("HoanTat");
            _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
            _tenBoPhan = BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan;
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            if (_ngayXacNhan == DateTime.MinValue)
                _ngayXacNhan = null;
            _soChungTu = dr.GetInt32("SoChungTu");
        }

        private void FetchObject_New(SafeDataReader dr)
        {
            _maChungTu = dr.GetInt32("MaChungTu");
            _so = dr.GetString("So");
            _ngay = dr.GetDateTime("Ngay");
            _dienGiai = dr.GetString("DienGiai");
            _ghiChu = dr.GetString("GhiChu");
            _soDeNghi = dr.GetInt32("SoDeNghi");
            _soTien = dr.GetDecimal("SoTien");
            _ngayLap = dr.GetDateTime("NgayLap");
            _userID = dr.GetInt32("UserID");
            _maNganHang = dr.GetInt32("MaNganHang");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _hoanTat = dr.GetBoolean("HoanTat");
            _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
            _tenBoPhan = BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan;
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
            if (_ngayXacNhan == DateTime.MinValue)
                _ngayXacNhan = null;
            _soChungTu = dr.GetInt32("SoChungTu");
            _tenDoiTac = dr.GetString("TenDoiTac");
            
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _deNghi = ChungTuNganHang_DeNghiList.GetChungTuNganHang_DeNghiList(_maChungTu);
            _chiTietChungTuList = ChiTietChungTuNganHangList.GetChiTietChungTuNganHangList(_maChungTu);
            _dieuChuyen = DieuChuyenTaiKhoan_NoiBo.GetDieuChuyenTaiKhoan_NoiBo(_maChungTu);
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ChungTuNganHang";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maChungTu = (int)cm.Parameters["@MaChungTu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Now);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            //cập nhật lại user cập nhật lần cuối
            _userID = Security.CurrentUser.Info.UserID;
            _ngayLap = DateTime.Today;

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_ChungTuNganHang";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Now);
            cm.Parameters.AddWithValue("@UserID", _userID);
            cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _deNghi.Update(tr, this);
            _chiTietChungTuList.Update(tr, this);

            //Kiểm tra điều chuyển
            if (_dieuChuyen.IsNew & _dieuChuyen.TaiKhoanNhan != 0)
            {
                _dieuChuyen.Insert(tr, this);
            }
            else if (_dieuChuyen.IsDeleted)
            {
                _dieuChuyen.DeleteSelf(tr, this);
            }
            else if (_dieuChuyen.IsDirty)
            {
                _dieuChuyen.Update(tr, this);
            }    
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            
            if (!IsDirty) return;
            if (IsNew) return;
            _chiTietChungTuList.DataPortal_Delete(tr);
            //if (_dieuChuyen)
            if (_dieuChuyen.TaiKhoanNhan != 0)
                _dieuChuyen.DeleteSelf(tr, this);
            ExecuteDelete(tr, new Criteria(_maChungTu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        /// <summary>
        /// Kiểm tra chứng từ điều chuyển nội bộ đã được lập bảng kê hay chưa
        /// </summary>
        /// <param name="maChungTu"></param>
        /// <returns></returns>
        public static bool KiemTraChungTu(int maChungTu)
        {
            bool bFound = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraChungTuDieuChuyen";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);

                    int iSoChungTu = Convert.ToInt32(cm.ExecuteScalar());
                    if (iSoChungTu > 0)
                        bFound = true;
                }
                cn.Close();
            }
            return bFound;
        }

        public string GetMaUNC()
        {
            string strMaUNC = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaUNCNganHang";
                    cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);

                    strMaUNC = Convert.ToString(cm.ExecuteScalar());
                }

                cn.Close();
            }
            return strMaUNC;
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
                    cm.CommandText = "spd_LaySoChungTuMax";
                    cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
                    cm.Parameters.AddWithValue("@Nam", _ngay.Year);

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

        public static void XyLyTinhThueTNCN(string strChuoiDeNghi, DateTime dtNgayTinh, int iLoaiChungTu, string strDienGiai, string strSoChungTu, long lMaChungTu, int PhanTramTinhThue)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_XuLyTinhThueTNCNLuyTien";
                    cm.CommandTimeout = 600;
                    cm.Parameters.AddWithValue("@DeNghiChuyenKhoan", strChuoiDeNghi);
                    cm.Parameters.AddWithValue("@NgayTinh", dtNgayTinh);
                    cm.Parameters.AddWithValue("@LoaiChungTu", iLoaiChungTu);
                    cm.Parameters.AddWithValue("@DienGiai", strDienGiai);
                    cm.Parameters.AddWithValue("@SoChungTu", strSoChungTu);
                    cm.Parameters.AddWithValue("@MaChungTu", lMaChungTu);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@PhanTramTinhThue", PhanTramTinhThue);
                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        public static void XyLyTinhThueTNCNCTV(string strChuoiDeNghi, DateTime dtNgayTinh, int iLoaiChungTu, string strDienGiai, string strSoChungTu, long lMaChungTu)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_XuLyTinhThueTNCNLuyTienCVT";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@DeNghiChuyenKhoan", strChuoiDeNghi);
                    cm.Parameters.AddWithValue("@NgayTinh", dtNgayTinh);
                    cm.Parameters.AddWithValue("@LoaiChungTu", iLoaiChungTu);
                    cm.Parameters.AddWithValue("@DienGiai", strDienGiai);
                    cm.Parameters.AddWithValue("@SoChungTu", strSoChungTu);
                    cm.Parameters.AddWithValue("@MaChungTu", lMaChungTu);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);

                    cm.ExecuteNonQuery();
                }
                cn.Close();
            }
        }

        public static bool KiemTraXoaTinhThue(string strSoChungTu, ref string ChungTuTon, Int64 MaChungTu)
        {
            bool bFound = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraXoaThueTNCNLuyTien";
                    cm.CommandTimeout = 90;
                    cm.Parameters.AddWithValue("@SoChungTu", strSoChungTu);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
                    ChungTuTon = Convert.ToString(cm.ExecuteScalar());
                    if (ChungTuTon != string.Empty)
                        bFound = true;
                }
                cn.Close();
            }
            return bFound;
        }
        SqlTransaction tr;  
        public static void KiemTraXoaTinhThue(long maChungTu)
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
                        cm.CommandText = "spd_XoaThueTNCNLuyTien";
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                        cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.ExecuteNonQuery();
                        tr.Commit();
                    }
                    cn.Close();                   
                }

                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        public static void XoaThueCTV(long maChungTu)
        {
            //SqlTransaction tr;
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{
            //    cn.Open();
            //    tr = cn.BeginTransaction();
            //    try
            //    {
            //        using (SqlCommand cm = cn.CreateCommand())
            //        {
            //            cn.BeginTransaction();

            //            cm.CommandType = CommandType.StoredProcedure;
            //            cm.CommandText = "spd_XoaThueCTV";
            //            cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
            //            cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
            //            cm.ExecuteNonQuery();

            //        }
            //        cn.Close();
            //        tr.Commit();
            //    }
            //    catch (SqlException ex)
            //    {
            //        tr.Rollback();
            //        throw ex;
            //    }
            //}

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
                        cm.CommandText = "spd_XoaThueCTV";
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                        cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                        cm.ExecuteNonQuery();
                        tr.Commit();
                    }
                    cn.Close();
                }

                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }


    }
}



using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{//
    [Serializable()]
    public class ChiTietDeCuNhanVien : Csla.BusinessBase<ChiTietDeCuNhanVien>
    {

        #region Business Properties and Methods
        //declare members
        private bool _Chon = false;
        private int _maChiTiet = 0;
        private int _maDeCu = 0;
        private long _maNhanVien = 0;
        private string _ghiChu = string.Empty;
        #region BoSung

        //--"TenNhanVien", "MaQLNhanVien", "BoPhanNhanVien"
        //--, "TinhTrangDaoTao"//K lay
        //--, "TenvanbangChungchi", "LoaiVanBangString", "VanbangChungChiString"
        //--, "NgayBatDau", "NgayKetThuc"
        //--, "SoNgayHoc"//K lay
        //--, "QuocGiaCap", "TenDonViDaoTao"
        //--, "TenTruongDaoTao", "TenChuyenNganhDaoTao", "TrongnuocNgoainuocString", "GhiChuLopHoc"
        private DeCu _deCu;
        private LopHoc _lopHoc;
        private string _tenNhanVien = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _boPhanNhanVien = string.Empty;
        private string _tenvanbangChungchi = string.Empty;
        private string _loaiVanBangString = string.Empty;
        private string _vanbangChungChiString = string.Empty;
        private SmartDate _ngayBatDau = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.MinValue);
        private string _quocGiaCap = string.Empty;
        private string _tenDonViDaoTao = string.Empty;
        private string _tenTruongDaoTao = string.Empty;
        private string _tenChuyenNganhDaoTao = string.Empty;
        private string _trongnuocNgoainuocString = string.Empty;
        private string _ghiChuLopHoc = string.Empty;

        private string _tenLoaiLop = string.Empty;
        #endregion//End BoSung
        [System.ComponentModel.DataObjectField(true, false)]


        public bool Chon
        {
            get { return _Chon; }
            set
            {
                _Chon = value;
            }
        }


        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaDeCu
        {
            get
            {
                CanReadProperty("MaDeCu", true);
                //if (_maDeCu != 0)
                //{
                //    _deCu = DeCu.GetDeCuWithoutChild(_maDeCu);
                //    if (_deCu != null && _deCu.MaHopHoc != 0)
                //    {
                //        _lopHoc = LopHoc.GetLopHoc(_deCu.MaHopHoc);
                //    }
                //}
                return _maDeCu;
            }
            set
            {
                CanWriteProperty("MaDeCu", true);
                if (!_maDeCu.Equals(value))
                {
                    _maDeCu = value;
                    //if (_maDeCu != 0)
                    //{
                    //    _deCu = DeCu.GetDeCu(_maDeCu);
                    //    if (_deCu != null && _deCu.MaHopHoc != 0)
                    //    {
                    //        _lopHoc = LopHoc.GetLopHoc(_deCu.MaHopHoc);
                    //    }
                    //}
                    PropertyHasChanged("MaDeCu");
                }
            }
        }

        #region Bo Sung De Cu
        public DeCu DeCu
        {
            get
            {
                return _deCu;
            }
        }

        public LopHoc LopHoc
        {
            get
            {
                return _lopHoc;
            }
        }

        public DateTime? NgayBatDau
        {
            get
            {
                return _ngayBatDau.Date;//_lopHoc.NgayBatDau;
            }
        }

        public DateTime? NgayKetThuc
        {
            get
            {
                return _ngayKetThuc.Date;//_lopHoc.NgayKetThuc;
            }
        }

        public string VanbangChungChiString
        {
            get
            {
                return _vanbangChungChiString;//_lopHoc.VanbangChungChiString;
            }
        }

        public string TenvanbangChungchi
        {
            get
            {
                return _tenvanbangChungchi;//_lopHoc.TenvanbangChungchi;
            }
        }

        public string LoaiVanBangString
        {
            get
            {
                return _loaiVanBangString;//_lopHoc.LoaiVanBangString;
            }
        }


        public string QuocGiaCap
        {
            get
            {
                return _quocGiaCap;//_lopHoc.QuocGiaCap;
            }
        }

        public string TenTruongDaoTao
        {
            get
            {
                return _tenTruongDaoTao;//_lopHoc.TenTruongDaoTao;
            }
        }

        public string TenDonViDaoTao
        {
            get
            {
                return _tenDonViDaoTao;//_lopHoc.TenDonViDaoTao;
            }
        }

        public string GhiChuLopHoc
        {
            get
            {
                return _ghiChuLopHoc;//_lopHoc.GhiChu;
            }
        }

        public string TenChuyenNganhDaoTao
        {
            get
            {
                return _tenTruongDaoTao;//_lopHoc.TenTruongDaoTao;
            }
        }

        public string TrongnuocNgoainuocString
        {
            get
            {
                return _trongnuocNgoainuocString;//_lopHoc.TrongnuocNgoainuocString;
            }
        }

        public string TenLoaiLop
        {
            get
            {
                return _tenLoaiLop;//_lopHoc.TenLoaiLop;
            }
        }

        public decimal SoGioHoc
        {
            get
            {
                return DeCu.GetDeCuWithLichHoc(_maDeCu).SoGioHoc;
            }
        }

        public decimal SoNgayHoc
        {
            get
            {
                return DeCu.GetDeCuWithLichHoc(_maDeCu).SoNgayHoc;
            }
        }
        #endregion

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                //if (_maNhanVien != 0)
                //{
                //    _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                //    _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                //    _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
                //}
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    //if (_maNhanVien != 0)
                    //{
                    //    _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                    //    _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                    //    _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
                    //}
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }
        #region Bo Sung Nhan Vien
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
        }
        public string BoPhanNhanVien
        {
            get
            {
                return _boPhanNhanVien;
            }
        }
        #endregion

        #region Bo Sung De Cu
        public string TinhTrangDaoTao
        {
            get
            {
                if (_maChiTiet != 0)
                {
                    return TinhTrangNhanVien(_maChiTiet);
                }
                return "";
            }
        }
        #endregion

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

        //public bool DuocDiHoc
        //{
        //    get
        //    {
        //        CanReadProperty("DuocDiHoc", true);
        //        return _duocDiHoc;
        //    }
        //    set
        //    {
        //        CanWriteProperty("DuocDiHoc", true);
        //        if (!_duocDiHoc.Equals(value))
        //        {
        //            _duocDiHoc = value;
        //            PropertyHasChanged("DuocDiHoc");
        //        }
        //    }
        //}


        protected override object GetIdValue()
        {
            return _maChiTiet;
        }
        #endregion//Business Properties and Methods

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
            //TODO: Define authorization rules in ChiTietDeCuNhanVien
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietDeCuNhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaDeCu", "ChiTietDeCuNhanVienReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ChiTietDeCuNhanVienReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietDeCuNhanVienReadGroup");

            //AuthorizationRules.AllowWrite("MaDeCu", "ChiTietDeCuNhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "ChiTietDeCuNhanVienWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietDeCuNhanVienWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods

        public static ChiTietDeCuNhanVien NewChiTietDeCuNhanVien(long maNhanVien)
        {
            return new ChiTietDeCuNhanVien(maNhanVien);
        }
        internal static ChiTietDeCuNhanVien GetChiTietDeCuNhanVien(SafeDataReader dr)
        {
            return new ChiTietDeCuNhanVien(dr);
        }

        internal static ChiTietDeCuNhanVien GetChiTietDeCuNhanVienSearch(SafeDataReader dr)//R
        {
            return new ChiTietDeCuNhanVien(dr, true);
        }

        private ChiTietDeCuNhanVien(long maNhanVien)
        {
            _maNhanVien = maNhanVien;
            if (_maNhanVien != 0)
            {
                _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            }
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietDeCuNhanVien(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private ChiTietDeCuNhanVien(SafeDataReader dr, bool search)//R
        {
            MarkAsChild();
            FetchSearch(dr);
        }

        #region Bo Sung
        public static bool KiemTraCTDeCudaDiHoc(int maChiTiet)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckCTDeCudaDihoc";
                    cm.Parameters.AddWithValue("@MaChiTiet", maChiTiet);
                    SqlParameter outPara = new SqlParameter("@DaDiHoc", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraNhanViendaDeCuvaoLoaiLop(int maDeCu, long maNhanVien, int maLoaiLop)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckNhanViendaDeCuvaoLop";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@MaLoaiLop", maLoaiLop);
                    SqlParameter outPara = new SqlParameter("@DaDeCuvaoLop", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraNhanVienTrungThoiGianLopHoc(int maDeCu, long maNhanVien, DateTime ngaybatdauuChinhthuc, DateTime ngayketthucChinhthuc)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckNhanVienTrungThoiGianHoc";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@NgayBatDau", ngaybatdauuChinhthuc);
                    cm.Parameters.AddWithValue("@NgayKetThuc", ngayketthucChinhthuc);
                    SqlParameter outPara = new SqlParameter("@TrungThoiGianHoc", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }
            return result;
        }

        //long maNhanVien,string thoiGian, int maDeCu
        public static bool KiemTraNhanVienTrungLichHoc(long maNhanVien, string tenThu, string gioHoc, decimal thoiGianhoc, DateTime ngaybatdau, DateTime ngayketthuc, int maDeCu)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungLichHocDaoTao";
                    cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    cm.Parameters.AddWithValue("@TenThu", tenThu);
                    cm.Parameters.AddWithValue("@GioHoc", gioHoc);
                    cm.Parameters.AddWithValue("@ThoiGianHoc", thoiGianhoc);
                    cm.Parameters.AddWithValue("@NgayBatDau", ngaybatdau.Date);
                    cm.Parameters.AddWithValue("@NgayKetThuc", ngayketthuc.Date);
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    SqlParameter outPara = new SqlParameter("@TrungLichHoc", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }
            return result;
        }

        public static string TinhTrangNhanVien(int maChiTietDeCu)
        {
            string result = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_GetTinhTrangNhanVienTrongQuaTrinhDaoTao";
                    cm.Parameters.AddWithValue("@MaChiTietDeCu", maChiTietDeCu);
                    SqlParameter outPara = new SqlParameter("@TinhTrang", SqlDbType.NVarChar, 100);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (string)outPara.Value;
                }
            }
            return result;
        }
        #endregion
        #endregion //Factory Methods

        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }
        private void FetchSearch(SafeDataReader dr)//R
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maDeCu = dr.GetInt32("MaDeCu");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            //if (_maNhanVien != 0)
            //{
            //    _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
            //    _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
            //    _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            //}
            _ghiChu = dr.GetString("GhiChu");

            _tenNhanVien = dr.GetString("TenNhanVien");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _boPhanNhanVien = dr.GetString("BoPhanNhanVien");
            _tenvanbangChungchi = dr.GetString("TenvanbangChungchi");
            _loaiVanBangString = dr.GetString("LoaiVanBangString");
            _vanbangChungChiString = dr.GetString("VanbangChungChiString");
            _ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _quocGiaCap = dr.GetString("QuocGiaCap");
            _tenDonViDaoTao = dr.GetString("TenDonViDaoTao");
            _tenTruongDaoTao = dr.GetString("TenTruongDaoTao");
            _tenChuyenNganhDaoTao = dr.GetString("TenChuyenNganhDaoTao");
            _trongnuocNgoainuocString = dr.GetString("TrongnuocNgoainuocString");
            _ghiChuLopHoc = dr.GetString("GhiChuLopHoc");
            _tenLoaiLop = dr.GetString("TenLoaiLop");
        }


        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DeCu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DeCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsCTDeCuNhanVien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DeCu parent)
        {
            _maDeCu = parent.MaDeCu;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDeCu != 0)
                cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            else
                cm.Parameters.AddWithValue("@MaDeCu", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            //if (_duocDiHoc != false)
            //    cm.Parameters.AddWithValue("@DuocDiHoc", _duocDiHoc);
            //else
            //    cm.Parameters.AddWithValue("@DuocDiHoc", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DeCu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DeCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsCTDeCuNhanVien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DeCu parent)
        {
            _maDeCu = parent.MaDeCu;
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDeCu != 0)
                cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            else
                cm.Parameters.AddWithValue("@MaDeCu", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            //if (_duocDiHoc != false)
            //    cm.Parameters.AddWithValue("@DuocDiHoc", _duocDiHoc);
            //else
            //    cm.Parameters.AddWithValue("@DuocDiHoc", DBNull.Value);
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

            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsCTDeCuNhanVien";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

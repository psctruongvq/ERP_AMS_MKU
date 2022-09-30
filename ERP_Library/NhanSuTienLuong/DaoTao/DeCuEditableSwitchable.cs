using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    public class DeCu : Csla.BusinessBase<DeCu>
    {
        #region Business Properties and Methods

        //declare members
        private int _maDeCu = 0;
        //private long _maNhanVien = 0;
        private int _maLopHoc = 0;
        private int _maNguoiLap = 0;
        private string _thu2 = string.Empty;
        private string _thu3 = string.Empty;
        private string _thu4 = string.Empty;
        private string _thu5 = string.Empty;
        private string _thu6 = string.Empty;
        private string _thu7 = string.Empty;
        private string _chuNhat = string.Empty;
        private SmartDate _ngayHeThong = new SmartDate(DateTime.Today);

        #region Bosung

        private string _tenvanbangChungchi = string.Empty;
        private SmartDate _ngayBatDau = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayBatDauChinhThuc = new SmartDate(DateTime.MinValue);
        private SmartDate _ngayKetThucChinhThuc = new SmartDate(DateTime.MinValue);
        private int _soNguoiDeCu = 0;
        private int _soNguoiDiHoc = 0;
        private decimal _soNgayHoc = 0;
        private decimal _soGioHoc = 0;

        private string _LoaiLop = string.Empty;
        private string _DonVi = string.Empty;
        private string _QuocGiaCap = String.Empty;

        private LopHoc _lopHoc = LopHoc.NewLopHoc();


        private string _NguoiPTThanhToan = string.Empty;
        private string _SoHopDong = string.Empty;
        private decimal _TongTien = 0;
        private decimal _ConLai = 0;
        #endregion
        //
        private ChiTietDeCuNhanVienList _chiTietDeCuNhanVien = ChiTietDeCuNhanVienList.NewChiTietDeCuNhanVienList();
        private LichHocDaoTaoList _lichHocDaoTao = LichHocDaoTaoList.NewLichHocDaoTaoList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDeCu
        {
            get
            {
                CanReadProperty("MaDeCu", true);
                return _maDeCu;
            }
        }

        //[DisplayName("Nhân viên")]
        //public long MaNhanVien
        //{
        //    get
        //    {
        //        CanReadProperty("MaNhanVien", true);
        //        return _maNhanVien;
        //    }
        //    set
        //    {
        //        CanWriteProperty("MaNhanVien", true);
        //        if (!_maNhanVien.Equals(value))
        //        {
        //            _maNhanVien = value;
        //            PropertyHasChanged("MaNhanVien");
        //        }
        //    }
        //}

        [DisplayName("Lớp học")]
        public int MaHopHoc
        {
            get
            {
                CanReadProperty("MaHopHoc", true);
                return _maLopHoc;
            }
            set
            {
                CanWriteProperty("MaHopHoc", true);
                if (!_maLopHoc.Equals(value))
                {
                    _maLopHoc = value;
                    PropertyHasChanged("MaHopHoc");
                }
            }
        }

        [DisplayName("Người lập")]
        public int MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
                return _maNguoiLap;
            }
            set
            {
                CanWriteProperty("MaNguoiLap", true);
                if (!_maNguoiLap.Equals(value))
                {
                    _maNguoiLap = value;
                    PropertyHasChanged("MaNguoiLap");
                }
            }
        }

        [DisplayName("Thứ 2")]
        public string Thu2
        {
            get
            {
                CanReadProperty("Thu2", true);
                return _thu2;
            }
            set
            {
                CanWriteProperty("Thu2", true);
                if (value == null) value = string.Empty;
                if (!_thu2.Equals(value))
                {
                    _thu2 = value.Replace("  :", "");
                    PropertyHasChanged("Thu2");
                }
            }
        }

        [DisplayName("Thứ 3")]
        public string Thu3
        {
            get
            {
                CanReadProperty("Thu3", true);
                return _thu3;
            }
            set
            {
                CanWriteProperty("Thu3", true);
                if (value == null) value = string.Empty;
                if (!_thu3.Equals(value))
                {
                    _thu3 = value.Replace("  :", "");
                    PropertyHasChanged("Thu3");
                }
            }
        }

        [DisplayName("Thứ 4")]
        public string Thu4
        {
            get
            {
                CanReadProperty("Thu4", true);
                return _thu4;
            }
            set
            {
                CanWriteProperty("Thu4", true);
                if (value == null) value = string.Empty;
                if (!_thu4.Equals(value))
                {
                    _thu4 = value.Replace("  :", "");
                    PropertyHasChanged("Thu4");
                }
            }
        }

        [DisplayName("Thứ 5")]
        public string Thu5
        {
            get
            {
                CanReadProperty("Thu5", true);
                return _thu5;
            }
            set
            {
                CanWriteProperty("Thu5", true);
                if (value == null) value = string.Empty;
                if (!_thu5.Equals(value))
                {
                    _thu5 = value.Replace("  :", "");
                    PropertyHasChanged("Thu5");
                }
            }
        }

        [DisplayName("Thứ 6")]
        public string Thu6
        {
            get
            {
                CanReadProperty("Thu6", true);
                return _thu6;
            }
            set
            {
                CanWriteProperty("Thu6", true);
                if (value == null) value = string.Empty;
                if (!_thu6.Equals(value))
                {
                    _thu6 = value.Replace("  :", "");
                    PropertyHasChanged("Thu6");
                }
            }
        }

        [DisplayName("Thứ 7")]
        public string Thu7
        {
            get
            {
                CanReadProperty("Thu7", true);
                return _thu7;
            }
            set
            {
                CanWriteProperty("Thu7", true);
                if (value == null) value = string.Empty;
                if (!_thu7.Equals(value))
                {
                    _thu7 = value.Replace("  :", "");
                    PropertyHasChanged("Thu7");
                }
            }
        }

        [DisplayName("Chủ nhật")]
        public string ChuNhat
        {
            get
            {
                CanReadProperty("ChuNhat", true);
                return _chuNhat;
            }
            set
            {
                CanWriteProperty("ChuNhat", true);
                if (value == null) value = string.Empty;
                if (!_chuNhat.Equals(value))
                {
                    _chuNhat = value.Replace("  :", "");
                    PropertyHasChanged("ChuNhat");
                }
            }
        }

        public DateTime? NgayHeThong
        {
            get
            {
                CanReadProperty("NgayHeThong", true);
                return _ngayHeThong.Date;
            }
            set
            {
                CanWriteProperty("NgayHeThong", true);
                if (!_ngayHeThong.Equals(value))
                {
                    if (value == null)
                        _ngayHeThong = new SmartDate(DateTime.MinValue);
                    else
                        _ngayHeThong = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }
        //

        #region BoSung
        public string TenvanbangChungchi
        {
            get
            {
                return _tenvanbangChungchi;//_lopHoc.TenvanbangChungchi;
            }
        }

        public string LoaiLop
        {
            get
            {
                return _LoaiLop;//;
            }
        }

        public string DonVi
        {
            get
            {
                return _DonVi;//
            }
        }

        public string QuocGiaCap
        {
            get
            {
                return _QuocGiaCap;//;
            }
        }

        public DateTime? NgayBatDau
        {
            get
            {
                return _ngayBatDau.Date;// _lopHoc.NgayBatDau;
                //if (_maLopHoc != 0)
                //{
                //    _ngayBatDau = LopHoc.GetLopHoc(_maLopHoc).NgayBatDau;
                //    return _ngayBatDau;
                //}
                //return null;
            }
        }

        public DateTime? NgayKetThuc
        {
            get
            {
                return _ngayKetThuc.Date;//_lopHoc.NgayKetThuc;
                //if (_maLopHoc != 0)
                //{
                //    _ngayKetThuc = LopHoc.GetLopHoc(_maLopHoc).NgayKetThuc;
                //    return _ngayKetThuc;
                //}
                //return null;
            }
        }

        public DateTime? NgayBatDauChinhThuc
        {
            get
            {
                return _ngayBatDauChinhThuc.Date;//_lopHoc.NgayBatDauChinhThuc;
            }
        }

        public DateTime? NgayKetThucChinhThuc
        {
            get
            {
                return _ngayKetThucChinhThuc.Date;//_lopHoc.NgayKetThucChinhThuc;
            }
        }

        public decimal SoNgayHoc
        {
            get
            {
                if (_lichHocDaoTao.Count > 0)
                {
                    _lopHoc = LopHoc.GetLopHoc(_maLopHoc);
                    if (_lopHoc.NgayBatDauChinhThuc != null && _lopHoc.NgayKetThucChinhThuc != null)
                    {
                        try
                        {
                            _soNgayHoc = TinhSoNgayDiHoc(_lopHoc.NgayBatDauChinhThuc.Value, _lopHoc.NgayKetThucChinhThuc.Value);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }

                    }
                }
                return _soNgayHoc;
            }
        }
        public decimal SoGioHoc
        {
            get
            {
                if (_lichHocDaoTao.Count > 0)
                {
                    _lopHoc = LopHoc.GetLopHoc(_maLopHoc);
                    if (_lopHoc.NgayBatDauChinhThuc != null && _lopHoc.NgayKetThucChinhThuc != null)
                    {
                        try
                        {
                            _soGioHoc = TinhSoGioDiHoc(_lopHoc.NgayBatDauChinhThuc.Value, _lopHoc.NgayKetThucChinhThuc.Value);
                        }
                        catch (Exception)
                        {

                            //throw;
                        }
                    }
                }
                return _soGioHoc;
            }
        }

        public int SoNguoiDeCu
        {
            get
            {
                return _soNguoiDeCu;//_chiTietDeCuNhanVien.Count;
            }
        }

        public int SoNguoiDiHoc
        {
            get
            {
                return _soNguoiDiHoc;//TinhSoNguoiDiHoc();
            }
        }

        public string NguoiPTThanhToan
        {
            get
            {
                return _NguoiPTThanhToan;
            }
        }

        public string SoHopDong
        {
            get
            {
                return _SoHopDong;
            }
        }

        public decimal TongTien
        {
            get
            {
                return _TongTien;
            }
        }

        public decimal ConLai
        {
            get
            {
                return _ConLai;
            }
        }
        #endregion

        public ChiTietDeCuNhanVienList chiTietDeCuNhanVienList
        {
            get
            {
                CanReadProperty("chiTietDeCuNhanVienList", true);
                return _chiTietDeCuNhanVien;
            }
        }


        public LopHoc LopHoc
        {
            get
            {
                return _lopHoc;
            }
        }

        public LichHocDaoTaoList LichHocDaoTaoList
        {
            get
            {
                CanReadProperty("LichHocDaoTaoList", true);
                return _lichHocDaoTao;
            }
        }

        protected override object GetIdValue()
        {
            return _maDeCu;
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chiTietDeCuNhanVien.IsValid && _lichHocDaoTao.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiTietDeCuNhanVien.IsDirty || _lichHocDaoTao.IsDirty; }
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
            //TODO: Define authorization rules in DeCu
            //AuthorizationRules.AllowRead("MaDeCu", "DeCuReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "DeCuReadGroup");
            //AuthorizationRules.AllowRead("MaHopHoc", "DeCuReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "DeCuReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "DeCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopHoc", "DeCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "DeCuWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeCu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeCu()
        { /* require use of factory method */ }

        public static DeCu NewDeCu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeCu");
            return DataPortal.Create<DeCu>();
        }

        public static DeCu GetDeCu(int maDeCu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeCu");
            return DataPortal.Fetch<DeCu>(new Criteria(maDeCu));
        }

        public static DeCu GetDeCuWithoutChild(int maDeCu)//R
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeCu");
            return DataPortal.Fetch<DeCu>(new CriteriaWithoutChild(maDeCu));
        }

        public static DeCu GetDeCuWithLichHoc(int maDeCu)//R
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeCu");
            return DataPortal.Fetch<DeCu>(new CriteriaWithLichHoc(maDeCu));
        }

        public static void DeleteDeCu(int maDeCu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeCu");
            DataPortal.Delete(new Criteria(maDeCu));
        }
        #region Bosung
        public static void DeleteDeCu(DeCu deCu)
        {//B
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    deCu._chiTietDeCuNhanVien.Clear();
                    deCu._chiTietDeCuNhanVien.Update(tr, deCu);
                    deCu.LichHocDaoTaoList.Clear();
                    deCu.LichHocDaoTaoList.Update(tr, deCu);
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblnsDeCu";

                        cm.Parameters.AddWithValue("@MaDeCu", deCu.MaDeCu);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E
        #endregion

        public override DeCu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeCu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeCu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeCu");

            return base.Save();
        }

        private int TinhSoNguoiDiHoc()
        {
            int tinh = 0;
            foreach (ChiTietDeCuNhanVien ct in _chiTietDeCuNhanVien)
            {
                if (ChiTietDeCuNhanVien.KiemTraCTDeCudaDiHoc(ct.MaChiTiet))
                {
                    tinh += 1;
                }
            }
            return tinh;
        }

        private decimal TinhSoGioHocTrongKhoangThoiGian(TimeSpan ts, LichHocDaoTao lichHoc)
        {
            decimal soGio = 0;
            if (lichHoc != null)
            {
                int days = ts.Days;
                for (int j = 0; j <= days; j++)
                {
                    DateTime testDate = lichHoc.NgayApDung.Value.AddDays(j);
                    //Thu 2
                    if (lichHoc.Time2 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Monday)
                        {
                            soGio += lichHoc.Time2;
                        }
                    //Thu 3
                    if (lichHoc.Time3 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Tuesday)
                        {
                            soGio += lichHoc.Time3;
                        }
                    //Thu 4
                    if (lichHoc.Time4 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Wednesday)
                        {
                            soGio += lichHoc.Time4;
                        }
                    //Thu 5
                    if (lichHoc.Time5 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Thursday)
                        {
                            soGio += lichHoc.Time5;
                        }
                    //Thu 6
                    if (lichHoc.Time6 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Friday)
                        {
                            soGio += lichHoc.Time6;
                        }
                    //Thu 7
                    if (lichHoc.Time7 != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            soGio += lichHoc.Time7;
                        }
                    //Chu Nhat
                    if (lichHoc.TimeCN != 0)
                        if (testDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            soGio += lichHoc.TimeCN;
                        }
                }
            }

            return soGio;
        }

        private bool LichHocThoaDieuKienCoDuLieu(LichHocDaoTao lichhoc)
        {
            if (lichhoc != null)
                if ((lichhoc.Time2 != 0)
                                || (lichhoc.Time3 != 0)
                                || (lichhoc.Time4 != 0)
                                || (lichhoc.Time5 != 0)
                                || (lichhoc.Time6 != 0)
                                || (lichhoc.Time7 != 0)
                                || (lichhoc.TimeCN != 0)
                                )
                {
                    return true;
                }
            return false;
        }

        private decimal TinhSoNgayDiHoc(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            decimal sogiohoc = 0;
            decimal soNgayHoc = 0;
            if (_lichHocDaoTao.Count > 0)
            {
                foreach (LichHocDaoTao lichhoc in _lichHocDaoTao)
                {
                    TimeSpan timeSpan = lichhoc.NgayKetThuc.Value - lichhoc.NgayApDung.Value;
                    if (LichHocThoaDieuKienCoDuLieu(lichhoc))
                    {
                        sogiohoc += TinhSoGioHocTrongKhoangThoiGian(timeSpan, lichhoc);
                    }
                }
                if (sogiohoc > 0)
                    soNgayHoc = sogiohoc / 8;
            }
            else
            {
                TimeSpan timeSpan = ngayKetThuc - ngayBatDau;
                soNgayHoc = timeSpan.Days;
            }
            #region Old
            //if (_lichHocDaoTao.Count > 0)
            //{
            //    if (_lichHocDaoTao.Count == 1)
            //    {
            //        //TimeSpan timeSpan = ngayKetThuc - _lichHocDaoTao[0].NgayApDung.Value;
            //        TimeSpan timeSpan = _lichHocDaoTao[0].NgayKetThuc.Value - _lichHocDaoTao[0].NgayApDung.Value;
            //        if (LichHocThoaDieuKienCoDuLieu(_lichHocDaoTao[0]))
            //            sogiohoc += TinhSoGioHocTrongKhoangThoiGian(timeSpan, _lichHocDaoTao[0]);
            //    }
            //    else
            //    {
            //        TimeSpan[] timespanArray = new TimeSpan[_lichHocDaoTao.Count - 1];
            //        for (int i = 0; i < _lichHocDaoTao.Count - 1; i++)
            //        {
            //            timespanArray[i] = _lichHocDaoTao[i + 1].NgayApDung.Value.AddDays(-1) - _lichHocDaoTao[i].NgayApDung.Value;
            //        }
            //        for (int i = 0; i < _lichHocDaoTao.Count - 1; i++)
            //        {
            //            if (LichHocThoaDieuKienCoDuLieu(_lichHocDaoTao[i]))
            //            {
            //                sogiohoc += TinhSoGioHocTrongKhoangThoiGian(timespanArray[i], _lichHocDaoTao[i]);
            //            }
            //        }
            //        TimeSpan lastTimeSpan = ngayKetThuc - _lichHocDaoTao[_lichHocDaoTao.Count - 1].NgayApDung.Value;
            //        if (LichHocThoaDieuKienCoDuLieu(_lichHocDaoTao[_lichHocDaoTao.Count - 1]))
            //            sogiohoc += TinhSoGioHocTrongKhoangThoiGian(lastTimeSpan, _lichHocDaoTao[_lichHocDaoTao.Count - 1]);
            //    }
            //}
            //if (sogiohoc > 0)
            //    soNgayHoc = sogiohoc / 8;
            #endregion//Old
            return soNgayHoc;
        }

        private decimal TinhSoGioDiHoc(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            decimal sogiohoc = 0;
            if (_lichHocDaoTao.Count > 0)
            {
                foreach (LichHocDaoTao lichhoc in _lichHocDaoTao)
                {
                    TimeSpan timeSpan = lichhoc.NgayKetThuc.Value - lichhoc.NgayApDung.Value;
                    if (LichHocThoaDieuKienCoDuLieu(lichhoc))
                    {
                        sogiohoc += TinhSoGioHocTrongKhoangThoiGian(timeSpan, lichhoc);
                    }
                }
            }
            return sogiohoc;
        }

        public static bool KiemTraDeCuDaCoNguoiDiHoc(int maDeCu)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckDeCuDaCoNguoiDiHoc";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    SqlParameter outPara = new SqlParameter("@CoDiHoc", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeCu NewDeCuChild()
        {
            DeCu child = new DeCu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeCu GetDeCu(SafeDataReader dr)
        {
            DeCu child = new DeCu();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static DeCu GetDeCuWithOutChild(SafeDataReader dr)
        {
            DeCu child = new DeCu();
            child.MarkAsChild();
            child.FetchWithoutChild(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaDeCu;

            public Criteria(int maDeCu)
            {
                this.MaDeCu = maDeCu;
            }
        }

        private class CriteriaWithoutChild//R
        {
            public int MaDeCu;

            public CriteriaWithoutChild(int maDeCu)
            {
                this.MaDeCu = maDeCu;
            }
        }

        private class CriteriaWithLichHoc//R
        {
            public int MaDeCu;

            public CriteriaWithLichHoc(int maDeCu)
            {
                this.MaDeCu = maDeCu;
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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw;
                }

            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            if (criteria is Criteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsDeCu";

                    cm.Parameters.AddWithValue("@MaDeCu", ((Criteria)criteria).MaDeCu);

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
            else if (criteria is CriteriaWithoutChild)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsDeCu";

                    cm.Parameters.AddWithValue("@MaDeCu", ((CriteriaWithoutChild)criteria).MaDeCu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();
                    }
                }//using
            }
            else if (criteria is CriteriaWithLichHoc)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsDeCu";

                    cm.Parameters.AddWithValue("@MaDeCu", ((CriteriaWithLichHoc)criteria).MaDeCu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        _lichHocDaoTao = LichHocDaoTaoList.GetLichHocDaoTaoList(this.MaDeCu);
                    }
                }//using
            }

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
                catch (Exception ex)
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

                catch (Exception ex)
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
            DataPortal_Delete(new Criteria(_maDeCu));
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
                    _chiTietDeCuNhanVien.Clear();
                    _chiTietDeCuNhanVien.Update(tr, this);
                    _lichHocDaoTao.Clear();
                    _lichHocDaoTao.Update(tr, this);
                    UpdateChildren(tr);
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (Exception ex)
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
                cm.CommandText = "spd_DeletetblnsDeCu";

                cm.Parameters.AddWithValue("@MaDeCu", criteria.MaDeCu);

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

        private void FetchWithoutChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDeCu = dr.GetInt32("MaDeCu");
            //_maNhanVien = dr.GetInt64("MaNhanVien");
            _maLopHoc = dr.GetInt32("MaHopHoc");
            //_lopHoc = LopHoc.GetLopHoc(_maLopHoc);
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _thu2 = dr.GetString("Thu2");
            _thu3 = dr.GetString("Thu3");
            _thu4 = dr.GetString("Thu4");
            _thu5 = dr.GetString("Thu5");
            _thu6 = dr.GetString("Thu6");
            _thu7 = dr.GetString("Thu7");
            _chuNhat = dr.GetString("ChuNhat");
            _ngayHeThong = dr.GetSmartDate("NgayHeThong", _ngayHeThong.EmptyIsMin);
            // "TenvanbangChungchi", "NgayBatDau", "NgayKetThuc", "NgayBatDauChinhThuc", "NgayKetThucChinhThuc", "SoNguoiDeCu", "SoNguoiDiHoc" 
            _tenvanbangChungchi = dr.GetString("TenVanBang_ChungChi");
            _ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _ngayBatDauChinhThuc = dr.GetSmartDate("NgayBatDauChinhThuc", _ngayBatDauChinhThuc.EmptyIsMin);
            _ngayKetThucChinhThuc = dr.GetSmartDate("NgayKetThucChinhThuc", _ngayKetThucChinhThuc.EmptyIsMin);
            _soNguoiDeCu = dr.GetInt32("SoNguoiDeCu");
            _soNguoiDiHoc = dr.GetInt32("SoNguoiDiHoc");

            _LoaiLop = dr.GetString("LoaiLop");
            _DonVi = dr.GetString("DonVi");
            _QuocGiaCap = dr.GetString("QuocGiaCap");

            _NguoiPTThanhToan = dr.GetString("NguoiPTThanhToan");
            _SoHopDong = dr.GetString("SoHopDong");
            _TongTien = dr.GetDecimal("TongTien");
            _ConLai = dr.GetDecimal("ConLai");

        }

        private void FetchChildren(SafeDataReader dr)
        {
            _chiTietDeCuNhanVien = ChiTietDeCuNhanVienList.GetChiTietDeCuNhanVienList(this.MaDeCu);
            _lichHocDaoTao = LichHocDaoTaoList.GetLichHocDaoTaoList(this.MaDeCu);
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
                cm.CommandText = "spd_InserttblnsDeCu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDeCu = (int)cm.Parameters["@MaDeCu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //if (_maNhanVien != 0)
            //    cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            //else
            //    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maLopHoc != 0)
                cm.Parameters.AddWithValue("@MaHopHoc", _maLopHoc);
            else
                cm.Parameters.AddWithValue("@MaHopHoc", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

            if (_thu2.Length > 0)
                cm.Parameters.AddWithValue("@Thu2", _thu2);
            else
                cm.Parameters.AddWithValue("@Thu2", DBNull.Value);
            if (_thu3.Length > 0)
                cm.Parameters.AddWithValue("@Thu3", _thu3);
            else
                cm.Parameters.AddWithValue("@Thu3", DBNull.Value);
            if (_thu4.Length > 0)
                cm.Parameters.AddWithValue("@Thu4", _thu4);
            else
                cm.Parameters.AddWithValue("@Thu4", DBNull.Value);
            if (_thu5.Length > 0)
                cm.Parameters.AddWithValue("@Thu5", _thu5);
            else
                cm.Parameters.AddWithValue("@Thu5", DBNull.Value);
            if (_thu6.Length > 0)
                cm.Parameters.AddWithValue("@Thu6", _thu6);
            else
                cm.Parameters.AddWithValue("@Thu6", DBNull.Value);
            if (_thu7.Length > 0)
                cm.Parameters.AddWithValue("@Thu7", _thu7);
            else
                cm.Parameters.AddWithValue("@Thu7", DBNull.Value);
            if (_chuNhat.Length > 0)
                cm.Parameters.AddWithValue("@ChuNhat", _chuNhat);
            else
                cm.Parameters.AddWithValue("@ChuNhat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong.DBValue);

            cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            cm.Parameters["@MaDeCu"].Direction = ParameterDirection.Output;
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsDeCu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            //if (_maNhanVien != 0)
            //    cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            //else
            //    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maLopHoc != 0)
                cm.Parameters.AddWithValue("@MaHopHoc", _maLopHoc);
            else
                cm.Parameters.AddWithValue("@MaHopHoc", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

            if (_thu2.Length > 0)
                cm.Parameters.AddWithValue("@Thu2", _thu2);
            else
                cm.Parameters.AddWithValue("@Thu2", DBNull.Value);
            if (_thu3.Length > 0)
                cm.Parameters.AddWithValue("@Thu3", _thu3);
            else
                cm.Parameters.AddWithValue("@Thu3", DBNull.Value);
            if (_thu4.Length > 0)
                cm.Parameters.AddWithValue("@Thu4", _thu4);
            else
                cm.Parameters.AddWithValue("@Thu4", DBNull.Value);
            if (_thu5.Length > 0)
                cm.Parameters.AddWithValue("@Thu5", _thu5);
            else
                cm.Parameters.AddWithValue("@Thu5", DBNull.Value);
            if (_thu6.Length > 0)
                cm.Parameters.AddWithValue("@Thu6", _thu6);
            else
                cm.Parameters.AddWithValue("@Thu6", DBNull.Value);
            if (_thu7.Length > 0)
                cm.Parameters.AddWithValue("@Thu7", _thu7);
            else
                cm.Parameters.AddWithValue("@Thu7", DBNull.Value);
            if (_chuNhat.Length > 0)
                cm.Parameters.AddWithValue("@ChuNhat", _chuNhat);
            else
                cm.Parameters.AddWithValue("@ChuNhat", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayHeThong", _ngayHeThong.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chiTietDeCuNhanVien.Update(tr, this);
            _lichHocDaoTao.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _chiTietDeCuNhanVien.Clear();
            _chiTietDeCuNhanVien.Update(tr, this);
            _lichHocDaoTao.Clear();
            _lichHocDaoTao.Update(tr, this);
            UpdateChildren(tr);
            ExecuteDelete(tr, new Criteria(_maDeCu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

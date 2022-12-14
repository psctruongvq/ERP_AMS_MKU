
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhep : Csla.BusinessBase<GiayNghiPhep>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNghiPhep = 0;
        private string _so = string.Empty;
        private SmartDate _ngay = new SmartDate(DateTime.Today);
        private Nullable<int> _maBoPhan = null;
        private Nullable<long> _maNhanVien = null;
        private string _lyDo = string.Empty;
        private string _dienThoai = string.Empty;
        private string _diaChi = string.Empty;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private int _ngayPhep = 1;
        private Nullable<long> _nhanVienBanGiao = null;
        private string _congViec = string.Empty;
        private string _ghiChu = string.Empty;
        private int _PhepDiDuong = 0;
        private Nullable<int> _maHinhThucNghi = null;
        private string _noiDen = "";
        private bool _giayKhamBS = false;
        private int _maKyTinhLuong = 0;
        
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public int MaNghiPhep
        {
            get
            {
                CanReadProperty("MaNghiPhep", true);
                return _maNghiPhep;
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

        public DateTime Ngay
        {
            get
            {
                CanReadProperty("Ngay", true);
                return _ngay.Date;
            }
            set
            {
                CanWriteProperty("Ngay", true);
                if (!_ngay.Equals(value))
                {
                    _ngay.Date = value;
                    PropertyHasChanged("Ngay");
                }
            }
        }

        public Nullable<int> MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public Nullable<long> MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
                }
            }
        }

        public string DienThoai
        {
            get
            {
                CanReadProperty("DienThoai", true);
                return _dienThoai;
            }
            set
            {
                CanWriteProperty("DienThoai", true);
                if (value == null) value = string.Empty;
                if (!_dienThoai.Equals(value))
                {
                    _dienThoai = value;
                    PropertyHasChanged("DienThoai");
                }
            }
        }

        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay.Date = value;
                    PropertyHasChanged("TuNgay");
                    CapNhatNgayPhep();
                }
            }
        }

        public string NoiDen
        {
            get
            {
                return _noiDen;
            }
            set
            {
                if (!_noiDen.Equals(value))
                {
                    _noiDen = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool GiayKhamBS
        {
            get
            {
                return _giayKhamBS;
            }
            set
            {
                if (!_giayKhamBS.Equals(value))
                {
                    _giayKhamBS = value;
                    PropertyHasChanged();
                }
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay.Date = value;
                    PropertyHasChanged("DenNgay");
                    CapNhatNgayPhep();
                }
            }
        }

        public int NgayPhep
        {
            get
            {
                CanReadProperty("NgayPhep", true);
                return _ngayPhep;
            }
        }

        private void CapNhatNgayPhep()
        {
            //kiểm tra ngày holiday
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = "Select Ngay From tblnsNgayHoliday";
            cm.CommandType = CommandType.Text;
            System.Collections.Generic.List<DateTime> d = new System.Collections.Generic.List<DateTime>();
            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            {
                while (dr.Read())
                {
                    d.Add(dr.GetDateTime("Ngay"));
                }
            }
            cn.Close();
            //không tính thứ 7 và chủ nhật
            int i = 0;
            if (_tuNgay <= _denNgay)
            {
                for (DateTime ngay = _tuNgay.Date; ngay <= _denNgay.Date; ngay = ngay.AddDays(1))
                {
                    if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!d.Contains(ngay))
                            i++;
                    }
                }
            }
            if (i > 0) i = i - PhepDiDuong;

            _ngayPhep = i;
            PropertyHasChanged("NgayPhep");
        }

        public Nullable<long> NhanVienBanGiao
        {
            get
            {
                CanReadProperty("NhanVienBanGiao", true);
                return _nhanVienBanGiao;
            }
            set
            {
                CanWriteProperty("NhanVienBanGiao", true);
                if (!_nhanVienBanGiao.Equals(value))
                {
                    _nhanVienBanGiao = value;
                    PropertyHasChanged("NhanVienBanGiao");
                }
            }
        }

        public string CongViec
        {
            get
            {
                CanReadProperty("CongViec", true);
                return _congViec;
            }
            set
            {
                CanWriteProperty("CongViec", true);
                if (value == null) value = string.Empty;
                if (!_congViec.Equals(value))
                {
                    _congViec = value;
                    PropertyHasChanged("CongViec");
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

        public int PhepDiDuong
        {
            get
            {
                CanReadProperty("PhepDiDuong");
                return _PhepDiDuong;
            }
            set
            {
                CanWriteProperty("PhepDiDuong");
                if (!_PhepDiDuong.Equals(value))
                {
                    _PhepDiDuong = value;
                    PropertyHasChanged("PhepDiDuong");
                    CapNhatNgayPhep();
                }
            }
        }

        public Nullable<int> MaHinhThucNghi
        {
            get
            {
                CanReadProperty("MaHinhThucNghi");
                return _maHinhThucNghi;
            }
            set
            {
                CanWriteProperty("MaHinhThucNghi");
                if (!_maHinhThucNghi.Equals(value))
                {
                    _maHinhThucNghi = value;
                    PropertyHasChanged("MaHinhThucNghi");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNghiPhep;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("So", "Chưa có nhập số giấy phép"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("LyDo", "Chưa có nhập lý do xin nghỉ phép"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa có nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa có nhập nhân viên"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaHinhThucNghi", "Chưa có nhập nhập hình thức nghỉ"));
            //ValidationRules.AddRule(NgayPhepDiDuong, new RuleArgs("PhepDiDuong"));
           // ValidationRules.AddRule(NgayPhepVuotGioiHan, new RuleArgs("NgayPhep"));
        }

        private void AddCommonRules()
        {
            //
            // So
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("So", 20));
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 200));
            //
            // DienThoai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 50));
            //
            // DiaChi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 100));

            ValidationRules.AddRule(CommonRules.IntegerMinValue,new CommonRules.IntegerMinValueRuleArgs("NgayPhep",0));
        }
        private static bool IntRequire(object obj, RuleArgs e)
        {
            switch (e.PropertyName)
            {
                case "MaNhanVien":
                    e.Description = "Chưa nhập nhân viên";
                    return ((GiayNghiPhep)obj)._maNhanVien.HasValue;
                case "MaBoPhan":
                    e.Description = "Chưa nhập bộ phận";
                    return ((GiayNghiPhep)obj)._maBoPhan.HasValue;
            }
            return false;
        }
        //private static bool NgayPhepDiDuong(object obj, RuleArgs e)
        //{
        //    if (((GiayNghiPhep)obj)._PhepDiDuong)
        //    {
        //        e.Description = "Ngày phép đi đường đã được sử dụng";
        //        int kq = 0;
        //        using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //        {
        //            SqlCommand cm = cn.CreateCommand();
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "sp_KiemTraNgayPhepDiDuong";
        //            cm.Parameters.AddWithValue("@MaNghiPhep", ((GiayNghiPhep)obj)._maNghiPhep);
        //            cm.Parameters.AddWithValue("@MaNhanVien", ((GiayNghiPhep)obj)._maNhanVien);
        //            cm.Parameters.AddWithValue("@Nam", ((GiayNghiPhep)obj)._ngay.Date.Year);
        //            cm.Parameters.AddWithValue("@Loai", "TrongNuoc");
        //            try
        //            {
        //                cn.Open();
        //                kq = (int)cm.ExecuteScalar();
        //            }
        //            catch (Exception ex)
        //            {
        //                System.Windows.Forms.MessageBox.Show(ex.Message);
        //            }
        //        }
        //        return  kq == 0;
        //    }
        //    else
        //        return true;
        //}




        private static bool NgayPhepVuotGioiHan(object obj, RuleArgs e)
        {
            e.Description = "Ngày phép sử dụng đã vượt quá giới hạn";
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_KiemTraNgayPhepConLai";
                cm.Parameters.AddWithValue("@MaNghiPhep", ((GiayNghiPhep)obj)._maNghiPhep);
                cm.Parameters.AddWithValue("@MaNhanVien", ((GiayNghiPhep)obj)._maNhanVien);
                cm.Parameters.AddWithValue("@Nam", ((GiayNghiPhep)obj)._ngay.Date.Year);
                cm.Parameters.AddWithValue("@Loai", "TrongNuoc");
                try
                {
                    cn.Open();
                    kq = (int)cm.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
            return ((GiayNghiPhep)obj)._ngayPhep <= kq;
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
            //TODO: Define authorization rules in GiayNghiPhep
            //AuthorizationRules.AllowRead("MaNghiPhep", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("So", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("DienThoai", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("DiaChi", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("NgayPhep", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("NhanVienBanGiao", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("CongViec", "GiayNghiPhepReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayNghiPhepReadGroup");

            //AuthorizationRules.AllowWrite("So", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("DienThoai", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("DiaChi", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("NgayPhep", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("NhanVienBanGiao", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("CongViec", "GiayNghiPhepWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayNghiPhepWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayNghiPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayNghiPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayNghiPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayNghiPhep
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayNghiPhep()
        { /* require use of factory method */ }

        public static GiayNghiPhep NewGiayNghiPhep()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayNghiPhep");
            return DataPortal.Create<GiayNghiPhep>();
        }

        public static GiayNghiPhep GetGiayNghiPhep(int maNghiPhep)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhep");
            return DataPortal.Fetch<GiayNghiPhep>(new Criteria(maNghiPhep));
        }

        public static void DeleteGiayNghiPhep(int maNghiPhep)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayNghiPhep");
            DataPortal.Delete(new Criteria(maNghiPhep));
        }

        public override GiayNghiPhep Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayNghiPhep");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayNghiPhep");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayNghiPhep");
            return base.Save();
        }

        #endregion //Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaNghiPhep;

            public Criteria(int maNghiPhep)
            {
                this.MaNghiPhep = maNghiPhep;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            //ValidationRules.CheckRules();
            PropertyHasChanged("So");
            PropertyHasChanged("LyDo");
            PropertyHasChanged("MaBoPhan");
            PropertyHasChanged("MaNhanVien");
            PropertyHasChanged("MaHinhThucNghi");
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
                cm.CommandText = "sp_SelecttblnsGiayNghiPhep";

                cm.Parameters.AddWithValue("@MaNghiPhep", criteria.MaNghiPhep);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);
                    //ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _maNghiPhep = dr.GetInt32("MaNghiPhep");
            _so = dr.GetString("So");
            _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _lyDo = dr.GetString("LyDo");
            _dienThoai = dr.GetString("DienThoai");
            _diaChi = dr.GetString("DiaChi");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _ngayPhep = dr.GetInt32("NgayPhep");
            _nhanVienBanGiao = dr.GetInt64("NhanVienBanGiao");
            if (_nhanVienBanGiao == 0)
                _nhanVienBanGiao = null;
            _congViec = dr.GetString("CongViec");
            _ghiChu = dr.GetString("GhiChu");
            _PhepDiDuong = dr.GetInt32("PhepDiDuong");
            _maHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
            _noiDen = dr.GetString("NoiDen");
            _giayKhamBS = dr.GetBoolean("GiayKhamBS");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
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

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsGiayNghiPhep";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNghiPhep = (int)cm.Parameters["@NewMaNghiPhep"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
            if (_nhanVienBanGiao.HasValue)
                cm.Parameters.AddWithValue("@NhanVienBanGiao", _nhanVienBanGiao);
            else
                cm.Parameters.AddWithValue("@NhanVienBanGiao", DBNull.Value);
            if (_congViec.Length > 0)
                cm.Parameters.AddWithValue("@CongViec", _congViec);
            else
                cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaNghiPhep", _maNghiPhep);
            cm.Parameters["@NewMaNghiPhep"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@PhepDiDuong", _PhepDiDuong);
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@NoiDen", _noiDen);
            cm.Parameters.AddWithValue("@GiayKhamBS", _giayKhamBS);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
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

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsGiayNghiPhep";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNghiPhep", _maNghiPhep);
            cm.Parameters.AddWithValue("@So", _so);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
            if (_nhanVienBanGiao.HasValue)
                cm.Parameters.AddWithValue("@NhanVienBanGiao", _nhanVienBanGiao);
            else
                cm.Parameters.AddWithValue("@NhanVienBanGiao", DBNull.Value);
            if (_congViec.Length > 0)
                cm.Parameters.AddWithValue("@CongViec", _congViec);
            else
                cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@PhepDiDuong", _PhepDiDuong);
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
            cm.Parameters.AddWithValue("@NoiDen", _noiDen);
            cm.Parameters.AddWithValue("@GiayKhamBS", _giayKhamBS);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maNghiPhep));
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
                cm.CommandText = "sp_DeletetblnsGiayNghiPhep";

                cm.Parameters.AddWithValue("@MaNghiPhep", criteria.MaNghiPhep);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public int SoNgayPhepConLai(int nam)
        {
            int np = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandText = "spd_Select_TinhSoNgayPhepConLai";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Nam", nam);
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                try
                {
                    np = Convert.ToInt32(cm.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    np = 0;
                }
                cn.Close();
            } 
            return np;
        }
        public int SoNgayPhepTrongNam(int nam)
        {
            int np = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandText = "spd_Select_TinhSoNgayTrongNam";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Nam", nam);
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                try
                {
                    np = Convert.ToInt32(cm.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    np = 0;
                }
                cn.Close();
            }
            return np;
        }
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepNuocNgoai : Csla.BusinessBase<GiayNghiPhepNuocNgoai>
    {
        #region Business Properties and Methods

        //declare members
        private int _maNghiPhep = 0;
        private string _so = string.Empty;
        private SmartDate _ngay = new SmartDate(DateTime.Today);
        private Nullable<int> _maBoPhan = null;
        private Nullable<long> _maNhanVien = null;
        private string _lyDo = string.Empty;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private int _ngayPhep = 1;
        private Nullable<long> _nhanVienBanGiao = null;
        private string _congViec = string.Empty;
        private string _ghiChu = string.Empty;
        private Nullable<long> _nguoiDuyet = null;
        private Nullable<int> _maKinhPhi = null;
        private Nullable<int> _MaHinhThucNghi = null;
        private int _maKyTinhLuong = 0;

        //declare child member(s)
        private GiayNghiPhepNuocNgoai_NuocDenList _nuocDen = GiayNghiPhepNuocNgoai_NuocDenList.NewGiayNghiPhepNuocNgoai_NuocDenList();

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

        public Nullable<long> NguoiDuyet
        {
            get
            {
                CanReadProperty("NguoiDuyet", true);
                return _nguoiDuyet;
            }
            set
            {
                CanWriteProperty("NguoiDuyet", true);
                if (!_nguoiDuyet.Equals(value))
                {
                    _nguoiDuyet = value;
                    PropertyHasChanged("NguoiDuyet");
                }
            }
        }

        public Nullable<int> MaKinhPhi
        {
            get
            {
                CanReadProperty("MaKinhPhi", true);
                return _maKinhPhi;
            }
            set
            {
                CanWriteProperty("MaKinhPhi", true);
                if (!_maKinhPhi.Equals(value))
                {
                    _maKinhPhi = value;
                    PropertyHasChanged("MaKinhPhi");
                }
            }
        }

        public Nullable<int> MaHinhThucNghi
        {
            get
            {
                CanReadProperty("MaHinhThucNghi");
                return _MaHinhThucNghi;
            }
            set
            {
                CanWriteProperty("MaHinhThucNghi");
                if (!_MaHinhThucNghi.Equals(value))
                {
                    _MaHinhThucNghi = value;
                    PropertyHasChanged("MaHinhThucNghi");
                }
            }
        }

        public GiayNghiPhepNuocNgoai_NuocDenList NuocDen
        {
            get
            {
                CanReadProperty("NuocDen", true);
                return _nuocDen;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _nuocDen.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _nuocDen.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maNghiPhep;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("So", "Chưa có nhập số giấy phép"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("LyDo", "Chưa có nhập lý do xin nghỉ phép"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa có nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa có nhập nhân viên"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaHinhThucNghi", "Chưa có nhập nhập hình thức nghỉ"));
            //ValidationRules.AddRule(NgayPhepVuotGioiHan, new RuleArgs("NgayPhep"));
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

            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs("NgayPhep", 0));
        }

        private static bool NgayPhepVuotGioiHan(object obj, RuleArgs e)
        {
            e.Description = "Ngày phép sử dụng đã vượt quá giới hạn";
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_KiemTraNgayPhepConLai";
                cm.Parameters.AddWithValue("@MaNghiPhep", ((GiayNghiPhepNuocNgoai)obj)._maNghiPhep);
                cm.Parameters.AddWithValue("@MaNhanVien", ((GiayNghiPhepNuocNgoai)obj)._maNhanVien);
                cm.Parameters.AddWithValue("@Nam", ((GiayNghiPhepNuocNgoai)obj)._ngay.Date.Year);
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
            return ((GiayNghiPhepNuocNgoai)obj)._ngayPhep <= kq;
        }

        private static bool IntRequire(object obj, RuleArgs e)
        {
            switch (e.PropertyName)
            {
                case "MaNhanVien":
                    e.Description = "Chưa nhập nhân viên";
                    return ((GiayNghiPhepNuocNgoai)obj)._maNhanVien.HasValue;
                case "MaBoPhan":
                    e.Description = "Chưa nhập bộ phận";
                    return ((GiayNghiPhepNuocNgoai)obj)._maBoPhan.HasValue;
            }
            return false;
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
            //TODO: Define authorization rules in GiayNghiPhepNuocNgoai
            //AuthorizationRules.AllowRead("NuocDen", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaNghiPhep", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("So", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("Ngay", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayString", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NgayPhep", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NhanVienBanGiao", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("CongViec", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("NguoiDuyet", "GiayNghiPhepNuocNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaKinhPhi", "GiayNghiPhepNuocNgoaiReadGroup");

            //AuthorizationRules.AllowWrite("So", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayString", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayPhep", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NhanVienBanGiao", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("CongViec", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiDuyet", "GiayNghiPhepNuocNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaKinhPhi", "GiayNghiPhepNuocNgoaiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in GiayNghiPhepNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepNuocNgoaiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in GiayNghiPhepNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepNuocNgoaiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in GiayNghiPhepNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepNuocNgoaiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in GiayNghiPhepNuocNgoai
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("GiayNghiPhepNuocNgoaiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private GiayNghiPhepNuocNgoai()
        { /* require use of factory method */ }

        public static GiayNghiPhepNuocNgoai NewGiayNghiPhepNuocNgoai()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayNghiPhepNuocNgoai");
            return DataPortal.Create<GiayNghiPhepNuocNgoai>();
        }

        public static GiayNghiPhepNuocNgoai GetGiayNghiPhepNuocNgoai(int maNghiPhep)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayNghiPhepNuocNgoai");
            return DataPortal.Fetch<GiayNghiPhepNuocNgoai>(new Criteria(maNghiPhep));
        }

        public static void DeleteGiayNghiPhepNuocNgoai(int maNghiPhep)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayNghiPhepNuocNgoai");
            DataPortal.Delete(new Criteria(maNghiPhep));
        }

        public override GiayNghiPhepNuocNgoai Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a GiayNghiPhepNuocNgoai");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a GiayNghiPhepNuocNgoai");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a GiayNghiPhepNuocNgoai");

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
                cm.CommandText = "sp_GetGiayNghiPhepNuocNgoai";

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
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _ngayPhep = dr.GetInt32("NgayPhep");
            _nhanVienBanGiao = dr.GetInt64("NhanVienBanGiao");
            _congViec = dr.GetString("CongViec");
            _ghiChu = dr.GetString("GhiChu");
            _nguoiDuyet = dr.GetInt64("NguoiDuyet");
            _maKinhPhi = dr.GetInt32("MaKinhPhi");
            _MaHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
            if (_maBoPhan == 0)
                _maBoPhan = null;
            if (_maNhanVien == 0)
                _maNhanVien = null;
            if (_nguoiDuyet == 0)
                _nguoiDuyet = null;
            if (_maKinhPhi == 0)
                _maKinhPhi = null;
            if (_nhanVienBanGiao == 0)
                _nhanVienBanGiao = null;
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            _nuocDen = GiayNghiPhepNuocNgoai_NuocDenList.GetGiayNghiPhepNuocNgoai_NuocDenList(dr);
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
                cm.CommandText = "sp_AddGiayNghiPhepNuocNgoai";

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
            if (_nguoiDuyet.HasValue)
                cm.Parameters.AddWithValue("@NguoiDuyet", _nguoiDuyet);
            else
                cm.Parameters.AddWithValue("@NguoiDuyet", DBNull.Value);
            if (_maKinhPhi.HasValue)
                cm.Parameters.AddWithValue("@MaKinhPhi", _maKinhPhi);
            else
                cm.Parameters.AddWithValue("@MaKinhPhi", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaNghiPhep", _maNghiPhep);
            cm.Parameters["@NewMaNghiPhep"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _MaHinhThucNghi);
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
                cm.CommandText = "sp_UpdateGiayNghiPhepNuocNgoai";

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
            if (_nguoiDuyet.HasValue)
                cm.Parameters.AddWithValue("@NguoiDuyet", _nguoiDuyet);
            else
                cm.Parameters.AddWithValue("@NguoiDuyet", DBNull.Value);
            if (_maKinhPhi.HasValue)
                cm.Parameters.AddWithValue("@MaKinhPhi", _maKinhPhi);
            else
                cm.Parameters.AddWithValue("@MaKinhPhi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHinhThucNghi", _MaHinhThucNghi);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _nuocDen.Update(tr, this);
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
                cm.CommandText = "sp_DeleteGiayNghiPhepNuocNgoai";

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
    }
}

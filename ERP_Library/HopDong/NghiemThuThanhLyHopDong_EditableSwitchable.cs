using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NghiemThuThanhLyHopDong : Csla.BusinessBase<NghiemThuThanhLyHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNghiemThuThanhLy = 0;
        private string _maNghiemThuThanhLyQL = string.Empty;
        private string _noiDung = string.Empty;
        private long _maHopDong = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private long _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private byte _tinhTrang = 0;
        private byte[] _fileDinhKem = new byte[0];
        private long _maNguoiKy = 0;
        private int _loai = 0;//1 Nghiem Thu; 2 Thanh Ly; 3 Nghiem Thu Thanh Ly
        private int _maLoaiTien = 0;
        private decimal _soTien = 0;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;
        private string _tenNguoiKy = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaNghiemThuThanhLy
        {
            get
            {
                CanReadProperty("MaNghiemThuThanhLy", true);
                return _maNghiemThuThanhLy;
            }
        }

        public string MaNghiemThuThanhLyQL
        {
            get
            {
                CanReadProperty("MaNghiemThuThanhLyQL", true);
                return _maNghiemThuThanhLyQL;
            }
            set
            {
                CanWriteProperty("MaNghiemThuThanhLyQL", true);
                if (value == null) value = string.Empty;
                if (!_maNghiemThuThanhLyQL.Equals(value))
                {
                    _maNghiemThuThanhLyQL = value;
                    PropertyHasChanged("MaNghiemThuThanhLyQL");
                }
            }
        }

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
                }
            }
        }

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
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
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }



        public long MaNguoiLap
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

        public byte[] FileDinhKem
        {
            get
            {
                CanReadProperty("FileDinhKem", true);
                return _fileDinhKem;
            }
            set
            {
                CanWriteProperty("FileDinhKem", true);
                if (!_fileDinhKem.Equals(value))
                {
                    _fileDinhKem = value;
                    PropertyHasChanged("FileDinhKem");
                }
            }
        }

        public long MaNguoiKy
        {
            get
            {
                CanReadProperty("MaNguoiKy", true);
                return _maNguoiKy;
            }
            set
            {
                CanWriteProperty("MaNguoiKy", true);
                if (!_maNguoiKy.Equals(value))
                {
                    _maNguoiKy = value;
                    _tenNguoiKy = TenNV.GetTenNhanVien(_maNguoiKy).TenNhanVien;
                    PropertyHasChanged("MaNguoiKy");
                }
            }
        }

        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        public int MaLoaiTien
        {
            get
            {
                CanReadProperty("MaLoaiTien", true);
                return _maLoaiTien;
            }
            set
            {
                CanWriteProperty("MaLoaiTien", true);
                if (!_maLoaiTien.Equals(value))
                {
                    _maLoaiTien = value;
                    PropertyHasChanged("MaLoaiTien");
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

        public DateTime? NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                if (_ngayKy.Date == DateTime.MinValue)
                    return null;
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKy.Equals(value))
                {
                    if (value == null)
                        _ngayKy = new SmartDate(DateTime.MinValue);
                    else
                        _ngayKy = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
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

        public string TenNguoiKy
        {
            get
            {
                CanReadProperty("TenNguoiKy", true);
                return _tenNguoiKy;
            }
            set
            {
                CanWriteProperty("TenNguoiKy", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiKy.Equals(value))
                {
                    _tenNguoiKy = value;
                    PropertyHasChanged("TenNguoiKy");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maNghiemThuThanhLy;
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
            // MaNghiemThuThanhLyQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNghiemThuThanhLyQL", 40));
            //
            // NoiDung
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 500));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1000));
            //
            // TenNguoiKy
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguoiKy", 500));
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
            //TODO: Define authorization rules in NghiemThuThanhLyHopDong
            //AuthorizationRules.AllowRead("MaNghiemThuThanhLy", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaNghiemThuThanhLyQL", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("FileDinhKem", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiKy", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayKy", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayKyString", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "NghiemThuThanhLyHopDongReadGroup");
            //AuthorizationRules.AllowRead("TenNguoiKy", "NghiemThuThanhLyHopDongReadGroup");

            //AuthorizationRules.AllowWrite("MaNghiemThuThanhLyQL", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("FileDinhKem", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiKy", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKyString", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "NghiemThuThanhLyHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TenNguoiKy", "NghiemThuThanhLyHopDongWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NghiemThuThanhLyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NghiemThuThanhLyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NghiemThuThanhLyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NghiemThuThanhLyHopDong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NghiemThuThanhLyHopDong()
        { /* require use of factory method */ }

        public static NghiemThuThanhLyHopDong NewNghiemThuThanhLyHopDong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiemThuThanhLyHopDong");
            return DataPortal.Create<NghiemThuThanhLyHopDong>();
        }

        public static NghiemThuThanhLyHopDong GetNghiemThuThanhLyHopDong(long maNghiemThuThanhLy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NghiemThuThanhLyHopDong");
            return DataPortal.Fetch<NghiemThuThanhLyHopDong>(new Criteria(maNghiemThuThanhLy));
        }

        public static void DeleteNghiemThuThanhLyHopDong(long maNghiemThuThanhLy)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NghiemThuThanhLyHopDong");
            DataPortal.Delete(new Criteria(maNghiemThuThanhLy));
        }

        public override NghiemThuThanhLyHopDong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NghiemThuThanhLyHopDong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NghiemThuThanhLyHopDong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NghiemThuThanhLyHopDong");

            return base.Save();
        }

        public static string SetMaNghiemThuThanhLyQL(long maHopDong, int loai)
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SetMaNghiemThuThanhLyQL";
                    cm.Parameters.AddWithValue("@MaHopDong", maHopDong);
                    cm.Parameters.AddWithValue("@Loai", loai);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 40);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }

        public static bool KiemTraTrungMaNghiemThuThanhLyQL(long maNghiemThuThanhLy, string maNghiemThuThanhLyQL)
        {
            bool trungMaPhuLucHopDongQL = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraTrungMaNghiemThuThanhLyQL";
                    cm.Parameters.AddWithValue("@MaNghiemThuThanhLy", maNghiemThuThanhLy);
                    cm.Parameters.AddWithValue("@MaNghiemThuThanhLyQL", maNghiemThuThanhLyQL);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@TrungMaNghiemThuThanhLyQL", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    trungMaPhuLucHopDongQL = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return trungMaPhuLucHopDongQL;
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NghiemThuThanhLyHopDong NewNghiemThuThanhLyHopDongChild()
        {
            NghiemThuThanhLyHopDong child = new NghiemThuThanhLyHopDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NghiemThuThanhLyHopDong GetNghiemThuThanhLyHopDong(SafeDataReader dr)
        {
            NghiemThuThanhLyHopDong child = new NghiemThuThanhLyHopDong();
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
            public long MaNghiemThuThanhLy;

            public Criteria(long maNghiemThuThanhLy)
            {
                this.MaNghiemThuThanhLy = maNghiemThuThanhLy;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_SelectNghiemThuThanhLy";

                cm.Parameters.AddWithValue("@MaNghiemThuThanhLy", criteria.MaNghiemThuThanhLy);

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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn, null);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn, null);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maNghiemThuThanhLy));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_DeleteNghiemThuThanhLy";

                cm.Parameters.AddWithValue("@MaNghiemThuThanhLy", criteria.MaNghiemThuThanhLy);

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
            _maNghiemThuThanhLy = dr.GetInt64("MaNghiemThuThanhLy");
            _maNghiemThuThanhLyQL = dr.GetString("MaNghiemThuThanhLyQL");
            _noiDung = dr.GetString("NoiDung");
            _maHopDong = dr.GetInt64("MaHopDong");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
            _tinhTrang = dr.GetByte("TinhTrang");
            _fileDinhKem = (byte[])dr["FileDinhKem"];
            _maNguoiKy = dr.GetInt64("MaNguoiKy");
            _loai = dr.GetInt32("Loai");
            _maLoaiTien = dr.GetInt32("MaLoaiTien");
            _soTien = dr.GetDecimal("SoTien");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _tenNguoiKy = dr.GetString("TenNguoiKy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, NghiemThuThanhLyHopDongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, NghiemThuThanhLyHopDongList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InsertNghiemThuThanhLy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maNghiemThuThanhLy = (long)cm.Parameters["@MaNghiemThuThanhLy"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NghiemThuThanhLyHopDongList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNghiemThuThanhLyQL.Length > 0)
                cm.Parameters.AddWithValue("@MaNghiemThuThanhLyQL", _maNghiemThuThanhLyQL);
            else
                cm.Parameters.AddWithValue("@MaNghiemThuThanhLyQL", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_tinhTrang != 0)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            cm.Parameters.AddWithValue("@FileDinhKem", _fileDinhKem);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNghiemThuThanhLy", _maNghiemThuThanhLy);
            cm.Parameters["@MaNghiemThuThanhLy"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, NghiemThuThanhLyHopDongList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn, NghiemThuThanhLyHopDongList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdateNghiemThuThanhLy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NghiemThuThanhLyHopDongList parent)
        {
            cm.Parameters.AddWithValue("@MaNghiemThuThanhLy", _maNghiemThuThanhLy);
            if (_maNghiemThuThanhLyQL.Length > 0)
                cm.Parameters.AddWithValue("@MaNghiemThuThanhLyQL", _maNghiemThuThanhLyQL);
            else
                cm.Parameters.AddWithValue("@MaNghiemThuThanhLyQL", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_tinhTrang != 0)
                cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            else
                cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            cm.Parameters.AddWithValue("@FileDinhKem", _fileDinhKem);
            if (_maNguoiKy != 0)
                cm.Parameters.AddWithValue("@MaNguoiKy", _maNguoiKy);
            else
                cm.Parameters.AddWithValue("@MaNguoiKy", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maLoaiTien != 0)
                cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
            else
                cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_tenNguoiKy.Length > 0)
                cm.Parameters.AddWithValue("@TenNguoiKy", _tenNguoiKy);
            else
                cm.Parameters.AddWithValue("@TenNguoiKy", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_maNghiemThuThanhLy));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

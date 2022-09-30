
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_TaiKhoanNganHang : Csla.BusinessBase<NhanVien_TaiKhoanNganHang>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private long _maNhanVien = 0;
        private int _maNganHang = 0;
        private string _tenNganHang = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private bool _luongV1 = false;
        private bool _luongV2 = false;
        private bool _thuLao = false;
        private bool _phuCap = false;
        private bool _khenThuong = false;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaNhanVien
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

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
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
                CanReadProperty("TenNganHang", true);
                _tenNganHang = NganHang.GetNganHang(_maNganHang).TenNganHang;
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }

        public int NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
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
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayCap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayCap");
                }
            }
        }

     

        public bool LuongV1
        {
            get
            {
                CanReadProperty("LuongV1", true);
                return _luongV1;
            }
            set
            {
                CanWriteProperty("LuongV1", true);
                if (!_luongV1.Equals(value))
                {
                    _luongV1 = value;
                    PropertyHasChanged("LuongV1");
                }
            }
        }

        public bool LuongV2
        {
            get
            {
                CanReadProperty("LuongV2", true);
                return _luongV2;
            }
            set
            {
                CanWriteProperty("LuongV2", true);
                if (!_luongV2.Equals(value))
                {
                    _luongV2 = value;
                    PropertyHasChanged("LuongV2");
                }
            }
        }

        public bool ThuLao
        {
            get
            {
                CanReadProperty("ThuLao", true);
                return _thuLao;
            }
            set
            {
                CanWriteProperty("ThuLao", true);
                if (!_thuLao.Equals(value))
                {
                    _thuLao = value;
                    PropertyHasChanged("ThuLao");
                }
            }
        }

        public bool PhuCap
        {
            get
            {
                CanReadProperty("PhuCap", true);
                return _phuCap;
            }
            set
            {
                CanWriteProperty("PhuCap", true);
                if (!_phuCap.Equals(value))
                {
                    _phuCap = value;
                    PropertyHasChanged("PhuCap");
                }
            }
        }

        public bool KhenThuong
        {
            get
            {
                CanReadProperty("KhenThuong", true);
                return _khenThuong;
            }
            set
            {
                CanWriteProperty("KhenThuong", true);
                if (!_khenThuong.Equals(value))
                {
                    _khenThuong = value;
                    PropertyHasChanged("KhenThuong");
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

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            // TenNganHang
            //
           // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 50));
            //
            // SoTaiKhoan
            //
           // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // GhiChu
            //
           // ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
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
            //TODO: Define authorization rules in NhanVien_TaiKhoanNganHang
            //AuthorizationRules.AllowRead("MaChiTiet", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("TenNganHang", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("LuongV1", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("LuongV2", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("ThuLao", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("PhuCap", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("KhenThuong", "NhanVien_TaiKhoanNganHangReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "NhanVien_TaiKhoanNganHangReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("TenNganHang", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("LuongV1", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("LuongV2", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("ThuLao", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("PhuCap", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("KhenThuong", "NhanVien_TaiKhoanNganHangWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "NhanVien_TaiKhoanNganHangWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static NhanVien_TaiKhoanNganHang NewNhanVien_TaiKhoanNganHang()
        {
            return new NhanVien_TaiKhoanNganHang();
        }

        internal static NhanVien_TaiKhoanNganHang GetNhanVien_TaiKhoanNganHang(SafeDataReader dr)
        {
            return new NhanVien_TaiKhoanNganHang(dr);
        }

        private NhanVien_TaiKhoanNganHang()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private NhanVien_TaiKhoanNganHang(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
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

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maNganHang = dr.GetInt32("MaNganHang");
            _tenNganHang = dr.GetString("TenNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _luongV1 = dr.GetBoolean("LuongV1");
            _luongV2 = dr.GetBoolean("LuongV2");
            _thuLao = dr.GetBoolean("ThuLao");
            _phuCap = dr.GetBoolean("PhuCap");
            _khenThuong = dr.GetBoolean("KhenThuong");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NhanVien parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhanVien_TaiKhoanNganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NhanVien parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_luongV1 != false)
                cm.Parameters.AddWithValue("@LuongV1", _luongV1);
            else
                cm.Parameters.AddWithValue("@LuongV1", DBNull.Value);
            if (_luongV2 != false)
                cm.Parameters.AddWithValue("@LuongV2", _luongV2);
            else
                cm.Parameters.AddWithValue("@LuongV2", DBNull.Value);
            if (_thuLao != false)
                cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            else
                cm.Parameters.AddWithValue("@ThuLao", DBNull.Value);
            if (_phuCap != false)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            if (_khenThuong != false)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NhanVien parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhanVien_TaiKhoanNganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
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
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_luongV1 != false)
                cm.Parameters.AddWithValue("@LuongV1", _luongV1);
            else
                cm.Parameters.AddWithValue("@LuongV1", DBNull.Value);
            if (_luongV2 != false)
                cm.Parameters.AddWithValue("@LuongV2", _luongV2);
            else
                cm.Parameters.AddWithValue("@LuongV2", DBNull.Value);
            if (_thuLao != false)
                cm.Parameters.AddWithValue("@ThuLao", _thuLao);
            else
                cm.Parameters.AddWithValue("@ThuLao", DBNull.Value);
            if (_phuCap != false)
                cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            else
                cm.Parameters.AddWithValue("@PhuCap", DBNull.Value);
            if (_khenThuong != false)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsNhanVien_TaiKhoanNganHang";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public static string GetSoTaiKhoan(int MaNhanVien, int MaNganHang)
        {
            string strSoTaiKhoan = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayTaiKhoanNhanVien";

                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);

                    strSoTaiKhoan = Convert.ToString(cm.ExecuteScalar());
                }//using
                cn.Close();
            }
            return strSoTaiKhoan;
        }
    }
}

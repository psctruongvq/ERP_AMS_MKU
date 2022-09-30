
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library.ThanhToan;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghiChuyenKhoan_DichVu : Csla.BusinessBase<DeNghiChuyenKhoan_DichVu>
    {
        #region Business Properties and Methods

        //declare members
        private long _maPhieu = 0;
        private long _maDoiTac = 0;
        private string _tenDoiTac = string.Empty;
        private string _soTaiKhoan = string.Empty;
        private decimal _soTien = 0;
        private int _loaiTien = 0;
        private int _maNganHang = 0;
        private string _tenNganHang = string.Empty;
        private int _maLoaiChungTu = 0;
        private string _ghiChu = string.Empty;
        private string _ghiChuThem = string.Empty;
        private long _maDeNghi = 0;
        private string _cmnd = string.Empty;
        private string _thongTinKhac = string.Empty;
        private decimal _soTienTruocThue = 0;
        private decimal _soTienThue = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaPhieu
        {
            get
            {
                CanReadProperty("MaPhieu", true);
                return _maPhieu;
            }
        }

        public long MaDoiTac
        {
            get
            {
                CanReadProperty("MaDoiTac", true);
                return _maDoiTac;
            }
            set
            {
                CanWriteProperty("MaDoiTac", true);
                if (!_maDoiTac.Equals(value))
                {
                    _maDoiTac = value;
                    PropertyHasChanged("MaDoiTac");
                }
            }
        }

        public string TenDoiTac
        {
            get
            {
                CanReadProperty("TenDoiTac", true);
                return _tenDoiTac;
            }
            set
            {
                CanWriteProperty("TenDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenDoiTac.Equals(value))
                {
                    _tenDoiTac = value;
                    PropertyHasChanged("TenDoiTac");
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

        public decimal SoTienTruocThue
        {
            get
            {
                CanReadProperty("SoTienTruocThue", true);
                return _soTienTruocThue;
            }
            set
            {
                CanWriteProperty("SoTienTruocThue", true);
                if (!_soTienTruocThue.Equals(value))
                {
                    _soTienTruocThue = value;
                    PropertyHasChanged("SoTienTruocThue");
                }
            }
        }

        public decimal SoTienThue
        {
            get
            {
                CanReadProperty("SoTienThue", true);
                return _soTienThue;
            }
            set
            {
                CanWriteProperty("SoTienThue", true);
                if (!_soTienThue.Equals(value))
                {
                    _soTienThue = value;
                    PropertyHasChanged("SoTienThue");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
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
                    PropertyHasChanged("MaNganHang");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
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

        public int MaLoaiChungTu
        {
            get
            {
                CanReadProperty("MaLoaiChungTu", true);
                return _maLoaiChungTu;
            }
            set
            {
                CanWriteProperty("MaLoaiChungTu", true);
                if (!_maLoaiChungTu.Equals(value))
                {
                    _maLoaiChungTu = value;
                    PropertyHasChanged("MaLoaiChungTu");
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

        public string GhiChuThem
        {
            get
            {
                CanReadProperty("GhiChuThem", true);
                return _ghiChuThem;
            }
            set
            {
                CanWriteProperty("GhiChuThem", true);
                if (value == null) value = string.Empty;
                if (!_ghiChuThem.Equals(value))
                {
                    _ghiChuThem = value;
                    PropertyHasChanged("GhiChuThem");
                }
            }
        }

        public long MaDeNghi
        {
            get
            {
                CanReadProperty("MaDeNghi", true);
                return _maDeNghi;
            }
            set
            {
                CanWriteProperty("MaDeNghi", true);
                if (!_maDeNghi.Equals(value))
                {
                    _maDeNghi = value;
                    PropertyHasChanged("MaDeNghi");
                }
            }
        }

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }

        public string ThongTinKhac
        {
            get
            {
                CanReadProperty("ThongTinKhac", true);
                return _thongTinKhac;
            }
            set
            {
                CanWriteProperty("ThongTinKhac", true);
                if (value == null) value = string.Empty;
                if (!_thongTinKhac.Equals(value))
                {
                    _thongTinKhac = value;
                    PropertyHasChanged("ThongTinKhac");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maPhieu;
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
            // TenDoiTac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTac", 500));
            //
            // SoTaiKhoan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTaiKhoan", 50));
            //
            // TenNganHang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNganHang", 500));
            //
            // GhiChu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
            //
            // Cmnd
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
            //
            // ThongTinKhac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThongTinKhac", 500));
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
            //TODO: Define authorization rules in DeNghiChuyenKhoan_DichVu
            //AuthorizationRules.AllowRead("MaPhieu", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTac", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("TenDoiTac", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("SoTaiKhoan", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("LoaiTien", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("TenNganHang", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("MaLoaiChungTu", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("Cmnd", "DeNghiChuyenKhoan_DichVuReadGroup");
            //AuthorizationRules.AllowRead("ThongTinKhac", "DeNghiChuyenKhoan_DichVuReadGroup");

            //AuthorizationRules.AllowWrite("MaDoiTac", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("TenDoiTac", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTaiKhoan", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiTien", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaNganHang", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("TenNganHang", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaLoaiChungTu", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeNghi", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("Cmnd", "DeNghiChuyenKhoan_DichVuWriteGroup");
            //AuthorizationRules.AllowWrite("ThongTinKhac", "DeNghiChuyenKhoan_DichVuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static DeNghiChuyenKhoan_DichVu NewDeNghiChuyenKhoan_DichVu()
        {
            return new DeNghiChuyenKhoan_DichVu();
        }

        internal static DeNghiChuyenKhoan_DichVu GetDeNghiChuyenKhoan_DichVu(SafeDataReader dr)
        {
            return new DeNghiChuyenKhoan_DichVu(dr);
        }

        private DeNghiChuyenKhoan_DichVu()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DeNghiChuyenKhoan_DichVu(SafeDataReader dr)
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
            _maPhieu = dr.GetInt64("MaPhieu");
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tenDoiTac = dr.GetString("TenDoiTac");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
            _soTien = dr.GetDecimal("SoTien");
            _loaiTien = dr.GetInt32("LoaiTien");
            _maNganHang = dr.GetInt32("MaNganHang");
            _tenNganHang = dr.GetString("TenNganHang");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _ghiChu = dr.GetString("GhiChu");
            _ghiChuThem = dr.GetString("GhiChuThem");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _cmnd = dr.GetString("CMND");
            _thongTinKhac = dr.GetString("ThongTinKhac");
            _soTienTruocThue = dr.GetDecimal("SoTienTruocThue");
            _soTienThue = dr.GetDecimal("SoTienThue");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDeNghiChuyenKhoan_DichVu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DeNghiChuyenKhoan parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (parent.TenNguoiNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", parent.TenNguoiNhan);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (parent.SoTaiKhoanNhan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", parent.SoTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", parent.NganHangNhan);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_maLoaiChungTu != 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_ghiChuThem.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuThem", _ghiChuThem);
            else
                cm.Parameters.AddWithValue("@GhiChuThem", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_thongTinKhac.Length > 0)
                cm.Parameters.AddWithValue("@ThongTinKhac", _thongTinKhac);
            else
                cm.Parameters.AddWithValue("@ThongTinKhac", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            if (_soTienTruocThue != 0)
                cm.Parameters.AddWithValue("@SoTienTruocThue", _soTienTruocThue);
            else
                cm.Parameters.AddWithValue("@SoTienTruocThue", DBNull.Value);
            if (_soTienThue != 0)
                cm.Parameters.AddWithValue("@SoTienThue", _soTienThue);
            else
                cm.Parameters.AddWithValue("@SoTienThue", DBNull.Value);

            cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DeNghiChuyenKhoan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DeNghiChuyenKhoan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDeNghiChuyenKhoan_DichVu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DeNghiChuyenKhoan parent)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
            if (parent.TenNguoiNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTac", parent.TenNguoiNhan);
            else
                cm.Parameters.AddWithValue("@TenDoiTac", DBNull.Value);
            if (parent.SoTaiKhoanNhan.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoan", parent.SoTaiKhoanNhan);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoan", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiTien != 0)
                cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
            else
                cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
            if (_maNganHang != 0)
                cm.Parameters.AddWithValue("@MaNganHang", _maNganHang);
            else
                cm.Parameters.AddWithValue("@MaNganHang", DBNull.Value);
            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", parent.NganHangNhan);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_maLoaiChungTu != 0)
                cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            else
                cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_ghiChuThem.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuThem", _ghiChuThem);
            else
                cm.Parameters.AddWithValue("@GhiChuThem", DBNull.Value);
            if (parent.MaPhieu != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", parent.MaPhieu);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_thongTinKhac.Length > 0)
                cm.Parameters.AddWithValue("@ThongTinKhac", _thongTinKhac);
            else
                cm.Parameters.AddWithValue("@ThongTinKhac", DBNull.Value);
            if (_soTienTruocThue != 0)
                cm.Parameters.AddWithValue("@SoTienTruocThue", _soTienTruocThue);
            else
                cm.Parameters.AddWithValue("@SoTienTruocThue", DBNull.Value);
            if (_soTienThue != 0)
                cm.Parameters.AddWithValue("@SoTienThue", _soTienThue);
            else
                cm.Parameters.AddWithValue("@SoTienThue", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            //if (IsNew) return;

            ExecuteDelete(tr);
            //MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblDeNghiChuyenKhoan_DichVu";

                cm.Parameters.AddWithValue("@MaPhieu", this._maPhieu);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HoaDonDichVu : Csla.BusinessBase<CT_HoaDonDichVu>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maHoaDon = 0;
        private string _tenHangHoaDichVu = string.Empty;
        private double _soLuong = 0;
        private decimal _donGia = 0;
        private decimal _thanhTien = 0;
        private int _maDonViTinh = 0;
        private decimal _tienPhat = 0;
        private decimal _tienPhuThu = 0;
        private string _Ghichu = "";
        private int _MaButToan = 0;
        private long _MaChungTu = 0;
        private long _maDoiTac = 0;

        private double _tyLeCK = 0;
        private decimal _tienChietKhau = 0;
        private decimal _chiPhiMuaHang = 0;
        private double _thueSuatVAT = 0;
        private decimal _tienThue = 0;
        private byte _NhomHHDVMuaVao = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    PropertyHasChanged("MaHoaDon");
                }
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

        public string TenHangHoaDichVu
        {
            get
            {
                CanReadProperty("TenHangHoaDichVu", true);
                return _tenHangHoaDichVu;
            }
            set
            {
                CanWriteProperty("TenHangHoaDichVu", true);
                if (value == null) value = string.Empty;
                if (!_tenHangHoaDichVu.Equals(value))
                {
                    _tenHangHoaDichVu = value;
                    PropertyHasChanged("TenHangHoaDichVu");
                }
            }
        }

        public double SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    if (_soLuong != 0 && _donGia != 0)
                        _thanhTien = ((decimal)_soLuong * _donGia);
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _donGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_donGia.Equals(value))
                {
                    _donGia = value;
                    if (_soLuong != 0 && _donGia != 0)
                    _thanhTien = ((decimal)_soLuong * _donGia);
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public decimal TienPhat
        {
            get
            {
                CanReadProperty("TienPhat", true);
                return _tienPhat;
            }
            set
            {
                CanWriteProperty("TienPhat", true);
                if (!_tienPhat.Equals(value))
                {
                    _tienPhat = value;
                    PropertyHasChanged("TienPhat");
                }
            }
        }

        public decimal TienPhuThu
        {
            get
            {
                CanReadProperty("TienPhuThu", true);
                return _tienPhuThu;
            }
            set
            {
                CanWriteProperty("TienPhuThu", true);
                if (!_tienPhuThu.Equals(value))
                {
                    _tienPhuThu = value;
                    PropertyHasChanged("TienPhuThu");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
                }
            }
        }

        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty("MaDonViTinh", true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
                    PropertyHasChanged("MaDonViTinh");
                }
            }
        }
        public string GhiChu
        {
            get
            {
                CanReadProperty(true);
                return _Ghichu;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_Ghichu.Equals(value))
                {
                    _Ghichu = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaButToan
        {
            get
            {
                CanReadProperty("MaButToan", true);
                return _MaButToan;
            }
            set
            {
                CanWriteProperty("MaButToan", true);
                if (!_MaButToan.Equals(value))
                {
                    _MaButToan = value;
                    PropertyHasChanged("MaButToan");
                }
            }
        }

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _MaChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_MaChungTu.Equals(value))
                {
                    _MaChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }

        public double TyLeCK
        {
            get
            {
                CanReadProperty("TyLeCK", true);
                return _tyLeCK;
            }
            set
            {
                CanWriteProperty("TyLeCK", true);
                if (!_tyLeCK.Equals(value))
                {
                    _tyLeCK = value;
                    _tienChietKhau = (_thanhTien * (decimal)_tyLeCK) / 100;
                    PropertyHasChanged("TyLeCK");
                }
            }
        }

        public decimal TienChietKhau
        {
            get
            {
                CanReadProperty("TienChietKhau", true);
                return _tienChietKhau;
            }
            set
            {
                CanWriteProperty("TienChietKhau", true);
                if (!_tienChietKhau.Equals(value))
                {
                    _tienChietKhau = value;
                    _tienChietKhau = (_thanhTien * (decimal)_tyLeCK) / 100;
                    PropertyHasChanged("TienChietKhau");
                }
            }
        }

        public decimal ChiPhiMuaHang
        {
            get
            {
                CanReadProperty("ChiPhiMuaHang", true);
                return _chiPhiMuaHang;
            }
            set
            {
                CanWriteProperty("ChiPhiMuaHang", true);
                if (!_chiPhiMuaHang.Equals(value))
                {
                    _chiPhiMuaHang = value;
                    PropertyHasChanged("ChiPhiMuaHang");
                }
            }
        }

        public double ThueSuatVAT
        {
            get
            {
                CanReadProperty("ThueSuatVAT", true);
                return _thueSuatVAT;
            }
            set
            {
                CanWriteProperty("ThueSuatVAT", true);
                if (!_thueSuatVAT.Equals(value))
                {
                    _thueSuatVAT = value;
                    PropertyHasChanged("ThueSuatVAT");
                }
            }
        }

        public decimal TienThue
        {
            get
            {
                CanReadProperty("TienThue", true);
                return _tienThue;
            }
            set
            {
                CanWriteProperty("TienThue", true);
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    _tienThue = ((_thanhTien - _tienChietKhau) * (decimal)_thueSuatVAT) / 100;
                    PropertyHasChanged("TienThue");
                }
            }
        }

        public byte NhomHHDVMuaVao
        {
            get
            {
                CanReadProperty("NhomHHDVMuaVao", true);
                return _NhomHHDVMuaVao;
            }
            set
            {
                CanWriteProperty("NhomHHDVMuaVao", true);
                if (!_NhomHHDVMuaVao.Equals(value))
                {
                    _NhomHHDVMuaVao = value;
                    PropertyHasChanged("NhomHHDVMuaVao");
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
            // TenHangHoaDichVu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHangHoaDichVu", 500));
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
            //TODO: Define authorization rules in CT_HoaDonDichVu
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaHoaDon", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("TenHangHoaDichVu", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_HoaDonDichVuReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_HoaDonDichVuReadGroup");

            //AuthorizationRules.AllowWrite("MaHoaDon", "CT_HoaDonDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("TenHangHoaDichVu", "CT_HoaDonDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_HoaDonDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CT_HoaDonDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_HoaDonDichVuWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_HoaDonDichVuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_HoaDonDichVu NewCT_HoaDonDichVu()
        {
            return new CT_HoaDonDichVu();
        }



        internal static CT_HoaDonDichVu GetCT_HoaDonDichVu(SafeDataReader dr)
        {
            return new CT_HoaDonDichVu(dr);
        }


        private CT_HoaDonDichVu()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_HoaDonDichVu(SafeDataReader dr)
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
            try
            {
                _maChiTiet = dr.GetInt64("MaChiTiet");
                _maHoaDon = dr.GetInt64("MaHoaDon");
                _tenHangHoaDichVu = dr.GetString("TenHangHoaDichVu");
                _soLuong = dr.GetDouble("SoLuong");
                _donGia = dr.GetDecimal("DonGia");
                _thanhTien = dr.GetDecimal("ThanhTien");
                _maDonViTinh = dr.GetInt32("MaDonViTinh");
                if (dr.GetDecimal("TienPhat") == null)
                    _tienPhat = 0;
                else
                    _tienPhat = dr.GetDecimal("TienPhat");
                if (dr.GetDecimal("TienPhuThu") == null)
                    _tienPhuThu = 0;
                else
                    _tienPhuThu = dr.GetDecimal("TienPhuThu");
                _Ghichu = dr.GetString("GhiChu");
                _MaButToan = dr.GetInt32("MaButToan");
                _MaChungTu = dr.GetInt64("MaChungTu");

                _tyLeCK = dr.GetDouble("TyLeCK");
                _tienChietKhau = dr.GetDecimal("TienChietKhau");
                _chiPhiMuaHang = dr.GetDecimal("ChiPhiMuaHang");
                _thueSuatVAT = dr.GetDouble("ThueSuatVAT");
                _tienThue = dr.GetDecimal("TienThue");
                _NhomHHDVMuaVao = dr.GetByte("NhomHHDVMuaVao");
                _maDoiTac = dr.GetInt64("MaDoiTac");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HoaDon parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_HoaDonDichVu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HoaDon parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent

            cm.Parameters.AddWithValue("@MaHoaDon", parent.MaHoaDon);
            if (_tenHangHoaDichVu.Length > 0)
                cm.Parameters.AddWithValue("@TenHangHoaDichVu", _tenHangHoaDichVu);
            else
                cm.Parameters.AddWithValue("@TenHangHoaDichVu", DBNull.Value);
            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            cm.Parameters.AddWithValue("@TienPhat", _tienPhat);
            cm.Parameters.AddWithValue("@TienPhuThu", _tienPhuThu);

            cm.Parameters.AddWithValue("@GhiChu", _Ghichu);

            if (_MaButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", _MaButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (_MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            //
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienChietKhau != 0)
                cm.Parameters.AddWithValue("@TienChietKhau", _tienChietKhau);
            else
                cm.Parameters.AddWithValue("@TienChietKhau", DBNull.Value);
            if (_chiPhiMuaHang != 0)
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", _chiPhiMuaHang);
            else
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", DBNull.Value);
            if (_thueSuatVAT != 0)
                cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            else
                cm.Parameters.AddWithValue("@ThueSuatVAT", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);

            if (_NhomHHDVMuaVao != 0)
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", _NhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", DBNull.Value);
            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HoaDon parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_HoaDonDichVu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);

            cm.Parameters.AddWithValue("@MaHoaDon", parent.MaHoaDon);
            if (_tenHangHoaDichVu.Length > 0)
                cm.Parameters.AddWithValue("@TenHangHoaDichVu", _tenHangHoaDichVu);
            else
                cm.Parameters.AddWithValue("@TenHangHoaDichVu", DBNull.Value);

            cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            cm.Parameters.AddWithValue("@DonGia", _donGia);
            cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);

            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            cm.Parameters.AddWithValue("@TienPhat", _tienPhat);
            cm.Parameters.AddWithValue("@TienPhuThu", _tienPhuThu);

            cm.Parameters.AddWithValue("@GhiChu", _Ghichu);

            if (_MaButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", _MaButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (_MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);

            //
            if (_tyLeCK != 0)
                cm.Parameters.AddWithValue("@TyLeCK", _tyLeCK);
            else
                cm.Parameters.AddWithValue("@TyLeCK", DBNull.Value);
            if (_tienChietKhau != 0)
                cm.Parameters.AddWithValue("@TienChietKhau", _tienChietKhau);
            else
                cm.Parameters.AddWithValue("@TienChietKhau", DBNull.Value);
            if (_chiPhiMuaHang != 0)
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", _chiPhiMuaHang);
            else
                cm.Parameters.AddWithValue("@ChiPhiMuaHang", DBNull.Value);
            if (_thueSuatVAT != 0)
                cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
            else
                cm.Parameters.AddWithValue("@ThueSuatVAT", DBNull.Value);
            if (_tienThue != 0)
                cm.Parameters.AddWithValue("@TienThue", _tienThue);
            else
                cm.Parameters.AddWithValue("@TienThue", DBNull.Value);

            if (_NhomHHDVMuaVao != 0)
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", _NhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@NhomHHDVMuaVao", DBNull.Value);

            if (_maDoiTac != 0)
                cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_HoaDonDichVu";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

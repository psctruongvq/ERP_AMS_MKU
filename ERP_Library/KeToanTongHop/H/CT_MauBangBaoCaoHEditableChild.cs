﻿
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_MauBangBaoCaoH : Csla.BusinessBase<CT_MauBangBaoCaoH>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private int _maTaiKhoan = 0;
        private byte _loai = 0;
        private int _maTaiKhoanDoiUng = 0;
        private string _soHieu = string.Empty;
        private byte _congTru = 1;
        private int _maMuc = 0;
        private byte _loaiMau = 1;
        private int _maMucLienQuan = 0;
        private byte _noCo = 1;
        private int _loaiHoatDong = 0;
        private int _maHoatDong = 0;
        private string _loaiHoatDongString = string.Empty;
        private string _maHoatDongString = string.Empty;
        private string _soHieuTKDU = string.Empty;
        private string _col1 = string.Empty;
        private string _col2 = string.Empty;
        private string _col3 = string.Empty;


        [System.ComponentModel.DataObjectField(true, false)]

        public string COL1
        {
            get
            {
                CanReadProperty("COL1", true);
                return _col1;
            }
            set
            {
                CanWriteProperty("COL1", true);
                if (value == null) value = string.Empty;
                if (!_col1.Equals(value))
                {
                    _col1 = value;
                    PropertyHasChanged("COL1");
                }
            }
        }

        public string COL2
        {
            get
            {
                CanReadProperty("COL2", true);
                return _col2;
            }
            set
            {
                CanWriteProperty("COL2", true);
                if (value == null) value = string.Empty;
                if (!_col2.Equals(value))
                {
                    _col2 = value;
                    PropertyHasChanged("COL2");
                }
            }
        }

        public string COL3
        {
            get
            {
                CanReadProperty("COL3", true);
                return _col3;
            }
            set
            {
                CanWriteProperty("COL3", true);
                if (value == null) value = string.Empty;
                if (!_col3.Equals(value))
                {
                    _col3 = value;
                    PropertyHasChanged("COL3");
                }
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

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    _soHieu = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoan).SoHieuTK;
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }

        public byte Loai
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

        public int MaTaiKhoanDoiUng
        {
            get
            {
                CanReadProperty("MaTaiKhoanDoiUng", true);
                return _maTaiKhoanDoiUng;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanDoiUng", true);
                if (!_maTaiKhoanDoiUng.Equals(value))
                {
                    _maTaiKhoanDoiUng = value;
                    _soHieuTKDU = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoanDoiUng).SoHieuTK;
                    PropertyHasChanged("MaTaiKhoanDoiUng");
                }
            }
        }

        public string SoHieu
        {
            get
            {
                CanReadProperty("SoHieu", true);
                return _soHieu;
            }
            set
            {
                CanWriteProperty("SoHieu", true);
                if (value == null) value = string.Empty;
                if (!_soHieu.Equals(value))
                {
                    _soHieu = value;
                    PropertyHasChanged("SoHieu");
                }
            }
        }

        public string SoHieuTKDU
        {
            get
            {
                CanReadProperty("SoHieuTKDU", true);
                return _soHieuTKDU;
            }
            set
            {
                CanWriteProperty("SoHieuTKDU", true);
                if (value == null) value = string.Empty;
                if (!_soHieuTKDU.Equals(value))
                {
                    _soHieuTKDU = value;
                    PropertyHasChanged("SoHieuTKDU");
                }
            }
        }

        public byte CongTru
        {
            get
            {
                CanReadProperty("CongTru", true);
                return _congTru;
            }
            set
            {
                CanWriteProperty("CongTru", true);
                if (!_congTru.Equals(value))
                {
                    _congTru = value;
                    PropertyHasChanged("CongTru");
                }
            }
        }

        public int MaMuc
        {
            get
            {
                CanReadProperty("MaMuc", true);
                return _maMuc;
            }
            set
            {
                CanWriteProperty("MaMuc", true);
                if (!_maMuc.Equals(value))
                {
                    _maMuc = value;
                    PropertyHasChanged("MaMuc");
                }
            }
        }

        public byte LoaiMau
        {
            get
            {
                CanReadProperty("LoaiMau", true);
                return _loaiMau;
            }
            set
            {
                CanWriteProperty("LoaiMau", true);
                if (!_loaiMau.Equals(value))
                {
                    _loaiMau = value;
                    PropertyHasChanged("LoaiMau");
                }
            }
        }

        public int MaMucLienQuan
        {
            get
            {
                CanReadProperty("MaMucLienQuan", true);
                return _maMucLienQuan;
            }
            set
            {
                CanWriteProperty("MaMucLienQuan", true);
                if (!_maMucLienQuan.Equals(value))
                {
                    _maMucLienQuan = value;
                    PropertyHasChanged("MaMucLienQuan");
                }
            }
        }

        public byte NoCo
        {
            get
            {
                CanReadProperty("NoCo", true);
                return _noCo;
            }
            set
            {
                CanWriteProperty("NoCo", true);
                if (!_noCo.Equals(value))
                {
                    _noCo = value;
                    PropertyHasChanged("NoCo");
                }
            }
        }

        public int LoaiHoatDong
        {
            get
            {
                CanReadProperty("LoaiHoatDong", true);
                return _loaiHoatDong;
            }
            set
            {
                CanWriteProperty("LoaiHoatDong", true);
                if (!_loaiHoatDong.Equals(value))
                {
                    _loaiHoatDong = value;
                    if (_loaiHoatDong != 0)
                        _loaiHoatDongString = CauTrucDoanhThuChiPhi.GetCauTrucDoanhThuChiPhi(_loaiHoatDong).Ten;
                    else
                        _loaiHoatDongString = "";
                    PropertyHasChanged("LoaiHoatDong");
                }
            }
        }

        public int MaHoatDong
        {
            get
            {
                CanReadProperty("MaHoatDong", true);
                return _maHoatDong;
            }
            set
            {
                CanWriteProperty("MaHoatDong", true);
                if (!_maHoatDong.Equals(value))
                {
                    _maHoatDong = value;
                    if (_maHoatDong != 0)
                        _maHoatDongString = HoatDong.GetHoatDong(_maHoatDong).TenHoatDong;
                    else
                        _maHoatDongString = "";
                    PropertyHasChanged("MaHoatDong");
                }
            }
        }

        public string LoaiHoatDongString
        {
            get
            {
                CanReadProperty("LoaiHoatDongString", true);
                return _loaiHoatDongString;
            }
        }

        public string MaHoatDongString
        {
            get
            {
                CanReadProperty("MaHoatDongString", true);
                return _maHoatDongString;
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
            // SoHieu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieu", 50));
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
            //TODO: Define authorization rules in CT_MauBangBaoCao
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("Loai", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoanDoiUng", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("SoHieu", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("CongTru", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("MaMuc", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("LoaiMau", "CT_MauBangBaoCaoReadGroup");
            //AuthorizationRules.AllowRead("MaMucLienQuan", "CT_MauBangBaoCaoReadGroup");

            //AuthorizationRules.AllowWrite("MaTaiKhoan", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoanDoiUng", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("SoHieu", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("CongTru", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("MaMuc", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiMau", "CT_MauBangBaoCaoWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucLienQuan", "CT_MauBangBaoCaoWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_MauBangBaoCaoH NewCT_MauBangBaoCaoH(int maChiTiet, byte loai)
        {
            return new CT_MauBangBaoCaoH(maChiTiet, loai);
        }
        public static CT_MauBangBaoCaoH NewCT_MauBangBaoCaoH(CT_MauBangBaoCaoH copy, byte loai)
        {
            return new CT_MauBangBaoCaoH(copy, loai);
        }
        internal static CT_MauBangBaoCaoH GetCT_MauBangBaoCaoH(SafeDataReader dr)
        {
            return new CT_MauBangBaoCaoH(dr);
        }

        private CT_MauBangBaoCaoH(int maChiTiet, byte loai)
        {
            this._maChiTiet = maChiTiet;
            this._loaiMau = loai;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_MauBangBaoCaoH(CT_MauBangBaoCaoH ctCopy, byte loai)
        {
            this._maTaiKhoan = ctCopy.MaTaiKhoan;
            this._loai = ctCopy.Loai;
            this._maTaiKhoanDoiUng = ctCopy.MaTaiKhoanDoiUng;
            this._soHieu = ctCopy.SoHieu;
            this._congTru = ctCopy.CongTru;
            //this._maMuc
            this._loaiMau = loai;
            //this._maMucLienQuan = ctCopy.MaMucLienQuan;
            this._noCo = ctCopy.NoCo;
            this._loaiHoatDong = ctCopy.LoaiHoatDong;
            this._maHoatDong = ctCopy.MaHoatDong;
            if (_loaiHoatDong != 0)
                _loaiHoatDongString = CauTrucDoanhThuChiPhi.GetCauTrucDoanhThuChiPhi(ctCopy.LoaiHoatDong).Ten;
            if (_maHoatDong != 0)
                _maHoatDongString = HoatDong.GetHoatDong(ctCopy.MaHoatDong).TenHoatDong;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_MauBangBaoCaoH(SafeDataReader dr)
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
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _loai = dr.GetByte("Loai");
            _maTaiKhoanDoiUng = dr.GetInt32("MaTaiKhoanDoiUng");
            _soHieu = dr.GetString("SoHieu");
            _congTru = dr.GetByte("CongTru");
            _maMuc = dr.GetInt32("MaMuc");
            _loaiMau = dr.GetByte("LoaiMau");
            _maMucLienQuan = dr.GetInt32("MaMucLienQuan");
            _soHieuTKDU = dr.GetString("SoHieuTKDU");
            _noCo = dr.GetByte("NoCo");
            _loaiHoatDong = dr.GetInt32("LoaiHoatDong");
            _loaiHoatDongString = dr.GetString("LoaiHoatDongString");
            _maHoatDong = dr.GetInt32("MaHoatDong");
            _maHoatDongString = dr.GetString("MaHoatDongString");
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert

        #region Bang Can doi ke toan
        internal void Insert(SqlTransaction tr, BangCanDoiKeToanH parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
        }

        private void ExecuteInsert(SqlTransaction tr, BangCanDoiKeToanH parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_AddCT_BangCanDoiKeToan1Child";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangCanDoiKeToanH parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maMuc = parent.MaMucTaiKhoan;
            //cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
            //if (_soHieu.Length > 0)
            //    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            //else
            //    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_soHieu.Trim() == "None")
            {
                _soHieu = "";
                if (_soHieu.Length > 0)
                    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                else
                    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            }
            else
            {
                if (_soHieu.Length > 0)
                    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                else
                    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            }
            if (_congTru != 0)
                cm.Parameters.AddWithValue("@CongTru", _congTru);
            else
                cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_loaiMau != 0)
                cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);
            else
                cm.Parameters.AddWithValue("@LoaiMau", DBNull.Value);
            if (_maMucLienQuan != 0)
                cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
            else
                cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
            if (_soHieuTKDU != "")
                cm.Parameters.AddWithValue("@SoHieuTKDU", _soHieuTKDU);
            else
                cm.Parameters.AddWithValue("@SoHieuTKDU", DBNull.Value);

            if (_loaiHoatDong != 0)
                cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            else
                cm.Parameters.AddWithValue("@LoaiHoatDong", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);

            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion //end region bang can doi ke toan

        #region Bang KQKDHD
        internal void Insert(SqlTransaction tr, BangKQHDKDH parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            MarkAsChild();
            //update child object(s)
        }

        private void ExecuteInsert(SqlTransaction tr, BangKQHDKDH parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_AddCT_BangCanDoiKeToan1Child";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangKQHDKDH parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maMuc = parent.MaMuc;
            //cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
            if (_maTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
            //if (_soHieu.Length > 0)
            //    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            //else
            //    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_soHieu.Trim() == "None")
            {
                _soHieu = "";
                if (_soHieu.Length > 0)
                    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                else
                    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            }
            else
            {
                if (_soHieu.Length > 0)
                    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                else
                    cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            }
            if (_congTru != 0)
                cm.Parameters.AddWithValue("@CongTru", _congTru);
            else
                cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_loaiMau != 0)
                cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);
            else
                cm.Parameters.AddWithValue("@LoaiMau", DBNull.Value);
            if (_maMucLienQuan != 0)
                cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
            else
                cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
            if (_soHieuTKDU != "")
                cm.Parameters.AddWithValue("@SoHieuTKDU", _soHieuTKDU);
            else
                cm.Parameters.AddWithValue("@SoHieuTKDU", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_loaiHoatDong != 0)
                cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            else
                cm.Parameters.AddWithValue("@LoaiHoatDong", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
        }
        #endregion //end region bang KQKDHD


        #endregion //Data Access - Insert

        #region Data Access - Update

        #region Bang can doi ke toan
        internal void Update(SqlTransaction tr, BangCanDoiKeToanH parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
        }

        private void ExecuteUpdate(SqlTransaction tr, BangCanDoiKeToanH parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateCT_BangCanDoiKeToan1Child";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangCanDoiKeToanH parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
            if (_soHieu.Length > 0)
                cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            else
                cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_congTru != 0)
                cm.Parameters.AddWithValue("@CongTru", _congTru);
            else
                cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_loaiMau != 0)
                cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);
            else
                cm.Parameters.AddWithValue("@LoaiMau", DBNull.Value);
            if (_maMucLienQuan != 0)
                cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
            else
                cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
            if (_soHieuTKDU != "")
                cm.Parameters.AddWithValue("@SoHieuTKDU", _soHieuTKDU);
            else
                cm.Parameters.AddWithValue("@SoHieuTKDU", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_loaiHoatDong != 0)
                cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            else
                cm.Parameters.AddWithValue("@LoaiHoatDong", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion //end bang can doi ke toan

        #region Bang KQHDKD
        internal void Update(SqlTransaction tr, BangKQHDKDH parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
        }

        private void ExecuteUpdate(SqlTransaction tr, BangKQHDKDH parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateCT_BangCanDoiKeToan1Child";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangKQHDKDH parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maTaiKhoanDoiUng != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", _maTaiKhoanDoiUng);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanDoiUng", DBNull.Value);
            if (_soHieu.Length > 0)
                cm.Parameters.AddWithValue("@SoHieu", _soHieu);
            else
                cm.Parameters.AddWithValue("@SoHieu", DBNull.Value);
            if (_congTru != 0)
                cm.Parameters.AddWithValue("@CongTru", _congTru);
            else
                cm.Parameters.AddWithValue("@CongTru", DBNull.Value);
            if (_maMuc != 0)
                cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            else
                cm.Parameters.AddWithValue("@MaMuc", DBNull.Value);
            if (_loaiMau != 0)
                cm.Parameters.AddWithValue("@LoaiMau", _loaiMau);
            else
                cm.Parameters.AddWithValue("@LoaiMau", DBNull.Value);
            if (_maMucLienQuan != 0)
                cm.Parameters.AddWithValue("@MaMucLienQuan", _maMucLienQuan);
            else
                cm.Parameters.AddWithValue("@MaMucLienQuan", DBNull.Value);
            if (_soHieuTKDU != "")
                cm.Parameters.AddWithValue("@SoHieuTKDU", _soHieuTKDU);
            else
                cm.Parameters.AddWithValue("@SoHieuTKDU", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_loaiHoatDong != 0)
                cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            else
                cm.Parameters.AddWithValue("@LoaiHoatDong", DBNull.Value);
            //cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion //end bang can doi ke toan

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
                cm.CommandText = "spd_DeleteCT_BangCanDoiKeToan1Child";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

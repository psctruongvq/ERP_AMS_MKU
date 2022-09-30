
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_MauBangBaoCao : Csla.BusinessBase<CT_MauBangBaoCao>
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
        private byte _loaiMau = 0;
        private int _maMucLienQuan = 0;
        private byte _noCo = 1;
        private int _loaiHoatDong = 0;
        private CT_MauBangBaoCao_HoatDongList _ct_MauBangBaoCao_HoatDongList = CT_MauBangBaoCao_HoatDongList.NewCT_MauBangBaoCao_HoatDongList();


        [System.ComponentModel.DataObjectField(true, false)]
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
                    PropertyHasChanged("LoaiHoatDong");
                }
            }
        }

        public CT_MauBangBaoCao_HoatDongList CT_MauBangBaoCao_HoatDongList
        {
            get
            {
                CanReadProperty("CT_MauBangBaoCao_HoatDongList", true);
                return _ct_MauBangBaoCao_HoatDongList;
            }
            set
            {
                CanWriteProperty("CT_MauBangBaoCao_HoatDongList", true);
                _ct_MauBangBaoCao_HoatDongList = value;
                PropertyHasChanged("CT_MauBangBaoCao_HoatDongList");

            }
        }


        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        public override bool IsValid
        {
            get { return base.IsValid && _ct_MauBangBaoCao_HoatDongList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _ct_MauBangBaoCao_HoatDongList.IsDirty; }
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
        public static CT_MauBangBaoCao NewCT_MauBangBaoCao(int maChiTiet, byte loai)
        {
            return new CT_MauBangBaoCao(maChiTiet, loai);
        }

        public static CT_MauBangBaoCao NewCT_MauBangBaoCao(CT_MauBangBaoCao ctCopy, byte loai)
        {
            return new CT_MauBangBaoCao(ctCopy, loai);
        }

        internal static CT_MauBangBaoCao GetCT_MauBangBaoCao(SafeDataReader dr)
        {
            return new CT_MauBangBaoCao(dr);
        }

        private CT_MauBangBaoCao(int maChiTiet, byte loai)
        {
            this._maChiTiet = maChiTiet;
            this._loaiMau = loai;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_MauBangBaoCao(CT_MauBangBaoCao ctCopy, byte loai)
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
            foreach (CT_MauBangBaoCao_HoatDong ct in ctCopy.CT_MauBangBaoCao_HoatDongList)
            {
                this._ct_MauBangBaoCao_HoatDongList.Add(CT_MauBangBaoCao_HoatDong.NewCT_MauBangBaoCao_HoatDong(ct));
            }
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_MauBangBaoCao(SafeDataReader dr)
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
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _loai = dr.GetByte("Loai");
            _maTaiKhoanDoiUng = dr.GetInt32("MaTaiKhoanDoiUng");
            _soHieu = dr.GetString("SoHieu");
            _congTru = dr.GetByte("CongTru");
            _maMuc = dr.GetInt32("MaMuc");
            _loaiMau = dr.GetByte("LoaiMau");
            _maMucLienQuan = dr.GetInt32("MaMucLienQuan");
            _noCo = dr.GetByte("NoCo");
            _loaiHoatDong = dr.GetInt32("LoaiHoatDong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _ct_MauBangBaoCao_HoatDongList = CT_MauBangBaoCao_HoatDongList.GetCT_MauBangBaoCao_HoatDongList(this.MaChiTiet);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert

        #region BCKQHoatDongKinhDoanh
        internal void Insert(SqlTransaction tr, BCKQHoatDongKinhDoanh parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BCKQHoatDongKinhDoanh parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_MauBangBaoCao";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BCKQHoatDongKinhDoanh parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maMuc = parent.MaMuc;
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }

        #endregion BCKQHoatDongKinhDoanh

        #region BangCanDoiKeToan
        internal void Insert(SqlTransaction tr, BangCanDoiKeToan parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BangCanDoiKeToan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_MauBangBaoCao";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangCanDoiKeToan parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maMuc = parent.MaMucTaiKhoan;
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion BangCanDoiKeToan

        #region BangTongHopTinhHinhKinhPhi
        internal void Insert(SqlTransaction tr, BangTongHopTinhHinhKinhPhi parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, BangTongHopTinhHinhKinhPhi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_MauBangBaoCao"; //"spd_InserttblCT_MauBangBaoCao";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangTongHopTinhHinhKinhPhi parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maMuc = parent.MaMucTaiKhoan;
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion BangTongHopTinhHinhKinhPhi

        #endregion //Data Access - Insert

        #region Data Access - Update
        #region BCKQHoatDongKinhDoanh

        internal void Update(SqlTransaction tr, BCKQHoatDongKinhDoanh parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BCKQHoatDongKinhDoanh parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_MauBangBaoCao";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BCKQHoatDongKinhDoanh parent)
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }

        #endregion BCKQHoatDongKinhDoanh

        #region BangCanDoiKeToan
        internal void Update(SqlTransaction tr, BangCanDoiKeToan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BangCanDoiKeToan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_MauBangBaoCao";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangCanDoiKeToan parent)
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #endregion BangCanDoiKeToan
        internal void Update(SqlTransaction tr, BangTongHopTinhHinhKinhPhi parent)
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

        private void ExecuteUpdate(SqlTransaction tr, BangTongHopTinhHinhKinhPhi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_MauBangBaoCao";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangTongHopTinhHinhKinhPhi parent)
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
            cm.Parameters.AddWithValue("@LoaiHoatDong", _loaiHoatDong);
            cm.Parameters.AddWithValue("@NoCo", _noCo);
        }
        #region BangTongHopTinhHinhKinhPhi

        #endregion BangTongHopTinhHinhKinhPhi

        private void UpdateChildren(SqlTransaction tr)
        {
            _ct_MauBangBaoCao_HoatDongList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _ct_MauBangBaoCao_HoatDongList.Clear();
            UpdateChildren(tr);
            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_MauBangBaoCao";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

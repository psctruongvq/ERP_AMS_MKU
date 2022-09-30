using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_DieuChuyenNoiBoCCDCChild : Csla.BusinessBase<CT_DieuChuyenNoiBoCCDCChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private int _maDieuChuyen = 0;
        private int _maCongCuDungCu = 0;
        private byte _lyDoDieuChuyen = 0;
        private string _hienTrang = string.Empty;
        private string _dienGiai = string.Empty;
        private int _maPhanBoCu = 0;
        private int _maPhanBoMoi = 0;
        private int _maTruongCu = 0;
        private int _maTruongMoi = 0;
        private int _maDuyetCongCuDungCu = 0;

        private bool _khongConDung = false;
        private bool _khongSuDung = false;

        private string _tenHangHoa = string.Empty;
        private string _MaQuanLy = string.Empty;

        private int _maBoPhanGiao = 0;
        private int _maBoPhanNhan = 0;
        private SmartDate _ngayDieuChuyen = new SmartDate(false);

        private CCDC_PhongBan _congCuDungCu_PhongBan = CCDC_PhongBan.NewCongCuDungCu_PhongBan();
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaDieuChuyen
        {
            get
            {
                CanReadProperty("MaDieuChuyen", true);
                return _maDieuChuyen;
            }
            set
            {
                CanWriteProperty("MaDieuChuyen", true);
                if (!_maDieuChuyen.Equals(value))
                {
                    _maDieuChuyen = value;
                    PropertyHasChanged("MaDieuChuyen");
                }
            }
        }

        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaCongCuDungCu", true);
                if (!_maCongCuDungCu.Equals(value))
                {
                    _maCongCuDungCu = value;
                    PropertyHasChanged("MaCongCuDungCu");
                }
            }
        }

        public byte LyDoDieuChuyen
        {
            get
            {
                CanReadProperty("LyDoDieuChuyen", true);
                return _lyDoDieuChuyen;
            }
            set
            {
                CanWriteProperty("LyDoDieuChuyen", true);
                if (!_lyDoDieuChuyen.Equals(value))
                {
                    _lyDoDieuChuyen = value;
                    PropertyHasChanged("LyDoDieuChuyen");
                }
            }
        }

        public string HienTrang
        {
            get
            {
                CanReadProperty("HienTrang", true);
                return _hienTrang;
            }
            set
            {
                CanWriteProperty("HienTrang", true);
                if (value == null) value = string.Empty;
                if (!_hienTrang.Equals(value))
                {
                    _hienTrang = value;
                    PropertyHasChanged("HienTrang");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public int MaPhanBoCu
        {
            get
            {
                CanReadProperty("MaPhanBoCu", true);
                return _maPhanBoCu;
            }
            set
            {
                CanWriteProperty("MaPhanBoCu", true);
                if (!_maPhanBoCu.Equals(value))
                {
                    _maPhanBoCu = value;
                    PropertyHasChanged("MaPhanBoCu");
                }
            }
        }

        public int MaPhanBoMoi
        {
            get
            {
                CanReadProperty("MaPhanBoMoi", true);
                return _maPhanBoMoi;
            }
            set
            {
                CanWriteProperty("MaPhanBoMoi", true);
                if (!_maPhanBoMoi.Equals(value))
                {
                    _maPhanBoMoi = value;
                    PropertyHasChanged("MaPhanBoMoi");
                }
            }
        }
        public int MaTruongCu
        {
            get
            {
                CanReadProperty("MaTruongCu", true);
                return _maTruongCu;
            }
            set
            {
                CanWriteProperty("MaTruongCu", true);
                if (!_maTruongCu.Equals(value))
                {
                    _maTruongCu = value;
                    PropertyHasChanged("MaTruongCu");
                }
            }
        }

        public int MaTruongMoi
        {
            get
            {
                CanReadProperty("MaTruongMoi", true);
                return _maTruongMoi;
            }
            set
            {
                CanWriteProperty("MaTruongMoi", true);
                if (!_maTruongMoi.Equals(value))
                {
                    _maTruongMoi = value;
                    PropertyHasChanged("MaTruongMoi");
                }
            }
        }

        public int MaDuyetCongCuDungCu
        {
            get
            {
                CanReadProperty("MaDuyetCongCuDungCu", true);
                return _maDuyetCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaDuyetCongCuDungCu", true);
                if (!_maDuyetCongCuDungCu.Equals(value))
                {
                    _maDuyetCongCuDungCu = value;
                    PropertyHasChanged("MaDuyetCongCuDungCu");
                }
            }
        }

        public bool KhongConDung
        {
            get
            {
                CanReadProperty("KhongConDung", true);
                return _khongConDung;
            }
            set
            {
                CanWriteProperty("KhongConDung", true);
                if (!_khongConDung.Equals(value))
                {
                    _khongConDung = value;
                    PropertyHasChanged("KhongConDung");
                    if (value == true)
                    {
                        _lyDoDieuChuyen = 1;
                    }

                    this._khongSuDung = !value;
                }
            }
        }

        public bool KhongSuDung
        {
            get
            {
                CanReadProperty("KhongSuDung", true);
                return _khongSuDung;
            }
            set
            {
                CanWriteProperty("KhongSuDung", true);
                if (!_khongSuDung.Equals(value))
                {
                    _khongSuDung = value;

                    PropertyHasChanged("KhongSuDung");
                    if (value == true)
                    {
                        _lyDoDieuChuyen = 2;

                    }
                    this._khongConDung = !value;
                }
            }
        }

        public string TenHangHoa
        {
            get
            {
                return _tenHangHoa;
            }
            set
            {
                _tenHangHoa = value;
            }
        }

        public string MaQuanLy
        {
            get{return _MaQuanLy;}
            set
            {
                _MaQuanLy = value;
            }
        }

        public CCDC_PhongBan CongCuDungCu_PhongBan
        {
            get
            {
                CanReadProperty("CongCuDungCu_PhongBanList", true);
                return _congCuDungCu_PhongBan;
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
            // HienTrang
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HienTrang", 1000));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
            //TODO: Define authorization rules in CT_DieuChuyenNoiBoCCDCChild
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaDieuChuyen", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("LyDoDieuChuyen", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("HienTrang", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhanBoCu", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaPhanBoMoi", "CT_DieuChuyenNoiBoCCDCChildReadGroup");
            //AuthorizationRules.AllowRead("MaDuyetCongCuDungCu", "CT_DieuChuyenNoiBoCCDCChildReadGroup");

            //AuthorizationRules.AllowWrite("MaDieuChuyen", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongCuDungCu", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("LyDoDieuChuyen", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("HienTrang", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhanBoCu", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaPhanBoMoi", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaDuyetCongCuDungCu", "CT_DieuChuyenNoiBoCCDCChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_DieuChuyenNoiBoCCDCChild NewCT_DieuChuyenNoiBoCCDCChild()
        {
            return new CT_DieuChuyenNoiBoCCDCChild();
        }

        internal static CT_DieuChuyenNoiBoCCDCChild GetCT_DieuChuyenNoiBoCCDCChild(SafeDataReader dr)
        {
            return new CT_DieuChuyenNoiBoCCDCChild(dr);
        }

        private CT_DieuChuyenNoiBoCCDCChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_DieuChuyenNoiBoCCDCChild(SafeDataReader dr)
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
            _maDieuChuyen = dr.GetInt32("MaDieuChuyen");
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _lyDoDieuChuyen = dr.GetByte("LyDoDieuChuyen");
            _hienTrang = dr.GetString("HienTrang");
            _dienGiai = dr.GetString("DienGiai");
            _maPhanBoCu = dr.GetInt32("MaPhanBoCu");
            _maPhanBoMoi = dr.GetInt32("MaPhanBoMoi");
            _maDuyetCongCuDungCu = dr.GetInt32("MaDuyetCongCuDungCu");

            if (_lyDoDieuChuyen == 1)
            {
                _khongConDung = true;
                _khongSuDung = false;
            }
            else if (_lyDoDieuChuyen == 2)
            {
                _khongConDung = false;
                _khongSuDung = true;

            }
            else
            {
                _khongConDung = false;
                _khongSuDung = false;
            }

            _tenHangHoa = dr.GetString("TenHangHoa");
            _MaQuanLy = dr.GetString("MaQuanLy");

        }

        private void FetchChildren(SafeDataReader dr)
        {
            _congCuDungCu_PhongBan = CCDC_PhongBan.GetCongCuDungCu_PhongBanbyMaCTDieuChuyenNoiBo(this._maChiTiet);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DieuChuyenNoiBoCCDC parent)
        {
            if (!IsDirty) return;
            ExecuteInsert(tr, parent);
            MarkOld();
            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DieuChuyenNoiBoCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_DieuChuyenNoiBoCCDC";

                AddInsertParameters(cm, parent);
                cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DieuChuyenNoiBoCCDC parent)
        {
            _maDieuChuyen = parent.MaDieuChuyen;//--
            _maBoPhanGiao = parent.MaBoPhanGiao;//
            _maBoPhanNhan = parent.MaBoPhanNhan;//
            _ngayDieuChuyen =new SmartDate(parent.NgayDieuChuyen);//
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDieuChuyen != 0)
                cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            else
                cm.Parameters.AddWithValue("@MaDieuChuyen", DBNull.Value);
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_lyDoDieuChuyen != 0)
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", _lyDoDieuChuyen);
            else
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", DBNull.Value);
            if (_hienTrang.Length > 0)
                cm.Parameters.AddWithValue("@HienTrang", _hienTrang);
            else
                cm.Parameters.AddWithValue("@HienTrang", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maPhanBoCu != 0)
                cm.Parameters.AddWithValue("@MaPhanBoCu", _maPhanBoCu);
            else
                cm.Parameters.AddWithValue("@MaPhanBoCu", DBNull.Value);
            if (_maPhanBoMoi != 0)
                cm.Parameters.AddWithValue("@MaPhanBoMoi", _maPhanBoMoi);
            else
                cm.Parameters.AddWithValue("@MaPhanBoMoi", DBNull.Value);
            if (_maTruongCu != 0)
                cm.Parameters.AddWithValue("@MaTruongCu", _maTruongCu);
            else
                cm.Parameters.AddWithValue("@MaTruongCu", DBNull.Value);
            if (_maTruongMoi != 0)
                cm.Parameters.AddWithValue("@MaTruongMoi", _maTruongMoi);
            else
                cm.Parameters.AddWithValue("@MaTruongMoi", DBNull.Value);
            if (_maDuyetCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DieuChuyenNoiBoCCDC parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DieuChuyenNoiBoCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_DieuChuyenNoiBoCCDC";
                AddUpdateParameters(cm, parent);
                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DieuChuyenNoiBoCCDC parent)
        {
            _maDieuChuyen = parent.MaDieuChuyen;//

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDieuChuyen != 0)
                cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            else
                cm.Parameters.AddWithValue("@MaDieuChuyen", DBNull.Value);
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_lyDoDieuChuyen != 0)
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", _lyDoDieuChuyen);
            else
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", DBNull.Value);
            if (_hienTrang.Length > 0)
                cm.Parameters.AddWithValue("@HienTrang", _hienTrang);
            else
                cm.Parameters.AddWithValue("@HienTrang", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_maPhanBoCu != 0)
                cm.Parameters.AddWithValue("@MaPhanBoCu", _maPhanBoCu);
            else
                cm.Parameters.AddWithValue("@MaPhanBoCu", DBNull.Value);
            if (_maPhanBoMoi != 0)
                cm.Parameters.AddWithValue("@MaPhanBoMoi", _maPhanBoMoi);
            else
                cm.Parameters.AddWithValue("@MaPhanBoMoi", DBNull.Value);
            if (_maTruongCu != 0)
                cm.Parameters.AddWithValue("@MaTruongCu", _maTruongCu);
            else
                cm.Parameters.AddWithValue("@MaTruongCu", DBNull.Value);
            if (_maTruongMoi != 0)
                cm.Parameters.AddWithValue("@MaTruongMoi", _maTruongMoi);
            else
                cm.Parameters.AddWithValue("@MaTruongMoi", DBNull.Value);
            if (_maDuyetCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", _maDuyetCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaDuyetCongCuDungCu", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            if (_congCuDungCu_PhongBan.IsNew)
                _congCuDungCu_PhongBan.Insert(tr, this,_maBoPhanNhan,_maTruongMoi,_ngayDieuChuyen);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
            _congCuDungCu_PhongBan.DeleteSelf(tr);//BS
            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_DieuChuyenNoiBoCCDC";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

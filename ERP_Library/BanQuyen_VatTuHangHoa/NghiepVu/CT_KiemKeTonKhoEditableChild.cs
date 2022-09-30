
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KiemKeTonKho : Csla.BusinessBase<CT_KiemKeTonKho>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTietKiemKe = 0;
        private long _maKiemKe = 0;
        private int _maHangHoa = 0;
        private decimal _sLSoSach = 0;
        private decimal _sLKiemKe = 0;
        private decimal _sLDieuChinh = 0;
        private decimal _giaTriSoSach = 0;
        private decimal _giaTriKiemKe = 0;
        private decimal _giaTriDieuChinh = 0;
        private bool _daDieuChinh = false;
        private string _dienGiai = string.Empty;

        private string _tenHangHoa = string.Empty;
        private string _maQuanLyHangHoa = string.Empty;
        private string _dVTHangHoa = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTietKiemKe
        {
            get
            {
                CanReadProperty("MaChiTietKiemKe", true);
                return _maChiTietKiemKe;
            }
        }

        public long MaKiemKe
        {
            get
            {
                CanReadProperty("MaKiemKe", true);
                return _maKiemKe;
            }
            set
            {
                CanWriteProperty("MaKiemKe", true);
                if (!_maKiemKe.Equals(value))
                {
                    _maKiemKe = value;
                    PropertyHasChanged("MaKiemKe");
                }
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }


        }

        public decimal SLSoSach
        {
            get
            {
                CanReadProperty("SLSoSach", true);
                return _sLSoSach;
            }
            set
            {
                CanWriteProperty("SLSoSach", true);
                if (!_sLSoSach.Equals(value))
                {
                    _sLSoSach = value;
                    _sLDieuChinh = _sLSoSach - _sLKiemKe;
                    PropertyHasChanged("SLSoSach");
                }
            }
        }

        public decimal SLKiemKe
        {
            get
            {
                CanReadProperty("SLKiemKe", true);
                return _sLKiemKe;
            }
            set
            {
                CanWriteProperty("SLKiemKe", true);
                if (!_sLKiemKe.Equals(value))
                {
                    _sLKiemKe = value;
                    _sLDieuChinh = _sLSoSach - _sLKiemKe;
                    PropertyHasChanged("SLKiemKe");
                }
            }
        }

        public decimal SLDieuChinh
        {
            get
            {
                CanReadProperty("SLDieuChinh", true);
                return _sLDieuChinh;
            }
            set
            {
                CanWriteProperty("SLDieuChinh", true);
                if (!_sLDieuChinh.Equals(value))
                {
                    _sLDieuChinh = value;
                    PropertyHasChanged("SLDieuChinh");
                }
            }
        }

        public decimal GiaTriSoSach
        {
            get
            {
                CanReadProperty("GiaTriSoSach", true);
                return _giaTriSoSach;
            }
            set
            {
                CanWriteProperty("GiaTriSoSach", true);
                if (!_giaTriSoSach.Equals(value))
                {
                    _giaTriSoSach = value;
                    _giaTriDieuChinh = _giaTriSoSach - _giaTriKiemKe;
                    PropertyHasChanged("GiaTriSoSach");
                }
            }
        }

        public decimal GiaTriKiemKe
        {
            get
            {
                CanReadProperty("GiaTriKiemKe", true);
                return _giaTriKiemKe;
            }
            set
            {
                CanWriteProperty("GiaTriKiemKe", true);
                if (!_giaTriKiemKe.Equals(value))
                {
                    _giaTriKiemKe = value;
                    _giaTriDieuChinh = _giaTriSoSach - _giaTriKiemKe;
                    PropertyHasChanged("GiaTriKiemKe");
                }
            }
        }

        public decimal GiaTriDieuChinh
        {
            get
            {
                CanReadProperty("GiaTriDieuChinh", true);
                return _giaTriDieuChinh;
            }
            set
            {
                CanWriteProperty("GiaTriDieuChinh", true);
                if (!_giaTriDieuChinh.Equals(value))
                {
                    _giaTriDieuChinh = value;
                    PropertyHasChanged("GiaTriDieuChinh");
                }
            }
        }

        public bool DaDieuChinh
        {
            get
            {
                CanReadProperty("DaDieuChinh", true);
                return _daDieuChinh;
            }
            set
            {
                CanWriteProperty("DaDieuChinh", true);
                if (!_daDieuChinh.Equals(value))
                {
                    _daDieuChinh = value;
                    PropertyHasChanged("DaDieuChinh");
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

        

        public string MaQuanLyHangHoa
        {
            get
            {
                CanReadProperty("MaQuanLyHangHoa", true);
                if (_maHangHoa != 0)
                {
                    HangHoaBQ_VT hh = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa);
                    _tenHangHoa = hh.TenHangHoa;
                    _maQuanLyHangHoa = hh.MaQuanLy;
                    if (hh.MaDonViTinh != 0)
                    {
                        _dVTHangHoa = DonViTinh.GetDonViTinh(hh.MaDonViTinh).TenDonViTinh;
                    }
                }
                return _maQuanLyHangHoa;
            }
        }
        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                
                return _tenHangHoa;
            }
        }

        public string DVTHangHoa
        {
            get
            {
                CanReadProperty("DVTHangHoa", true);
                return _dVTHangHoa;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTietKiemKe;
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
            //TODO: Define authorization rules in CT_KiemKeTonKho
            //AuthorizationRules.AllowRead("MaChiTietKiemKe", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("MaKiemKe", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("SLSoSach", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("SLKiemKe", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("SLDieuChinh", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("GiaTriSoSach", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("GiaTriKiemKe", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("GiaTriDieuChinh", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("DaDieuChinh", "CT_KiemKeTonKhoReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_KiemKeTonKhoReadGroup");

            //AuthorizationRules.AllowWrite("MaKiemKe", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("SLSoSach", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("SLKiemKe", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("SLDieuChinh", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTriSoSach", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTriKiemKe", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTriDieuChinh", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("DaDieuChinh", "CT_KiemKeTonKhoWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_KiemKeTonKhoWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_KiemKeTonKho NewCT_KiemKeTonKho()
        {
            return new CT_KiemKeTonKho();
        }

        internal static CT_KiemKeTonKho GetCT_KiemKeTonKho(SafeDataReader dr, bool _kieu)
        {
            return new CT_KiemKeTonKho(dr, _kieu);
        }



        private CT_KiemKeTonKho()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_KiemKeTonKho(SafeDataReader dr, bool _kieu)
        {
            MarkAsChild();
            Fetch(dr, _kieu);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool _kieu)
        {
            FetchObject(dr);
            if (_kieu == false)
                MarkNew();
            else MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTietKiemKe = dr.GetInt64("MaChiTietKiemKe");
            _maKiemKe = dr.GetInt64("MaKiemKe");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _sLSoSach = dr.GetDecimal("SLSoSach");
            _sLKiemKe = dr.GetDecimal("SLKiemKe");
            _sLDieuChinh = dr.GetDecimal("SLDieuChinh");
            _giaTriSoSach = dr.GetDecimal("GiaTriSoSach");
            _giaTriKiemKe = dr.GetDecimal("GiaTriKiemKe");
            _giaTriDieuChinh = dr.GetDecimal("GiaTriDieuChinh");
            _daDieuChinh = dr.GetBoolean("DaDieuChinh");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KiemKeTonKho parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KiemKeTonKho parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KiemKeTonKho";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietKiemKe = (long)cm.Parameters["@MaChiTietKiemKe"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KiemKeTonKho parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maKiemKe = parent.MaKiemKe;
            cm.Parameters.AddWithValue("@MaKiemKe", _maKiemKe);
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            if (_sLSoSach != 0)
                cm.Parameters.AddWithValue("@SLSoSach", _sLSoSach);
            else
                cm.Parameters.AddWithValue("@SLSoSach", DBNull.Value);
            if (_sLKiemKe != 0)
                cm.Parameters.AddWithValue("@SLKiemKe", _sLKiemKe);
            else
                cm.Parameters.AddWithValue("@SLKiemKe", DBNull.Value);


            cm.Parameters.AddWithValue("@SLDieuChinh", _sLDieuChinh);



            if (_giaTriSoSach != 0)
                cm.Parameters.AddWithValue("@GiaTriSoSach", _giaTriSoSach);
            else
                cm.Parameters.AddWithValue("@GiaTriSoSach", DBNull.Value);
            if (_giaTriKiemKe != 0)
                cm.Parameters.AddWithValue("@GiaTriKiemKe", _giaTriKiemKe);
            else
                cm.Parameters.AddWithValue("@GiaTriKiemKe", DBNull.Value);


            cm.Parameters.AddWithValue("@GiaTriDieuChinh", _giaTriDieuChinh);

            cm.Parameters.AddWithValue("@DaDieuChinh", _daDieuChinh);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietKiemKe", _maChiTietKiemKe);
            cm.Parameters["@MaChiTietKiemKe"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KiemKeTonKho parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KiemKeTonKho parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KiemKeTonKho";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KiemKeTonKho parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietKiemKe", _maChiTietKiemKe);
            cm.Parameters.AddWithValue("@MaKiemKe", _maKiemKe);
            cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            if (_sLSoSach != 0)
                cm.Parameters.AddWithValue("@SLSoSach", _sLSoSach);
            else
                cm.Parameters.AddWithValue("@SLSoSach", DBNull.Value);
            if (_sLKiemKe != 0)
                cm.Parameters.AddWithValue("@SLKiemKe", _sLKiemKe);
            else
                cm.Parameters.AddWithValue("@SLKiemKe", DBNull.Value);
            if (_sLDieuChinh != 0)
                cm.Parameters.AddWithValue("@SLDieuChinh", _sLDieuChinh);
            else
                cm.Parameters.AddWithValue("@SLDieuChinh", DBNull.Value);
            if (_giaTriSoSach != 0)
                cm.Parameters.AddWithValue("@GiaTriSoSach", _giaTriSoSach);
            else
                cm.Parameters.AddWithValue("@GiaTriSoSach", DBNull.Value);
            if (_giaTriKiemKe != 0)
                cm.Parameters.AddWithValue("@GiaTriKiemKe", _giaTriKiemKe);
            else
                cm.Parameters.AddWithValue("@GiaTriKiemKe", DBNull.Value);
            if (_giaTriDieuChinh != 0)
                cm.Parameters.AddWithValue("@GiaTriDieuChinh", _giaTriDieuChinh);
            else
                cm.Parameters.AddWithValue("@GiaTriDieuChinh", DBNull.Value);
            cm.Parameters.AddWithValue("@DaDieuChinh", _daDieuChinh);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_KiemKeTonKho";

                cm.Parameters.AddWithValue("@MaChiTietKiemKe", this._maChiTietKiemKe);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Windows.Forms;
//13_04_2013
namespace ERP_Library//05012016
{
    [Serializable()]
    public class CT_PhieuDeNghiXuatDongPhuc : Csla.BusinessBase<CT_PhieuDeNghiXuatDongPhuc>
    {
        #region Business Properties and Methods

        //declare members
        public bool Check { get; set; }
        private int _maChiTiet = 0;
        private int _maDeNghiXuat = 0;
        private int _maHangHoa = 0;
        private decimal _soLuong = 0;
        private int _maDonViTinh = 0;
        private string _dienGiai = string.Empty;

        private int _MaNhomHangHoa = 0;
        private Guid _oidMaBienLai = Guid.Empty;
        private Guid _oidChiTietBienLai = Guid.Empty;
        private int _iDBienLai = 0;
        private long _iDChiTietBienLai = 0;


        public int MaNhomHangHoa
        {
            get
            {
                CanReadProperty("MaNhomHangHoa", true);
                return _MaNhomHangHoa;
            }
            set
            {
                CanWriteProperty("MaNhomHangHoa", true);
                if (!_MaNhomHangHoa.Equals(value))
                {
                    _MaNhomHangHoa = value;
                    PropertyHasChanged("MaNhomHangHoa");
                }
            }
        }
        public Guid OidMaBienLai
        {
            get
            {
                CanReadProperty("OidMaBienLai", true);
                return _oidMaBienLai;
            }
            set
            {
                CanWriteProperty("OidMaBienLai", true);
                if (!_oidMaBienLai.Equals(value))
                {
                    _oidMaBienLai = value;
                    PropertyHasChanged("OidMaBienLai");
                }
            }
        }

        public Guid OidChiTietBienLai
        {
            get
            {
                CanReadProperty("OidChiTietBienLai", true);
                return _oidChiTietBienLai;
            }
            set
            {
                CanWriteProperty("OidChiTietBienLai", true);
                if (!_oidChiTietBienLai.Equals(value))
                {
                    _oidChiTietBienLai = value;
                    PropertyHasChanged("OidChiTietBienLai");
                }
            }
        }

        public int IDBienLai
        {
            get
            {
                CanReadProperty("IDBienLai", true);
                return _iDBienLai;
            }
            set
            {
                CanWriteProperty("IDBienLai", true);
                if (!_iDBienLai.Equals(value))
                {
                    _iDBienLai = value;
                    PropertyHasChanged("IDBienLai");
                }
            }
        }

        public long IDChiTietBienLai
        {
            get
            {
                CanReadProperty("IDChiTietBienLai", true);
                return _iDChiTietBienLai;
            }
            set
            {
                CanWriteProperty("IDChiTietBienLai", true);
                if (!_iDChiTietBienLai.Equals(value))
                {
                    _iDChiTietBienLai = value;
                    PropertyHasChanged("IDChiTietBienLai");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaDeNghiXuat
        {
            get
            {
                CanReadProperty("MaDeNghiXuat", true);
                return _maDeNghiXuat;
            }
            set
            {
                CanWriteProperty("MaDeNghiXuat", true);
                if (!_maDeNghiXuat.Equals(value))
                {
                    _maDeNghiXuat = value;
                    PropertyHasChanged("MaDeNghiXuat");
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

        public decimal SoLuong
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
                    PropertyHasChanged("SoLuong");
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
            //TODO: Define authorization rules in CT_PhieuDeNghiXuatDongPhuc
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_PhieuDeNghiXuatDongPhucReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghiXuat", "CT_PhieuDeNghiXuatDongPhucReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuDeNghiXuatDongPhucReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_PhieuDeNghiXuatDongPhucReadGroup");
            //AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuDeNghiXuatDongPhucReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_PhieuDeNghiXuatDongPhucReadGroup");

            //AuthorizationRules.AllowWrite("MaDeNghiXuat", "CT_PhieuDeNghiXuatDongPhucWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuDeNghiXuatDongPhucWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_PhieuDeNghiXuatDongPhucWriteGroup");
            //AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuDeNghiXuatDongPhucWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_PhieuDeNghiXuatDongPhucWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_PhieuDeNghiXuatDongPhuc NewCT_PhieuDeNghiXuatDongPhuc()
        {
            return new CT_PhieuDeNghiXuatDongPhuc();
        }
        internal static CT_PhieuDeNghiXuatDongPhuc GetCT_PhieuDeNghiXuatDongPhuc(SafeDataReader dr)
        {
            return new CT_PhieuDeNghiXuatDongPhuc(dr);
        }

        private CT_PhieuDeNghiXuatDongPhuc()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_PhieuDeNghiXuatDongPhuc(SafeDataReader dr)
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
            _maDeNghiXuat = dr.GetInt32("MaDeNghiXuat");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _soLuong = dr.GetDecimal("SoLuong");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _dienGiai = dr.GetString("DienGiai");
            _iDBienLai = dr.GetInt32("IDBienLai");
            _iDChiTietBienLai = dr.GetInt64("IDChiTietBienLai");
            //_MaNhomHangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).MaNhomHangHoa;

        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuDeNghiXuatDongPhuc parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuDeNghiXuatDongPhuc parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuDeNghiXuatDongPhuc";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuDeNghiXuatDongPhuc parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
                cm.Parameters.AddWithValue("@MaDeNghiXuat", parent.MaDeNghiXuat);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_oidMaBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
            else
                cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
            if (_oidChiTietBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
            if (_iDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
            if (_iDChiTietBienLai != 0)
                cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuDeNghiXuatDongPhuc parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuDeNghiXuatDongPhuc parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuDeNghiXuatDongPhuc";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuDeNghiXuatDongPhuc parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDeNghiXuat != 0)
                cm.Parameters.AddWithValue("@MaDeNghiXuat", _maDeNghiXuat);
            else
                cm.Parameters.AddWithValue("@MaDeNghiXuat", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_oidMaBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidMaBienLai", _oidMaBienLai);
            else
                cm.Parameters.AddWithValue("@OidMaBienLai", DBNull.Value);
            if (_oidChiTietBienLai != Guid.Empty)
                cm.Parameters.AddWithValue("@OidChiTietBienLai", _oidChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@OidChiTietBienLai", DBNull.Value);
            if (_iDBienLai != 0)
                cm.Parameters.AddWithValue("@IDBienLai", _iDBienLai);
            else
                cm.Parameters.AddWithValue("@IDBienLai", DBNull.Value);
            if (_iDChiTietBienLai != 0)
                cm.Parameters.AddWithValue("@IDChiTietBienLai", _iDChiTietBienLai);
            else
                cm.Parameters.AddWithValue("@IDChiTietBienLai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_PhieuDeNghiXuatDongPhuc";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

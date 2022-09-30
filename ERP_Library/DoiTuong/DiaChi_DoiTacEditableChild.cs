
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DiaChi_DoiTac : Csla.BusinessBase<DiaChi_DoiTac>
    {

        #region Business Properties and Methods

        //declare members
        private long _maDoiTac = 0;
        private string _tenDiaChi = string.Empty;
        private int _maQuanHuyen = 0;
        private string _quanHuyen = string.Empty;
        private int _maTinhThanh = 0;
        private string _tinhTP = string.Empty;
        private int _maQuocGia = 0;
        private string _quocGia = string.Empty;
        private int _maDiaChi = 0;
        private int _maChiTiet = 0;
        private bool _active = true;
        private string _tenDiaChiChung = string.Empty;

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
        public string TenDiaChi
        {
            get
            {
                CanReadProperty("TenDiaChi", true);
                return _tenDiaChi;
            }
            set
            {
                CanWriteProperty("TenDiaChi", true);
                if (value == null) value = string.Empty;
                if (!_tenDiaChi.Equals(value))
                {
                    _tenDiaChi = value;
                    PropertyHasChanged("TenDiaChi");
                }
            }
        }

        public int MaQuanHuyen
        {
            get
            {
                CanReadProperty("MaQuanHuyen", true);
                return _maQuanHuyen;
            }
            set
            {
                CanWriteProperty("MaQuanHuyen", true);
                if (!_maQuanHuyen.Equals(value))
                {
                    _maQuanHuyen = value;
                    PropertyHasChanged("MaQuanHuyen");
                }
            }
        }

        public string QuanHuyen
        {
            get
            {
                CanReadProperty("QuanHuyen", true);
                if (_maQuanHuyen != 0)
                {
                    _quanHuyen = ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).TenQuanHuyen;
                }
                return _quanHuyen;
            }
            set
            {
                CanWriteProperty("QuanHuyen", true);
                if (value == null) value = string.Empty;
                if (!_quanHuyen.Equals(value))
                {
                    _quanHuyen = value;
                    PropertyHasChanged("QuanHuyen");
                }
            }
        }

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
                if (_maQuanHuyen != 0)
                {
                    _maTinhThanh = ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).MaTinhThanh;
                }
                return _maTinhThanh;
            }
            set
            {
                CanWriteProperty("MaTinhThanh", true);
                if (!_maTinhThanh.Equals(value))
                {
                    _maTinhThanh = value;
                    PropertyHasChanged("MaTinhThanh");
                }
            }
        }

        public string TinhTP
        {
            get
            {
                CanReadProperty("TinhTP", true);
                if (MaTinhThanh != 0)
                {
                    _tinhTP = TinhThanh.GetTinhThanh(MaTinhThanh).TenTinhThanh;
                }
                return _tinhTP;
            }
            set
            {
                CanWriteProperty("TinhTP", true);
                if (value == null) value = string.Empty;
                if (!_tinhTP.Equals(value))
                {
                    _tinhTP = value;
                    PropertyHasChanged("TinhTP");
                }
            }
        }

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                if (_maTinhThanh != 0)
                {
                    _maQuocGia = TinhThanh.GetTinhThanh(ERP_Library.QuanHuyen.GetQuanHuyen(_maQuanHuyen).MaTinhThanh).MaQuocGia;
                }
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public string QuocGia
        {
            get
            {
                CanReadProperty("QuocGia", true);
                if (MaQuocGia != 0)
                {
                    _quocGia = ERP_Library.QuocGia.GetQuocGia(_maQuocGia).TenQuocGia;
                }
                return _quocGia;
            }
            set
            {
                CanWriteProperty("QuocGia", true);
                if (value == null) value = string.Empty;
                if (!_quocGia.Equals(value))
                {
                    _quocGia = value;
                    PropertyHasChanged("QuocGia");
                }
            }
        }

        public bool Active
        {
            get
            {
                CanReadProperty("Active", true);
                return _active;
            }
            set
            {
                CanWriteProperty("Active", true);
                if (!_active.Equals(value))
                {
                    _active = value;
                    PropertyHasChanged("Active");
                }
            }
        }

        public string TenDiaChiChung
        {
            get
            {
                CanReadProperty("TenDiaChiChung", true);
                return _tenDiaChiChung;
            }
            set
            {
                CanWriteProperty("TenDiaChiChung", true);
                if (value == null) value = string.Empty;
                if (!_tenDiaChiChung.Equals(value))
                {
                    _tenDiaChiChung = value;
                    PropertyHasChanged("TenDiaChiChung");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaDiaChi
        {
            get
            {
                CanReadProperty("MaDiaChi", true);
                return _maDiaChi;
            }
            set
            {
                CanWriteProperty("MaDiaChi", true);
                if (!_maDiaChi.Equals(value))
                {
                    _maDiaChi = value;
                    PropertyHasChanged("MaDiaChi");
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
            // TenDiaChi
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenDiaChi");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDiaChi", 500));
            //
            // QuanHuyen
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "QuanHuyen");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHuyen", 50));
            //
            // TinhTP
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TinhTP");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTP", 50));
            //
            // QuocGia
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "QuocGia");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuocGia", 50));
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
            //TODO: Define authorization rules in DiaChi_DoiTac
            //AuthorizationRules.AllowRead("MaDoiTac", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TenDiaChi", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("QuanHuyen", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("TinhTP", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("QuocGia", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaChiTiet", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("MaDiaChi", "DiaChi_DoiTacReadGroup");
            //AuthorizationRules.AllowRead("Active", "DiaChi_DoiTacReadGroup");

            //AuthorizationRules.AllowWrite("MaDoiTac", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TenDiaChi", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("QuanHuyen", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTP", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("QuocGia", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("MaDiaChi", "DiaChi_DoiTacWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "DiaChi_DoiTacWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static DiaChi_DoiTac NewDiaChi_DoiTac()
        {
            return new DiaChi_DoiTac();
        }

        public static DiaChi_DoiTac GetDiaChi_DoiTac(SafeDataReader dr)
        {
            return new DiaChi_DoiTac(dr);
        }

        public DiaChi_DoiTac()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public DiaChi_DoiTac(SafeDataReader dr)
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
            _maDoiTac = dr.GetInt64("MaDoiTac");
            _tenDiaChi = dr.GetString("TenDiaChi");
            _quanHuyen = dr.GetString("QuanHuyen");
            _tinhTP = dr.GetString("TinhTP");
            _quocGia = dr.GetString("QuocGia");
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maDiaChi = dr.GetInt32("MaDiaChi");
            _active = dr.GetBoolean("Active");
            _tenDiaChiChung = _tenDiaChi + " " + _quanHuyen + " " + _tinhTP + " " + _quocGia;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DoiTac parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDiaChi_DoiTac";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                _maDiaChi = (int)cm.Parameters["@MaDiaChi"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DoiTac parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent			
            cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
            cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
            cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            cm.Parameters.AddWithValue("@QuocGia", _quocGia);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

            cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            cm.Parameters["@MaDiaChi"].Direction = ParameterDirection.Output;

            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);

        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DoiTac parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDiaChi_DoiTac";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
        {
            cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
            cm.Parameters.AddWithValue("@TenDiaChi", _tenDiaChi);
            cm.Parameters.AddWithValue("@QuanHuyen", _quanHuyen);
            cm.Parameters.AddWithValue("@TinhTP", _tinhTP);
            cm.Parameters.AddWithValue("@QuocGia", _quocGia);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDiaChi != 0)
                cm.Parameters.AddWithValue("@MaDiaChi", _maDiaChi);
            else
                cm.Parameters.AddWithValue("@MaDiaChi", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDiaChi_DoiTac";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);
                //cm.Parameters.AddWithValue("@MaDoiTac", this._maDoiTac);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

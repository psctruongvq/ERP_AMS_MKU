
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNganHangChild : Csla.BusinessBase<ThongTinNganHangChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maTTNH = 0;
        private int _maNganHang = 0;
        private string _diaChi = string.Empty;
        private string _swiftCode = string.Empty;
        private string _sortCode = string.Empty;
        private string _blz = string.Empty;
        private string _fedwire = string.Empty;
        private string _chips = string.Empty;
        private string _bsb = string.Empty;
        private string _ghiChuKhac = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaTTNH
        {
            get
            {
                CanReadProperty("MaTTNH", true);
                return _maTTNH;
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

        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }
        }

        public string SwiftCode
        {
            get
            {
                CanReadProperty("SwiftCode", true);
                return _swiftCode;
            }
            set
            {
                CanWriteProperty("SwiftCode", true);
                if (value == null) value = string.Empty;
                if (!_swiftCode.Equals(value))
                {
                    _swiftCode = value;
                    PropertyHasChanged("SwiftCode");
                }
            }
        }

        public string SortCode
        {
            get
            {
                CanReadProperty("SortCode", true);
                return _sortCode;
            }
            set
            {
                CanWriteProperty("SortCode", true);
                if (value == null) value = string.Empty;
                if (!_sortCode.Equals(value))
                {
                    _sortCode = value;
                    PropertyHasChanged("SortCode");
                }
            }
        }

        public string Blz
        {
            get
            {
                CanReadProperty("Blz", true);
                return _blz;
            }
            set
            {
                CanWriteProperty("Blz", true);
                if (value == null) value = string.Empty;
                if (!_blz.Equals(value))
                {
                    _blz = value;
                    PropertyHasChanged("Blz");
                }
            }
        }

        public string Fedwire
        {
            get
            {
                CanReadProperty("Fedwire", true);
                return _fedwire;
            }
            set
            {
                CanWriteProperty("Fedwire", true);
                if (value == null) value = string.Empty;
                if (!_fedwire.Equals(value))
                {
                    _fedwire = value;
                    PropertyHasChanged("Fedwire");
                }
            }
        }

        public string Chips
        {
            get
            {
                CanReadProperty("Chips", true);
                return _chips;
            }
            set
            {
                CanWriteProperty("Chips", true);
                if (value == null) value = string.Empty;
                if (!_chips.Equals(value))
                {
                    _chips = value;
                    PropertyHasChanged("Chips");
                }
            }
        }

        public string Bsb
        {
            get
            {
                CanReadProperty("Bsb", true);
                return _bsb;
            }
            set
            {
                CanWriteProperty("Bsb", true);
                if (value == null) value = string.Empty;
                if (!_bsb.Equals(value))
                {
                    _bsb = value;
                    PropertyHasChanged("Bsb");
                }
            }
        }

        public string GhiChuKhac
        {
            get
            {
                CanReadProperty("GhiChuKhac", true);
                return _ghiChuKhac;
            }
            set
            {
                CanWriteProperty("GhiChuKhac", true);
                if (value == null) value = string.Empty;
                if (!_ghiChuKhac.Equals(value))
                {
                    _ghiChuKhac = value;
                    PropertyHasChanged("GhiChuKhac");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maTTNH;
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
            // DiaChi
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 500));
            //
            // SwiftCode
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SwiftCode", 100));
            //
            // SortCode
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SortCode", 100));
            //
            // Blz
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Blz", 100));
            //
            // Fedwire
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Fedwire", 200));
            //
            // Chips
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Chips", 200));
            //
            // Bsb
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Bsb", 200));
            //
            // GhiChuKhac
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChuKhac", 200));
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
            //TODO: Define authorization rules in ThongTinNganHangChild
            //AuthorizationRules.AllowRead("MaTTNH", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("MaNganHang", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("DiaChi", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("SwiftCode", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("SortCode", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("Blz", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("Fedwire", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("Chips", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("Bsb", "ThongTinNganHangChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChuKhac", "ThongTinNganHangChildReadGroup");

            //AuthorizationRules.AllowWrite("MaNganHang", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("DiaChi", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("SwiftCode", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("SortCode", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("Blz", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("Fedwire", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("Chips", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("Bsb", "ThongTinNganHangChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChuKhac", "ThongTinNganHangChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ThongTinNganHangChild NewThongTinNganHangChild()
        {
            return new ThongTinNganHangChild();
        }

        internal static ThongTinNganHangChild GetThongTinNganHangChild(SafeDataReader dr)
        {
            return new ThongTinNganHangChild(dr);
        }

        private ThongTinNganHangChild()
        {
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ThongTinNganHangChild(SafeDataReader dr)
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
            _maTTNH = dr.GetInt64("MaTTNH");
            _maNganHang = dr.GetInt32("MaTKNganHang");
            _diaChi = dr.GetString("DiaChi");
            _swiftCode = dr.GetString("SwiftCode");
            _sortCode = dr.GetString("SortCode");
            _blz = dr.GetString("BLZ");
            _fedwire = dr.GetString("Fedwire");
            _chips = dr.GetString("Chips");
            _bsb = dr.GetString("BSB");
            _ghiChuKhac = dr.GetString("GhiChuKhac");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, TK_NganHang parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, TK_NganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThongTinNganHang";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maTTNH = (long)cm.Parameters["@MaTTNH"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, TK_NganHang parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaTKNganHang != 0)
                cm.Parameters.AddWithValue("@MaTKNganHang", parent.MaTKNganHang);
            else
                cm.Parameters.AddWithValue("@MaTKNganHang", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_swiftCode.Length > 0)
                cm.Parameters.AddWithValue("@SwiftCode", _swiftCode);
            else
                cm.Parameters.AddWithValue("@SwiftCode", DBNull.Value);
            if (_sortCode.Length > 0)
                cm.Parameters.AddWithValue("@SortCode", _sortCode);
            else
                cm.Parameters.AddWithValue("@SortCode", DBNull.Value);
            if (_blz.Length > 0)
                cm.Parameters.AddWithValue("@BLZ", _blz);
            else
                cm.Parameters.AddWithValue("@BLZ", DBNull.Value);
            if (_fedwire.Length > 0)
                cm.Parameters.AddWithValue("@Fedwire", _fedwire);
            else
                cm.Parameters.AddWithValue("@Fedwire", DBNull.Value);
            if (_chips.Length > 0)
                cm.Parameters.AddWithValue("@Chips", _chips);
            else
                cm.Parameters.AddWithValue("@Chips", DBNull.Value);
            if (_bsb.Length > 0)
                cm.Parameters.AddWithValue("@BSB", _bsb);
            else
                cm.Parameters.AddWithValue("@BSB", DBNull.Value);
            if (_ghiChuKhac.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuKhac", _ghiChuKhac);
            else
                cm.Parameters.AddWithValue("@GhiChuKhac", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTTNH", _maTTNH);
            cm.Parameters["@MaTTNH"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, TK_NganHang parent)
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

        private void ExecuteUpdate(SqlTransaction tr, TK_NganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsThongTinNganHang";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, TK_NganHang parent)
        {
            cm.Parameters.AddWithValue("@MaTTNH", _maTTNH);
            if (parent.MaTKNganHang != 0)
                cm.Parameters.AddWithValue("@MaTKNganHang", parent.MaTKNganHang);
            else
                cm.Parameters.AddWithValue("@MaTKNganHang", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_swiftCode.Length > 0)
                cm.Parameters.AddWithValue("@SwiftCode", _swiftCode);
            else
                cm.Parameters.AddWithValue("@SwiftCode", DBNull.Value);
            if (_sortCode.Length > 0)
                cm.Parameters.AddWithValue("@SortCode", _sortCode);
            else
                cm.Parameters.AddWithValue("@SortCode", DBNull.Value);
            if (_blz.Length > 0)
                cm.Parameters.AddWithValue("@BLZ", _blz);
            else
                cm.Parameters.AddWithValue("@BLZ", DBNull.Value);
            if (_fedwire.Length > 0)
                cm.Parameters.AddWithValue("@Fedwire", _fedwire);
            else
                cm.Parameters.AddWithValue("@Fedwire", DBNull.Value);
            if (_chips.Length > 0)
                cm.Parameters.AddWithValue("@Chips", _chips);
            else
                cm.Parameters.AddWithValue("@Chips", DBNull.Value);
            if (_bsb.Length > 0)
                cm.Parameters.AddWithValue("@BSB", _bsb);
            else
                cm.Parameters.AddWithValue("@BSB", DBNull.Value);
            if (_ghiChuKhac.Length > 0)
                cm.Parameters.AddWithValue("@GhiChuKhac", _ghiChuKhac);
            else
                cm.Parameters.AddWithValue("@GhiChuKhac", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsThongTinNganHang";

                cm.Parameters.AddWithValue("@MaTTNH", this._maTTNH);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

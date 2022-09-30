using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    public class LichHocDaoTao : Csla.BusinessBase<LichHocDaoTao>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLichHoc = 0;
        private SmartDate _ngayApDung = new SmartDate(DateTime.Today);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.Today);//
        private string _thu2 = string.Empty;
        private decimal _time2 = 0;
        private string _thu3 = string.Empty;
        private decimal _time3 = 0;
        private string _thu4 = string.Empty;
        private decimal _time4 = 0;
        private string _thu5 = string.Empty;
        private decimal _time5 = 0;
        private string _thu6 = string.Empty;
        private decimal _time6 = 0;
        private string _thu7 = string.Empty;
        private decimal _time7 = 0;
        private string _chuNhat = string.Empty;
        private decimal _timeCN = 0;
        private int _maDeCu = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaLichHoc
        {
            get
            {
                CanReadProperty("MaLichHoc", true);
                return _maLichHoc;
            }
        }

        [DisplayName("Ngày áp dụng")]
        public DateTime? NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                if (_ngayApDung.Date == DateTime.MinValue)
                    return null;
                return _ngayApDung.Date;
            }
            set
            {
                CanWriteProperty("NgayApDung", true);
                if (!_ngayApDung.Equals(value))
                {
                    if (value == null)
                        _ngayApDung = new SmartDate(DateTime.MinValue);
                    else
                        _ngayApDung = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Ngày kết thúc")]
        public DateTime? NgayKetThuc
        {
            get
            {
                CanReadProperty("NgayKetThuc", true);
                if (_ngayKetThuc.Date == DateTime.MinValue)
                    return null;
                return _ngayKetThuc.Date;
            }
            set
            {
                CanWriteProperty("NgayKetThuc", true);
                if (!_ngayKetThuc.Equals(value))
                {
                    if (value == null)
                        _ngayKetThuc = new SmartDate(DateTime.MinValue);
                    else
                        _ngayKetThuc = new SmartDate(value.Value.Date);
                    PropertyHasChanged();
                }
            }
        }

        [DisplayName("Thứ 2")]
        public string Thu2
        {
            get
            {
                CanReadProperty("Thu2", true);
                return _thu2;
            }
            set
            {
                CanWriteProperty("Thu2", true);
                if (value == null) value = string.Empty;
                if (!_thu2.Equals(value))
                {
                    _thu2 = value;
                    PropertyHasChanged("Thu2");
                }
            }
        }

        [DisplayName("T2(h)")]
        public decimal Time2
        {
            get
            {
                CanReadProperty("Time2", true);
                return _time2;
            }
            set
            {
                CanWriteProperty("Time2", true);
                if (!_time2.Equals(value))
                {
                    _time2 = value;
                    PropertyHasChanged("Time2");
                }
            }
        }

        [DisplayName("Thứ 3")]
        public string Thu3
        {
            get
            {
                CanReadProperty("Thu3", true);
                return _thu3;
            }
            set
            {
                CanWriteProperty("Thu3", true);
                if (value == null) value = string.Empty;
                if (!_thu3.Equals(value))
                {
                    _thu3 = value;
                    PropertyHasChanged("Thu3");
                }
            }
        }

        [DisplayName("T3(h)")]
        public decimal Time3
        {
            get
            {
                CanReadProperty("Time3", true);
                return _time3;
            }
            set
            {
                CanWriteProperty("Time3", true);
                if (!_time3.Equals(value))
                {
                    _time3 = value;
                    PropertyHasChanged("Time3");
                }
            }
        }

        [DisplayName("Thứ 4")]
        public string Thu4
        {
            get
            {
                CanReadProperty("Thu4", true);
                return _thu4;
            }
            set
            {
                CanWriteProperty("Thu4", true);
                if (value == null) value = string.Empty;
                if (!_thu4.Equals(value))
                {
                    _thu4 = value;
                    PropertyHasChanged("Thu4");
                }
            }
        }

        [DisplayName("T4(h)")]
        public decimal Time4
        {
            get
            {
                CanReadProperty("Time4", true);
                return _time4;
            }
            set
            {
                CanWriteProperty("Time4", true);
                if (!_time4.Equals(value))
                {
                    _time4 = value;
                    PropertyHasChanged("Time4");
                }
            }
        }

        [DisplayName("Thứ 5")]
        public string Thu5
        {
            get
            {
                CanReadProperty("Thu5", true);
                return _thu5;
            }
            set
            {
                CanWriteProperty("Thu5", true);
                if (value == null) value = string.Empty;
                if (!_thu5.Equals(value))
                {
                    _thu5 = value;
                    PropertyHasChanged("Thu5");
                }
            }
        }
        [DisplayName("T5(h)")]
        public decimal Time5
        {
            get
            {
                CanReadProperty("Time5", true);
                return _time5;
            }
            set
            {
                CanWriteProperty("Time5", true);
                if (!_time5.Equals(value))
                {
                    _time5 = value;
                    PropertyHasChanged("Time5");
                }
            }
        }

        [DisplayName("Thứ 6")]
        public string Thu6
        {
            get
            {
                CanReadProperty("Thu6", true);
                return _thu6;
            }
            set
            {
                CanWriteProperty("Thu6", true);
                if (value == null) value = string.Empty;
                if (!_thu6.Equals(value))
                {
                    _thu6 = value;
                    PropertyHasChanged("Thu6");
                }
            }
        }
        [DisplayName("T6(h)")]
        public decimal Time6
        {
            get
            {
                CanReadProperty("Time6", true);
                return _time6;
            }
            set
            {
                CanWriteProperty("Time6", true);
                if (!_time6.Equals(value))
                {
                    _time6 = value;
                    PropertyHasChanged("Time6");
                }
            }
        }

        [DisplayName("Thứ 7")]
        public string Thu7
        {
            get
            {
                CanReadProperty("Thu7", true);
                return _thu7;
            }
            set
            {
                CanWriteProperty("Thu7", true);
                if (value == null) value = string.Empty;
                if (!_thu7.Equals(value))
                {
                    _thu7 = value;
                    PropertyHasChanged("Thu7");
                }
            }
        }
        [DisplayName("T7(h)")]
        public decimal Time7
        {
            get
            {
                CanReadProperty("Time7", true);
                return _time7;
            }
            set
            {
                CanWriteProperty("Time7", true);
                if (!_time7.Equals(value))
                {
                    _time7 = value;
                    PropertyHasChanged("Time7");
                }
            }
        }

        [DisplayName("Chủ nhật")]
        public string ChuNhat
        {
            get
            {
                CanReadProperty("ChuNhat", true);
                return _chuNhat;
            }
            set
            {
                CanWriteProperty("ChuNhat", true);
                if (value == null) value = string.Empty;
                if (!_chuNhat.Equals(value))
                {
                    _chuNhat = value;
                    PropertyHasChanged("ChuNhat");
                }
            }
        }
        [DisplayName("CN(h)")]
        public decimal TimeCN
        {
            get
            {
                CanReadProperty("TimeCN", true);
                return _timeCN;
            }
            set
            {
                CanWriteProperty("TimeCN", true);
                if (!_timeCN.Equals(value))
                {
                    _timeCN = value;
                    PropertyHasChanged("TimeCN");
                }
            }
        }

        public int MaDeCu
        {
            get
            {
                CanReadProperty("MaDeCu", true);
                return _maDeCu;
            }
            set
            {
                CanWriteProperty("MaDeCu", true);
                if (!_maDeCu.Equals(value))
                {
                    _maDeCu = value;
                    PropertyHasChanged("MaDeCu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLichHoc;
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
            // Thu2
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu2", 5));
            //
            // Thu3
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu3", 5));
            //
            // Thu4
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu4", 5));
            //
            // Thu5
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu5", 5));
            //
            // Thu6
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu6", 5));
            //
            // Thu7
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Thu7", 5));
            //
            // ChuNhat
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuNhat", 5));
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
            //TODO: Define authorization rules in LichHocDaoTao
            //AuthorizationRules.AllowRead("MaLichHoc", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("NgayApDung", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("NgayApDungString", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu2", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time2", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu3", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time3", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu4", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time4", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu5", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time5", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu6", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time6", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Thu7", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("Time7", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("ChuNhat", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("TimeCN", "LichHocDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("MaDeCu", "LichHocDaoTaoReadGroup");

            //AuthorizationRules.AllowWrite("NgayApDungString", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu2", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time2", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu3", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time3", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu4", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time4", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu5", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time5", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu6", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time6", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Thu7", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("Time7", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("ChuNhat", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("TimeCN", "LichHocDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeCu", "LichHocDaoTaoWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static LichHocDaoTao NewLichHocDaoTao()
        {
            return new LichHocDaoTao();
        }

        internal static LichHocDaoTao GetLichHocDaoTao(SafeDataReader dr)
        {
            return new LichHocDaoTao(dr);
        }

        private LichHocDaoTao()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private LichHocDaoTao(SafeDataReader dr)
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
            _maLichHoc = dr.GetInt32("MaLichHoc");
            _ngayApDung = dr.GetSmartDate("NgayApDung", _ngayApDung.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _thu2 = dr.GetString("Thu2");
            _time2 = dr.GetDecimal("Time2");
            _thu3 = dr.GetString("Thu3");
            _time3 = dr.GetDecimal("Time3");
            _thu4 = dr.GetString("Thu4");
            _time4 = dr.GetDecimal("Time4");
            _thu5 = dr.GetString("Thu5");
            _time5 = dr.GetDecimal("Time5");
            _thu6 = dr.GetString("Thu6");
            _time6 = dr.GetDecimal("Time6");
            _thu7 = dr.GetString("Thu7");
            _time7 = dr.GetDecimal("Time7");
            _chuNhat = dr.GetString("ChuNhat");
            _timeCN = dr.GetDecimal("TimeCN");
            _maDeCu = dr.GetInt32("MaDeCu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DeCu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DeCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLichHocDaoTao";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maLichHoc = (int)cm.Parameters["@MaLichHoc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DeCu parent)
        {
            _maDeCu = parent.MaDeCu;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if (_thu2.Length > 0)
                cm.Parameters.AddWithValue("@Thu2", _thu2);
            else
                cm.Parameters.AddWithValue("@Thu2", DBNull.Value);
            if (_time2 != 0)
                cm.Parameters.AddWithValue("@Time2", _time2);
            else
                cm.Parameters.AddWithValue("@Time2", DBNull.Value);
            if (_thu3.Length > 0)
                cm.Parameters.AddWithValue("@Thu3", _thu3);
            else
                cm.Parameters.AddWithValue("@Thu3", DBNull.Value);
            if (_time3 != 0)
                cm.Parameters.AddWithValue("@Time3", _time3);
            else
                cm.Parameters.AddWithValue("@Time3", DBNull.Value);
            if (_thu4.Length > 0)
                cm.Parameters.AddWithValue("@Thu4", _thu4);
            else
                cm.Parameters.AddWithValue("@Thu4", DBNull.Value);
            if (_time4 != 0)
                cm.Parameters.AddWithValue("@Time4", _time4);
            else
                cm.Parameters.AddWithValue("@Time4", DBNull.Value);
            if (_thu5.Length > 0)
                cm.Parameters.AddWithValue("@Thu5", _thu5);
            else
                cm.Parameters.AddWithValue("@Thu5", DBNull.Value);
            if (_time5 != 0)
                cm.Parameters.AddWithValue("@Time5", _time5);
            else
                cm.Parameters.AddWithValue("@Time5", DBNull.Value);
            if (_thu6.Length > 0)
                cm.Parameters.AddWithValue("@Thu6", _thu6);
            else
                cm.Parameters.AddWithValue("@Thu6", DBNull.Value);
            if (_time6 != 0)
                cm.Parameters.AddWithValue("@Time6", _time6);
            else
                cm.Parameters.AddWithValue("@Time6", DBNull.Value);
            if (_thu7.Length > 0)
                cm.Parameters.AddWithValue("@Thu7", _thu7);
            else
                cm.Parameters.AddWithValue("@Thu7", DBNull.Value);
            if (_time7 != 0)
                cm.Parameters.AddWithValue("@Time7", _time7);
            else
                cm.Parameters.AddWithValue("@Time7", DBNull.Value);
            if (_chuNhat.Length > 0)
                cm.Parameters.AddWithValue("@ChuNhat", _chuNhat);
            else
                cm.Parameters.AddWithValue("@ChuNhat", DBNull.Value);
            if (_timeCN != 0)
                cm.Parameters.AddWithValue("@TimeCN", _timeCN);
            else
                cm.Parameters.AddWithValue("@TimeCN", DBNull.Value);
            if (_maDeCu != 0)
                cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            else
                cm.Parameters.AddWithValue("@MaDeCu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLichHoc", _maLichHoc);
            cm.Parameters["@MaLichHoc"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DeCu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, DeCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLichHocDaoTao";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DeCu parent)
        {
            _maDeCu = parent.MaDeCu;
            cm.Parameters.AddWithValue("@MaLichHoc", _maLichHoc);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            if (_thu2.Length > 0)
                cm.Parameters.AddWithValue("@Thu2", _thu2);
            else
                cm.Parameters.AddWithValue("@Thu2", DBNull.Value);
            if (_time2 != 0)
                cm.Parameters.AddWithValue("@Time2", _time2);
            else
                cm.Parameters.AddWithValue("@Time2", DBNull.Value);
            if (_thu3.Length > 0)
                cm.Parameters.AddWithValue("@Thu3", _thu3);
            else
                cm.Parameters.AddWithValue("@Thu3", DBNull.Value);
            if (_time3 != 0)
                cm.Parameters.AddWithValue("@Time3", _time3);
            else
                cm.Parameters.AddWithValue("@Time3", DBNull.Value);
            if (_thu4.Length > 0)
                cm.Parameters.AddWithValue("@Thu4", _thu4);
            else
                cm.Parameters.AddWithValue("@Thu4", DBNull.Value);
            if (_time4 != 0)
                cm.Parameters.AddWithValue("@Time4", _time4);
            else
                cm.Parameters.AddWithValue("@Time4", DBNull.Value);
            if (_thu5.Length > 0)
                cm.Parameters.AddWithValue("@Thu5", _thu5);
            else
                cm.Parameters.AddWithValue("@Thu5", DBNull.Value);
            if (_time5 != 0)
                cm.Parameters.AddWithValue("@Time5", _time5);
            else
                cm.Parameters.AddWithValue("@Time5", DBNull.Value);
            if (_thu6.Length > 0)
                cm.Parameters.AddWithValue("@Thu6", _thu6);
            else
                cm.Parameters.AddWithValue("@Thu6", DBNull.Value);
            if (_time6 != 0)
                cm.Parameters.AddWithValue("@Time6", _time6);
            else
                cm.Parameters.AddWithValue("@Time6", DBNull.Value);
            if (_thu7.Length > 0)
                cm.Parameters.AddWithValue("@Thu7", _thu7);
            else
                cm.Parameters.AddWithValue("@Thu7", DBNull.Value);
            if (_time7 != 0)
                cm.Parameters.AddWithValue("@Time7", _time7);
            else
                cm.Parameters.AddWithValue("@Time7", DBNull.Value);
            if (_chuNhat.Length > 0)
                cm.Parameters.AddWithValue("@ChuNhat", _chuNhat);
            else
                cm.Parameters.AddWithValue("@ChuNhat", DBNull.Value);
            if (_timeCN != 0)
                cm.Parameters.AddWithValue("@TimeCN", _timeCN);
            else
                cm.Parameters.AddWithValue("@TimeCN", DBNull.Value);
            if (_maDeCu != 0)
                cm.Parameters.AddWithValue("@MaDeCu", _maDeCu);
            else
                cm.Parameters.AddWithValue("@MaDeCu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsLichHocDaoTao";

                cm.Parameters.AddWithValue("@MaLichHoc", this._maLichHoc);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

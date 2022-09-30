using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThuLaoHopDong : Csla.BusinessBase<ChiTietThuLaoHopDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private SmartDate _ngayTinhThuLao = new SmartDate(DateTime.Today);
        private decimal _soTien = 0;
        private int _maBoPhan = 0;
        private long _maHopDong = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public DateTime? NgayTinhThuLao
        {
            get
            {
                CanReadProperty("NgayTinhThuLao", true);
                if (_ngayTinhThuLao.Date == DateTime.MinValue)
                    return null;
                return _ngayTinhThuLao.Date;
            }
            set
            {

                CanWriteProperty("NgayTinhThuLao", true);
                if (value == null)
                    _ngayTinhThuLao = new SmartDate(DateTime.MinValue);
                else
                    _ngayTinhThuLao = new SmartDate(value.Value.Date);
                PropertyHasChanged("NgayTinhThuLao");
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

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
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
            // TenBoPhan
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 100));
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
            //TODO: Define authorization rules in ChiTietThuLaoHopDong
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayTinhThuLao", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("NgayTinhThuLaoString", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "ChiTietThuLaoHopDongReadGroup");
            //AuthorizationRules.AllowRead("TenBoPhan", "ChiTietThuLaoHopDongReadGroup");

            //AuthorizationRules.AllowWrite("NgayTinhThuLaoString", "ChiTietThuLaoHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietThuLaoHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "ChiTietThuLaoHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "ChiTietThuLaoHopDongWriteGroup");
            //AuthorizationRules.AllowWrite("TenBoPhan", "ChiTietThuLaoHopDongWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietThuLaoHopDong NewChiTietThuLaoHopDong()
        {
            return new ChiTietThuLaoHopDong();
        }

        internal static ChiTietThuLaoHopDong GetChiTietThuLaoHopDong(SafeDataReader dr)
        {
            return new ChiTietThuLaoHopDong(dr);
        }

        private ChiTietThuLaoHopDong()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public ChiTietThuLaoHopDong(ChiTietThuLaoHopDong ct)
        {
            if (ct.NgayTinhThuLao == null)
                _ngayTinhThuLao = new SmartDate(DateTime.MinValue);
            else
                _ngayTinhThuLao = new SmartDate(ct.NgayTinhThuLao.Value.Date);

            _soTien = ct.SoTien;
            _maBoPhan = ct.MaBoPhan;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietThuLaoHopDong(SafeDataReader dr)
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
            _ngayTinhThuLao = dr.GetSmartDate("NgayTinhThuLao", _ngayTinhThuLao.EmptyIsMin);
            _soTien = dr.GetDecimal("SoTien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maHopDong = dr.GetInt64("MaHopDong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, HopDongThuChi parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HopDongThuChi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_InserttblChiTietThuLaoHopDong";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HopDongThuChi parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@NgayTinhThuLao", _ngayTinhThuLao.DBValue);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, HopDongThuChi parent)
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

        private void ExecuteUpdate(SqlTransaction tr, HopDongThuChi parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_UpdatetblChiTietThuLaoHopDong";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HopDongThuChi parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@NgayTinhThuLao", _ngayTinhThuLao.DBValue);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);

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
                cm.CommandText = "usp_DeletetblChiTietThuLaoHopDong";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

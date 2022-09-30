
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietDeNghi_LenhChuyenTien : Csla.BusinessBase<ChiTietDeNghi_LenhChuyenTien>
    {
        //ok
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maDeNghi = 0;
        private long _maLenhCT = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private int _loaiTien = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public long MaDeNghi
        {
            get
            {
                CanReadProperty("MaDeNghi", true);
                return _maDeNghi;
            }
            set
            {
                CanWriteProperty("MaDeNghi", true);
                if (!_maDeNghi.Equals(value))
                {
                    _maDeNghi = value;
                    PropertyHasChanged("MaDeNghi");
                }
            }
        }

        public long MaLenhCT
        {
            get
            {
                CanReadProperty("MaLenhCT", true);
                return _maLenhCT;
            }
            set
            {
                CanWriteProperty("MaLenhCT", true);
                if (!_maLenhCT.Equals(value))
                {
                    _maLenhCT = value;
                    PropertyHasChanged("MaLenhCT");
                }
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

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public int LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    PropertyHasChanged("LoaiTien");
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
            // SoChungTu
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
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
            //TODO: Define authorization rules in ChiTietDeNghi_LenhChuyenTien
            //AuthorizationRules.AllowRead("MaChiTiet", "ChiTietDeNghi_LenhChuyenTienReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "ChiTietDeNghi_LenhChuyenTienReadGroup");
            //AuthorizationRules.AllowRead("MaLenhCT", "ChiTietDeNghi_LenhChuyenTienReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChiTietDeNghi_LenhChuyenTienReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChiTietDeNghi_LenhChuyenTienReadGroup");

            //AuthorizationRules.AllowWrite("MaDeNghi", "ChiTietDeNghi_LenhChuyenTienWriteGroup");
            //AuthorizationRules.AllowWrite("MaLenhCT", "ChiTietDeNghi_LenhChuyenTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChiTietDeNghi_LenhChuyenTienWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChiTietDeNghi_LenhChuyenTienWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChiTietDeNghi_LenhChuyenTien NewChiTietDeNghi_LenhChuyenTien()
        {
            return new ChiTietDeNghi_LenhChuyenTien();
        }

        internal static ChiTietDeNghi_LenhChuyenTien GetChiTietDeNghi_LenhChuyenTien(SafeDataReader dr)
        {
            return new ChiTietDeNghi_LenhChuyenTien(dr);
        }

        public static ChiTietDeNghi_LenhChuyenTien NewChiTietDeNghi_LenhChuyenTien(long maDeNghi, string SoDeNghi, decimal soTien, int LoaiTien)
        {
            ChiTietDeNghi_LenhChuyenTien child = ChiTietDeNghi_LenhChuyenTien.NewChiTietDeNghi_LenhChuyenTien();
            child.MarkAsChild();
            child.MaDeNghi = maDeNghi;
            child.SoChungTu = SoDeNghi;
            child.SoTien = soTien;
            child.LoaiTien = LoaiTien;
            return child;
        }

        private ChiTietDeNghi_LenhChuyenTien()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietDeNghi_LenhChuyenTien(SafeDataReader dr)
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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _maLenhCT = dr.GetInt64("MaLenhCT");
            _soTien = dr.GetDecimal("SoTien");
            _soChungTu = dr.GetString("SoChungTu");
            _loaiTien = dr.GetInt32("LoaiTien");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, LenhChuyenTienNuocNgoai parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, LenhChuyenTienNuocNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDeNghi_LenhChuyenTien";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, LenhChuyenTienNuocNgoai parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (parent.MaLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", parent.MaLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, LenhChuyenTienNuocNgoai parent)
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

        private void ExecuteUpdate(SqlTransaction tr, LenhChuyenTienNuocNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDeNghi_LenhChuyenTien";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, LenhChuyenTienNuocNgoai parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            if (parent.MaLenhCT != 0)
                cm.Parameters.AddWithValue("@MaLenhCT", parent.MaLenhCT);
            else
                cm.Parameters.AddWithValue("@MaLenhCT", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (!IsDirty) return;
            //if (IsNew) return;

            ExecuteDelete(tr);
            //MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblDeNghi_LenhChuyenTien";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

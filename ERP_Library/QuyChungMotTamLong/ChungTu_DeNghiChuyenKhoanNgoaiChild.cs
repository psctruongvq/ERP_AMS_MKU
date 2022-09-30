
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_DeNghiChuyenKhoanNgoai : Csla.BusinessBase<ChungTu_DeNghiChuyenKhoanNgoai>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChungTu = 0;
        private string _soChungTu = string.Empty;
        private long _maDeNghi = 0;
        private long _maChiTiet = 0;
        private decimal _soTien = 0;
        private int _loaiDeNghi = 0;
        private string _lyDo = string.Empty;

        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
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

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
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

        public int LoaiDeNghi
        {
            get
            {
                CanReadProperty("LoaiDeNghi", true);
                return _loaiDeNghi;
            }
            set
            {
                CanWriteProperty("LoaiDeNghi", true);
                if (!_loaiDeNghi.Equals(value))
                {
                    _loaiDeNghi = value;
                    PropertyHasChanged("LoaiDeNghi");
                }
            }
        }

        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
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
            //
            // LyDo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 4000));
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
            //TODO: Define authorization rules in ChungTu_DeNghiChuyenKhoanNgoai
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaDeNghi", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("MaChiTiet", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_DeNghiChuyenKhoanNgoaiReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("MaDeNghi", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_DeNghiChuyenKhoanNgoaiWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_DeNghiChuyenKhoanNgoai NewChungTu_DeNghiChuyenKhoanNgoai()
        {
            return new ChungTu_DeNghiChuyenKhoanNgoai();
        }

        internal static ChungTu_DeNghiChuyenKhoanNgoai GetChungTu_DeNghiChuyenKhoanNgoai(SafeDataReader dr)
        {
            return new ChungTu_DeNghiChuyenKhoanNgoai(dr);
        }

        public static ChungTu_DeNghiChuyenKhoanNgoai NewChungTu_DeNghiChuyenKhoanNgoai(int maPhieu, decimal soTien, string SoChungTu, string LyDo)
        {
            return new ChungTu_DeNghiChuyenKhoanNgoai(maPhieu, soTien, SoChungTu, LyDo);
        }

        private ChungTu_DeNghiChuyenKhoanNgoai()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_DeNghiChuyenKhoanNgoai(long maPhieu, decimal SoTien, string SoChungTu, string LyDo)
        {
            this.MaDeNghi = maPhieu;
            this.SoTien = SoTien;
            this.SoChungTu = SoChungTu;
            this.LyDo = LyDo;
            this.MarkAsChild();
        }

        private ChungTu_DeNghiChuyenKhoanNgoai(SafeDataReader dr)
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
            _maChungTu = dr.GetInt64("MaChungTu");
            _soChungTu = dr.GetString("SoChungTu");
            _maDeNghi = dr.GetInt64("MaDeNghi");
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _soTien = dr.GetDecimal("SoTien");
            _loaiDeNghi = dr.GetInt32("LoaiDeNghi");
            _lyDo = dr.GetString("LyDo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_DeNghiChuyenKhoanNgoai";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_DeNghiChuyenKhoanNgoai";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maDeNghi != 0)
                cm.Parameters.AddWithValue("@MaDeNghi", _maDeNghi);
            else
                cm.Parameters.AddWithValue("@MaDeNghi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_loaiDeNghi != 0)
                cm.Parameters.AddWithValue("@LoaiDeNghi", _loaiDeNghi);
            else
                cm.Parameters.AddWithValue("@LoaiDeNghi", DBNull.Value);
            if (_lyDo.Length > 0)
                cm.Parameters.AddWithValue("@LyDo", _lyDo);
            else
                cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_DeNghiChuyenKhoanNgoai";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_GiayRutTien_CacQuy : Csla.BusinessBase<ChungTu_GiayRutTien_CacQuy>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTiet = 0;
        private long _maChungTu = 0;
        private long _maGiayRutTien = 0;
        private string _soChungTu = string.Empty;
        private decimal _soTien = 0;
        private int _loaiDeNghi = 0;
        private string _lyDo = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

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

        public long MaGiayRutTien
        {
            get
            {
                CanReadProperty("MaGiayRutTien", true);
                return _maGiayRutTien;
            }
            set
            {
                CanWriteProperty("MaGiayRutTien", true);
                if (!_maGiayRutTien.Equals(value))
                {
                    _maGiayRutTien = value;
                    PropertyHasChanged("MaGiayRutTien");
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
            //TODO: Define authorization rules in ChungTu_GiayRutTien_CacQuy
            //AuthorizationRules.AllowRead("MaChiTiet", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaChungTu", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("MaGiayRutTien", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LoaiDeNghi", "ChungTu_GiayRutTien_CacQuyReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "ChungTu_GiayRutTien_CacQuyReadGroup");

            //AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("MaGiayRutTien", "ChungTu_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "ChungTu_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiDeNghi", "ChungTu_GiayRutTien_CacQuyWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "ChungTu_GiayRutTien_CacQuyWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_GiayRutTien_CacQuy NewChungTu_GiayRutTien_CacQuy()
        {
            return new ChungTu_GiayRutTien_CacQuy();
        }

        internal static ChungTu_GiayRutTien_CacQuy GetChungTu_GiayRutTien_CacQuy(SafeDataReader dr)
        {
            return new ChungTu_GiayRutTien_CacQuy(dr);
        }

        public static ChungTu_GiayRutTien_CacQuy NewChungTu_GiayRutTien_CacQuy(int MaGRT, decimal soTien, string SoChungTu, string LyDo)
        {
            return new ChungTu_GiayRutTien_CacQuy(MaGRT, soTien, SoChungTu, LyDo);
        }


		private ChungTu_GiayRutTien_CacQuy()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

        private ChungTu_GiayRutTien_CacQuy(long MaGRT, decimal SoTien, string SoChungTu, string LyDo)
        {
            this.MaGiayRutTien = MaGRT;
            this.SoTien = SoTien;
            this.SoChungTu = SoChungTu;
            this.LyDo = LyDo;
            this.MarkAsChild();
        }

        private ChungTu_GiayRutTien_CacQuy(SafeDataReader dr)
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
            _maChungTu = dr.GetInt64("MaChungTu");
            _maGiayRutTien = dr.GetInt64("MaGiayRutTien");
            _soChungTu = dr.GetString("SoChungTu");
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
                cm.CommandText = "spd_InserttblChungTu_GiayRutTien_CacQuy";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblChungTu_GiayRutTien_CacQuy";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu_CacLoaiQuy parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MachungtuCacquy != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MachungtuCacquy);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maGiayRutTien != 0)
                cm.Parameters.AddWithValue("@MaGiayRutTien", _maGiayRutTien);
            else
                cm.Parameters.AddWithValue("@MaGiayRutTien", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChungTu_GiayRutTien_CacQuy";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

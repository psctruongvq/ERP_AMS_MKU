
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_DeNghiChuyenKhoanChild : Csla.BusinessBase<ChungTu_DeNghiChuyenKhoanChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maCTDNCK = 0;
        private long _maCT = 0;
        private long _maDNCK = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _lyDo = string.Empty;
        private int _loai = 0;
       
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
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
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
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
                }
            }
        }
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaCTDNCK
        {
            get
            {
                CanReadProperty("MaCTDNCK", true);
                return _maCTDNCK;
            }
        }
        
        public long MaCT
        {
            get
            {
                CanReadProperty("MaCT", true);
                return _maCT;
            }
            set
            {
                CanWriteProperty("MaCT", true);
                if (!_maCT.Equals(value))
                {
                    _maCT = value;
                    PropertyHasChanged("MaCT");
                }
            }
        }

        public long MaDNCK
        {
            get
            {
                CanReadProperty("MaDNCK", true);
                return _maDNCK;
            }
            set
            {
                CanWriteProperty("MaDNCK", true);
                if (!_maDNCK.Equals(value))
                {
                    _maDNCK = value;
                    PropertyHasChanged("MaDNCK");
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

        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maCTDNCK;
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
            //TODO: Define authorization rules in ChungTu_DeNghiChuyenKhoanChild
            //AuthorizationRules.AllowRead("MaCTDNCK", "ChungTu_DeNghiChuyenKhoanChildReadGroup");
            //AuthorizationRules.AllowRead("MaCT", "ChungTu_DeNghiChuyenKhoanChildReadGroup");
            //AuthorizationRules.AllowRead("MaDNCK", "ChungTu_DeNghiChuyenKhoanChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_DeNghiChuyenKhoanChildReadGroup");

            //AuthorizationRules.AllowWrite("MaCT", "ChungTu_DeNghiChuyenKhoanChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaDNCK", "ChungTu_DeNghiChuyenKhoanChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_DeNghiChuyenKhoanChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static ChungTu_DeNghiChuyenKhoanChild NewChungTu_DeNghiChuyenKhoanChild()
        {
            return new ChungTu_DeNghiChuyenKhoanChild();
        }
        public static ChungTu_DeNghiChuyenKhoanChild NewChungTu_DeNghiChuyenKhoanChild(int maDNCK, decimal soTien)
        {
            return new ChungTu_DeNghiChuyenKhoanChild(maDNCK, soTien);
        }

        public static ChungTu_DeNghiChuyenKhoanChild NewChungTu_DeNghiChuyenKhoanChild(int maDNCK, decimal soTien, int loaiCT, string SoChungTu, string LyDo)
        {
            return new ChungTu_DeNghiChuyenKhoanChild(maDNCK, soTien, loaiCT, SoChungTu, LyDo);
        }

        internal static ChungTu_DeNghiChuyenKhoanChild GetChungTu_DeNghiChuyenKhoanChild(SafeDataReader dr)
        {
            return new ChungTu_DeNghiChuyenKhoanChild(dr);
        }

        private ChungTu_DeNghiChuyenKhoanChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private ChungTu_DeNghiChuyenKhoanChild(int maDNCK, decimal soTien)
        {
            this.MaDNCK = maDNCK;
            this.SoTien = soTien;

            MarkAsChild();
        }

        private ChungTu_DeNghiChuyenKhoanChild(int maDNCK, decimal soTien, int loaiCT, string soChungTu, string lyDo)
        {
            this.LyDo = lyDo;
            this.SoChungTu = soChungTu;
            this.Loai = loaiCT;
            this.MaDNCK = maDNCK;
            this.SoTien = soTien;
            MarkAsChild();
        }
        private ChungTu_DeNghiChuyenKhoanChild(SafeDataReader dr)
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
            _maCTDNCK = dr.GetInt64("MaCTDNCK");
            _maCT = dr.GetInt64("MaChungTu");
            _maDNCK = dr.GetInt64("MaDeNghiChuyenKhoan");
            _soTien = dr.GetDecimal("SoTien");
            _soChungTu = dr.GetString("SoChungTu");
            _lyDo = dr.GetString("LyDo");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_DeNghiChuyenKhoan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCTDNCK = (long)cm.Parameters["@MaCTDNCK"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _maCT = parent.MaChungTu;
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaChungTu", _maCT);
            cm.Parameters.AddWithValue("@MaDeNghiChuyenKhoan", _maDNCK);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@MaCTDNCK", _maCTDNCK);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            cm.Parameters["@MaCTDNCK"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_DeNghiChuyenKhoan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@MaCTDNCK", _maCTDNCK);
            cm.Parameters.AddWithValue("@MaChungTu", _maCT);
            cm.Parameters.AddWithValue("@MaDeNghiChuyenKhoan", _maDNCK);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@LyDo", _lyDo);
            cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            //if (IsDirty) return;
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
                cm.CommandText = "sp_DeletetblChungTu_DeNghiChuyenKhoan";

                cm.Parameters.AddWithValue("@MaCTDNCK", this._maCTDNCK);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

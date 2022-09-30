
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThuLaoNhanVienNgoaiDai_ChiTietChild : Csla.BusinessBase<ThuLaoNhanVienNgoaiDai_ChiTietChild>
    {
        #region Business Properties and Methods

        //declare members
        internal long _maChiTiet = 0;
        private long _maNhanVien = 0;
        private decimal _soTien = 0;
        private int _pTThue = 0;
        private decimal _tienThue = 0;
        private decimal _conLai = 0;
        private string _ghiChu = string.Empty;
        private int _maThuLao = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                    TienThue = Math.Round(_soTien * _pTThue / 100, 0);
                    ConLai = _soTien - TienThue;
                }
            }
        }

        public int PTThue
        {
            get
            {
                return _pTThue;
            }
            set
            {
                if (!_pTThue.Equals(value))
                {
                    _pTThue = value;
                    PropertyHasChanged("PTThue");
                    TienThue = Math.Round(SoTien * _pTThue / 100, 0);
                    ConLai = SoTien - TienThue;
                }
            }
        }

        public decimal TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged("TienThue");
                    ConLai = SoTien - _tienThue;
                }
            }
        }

        public decimal ConLai
        {
            get
            {
                return _conLai;
            }
            set
            {
                if (!_conLai.Equals(value))
                {
                    _conLai = value;
                    PropertyHasChanged("ConLai");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public int MaThuLao
        {
            get
            {
                return _maThuLao;
            }
            set
            {
                if (!_maThuLao.Equals(value))
                {
                    _maThuLao = value;
                    PropertyHasChanged("MaThuLao");
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

        #region Factory Methods
        internal static ThuLaoNhanVienNgoaiDai_ChiTietChild NewThuLaoNhanVienNgoaiDai_ChiTietChild()
        {
            return new ThuLaoNhanVienNgoaiDai_ChiTietChild();
        }

        internal static ThuLaoNhanVienNgoaiDai_ChiTietChild GetThuLaoNhanVienNgoaiDai_ChiTietChild(SafeDataReader dr)
        {
            return new ThuLaoNhanVienNgoaiDai_ChiTietChild(dr);
        }

        public ThuLaoNhanVienNgoaiDai_ChiTietChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ThuLaoNhanVienNgoaiDai_ChiTietChild(SafeDataReader dr)
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
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _soTien = dr.GetDecimal("SoTien");
            _pTThue = dr.GetInt32("PTThue");
            _tienThue = dr.GetDecimal("TienThue");
            _conLai = dr.GetDecimal("ConLai");
            _ghiChu = dr.GetString("GhiChu");
            _maThuLao = dr.GetInt32("MaThuLao");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ThuLaoNhanVienNgoaiDai parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ThuLaoNhanVienNgoaiDai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ThuLaoNhanVienNgoaiDai_ChiTietChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ThuLaoNhanVienNgoaiDai parent)
        {
            _maThuLao = parent.MaThuLao;
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@PTThue", _pTThue);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@ConLai", _conLai);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThuLao", _maThuLao);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ThuLaoNhanVienNgoaiDai parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ThuLaoNhanVienNgoaiDai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_ThuLaoNhanVienNgoaiDai_ChiTietChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ThuLaoNhanVienNgoaiDai parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@PTThue", _pTThue);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@ConLai", _conLai);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThuLao", _maThuLao);
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
                cm.CommandText = "spd_Delete_ThuLaoNhanVienNgoaiDai_ChiTietChild";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

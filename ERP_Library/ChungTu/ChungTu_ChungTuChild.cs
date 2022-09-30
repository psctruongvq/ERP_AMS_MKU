using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_ChungTuChild : Csla.BusinessBase<ChungTu_ChungTuChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _iDChungTu = 0;
        private long _iDChungTuRef = 0;
        private long _MaDoiTuong = 0;
        private string _noiDung = string.Empty;
        private decimal _soTien = 0;
        private decimal _soTienNgoaiTe = 0;
        private string _soChungTuRef = string.Empty;

        private string _TenDoiTuong = string.Empty;
        private DateTime _ngayCanTru = DateTime.Today.Date;

        private long _MaButToanNo = 0;
        private long _MaButToanCo = 0;
        private bool _isCanTruSoDauKy = false;
        private int _idDTCN = 0;     
        private byte _RefType = 0;//1: Hoàn tạm ứng
        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public long IDChungTu
        {
            get
            {
                CanReadProperty("IDChungTu", true);
                return _iDChungTu;
            }
            set
            {
                CanWriteProperty("IDChungTu", true);
                if (!_iDChungTu.Equals(value))
                {
                    _iDChungTu = value;
                    PropertyHasChanged("IDChungTu");
                }
            }
        }

        public long IDChungTuRef
        {
            get
            {
                CanReadProperty("IDChungTuRef", true);
                return _iDChungTuRef;
            }
            set
            {
                CanWriteProperty("IDChungTuRef", true);
                if (!_iDChungTuRef.Equals(value))
                {
                    _iDChungTuRef = value;
                    PropertyHasChanged("IDChungTuRef");
                }
            }
        }

        public long MaDoiTuong
        {
            get
            {
                CanReadProperty("MaDoiTuong", true);
                return _MaDoiTuong;
            }
            set
            {
                CanWriteProperty("MaDoiTuong", true);
                if (!_MaDoiTuong.Equals(value))
                {
                    _MaDoiTuong = value;
                    PropertyHasChanged("MaDoiTuong");
                }
            }
        }

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
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

        public decimal SoTienNgoaiTe
        {
            get
            {
                CanReadProperty("SoTienNgoaiTe", true);
                return _soTienNgoaiTe;
            }
            set
            {
                CanWriteProperty("SoTienNgoaiTe", true);
                if (!_soTienNgoaiTe.Equals(value))
                {
                    _soTienNgoaiTe = value;
                    PropertyHasChanged("SoTienNgoaiTe");
                }
            }
        }

        public string SoChungTuRef
        {
            get
            {
                CanReadProperty("SoChungTuRef", true);
                return _soChungTuRef;
            }
            set
            {
                CanWriteProperty("SoChungTuRef", true);
                if (value == null) value = string.Empty;
                if (!_soChungTuRef.Equals(value))
                {
                    _soChungTuRef = value;
                    PropertyHasChanged("SoChungTuRef");
                }
            }
        }

        public string TenDoiTuong
        {
            get
            {
                CanReadProperty("TenDoiTuong", true);
                return _TenDoiTuong;
            }
            set
            {
                CanWriteProperty("TenDoiTuong", true);
                if (value == null) value = string.Empty;
                if (!_TenDoiTuong.Equals(value))
                {
                    _TenDoiTuong = value;
                    PropertyHasChanged("TenDoiTuong");
                }
            }
        }

        public DateTime NgayCanTru
        {
            get
            {
                CanReadProperty("NgayCanTru", true);
                return _ngayCanTru;
            }
            set
            {
                CanWriteProperty("NgayCanTru", true);
                if (!_ngayCanTru.Equals(value))
                {
                    _ngayCanTru = value;
                    PropertyHasChanged("NgayCanTru");
                }
            }
        }

        public byte RefType
        {
            get
            {
                CanReadProperty("RefType", true);
                return _RefType;
            }
            set
            {
                CanWriteProperty("RefType", true);
                if (!_RefType.Equals(value))
                {
                    _RefType = value;
                    PropertyHasChanged("RefType");
                }
            }
        }

        public long MaButToanNo
        {
            get
            {
                CanReadProperty("MaButToanNo", true);
                return _MaButToanNo;
            }
            set
            {
                CanWriteProperty("MaButToanNo", true);
                if (!_MaButToanNo.Equals(value))
                {
                    _MaButToanNo = value;
                    PropertyHasChanged("MaButToanNo");
                }
            }
        }
        public long MaButToanCo
        {
            get
            {
                CanReadProperty("MaButToanCo", true);
                return _MaButToanCo;
            }
            set
            {
                CanWriteProperty("MaButToanCo", true);
                if (!_MaButToanCo.Equals(value))
                {
                    _MaButToanCo = value;
                    PropertyHasChanged("MaButToanCo");
                }
            }
        }

        public bool IsCanTruSoDauKy
        {
            get
            {
                CanReadProperty("IsCanTruSoDauKy", true);
                return _isCanTruSoDauKy;
            }
            set
            {
                CanWriteProperty("IsCanTruSoDauKy", true);
                if (!_isCanTruSoDauKy.Equals(value))
                {
                    _isCanTruSoDauKy = value;
                    PropertyHasChanged("IsCanTruSoDauKy");
                }
            }
        }
       
        public int IdDTCN
        {
            get
            {
                CanReadProperty("IdDTCN", true);
                return _idDTCN;
            }
            set
            {
                CanWriteProperty("IdDTCN", true);
                if (!_idDTCN.Equals(value))
                {
                    _idDTCN = value;
                    PropertyHasChanged("IdDTCN");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _id;
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
            // SoChungTuRef
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTuRef", 50));
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
            //TODO: Define authorization rules in ChungTu_ChungTuChild
            //AuthorizationRules.AllowRead("Id", "ChungTu_ChungTuChildReadGroup");
            //AuthorizationRules.AllowRead("IDChungTu", "ChungTu_ChungTuChildReadGroup");
            //AuthorizationRules.AllowRead("IDChungTuRef", "ChungTu_ChungTuChildReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "ChungTu_ChungTuChildReadGroup");
            //AuthorizationRules.AllowRead("SoTien", "ChungTu_ChungTuChildReadGroup");
            //AuthorizationRules.AllowRead("SoChungTuRef", "ChungTu_ChungTuChildReadGroup");

            //AuthorizationRules.AllowWrite("IDChungTu", "ChungTu_ChungTuChildWriteGroup");
            //AuthorizationRules.AllowWrite("IDChungTuRef", "ChungTu_ChungTuChildWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "ChungTu_ChungTuChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoTien", "ChungTu_ChungTuChildWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTuRef", "ChungTu_ChungTuChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static ChungTu_ChungTuChild NewChungTu_ChungTuChild()
        {
            return new ChungTu_ChungTuChild();
        }

        internal static ChungTu_ChungTuChild GetChungTu_ChungTuChild(SafeDataReader dr)
        {
            return new ChungTu_ChungTuChild(dr);
        }

        private ChungTu_ChungTuChild()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChungTu_ChungTuChild(SafeDataReader dr)
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
            _id = dr.GetInt64("ID");
            _iDChungTu = dr.GetInt64("IDChungTu");
            _iDChungTuRef = dr.GetInt64("IDChungTuRef");
            _MaDoiTuong = dr.GetInt64("MaDoiTuong");
            _noiDung = dr.GetString("NoiDung");
            _soTien = dr.GetDecimal("SoTien");
            _soChungTuRef = dr.GetString("SoChungTuRef");
            _TenDoiTuong = dr.GetString("TenDoiTuong");
            _RefType = dr.GetByte("RefType");
            _soTienNgoaiTe = dr.GetDecimal("SoTienNgoaiTe");
            _ngayCanTru = dr.GetDateTime("NgayCanTru");
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
                cm.CommandText = "spd_InserttblChungTu_ChungTu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTu parent)
        {
            _iDChungTu = parent.MaChungTu;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_iDChungTu != 0)
                cm.Parameters.AddWithValue("@IDChungTu", _iDChungTu);
            else
                cm.Parameters.AddWithValue("@IDChungTu", DBNull.Value);
            if (_iDChungTuRef != 0)
                cm.Parameters.AddWithValue("@IDChungTuRef", _iDChungTuRef);
            else
                cm.Parameters.AddWithValue("@IDChungTuRef", DBNull.Value);
            if (_MaDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);

            if (_soTienNgoaiTe != 0)
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", _soTienNgoaiTe);
            else
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);

            if (_soChungTuRef.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuRef", _soChungTuRef);
            else
                cm.Parameters.AddWithValue("@SoChungTuRef", DBNull.Value);
            if (_RefType != 0)
                cm.Parameters.AddWithValue("@RefType", _RefType);
            else
                cm.Parameters.AddWithValue("@RefType", DBNull.Value);
            cm.Parameters.AddWithValue("@IsCanTruSoDuDauKy", _isCanTruSoDauKy);
            cm.Parameters.AddWithValue("@NgayCanTru", _ngayCanTru);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
        }

        internal void Insert(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTu_ChungTu_DTCN";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, TongHopDoiTruCongNo parent)
        {
            _idDTCN = parent.Id;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_iDChungTu != 0)
                cm.Parameters.AddWithValue("@IDChungTu", _iDChungTu);
            else
                cm.Parameters.AddWithValue("@IDChungTu", DBNull.Value);
            if (_iDChungTuRef != 0)
                cm.Parameters.AddWithValue("@IDChungTuRef", _iDChungTuRef);
            else
                cm.Parameters.AddWithValue("@IDChungTuRef", DBNull.Value);
            if (_MaDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);

            if (_soTienNgoaiTe != 0)
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", _soTienNgoaiTe);
            else
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);

            if (_soChungTuRef.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuRef", _soChungTuRef);
            else
                cm.Parameters.AddWithValue("@SoChungTuRef", DBNull.Value);
            if (_RefType != 0)
                cm.Parameters.AddWithValue("@RefType", _RefType);
            else
                cm.Parameters.AddWithValue("@RefType", DBNull.Value);  
                     
            cm.Parameters.AddWithValue("@IsCanTruSoDuDauKy", _isCanTruSoDauKy);
            cm.Parameters.AddWithValue("@NgayCanTru", _ngayCanTru);
            cm.Parameters.AddWithValue("@IdDTCN", _idDTCN);           
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblChungTu_ChungTu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_iDChungTu != 0)
                cm.Parameters.AddWithValue("@IDChungTu", _iDChungTu);
            else
                cm.Parameters.AddWithValue("@IDChungTu", DBNull.Value);
            if (_iDChungTuRef != 0)
                cm.Parameters.AddWithValue("@IDChungTuRef", _iDChungTuRef);
            else
                cm.Parameters.AddWithValue("@IDChungTuRef", DBNull.Value);
            if (_MaDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soTienNgoaiTe != 0)
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", _soTienNgoaiTe);
            else
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);
            if (_soChungTuRef.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuRef", _soChungTuRef);
            else
                cm.Parameters.AddWithValue("@SoChungTuRef", DBNull.Value);
            if (_RefType != 0)
                cm.Parameters.AddWithValue("@RefType", _RefType);
            else
                cm.Parameters.AddWithValue("@RefType", DBNull.Value);
            cm.Parameters.AddWithValue("@IsCanTruSoDuDauKy", _isCanTruSoDauKy);
            cm.Parameters.AddWithValue("@NgayCanTru", _ngayCanTru);
        }
        internal void Update(SqlTransaction tr, TongHopDoiTruCongNo parent)
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

        private void ExecuteUpdate(SqlTransaction tr, TongHopDoiTruCongNo parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTu_ChungTu_DTCN";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, TongHopDoiTruCongNo parent)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_iDChungTu != 0)
                cm.Parameters.AddWithValue("@IDChungTu", _iDChungTu);
            else
                cm.Parameters.AddWithValue("@IDChungTu", DBNull.Value);
            if (_iDChungTuRef != 0)
                cm.Parameters.AddWithValue("@IDChungTuRef", _iDChungTuRef);
            else
                cm.Parameters.AddWithValue("@IDChungTuRef", DBNull.Value);
            if (_MaDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_soTienNgoaiTe != 0)
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", _soTienNgoaiTe);
            else
                cm.Parameters.AddWithValue("@SoTienNgoaiTe", DBNull.Value);
            if (_soChungTuRef.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTuRef", _soChungTuRef);
            else
                cm.Parameters.AddWithValue("@SoChungTuRef", DBNull.Value);
            if (_RefType != 0)
                cm.Parameters.AddWithValue("@RefType", _RefType);
            else
                cm.Parameters.AddWithValue("@RefType", DBNull.Value);
            cm.Parameters.AddWithValue("@IsCanTruSoDuDauKy", _isCanTruSoDauKy);
            cm.Parameters.AddWithValue("@NgayCanTru", _ngayCanTru);
            cm.Parameters.AddWithValue("@IdDTCN", _idDTCN);
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
                cm.CommandText = "spd_DeletetblChungTu_ChungTu";

                cm.Parameters.AddWithValue("@ID", this._id);

                cm.ExecuteNonQuery();
            }//using
        }

        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

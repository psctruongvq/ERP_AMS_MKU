
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{
    [Serializable()]
    public class NguoiKyTen : Csla.BusinessBase<NguoiKyTen>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private string _NguoiLapTieude = string.Empty;
        private string _NguoiLapTen = string.Empty;
        private string _bptTieude = string.Empty;
        private string _bptTen = string.Empty;
        private string _ThuTruongTieude = string.Empty;
        private string _ThuTruongTen = string.Empty;
        private string _tenTongGiamDoc = string.Empty;
        private string _tieuDeTongGiamDoc = string.Empty;

        private string _tenThuQuy = string.Empty;
        private string _tieuDeThuQuy = string.Empty;


        private string _tenChuTichCD = string.Empty;
        private string _tieuDeChuTichCD = string.Empty;
       
        [System.ComponentModel.DataObjectField(true, true)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }
        public string TenTongGiamDoc
        {
            get { return _tenTongGiamDoc; }
            set { _tenTongGiamDoc = value;

            PropertyHasChanged("TenTongGiamDoc");
            }
        }
        public string TieuDeTongGiamDoc
        {
            get { return _tieuDeTongGiamDoc; }
            set
            {
                _tieuDeTongGiamDoc = value;

                PropertyHasChanged("TieuDeTongGiamDoc");
            }
        }
        public string NguoiLapTieude
        {
            get
            {
                return _NguoiLapTieude;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_NguoiLapTieude.Equals(value))
                {
                    _NguoiLapTieude = value;
                    PropertyHasChanged("NguoiLapTieude");
                }
            }
        }

        public string NguoiLapTen
        {
            get
            {
                return _NguoiLapTen;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_NguoiLapTen.Equals(value))
                {
                    _NguoiLapTen = value;
                    PropertyHasChanged("NguoiLapTen");
                }
            }
        }

        public string BptTieude
        {
            get
            {
                return _bptTieude;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_bptTieude.Equals(value))
                {
                    _bptTieude = value;
                    PropertyHasChanged("BptTieude");
                }
            }
        }

        public string BptTen
        {
            get
            {
                return _bptTen;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_bptTen.Equals(value))
                {
                    _bptTen = value;
                    PropertyHasChanged("BptTen");
                }
            }
        }

        public string ThuTruongTieude
        {
            get
            {
                return _ThuTruongTieude;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ThuTruongTieude.Equals(value))
                {
                    _ThuTruongTieude = value;
                    PropertyHasChanged("ThuTruongTieude");
                }
            }
        }

        public string ThuTruongTen
        {
            get
            {
                return _ThuTruongTen;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ThuTruongTen.Equals(value))
                {
                    _ThuTruongTen = value;
                    PropertyHasChanged("ThuTruongTen");
                }
            }
        }


        public string TenThuQuy
        {
            get
            {
                return _tenThuQuy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenThuQuy.Equals(value))
                {
                    _tenThuQuy = value;
                    PropertyHasChanged("TenThuQuy");
                }
            }
        }

        public string TieuDeThuQuy
        {
            get
            {
                return _tieuDeThuQuy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tieuDeThuQuy.Equals(value))
                {
                    _tieuDeThuQuy = value;
                    PropertyHasChanged("TieuDeThuQuy");
                }
            }
        }


        public string TenChuTichCD
        {
            get
            {
                return _tenChuTichCD;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChuTichCD.Equals(value))
                {
                    _tenChuTichCD = value;
                    PropertyHasChanged("TenChuTichCD");
                }
            }
        }

        public string TieuDeChuTichCD
        {
            get
            {
                return _tieuDeChuTichCD;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tieuDeChuTichCD.Equals(value))
                {
                    _tieuDeChuTichCD = value;
                    PropertyHasChanged("TieuDeChuTichCD");
                }
            }
        }
        protected override object GetIdValue()
        {
            return _userID;
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
            // NguoiLapTieude
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiLapTieude", 50));
            //
            // NguoiLapTen
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiLapTen", 50));
            //
            // BptTieude
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("BptTieude", 50));
            //
            // BptTen
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("BptTen", 50));
            //
            // ThuTruongTieude
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThuTruongTieude", 50));
            //
            // ThuTruongTen
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThuTruongTen", 50));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        private NguoiKyTen()
        { /* require use of factory method */ }

        public static NguoiKyTen NewNguoiKyTen()
        {
            return DataPortal.Create<NguoiKyTen>();
        }

        public static NguoiKyTen GetNguoiKyTen(int userID)
        {
            return DataPortal.Fetch<NguoiKyTen>(new Criteria(userID));
        }

        public static void DeleteNguoiKyTen(int userID)
        {
            DataPortal.Delete(new Criteria(userID));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int UserID;

            public Criteria(int userID)
            {
                this.UserID = userID;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_NguoiKyTen";

                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _tenTongGiamDoc = dr.GetString("TenTongGiamDoc");
            _tieuDeTongGiamDoc = dr.GetString("TieuDeTongGiamDoc");
            _userID = dr.GetInt32("UserID");
            _NguoiLapTieude = dr.GetString("NguoiLap_TieuDe");
            _NguoiLapTen = dr.GetString("NguoiLap_Ten");
            _bptTieude = dr.GetString("BPT_TieuDe");
            _bptTen = dr.GetString("BPT_Ten");
            _ThuTruongTieude = dr.GetString("ThuTruong_TieuDe");
            _ThuTruongTen = dr.GetString("ThuTruong_Ten");
            if (_NguoiLapTieude == "")
                _NguoiLapTieude = "Người lập bảng";
            if (_bptTieude == "")
                _bptTieude = "BPT " + BoPhan.GetBoPhan(Security.CurrentUser.Info.MaBoPhan).TenBoPhan;
            if (_ThuTruongTieude == "")
                _ThuTruongTieude = "Thủ trưởng đơn vị";
            _tieuDeThuQuy = dr.GetString("TieuDeThuQuy");
            _tenThuQuy = dr.GetString("TenThuQuy");
            _tieuDeChuTichCD = dr.GetString("TieuDeChuTichCD");
            _tenChuTichCD = dr.GetString("TenChuTichCD");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_NguoiKyTen";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _userID = (int)cm.Parameters["@NewUserID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_NguoiLapTieude.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLap_TieuDe", _NguoiLapTieude);
            else
                cm.Parameters.AddWithValue("@NguoiLap_TieuDe", DBNull.Value);
            if (_NguoiLapTen.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLap_Ten", _NguoiLapTen);
            else
                cm.Parameters.AddWithValue("@NguoiLap_Ten", DBNull.Value);
            if (_bptTieude.Length > 0)
                cm.Parameters.AddWithValue("@BPT_TieuDe", _bptTieude);
            else
                cm.Parameters.AddWithValue("@BPT_TieuDe", DBNull.Value);
            if (_bptTen.Length > 0)
                cm.Parameters.AddWithValue("@BPT_Ten", _bptTen);
            else
                cm.Parameters.AddWithValue("@BPT_Ten", DBNull.Value);
            if (_ThuTruongTieude.Length > 0)
                cm.Parameters.AddWithValue("@ThuTruong_TieuDe", _ThuTruongTieude);
            else
                cm.Parameters.AddWithValue("@ThuTruong_TieuDe", DBNull.Value);
            if (_ThuTruongTen.Length > 0)
                cm.Parameters.AddWithValue("@ThuTruong_Ten", _ThuTruongTen);
            else
                cm.Parameters.AddWithValue("@ThuTruong_Ten", DBNull.Value);
            cm.Parameters.AddWithValue("@NewUserID", _userID);
            cm.Parameters["@NewUserID"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_NguoiKyTen";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@UserID", _userID);
            if (_NguoiLapTieude.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLap_TieuDe", _NguoiLapTieude);
            else
                cm.Parameters.AddWithValue("@NguoiLap_TieuDe", DBNull.Value);
            if (_NguoiLapTen.Length > 0)
                cm.Parameters.AddWithValue("@NguoiLap_Ten", _NguoiLapTen);
            else
                cm.Parameters.AddWithValue("@NguoiLap_Ten", DBNull.Value);
            if (_bptTieude.Length > 0)
                cm.Parameters.AddWithValue("@BPT_TieuDe", _bptTieude);
            else
                cm.Parameters.AddWithValue("@BPT_TieuDe", DBNull.Value);
            if (_bptTen.Length > 0)
                cm.Parameters.AddWithValue("@BPT_Ten", _bptTen);
            else
                cm.Parameters.AddWithValue("@BPT_Ten", DBNull.Value);
            if (_ThuTruongTieude.Length > 0)
                cm.Parameters.AddWithValue("@ThuTruong_TieuDe", _ThuTruongTieude);
            else
                cm.Parameters.AddWithValue("@ThuTruong_TieuDe", DBNull.Value);
            if (_ThuTruongTen.Length > 0)
                cm.Parameters.AddWithValue("@ThuTruong_Ten", _ThuTruongTen);
            else
                cm.Parameters.AddWithValue("@ThuTruong_Ten", DBNull.Value);
            if (_tenTongGiamDoc.Length > 0)
                cm.Parameters.AddWithValue("@TenTongGiamDoc", _tenTongGiamDoc);
            else
                cm.Parameters.AddWithValue("@TenTongGiamDoc", DBNull.Value);
            if (_tieuDeTongGiamDoc.Length > 0 || _tieuDeTongGiamDoc !=null)
                cm.Parameters.AddWithValue("@TieuDeTongGiamDoc", _tieuDeTongGiamDoc);
            else
                cm.Parameters.AddWithValue("@TieuDeTongGiamDoc", DBNull.Value);



            if (_tieuDeThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@TieuDeThuQuy", _tieuDeThuQuy);
            else
                cm.Parameters.AddWithValue("@TieuDeThuQuy", DBNull.Value);
            if (_tenThuQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenThuQuy", _tenThuQuy);
            else
                cm.Parameters.AddWithValue("@TenThuQuy", DBNull.Value);

            if (_tieuDeChuTichCD.Length > 0)
                cm.Parameters.AddWithValue("@TieuDeChuTichCD", _tieuDeChuTichCD);
            else
                cm.Parameters.AddWithValue("@TieuDeChuTichCD", DBNull.Value);

            if (_tenChuTichCD.Length > 0)
                cm.Parameters.AddWithValue("@TenChuTichCD", _tenChuTichCD);
            else
                cm.Parameters.AddWithValue("@TenChuTichCD", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_userID));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Delete_NguoiKyTen";

                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

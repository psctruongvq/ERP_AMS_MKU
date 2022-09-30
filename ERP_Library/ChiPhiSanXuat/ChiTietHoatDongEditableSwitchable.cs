
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietHoatDong : Csla.BusinessBase<ChiTietHoatDong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTietHoatDong = 0;
        private string _maChiTietHoatDongQL = string.Empty;
        private string _tenChiTietHoatDong = string.Empty;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _nguoiLap = 0;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private int _maHoatDong = 0;
        private int _maCongTy = 0;

      
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTietHoatDong
        {
            get
            {
                return _maChiTietHoatDong;
            }
        }
        public int MaCongTy
        {
            get { return _maCongTy; }
            set { _maCongTy = value; }
        }
        public string MaChiTietHoatDongQL
        {
            get
            {
                return _maChiTietHoatDongQL;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maChiTietHoatDongQL.Equals(value))
                {
                    _maChiTietHoatDongQL = value;
                    PropertyHasChanged("MaChiTietHoatDongQL");
                }
            }
        }

        public string TenChiTietHoatDong
        {
            get
            {
                return _tenChiTietHoatDong;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenChiTietHoatDong.Equals(value))
                {
                    _tenChiTietHoatDong = value;
                    PropertyHasChanged("TenChiTietHoatDong");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public int NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
            set
            {
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        public int MaHoatDong
        {
            get
            {
                return _maHoatDong;
            }
            set
            {
                if (!_maHoatDong.Equals(value))
                {
                    _maHoatDong = value;
                    PropertyHasChanged("MaHoatDong");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTietHoatDong;
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
            // MaChiTietHoatDongQL
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChiTietHoatDongQL", 50));
            //
            // TenChiTietHoatDong
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiTietHoatDong", 200));
            //
            // TenBoPhan
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        private ChiTietHoatDong()
        { /* require use of factory method */ }

        public static ChiTietHoatDong NewChiTietHoatDong()
        {
            return DataPortal.Create<ChiTietHoatDong>();
        }

        public static ChiTietHoatDong GetChiTietHoatDong(int maChiTietHoatDong)
        {
            return DataPortal.Fetch<ChiTietHoatDong>(new Criteria(maChiTietHoatDong));
        }

        public static void DeleteChiTietHoatDong(int maChiTietHoatDong)
        {
            DataPortal.Delete(new Criteria(maChiTietHoatDong));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChiTietHoatDong NewChiTietHoatDongChild()
        {
            ChiTietHoatDong child = new ChiTietHoatDong();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChiTietHoatDong GetChiTietHoatDong(SafeDataReader dr)
        {
            ChiTietHoatDong child = new ChiTietHoatDong();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaChiTietHoatDong;

            public Criteria(int maChiTietHoatDong)
            {
                this.MaChiTietHoatDong = maChiTietHoatDong;
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
                cm.CommandText = "SelecttblChiTietHoatDong";

                cm.Parameters.AddWithValue("@MaChiTietHoatDong", criteria.MaChiTietHoatDong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
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
                    ExecuteInsert(tr, null);

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
                        ExecuteUpdate(tr, null);
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

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maChiTietHoatDong));
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
                cm.CommandText = "DeletetblChiTietHoatDong";

                cm.Parameters.AddWithValue("@MaChiTietHoatDong", criteria.MaChiTietHoatDong);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

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
            _maChiTietHoatDong = dr.GetInt32("MaChiTietHoatDong");
            _maChiTietHoatDongQL = dr.GetString("MaChiTietHoatDongQL");
            _tenChiTietHoatDong = dr.GetString("TenChiTietHoatDong");
            _ngayLap = dr.GetDateTime("NgayLap");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maHoatDong = dr.GetInt32("MaHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChiTietHoatDongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChiTietHoatDongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblChiTietHoatDong";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietHoatDong = (int)cm.Parameters["@MaChiTietHoatDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChiTietHoatDongList parent)
        {
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maChiTietHoatDongQL.Length > 0)
                cm.Parameters.AddWithValue("@MaChiTietHoatDongQL", _maChiTietHoatDongQL);
            else
                cm.Parameters.AddWithValue("@MaChiTietHoatDongQL", DBNull.Value);
            if (_tenChiTietHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@TenChiTietHoatDong", _tenChiTietHoatDong);
            else
                cm.Parameters.AddWithValue("@TenChiTietHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            cm.Parameters.AddWithValue("@MaChiTietHoatDong", _maChiTietHoatDong);
            cm.Parameters["@MaChiTietHoatDong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChiTietHoatDongList parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChiTietHoatDongList parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblChiTietHoatDong";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChiTietHoatDongList parent)
        {
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            cm.Parameters.AddWithValue("@MaChiTietHoatDong", _maChiTietHoatDong);
            if (_maChiTietHoatDongQL.Length > 0)
                cm.Parameters.AddWithValue("@MaChiTietHoatDongQL", _maChiTietHoatDongQL);
            else
                cm.Parameters.AddWithValue("@MaChiTietHoatDongQL", DBNull.Value);
            if (_tenChiTietHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@TenChiTietHoatDong", _tenChiTietHoatDong);
            else
                cm.Parameters.AddWithValue("@TenChiTietHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
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

            ExecuteDelete(tr, new Criteria(_maChiTietHoatDong));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

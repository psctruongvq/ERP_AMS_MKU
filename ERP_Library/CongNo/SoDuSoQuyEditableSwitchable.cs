
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//long

namespace ERP_Library
{
    [Serializable()]
    public class SoDuSoQuy : Csla.BusinessBase<SoDuSoQuy>
    {
        #region Business Properties and Methods

        //declare members
        private int _maSoQuy = 0;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private decimal _soDuNo = 0;
        private decimal _soDuCo = 0;
        private decimal _luyKeNo = 0;
        private decimal _luyKeCo = 0;
        private int _nam = DateTime.Now.Year;

        //[System.ComponentModel.DataObjectField(true, false)]
        public int MaSoQuy
        {
            get
            {
                return _maSoQuy;
            }
            set
            {
                if (!_maSoQuy.Equals(value))
                {
                    this._maSoQuy = value;
                    PropertyHasChanged();
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public decimal SoDuNo
        {
            get
            {
                return _soDuNo;
            }
            set
            {
                if (!_soDuNo.Equals(value))
                {
                    _soDuNo = value;
                    PropertyHasChanged("SoDuNo");
                }
            }
        }

        public decimal SoDuCo
        {
            get
            {
                return _soDuCo;
            }
            set
            {
                if (!_soDuCo.Equals(value))
                {
                    _soDuCo = value;
                    PropertyHasChanged("SoDuCo");
                }
            }
        }

        public decimal LuyKeNo
        {
            get
            {
                return _luyKeNo;
            }
            set
            {
                if (!_luyKeNo.Equals(value))
                {
                    _luyKeNo = value;
                    PropertyHasChanged("LuyKeNo");
                }
            }
        }

        public decimal LuyKeCo
        {
            get
            {
                return _luyKeCo;
            }
            set
            {
                if (!_luyKeCo.Equals(value))
                {
                    _luyKeCo = value;
                    PropertyHasChanged("LuyKeCo");
                }
            }
        }

        //[System.ComponentModel.DataObjectField(true, false)]
        public int Nam
        {
            get
            {
                return _nam;
            }
            set
            {
                if (!_nam.Equals(value))
                {
                    this._nam = value;
                    PropertyHasChanged();
                }
            }
        }

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}:{2}", _maSoQuy, _maBoPhan, _nam);
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
        public SoDuSoQuy()
        { /* require use of factory method */ }


        private SoDuSoQuy(int maSoQuy, int maBoPhan, int nam)
        {
            this._maSoQuy = maSoQuy;
            this._maBoPhan = maBoPhan;
            this._nam = nam;
        }


        private SoDuSoQuy(int nam)
        {
            this._nam = nam;
        }


        public static SoDuSoQuy NewSoDuSoQuy(int maSoQuy, int maBoPhan, int nam)
        {
            //return DataPortal.Create<SoDuSoQuy>(new Criteria(maSoQuy, maBoPhan, nam));
            SoDuSoQuy sd = new SoDuSoQuy(maSoQuy, maBoPhan, nam);
            sd.MarkAsChild();

            return sd;

        }

        //long

        public static SoDuSoQuy NewSoDuSoQuy(int nam)
        {
            //return DataPortal.Create<SoDuSoQuy>(new Criteria(maSoQuy, maBoPhan, nam));
            SoDuSoQuy sd = new SoDuSoQuy(nam);
            sd.MarkAsChild();

            return sd;

        }

        public static SoDuSoQuy NewSoDuSoQuy()
        {
            SoDuSoQuy sd = new SoDuSoQuy();
            sd.MarkAsChild();

            return sd;
        }

        public static SoDuSoQuy GetSoDuSoQuy(int maSoQuy, int maBoPhan, int nam)
        {
            return DataPortal.Fetch<SoDuSoQuy>(new Criteria(maSoQuy, maBoPhan, nam));
        }

        public static void DeleteSoDuSoQuy(int maSoQuy, int maBoPhan, int nam)
        {
            DataPortal.Delete(new Criteria(maSoQuy, maBoPhan, nam));
        }

        #endregion //Factory Methods

        #region Child Factory Methods

        internal static SoDuSoQuy NewSoDuSoQuyChild(int maSoQuy, int maBoPhan, int nam)
        {
            SoDuSoQuy child = new SoDuSoQuy(maSoQuy, maBoPhan, nam);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static SoDuSoQuy GetSoDuSoQuy(SafeDataReader dr)
        {
            SoDuSoQuy child = new SoDuSoQuy();
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
            public int MaSoQuy;
            public int MaBoPhan;
            public int Nam;

            public Criteria(int maSoQuy, int maBoPhan, int nam)
            {
                this.MaSoQuy = maSoQuy;
                this.MaBoPhan = maBoPhan;
                this.Nam = nam;
            }
        }
        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _maSoQuy = criteria.MaSoQuy;
            _maBoPhan = criteria.MaBoPhan;
            _nam = criteria.Nam;
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

                cm.CommandText = "spd_SelecttblSoDuSoQuy";

                cm.Parameters.AddWithValue("@MaSoQuy", criteria.MaSoQuy);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);

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

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maSoQuy, _maBoPhan, _nam));
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
                cm.CommandText = "spd_DeletetblSoDuSoQuy";

                cm.Parameters.AddWithValue("@MaSoQuy", criteria.MaSoQuy);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);

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
            _maSoQuy = dr.GetInt32("MaSoQuy");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _soDuNo = dr.GetDecimal("SoDuNo");
            _soDuCo = dr.GetDecimal("SoDuCo");
            _luyKeNo = dr.GetDecimal("LuyKeNo");
            _luyKeCo = dr.GetDecimal("LuyKeCo");
            _nam = dr.GetInt32("Nam");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            if (this._maSoQuy > 0)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblSoDuSoQuy";

                    AddInsertParameters(cm);

                    cm.ExecuteNonQuery();

                }//using
            }
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@SoDuNo", _soDuNo);
            cm.Parameters.AddWithValue("@SoDuCo", _soDuCo);
            cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            cm.Parameters.AddWithValue("@Nam", _nam);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblSoDuSoQuy";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@SoDuNo", _soDuNo);
            cm.Parameters.AddWithValue("@SoDuCo", _soDuCo);
            cm.Parameters.AddWithValue("@LuyKeNo", _luyKeNo);
            cm.Parameters.AddWithValue("@LuyKeCo", _luyKeCo);
            cm.Parameters.AddWithValue("@Nam", _nam);
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

            ExecuteDelete(tr, new Criteria(_maSoQuy, _maBoPhan, _nam));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

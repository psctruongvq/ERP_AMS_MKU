
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class KyKetChuyenCongCuDungCu : Csla.BusinessBase<KyKetChuyenCongCuDungCu>
    {
        #region Business Properties and Methods

        //declare members
        private int _maKetChuyen = 0;
        private int _maKy = 0;
        private int _maBoPhan = 0;
        private SmartDate _ngayKetChuyen = new SmartDate(DateTime.Today);

        //declare child member(s)
        private CT_KetChuyenCongCuDungCuList _cT_KetChuyenCongCuDungCuList = CT_KetChuyenCongCuDungCuList.NewCT_KetChuyenCongCuDungCuList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaKetChuyen
        {
            get
            {
                return _maKetChuyen;
            }
        }

        public int MaKy
        {
            get
            {
                return _maKy;
            }
            set
            {
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged("MaKy");
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

        public DateTime NgayKetChuyen
        {
            get
            {
                return _ngayKetChuyen.Date;
            }
        }

        public string NgayKetChuyenString
        {
            get
            {
                return _ngayKetChuyen.Text;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ngayKetChuyen.Equals(value))
                {
                    _ngayKetChuyen.Text = value;
                    PropertyHasChanged("NgayKetChuyenString");
                }
            }
        }

        public CT_KetChuyenCongCuDungCuList CT_KetChuyenCongCuDungCuList
        {
            get
            {
                return _cT_KetChuyenCongCuDungCuList;
            }
            set
            {
                CanWriteProperty("CT_KetChuyenCongCuDungCuList", true);

                _cT_KetChuyenCongCuDungCuList = value;
                PropertyHasChanged("CT_KetChuyenCongCuDungCuList");
            }


        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_KetChuyenCongCuDungCuList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_KetChuyenCongCuDungCuList.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maKetChuyen;
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
        private KyKetChuyenCongCuDungCu()
        { /* require use of factory method */ }

        public static KyKetChuyenCongCuDungCu NewKyKetChuyenCongCuDungCu()
        {
            return DataPortal.Create<KyKetChuyenCongCuDungCu>();
        }

        public static KyKetChuyenCongCuDungCu GetKyKetChuyenCongCuDungCu(int maKetChuyen)
        {
            return DataPortal.Fetch<KyKetChuyenCongCuDungCu>(new Criteria(maKetChuyen));
        }

        public static KyKetChuyenCongCuDungCu GetKyKetChuyenCongCuDungCu(int maKy, int maBoPhan)
        {
            return DataPortal.Fetch<KyKetChuyenCongCuDungCu>(new Criteria_MaKy_MaBoPhan(maKy,maBoPhan));
        }

        public static void DeleteKyKetChuyenCongCuDungCu(int maKetChuyen)
        {
            DataPortal.Delete(new Criteria(maKetChuyen));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KyKetChuyenCongCuDungCu NewKyKetChuyenCongCuDungCuChild()
        {
            KyKetChuyenCongCuDungCu child = new KyKetChuyenCongCuDungCu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static KyKetChuyenCongCuDungCu GetKyKetChuyenCongCuDungCu(SafeDataReader dr)
        {
            KyKetChuyenCongCuDungCu child = new KyKetChuyenCongCuDungCu();
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
            public int MaKetChuyen;

            public Criteria(int maKetChuyen)
            {
                this.MaKetChuyen = maKetChuyen;
            }
        }

        private class Criteria_MaKy_MaBoPhan
        {
            public int MaKy;
            public int MaBoPhan;

            public Criteria_MaKy_MaBoPhan(int maKy, int maBoPhan)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
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
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenCongCuDungCu";//\\
                    cm.Parameters.AddWithValue("@MaKetChuyen", ((Criteria)criteria).MaKetChuyen);
                }
                if (criteria is Criteria_MaKy_MaBoPhan)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenCongCuDungCu_MaKy_MaBoPhan";//\\
                    cm.Parameters.AddWithValue("@MaKy", ((Criteria_MaKy_MaBoPhan)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((Criteria_MaKy_MaBoPhan)criteria).MaBoPhan);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read()) //Thang
                    {

                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
            DataPortal_Delete(new Criteria(_maKetChuyen));
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
                cm.CommandText = "spd_DeletetblKyKetChuyenCongCuDungCu";//\\

                cm.Parameters.AddWithValue("@MaKetChuyen", criteria.MaKetChuyen);

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
            _maKetChuyen = dr.GetInt32("MaKetChuyen");
            _maKy = dr.GetInt32("MaKy");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _ngayKetChuyen = dr.GetSmartDate("NgayKetChuyen", _ngayKetChuyen.EmptyIsMin);
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //dr.NextResult();
            _cT_KetChuyenCongCuDungCuList = CT_KetChuyenCongCuDungCuList.GetCT_KetChuyenCongCuDungCuList(this.MaKetChuyen);
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblKyKetChuyenCongCuDungCu";//\\

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maKetChuyen = (int)cm.Parameters["@MaKetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
            cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            cm.Parameters["@MaKetChuyen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKyKetChuyenCongCuDungCu";//\\

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            if (_maKy != 0)
                cm.Parameters.AddWithValue("@MaKy", _maKy);
            else
                cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_KetChuyenCongCuDungCuList.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maKetChuyen));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NgoaiGio_ChiTiet : Csla.BusinessBase<NgoaiGio_ChiTiet>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maChiTiet = 0;
        private int _maNgoaiGio = 0;
        private int _maLoai = 0;
        private decimal _soGio = 0;
        private int _loaiDuyet = 0;
        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public int MaNgoaiGio
        {
            get
            {
                return _maNgoaiGio;
            }
            set
            {
                if (!_maNgoaiGio.Equals(value))
                {
                    _maNgoaiGio = value;
                    PropertyHasChanged("MaNgoaiGio");
                }
            }
        }

        public int MaLoai
        {
            get
            {
                return _maLoai;
            }
            set
            {
                if (!_maLoai.Equals(value))
                {
                    _maLoai = value;
                    PropertyHasChanged("MaLoai");
                }
            }
        }

        public decimal SoGio
        {
            get
            {
                return _soGio;
            }
            set
            {
                if (!_soGio.Equals(value))
                {
                    _soGio = value;
                    PropertyHasChanged("SoGio");
                }
            }
        }

        public int LoaiDuyet
        {
            get
            {
                return _loaiDuyet;
            }
            set
            {
                if (!_loaiDuyet.Equals(value))
                {
                    _loaiDuyet = value;
                    PropertyHasChanged();
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
        public NgoaiGio_ChiTiet()
        { /* require use of factory method */ }

        public static NgoaiGio_ChiTiet NewNgoaiGio_ChiTiet()
        {
            return DataPortal.Create<NgoaiGio_ChiTiet>();
        }

        public static NgoaiGio_ChiTiet GetNgoaiGio_ChiTiet(int maChiTiet)
        {
            return DataPortal.Fetch<NgoaiGio_ChiTiet>(new Criteria(maChiTiet));
        }

        public static void DeleteNgoaiGio_ChiTiet(int maChiTiet)
        {
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        public static NgoaiGio_ChiTiet NewNgoaiGio_ChiTietChild()
        {
            NgoaiGio_ChiTiet child = new NgoaiGio_ChiTiet();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NgoaiGio_ChiTiet GetNgoaiGio_ChiTiet(SafeDataReader dr)
        {
            NgoaiGio_ChiTiet child = new NgoaiGio_ChiTiet();
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
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                this.MaChiTiet = maChiTiet;
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
                cm.CommandText = "spd_Select_NgoaiGio_ChiTiet";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            DataPortal_Delete(new Criteria(_maChiTiet));
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
                cm.CommandText = "spd_Delete_NgoaiGio_ChiTiet";

                cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maNgoaiGio = dr.GetInt32("MaNgoaiGio");
            _maLoai = dr.GetInt32("MaLoai");
            _soGio = dr.GetDecimal("SoGio");
            _loaiDuyet = dr.GetInt32("LoaiDuyet");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, NgoaiGio_TongHop parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, NgoaiGio_TongHop parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_NgoaiGio_ChiTiet";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, NgoaiGio_TongHop parent)
        {
            _maNgoaiGio = parent.MaNgoaiGio;
            cm.Parameters.AddWithValue("@MaNgoaiGio", _maNgoaiGio);
            cm.Parameters.AddWithValue("@MaLoai", _maLoai);
            cm.Parameters.AddWithValue("@SoGio", _soGio);
            cm.Parameters.AddWithValue("@LoaiDuyet", _loaiDuyet);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, NgoaiGio_TongHop parent)
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

        private void ExecuteUpdate(SqlTransaction tr, NgoaiGio_TongHop parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_NgoaiGio_ChiTiet";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, NgoaiGio_TongHop parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaNgoaiGio", _maNgoaiGio);
            cm.Parameters.AddWithValue("@MaLoai", _maLoai);
            cm.Parameters.AddWithValue("@SoGio", _soGio);
            cm.Parameters.AddWithValue("@LoaiDuyet", _loaiDuyet);
           // cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
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

            ExecuteDelete(tr, new Criteria(_maChiTiet));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        public void SetLoaiDuyet(int MaBoPhan, int MaLoai)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_DuyetChamNgoaiGio";
                cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                cm.Parameters.AddWithValue("@MaLoai", MaLoai);
                bool khongduyet = false;
                khongduyet = Convert.ToBoolean(cm.ExecuteScalar());
                cn.Close();
                if (khongduyet)
                    _loaiDuyet = 2;
            }
        }
    }
}

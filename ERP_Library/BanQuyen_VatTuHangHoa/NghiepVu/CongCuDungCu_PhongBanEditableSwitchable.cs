
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CongCuDungCu_PhongBan : Csla.BusinessBase<CongCuDungCu_PhongBan>
    {
        #region Business Properties and Methods
        //reference object
        BoPhan _boPhan = null;
        public BoPhan BoPhan
        {
            get
            {
                if ((_boPhan == null && _maBoPhan != 0) || (_boPhan != null && _boPhan.MaBoPhan != _maBoPhan))
                {
                    _boPhan = BoPhan.GetBoPhanKeCaBoPhanMoRong(_maBoPhan);//.GetBoPhan(_maBoPhan);
                }
                
                return _boPhan;
            }
            //set { _boPhan = value; }
        }
        //declare members
        private int _maPhanBo = 0;
        private int _maCongCuDungCu = 0;
        private int _maBoPhan = 0;
        private SmartDate _ngayNhan = new SmartDate(true);
        private SmartDate _denNgay = new SmartDate(true);

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaPhanBo
        {
            get
            {
                CanReadProperty("MaPhanBo", true);
                return _maPhanBo;
            }
        }

        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaCongCuDungCu", true);
                if (!_maCongCuDungCu.Equals(value))
                {
                    _maCongCuDungCu = value;
                    PropertyHasChanged("MaCongCuDungCu");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public DateTime NgayNhan
        {
            get
            {
                CanReadProperty("NgayNhan", true);
                return _ngayNhan.Date;
            }

            set
            {
                CanWriteProperty("NgayNhan", true);
                if (!_ngayNhan.Equals(value))
                {
                    _ngayNhan = new SmartDate(value);
                    PropertyHasChanged("NgayNhan");
                }
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
        }


        protected override object GetIdValue()
        {
            return _maPhanBo;
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
            //TODO: Define authorization rules in CongCuDungCu_PhongBan
            //AuthorizationRules.AllowRead("MaPhanBo", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("NgayNhan", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("NgayNhanString", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "CongCuDungCu_PhongBanReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "CongCuDungCu_PhongBanReadGroup");

            //AuthorizationRules.AllowWrite("MaCongCuDungCu", "CongCuDungCu_PhongBanWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "CongCuDungCu_PhongBanWriteGroup");
            //AuthorizationRules.AllowWrite("NgayNhanString", "CongCuDungCu_PhongBanWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "CongCuDungCu_PhongBanWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongCuDungCu_PhongBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCu_PhongBanViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongCuDungCu_PhongBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCu_PhongBanAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongCuDungCu_PhongBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCu_PhongBanEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongCuDungCu_PhongBan
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongCuDungCu_PhongBanDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongCuDungCu_PhongBan()
        { /* require use of factory method */ }

        public static CongCuDungCu_PhongBan NewCongCuDungCu_PhongBan()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongCuDungCu_PhongBan");
            return DataPortal.Create<CongCuDungCu_PhongBan>();
        }

        public static CongCuDungCu_PhongBan GetCongCuDungCu_PhongBan_ByMaPhanBo(int maPhanBo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongCuDungCu_PhongBan");
            return DataPortal.Fetch<CongCuDungCu_PhongBan>(new CriteriaByMaPhanBo(maPhanBo));
        }
        public static CongCuDungCu_PhongBan GetCongCuDungCu_PhongBan(int maCongCuDungCu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongCuDungCu_PhongBan");
            return DataPortal.Fetch<CongCuDungCu_PhongBan>(new CriteriaByMaCongCuDungCu(maCongCuDungCu));
        }
        public static void DeleteCongCuDungCu_PhongBan(int maPhanBo)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongCuDungCu_PhongBan");
            DataPortal.Delete(new CriteriaByMaCongCuDungCu(maPhanBo));
        }

        public override CongCuDungCu_PhongBan Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongCuDungCu_PhongBan");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongCuDungCu_PhongBan");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CongCuDungCu_PhongBan");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CongCuDungCu_PhongBan NewCongCuDungCu_PhongBanChild()
        {
            CongCuDungCu_PhongBan child = new CongCuDungCu_PhongBan();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CongCuDungCu_PhongBan GetCongCuDungCu_PhongBan(SafeDataReader dr)
        {
            CongCuDungCu_PhongBan child = new CongCuDungCu_PhongBan();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class CriteriaByMaCongCuDungCu
        {
            public int MaCongCuDungCu;

            public CriteriaByMaCongCuDungCu(int maCongCuDungCu)
            {
                this.MaCongCuDungCu = maCongCuDungCu;
            }
        }

        [Serializable()]
        private class CriteriaByMaPhanBo
        {
            public int MaPhanBo;

            public CriteriaByMaPhanBo(int maPhanBo)
            {
                this.MaPhanBo = maPhanBo;
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
            if (criteria is CriteriaByMaPhanBo)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_ByMaPhanBo(tr, criteria as CriteriaByMaPhanBo);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is CriteriaByMaCongCuDungCu)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch(tr, criteria as CriteriaByMaCongCuDungCu);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
        }
        private void ExecuteFetch_ByMaPhanBo(SqlTransaction tr, CriteriaByMaPhanBo criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblCongCuDungCu_PhongBan";

                cm.Parameters.AddWithValue("@MaPhanBo", criteria.MaPhanBo);

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
        private void ExecuteFetch(SqlTransaction tr, CriteriaByMaCongCuDungCu criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblCongCuDungCu_PhongBansByAndMaCongCuDungCu";

                cm.Parameters.AddWithValue("@MaCongCuDungCu", criteria.MaCongCuDungCu);

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
            DataPortal_Delete(new CriteriaByMaPhanBo(_maPhanBo));
        }

        private void DataPortal_Delete(CriteriaByMaPhanBo criteria)
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

        private void ExecuteDelete(SqlTransaction tr, CriteriaByMaPhanBo criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCongCuDungCu_PhongBan";

                cm.Parameters.AddWithValue("@MaPhanBo", criteria.MaPhanBo);

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
            _maPhanBo = dr.GetInt32("MaPhanBo");
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _ngayNhan = dr.GetSmartDate("NgayNhan", _ngayNhan.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
        }

        private void FetchChildren(SafeDataReader dr)
        {
            //_boPhan = BoPhan.GetBoPhan(_maBoPhan);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, CongCuDungCu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, object parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongCuDungCu_PhongBan";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maPhanBo = (int)cm.Parameters["@MaPhanBo"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, object parent)
        {
            if (parent != null)
            {
                if (parent is CongCuDungCu)
                {
                    _maCongCuDungCu = (parent as CongCuDungCu).MaCongCuDungCu;
                }
            }
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
            cm.Parameters["@MaPhanBo"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, CongCuDungCu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, CongCuDungCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongCuDungCu_PhongBan";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, CongCuDungCu parent)
        {
            cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayNhan", _ngayNhan.Date);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {

            if (IsNew) return;

            ExecuteDelete(tr, new CriteriaByMaPhanBo(_maPhanBo));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

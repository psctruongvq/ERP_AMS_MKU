
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class InLoatHDLD : Csla.BusinessBase<InLoatHDLD>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private long _manhanvien = 0;
        private string _MaqlNhanvien = string.Empty;
        private string _tenNhanvien = string.Empty;
        private long _MaHopDongLaoDong = 0;
        private bool _chon = false;
        private string _SoHDLD = string.Empty;
        private DateTime _ngayky;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public long Manhanvien
        {
            get
            {
                CanReadProperty("Manhanvien", true);
                return _manhanvien;
            }
            set
            {
                CanWriteProperty("Manhanvien", true);
                if (!_manhanvien.Equals(value))
                {
                    _manhanvien = value;
                    PropertyHasChanged("Manhanvien");
                }
            }
        }
        public long Mahopdonglaodong
        {
            get
            {
                CanReadProperty("Mahopdonglaodong", true);
                return _MaHopDongLaoDong;
            }

        }

        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
        public string Tennhanvien
        {
            get
            {
                CanReadProperty(true);
                return _tenNhanvien;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tenNhanvien.Equals(value))
                {
                    _tenNhanvien = value;
                    PropertyHasChanged();
                }
            }
        }
        public string MaqlNhanvien
        {
            get
            {
                CanReadProperty(true);
                return _MaqlNhanvien;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_MaqlNhanvien.Equals(value))
                {
                    _MaqlNhanvien = value;
                    PropertyHasChanged();
                }
            }
        }
        public string SoHDLD

        {
            get
            {
                CanReadProperty(true);
                return _SoHDLD;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_SoHDLD.Equals(value))
                {
                    _SoHDLD = value;
                    PropertyHasChanged();
                }
            }
        }
        public DateTime Ngayky
        {
            get
            {
                CanReadProperty(true);
                return _ngayky;
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
            //TODO: Define authorization rules in InLoatHDLD
            //AuthorizationRules.AllowRead("Id", "InLoatHDLDReadGroup");
            //AuthorizationRules.AllowRead("Manhanvien", "InLoatHDLDReadGroup");
            //AuthorizationRules.AllowRead("Chon", "InLoatHDLDReadGroup");

            //AuthorizationRules.AllowWrite("Manhanvien", "InLoatHDLDWriteGroup");
            //AuthorizationRules.AllowWrite("Chon", "InLoatHDLDWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in InLoatHDLD
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in InLoatHDLD
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in InLoatHDLD
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in InLoatHDLD
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("InLoatHDLDDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private InLoatHDLD()
        { /* require use of factory method */ }

        public static InLoatHDLD NewInLoatHDLD()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InLoatHDLD");
            return DataPortal.Create<InLoatHDLD>();
        }

        public static InLoatHDLD GetInLoatHDLD(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a InLoatHDLD");
            return DataPortal.Fetch<InLoatHDLD>(new Criteria(id));
        }

        public static void DeleteInLoatHDLD(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a InLoatHDLD");
            DataPortal.Delete(new Criteria(id));
        }

        public override InLoatHDLD Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a InLoatHDLD");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a InLoatHDLD");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a InLoatHDLD");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static InLoatHDLD NewInLoatHDLDChild()
        {
            InLoatHDLD child = new InLoatHDLD();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static InLoatHDLD GetInLoatHDLD(SafeDataReader dr)
        {
            InLoatHDLD child = new InLoatHDLD();
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
            public long Id;

            public Criteria(long id)
            {
                this.Id = id;
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
                cm.CommandText = "spd_SelecttblnsInLoatHDLD";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblnsInLoatHDLD";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            ThongTinNhanVienTongHop _TTNhanvien;
            HDLaoDong _HDLD;            
            _id = dr.GetInt64("ID");
            _manhanvien = dr.GetInt64("Manhanvien");
            _MaHopDongLaoDong = dr.GetInt64("Mahopdonglaodong");
            _ngayky = dr.GetDateTime("Ngayky");
            //_HDLD = HDLaoDong.GetHDLaoDong(_MaHopDongLaoDong);
           // _SoHDLD = _HDLD.SoHopDong;
            _TTNhanvien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_manhanvien);
            _tenNhanvien = _TTNhanvien.TenNhanVien;
            _MaqlNhanvien = _TTNhanvien.MaQLNhanVien;
            _chon = dr.GetBoolean("Chon");
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsInLoatHDLD";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_manhanvien != 0)
                cm.Parameters.AddWithValue("@Manhanvien", _manhanvien);
            else
                cm.Parameters.AddWithValue("@Manhanvien", DBNull.Value);
            if (_chon != false)
                cm.Parameters.AddWithValue("@Chon", _chon);
            else
                cm.Parameters.AddWithValue("@Chon", DBNull.Value);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsInLoatHDLD";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_manhanvien != 0)
                cm.Parameters.AddWithValue("@Manhanvien", _manhanvien);
            else
                cm.Parameters.AddWithValue("@Manhanvien", DBNull.Value);
            if (_chon != false)
                cm.Parameters.AddWithValue("@Chon", _chon);
            else
                cm.Parameters.AddWithValue("@Chon", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        private void LayDanhsachKyMoi(int maBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                    cn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Spd_InserttblnsInLoatHDLDbybohan";
                    command.Parameters.AddWithValue("@mabophan", maBoPhan);
                    command.ExecuteNonQuery();
            }
        }
    }
}

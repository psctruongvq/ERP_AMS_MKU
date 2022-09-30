
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class DoiTuongTheoDoi : Csla.BusinessBase<DoiTuongTheoDoi>
    {
        #region Business Properties and Methods

        //declare members
        private long _maDoiTuongTheoDoi = 0;
        private long _maDoiTuong = 0;
        private int _maTaiKhoan = 0;
        private bool _xoa = false;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;

        private long _MaNguoiPhuTrachChinh = 0;
        private string _TenNguoiPhuTrachChinh = string.Empty;

        private string _TenDoiTuong = string.Empty;

        public int MaBoPhan
        {
            get { return ERP_Library.Security.CurrentUser.Info.MaBoPhan; }
            
        }

        private int _NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;



        [System.ComponentModel.DataObjectField(true, true)]

        public bool Check { get; set; }


        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        public int NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return ERP_Library.Security.CurrentUser.Info.UserID;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_NguoiLap.Equals(value))
                {
                    _NguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
           
        }
        public long MaDoiTuongTheoDoi
        {
            get
            {
                CanReadProperty("MaDoiTuongTheoDoi", true);
                return _maDoiTuongTheoDoi;
            }
        }

        public long MaDoiTuong
        {
            get
            {
                CanReadProperty("MaDoiTuong", true);
                return _maDoiTuong;
            }
            set
            {
                CanWriteProperty("MaDoiTuong", true);
                if (!_maDoiTuong.Equals(value))
                {
                    _maDoiTuong = value;
                    if (_maDoiTuong != 0)
                    {
                        //DoiTac dt = DoiTac.GetDoiTacForDoiTuongTheoDoi(_maDoiTuong);
                        DoiTuongAll dt = DoiTuongAll.GetDoiTuongAll(_maDoiTuong);
                        _TenDoiTuong = dt.TenDoiTuong;
                    }
                    PropertyHasChanged("MaDoiTuong");
                }
            }
        }

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }

        public long MaNguoiPhuTrachChinh
        {
            get
            {
                CanReadProperty("MaNguoiPhuTrachChinh", true);
                return _MaNguoiPhuTrachChinh;
            }
            set
            {
                CanWriteProperty("MaNguoiPhuTrachChinh", true);
                if (!_MaNguoiPhuTrachChinh.Equals(value))
                {
                    _MaNguoiPhuTrachChinh = value;
                    PropertyHasChanged("MaNguoiPhuTrachChinh");
                }
            }
        }

        public string TenNguoiPhuTrachChinh
        {
            get
            {
                CanReadProperty("TenNguoiPhuTrachChinh", true);
                return _TenNguoiPhuTrachChinh;
            }
        }

        public string TenDoiTuong
        {
            get
            {
                CanReadProperty("TenDoiTuong", true);
                return _TenDoiTuong;
            }
        }

        public bool Xoa
        {
            get { return _xoa; }
            set { _xoa = value; }
        }
        protected override object GetIdValue()
        {
            return _maDoiTuongTheoDoi;
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
            //TODO: Define authorization rules in DoiTuongTheoDoi
            //AuthorizationRules.AllowRead("MaDoiTuongTheoDoi", "DoiTuongTheoDoiReadGroup");
            //AuthorizationRules.AllowRead("MaDoiTuong", "DoiTuongTheoDoiReadGroup");
            //AuthorizationRules.AllowRead("MaTaiKhoan", "DoiTuongTheoDoiReadGroup");

            //AuthorizationRules.AllowWrite("MaDoiTuong", "DoiTuongTheoDoiWriteGroup");
            //AuthorizationRules.AllowWrite("MaTaiKhoan", "DoiTuongTheoDoiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DoiTuongTheoDoi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongTheoDoiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DoiTuongTheoDoi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongTheoDoiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DoiTuongTheoDoi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongTheoDoiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DoiTuongTheoDoi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DoiTuongTheoDoiDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DoiTuongTheoDoi()
        { /* require use of factory method */ }
        private DoiTuongTheoDoi(int maTaiKhoan,long maDoiTuong)
        {
            this.MaTaiKhoan = maTaiKhoan;
            this.MaDoiTuong = maDoiTuong;
        }
        public static DoiTuongTheoDoi NewDoiTuongTheoDoi()
        {
            DoiTuongTheoDoi item = new DoiTuongTheoDoi();
            item.MarkAsChild();
            return item;
        }
        public static DoiTuongTheoDoi NewDoiTuongTheoDoi(int maTaiKhoan, long maDoiTuong)
        {
            return new DoiTuongTheoDoi(maTaiKhoan, maDoiTuong);
        }
        public static DoiTuongTheoDoi GetDoiTuongTheoDoi(long maDoiTuongTheoDoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTuongTheoDoi");
            return DataPortal.Fetch<DoiTuongTheoDoi>(new Criteria(maDoiTuongTheoDoi));
        }

        public static void DeleteDoiTuongTheoDoi(long maDoiTuongTheoDoi)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTuongTheoDoi");
            DataPortal.Delete(new Criteria(maDoiTuongTheoDoi));
        }

        public override DoiTuongTheoDoi Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DoiTuongTheoDoi");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongTheoDoi");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DoiTuongTheoDoi");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DoiTuongTheoDoi NewDoiTuongTheoDoiChild()
        {
            DoiTuongTheoDoi child = new DoiTuongTheoDoi();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DoiTuongTheoDoi GetDoiTuongTheoDoi(SafeDataReader dr)
        {
            DoiTuongTheoDoi child = new DoiTuongTheoDoi();
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
            public long MaDoiTuongTheoDoi;

            public Criteria(long maDoiTuongTheoDoi)
            {
                this.MaDoiTuongTheoDoi = maDoiTuongTheoDoi;
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
                cm.CommandText = "GetDoiTuongTheoDoi";

                cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", criteria.MaDoiTuongTheoDoi);

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
            DataPortal_Delete(new Criteria(_maDoiTuongTheoDoi));
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
                cm.CommandText = "sp_DeletetblDoiTuongTheoDoi";

                cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", criteria.MaDoiTuongTheoDoi);

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
            _maDoiTuongTheoDoi = dr.GetInt64("MaDoiTuongTheoDoi");
            _maDoiTuong = dr.GetInt64("MaDoiTuong");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _NguoiLap = dr.GetInt32("NguoiLap");
            _maBoPhan = dr.GetInt32("MaBoPhan");

            _MaNguoiPhuTrachChinh = dr.GetInt64("MaNguoiPhuTrachChinh");
            _TenNguoiPhuTrachChinh = dr.GetString("TenNguoiPhuTrachChinh");
            _TenDoiTuong = dr.GetString("TenDoiTuong");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DoiTac parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr,parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblDoiTuongTheoDoi";

                AddInsertParameters(cm,parent);

                cm.ExecuteNonQuery();

                _maDoiTuongTheoDoi = (long)cm.Parameters["@MaDoiTuongTheoDoi"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm,DoiTac parent)
        {
            cm.Parameters.AddWithValue("@MaDoiTuong", parent.MaDoiTac);

            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", _maDoiTuongTheoDoi);
            cm.Parameters.AddWithValue("@NguoiLap", _NguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

            if (_MaNguoiPhuTrachChinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", _MaNguoiPhuTrachChinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", DBNull.Value);

            cm.Parameters["@MaDoiTuongTheoDoi"].Direction = ParameterDirection.Output;
        }
        //-==================
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
                cm.CommandText = "sp_InserttblDoiTuongTheoDoi";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDoiTuongTheoDoi = (long)cm.Parameters["@MaDoiTuongTheoDoi"].Value;
            }//using
        }

        

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", _maDoiTuongTheoDoi);
            cm.Parameters.AddWithValue("@NguoiLap", _NguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

            if (_MaNguoiPhuTrachChinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", _MaNguoiPhuTrachChinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", DBNull.Value);

            cm.Parameters["@MaDoiTuongTheoDoi"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr,DoiTac parent)
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

        private void ExecuteUpdate(SqlTransaction tr,DoiTac parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblDoiTuongTheoDoi";

                AddUpdateParameters(cm,parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm,DoiTac parent)
        {
            cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", _maDoiTuongTheoDoi);

            cm.Parameters.AddWithValue("@MaDoiTuong", parent.MaDoiTac);//

            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiLap", _NguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@Xoa", _xoa);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

            if (_MaNguoiPhuTrachChinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", _MaNguoiPhuTrachChinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", DBNull.Value);
        }
        //======================
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
                cm.CommandText = "sp_UpdatetblDoiTuongTheoDoi";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDoiTuongTheoDoi", _maDoiTuongTheoDoi);
            if (_maDoiTuong != 0)
                cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
            else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiLap", _NguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@Xoa", _xoa);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

            if (_MaNguoiPhuTrachChinh != 0)
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", _MaNguoiPhuTrachChinh);
            else
                cm.Parameters.AddWithValue("@MaNguoiPhuTrachChinh", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maDoiTuongTheoDoi));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

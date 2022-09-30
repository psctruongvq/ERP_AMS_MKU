
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library;

namespace ERP_Library
{
    [Serializable()]
    public class BangCatCong : Csla.BusinessBase<BangCatCong>
    {
        #region Business Properties and Methods

        //declare members
        private int _maBangCatCong = 0;
        private SmartDate _ngayCatCong = new SmartDate(DateTime.Today);
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;

        public int MaBangCatCong
        {
            get
            {
                CanReadProperty("MaBangCatCong", true);
                return _maBangCatCong;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public DateTime NgayCatCong
        {
            get
            {
                CanReadProperty("NgayCatCong", true);
                return _ngayCatCong.Date;
            }
            set
            {
                CanWriteProperty("NgayCatCong", true);

                if (!_ngayCatCong.Equals(value))
                {
                    _ngayCatCong = new SmartDate(value);
                    PropertyHasChanged("NgayCatCong");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {

                CanWriteProperty("TenBoPhan", true);
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
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

        protected override object GetIdValue()
        {
            return string.Format("{0}:{1}", _ngayCatCong, _maBoPhan);
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
            // NgayCatCong
            //
            
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
            //TODO: Define authorization rules in BangCatCong
            //AuthorizationRules.AllowRead("MaBangCatCong", "BangCatCongReadGroup");
            //AuthorizationRules.AllowRead("NgayCatCong", "BangCatCongReadGroup");
            //AuthorizationRules.AllowRead("NgayCatCongString", "BangCatCongReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "BangCatCongReadGroup");

        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangCatCong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCatCongViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangCatCong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCatCongAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangCatCong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCatCongEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangCatCong
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCatCongDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public BangCatCong()
        { /* require use of factory method */ }
        //public BangCatCong(int maBoPhan, DateTime ngayCatCong)
        //{
        //    this.MaBoPhan = maBoPhan;
        //    this.NgayCatCong = ngayCatCong;

        //}

        public static BangCatCong NewBangCatCong(SmartDate ngayCatCong, int maBoPhan)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCatCong");
            return DataPortal.Create<BangCatCong>(new Criteria(ngayCatCong, maBoPhan));
        }
        public static BangCatCong NewBangCatCong()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCatCong");
            return DataPortal.Create<BangCatCong>(new Criteria());
        }
        public static BangCatCong GetBangCatCong(SmartDate ngayCatCong, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCatCong");
            return DataPortal.Fetch<BangCatCong>(new Criteria(ngayCatCong, maBoPhan));
        }

        public static void DeleteBangCatCong(SmartDate ngayCatCong, int maBoPhan)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangCatCong");
            DataPortal.Delete(new Criteria(ngayCatCong, maBoPhan));
        }

        public override BangCatCong Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangCatCong");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCatCong");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BangCatCong");

            return base.Save();
        }

        //public static DataTable LayDSBoPhanChuaCatCong(SmartDate NgayCatCong)
        //{
        //    DataTable table=new DataTable();
        //    SqlDataAdapter da;

        //    SqlConnection cn = new SqlConnection(Database.ERP_Connection);
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "spd_LayDSBoPhanChuaCatCong";

        //        //AddUpdateParameters(cm, parent);

        //        cm.Parameters.AddWithValue("@NgayCatCong", DateTime.Parse(NgayCatCong.Text) );
        //        //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
        //        cn.Open();
        //        da = new SqlDataAdapter(cm);
        //        da.SelectCommand.ExecuteNonQuery();
        //        //cm.ExecuteNonQuery();
        //        da.Fill(table);
        //        return table;

        //        cn.Close();

        //    }//using
        //}
        //public static DataTable LayDSBoPhanDaCatCong(SmartDate NgayCatCong)
        //{
        //    DataTable table = new DataTable();
        //    SqlDataAdapter da;

        //    SqlConnection cn = new SqlConnection(Database.ERP_Connection);
        //    using (SqlCommand cm = cn.CreateCommand())
        //    {
        //        cm.CommandType = CommandType.StoredProcedure;
        //        cm.CommandText = "spd_LayDSBoPhanDaCatCong";

        //        //AddUpdateParameters(cm, parent);

        //        cm.Parameters.AddWithValue("@NgayCatCong", DateTime.Parse(NgayCatCong.Text));
        //        //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
        //        cn.Open();
        //        da = new SqlDataAdapter(cm);
        //        da.SelectCommand.ExecuteNonQuery();
        //        //cm.ExecuteNonQuery();
        //        da.Fill(table);
        //        return table;

        //        cn.Close();

        //    }//using
        //}
        #endregion //Factory Methods

        #region Child Factory Methods
        private BangCatCong(SmartDate ngayCatCong, int maBoPhan)
        {
            this._ngayCatCong = ngayCatCong;
            this._maBoPhan = maBoPhan;
        }

        internal static BangCatCong NewBangCatCongChild(SmartDate ngayCatCong, int maBoPhan)
        {
            BangCatCong child = new BangCatCong(ngayCatCong, maBoPhan);
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BangCatCong GetBangCatCong(SafeDataReader dr)
        {
            BangCatCong child = new BangCatCong();
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
            public SmartDate NgayCatCong;
            public int MaBoPhan;

            public Criteria(SmartDate ngayCatCong, int maBoPhan)
            {
                this.NgayCatCong = ngayCatCong;
                this.MaBoPhan = maBoPhan;
            }
            public Criteria(SmartDate ngayCatCong)
            {
                this.NgayCatCong = ngayCatCong;
            }
            public Criteria()
            {
               
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _ngayCatCong = criteria.NgayCatCong;
            _maBoPhan = criteria.MaBoPhan;
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_SelecttblnsBangCatCong]";

                cm.Parameters.AddWithValue("@NgayCatCong", criteria.NgayCatCong.DBValue);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn, null);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn, null);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_ngayCatCong, _maBoPhan));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_DeletetblnsBangCatCong]";

                cm.Parameters.AddWithValue("@NgayCatCong", criteria.NgayCatCong.DBValue);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
            _maBangCatCong = dr.GetInt32("MaBangCatCong");
            _ngayCatCong = dr.GetSmartDate("NgayCatCong", _ngayCatCong.EmptyIsMin);
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn, BangCatCongList parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn, BangCatCongList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_InserttblnsBangCatCong]";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

               // _maBangCatCong = (int)cm.Parameters["@NewMaBangCatCong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, BangCatCongList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@NgayCatCong", _ngayCatCong.DBValue);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            //cm.Parameters.AddWithValue("@NewMaBangCatCong", _maBangCatCong);
           // cm.Parameters["@NewMaBangCatCong"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlConnection cn, BangCatCongList parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteUpdate(SqlConnection cn, BangCatCongList parent)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_UpdatetblnsBangCatCong]";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, BangCatCongList parent)
        {
            cm.Parameters.AddWithValue("@MaBangCatCong", _maBangCatCong);
            cm.Parameters.AddWithValue("@NgayCatCong", _ngayCatCong.DBValue);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_ngayCatCong, _maBoPhan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


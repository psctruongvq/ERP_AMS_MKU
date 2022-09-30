
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KHCapPhatVatTuList : Csla.BusinessListBase<KHCapPhatVatTuList, KHCapPhatVatTu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KHCapPhatVatTu item = KHCapPhatVatTu.NewKHCapPhatVatTu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KHCapPhatVatTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KHCapPhatVatTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KHCapPhatVatTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KHCapPhatVatTuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KHCapPhatVatTuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KHCapPhatVatTuList()
        { /* require use of factory method */ }

        public static KHCapPhatVatTuList NewKHCapPhatVatTuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KHCapPhatVatTuList");
            return new KHCapPhatVatTuList();
        }

        public static KHCapPhatVatTuList GetKHCapPhatVatTuList(int maNguoiLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KHCapPhatVatTuList");
            return DataPortal.Fetch<KHCapPhatVatTuList>(new FilterCriteria(maNguoiLap));
        }

        public static KHCapPhatVatTuList GetKHCapPhatVatTuList(int checkDay,int maNguoiLap,string soKeHoach,int maBoPhan,DateTime tuNgay,DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KHCapPhatVatTuList");
            return DataPortal.Fetch<KHCapPhatVatTuList>(new FilterCriteria(checkDay,maNguoiLap,soKeHoach,maBoPhan,tuNgay,denNgay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaNguoiLap;

            public FilterCriteria(int maNguoiLap)
            {
                this.MaNguoiLap = maNguoiLap;
            }

            public int CheckDay;
            public string SoKeHoach;
            public int MaBoPhan=-1;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteria(int checkDay,int maNguoiLap, string soKeHoach, int maBoPhan, DateTime tuNgay, DateTime denNgay)
            {
                this.CheckDay = checkDay;
                this.MaNguoiLap = maNguoiLap;
                this.SoKeHoach = soKeHoach;
                this.MaBoPhan = maBoPhan;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;

            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

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

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            if(criteria.MaBoPhan==-1)
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectKeHoachCapPhatVatTusAll";
                    //cm.Parameters.AddWithValue("@MaNguoiLap", criteria.MaNguoiLap);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KHCapPhatVatTu.GetKHCapPhatVatTu(dr));
                    }
                }//using
            else
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectKeHoachCapPhatVatTuByAll";
                    cm.Parameters.AddWithValue("@CheckDay", criteria.CheckDay);
                    cm.Parameters.AddWithValue("@SoKeHoach", criteria.SoKeHoach);
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KHCapPhatVatTu.GetKHCapPhatVatTu(dr));
                    }
                }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

           SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (KHCapPhatVatTu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (KHCapPhatVatTu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

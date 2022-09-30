using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SoDuDauKyHList : Csla.BusinessListBase<SoDuDauKyHList, SoDuDauKyH>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            SoDuDauKyH item = SoDuDauKyH.NewSoDuDauKyH();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in SoDuDauKyHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in SoDuDauKyHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in SoDuDauKyHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in SoDuDauKyHList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("SoDuDauKyHListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private SoDuDauKyHList()
        { /* require use of factory method */ }

        public static SoDuDauKyHList NewSoDuDauKyHList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a SoDuDauKyHList");
            return new SoDuDauKyHList();
        }

        public static SoDuDauKyHList GetSoDuDauKyHList(int maKy, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a SoDuDauKyHList");
            return DataPortal.Fetch<SoDuDauKyHList>(new FilterCriteria(maKy, maBoPhan));
        }

        public static SoDuDauKyHList GetSoDuDauKyHList_TaiKhoanCon(int maKy, int maBoPhan)
        {
            SoDuDauKyHList list = new SoDuDauKyHList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spd_LaySoDuDauTaiKhoanH";
                    cm.CommandText = "spd_LaySoDuDauTaiKhoanT";
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@MaBoPhan",maBoPhan);
                    cm.Parameters.AddWithValue("@Action", "TaiKhoanCon");
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            list.Add(SoDuDauKyH.GetSoDuDauKyH(dr));
                    }
                }//using
            }//using
            return list;
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKy;
            public int MaBoPhan;

            public FilterCriteria(int maKy, int maBoPhan)
            {
                this.MaKy = maKy;
                this.MaBoPhan = maBoPhan;
            }
        }
              

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spd_LaySoDuDauTaiKhoanH";
                    cm.CommandText = "spd_LaySoDuDauTaiKhoanT";
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
               
                
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(SoDuDauKyH.GetSoDuDauKyH(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (SoDuDauKyH deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (SoDuDauKyH child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

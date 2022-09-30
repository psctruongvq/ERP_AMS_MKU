using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhanLoaiHopDongList : Csla.BusinessListBase<PhanLoaiHopDongList, PhanLoaiHopDong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhanLoaiHopDong item = PhanLoaiHopDong.NewPhanLoaiHopDong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in PhanLoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in PhanLoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in PhanLoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in PhanLoaiHopDongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("PhanLoaiHopDongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private PhanLoaiHopDongList()
        { /* require use of factory method */ }

        public static PhanLoaiHopDongList NewPhanLoaiHopDongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a PhanLoaiHopDongList");
            return new PhanLoaiHopDongList();
        }

        public static PhanLoaiHopDongList GetPhanLoaiHopDongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanLoaiHopDongList");
            return DataPortal.Fetch<PhanLoaiHopDongList>(new FilterCriteria());
        }

        public static PhanLoaiHopDongList GetPhanLoaiHopDongList(int maLoaiHopDong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanLoaiHopDongList");
            return DataPortal.Fetch<PhanLoaiHopDongList>(new FilterCriteria(maLoaiHopDong));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLoaiHopDong;

            public FilterCriteria()
            {

            }
            public FilterCriteria(int maLoaiHopDong)
            {
                this.MaLoaiHopDong = maLoaiHopDong;
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

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_SelecttblPhanLoaiHopDongsAll";
                cm.Parameters.AddWithValue("@MaLoaiHopDong", criteria.MaLoaiHopDong);
                cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(PhanLoaiHopDong.GetPhanLoaiHopDong(dr));
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
                foreach (PhanLoaiHopDong deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (PhanLoaiHopDong child in this)
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

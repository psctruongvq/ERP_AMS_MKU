
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinPhepNamList : Csla.BusinessListBase<ThongTinPhepNamList, ThongTinPhepNam>
    {
        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuaTrinhNghiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuaTrinhNghiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuaTrinhNghiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuaTrinhNghiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinPhepNamList()
        { /* require use of factory method */ }

        public static ThongTinPhepNamList GetThongTinPhepNamList(int MaChiNhanh, int MaPhongBan, int MaTo, int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<ThongTinPhepNamList>(new FilterCriteria(MaChiNhanh, MaPhongBan, MaTo, Nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaChiNhanh;
            public int MaPhongBan;
            public int MaTo;
            public int Nam;

            public FilterCriteria(int maChiNhanh, int maPhongBan, int maTo, int nam)
            {
                this.MaChiNhanh = maChiNhanh;
                this.MaPhongBan = maPhongBan;
                this.MaTo = maTo;
                this.Nam = nam;
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
                cm.CommandText = "spd_ThongTinNghiPhepNam";

                cm.Parameters.AddWithValue("@MaChiNhanh", criteria.MaChiNhanh);
                cm.Parameters.AddWithValue("@MaPhongBan", criteria.MaPhongBan);
                cm.Parameters.AddWithValue("@MaTo", criteria.MaTo);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinPhepNam.GetThongTinPhepNam(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch

        #region Data Access - Update
        //protected override void DataPortal_Update()
        //{
        //    RaiseListChangedEvents = false;

        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        // loop through each deleted child object
        //        foreach (ThongTinPhepNam deletedChild in DeletedList)
        //            deletedChild.DeleteSelf(cn);
        //        DeletedList.Clear();

        //        // loop through each non-deleted child object
        //        foreach (ThongTinPhepNam child in this)
        //        {
        //            if (child.IsNew)
        //                child.Insert(cn, this);
        //            else
        //                child.Update(cn, this);
        //        }
        //    }//using SqlConnection

        //    RaiseListChangedEvents = true;
        //}
        #endregion //Data Access - Update

        #endregion //Data Access
    }
}

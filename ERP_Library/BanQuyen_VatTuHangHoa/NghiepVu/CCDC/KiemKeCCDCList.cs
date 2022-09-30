using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class KiemKeCCDCList : Csla.BusinessListBase<KiemKeCCDCList, KiemKeCCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            KiemKeCCDC item = KiemKeCCDC.NewKiemKeCCDC();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in KiemKeCCDCList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in KiemKeCCDCList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in KiemKeCCDCList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in KiemKeCCDCList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("KiemKeCCDCListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private KiemKeCCDCList()
        { /* require use of factory method */ }

        public static KiemKeCCDCList NewKiemKeCCDCList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a KiemKeCCDCList");
            return new KiemKeCCDCList();
        }

        public static KiemKeCCDCList GetKiemKeCCDCList(int maPhongBan, int maCCDC, int maChiTietCCDC)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KiemKeCCDCList");
            return DataPortal.Fetch<KiemKeCCDCList>(new FilterCriteria(maPhongBan, maCCDC, maChiTietCCDC));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaPhongBan;
            public int MaCCDC;
            public int MaChiTietCCDC;

            public FilterCriteria(int maPhongBan, int maCCDC, int maChiTietCCDC)
            {
                this.MaPhongBan = maPhongBan;
                this.MaCCDC = maCCDC;
                this.MaChiTietCCDC = maChiTietCCDC;
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
                cm.CommandText = "GetKiemKeCCDCList";
                cm.Parameters.AddWithValue("@MaPhongBan", criteria.MaPhongBan);
                cm.Parameters.AddWithValue("@MaCCDC", criteria.MaCCDC);
                cm.Parameters.AddWithValue("@MaChiTietCCDC", criteria.MaChiTietCCDC);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KiemKeCCDC.GetKiemKeCCDC(dr));
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
                foreach (KiemKeCCDC deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (KiemKeCCDC child in this)
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

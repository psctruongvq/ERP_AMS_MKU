
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LuongBinhQuanList : Csla.BusinessListBase<LuongBinhQuanList, LuongBinhQuan>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LuongBinhQuanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuongBinhQuanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LuongBinhQuanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuongBinhQuanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LuongBinhQuanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuongBinhQuanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LuongBinhQuanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LuongBinhQuanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LuongBinhQuanList()
        { /* require use of factory method */ }

        public static LuongBinhQuanList NewLuongBinhQuanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LuongBinhQuanList");
            return new LuongBinhQuanList();
        }

        public static LuongBinhQuanList GetLuongBinhQuanList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuongBinhQuanList");
            return DataPortal.Fetch<LuongBinhQuanList>(new FilterCriteria(maNhanVien));
        }
        public static LuongBinhQuanList GetLuongBinhQuanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuongBinhQuanList");
            return DataPortal.Fetch<LuongBinhQuanList>(new Criteria());
        }
        public static LuongBinhQuanList GetLuongBinhQuanList_Bophan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuongBinhQuanList");
            return DataPortal.Fetch<LuongBinhQuanList>(new Criteria_Bophan(mabophan));
        }
        public static LuongBinhQuanList GetLuongBinhQuanList_NhanVien(int mabophan,string DkTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LuongBinhQuanList");
            return DataPortal.Fetch<LuongBinhQuanList>(new Criteria_NhanVien(mabophan,DkTim));
        }
        
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }
        private class Criteria
        {
            public Criteria()
            {

            }
        }
        private class Criteria_Bophan
        {
            public int mabophan;
            public Criteria_Bophan(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
        private class Criteria_NhanVien
        {
            public int mabophan;
            public string DKTim;
            public Criteria_NhanVien(int mabophan, string DKTim)
            {
                this.mabophan = mabophan;
                this.DKTim = DKTim;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object  criteria)
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsLuongBinhQuan";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                }
                else if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsLuongBinhQuansAll";
                }
                else if (criteria is Criteria_Bophan)
                {
                    cm.CommandText = "spd_SelecttblnsLuongbinhquan_bophan";
                    cm.Parameters.AddWithValue("@mabophan", ((Criteria_Bophan)criteria).mabophan);
                }
                else if (criteria is Criteria_NhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsLuongbinhquan_NhanVien";
                    cm.Parameters.AddWithValue("@mabophan", ((Criteria_NhanVien)criteria).mabophan);
                    cm.Parameters.AddWithValue("@DKTim", ((Criteria_NhanVien)criteria).DKTim);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LuongBinhQuan.GetLuongBinhQuan(dr));
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
                    foreach (LuongBinhQuan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LuongBinhQuan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

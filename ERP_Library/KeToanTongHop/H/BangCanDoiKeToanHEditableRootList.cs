
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangCanDoiKeToanListH : Csla.BusinessListBase<BangCanDoiKeToanListH, BangCanDoiKeToanH>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            BangCanDoiKeToanH item = BangCanDoiKeToanH.NewBangCanDoiKeToanH();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangCanDoiKeToanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangCanDoiKeToanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangCanDoiKeToanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangCanDoiKeToanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangCanDoiKeToanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangCanDoiKeToanListH()
        { /* require use of factory method */ }

        public static BangCanDoiKeToanListH NewBangCanDoiKeToanListH()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangCanDoiKeToanListH");
            return new BangCanDoiKeToanListH();
        }

        public static BangCanDoiKeToanListH NewBangCanDoiKeToanListHLoadMucCha(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriaLoadMucCha(maThongTu));
        }

        public static BangCanDoiKeToanListH GetBangCanDoiKeToanListH(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteria(maThongTu));
        }

        public static BangCanDoiKeToanListH GetBangCanDoiKeToanListH_ForTree(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriaForTree(maThongTu));
        }

        public static BangCanDoiKeToanListH GetBangCanDoiKeToanListHforNHNN(int maThongTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriaforNHNN(maThongTu));
        }

        public static BangCanDoiKeToanListH GetBangCanDoiKeToanListHbyMaThongTu(int maThongTu, byte isNHNN)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriabyMaThongTu(maThongTu, isNHNN));
        }

        public static BangCanDoiKeToanListH GetBangCanDoiKeToanListHCheckChild(int maMucTK)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
            return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriaCheckChild(maMucTK));
        }

        //public static BangCanDoiKeToanListH GetBangCanDoiKeToanListHCheckCha(int maMucTK)
        //{
        //    if (!CanGetObject())
        //        throw new System.Security.SecurityException("User not authorized to view a BangCanDoiKeToanListH");
        //    return DataPortal.Fetch<BangCanDoiKeToanListH>(new FilterCriteriaCheckCha(maMucTK));
        //}


        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria

        [Serializable()]
        private class FilterCriteriaForTree
        {
            public int MaThongTu = 0;

            public FilterCriteriaForTree(int maThongTu)
            {
                MaThongTu = maThongTu;

            }
        }

        [Serializable()]
        private class FilterCriteria
        {
            public int MaThongTu = 0;

            public FilterCriteria(int maThongTu)
            {
                MaThongTu = maThongTu;
                
            }
        }

        [Serializable()]
        private class FilterCriteriaLoadMucCha
        {
            public int MaThongTu = 0;

            public FilterCriteriaLoadMucCha(int maThongTu)
            {
                MaThongTu = maThongTu;
            }
        }

        [Serializable()]
        private class FilterCriteriaCheckChild
        {
            public int MaMucTK = 0;

            public FilterCriteriaCheckChild(int maMucTK)
            {
                MaMucTK = maMucTK;
            }
        }

        //[Serializable()]
        //private class FilterCriteriaCheckCha
        //{
        //    public int MaMucTK = 0;

        //    public FilterCriteriaCheckCha(int maMucTK)
        //    {
        //        MaMucTK = maMucTK;
        //    }
        //}

        [Serializable()]
        private class FilterCriteriaforNHNN
        {
            public int MaThongTu = 0;

            public FilterCriteriaforNHNN(int maThongTu)
            {
                MaThongTu = maThongTu;
            }
        }

        [Serializable()]
        private class FilterCriteriabyMaThongTu
        {
            public int MaThongTu = 0;
            public byte isNHNN = 0;

            public FilterCriteriabyMaThongTu(int maThongTu, byte _isNHNN)
            {
                MaThongTu = maThongTu;
                isNHNN = _isNHNN;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        public void UpdateMucCha(int maThongTu)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdateMucChaBCDKTH";
                    cm.Parameters.AddWithValue("@MaThongTu", maThongTu);
                    cm.ExecuteNonQuery();

                }
            }
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {

                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_GetBangCanDoiKeToan1List";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteria)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaLoadMucCha)
                {
                    cm.CommandText = "spd_GetMucChaBangCanDoiKeToan1";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaLoadMucCha)criteria).MaThongTu);
                }
                else if (criteria is FilterCriteriaCheckChild)
                {
                    cm.CommandText = "spd_CheckChildBCDKTH";
                    cm.Parameters.AddWithValue("@MaMucTaiKhoan", ((FilterCriteriaCheckChild)criteria).MaMucTK);
                }
                else if (criteria is FilterCriteriaForTree)
                {
                    cm.CommandText = "spd_GetCongThucBangCanDoiKeToan";
                    cm.Parameters.AddWithValue("@MaThongTu", ((FilterCriteriaForTree)criteria).MaThongTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BangCanDoiKeToanH.GetBangCanDoiKeToanH_ForTree(dr));
                    }
                    return;
                }
                //else if (criteria is FilterCriteriaCheckCha)
                //{
                //    cm.CommandText = "spd_CheckXoaChaBCDKT";
                //    cm.Parameters.AddWithValue("@MaMucTaiKhoan", ((FilterCriteriaCheckCha)criteria).MaMucTK);
                //}
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangCanDoiKeToanH.GetBangCanDoiKeToanH(dr));
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
                    foreach (BangCanDoiKeToanH deletedChild in DeletedList)
                    {
                        if (deletedChild.MaChiTiet != 0)    //doi tuong cua chi tiet cong thuc
                        {
                            continue;
                        }
                        deletedChild.DeleteSelf(tr);
                    }
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (BangCanDoiKeToanH child in this)
                    {
                        if (child.MaChiTiet != 0)    //doi tuong cua chi tiet cong thuc
                        {
                            continue;
                        }

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

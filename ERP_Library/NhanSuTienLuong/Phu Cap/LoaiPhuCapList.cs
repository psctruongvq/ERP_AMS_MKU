
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiPhuCapList : Csla.BusinessListBase<LoaiPhuCapList, LoaiPhuCapChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiPhuCapChild item = LoaiPhuCapChild.NewLoaiPhuCapChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiPhuCapList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiPhuCapList()
        { /* require use of factory method */ }

        public static LoaiPhuCapList NewLoaiPhuCapList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiPhuCapList");
            return new LoaiPhuCapList();
        }

        public static LoaiPhuCapList GetLoaiPhuCapList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
            return DataPortal.Fetch<LoaiPhuCapList>(new FilterCriteria());
        }
         public static LoaiPhuCapList GetLoaiPhuCapListByThuong()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
            return DataPortal.Fetch<LoaiPhuCapList>(new FilterThuong());
        }

         public static LoaiPhuCapList GetLoaiPhuCapListByMaLoaiChi(int maLoaiChi)
         {
             if (!CanGetObject())
                 throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
             return DataPortal.Fetch<LoaiPhuCapList>(new FilterbyMaLoaiChi(maLoaiChi));
         }

        public static LoaiPhuCapList GetLoaiPhuCapByMaNhom(int MaNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
            return DataPortal.Fetch<LoaiPhuCapList>(new FilterNhom(MaNhom));
        }

        public static LoaiPhuCapList GetLoaiPhuCapByMaLoai(int MaLoai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
            return DataPortal.Fetch<LoaiPhuCapList>(new FilterLoai(MaLoai));
        }
        
        /// <summary>
        /// Có thêm dòng Tất cả, value = 0
        /// </summary>
        /// <returns></returns>
        public static LoaiPhuCapList GetLoaiPhuCapListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapList");
            LoaiPhuCapList lst = DataPortal.Fetch<LoaiPhuCapList>(new FilterCriteria());
            LoaiPhuCapChild all = LoaiPhuCapChild.NewLoaiPhuCapChild();
            all.TenLoaiPhuCap = "Tất cả";
            lst.Insert(0, all);
            return lst;
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }
    
        private class FilterThuong
        {

            public FilterThuong()
            {

            }
        }

        private class FilterbyMaLoaiChi
        {
            public int MaLoaiChi;

            public FilterbyMaLoaiChi(int maLoaiChi)
            {
                this.MaLoaiChi = maLoaiChi;
            }
        }

        private class FilterNhom
        {
            public int MaNhom;
            public FilterNhom(int maNhom)
            {
                MaNhom = maNhom;
            }
        }

        private class FilterLoai
        {
            public int MaLoai;
            public FilterLoai(int maLoai)
            {
                MaLoai = maLoai;
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
        //them
   

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_LoaiPhuCapList";
                }
               else if (criteria is FilterThuong)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectALLByThuong";
                }
                else if (criteria is FilterbyMaLoaiChi)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectALLByMaLoaiChi";
                    cm.Parameters.AddWithValue("@MaLoaiChi", ((FilterbyMaLoaiChi)criteria).MaLoaiChi);
                    cm.Parameters.AddWithValue("UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterNhom)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_LoaiPCListbyNhom";
                    cm.Parameters.AddWithValue("@MaNhom", ((FilterNhom)criteria).MaNhom);
                }
                else if (criteria is FilterLoai)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_Select_LoaiPCListByLoai";
                    cm.Parameters.AddWithValue("@MaLoai", ((FilterLoai)criteria).MaLoai);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiPhuCapChild.GetLoaiPhuCapChild(dr));
                }
            }//using
        }
            //them

        
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
                    foreach (LoaiPhuCapChild deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiPhuCapChild child in this)
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

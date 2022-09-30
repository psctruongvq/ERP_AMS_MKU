using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Linq;

namespace ERP_Library
{
    [Serializable()]
    public class TinhChatPhongList : Csla.BusinessListBase<TinhChatPhongList, TinhChatPhong>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TinhChatPhong item = TinhChatPhong.NewTinhChatPhong();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in TinhChatPhongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in TinhChatPhongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in TinhChatPhongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in TinhChatPhongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("TinhChatPhongListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private TinhChatPhongList()
        { /* require use of factory method */ }

        public static TinhChatPhongList NewTinhChatPhongList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TinhChatPhongList");
            return new TinhChatPhongList();
        }

        public static TinhChatPhongList GetTinhChatPhongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TinhChatPhongList");
            return DataPortal.Fetch<TinhChatPhongList>(new FilterCriteria());
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
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhChatPhongList_GetALL";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    var rlce = RaiseListChangedEvents; //Template Customize
                    RaiseListChangedEvents = false; //Template Customize
                    while (dr.Read())
                        this.Add(TinhChatPhong.GetTinhChatPhong(dr));
                    RaiseListChangedEvents = rlce; //Template Customize
                    if (this.Count > 0) //Template Customize
                        this[0].FetchChildren(dr); //Template Customize
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
                    foreach (TinhChatPhong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TinhChatPhong child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr,this);
                        else
                            child.Update(tr,this);
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
        #region Template Customize
        public TinhChatPhong FindTinhChatPhongByParentProperties(int _maTinhChatPhong)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this[i].MaTinhChatPhong.Equals(_maTinhChatPhong))
                {
                    return this[i];
                }
            }

            return null;
        }
        #endregion //Template Customize      
        #region function
        public static int GetMaBoPhanByMaBoPhanQL(TinhChatPhongList tinhChatPhongList, string maTinhChatPhongQL)
        {
            return tinhChatPhongList.Single(o => o.MaTinhChatPhongQL == maTinhChatPhongQL).MaTinhChatPhong;
        }
        #endregion
    }
}

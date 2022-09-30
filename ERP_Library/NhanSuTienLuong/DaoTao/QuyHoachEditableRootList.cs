using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class QuyHoachList : Csla.BusinessListBase<QuyHoachList, QuyHoach>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            QuyHoach item = QuyHoach.NewQuyHoach();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyHoachList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyHoachList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyHoachList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyHoachList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyHoachListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyHoachList()
        { /* require use of factory method */ }

        public static QuyHoachList NewQuyHoachList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyHoachList");
            return new QuyHoachList();
        }

        public static QuyHoachList GetQuyHoachList(int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyHoachList");
            return DataPortal.Fetch<QuyHoachList>(new FilterCriteria(nam));
        }

        public static QuyHoachList GetQuyHoachListWithOutChild(int nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyHoachList");
            return DataPortal.Fetch<QuyHoachList>(new FilterCriteriaWithOutChild(nam));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int Nam;

            public FilterCriteria(int nam)
            {
                this.Nam = nam;
            }
        }

        private class FilterCriteriaWithOutChild
        {
            public int Nam;

            public FilterCriteriaWithOutChild(int nam)
            {
                this.Nam = nam;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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
                cm.CommandText = "spd_SelecttblnsQuyHoachListbySearch";
                if (criteria is FilterCriteriaWithOutChild)
                {
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteriaWithOutChild)criteria).Nam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuyHoach.GetQuyHoachWithoutChild(dr));
                    }
                }
                else
                {
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria)criteria).Nam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuyHoach.GetQuyHoach(dr));
                    }
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
                    foreach (QuyHoach deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuyHoach child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
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

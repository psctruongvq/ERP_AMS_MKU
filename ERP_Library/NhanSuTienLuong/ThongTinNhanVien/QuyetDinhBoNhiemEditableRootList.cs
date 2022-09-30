
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class QuyetDinhBoNhiemList : Csla.BusinessListBase<QuyetDinhBoNhiemList, QuyetDinhBoNhiem>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            QuyetDinhBoNhiem item = QuyetDinhBoNhiem.NewQuyetDinhBoNhiem();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyetDinhBoNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyetDinhBoNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyetDinhBoNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyetDinhBoNhiemList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhBoNhiemListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyetDinhBoNhiemList()
        { /* require use of factory method */ }

        public static QuyetDinhBoNhiemList NewQuyetDinhBoNhiemList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyetDinhBoNhiemList");
            return new QuyetDinhBoNhiemList();
        }

        public static QuyetDinhBoNhiemList GetQuyetDinhBoNhiemList(int maLoaiQuyetDinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhBoNhiemList");
            return DataPortal.Fetch<QuyetDinhBoNhiemList>(new FilterCriteria(maLoaiQuyetDinh));
        }
        public static QuyetDinhBoNhiemList GetQuyetDinhBoNhiemAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhBoNhiemList");
            return DataPortal.Fetch<QuyetDinhBoNhiemList>(new FilterCriteriaAll());
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLoaiQuyetDinh;

            public FilterCriteria(int maLoaiQuyetDinh)
            {
                this.MaLoaiQuyetDinh = maLoaiQuyetDinh;
            }
        }
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {

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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsQuyetDinhBoNhiemByLoaiQD";
                    cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", ((FilterCriteria)criteria).MaLoaiQuyetDinh);
                }
                if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsQuyetDinhBoNhiemAll";
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(QuyetDinhBoNhiem.GetQuyetDinhBoNhiem(dr));
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
                    foreach (QuyetDinhBoNhiem deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuyetDinhBoNhiem child in this)
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

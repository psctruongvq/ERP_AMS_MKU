
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ButToan_CacQuyList : Csla.BusinessListBase<ButToan_CacQuyList, ButToan_CacQuy>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ButToan_CacQuy item = ButToan_CacQuy.NewButToan_CacQuy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ButToan_CacQuyList NewButToan_CacQuyList()
        {
            return new ButToan_CacQuyList();
        }

        internal static ButToan_CacQuyList GetButToan_CacQuyList(SafeDataReader dr)
        {
            return new ButToan_CacQuyList(dr);
        }

        public static ButToan_CacQuyList GetButToan_CacQuyList(long maChungTu)
        {
            return DataPortal.Fetch<ButToan_CacQuyList>(new FilterCriteria(maChungTu));
        }

        public static ButToan_CacQuyList GetButToan_CacQuyList_ByLoaiQuy(long maUNC)
        {
            return DataPortal.Fetch<ButToan_CacQuyList>(new FilterCriteria_ByLoaiQuy(maUNC));
        }

        private ButToan_CacQuyList()
        {
            MarkAsChild();
        }

        private ButToan_CacQuyList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria_ByLoaiQuy
        {
            public long MaLoaiQuy;

            public FilterCriteria_ByLoaiQuy(long maLoaiQuy)
            {
                this.MaLoaiQuy = maLoaiQuy;
            }
        }

        private class FilterCriteria
        {
            public long MaChungTu;

            public FilterCriteria(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria


        #region Data Access
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
                    cm.CommandText = "spd_SelecttblButToan_CacQuiesByMaChungTu_CacQuy";
                    cm.Parameters.AddWithValue("@MaChungTu_CacQuy", ((FilterCriteria)criteria).MaChungTu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ButToan_CacQuy.GetButToan_CacQuy(dr));
                }

            }//using
        }


        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ButToan_CacQuy.GetButToan_CacQuy(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ButToan_CacQuy deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ButToan_CacQuy child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (ButToan_CacQuy child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

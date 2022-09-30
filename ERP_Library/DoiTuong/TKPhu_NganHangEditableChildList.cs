
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library.ThanhToan;

namespace ERP_Library
{
    [Serializable()]
    public class TKPhu_NganHangList : Csla.BusinessListBase<TKPhu_NganHangList, TKPhu_NganHang>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            TKPhu_NganHang item = TKPhu_NganHang.NewTKPhu_NganHang();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static TKPhu_NganHangList NewTKPhu_NganHangList()
        {
            return new TKPhu_NganHangList();
        }

        internal static TKPhu_NganHangList GetTKPhu_NganHangList(SafeDataReader dr)
        {
            return new TKPhu_NganHangList(dr);
        }

        public static TKPhu_NganHangList GetTKPhu_NganHangList(long maDoiTac)
        {
            return DataPortal.Fetch<TKPhu_NganHangList>(new FilterCriteria(maDoiTac));
        }

        private TKPhu_NganHangList()
        {
            MarkAsChild();
        }

        private TKPhu_NganHangList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaDoiTac;

            public FilterCriteria(long MaDoiTac)
            {
                this.MaDoiTac = MaDoiTac;
            }
        }
        #endregion //Filter Criteria

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
                    cm.CommandText = "spd_SelecttblTKPhu_NganHangsByMaDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteria)criteria).MaDoiTac);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TKPhu_NganHang.GetTKPhu_NganHang(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(TKPhu_NganHang.GetTKPhu_NganHang(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, DoiTac parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (TKPhu_NganHang deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (TKPhu_NganHang child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToanList : Csla.BusinessListBase<ChiTietThanhToanList, ChiTietThanhToan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietThanhToan item = ChiTietThanhToan.NewChiTietThanhToan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietThanhToanList NewChiTietThanhToanList()
        {
            return new ChiTietThanhToanList();
        }

        internal static ChiTietThanhToanList GetChiTietThanhToanList(SafeDataReader dr)
        {
            return new ChiTietThanhToanList(dr);
        }

        public static ChiTietThanhToanList GetChiTietThanhToanList(long maHopDong)
        {
            return DataPortal.Fetch<ChiTietThanhToanList>(new FilterCriteria(maHopDong));
        }

        private ChiTietThanhToanList()
        {
            MarkAsChild();
        }

        private ChiTietThanhToanList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaHopDong;

            public FilterCriteria(long maHopDong)
            {
                this.MaHopDong = maHopDong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
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
                cm.CommandText = "spd_SelecttblChiTietThanhToansByMaHopDong";
                cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietThanhToan.GetChiTietThanhToan(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietThanhToan.GetChiTietThanhToan(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, HopDongMuaBan parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietThanhToan deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietThanhToan child in this)
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

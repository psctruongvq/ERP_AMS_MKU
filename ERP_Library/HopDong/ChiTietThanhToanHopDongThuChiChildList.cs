
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietThanhToanHopDongThuChiList : Csla.BusinessListBase<ChiTietThanhToanHopDongThuChiList, ChiTietThanhToanHopDongThuChi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietThanhToanHopDongThuChi item = ChiTietThanhToanHopDongThuChi.NewChiTietThanhToan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietThanhToanHopDongThuChiList NewChiTietThanhToanList()
        {
            return new ChiTietThanhToanHopDongThuChiList();
        }

        internal static ChiTietThanhToanHopDongThuChiList GetChiTietThanhToanList(SafeDataReader dr)
        {
            return new ChiTietThanhToanHopDongThuChiList(dr);
        }

        public static ChiTietThanhToanHopDongThuChiList GetChiTietThanhToanList(long maHopDong)
        {
            return DataPortal.Fetch<ChiTietThanhToanHopDongThuChiList>(new FilterCriteria(maHopDong));
        }

        private ChiTietThanhToanHopDongThuChiList()
        {
            MarkAsChild();
        }

        private ChiTietThanhToanHopDongThuChiList(SafeDataReader dr)
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
                        this.Add(ChiTietThanhToanHopDongThuChi.GetChiTietThanhToan(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietThanhToanHopDongThuChi.GetChiTietThanhToan(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, HopDongThuChi parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietThanhToanHopDongThuChi deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietThanhToanHopDongThuChi child in this)
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

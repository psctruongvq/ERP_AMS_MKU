
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_HopDongThuChiList : Csla.BusinessListBase<CT_HopDongThuChiList, CT_HopDongThuChi>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_HopDongThuChi item = CT_HopDongThuChi.NewCT_HopDongDichVu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_HopDongThuChiList NewCT_HopDongDichVuList()
        {
            return new CT_HopDongThuChiList();
        }

        internal static CT_HopDongThuChiList GetCT_HopDongDichVuList(SafeDataReader dr)
        {
            return new CT_HopDongThuChiList(dr);
        }

        public static CT_HopDongThuChiList GetCT_HopDongDichVuList(long maHopDong)
        {
            return DataPortal.Fetch<CT_HopDongThuChiList>(new FilterCriteria(maHopDong));
        }

        private CT_HopDongThuChiList()
        {
            MarkAsChild();
        }

        private CT_HopDongThuChiList(SafeDataReader dr)
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
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CT_HopDongThuChi.GetCT_HopDongDichVu(dr));

            RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch((FilterCriteria)criteria);
            }
        }

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
                cm.CommandText = "spd_SelecttblCT_HopDongDichVusByMaHopDong";
                cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CT_HopDongThuChi.GetCT_HopDongDichVu(dr));
                }
            }//using
        }

        internal void Update(SqlTransaction tr, HopDongThuChi parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_HopDongThuChi deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_HopDongThuChi child in this)
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
            foreach (CT_HopDongThuChi child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

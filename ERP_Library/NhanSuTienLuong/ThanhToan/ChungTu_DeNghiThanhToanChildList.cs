
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class ChungTu_DeNghiThanhToanChildList : Csla.BusinessListBase<ChungTu_DeNghiThanhToanChildList, ChungTu_DeNghiThanhToanChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_DeNghiThanhToanChild item = ChungTu_DeNghiThanhToanChild.NewChungTu_DeNghiThanhToanChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static ChungTu_DeNghiThanhToanChildList NewChungTu_DeNghiThanhToanChildList()
        {
            return new ChungTu_DeNghiThanhToanChildList();
        }

        //internal static ChungTu_DeNghiThanhToanChildList GetChungTu_DeNghiThanhToanChildList(SafeDataReader dr)
        //{
        //    return new ChungTu_DeNghiThanhToanChildList(dr);
        //}
        public static ChungTu_DeNghiThanhToanChildList GetChungTu_DeNghiThanhToanChildList(long MaPhieu)
        {
            return DataPortal.Fetch<ChungTu_DeNghiThanhToanChildList>(new FilterCriteria(MaPhieu));
        }
        public static ChungTu_DeNghiThanhToanChildList GetChungTu_DeNghiThanhToanChildListByChungTu(long MaChungTu)
        {
            return DataPortal.Fetch<ChungTu_DeNghiThanhToanChildList>(new FilterCriteriaByChungTu(MaChungTu));
        }
        //private ChungTu_DeNghiThanhToanChildList()
        //{
        //    MarkAsChild();
        //}

        //private ChungTu_DeNghiThanhToanChildList(SafeDataReader dr)
        //{
        //    MarkAsChild();
        //    Fetch(dr);
        //}
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaPhieu;

            public FilterCriteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }
        #endregion //Filter Criteria
        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;

            public FilterCriteriaByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #region Data Access
        //private void Fetch(SafeDataReader dr)
        //{
        //    RaiseListChangedEvents = false;

        //    while (dr.Read())
        //        this.Add(ChungTu_DeNghiThanhToanChild.GetChungTu_DeNghiThanhToanChild(dr));

        //    RaiseListChangedEvents = true;
        //}

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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblChungTu_DeNghiThanhToanListBymaPhieu";
                    cm.Parameters.AddWithValue("@MaPhieu",((FilterCriteria)criteria).MaPhieu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_DeNghiThanhToanChild.GetChungTu_DeNghiThanhToanChild(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblChungTu_DeNghiThanhToanListByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu",((FilterCriteriaByChungTu)criteria).MaChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_DeNghiThanhToanChild.GetChungTu_DeNghiThanhToanChild(dr));
                    }
                }//using
            }
        }
        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_DeNghiThanhToanChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_DeNghiThanhToanChild child in this)
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
            foreach (ChungTu_DeNghiThanhToanChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }

        #endregion //Data Access

    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_DeNghiChuyenKhoanChildList : Csla.BusinessListBase<ChungTu_DeNghiChuyenKhoanChildList, ChungTu_DeNghiChuyenKhoanChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_DeNghiChuyenKhoanChild item = ChungTu_DeNghiChuyenKhoanChild.NewChungTu_DeNghiChuyenKhoanChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static ChungTu_DeNghiChuyenKhoanChildList NewChungTu_DeNghiChuyenKhoanChildList()
        {
            return new ChungTu_DeNghiChuyenKhoanChildList();
        }

        //internal static ChungTu_DeNghiChuyenKhoanChildList GetChungTu_DeNghiChuyenKhoanChildList(SafeDataReader dr)
        //{
        //    return new ChungTu_DeNghiChuyenKhoanChildList(dr);
        //}
        public static ChungTu_DeNghiChuyenKhoanChildList GetChungTu_DeNghiChuyenKhoanChildList(long MaPhieu)
        {
            return DataPortal.Fetch<ChungTu_DeNghiChuyenKhoanChildList>(new FilterCriteria(MaPhieu));
        }
        public static ChungTu_DeNghiChuyenKhoanChildList GetChungTu_DeNghiChuyenKhoanChildListByChungTu(long MaChungTu)
        {
            return DataPortal.Fetch<ChungTu_DeNghiChuyenKhoanChildList>(new FilterCriteriaByChungTu(MaChungTu));
        }
        //private ChungTu_DeNghiChuyenKhoanChildList()
        //{
        //    MarkAsChild();
        //}

        //private ChungTu_DeNghiChuyenKhoanChildList(SafeDataReader dr)
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
        private class FilterCriteriaByChungTu
        {
            public long MaChungTu;

            public FilterCriteriaByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
        //private void Fetch(SafeDataReader dr)
        //{
        //    RaiseListChangedEvents = false;

        //    while (dr.Read())
        //        this.Add(ChungTu_DeNghiChuyenKhoanChild.GetChungTu_DeNghiChuyenKhoanChild(dr));

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
                    cm.CommandText = "sp_SelecttblChungTu_DeNghiChuyenKhoanListBymaPhieu";
                    cm.Parameters.AddWithValue("@MaPhieu",((FilterCriteria)criteria).MaPhieu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_DeNghiChuyenKhoanChild.GetChungTu_DeNghiChuyenKhoanChild(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByChungTu)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblChungTu_DeNghiChuyenKhoanListByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTu_DeNghiChuyenKhoanChild.GetChungTu_DeNghiChuyenKhoanChild(dr));
                    }
                }//using
            }
        }
        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_DeNghiChuyenKhoanChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_DeNghiChuyenKhoanChild child in this)
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
            foreach (ChungTu_DeNghiChuyenKhoanChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_LenhChuyenTienNNChildList : Csla.BusinessListBase<ChungTu_LenhChuyenTienNNChildList, ChungTu_LenhChuyenTienNNChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTu_LenhChuyenTienNNChild item = ChungTu_LenhChuyenTienNNChild.NewChungTu_LenhChuyenTienNNChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChungTu_LenhChuyenTienNNChildList NewChungTu_LenhChuyenTienNNChildList()
        {
            return new ChungTu_LenhChuyenTienNNChildList();
        }

        internal static ChungTu_LenhChuyenTienNNChildList GetChungTu_LenhChuyenTienNNChildList(SafeDataReader dr)
        {
            return new ChungTu_LenhChuyenTienNNChildList(dr);
        }

        public static ChungTu_LenhChuyenTienNNChildList GetChungTu_LenhChuyenTienNNChildList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_LenhChuyenTienNNChildList>(new FilterCriteria_ByChungTu(maChungTu));
        }

        public static ChungTu_LenhChuyenTienNNChildList GetChungTu_LenhChuyenTienNNChildList_ByMaPhieu(long maPhieu)
        {
            return DataPortal.Fetch<ChungTu_LenhChuyenTienNNChildList>(new FilterCriteria_ByPhieu(maPhieu));
        }

        private ChungTu_LenhChuyenTienNNChildList()
        {
            MarkAsChild();
        }

        private ChungTu_LenhChuyenTienNNChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
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

        private class FilterCriteria_ByChungTu
        {
            public long MaChungTu;

            public FilterCriteria_ByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

        private class FilterCriteria_ByPhieu
        {
            public long MaPhieu;

            public FilterCriteria_ByPhieu(long maPhieu)
            {
                this.MaPhieu = maPhieu;
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
                    cm.CommandText = "spd_SelecttblChungTu_LenhChuyenTiensAll";
                }
                else if (criteria is FilterCriteria_ByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_LenhChuyenTiensByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria_ByPhieu)
                {
                    cm.CommandText = "spd_SelecttblChungTu_LenhChuyenTiensByMaLenhCT";
                    cm.Parameters.AddWithValue("@MaLenhCT", ((FilterCriteria_ByPhieu)criteria).MaPhieu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_LenhChuyenTienNNChild.GetChungTu_LenhChuyenTienNNChild(dr));
                }

            }//using
        }
        #endregion

        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_LenhChuyenTienNNChild.GetChungTu_LenhChuyenTienNNChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_LenhChuyenTienNNChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_LenhChuyenTienNNChild child in this)
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
            foreach (ChungTu_LenhChuyenTienNNChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
    
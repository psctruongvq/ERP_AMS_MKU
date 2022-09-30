
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietDeNghi_LenhChuyenTienList : Csla.BusinessListBase<ChiTietDeNghi_LenhChuyenTienList, ChiTietDeNghi_LenhChuyenTien>
    {
        //ok
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietDeNghi_LenhChuyenTien item = ChiTietDeNghi_LenhChuyenTien.NewChiTietDeNghi_LenhChuyenTien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietDeNghi_LenhChuyenTienList NewChiTietDeNghi_LenhChuyenTienList()
        {
            return new ChiTietDeNghi_LenhChuyenTienList();
        }

        internal static ChiTietDeNghi_LenhChuyenTienList GetChiTietDeNghi_LenhChuyenTienList(SafeDataReader dr)
        {
            return new ChiTietDeNghi_LenhChuyenTienList(dr);
        }

        public static ChiTietDeNghi_LenhChuyenTienList GetChungTu_LenhChuyenTienNNChildList(long maLenhCT)
        {
            return DataPortal.Fetch<ChiTietDeNghi_LenhChuyenTienList>(new FilterCriteria(maLenhCT));
        }

        public static ChiTietDeNghi_LenhChuyenTienList GetChungTu_LenhChuyenTienNNChildList_ByMaPhieu(long maPhieu)
        {
            return DataPortal.Fetch<ChiTietDeNghi_LenhChuyenTienList>(new FilterCriteria_ByPhieu(maPhieu));
        }


        private ChiTietDeNghi_LenhChuyenTienList()
        {
            MarkAsChild();
        }

        private ChiTietDeNghi_LenhChuyenTienList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        [Serializable()]
        private class FilterCriteria
        {
            public long MaLenhCT;

            public FilterCriteria(long maLenhCT)
            {
                this.MaLenhCT = maLenhCT;
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
                    cm.CommandText = "spd_SelecttblDeNghi_LenhChuyenTiensByMaLenhCT";
                    cm.Parameters.AddWithValue("@MaLenhCT", ((FilterCriteria)criteria).MaLenhCT);
                }
                else if (criteria is FilterCriteria_ByPhieu)
                {
                    cm.CommandText = "spd_SelecttblDeNghi_LenhChuyenTiensByMaDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", ((FilterCriteria_ByPhieu)criteria).MaPhieu);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietDeNghi_LenhChuyenTien.GetChiTietDeNghi_LenhChuyenTien(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietDeNghi_LenhChuyenTien.GetChiTietDeNghi_LenhChuyenTien(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, LenhChuyenTienNuocNgoai parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietDeNghi_LenhChuyenTien deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietDeNghi_LenhChuyenTien child in this)
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
            foreach (ChiTietDeNghi_LenhChuyenTien child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

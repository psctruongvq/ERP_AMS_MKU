
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//ok

namespace ERP_Library
{
    [Serializable()]
    public class ChuyenTien_BanNgoaiTeList : Csla.BusinessListBase<ChuyenTien_BanNgoaiTeList, ChuyenTien_BanNgoaiTe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChuyenTien_BanNgoaiTe item = ChuyenTien_BanNgoaiTe.NewChuyenTien_BanNgoaiTe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChuyenTien_BanNgoaiTeList NewChuyenTien_BanNgoaiTeList()
        {
            return new ChuyenTien_BanNgoaiTeList();
        }

        internal static ChuyenTien_BanNgoaiTeList GetChuyenTien_BanNgoaiTeList(SafeDataReader dr)
        {
            return new ChuyenTien_BanNgoaiTeList(dr);
        }

        public static ChuyenTien_BanNgoaiTeList GetChuyenTien_BanNgoaiTeList_ByLenhCT(long maLenhCT)
        {
            return DataPortal.Fetch<ChuyenTien_BanNgoaiTeList>(new FilterCriteria_ByLenhChuyenTien(maLenhCT));
        }

        public static ChuyenTien_BanNgoaiTeList GetChuyenTien_BanNgoaiTeList(long maPhieu)
        {
            return DataPortal.Fetch<ChuyenTien_BanNgoaiTeList>(new FilterCriteria(maPhieu));
        }

        private ChuyenTien_BanNgoaiTeList()
        {
            MarkAsChild();
        }

        private ChuyenTien_BanNgoaiTeList(SafeDataReader dr)
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

        private class FilterCriteria_ByLenhChuyenTien
        {
            public long MaLenhCT;

            public FilterCriteria_ByLenhChuyenTien(long maLenhCT)
            {
                this.MaLenhCT = maLenhCT;
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
                    //ok
                    cm.CommandText = "spd_SelecttblChuyenTien_BanNgoaiTesByMaPhieu";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria)criteria).MaPhieu);
                }
                else if (criteria is FilterCriteria_ByLenhChuyenTien)
                {
                    cm.CommandText = "spd_SelecttblChuyenTien_BanNgoaiTesByMaLenhCT";
                    cm.Parameters.AddWithValue("@MaLenhCT", ((FilterCriteria_ByLenhChuyenTien)criteria).MaLenhCT);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuyenTien_BanNgoaiTe.GetChuyenTien_BanNgoaiTe(dr));
                }

            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChuyenTien_BanNgoaiTe.GetChuyenTien_BanNgoaiTe(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChuyenTien_BanNgoaiTe deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChuyenTien_BanNgoaiTe child in this)
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
            foreach (ChuyenTien_BanNgoaiTe child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

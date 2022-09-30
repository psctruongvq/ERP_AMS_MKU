
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghi_GiayBanNgoaiTeList : Csla.BusinessListBase<DeNghi_GiayBanNgoaiTeList, DeNghi_GiayBanNgoaiTe>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DeNghi_GiayBanNgoaiTe item = DeNghi_GiayBanNgoaiTe.NewDeNghi_GiayBanNgoaiTe();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static DeNghi_GiayBanNgoaiTeList NewDeNghi_GiayBanNgoaiTeList()
        {
            return new DeNghi_GiayBanNgoaiTeList();
        }

        internal static DeNghi_GiayBanNgoaiTeList GetDeNghi_GiayBanNgoaiTeList(SafeDataReader dr)
        {
            return new DeNghi_GiayBanNgoaiTeList(dr);
        }

        public static DeNghi_GiayBanNgoaiTeList GetDeNghi_GiayBanNgoaiTeList(long maPhieu)
        {
            return DataPortal.Fetch<DeNghi_GiayBanNgoaiTeList>(new FilterCriteria(maPhieu));
        }

        public static DeNghi_GiayBanNgoaiTeList GetDeNghi_GiayBanNgoaiTeList_ByDeNghiCK(long maDeNghi)
        {
            return DataPortal.Fetch<DeNghi_GiayBanNgoaiTeList>(new FilterCriteria_ByDeNghiCK(maDeNghi));
        }

        private DeNghi_GiayBanNgoaiTeList()
        {
            MarkAsChild();
        }

        private DeNghi_GiayBanNgoaiTeList(SafeDataReader dr)
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
            public long MaPhieu;

            public FilterCriteria(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }

        private class FilterCriteria_ByDeNghiCK
        {
            public long MaDeNghi;

            public FilterCriteria_ByDeNghiCK(long maDeNghi)
            {
                this.MaDeNghi = maDeNghi;
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
                    cm.CommandText = "spd_SelecttblDeNghi_GiayBanNgoaiTesByMaPhieu";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria)criteria).MaPhieu);
                }
                else if (criteria is FilterCriteria_ByDeNghiCK)
                {
                    cm.CommandText = "spd_SelecttblDeNghi_GiayBanNgoaiTesByMaDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", ((FilterCriteria_ByDeNghiCK)criteria).MaDeNghi);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghi_GiayBanNgoaiTe.GetDeNghi_GiayBanNgoaiTe(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(DeNghi_GiayBanNgoaiTe.GetDeNghi_GiayBanNgoaiTe(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (DeNghi_GiayBanNgoaiTe deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (DeNghi_GiayBanNgoaiTe child in this)
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

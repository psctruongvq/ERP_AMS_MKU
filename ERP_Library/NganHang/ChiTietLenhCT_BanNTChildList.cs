
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietLenhCT_BanNTChildList : Csla.BusinessListBase<ChiTietLenhCT_BanNTChildList, ChiTietLenhCT_BanNTChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietLenhCT_BanNTChild item = ChiTietLenhCT_BanNTChild.NewChiTietLenhCT_BanNTChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietLenhCT_BanNTChildList NewChiTietLenhCT_BanNTChildList()
        {
            return new ChiTietLenhCT_BanNTChildList();
        }

        internal static ChiTietLenhCT_BanNTChildList GetChiTietLenhCT_BanNTChildList(SafeDataReader dr)
        {
            return new ChiTietLenhCT_BanNTChildList(dr);
        }

        public static ChungTu_GiayBanNgoaiTeChildList GetChungTu_GiayBanNgoaiTeChildList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_GiayBanNgoaiTeChildList>(new FilterCriteria_ByChungTu(maChungTu));
        }

        public static ChungTu_GiayBanNgoaiTeChildList GetChungTu_GiayBanNgoaiTeChildList_ByPhieu(long MaPhieu)
        {
            return DataPortal.Fetch<ChungTu_GiayBanNgoaiTeChildList>(new FilterCriteria_ByPhieu(MaPhieu));
        }

        private ChiTietLenhCT_BanNTChildList()
        {
            MarkAsChild();
        }

        private ChiTietLenhCT_BanNTChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public FilterCriteria()
            {

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
                    cm.CommandText = "spd_SelecttblChuyenTien_BanNgoaiTesAll";
                }
                else if (criteria is FilterCriteria_ByChungTu)
                {
                    cm.CommandText = "spd_SelecttblChuyenTien_BanNgoaiTesByMaLenhCT";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria_ByPhieu)
                {
                    cm.CommandText = "spd_SelecttblChuyenTien_BanNgoaiTesByMaPhieu";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteria_ByPhieu)criteria).MaPhieu);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietLenhCT_BanNTChild.GetChiTietLenhCT_BanNTChild(dr));
                }

            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietLenhCT_BanNTChild.GetChiTietLenhCT_BanNTChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, GiayBanNgoaiTe parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietLenhCT_BanNTChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietLenhCT_BanNTChild child in this)
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
            foreach (ChiTietLenhCT_BanNTChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}

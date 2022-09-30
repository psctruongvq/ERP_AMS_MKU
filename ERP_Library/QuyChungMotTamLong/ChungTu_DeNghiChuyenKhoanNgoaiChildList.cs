
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_DeNghiChuyenKhoanNgoaiList : Csla.BusinessListBase<ChungTu_DeNghiChuyenKhoanNgoaiList, ChungTu_DeNghiChuyenKhoanNgoai>
    {
        protected override object AddNewCore()
        {
            ChungTu_DeNghiChuyenKhoanNgoai item = ChungTu_DeNghiChuyenKhoanNgoai.NewChungTu_DeNghiChuyenKhoanNgoai();
            this.Add(item);
            return item;
        }

        #region Factory Methods
        internal static ChungTu_DeNghiChuyenKhoanNgoaiList NewChungTu_DeNghiChuyenKhoanNgoaiList()
        {
            return new ChungTu_DeNghiChuyenKhoanNgoaiList();
        }

        internal static ChungTu_DeNghiChuyenKhoanNgoaiList GetChungTu_DeNghiChuyenKhoanNgoaiList(SafeDataReader dr)
        {
            return new ChungTu_DeNghiChuyenKhoanNgoaiList(dr);
        }

        public static ChungTu_DeNghiChuyenKhoanNgoaiList GetChungTu_DeNghiChuyenKhoanNgoaiList(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_DeNghiChuyenKhoanNgoaiList>(new FilterCriteria(maChungTu));
        }

        public static ChungTu_DeNghiChuyenKhoanNgoaiList GetChungTu_DeNghiChuyenKhoanNgoaiList_ByDeNghi( long maDeNghi)
        {
            return DataPortal.Fetch<ChungTu_DeNghiChuyenKhoanNgoaiList>(new FilterCriteria(maDeNghi));
        }

        private ChungTu_DeNghiChuyenKhoanNgoaiList()
        {
            MarkAsChild();
        }

        private ChungTu_DeNghiChuyenKhoanNgoaiList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaChungTu;

            public FilterCriteria(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

        private class FilterCriteria_MaDeNghi
        {
            public long MaDeNghi;

            public FilterCriteria_MaDeNghi(long maDeNghi)
            {
                this.MaDeNghi = maDeNghi;
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
                    cm.CommandText = "spd_SelecttblChungTu_DeNghiChuyenKhoanNgoaisByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblChungTu_DeNghiChuyenKhoanNgoaisByMaDeNghi";
                    cm.Parameters.AddWithValue("@MaDeNghi", ((FilterCriteria_MaDeNghi)criteria).MaDeNghi);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChungTu_DeNghiChuyenKhoanNgoai.GetChungTu_DeNghiChuyenKhoanNgoai(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChungTu_DeNghiChuyenKhoanNgoai.GetChungTu_DeNghiChuyenKhoanNgoai(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu_CacLoaiQuy parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTu_DeNghiChuyenKhoanNgoai deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTu_DeNghiChuyenKhoanNgoai child in this)
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

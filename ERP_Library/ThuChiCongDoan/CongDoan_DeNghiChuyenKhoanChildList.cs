
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongDoan_DeNghiChuyenKhoanList : Csla.BusinessListBase<CongDoan_DeNghiChuyenKhoanList, CongDoan_DeNghiChuyenKhoan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongDoan_DeNghiChuyenKhoan item = CongDoan_DeNghiChuyenKhoan.NewCongDoan_DeNghiChuyenKhoan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CongDoan_DeNghiChuyenKhoanList NewCongDoan_DeNghiChuyenKhoanList()
        {
            return new CongDoan_DeNghiChuyenKhoanList();
        }

        internal static CongDoan_DeNghiChuyenKhoanList GetCongDoan_DeNghiChuyenKhoanList(SafeDataReader dr)
        {
            return new CongDoan_DeNghiChuyenKhoanList(dr);
        }

        public static CongDoan_DeNghiChuyenKhoanList GetCongDoan_DeNghiChuyenKhoanList(int maChungTu)
        {
            return DataPortal.Fetch<CongDoan_DeNghiChuyenKhoanList>(new FilterCriteria(maChungTu));
        }

        private CongDoan_DeNghiChuyenKhoanList()
        {
            MarkAsChild();
        }

        private CongDoan_DeNghiChuyenKhoanList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaChungTu;

            public FilterCriteria(int maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access
        private void DataPortal_Fetch(FilterCriteria criteria)
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

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblCongDoan_DeNghiChuyenKhoanNgoaisByMaChungTu";
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongDoan_DeNghiChuyenKhoan.GetCongDoan_DeNghiChuyenKhoan(dr));
                }
            }//using
        }

        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CongDoan_DeNghiChuyenKhoan.GetCongDoan_DeNghiChuyenKhoan(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CongDoan_DeNghiChuyenKhoan deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CongDoan_DeNghiChuyenKhoan child in this)
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

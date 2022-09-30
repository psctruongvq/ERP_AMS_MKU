using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiChuyenKhoan_ChungTuList : Csla.BusinessListBase<DeNghiChuyenKhoan_ChungTuList, DeNghiChuyenKhoan_ChungTu>
    {
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            DeNghiChuyenKhoan_ChungTu item = DeNghiChuyenKhoan_ChungTu.NewDeNghiChuyenKhoan_ChungTuChild();
            item._maChungTu = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private DeNghiChuyenKhoan_ChungTuList()
        { /* require use of factory method */ }

        public static DeNghiChuyenKhoan_ChungTuList NewDeNghiChuyenKhoan_ChungTuList()
        {
            return new DeNghiChuyenKhoan_ChungTuList();
        }

        public static DeNghiChuyenKhoan_ChungTuList GetDeNghiChuyenKhoan_ChungTuList(long MaPhieu)
        {
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuList>(new FilterCriteria(MaPhieu));
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
        #endregion //Filter Criteria

        #region Data Access - Fetch
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
                cm.CommandText = "spd_Select_DeNghiChuyenKhoan_ChungTuList";
                cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghiChuyenKhoan_ChungTu.GetDeNghiChuyenKhoan_ChungTu(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
              
                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (DeNghiChuyenKhoan_ChungTu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeNghiChuyenKhoan_ChungTu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

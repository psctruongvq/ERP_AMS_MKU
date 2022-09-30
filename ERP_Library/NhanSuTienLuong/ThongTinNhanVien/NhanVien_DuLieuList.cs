
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_DuLieuList : Csla.BusinessListBase<NhanVien_DuLieuList, NhanVien_DuLieu>
    {
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            NhanVien_DuLieu item = NhanVien_DuLieu.NewNhanVien_DuLieuChild();
            item._maDuLieu = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private NhanVien_DuLieuList()
        { /* require use of factory method */
            MarkAsChild();
        }

        public static NhanVien_DuLieuList NewNhanVien_DuLieuList()
        {
            return new NhanVien_DuLieuList();
        }

        public static NhanVien_DuLieuList GetNhanVien_DuLieuList(long maNhanVien)
        {
            return DataPortal.Fetch<NhanVien_DuLieuList>(new FilterCriteria(maNhanVien));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
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
                cm.CommandText = "spd_Select_NhanVien_DuLieuAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_DuLieu.GetNhanVien_DuLieu(dr));
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
                    foreach (NhanVien_DuLieu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NhanVien_DuLieu child in this)
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

        internal void SaveDelete(SqlTransaction tr)
        {
            // loop through each deleted child object
            foreach (NhanVien_DuLieu deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();
        }
    }
}

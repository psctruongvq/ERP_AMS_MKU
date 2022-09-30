using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class LoaiChungTuGocList : Csla.BusinessListBase<LoaiChungTuGocList, LoaiChungTuGoc>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            LoaiChungTuGoc item = LoaiChungTuGoc.NewLoaiChungTuGocChild();
            item._maLoaiChungTu = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private LoaiChungTuGocList()
        { /* require use of factory method */ }

        public static LoaiChungTuGocList NewLoaiChungTuGocList()
        {
            return new LoaiChungTuGocList();
        }

        public static LoaiChungTuGocList GetLoaiChungTuGocList(string MaPhanHe,string PhanLoai, bool Loai)
        {
            return DataPortal.Fetch<LoaiChungTuGocList>(new FilterCriteria(MaPhanHe, PhanLoai, Loai));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public string MaPhanHe, PhanLoai;
            public bool Loai;
            public FilterCriteria(string maPhanHe, string phanLoai, bool loai)
            {
                MaPhanHe = maPhanHe;
                PhanLoai = phanLoai;
                this.Loai = loai;
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
                cm.CommandText = "spd_Select_LoaiChungTuGocList";
                cm.Parameters.AddWithValue("@MaPhanHe", criteria.MaPhanHe);
                cm.Parameters.AddWithValue("@PhanLoai", criteria.PhanLoai);
                cm.Parameters.AddWithValue("@Loai", criteria.Loai);
                if (ERP_Library.Security.CurrentUser.IsAdminNhanSu || ERP_Library.Security.CurrentUser.Info.UserID == 64 || ERP_Library.Security.CurrentUser.Info.UserID == 65)
                    cm.Parameters.AddWithValue("@IsAdmin", true);
                else
                    cm.Parameters.AddWithValue("@IsAdmin", false);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiChungTuGoc.GetLoaiChungTuGoc(dr));
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
                    foreach (LoaiChungTuGoc deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiChungTuGoc child in this)
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

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinNhanVienTrichNgangList : Csla.BusinessListBase<ThongTinNhanVienTrichNgangList, ThongTinNhanVienTrichNgang>
    {


        #region Factory Methods
        private ThongTinNhanVienTrichNgangList()
        { /* require use of factory method */ }

        public static ThongTinNhanVienTrichNgangList NewThongTinNhanVienTrichNgangList()
        {
            return new ThongTinNhanVienTrichNgangList();
        }

        public static ThongTinNhanVienTrichNgangList GetThongTinNhanVienTrichNgangList(int MaBoPhan)
        {
            return DataPortal.Fetch<ThongTinNhanVienTrichNgangList>(new FilterCriteria(MaBoPhan));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaBoPhan;
            public FilterCriteria(int maBoPhan)
            {
                MaBoPhan = maBoPhan;
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
                cm.CommandText = "spd_Select_ThongTinNhanVienTrichNgangList";
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinNhanVienTrichNgang.GetThongTinNhanVienTrichNgang(dr));
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
                    foreach (ThongTinNhanVienTrichNgang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThongTinNhanVienTrichNgang child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);

                        //cập nhật chi tiết
                        child.ChiTiet.SaveDelete(tr);
                        foreach (NhanVien_DuLieu item in child.ChiTiet)
                        {
                            if (item.IsNew)
                                item.Insert(tr);
                            else
                                if (!item.IsDeleted)
                                    item.Update(tr);
                        }
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

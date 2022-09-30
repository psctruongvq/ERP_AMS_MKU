
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class BangChamCongList : Csla.ReadOnlyListBase<BangChamCongList, BangChamCongChild>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangChamCongList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangChamCongListViewGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangChamCongList()
        { /* require use of factory method */ }

        public static BangChamCongList GetBangChamCongList(Nullable<long> maNhanVien, Nullable<int> maBoPhan,int maKyLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangChamCongList");
            return DataPortal.Fetch<BangChamCongList>(new FilterCriteria(maNhanVien, maBoPhan, maKyLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public Nullable<long> MaNhanVien;
            public Nullable<int> MaBoPhan;
            public int MaKyLuong;

            public FilterCriteria(Nullable<long> maNhanVien, Nullable<int> maBoPhan, int maKyLuong)
            {
                if (maNhanVien.HasValue)
                {
                    this.MaNhanVien = maNhanVien;
                    this.MaBoPhan = null;
                }
                else
                {
                    this.MaNhanVien = null;
                    this.MaBoPhan = maBoPhan;
                }
                this.MaKyLuong = maKyLuong;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

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

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectAll_BangChamCongList";
                if (criteria.MaNhanVien.HasValue)
                    cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                else
                    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
                if (criteria.MaBoPhan.HasValue)
                    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                cm.Parameters.AddWithValue("@MaKyLuong", criteria.MaKyLuong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(BangChamCongChild.GetBangChamCongChild(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class NgoaiGioTungNgay_TongHopList : Csla.BusinessListBase<NgoaiGioTungNgay_TongHopList, NgoaiGioTungNgay_TongHop>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            NgoaiGioTungNgay_TongHop item = NgoaiGioTungNgay_TongHop.NewNgoaiGioTungNgay_TongHopChild();
            item._maNgoaiGio = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private NgoaiGioTungNgay_TongHopList()
        { /* require use of factory method */ }

        public static NgoaiGioTungNgay_TongHopList NewNgoaiGioTungNgay_TongHopList()
        {
            return new NgoaiGioTungNgay_TongHopList();
        }

        public static NgoaiGioTungNgay_TongHopList GetNgoaiGioTungNgay_TongHopList(int maKyTinhLuong, int maBoPhan, int maLoai, int maKyChamCong)
        {
            return DataPortal.Fetch<NgoaiGioTungNgay_TongHopList>(new FilterCriteria(maKyTinhLuong, maBoPhan, maLoai, maKyChamCong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public int MaLoai, MaKyChamCong;

            public FilterCriteria(int maKyTinhLuong, int maBoPhan, int maLoai, int maKyChamCong)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                MaLoai = maLoai;
                MaKyChamCong = maKyChamCong;
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
                cm.CommandText = "spd_Select_NgoaiGioTungNgay_TongHopList";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaLoai", criteria.MaLoai);
                cm.Parameters.AddWithValue("@MaKyChamCong", criteria.MaKyChamCong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NgoaiGioTungNgay_TongHop.GetNgoaiGioTungNgay_TongHop(dr));
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
                    foreach (NgoaiGioTungNgay_TongHop deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NgoaiGioTungNgay_TongHop child in this)
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

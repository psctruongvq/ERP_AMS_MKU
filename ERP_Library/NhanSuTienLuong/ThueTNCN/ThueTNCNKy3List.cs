
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ThueTNCNKy3List : Csla.BusinessListBase<ThueTNCNKy3List, ThueTNCNKy3>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ThueTNCNKy3 item = ThueTNCNKy3.NewThueTNCNKy3Child();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private ThueTNCNKy3List()
        { /* require use of factory method */ }

        public static ThueTNCNKy3List NewThueTNCNKy3List()
        {
            return new ThueTNCNKy3List();
        }

        public static ThueTNCNKy3List GetThueTNCNKy3ListIn(int MaKyTinhLuong, int MaBoPhan, int LoaiIn)
        {
            return DataPortal.Fetch<ThueTNCNKy3List>(new FilterCriteriaIn(MaKyTinhLuong, MaBoPhan, LoaiIn));
        }
        public static ThueTNCNKy3List GetThueTNCNKy3List(int MaKyTinhLuong, int MaBoPhan)
        {
            return DataPortal.Fetch<ThueTNCNKy3List>(new FilterCriteria(MaKyTinhLuong, MaBoPhan));
        }
        public static ThueTNCNKy3List GetThueTNCNKy3TongHop(int MaKyTinhLuong,int LoaiIn)
        {
            return DataPortal.Fetch<ThueTNCNKy3List>(new FilterTongHop(MaKyTinhLuong, LoaiIn));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaKyTinhLuong, MaBoPhan;
            public FilterCriteria(int maKyTinhLuong, int maBoPhan)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
              
            }
        }

        [Serializable()]
        private class FilterCriteriaIn
        {
            public int MaKyTinhLuong, MaBoPhan, LoaiIn;
            public FilterCriteriaIn(int maKyTinhLuong, int maBoPhan, int loaiIn)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                LoaiIn = loaiIn;
            }
        }
        [Serializable()]
        private class FilterTongHop
        {
            public int MaKyTinhLuong, LoaiIn;
            public FilterTongHop(int maKyTinhLuong, int loaiIn)
            {
                MaKyTinhLuong = maKyTinhLuong;
                LoaiIn = loaiIn;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
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
                    cm.CommandText = "spd_Select_ThueTNCNKy3List";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);                    
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                if (criteria is FilterCriteriaIn)
                {
                    cm.CommandText = "spd_Select_ThueTNCNKy3ListIn";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaIn)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaIn)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", ((FilterCriteriaIn)criteria).LoaiIn);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterTongHop)
                {
                    cm.CommandText = "spd_Select_ThueTNCNKy3TongHop";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterTongHop)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@LoaiIn", ((FilterTongHop)criteria).LoaiIn);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThueTNCNKy3.GetThueTNCNKy3(dr));
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
                    foreach (ThueTNCNKy3 deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThueTNCNKy3 child in this)
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

        /// <summary>
        /// Tính lại dữ liệu thuế TNCN kỳ 3, MaBoPhan = 0  sẽ tính tất cả
        /// </summary>
        /// <param name="MaKyTinhLuong">Mã kỳ tính lương</param>
        /// <param name="MaBoPhan">Bộ phận tính thuế TNCN, =0 sẽ tính tất cả</param>
        public void TinhThueTNCN(int MaKyTinhLuong, int MaBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandTimeout = 0;
                cm.CommandText = "spd_TinhThueThuNhapCaNhanKy3";
                cm.CommandType = CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@MaKyTinhLuong", MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", MaBoPhan);
                cm.Parameters.AddWithValue("@USerID", ERP_Library.Security.CurrentUser.Info.UserID);
                cm.ExecuteNonQuery();
                cn.Close();
            }
        }
    }
}

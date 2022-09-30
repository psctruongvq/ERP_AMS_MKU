
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DeNghiChuyenKhoan_ChungTuNgoaiList : Csla.BusinessListBase<DeNghiChuyenKhoan_ChungTuNgoaiList, DeNghiChuyenKhoan_ChungTuNgoai>
    {
        #region BindingList Overrides
        private long iddef = -1;
        protected override object AddNewCore()
        {
            DeNghiChuyenKhoan_ChungTuNgoai item = DeNghiChuyenKhoan_ChungTuNgoai.NewDeNghiChuyenKhoan_ChungTuNgoai();
            item._maPhieu = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiChuyenKhoan_ChungTuNgoaiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiChuyenKhoan_ChungTuNgoaiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiChuyenKhoan_ChungTuNgoaiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiChuyenKhoan_ChungTuNgoaiList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuNgoaiListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeNghiChuyenKhoan_ChungTuNgoaiList()
        { /* require use of factory method */ }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList NewDeNghiChuyenKhoan_ChungTuNgoaiList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return new DeNghiChuyenKhoan_ChungTuNgoaiList();
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList(int userID)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria(userID));
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria_ByNgay(TuNgay, DenNgay));
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList(DateTime TuNgay, DateTime DenNgay, int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria_ByNgayAndLoai(TuNgay, DenNgay, LoaiDeNghi));
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaDuyet(int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria_ByChuaDuyet(LoaiDeNghi));
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaLapCT(int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria_ChuaLapCT(LoaiDeNghi));
        }

        public static DeNghiChuyenKhoan_ChungTuNgoaiList GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaLapCT_CongDoan(int LoaiDeNghi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTuNgoaiList");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTuNgoaiList>(new FilterCriteria_ChuaLapCT_CongDoan(LoaiDeNghi));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int UserID;

            public FilterCriteria(int userID)
            {
                this.UserID = userID;
            }
        }

        private class FilterCriteria_ByNgay
        {
            public DateTime _tuNgay;
            public DateTime _denNgay;

            public FilterCriteria_ByNgay(DateTime TuNgay, DateTime DenNgay)
            {
                this._tuNgay = TuNgay; 
                this._denNgay = DenNgay;
            }
        }

        private class FilterCriteria_ByNgayAndLoai
        {
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _loaiDeNghi;

            public FilterCriteria_ByNgayAndLoai(DateTime TuNgay, DateTime DenNgay, int LoaiDeNghi)
            {
                this._tuNgay = TuNgay;
                this._denNgay = DenNgay;
                this._loaiDeNghi = LoaiDeNghi;
            }
        }

        private class FilterCriteria_ByChuaDuyet
        {
            public int _loaiDeNghi;

            public FilterCriteria_ByChuaDuyet(int LoaiDeNghi)
            {
                this._loaiDeNghi = LoaiDeNghi;
            }
        }

        private class FilterCriteria_ChuaLapCT
        {
            public int _loaiDeNghi;

            public FilterCriteria_ChuaLapCT(int LoaiDeNghi)
            {
                this._loaiDeNghi = LoaiDeNghi;
            }
        }

        private class FilterCriteria_ChuaLapCT_CongDoan
        {
            public int _loaiDeNghi;

            public FilterCriteria_ChuaLapCT_CongDoan(int LoaiDeNghi)
            {
                this._loaiDeNghi = LoaiDeNghi;
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
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoaisAll";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ByNgay)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai_ByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgay)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgay)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ByNgayAndLoai)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai_ByNgayAndLoaiDeNghi";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgayAndLoai)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgayAndLoai)criteria)._denNgay);
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ByNgayAndLoai)criteria)._loaiDeNghi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ByChuaDuyet)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai_ByChuaDuyet";
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ByChuaDuyet)criteria)._loaiDeNghi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ChuaLapCT)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai_ByChuaCT";
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ChuaLapCT)criteria)._loaiDeNghi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan_ChungTuNgoai.GetDeNghiChuyenKhoan_ChungTuNgoai_New(dr));
                    }
                    return;
                }
                else if (criteria is FilterCriteria_ChuaLapCT_CongDoan)
                {
                    cm.CommandText = "spd_SelecttblDeNghiChuyenKhoan_ChungTuNgoai_ByChuaCT_CongDoan";
                    cm.Parameters.AddWithValue("@LoaiDeNghi", ((FilterCriteria_ChuaLapCT_CongDoan)criteria)._loaiDeNghi);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DeNghiChuyenKhoan_ChungTuNgoai.GetDeNghiChuyenKhoan_ChungTuNgoai_New(dr));
                    }
                    return;
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeNghiChuyenKhoan_ChungTuNgoai.GetDeNghiChuyenKhoan_ChungTuNgoai(dr));
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
                    foreach (DeNghiChuyenKhoan_ChungTuNgoai deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeNghiChuyenKhoan_ChungTuNgoai child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
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

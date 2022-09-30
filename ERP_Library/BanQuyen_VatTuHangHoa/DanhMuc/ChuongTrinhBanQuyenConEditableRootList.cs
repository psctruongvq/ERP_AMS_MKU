
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChuongTrinhBanQuyenConList : Csla.BusinessListBase<ChuongTrinhBanQuyenConList, ChuongTrinhBanQuyenCon>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChuongTrinhBanQuyenCon item = ChuongTrinhBanQuyenCon.NewChuongTrinhBanQuyenCon();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuongTrinhBanQuyenConList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuongTrinhBanQuyenConList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuongTrinhBanQuyenConList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuongTrinhBanQuyenConList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhBanQuyenConListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuongTrinhBanQuyenConList()
        { /* require use of factory method */ }

        public static ChuongTrinhBanQuyenConList NewChuongTrinhBanQuyenConList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinhBanQuyenConList");
            return new ChuongTrinhBanQuyenConList();
        }

        public static ChuongTrinhBanQuyenConList GetChuongTrinhBanQuyenConList(int maHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhBanQuyenConList");
            return DataPortal.Fetch<ChuongTrinhBanQuyenConList>(new FilterCriteriaByMaHangHoa(maHangHoa));
        }
        public static ChuongTrinhBanQuyenConList GetChuongTrinhBanQuyenConList(long maPhieuXuat, long maBoPhan, int maKho, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhBanQuyenConList");
            return DataPortal.Fetch<ChuongTrinhBanQuyenConList>(new FilterCriteriaWithSoLuongConTon(maPhieuXuat,maBoPhan,maKho,ngay));
        }
        public static ChuongTrinhBanQuyenConList GetChuongTrinhBanQuyenConList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhBanQuyenConList");
            return DataPortal.Fetch<ChuongTrinhBanQuyenConList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByMaHangHoa
        {
            public int MaHangHoa;

            public FilterCriteriaByMaHangHoa(int maHangHoa)
            {
                this.MaHangHoa = maHangHoa;
            }
        }
        private class FilterCriteriaWithSoLuongConTon
        {
            public long MaPhieuXuat;
            public long MaBoPhan;
            public int MaKho;
            public DateTime Ngay;
            public FilterCriteriaWithSoLuongConTon(long maPhieuXat,long maBoPhan,int maKho, DateTime ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.MaPhieuXuat = maPhieuXat;
                this.MaKho = maKho;
                this.Ngay = ngay;
            }
        }
        private class FilterCriteria
        {
            public FilterCriteria()
            {
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
                if (criteria is FilterCriteriaByMaHangHoa)
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenConsAllByMaHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", ((FilterCriteriaByMaHangHoa)criteria).MaHangHoa);
                }
                else if(criteria is FilterCriteriaWithSoLuongConTon)
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenConTon";
                    cm.Parameters.AddWithValue("@maPhieuXuat", ((FilterCriteriaWithSoLuongConTon)criteria).MaPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", ((FilterCriteriaWithSoLuongConTon)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@maKho", ((FilterCriteriaWithSoLuongConTon)criteria).MaKho);
                    cm.Parameters.AddWithValue("@ngay", ((FilterCriteriaWithSoLuongConTon)criteria).Ngay);
                }
                else
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenConsAll";
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(dr));
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
                    foreach (ChuongTrinhBanQuyenCon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChuongTrinhBanQuyenCon child in this)
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

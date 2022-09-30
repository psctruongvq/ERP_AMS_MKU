
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChuongTrinh_NewBQList : Csla.BusinessListBase<ChuongTrinh_NewBQList, ChuongTrinh_NewBQ>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChuongTrinh_NewBQ item = ChuongTrinh_NewBQ.NewChuongTrinh_New();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuongTrinh_NewList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuongTrinh_NewListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuongTrinh_NewBQList()
        { /* require use of factory method */ }

        public static ChuongTrinh_NewBQList NewChuongTrinh_NewList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuongTrinh_NewList");
            return new ChuongTrinh_NewBQList();
        }

     
        public static ChuongTrinh_NewBQList GetChuongTrinh_NewListConTon(long maPhieuXuat, long maBoPhan, int maKho, DateTime ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh_NewList");
            return DataPortal.Fetch<ChuongTrinh_NewBQList>(new FilterCriteriaWithSoLuongConTon(maPhieuXuat, maBoPhan, maKho, ngay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaWithSoLuongConTon
        {
            public long MaPhieuXuat;
            public long MaBoPhan;
            public int MaKho;
            public DateTime Ngay;
            public FilterCriteriaWithSoLuongConTon(long maPhieuXat, long maBoPhan, int maKho, DateTime ngay)
            {
                this.MaBoPhan = maBoPhan;
                this.MaPhieuXuat = maPhieuXat;
                this.MaKho = maKho;
                this.Ngay = ngay;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, Object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaWithSoLuongConTon)
                {
                    cm.CommandText = "spd_SelecttblChuongTrinhBanQuyenConTon_BQ";
                    cm.Parameters.AddWithValue("@maPhieuXuat", ((FilterCriteriaWithSoLuongConTon)criteria).MaPhieuXuat);
                    cm.Parameters.AddWithValue("@maBoPhan", ((FilterCriteriaWithSoLuongConTon)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@maKho", ((FilterCriteriaWithSoLuongConTon)criteria).MaKho);
                    cm.Parameters.AddWithValue("@ngay", ((FilterCriteriaWithSoLuongConTon)criteria).Ngay);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuongTrinh_NewBQ.GetChuongTrinh_New(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (ChuongTrinh_NewBQ deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChuongTrinh_NewBQ child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn,this);
                    else
                        child.Update(cn, this);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

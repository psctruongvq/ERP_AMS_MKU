using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LopHocList : Csla.BusinessListBase<LopHocList, LopHoc>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LopHoc item = LopHoc.NewLopHoc();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LopHocList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LopHocList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LopHocList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LopHocList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LopHocListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LopHocList()
        { /* require use of factory method */ }

        public static LopHocList NewLopHocList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LopHocList");
            return new LopHocList();
        }

        public static LopHocList GetLopHocList(int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, int maDonViDaoTao,int maLoaiLop)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LopHocList");
            return DataPortal.Fetch<LopHocList>(new FilterCriteria(loaiVanBang, maQuocGiaCap, maTruongDaoTao, maChuyenNganhDaoTao,nam,maDonViDaoTao,maLoaiLop));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int LoaiVanBang;
            public int MaQuocGiaCap;
            public int MaTruongDaoTao;
            public int MaChuyenNganhDaoTao;
            public int Nam;
            public int MaDonViDaoTao;
            public int MaLoaiLop;

            public FilterCriteria(int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao,int nam, int maDonViDaoTao,int maLoaiLop)
            {
                this.LoaiVanBang = loaiVanBang;
                this.MaQuocGiaCap = maQuocGiaCap;
                this.MaTruongDaoTao = maTruongDaoTao;
                this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
                this.Nam = nam;
                this.MaDonViDaoTao = maDonViDaoTao;
                this.MaLoaiLop = maLoaiLop;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsLopHocsAll";
                cm.Parameters.AddWithValue("@LoaiVanBang", criteria.LoaiVanBang);
                cm.Parameters.AddWithValue("@MaQuocGiaCap", criteria.MaQuocGiaCap);
                cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@MaDonViDaoTao", criteria.MaDonViDaoTao);
                cm.Parameters.AddWithValue("@MaLoaiLop", criteria.MaLoaiLop);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LopHoc.GetLopHoc(dr));
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
                    foreach (LopHoc deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LopHoc child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }
                    tr.Commit();
                }
                catch (Exception ex)
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

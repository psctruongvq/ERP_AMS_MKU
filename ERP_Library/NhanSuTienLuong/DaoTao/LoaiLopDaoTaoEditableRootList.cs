using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiLopDaoTaoList : Csla.BusinessListBase<LoaiLopDaoTaoList, LoaiLopDaoTao>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LoaiLopDaoTao item = LoaiLopDaoTao.NewLoaiLopDaoTao();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiLopDaoTaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiLopDaoTaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiLopDaoTaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiLopDaoTaoList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiLopDaoTaoList()
        { /* require use of factory method */ }

        public static LoaiLopDaoTaoList NewLoaiLopDaoTaoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiLopDaoTaoList");
            return new LoaiLopDaoTaoList();
        }

        public static LoaiLopDaoTaoList GetLoaiLopDaoTaoList(int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiLopDaoTaoList");
            return DataPortal.Fetch<LoaiLopDaoTaoList>(new FilterCriteria(loaiVanBang, maQuocGiaCap, maTruongDaoTao, maChuyenNganhDaoTao));
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

            public FilterCriteria(int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao)
            {
                this.LoaiVanBang = loaiVanBang;
                this.MaQuocGiaCap = maQuocGiaCap;
                this.MaTruongDaoTao = maTruongDaoTao;
                this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsLoaiLopDaoTaosAll";
                cm.Parameters.AddWithValue("@LoaiVanBang", criteria.LoaiVanBang);
                cm.Parameters.AddWithValue("@MaQuocGiaCap", criteria.MaQuocGiaCap);
                cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LoaiLopDaoTao.GetLoaiLopDaoTao(dr));
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
                    foreach (LoaiLopDaoTao deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LoaiLopDaoTao child in this)
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

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class QuaTrinhDaoTaoNhanLucList : Csla.BusinessListBase<QuaTrinhDaoTaoNhanLucList, QuaTrinhDaoTaoNhanLuc>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            QuaTrinhDaoTaoNhanLuc item = QuaTrinhDaoTaoNhanLuc.NewQuaTrinhDaoTaoNhanLuc();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuaTrinhDaoTaoNhanLucList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuaTrinhDaoTaoNhanLucList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuaTrinhDaoTaoNhanLucList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuaTrinhDaoTaoNhanLucList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoNhanLucListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private QuaTrinhDaoTaoNhanLucList()
        { /* require use of factory method */ }

        public static QuaTrinhDaoTaoNhanLucList NewQuaTrinhDaoTaoNhanLucList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoNhanLucList");
            return new QuaTrinhDaoTaoNhanLucList();
        }

        public static QuaTrinhDaoTaoNhanLucList GetQuaTrinhDaoTaoNhanLucList(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte ketQuaDaoTao, int maDonViDaoTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoNhanLucList");
            return DataPortal.Fetch<QuaTrinhDaoTaoNhanLucList>(new FilterCriteria(maLopHoc, loaiVanBang, maQuocGiaCap, maTruongDaoTao, maChuyenNganhDaoTao,nam,ketQuaDaoTao,maDonViDaoTao));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaLopHoc;
            public int LoaiVanBang;
            public int MaQuocGiaCap;
            public int MaTruongDaoTao;
            public int MaChuyenNganhDaoTao;
            public int Nam;
            public byte KetQuaDaoTao;
            public int MaDonViDaoTao;

            public FilterCriteria(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte ketQuaDaoTao,int maDonViDaoTao)
            {
                this.MaLopHoc = maLopHoc;
                this.LoaiVanBang = loaiVanBang;
                this.MaQuocGiaCap = maQuocGiaCap;
                this.MaTruongDaoTao = maTruongDaoTao;
                this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
                this.Nam = nam;
                this.KetQuaDaoTao = ketQuaDaoTao;
                this.MaDonViDaoTao = maDonViDaoTao;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTaoNhanSusAll";
                cm.Parameters.AddWithValue("@MaLopHoc", criteria.MaLopHoc);
                cm.Parameters.AddWithValue("@LoaiVanBang", criteria.LoaiVanBang);
                cm.Parameters.AddWithValue("@MaQuocGiaCap", criteria.MaQuocGiaCap);
                cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@KetQuaDaoTao", criteria.KetQuaDaoTao);
                cm.Parameters.AddWithValue("@MaDonViDaoTao", criteria.MaDonViDaoTao);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(QuaTrinhDaoTaoNhanLuc.GetQuaTrinhDaoTaoNhanLuc(dr));
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
                foreach (QuaTrinhDaoTaoNhanLuc deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (QuaTrinhDaoTaoNhanLuc child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}

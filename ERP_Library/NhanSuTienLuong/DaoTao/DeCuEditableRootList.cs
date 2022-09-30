using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DeCuList : Csla.BusinessListBase<DeCuList, DeCu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DeCu item = DeCu.NewDeCu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeCuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DeCuList()
        { /* require use of factory method */ }

        public static DeCuList NewDeCuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeCuList");
            return new DeCuList();
        }

        public static DeCuList GetDeCuList(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan, int maDonViDaoTao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeCuList");
            return DataPortal.Fetch<DeCuList>(new FilterCriteria(maLopHoc,loaiVanBang,maQuocGiaCap,maTruongDaoTao,maChuyenNganhDaoTao,nam,sapHetHan,thoiGianSapHetHan,maDonViDaoTao));
        }

        //public static ChiTietDeCuNhanVienList GetChiTietDeCuNhanVienList(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan)
        //{
        //    return new ChiTietDeCuNhanVienList(maLoaiLop, loaiVanBang, maQuocGiaCap, maTruongDaoTao, maChuyenNganhDaoTao, nam, sapHetHan, thoiGianSapHetHan);
        //}
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
            public byte SapHetHan;
            public int ThoiGianSapHetHan;
            public int MaDonViDaoTao;

            public FilterCriteria(int maLopHoc, int loaiVanBang, int maQuocGiaCap, int maTruongDaoTao, int maChuyenNganhDaoTao, int nam, byte sapHetHan, int thoiGianSapHetHan,int maDonViDaoTao)
            {
                this.MaLopHoc = maLopHoc;
                this.LoaiVanBang = loaiVanBang;
                this.MaQuocGiaCap = maQuocGiaCap;
                this.MaTruongDaoTao = maTruongDaoTao;
                this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
                this.Nam = nam;
                this.SapHetHan = sapHetHan;
                this.ThoiGianSapHetHan = thoiGianSapHetHan;
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
                cm.CommandText = "spd_SelecttblnsDeCubySearch";
                cm.Parameters.AddWithValue("@MaLopHoc", criteria.MaLopHoc);
                cm.Parameters.AddWithValue("@LoaiVanBang", criteria.LoaiVanBang);
                cm.Parameters.AddWithValue("@MaQuocGiaCap", criteria.MaQuocGiaCap);
                cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@SapHetHan", criteria.SapHetHan);
                cm.Parameters.AddWithValue("@ThoiGianSapHetHan", criteria.ThoiGianSapHetHan);
                cm.Parameters.AddWithValue("@MaDonViDaoTao", criteria.MaDonViDaoTao);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DeCu.GetDeCuWithOutChild(dr));
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
                    foreach (DeCu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (DeCu child in this)
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

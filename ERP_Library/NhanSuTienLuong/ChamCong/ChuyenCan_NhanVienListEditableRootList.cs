
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library;
namespace ERP_Library
{
    [Serializable()]

    public class ChuyenCan_NhanVienList : Csla.BusinessListBase<ChuyenCan_NhanVienList, ChuyenCan_NhanVien>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChuyenCan_NhanVien item = ChuyenCan_NhanVien.NewChuyenCan_NhanVien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChuyenCan_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChuyenCan_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChuyenCan_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChuyenCan_NhanVienList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChuyenCan_NhanVienListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChuyenCan_NhanVienList()
        { /* require use of factory method */ }

        public static ChuyenCan_NhanVienList NewChuyenCan_NhanVienList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChuyenCan_NhanVienList");
            return new ChuyenCan_NhanVienList();
        }

        public static ChuyenCan_NhanVienList GetChuyenCan_NhanVienList(long maNhanVien, int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenCan_NhanVienList");
            return DataPortal.Fetch<ChuyenCan_NhanVienList>(new FilterCriteria(maNhanVien, maKyTinhLuong));
        }
        public static ChuyenCan_NhanVienList GetChuyenCan_NhanVienList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenCan_NhanVienList");
            return DataPortal.Fetch<ChuyenCan_NhanVienList>(new FilterCriteria());
        }
        public static ChuyenCan_NhanVienList GetChuyenCan_NhanVienList(int MaBoPhan,int MaKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuyenCan_NhanVienList");
            return DataPortal.Fetch<ChuyenCan_NhanVienList>(new FilterCriteria(MaBoPhan, MaKyTinhLuong));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;
            public int MaBoPhan=0;

            public FilterCriteria(long maNhanVien, int maKyTinhLuong)
            {
                this.MaNhanVien = maNhanVien;
                this.MaKyTinhLuong = maKyTinhLuong;
            }
            public FilterCriteria()
            {
                this.MaBoPhan = 0;
            }
            public FilterCriteria(int maBoPhan,int maKyTinhLuong)
            {
                this.MaBoPhan = maBoPhan;
                this.MaKyTinhLuong = maKyTinhLuong;
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
                cm.CommandText = "[spd_SelecttblnsChuyenCan_NhanViensAll]";
                
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                //cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChuyenCan_NhanVien.GetChuyenCan_NhanVien(dr));
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
                foreach (ChuyenCan_NhanVien deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChuyenCan_NhanVien child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn, this);
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
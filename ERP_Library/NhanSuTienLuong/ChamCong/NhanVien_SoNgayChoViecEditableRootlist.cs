
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_SoNgayChoViecList : Csla.BusinessListBase<NhanVien_SoNgayChoViecList, NhanVien_SoNgayChoViec>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_SoNgayChoViec item = NhanVien_SoNgayChoViec.NewNhanVien_SoNgayChoViec();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in NhanVien_SoNgayChoViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in NhanVien_SoNgayChoViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in NhanVien_SoNgayChoViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in NhanVien_SoNgayChoViecList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhanVien_SoNgayChoViecListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private NhanVien_SoNgayChoViecList()
        { /* require use of factory method */ }

        public static NhanVien_SoNgayChoViecList NewNhanVien_SoNgayChoViecList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhanVien_SoNgayChoViecList");
            return new NhanVien_SoNgayChoViecList();
        }

        public static NhanVien_SoNgayChoViecList GetNhanVien_SoNgayChoViecList(long maNhanVien, int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_SoNgayChoViecList");
            return DataPortal.Fetch<NhanVien_SoNgayChoViecList>(new FilterCriteria(maNhanVien, maKyTinhLuong));
        }
        public static NhanVien_SoNgayChoViecList GetNhanVien_SoNgayChoViecList(int MaBoPhan,int MaKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_SoNgayChoViecList");
            return DataPortal.Fetch<NhanVien_SoNgayChoViecList>(new FilterCriteria(MaBoPhan,MaKyTinhLuong));
        }
        public static NhanVien_SoNgayChoViecList GetNhanVien_SoNgayChoViecList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVien_SoNgayChoViecList");
            return DataPortal.Fetch<NhanVien_SoNgayChoViecList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;
            public int MaBoPhan;

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
                cm.CommandText = "[spd_SelecttblnsNhanVien_SoNgayChoViecsAll]";
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                ////cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_SoNgayChoViec.GetNhanVien_SoNgayChoViec(dr));
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
                foreach (NhanVien_SoNgayChoViec deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (NhanVien_SoNgayChoViec child in this)
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

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]

    public class DanhsachNVTheoBiaBHXHList : Csla.BusinessListBase<DanhsachNVTheoBiaBHXHList, DanhsachNVTheoBiaBHXH>
    {

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DanhsachNVTheoHDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhsachNVTheoHDListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DanhsachNVTheoHDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhsachNVTheoHDListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DanhsachNVTheoHDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhsachNVTheoHDListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DanhsachNVTheoHDList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DanhsachNVTheoHDListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DanhsachNVTheoBiaBHXHList()
        { /* require use of factory method */ }

        public static DanhsachNVTheoBiaBHXHList NewDanhsachNVTheoBiaBHXHList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanhsachNVTheoHDList");
            return new DanhsachNVTheoBiaBHXHList();
        }

        public static DanhsachNVTheoBiaBHXHList GetNhanvien_chuacobiaBHXH(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaBHXHList>(new FilterCriteriaByDSchuacobiaBHXH(mabophan));
        }

        public static DanhsachNVTheoBiaBHXHList GetNhanvien_chuacobiaBHXHByTen(int mabophan,string ten)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaBHXHList>(new FilterCriteriaByDSchuacobiaBHXHByTen(mabophan,ten));
        }
        
        public static DanhsachNVTheoBiaBHXHList GetNhanvien_trongbiaBHXH(int mabiahoso)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaBHXHList>(new FilterCriteriaByDStrongbia(mabiahoso));
        }

        public static DanhsachNVTheoBiaBHXHList GetNhanvienDaNghi_trongbiaBHXH(int mabiahoso, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaBHXHList>(new FilterCriteriaByDSDaNghitrongbia(mabiahoso, tungay,denngay));

        }
        
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByDSchuacobiaBHXH
        {
            public int mabophan;
            public FilterCriteriaByDSchuacobiaBHXH(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaByDSchuacobiaBHXHByTen
        {
            public int mabophan;
            public string ten;
            public FilterCriteriaByDSchuacobiaBHXHByTen(int mabophan,string ten)
            {
                this.mabophan = mabophan;
                this.ten = ten;
            }
        }
        private class FilterCriteriaByDStrongbia
        {
            public int mabiahoso;
            public FilterCriteriaByDStrongbia(int mabiahoso)
            {
                this.mabiahoso = mabiahoso;
            }
        }

        private class FilterCriteriaByDSDaNghitrongbia
        {
            public int mabiahoso;
            public DateTime tungay;
            public DateTime Denngay;
            public FilterCriteriaByDSDaNghitrongbia(int mabiahoso, DateTime tungay,DateTime denngay)
            {
                this.mabiahoso = mabiahoso;
                this.tungay = tungay;
                this.Denngay = denngay;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            if (criteria is FilterCriteriaByDSchuacobiaBHXH)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienchuacobiaBHXH";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByDSchuacobiaBHXH)criteria).mabophan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaBHXH.GetDanhsachNVTheoBiaBHXH(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByDSchuacobiaBHXHByTen)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienchuacobiaBHXHByTen";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByDSchuacobiaBHXHByTen)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Ten", ((FilterCriteriaByDSchuacobiaBHXHByTen)criteria).ten);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaBHXH.GetDanhsachNVTheoBiaBHXH(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDStrongbia)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvientrongbiaBHXH";
                    cm.Parameters.AddWithValue("@MabiaBHXh", ((FilterCriteriaByDStrongbia)criteria).mabiahoso);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaBHXH.GetDanhsachNVTheoBiaBHXH(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByDSDaNghitrongbia)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienDanghitrongbiaBHXH";
                    cm.Parameters.AddWithValue("@MabiaBHXh", ((FilterCriteriaByDSDaNghitrongbia)criteria).mabiahoso);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByDSDaNghitrongbia)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByDSDaNghitrongbia)criteria).Denngay);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaBHXH.GetDanhsachNVTheoBiaBHXH(dr));
                    }
                }//using
            }
        }
        #endregion //Data Access - Fetch

        #region Data Access - Update
        /*
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (ThongTinNhanVienTongHop deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (ThongTinNhanVienTongHop child in this)
				{
					if (child.IsNew)
						child.Insert(cn);
					else
						child.Update(cn);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
        */
        #endregion //Data Access - Update

        #endregion //Data Access
    }
}

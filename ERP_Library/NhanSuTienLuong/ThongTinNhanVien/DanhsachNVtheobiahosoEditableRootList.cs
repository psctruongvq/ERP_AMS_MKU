
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DanhsachNVTheoBiaHoSoList : Csla.BusinessListBase<DanhsachNVTheoBiaHoSoList, DanhsachNVTheoBiaHoSo>
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
        private DanhsachNVTheoBiaHoSoList()
        { /* require use of factory method */ }

        public static DanhsachNVTheoBiaHoSoList NewDanhsachNVTheoBiaHoSoList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanhsachNVTheoHDList");
            return new DanhsachNVTheoBiaHoSoList();
        }
        public static DanhsachNVTheoBiaHoSoList GetNhanvien_chuacobiahoso(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByDSchuacobiahoso(mabophan));
        }

        public static DanhsachNVTheoBiaHoSoList GetNhanvien_chuacobiahosoByTen(int mabophan,string Ten)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByDSchuacobiahosoByTen(mabophan,Ten));
        }
        
        public static DanhsachNVTheoBiaHoSoList GetNhanvienBiaHoSoAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaAll());
        }

        public static DanhsachNVTheoBiaHoSoList GetNhanvienBiaHoSoByNhanVien(string DKTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByNhanVien(DKTim));
        }
        

        public static DanhsachNVTheoBiaHoSoList GetNhanvienBiaHoSoByBoPhan(int Mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByBoPhan(Mabophan));
        }


        public static DanhsachNVTheoBiaHoSoList GetNhanvien_trongbiahoso(int mabiahoso)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByDStrongbia(mabiahoso));
        }

        public static DanhsachNVTheoBiaHoSoList GetNhanvienDaNghi_trongbiahoso(int mabiahoso, DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoBiaHoSoList>(new FilterCriteriaByDSDaNghitrongbia(mabiahoso,tungay,denngay));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaAll
        {

            public FilterCriteriaAll()
            {
                
            }
        }

        private class FilterCriteriaByNhanVien
        {
            public string DKTim;
            public FilterCriteriaByNhanVien(string DKTim)
            {
                this.DKTim = DKTim;
            }
        }

        private class FilterCriteriaByBoPhan
        {
            public int mabophan;
            public FilterCriteriaByBoPhan(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaByDSchuacobiahoso
        {
            public int mabophan;
            public FilterCriteriaByDSchuacobiahoso(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaByDSchuacobiahosoByTen
        {
            public int mabophan;
            public string ten;
            public FilterCriteriaByDSchuacobiahosoByTen(int mabophan, string ten)
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
            public DateTime Tungay;
            public DateTime Denngay;
            public FilterCriteriaByDSDaNghitrongbia(int mabiahoso, DateTime tungay, DateTime denngay)
            {
                this.mabiahoso = mabiahoso;
                this.Tungay = tungay;
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
            if (criteria is FilterCriteriaByDSchuacobiahoso)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienchuacobiaHoso";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByDSchuacobiahoso)criteria).mabophan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByDSchuacobiahosoByTen)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienchuacobiaHosobyTen";
                    cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaByDSchuacobiahosoByTen)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Ten", ((FilterCriteriaByDSchuacobiahosoByTen)criteria).ten);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaAll)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThongTinCongTyBiaAll";                 
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByNhanVien)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThongTinCongTyBiaByNhanVien";
                    cm.Parameters.AddWithValue("@DKTim", ((FilterCriteriaByNhanVien)criteria).DKTim);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByBoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThongTinCongTyBiaByBoPhan";
                    cm.Parameters.AddWithValue("@maBophan", ((FilterCriteriaByBoPhan)criteria).mabophan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }
            
            else if (criteria is FilterCriteriaByDStrongbia)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvientrongbiaHoso";
                    cm.Parameters.AddWithValue("@Mabiahoso", ((FilterCriteriaByDStrongbia)criteria).mabiahoso);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSDaNghitrongbia)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanvienDaNghitrongbiaHoso";
                    cm.Parameters.AddWithValue("@Mabiahoso", ((FilterCriteriaByDSDaNghitrongbia)criteria).mabiahoso);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByDSDaNghitrongbia)criteria).Tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByDSDaNghitrongbia)criteria).Denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoBiaHoSo.GetDanhsachNVTheoBiaHoSo(dr));
                    }
                }//using
            }
        }
        #endregion //Data Access - Fetch

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

               
                // loop through each non-deleted child object
                foreach (DanhsachNVTheoBiaHoSo child in this)
                {
                    if (child.IsDirty)
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
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

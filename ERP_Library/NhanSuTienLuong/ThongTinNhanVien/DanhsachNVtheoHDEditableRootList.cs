
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DanhsachNVTheoHDList : Csla.BusinessListBase<DanhsachNVTheoHDList, DanhsachNVTheoHD>
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
        private DanhsachNVTheoHDList()
        { /* require use of factory method */ }

        public static DanhsachNVTheoHDList NewDanhsachNVTheoHDList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DanhsachNVTheoHDList");
            return new DanhsachNVTheoHDList();
        }
        public static DanhsachNVTheoHDList GetDanhsachNVTheoHDList(string dieuKienTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DanhsachNVTheoHDList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteria(dieuKienTim));
        }
        public static DanhsachNVTheoHDList GetNhanVienNghi(int maChiNhanh, int tuNam, int denNam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByNhanVienNghi(maChiNhanh, tuNam, denNam));
        }
        public static DanhsachNVTheoHDList GetNhanvien_ChuakyHD_ALL()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSchuakyHD_ALL());
        }
        public static DanhsachNVTheoHDList GetNhanvien_ChuakyHD(int mabophan,DateTime Tungay,DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSchuakyHD(mabophan,Tungay,Denngay));
        }
        public static DanhsachNVTheoHDList GetNhanvien_ChuakyHDByNgay( DateTime Tungay, DateTime Denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSchuakyHDByNgay(Tungay,Denngay));
        }
        
        public static DanhsachNVTheoHDList GetNhanvien_denhanchuyendoiHD_ALL(DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSdenhanchuyendoiHD_ALL(denngay));
        }
        public static DanhsachNVTheoHDList GetNhanvien_denhanchuyendoiHD(int mabophan, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSdenhanchuyendoiHD(mabophan, denngay));
        }

        public static DanhsachNVTheoHDList GetNhanvien_denhanchuyendoiHDByLoaiHD(int mabophan, DateTime denngay,int LoaiHD)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD(mabophan, denngay,LoaiHD));
        }

        public static DanhsachNVTheoHDList GetDSchuaphanbothuviecByBophan(int mabophan,DateTime TuNgay, DateTime Denngay, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaDSChuaPhanBoByBoPhan(mabophan,TuNgay, Denngay, Loai));
        }

        public static DanhsachNVTheoHDList GetDSchuaphanbothuviecByNgay(DateTime TuNgay, DateTime Denngay, int Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaDSChuaPhanBoByNgay(TuNgay, Denngay, Loai));
        }
        
        public static DanhsachNVTheoHDList GetDSNhanvienDangDiLamByBophan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaDSDangDiLam(mabophan));
        }

        public static DanhsachNVTheoHDList GetDSNhanvienDangDiLamByNhanVien(int mabophan,string DkTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThuViecHocViecList");
            return DataPortal.Fetch<DanhsachNVTheoHDList>(new FilterCriteriaDSDangDiLamByNhanVien(mabophan,DkTim));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public string dieuKienTim;
            public FilterCriteria(string dieuKienTim)
            {
                this.dieuKienTim = dieuKienTim;
            }
        }
        private class FilterCriteriaByNhanVienNghi
        {
            public int maChiNhanh;
            public int tuNam;
            public int denNam;
            public FilterCriteriaByNhanVienNghi(int maChiNhanh, int TuNam, int DenNam)
            {
                this.maChiNhanh = maChiNhanh;
                this.tuNam = TuNam;
                this.denNam = DenNam;
            }
        }
        private class FilterCriteriaByDSchuakyHD_ALL
        {
            public FilterCriteriaByDSchuakyHD_ALL()
            {

            }
        }
        private class FilterCriteriaByDSchuakyHD
        {
            public int mabophan;
            public DateTime tungay;
            public DateTime denngay;
            public FilterCriteriaByDSchuakyHD(int mabophan,DateTime tungay,DateTime denngay)
            {
                this.mabophan = mabophan;
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }
        private class FilterCriteriaByDSchuakyHDByNgay
        {
            public DateTime tungay;
            public DateTime denngay;
            public FilterCriteriaByDSchuakyHDByNgay(DateTime tungay, DateTime denngay)
            {
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }
        private class FilterCriteriaByDSdenhanchuyendoiHD_ALL
        {
            public DateTime denngay;
            public FilterCriteriaByDSdenhanchuyendoiHD_ALL(DateTime denngay)
            {
                this.denngay = denngay;
            }
        }
        private class FilterCriteriaByDSdenhanchuyendoiHD
        {
            public int mabophan;
            public DateTime denngay;
            public FilterCriteriaByDSdenhanchuyendoiHD(int mabophan, DateTime denngay)
            {
                this.mabophan = mabophan;
                this.denngay = denngay;
            }
        }
        private class FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD
        {
            public int mabophan;
            public DateTime denngay;
            public int LoaiHD;
            public FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD(int mabophan, DateTime denngay, int LoaiHD)
            {
                this.mabophan = mabophan;
                this.denngay = denngay;
                this.LoaiHD = LoaiHD;
            }
        }
        private class FilterCriteriaDSChuaPhanBoByBoPhan
        {
            public int mabophan;
            public DateTime tungay;
            public DateTime denngay;
            public int Loai;
            public FilterCriteriaDSChuaPhanBoByBoPhan(int mabophan,DateTime tungay,DateTime denngay,int Loai)
            {
                this.tungay = tungay;
                this.denngay = denngay;
                this.mabophan = mabophan;
                this.Loai = Loai;
            }
        }

        private class FilterCriteriaDSChuaPhanBoByNgay
        {
            public DateTime tungay;
            public DateTime denngay;
            public int Loai;
            public FilterCriteriaDSChuaPhanBoByNgay(DateTime tungay, DateTime denngay,int Loai)
            {
                this.Loai = Loai;
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }

        private class FilterCriteriaDSDangDiLam
        {
            public int mabophan;
            public FilterCriteriaDSDangDiLam(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }
        private class FilterCriteriaDSDangDiLamByNhanVien
        {
            public int mabophan;
            public string DKtim;
            public FilterCriteriaDSDangDiLamByNhanVien(int mabophan,string DKtim)
            {
                this.mabophan = mabophan;
                this.DKtim = DKtim;
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimNhanVien";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria)criteria).dieuKienTim);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByNhanVienNghi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNhanVienNghiAll";
                    cm.Parameters.AddWithValue("@MaChiNhanh", ((FilterCriteriaByNhanVienNghi)criteria).maChiNhanh);
                    cm.Parameters.AddWithValue("@TuNam", ((FilterCriteriaByNhanVienNghi)criteria).tuNam);
                    cm.Parameters.AddWithValue("@DenNam", ((FilterCriteriaByNhanVienNghi)criteria).denNam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSchuakyHD_ALL)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuakyHD_ALL";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSchuakyHD)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuakyHD";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByDSchuakyHD)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByDSchuakyHD)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByDSchuakyHD)criteria).denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSchuakyHDByNgay)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuakyHDByNgay";                    
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaByDSchuakyHDByNgay)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaByDSchuakyHDByNgay)criteria).denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSdenhanchuyendoiHD_ALL)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuyendoiHD_ALL";
                    cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaByDSdenhanchuyendoiHD_ALL)criteria).denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSdenhanchuyendoiHD)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuyendoiHD";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByDSdenhanchuyendoiHD)criteria).mabophan);
                    cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaByDSdenhanchuyendoiHD)criteria).denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_selecttblnsDSchuyendoiHDByLoaiHD";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).mabophan);
                    cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).denngay);
                    cm.Parameters.AddWithValue("@LoaiHD", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).LoaiHD);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDSChuaPhanBoByBoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThuViecHocViecChuaPhanBoByBoPhan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaDSChuaPhanBoByBoPhan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaDSChuaPhanBoByBoPhan)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaDSChuaPhanBoByBoPhan)criteria).denngay);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaDSChuaPhanBoByBoPhan)criteria).Loai); 
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using            
            }
            else if (criteria is FilterCriteriaDSChuaPhanBoByNgay)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThuViecHocViecChuaPhanBoByNgay";                    
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteriaDSChuaPhanBoByNgay)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteriaDSChuaPhanBoByNgay)criteria).denngay);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaDSChuaPhanBoByNgay)criteria).Loai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using            
            }
            else if (criteria is FilterCriteriaDSDangDiLam)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsDsDangdilamByBoPhan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaDSDangDiLam)criteria).mabophan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
                    }
                }//using            
            }
            else if (criteria is FilterCriteriaDSDangDiLamByNhanVien)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsDsDangdilamByNhanVien";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaDSDangDiLamByNhanVien)criteria).mabophan);
                    cm.Parameters.AddWithValue("@DkTim", ((FilterCriteriaDSDangDiLamByNhanVien)criteria).DKtim);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DanhsachNVTheoHD.GetDanhsachNVTheoHD(dr));
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

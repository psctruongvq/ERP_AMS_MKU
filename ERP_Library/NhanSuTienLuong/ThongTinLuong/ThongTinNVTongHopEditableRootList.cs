using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Collections;
namespace ERP_Library
{ 


	[Serializable()] 
	public class ThongTinNhanVienTongHopList : Csla.BusinessListBase<ThongTinNhanVienTongHopList, ThongTinNhanVienTongHop>
	{
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinNhanVienTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinNhanVienTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinNhanVienTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinNhanVienTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinNhanVienTongHopList()
		{ /* require use of factory method */ }

		public static ThongTinNhanVienTongHopList NewThongTinNhanVienTongHopList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHopList");
			return new ThongTinNhanVienTongHopList();
		}
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListByLuongKhoan()
        {
            
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaByLuongKhoan());
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListByBoPhan_DangLamViec(int maBoPhan)
        {

            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaByBoPhan_DangLamViec(maBoPhan));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListByLuongKhoan_New()
        {

            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaByLuongKhoan_New());
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList(ArrayList dieuKienTim,string TimTheoBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria(dieuKienTim, TimTheoBoPhan));
		}
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListSearch(string dieuKienTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaSearch(dieuKienTim));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListSearch_New(string dieuKienTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaSearch_New(dieuKienTim));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListByMabia(int mabiaHoSo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_ByMaBia(mabiaHoSo));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_ChucVu(int maChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_ChucVu(maChucVu));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_Bophan(int mabophan,long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhan(mabophan,maNhanVien));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(int mabophan,bool kieuNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanThuLaoChuongTrinh(mabophan, kieuNhanVien));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaKeCaNVBoPhanMoRong_ByMaBoPhan(maBoPhan));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_ByBophan(int mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_ByBoPhan(mabophan));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_CoTaiKhoanNganHang(int mabophan, bool kieuNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanCoTaiKhoanNganHang(mabophan, kieuNhanVien));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListTheoMaSoThue(int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new CriteriaBaoMaSoThue(maKyTinhLuong));
        }

        public static ThongTinNhanVienTongHopList GetNguoiLapAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new CriteriaByNguoiLapAll());
        }
        /// <summary>
        /// Lấy nhân viên ở cả 3 database.
        /// </summary>
        /// <param name="mabophan"></param>
        /// <param name="kieuNhanVien"></param>
        /// <returns></returns>
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_BophanByDatabase(int mabophan, bool kieuNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanByDatabase(mabophan, kieuNhanVien));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopListByTinhLuong(int mabophan, bool kieuNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_ByTinhLuong(mabophan, kieuNhanVien));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_DangLamViec()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_DangLamViec());
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_BophanByKieuNhanVien(int mabophan, bool kieuNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanKieuNhanVien(mabophan, kieuNhanVien));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_BophanKhongCotrongQTNghi(int mabophan,DateTime tungay, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanKhongCotrongQTNghi(mabophan,tungay,denngay));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopList_BophanAndNVKhongCotrongQTNghi(int mabophan, DateTime tungay, DateTime denngay,string Maso)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_BoPhanAndNVKhongCotrongQTNghi(mabophan,tungay,denngay,Maso));
        }

        public static ThongTinNhanVienTongHopList GetNhanVienNghi(int maChiNhanh, int tuNam, int denNam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaByNhanVienNghi(maChiNhanh, tuNam, denNam));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienNghiTongHopList_Bophan(int mabophan,long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_NghiBoPhan(mabophan,maNhanVien));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienNghiTongHopList_BophanAndKyLuong(int mabophan,int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteria_NghiBoPhanAndKyLuong(mabophan, maky));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienNghiTongHopListDieuChinhLuong_BophanAndKyLuong(int mabophan, int maky)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong(mabophan, maky));
        }

        public static ThongTinNhanVienTongHopList GetThongTinNhanVienNghiTongHopListDieuChinhLuong_BophanAndKyLuongNV(int mabophan, int maky, string DkTim)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHopList");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV(mabophan, maky, DkTim));
        }
        public static ThongTinNhanVienTongHopList GetThongTinNhanVienTongHopAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<ThongTinNhanVienTongHopList>(new CriteriaAll());
        }
    
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]


        private class CriteriaBaoMaSoThue
        {
            public int MaKyTinhLuong;

            public CriteriaBaoMaSoThue(int maKyTinhLuong)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
            }

        }
        private class CriteriaByNguoiLapAll
        {

            public CriteriaByNguoiLapAll()
            {
            }

        }

        private class FilterCriteriaByBoPhan_DangLamViec
        {
            public int _maBoPhan;

            public FilterCriteriaByBoPhan_DangLamViec(int maBoPhan)
            {
                _maBoPhan = maBoPhan;
            }
        }
        
         private class FilterCriteriaByLuongKhoan
        {
            public FilterCriteriaByLuongKhoan()
            {

            }
        }

         private class FilterCriteriaByLuongKhoan_New
         {
             public FilterCriteriaByLuongKhoan_New()
             {

             }
         }
        private class CriteriaAll
        {


            public CriteriaAll()
            {

            }

        }
     
		[Serializable()]
		private class FilterCriteria
		{
            //public string dieuKienTim;
            public ArrayList chuoi;
            public string TimTheoBP;
            public FilterCriteria(ArrayList chuoiDk, string TimTheoBP)
			{
                this.chuoi = chuoiDk;
                this.TimTheoBP = TimTheoBP;
			}
		}

        private class FilterCriteria_DangLamViec
        {
            public FilterCriteria_DangLamViec()
            {

            }
        }
        private class FilterCriteriaSearch
        {
            //public string dieuKienTim;
            public string chuoi;
           
            public FilterCriteriaSearch(string chuoiDk)
            {
                this.chuoi = chuoiDk;
               
            }
        }
        private class FilterCriteriaSearch_New
        {
            //public string dieuKienTim;
            public string chuoi;

            public FilterCriteriaSearch_New(string chuoiDk)
            {
                this.chuoi = chuoiDk;

            }
        }
        //private class FilterCriteria_ByMaQLNhanVien
        //{
        //    public string MaQLNhanVien;
        //    public FilterCriteria_ByMaQLNhanVien(string MaQLNhanVien)
        //    {
        //        this.MaQLNhanVien = MaQLNhanVien;

        //    }
        //}
        private class FilterCriteria_ChucVu
        {
            public int MaChucVu;
            public FilterCriteria_ChucVu(int maChucVu)
            {
                this.MaChucVu = maChucVu;
            }
        }

        private class FilterCriteria_ByMaBia
        {
            public int mabia;
            public FilterCriteria_ByMaBia(int mabia)
            {
                this.mabia = mabia;
            }
        }
        private class FilterCriteria_BoPhan
        {
            public int mabophan;
            public long maNhanVien;
            public FilterCriteria_BoPhan(int mabophan,long maNhanVien)
            {
                this.mabophan = mabophan;
                this.maNhanVien = maNhanVien;
            }
        }
        private class FilterCriteria_BoPhanThuLaoChuongTrinh
        {
            public int Mabophan;
            public bool KieuNhanVien;
            public FilterCriteria_BoPhanThuLaoChuongTrinh(int mabophan, bool kieuNhanVien)
            {
                this.Mabophan = mabophan;             
                this.KieuNhanVien = kieuNhanVien;
            }
        }
        private class FilterCriteriaKeCaNVBoPhanMoRong_ByMaBoPhan
        {
            public int MaBoPhan;
            public FilterCriteriaKeCaNVBoPhanMoRong_ByMaBoPhan(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterCriteria_ByBoPhan
        {
            public int Mabophan;
            public FilterCriteria_ByBoPhan(int mabophan)
            {
                this.Mabophan = mabophan;
            }
        }
        private class FilterCriteria_BoPhanCoTaiKhoanNganHang
        {
            public int Mabophan;
            public bool KieuNhanVien;
            public FilterCriteria_BoPhanCoTaiKhoanNganHang(int mabophan, bool kieuNhanVien)
            {
                this.Mabophan = mabophan;
                this.KieuNhanVien = kieuNhanVien;
            }
        }
        private class FilterCriteria_BoPhanByDatabase
        {
            public int Mabophan;
            public bool KieuNhanVien;
            public FilterCriteria_BoPhanByDatabase(int mabophan, bool kieuNhanVien)
            {
                this.Mabophan = mabophan;
                this.KieuNhanVien = kieuNhanVien;
            }
        }
             private class FilterCriteria_ByTinhLuong
        {
            public int Mabophan;
            public bool KieuNhanVien;
            public FilterCriteria_ByTinhLuong(int mabophan, bool kieuNhanVien)
            {
                this.Mabophan = mabophan;
                this.KieuNhanVien = kieuNhanVien;
            }
        }
        
        private class FilterCriteria_BoPhanKieuNhanVien
        {
            public int Mabophan;
           
            public bool KieuNhanVien;
            public FilterCriteria_BoPhanKieuNhanVien(int mabophan, bool kieuNhanVien)
            {
                this.Mabophan = mabophan;              
                this.KieuNhanVien = kieuNhanVien;
            }
        }
        private class FilterCriteria_BoPhanKhongCotrongQTNghi
        {
            public int mabophan;
            public DateTime tungay;
            public DateTime denngay; 
            public FilterCriteria_BoPhanKhongCotrongQTNghi(int mabophan,DateTime tungay, DateTime denngay)
            {
                this.mabophan = mabophan;
                this.tungay = tungay;
                this.denngay = denngay;
            }
        }
        private class FilterCriteria_BoPhanAndNVKhongCotrongQTNghi
        {
            public int mabophan;
            public DateTime tungay;
            public DateTime denngay;
            public string maso;
            public FilterCriteria_BoPhanAndNVKhongCotrongQTNghi(int mabophan, DateTime tungay, DateTime denngay,string maso)
            {
                this.mabophan = mabophan;
                this.tungay = tungay;
                this.denngay = denngay;
                this.maso = maso;
            }
        }
        private class FilterCriteria_NghiBoPhan
        {
            public int mabophan;
            public long manhanVien;
            public FilterCriteria_NghiBoPhan(int mabophan,long _manhanvien)
            {
                this.mabophan = mabophan;
                this.manhanVien = _manhanvien;
            }
        }
        private class FilterCriteria_NghiBoPhanAndKyLuong
        {
            public int mabophan;
            public int maky;
            public FilterCriteria_NghiBoPhanAndKyLuong(int mabophan, int maky)
            {
                this.mabophan = mabophan;
                this.maky = maky;
            }
        }

        private class FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV
        {
            public int mabophan;
            public int maky;
            public string DKtim;
            public FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV(int mabophan, int maky,string DKtim)
            {
                this.mabophan = mabophan;
                this.maky = maky;
                this.DKtim = DKtim;
            }
        }
        private class FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong
        {
            public int mabophan;
            public int maky;            
            public FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong(int mabophan, int maky)
            {
                this.mabophan = mabophan;
                this.maky = maky;               
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
            if (criteria is FilterCriteriaSearch )
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimNhanVien ";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteriaSearch)criteria).chuoi);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaSearch_New)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimNhanVien_New";
                    cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteriaSearch_New)criteria).chuoi);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is CriteriaByNguoiLapAll)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelectNguoiLapAll";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is CriteriaAll)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNhanVienAll";                   
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop_New(dr));
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
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_DangLamViec)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_DangLamViec";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr,1));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaByBoPhan_DangLamViec)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVienByBoPhan_DangLamViec";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhan_DangLamViec)criteria)._maBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr,1));
                    }
                }//using
            }

            else if (criteria is FilterCriteria_ChucVu)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_ChucVu";
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteria_ChucVu)criteria).MaChucVu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_BoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_BoPhan)criteria).maNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanThuLaoChuongTrinh)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_BoPhanByThuLaoChuongTrinh";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanThuLaoChuongTrinh)criteria).Mabophan);                    
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteria_BoPhanThuLaoChuongTrinh)criteria).KieuNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaKeCaNVBoPhanMoRong_ByMaBoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNhanVienKeCaNVBoPhanMoRong_ByMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaKeCaNVBoPhanMoRong_ByMaBoPhan)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ByBoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNhanVienAll_ByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByBoPhan)criteria).Mabophan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanCoTaiKhoanNganHang)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_ThuLaoATM";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanCoTaiKhoanNganHang)criteria).Mabophan);
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteria_BoPhanCoTaiKhoanNganHang)criteria).KieuNhanVien);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteria_ByTinhLuong)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_ByTinhLuong";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_ByTinhLuong)criteria).Mabophan);
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteria_ByTinhLuong)criteria).KieuNhanVien);                   
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanByDatabase)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_ByDatabase";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanByDatabase)criteria).Mabophan);
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteria_BoPhanByDatabase)criteria).KieuNhanVien);                   
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanKieuNhanVien)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_BoPhanByKieuNhanVien";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanKieuNhanVien)criteria).Mabophan);
                    cm.Parameters.AddWithValue("@LoaiNhanVien", ((FilterCriteria_BoPhanKieuNhanVien)criteria).KieuNhanVien);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
                
            else if (criteria is FilterCriteria_ByMaBia)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_DanhSachNhanVien_ByMaBia]";
                    cm.Parameters.AddWithValue("@mabiahoso", ((FilterCriteria_ByMaBia)criteria).mabia);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanKhongCotrongQTNghi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_BoPhanKhongCotrongQTNghi";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanKhongCotrongQTNghi)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteria_BoPhanKhongCotrongQTNghi)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteria_BoPhanKhongCotrongQTNghi)criteria).denngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_BoPhanAndNVKhongCotrongQTNghi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_BoPhanAndNVKhongCotrongQTNghi";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_BoPhanAndNVKhongCotrongQTNghi)criteria).mabophan);
                    cm.Parameters.AddWithValue("@Tungay", ((FilterCriteria_BoPhanAndNVKhongCotrongQTNghi)criteria).tungay);
                    cm.Parameters.AddWithValue("@Denngay", ((FilterCriteria_BoPhanAndNVKhongCotrongQTNghi)criteria).denngay);
                    cm.Parameters.AddWithValue("@MaQlNhanVien", ((FilterCriteria_BoPhanAndNVKhongCotrongQTNghi)criteria).maso);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteria_NghiBoPhan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_NghiBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_NghiBoPhan)criteria).mabophan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_NghiBoPhan)criteria).manhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_NghiBoPhanAndKyLuong)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVien_NghiBoPhanAndKyLuong";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_NghiBoPhanAndKyLuong)criteria).mabophan);
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteria_NghiBoPhanAndKyLuong)criteria).maky);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVienDieuChinhLuong_BoPhanAndKyLuongNV";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV)criteria).mabophan);
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV)criteria).maky);
                    cm.Parameters.AddWithValue("@DKTIM", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuongNV)criteria).DKtim);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVienDieuChinhLuong_BoPhanAndKyLuong";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong)criteria).mabophan);
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong)criteria).maky);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaSearch)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DanhSachNhanVienDieuChinhLuong_BoPhanAndKyLuong";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong)criteria).mabophan);
                    cm.Parameters.AddWithValue("@maky", ((FilterCriteriaDieuChinhLuong_BoPhanAndKyLuong)criteria).maky);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByLuongKhoan)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectNhanVienKhongBienChe";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByLuongKhoan_New)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectNhanVienKhongBienChe_New";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(dr));
                    }
                }//using
            }
            else if (criteria is CriteriaBaoMaSoThue)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoMaSoThueChoCucThue";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((CriteriaBaoMaSoThue)criteria).MaKyTinhLuong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHopBaoCaoThue(dr));
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

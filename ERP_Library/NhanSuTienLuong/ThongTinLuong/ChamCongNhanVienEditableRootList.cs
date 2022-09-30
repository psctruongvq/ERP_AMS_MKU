
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChamCongNhanVienList : Csla.BusinessListBase<ChamCongNhanVienList, ChamCongNhanVien>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChamCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChamCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChamCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChamCongNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChamCongNhanVienList()
		{ /* require use of factory method */ }

		public static ChamCongNhanVienList NewChamCongNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChamCongNhanVienList");
			return new ChamCongNhanVienList();
		}

		public static ChamCongNhanVienList GetChamCongNhanVienList(DateTime ngay,int maCty,int maPB,int maTo,int maCa)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
			return DataPortal.Fetch<ChamCongNhanVienList>(new FilterCriteria(ngay,maCty,maPB,maTo,maCa));
		}
        public static ChamCongNhanVienList GetNhanVienNghi(DateTime ngay, int maCty, int maPB, int maTo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
            return DataPortal.Fetch<ChamCongNhanVienList>(new FilterCriteria_NhanVienNghi(ngay, maCty, maPB, maTo));
        }
        public static ChamCongNhanVienList TimNhanVien(DateTime ngay, int maCty, int maPB, int maTo,string chuoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
            return DataPortal.Fetch<ChamCongNhanVienList>(new FilterCriteria_TimNhanVien(ngay, maCty, maPB, maTo,chuoi));
        }
        public static ChamCongNhanVienList TimNhanVien_TheoKyLuong(long MaNhanVien,int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
            return DataPortal.Fetch<ChamCongNhanVienList>(new FilterCriteria_TimNhanVienTheoKyLuong(MaNhanVien,maKy));
        }
        public static ChamCongNhanVienList TimNhanVien_TheoGioHC(DateTime ngay, int maCty, int maPB, int maTo,decimal Tu,decimal Den)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVienList");
            return DataPortal.Fetch<ChamCongNhanVienList>(new FilterCriteria_TimNhanVien_TheoGioHC(ngay,maCty, maPB, maTo, Tu, Den));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]
        private class FilterCriteria_TimNhanVien
        {
            public DateTime Ngay;
            public int MaCongTy;
            public int MaPhongBan;
            public int MaTo;
            public string chuoiTimNhanVien;
            
            public FilterCriteria_TimNhanVien(DateTime ngay, int cty, int pb, int to, string chuoi)
			{
                this.Ngay = ngay;
                this.MaCongTy = cty;
                this.MaPhongBan = pb;
                this.MaTo = to;                
                this.chuoiTimNhanVien = chuoi;
			}
        }
        private class FilterCriteria_TimNhanVienTheoKyLuong
        {            
            //public int MaCongTy;
            //public int MaPhongBan;
            //public int MaTo;
            public long MaNhanVien;
            public int MaKy;

            public FilterCriteria_TimNhanVienTheoKyLuong( long maNhanVien,int ky)
            {                
                //this.MaCongTy = cty;
                //this.MaPhongBan = pb;
                //this.MaTo = to;
                this.MaNhanVien = maNhanVien;
                this.MaKy = ky;
            }
        }
        private class FilterCriteria_TimNhanVien_TheoGioHC
        {
            public DateTime Ngay;
            public int MaCongTy;
            public int MaPhongBan;
            public int MaTo;
            public decimal Tu, Den;            

            public FilterCriteria_TimNhanVien_TheoGioHC(DateTime ngay, int cty, int pb, int to, decimal tu,decimal den)
            {
                this.Ngay = ngay;
                this.MaCongTy = cty;
                this.MaPhongBan = pb;
                this.MaTo = to;
                this.Tu = tu;
                this.Den = den;
            }
        }
        private class FilterCriteria_NhanVienNghi
        {
            public DateTime Ngay;
            public int MaCongTy;
            public int MaPhongBan;
            public int MaTo;
            //public int MaCa;
            public FilterCriteria_NhanVienNghi(DateTime ngay, int cty, int pb, int to)
            {
                this.Ngay = ngay;
                this.MaCongTy = cty;
                this.MaPhongBan = pb;
                this.MaTo = to;
                //this.MaCa = maCa;
            }
        }
		private class FilterCriteria
		{
            public DateTime Ngay;
            public int MaCongTy;
            public int MaPhongBan;
            public int MaTo;            
            public int MaCa;
            public FilterCriteria(DateTime ngay, int cty, int pb, int to,int maCa)
            {
                this.Ngay = ngay;
                this.MaCongTy = cty;
                this.MaPhongBan = pb;
                this.MaTo = to;
                this.MaCa = maCa;
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

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (criteria is FilterCriteria_TimNhanVien)
                    {
                        cm.CommandText = "spd_ChamCongBangTay_TimNhanVien";
                        cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria_TimNhanVien)criteria).Ngay);
                        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_TimNhanVien)criteria).MaCongTy);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria_TimNhanVien)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria_TimNhanVien)criteria).MaTo);
                        cm.Parameters.AddWithValue("@Chuoi", ((FilterCriteria_TimNhanVien)criteria).chuoiTimNhanVien);
                    }
                    else if (criteria is FilterCriteria_TimNhanVienTheoKyLuong)
                    {
                        cm.CommandText = "spd_ChamCongBangTay_TimNhanVienTheoKyLuong";                        
                        //cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaCongTy);
                        //cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaPhongBan);
                        //cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaTo);
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaNhanVien);
                        cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria_TimNhanVienTheoKyLuong)criteria).MaKy);
                    }
                    else if (criteria is FilterCriteria_TimNhanVien_TheoGioHC)
                    {
                        cm.CommandText = "spd_ChamCongBangTay_TimNhanVien_TheoGioHC";
                        cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Ngay);
                        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).MaCongTy);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).MaTo);
                        cm.Parameters.AddWithValue("@Tu", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Tu);
                        cm.Parameters.AddWithValue("@Den", ((FilterCriteria_TimNhanVien_TheoGioHC)criteria).Den);
                    }
                    else if (criteria is FilterCriteria)
                    {
                        cm.CommandText = "spd_ChamCongBangTay";
                        cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria)criteria).Ngay);
                        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria)criteria).MaCongTy);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria)criteria).MaTo);
                        cm.Parameters.AddWithValue("@MaCa", ((FilterCriteria)criteria).MaCa);
                    }
                    else if (criteria is FilterCriteria_NhanVienNghi)
                    {
                        cm.CommandText = "spd_ChamCong_NhanVienNghi";
                        cm.Parameters.AddWithValue("@Ngay", ((FilterCriteria_NhanVienNghi)criteria).Ngay);
                        cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_NhanVienNghi)criteria).MaCongTy);
                        cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria_NhanVienNghi)criteria).MaPhongBan);
                        cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria_NhanVienNghi)criteria).MaTo);                        
                    }
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChamCongNhanVien.GetChamCongNhanVien(dr));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

				// loop through each deleted child object
				foreach (ChamCongNhanVien deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (ChamCongNhanVien child in this)
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

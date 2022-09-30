
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NganHangList : Csla.BusinessListBase<NganHangList, NganHang>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NganHang item = NganHang.NewNganHang();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NganHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NganHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NganHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NganHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NganHangListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NganHangList()
		{ /* require use of factory method */ }

		public static NganHangList NewNganHangList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NganHangList");
			return new NganHangList();
		}

		public static NganHangList GetNganHangList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NganHangList");
			return DataPortal.Fetch<NganHangList>(new FilterCriteria());
		}
        public static NganHangList GetNganHangListByCongTy()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NganHangList");
            return DataPortal.Fetch<NganHangList>(new FilterCriteriaByCongTy());
        }

        public static NganHangList GetNganHangListByCTV(int maKyTinhLuong, int maNgangHang, DateTime tuNgay, DateTime denNgay, int userID, int maChuongTrinh, string maBoPhanString, string tenNganHangChuyen, int loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NganHangList");
            return DataPortal.Fetch<NganHangList>(new FilterCriteriaByCTV(maKyTinhLuong, maNgangHang, tuNgay, denNgay, userID, maChuongTrinh, maBoPhanString, tenNganHangChuyen, loai));
        }

        public static NganHangList GetNganHangListByCTVPhuCap(int maKyTinhLuong, int maKyPhuCap,int userID, int maNganHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NganHangList");
            return DataPortal.Fetch<NganHangList>(new FilterCriteriaByCTVPhuCap(maKyTinhLuong, maKyPhuCap, userID, maNganHang));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{

			public FilterCriteria()
			{

			}
		}

        [Serializable()]
        private class FilterCriteriaByCongTy
        {


            public FilterCriteriaByCongTy()
            {

            }
        }


        private class FilterCriteriaByCTV
        {
             public int MaKyTinhLuong ;     
	         public int  MaNganHang ;      
	         public  DateTime TuNgay ;      
	         public DateTime DenNgay ;
	         public int UserID ;           
	         public int  MaChuongTrinh ;
             public string MaBoPhan;
             public string TenNganHangChuyen;
             public int Loai;
             public FilterCriteriaByCTV( int maKyTinhLuong, int maNgangHang, DateTime tuNgay, DateTime denNgay, int userID, int maChuongTrinh, string maBoPhan, string tenNganHangChuyen, int loai)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaNganHang = maNgangHang;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.UserID = userID;
                this.MaChuongTrinh = maChuongTrinh;
                this.MaBoPhan = maBoPhan;
                this.TenNganHangChuyen = tenNganHangChuyen;
                this.Loai = loai;
            }
        }


        private class FilterCriteriaByCTVPhuCap
        {
            public int MaKyTinhLuong;
            public int MaKyPhuCap;
            public int MaNganHang;
            public int UserID;

            public FilterCriteriaByCTVPhuCap(int maKyTinhLuong, int maKyPhuCap, int maNgangHang, int userID)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaNganHang = maNgangHang;
                this.UserID = userID;
                this.MaKyPhuCap = maKyPhuCap;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlConnection cn, Object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsNganHangsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NganHang.GetNganHang_CoNhom(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCongTy)
                {
                    cm.CommandText = "spd_Select_TaiKhoanNganHangCongTyByLong";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NganHang.GetNganHang_CoNhom(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCTV)
                {
                    cm.CommandText = "spd_LayTatCaNganHangCoPhatSinh";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByCTV)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaByCTV)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByCTV)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByCTV)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByCTV)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByCTV)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TenNganHangChuyen", ((FilterCriteriaByCTV)criteria).TenNganHangChuyen);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByCTV)criteria).Loai);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NganHang.GetNganHang(dr));
                    }
                }
                else if (criteria is FilterCriteriaByCTVPhuCap)
                {
                    cm.CommandText = "spd_LayTatCaNganHangCoPhatSinhPhuCap";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByCTVPhuCap)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", ((FilterCriteriaByCTVPhuCap)criteria).MaKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaByCTVPhuCap)criteria).MaNganHang);                  
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NganHang.GetNganHang(dr));
                    }
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
                try
                {
                    // loop through each deleted child object
                    foreach (NganHang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NganHang child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn);
                        else
                            child.Update(cn);
                    }
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

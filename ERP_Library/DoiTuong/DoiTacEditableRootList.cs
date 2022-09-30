
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTacList : Csla.BusinessListBase<DoiTacList, DoiTac>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DoiTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTacListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DoiTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTacListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DoiTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTacListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DoiTacList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTacListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules


		#region Factory Methods
		private DoiTacList()
		{ /* require use of factory method */ }

		public static DoiTacList NewDoiTacList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTacList");
			return new DoiTacList();
		}
        
		public static DoiTacList GetDoiTacList(Boolean loai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
			return DataPortal.Fetch<DoiTacList>(new FilterCriteria(loai));
		}

        public static DoiTacList GetDoiTacList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaAll());
        }  

        public static DoiTacList GetDoiTacList(String tenDoiTac,int loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaByTenDoiTac(tenDoiTac,loai));
        }

        public static DoiTacList GetDoiTacList(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaByMaDoiTac(maDoiTac));
        }

        public static DoiTacList GetNCCVaKHList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaNCCKH());
        }

        public static DoiTacList GetDoiTacHocSinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaHocSinh());
        }

        public static DoiTacList GetHocSinhFormBienLai(string maTruong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaHocSinhBienLai(maTruong));
        }

        public static DoiTacList GetDoiTacListByOidDoiTacFromOtherDB(Guid oiddoitac, int idDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaByOidDoiTuongFromOtherDB (oiddoitac,idDoiTac));
        }  

        public static DoiTacList GetDoiTacListTheoLoaiKhachHang(int maLoaiKhachHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaByMaLoaiKhachHang(maLoaiKhachHang));
        }
        public static DoiTacList GetDoiTacListTheoKhachHangDaiLy(byte DoiTuongLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaKhachHangDaiLy(DoiTuongLap));
        }


        // By Loc

        public static DoiTacList GetDoiTacListByTen(int loai) // 0 nhac cc 1 kh 2 nhan vien
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaAllByTen(loai));
        }


        public static DoiTacList GetDoiTacListForNhapDoiTuongTheoDoiTaiKhoan() // 0 nhac cc 1 kh 2 nhan vien
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteriaWithOutChild());
        }

        public static DoiTacList GetDoiTacList_ByMaCongTy(int _maCongTy) // 0 nhac cc 1 kh 2 nhan vien
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteria_ByMaCongTy(_maCongTy));
        }
        public static DoiTacList GetHocSinhList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteria_GethocSinh());
        }
        public static DoiTacList GetDoiTacList_Refresh()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DoiTacList");
            return DataPortal.Fetch<DoiTacList>(new FilterCriteria_Refresh());
        }

        //spd_SelecttblDoiTac_ByMaCongTy
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public Boolean loai;

            public FilterCriteria(Boolean _loai)
            {
                this.loai = _loai;
            }
		}

        private class FilterCriteria_GethocSinh
        {
            public FilterCriteria_GethocSinh()
            {
            }
        }

            
        private class FilterCriteria_Refresh
        {
            public FilterCriteria_Refresh()
            {
            }
        }
        
        private class FilterCriteriaNCCKH
        {

            public FilterCriteriaNCCKH()
            {
            }
        }
        private class FilterCriteria_ByMaCongTy
        {
            public int maCongTy;

            public FilterCriteria_ByMaCongTy(int _maCongTy)
            {
                this.maCongTy = _maCongTy;
            }
        }

        private class FilterCriteriaHocSinh
        {

            public FilterCriteriaHocSinh()
            {
            }
        }

        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
               
            }
        }

        private class FilterCriteria_KDVangTrenTK
        {
            public FilterCriteria_KDVangTrenTK()
            {

            }
        }

        private class FilterCriteria_KDVangTrenTK_TuNgayDenNgay
        {
            public DateTime tuNgay;
            public DateTime denNgay;
            public FilterCriteria_KDVangTrenTK_TuNgayDenNgay(DateTime tuNgay,DateTime denNgay)
            {
                this.tuNgay = tuNgay;
                this.denNgay = denNgay;
            }
        }
        
        private class FilterCriteriaByTenDoiTac
        {
            public String  tenDoiTac;
            public int loai;
            public FilterCriteriaByTenDoiTac(String _tenDoiTac,int loai)
            {
                this.tenDoiTac = _tenDoiTac;
                this.loai = loai;
            }
        }
        //
        private class FilterCriteriaByMaDoiTac
        {
            public long maDoiTac;

            public FilterCriteriaByMaDoiTac(long _maDoiTac)
            {
                this.maDoiTac = _maDoiTac;
            }
        }

        private class FilterCriteriaByOidDoiTuongFromOtherDB
        {
            public Guid OidDoiTac;
            public int IdDoiTac;

            public FilterCriteriaByOidDoiTuongFromOtherDB(Guid oiddoitac,int iddoitac)
            {
                this.OidDoiTac = oiddoitac;
                this.IdDoiTac = iddoitac;
            }
        }

        private class FilterCriteria_ByMaLoaiKho
        {
            public int maLoaiKho;

            public FilterCriteria_ByMaLoaiKho(int _maLoaiKho)
            {
                this.maLoaiKho = _maLoaiKho;
            }
        }

        private class FilterCriteriaByMaLoaiKhachHang
        {
            public int  MaLoaiKhachHang;

            public FilterCriteriaByMaLoaiKhachHang(int _maLoaiKhachHang)
            {
                this.MaLoaiKhachHang= _maLoaiKhachHang;
            }
        }

        private class FilterCriteriaKhachHangDaiLy
        {
            public byte DoiTuongLap;

            public FilterCriteriaKhachHangDaiLy(byte _DoiTuongLap)
            {
                this.DoiTuongLap = _DoiTuongLap;
            }
        }

        private class FilterCriteriaAllByTen
        {
            public int loai;
            public FilterCriteriaAllByTen(int loai)
            {
                this.loai = loai;                
            }
        }
        
        private class FilterCriteriaHocSinhBienLai
        {
            public string maTruong = "";
            public FilterCriteriaHocSinhBienLai(string MaTruong)
            {
                this.maTruong = MaTruong;
            }
        }

        private class FilterCriteriaWithOutChild
        {
            public FilterCriteriaWithOutChild()
            {
               
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		protected override void DataPortal_Fetch(object criteria)
		{            
			RaiseListChangedEvents = false;

			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

					tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using

			RaiseListChangedEvents = true;
		}

        
		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
            
            if (criteria is FilterCriteriaAll)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "spd_SelecttblDoiTac_KDK";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTac(dr));
                    }
                }//using
            }
            //lay doi tac theo loai
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacsAll";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).loai);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTac(dr));
                    }
                }//using
            }
            //lay doi tac theo ten
            else if (criteria is FilterCriteriaByTenDoiTac)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacByTenDoiTac";
                    cm.Parameters.AddWithValue("@TenDoiTac",((FilterCriteriaByTenDoiTac)criteria).tenDoiTac);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByTenDoiTac)criteria).loai);
                    cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByTen(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaHocSinh)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacHocSinh";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByTen(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaHocSinhBienLai)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetHocSinhFromBienLai";
                    cm.Parameters.AddWithValue("@maTruong", ((FilterCriteriaHocSinhBienLai)criteria).maTruong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetHocSinhFromBienLai(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByMaDoiTac)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacByMaDoiTac";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByMaDoiTac)criteria).maDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByViewDoiTuong(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaNCCKH)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacByTenDoiTac_1";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByTen(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByOidDoiTuongFromOtherDB)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacByOidDoiTacFromOtherDB";
                    cm.Parameters.AddWithValue("@OidDoiTac", ((FilterCriteriaByOidDoiTuongFromOtherDB)criteria).OidDoiTac);
                    cm.Parameters.AddWithValue("@IdDoiTac", ((FilterCriteriaByOidDoiTuongFromOtherDB)criteria).IdDoiTac);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByViewDoiTuong(dr));
                    }
                }//using
            }
          
            else if (criteria is FilterCriteriaByMaLoaiKhachHang)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacByMaLoaiKhachHang";
                    cm.Parameters.AddWithValue("@MaLoaiKhachHang", ((FilterCriteriaByMaLoaiKhachHang)criteria).MaLoaiKhachHang);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTac(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaAllByTen)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacsAllByTen";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaAllByTen)criteria).loai);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByTen(dr));
                    }
                }//using
            }

            else if (criteria is FilterCriteriaWithOutChild)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTacForNhapDoiTuongTheoDoiTaiKhoan";
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByViewDoiTuong(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ByMaCongTy)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblDoiTac_ByMaCongTy";
                    cm.Parameters.AddWithValue("@maCongTy", ((FilterCriteria_ByMaCongTy)criteria).maCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetDoiTacByTen(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_GethocSinh)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetHocSinhByTen";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(DoiTac.GetHocSinh(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_Refresh)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "dbo.spd_UpdateDoiTuongFromOtherDB_ForAccountsFee";
                    cm.ExecuteNonQuery();
                }//using
            }
           
		}
        private void ExecuteFetchByTen(SqlTransaction tr, object criteria)
        {
            
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
                    foreach (DoiTac deletedChild in DeletedList)
                    {
                        if (deletedChild.DiaChi_DoiTacList.Count == 0)
                        {
                            //xoa doi tuong ma co fetch child nen loi khoa ngoai, phai get lai dung doi tuong de xoa
                            DoiTac.GetDoiTac(deletedChild.MaDoiTac).DeleteSelf(tr);                           
                        }
                        else
                        {
                            deletedChild.DeleteSelf(tr);
                        }

                    }
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DoiTac child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

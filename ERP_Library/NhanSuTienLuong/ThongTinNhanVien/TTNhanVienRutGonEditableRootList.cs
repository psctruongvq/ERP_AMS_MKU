
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class TTNhanVienRutGonList : Csla.BusinessListBase<TTNhanVienRutGonList, TTNhanVienRutGon>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TTNhanVienRutGonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TTNhanVienRutGonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TTNhanVienRutGonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TTNhanVienRutGonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TTNhanVienRutGonListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TTNhanVienRutGonList()
		{ /* require use of factory method */ }

		public static TTNhanVienRutGonList NewTTNhanVienRutGonList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TTNhanVienRutGonList");
			return new TTNhanVienRutGonList();
		}

        public static TTNhanVienRutGonList GetNhanVienListBoPhan(int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TTNhanVienRutGonList");
			return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteria(maBoPhan));
		}
     
        public static TTNhanVienRutGonList GetNhanVienListByMaChucVu(int MaChucVu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaByMaChucVu(MaChucVu));
        }
        public static TTNhanVienRutGonList GetNhanVienListByMaChucVuBoPhan(int MaChucVu,int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaByBoPhanMaChucVu(MaChucVu,MaBoPhan));
        }
        public static TTNhanVienRutGonList GetNhanVienListMangThaiByMaBoPhan(int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaByMangThaiCon1Tuoi(MaBoPhan));
        }

        public static TTNhanVienRutGonList GetNhanVienListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaAll());
        }
        public static TTNhanVienRutGonList GetNhanVienListByCachTinhThue(Int16 cachTinhThue)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaThueTNCN(cachTinhThue));
        }
        public static TTNhanVienRutGonList GetNhanVienListByDangVien(int maBoPhan,long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaDangVien(maBoPhan,maNhanVien));
        }
        public static TTNhanVienRutGonList GetNhanVienListByBoPhanNhanVien(int maBoPhan, long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaBoPhanNhanVien(maBoPhan, maNhanVien));
        }
        public static TTNhanVienRutGonList GetNhanVienListBoPhanTrongNgoai(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TTNhanVienRutGonList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaTrongNgoai(maBoPhan));
        }
        /// <summary>
        /// Input MaLoaiNhanVien: 0: All; 101: MaLoai=1,4; 102: MaLoai=2,3; 103: MaLoai=5
        /// </summary>
        /// <param name="maBoPhan"></param>
        /// <param name="maLoaiNV">0: All; 101: MaLoai=1,4; 102: MaLoai=2,3; 103: MaLoai=5</param>
        /// <param name="maNganHang"></param>
        /// <param name="maNhanVien"></param>
        /// <returns></returns>
        public static TTNhanVienRutGonList GetNhanVienListByBoPhanNganHang(int maBoPhan,int maLoaiNV,int maNganHang, long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaBoPhanNganHang(maBoPhan,maLoaiNV,maNganHang, maNhanVien));
        }
        public static TTNhanVienRutGonList GetNhanVienListByBoPhanCachTinhThue(Int16 cachTinhThue,int maBoPhan,long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhanVienList");
            return DataPortal.Fetch<TTNhanVienRutGonList>(new FilterCriteriaBoPhanThueTNCN(cachTinhThue,maBoPhan,maNhanVien));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class FilterCriteriaAll
        {
           // public int MaBoPhan;
            public FilterCriteriaAll()
            {
               // this.MaBoPhan = MaBoPhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaThueTNCN
        {
            public Int16 cachTinhThue;
            public FilterCriteriaThueTNCN(Int16 _cachTinhThue)
            {
                this.cachTinhThue = _cachTinhThue;
            }
        }
        [Serializable()]
        private class FilterCriteriaDangVien
        {
            public int MaBoPhan;
            public long MaNhanVien;
            public FilterCriteriaDangVien(int maBoPhan,long maNhanVien)
            {
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
            }
        }
        [Serializable()]
        private class FilterCriteriaBoPhanNhanVien
        {
            public int MaBoPhan;
            public long MaNhanVien;
            public FilterCriteriaBoPhanNhanVien(int maBoPhan, long maNhanVien)
            {
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
            }
        }
        private class FilterCriteriaBoPhanNganHang
        {
            public int MaBoPhan;
            public int MaLoaiNV;
            public long MaNhanVien;
            public long MaNganHang;
            public FilterCriteriaBoPhanNganHang(int maBoPhan,int maLoaiNV ,int maNganHang, long maNhanVien)
            {
                this.MaBoPhan = maBoPhan;
                this.MaLoaiNV = maLoaiNV;
                this.MaNhanVien = maNhanVien;
                this.MaNganHang = maNganHang;
            }
        }

        private class FilterCriteriaBoPhanThueTNCN
        {
            public Int16 cachTinhThue;
            public int MaBoPhan;
            public long MaNhanVien;
            public FilterCriteriaBoPhanThueTNCN(Int16 _cachTinhThue, int MaBoPhan, long maNhanVien)
            {
                this.cachTinhThue = _cachTinhThue;
                this.MaBoPhan = MaBoPhan;
                this.MaNhanVien = maNhanVien;
            }
        }
		private class FilterCriteria
		{
            public int MaBoPhan;
			public FilterCriteria(int MaBoPhan)
			{
                this.MaBoPhan = MaBoPhan;
			}
		}
      
        private class FilterCriteriaByMangThaiCon1Tuoi
        {
            public int MaBoPhan;
            public FilterCriteriaByMangThaiCon1Tuoi(int MaBoPhan)
            {
                this.MaBoPhan = MaBoPhan;
            }
        }
        private class FilterCriteriaByMaChucVu
        {
            public int MaChucVu;
            public FilterCriteriaByMaChucVu(int MaChucVu)
            {
                this.MaChucVu = MaChucVu;
            }
        }
        private class FilterCriteriaByBoPhanMaChucVu
        {
            public int MaChucVu;
            public int MaBoPhan;
            public FilterCriteriaByBoPhanMaChucVu(int MaChucVu,int maBoPhan)
            {
                this.MaChucVu = MaChucVu;
                this.MaBoPhan = maBoPhan;
            }
        }
        private class FilterCriteriaTrongNgoai
        {
            public int MaBoPhan;
            public FilterCriteriaTrongNgoai(int MaBoPhan)
            {
                this.MaBoPhan = MaBoPhan;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonAll";
                    
                }
                else if (criteria is FilterCriteriaThueTNCN)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonCachTinhThue";
                    cm.Parameters.AddWithValue("@CachTinhThue", ((FilterCriteriaThueTNCN)criteria).cachTinhThue);
                }
                else if (criteria is FilterCriteriaBoPhanThueTNCN)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonBoPhanCachTinhThue";
                    cm.Parameters.AddWithValue("@CachTinhThue", ((FilterCriteriaBoPhanThueTNCN)criteria).cachTinhThue);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaBoPhanThueTNCN)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaBoPhanThueTNCN)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteria) criteria).MaBoPhan);
                }
               
                else if (criteria is FilterCriteriaDangVien)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByDangVien";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaDangVien)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaDangVien)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaBoPhanDangNhap", (ERP_Library.Security.CurrentUser.Info.MaBoPhan));
                }
                else if (criteria is FilterCriteriaBoPhanNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByBoPhanNhanVien";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaBoPhanNhanVien)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaBoPhanNhanVien)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaBoPhanNganHang)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByBoPhanNganHang";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaBoPhanNganHang)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaBoPhanNganHang)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaNganHang", ((FilterCriteriaBoPhanNganHang)criteria).MaNganHang);
                    cm.Parameters.AddWithValue("@MaLoaiNV", ((FilterCriteriaBoPhanNganHang)criteria).MaLoaiNV);
                }
                else if (criteria is FilterCriteriaByMangThaiCon1Tuoi)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonMangThaiByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteria) criteria).MaBoPhan);
                }
                
                else if (criteria is FilterCriteriaByMaChucVu)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByChucVu";
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByMaChucVu)criteria).MaChucVu);
                }
                else if (criteria is FilterCriteriaByBoPhanMaChucVu)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByBoPhanChucVu";
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByBoPhanMaChucVu)criteria).MaChucVu);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhanMaChucVu)criteria).MaBoPhan);
                }
                else if (criteria is FilterCriteriaTrongNgoai)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonByBoPhanTrongNgoai";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTrongNgoai)criteria).MaBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TTNhanVienRutGon.GetTTNhanVienRutGonTrongNgoai(dr));
                    }
                    return;
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TTNhanVienRutGon.GetTTNhanVienRutGon(dr));
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
					foreach (TTNhanVienRutGon deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TTNhanVienRutGon child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
					}

					tr.Commit();
				}
				catch
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

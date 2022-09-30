
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayXacNhan_TrackingList : Csla.BusinessListBase<GiayXacNhan_TrackingList, GiayXacNhan_Tracking>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			GiayXacNhan_Tracking item = GiayXacNhan_Tracking.NewGiayXacNhan_Tracking();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private GiayXacNhan_TrackingList()
		{ /* require use of factory method */ }

		public static GiayXacNhan_TrackingList NewGiayXacNhan_TrackingList()
		{
			return new GiayXacNhan_TrackingList();
		}

		public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingList()
		{
			return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteria());
		}
        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByDeNghiChuyenKhoan(string maPhieuStr)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByDeNghiChuyenKhoan(maPhieuStr));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByDeNghiChuyenKhoanByNhanVien(string maPhieuStr)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByDeNghiChuyenKhoanByNhanVien(maPhieuStr));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByChiTietGiayXacNhan(int maChiTietGiayXacNhan)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByChiTietGiayXacNhan(maChiTietGiayXacNhan));
        }
        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByUser(int userID,DateTime tuNgay,DateTime denNgay)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByUser(userID, tuNgay, denNgay));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByDVChuQuan(int userID, DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByDVChuQuan(userID, tuNgay, denNgay));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByNgayLap_TheoDoiGiayXacNhanDVCQ(int userID, DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ(userID, tuNgay, denNgay));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByNgayLap_TheoDoiGiayXacNhan(int userID, DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByNgayLap_TheoDoiGiayXacNhan(userID, tuNgay, denNgay));
        }

        public static GiayXacNhan_TrackingList GetGiayXacNhan_TrackingListByNgayNhapThuLao(int userID, DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<GiayXacNhan_TrackingList>(new FilterCriteriaByUserNgayLapThuLao(userID, tuNgay, denNgay));
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
        private class FilterCriteriaByDeNghiChuyenKhoan
		{
            public string MaPhieu;
            public FilterCriteriaByDeNghiChuyenKhoan(string maPhieu)
			{
                this.MaPhieu = maPhieu;
			}
		}

        private class FilterCriteriaByDeNghiChuyenKhoanByNhanVien
        {
            public string MaPhieu;
            public FilterCriteriaByDeNghiChuyenKhoanByNhanVien(string maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }
        
        private class FilterCriteriaByChiTietGiayXacNhan
		{
            public int MaChiTietGiayXacNhan;
            public FilterCriteriaByChiTietGiayXacNhan(int maChiTietGiayXacNhan)
			{
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
			}
		}
        private class FilterCriteriaByUser
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByUser(int userID,DateTime tuNgay,DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByDVChuQuan
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByDVChuQuan(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByNgayLap_TheoDoiGiayXacNhan
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayLap_TheoDoiGiayXacNhan(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByUserNgayLapThuLao
        {
            public int UserID;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByUserNgayLapThuLao(int userID, DateTime tuNgay, DateTime denNgay)
            {
                this.UserID = userID;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
                cm.CommandTimeout = 90;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByChiTietGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingByMaChiTietGXN";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByChiTietGiayXacNhan)criteria).MaChiTietGiayXacNhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByUser && Security.CurrentUser.IsAdminThuChi==true)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingByAdminThuChi";                    
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByUser)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByUser)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUser)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByUser)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingByUser";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUser)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByUser)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByUser)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByDVChuQuan)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_TrackingByDVChuQuan";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByDVChuQuan)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByDVChuQuan)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByDVChuQuan)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_ByNgayLap_TheoDoiGiayXacNhanDVCQ";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhanDVCQ)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByNgayLap_TheoDoiGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhan_ByNgayLap_TheoDoiGiayXacNhan";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhan)criteria).UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhan)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap_TheoDoiGiayXacNhan)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(dr));
                    }
                }
                else if (criteria is FilterCriteriaByDeNghiChuyenKhoan)
                {
                    cm.CommandText = "SelectGiayXacNhan_DeNghiChuyenKhoan";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteriaByDeNghiChuyenKhoan)criteria).MaPhieu);
                    cm.CommandTimeout = 0;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_TrackingDeNghiChuyenKhoan(dr));
                    }
                }

                else if (criteria is FilterCriteriaByDeNghiChuyenKhoanByNhanVien)
                {
                    cm.CommandText = "SelectGiayXacNhan_DeNghiChuyenKhoanByNhanVienNhapHo";
                    cm.Parameters.AddWithValue("@MaPhieu", ((FilterCriteriaByDeNghiChuyenKhoanByNhanVien)criteria).MaPhieu);
                    cm.CommandTimeout = 0;
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhan_Tracking.GetGiayXacNhan_TrackingDeNghiChuyenKhoanByNhanVien(dr));
                    }
                }
				
               // 
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        internal void Update(SqlTransaction tr, ChiTietGiayXacNhan parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (GiayXacNhan_Tracking deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (GiayXacNhan_Tracking child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        /*
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
                    foreach (GiayXacNhan_Tracking deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
                    foreach (GiayXacNhan_Tracking child in this)
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
        */
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

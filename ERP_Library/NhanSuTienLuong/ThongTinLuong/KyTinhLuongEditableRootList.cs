
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyTinhLuongList : Csla.BusinessListBase<KyTinhLuongList, KyTinhLuong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KyTinhLuong item = KyTinhLuong.NewKyTinhLuong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyTinhLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyTinhLuongList()
		{ /* require use of factory method */ }

        public static KyTinhLuongList GetKyTinhLuong_TheoNam(int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterCriteria_Nam(Nam));
        }

		public static KyTinhLuongList NewKyTinhLuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyTinhLuongList");
			return new KyTinhLuongList();
		}

		public static KyTinhLuongList GetKyTinhLuongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
			return DataPortal.Fetch<KyTinhLuongList>(new FilterCriteria());
		}

        public static KyTinhLuongList GetKyTinhLuongKy3List()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterCriteriaKy3());
        }
        public static KyTinhLuongList GetKyTinhLuongListByKhoaSo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterCriteriaByKhoaSo());
        }

        public static KyTinhLuongList GetKyChamNgoaiGioTungNgay(int MaKyTinhLuong, int MaBoPhan, int MaLoai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterKyChamNgoaiGioTungNgay(MaKyTinhLuong, MaBoPhan, MaLoai));
        }
        public static KyTinhLuongList GetKyChamNgoaiGioTongHop(int MaKyTinhLuong, int MaBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterKyChamNgoaiGioTongHop(MaKyTinhLuong, MaBoPhan));
        }

        public static KyTinhLuongList GetKyTinhPhuCap(int MaKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuongList");
            return DataPortal.Fetch<KyTinhLuongList>(new FilterKyTinhPhuCap(MaKyTinhLuong));
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

        private class FilterCriteriaKy3
        {

            public FilterCriteriaKy3()
            {

            }
        }
        [Serializable()]
        private class FilterCriteriaByKhoaSo
        {

            public FilterCriteriaByKhoaSo()
            {

            }
        }
        private class FilterCriteria_Nam
        {
            public int nam;
            public FilterCriteria_Nam(int year)
            {
                this.nam = year;
            }
        }
        private class FilterKyChamNgoaiGioTungNgay
        {
            public int MaKyTinhLuong, MaBoPhan, MaLoai;
            public FilterKyChamNgoaiGioTungNgay(int maKyTinhLuong, int maBoPhan, int maLoai)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
                MaLoai = maLoai;
            }
        }
        private class FilterKyChamNgoaiGioTongHop
        {
            public int MaKyTinhLuong, MaBoPhan;
            public FilterKyChamNgoaiGioTongHop(int maKyTinhLuong, int maBoPhan)
            {
                MaKyTinhLuong = maKyTinhLuong;
                MaBoPhan = maBoPhan;
            }
        }

        private class FilterKyTinhPhuCap
        {
            public int MaKyTinhLuong;
            public FilterKyTinhPhuCap(int maKyTinhLuong)
            {
                MaKyTinhLuong = maKyTinhLuong;
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsKyTinhLuongsAll";
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaKy3)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_SelecttblnsKyTinhLuongKy3]";
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteriaByKhoaSo)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsKyTinhLuongByKhoaSo";
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterCriteria_Nam)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsKyTinhLuong_TheoNam";
                    cm.Parameters.AddWithValue("@Nam", ((FilterCriteria_Nam)criteria).nam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterKyChamNgoaiGioTungNgay)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_KyChamNgoaiGioTungNgay";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKyChamNgoaiGioTungNgay)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterKyChamNgoaiGioTungNgay)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaLoai", ((FilterKyChamNgoaiGioTungNgay)criteria).MaLoai);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterKyChamNgoaiGioTongHop)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_KyChamNgoaiGioTongHop";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKyChamNgoaiGioTongHop)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterKyChamNgoaiGioTongHop)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }
            if (criteria is FilterKyTinhPhuCap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_KyTinhPhuCap";
                    if (ERP_Library.Security.CurrentUser.IsAdminNhanSu)
                        cm.Parameters.AddWithValue("@UserID", 0);
                    else
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterKyTinhPhuCap)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(KyTinhLuong.GetKyTinhLuong(dr));
                    }
                }//using
            }

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
					foreach (KyTinhLuong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KyTinhLuong child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

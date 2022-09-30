
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ThueTamThuList : Csla.BusinessListBase<ThueTamThuList, ThueTamThu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThueTamThu item = ThueTamThu.NewThueTamThu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThueTamThuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThueTamThuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThueTamThuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThueTamThuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTamThuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThueTamThuList()
		{ /* require use of factory method */ }

		public static ThueTamThuList NewThueTamThuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTamThuList");
			return new ThueTamThuList();
		}

		public static ThueTamThuList GetThueTamThuListTheoNgay(int MaKyTinhLuong, int MaBoPhan,DateTime TuNgay,DateTime DenNgay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThueTamThuList");
			return DataPortal.Fetch<ThueTamThuList>(new FilterCriteria(MaKyTinhLuong,MaBoPhan,TuNgay,DenNgay));
		}
        public static ThueTamThuList GetThueTamThuReport(int MaKyTinhLuong, int MaBoPhan, DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTamThuList");
            return DataPortal.Fetch<ThueTamThuList>(new FilterReport(MaKyTinhLuong, MaBoPhan, TuNgay, DenNgay));
        }
        public static ThueTamThuList TinhThueTamThu(int MaKyTinhLuong, DateTime DenNgay, DateTime NgayTinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTamThuList");
            return DataPortal.Fetch<ThueTamThuList>(new FilterCriteria_TinhThueTamThu(MaKyTinhLuong, DenNgay, NgayTinh));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public DateTime TuNgay;
            public DateTime DenNgay;

			public FilterCriteria(int maKyTinhLuong,int maBoPhan,DateTime tuNgay,DateTime denNgay)
			{
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
			}
		}

        [Serializable()]
        private class FilterReport
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterReport(int maKyTinhLuong, int maBoPhan, DateTime tuNgay, DateTime denNgay)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        [Serializable()]
        private class FilterCriteria_TinhThueTamThu
        {
            public int MaKyTinhLuong=0;
            public DateTime NgayTinh, DenNgay;
            public FilterCriteria_TinhThueTamThu(int maKyTinhLuong, DateTime denNgay,DateTime ngayTinh)
            {
                DenNgay = denNgay;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.NgayTinh = ngayTinh;
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
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria_TinhThueTamThu)
                {
                    cm.CommandText = "spd_TinhThueTamThu";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria_TinhThueTamThu)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@NgayTinh", ((FilterCriteria_TinhThueTamThu)criteria).NgayTinh);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_TinhThueTamThu)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@LuongKy1", false);
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_GetThueTamThuTheoNgay";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterReport)
                {
                    cm.CommandText = "spd_Report_ThueTamThuTheoNgay";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterReport)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterReport)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterReport)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterReport)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                   
					while (dr.Read())
						this.Add(ThueTamThu.GetThueTamThu(dr));
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

				// loop through each deleted child object
				foreach (ThueTamThu deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (ThueTamThu child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
						child.Update(cn,this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

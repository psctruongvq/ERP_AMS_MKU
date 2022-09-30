using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NghiemThuThanhLyHopDongList : Csla.BusinessListBase<NghiemThuThanhLyHopDongList, NghiemThuThanhLyHopDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NghiemThuThanhLyHopDong item = NghiemThuThanhLyHopDong.NewNghiemThuThanhLyHopDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NghiemThuThanhLyHopDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NghiemThuThanhLyHopDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NghiemThuThanhLyHopDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NghiemThuThanhLyHopDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NghiemThuThanhLyHopDongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NghiemThuThanhLyHopDongList()
		{ /* require use of factory method */ }

		public static NghiemThuThanhLyHopDongList NewNghiemThuThanhLyHopDongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NghiemThuThanhLyHopDongList");
			return new NghiemThuThanhLyHopDongList();
		}

        public static NghiemThuThanhLyHopDongList GetNghiemThuThanhLyHopDongList(long maHopDong, int loai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NghiemThuThanhLyHopDongList");
			return DataPortal.Fetch<NghiemThuThanhLyHopDongList>(new FilterCriteria(maHopDong,loai));
		}

        public static NghiemThuThanhLyHopDongList GetNghiemThuThanhLyHopDongList(long maHopDong, DateTime tuNgay, DateTime denNgay,int loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NghiemThuThanhLyHopDongList");
            return DataPortal.Fetch<NghiemThuThanhLyHopDongList>(new FilterCriteriaTimTheoNgayKy(maHopDong,tuNgay,denNgay,loai));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaHopDong;
            public int Loai;

			public FilterCriteria(long maHopDong,int loai)
			{
				this.MaHopDong = maHopDong;
                this.Loai = loai;
			}
		}

        private class FilterCriteriaTimTheoNgayKy
        {
            public long MaHopDong;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int Loai;

            public FilterCriteriaTimTheoNgayKy(long maHopDong, DateTime tuNgay, DateTime denNgay,int loai)
            {
                this.MaHopDong = maHopDong;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.Loai = loai;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelectNghiemThuThanhLyListAll";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaHopDong", ((FilterCriteria)criteria).MaHopDong);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                }
                else if (criteria is FilterCriteriaTimTheoNgayKy)
                {
                    cm.CommandText = "spd_SelectNghiemThuThanhLyListAllByNgayKy";
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaHopDong", ((FilterCriteriaTimTheoNgayKy)criteria).MaHopDong);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaTimTheoNgayKy)criteria).Loai);
                    if (((FilterCriteriaTimTheoNgayKy)criteria).TuNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaTimTheoNgayKy)criteria).TuNgay);
                    else
                        cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                    if (((FilterCriteriaTimTheoNgayKy)criteria).DenNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaTimTheoNgayKy)criteria).DenNgay);
                    else
                        cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NghiemThuThanhLyHopDong.GetNghiemThuThanhLyHopDong(dr));
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
				foreach (NghiemThuThanhLyHopDong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (NghiemThuThanhLyHopDong child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoDongBaoHiemList : Csla.BusinessListBase<HoSoDongBaoHiemList, HoSoDongBaoHiem>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoSoDongBaoHiem item = HoSoDongBaoHiem.NewHoSoDongBaoHiem();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HoSoDongBaoHiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HoSoDongBaoHiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HoSoDongBaoHiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HoSoDongBaoHiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HoSoDongBaoHiemListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HoSoDongBaoHiemList()
		{ /* require use of factory method */ }

		public static HoSoDongBaoHiemList NewHoSoDongBaoHiemList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HoSoDongBaoHiemList");
			return new HoSoDongBaoHiemList();
		}

		public static HoSoDongBaoHiemList GetHoSoDongBaoHiemList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HoSoDongBaoHiemList");
			return DataPortal.Fetch<HoSoDongBaoHiemList>(new FilterCriteria(maNhanVien));
		}

        public static HoSoDongBaoHiemList GetHoSoDongBaoHiemList(int maChiNhanh, int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoSoDongBaoHiemList");
            return DataPortal.Fetch<HoSoDongBaoHiemList>(new FilterCriteria_TheoKy(maChiNhanh, maKy));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;

			public FilterCriteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}
        private class FilterCriteria_TheoKy
        {
            public int MaChiNhanh;
            public int MaKy;

            public FilterCriteria_TheoKy(int maChiNhanh, int maKy)
            {
                this.MaChiNhanh = maChiNhanh;
                this.MaKy = maKy;
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsHoSoDongBaoHiemsAll";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoSoDongBaoHiem.GetHoSoDongBaoHiem(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_TheoKy)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsHoSoDongBaoHiemsAll_TheoKy";
                    cm.Parameters.AddWithValue("@MaChiNhanh", ((FilterCriteria_TheoKy)criteria).MaChiNhanh);
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteria_TheoKy)criteria).MaKy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HoSoDongBaoHiem.GetHoSoDongBaoHiem(dr));
                    }
                }//using
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
				foreach (HoSoDongBaoHiem deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (HoSoDongBaoHiem child in this)
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

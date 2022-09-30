using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThangLuongList : Csla.BusinessListBase<ThangLuongList, ThangLuong>
	{



		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThangLuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThangLuongList()
		{ /* require use of factory method */ }

		public static ThangLuongList NewThangLuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThangLuongList");
			return new ThangLuongList();
		}

		public static ThangLuongList GetThangLuongList(int maChucVu, int maCongViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThangLuongList");
			return DataPortal.Fetch<ThangLuongList>(new FilterCriteria(maChucVu, maCongViec));
		}
        public static ThangLuongList GetThangLuongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThangLuongList");
            return DataPortal.Fetch<ThangLuongList>(new FilterCriteria());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChucVu;
			public int MaCongViec;

			public FilterCriteria(int maChucVu, int maCongViec)
			{
				this.MaChucVu = maChucVu;
				this.MaCongViec = maCongViec;
			}
            public FilterCriteria()
            {
                //this.MaChucVu = 0;
                //this.MaCongViec = 0;
            }
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsThangLuongsAll";
                //cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
                //cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ThangLuong.GetThangLuong(dr));
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
                    foreach (ThangLuong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ThangLuong child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn, this);
                        else
                            child.Update(cn, this);
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

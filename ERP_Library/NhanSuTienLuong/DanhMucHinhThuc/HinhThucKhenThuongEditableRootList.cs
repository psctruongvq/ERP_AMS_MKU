
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucKhenThuongList : Csla.BusinessListBase<HinhThucKhenThuongList, HinhThucKhenThuong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucKhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucKhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucKhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucKhenThuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucKhenThuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucKhenThuongList()
		{ /* require use of factory method */ }

		public static HinhThucKhenThuongList NewHinhThucKhenThuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucKhenThuongList");
			return new HinhThucKhenThuongList();
		}

		public static HinhThucKhenThuongList GetHinhThucKhenThuongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucKhenThuongList");
			return DataPortal.Fetch<HinhThucKhenThuongList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsHinhThucKhenThuongsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HinhThucKhenThuong.GetHinhThucKhenThuong(dr));
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
                try
                {
                    // loop through each deleted child object
                    foreach (HinhThucKhenThuong deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();
                    // loop through each non-deleted child object
                    foreach (HinhThucKhenThuong child in this)
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

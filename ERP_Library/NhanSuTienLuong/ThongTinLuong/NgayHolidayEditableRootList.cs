using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgayHolidayList : Csla.BusinessListBase<NgayHolidayList, NgayHoliday>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NgayHoliday item = NgayHoliday.NewNgayHoliday();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgayHolidayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgayHolidayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgayHolidayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgayHolidayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgayHolidayListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgayHolidayList()
		{ /* require use of factory method */ }

		public static NgayHolidayList NewNgayHolidayList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgayHolidayList");
			return new NgayHolidayList();
		}

		public static NgayHolidayList GetNgayHolidayList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgayHolidayList");
			return DataPortal.Fetch<NgayHolidayList>(new FilterCriteria());
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

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsNgayHolidaysAll";

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NgayHoliday.GetNgayHoliday(dr));
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
				foreach (NgayHoliday deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (NgayHoliday child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

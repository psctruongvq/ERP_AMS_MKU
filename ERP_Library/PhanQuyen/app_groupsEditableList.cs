using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class app_groupsList : Csla.BusinessListBase<app_groupsList, app_groups>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			app_groups item = app_groups.Newapp_groups();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in app_groupsList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in app_groupsList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in app_groupsList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in app_groupsList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("app_groupsListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private app_groupsList()
		{ /* require use of factory method */ }

		public static app_groupsList Newapp_groupsList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a app_groupsList");
			return new app_groupsList();
		}

		public static app_groupsList Getapp_groupsList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a app_groupsList");
			return DataPortal.Fetch<app_groupsList>(new FilterCriteria());
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
				cm.CommandText = "spd_SelecttblAppMenuGroup";
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(app_groups.Getapp_groups(dr));
				}
			}//dang su dung 
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
				foreach (app_groups deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (app_groups child in this)
				{
                    if (child.IsDirty)
                    {
                        child.Insert(cn);// insert phan quyen group
                                         // update all user thuoc group 

                        CapNhatQuyenUserTheoGroup(child.GroupID);
                    }

				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
        private void CapNhatQuyenUserTheoGroup(int GroupID)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_PhanQuyenUserTheoGroup";
                    cm.Parameters.AddWithValue("@GroupID", GroupID);
                    cm.ExecuteNonQuery();
                }
            }
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

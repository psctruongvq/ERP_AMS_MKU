
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LyDoThoiViecList : Csla.BusinessListBase<LyDoThoiViecList, LyDoThoiViec>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LyDoThoiViec item = LyDoThoiViec.NewLyDoThoiViec();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LyDoThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LyDoThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LyDoThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LyDoThoiViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LyDoThoiViecList()
		{ /* require use of factory method */ }

		public static LyDoThoiViecList NewLyDoThoiViecList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LyDoThoiViecList");
			return new LyDoThoiViecList();
		}

		public static LyDoThoiViecList GetLyDoThoiViecList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LyDoThoiViecList");
			return DataPortal.Fetch<LyDoThoiViecList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsLyDoThoiViecsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LyDoThoiViec.GetLyDoThoiViec(dr));
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
                    foreach (LyDoThoiViec deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LyDoThoiViec child in this)
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

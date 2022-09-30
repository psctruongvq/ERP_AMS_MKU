
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CapQuyetDinhList : Csla.BusinessListBase<CapQuyetDinhList, CapQuyetDinh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CapQuyetDinh item = CapQuyetDinh.NewCapQuyetDinh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CapQuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CapQuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CapQuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CapQuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CapQuyetDinhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CapQuyetDinhList()
		{ /* require use of factory method */ }

		public static CapQuyetDinhList NewCapQuyetDinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CapQuyetDinhList");
			return new CapQuyetDinhList();
		}

		public static CapQuyetDinhList GetCapQuyetDinhList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CapQuyetDinhList");
			return DataPortal.Fetch<CapQuyetDinhList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsCapQuyetDinhesAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CapQuyetDinh.GetCapQuyetDinh(dr));
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
                    foreach (CapQuyetDinh deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (CapQuyetDinh child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class MucDoHTCongViecList : Csla.BusinessListBase<MucDoHTCongViecList, MucDoHTCongViec>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			MucDoHTCongViec item = MucDoHTCongViec.NewMucDoHTCongViec();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MucDoHTCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MucDoHTCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MucDoHTCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MucDoHTCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucDoHTCongViecListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MucDoHTCongViecList()
		{ /* require use of factory method */ }

		public static MucDoHTCongViecList NewMucDoHTCongViecList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucDoHTCongViecList");
			return new MucDoHTCongViecList();
		}

		public static MucDoHTCongViecList GetMucDoHTCongViecList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MucDoHTCongViecList");
			return DataPortal.Fetch<MucDoHTCongViecList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsMucDoHTCongViecsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(MucDoHTCongViec.GetMucDoHTCongViec(dr));
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
                    foreach (MucDoHTCongViec deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (MucDoHTCongViec child in this)
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

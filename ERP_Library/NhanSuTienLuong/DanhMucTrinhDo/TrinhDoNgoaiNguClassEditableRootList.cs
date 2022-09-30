
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoNgoaiNguClassList : Csla.BusinessListBase<TrinhDoNgoaiNguClassList, TrinhDoNgoaiNguClass>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TrinhDoNgoaiNguClass item = TrinhDoNgoaiNguClass.NewTrinhDoNgoaiNguClass();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoNgoaiNguClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoNgoaiNguClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoNgoaiNguClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoNgoaiNguClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoNgoaiNguClassListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoNgoaiNguClassList()
		{ /* require use of factory method */ }

		public static TrinhDoNgoaiNguClassList NewTrinhDoNgoaiNguClassList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoNgoaiNguClassList");
			return new TrinhDoNgoaiNguClassList();
		}

		public static TrinhDoNgoaiNguClassList GetTrinhDoNgoaiNguClassList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoNgoaiNguClassList");
			return DataPortal.Fetch<TrinhDoNgoaiNguClassList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsTrinhDoNgoaiNgusAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TrinhDoNgoaiNguClass.GetTrinhDoNgoaiNguClass(dr));
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
                    foreach (TrinhDoNgoaiNguClass deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TrinhDoNgoaiNguClass child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgoaiNguList : Csla.BusinessListBase<NgoaiNguList, NgoaiNgu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NgoaiNgu item = NgoaiNgu.NewNgoaiNgu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgoaiNguList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgoaiNguList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgoaiNguList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgoaiNguList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgoaiNguList()
		{ /* require use of factory method */ }

		public static NgoaiNguList NewNgoaiNguList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgoaiNguList");
			return new NgoaiNguList();
		}

		public static NgoaiNguList GetNgoaiNguList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgoaiNguList");
			return DataPortal.Fetch<NgoaiNguList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsNgoaiNgusAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NgoaiNgu.GetNgoaiNgu(dr));
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
                    foreach (NgoaiNgu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NgoaiNgu child in this)
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

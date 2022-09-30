
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ToKhaiThueList : Csla.BusinessListBase<ToKhaiThueList, ToKhaiThue>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ToKhaiThue item = ToKhaiThue.NewToKhaiThue();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ToKhaiThueList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ToKhaiThueList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ToKhaiThueList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ToKhaiThueList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ToKhaiThueList()
		{ /* require use of factory method */ }

		public static ToKhaiThueList NewToKhaiThueList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToKhaiThueList");
			return new ToKhaiThueList();
		}

		public static ToKhaiThueList GetToKhaiThueList(long maHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ToKhaiThueList");
			return DataPortal.Fetch<ToKhaiThueList>(new FilterCriteria(maHopDong));
		}
		#endregion //Factory Methods

		#region Data Access
        
		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaHopDong;

			public FilterCriteria(long maHopDong)
			{
				this.MaHopDong = maHopDong;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblToKhaiThuesByMaHopDong";
                cm.Parameters.AddWithValue("@MaHoaDon", criteria.MaHopDong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ToKhaiThue.GetToKhaiThue(dr));
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

				tr = cn.BeginTransaction();
				try
				{
					// loop through each deleted child object
					foreach (ToKhaiThue deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ToKhaiThue child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

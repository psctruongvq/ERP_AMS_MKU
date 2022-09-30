
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhongBan_KHHMList : Csla.BusinessListBase<PhongBan_KHHMList, PhongBan_KHHM>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhongBan_KHHM item = PhongBan_KHHM.NewPhongBan_KHHM();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhongBan_KHHMList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhongBan_KHHMList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhongBan_KHHMList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhongBan_KHHMList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhongBan_KHHMListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhongBan_KHHMList()
		{ /* require use of factory method */ }

		public static PhongBan_KHHMList NewPhongBan_KHHMList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhongBan_KHHMList");
			return new PhongBan_KHHMList();
		}

		public static PhongBan_KHHMList GetPhongBan_KHHMList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhongBan_KHHMList");
			return DataPortal.Fetch<PhongBan_KHHMList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelectAll_PhongBan_KHHM";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhongBan_KHHM.GetPhongBan_KHHM(dr));
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
					foreach (PhongBan_KHHM deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhongBan_KHHM child in this)
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

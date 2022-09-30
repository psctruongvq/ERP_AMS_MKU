
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CacLoaiCongList : Csla.BusinessListBase<CacLoaiCongList, CacLoaiCong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CacLoaiCong item = CacLoaiCong.NewCacLoaiCong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CacLoaiCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CacLoaiCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CacLoaiCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CacLoaiCongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CacLoaiCongList()
		{ /* require use of factory method */ }

		public static CacLoaiCongList NewCacLoaiCongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CacLoaiCongList");
			return new CacLoaiCongList();
		}

		public static CacLoaiCongList GetCacLoaiCongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CacLoaiCongList");
			return DataPortal.Fetch<CacLoaiCongList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsCacLoaiCongsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CacLoaiCong.GetCacLoaiCong(dr));
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
				foreach (CacLoaiCong deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (CacLoaiCong child in this)
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

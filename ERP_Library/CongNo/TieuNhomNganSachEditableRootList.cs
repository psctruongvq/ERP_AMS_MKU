
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TieuNhomNganSachList : Csla.BusinessListBase<TieuNhomNganSachList, TieuNhomNganSach>
	{
		#region BindingList Overrides

        protected override object AddNewCore()
        {
            TieuNhomNganSach item = TieuNhomNganSach.NewTieuNhomNganSach();
            this.Add(item);
            return item;
        }
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TieuNhomNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TieuNhomNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TieuNhomNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TieuNhomNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TieuNhomNganSachList()
		{ /* require use of factory method */ }

		public static TieuNhomNganSachList NewTieuNhomNganSachList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuNhomNganSachList");
			return new TieuNhomNganSachList();
		}

		public static TieuNhomNganSachList GetTieuNhomNganSachList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TieuNhomNganSachList");
			return DataPortal.Fetch<TieuNhomNganSachList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblTieuNhomNganSachesAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TieuNhomNganSach.GetTieuNhomNganSach(dr));
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
				foreach (TieuNhomNganSach deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (TieuNhomNganSach child in this)
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

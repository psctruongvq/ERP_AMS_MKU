using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Default_NgayList : Csla.BusinessListBase<Default_NgayList, Default_Ngay>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			Default_Ngay item = Default_Ngay.NewDefault_Ngay();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Default_NgayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Default_NgayListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Default_NgayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Default_NgayListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Default_NgayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Default_NgayListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Default_NgayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Default_NgayListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Default_NgayList()
		{ /* require use of factory method */ }

		public static Default_NgayList NewDefault_NgayList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Default_NgayList");
			return new Default_NgayList();
		}

		public static Default_NgayList GetDefault_NgayList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Default_NgayList");
			return DataPortal.Fetch<Default_NgayList>(new FilterCriteria());
		}

        public static Default_NgayList GetDefault_NgayList_Modify()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a Default_NgayList");
            return DataPortal.Fetch<Default_NgayList>(new FilterCriteriaList());
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

        [Serializable()]
        private class FilterCriteriaList
        {

            public FilterCriteriaList()
            {

            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                    cm.CommandText = "spd_SelecttblnsDefault_NgaysAll";
                else
                {
                    cm.CommandText = "spd_SelecttblnsDefault_NgaysList";
                }



				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(Default_Ngay.GetDefault_Ngay(dr));
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
				foreach (Default_Ngay deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (Default_Ngay child in this)
				{
					if (child.IsNew)
						child.Insert(cn);
					else
						child.Update(cn);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

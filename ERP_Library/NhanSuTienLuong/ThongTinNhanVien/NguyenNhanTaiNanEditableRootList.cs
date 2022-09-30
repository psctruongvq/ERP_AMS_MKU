
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguyenNhanTaiNanList : Csla.BusinessListBase<NguyenNhanTaiNanList, NguyenNhanTaiNan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NguyenNhanTaiNan item = NguyenNhanTaiNan.NewNguyenNhanTaiNan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NguyenNhanTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NguyenNhanTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NguyenNhanTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NguyenNhanTaiNanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NguyenNhanTaiNanList()
		{ /* require use of factory method */ }

		public static NguyenNhanTaiNanList NewNguyenNhanTaiNanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NguyenNhanTaiNanList");
			return new NguyenNhanTaiNanList();
		}

		public static NguyenNhanTaiNanList GetNguyenNhanTaiNanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NguyenNhanTaiNanList");
			return DataPortal.Fetch<NguyenNhanTaiNanList>(new FilterCriteria());
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
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsNguyenNhanTaiNansAll";


                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(NguyenNhanTaiNan.GetNguyenNhanTaiNan(dr));
                    }
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    foreach (NguyenNhanTaiNan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NguyenNhanTaiNan child in this)
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

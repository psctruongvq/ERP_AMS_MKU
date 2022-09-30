
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCaoList : Csla.BusinessListBase<BaoCaoList, BaoCao>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BaoCaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCaoList()
		{ /* require use of factory method */ }

		public static BaoCaoList NewBaoCaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCaoList");
			return new BaoCaoList();
		}

		public static BaoCaoList GetBaoCaoList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCaoList");
			return DataPortal.Fetch<BaoCaoList>(new FilterCriteria());
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
                cm.CommandText = "sps_SelecttblcnBaoCao";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BaoCao.GetBaoCao(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


        //#region Data Access - Update
        //protected override void DataPortal_Update()
        //{
        //    RaiseListChangedEvents = false;

        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        // loop through each deleted child object
        //        foreach (BaoCao deletedChild in DeletedList)
        //            deletedChild.DeleteSelf(cn);
        //        DeletedList.Clear();

        //        // loop through each non-deleted child object
        //        foreach (BaoCao child in this)
        //        {
        //            if (child.IsNew)
        //                child.Insert(cn,this);
        //            else
        //                child.Update(cn, this);
        //        }
        //    }//using SqlConnection

        //    RaiseListChangedEvents = true;
        //}
        //#endregion //Data Access - Update
		#endregion //Data Access
	}
}

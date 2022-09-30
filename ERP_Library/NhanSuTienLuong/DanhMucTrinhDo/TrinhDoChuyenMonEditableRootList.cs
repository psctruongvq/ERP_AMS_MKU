
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoChuyenMonList : Csla.BusinessListBase<TrinhDoChuyenMonList, TrinhDoChuyenMon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TrinhDoChuyenMon item = TrinhDoChuyenMon.NewTrinhDoChuyenMon();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoChuyenMonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoChuyenMonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoChuyenMonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoChuyenMonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoChuyenMonListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoChuyenMonList()
		{ /* require use of factory method */ }

		public static TrinhDoChuyenMonList NewTrinhDoChuyenMonList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoChuyenMonList");
			return new TrinhDoChuyenMonList();
		}

		public static TrinhDoChuyenMonList GetTrinhDoChuyenMonList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoChuyenMonList");
			return DataPortal.Fetch<TrinhDoChuyenMonList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsTrinhDoChuyenMonsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TrinhDoChuyenMon.GetTrinhDoChuyenMon(dr));
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
                //tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (TrinhDoChuyenMon deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TrinhDoChuyenMon child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn);
                        else
                            child.Update(cn);
                    }
                  //  tr.Commit();
                }
                catch (SqlException ex)
                {
                 //   tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

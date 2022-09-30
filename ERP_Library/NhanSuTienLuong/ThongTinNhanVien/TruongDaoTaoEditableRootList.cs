
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TruongDaoTaoList : Csla.BusinessListBase<TruongDaoTaoList, TruongDaoTao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TruongDaoTao item = TruongDaoTao.NewTruongDaoTao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TruongDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TruongDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TruongDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TruongDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TruongDaoTaoList()
		{ /* require use of factory method */ }

		public static TruongDaoTaoList NewTruongDaoTaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TruongDaoTaoList");
			return new TruongDaoTaoList();
		}

		public static TruongDaoTaoList GetTruongDaoTaoList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TruongDaoTaoList");
			return DataPortal.Fetch<TruongDaoTaoList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsTruongDaoTaosAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TruongDaoTao.GetTruongDaoTao(dr));
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
                    foreach (TruongDaoTao deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (TruongDaoTao child in this)
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

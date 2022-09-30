
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyKetChuyenSoDuCCDCList : Csla.BusinessListBase<KyKetChuyenSoDuCCDCList, KyKetChuyenSoDuCCDC>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KyKetChuyenSoDuCCDC item = KyKetChuyenSoDuCCDC.NewKyKetChuyenSoDuCCDC();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyKetChuyenSoDuCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenSoDuCCDCListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyKetChuyenSoDuCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenSoDuCCDCListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyKetChuyenSoDuCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenSoDuCCDCListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyKetChuyenSoDuCCDCList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenSoDuCCDCListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyKetChuyenSoDuCCDCList()
		{ /* require use of factory method */ }

		public static KyKetChuyenSoDuCCDCList NewKyKetChuyenSoDuCCDCList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyKetChuyenSoDuCCDCList");
			return new KyKetChuyenSoDuCCDCList();
		}

		public static KyKetChuyenSoDuCCDCList GetKyKetChuyenSoDuCCDCList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyKetChuyenSoDuCCDCList");
			return DataPortal.Fetch<KyKetChuyenSoDuCCDCList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblKyKetChuyenSoDuCCDCsAll";//\\


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KyKetChuyenSoDuCCDC.GetKyKetChuyenSoDuCCDC(dr));
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
					foreach (KyKetChuyenSoDuCCDC deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KyKetChuyenSoDuCCDC child in this)
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

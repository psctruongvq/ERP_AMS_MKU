
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyKetChuyenCongCuDungCuList : Csla.BusinessListBase<KyKetChuyenCongCuDungCuList, KyKetChuyenCongCuDungCu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KyKetChuyenCongCuDungCu item = KyKetChuyenCongCuDungCu.NewKyKetChuyenCongCuDungCu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyKetChuyenCongCuDungCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenCongCuDungCuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyKetChuyenCongCuDungCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenCongCuDungCuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyKetChuyenCongCuDungCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenCongCuDungCuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyKetChuyenCongCuDungCuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenCongCuDungCuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyKetChuyenCongCuDungCuList()
		{ /* require use of factory method */ }

		public static KyKetChuyenCongCuDungCuList NewKyKetChuyenCongCuDungCuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyKetChuyenCongCuDungCuList");
			return new KyKetChuyenCongCuDungCuList();
		}

		public static KyKetChuyenCongCuDungCuList GetKyKetChuyenCongCuDungCuList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyKetChuyenCongCuDungCuList");
			return DataPortal.Fetch<KyKetChuyenCongCuDungCuList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblKyKetChuyenCongCuDungCusAll";//\\


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KyKetChuyenCongCuDungCu.GetKyKetChuyenCongCuDungCu(dr));
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
					foreach (KyKetChuyenCongCuDungCu deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KyKetChuyenCongCuDungCu child in this)
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

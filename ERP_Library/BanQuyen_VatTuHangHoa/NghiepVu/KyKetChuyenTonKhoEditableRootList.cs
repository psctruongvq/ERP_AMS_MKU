
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyKetChuyenTonKhoList : Csla.BusinessListBase<KyKetChuyenTonKhoList, KyKetChuyenTonKho>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			KyKetChuyenTonKho item = KyKetChuyenTonKho.NewKyKetChuyenTonKho();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyKetChuyenTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyKetChuyenTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyKetChuyenTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyKetChuyenTonKhoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyKetChuyenTonKhoList()
		{ /* require use of factory method */ }

		public static KyKetChuyenTonKhoList NewKyKetChuyenTonKhoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyKetChuyenTonKhoList");
			return new KyKetChuyenTonKhoList();
		}

		public static KyKetChuyenTonKhoList GetKyKetChuyenTonKhoList(int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyKetChuyenTonKhoList");
			return DataPortal.Fetch<KyKetChuyenTonKhoList>(new FilterCriteria(maKy));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaKy;

			public FilterCriteria(int maKy)
			{
				this.MaKy = maKy;
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
                cm.CommandText = "spd_SelecttblKyKetChuyenTonKhosByAndMaKy";
				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(KyKetChuyenTonKho.GetKyKetChuyenTonKho(dr));
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
					foreach (KyKetChuyenTonKho deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (KyKetChuyenTonKho child in this)
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

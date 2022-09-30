
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HopDongChoVayList : Csla.BusinessListBase<HopDongChoVayList, HopDongChoVay>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HopDongChoVay item = HopDongChoVay.NewHopDongChoVay();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HopDongChoVayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HopDongChoVayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HopDongChoVayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HopDongChoVayList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongChoVayListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HopDongChoVayList()
		{ /* require use of factory method */ }

		public static HopDongChoVayList NewHopDongChoVayList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDongChoVayList");
			return new HopDongChoVayList();
		}

		public static HopDongChoVayList GetHopDongChoVayList(int maDonViKyHanTT, int maDonViKyTinhLai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HopDongChoVayList");
			return DataPortal.Fetch<HopDongChoVayList>(new FilterCriteria(maDonViKyHanTT, maDonViKyTinhLai));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaDonViKyHanTT;
			public int MaDonViKyTinhLai;

			public FilterCriteria(int maDonViKyHanTT, int maDonViKyTinhLai)
			{
				this.MaDonViKyHanTT = maDonViKyHanTT;
				this.MaDonViKyTinhLai = maDonViKyTinhLai;
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
				cm.CommandText = "GetHopDongChoVayList";
				cm.Parameters.AddWithValue("@MaDonViKyHanTT", criteria.MaDonViKyHanTT);
				cm.Parameters.AddWithValue("@MaDonViKyTinhLai", criteria.MaDonViKyTinhLai);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HopDongChoVay.GetHopDongChoVay(dr));
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
					foreach (HopDongChoVay deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (HopDongChoVay child in this)
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

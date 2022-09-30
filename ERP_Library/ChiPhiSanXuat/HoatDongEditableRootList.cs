
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDongList : Csla.BusinessListBase<HoatDongList, HoatDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoatDong item = HoatDong.NewHoatDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private HoatDongList()
		{ /* require use of factory method */ }

		public static HoatDongList NewHoatDongList()
		{
			return new HoatDongList();
		}

		public static HoatDongList GetHoatDongList()
		{
			return DataPortal.Fetch<HoatDongList>(new FilterCriteria());
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
				cm.CommandText = "SelecttblHoatDongsAll";
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HoatDong.GetHoatDong(dr));
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
					foreach (HoatDong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (HoatDong child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
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

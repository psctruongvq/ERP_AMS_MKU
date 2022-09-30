
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiChiPhiSanXuatChuongTrinhList : Csla.BusinessListBase<LoaiChiPhiSanXuatChuongTrinhList, LoaiChiPhiSanXuatChuongTrinh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LoaiChiPhiSanXuatChuongTrinh item = LoaiChiPhiSanXuatChuongTrinh.NewLoaiChiPhiSanXuatChuongTrinh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private LoaiChiPhiSanXuatChuongTrinhList()
		{ /* require use of factory method */ }

		public static LoaiChiPhiSanXuatChuongTrinhList NewLoaiChiPhiSanXuatChuongTrinhList()
		{
			return new LoaiChiPhiSanXuatChuongTrinhList();
		}

		public static LoaiChiPhiSanXuatChuongTrinhList GetLoaiChiPhiSanXuatChuongTrinhList()
		{
			return DataPortal.Fetch<LoaiChiPhiSanXuatChuongTrinhList>(new FilterCriteria());
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
                cm.CommandText = "SelecttblLoaiChiPhiSanXuatChuongTrinhesAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiChiPhiSanXuatChuongTrinh.GetLoaiChiPhiSanXuatChuongTrinh(dr));
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
					foreach (LoaiChiPhiSanXuatChuongTrinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiChiPhiSanXuatChuongTrinh child in this)
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

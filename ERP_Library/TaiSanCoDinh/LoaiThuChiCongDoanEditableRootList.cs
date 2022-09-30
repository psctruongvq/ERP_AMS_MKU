
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiThuChiCongDoanList : Csla.BusinessListBase<LoaiThuChiCongDoanList, LoaiThuChiCongDoan>
	{

		#region Factory Methods
		private LoaiThuChiCongDoanList()
		{ /* require use of factory method */ }

		public static LoaiThuChiCongDoanList NewLoaiThuChiCongDoanList()
		{
			return new LoaiThuChiCongDoanList();
		}

		public static LoaiThuChiCongDoanList GetLoaiThuChiCongDoanList()
		{
			return DataPortal.Fetch<LoaiThuChiCongDoanList>(new FilterCriteria());
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
				cm.CommandText = "SelecttblLoaiThuChiCongDoansAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiThuChiCongDoan.GetLoaiThuChiCongDoan(dr));
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
					foreach (LoaiThuChiCongDoan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiThuChiCongDoan child in this)
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

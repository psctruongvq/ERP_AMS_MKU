
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuImportList : Csla.BusinessListBase<ChungTuImportList, ChungTuImport>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTuImport item = ChungTuImport.NewChungTuImport();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ChungTuImportList()
		{ /* require use of factory method */ }

		public static ChungTuImportList NewChungTuImportList()
		{
			return new ChungTuImportList();
		}

		public static ChungTuImportList GetChungTuImportList(int maLoaiChungTu, int maDoiTuongThuChi)
		{
			return DataPortal.Fetch<ChungTuImportList>(new FilterCriteria(maLoaiChungTu, maDoiTuongThuChi));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaLoaiChungTu;
			public int MaDoiTuongThuChi;

			public FilterCriteria(int maLoaiChungTu, int maDoiTuongThuChi)
			{
				this.MaLoaiChungTu = maLoaiChungTu;
				this.MaDoiTuongThuChi = maDoiTuongThuChi;
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
				cm.CommandText = "SelecttblChungTuImportsAll";
				cm.Parameters.AddWithValue("@MaLoaiChungTu", criteria.MaLoaiChungTu);
				cm.Parameters.AddWithValue("@MaDoiTuongThuChi", criteria.MaDoiTuongThuChi);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTuImport.GetChungTuImport(dr));
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
					foreach (ChungTuImport deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ChungTuImport child in this)
					{
						if (child.IsNew)
                            child.Insert(tr, this);
						else
                            child.Update(tr, this);
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

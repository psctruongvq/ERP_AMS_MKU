
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanImportList : Csla.BusinessListBase<ButToanImportList, ButToanImport>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ButToanImport item = ButToanImport.NewButToanImport();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ButToanImportList()
		{ /* require use of factory method */ }

		public static ButToanImportList NewButToanImportList()
		{
			return new ButToanImportList();
		}

		public static ButToanImportList GetButToanImportList(long maChungTu)
		{
			return DataPortal.Fetch<ButToanImportList>(new FilterCriteria(maChungTu));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaChungTu;

			public FilterCriteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
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
				cm.CommandText = "SelecttblButToanImportsAll";
				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ButToanImport.GetButToanImport(dr));
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
					foreach (ButToanImport deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ButToanImport child in this)
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

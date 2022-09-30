
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToan_MucNganSachImportList : Csla.BusinessListBase<ButToan_MucNganSachImportList, ButToan_MucNganSachImport>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ButToan_MucNganSachImport item = ButToan_MucNganSachImport.NewButToan_MucNganSachImport();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ButToan_MucNganSachImportList()
		{ /* require use of factory method */ }

		public static ButToan_MucNganSachImportList NewButToan_MucNganSachImportList()
		{
			return new ButToan_MucNganSachImportList();
		}

		public static ButToan_MucNganSachImportList GetButToan_MucNganSachImportList(int maButToan)
		{
			return DataPortal.Fetch<ButToan_MucNganSachImportList>(new FilterCriteria(maButToan));
		}
        public static ButToan_MucNganSachImportList GetButToan_MucNganSachImportListByKetChuyen()
        {
            return DataPortal.Fetch<ButToan_MucNganSachImportList>(new FilterCriteriaByKetChuyen());
        } 
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaButToan;

			public FilterCriteria(int maButToan)
			{
				this.MaButToan = maButToan;
			}
		}

        private class FilterCriteriaByKetChuyen
        {

            public FilterCriteriaByKetChuyen()
            {
            }
        }

		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SelecttblButToan_MucNganSachImportsAll";
                    cm.Parameters.AddWithValue("@MaButToan", ((FilterCriteria)criteria).MaButToan);
                }

                if (criteria is FilterCriteriaByKetChuyen)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblButToan_MucNganSachImportsByKetChuyen";
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ButToan_MucNganSachImport.GetButToan_MucNganSachImport(dr));
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
					foreach (ButToan_MucNganSachImport deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ButToan_MucNganSachImport child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
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

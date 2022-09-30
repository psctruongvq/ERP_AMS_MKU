
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongDoan_ButToanMucNganSachList : Csla.BusinessListBase<CongDoan_ButToanMucNganSachList, CongDoan_ButToanMucNganSach>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongDoan_ButToanMucNganSach item = CongDoan_ButToanMucNganSach.NewCongDoan_ButToanMucNganSach();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private CongDoan_ButToanMucNganSachList()
		{ /* require use of factory method */ }

		public static CongDoan_ButToanMucNganSachList NewCongDoan_ButToanMucNganSachList()
		{
			return new CongDoan_ButToanMucNganSachList();
		}

		public static CongDoan_ButToanMucNganSachList GetCongDoan_ButToanMucNganSachList(int maButToan)
		{
			return DataPortal.Fetch<CongDoan_ButToanMucNganSachList>(new FilterCriteria(maButToan));
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
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "SelecttblCongDoan_ButToanMucNganSachesAll";
                    cm.Parameters.AddWithValue("@MaButToan",((FilterCriteria)criteria).MaButToan);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CongDoan_ButToanMucNganSach.GetCongDoan_ButToanMucNganSach(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        internal void Update(SqlTransaction tr, CongDoan_ButToan parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                // loop through each deleted child object
                foreach (CongDoan_ButToanMucNganSach deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CongDoan_ButToanMucNganSach child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }

            catch (Exception ex)
            {
              //  tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
		
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

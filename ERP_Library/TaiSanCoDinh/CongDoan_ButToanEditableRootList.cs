
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongDoan_ButToanList : Csla.BusinessListBase<CongDoan_ButToanList, CongDoan_ButToan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongDoan_ButToan item = CongDoan_ButToan.NewCongDoan_ButToan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private CongDoan_ButToanList()
		{ /* require use of factory method */ }

		public static CongDoan_ButToanList NewCongDoan_ButToanList()
		{
			return new CongDoan_ButToanList();
		}

		public static CongDoan_ButToanList GetCongDoan_ButToanList(int maChungTu)
		{
			return DataPortal.Fetch<CongDoan_ButToanList>(new FilterCriteria(maChungTu));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChungTu;

			public FilterCriteria(int maChungTu)
			{
				this.MaChungTu = maChungTu;
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
					//tr.Rollback();
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
                    cm.CommandText = "SelecttblCongDoan_ButToanByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu",((FilterCriteria)criteria).MaChungTu);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CongDoan_ButToan.GetCongDoan_ButToan(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        
        internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
        {
            RaiseListChangedEvents = false;
            try
            {

                // loop through each deleted child object
                foreach (CongDoan_ButToan deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();                
                foreach (CongDoan_ButToan child in this)
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

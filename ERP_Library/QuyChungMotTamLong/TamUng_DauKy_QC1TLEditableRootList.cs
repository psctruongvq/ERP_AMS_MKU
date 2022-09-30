
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()]
    public class TamUng_DauKy_QC1TLList : Csla.BusinessListBase<TamUng_DauKy_QC1TLList, TamUng_DauKy_QC1TL>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
            TamUng_DauKy_QC1TL item = TamUng_DauKy_QC1TL.NewTamUng_DauKy_QC1TL();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private TamUng_DauKy_QC1TLList()
		{ /* require use of factory method */ }

        public static TamUng_DauKy_QC1TLList NewTamUng_DauKy_QC1TLList()
		{
			return new TamUng_DauKy_QC1TLList();
		}

        public static TamUng_DauKy_QC1TLList GetTamUng_DauKy_QC1TLList(int Nam)
		{
			return DataPortal.Fetch<TamUng_DauKy_QC1TLList>(new FilterCriteria(Nam));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int Nam;
			public FilterCriteria(int nam)
			{
                this.Nam = nam;
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
                cm.CommandText = "spd_SelecttblTamUng_SoDuDauKy_QC1TLAll";
                cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
                        this.Add(TamUng_DauKy_QC1TL.GetTamUng_DauKy_QC1TL(dr));
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
                    foreach (TamUng_DauKy_QC1TL deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
                    foreach (TamUng_DauKy_QC1TL child in this)
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

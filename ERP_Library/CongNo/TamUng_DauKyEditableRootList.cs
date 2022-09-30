
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUng_DauKyList : Csla.BusinessListBase<TamUng_DauKyList, TamUng_DauKy>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TamUng_DauKy item = TamUng_DauKy.NewTamUng_DauKy();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private TamUng_DauKyList()
		{ /* require use of factory method */ }

		public static TamUng_DauKyList NewTamUng_DauKyList()
		{
			return new TamUng_DauKyList();
		}

		public static TamUng_DauKyList GetTamUng_DauKyList(int Nam)
		{
			return DataPortal.Fetch<TamUng_DauKyList>(new FilterCriteria(Nam));
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
                cm.CommandText = "SelecttblTamUng_SoDuDauKiesAll";
                cm.Parameters.AddWithValue("@MaBoPhan", Security.CurrentUser.Info.MaBoPhan);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TamUng_DauKy.GetTamUng_DauKy(dr));
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
					foreach (TamUng_DauKy deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TamUng_DauKy child in this)
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

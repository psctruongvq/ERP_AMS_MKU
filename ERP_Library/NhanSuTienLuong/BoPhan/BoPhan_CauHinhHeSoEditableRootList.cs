
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhan_CauHinhHeSoList : Csla.BusinessListBase<BoPhan_CauHinhHeSoList, BoPhan_CauHinhHeSo>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BoPhan_CauHinhHeSo item = BoPhan_CauHinhHeSo.NewBoPhan_CauHinhHeSo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private BoPhan_CauHinhHeSoList()
		{ /* require use of factory method */ }

		public static BoPhan_CauHinhHeSoList NewBoPhan_CauHinhHeSoList()
		{
			return new BoPhan_CauHinhHeSoList();
		}

		public static BoPhan_CauHinhHeSoList GetBoPhan_CauHinhHeSoList()
		{
			return DataPortal.Fetch<BoPhan_CauHinhHeSoList>(new FilterCriteria());
		}
        public static BoPhan_CauHinhHeSoList GetBoPhan_CauHinhHeSoList(int maBoPhan)
        {
            return DataPortal.Fetch<BoPhan_CauHinhHeSoList>(new FilterCriteriaBoPhan(maBoPhan));
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
        private class FilterCriteriaBoPhan
        {
            public int MaBoPhan;
            public FilterCriteriaBoPhan(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
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
                    cm.CommandText = "SelecttblnsBoPhan_CauHinhHSsAll";
                }
                else if (criteria is FilterCriteriaBoPhan)
                {
                    cm.CommandText = "SelecttblnsBoPhan_CauHinhBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaBoPhan)criteria).MaBoPhan);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BoPhan_CauHinhHeSo.GetBoPhan_CauHinhHeSo(dr));
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
					foreach (BoPhan_CauHinhHeSo deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoPhan_CauHinhHeSo child in this)
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

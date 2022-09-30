
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTacNuocNgoaiList : Csla.BusinessListBase<CongTacNuocNgoaiList, CongTacNuocNgoai>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongTacNuocNgoai item = CongTacNuocNgoai.NewCongTacNuocNgoai();
           
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private CongTacNuocNgoaiList()
		{ /* require use of factory method */ }

		public static CongTacNuocNgoaiList NewCongTacNuocNgoaiList()
		{
			return new CongTacNuocNgoaiList();
		}

		public static CongTacNuocNgoaiList GetCongTacNuocNgoaiList(DateTime tuNgay,DateTime denNgay)
		{
			return DataPortal.Fetch<CongTacNuocNgoaiList>(new FilterCriteria(tuNgay,denNgay));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public DateTime TuNgay;
            public DateTime DenNgay;
			public FilterCriteria(DateTime tuNgay,DateTime denNgay)
			{
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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
                    cm.CommandText = "SelecttblnsQuaTrinhCongTacNuocNgoaisAll";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CongTacNuocNgoai.GetCongTacNuocNgoai(dr));
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
					foreach (CongTacNuocNgoai deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (CongTacNuocNgoai child in this)
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

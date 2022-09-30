
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TaiKhoan_NguonList : Csla.BusinessListBase<TaiKhoan_NguonList, TaiKhoan_Nguon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TaiKhoan_Nguon item = TaiKhoan_Nguon.NewTaiKhoan_Nguon();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private TaiKhoan_NguonList()
		{ /* require use of factory method */ }

		public static TaiKhoan_NguonList NewTaiKhoan_NguonList()
		{
			return new TaiKhoan_NguonList();
		}
        public static TaiKhoan_NguonList GetTaiKhoan_NguonList()
        {
            return DataPortal.Fetch<TaiKhoan_NguonList>(new FilterCriteriaAll());
        }
		public static TaiKhoan_NguonList GetTaiKhoan_NguonList(int maNguon, int maTaiKhoan)
		{
			return DataPortal.Fetch<TaiKhoan_NguonList>(new FilterCriteria(maNguon, maTaiKhoan));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class FilterCriteriaAll
        {
         

            public FilterCriteriaAll()
            {
               
            }
        }
		private class FilterCriteria
		{
			public int MaNguon;
			public int MaTaiKhoan;

			public FilterCriteria(int maNguon, int maTaiKhoan)
			{
				this.MaNguon = maNguon;
				this.MaTaiKhoan = maTaiKhoan;
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
                    cm.CommandText = "SelecttblTaiKhoan_NguonsAll";
                    cm.Parameters.AddWithValue("@MaNguon",((FilterCriteria) criteria).MaNguon);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteria)criteria).MaTaiKhoan);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "SelecttblTaiKhoan_NguonsAll";
                    cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TaiKhoan_Nguon.GetTaiKhoan_Nguon(dr));
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
					foreach (TaiKhoan_Nguon deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TaiKhoan_Nguon child in this)
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

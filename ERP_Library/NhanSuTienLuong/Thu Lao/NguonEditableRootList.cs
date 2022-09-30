
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguonList : Csla.BusinessListBase<NguonList, Nguon>
	{
		#region BindingList Overrides
        protected override object AddNewCore()
        {
            Nguon item = Nguon.NewNguon();
            this.Add(item);
            return item;
        }
		#endregion //BindingList Overrides

		#region Factory Methods
		private NguonList()
		{ /* require use of factory method */ }

		public static NguonList NewNguonList()
		{
			return new NguonList();
		}

		public static NguonList GetNguonList()
		{
			return DataPortal.Fetch<NguonList>(new FilterCriteria());
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
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_SelecttblNguonsAll";
                cm.Parameters.AddWithValue("@MacongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(Nguon.GetNguon(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (Nguon deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (Nguon child in this)
				{
					if (child.IsNew)
						child.Insert(cn,this);
					else
						child.Update(cn,this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

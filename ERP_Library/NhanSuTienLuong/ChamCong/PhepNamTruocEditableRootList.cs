
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhepNamTruocList : Csla.BusinessListBase<PhepNamTruocList, PhepNamTruoc>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhepNamTruoc item = PhepNamTruoc.NewPhepNamTruoc();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private PhepNamTruocList()
		{ /* require use of factory method */ }

		public static PhepNamTruocList NewPhepNamTruocList()
		{
			return new PhepNamTruocList();
		}

		public static PhepNamTruocList GetPhepNamTruocList(int Nam, int MaBoPhan)
		{
			return DataPortal.Fetch<PhepNamTruocList>(new FilterCriteria(Nam, MaBoPhan));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int Nam;
            public int BoPhan;
			public FilterCriteria(int nam, int bophan)
			{
                this.Nam = nam;
                this.BoPhan = bophan;
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
                cm.CommandText = "[spd_SelecttblPhepNamTruocsAll]";
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.BoPhan);
    
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhepNamTruoc.GetPhepNamTruoc(dr));
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
				foreach (PhepNamTruoc deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (PhepNamTruoc child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuongThucThanhToanList : Csla.BusinessListBase<PhuongThucThanhToanList, PhuongThucThanhToan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhuongThucThanhToan item = PhuongThucThanhToan.NewPhuongThucThanhToan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuongThucThanhToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuongThucThanhToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuongThucThanhToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuongThucThanhToanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucThanhToanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public PhuongThucThanhToanList()
		{ /* require use of factory method */ }

		public static PhuongThucThanhToanList NewPhuongThucThanhToanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucThanhToanList");
			return new PhuongThucThanhToanList();
		}

		public static PhuongThucThanhToanList GetPhuongThucThanhToanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuongThucThanhToanList");
			return DataPortal.Fetch<PhuongThucThanhToanList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblPhuongThucThanhToansAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhuongThucThanhToan.GetPhuongThucThanhToan(dr));
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
					foreach (PhuongThucThanhToan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhuongThucThanhToan child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(SqlException ex)
				{
					tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuongThucGiaoNhanList : Csla.BusinessListBase<PhuongThucGiaoNhanList, PhuongThucGiaoNhan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhuongThucGiaoNhan item = PhuongThucGiaoNhan.NewPhuongThucGiaoNhan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuongThucGiaoNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuongThucGiaoNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuongThucGiaoNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuongThucGiaoNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhuongThucGiaoNhanList()
		{ /* require use of factory method */ }

		public static PhuongThucGiaoNhanList NewPhuongThucGiaoNhanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucGiaoNhanList");
			return new PhuongThucGiaoNhanList();
		}

		public static PhuongThucGiaoNhanList GetPhuongThucGiaoNhanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuongThucGiaoNhanList");
			return DataPortal.Fetch<PhuongThucGiaoNhanList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblPhuongThucGiaoNhansAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhuongThucGiaoNhan.GetPhuongThucGiaoNhan(dr));
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
					foreach (PhuongThucGiaoNhan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhuongThucGiaoNhan child in this)
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
		#endregion 
	}
}

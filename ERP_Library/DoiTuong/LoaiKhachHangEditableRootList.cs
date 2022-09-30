
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiKhachHangList : Csla.BusinessListBase<LoaiKhachHangList, LoaiKhachHang>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LoaiKhachHang item = LoaiKhachHang.NewLoaiKhachHang();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiKhachHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiKhachHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiKhachHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiKhachHangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiKhachHangList()
		{ /* require use of factory method */ }

		public static LoaiKhachHangList NewLoaiKhachHangList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiKhachHangList");
			return new LoaiKhachHangList();
		}

		public static LoaiKhachHangList GetLoaiKhachHangList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiKhachHangList");
			return DataPortal.Fetch<LoaiKhachHangList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblLoaiKhachHangsAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiKhachHang.GetLoaiKhachHang(dr));
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
					foreach (LoaiKhachHang deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiKhachHang child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
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

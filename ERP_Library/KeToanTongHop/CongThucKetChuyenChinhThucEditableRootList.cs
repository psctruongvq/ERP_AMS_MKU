using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongThucKetChuyenChinhThucList : Csla.BusinessListBase<CongThucKetChuyenChinhThucList, CongThucKetChuyenChinhThuc>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongThucKetChuyenChinhThuc item = CongThucKetChuyenChinhThuc.NewCongThucKetChuyenChinhThuc();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongThucKetChuyenChinhThucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongThucKetChuyenChinhThucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongThucKetChuyenChinhThucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongThucKetChuyenChinhThucList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CongThucKetChuyenChinhThucList()
        { /* require use of factory method */  }

		public static CongThucKetChuyenChinhThucList NewCongThucKetChuyenChinhThucList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThucKetChuyenChinhThucList");
			return new CongThucKetChuyenChinhThucList();
		}

		public static CongThucKetChuyenChinhThucList GetCongThucKetChuyenChinhThucList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongThucKetChuyenChinhThucList");
			return DataPortal.Fetch<CongThucKetChuyenChinhThucList>(new FilterCriteria());
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]

        private class FilterCriteria
        {

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
                cm.CommandText = "spd_SelecttblCongThucKetChuyenChinhThucsAll";

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(CongThucKetChuyenChinhThuc.GetCongThucKetChuyenChinhThuc(dr));
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
					foreach (CongThucKetChuyenChinhThuc deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (CongThucKetChuyenChinhThuc child in this)
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

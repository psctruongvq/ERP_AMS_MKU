
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HeSoList : Csla.BusinessListBase<HeSoList, HeSo>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HeSoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HeSoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HeSoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HeSoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HeSoList()
		{ /* require use of factory method */ }

		public static HeSoList NewHeSoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HeSoList");
			return new HeSoList();
		}

		public static HeSoList GetHeSoList(int maKyTinhLuong, int  maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HeSoList");
            return DataPortal.Fetch<HeSoList>(new FilterCriteria(maKyTinhLuong, maBoPhan));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaKyTinhLuong;
            public int MaBoPhan;

			public FilterCriteria(int maKyTinhLuong, int maBoPhan)
			{
				this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
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
                cm.CommandText = "spd_SelecttblnsHeSoByKyTinhAndBoPhan";
				cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(HeSo.GetHeSo(dr));
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
					foreach (HeSo deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (HeSo child in this)
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

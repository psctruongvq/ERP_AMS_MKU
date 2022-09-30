
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 


	[Serializable()] 
	public class LoaiCongViecList : Csla.BusinessListBase<LoaiCongViecList, LoaiCongViec>
	{
        protected override object AddNewCore()
        {
            LoaiCongViec item = LoaiCongViec.NewLoaiCongViec(0);

            this.Add(item);
            return item;
        }
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiCongViecList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiCongViecList()
		{ /* require use of factory method */ }

		public static LoaiCongViecList NewLoaiCongViecList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiCongViecList");
			return new LoaiCongViecList();
		}

		public static LoaiCongViecList GetLoaiCongViecListAll()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiCongViecList");
			return DataPortal.Fetch<LoaiCongViecList>(new FilterCriteria());
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			//public int MaLoaiLuong;

			public FilterCriteria()
			{
				//this.MaLoaiLuong = maLoaiLuong;
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
                cm.CommandText = "sp_SelecttblnsLoaiCongViecsAll";
				//cm.Parameters.AddWithValue("@MaLoaiLuong", criteria.MaLoaiLuong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiCongViec.GetLoaiCongViec(dr));
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
					foreach (LoaiCongViec deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiCongViec child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinTuyenDungList : Csla.BusinessListBase<ThongTinTuyenDungList, ThongTinTuyenDung>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThongTinTuyenDung item = ThongTinTuyenDung.NewThongTinTuyenDung();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinTuyenDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinTuyenDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinTuyenDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinTuyenDungList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinTuyenDungList()
		{ /* require use of factory method */ }

		public static ThongTinTuyenDungList NewThongTinTuyenDungList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinTuyenDungList");
			return new ThongTinTuyenDungList();
		}

		public static ThongTinTuyenDungList GetThongTinTuyenDungList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinTuyenDungList");
			return DataPortal.Fetch<ThongTinTuyenDungList>(new FilterCriteria());
		}
        
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			//public int MaViTri;

			public FilterCriteria()
			{
				
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelecttblnsThongTinTuyenDungsAll";
                }
				//cm.Parameters.AddWithValue("@MaViTri", criteria.MaViTri);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ThongTinTuyenDung.GetThongTinTuyenDung(dr));
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
					foreach (ThongTinTuyenDung deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ThongTinTuyenDung child in this)
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

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Luong_NguonList : Csla.BusinessListBase<Luong_NguonList, Luong_Nguon>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			Luong_Nguon item = Luong_Nguon.NewLuong_Nguon();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Luong_NguonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Luong_NguonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Luong_NguonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Luong_NguonList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Luong_NguonList()
		{ /* require use of factory method */ }

		public static Luong_NguonList NewLuong_NguonList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Luong_NguonList");
			return new Luong_NguonList();
		}

		public static Luong_NguonList GetLuong_NguonList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Luong_NguonList");
			return DataPortal.Fetch<Luong_NguonList>(new FilterCriteria());
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
                cm.CommandText = "spd_SelecttblnsLuong_NguonsAll";

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(Luong_Nguon.GetLuong_Nguon(dr));
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
					foreach (Luong_Nguon deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (Luong_Nguon child in this)
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

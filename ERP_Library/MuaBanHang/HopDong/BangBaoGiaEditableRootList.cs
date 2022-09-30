
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangBaoGiaList : Csla.BusinessListBase<BangBaoGiaList, BangBaoGia>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BangBaoGia item = BangBaoGia.NewBangBaoGiaChild();
			this.Add(item);
            
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangBaoGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangBaoGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangBaoGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangBaoGiaList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangBaoGiaListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangBaoGiaList()
		{ /* require use of factory method */ }

		public static BangBaoGiaList NewBangBaoGiaList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangBaoGiaList");
			return new BangBaoGiaList();
		}

		public static BangBaoGiaList GetBangBaoGiaList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangBaoGiaList");
			return DataPortal.Fetch<BangBaoGiaList>(new FilterCriteria());
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
				catch(Exception ex) 
				{
					tr.Rollback();
					throw ex;
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
                cm.CommandText = "spd_SelecttblBangBaoGiasAll";
				

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        this.Add(BangBaoGia.GetBangBaoGia(dr));
                    }
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
                    foreach (BangBaoGia deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BangBaoGia child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update

		#endregion //Data Access
	}
}

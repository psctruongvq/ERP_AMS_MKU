
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoQuiDoiList : Csla.BusinessListBase<BoQuiDoiList, BoQuiDoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BoQuiDoi item = BoQuiDoi.NewBoQuiDoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoQuiDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoQuiDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoQuiDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoQuiDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoQuiDoiList()
		{ /* require use of factory method */ }

		public static BoQuiDoiList NewBoQuiDoiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoQuiDoiList");
			return new BoQuiDoiList();
		}

		public static BoQuiDoiList GetBoQuiDoiList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoQuiDoiList");
			return DataPortal.Fetch<BoQuiDoiList>(new FilterCriteria());
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            //public int MaHangHoa;
            //public int MaDonViQuiDoi;

			public FilterCriteria()//(int maHangHoa, int maDonViQuiDoi)
			{
                //this.MaHangHoa = maHangHoa;
                //this.MaDonViQuiDoi = maDonViQuiDoi;
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
                cm.CommandText = "spd_SelecttblBoQuiDoisAll";
				//cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);
				//cm.Parameters.AddWithValue("@MaDonViQuiDoi", criteria.MaDonViQuiDoi);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BoQuiDoi.GetBoQuiDoi(dr));
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
					foreach (BoQuiDoi deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoQuiDoi child in this)
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

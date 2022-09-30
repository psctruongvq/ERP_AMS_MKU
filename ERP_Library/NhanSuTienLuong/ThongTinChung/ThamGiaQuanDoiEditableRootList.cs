
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThamGiaQuanDoiList : Csla.BusinessListBase<ThamGiaQuanDoiList, ThamGiaQuanDoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThamGiaQuanDoi item = ThamGiaQuanDoi.NewThamGiaQuanDoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThamGiaQuanDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThamGiaQuanDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThamGiaQuanDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThamGiaQuanDoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThamGiaQuanDoiList()
		{ /* require use of factory method */ }

		public static ThamGiaQuanDoiList NewThamGiaQuanDoiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThamGiaQuanDoiList");
			return new ThamGiaQuanDoiList();
		}

		public static ThamGiaQuanDoiList GetThamGiaQuanDoiList(long MaNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThamGiaQuanDoiList");
			return DataPortal.Fetch<ThamGiaQuanDoiList>(new FilterCriteria(MaNhanVien));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public long MaNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhTGQDoi";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ThamGiaQuanDoi.GetThamGiaQuanDoi(dr));
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
					foreach (ThamGiaQuanDoi deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ThamGiaQuanDoi child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
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

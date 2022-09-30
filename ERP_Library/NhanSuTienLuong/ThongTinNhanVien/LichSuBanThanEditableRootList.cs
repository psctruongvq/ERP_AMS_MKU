
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LichSuBanThanList : Csla.BusinessListBase<LichSuBanThanList, LichSuBanThan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LichSuBanThan item = LichSuBanThan.NewLichSuBanThan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LichSuBanThanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LichSuBanThanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LichSuBanThanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LichSuBanThanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LichSuBanThanList()
		{ /* require use of factory method */ }

		public static LichSuBanThanList NewLichSuBanThanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LichSuBanThanList");
			return new LichSuBanThanList();
		}

        public static LichSuBanThanList GetLichSuBanThanList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghiList");
            return DataPortal.Fetch<LichSuBanThanList>(new FilterCriteria(maNhanVien));
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
                cm.CommandText = "spd_SelecttblnsLichSuBanThansAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LichSuBanThan.GetLichSuBanThan(dr));
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
					foreach (LichSuBanThan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LichSuBanThan child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GhepCongNhanList : Csla.BusinessListBase<GhepCongNhanList, GhepCongNhan>
	{
        protected override object AddNewCore()
        {

            GhepCongNhan item = GhepCongNhan.NewGhepCongNhan(0);
            this.Add(item);
            return item;
        }
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GhepCongNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GhepCongNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GhepCongNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GhepCongNhanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GhepCongNhanList()
		{ /* require use of factory method */ }

		public static GhepCongNhanList NewGhepCongNhanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GhepCongNhanList");
			return new GhepCongNhanList();
		}

		public static GhepCongNhanList GetGhepCongNhanList(long maNhanVienChinh, long maNhanVienPhu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GhepCongNhanList");
			return DataPortal.Fetch<GhepCongNhanList>(new FilterCriteria(maNhanVienChinh, maNhanVienPhu));
		}
        public static GhepCongNhanList GetGhepCongNhanListByMaKy(int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GhepCongNhanList");
            return DataPortal.Fetch<GhepCongNhanList>(new FilterCriteriaByKyTinhLuong(maKy));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVienChinh;
			public long MaNhanVienPhu;

			public FilterCriteria(long maNhanVienChinh, long maNhanVienPhu)
			{
				this.MaNhanVienChinh = maNhanVienChinh;
				this.MaNhanVienPhu = maNhanVienPhu;
			}
		}
        private class FilterCriteriaByKyTinhLuong
        {
            public int maKy;
            public FilterCriteriaByKyTinhLuong(int maKy)
            {
                this.maKy = maKy;
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
                    cm.CommandText = "GetGhepCongNhanList";
                    cm.Parameters.AddWithValue("@MaNhanVienChinh",((FilterCriteria)criteria).MaNhanVienChinh);
                    cm.Parameters.AddWithValue("@MaNhanVienPhu",((FilterCriteria) criteria).MaNhanVienPhu);
                }
                else if (criteria is FilterCriteriaByKyTinhLuong)
                {
                    cm.CommandText = "sp_SelecttblGhepCongNhanByMaKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong",((FilterCriteriaByKyTinhLuong)criteria).maKy);
                    
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(GhepCongNhan.GetGhepCongNhan(dr));
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
					foreach (GhepCongNhan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (GhepCongNhan child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUngTheoChucVuList : Csla.BusinessListBase<TamUngTheoChucVuList, TamUngTheoChucVu>
	{
        protected override object AddNewCore()
        {
            TamUngTheoChucVu item = TamUngTheoChucVu.NewTamUngTheoChucVu(0);

            this.Add(item);
            return item;
        }
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TamUngTheoChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TamUngTheoChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TamUngTheoChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TamUngTheoChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TamUngTheoChucVuList()
		{ /* require use of factory method */ }

		public static TamUngTheoChucVuList NewTamUngTheoChucVuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoChucVuList");
			return new TamUngTheoChucVuList();
		}

		public static TamUngTheoChucVuList GetTamUngTheoChucVuList(int maChucVu, int maKyTinhLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TamUngTheoChucVuList");
			return DataPortal.Fetch<TamUngTheoChucVuList>(new FilterCriteria(maChucVu, maKyTinhLuong));
		}
        public static TamUngTheoChucVuList GetTamUngTheoChucVuListByMaKyTinhLuong( int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TamUngTheoChucVuList");
            return DataPortal.Fetch<TamUngTheoChucVuList>(new FilterCriteriaByMaKyTinhLuong( maKyTinhLuong));
        }
        public static TamUngTheoChucVuList GetTamUngTheoChucVuListByMaChucVuMaKyTinhLuong(int maChucVu,int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TamUngTheoChucVuList");
            return DataPortal.Fetch<TamUngTheoChucVuList>(new FilterCriteriaByMaChucVuKyTinhLuong(maChucVu,maKyTinhLuong));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChucVu;
			public int MaKyTinhLuong;

			public FilterCriteria(int maChucVu, int maKyTinhLuong)
			{
				this.MaChucVu = maChucVu;
				this.MaKyTinhLuong = maKyTinhLuong;
			}
		}
        [Serializable()]
		private class FilterCriteriaByMaKyTinhLuong
		{
			
			public int MaKyTinhLuong;

            public FilterCriteriaByMaKyTinhLuong(int maKyTinhLuong)
			{
				
				this.MaKyTinhLuong = maKyTinhLuong;
			}
		}
        [Serializable()]
		private class FilterCriteriaByMaChucVuKyTinhLuong
		{
			
			public int MaKyTinhLuong;
            public int MaChucVu;
            public FilterCriteriaByMaChucVuKyTinhLuong(int maChucVu,int maKyTinhLuong)
			{
                this.MaChucVu = maChucVu;
				this.MaKyTinhLuong = maKyTinhLuong;
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
                if(criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelecttblnsTamUngTheoChucVusAll";
                }
                else if(criteria is FilterCriteriaByMaKyTinhLuong)
                {
                    cm.CommandText = "sp_SelecttblnsTamUngTheoChucVuByMaKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong",((FilterCriteriaByMaKyTinhLuong) criteria).MaKyTinhLuong);
                }
                else if (criteria is FilterCriteriaByMaChucVuKyTinhLuong)
                {
                    cm.CommandText = "sp_SelecttblnsTamUngTheoChucVuByMaChucMaKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByMaChucVuKyTinhLuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteriaByMaChucVuKyTinhLuong)criteria).MaChucVu);
                }
                
				//cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);
				//cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TamUngTheoChucVu.GetTamUngTheoChucVu(dr));
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
					foreach (TamUngTheoChucVu deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TamUngTheoChucVu child in this)
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

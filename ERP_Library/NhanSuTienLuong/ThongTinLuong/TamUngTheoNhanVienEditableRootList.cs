
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUngTheoNhanVienList : Csla.BusinessListBase<TamUngTheoNhanVienList, TamUngTheoNhanVien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TamUngTheoNhanVien item = TamUngTheoNhanVien.NewTamUngTheoNhanVien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TamUngTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TamUngTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TamUngTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TamUngTheoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TamUngTheoNhanVienList()
		{ /* require use of factory method */ }

		public static TamUngTheoNhanVienList NewTamUngTheoNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoNhanVienList");
			return new TamUngTheoNhanVienList();
		}

		public static TamUngTheoNhanVienList GetTamUngTheoNhanVienList(long maNhanVien, int maChucVu, int maKyTinhLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TamUngTheoNhanVienList");
			return DataPortal.Fetch<TamUngTheoNhanVienList>(new FilterCriteria(maNhanVien, maChucVu, maKyTinhLuong));
		}
        public static TamUngTheoNhanVienList GetTamUngTheoNhanVienListByMaKy(long maNhanVien, int maKyTinhLuong)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TamUngTheoNhanVienList");
            return DataPortal.Fetch<TamUngTheoNhanVienList>(new FilterCriteriaByKy(maNhanVien, maKyTinhLuong));
        }
        public static TamUngTheoNhanVienList GetTamUngTheoNhanVienListMaChucVuMaKyTinhLuong( int maChucVu, int maKyTinhLuong,int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TamUngTheoNhanVienList");
            return DataPortal.Fetch<TamUngTheoNhanVienList>(new FilterCriteriaByMaChucVumaKyTinhLuong(maChucVu, maKyTinhLuong,maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;
			public int MaChucVu;
			public int MaKyTinhLuong;

			public FilterCriteria(long maNhanVien, int maChucVu, int maKyTinhLuong)
			{
				this.MaNhanVien = maNhanVien;
				this.MaChucVu = maChucVu;
				this.MaKyTinhLuong = maKyTinhLuong;
			}
		}
        private class FilterCriteriaByMaChucVumaKyTinhLuong
        {
            
            public int MaChucVu;
            public int MaKyTinhLuong;
            public int MaBoPhan;

            public FilterCriteriaByMaChucVumaKyTinhLuong( int maChucVu, int maKyTinhLuong,int maBoPhan)
            {
                
                this.MaChucVu = maChucVu;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
            }
        }
         private class FilterCriteriaByKy
        {
            
            public long MaNhanVien;
            public int MaKyTinhLuong;

             public FilterCriteriaByKy(long MaNhanVien, int maKyTinhLuong)
            {

                this.MaNhanVien = MaNhanVien;
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
                    cm.CommandText = "sp_SelecttblnsTamUngTheoNhanViensAll";
               }
               else if(criteria is FilterCriteriaByMaChucVumaKyTinhLuong)
               {
                   cm.CommandText = "sp_SelecttblnsTamUngTheoNhanVienMaChucVuMaKyTinhLuong";
                   cm.Parameters.AddWithValue("@MaChucVu",((FilterCriteriaByMaChucVumaKyTinhLuong) criteria).MaChucVu);
                   cm.Parameters.AddWithValue("@MaKyTinhLuong",((FilterCriteriaByMaChucVumaKyTinhLuong)criteria).MaKyTinhLuong);
                   cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByMaChucVumaKyTinhLuong)criteria).MaBoPhan);
               }
                 else if(criteria is FilterCriteriaByKy)
               {
                   cm.CommandText = "sp_SelecttblnsTamUngTheoNhanVienTheoKy";
                   cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByKy)criteria).MaNhanVien);
                   cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByKy)criteria).MaKyTinhLuong);
               }
				//cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				
                
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TamUngTheoNhanVien.GetTamUngTheoNhanVien(dr));
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
					foreach (TamUngTheoNhanVien deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TamUngTheoNhanVien child in this)
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

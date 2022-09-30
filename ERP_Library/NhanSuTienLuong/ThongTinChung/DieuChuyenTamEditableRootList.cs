
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DieuChuyenTamList : Csla.BusinessListBase<DieuChuyenTamList, DieuChuyenTam>
	{
		#region BindingList Overrides
        protected override object AddNewCore()
        {
            DieuChuyenTam item = DieuChuyenTam.NewDieuChuyenTam(0);
            this.Add(item);
            return item;
        }
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DieuChuyenTamList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DieuChuyenTamList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DieuChuyenTamList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DieuChuyenTamList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DieuChuyenTamList()
		{ /* require use of factory method */ }

		public static DieuChuyenTamList NewDieuChuyenTamList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChuyenTamList");
			return new DieuChuyenTamList();
		}

		public static DieuChuyenTamList GetDieuChuyenTamList(int maBoPhan, int maCongViec, long maNhanVien, int maKyTinhLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DieuChuyenTamList");
			return DataPortal.Fetch<DieuChuyenTamList>(new FilterCriteria(maBoPhan, maCongViec, maNhanVien, maKyTinhLuong));
		}
        public static DieuChuyenTamList GetDieuChuyenTamListByNhanVien(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenTamList");
            return DataPortal.Fetch<DieuChuyenTamList>(new FilterCriteriaByNhanVien(maNhanVien));
        }
        public static DieuChuyenTamList GetDieuChuyenTamListByKyTinhLuong(int maKyTinhLuong,int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DieuChuyenTamList");
            return DataPortal.Fetch<DieuChuyenTamList>(new FilterCriteriaByKyTinhLuong(maKyTinhLuong,maBoPhan));
        }
        
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaBoPhan;
			public int MaCongViec;
			public long MaNhanVien;
			public int MaKyTinhLuong;

			public FilterCriteria(int maBoPhan, int maCongViec, long maNhanVien, int maKyTinhLuong)
			{
				this.MaBoPhan = maBoPhan;
				this.MaCongViec = maCongViec;
				this.MaNhanVien = maNhanVien;
				this.MaKyTinhLuong = maKyTinhLuong;
			}
		}
        private class FilterCriteriaByNhanVien
        {
            public long MaNhanVien;
            public FilterCriteriaByNhanVien(long maNhanVien)
            {               
                this.MaNhanVien = maNhanVien;                
            }
        }
        private class FilterCriteriaByKyTinhLuong
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public FilterCriteriaByKyTinhLuong(int maKyTinhLuong,int maBoPhan)
            {
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaBoPhan = maBoPhan;
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
                    cm.CommandText = "sp_SelecttblnsDieuChuyenTamsAll";
                }
                else if (criteria is FilterCriteriaByNhanVien)
                {
                    cm.CommandText = "sp_SelecttblnsDieuChuyenTamByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteriaByNhanVien)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaByKyTinhLuong)
                {
                    cm.CommandText = "sp_SelecttblnsDieuChuyenTamByKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByKyTinhLuong)criteria).MaKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaBoPhanGoc", ((FilterCriteriaByKyTinhLuong)criteria).MaBoPhan);
                }
				//cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
				//cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);
				//cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				//cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(DieuChuyenTam.GetDieuChuyenTam(dr));
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
					foreach (DieuChuyenTam deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DieuChuyenTam child in this)
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

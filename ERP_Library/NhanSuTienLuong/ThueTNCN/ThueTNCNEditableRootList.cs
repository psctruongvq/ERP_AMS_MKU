
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThueTNCNList : Csla.BusinessListBase<ThueTNCNList, ThueTNCN>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThueTNCN item = ThueTNCN.NewThueTNCN();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThueTNCNList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThueTNCNList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThueTNCNList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThueTNCNList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThueTNCNListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThueTNCNList()
		{ /* require use of factory method */ }

		public static ThueTNCNList NewThueTNCNList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThueTNCNList");
			return new ThueTNCNList();
		}

		public static ThueTNCNList GetThueTNCNList(long maNhanVien, int maKyTinhLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThueTNCNList");
			return DataPortal.Fetch<ThueTNCNList>(new FilterCriteria(maNhanVien, maKyTinhLuong));
		}
        public static ThueTNCNList GetThueTNCNList(Int16 cachTinhThue, int maKyTinhLuong,int maBoPhan, long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNList");
            return DataPortal.Fetch<ThueTNCNList>(new FilterCriteria(maNhanVien, maKyTinhLuong));
        }
        public static ThueTNCNList GetNhanVienListByCachTinhThue(Int16 cachTinhThue)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNList");
            return DataPortal.Fetch<ThueTNCNList>(new FilterCriteriaThueTNCN(cachTinhThue));
        }
        public static ThueTNCNList GetNhanVienListByCachTinhThueByAll(Int16 cachTinhThue,int maKyTinhLuong,int maBoPhan,long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThueTNCNList");
            return DataPortal.Fetch<ThueTNCNList>(new FilterCriteriaByAll(cachTinhThue,maKyTinhLuong,maBoPhan,maNhanVien));
        }
        //public static ThueTNCNList GetNhanVienList_XuLyThue(Int16 cachTinhThue, int maKyTinhLuong, int maBoPhan, long maNhanVien)
        //{
        //    if (!CanGetObject())
        //        throw new System.Security.SecurityException("User not authorized to view a ThueTNCNList");
        //    return DataPortal.Fetch<ThueTNCNList>(new FilterCriteria_XuLyThue(cachTinhThue, maKyTinhLuong, maBoPhan, maNhanVien));
        //}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;
			public int MaKyTinhLuong;

			public FilterCriteria(long maNhanVien, int maKyTinhLuong)
			{
				this.MaNhanVien = maNhanVien;
				this.MaKyTinhLuong = maKyTinhLuong;
			}
		}
        //private class FilterCriteria_XuLyThue
        //{
        //    public long MaNhanVien;
        //    public int MaKyTinhLuong;
        //    public int MaBoPhan;
        //    public Int16 CachTinhThue;
        //    public FilterCriteria_XuLyThue(Int16 cachTinhThue, int maKyTinhLuong, int maBoPhan, long maNhanVien)
        //    {
        //        this.MaNhanVien = maNhanVien;
        //        this.MaKyTinhLuong = maKyTinhLuong;
        //        this.CachTinhThue = cachTinhThue;
        //        this.MaBoPhan = maBoPhan;
        //    }
        //}
        [Serializable()]
        private class FilterCriteriaByAll
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public Int16 CachTinhThue;
            public FilterCriteriaByAll(Int16 cachTinhThue, int maKyTinhLuong,int maBoPhan, long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.CachTinhThue = cachTinhThue;
                this.MaBoPhan = maBoPhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaThueTNCN
        {
            public Int16 cachTinhThue;

            public FilterCriteriaThueTNCN(Int16 _cachTinhThue)
            {
                this.cachTinhThue = _cachTinhThue;
            }
        }
      
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsThueThuNhapCaNhansByMaKyTinhLuongAndMaNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteria)criteria).MaKyTinhLuong);
                }
                else if (criteria is FilterCriteriaThueTNCN)
                {
                    cm.CommandText = "spd_SelecttblnsTTNhanVienRutGonCachTinhThue";
                    cm.Parameters.AddWithValue("@CachTinhThue", ((FilterCriteriaThueTNCN)criteria).cachTinhThue);
              
                }
                else if (criteria is FilterCriteriaByAll)
                {
                    cm.CommandText = "spd_SelecttblnsThueThuNhapCaNhansByAll";
                    cm.Parameters.AddWithValue("@CachTinhThue", ((FilterCriteriaByAll)criteria).CachTinhThue);
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByAll)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByAll)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByAll)criteria).MaKyTinhLuong);

                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ThueTNCN.GetThueTNCN(dr));
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
					foreach (ThueTNCN deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ThueTNCN child in this)
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

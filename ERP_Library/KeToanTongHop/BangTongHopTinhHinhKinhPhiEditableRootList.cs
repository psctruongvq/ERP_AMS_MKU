
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangTongHopTinhHinhKinhPhiList : Csla.BusinessListBase<BangTongHopTinhHinhKinhPhiList, BangTongHopTinhHinhKinhPhi>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangTongHopTinhHinhKinhPhiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangTongHopTinhHinhKinhPhiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangTongHopTinhHinhKinhPhiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangTongHopTinhHinhKinhPhiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangTongHopTinhHinhKinhPhiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangTongHopTinhHinhKinhPhiList()
		{ /* require use of factory method */ }

		public static BangTongHopTinhHinhKinhPhiList NewBangTongHopTinhHinhKinhPhiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangTongHopTinhHinhKinhPhiList");
			return new BangTongHopTinhHinhKinhPhiList();
		}

		public static BangTongHopTinhHinhKinhPhiList GetBangTongHopTinhHinhKinhPhiList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangTongHopTinhHinhKinhPhiList");
			return DataPortal.Fetch<BangTongHopTinhHinhKinhPhiList>(new FilterCriteria());
		}
        public static BangTongHopTinhHinhKinhPhiList GetBangTongHopTinhHinhKinhPhiList(int MaCongTy, byte LoaiMau)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangTongHopTinhHinhKinhPhiList");
            return DataPortal.Fetch<BangTongHopTinhHinhKinhPhiList>(new FilterCriteriaByMaCongTy(MaCongTy, LoaiMau));
        }

        public static BangTongHopTinhHinhKinhPhiList GetBangTongHopTinhHinhKinhPhiList(byte CapMuc, byte LoaiMau, int MaCongTy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangTongHopTinhHinhKinhPhiList");
            return DataPortal.Fetch<BangTongHopTinhHinhKinhPhiList>(new FilterCriteriaByCapMuc(CapMuc, LoaiMau, MaCongTy));
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

        [Serializable()]
        private class FilterCriteriaByMaCongTy
        {
           public int MaCongTy = 0;
           public byte LoaiMau = 0;
            public FilterCriteriaByMaCongTy(int maCongTy, byte loaiMau)
            {
                MaCongTy = maCongTy;
                LoaiMau = loaiMau;
            }
        }

        [Serializable()]
        private class FilterCriteriaByCapMuc
        {
            public byte CapMuc = 0;
            public byte LoaiMau = 0;
            public int MaCongTy = 0;
            public FilterCriteriaByCapMuc(byte capMuc, byte loaiMau, int maCongTy)
            {
                CapMuc = capMuc;
                LoaiMau = loaiMau;
                MaCongTy = maCongTy;
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
                    cm.CommandText = "spd_SelecttblBangTongHopTinhHinhKinhPhisAll";
                else if (criteria is FilterCriteriaByMaCongTy)
                {
                    cm.CommandText = "spd_SelecttblBangTongHopTinhHinhKinhPhiByMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaByMaCongTy)criteria).MaCongTy);
                    cm.Parameters.AddWithValue("@LoaiMau", ((FilterCriteriaByMaCongTy)criteria).LoaiMau);
                }
                else if (criteria is FilterCriteriaByCapMuc)
                {
                    cm.CommandText = "spd_SelecttblBangTongHopTinhHinhKinhPhiByCapMuc";
                    cm.Parameters.AddWithValue("@CapMuc", ((FilterCriteriaByCapMuc)criteria).CapMuc);
                    cm.Parameters.AddWithValue("@LoaiMau", ((FilterCriteriaByCapMuc)criteria).LoaiMau);
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteriaByCapMuc)criteria).MaCongTy);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BangTongHopTinhHinhKinhPhi.GetBangTongHopTinhHinhKinhPhi(dr));
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
					foreach (BangTongHopTinhHinhKinhPhi deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BangTongHopTinhHinhKinhPhi child in this)
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

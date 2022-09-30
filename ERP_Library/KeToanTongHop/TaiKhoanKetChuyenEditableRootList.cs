
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TaiKhoanKetChuyenList : Csla.BusinessListBase<TaiKhoanKetChuyenList, TaiKhoanKetChuyen>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TaiKhoanKetChuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TaiKhoanKetChuyenListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TaiKhoanKetChuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TaiKhoanKetChuyenListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TaiKhoanKetChuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TaiKhoanKetChuyenListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TaiKhoanKetChuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TaiKhoanKetChuyenListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TaiKhoanKetChuyenList()
		{ /* require use of factory method */ }

		public static TaiKhoanKetChuyenList NewTaiKhoanKetChuyenList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TaiKhoanKetChuyenList");
			return new TaiKhoanKetChuyenList();
		}

		public static TaiKhoanKetChuyenList GetTaiKhoanKetChuyenListByNguoiLap()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TaiKhoanKetChuyenList");
			return DataPortal.Fetch<TaiKhoanKetChuyenList>(new FilterCriteria());
		}

        public static TaiKhoanKetChuyenList GetTaiKhoanKetChuyenList(int maLoaiKetChuyen, int MaKy, DateTime TuNgay, DateTime DenNgay, byte NoCo)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TaiKhoanKetChuyenList");
            return DataPortal.Fetch<TaiKhoanKetChuyenList>(new FilterCriteriaByKetChuyen(maLoaiKetChuyen, MaKy, TuNgay, DenNgay, NoCo));
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

        private class FilterCriteriaByKetChuyen
        {
            public int MaLoaiKetChuyen;
            public int MaKy;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public byte NoCo;

            public FilterCriteriaByKetChuyen(int maLoaiKetChuyen, int maKy, DateTime tuNgay, DateTime denNgay, byte noCo)
            {
                MaLoaiKetChuyen = maLoaiKetChuyen;
                MaKy = maKy;
                TuNgay = tuNgay;
                DenNgay = denNgay;
                NoCo = noCo;
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
                    cm.CommandText = "spd_SelecttblCongThucKetChuyensAll";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                }

                else if (criteria is FilterCriteriaByKetChuyen)
                {
                    cm.CommandText = "spd_getTaiKhoanKetChuyen";
                    cm.Parameters.AddWithValue("@MaLoaiKetChuyen", ((FilterCriteriaByKetChuyen)criteria).MaLoaiKetChuyen);
                    cm.Parameters.AddWithValue("@MaKy", ((FilterCriteriaByKetChuyen)criteria).MaKy);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByKetChuyen)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByKetChuyen)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@NoCo", ((FilterCriteriaByKetChuyen)criteria).NoCo);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TaiKhoanKetChuyen.GetTaiKhoanKetChuyen(dr));
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
					foreach (TaiKhoanKetChuyen deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TaiKhoanKetChuyen child in this)
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

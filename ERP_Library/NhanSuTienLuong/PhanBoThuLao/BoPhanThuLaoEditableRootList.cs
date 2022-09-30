using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhanThuLaoList : Csla.BusinessListBase<BoPhanThuLaoList, BoPhanThuLao>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhanThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhanThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhanThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhanThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhanThuLaoList()
		{ /* require use of factory method */ }

		public static BoPhanThuLaoList NewBoPhanThuLaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanThuLaoList");
			return new BoPhanThuLaoList();
		}

		public static BoPhanThuLaoList GetBoPhanThuLaoList(int maKyTinhLuong,int maGiayXacNhan,DateTime tuNgay,DateTime denNgay,int maBoPhan,int bien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhanThuLaoList");
			return DataPortal.Fetch<BoPhanThuLaoList>(new FilterCriteria(maKyTinhLuong,maGiayXacNhan,tuNgay,denNgay,maBoPhan, bien));
		}

        public static BoPhanThuLaoList GetBoPhanThuLaoListAll(int maKyTinhLuong, DateTime tuNgay, DateTime denNgay, int maBoPhan, int bien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhanThuLaoList");
            return DataPortal.Fetch<BoPhanThuLaoList>(new FilterCriteriaAll(maKyTinhLuong, tuNgay, denNgay, maBoPhan, bien));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int _maKyTinhLuong;
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _bien;
            public int _maBoPhan;
            public int _maGiayXacnhan;

            public FilterCriteria(int maKyTinhLuong,int maGiacXacNhan, DateTime tuNgay, DateTime denNgay, int maBoPhan,int bien)
			{
                _maKyTinhLuong = maKyTinhLuong;
                _tuNgay = tuNgay;
                _denNgay = denNgay;
                _bien = bien;
                _maBoPhan = maBoPhan;
                _maGiayXacnhan = maGiacXacNhan;
			}
		}

        private class FilterCriteriaAll
        {
            public int _maKyTinhLuong;
            public DateTime _tuNgay;
            public DateTime _denNgay;
            public int _bien;
            public int _maBoPhan;

            public FilterCriteriaAll(int maKyTinhLuong, DateTime tuNgay, DateTime denNgay, int maBoPhan, int bien)
            {
                _maKyTinhLuong = maKyTinhLuong;
                _tuNgay = tuNgay;
                _denNgay = denNgay;
                _bien = bien;
                _maBoPhan = maBoPhan;
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
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelectBoPhanThuLao";

                    cm.Parameters.Add("@MaKyTinhLuong", ((FilterCriteria)criteria)._maKyTinhLuong);
                    cm.Parameters.Add("@TuNgay", ((FilterCriteria)criteria)._tuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteria)criteria)._denNgay);
                    cm.Parameters.Add("@Bien", ((FilterCriteria)criteria)._bien);
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@MaGiayXacNhan", ((FilterCriteria)criteria)._maGiayXacnhan);
                }

                if (criteria is FilterCriteriaAll)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelectBoPhanThuLaosAll";

                    cm.Parameters.Add("@MaKyTinhLuong", ((FilterCriteriaAll)criteria)._maKyTinhLuong);
                    cm.Parameters.Add("@TuNgay", ((FilterCriteriaAll)criteria)._tuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaAll)criteria)._denNgay);
                    cm.Parameters.Add("@Bien", ((FilterCriteriaAll)criteria)._bien);
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BoPhanThuLao.GetBoPhanThuLao(dr));
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
					foreach (BoPhanThuLao deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BoPhanThuLao child in this)
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

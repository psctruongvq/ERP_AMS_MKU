
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhanTongHopList : Csla.BusinessListBase<ChiTietGiayXacNhanTongHopList, ChiTietGiayXacNhanTongHop>
	{

		#region Factory Methods
        protected override object AddNewCore()
        {
            ChiTietGiayXacNhanTongHop item = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();
            
            this.Add(item);
            return item;
        }
        private ChiTietGiayXacNhanTongHopList()
		{ /* require use of factory method */ }


        public static ChiTietGiayXacNhanTongHopList NewChiTietGiayXacNhanTongHopList()
		{
            return new ChiTietGiayXacNhanTongHopList();
		}

        public static ChiTietGiayXacNhanTongHopList GetChiTietGiayXacNhanTongHopListByUserID(int userID)
        {
            return DataPortal.Fetch<ChiTietGiayXacNhanTongHopList>(new FilterCriteriaByUserID(userID));
        }
        public static ChiTietGiayXacNhanTongHopList GetChiTietGiayXacNhanTongHopListByUserIDAndMaChiTietGiayXacNhan(int userID,int maChiTietGXN )
        {
            return DataPortal.Fetch<ChiTietGiayXacNhanTongHopList>(new FilterCriteriaByUserIDAndMaChiTietGiayXacNhan(userID, maChiTietGXN));
        }
   		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria

        [Serializable()]
        private class FilterCriteriaByUserID
        {
            public int UserID;

            public FilterCriteriaByUserID(int userID)
            {
                this.UserID = userID;
            }
        }
        private class FilterCriteriaByUserIDAndMaChiTietGiayXacNhan
        {
            public int UserID;
            public int MaChiTietGXN;
            public FilterCriteriaByUserIDAndMaChiTietGiayXacNhan(int userID, int maChiTietGXN)
            {
                this.UserID = userID;
                this.MaChiTietGXN = maChiTietGXN;
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
                cm.CommandTimeout = 90;
                if (criteria is FilterCriteriaByUserID)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanChuongTrinhByThuLao";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserID)criteria).UserID);
                }
                if (criteria is FilterCriteriaByUserIDAndMaChiTietGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanChuongTrinhByUserIDAndMaChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserIDAndMaChiTietGiayXacNhan)criteria).UserID);
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((FilterCriteriaByUserIDAndMaChiTietGiayXacNhan)criteria).MaChiTietGXN);
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietGiayXacNhanTongHop.GetChiTietGiayXacNhanTongHop(dr));
                }
				
			}//using
		}
		#endregion //Data Access - Fetch

		#endregion //Data Access

    }
}

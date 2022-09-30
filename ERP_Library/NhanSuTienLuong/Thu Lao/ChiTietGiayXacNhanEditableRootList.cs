
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhanList : Csla.BusinessListBase<ChiTietGiayXacNhanList, ChiTietGiayXacNhan>
	{

		#region Factory Methods
        protected override object AddNewCore()
        {
            ChiTietGiayXacNhan item = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
            
            this.Add(item);
            return item;
        }
		private ChiTietGiayXacNhanList()
		{ /* require use of factory method */ }


		public static ChiTietGiayXacNhanList NewChiTietGiayXacNhanList()
		{
			return new ChiTietGiayXacNhanList();
		}

		public static ChiTietGiayXacNhanList GetChiTietGiayXacNhanList(int maChiTietGiayXacNhan)
		{
			return DataPortal.Fetch<ChiTietGiayXacNhanList>(new FilterCriteria(maChiTietGiayXacNhan));
		}
    
        public static ChiTietGiayXacNhanList GetChiTietGiayXacNhanListByUserID(int userID)
        {
            return DataPortal.Fetch<ChiTietGiayXacNhanList>(new FilterCriteriaByUserID(userID));
        }
        public static ChiTietGiayXacNhanList GetChiTietGiayXacNhanListByGiayXacNhan(int maGiayXacNhan)
        {
            return DataPortal.Fetch<ChiTietGiayXacNhanList>(new FilterCriteriaByGiayXacNhan(maGiayXacNhan));
        }

        public static ChiTietGiayXacNhanList GetChiTietGiayXacNhanListByBoPhanDen(int maBoPhan, int duocNhapHo)
        {
            return DataPortal.Fetch<ChiTietGiayXacNhanList>(new FilterCriteriaByBoPhanDen(maBoPhan, duocNhapHo));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChiTietGiayXacNhan;

			public FilterCriteria(int maChiTietGiayXacNhan)
			{
				this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
			}
		}
        [Serializable()]
        private class FilterCriteriaByGiayXacNhan
        {
            public int MaGiayXacNhan;

            public FilterCriteriaByGiayXacNhan(int maGiayXacNhan)
            {
                this.MaGiayXacNhan = maGiayXacNhan;
            }
        }
        [Serializable()]
        private class FilterCriteriaByUserID
        {
            public int UserID;

            public FilterCriteriaByUserID(int userID)
            {
                this.UserID = userID;
            }
        }

        [Serializable()]
        private class FilterCriteriaByBoPhanDen
        {
            public int BoPhan;
            public int NhapHo;

            public FilterCriteriaByBoPhanDen(int bophan, int nhapho)
            {
                this.BoPhan = bophan;
                this.NhapHo = nhapho;
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
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanByMaGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan",((FilterCriteria)criteria).MaChiTietGiayXacNhan);
                
                }
                else if (criteria is FilterCriteriaByUserID)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanChuongTrinhByThuLao";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUserID)criteria).UserID);
                }
                else if (criteria is FilterCriteriaByBoPhanDen)
                {
                    cm.CommandText = "spd_GiayXacNhanChoGoiDen";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhanDen)criteria).BoPhan);
                    cm.Parameters.AddWithValue("@DuocNhapHo", ((FilterCriteriaByBoPhanDen)criteria).NhapHo);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietGiayXacNhan.GetChiTietGiayXacNhan(dr));
                }
				
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        /*
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
					foreach (ChiTietGiayXacNhan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ChiTietGiayXacNhan child in GiayXacNhanChuongTrinh)
					{
						if (child.IsNew)
                            child.Insert(tr, GiayXacNhanChuongTrinh);
						else
                            child.Update(tr, GiayXacNhanChuongTrinh);
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
        */
		#endregion //Data Access - Update
		#endregion //Data Access

        internal void Update(SqlTransaction tr, GiayXacNhanChuongTrinh parent)
        {
            RaiseListChangedEvents = false;

           

          
                //tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (ChiTietGiayXacNhan deletedChild in DeletedList)
                    {

                      

                        deletedChild.DeleteSelf(tr);
                    }
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChiTietGiayXacNhan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, parent);
                        else
                            child.Update(tr, parent);
                    }

                    //tr.Commit();
                }
                catch
                {
                   // tr.Rollback();
                    throw;
                }
           
            RaiseListChangedEvents = true;
        }
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayXacNhanChuongTrinhList : Csla.BusinessListBase<GiayXacNhanChuongTrinhList, GiayXacNhanChuongTrinh>
	{
		#region BindingList Overrides
        protected override object AddNewCore()
        {
            GiayXacNhanChuongTrinh item = GiayXacNhanChuongTrinh.NewGiayXacNhanChuongTrinh();
                this.Add(item);
                return item;
        }
        //protected override object AddNewCore()
        //{
        //    GiayXacNhanChuongTrinh item = GiayXacNhanChuongTrinh.NewGiayXacNhanChuongTrinh();
        //    this.Add(item);
        //    return item;
        //}
		#endregion //BindingList Overrides

		#region Factory Methods
		private GiayXacNhanChuongTrinhList()
		{ /* require use of factory method */ }

		public static GiayXacNhanChuongTrinhList NewGiayXacNhanChuongTrinhList()
		{
			return new GiayXacNhanChuongTrinhList();
		}

		public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhList(int maChuongTrinh, int maDonViXacNhanDi)
		{
			return DataPortal.Fetch<GiayXacNhanChuongTrinhList>(new FilterCriteria(maChuongTrinh, maDonViXacNhanDi));
		}
        public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhListByNgayLap(DateTime tuNgay, DateTime denNgay,bool isDeleted, bool loaiGiayXacNhan)
        {
            return DataPortal.Fetch<GiayXacNhanChuongTrinhList>(new FilterCriteriaByNgayLap(tuNgay, denNgay, isDeleted, loaiGiayXacNhan));
        }
       
        public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhListByMaGiayXacNhan(int maGiayXacNhan)
        {
            return DataPortal.Fetch<GiayXacNhanChuongTrinhList>(new FilterCriteriaByMaGiayXacNhan(maGiayXacNhan));
        }
        public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhListByDonViDen(int maBoPhan)
        {
            return DataPortal.Fetch<GiayXacNhanChuongTrinhList>(new FilterCriteriaByNhapThuLao(maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaChuongTrinh;
			public int MaDonViXacNhanDi;

			public FilterCriteria(int maChuongTrinh, int maDonViXacNhanDi)
			{
				this.MaChuongTrinh = maChuongTrinh;
				this.MaDonViXacNhanDi = maDonViXacNhanDi;
			}
		}
        private class FilterCriteriaByNhapThuLao
        {

            public int MaBoPhan;

            public FilterCriteriaByNhapThuLao(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
                
            }
        }
        private class FilterCriteriaByMaGiayXacNhan
        {
            public int MaGiayXacNhan;
         
            public FilterCriteriaByMaGiayXacNhan(int maGiayXacNhan)
            {
                this.MaGiayXacNhan = maGiayXacNhan;
             
            }
        }
        
        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public bool ISDeleted;
            public bool LoaiGiayXacNhan;
            public FilterCriteriaByNgayLap(DateTime tuNgay, DateTime denNgay, bool isDelete, bool loaiGiayXacNhan)
            {
                this.ISDeleted = isDelete;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.LoaiGiayXacNhan = loaiGiayXacNhan;
            }
        }
        private class FilterCriteriaByUser
        {
            public int UserID;
            public FilterCriteriaByUser(int userID)
            {
                this.UserID = userID;
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
                    cm.CommandText = "GetGiayXacNhanChuongTrinhList";
                    cm.Parameters.AddWithValue("@MaChuongTrinh",((FilterCriteria)criteria).MaChuongTrinh);
                    cm.Parameters.AddWithValue("@MaDonViXacNhanDi", ((FilterCriteria)criteria).MaDonViXacNhanDi);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByUser)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinhByUser";
                    cm.Parameters.AddWithValue("@UserID", ((FilterCriteriaByUser)criteria).UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
                }
  
                else if (criteria is FilterCriteriaByNgayLap)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinhByNgayLap";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@IsDeleted", ((FilterCriteriaByNgayLap)criteria).ISDeleted);
                    cm.Parameters.AddWithValue("@LoaiGiayXacNhan", ((FilterCriteriaByNgayLap)criteria).LoaiGiayXacNhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinh";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((FilterCriteriaByMaGiayXacNhan)criteria).MaGiayXacNhan);
                  
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByNhapThuLao)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinhByThuLao";
                    cm.Parameters.AddWithValue("@MaBoPhanDangNhap", ((FilterCriteriaByNhapThuLao)criteria).MaBoPhan);                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMaGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanChuongTrinh";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((FilterCriteriaByMaGiayXacNhan)criteria).MaGiayXacNhan);
                  
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(dr));
                    }
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
					foreach (GiayXacNhanChuongTrinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (GiayXacNhanChuongTrinh child in this)
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



        public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhListByNgayLap(DateTime dateTime, DateTime dateTime_2, int p)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public static GiayXacNhanChuongTrinhList GetGiayXacNhanChuongTrinhList(int userID)
        {           
            return DataPortal.Fetch<GiayXacNhanChuongTrinhList>(new FilterCriteriaByUser(userID));
        }
    }
}

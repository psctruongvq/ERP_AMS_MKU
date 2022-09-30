
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TinhDangPhi_DieuChinhList : Csla.BusinessListBase<TinhDangPhi_DieuChinhList, TinhDangPhi_DieuChinh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
            TinhDangPhi_DieuChinh item = TinhDangPhi_DieuChinh.NewTinhDangPhi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
        private TinhDangPhi_DieuChinhList()
		{ /* require use of factory method */ }

        public static TinhDangPhi_DieuChinhList NewTinhDangPhi_DieuChinhList()
		{
            return new TinhDangPhi_DieuChinhList();
		}

        public static TinhDangPhi_DieuChinhList GetTinhDangPhiList()
		{
            return DataPortal.Fetch<TinhDangPhi_DieuChinhList>(new FilterCriteria());
		}
        public static TinhDangPhi_DieuChinhList GetTinhDangPhi_DieuChinhList(int maKyTinhLuong, int maBoPhan, long maNhanVien)
        {
            return DataPortal.Fetch<TinhDangPhi_DieuChinhList>(new FilterCriteriaByBoPhanKyTinhLuong(maKyTinhLuong, maBoPhan, maNhanVien));
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
        private class FilterCriteriaByBoPhanKyTinhLuong
        {
            public int MaKyTinhLuong;
            public int MaBoPhan;
            public long MaNhanVien;
            public FilterCriteriaByBoPhanKyTinhLuong(int maKyTinhLuong,int maBoPhan,long maNhanVien)
            {
                this.MaBoPhan = maBoPhan;
                this.MaKyTinhLuong = maKyTinhLuong;
                this.MaNhanVien = maNhanVien;
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
                    cm.CommandText = "spd_SelecttblnsNhanVien_DangPhisAll";
                }
                else if (criteria is FilterCriteriaByBoPhanKyTinhLuong)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_DangPhi_DieuChinhByBoPhanKyTinhLuong";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByBoPhanKyTinhLuong)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhanKyTinhLuong)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", ((FilterCriteriaByBoPhanKyTinhLuong)criteria).MaKyTinhLuong);

                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
                        this.Add(TinhDangPhi_DieuChinh.GetTinhDangPhi(dr));
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
                    foreach (TinhDangPhi_DieuChinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
                    foreach (TinhDangPhi_DieuChinh child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TheBaoHiemYTeList : Csla.BusinessListBase<TheBaoHiemYTeList, TheBaoHiemYTe>
	{

		#region Factory Methods
		private TheBaoHiemYTeList()
		{ /* require use of factory method */ }

		public static TheBaoHiemYTeList NewTheBaoHiemYTeList()
		{
			return new TheBaoHiemYTeList();
		}

		public static TheBaoHiemYTeList GetTheBaoHiemYTeList(int maNoiDangKyKCB, long maNhanVien)
		{
			return DataPortal.Fetch<TheBaoHiemYTeList>(new FilterCriteria(maNoiDangKyKCB, maNhanVien));
		}
        public static TheBaoHiemYTeList GetTheBaoHiemYTeListByBoPhan(int maboPhan)
        {
            return DataPortal.Fetch<TheBaoHiemYTeList>(new FilterCriteriaByBoPhan(maboPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaNoiDangKyKCB;
			public long MaNhanVien;

			public FilterCriteria(int maNoiDangKyKCB, long maNhanVien)
			{
				this.MaNoiDangKyKCB = maNoiDangKyKCB;
				this.MaNhanVien = maNhanVien;
			}
		}
        private class FilterCriteriaByBoPhan
		{
			public int MaBoPhan;		

            public FilterCriteriaByBoPhan(int maBoPhan)
			{
                this.MaBoPhan = maBoPhan;
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
                    cm.CommandText = "spd_SelecttblnsTheBaoHiemYTesAll";
                }
                else if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsTheBaoHiemYTeByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteriaByBoPhan)criteria).MaBoPhan);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TheBaoHiemYTe.GetTheBaoHiemYTe(dr));
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
					foreach (TheBaoHiemYTe deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (TheBaoHiemYTe child in this)
					{
						if (child.IsNew)
                            child.Insert(tr, this);
						else
                            child.Update(tr, this);
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

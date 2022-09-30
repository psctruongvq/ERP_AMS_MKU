
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoHiemThatNghiepList : Csla.BusinessListBase<BaoHiemThatNghiepList, BaoHiemThatNghiep>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BaoHiemThatNghiep item = BaoHiemThatNghiep.NewBaoHiemThatNghiep();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private BaoHiemThatNghiepList()
		{ /* require use of factory method */ }

		public static BaoHiemThatNghiepList NewBaoHiemThatNghiepList()
		{
			return new BaoHiemThatNghiepList();
		}

		public static BaoHiemThatNghiepList GetBaoHiemThatNghiepList(int maBaoHiemThatNghiep, long maNhanVien)
		{
			return DataPortal.Fetch<BaoHiemThatNghiepList>(new FilterCriteria(maBaoHiemThatNghiep, maNhanVien));
		}
        public static BaoHiemThatNghiepList GetBaoHiemThatNghiepList(int maBoPhan)
        {
            return DataPortal.Fetch<BaoHiemThatNghiepList>(new FilterCriteriaByBoPhan(maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaBaoHiemThatNghiep;
			public long MaNhanVien;

			public FilterCriteria(int maBaoHiemThatNghiep, long maNhanVien)
			{
				this.MaBaoHiemThatNghiep = maBaoHiemThatNghiep;
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
                    cm.CommandText = "spd_SelecttblnsBaoHiemThatNghiepsAll";
                }
                else if(criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsBaoHiemThatNghiepByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteriaByBoPhan)criteria).MaBoPhan);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BaoHiemThatNghiep.GetBaoHiemThatNghiep(dr));
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
					foreach (BaoHiemThatNghiep deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BaoHiemThatNghiep child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
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

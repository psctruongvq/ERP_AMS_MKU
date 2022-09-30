
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class SoBaoHiemXaHoiList : Csla.BusinessListBase<SoBaoHiemXaHoiList, SoBaoHiemXaHoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			SoBaoHiemXaHoi item = SoBaoHiemXaHoi.NewSoBaoHiemXaHoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private SoBaoHiemXaHoiList()
		{ /* require use of factory method */ }

		public static SoBaoHiemXaHoiList NewSoBaoHiemXaHoiList()
		{
			return new SoBaoHiemXaHoiList();
		}

		public static SoBaoHiemXaHoiList GetSoBaoHiemXaHoiList(long maNhanVien)
		{
			return DataPortal.Fetch<SoBaoHiemXaHoiList>(new FilterCriteria(maNhanVien));
		}
        public static SoBaoHiemXaHoiList GetSoBaoHiemXaHoiListByBoPhan(int maBoPhan)
        {
            return DataPortal.Fetch<SoBaoHiemXaHoiList>(new FilterCriteriaByBoPhan(maBoPhan));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;

			public FilterCriteria(long maNhanVien)
			{
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
                    cm.CommandText = "spd_SelecttblnsSoBaoHiemXaHoisAll";                
                }
                else if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsSoBaoHiemXaHoiByBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan",((FilterCriteriaByBoPhan)criteria).MaBoPhan);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(dr));
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
					foreach (SoBaoHiemXaHoi deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (SoBaoHiemXaHoi child in this)
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

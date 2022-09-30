
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BHXH03AList : Csla.BusinessListBase<BHXH03AList, BHXH03A>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BHXH03A item = BHXH03A.NewBHXH03A();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private BHXH03AList()
		{ /* require use of factory method */ }

		public static BHXH03AList NewBHXH03AList()
		{
			return new BHXH03AList();
		}

		public static BHXH03AList GetBHXH03AList(int kyTinhBaoHiem, long maNhanVien, int maTheBHYT, int maSoBaoHiemXH)
		{
			return DataPortal.Fetch<BHXH03AList>(new FilterCriteria(kyTinhBaoHiem, maNhanVien, maTheBHYT, maSoBaoHiemXH));
		}
        public static BHXH03AList GetBHXH03AList_LapDanhSach(DateTime tuNgay,DateTime denNgay)
        {
            return DataPortal.Fetch<BHXH03AList>(new FilterCriteriaDS03ATam(tuNgay,denNgay));
        }
        public static BHXH03AList GetBHXH03AListByMaKyTinhBaoHiem(int maKyTinhBaoHiem)
        {
            return DataPortal.Fetch<BHXH03AList>(new FilterCriteriaDS03AByKyTinhBaoHiem(maKyTinhBaoHiem));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int KyTinhBaoHiem;
			public long MaNhanVien;
			public int MaTheBHYT;
			public int MaSoBaoHiemXH;

			public FilterCriteria(int kyTinhBaoHiem, long maNhanVien, int maTheBHYT, int maSoBaoHiemXH)
			{
				this.KyTinhBaoHiem = kyTinhBaoHiem;
				this.MaNhanVien = maNhanVien;
				this.MaTheBHYT = maTheBHYT;
				this.MaSoBaoHiemXH = maSoBaoHiemXH;
			}
		}
        private class FilterCriteriaDS03ATam
        {
           
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaDS03ATam(DateTime tuNgay,DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }
        private class FilterCriteriaDS03AByKyTinhBaoHiem
        {

            public int maKyTinhBaoHiem;
            public FilterCriteriaDS03AByKyTinhBaoHiem(int _maKyTinhBaoHiem)
            {
                this.maKyTinhBaoHiem = _maKyTinhBaoHiem;
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
                    cm.CommandText = "spd_SelecttblnsBHXH03AsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH03A.GetBHXH03A(dr));
                    }
                }
                else if (criteria is FilterCriteriaDS03ATam)
                {
                    cm.CommandText = "spd_DanhSachLap03ATBH";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaDS03ATam)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaDS03ATam)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH03A.GetBHXH03AGetDS(dr));
                    }
                }
                else if (criteria is FilterCriteriaDS03AByKyTinhBaoHiem)
                {
                    cm.CommandText = "spd_SelecttblnsBHXH03AByKyTinhBaoHiem";
                    cm.Parameters.AddWithValue("@KyTinhBaoHiem", ((FilterCriteriaDS03AByKyTinhBaoHiem)criteria).maKyTinhBaoHiem);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH03A.GetBHXH03A(dr));
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
					foreach (BHXH03A deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BHXH03A child in this)
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

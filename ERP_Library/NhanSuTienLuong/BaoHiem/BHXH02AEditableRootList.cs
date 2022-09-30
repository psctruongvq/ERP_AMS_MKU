
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BHXH02AList : Csla.BusinessListBase<BHXH02AList, BHXH02A>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			BHXH02A item = BHXH02A.NewBHXH02A();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private BHXH02AList()
		{ /* require use of factory method */ }

		public static BHXH02AList NewBHXH02AList()
		{
			return new BHXH02AList();
		}

		public static BHXH02AList GetBHXH02AList(int kyTinhBaoHiem, long maNhanVien, int maTheBHYT, int maSoBaoHiemXH)
		{
			return DataPortal.Fetch<BHXH02AList>(new FilterCriteria(kyTinhBaoHiem, maNhanVien, maTheBHYT, maSoBaoHiemXH));
		}
        public static BHXH02AList GetBHXH02AList(int kyTinhBaoHiem)
        {
            return DataPortal.Fetch<BHXH02AList>(new FilterCriteriaByMaKy(kyTinhBaoHiem));
        }
        public static  BHXH02AList BHXH02AListGetDanhSachLapByTuNgayDenNgay (DateTime tuNgay,DateTime denNgay)
        {
            return DataPortal.Fetch<BHXH02AList>(new FilterCriteriaDanhSachLapByTuNgayDenNgay(tuNgay,denNgay));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]

        private class FilterCriteriaByMaKy
        {
            public int KyTinhBaoHiem;

            public FilterCriteriaByMaKy(int kyTinhBaoHiem)
            {
                this.KyTinhBaoHiem = kyTinhBaoHiem;

            }
        }
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
        private class FilterCriteriaDanhSachLapByTuNgayDenNgay
        {

            public DateTime _tuNgay;
            public DateTime _denNgay;

            public FilterCriteriaDanhSachLapByTuNgayDenNgay(DateTime tuNgay,DateTime denNgay)
            {
                this._tuNgay = tuNgay;
                this._denNgay = denNgay;
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
                    cm.CommandText = "spd_SelecttblnsBHXH02AsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH02A.GetBHXH02A(dr));
                    }
                }
                if (criteria is FilterCriteriaByMaKy)
                {
                    cm.CommandText = "spd_SelecttblnsBHXH02ByMaKyTinhBaoHiem";
                    cm.Parameters.AddWithValue("@MaKyTinhBaoHiem",((FilterCriteriaByMaKy)criteria).KyTinhBaoHiem);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH02A.GetBHXH02A(dr));
                    }
                }
                else if (criteria is FilterCriteriaDanhSachLapByTuNgayDenNgay)
                {
                    cm.CommandText = "spd_DanhSachLap02ATBH";
                    cm.Parameters.AddWithValue("@TuNgay",((FilterCriteriaDanhSachLapByTuNgayDenNgay)criteria)._tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaDanhSachLapByTuNgayDenNgay)criteria)._denNgay);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(BHXH02A.GetDSLap2ATBH(dr));
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
					foreach (BHXH02A deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (BHXH02A child in this)
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

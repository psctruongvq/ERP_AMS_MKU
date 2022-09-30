using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLaoNhanVienNgoaiDaiList : Csla.BusinessListBase<PhanBoThuLaoNhanVienNgoaiDaiList, PhanBoThuLaoNhanVienNgoaiDai>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhanBoThuLaoNhanVienNgoaiDai item = PhanBoThuLaoNhanVienNgoaiDai.NewPhanBoThuLaoNhanVienNgoaiDai();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLaoNhanVienNgoaiDaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLaoNhanVienNgoaiDaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLaoNhanVienNgoaiDaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLaoNhanVienNgoaiDaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienNgoaiDaiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLaoNhanVienNgoaiDaiList()
		{ /* require use of factory method */ }

		public static PhanBoThuLaoNhanVienNgoaiDaiList NewPhanBoThuLaoNhanVienNgoaiDaiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVienNgoaiDaiList");
			return new PhanBoThuLaoNhanVienNgoaiDaiList();
		}

		public static PhanBoThuLaoNhanVienNgoaiDaiList GetPhanBoThuLaoNhanVienNgoaiDaiList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVienNgoaiDaiList");
			return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDaiList>(new FilterCriteria());
		}

        public static PhanBoThuLaoNhanVienNgoaiDaiList GetPhanBoThuLaoNhanVienNgoaiDaiListByBoPhan(int maBoPhan, int maCongViec, long maPhanBoThuLao, bool daDuyet, string dienGiai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVienNgoaiDaiList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByBoPhan(maBoPhan, maCongViec, maPhanBoThuLao, daDuyet, dienGiai));
        }


        public static PhanBoThuLaoNhanVienNgoaiDaiList GetPhanBoThuLaoNhanVienNgoaiDaiListByNgayLap(DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByNgayLap(tuNgay, denNgay));
        }

        public static PhanBoThuLaoNhanVienNgoaiDaiList GetPhanBoThuLaoNhanVienNgoaiDaiListByPhanBoThuLao(int maPhanBoThuLao,long maChiTietPhanBoThuLao, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienNgoaiDaiList>(new FilterCriteriaByPhanBoThuLao(maPhanBoThuLao, maChiTietPhanBoThuLao,ngayLap));
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

        private class FilterCriteriaByPhanBoThuLao
        {
            public int _maPhanBoThuLao;
            public long _maChiTietPhanBoThuLao;
            public DateTime _ngayLap;

            public FilterCriteriaByPhanBoThuLao(int maPhanBoThuLao,long maChiTietPhanBoThuLao, DateTime ngayLap)
            {
                _maPhanBoThuLao = maPhanBoThuLao;
                _maChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
                _ngayLap = ngayLap;
            }
        }


        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;

            public FilterCriteriaByNgayLap(DateTime tuNgay, DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
            }
        }

        private class FilterCriteriaByBoPhan
        {
            public int _maBoPhan;
            public int _maCongViec;
            public long _maPhanBoThuLao;
            public bool _daDuyet;
            public string _dienGiai;

            public FilterCriteriaByBoPhan(int maBoPhan, int maCongViec, long maPhanBoThuLao,bool daDuyet, string dienGiai)
            {
                _maBoPhan = maBoPhan;
                _maCongViec = maCongViec;
                _maPhanBoThuLao = maPhanBoThuLao;
                _daDuyet = daDuyet;
                _dienGiai = dienGiai;
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
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDaisAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVienNgoaiDai.GetPhanBoThuLaoNhanVienNgoaiDai(dr));
                    }
                }//using
            }

            if (criteria is FilterCriteriaByPhanBoThuLao)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDaisAllByPhanBoThuLao";

                    cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByPhanBoThuLao)criteria)._maPhanBoThuLao);
                    cm.Parameters.Add("@MaChiTietPhanBoThuLao", ((FilterCriteriaByPhanBoThuLao)criteria)._maChiTietPhanBoThuLao);
                    cm.Parameters.Add("@NgayLap", ((FilterCriteriaByPhanBoThuLao)criteria)._ngayLap);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVienNgoaiDai.GetPhanBoThuLaoNhanVienNgoaiDai(dr));
                    }
                }//using
            }

            if(criteria is FilterCriteriaByBoPhan)
            {
             using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDaisAllByBoPhan";

                    cm.Parameters.Add("@MaCongViec", ((FilterCriteriaByBoPhan)criteria)._maCongViec);
                    cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByBoPhan)criteria)._maPhanBoThuLao);
                    cm.Parameters.Add("@MaBoPhan", ((FilterCriteriaByBoPhan)criteria)._maBoPhan);
                    cm.Parameters.Add("@DaDuyet", ((FilterCriteriaByBoPhan)criteria)._daDuyet);
                    cm.Parameters.Add("@DienGiai", ((FilterCriteriaByBoPhan)criteria)._dienGiai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVienNgoaiDai.GetPhanBoThuLaoNhanVienNgoaiDai(dr));
                    }
                }//using
            }

            if (criteria is FilterCriteriaByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoNhanVienNgoaiDaisAllByNgayLap";

                    cm.Parameters.Add("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVienNgoaiDai.GetPhanBoThuLaoNhanVienNgoaiDai(dr));
                    }
                }//using
            }
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
					foreach (PhanBoThuLaoNhanVienNgoaiDai deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhanBoThuLaoNhanVienNgoaiDai child in this)
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


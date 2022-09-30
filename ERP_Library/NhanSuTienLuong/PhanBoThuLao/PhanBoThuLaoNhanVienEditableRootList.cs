using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLaoNhanVienList : Csla.BusinessListBase<PhanBoThuLaoNhanVienList, PhanBoThuLaoNhanVien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhanBoThuLaoNhanVien item = PhanBoThuLaoNhanVien.NewPhanBoThuLaoNhanVien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLaoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLaoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLaoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLaoNhanVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoNhanVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLaoNhanVienList()
		{ /* require use of factory method */ }

		public static PhanBoThuLaoNhanVienList NewPhanBoThuLaoNhanVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoNhanVienList");
			return new PhanBoThuLaoNhanVienList();
		}

		public static PhanBoThuLaoNhanVienList GetPhanBoThuLaoNhanVienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoNhanVienList");
			return DataPortal.Fetch<PhanBoThuLaoNhanVienList>(new FilterCriteria());
		}

        public static PhanBoThuLaoNhanVienList GetPhanBoThuLaoNhanVienListByPhanBoThuLao(int maPhanBoThuLao ,long maChiTietPhanBoThuLao, DateTime ngayLap)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienList>(new FilterCriteriaByPhanBoThuLao(maPhanBoThuLao, maChiTietPhanBoThuLao,ngayLap));
        }

        public static PhanBoThuLaoNhanVienList GetPhanBoThuLaoNhanVienListByNgayLap(int maPhanBoThuLao, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienList>(new FilterCriteriaByNgayLap(maPhanBoThuLao,maBoPhan));
        }

        public static PhanBoThuLaoNhanVienList GetPhanBoThuLaoNhanVienListByBoPhan(int maBoPhan, int maCongViec, long maPhanBoThuLao, bool daDuyet,  string dienGiai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoNhanVienList>(new FilterCriteriaByBoPhan(maBoPhan, maCongViec, maPhanBoThuLao, daDuyet, dienGiai));
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

            public FilterCriteriaByPhanBoThuLao(int maPhanBoThuLao, long maChiTietPhanBoThuLao, DateTime ngayLap)
            {
                _maPhanBoThuLao = maPhanBoThuLao;
                _maChiTietPhanBoThuLao=maChiTietPhanBoThuLao;
                _ngayLap = ngayLap;
            }
        }

        private class FilterCriteriaByNgayLap
        {
            public int _maPhanBoThuLao;
            public int _maBoPhan;

            public FilterCriteriaByNgayLap(int maPhanBoThuLao,int maBoPhan)
            {
                _maPhanBoThuLao = maPhanBoThuLao;
                _maBoPhan = maBoPhan;
            }
        }

        private class FilterCriteriaByBoPhan
        {
            public int _maCongViec;
            public long _maPhanBoThuLao;
            public int _maBoPhan;
            public bool _daDuyet;
            public string _dienGiai;

            public FilterCriteriaByBoPhan(int maBoPhan,int maCongViec, long maPhanBoThuLao, bool daDuyet, string dienGiai)
            {
                _maCongViec = maCongViec;
                _maPhanBoThuLao = maPhanBoThuLao;
                _maBoPhan = maBoPhan;
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
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinhsAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVien.GetPhanBoThuLaoNhanVien(dr));
                    }
                }//using
            }

            if (criteria is FilterCriteriaByPhanBoThuLao)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinhsAllByPhanBoThuLao";

                    cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByPhanBoThuLao)criteria)._maPhanBoThuLao);
                    cm.Parameters.Add("@MaChiTietPhanBoThuLao", ((FilterCriteriaByPhanBoThuLao)criteria)._maChiTietPhanBoThuLao);
                    cm.Parameters.Add("@NgayLap", ((FilterCriteriaByPhanBoThuLao)criteria)._ngayLap);
                   // cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVien.GetPhanBoThuLaoNhanVien(dr));
                    }
                }//using
            }

            if (criteria is FilterCriteriaByNgayLap)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinhsAllByNgayLap";

                    cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByNgayLap)criteria)._maPhanBoThuLao);
                    cm.Parameters.Add("@MaBoPhan", ((FilterCriteriaByNgayLap)criteria)._maBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVien.GetPhanBoThuLaoNhanVien(dr));
                    }
                }//using
            }

            if (criteria is FilterCriteriaByBoPhan)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoChuongTrinhsAllByBoPhan";

                    cm.Parameters.Add("@MaBoPhan", ((FilterCriteriaByBoPhan)criteria)._maBoPhan);
                    cm.Parameters.Add("@MaCongViec", ((FilterCriteriaByBoPhan)criteria)._maCongViec);
                    cm.Parameters.Add("@DaDuyet", ((FilterCriteriaByBoPhan)criteria)._daDuyet);
                    cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByBoPhan)criteria)._maPhanBoThuLao);
                    cm.Parameters.Add("@DienGiai", ((FilterCriteriaByBoPhan)criteria)._dienGiai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLaoNhanVien.GetPhanBoThuLaoNhanVien(dr));
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
					foreach (PhanBoThuLaoNhanVien deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhanBoThuLaoNhanVien child in this)
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



using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinUngVienList : Csla.BusinessListBase<ThongTinUngVienList, ThongTinUngVien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThongTinUngVien item = ThongTinUngVien.NewThongTinUngVien(0);

			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinUngVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinUngVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinUngVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinUngVienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinUngVienList()
		{ /* require use of factory method */ }

		public static ThongTinUngVienList NewThongTinUngVienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinUngVienList");
			return new ThongTinUngVienList();
		}
        public static ThongTinUngVienList GetThongTinUngVienList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVienList");
            return DataPortal.Fetch<ThongTinUngVienList>(new FilterCriteriaAll());
        }
		public static ThongTinUngVienList GetThongTinUngVienList(int noiCap, int trinhDoVanHoa, int trinhDoTayNghe, long maTuyenDung)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVienList");
			return DataPortal.Fetch<ThongTinUngVienList>(new FilterCriteria(noiCap, trinhDoVanHoa, trinhDoTayNghe, maTuyenDung));
		}
        public static ThongTinUngVienList GetThongTinUngVienListByMaTuyenDung( long maTuyenDung)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVienList");
            return DataPortal.Fetch<ThongTinUngVienList>(new FilterCriteriaMaTuyenDung(maTuyenDung));
        }
        public static ThongTinUngVienList GetThongTinUngVienListTrungTuyen( long maTuyenDung)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVienList");
            return DataPortal.Fetch<ThongTinUngVienList>(new FilterCriteriaMaTuyenDungByTrungTuyen(maTuyenDung));
        }
        public static ThongTinUngVienList GetThongTinUngVienListTrungTuyenByNgay(DateTime tuNgay,DateTime denNgay,int daChuyen)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVienList");
            return DataPortal.Fetch<ThongTinUngVienList>(new FilterCriteriaMaTuyenDungByTrungTuyenNgay(tuNgay,denNgay,daChuyen));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]

        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {

            }
        }
		private class FilterCriteria
		{
			public int NoiCap;
			public int TrinhDoVanHoa;
			public int TrinhDoTayNghe;
			public long MaTuyenDung;

			public FilterCriteria(int noiCap, int trinhDoVanHoa, int trinhDoTayNghe, long maTuyenDung)
			{
				this.NoiCap = noiCap;
				this.TrinhDoVanHoa = trinhDoVanHoa;
				this.TrinhDoTayNghe = trinhDoTayNghe;
				this.MaTuyenDung = maTuyenDung;
			}
		}

        private class FilterCriteriaMaTuyenDungByTrungTuyenNgay
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int DaChuyen;

            public FilterCriteriaMaTuyenDungByTrungTuyenNgay(DateTime tuNgay,DateTime denNgay,int daChuyen)
            {
                this.DaChuyen = daChuyen;

                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;

            }
        }
        private class FilterCriteriaMaTuyenDung
		{
			//public int NoiCap;
			//public int TrinhDoVanHoa;
			//public int TrinhDoTayNghe;
			public long MaTuyenDung;

            public FilterCriteriaMaTuyenDung(long maTuyenDung)
			{
				
				
				this.MaTuyenDung = maTuyenDung;
			}
		}
        private class FilterCriteriaMaTuyenDungByTrungTuyen
        {
            //public int NoiCap;
            //public int TrinhDoVanHoa;
            //public int TrinhDoTayNghe;
            public long MaTuyenDung;

            public FilterCriteriaMaTuyenDungByTrungTuyen(long maTuyenDung)
            {


                this.MaTuyenDung = maTuyenDung;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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
                if (criteria is FilterCriteriaMaTuyenDung)
                {
                    cm.CommandText = "sp_SelecttblnsThongTinUngVienByTuyenDung";
                    cm.Parameters.AddWithValue("@MaTuyenDung",((FilterCriteriaMaTuyenDung) criteria).MaTuyenDung);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "sp_SelecttblnsThongTinUngViensAll";
                    
                }
                else if (criteria is FilterCriteria)
                {
                    cm.CommandText = "sp_SelecttblnsThongTinUngVienByTuyenDung";
                    cm.Parameters.AddWithValue("@MaTuyenDung", 0);
                }
                else if (criteria is FilterCriteriaMaTuyenDungByTrungTuyen)
                {
                    cm.CommandText = "sp_SelecttblnsUngVienTrungTuyen";
                    cm.Parameters.AddWithValue("@MaTuyenDung", ((FilterCriteriaMaTuyenDungByTrungTuyen)criteria).MaTuyenDung);
                }
                else if (criteria is FilterCriteriaMaTuyenDungByTrungTuyenNgay)
                {
                    cm.CommandText = "sp_SelecttblnsUngVienTrungTuyenByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaMaTuyenDungByTrungTuyenNgay)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaMaTuyenDungByTrungTuyenNgay)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@DaChuyen", ((FilterCriteriaMaTuyenDungByTrungTuyenNgay)criteria).DaChuyen);
                }
                
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ThongTinUngVien.GetThongTinUngVien(dr));
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
					foreach (ThongTinUngVien deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ThongTinUngVien child in this)
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

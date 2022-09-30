using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLaoList : Csla.BusinessListBase<PhanBoThuLaoList, PhanBoThuLao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhanBoThuLao item = PhanBoThuLao.NewPhanBoThuLao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLaoList()
		{ /* require use of factory method */
          
        }

        public static PhanBoThuLaoList GetPhanBoThuLaoList_BoPhan(int maBoPhan, int loai)
        {
            return DataPortal.Fetch<PhanBoThuLaoList>(new FilterCriteria_BoPhan(maBoPhan,loai));
        }

        public static PhanBoThuLaoList GetPhanBoThuLaoList_BoPhan(int maBoPhan,int maPhanBoThuLao ,long maChiTietPhanBo,int loai)
        {
            return DataPortal.Fetch<PhanBoThuLaoList>(new FilterCriteria_BoPhan_PhanBoThuLao(maBoPhan, maPhanBoThuLao,maChiTietPhanBo, loai));
        }

		public static PhanBoThuLaoList NewPhanBoThuLaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLaoList");
			return new PhanBoThuLaoList();
		}

		public static PhanBoThuLaoList GetPhanBoThuLaoList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
			return DataPortal.Fetch<PhanBoThuLaoList>(new FilterCriteria());
		}

        public static PhanBoThuLaoList GetPhanBoThuLaoListByNgayLap(DateTime tuNgay, DateTime denNgay, int userID,int loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoList>(new FilterCriteriaByNgayLap(tuNgay, denNgay, userID, loai));
        }

        public static PhanBoThuLaoList GetPhanBoThuLaoListByNgayLap_MaPhanBoThuLao(DateTime tuNgay, DateTime denNgay, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLaoList");
            return DataPortal.Fetch<PhanBoThuLaoList>(new FilterCriteriaByNgayLap_MaPhanBoThuLao(tuNgay, denNgay, maBoPhan));
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

        private class FilterCriteriaByNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int UserID;
            public int Loai;

            public FilterCriteriaByNgayLap(DateTime tuNgay, DateTime denNgay,int userID,int loai)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                UserID = userID;
                Loai = loai;
            }
        }

        private class FilterCriteriaByNgayLap_MaPhanBoThuLao
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int MaBoPhan;

            public FilterCriteriaByNgayLap_MaPhanBoThuLao(DateTime tuNgay, DateTime denNgay, int maBoPhan)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                MaBoPhan = maBoPhan;
            }
        }

        private class FilterCriteria_BoPhan
        {
            public int MaBoPhan;
            public int Loai;

            public FilterCriteria_BoPhan(int maBoPhan, int loai)
            {
                this.MaBoPhan = maBoPhan;
                this.Loai = loai;
            }
        }

        private class FilterCriteria_BoPhan_PhanBoThuLao
        {
            public int MaBoPhan;
            public int Loai;
            public int MaPhanBoThuLao;
            public long MaChiTietPhanBo;

            public FilterCriteria_BoPhan_PhanBoThuLao(int maBoPhan,int maPhanBoThuLao,long maChiTietPhanBo, int loai)
            {
                this.MaBoPhan = maBoPhan;
                this.MaPhanBoThuLao = maPhanBoThuLao;
                this.Loai = loai;
                this.MaChiTietPhanBo = maChiTietPhanBo;
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
                if (criteria is FilterCriteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaosAll";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLao.GetPhanBoThuLao(dr));
                    }
                }

                if (criteria is FilterCriteria_BoPhan)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLao_MaBoPhan";
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_BoPhan)criteria).Loai);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLao.GetPhanBoThuLao(dr,1));
                    }
                }

                if (criteria is FilterCriteria_BoPhan_PhanBoThuLao)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLao_MaBoPhan_PhanBoThuLao";
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", ((FilterCriteria_BoPhan_PhanBoThuLao)criteria).MaPhanBoThuLao);
                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", ((FilterCriteria_BoPhan_PhanBoThuLao)criteria).MaChiTietPhanBo);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_BoPhan_PhanBoThuLao)criteria).Loai);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLao.GetPhanBoThuLao(dr,1));
                    }
                }

                if (criteria is FilterCriteriaByNgayLap)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaosAllByNgayLap";

                    cm.Parameters.Add("@TuNgay", ((FilterCriteriaByNgayLap)criteria).TuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaByNgayLap)criteria).DenNgay);
                    cm.Parameters.Add("@UserID", ((FilterCriteriaByNgayLap)criteria).UserID);
                    cm.Parameters.Add("@Loai", ((FilterCriteriaByNgayLap)criteria).Loai);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLao.GetPhanBoThuLao(dr));
                    }
                }

                if (criteria is FilterCriteriaByNgayLap_MaPhanBoThuLao)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaosAllByNgayLap_MaPhanBoThuLao";

                    cm.Parameters.Add("@TuNgay", ((FilterCriteriaByNgayLap_MaPhanBoThuLao)criteria).TuNgay);
                    cm.Parameters.Add("@DenNgay", ((FilterCriteriaByNgayLap_MaPhanBoThuLao)criteria).DenNgay);
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhanBoThuLao.GetPhanBoThuLao(dr));
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
					foreach (PhanBoThuLao deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhanBoThuLao child in this)
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


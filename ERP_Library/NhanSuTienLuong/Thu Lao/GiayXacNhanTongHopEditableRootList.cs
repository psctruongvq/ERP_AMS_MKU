using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayXacNhanTongHopList : Csla.BusinessListBase<GiayXacNhanTongHopList, GiayXacNhanTongHop>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GiayXacNhanTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GiayXacNhanTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GiayXacNhanTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GiayXacNhanTongHopList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayXacNhanTongHopListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GiayXacNhanTongHopList()
		{ /* require use of factory method */ }

		public static GiayXacNhanTongHopList NewGiayXacNhanTongHopList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayXacNhanTongHopList");
			return new GiayXacNhanTongHopList();
		}


		public static GiayXacNhanTongHopList GetGiayXacNhanTongHopListByBoPhanDen(int maBoPhanDen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHopList");
			return DataPortal.Fetch<GiayXacNhanTongHopList>(new FilterCriteria(maBoPhanDen));
		}

        public static GiayXacNhanTongHopList GetGiayXacNhanTongHopListByBoPhanDen_DaNhapPhanBoThuLao(int maBoPhanDen, int bien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHopList");
            return DataPortal.Fetch<GiayXacNhanTongHopList>(new FilterCriteria_DaNhapPhanBoThuLao(maBoPhanDen, bien));
        }

        public static GiayXacNhanTongHopList GetGiayXacNhanTongHopList(int maBoPhanDen)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHopList");
            return DataPortal.Fetch<GiayXacNhanTongHopList>(new FilterCriteriaByBoPhan(maBoPhanDen));
        }

        public static GiayXacNhanTongHopList GetGiayXacNhanTongHopListByBoPhanDen(int maBoPhanDen, int maPhanBoThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a GiayXacNhanTongHopList");
            return DataPortal.Fetch<GiayXacNhanTongHopList>(new FilterCriteriaByPhanBoThuLao(maBoPhanDen,maPhanBoThuLao));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int _maBoPhanDen;

			public FilterCriteria(int maBoPhanDen)
			{
                _maBoPhanDen = maBoPhanDen;
			}
		}

        private class FilterCriteria_DaNhapPhanBoThuLao
        {
            public int _maBoPhanDen;
            public int _bien;

            public FilterCriteria_DaNhapPhanBoThuLao(int maBoPhanDen, int bien)
            {
                _maBoPhanDen = maBoPhanDen;
                _bien = bien;
            }
        }

        private class FilterCriteriaByBoPhan
        {
            public int _maBoPhanDen;

            public FilterCriteriaByBoPhan(int maBoPhanDen)
            {
                _maBoPhanDen = maBoPhanDen;
            }
        }

        private class FilterCriteriaByPhanBoThuLao
        {
            public int _maBoPhanDen;
            public int _maPhanBoThuLao;

            public FilterCriteriaByPhanBoThuLao(int maBoPhanDen, int maPhanBoThuLao)
            {
                _maBoPhanDen = maBoPhanDen;
                _maPhanBoThuLao=maPhanBoThuLao;
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
                if(criteria is FilterCriteria)
                {
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsGiayXacNhanTongHopByBoPhan";

                cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria)._maBoPhanDen);
                }

                if (criteria is FilterCriteria_DaNhapPhanBoThuLao)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanTongHopByBoPhan_DaNhapPhanBoThuLao";

                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_DaNhapPhanBoThuLao)criteria)._maBoPhanDen);
                    cm.Parameters.AddWithValue("@Bien", ((FilterCriteria_DaNhapPhanBoThuLao)criteria)._bien);
      
                }

                if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsGiayXacNhanTongHopsAll";

                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByBoPhan)criteria)._maBoPhanDen);
                }

                if(criteria is FilterCriteriaByPhanBoThuLao)
                {
                cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsGiayXacNhanTongHopByBoPhanAndPhanBoThuLao";

                cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByPhanBoThuLao)criteria)._maBoPhanDen);
                cm.Parameters.Add("@MaPhanBoThuLao", ((FilterCriteriaByPhanBoThuLao)criteria)._maPhanBoThuLao);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(GiayXacNhanTongHop.GetGiayXacNhanTongHop(dr));
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
					foreach (GiayXacNhanTongHop deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (GiayXacNhanTongHop child in this)
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


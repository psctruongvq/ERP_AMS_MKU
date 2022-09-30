
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanTramHoaHongList : Csla.BusinessListBase<PhanTramHoaHongList, PhanTramHoaHong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanTramHoaHongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanTramHoaHongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanTramHoaHongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanTramHoaHongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanTramHoaHongList()
		{ /* require use of factory method */ }

		public static PhanTramHoaHongList NewPhanTramHoaHongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanTramHoaHongList");
			return new PhanTramHoaHongList();
		}

		public static PhanTramHoaHongList GetPhanTramHoaHongList(int maLoaiHangHoa)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanTramHoaHongList");
			return DataPortal.Fetch<PhanTramHoaHongList>(new FilterCriteria(maLoaiHangHoa));
		}
        public static PhanTramHoaHongList GetPhanTramHoaHongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanTramHoaHongList");
            return DataPortal.Fetch<PhanTramHoaHongList>(new FilterCriteriaAll());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaLoaiHangHoa;

			public FilterCriteria(int maLoaiHangHoa)
			{
				this.MaLoaiHangHoa = maLoaiHangHoa;
			}
		}

        private class FilterCriteriaAll
        {         
            public FilterCriteriaAll()
            {            
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblPhanTramHoaHongsByMaLoaiHangHoa";
                    cm.Parameters.AddWithValue("@MaLoaiHangHoa", ((FilterCriteria)criteria).MaLoaiHangHoa);
                }
                else if(criteria is FilterCriteriaAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblPhanTramHoaHongsAll";                    
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(PhanTramHoaHong.GetPhanTramHoaHong(dr));
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
					foreach (PhanTramHoaHong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhanTramHoaHong child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(SqlException ex)
				{
					tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

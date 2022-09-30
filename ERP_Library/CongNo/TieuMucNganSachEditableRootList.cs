
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TieuMucNganSachList : Csla.BusinessListBase<TieuMucNganSachList, TieuMucNganSach>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			TieuMucNganSach item = TieuMucNganSach.NewTieuMucNganSach();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TieuMucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TieuMucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TieuMucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TieuMucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TieuMucNganSachList()
		{ /* require use of factory method */ }

		public static TieuMucNganSachList NewTieuMucNganSachList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuMucNganSachList");
			return new TieuMucNganSachList();
		}

		public static TieuMucNganSachList GetTieuMucNganSachList(int maMucNganSach)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TieuMucNganSachList");
			return DataPortal.Fetch<TieuMucNganSachList>(new FilterCriteria(maMucNganSach));
		}
        public static TieuMucNganSachList GetTieuMucNganSachListByNhieuMaMuc(string multiMucNganSachStr)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TieuMucNganSachList");
            return DataPortal.Fetch<TieuMucNganSachList>(new FilterCriteriaByNhieuMaMuc(multiMucNganSachStr));
        }
        public static TieuMucNganSachList GetTieuMucNganSachList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TieuMucNganSachList");
            return DataPortal.Fetch<TieuMucNganSachList>(new FilterCriteriaAll());
        }

        public static int LayTongTienMucNganSach()
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TongTienMucNganSach";
                        cm.Parameters["@TongTien"].Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@TongTien"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }

        public static int LayTongTienTieuMucNganSach()
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TongTienTieuMucNganSach";
                        cm.Parameters["@TongTien"].Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@TongTien"].Value;

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        

		private class FilterCriteria
		{
			public int MaMucNganSach;

			public FilterCriteria(int maMucNganSach)
			{
				this.MaMucNganSach = maMucNganSach;
			}
		}
        private class FilterCriteriaByNhieuMaMuc
		{
			public string MaMucNganSach;

            public FilterCriteriaByNhieuMaMuc(string maMucNganSach)
			{
                this.MaMucNganSach = maMucNganSach;
			}
		}
        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is FilterCriteriaAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTieuMucNganSachesAll";
                }
                else if(criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTieuMucNganSachesAll_All";
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteria)criteria).MaMucNganSach);
                }
                else if (criteria is FilterCriteriaByNhieuMaMuc)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTieuMucNganSachByNhieuMuc";
                    cm.Parameters.AddWithValue("@MaMucNganSach", ((FilterCriteriaByNhieuMaMuc)criteria).MaMucNganSach);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(TieuMucNganSach.GetTieuMucNganSach(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (TieuMucNganSach deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (TieuMucNganSach child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

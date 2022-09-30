
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TaiKhoanList : Csla.BusinessListBase<ChungTu_TaiKhoanList, ChungTu_TaiKhoan>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_TaiKhoanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_TaiKhoanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_TaiKhoanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_TaiKhoanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_TaiKhoanList()
		{ /* require use of factory method */ }

		public static ChungTu_TaiKhoanList NewChungTu_TaiKhoanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_TaiKhoanList");
			return new ChungTu_TaiKhoanList();
		}

		public static ChungTu_TaiKhoanList GetChungTu_TaiKhoanList(long maChungTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTu_TaiKhoanList");
			return DataPortal.Fetch<ChungTu_TaiKhoanList>(new FilterCriteria(maChungTu));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaChungTu;

			public FilterCriteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblcnChungTu_TaiKhoan";
				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTu_TaiKhoan.GetChungTu_TaiKhoan(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch

		#region Data Access - Update
        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each non-deleted child object
                foreach (ChungTu_TaiKhoan child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr);
                    else
                        child.Update(tr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

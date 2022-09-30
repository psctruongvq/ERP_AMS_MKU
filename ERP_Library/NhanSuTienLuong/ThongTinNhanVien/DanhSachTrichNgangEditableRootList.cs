using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 

	[Serializable()] 
	public class TrichNgangList : Csla.BusinessListBase<TrichNgangList, TrichNgang>
	{
		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrichNgangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrichNgangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrichNgangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrichNgangList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
        private TrichNgangList()
		{ /* require use of factory method */ }

        public static TrichNgangList NewTrichNgangList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrichNgangList");
            return new TrichNgangList();
		}

        public static TrichNgangList GetDanhSachTrichNgang(string DieuKien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TrichNgangList");
            return DataPortal.Fetch<TrichNgangList>(new FilterCriteria_TrichNgang(DieuKien));
        }    
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria_TrichNgang
		{
            public string dieuKienTim;
            public FilterCriteria_TrichNgang(string dieuKienTim)
			{
                this.dieuKienTim = dieuKienTim;
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
              using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (criteria is FilterCriteria_TrichNgang)
                    {
                        cm.CommandText = "[spd_DanhSachNhanVien_TrichNgang]";
                        cm.Parameters.AddWithValue("@dieuKienTim", ((FilterCriteria_TrichNgang)criteria).dieuKienTim);
                    }
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(TrichNgang.GetTrichNgang(dr));
                    }
                }//using           
		}
		#endregion //Data Access - Fetch

		#region Data Access - Update
        /*
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (TrichNgang deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (TrichNgang child in this)
				{
					if (child.IsNew)
						child.Insert(cn);
					else
						child.Update(cn);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
        */
		#endregion //Data Access - Update
    
		#endregion //Data Access
	}
}

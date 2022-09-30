
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DSPhieuNhapXuatList : Csla.BusinessListBase<DSPhieuNhapXuatList, DSPhieuNhapXuat>
	{
        public long _MaChungTu = 0;

		#region BindingList Overrides
		protected override object AddNewCore()
		{
			DSPhieuNhapXuat item = DSPhieuNhapXuat.NewDSPhieuNhapXuat();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DSPhieuNhapXuatList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DSPhieuNhapXuatList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DSPhieuNhapXuatList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DSPhieuNhapXuatList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSPhieuNhapXuatListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DSPhieuNhapXuatList()
		{ /* require use of factory method */ }

		public static DSPhieuNhapXuatList NewDSPhieuNhapXuatList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSPhieuNhapXuatList");
			return new DSPhieuNhapXuatList();
		}

		public static DSPhieuNhapXuatList GetDSPhieuNhapXuatList_NhapMuaHang(long MaKhachHang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DSPhieuNhapXuatList");
			return DataPortal.Fetch<DSPhieuNhapXuatList>(new FilterCriteria_NhapMuaHang(MaKhachHang));
		}

        public static DSPhieuNhapXuatList GetDSPhieuNhapXuatList_NhapHangTraLai(long MaKhachHang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DSPhieuNhapXuatList");
            return DataPortal.Fetch<DSPhieuNhapXuatList>(new FilterCriteria_NhapHangTraLai(MaKhachHang));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria_NhapMuaHang
		{
            public long MaKhachHang;
            public FilterCriteria_NhapMuaHang(long maKhachHang)
			{
                this.MaKhachHang = maKhachHang;
			}
		}
        private class FilterCriteria_NhapHangTraLai
        {
            public long MaKhachHang;
            public FilterCriteria_NhapHangTraLai(long maKhachHang)
            {
                this.MaKhachHang = maKhachHang;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, Object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is FilterCriteria_NhapMuaHang)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DSPhieuNhapXuat_NhapMuaHang";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteria_NhapMuaHang)criteria).MaKhachHang);
                }
                else if (criteria is FilterCriteria_NhapHangTraLai)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DSPhieuNhapXuat_NhapHangTraLai";
                    cm.Parameters.AddWithValue("@MaKhachHang", ((FilterCriteria_NhapHangTraLai)criteria).MaKhachHang);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(DSPhieuNhapXuat.GetDSPhieuNhapXuat(dr));
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
                foreach (DSPhieuNhapXuat child in this)
                {
                    if(!child.IsNew)
                        child.Update(tr, this);
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

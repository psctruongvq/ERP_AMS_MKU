using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgachLuongCoBanList : Csla.BusinessListBase<NgachLuongCoBanList, NgachLuongCoBan>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NgachLuongCoBan item = NgachLuongCoBan.NewNgachLuongCoBan();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgachLuongCoBanList()
		{ /* require use of factory method */ }

		public static NgachLuongCoBanList NewNgachLuongCoBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgachLuongCoBanList");
			return new NgachLuongCoBanList();
		}

		public static NgachLuongCoBanList GetNgachLuongCoBanList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgachLuongCoBanList");
			return DataPortal.Fetch<NgachLuongCoBanList>(new FilterCriteria());
		}

        public static NgachLuongCoBanList GetNgachLuongCoBanListByNhomNgach(int maNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NgachLuongCoBanList");
            return DataPortal.Fetch<NgachLuongCoBanList>(new FilterCriteriaByNhomNgach(maNhom));
        }
        public static NgachLuongCoBanList GetNgachLuongCoBanListByChucVu(int machucvu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NgachLuongCoBanList");
            return DataPortal.Fetch<NgachLuongCoBanList>(new FilterCriteriaByChucVu(machucvu));
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

        private class FilterCriteriaByChucVu
        {
            public int Machucvu;
            public FilterCriteriaByChucVu(int machucvu)
            {
                this.Machucvu = machucvu;
            }
        }
        private class FilterCriteriaByNhomNgach
        {
            public int MaNhomNgachLuongCoBan;
            public FilterCriteriaByNhomNgach(int _MaNhomNgachLuongCoBan)
            {
                this.MaNhomNgachLuongCoBan = _MaNhomNgachLuongCoBan;
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
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsNgachLuongCoBansAll";
                }
                else if (criteria is FilterCriteriaByChucVu)
                {
                    cm.CommandText = "spd_SelecttblnsNgachLuongCoBansByChuCVu";
                    cm.Parameters.AddWithValue("@MaChucVu",((FilterCriteriaByChucVu)criteria).Machucvu);
                }
                 else if (criteria is FilterCriteriaByNhomNgach)
                {
                    cm.CommandText = "spd_SelecttblnsNgachLuongCoBansByNhomNgach";
                    cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", ((FilterCriteriaByNhomNgach)criteria).MaNhomNgachLuongCoBan);
                }
                

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NgachLuongCoBan.GetNgachLuongCoBan(dr));
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
                try
                {
                    // loop through each deleted child object
                    foreach (NgachLuongCoBan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (NgachLuongCoBan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn, this);
                        else
                            child.Update(cn, this);
                    }
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

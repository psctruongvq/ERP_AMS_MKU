
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChucVuList : Csla.BusinessListBase<ChucVuList, ChucVu>
	{
		#region BindingList Overrides
        protected override object AddNewCore()
        {
            ChucVu item = ChucVu.NewChucVu();
            this.Add(item);
            return item;
        }
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChucVuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChucVuList()
		{ /* require use of factory method */ }

		public static ChucVuList NewChucVuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChucVuList");
			return new ChucVuList();
		}

		public static ChucVuList GetChucVuList(int maNhomChucVu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChucVuList");
			return DataPortal.Fetch<ChucVuList>(new FilterCriteria(maNhomChucVu));
		}

        public static ChucVuList GetChucVuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChucVuList");
            return DataPortal.Fetch<ChucVuList>(new FilterCriteriaAll());
        }
        public static ChucVuList GetChucVuList(long maNhanVien,int gt)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChucVuList");
            return DataPortal.Fetch<ChucVuList>(new FilterCriteriaByMaNV(maNhanVien,gt));
        }
        public static ChucVuList GetChucVuListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChucVuList");
            return DataPortal.Fetch<ChucVuList>(new FilterCriteriaAll());
        }
        public static ChucVuList GetChucVuListForQuyHoach()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChucVuList");
            return DataPortal.Fetch<ChucVuList>(new FilterCriteriaForQuyHoach());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public int MaNhomChucVu;

			public FilterCriteria(int maNhomChucVu)
			{
				this.MaNhomChucVu = maNhomChucVu;
			}
        }
        private class FilterCriteriaByMaNV
        {
            public long maNhanVien;
            public int gt;
            public FilterCriteriaByMaNV(long maNV,int gt)
            {
                this.maNhanVien = maNV;
                this.gt = gt;
            }
        }
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {

            }
        }

        private class FilterCriteriaForQuyHoach
        {
            public FilterCriteriaForQuyHoach()
            {

            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
        protected override void DataPortal_Fetch(object criteria) 
		{
			RaiseListChangedEvents = false;

            if (criteria is FilterCriteria)
            {
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
            }
            if (criteria is FilterCriteriaAll || criteria is FilterCriteriaForQuyHoach)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    try
                    {
                        ExecuteFetchAll(cn, criteria);
                    }
                    catch (SqlException ex)
                    {
                        HamDungChung.ThongBaoLoi(ex);
                    }
                }//using
            
            }
            else if (criteria is FilterCriteriaByMaNV)
            {
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
            }
			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsChucVuTheoNhomCV";
                    cm.Parameters.AddWithValue("@MaNhomChucVu", ((FilterCriteria)criteria).MaNhomChucVu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChucVu.GetChucVu(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByMaNV)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsChucVuTheoMaNV";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByMaNV)criteria).maNhanVien);
                    cm.Parameters.AddWithValue("@gt", ((FilterCriteriaByMaNV)criteria).gt);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChucVu.GetChucVu(dr));
                    }
                }//using
            }

		}


        private void ExecuteFetchAll(SqlConnection cn, object criteriaAll)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                if (criteriaAll is FilterCriteriaAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsChucVusAll";  
                }
                else if (criteriaAll is FilterCriteriaForQuyHoach) 
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsChucVusForQuyHoach";  
                }
                              

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChucVu.GetChucVu(dr));
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
                    foreach (ChucVu deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChucVu child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn);
                        else
                            child.Update(cn);
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

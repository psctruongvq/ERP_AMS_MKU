
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomNgachLuongCoBanList : Csla.BusinessListBase<NhomNgachLuongCoBanList, NhomNgachLuongCoBan>
	{

		#region Authorization Rules
        protected override object AddNewCore()
        {
            NhomNgachLuongCoBan item = NhomNgachLuongCoBan.NewNhomNgachLuongCoBan();
            
            this.Add(item);
            return item;
        }
        //protected override object AddNewCore()
        //{
        //    NhomNgachLuongCoBan item = NgachLuongCoBan.NewNgachLuongCoBan();
        //    this.Add(item);
        //    return item;
        //}
		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomNgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomNgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomNgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomNgachLuongCoBanList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongCoBanListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhomNgachLuongCoBanList()
		{ /* require use of factory method */ }

		public static NhomNgachLuongCoBanList NewNhomNgachLuongCoBanList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomNgachLuongCoBanList");
			return new NhomNgachLuongCoBanList();
		}

        public static NhomNgachLuongCoBanList GetNhomNgachLuongCoBanList(int maNhom)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhomNgachLuongCoBanList");
			return DataPortal.Fetch<NhomNgachLuongCoBanList>(new FilterCriteria(maNhom));
		}
        public static NhomNgachLuongCoBanList GetNhomNgachLuongCoBanListAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomNgachLuongCoBanList");
            return DataPortal.Fetch<NhomNgachLuongCoBanList>(new FilterCriteriaAll());
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public int MaNhomNgachLuong;
			
            public FilterCriteria(int maNhomNgachLuong)
            {
                this.MaNhomNgachLuong = maNhomNgachLuong;
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
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsNhomNgachLuongCoBan";
                    cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", ((FilterCriteria)criteria).MaNhomNgachLuong);
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandText = "spd_SelecttblnsNhomNgachLuongCoBansAll";
                    
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(dr));
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
					foreach (NhomNgachLuongCoBan deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (NhomNgachLuongCoBan child in this)
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

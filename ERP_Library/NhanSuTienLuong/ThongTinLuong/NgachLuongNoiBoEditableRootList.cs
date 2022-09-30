
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgachLuongNoiBoList : Csla.BusinessListBase<NgachLuongNoiBoList, NgachLuongNoiBo>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NgachLuongNoiBo item = NgachLuongNoiBo.NewNgachLuongNoiBo();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgachLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgachLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgachLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgachLuongNoiBoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgachLuongNoiBoList()
		{ /* require use of factory method */ }

		public static NgachLuongNoiBoList NewNgachLuongNoiBoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgachLuongNoiBoList");
			return new NgachLuongNoiBoList();
		}

		public static NgachLuongNoiBoList GetNgachLuongNoiBoList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgachLuongNoiBoList");
			return DataPortal.Fetch<NgachLuongNoiBoList>(new FilterCriteria());
		}
        public static NgachLuongNoiBoList GetNgachLuongNoiBoListByNhomNgach(int nhomNgach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NgachLuongNoiBoList");
            return DataPortal.Fetch<NgachLuongNoiBoList>(new FilterCriteriaByNhomNgach(nhomNgach));
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
        private class FilterCriteriaByNhomNgach
        {
            public int maNhomNgach;
            public FilterCriteriaByNhomNgach(int _manhom)
            {
                this.maNhomNgach = _manhom;
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
                    cm.CommandText = "spd_SelecttblnsNgachLuongNoiBosAll";
                }
                else if (criteria is FilterCriteriaByNhomNgach)
                {
                    cm.CommandText = "spd_SelecttblnsNgachLuongNoiBoByMaNhomNgach";
                    cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem",((FilterCriteriaByNhomNgach)criteria).maNhomNgach);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NgachLuongNoiBo.GetNgachLuongNoiBo(dr));
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
					foreach (NgachLuongNoiBo deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (NgachLuongNoiBo child in this)
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomHHDVMuaVaoList : Csla.BusinessListBase<NhomHHDVMuaVaoList, NhomHHDVMuaVao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NhomHHDVMuaVao item = NhomHHDVMuaVao.NewNhomHHDVMuaVao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
            //TODO: Define CanGetObject permission in NhomHHDVMuaVaoList
			return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
            //TODO: Define CanAddObject permission in NhomHHDVMuaVaoList
			return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
            //TODO: Define CanEditObject permission in NhomHHDVMuaVaoList
			return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
            //TODO: Define CanDeleteObject permission in NhomHHDVMuaVaoList
			return true;
            //if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
        private NhomHHDVMuaVaoList()
		{ /* require use of factory method */ }

        public static NhomHHDVMuaVaoList NewNhomHHDVMuaVaoList()
		{
			if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHHDVMuaVaoList");
            return new NhomHHDVMuaVaoList();
		}

        public static NhomHHDVMuaVaoList GetNhomHHDVMuaVaoList()
		{
			if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHHDVMuaVaoList");
            return DataPortal.Fetch<NhomHHDVMuaVaoList>(new FilterCriteria());
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
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblNhomHHDVMuaVaoAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
                        this.Add(NhomHHDVMuaVao.GetNhomHHDVMuaVao(dr));
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
                    foreach (NhomHHDVMuaVao deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
                    foreach (NhomHHDVMuaVao child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
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

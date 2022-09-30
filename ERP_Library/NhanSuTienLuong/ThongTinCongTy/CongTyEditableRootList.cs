
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTyList : Csla.BusinessListBase<CongTyList, CongTy>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			CongTy item = CongTy.NewCongTy();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongTyList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongTyListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongTyList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongTyListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongTyList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongTyListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongTyList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongTyListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public CongTyList()
		{ /* require use of factory method */ }

		public static CongTyList NewCongTyList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongTyList");
			return new CongTyList();
		}

		public static CongTyList GetCongTyList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongTyList");
			return DataPortal.Fetch<CongTyList>(new FilterCriteria());
		}
        public static CongTyList GetCongTyListChooseChild(bool diaChi_CongTyListChild,
            bool congTy_DienThoai_FaxListChild, bool congTy_Website_EmailListChild, bool congTy_NganHangListChild)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongTyList");
            return DataPortal.Fetch<CongTyList>(new FilterCriteriaChooseChild( diaChi_CongTyListChild,
             congTy_DienThoai_FaxListChild, congTy_Website_EmailListChild, congTy_NganHangListChild));
        }
        public static CongTyList GetCongTyList1()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongTyList");
            return DataPortal.Fetch<CongTyList>(new FilterCriteria1());
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
        [Serializable()]
        private class FilterCriteriaChooseChild
        {
            public bool diaChi_CongTyListChild, congTy_DienThoai_FaxListChild, congTy_Website_EmailListChild, congTy_NganHangListChild;
            public FilterCriteriaChooseChild(bool diaChi_CongTyListChild,
            bool congTy_DienThoai_FaxListChild, bool congTy_Website_EmailListChild, bool congTy_NganHangListChild)
            {
                this.diaChi_CongTyListChild = diaChi_CongTyListChild;
                this.congTy_DienThoai_FaxListChild = congTy_DienThoai_FaxListChild;
                this.congTy_Website_EmailListChild = congTy_Website_EmailListChild;
                this.congTy_NganHangListChild = congTy_NganHangListChild;
            }
        }
        [Serializable()]
        private class FilterCriteria1
        {
            public FilterCriteria1()
            {
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		protected override void DataPortal_Fetch(object criteria)
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongTiesAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongTy.GetCongTy(dr));
                    }
                }//using
            }
           else if (criteria is FilterCriteriaChooseChild)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongTiesAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongTy.GetCongTyChooseChild(dr,
                               diaChi_CongTyListChild:((FilterCriteriaChooseChild)criteria).diaChi_CongTyListChild,
                               congTy_DienThoai_FaxListChild:((FilterCriteriaChooseChild)criteria).congTy_DienThoai_FaxListChild,
                               congTy_NganHangListChild:((FilterCriteriaChooseChild)criteria).congTy_NganHangListChild,
                               congTy_Website_EmailListChild:((FilterCriteriaChooseChild)criteria).congTy_Website_EmailListChild
                                ));
                    }
                }//using
            }
            else if (criteria is FilterCriteria1)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongTiesAll1";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CongTy.GetCongTy(dr));
                    }
                }//using
            }
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
					foreach (CongTy deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (CongTy child in this)
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

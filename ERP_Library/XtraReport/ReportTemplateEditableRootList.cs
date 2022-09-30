
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ReportTemplateList : Csla.BusinessListBase<ReportTemplateList, ReportTemplate>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ReportTemplateList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ReportTemplateList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ReportTemplateList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ReportTemplateList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ReportTemplateListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ReportTemplateList()
		{ /* require use of factory method */ }

		public static ReportTemplateList NewReportTemplateList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ReportTemplateList");
			return new ReportTemplateList();
		}

		public static ReportTemplateList GetReportTemplateList( string ID)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ReportTemplateList");
			return DataPortal.Fetch<ReportTemplateList>(new FilterCriteriaByMa(ID));
		}

        public static ReportTemplateList GetReportTemplateList(int thuMuc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportTemplateList");
            return DataPortal.Fetch<ReportTemplateList>(new FilterCriteriaByThuMuc(thuMuc));
        }

        public static ReportTemplateList GetReportTemplateList_ByUserId(int UserId)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ReportTemplateList");
            return DataPortal.Fetch<ReportTemplateList>(new FilterCriteriaByUserId(UserId));
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

        private class FilterCriteriaByMa
        {
            public string id;
            public FilterCriteriaByMa(string ID)
            {
                this.id=ID;
            }
        }

        private class FilterCriteriaByThuMuc
        {
            public int ThuMuc;
            public FilterCriteriaByThuMuc(int thuMuc)
            {
                this.ThuMuc = thuMuc;
            }
        }

        private class FilterCriteriaByUserId
        {
            public int UserId;
            public FilterCriteriaByUserId(int userId)
            {
                this.UserId = userId;
            }
        }

		#endregion //Filter Criteria

		#region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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
        
		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByMa)
                {
                    cm.CommandText = "spd_SelectReportTemplateList";
                    cm.Parameters.AddWithValue("@ID", ((FilterCriteriaByMa)criteria).id);
                }
                else if (criteria is FilterCriteriaByThuMuc)
                {
                    cm.CommandText = "spd_SelectReportTemplateListByThuMuc";
                    cm.Parameters.AddWithValue("@ThuMuc", ((FilterCriteriaByThuMuc)criteria).ThuMuc);
                }
                else if (criteria is FilterCriteriaByUserId)
                {
                    cm.CommandText = "spd_SelectReportTemplateListByUserId";
                    cm.Parameters.AddWithValue("@UserId", ((FilterCriteriaByUserId)criteria).UserId);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ReportTemplate.GetReportTemplate(dr));
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
					foreach (ReportTemplate deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ReportTemplate child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr, this);
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

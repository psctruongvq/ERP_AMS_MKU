
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTuongList : Csla.BusinessListBase<DoiTuongList, DoiTuong>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DoiTuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DoiTuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DoiTuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DoiTuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DoiTuongList()
		{ /* require use of factory method */ }

		public static DoiTuongList NewDoiTuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTuongList");
			return new DoiTuongList();
		}

		public static DoiTuongList GetDoiTuongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DoiTuongList");
			return DataPortal.Fetch<DoiTuongList>(new FilterCriteria());
		}

        public static DoiTuongList GetDoiTuongByDoiTacList()
        {
            return DataPortal.Fetch<DoiTuongList>(new CriteriaByDoiTac());
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
        private class CriteriaByDoiTac
        {

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
            if (criteria is FilterCriteria)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        try
                        {
                            cn.Open();
                            using (SqlCommand cm = cn.CreateCommand())
                            {
                                cm.CommandType = CommandType.Text;
                                cm.CommandText = "select * from tblDoiTuong";

                                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                                {
                                    while (dr.Read())
                                    {
                                        this.Add(DoiTuong.GetDoiTuong(dr));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                    }
                }
                else if (criteria is CriteriaByDoiTac)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblDoiTuong where Loai=0";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(DoiTuong.GetDoiTuong(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            
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
					foreach (DoiTuong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (DoiTuong child in this)
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

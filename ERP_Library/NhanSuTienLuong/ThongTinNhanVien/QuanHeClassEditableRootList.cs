
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHeClassList : Csla.BusinessListBase<QuanHeClassList, QuanHeClass>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuanHeClass item = QuanHeClass.NewQuanHeClass();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHeClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHeClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHeClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHeClassList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHeClassList()
		{ /* require use of factory method */ }

		public static QuanHeClassList NewQuanHeClassList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHeClassList");
			return new QuanHeClassList();
		}

		public static QuanHeClassList GetQuanHeClassList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHeClassList");
			return DataPortal.Fetch<QuanHeClassList>(new FilterCriteria());
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    ExecuteFetch(cn, criteria);
                }//using
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuanHesAll";


				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuanHeClass.GetQuanHeClass(dr));
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
                    foreach (QuanHeClass deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuanHeClass child in this)
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

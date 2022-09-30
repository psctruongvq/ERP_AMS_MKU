using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHuyenList : Csla.BusinessListBase<QuanHuyenList, QuanHuyen>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuanHuyen item = QuanHuyen.NewQuanHuyen();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHuyenList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHuyenList()
		{ /* require use of factory method */ }

		public static QuanHuyenList NewQuanHuyenList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHuyenList");
			return new QuanHuyenList();
		}
        public static QuanHuyenList GetQuanHuyenList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuanHuyenList");
            return DataPortal.Fetch<QuanHuyenList>(new Criteria());
        }
        public static QuanHuyenList GetQuanHuyenList(int maTinhThanh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuanHuyenList");
            return DataPortal.Fetch<QuanHuyenList>(new FilterCriteria(maTinhThanh));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        private class Criteria
        {
            public Criteria()
            {
            }
        }
		private class FilterCriteria
		{
			public int MaTinhThanh;

			public FilterCriteria(int maTinhThanh)
			{
				this.MaTinhThanh = maTinhThanh;
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

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            try
            {
                if (criteria is Criteria)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblQuanHuyensAll";
                        //cm.Parameters.AddWithValue("@MaTinhThanh", criteria.MaTinhThanh);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(QuanHuyen.GetQuanHuyen(dr));
                        }
                    }//using
                }
                else if (criteria is FilterCriteria)
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblQuanHuyenByTinhThanh";
                        cm.Parameters.AddWithValue("@MaTinhThanh", ((FilterCriteria)criteria).MaTinhThanh);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(QuanHuyen.GetQuanHuyen(dr));
                        }
                    }//using 
                }
            }
            catch (Exception ex) { throw ex; }
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				// loop through each deleted child object
				foreach (QuanHuyen deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (QuanHuyen child in this)
				{
					if (child.IsNew)
						child.Insert(cn);
					else
						child.Update(cn);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

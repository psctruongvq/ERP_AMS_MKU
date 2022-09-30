
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHeGiaDinhList : Csla.BusinessListBase<QuanHeGiaDinhList, QuanHeGiaDinh>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuanHeGiaDinh item = QuanHeGiaDinh.NewQuanHeGiaDinh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHeGiaDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHeGiaDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHeGiaDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHeGiaDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeGiaDinhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHeGiaDinhList()
		{ /* require use of factory method */ }

		public static QuanHeGiaDinhList NewQuanHeGiaDinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHeGiaDinhList");
			return new QuanHeGiaDinhList();
		}

		public static QuanHeGiaDinhList GetQuanHeGiaDinhList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHeGiaDinhList");
			return DataPortal.Fetch<QuanHeGiaDinhList>(new FilterCriteria());
		}

        public static QuanHeGiaDinhList GetQuanHeGiaDinhList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuanHeGiaDinhList");
            return DataPortal.Fetch<QuanHeGiaDinhList>(new FilterCriteria_MaNhanVien(maNhanVien));
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

        private class FilterCriteria_MaNhanVien
        {
            public long MaNhanVien;
            public FilterCriteria_MaNhanVien(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
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
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
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
                    cm.CommandText = "spd_SelecttblnsQuanHeGiaDinhesAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuanHeGiaDinh.GetQuanHeGiaDinh(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteria_MaNhanVien)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsQuanHeGiaDinhesAll_MaNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria_MaNhanVien)criteria).MaNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuanHeGiaDinh.GetQuanHeGiaDinh(dr));
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
					foreach (QuanHeGiaDinh deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (QuanHeGiaDinh child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

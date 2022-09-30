
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiTienList : Csla.BusinessListBase<LoaiTienList, LoaiTien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LoaiTien item = LoaiTien.NewLoaiTien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiTienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiTienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiTienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiTienList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTienListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiTienList()
		{ /* require use of factory method */ }

		public static LoaiTienList NewLoaiTienList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTienList");
			return new LoaiTienList();
		}

		public static LoaiTienList GetLoaiTienList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiTienList");
			return DataPortal.Fetch<LoaiTienList>(new FilterCriteria());
		}
        public static LoaiTienList GetLoaiTienList(int maLoaiTien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiTienList");
            return DataPortal.Fetch<LoaiTienList>(new FilterCriteria_MaLoaiTien(maLoaiTien));
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

        private class FilterCriteria_MaLoaiTien
        {
            public int maLoaiTien;
            public FilterCriteria_MaLoaiTien(int maLoaiTien)
            {
                this.maLoaiTien = maLoaiTien;
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
                    cm.CommandText = "spd_SelecttblLoaiTiensAll";
                }
                else if (criteria is FilterCriteria_MaLoaiTien)
                {
                    cm.CommandText = "spd_SelecttblLoaiTien_MaLoaiTien";
                    cm.Parameters.AddWithValue("@MaLoaiTien", ((FilterCriteria_MaLoaiTien)criteria).maLoaiTien);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(LoaiTien.GetLoaiTien(dr));
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
					foreach (LoaiTien deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (LoaiTien child in this)
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

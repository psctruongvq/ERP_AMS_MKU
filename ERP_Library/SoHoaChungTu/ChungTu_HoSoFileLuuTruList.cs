using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_HoSoFileLuuTruList : Csla.BusinessListBase<ChungTu_HoSoFileLuuTruList, ChungTu_HoSoFileLuuTru>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTu_HoSoFileLuuTru item = ChungTu_HoSoFileLuuTru.NewChungTu_HoSoFileLuuTru();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_HoSoFileLuuTruList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_HoSoFileLuuTruList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_HoSoFileLuuTruList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_HoSoFileLuuTruList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_HoSoFileLuuTruListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_HoSoFileLuuTruList()
		{ /* require use of factory method */ }

		public static ChungTu_HoSoFileLuuTruList NewChungTu_HoSoFileLuuTruList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_HoSoFileLuuTruList");
			return new ChungTu_HoSoFileLuuTruList();
		}

		public static ChungTu_HoSoFileLuuTruList GetChungTu_HoSoFileLuuTruList(long maChungTu,int maLoaiNV)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTu_HoSoFileLuuTruList");
			return DataPortal.Fetch<ChungTu_HoSoFileLuuTruList>(new FilterCriteria(maChungTu,maLoaiNV));
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
		private class FilterCriteria
		{
			public long MaChungTu;
            public int MaLoaiNV;
			public FilterCriteria(long maChungTu,int maLoaiNV)
			{
				this.MaChungTu = maChungTu;
                this.MaLoaiNV = maLoaiNV;
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

				ExecuteFetch(cn, criteria);
			}//using

			RaiseListChangedEvents = true;
		}

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "GetChungTu_HoSoFileLuuTruList";
                cm.Parameters.AddWithValue("@LoaiNghiepVu", criteria.MaLoaiNV);
                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTu_HoSoFileLuuTru.GetChungTu_HoSoFileLuuTru(dr));
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

				// loop through each deleted child object
				foreach (ChungTu_HoSoFileLuuTru deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (ChungTu_HoSoFileLuuTru child in this)
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

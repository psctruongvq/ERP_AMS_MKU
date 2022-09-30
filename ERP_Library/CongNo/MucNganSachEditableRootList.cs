
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class MucNganSachList : Csla.BusinessListBase<MucNganSachList, MucNganSach>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			MucNganSach item = MucNganSach.NewMucNganSach();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in MucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in MucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in MucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in MucNganSachList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("MucNganSachListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private MucNganSachList()
		{ /* require use of factory method */ }

		public static MucNganSachList NewMucNganSachList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a MucNganSachList");
			return new MucNganSachList();
		}

		public static MucNganSachList GetMucNganSachList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a MucNganSachList");
			return DataPortal.Fetch<MucNganSachList>(new FilterCriteria());
		}

        public static MucNganSachList GetMucNganSachList(int MaTieuNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucNganSachList");
            return DataPortal.Fetch<MucNganSachList>(new FilterCriteriaAll(MaTieuNhom));
        }

        public static MucNganSachList GetMucNganSachList(string MaTieuNhom)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a MucNganSachList");
            return DataPortal.Fetch<MucNganSachList>(new FilterCriteriaMaChuoi(MaTieuNhom));
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
		private class FilterCriteriaAll
		{
			public int MaTieuNhom;

			public FilterCriteriaAll(int maTieuNhom)
			{
				this.MaTieuNhom = maTieuNhom;
			}
		}

        [Serializable()]
        private class FilterCriteriaMaChuoi
        {
            public string MaMucChuoi;

            public FilterCriteriaMaChuoi(string mamucchuoi)
            {
                this.MaMucChuoi = mamucchuoi;
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
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblMucNganSachesAll";
                }
                else if (criteria is FilterCriteriaAll)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblMucNganSachesAll_All";
                    cm.Parameters.AddWithValue("@MaTieuNhom", ((FilterCriteriaAll)criteria).MaTieuNhom);
                }
                else if (criteria is FilterCriteriaMaChuoi)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimMucChuoi";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaMaChuoi)criteria).MaMucChuoi);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(MucNganSach.GetMucNganSach(dr));
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
				foreach (MucNganSach deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (MucNganSach child in this)
				{
					if (child.IsNew)
						child.Insert(cn, this);
					else
						child.Update(cn, this);
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

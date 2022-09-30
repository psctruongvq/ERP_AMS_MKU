
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhDaoTaoList : Csla.BusinessListBase<QuaTrinhDaoTaoList, QuaTrinhDaoTao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhDaoTao item = QuaTrinhDaoTao.NewQuaTrinhDaoTaoMoi();
            
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhDaoTaoMoiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhDaoTaoList()
		{ /* require use of factory method */ }

		public static QuaTrinhDaoTaoList NewQuaTrinhDaoTaoMoiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoMoiList");
			return new QuaTrinhDaoTaoList();
		}

		public static QuaTrinhDaoTaoList GetQuaTrinhDaoTaoMoiList(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoMoiList");
			return DataPortal.Fetch<QuaTrinhDaoTaoList>(new FilterCriteria(maNhanVien));
		}
        public static QuaTrinhDaoTaoList GetQuaTrinhDaoTaoMoiList(int tuNam,int denNam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoMoiList");
            return DataPortal.Fetch<QuaTrinhDaoTaoList>(new FilterCriteriaNam(tuNam, denNam));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			public long MaNhanVien;

			public FilterCriteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}
        private class FilterCriteriaNam
        {
            public int TuNam;
            public int DenNam;

            public FilterCriteriaNam(int tuNam, int denNam)
            {
                this.TuNam = tuNam;
                this.DenNam = denNam;
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
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTaosAll";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteria) criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaNam)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTaoByNamTotNghiep";
                    cm.Parameters.AddWithValue("@TuNam", ((FilterCriteriaNam)criteria).TuNam);
                    cm.Parameters.AddWithValue("@DenNam", ((FilterCriteriaNam)criteria).DenNam);

                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhDaoTao.GetQuaTrinhDaoTaoMoi(dr));
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
				foreach (QuaTrinhDaoTao deletedChild in DeletedList)
					deletedChild.DeleteSelf(cn);
				DeletedList.Clear();

				// loop through each non-deleted child object
				foreach (QuaTrinhDaoTao child in this)
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

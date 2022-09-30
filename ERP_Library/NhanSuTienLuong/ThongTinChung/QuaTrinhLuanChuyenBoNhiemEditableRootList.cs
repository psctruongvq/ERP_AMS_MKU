
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhLuanChuyenBoNhiemList : Csla.BusinessListBase<QuaTrinhLuanChuyenBoNhiemList, QuaTrinhLuanChuyenBoNhiem>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuaTrinhLuanChuyenBoNhiem item = QuaTrinhLuanChuyenBoNhiem.NewQuaTrinhLuanChuyenBoNhiem();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhLuanChuyenBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhLuanChuyenBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhLuanChuyenBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhLuanChuyenBoNhiemList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhLuanChuyenBoNhiemListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhLuanChuyenBoNhiemList()
		{ /* require use of factory method */ }

		public static QuaTrinhLuanChuyenBoNhiemList NewQuaTrinhLuanChuyenBoNhiemList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhLuanChuyenBoNhiemList");
			return new QuaTrinhLuanChuyenBoNhiemList();
		}

		public static QuaTrinhLuanChuyenBoNhiemList GetQuaTrinhLuanChuyenBoNhiemList(long maNhanVien, int loai)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhLuanChuyenBoNhiemList");
            return DataPortal.Fetch<QuaTrinhLuanChuyenBoNhiemList>(new FilterCriteria(maNhanVien, loai));
		}
        public static QuaTrinhLuanChuyenBoNhiemList GetQuaTrinhLuanChuyenBoNhiemList(DateTime tuNgay,DateTime denNgay, int loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhLuanChuyenBoNhiemList");
            return DataPortal.Fetch<QuaTrinhLuanChuyenBoNhiemList>(new FilterCriteriaByNgay(tuNgay, denNgay, loai));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public long MaNhanVien;
            public int Loai;
			public FilterCriteria(long maNhanVien, int loai)
			{
                this.MaNhanVien = maNhanVien;
                this.Loai = loai;
			}
		}
        private class FilterCriteriaByNgay
		{
            public DateTime tuNgay;
            public DateTime denNgay;
            public int Loai;
            public FilterCriteriaByNgay(DateTime tuNgay,DateTime denNgay, int loai)
			{
                this.tuNgay = tuNgay;
                this.denNgay = denNgay;
                this.Loai = loai;
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
                    cm.CommandText = "spd_SelecttblnsQuaTrinhLuanChuyenBoNhiemByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteria)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria)criteria).Loai);
                }
                if (criteria is FilterCriteriaByNgay)
                {
                    cm.CommandText = "spd_SelecttblnsQuaTrinhLuanChuyenBoNhiemByNgay";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgay)criteria).tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgay)criteria).denNgay);
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByNgay)criteria).Loai);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuaTrinhLuanChuyenBoNhiem.GetQuaTrinhLuanChuyenBoNhiem(dr));
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
					foreach (QuaTrinhLuanChuyenBoNhiem deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (QuaTrinhLuanChuyenBoNhiem child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}

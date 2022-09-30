
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_DungCuLaoDongList : Csla.BusinessListBase<NhanVien_DungCuLaoDongList, NhanVien_DungCuLaoDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			NhanVien_DungCuLaoDong item = NhanVien_DungCuLaoDong.NewNhanVien_DungCuLaoDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private NhanVien_DungCuLaoDongList()
		{ /* require use of factory method */ }

		public static NhanVien_DungCuLaoDongList NewNhanVien_DungCuLaoDongList()
		{
            return new NhanVien_DungCuLaoDongList();
		}

		public static NhanVien_DungCuLaoDongList GetNhanVien_DungCuLaoDongList(long maNhanVien)
		{
			return DataPortal.Fetch<NhanVien_DungCuLaoDongList>(new FilterCriteria(maNhanVien));
		}
        public static NhanVien_DungCuLaoDongList GetNhanVien_DungCuLaoDongList(DateTime tuNgay,DateTime denNgay,long maNhanVien)
        {
            return DataPortal.Fetch<NhanVien_DungCuLaoDongList>(new FilterCriteriaByNgayHetHan(tuNgay,denNgay,maNhanVien));
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
        private class FilterCriteriaByNgayHetHan
        {
            public long MaNhanVien;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public FilterCriteriaByNgayHetHan(DateTime tuNgay,DateTime denNgay,long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
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
                    cm.CommandText = "SelecttblnsNhanVien_DungCuLDsAll";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaByNgayHetHan)
                {
                    cm.CommandText = "SelecttblnsNhanVien_DungCuLDByNgaỵHetHan";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNgayHetHan)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByNgayHetHan)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByNgayHetHan)criteria).DenNgay);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhanVien_DungCuLaoDong.GetNhanVien_DungCuLaoDong(dr));
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
					foreach (NhanVien_DungCuLaoDong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (NhanVien_DungCuLaoDong child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ImportChungTuHVTList : Csla.BusinessListBase<ImportChungTuHVTList, ImportChungTuHVT>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ImportChungTuHVT item = ImportChungTuHVT.NewImportChungTuHVT();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ImportChungTuHVTList()
		{ /* require use of factory method */ }

		public static ImportChungTuHVTList NewImportChungTuHVTList()
		{
			return new ImportChungTuHVTList();
		}

		public static ImportChungTuHVTList GetImportChungTuHVTList()
		{
			return DataPortal.Fetch<ImportChungTuHVTList>(new FilterCriteria());
		}
        public static ImportChungTuHVTList GetImportChungTuHVT_DistinctBySoChungTu()
        {
            return DataPortal.Fetch<ImportChungTuHVTList>(new FilterCriteriaBySoChungTu());
        }
        public static ImportChungTuHVTList GetImportChungTuHVT_DistinctByButToan()
        {
            return DataPortal.Fetch<ImportChungTuHVTList>(new FilterCriteriaByButToan());
        }
        public static ImportChungTuHVTList GetImportChungTuHVT_DistinctByMucNganSach()
        {
            return DataPortal.Fetch<ImportChungTuHVTList>(new FilterCriteriaByMucNganSach());
        }
        public static ImportChungTuHVTList GetImportChungTuHVT_ByDanhSach()
        {
            return DataPortal.Fetch<ImportChungTuHVTList>(new FilterCriteriaByDanhSach());
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
        private class FilterCriteriaBySoChungTu
        {

            public FilterCriteriaBySoChungTu()
            {

            }
        }
         private class FilterCriteriaByDanhSach
        {

             public FilterCriteriaByDanhSach()
            {

            }
        }
        private class FilterCriteriaByButToan
        {

            public FilterCriteriaByButToan()
            {

            }
        }
        private class FilterCriteriaByMucNganSach
        {

            public FilterCriteriaByMucNganSach()
            {

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
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SelectImportChungTuHTVsAll";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ImportChungTuHVT.GetImportChungTuHVT(dr));
                    }
                }
                else if (criteria is FilterCriteriaBySoChungTu)
                {
                    cm.CommandType = CommandType.Text;
            
                    // cai cu
                    //cm.CommandText = " select distinct SoChungTu,NgayLap,sum(SoTien) as SoTien,TiGia,DienGiaiCT,LoaiChungTu,MaBoPhan,BoPhan,KhachHangNgoaiDai, NguoiDangNhap, ";
                    //cm.CommandText += " DiaChi,KhachHangTrongDai,DiaChi1 from ImportChungTuHTV";
                    //cm.CommandText += " group by SoChungTu,NgayLap,TiGia,DienGiaiCT,LoaiChungTu,MaBoPhan,BoPhan,KhachHangNgoaiDai, DiaChi,KhachHangTrongDai,DiaChi1, NguoiDangNhap ";
                    //cm.CommandText += " order by NgayLap,  SoChungTu";


                    cm.CommandText = " select SoChungTu, NgayLap, 	ThanhTien as SoTien, TiGia, DienGiaiCT, LoaiChungTu, MaBoPhan, BoPhan, KhachHangNgoaiDai, NguoiDangNhap, DiaChi,KhachHangTrongDai,DiaChi1, TKNo, TKCO,DienGiaiBT,DienGiaiMuc,SoTienTieuMuc,SoTienButToan,MucNganSach from ImportChungTuHTV";
                  
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ImportChungTuHVT.GetImportChungTuHVTBySoChungTu(dr));
                    }
                }
                else if (criteria is FilterCriteriaByButToan)
                {
                    cm.CommandType = CommandType.Text;
                    //cm.CommandText = "Select distinct SoChungTu,TKNo,TKCo,Sum(SoTienButToan) as SoTienButToan, DienGiaiBT, MaBoPhan from ImportChungTuHTV group by SoChungTu,TKNo,TKCo, DienGiaiBT,MaBoPhan";
                    cm.CommandText = "Select SoChungTu,TKNo,TKCo,SoTienButToan, DienGiaiBT, MaBoPhan from ImportChungTuHTV ";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())

                            this.Add(ImportChungTuHVT.GetImportChungTuHVTByButToan(dr));
                    }
                }
                else if (criteria is FilterCriteriaByMucNganSach)
                {
                    cm.CommandType = CommandType.Text;
                   // cm.CommandText = "Select  SoChungTu,TKNo,TKCo,SoTienButToan,SoTienTieuMuc,MucNganSach, DienGiaiMuc from ImportChungTuHTV where(SoTienTieuMuc is not null or MucNganSach is not null)";
                    // A long sua khuc nay
                    cm.CommandText = "select *from view_ButToanMucNganSachImport";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ImportChungTuHVT.GetImportChungTuHVTByMucNganSach(dr));
                    }
                }
                else if (criteria is FilterCriteriaByDanhSach)
                {
                    cm.CommandType = CommandType.Text;
                   // cm.CommandText = "Select  SoChungTu,TKNo,TKCo,SoTienButToan,SoTienTieuMuc,MucNganSach, DienGiaiMuc from ImportChungTuHTV where(SoTienTieuMuc is not null or MucNganSach is not null)";
                    // A long sua khuc nay
                    cm.CommandText = "select TenDanhSach from ImportChungTuHTV group by TenDanhSach";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ImportChungTuHVT.GetImportChungTuByDanhSach(dr));
                    }
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
					foreach (ImportChungTuHVT deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (ImportChungTuHVT child in this)
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

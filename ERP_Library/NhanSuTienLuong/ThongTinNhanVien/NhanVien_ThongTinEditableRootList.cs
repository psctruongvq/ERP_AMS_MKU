
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ThongTinList : Csla.BusinessListBase<NhanVien_ThongTinList, NhanVien_ThongTin>
	{

		#region Factory Methods
		private NhanVien_ThongTinList()
		{ /* require use of factory method */ }

		public static NhanVien_ThongTinList NewNhanVien_ThongTinList()
		{
			return new NhanVien_ThongTinList();
		}
        /// <summary>
        /// Lấy nhân viên theo nhiều mã
        /// </summary>
        /// <param name="maBoPhan">'0': Tất cả, ngược lại truyền theo nhiều mã, ví dụ: '1,2'</param>
        /// <param name="maChucVu">'0': Tất cả, ngược lại truyền theo nhiều mã, ví dụ: '1,2'</param>
        /// <param name="maLoaiNhanVien">'0': Tất cả, ngược lại truyền theo nhiều mã, ví dụ: '1,2'</param>
        /// <returns></returns>
        public static NhanVien_ThongTinList GetNhanVien_ThongTinList(string maBoPhan, string maChucVu, string maLoaiNhanVien, string maTrinhDoHocVan, 
                                string maTrinhDoTinHoc, string maTrinhDongoaingu, string maTrinhDoQLNN, string maTrinhDovanhoa, string maTrinhDoLLCT, string machuyenNganhDT, 
                                string maTrinhDoQLKT, string machungChi)
		{
			return DataPortal.Fetch<NhanVien_ThongTinList>(new FilterCriteria( maBoPhan,  maChucVu,  maLoaiNhanVien,  maTrinhDoHocVan,  maTrinhDoTinHoc,  maTrinhDongoaingu,  maTrinhDoQLNN,  maTrinhDovanhoa,  maTrinhDoLLCT,  machuyenNganhDT,  maTrinhDoQLKT,  machungChi));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public string MaBoPhan;
            public string MaChucVu;
            public string MaLoaiNhanVien;
            public string MaTrinhDoHocVan;
            public string MaTrinhDoTinHoc;
            public string MaTrinhDongoaingu;
            public string MaTrinhDoQLNN;
            public string MaTrinhDovanhoa;
            public string MaTrinhDoLLCT;
            public string MachuyenNganhDT;
            public string MaTrinhDoQLKT;
            public string MachungChi;
            public FilterCriteria(string maBoPhan, string maChucVu, string maLoaiNhanVien, string maTrinhDoHocVan, string maTrinhDoTinHoc, string maTrinhDongoaingu,
                                  string maTrinhDoQLNN, string maTrinhDovanhoa, string maTrinhDoLLCT, string machuyenNganhDT, string maTrinhDoQLKT, string machungChi)
			{
                this.MaBoPhan = maBoPhan;
                this.MaChucVu = maChucVu;
                this.MaLoaiNhanVien = maLoaiNhanVien;
                this.MaTrinhDoHocVan = maTrinhDoHocVan;
                this.MaTrinhDoTinHoc = maTrinhDoTinHoc;
                this.MaTrinhDongoaingu = maTrinhDongoaingu;
                this.MaTrinhDoQLNN = maTrinhDoQLNN;
                this.MaTrinhDovanhoa = maTrinhDovanhoa;
                this.MaTrinhDoLLCT = maTrinhDoLLCT;
                this.MachuyenNganhDT = machuyenNganhDT;
                this.MaTrinhDoQLKT = maTrinhDoQLKT;
                this.MachungChi = machungChi;
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
                    cm.CommandText = "NhanVien_ThongTinCoBanImport";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@MaChucVu", ((FilterCriteria)criteria).MaChucVu);
                    cm.Parameters.AddWithValue("@MaLoaiNhanVien", ((FilterCriteria)criteria).MaLoaiNhanVien);
                    cm.Parameters.AddWithValue("@MaTrinhDoHocVan", ((FilterCriteria)criteria).MaTrinhDoHocVan);
                    cm.Parameters.AddWithValue("@MaTrinhDoTinHoc", ((FilterCriteria)criteria).MaTrinhDoTinHoc);
                    cm.Parameters.AddWithValue("@MaTrinhDongoaingu", ((FilterCriteria)criteria).MaTrinhDongoaingu);
                    cm.Parameters.AddWithValue("@MaTrinhDoQLNN", ((FilterCriteria)criteria).MaTrinhDoQLNN);
                    cm.Parameters.AddWithValue("@MaTrinhDovanhoa", ((FilterCriteria)criteria).MaTrinhDovanhoa);
                    cm.Parameters.AddWithValue("@MaTrinhDoLLCT", ((FilterCriteria)criteria).MaTrinhDoLLCT);
                    cm.Parameters.AddWithValue("@MachuyenNganhDT", ((FilterCriteria)criteria).MachuyenNganhDT);
                    cm.Parameters.AddWithValue("@MaTrinhDoQLKT", ((FilterCriteria)criteria).MaTrinhDoQLKT);
                    cm.Parameters.AddWithValue("@MachungChi", ((FilterCriteria)criteria).MachungChi);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhanVien_ThongTin.GetNhanVien_ThongTin(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		
		#endregion //Data Access
	}
}

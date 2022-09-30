
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//23/04/2013
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhieuLinhNhienLieuList : Csla.BusinessListBase<PhieuLinhNhienLieuList, PhieuLinhNhienLieu>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			PhieuLinhNhienLieu item = PhieuLinhNhienLieu.NewPhieuLinhNhienLieu();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhieuLinhNhienLieuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhieuLinhNhienLieuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhieuLinhNhienLieuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhieuLinhNhienLieuList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhieuLinhNhienLieuList()
		{ /* require use of factory method */ }

		public static PhieuLinhNhienLieuList NewPhieuLinhNhienLieuList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhieuLinhNhienLieuList");
			return new PhieuLinhNhienLieuList();
		}

		public static PhieuLinhNhienLieuList GetPhieuLinhNhienLieuList(long maPhieuNhapXuat)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhieuLinhNhienLieuList");
			return DataPortal.Fetch<PhieuLinhNhienLieuList>(new FilterCriteria(maPhieuNhapXuat));
		}
        public static PhieuLinhNhienLieuList GetPhieuLinhNhienLieuList(int ngayLap,int ngayHetHan,long maPhieuNhapXuat, string soChungTu, int maKho, byte tinhTrang, DateTime tuNgayLap, DateTime denNgayLap, DateTime tuNgayHetHan, DateTime denNgayHetHan, int maBoPhan, int maNguoiNhan, int userID, byte loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhieuLinhNhienLieuList");
            return DataPortal.Fetch<PhieuLinhNhienLieuList>(new FilterCriteria(ngayLap,ngayHetHan,maPhieuNhapXuat,soChungTu,maKho,tinhTrang,tuNgayLap,denNgayLap,tuNgayHetHan,denNgayHetHan,maBoPhan,maNguoiNhan, userID, loai));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
			
			public long MaPhieuNhapXuat;
			public FilterCriteria(long maPhieuNhapXuat)
			{				
				this.MaPhieuNhapXuat = maPhieuNhapXuat;
			}
            public string SoChungTu="-1"; 
            public int MaKho;
            public byte TinhTrang;
            public DateTime TuNgayLap;
            public DateTime DenNgayLap;
            public DateTime TuNgayHetHan;
            public DateTime DenNgayHetHan;
            public int MaBoPhanNhan;
            public int MaNguoiNhan;
            public int NgayLap;
            public int NgayHetHan;
            public int UserId;
            public byte Loai;
            public FilterCriteria(int ngayLap,int ngayHetHan,long maPhieuNhapXuat,string soChungTu,int maKho, byte tinhTrang,DateTime tuNgayLap,DateTime denNgayLap,DateTime tuNgayHetHan,DateTime denNgayHetHan,int maBoPhan,int maNguoiNhan, int userId, byte loai)
            {
                this.NgayLap = ngayLap;
                this.NgayHetHan = ngayHetHan;
                this.MaPhieuNhapXuat = maPhieuNhapXuat;
                this.SoChungTu = soChungTu;
                this.MaKho = maKho;
                this.TinhTrang = tinhTrang;
                this.TuNgayLap = tuNgayLap;
                this.DenNgayLap = denNgayLap;
                this.TuNgayHetHan = tuNgayHetHan;
                this.DenNgayHetHan = denNgayHetHan;
                this.MaBoPhanNhan = maBoPhan;
                this.MaNguoiNhan = maNguoiNhan;
                this.UserId = userId;
                this.Loai = loai;
            }
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
		{
            if(criteria.SoChungTu=="-1")
			    using (SqlCommand cm = tr.Connection.CreateCommand())
			    {
				    cm.Transaction = tr;
				    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblPhieuLinhNhienLieusByAndMaPhieuNhapXuat";				
				    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.MaPhieuNhapXuat);

				    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				    {
					    while (dr.Read())
						    //this.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(dr));//Old
                            this.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieuKhongChild(dr));//New
				    }
			    }//using
            else
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblPhieuLinhNhienLieusByAll";
                    cm.Parameters.AddWithValue("@NgayLap", criteria.NgayLap);
                    cm.Parameters.AddWithValue("@NgayHetHan", criteria.NgayHetHan);
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", criteria.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@SoChungTu", criteria.SoChungTu);
                    cm.Parameters.AddWithValue("@MaKho", criteria.MaKho);
                    cm.Parameters.AddWithValue("@TinhTrang", criteria.TinhTrang);
                    cm.Parameters.AddWithValue("@TuNgayLap", criteria.TuNgayLap);
                    cm.Parameters.AddWithValue("@DenNgayLap", criteria.DenNgayLap);
                    cm.Parameters.AddWithValue("@TuNgayHetHan", criteria.TuNgayHetHan);
                    cm.Parameters.AddWithValue("@DenNgayHetHan", criteria.DenNgayHetHan);
                    cm.Parameters.AddWithValue("@MaBoPhanNhan", criteria.MaBoPhanNhan);
                    cm.Parameters.AddWithValue("@MaNguoiNhan", criteria.MaNguoiNhan);
                    cm.Parameters.AddWithValue("@UserID", criteria.UserId);
                    cm.Parameters.AddWithValue("@Loai", criteria.Loai);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            //this.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(dr));//Old
                            this.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieuKhongChild(dr));//New
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
					foreach (PhieuLinhNhienLieu deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (PhieuLinhNhienLieu child in this)
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

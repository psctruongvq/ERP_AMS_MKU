
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrichNgang : Csla.BusinessBase<TrichNgang>
	{
        #region Business Properties and Methods
		//declare members
		private long _maNhanVien = 0;
        private DateTime _ngayVaoLam = DateTime.Today;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
        private string _gioiTinh =string.Empty;
        private DateTime _NgaySinh = DateTime.Today;
        private string _CMND =string.Empty;
        private DateTime _NgayCap = DateTime.Today;
        private string _NoiCap =string.Empty;
        private string _NoiSinh =string.Empty;
        private string _Dantoc =string.Empty;
        private string _TonGiao =string.Empty;
        private string _DiaCHiNV =string.Empty;
        private string _TrinhDoHocVan =string.Empty;
        private string _TrinhDoChuyenMon =string.Empty;

        private string _TenChucVu =string.Empty;
        private string _TenCongViec =string.Empty;
        private string _ChuyenNganh =string.Empty;   
		private string _tenBoPhan = string.Empty;
        
		
		private string _cmnd = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
		}

        public DateTime NgayVaoLam
		{
			get
			{
				CanReadProperty( true);
				return _ngayVaoLam;
			}          
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty( true);
				return _maQLNhanVien;
			}		
		}

	    public string TenNhanVien
		{
			get
			{
				CanReadProperty(true);
				return _tenNhanVien;
			}			
		}

        public string GioiTinh
		{
			get
			{
				CanReadProperty("GioiTinh", true);
				return _gioiTinh;
			}
        }

        public DateTime NgaySinh
		{
			get
			{
				CanReadProperty( true);
				return _NgaySinh;
			}          
		}

        public string CMND
		{
			get
			{
				CanReadProperty( true);
				return _CMND;
			}		
		}

        public DateTime NgayCap
		{
			get
			{
				CanReadProperty( true);
				return _NgayCap;
			}          
		}

        public string NoiCap
		{
			get
			{
				CanReadProperty( true);
				return _NoiCap ;
			}
			
		}

        public string NoiSinh
		{
			get
			{
				CanReadProperty( true);
				return _NoiSinh ;
			}
			
		}

        public string Dantoc
		{
			get
			{
				CanReadProperty( true);
				return _Dantoc ;
			}
			
		}

        public string TonGiao
		{
			get
			{
				CanReadProperty( true);
				return _TonGiao ;
			}
			
		}

        public string DiaCHiNV
		{
			get
			{
				CanReadProperty( true);
				return _DiaCHiNV ;
			}
			
		}

        public string TrinhDoHocVan
		{
			get
			{
				CanReadProperty( true);
				return _TrinhDoHocVan ;
			}
			
		}

        public string TrinhDoChuyenMon
		{
			get
			{
				CanReadProperty( true);
				return _TrinhDoChuyenMon ;
			}
			
		}

        public string TenChucVu
		{
			get
			{
				CanReadProperty("TenChucVu", true);
				return _TenChucVu;
			}		
		}

        public string TenCongViec
        {
            get
            {
                CanReadProperty( true);
                return _TenCongViec;
            }
        }

        public string ChuyenNganh
		{
			get
			{
				CanReadProperty( true);
				return _ChuyenNganh ;
			}			
		}

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }          
        }
 
		protected override object GetIdValue()
		{
			return _maNhanVien;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in TrichNgang
			//AuthorizationRules.AllowRead("MaNhanVien", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("CardID", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TenChucVu", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBan", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TenPhongBan", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("NgachLuong", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramBHXH", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TienBHXH", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramBHYT", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TienBHYT", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramiCongDoan", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramDanhGiaCB", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramDanhGiaKD", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoTienCongDoan", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TienNopThue", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoNgayCong", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoNgayLamViec", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TienThucLanh", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TienThucLanhTron", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhiDoan", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhiDang", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLCB", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("PhanTramLKD", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("LuongCB", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongCB", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoLam", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("NgayVaoLamString", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoTienHSCB", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("LuongKD", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuongKD", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("SoTienHSKD", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("TenChiNhanh", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("GioiTinh", "ThongTinNhanVienTongHopReadGroup");
			//AuthorizationRules.AllowRead("Cmnd", "ThongTinNhanVienTongHopReadGroup");

			//AuthorizationRules.AllowWrite("MaQLNhanVien", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("CardID", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TenChucVu", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBan", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TenPhongBan", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("NgachLuong", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramBHXH", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TienBHXH", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramBHYT", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TienBHYT", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramiCongDoan", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramDanhGiaCB", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramDanhGiaKD", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienCongDoan", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TienNopThue", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoNgayCong", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoNgayLamViec", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TienThucLanh", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TienThucLanhTron", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhiDoan", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhiDang", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLCB", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramLKD", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("LuongCB", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongCB", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("NgayVaoLamString", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienHSCB", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("LuongKD", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoLuongKD", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienHSKD", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("TenChiNhanh", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("GioiTinh", "ThongTinNhanVienTongHopWriteGroup");
			//AuthorizationRules.AllowWrite("Cmnd", "ThongTinNhanVienTongHopWriteGroup");
		}

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrichNgang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrichNgang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrichNgang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrichNgang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrichNgang()
		{ /* require use of factory method */ }

		public static TrichNgang NewTrichNgang(long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrichNgang");
			return DataPortal.Create<TrichNgang>(new Criteria(maNhanVien));
		}

		public static TrichNgang GetTrichNgang(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrichNgang");
			return DataPortal.Fetch<TrichNgang>(new Criteria(maNhanVien));
		}

		public static void DeleteTrichNgang(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrichNgang");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override TrichNgang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrichNgang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrichNgang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TrichNgang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TrichNgang(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}

		internal static TrichNgang NewTrichNgangChild(long maNhanVien)
		{
			TrichNgang child = new TrichNgang(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrichNgang GetTrichNgang(SafeDataReader dr)
		{
			TrichNgang child =  new TrichNgang();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}

        [Serializable()]
        private class Criteria_ChucVu
        {
            public long MaChucVu;

            public Criteria_ChucVu(int maChucVu)
            {
                this.MaChucVu = maChucVu;
            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_ThongTinNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
				}
			}//using
		}

		#endregion //Data Access - Fetch

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
            try
            {
           		 _maNhanVien = dr.GetInt64("Manhanvien");
                 _ngayVaoLam = dr.GetDateTime("NgayVaoLam");
                 _maQLNhanVien = dr.GetString("MAQlNhanVien");
                 _tenNhanVien = dr.GetString("TennHanvien");
                 if (dr.GetBoolean("Gioitinh"))
                 {
                     _gioiTinh = "Nam";
                 }
                 else
                 {
                     _gioiTinh = "Nữ";
                 }
                 _NgaySinh = dr.GetDateTime("NgaySinh");
                 _CMND = dr.GetString("CMND");
                 _NgayCap = dr.GetDateTime("NgayCap");
                 _NoiCap = dr.GetString("NoiCap");
                 _NoiSinh = dr.GetString("NoiSinh");
                 _Dantoc = dr.GetString("DanToc");
                 _TonGiao = dr.GetString("TenTonGiao");
                 _DiaCHiNV = dr.GetString("DiaChiNV");
                 _TrinhDoHocVan = dr.GetString("TrinhdoHOcVan");
                 _TrinhDoChuyenMon = dr.GetString("TrinhdoChuyenMon");

                 _TenChucVu = dr.GetString("TenChucvu");
                 _TenCongViec = dr.GetString("TenCongViec");
                 _ChuyenNganh = dr.GetString("ChuyenNganh");
                 _tenBoPhan = dr.GetString("TenBophan");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch


        #endregion //Data Access
    }
}

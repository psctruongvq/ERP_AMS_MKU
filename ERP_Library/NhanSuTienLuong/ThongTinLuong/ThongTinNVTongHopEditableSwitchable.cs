
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinNhanVienTongHop : Csla.BusinessBase<ThongTinNhanVienTongHop>
	{
        #region Business Properties and Methods
		//declare members
    
        private bool _Chon;
        private decimal _HeSoBu = 0;
        private decimal _HeSoDocHai = 0;
        private bool _PhuCapHC = false;
        private decimal _HeSoLuong = 0;
      //  private decimal _heSoLuong = 0;
        private decimal _HeSoPhuCapChucVu = 0;
        private decimal _HeSoLuongBaoHiem = 0;
        private decimal _HeSoLuongBoSung = 0;
        private decimal _heSoVuotKhung = 0;    
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;          
        
        private string _tenNhanVien = string.Empty;     
        private string _tenChucVu = string.Empty;
        private string _tenNganHang = string.Empty;      
        private string _tenBoPhan = string.Empty;
        private string _soTaiKhoan = string.Empty;

        private int _maBoPhan = 0;
        private int _maChucVu = 0;
        private int _maNganHang = 0;


        private string _cmnd = string.Empty;  
       
        private string _MaSoThue = string.Empty;
        private string _gioiTinh = string.Empty;
        private string _MaQLBoPhan = string.Empty;
        private decimal _ghiChu = 0;
        private int _soNguoiPhuThuoc = 0;


        public bool Chon
        {
            get { return _Chon; }
            set
            {
                _Chon = value;
            }
        }
        

        public string MaQLBoPhan
        {
            get
            {
                return _MaQLBoPhan; }
            set { _MaQLBoPhan = value; }
        }
       
      
      
     

        [System.ComponentModel.DataObjectField(true, true)]
        public string GioiTinh
        {
            get { return _gioiTinh; }
            set { _gioiTinh = value; }
        }
        public decimal SoTien
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }    
        public decimal HeSoDocHai
        {
            get
            {
                CanReadProperty("HeSoDocHai", true);
                return _HeSoDocHai;
            }
            set
            {
                CanWriteProperty("HeSoDocHai", true);
                if (!_HeSoDocHai.Equals(value))
                {
                    _HeSoDocHai = value;
                    PropertyHasChanged("HeSoDocHai");
                }
            }
        }
        public decimal HeSoBu
        {
            get
            {
                CanReadProperty("HeSoBu", true);
                return _HeSoBu;
            }
            set
            {
                CanWriteProperty("HeSoBu", true);
                if (!_HeSoBu.Equals(value))
                {
                    _HeSoBu = value;
                    PropertyHasChanged("HeSoBu");
                }
            }
        }
        public bool PhuCapHC
        {
            get
            {
                CanReadProperty("PhuCapHC", true);
                return _PhuCapHC;
            }
            set
            {
                CanWriteProperty("PhuCapHC", true);
                if (!_PhuCapHC.Equals(value))
                {
                    _PhuCapHC = value;
                    PropertyHasChanged("PhuCapHC");
                }
            }
        }
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }
      
        public decimal HeSoLuongBoSung
        {
            get
            {
                CanReadProperty("HeSoLuongBoSung", true);
                return _HeSoLuongBoSung;
            }
            set
            {
                CanWriteProperty("HeSoLuongBoSung", true);
                if (!_HeSoLuongBoSung.Equals(value))
                {
                    _HeSoLuongBoSung = value;
                    PropertyHasChanged("HeSoLuongBoSung");
                }
            }
        }
   
        public decimal HeSoLuongBaoHiem
        {
            get
            {
                CanReadProperty("HeSoLuongBaoHiem", true);
                // HeSoLuongBaoHiem = BacLuongNoiBo.GetBacLuongNoiBo(_MaBacLuongNoiBo).HeSoLuong;
                return _HeSoLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("HeSoLuongBaoHiem", true);
                if (!_HeSoLuongBaoHiem.Equals(value))
                {
                    _HeSoLuongBaoHiem = value;
                    //   HeSoLuongBaoHiem = BacLuongNoiBo.GetBacLuongNoiBo(_MaBacLuongNoiBo).HeSoLuong;
                    PropertyHasChanged("HeSoLuongBaoHiem");
                }
            }
        }
        public decimal HeSoPhuCapChucVu
        {
            get
            {
                CanReadProperty("HeSoPhuCapChucVu", true);
                return _HeSoPhuCapChucVu;
            }
            set
            {
                CanWriteProperty("HeSoPhuCapChucVu", true);
                if (!_HeSoPhuCapChucVu.Equals(value))
                {
                    _HeSoPhuCapChucVu = value;
                    PropertyHasChanged("HeSoPhuCapChucVu");
                }
            }
        }
        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return _maQLNhanVien;
            }
            set
            {
                CanWriteProperty("MaQLNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_maQLNhanVien.Equals(value))
                {
                    _maQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
                }
            }
        }
    
    
     
        public string MaSoThue
        {
            get
            {
                CanReadProperty("MaSoThue", true);
                return _MaSoThue;
            }
            set
            {
                CanWriteProperty("MaSoThue", true);
                if (value == null) value = string.Empty;
                if (!_MaSoThue.Equals(value))
                {
                    _MaSoThue = value;
                    PropertyHasChanged("MaSoThue");
                }
            }
        }
  

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                CanReadProperty("SoTaiKhoan", true);
                return _soTaiKhoan;
            }
            set
            {
                CanWriteProperty("SoTaiKhoan", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
                }
            }
        }


    

        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);
                return _tenChucVu;
            }
            set
            {
                CanWriteProperty("TenChucVu", true);
                if (value == null) value = string.Empty;
                if (!_tenChucVu.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucVu");
                }
            }
        }

            public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }

    

        public string Cmnd
        {
            get
            {
                CanReadProperty("Cmnd", true);
                return _cmnd;
            }
            set
            {
                CanWriteProperty("Cmnd", true);
                if (value == null) value = string.Empty;
                if (!_cmnd.Equals(value))
                {
                    _cmnd = value;
                    PropertyHasChanged("Cmnd");
                }
            }
        }        

   

       
        public decimal HeSoVuotKhung
        {
            get
            {
                CanReadProperty("HeSoVuotKhung", true);
                return _heSoVuotKhung;
            }
            set
            {
                CanWriteProperty("HeSoVuotKhung", true);
                if (!_heSoVuotKhung.Equals(value))
                {
                    _heSoVuotKhung = value;
                    PropertyHasChanged("HeSoVuotKhung");
                }
            }
        }
        public decimal HeSoLuong
        {
            get
            {
                CanReadProperty("HeSoLuong", true);
                return _HeSoLuong;
            }
            set
            {
                CanWriteProperty("HeSoLuong", true);
                if (!_HeSoLuong.Equals(value))
                {
                    _HeSoLuong = value;
                    PropertyHasChanged("HeSoLuong");
                }
            }
        }
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public int MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                CanWriteProperty("MaNganHang", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
                }
            }
        }
        public int MaChucVu
        {
            get
            {
                CanReadProperty("MaChucVu", true);
                return _maChucVu;
            }
            set
            {
                CanWriteProperty("MaChucVu", true);
                if (!_maChucVu.Equals(value))
                {
                    _maChucVu = value;
                    PropertyHasChanged("MaChucVu");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maNhanVien;
		}

        public int SoNguoiPhuThuoc
        {
            get
            {
                CanReadProperty("SoNguoiPhuThuoc", true);
                return _soNguoiPhuThuoc;
            }
            set
            {
                CanWriteProperty("SoNguoiPhuThuoc", true);
                if (!_soNguoiPhuThuoc.Equals(value))
                {
                    _soNguoiPhuThuoc = value;
                    PropertyHasChanged("SoNguoiPhuThuoc");
                }
            }
        }

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			//
			// MaQLNhanVien
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
			//
			// CardID
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CardID", 50));
			//
			// TenNhanVien
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// TenChucVu
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
			//
			// Cmnd
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 20));
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
			//TODO: Define authorization rules in ThongTinNhanVienTongHop
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
			//TODO: Define CanGetObject permission in ThongTinNhanVienTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinNhanVienTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinNhanVienTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinNhanVienTongHop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinNhanVienTongHopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinNhanVienTongHop()
		{ /* require use of factory method */ }
        private ThongTinNhanVienTongHop(string tenNhanVien)
        {
            this.TenNhanVien = tenNhanVien;
        }

		public static ThongTinNhanVienTongHop NewThongTinNhanVienTongHop(long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
			return DataPortal.Create<ThongTinNhanVienTongHop>(new Criteria(maNhanVien));
		}
        public static ThongTinNhanVienTongHop NewThongTinNhanVienTongHop(long maNhanVien,string tenNhanVien)
        {
            return new ThongTinNhanVienTongHop(tenNhanVien);
        }
      
		public static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
			return DataPortal.Fetch<ThongTinNhanVienTongHop>(new Criteria(maNhanVien));
		}
        public static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop(long maNhanVien,int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<ThongTinNhanVienTongHop>(new CriteriaByDataBase(maNhanVien,maBoPhan));
        }

        public static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop_ByMaQLNhanVien(string maQLNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ThongTinNhanVienTongHop");
            return DataPortal.Fetch<ThongTinNhanVienTongHop>(new Criteria_MaQLNhanVien(maQLNhanVien));
        }

		public static void DeleteThongTinNhanVienTongHop(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override ThongTinNhanVienTongHop Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinNhanVienTongHop");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinNhanVienTongHop");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThongTinNhanVienTongHop");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThongTinNhanVienTongHop(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}

		internal static ThongTinNhanVienTongHop NewThongTinNhanVienTongHopChild(long maNhanVien)
		{
			ThongTinNhanVienTongHop child = new ThongTinNhanVienTongHop(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop(SafeDataReader dr)
		{
			ThongTinNhanVienTongHop child =  new ThongTinNhanVienTongHop();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop(SafeDataReader dr, int bien)
        {
            ThongTinNhanVienTongHop child = new ThongTinNhanVienTongHop();
            child.MarkAsChild();
            child.Fetch(dr, bien);
            return child;
        }

        internal static ThongTinNhanVienTongHop GetThongTinNhanVienTongHop_New(SafeDataReader dr)
        {
            ThongTinNhanVienTongHop child = new ThongTinNhanVienTongHop();
            child.MarkAsChild();
            child.Fetch_New(dr);
            return child;
        }

        internal static ThongTinNhanVienTongHop GetThongTinNhanVienTongHopBaoCaoThue(SafeDataReader dr)
        {
            ThongTinNhanVienTongHop child = new ThongTinNhanVienTongHop();
            child.MarkAsChild();
            child.FetchBaoCaoThue(dr);
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
       
		private class CriteriaByDataBase
		{
			public long MaNhanVien;
            public int maBoPhan;
            public CriteriaByDataBase(long maNhanVien,int maBoPhan)
			{
				this.MaNhanVien = maNhanVien;
                this.maBoPhan = maBoPhan;
			}
            
		}
        private class Criteria_MaQLNhanVien
        {
            public string MaQLNhanVien;

            public Criteria_MaQLNhanVien(string maQLNhanVien)
            {
                this.MaQLNhanVien = maQLNhanVien;
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
		private void DataPortal_Fetch(object criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}
        //private void DataPortal_Fetch(Criteria_MaQLNhanVien criteria)
        //{
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        ExecuteFetch(cn, criteria);
        //    }//using
        //}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            if(criteria is Criteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ThongTinNhanVien";

                    cm.Parameters.AddWithValue("@MaNhanVien",((Criteria) criteria).MaNhanVien);

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
            if (criteria is CriteriaByDataBase)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ThongTinNhanVien_ByDatabase";

                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByDataBase)criteria).MaNhanVien);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByDataBase)criteria).maBoPhan);
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
            else if (criteria is Criteria_MaQLNhanVien)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    string MaTimKiem = ((Criteria_MaQLNhanVien)criteria).MaQLNhanVien.ToString().Trim();

                    string sqlCmd = "SELECT " +
                         " tblnsNhanVien.MaNhanVien AS MaNhanVien," +
                         " tblnsNhanVien.MaQLNhanVien AS MaQLNhanVien," +
                         " tblnsNhanVien.CardID AS CardID," +
                         " tblnsNhanVien.TenNhanVien AS TenNhanVien," +
                         " tblnsNhanVien.TenChucVu AS TenChucVu," +
                         " tblnsNhanVien.MaChucVu AS MaChucVu," +
                         " tblnsNhanVien.MaChucDanh AS MaChucDanh, " +
                         " tblnsNhanVien.MaKiemNhiem as MaKiemNhiem," +
                         " tblnsNhanVien.MaBoPhan AS MaBoPhan," +
                          " tblnsNhanVien.MaSoThue as MaSoThue," +
                         " tblnsNhanVien.TheNhaBao AS TheNhaBao," +
                         " tblnsNhanVien.TenboPhan AS TenBoPhan," +
                         " V_BoPhan.MaBoPhanCha As MaBoPhanCha," +
                         " tblnsCongViec.MaCongViec as MacongViec," +
                         " tblnsCongViec.TenCongViec as TenCongViec," +
                         " V_BoPhan.TenBoPhanCha As TenBoPhanCha," +
                         " tblnsBiaHoSo.TenBiaHoSo as TenBiaHoSo," +
                         " tblnsSoBaoHiemXaHoi.SoSoBaoHiem as SoBaoHiemXaHoi," +
                         " tblnsSoBaoHiemYTe.SoSoBaoHiem as SoBaoHiemYTe," +
                         " tblnsThongTinCongTy.PhanTramBHXH AS PhanTramBHXH," +
                         " tblnsThongTinCongTy.TienBHXH AS TienBHXH, " +
                         " tblnsThongTinCongTy.PhanTramBHYT AS PhanTramBHYT," +
                         " tblnsThongTinCongTy.TienBHYT AS TienBHYT," +
                         " tblnsThongTinCongTy.SoTienCongDoan AS SoTienCongDoan," +
                         " tblnsThongTinCongTy.SoNgayLamViec AS SoNgayLamViec," +
                         " tblnsThongTinCongTy.NgayVaoLam AS NgayVaoLam," +
                         " tblnsNhanVien.GioiTinh AS GioiTinh," +
                         " tblnsNhanVien.CMND AS CMND," +
                         " tblTinhThanh.TenTinhThanh As NoiSinh" +

                         " FROM      tblnsNhanVien INNER JOIN " +
                                     " tblnsThongTinCongTy ON tblnsNhanVien.MaNhanVien = tblnsThongTinCongTy.MaNhanVien  " +
                                     " left join V_BoPhan on V_BoPhan.MaBoPhanCon=tblnsNhanVien.MaBoPhan " +
                                     " left join tblnsCongViec on tblnsCongViec.MaCongViec=tblnsNhanVien.MaCongViec " +
                                     " left join tblnsBiaHoSo on tblnsBiaHoSo.MaBiaHoSo=tblnsThongTinCongTy.MaBiaHoSo " +
                                     " left join tblnsSoBaoHiemYTe on tblnsSoBaoHiemYTe.MaNhanVien=tblnsNhanVien.MaNhanVien " +
                                     " left join tblnsSoBaoHiemXaHoi on tblnsSoBaoHiemXaHoi.MaNhanVien=tblnsNhanVien.MaNhanVien " +
                                     " left join tblTinhThanh on tblTinhThanh.MaTinhThanh=tblnsNhanVien.MaNoiSinh" +
                                     //" where substring(tblnsNhanVien.MaQLNhanVien,7,5) = '"+MaTimKiem+"'";
                                     " where tblnsNhanVien.MaQLNhanVien = '" + MaTimKiem + "'";
                        //" where	 patindex('%"+ MaTimKiem + "%',tblnsNhanVien.MAQLNhanVien)<>0";

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimNhanVienByMaQuanLy";

                    // cm.Parameters.AddWithValue("@DieuKienTim", ((FilterCriteria)criteria).chuoi);
                    cm.Parameters.AddWithValue("@chuoi", sqlCmd);
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

            }//else
			
		}

		#endregion //Data Access - Fetch

    
        #region Data Access - Fetch
        private void FetchBaoCaoThue(SafeDataReader dr)
        {
            _MaQLBoPhan = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _cmnd = dr.GetString("CMND");
            _MaSoThue = dr.GetString("MaSoThue");
            _soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            _tenChucVu = dr.GetString("LoaiNhanVien");
            MarkOld();
        }


        private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

        private void Fetch(SafeDataReader dr, int bien)
        {
            FetchObject(dr, bien);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void Fetch_New(SafeDataReader dr)
        {
            FetchObject_New(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

		private void FetchObject(SafeDataReader dr)
		{
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");                
                _tenNhanVien = dr.GetString("TenNhanVien");                
                _tenChucVu = dr.GetString("TenChucVu");
                _cmnd = dr.GetString("CMND");                            
                _MaSoThue = dr.GetString("MaSoThue");                
                _HeSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
                _HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
                _HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");                
                _HeSoBu = dr.GetDecimal("HeSoBu");
                _HeSoDocHai = dr.GetDecimal("HeSoDocHai");
                _PhuCapHC = dr.GetBoolean("PhuCapHC");                
                _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
                _HeSoLuong = dr.GetDecimal("HeSoLuong");
                _gioiTinh = dr.GetString("Phai");
                _MaQLBoPhan = dr.GetString("MaBoPhanQL");
                _maBoPhan = dr.GetInt32("MaBoPhan");
                _tenBoPhan = dr.GetString("TenBoPhan");
                _maChucVu = dr.GetInt32("MaChucVu");
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

        private void FetchObject(SafeDataReader dr, int bien)
        {
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenChucVu = dr.GetString("TenChucVu");
                _cmnd = dr.GetString("CMND");
                _MaSoThue = dr.GetString("MaSoThue");
                _HeSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
                _HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
                _HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
                _HeSoBu = dr.GetDecimal("HeSoBu");
                _HeSoDocHai = dr.GetDecimal("HeSoDocHai");
                _PhuCapHC = dr.GetBoolean("PhuCapHC");
                _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
                _HeSoLuong = dr.GetDecimal("HeSoLuong");
                _gioiTinh = dr.GetString("Phai");
                _MaQLBoPhan = dr.GetString("MaBoPhanQL");
                _maBoPhan = dr.GetInt32("MaBoPhan");
                _tenBoPhan = dr.GetString("TenBoPhan");
                _maChucVu = dr.GetInt32("MaChucVu");
                _tenNganHang = dr.GetString("TenNganHang");
                _soTaiKhoan = dr.GetString("SoTaiKhoan");
                _maNganHang = dr.GetInt32("MaNganHang");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Thành làm (25/04/2012)
        private void FetchObject_New(SafeDataReader dr)
        {
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _maQLNhanVien = dr.GetString("MaQLNhanVien");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _tenChucVu = dr.GetString("TenChucVu");
                _cmnd = dr.GetString("CMND");
                _MaSoThue = dr.GetString("MaSoThue");
                _HeSoLuongBoSung = dr.GetDecimal("HeSoLuongBoSung");
                _HeSoPhuCapChucVu = dr.GetDecimal("HeSoPhuCapChucVu");
                _HeSoLuongBaoHiem = dr.GetDecimal("HeSoLuongBaoHiem");
                _HeSoBu = dr.GetDecimal("HeSoBu");
                _HeSoDocHai = dr.GetDecimal("HeSoDocHai");
                _PhuCapHC = dr.GetBoolean("PhuCapHC");
                _heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
                _HeSoLuong = dr.GetDecimal("HeSoLuong");
                _gioiTinh = dr.GetString("Phai");
                //_MaQLBoPhan = dr.GetString("MaBoPhanQL");
                //_maBoPhan = dr.GetInt32("MaBoPhan");
                //_tenBoPhan = dr.GetString("TenBoPhan");
                //_maChucVu = dr.GetInt32("MaChucVu");

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
        public static void ThemVaoBia(string manhanvien, int mabiaHoso)
        {
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using(SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Update tblnsthongtincongty set Mabiahoso=" + mabiaHoso + " where manhanvien=" + manhanvien + "";
                    cm.ExecuteNonQuery();
                }
            }
        }

        public static void BoraKhoiBia(string manhanvien)
        {
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using(SqlCommand cm=cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "Update tblnsthongtincongty set Mabiahoso=null where manhanvien=" + manhanvien + "";
                    cm.ExecuteNonQuery();
                }
            }
        }
    }
}

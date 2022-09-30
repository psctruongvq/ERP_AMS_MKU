
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThuLaoChuongTrinh : Csla.BusinessBase<ThuLaoChuongTrinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThuLao = 0;
		private string _maQL = string.Empty;
		private int _maChuongTrinh = 0;
		private long _maNhanVien = 0;
		private int _maKyTinhLuong = 0;
        private int _maGiayXacNhan = 0;
        private int _maChiTietGiayXacNhan = 0;
        private int _maPhanBoThuLaoChuongTrinh = 0;
		private decimal _soTien = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _nguoiLap = 0;
        
        private string _tenNhanVien = string.Empty;
        private string _maPhieuChi = string.Empty;
        private string _dienGiai = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _maQLBoPhan= string.Empty;
        private bool _tinhDangPhi=false;
        private string _tenGiayXacNhan = string.Empty;

        private string _TenChuongTrinh = string.Empty;

        private byte _phanTramThue = 0;
        private decimal _tienThue = 0;
        private decimal _soTienConLai = 0;      
        
        private bool _thanhToan = false;
        private bool _thucNhan = true;
      
        private int _maBoPhan = 0;
        private int _maPhanBoThuLao = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenChucVu = string.Empty;
        private int _maChucVu = 0;
        private string _soChungTu = string.Empty;
        private long _maChungTu = 0;
        private long _maChiThuLao = 0;
       // private int _dBNumberMaChiThuLao = 0;
        private int _maNguonChuongTrinh = 0;
        private string _tenNguonChuongTrinh = string.Empty;
        private bool _duocNhapHo = false;
        private long _maChungTuDeNghi = 0;
        private string _tenNguoiLap = string.Empty;


        [System.ComponentModel.DataObjectField(true, false)]
        public string TenNguoiLap
        {
            get
            {

                return _tenNguoiLap;
            }
            set
            {
                CanWriteProperty("TenNguoiLap", true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLap.Equals(value))
                {
                    _tenNguoiLap = value;
                    PropertyHasChanged("TenNguoiLap");
                }
            }

        }
        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _TenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_TenChuongTrinh.Equals(value))
                {
                    _TenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
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

        public string MaQLBoPhan
        {
            get
            {
                CanReadProperty("MaQLBoPhan", true);
                return _maQLBoPhan;
            }
            set
            {
                CanWriteProperty("MaQLBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_maQLBoPhan.Equals(value))
                {
                    _maQLBoPhan = value;
                    PropertyHasChanged("MaQLBoPhan");
                }
            }
        }

        public int MaThuLao
		{
			get
			{
				CanReadProperty("MaThuLao", true);
				return _maThuLao;
			}
		}              

		public string MaQL
		{
			get
			{
				CanReadProperty("MaQL", true);
				return _maQL;
			}
			set
			{
				CanWriteProperty("MaQL", true);
				if (value == null) value = string.Empty;
				if (!_maQL.Equals(value))
				{
					_maQL = value;
					PropertyHasChanged("MaQL");
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

		public int MaChuongTrinh
		{
			get
			{
				CanReadProperty("MaChuongTrinh", true);
				return _maChuongTrinh;
			}
			set
			{
				CanWriteProperty("MaChuongTrinh", true);
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

        public int MaPhanBoThuLaoChuongTrinh
        {
            get
            {
                CanReadProperty("MaPhanBoThuLaoChuongTrinh", true);
                return _maPhanBoThuLaoChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaPhanBoThuLaoChuongTrinh", true);
                if (!_maPhanBoThuLaoChuongTrinh.Equals(value))
                {
                    _maPhanBoThuLaoChuongTrinh = value;
                    PropertyHasChanged("MaPhanBoThuLaoChuongTrinh");
                }
            }
        }


        public int MaPhanBoThuLao
        {
            get
            {
                CanReadProperty("MaPhanBoThuLao", true);
                return _maPhanBoThuLao;
            }
            set
            {
                CanWriteProperty("MaPhanBoThuLao", true);
                if (!_maPhanBoThuLao.Equals(value))
                {
                    _maPhanBoThuLao = value;
                    PropertyHasChanged("MaPhanBoThuLao");
                }
            }
        }
        public int MaChiTietGiayXacNhan
        {
            get
            {
                CanReadProperty("MaChiTietGiayXacNhan", true);
                return _maChiTietGiayXacNhan;
            }
            set
            {
                CanWriteProperty("MaChiTietGiayXacNhan", true);
                if (!_maChiTietGiayXacNhan.Equals(value))
                {
                    _maChiTietGiayXacNhan = value;
                    PropertyHasChanged("MaChiTietGiayXacNhan");
                }
            }
        }
        public byte PhanTramThue
        {
            get
            {
                CanReadProperty("PhanTramThue", true);
                return _phanTramThue;
            }
            set
            {
                CanWriteProperty("PhanTramThue", true);
                _phanTramThue = 0;
                PropertyHasChanged("PhanTramThue");
                //if (!_phanTramThue.Equals(value))
                //{
                //    _phanTramThue = value;
                //    PropertyHasChanged("PhanTramThue");
                //}
            }
        }
        public int MaGiayXacNhan
        {
            get
            {
                CanReadProperty("MaGiayXacNhan", true);
                return _maGiayXacNhan;
            }
            set
            {
                CanWriteProperty("MaGiayXacNhan", true);
                if (!_maGiayXacNhan.Equals(value))
                {
                    _maGiayXacNhan = value;
                    PropertyHasChanged("MaGiayXacNhan");
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
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
                
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
                    _tienThue = 0;
                    _soTien = value;
					PropertyHasChanged("SoTien");
                    
                    //if (_phanTramThue == 0)
                    //{
                    //    _tienThue = 0;
                    //    _soTienConLai = Math.Round( _soTien,0);
                    //}
                    //else
                    //{
                    //    _tienThue = Math.Round( _soTien * _phanTramThue / 100,0);
                    //    _soTienConLai = Math.Round(_soTien,0) - _tienThue;
                    //}
				}
			}
		}

       
		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}
        	
		public int NguoiLap
		{
			get
			{
				CanReadProperty("NguoiLap", true);
				return _nguoiLap;
			}
			set
			{
				CanWriteProperty("NguoiLap", true);
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
			}
		}

        public string MaPhieuChi
        {
            get
            {
                CanReadProperty("MaPhieuChi", true);                
                return _maPhieuChi;
            }
            set
            {
                CanWriteProperty("MaPhieuChi", true);
                if (value == null) value = string.Empty;
                if (!_maPhieuChi.Equals(value))
                {
                    _maPhieuChi = value;
                    PropertyHasChanged("MaPhieuChi");
                }
            }
        }
        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }
        public bool TinhDangPhi
        {
            get
            {
                CanReadProperty("TinhDangPhi", true);
                return _tinhDangPhi;
            }
            set
            {
                CanWriteProperty("TinhDangPhi", true);
                if (!_tinhDangPhi.Equals(value))
                {
                    _tinhDangPhi = value;
                    PropertyHasChanged("TinhDangPhi");
                }
            }
        }
        public string TenGiayXacNhan
        {
            get
            {
                CanReadProperty("TenGiayXacNhan", true);
                //_tenGiayXacNhan = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(_maGiayXacNhan).TenGiayXacNhan;
                return _tenGiayXacNhan;
            }
            set
            {
                CanWriteProperty("TenGiayXacNhan", true);
                if (value == null) value = string.Empty;
                if (!_tenGiayXacNhan.Equals(value))
                {
                    _tenGiayXacNhan = value;
                    PropertyHasChanged("TenGiayXacNhan");
                }
            }
         
        }
      
        public bool ThanhToan
        {
            get
            {
                CanReadProperty("ThanhToan", true);
                return _thanhToan;
            }
            set
            {
                CanWriteProperty("ThanhToan", true);
                if (!_thanhToan.Equals(value))
                {
                    _thanhToan = value;
                    PropertyHasChanged("ThanhToan");
                }
            }
        }
        public bool ThucNhan
        {
            get
            {
                CanReadProperty("ThucNhan", true);
                return _thucNhan;
            }
            set
            {
                CanWriteProperty("ThucNhan", true);
                if (!_thucNhan.Equals(value))
                {
                    _thucNhan = value;
                    PropertyHasChanged("ThucNhan");
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
        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }
        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }
        public long MaChiThuLao
        {
            get
            {
                CanReadProperty("MaChiThuLao", true);
                return _maChiThuLao;
            }
            set
            {
                CanWriteProperty("MaChiThuLao", true);
                if (!_maChiThuLao.Equals(value))
                {
                    _maChiThuLao = value;
                    PropertyHasChanged("MaChiThuLao");
                }
            }
        }
     
        public int MaNguonChuongTrinh
        {
            get
            {
                CanReadProperty("MaNguonChuongTrinh", true);
                return _maNguonChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaNguonChuongTrinh", true);
                if (!_maNguonChuongTrinh.Equals(value))
                {
                    _maNguonChuongTrinh = value;
                    PropertyHasChanged("MaNguonChuongTrinh");
                }
            }
        }
        public string TenNguonChuongTrinh
        {
            get
            {
                CanReadProperty("TenNguonChuongTrinh", true);
                return _tenNguonChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenNguonChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenNguonChuongTrinh.Equals(value))
                {
                    _tenNguonChuongTrinh = value;
                    PropertyHasChanged("TenNguonChuongTrinh");
                }
            }
        }
        public bool DuocNhapHo
        {
            get
            {
                CanReadProperty("DuocNhapHo", true);
                return _duocNhapHo;
            }
            set
            {
                CanWriteProperty("DuocNhapHo", true);
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
                }
            }
        }
        public long MaChungTuDeNghi
        {
            get
            {
                CanReadProperty("MaChungTuDeNghi", true);
                return _maChungTuDeNghi;
            }
            set
            {
                CanWriteProperty("MaChungTuDeNghi", true);
                if (!_maChungTuDeNghi.Equals(value))
                {
                    _maChungTuDeNghi = value;
                    PropertyHasChanged("MaChungTuDeNghi");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maThuLao;
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
			// MaQL
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 10));
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
			//TODO: Define authorization rules in ThuLaoChuongTrinh
			//AuthorizationRules.AllowRead("MaThuLao", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaQL", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinh", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ThuLaoChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "ThuLaoChuongTrinhReadGroup");

			//AuthorizationRules.AllowWrite("MaQL", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuongTrinh", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ThuLaoChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "ThuLaoChuongTrinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThuLaoChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThuLaoChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThuLaoChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThuLaoChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThuLaoChuongTrinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules


		#region Factory Methods
		private ThuLaoChuongTrinh()
		{ /* require use of factory method */
            MarkAsChild();
        }
       
        public static ThuLaoChuongTrinh NewThuLaoChuongTrinh()
        {
            ThuLaoChuongTrinh item = new ThuLaoChuongTrinh();
           
            item.MarkAsChild();
            return item;
        }

		public static ThuLaoChuongTrinh NewThuLaoChuongTrinh(int maThuLao)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThuLaoChuongTrinh");
			return DataPortal.Create<ThuLaoChuongTrinh>(new Criteria(maThuLao));
		}

		public static ThuLaoChuongTrinh GetThuLaoChuongTrinh(int maThuLao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThuLaoChuongTrinh");
			return DataPortal.Fetch<ThuLaoChuongTrinh>(new Criteria(maThuLao));
		}
        public static void UpdateDangPhi(int maThuLao,bool dangPhi)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "updatetlnsThuLaoChuongTrinh_DangPhi";
                cm.Parameters.AddWithValue("@MaThuLao", maThuLao);
                cm.Parameters.AddWithValue("@DangPhi", dangPhi);

                cm.ExecuteNonQuery();

            }
        }
      
        public static void InsertThuLaoChuaChuyenKhoan(int maKyTinhLuongMoi,DateTime ngayChuyen,ThuLaoChuongTrinh tl)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 600;
                cm.CommandText = "spd_InserttblnsThuLaoChuongTrinhChuaChuyenKhoan";

                cm.Parameters.AddWithValue("@MaThuLao", tl._maThuLao);
                cm.Parameters.AddWithValue("@MaKyTinhLuongChuyen", maKyTinhLuongMoi);
                cm.Parameters.AddWithValue("@NgayChuyen", ngayChuyen);
                if (tl._maQL.Length > 0)
                    cm.Parameters.AddWithValue("@MaQL",tl._maQL);
                else
                    cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
                if (tl._maChuongTrinh != 0)
                    cm.Parameters.AddWithValue("@MaChuongTrinh",tl._maChuongTrinh);
                else
                    cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
                if (tl._maNhanVien != 0)
                    cm.Parameters.AddWithValue("@MaNhanVien",tl._maNhanVien);
                else
                    cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
                if (tl._maKyTinhLuong != 0)
                    cm.Parameters.AddWithValue("@MaKyTinhLuong",tl._maKyTinhLuong);
                else
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);

                cm.Parameters.AddWithValue("@SoTien",tl._soTien);

                cm.Parameters.AddWithValue("@NgayLap", tl.NgayLap);
                if (tl._nguoiLap != 0)
                    cm.Parameters.AddWithValue("@NguoiLap",tl.NguoiLap);
                else
                    cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
              
                if (tl._maPhieuChi.Length > 0)
                    cm.Parameters.AddWithValue("@MaPhieuChi",tl._maPhieuChi);
                else
                    cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
                if (tl._dienGiai.Length != 0)
                    cm.Parameters.AddWithValue("@DienGiai",tl._dienGiai);
                else
                    cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
                if (tl._tenGiayXacNhan.Length != 0)
                    cm.Parameters.AddWithValue("@TenGiayXacNhan",tl._tenGiayXacNhan);
                else
                    cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
                cm.Parameters.AddWithValue("@PhanTramThue",tl._phanTramThue);
                if (tl._phanTramThue == 0)
                {
                    cm.Parameters.AddWithValue("@TienThue", 0);
                    cm.Parameters.AddWithValue("@SoTienConLai",tl._soTien);
                }
                else
                {
                    cm.Parameters.AddWithValue("@TienThue",tl._soTien *tl._phanTramThue / 100);
                    cm.Parameters.AddWithValue("@SoTienConLai",tl._soTien - (tl._soTien *tl._phanTramThue / 100));
                }
                cm.Parameters.AddWithValue("@TinhDangPhi",tl._tinhDangPhi);
                if (tl._maGiayXacNhan != 0)
                    cm.Parameters.AddWithValue("@MaGiayXacNhan",tl._maGiayXacNhan);
                else
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
                if (tl._maChiTietGiayXacNhan != 0)
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan",tl._maChiTietGiayXacNhan);
                else
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
              
                cm.Parameters.AddWithValue("@ThanhToan",tl._thanhToan);
                cm.Parameters.AddWithValue("@ThucNhan",tl._thucNhan);
               

                if (tl._tenNhanVien.Length > 0)
                    cm.Parameters.AddWithValue("@TenNhanVien",tl._tenNhanVien);
                else
                    cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
                if (tl._maBoPhan != 0)
                    cm.Parameters.AddWithValue("@MaBoPhan",tl._maBoPhan);
                else
                    cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                if (tl._tenBoPhan.Length > 0)
                    cm.Parameters.AddWithValue("@TenBoPhan",tl._tenBoPhan);
                else
                    cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
                if (tl._maChucVu != 0)
                    cm.Parameters.AddWithValue("@MaChucVu",tl._maChucVu);
                else
                    cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
                if (tl._tenChucVu.Length > 0)
                    cm.Parameters.AddWithValue("@TenChucVu",tl._tenChucVu);
                else
                    cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
                if (tl._maQLNhanVien.Length > 0)
                    cm.Parameters.AddWithValue("@MaQLNhanVien",tl._maQLNhanVien);
                else
                    cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
                if (tl._TenChuongTrinh.Length > 0)
                    cm.Parameters.AddWithValue("@TenChuongTrinh",tl._TenChuongTrinh);
                else
                    cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
                if (tl._soChungTu.Length > 0)
                    cm.Parameters.AddWithValue("@SoChungTu",tl._soChungTu);
                else
                    cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
                if (tl._maChungTu != 0)
                    cm.Parameters.AddWithValue("@MaChungTu",tl._maChungTu);
                else
                    cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
                if (tl._maChiThuLao != 0)
                    cm.Parameters.AddWithValue("@MaChiThuLao",tl._maChiThuLao);
                else
                    cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
            
                if (tl._maNguonChuongTrinh != 0)
                    cm.Parameters.AddWithValue("@MaNguonChuongTrinh",tl._maNguonChuongTrinh);
                else
                    cm.Parameters.AddWithValue("@MaNguonChuongTrinh", DBNull.Value);
                if (tl._tenNguonChuongTrinh.Length > 0)
                    cm.Parameters.AddWithValue("@TenNguonChuongTrinh",tl._tenNguonChuongTrinh);
                else
                    cm.Parameters.AddWithValue("@TenNguonChuongTrinh", DBNull.Value);
                cm.Parameters.AddWithValue("@DuocNhapHo",tl._duocNhapHo);

                cm.ExecuteNonQuery();

            }
        }
		public static void DeleteThuLaoChuongTrinh(int maThuLao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThuLaoChuongTrinh");
			DataPortal.Delete(new Criteria(maThuLao));
		}

		public override ThuLaoChuongTrinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThuLaoChuongTrinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThuLaoChuongTrinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThuLaoChuongTrinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ThuLaoChuongTrinh(int maThuLao)
		{
			this._maThuLao = maThuLao;
		}

		internal static ThuLaoChuongTrinh NewThuLaoChuongTrinhChild(int maThuLao)
		{
			ThuLaoChuongTrinh child = new ThuLaoChuongTrinh(maThuLao);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThuLaoChuongTrinh GetThuLaoChuongTrinh(SafeDataReader dr)
		{
			ThuLaoChuongTrinh child =  new ThuLaoChuongTrinh();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static ThuLaoChuongTrinh GetThuLaoChuongTrinhByNew(SafeDataReader dr)
        {
            ThuLaoChuongTrinh child = new ThuLaoChuongTrinh();
            child.MarkAsChild();
            child.FetchByNew(dr);
            return child;
        }

        internal static ThuLaoChuongTrinh GetThuLaoChuongTrinhByNgayLap(SafeDataReader dr)
        {
            ThuLaoChuongTrinh child = new ThuLaoChuongTrinh(); 
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");          
            child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            child._maPhieuChi = dr.GetString("MaPhieuChi");
            child._TenChuongTrinh = dr.GetString("TenChuongTrinh"); 
            child._soTien = dr.GetDecimal("SoTien");
            child._ngayLap = dr.GetSmartDate("NgayLap");
            child._tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            child._maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
          //  child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child._maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child._soChungTu = dr.GetString("SoChungTu");
            child._maChungTu = dr.GetInt64("MaChungTu");
            child._maChiThuLao = dr.GetInt64("MaChiThuLao");
            child.TenNguoiLap  = Security.UserItem.GetUserItem(dr.GetInt32("NguoiLap")).TenDangNhap;
            child._duocNhapHo = dr.GetBoolean("DuocNhapHo");
            //child._maChungTuDeNghi = dr.GetInt64("MaChungTuDeNghi");
            child.MarkAsChild();
            child.MarkOld();
            return child;
        }
        internal static ThuLaoChuongTrinh GetThuLaoChuongTrinhByPhieuChi(SafeDataReader dr)
        {
          
            ThuLaoChuongTrinh child = new ThuLaoChuongTrinh();
            child._maThuLao = dr.GetInt32("MaThuLao");
            child._maQL = dr.GetString("MaQL");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            child._soTien = dr.GetDecimal("SoTien");
            child._ngayLap = dr.GetSmartDate("NgayLap");
            child._nguoiLap = dr.GetInt32("NguoiLap");
            child._maPhieuChi = dr.GetString("MaPhieuChi");
            child._dienGiai = dr.GetString("DienGiai");
            child._maQLNhanVien = dr.GetString("MaQLNhanVien");
            child._maQLBoPhan = dr.GetString("MaQLBoPhan");
            child._tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._maQLNhanVien = dr.GetString("MaQLNhanVien");
            child._maQLBoPhan = dr.GetString("MaQLBoPhan");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._TenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._maChiThuLao = dr.GetInt64("MaChiThuLao");
            child._phanTramThue = dr.GetByte("PhanTramThue");
            child._duocNhapHo = dr.GetBoolean("DuocNhapHo");
            child._maChungTuDeNghi = dr.GetInt64("MaChungTuDeNghi");
            child._maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            child.TenBoPhan = dr.GetString("TenBoPhan");
            child.MarkAsChild();
            child.MarkOld();
            return child;
        }
        internal static ThuLaoChuongTrinh GetThuLaoChuongTrinhByCopyTienMat(SafeDataReader dr)
        {
            ThuLaoChuongTrinh child = new ThuLaoChuongTrinh();
            child._maThuLao = dr.GetInt32("MaThuLao");
            child._maQL = dr.GetString("MaQL");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            child._soTien = dr.GetDecimal("SoTien");
            child._ngayLap = dr.GetSmartDate("NgayLap");
            child._nguoiLap = dr.GetInt32("NguoiLap");
            child._maPhieuChi = dr.GetString("MaPhieuChi");
            child._dienGiai = dr.GetString("DienGiai");
            child._maQLNhanVien = dr.GetString("MaQLNhanVien");
            child._maQLBoPhan = dr.GetString("MaQLBoPhan");
            child._tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._maQLNhanVien = dr.GetString("MaQLNhanVien");
            child._maQLBoPhan = dr.GetString("MaQLBoPhan");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._TenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._maChiThuLao = dr.GetInt64("MaChiThuLao");
            child._phanTramThue = dr.GetByte("PhanTramThue");
            child._duocNhapHo = dr.GetBoolean("DuocNhapHo");
            child._maChungTuDeNghi = dr.GetInt64("MaChungTuDeNghi");
            child._maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            child.MarkAsChild();
            //Not Old
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaThuLao;

			public Criteria(int maThuLao)
			{
				this.MaThuLao = maThuLao;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maThuLao = criteria.MaThuLao;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
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
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsThuLaoChuongTrinh";

				cm.Parameters.AddWithValue("@MaThuLao", criteria.MaThuLao);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
                    {
                        FetchObject(dr);
                       // ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr, null);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr, null);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maThuLao));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsThuLaoChuongTrinh";

				cm.Parameters.AddWithValue("@MaThuLao", criteria.MaThuLao);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
		    FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}
        private void FetchByNew(SafeDataReader dr)
        {
            FetchObject(dr);
           
        }

		private void FetchObject(SafeDataReader dr)
		{
			_maThuLao = dr.GetInt32("MaThuLao");
			_maQL = dr.GetString("MaQL");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_soTien = dr.GetDecimal("SoTien");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _nguoiLap = dr.GetInt32("NguoiLap");
            _maPhieuChi = dr.GetString("MaPhieuChi");
            _dienGiai = dr.GetString("DienGiai");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _maQLBoPhan = dr.GetString("MaQLBoPhan");
            _phanTramThue = dr.GetByte("PhanTramThue");
            _tienThue = dr.GetDecimal("TienThue");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            _maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
            _tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            _maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
          
            _thanhToan = dr.GetBoolean("ThanhToan");
            _thucNhan = dr.GetBoolean("ThucNhan");
          
            _tenNhanVien = dr.GetString("TenNhanVien");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _tenChucVu = dr.GetString("TenChucVu");
            _maChucVu = dr.GetInt32("MaChucVu");
            _TenChuongTrinh = dr.GetString("TenChuongTrinh");
            _soChungTu = dr.GetString("SoChungTu");
            _maChungTu=dr.GetInt64("MaChungTu");
            _maChiThuLao = dr.GetInt64("MaChiThuLao");
           
            _maNguonChuongTrinh = dr.GetInt32("MaNguonChuongTrinh");
            _tenNguonChuongTrinh = dr.GetString("TenNguonChuongTrinh");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _maChungTuDeNghi = dr.GetInt64("MaChungTuDeNghi");
           _tenNguoiLap= Security.UserItem.GetUserItem(_nguoiLap).TenDangNhap;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ThuLaoChuongTrinhList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ThuLaoChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThuLaoChuongTrinh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maThuLao = (int)cm.Parameters["@MaThuLao"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ThuLaoChuongTrinhList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
           
			if (_maQL.Length > 0)
				cm.Parameters.AddWithValue("@MaQL", _maQL);
			else
				cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
		
				cm.Parameters.AddWithValue("@SoTien", Math.Round( _soTien,0));
		
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThuLao", 0);
            cm.Parameters["@MaThuLao"].Direction = ParameterDirection.Output;
            if(_maPhieuChi.Length>0) 
            cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
            cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_dienGiai.Length != 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_tenGiayXacNhan.Length != 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            if (_phanTramThue==0)
            {
                cm.Parameters.AddWithValue("@TienThue", 0);
                cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0));
            }
            else
            {
                cm.Parameters.AddWithValue("@TienThue", Math.Round( (Math.Round( _soTien,0) * _phanTramThue / 100),0));
                cm.Parameters.AddWithValue("@SoTienConLai", (Math.Round( _soTien,0) - Math.Round((Math.Round(_soTien, 0) * _phanTramThue / 100), 0)));
            }
            cm.Parameters.AddWithValue("@TinhDangPhi", _tinhDangPhi);
            if(_maGiayXacNhan!=0)
            cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            else
            cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
            if (_maChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
        
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            cm.Parameters.AddWithValue("@ThucNhan", _thucNhan);
                
          
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan",_maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maChucVu != 0)
                cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
            else
                cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
            if (_tenChucVu.Length > 0)
                cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
            else
                cm.Parameters.AddWithValue("@TenChucVu", DBNull.Value);
            if (_maQLNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
            else
                cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
            if (_TenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _TenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if(_maChungTu!=0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
         
            if (_maNguonChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaNguonChuongTrinh", _maNguonChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaNguonChuongTrinh", DBNull.Value);
            if (_tenNguonChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenNguonChuongTrinh", _tenNguonChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenNguonChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);

            if (_maPhanBoThuLao != 0)
                cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
            else
                cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);


		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ThuLaoChuongTrinhList parent)
		{
			if (!IsDirty) return;
            if (_maChungTuDeNghi != 0)
                return;
			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, ThuLaoChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsThuLaoChuongTrinh";                
				AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ThuLaoChuongTrinhList parent)
        {
         
            cm.Parameters.AddWithValue("@MaThuLao", _maThuLao);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);

            cm.Parameters.AddWithValue("@SoTien", Math.Round( _soTien,0));

            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maPhieuChi.Length > 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_dienGiai.Length != 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            if (_phanTramThue==0)
            {
                cm.Parameters.AddWithValue("@TienThue", 0);
                cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0));
            }
            else
            {
                cm.Parameters.AddWithValue("@TienThue", Math.Round( (Math.Round( _soTien,0) * _phanTramThue / 100),0));
                cm.Parameters.AddWithValue("@SoTienConLai", (Math.Round( _soTien,0) - Math.Round((Math.Round(_soTien, 0) * _phanTramThue / 100), 0)));
            }
            cm.Parameters.AddWithValue("@TinhDangPhi", _tinhDangPhi);
            if (_maGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
            if (_tenGiayXacNhan.Length != 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            if (_maChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
          

            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            cm.Parameters.AddWithValue("@ThucNhan", _thucNhan);
            if (_TenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _TenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_maChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
           
            if (_maNguonChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaNguonChuongTrinh", _maNguonChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaNguonChuongTrinh", DBNull.Value);
            if (_tenNguonChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenNguonChuongTrinh", _tenNguonChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenNguonChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
        }

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            if (_maChungTuDeNghi != 0)
                return;
			ExecuteDelete(tr, new Criteria(_maThuLao));
			MarkNew();
		}
		#endregion //Data Access - Delete

      
		#endregion //Data Access
	}
}

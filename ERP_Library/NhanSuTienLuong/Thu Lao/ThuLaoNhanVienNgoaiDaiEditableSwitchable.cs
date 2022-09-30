
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThuLaoNhanVienNgoaiDai : Csla.BusinessBase<ThuLaoNhanVienNgoaiDai>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThuLao = 0;
        private long _maNhanVien = 0;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private int _maGiayXacNhan = 0;
		private string _tenGiayXacNhan = string.Empty;
		private int _maChiTietGiayXacNhan = 0;
        private long _maPhanBoThuLaoNgoaiDai = 0;
		private int _maKyTinhLuong = 0;
		private string _dienGiai = string.Empty;
		private decimal _soTien = 0;
		private int _nguoiLap = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
	
		private string _maPhieuChi = string.Empty;
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private long _maChiThuLao = 0;
		
		private int _maBoPhan = 0;
        private int _maPhanBoThuLao = 0;
		private string _maQLBoPhan = string.Empty;
		private string _tenBoPhan = string.Empty;
		private string _tenNhanVien = string.Empty;
		private byte _phanTramThue = 0;
		private decimal _tienThue = 0;
		private decimal _soTienConLai = 0;
        private bool _duocNhapHo = false;
        private bool _thanhToan = false;
        private string _diaChi = string.Empty;
        private string _tenNguoiLap = string.Empty;
        private SmartDate _ngayChungTu = new SmartDate(DateTime.Today);
        private int _loai = 0;
        private long _maNhanVienChuyenTien = 0;
        private long _MaNhanVienTrongDai = 0;
        private int _maNganHang = 0;
        private string _soTaiKhoan = string.Empty;


       
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }
        private string _cmnd = string.Empty;

        public string Cmnd
        {
            get { return _cmnd; }
            set { _cmnd = value; }
        }
        private string _maSoThue = string.Empty;

        public string MaSoThue
        {
            get { return _maSoThue; }
            set { _maSoThue = value; }
        }
        private string _dienThoai = string.Empty;

        public string DienThoai
        {
            get { return _dienThoai; }
            set { _dienThoai = value; }
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaThuLao
		{
			get
			{
				CanReadProperty("MaThuLao", true);
				return _maThuLao;
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
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

        public long MaPhanBoThuLaoNgoaiDai
        {
            get
            {
                CanReadProperty("MaPhanBoThuLaoNgoaiDai", true);
                return _maPhanBoThuLaoNgoaiDai;
            }
            set
            {
                if (!_maPhanBoThuLaoNgoaiDai.Equals(value))
                {
                    _maPhanBoThuLaoNgoaiDai = value;
                    PropertyHasChanged("MaPhanBoThuLaoNgoaiDai");
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

		public string TenChuongTrinh
		{
			get
			{
				CanReadProperty("TenChuongTrinh", true);
				return _tenChuongTrinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChuongTrinh.Equals(value))
				{
					_tenChuongTrinh = value;
					PropertyHasChanged("TenChuongTrinh");
				}
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
				if (!_maGiayXacNhan.Equals(value))
				{
					_maGiayXacNhan = value;
					PropertyHasChanged("MaGiayXacNhan");
				}
			}
		}

		public string TenGiayXacNhan
		{
			get
			{
				CanReadProperty("TenGiayXacNhan", true);
				return _tenGiayXacNhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenGiayXacNhan.Equals(value))
				{
					_tenGiayXacNhan = value;
					PropertyHasChanged("TenGiayXacNhan");
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
				if (!_maChiTietGiayXacNhan.Equals(value))
				{
					_maChiTietGiayXacNhan = value;
					PropertyHasChanged("MaChiTietGiayXacNhan");
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
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
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
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
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
					_soTien = value;
					PropertyHasChanged("SoTien");
                    //if (_phanTramThue == 0)
                    //{
                    //    _tienThue = 0;
                    //    _soTienConLai = _soTien;
                    //}
                    //else
                    //{
                    //    _tienThue = _soTien * _phanTramThue / 100;
                    //    _soTienConLai = _soTien - _tienThue;
                    //}
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
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
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

	
	

		public string MaPhieuChi
		{
			get
			{
				CanReadProperty("MaPhieuChi", true);
				return _maPhieuChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maPhieuChi.Equals(value))
				{
					_maPhieuChi = value;
					PropertyHasChanged("MaPhieuChi");
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
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
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
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
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
				if (!_maChiThuLao.Equals(value))
				{
					_maChiThuLao = value;
					PropertyHasChanged("MaChiThuLao");
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
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
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
				if (value == null) value = string.Empty;
				if (!_maQLBoPhan.Equals(value))
				{
					_maQLBoPhan = value;
					PropertyHasChanged("MaQLBoPhan");
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
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
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
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
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
				if (!_phanTramThue.Equals(value))
				{
					_phanTramThue = value;
					PropertyHasChanged("PhanTramThue");
				}
			}
		}

		public decimal TienThue
		{
			get
			{
				CanReadProperty("TienThue", true);
				return _tienThue;
			}
			set
			{
				if (!_tienThue.Equals(value))
				{
					_tienThue = value;
					PropertyHasChanged("TienThue");
				}
			}
		}

		public decimal SoTienConLai
		{
			get
			{
				CanReadProperty("SoTienConLai", true);
				return _soTienConLai;
			}
			set
			{
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
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
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
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
                if (!_thanhToan.Equals(value))
                {
                    _thanhToan = value;
                    PropertyHasChanged("ThanhToan");
                }
            }
        }
        public string TenNguoiLap
        {
            get { return _tenNguoiLap; }
            set { _tenNguoiLap = value; }
        }


        public DateTime NgayChungTu
        {
            get
            {
                CanReadProperty("NgayChungTu", true);
                return _ngayChungTu.Date;
            }
            set
            {
                CanWriteProperty("NgayChungTu", true);
                if (!_ngayChungTu.Equals(value))
                {
                    _ngayChungTu = new SmartDate(value);
                    PropertyHasChanged("NgayChungTu");
                }
            }
        }



        public int Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }


        public long MaNhanVienChuyenTien
        {
            get
            {
                CanReadProperty("MaNhanVienChuyenTien", true);
                return _maNhanVienChuyenTien;
            }
            set
            {
                if (!_maNhanVienChuyenTien.Equals(value))
                {
                    _maNhanVienChuyenTien = value;
                    PropertyHasChanged("MaNhanVienChuyenTien");
                }
            }
        }

        public long MaNhanVienTrongDai
        {
            get
            {
                CanReadProperty("MaNhanVienTrongDai", true);
                return _MaNhanVienTrongDai;
            }
            set
            {
                if (!_MaNhanVienTrongDai.Equals(value))
                {
                    _MaNhanVienTrongDai = value;
                    PropertyHasChanged("MaNhanVienTrongDai");
                }
            }
        }

        public Int32 MaNganHang
        {
            get
            {
                CanReadProperty("MaNganHang", true);
                return _maNganHang;
            }
            set
            {
                if (!_maNganHang.Equals(value))
                {
                    _maNganHang = value;
                    PropertyHasChanged("MaNganHang");
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
                if (value == null) value = string.Empty;
                if (!_soTaiKhoan.Equals(value))
                {
                    _soTaiKhoan = value;
                    PropertyHasChanged("SoTaiKhoan");
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
		
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ThuLaoNhanVienNgoaiDai()
		{ /* require use of factory method */ }

		public static ThuLaoNhanVienNgoaiDai NewThuLaoNhanVienNgoaiDai()
		{
            ThuLaoNhanVienNgoaiDai item = new ThuLaoNhanVienNgoaiDai();
            item.MarkAsChild();
            return item;
		}

		public static ThuLaoNhanVienNgoaiDai GetThuLaoNhanVienNgoaiDai(int maThuLao)
		{
			return DataPortal.Fetch<ThuLaoNhanVienNgoaiDai>(new Criteria(maThuLao));
		}

		public static void DeleteThuLaoNhanVienNgoaiDai(int maThuLao)
		{
			DataPortal.Delete(new Criteria(maThuLao));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThuLaoNhanVienNgoaiDai NewThuLaoNhanVienNgoaiDaiChild()
		{
			ThuLaoNhanVienNgoaiDai child = new ThuLaoNhanVienNgoaiDai();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}
        internal static ThuLaoNhanVienNgoaiDai GetThuLaoChuongTrinhByNgayLap(SafeDataReader dr)
        {
            try
            {
                ThuLaoNhanVienNgoaiDai child = new ThuLaoNhanVienNgoaiDai();

                child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
                child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
                child._maPhieuChi = dr.GetString("MaPhieuChi");
                child._tenChuongTrinh = dr.GetString("TenChuongTrinh");
                child._soTien = dr.GetDecimal("SoTien");
                child._ngayLap = dr.GetSmartDate("NgayLap");
                child._tienThue = dr.GetDecimal("TienThue");
                child._soTienConLai = dr.GetDecimal("SoTienConLai");
                child._maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
                child._maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
                child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
                child._soChungTu = dr.GetString("SoChungTu");
                child._maChungTu = dr.GetInt64("MaChungTu");
                child._maChiThuLao = dr.GetInt64("MaChiThuLao");
                child.TenNguoiLap = dr.GetString("TenDangNhap");
                child._ngayChungTu = dr.GetSmartDate("NgayChungTu");
                child._thanhToan = dr.GetBoolean("ThanhToan");
                child._duocNhapHo = dr.GetBoolean("DuocNhapHo");
                //child._MaNhanVienTrongDai= dr.GetInt64("MaNhanVienTrongDai");
                child.MarkAsChild();
                child.MarkOld();
                return child;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
		internal static ThuLaoNhanVienNgoaiDai GetThuLaoNhanVienNgoaiDai(SafeDataReader dr)
		{
			ThuLaoNhanVienNgoaiDai child =  new ThuLaoNhanVienNgoaiDai();
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
			public int MaThuLao;

			public Criteria(int maThuLao)
			{
				this.MaThuLao = maThuLao;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
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
                cm.CommandText = "usp_SelecttblnsThuLaoNhanVienNgoaiDai";

				cm.Parameters.AddWithValue("@MaThuLao", criteria.MaThuLao);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
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
                cm.CommandText = "usp_DeletetblnsThuLaoNhanVienNgoaiDai";

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

		private void FetchObject(SafeDataReader dr)
		{
            _maNhanVien = dr.GetInt64("MaNhanVien");
			_maThuLao = dr.GetInt32("MaThuLao");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_dienGiai = dr.GetString("DienGiai");
			_soTien = dr.GetDecimal("SoTien");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maPhieuChi = dr.GetString("MaPhieuChi");
			_maChungTu = dr.GetInt64("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_maChiThuLao = dr.GetInt64("MaChiThuLao");			
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maQLBoPhan = dr.GetString("MaQLBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_phanTramThue = dr.GetByte("PhanTramThue");
			_tienThue = dr.GetDecimal("TienThue");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _thanhToan = dr.GetBoolean("ThanhToan");
            _diaChi = dr.GetString("DiaChi");
            _maSoThue = dr.GetString("MaSoThue");
            _cmnd = dr.GetString("CMND");
            _dienThoai = dr.GetString("DienThoai");
            _maNhanVienChuyenTien = dr.GetInt64("MaNhanVienChuyenTien");
            _MaNhanVienTrongDai = dr.GetInt64("MaNhanVienTrongDai");
            
		}

        internal static ThuLaoNhanVienNgoaiDai GetThuLaoNgoaiDaiByCopyTienMat(SafeDataReader dr)
        {

            ThuLaoNhanVienNgoaiDai child = new ThuLaoNhanVienNgoaiDai();
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._maThuLao = dr.GetInt32("MaThuLao");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child._tenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
            child._tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            child._maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            child._dienGiai = dr.GetString("DienGiai");
            child._soTien = dr.GetDecimal("SoTien");
            child._nguoiLap = dr.GetInt32("NguoiLap");
            child._ngayLap = dr.GetSmartDate("NgayLap", child._ngayLap.EmptyIsMin);
            child._maPhieuChi = dr.GetString("MaPhieuChi");
            child._maChungTu = dr.GetInt64("MaChungTu");
            child._soChungTu = dr.GetString("SoChungTu");
            child._maChiThuLao = dr.GetInt64("MaChiThuLao");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._maQLBoPhan = dr.GetString("MaQLBoPhan");
            child._tenBoPhan = dr.GetString("TenBoPhan");
            child._tenNhanVien = dr.GetString("TenNhanVien");
            child._phanTramThue = dr.GetByte("PhanTramThue");
            child._tienThue = dr.GetDecimal("TienThue");
            child._soTienConLai = dr.GetDecimal("SoTienConLai");
            child._duocNhapHo = dr.GetBoolean("DuocNhapHo");
            child._thanhToan = dr.GetBoolean("ThanhToan");
            child._diaChi = dr.GetString("DiaChi");
            child._maSoThue = dr.GetString("MaSoThue");
            child._cmnd = dr.GetString("CMND");
            child._dienThoai = dr.GetString("DienThoai");
            child._maNhanVienChuyenTien = dr.GetInt64("MaNhanVienChuyenTien");
            child._MaNhanVienTrongDai = dr.GetInt64("MaNhanVienTrongDai");
            child.MarkAsChild();
            //Not Old
            return child;
        }

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ThuLaoNhanVienNgoaiDaiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ThuLaoNhanVienNgoaiDaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_InserttblnsThuLaoNhanVienNgoaiDai";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maThuLao = (int)cm.Parameters["@MaThuLao"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ThuLaoNhanVienNgoaiDaiList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (@MaChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_maGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
            if (_tenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            if (_maChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTien", Math.Round( _soTien,0));
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);

            cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
            if (_maPhieuChi.Length > 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);

            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maQLBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
            else
                cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);

            cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@SoTienConLai", SoTienConLai);
            
            //cm.Parameters.AddWithValue("@TienThue", Math.Round( _tienThue,0));
            //cm.Parameters.AddWithValue("@SoTienConLai", Math.Round( _soTienConLai,0));

            //if (_phanTramThue == 0)
            //{
            //    cm.Parameters.AddWithValue("@TienThue", 0);
            //    cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0));
            //}
            //else
            //{
            //    cm.Parameters.AddWithValue("@TienThue", Math.Round(Math.Round(_soTien, 0) * _phanTramThue / 100, 0));
            //    cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0) - Math.Round(Math.Round(_soTien, 0) * _phanTramThue / 100, 0));
            //}

            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            cm.Parameters.AddWithValue("@MaThuLao", _maThuLao);
            cm.Parameters["@MaThuLao"].Direction = ParameterDirection.Output;

            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVien);

            if (_MaNhanVienTrongDai != 0)
                cm.Parameters.AddWithValue("@MaNhanVienTrongDai", _MaNhanVienTrongDai);
            else
                cm.Parameters.AddWithValue("@MaNhanVienTrongDai", DBNull.Value);

            if (_maPhanBoThuLao != 0)
                cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
            else
                cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);
        }
        public static void InsertThuLaoChuaChuyenKhoan(int maKyTinhLuongMoi, DateTime ngayChuyen, ThuLaoNhanVienNgoaiDai tl)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsThuLaoCongTacVienChuaChuyenKhoan";

                cm.Parameters.AddWithValue("@MaThuLao", tl._maThuLao);
                cm.Parameters.AddWithValue("@MaKyTinhLuongChuyen", maKyTinhLuongMoi);
                cm.Parameters.AddWithValue("@NgayChuyen", ngayChuyen);
             
             
                cm.ExecuteNonQuery();

            }
        }
	
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ThuLaoNhanVienNgoaiDaiList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, ThuLaoNhanVienNgoaiDaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_UpdatetblnsThuLaoNhanVienNgoaiDai";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ThuLaoNhanVienNgoaiDaiList parent)
        {
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@MaThuLao", _maThuLao);
            cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_maGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhan", _maGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
            if (_tenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", _tenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            if (_maChiTietGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTien", Math.Round( _soTien,0));
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
          
            if (_maPhieuChi.Length > 0)
                cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            else
                cm.Parameters.AddWithValue("@MaPhieuChi", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChiThuLao != 0)
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);
          
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maQLBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
            else
                cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);

            cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@SoTienConLai", SoTienConLai);
            //if(_loai!=1
            //if (_phanTramThue == 0)
            //{
            //    cm.Parameters.AddWithValue("@TienThue", 0);
            //    cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0));
            //}
            //else
            //{
            //    cm.Parameters.AddWithValue("@TienThue", Math.Round(Math.Round(_soTien, 0) * _phanTramThue / 100, 0));
            //    cm.Parameters.AddWithValue("@SoTienConLai", Math.Round(_soTien, 0) - Math.Round(Math.Round(_soTien, 0) * _phanTramThue / 100, 0));
            //}

            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_cmnd.Length > 0)
                cm.Parameters.AddWithValue("@CMND", _cmnd);
            else
                cm.Parameters.AddWithValue("@CMND", DBNull.Value);
            if (_maSoThue.Length > 0)
                cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
            else
                cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
            cm.Parameters.AddWithValue("@Loai", _loai);

            if (_maNhanVienChuyenTien != 0)
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVienChuyenTien);
            else
                cm.Parameters.AddWithValue("@MaNhanVienChuyenTien", _maNhanVien);
            if (_MaNhanVienTrongDai != 0)
                cm.Parameters.AddWithValue("@MaNhanVienTrongDai", _MaNhanVienTrongDai);
            else
                cm.Parameters.AddWithValue("@MaNhanVienTrongDai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maThuLao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

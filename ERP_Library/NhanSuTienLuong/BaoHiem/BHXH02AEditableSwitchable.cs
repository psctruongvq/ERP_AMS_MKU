
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.Timers;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BHXH02A : Csla.BusinessBase<BHXH02A>
	{
        int _soThangDongBoSung = 0;
        decimal _tongHeSoDongBHXH =0;
        decimal _tongHeSoDongBHYT = 0;
        decimal _tongHeSoDongBHTN = 0;
        decimal _soTienBHXHDongBoSung=0;
        decimal _soTienBHYTDongBoSung=0;
        decimal _soTienBHTNDongBoSung = 0;
        decimal _luongCoBan = 0;
		#region Business Properties and Methods

		//declare members
		private int _maMauBH02A = 0;
		private int _kyTinhBaoHiem = 0;
		private long _maNhanVien = 0;
		private SmartDate _ngaySinh = new SmartDate(DateTime.Today.Date);
		private bool _gioiTinh = false;
		private string _cmnd = string.Empty;
		private int _maTheBHYT = 0;
		private int _maSoBaoHiemXH = 0;
		private decimal _heSoLuong = 0;
		private decimal _heSoPhuCap = 0;
		private decimal _heSoVuotKhung = 0;
		private decimal _heSoThamNien = 0;
		private decimal _heSoKhuVuc = 0;
        private bool _dongBHTN = false;      
        private SmartDate _thamGiaTu = new SmartDate(DateTime.Today.Date);
        private SmartDate _thamGiaDen = new SmartDate(DateTime.Today.Date);
		private string _ghiChu = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _soSoBHXH = string.Empty;
        private string _soTheBHYT = string.Empty;
        private string _noiDangKyKCB_Tinh = string.Empty;
        private string _noiDangKyKCB_BenhVien = string.Empty;
        [System.ComponentModel.DataObjectField(true, true)]
        public string TenNhanVien
        {
            get
            {
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _tenNhanVien; 
            }
            set { _tenNhanVien = value; }
        }
        public string SoSoBHXH
        {
            get
            {
                _soSoBHXH = SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(MaSoBaoHiemXH).SoSoBaoHiem;
                return _soSoBHXH; 
            }
            set { _soSoBHXH = value; }
        }

        public string SoTheBHYT
        {
            get 
            {
                _soTheBHYT = TheBaoHiemYTe.GetTheBaoHiemYTe(MaTheBHYT).SoTheBHYT;
                return _soTheBHYT; 
            }
            set { _soTheBHYT = value; }
        }
		
		public int MaMauBH02A
		{
			get
			{
				return _maMauBH02A;
			}
		}

		public int KyTinhBaoHiem
		{
			get
			{
				return _kyTinhBaoHiem;
			}
			set
			{
				if (!_kyTinhBaoHiem.Equals(value))
				{
					_kyTinhBaoHiem = value;
					PropertyHasChanged("KyTinhBaoHiem");
				}
			}
		}

		public long MaNhanVien
		{
			get
			{
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
                    _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public DateTime NgaySinh
		{
			get
			{
				return _ngaySinh.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = new SmartDate(value);
                    PropertyHasChanged("NgaySinh");
                }
            }
		}
	
		public bool GioiTinh
		{
			get
			{
				return _gioiTinh;
			}
			set
			{
				if (!_gioiTinh.Equals(value))
				{
					_gioiTinh = value;
					PropertyHasChanged("GioiTinh");
				}
			}
		}
        public string NoiDangKyKCB_Tinh
        {
            get { return _noiDangKyKCB_Tinh; }
            set { _noiDangKyKCB_Tinh = value; }
        }

        public string NoiDangKyKCB_BenhVien
        {
            get { return _noiDangKyKCB_BenhVien; }
            set { _noiDangKyKCB_BenhVien = value; }
        }
		public string Cmnd
		{
			get
			{
				return _cmnd;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_cmnd.Equals(value))
				{
					_cmnd = value;
					PropertyHasChanged("Cmnd");
				}
			}
		}

		public int MaTheBHYT
		{
			get
			{
               // _soTheBHYT = TheBaoHiemYTe.GetTheBaoHiemYTe(MaTheBHYT).SoTheBHYT;
				return _maTheBHYT;
			}
			set
			{
				if (!_maTheBHYT.Equals(value))
				{
					_maTheBHYT = value;
                    _soTheBHYT = TheBaoHiemYTe.GetTheBaoHiemYTe(MaTheBHYT).SoTheBHYT;
					PropertyHasChanged("MaTheBHYT");
				}
			}
		}

		public int MaSoBaoHiemXH
		{
			get
			{
              //  _soSoBHXH = SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(MaSoBaoHiemXH).SoSoBaoHiem;
				return _maSoBaoHiemXH;
			}
			set
			{
				if (!_maSoBaoHiemXH.Equals(value))
				{
					_maSoBaoHiemXH = value;
                    _soSoBHXH = SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(MaSoBaoHiemXH).SoSoBaoHiem;
					PropertyHasChanged("MaSoBaoHiemXH");
				}
			}
		}

		public decimal HeSoLuong
		{
			get
			{
				return _heSoLuong;
			}
			set
			{
				if (!_heSoLuong.Equals(value))
				{
					_heSoLuong = value;
					PropertyHasChanged("HeSoLuong");
				}
			}
		}

		public decimal HeSoPhuCap
		{
			get
			{
				return _heSoPhuCap;
			}
			set
			{
				if (!_heSoPhuCap.Equals(value))
				{
					_heSoPhuCap = value;
					PropertyHasChanged("HeSoPhuCap");
				}
			}
		}

		public decimal HeSoVuotKhung
		{
			get
			{
				return _heSoVuotKhung;
			}
			set
			{
				if (!_heSoVuotKhung.Equals(value))
				{
					_heSoVuotKhung = value;
					PropertyHasChanged("HeSoVuotKhung");
				}
			}
		}

		public decimal HeSoThamNien
		{
			get
			{
				return _heSoThamNien;
			}
			set
			{
				if (!_heSoThamNien.Equals(value))
				{
					_heSoThamNien = value;
					PropertyHasChanged("HeSoThamNien");
				}
			}
		}

		public decimal HeSoKhuVuc
		{
			get
			{
				return _heSoKhuVuc;
			}
			set
			{
				if (!_heSoKhuVuc.Equals(value))
				{
					_heSoKhuVuc = value;
					PropertyHasChanged("HeSoKhuVuc");
				}
			}
		}
        public bool DongBHTN
        {
            get { return _dongBHTN; }
            set { _dongBHTN = value; }
        }
		public DateTime ThamGiaTu
		{
			get
			{
				return _thamGiaTu.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_thamGiaTu.Equals(value))
                {
                    _thamGiaTu = new SmartDate(value);
                    PropertyHasChanged("ThamGiaTu");
                }
            }
		}


		public DateTime ThamGiaDen
		{
			get
			{
				return _thamGiaDen.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_thamGiaDen.Equals(value))
                {
                    _thamGiaDen = new SmartDate(value);
                    PropertyHasChanged("ThamGiaDen");
                }
            }
		}


		public string GhiChu
		{
			get
			{
				return _ghiChu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maMauBH02A;
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
			// Cmnd
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
			//
			// GhiChu
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private BHXH02A()
		{ /* require use of factory method */ }

		public static BHXH02A NewBHXH02A()
		{
			return DataPortal.Create<BHXH02A>();
		}
        public static BHXH02A NewBHXH02A(long maNhanVien,int MaKyTinhBaoHiem,DateTime thamGiaTuNgay,DateTime ngayHienHanh,string ghiChu)
        {
            NhanVien nv = NhanVien.GetNhanVien(maNhanVien);
            TheBaoHiemYTe theBHYT = TheBaoHiemYTe.GetTheBaoHiemYTe(maNhanVien);
            SoBaoHiemXaHoi soBHXH = SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(maNhanVien);
            BaoHiemThatNghiep baoHiemTN = BaoHiemThatNghiep.GetBaoHiemThatNghiep(maNhanVien);
            NoiDangKyKCB noiDangKyKCB = NoiDangKyKCB.GetNoiDangKyKCB(theBHYT.MaNoiDangKyKCB);
            BHXH02A item = new BHXH02A();
            item.MarkAsChild();
            item.MaNhanVien = maNhanVien;
            item.KyTinhBaoHiem = MaKyTinhBaoHiem;
            item.NgaySinh = nv.NgaySinh;
            item.GioiTinh = nv.GioiTinh;
            item.Cmnd = nv.Cmnd;
            item.HeSoLuong = nv.HeSoLuongBaoHiem;
            item.HeSoPhuCap = nv.HeSoPhuCapChucVu;
            item.HeSoVuotKhung = nv.HeSoVuotKhung;
            item.MaSoBaoHiemXH = soBHXH.MaSoBaoHiemXH;
            item.MaTheBHYT = theBHYT.MaTheBHYT;
            item.ThamGiaTu = thamGiaTuNgay;
            item.ThamGiaDen = ngayHienHanh;
            item._noiDangKyKCB_Tinh = noiDangKyKCB.MaQLTinhThanhKCB;
            item._noiDangKyKCB_BenhVien = noiDangKyKCB.MaQLBenhVienKCB;
            if (maNhanVien == baoHiemTN.MaNhanVien)
            {
                item.DongBHTN = true;
            }
            else
                item.DongBHTN = false;
            item.GhiChu = ghiChu;
            return item;
            
        }

		public static BHXH02A GetBHXH02A(int maMauBH02A)
		{
			return DataPortal.Fetch<BHXH02A>(new Criteria(maMauBH02A));
		}

		public static void DeleteBHXH02A(int maMauBH02A)
		{
			DataPortal.Delete(new Criteria(maMauBH02A));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BHXH02A NewBHXH02AChild()
		{
			BHXH02A child = new BHXH02A();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BHXH02A GetBHXH02A(SafeDataReader dr)
		{
			BHXH02A child =  new BHXH02A();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static BHXH02A GetDSLap2ATBH(SafeDataReader dr)
        {
            BHXH02A item = new BHXH02A();
            item.MarkAsChild();
            item.MaNhanVien = dr.GetInt64("MaNhanVien");
            item.TenNhanVien = dr.GetString("TenNhanVien");
            item.GhiChu = dr.GetString("TenHinhThucHopDong")+ ". Ngày tăng: "+Convert.ToDateTime( dr.GetDateTime("NgayKy")).ToString("dd/MM/yyyy");
            item.NgaySinh = dr.GetDateTime("NgayKy");
            return item;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaMauBH02A;

			public Criteria(int maMauBH02A)
			{
				this.MaMauBH02A = maMauBH02A;
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
                cm.CommandText = "spd_SelecttblnsBHXH02A";

				cm.Parameters.AddWithValue("@MaMauBH02A", criteria.MaMauBH02A);

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
			DataPortal_Delete(new Criteria(_maMauBH02A));
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
                    UpdateChildren3(tr);
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
                cm.CommandText = "spd_DeletetblnsBHXH02A";

				cm.Parameters.AddWithValue("@MaMauBH02A", criteria.MaMauBH02A);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

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
			_maMauBH02A = dr.GetInt32("MaMauBH02A");
			_kyTinhBaoHiem = dr.GetInt32("KyTinhBaoHiem");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_ngaySinh = dr.GetSmartDate("NgaySinh", _ngaySinh.EmptyIsMin);
			_gioiTinh = dr.GetBoolean("GioiTinh");
			_cmnd = dr.GetString("CMND");
			_maTheBHYT = dr.GetInt32("MaTheBHYT");
			_maSoBaoHiemXH = dr.GetInt32("MaSoBaoHiemXH");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
			_heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
			_heSoThamNien = dr.GetDecimal("HeSoThamNien");
			_heSoKhuVuc = dr.GetDecimal("HeSoKhuVuc");
            _dongBHTN = dr.GetBoolean("DongBHTN");
			_thamGiaTu = dr.GetSmartDate("ThamGiaTu", _thamGiaTu.EmptyIsMin);
			_thamGiaDen = dr.GetSmartDate("ThamGiaDen", _thamGiaDen.EmptyIsMin);
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BHXH02AList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BHXH02AList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
                cm.Parameters.Clear();
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsBHXH02A";
				AddInsertParameters(cm, parent);
				cm.ExecuteNonQuery();                
				_maMauBH02A = (int)cm.Parameters["@MaMauBH02A"].Value;

                ////Insert into tblnsTongHop02ATBH
                //cm.Parameters.Clear();
                //cm.CommandType = CommandType.StoredProcedure;
                //cm.CommandText = "BHXH02A";
                //cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                //cm.Parameters.AddWithValue("@MaKyTinhBaoHiem", _kyTinhBaoHiem);
                //cm.ExecuteNonQuery();
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BHXH02AList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
		
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", _kyTinhBaoHiem);
			
		
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			
			cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
			
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
			
			
				cm.Parameters.AddWithValue("@CMND", _cmnd);
		
		
				cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
		
		
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			
			
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			
			
				cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
		
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			
			cm.Parameters.AddWithValue("@HeSoThamNien", _heSoThamNien);
		
				cm.Parameters.AddWithValue("@HeSoKhuVuc", _heSoKhuVuc);
		
			cm.Parameters.AddWithValue("@ThamGiaTu", _thamGiaTu.DBValue);
			cm.Parameters.AddWithValue("@ThamGiaDen", _thamGiaDen.DBValue);
			
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
		
            cm.Parameters.AddWithValue("@DongBHTN", _dongBHTN);
			cm.Parameters.AddWithValue("@MaMauBH02A", _maMauBH02A);
			cm.Parameters["@MaMauBH02A"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BHXH02AList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren1(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, BHXH02AList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBHXH02A";
				AddUpdateParameters(cm, parent);
				cm.ExecuteNonQuery();

               
			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BHXH02AList parent)
		{
			cm.Parameters.AddWithValue("@MaMauBH02A", _maMauBH02A);
			
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", _kyTinhBaoHiem);
		
		
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
		
			cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
			
				cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
		
		
				cm.Parameters.AddWithValue("@CMND", _cmnd);
		
				cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
			
		
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			
			
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			
		
				cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
			
		
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			
			cm.Parameters.AddWithValue("@HeSoThamNien", _heSoThamNien);
		
				cm.Parameters.AddWithValue("@HeSoKhuVuc", _heSoKhuVuc);
			
			cm.Parameters.AddWithValue("@ThamGiaTu", _thamGiaTu.DBValue);
			cm.Parameters.AddWithValue("@ThamGiaDen", _thamGiaDen.DBValue);
			
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			
            cm.Parameters.AddWithValue("@DongBHTN", _dongBHTN);
		}
        private void UpdateChildren1(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {

                _luongCoBan = Default_Ngay.GetDefault_Ngay().LuongCoBan;
                _soThangDongBoSung = HamDungChung.GetMonthsDiff(ThamGiaTu, ThamGiaDen);
                _tongHeSoDongBHXH = _heSoLuong + _heSoPhuCap + _heSoVuotKhung;
                _tongHeSoDongBHYT = _heSoLuong + _heSoPhuCap + _heSoVuotKhung + _heSoKhuVuc;
                _tongHeSoDongBHTN = _tongHeSoDongBHYT;
                _soTienBHXHDongBoSung = _tongHeSoDongBHXH * _soThangDongBoSung * _luongCoBan;
                _soTienBHYTDongBoSung = _tongHeSoDongBHYT * _soThangDongBoSung * _luongCoBan;
                _soTienBHTNDongBoSung = _tongHeSoDongBHTN * _soThangDongBoSung * _luongCoBan;
                //Insert into tblnsTongHop02ATBH
                cm.Parameters.Clear();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsTongHop02ATBH";
                cm.Parameters.AddWithValue("@MaMauBH02A", _maMauBH02A);
                cm.Parameters.AddWithValue("@TongHeSoDongBHXH", _tongHeSoDongBHXH);
                cm.Parameters.AddWithValue("@TongHeSoDongBHYT", _tongHeSoDongBHYT);
                cm.Parameters.AddWithValue("@TongHeSoDongBHTN", _tongHeSoDongBHTN);

                cm.Parameters.AddWithValue("@SoThangDongBoSung", _soThangDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHXHDongBoSung", _soTienBHXHDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHYTDongBoSung", _soTienBHYTDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHYTNDongBoSung", _soTienBHTNDongBoSung);

                cm.ExecuteNonQuery();
            }//using
        }
		private void UpdateChildren(SqlTransaction tr)
		{
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
              
                _luongCoBan=Default_Ngay.GetDefault_Ngay().LuongCoBan;
               _soThangDongBoSung = HamDungChung.GetMonthsDiff(ThamGiaTu, ThamGiaDen);
                 _tongHeSoDongBHXH=_heSoLuong+_heSoPhuCap+_heSoVuotKhung;
                 _tongHeSoDongBHYT=_heSoLuong + _heSoPhuCap + _heSoVuotKhung + _heSoKhuVuc;
                 _tongHeSoDongBHTN=_tongHeSoDongBHYT;
                 _soTienBHXHDongBoSung=_tongHeSoDongBHXH*_soThangDongBoSung*_luongCoBan;
                _soTienBHYTDongBoSung=_tongHeSoDongBHYT*_soThangDongBoSung*_luongCoBan;
                _soTienBHTNDongBoSung=_tongHeSoDongBHTN*_soThangDongBoSung*_luongCoBan;
                //Insert into tblnsTongHop02ATBH
                cm.Parameters.Clear();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsTongHop02ATBH";
                cm.Parameters.AddWithValue("@MaMauBH02A", _maMauBH02A);
                cm.Parameters.AddWithValue("@TongHeSoDongBHXH",_tongHeSoDongBHXH );
                cm.Parameters.AddWithValue("@TongHeSoDongBHYT", _tongHeSoDongBHYT);
                cm.Parameters.AddWithValue("@TongHeSoDongBHTN", _tongHeSoDongBHTN);
               
                cm.Parameters.AddWithValue("@SoThangDongBoSung", _soThangDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHXHDongBoSung", _soTienBHXHDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHYTDongBoSung", _soTienBHYTDongBoSung);
                cm.Parameters.AddWithValue("@SoTienBHYTNDongBoSung", _soTienBHTNDongBoSung);
                
                cm.ExecuteNonQuery();
            }//using
		}
        private void UpdateChildren3(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {

              
                cm.Parameters.Clear();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsTongHop02ATBH";
                cm.Parameters.AddWithValue("@MaMauBH02A", _maMauBH02A);               

                cm.ExecuteNonQuery();
            }//using
        }
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maMauBH02A));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

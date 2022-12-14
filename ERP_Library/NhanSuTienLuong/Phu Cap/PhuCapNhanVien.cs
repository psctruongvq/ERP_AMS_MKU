//
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuCapNhanVien : Csla.BusinessBase<PhuCapNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		internal int _maChiTiet = 0;
		private int _maBoPhan = 0;
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private string _tenBoPhan = string.Empty;
		private decimal _phuCap = 0;
		private decimal _thueSuat = 0;
		private decimal _soTien = 0;
        private decimal _tienThue = 0;
		private bool _tinhThueTNCN = true;
		private int _maLoaiPhuCap = 0;
        private string _tenPhuCap = "";
        private int _maKyTinhLuong = 0;
        private int _maKyPhuCap = 0;
        private int _UserID = Security.CurrentUser.Info.UserID;

        private string _SoQuyetDinh = string.Empty;
        private SmartDate _ngayLap =new SmartDate(DateTime.Today);
        private string _maPhieuChi = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _thanhToan = false;
        private decimal _soTienChiuThue = 0;

        private long _maChiThuLao = 0;

        private int _PhanLoai = 0;//1: Truy thu BHXH; 2: Truy thu BHYT; 3: Truy thu BHTN

        private string _PhanLoaiString = string.Empty;

        private Boolean _tinhDangPhi = true;
        [System.ComponentModel.DataObjectField(true, false)]

        public bool Chon { get;set;}//

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
                        
        public string SoQuyetDinh
        {
            get
            {
                CanReadProperty("SoQuyetDinh", true);
                return _SoQuyetDinh;
            }
            set
            {
                CanWriteProperty("SoQuyetDinh", true);
                if (value == null) value = string.Empty;
                if (!_SoQuyetDinh.Equals(value))
                {
                    _SoQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
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
		public int MaChiTiet
		{
			get
			{
				return _maChiTiet;
			}
		}

		public int MaBoPhan
		{
			get
			{
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

		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public string TenNhanVien
		{
			get
			{
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

        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
            set
            {
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaKyPhuCap
        {
            get
            {
                return _maKyPhuCap;
            }
            set
            {
                if (!_maKyPhuCap.Equals(value))
                {
                    _maKyPhuCap = value;
                    PropertyHasChanged();
                }
            }
        }

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
            set
            {
                _tenBoPhan = value;
            }
		}

		public decimal PhuCap
		{
			get
			{
				return _phuCap;
			}
			set
			{
				if (!_phuCap.Equals(value))
				{
					_phuCap = value;
					PropertyHasChanged("PhuCap");
				}
			}
		}

		public decimal ThueSuat
		{
			get
			{
				return _thueSuat;
			}
			set
			{
				if (!_thueSuat.Equals(value))
				{
					_thueSuat = value;
					PropertyHasChanged("ThueSuat");
				}
			}
		}

        public decimal TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
                if (!_tienThue.Equals(value))
                {
                    _tienThue = value;
                    PropertyHasChanged();
                }
            }
        }

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

        public decimal SoTienChiuThue
        {
            get
            {
                return _soTienChiuThue;
            }
            set
            {
                if (!_soTienChiuThue.Equals(value))
                {
                    _soTienChiuThue = value;
                    PropertyHasChanged("SoTienChiuThue");
                }
            }
        }

		public bool TinhThueTNCN
		{
			get
			{
				return _tinhThueTNCN;
			}
			set
			{
				if (!_tinhThueTNCN.Equals(value))
				{
					_tinhThueTNCN = value;
					PropertyHasChanged("TinhThueTNCN");
				}
			}
		}

		public int MaLoaiPhuCap
		{
			get
			{
				return _maLoaiPhuCap;
			}
			set
			{
				if (!_maLoaiPhuCap.Equals(value))
				{
					_maLoaiPhuCap = value;
					PropertyHasChanged("MaLoaiPhuCap");
				}
			}
		}


        public string TenPhuCap
        {
            get { return _tenPhuCap; }
            set
            {
                if (!_tenPhuCap.Equals(value))
                {
                    _tenPhuCap = value;
                    PropertyHasChanged();
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
                if (!_tinhDangPhi.Equals(value))
                {
                    _tinhDangPhi = value;
                    PropertyHasChanged("TinhDangPhi");
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

        public long MaChiThuLao
        {
            get
            {
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

        public int PhanLoai
        {
            get
            {
                return _PhanLoai;
            }
            set
            {
                if (!_PhanLoai.Equals(value))
                {
                    _PhanLoai = value;
                    if (_PhanLoai == 1)
                        _PhanLoaiString = "Truy thu BHXH";
                    else if(_PhanLoai==2)
                        _PhanLoaiString = "Truy thu BHYT";
                    else if(_PhanLoai==3)
                        _PhanLoaiString = "Truy thu BHTN";
                    else _PhanLoaiString = "";
                    PropertyHasChanged("PhanLoai");
                }
            }
        }

        public string PhanLoaiString
        {
            get
            {
                return _PhanLoaiString;
            }
            set
            {
                if (!_PhanLoaiString.Equals(value))
                {
                    _PhanLoaiString = value;
                    PropertyHasChanged("PhanLoaiString");
                }
            }
        }



		protected override object GetIdValue()
		{
			return _maChiTiet;
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
		public PhuCapNhanVien()
		{ /* require use of factory method */ }

		public static PhuCapNhanVien NewPhuCapNhanVien()
		{
			return DataPortal.Create<PhuCapNhanVien>();
		}

		public static PhuCapNhanVien GetPhuCapNhanVien(int maChiTiet)
		{
			return DataPortal.Fetch<PhuCapNhanVien>(new Criteria(maChiTiet));
		}

		public static void DeletePhuCapNhanVien(int maChiTiet)
		{
			DataPortal.Delete(new Criteria(maChiTiet));
		}

        public static decimal SoTienConLaiPhieuChi(long maChiThuLao)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SoTienConLaiPhieuChiForPhuCap_KhenThuong";
                    cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                    cm.Parameters.AddWithValue("@SoTienConLai", soTienConLai);
                    cm.Parameters["@SoTienConLai"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    soTienConLai = (decimal)cm.Parameters["@SoTienConLai"].Value;
                }
                catch (Exception ex)
                {
                    soTienConLai = 0;
                }

            }
            return soTienConLai;
        }

        public static decimal SoTienDaNhap(long maChiThuLao)
        {
            decimal soTienDaNhap = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SoTienDaNhapForPhuCap_KhenThuong";
                    cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                    cm.Parameters.AddWithValue("@SoTienDaNhap", soTienDaNhap);
                    cm.Parameters["@SoTienDaNhap"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    soTienDaNhap = (decimal)cm.Parameters["@SoTienDaNhap"].Value;
                }
                catch (Exception ex)
                {
                    soTienDaNhap = 0;
                }

            }
            return soTienDaNhap;
        }

		#endregion //Factory Methods

		#region Child Factory Methods

		internal static PhuCapNhanVien NewPhuCapNhanVienChild()
		{
			PhuCapNhanVien child = new PhuCapNhanVien();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhuCapNhanVien GetPhuCapNhanVien(SafeDataReader dr)
		{
			PhuCapNhanVien child =  new PhuCapNhanVien();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

        /// <summary>
        /// Sử dụng để group từ phụ cấp, sửa lần này, lần sau tách ra class group, class chỉ để view kg gọi cập nhật (sẽ làm sai)
        /// </summary>
        /// <param name="dr">data của store dùng group</param>
        /// <returns></returns>
        internal static PhuCapNhanVien GetPhuCap_DangPhi(SafeDataReader dr)
        {
            PhuCapNhanVien child = new PhuCapNhanVien();
            child.MarkAsChild();
            child.FetchObjectPhuCap_DangPhi(dr);
            child.MarkOld();
            return child;

        }

        internal static PhuCapNhanVien GetKhenThuongList(SafeDataReader dr)
        {
            PhuCapNhanVien child = new PhuCapNhanVien();
            child.MarkAsChild();
            child.FetchObjectKhenThuongList(dr);
            child.MarkOld();
            return child;
        }

        internal static PhuCapNhanVien GetKhenThuongListbyMaLoaiChi(SafeDataReader dr)
        {
            PhuCapNhanVien child = new PhuCapNhanVien();
            child.MarkAsChild();
            //child.FetchObjectKhenThuongList(dr);
            child._maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            child._maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            child._tenPhuCap = dr.GetString("TenLoaiPhuCap");
            child._thanhToan = dr.GetBoolean("ThanhToan");
            child._soTien = dr.GetDecimal("SoTien");
            child._SoQuyetDinh = dr.GetString("SoQuyetDinh");
            child._maPhieuChi = dr.GetString("MaPhieuChi");
            child._ngayLap = dr.GetSmartDate("NgayLap");
            child._maChiThuLao = dr.GetInt64("MaChiThuLao");
            child.MarkOld();
            return child;
        }

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaChiTiet;

			public Criteria(int maChiTiet)
			{
				this.MaChiTiet = maChiTiet;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
            MarkAsChild();
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
				cm.CommandText = "spd_Select_PhuCapNhanVien";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

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
					ExecuteInsert(tr);

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
						ExecuteUpdate(tr);
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
			DataPortal_Delete(new Criteria(_maChiTiet));
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
				cm.CommandText = "spd_Delete_PhuCapNhanVien";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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

        //fetch này chỉ để view kg dùng cập nhật
        private void FetchObjectPhuCap_DangPhi(SafeDataReader dr)
        {
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _tenPhuCap = dr.GetString("TenPhuCap");
            _tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            _thanhToan = dr.GetBoolean("ThanhToan");
            _soTien = dr.GetDecimal("SoTien");
        }

        //fetch này chỉ để view kg dùng cập nhật
        private void FetchObjectKhenThuongList(SafeDataReader dr)
        {
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _tenPhuCap = dr.GetString("TenLoaiPhuCap");
            _thanhToan = dr.GetBoolean("ThanhToan");
            _soTien = dr.GetDecimal("SoTien");
            _SoQuyetDinh = dr.GetString("SoQuyetDinh");
            _maPhieuChi = dr.GetString("MaPhieuChi");
            _ngayLap = dr.GetSmartDate("NgayLap");
            _maChiThuLao = dr.GetInt64("MaChiThuLao");
        }
        
        private void FetchObject(SafeDataReader dr)
		{
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_phuCap = dr.GetDecimal("PhuCap");
			_thueSuat = dr.GetDecimal("ThueSuat");
			_soTien = dr.GetDecimal("SoTien");
			_tinhThueTNCN = dr.GetBoolean("TinhThueTNCN");
			_maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
            _tienThue = dr.GetDecimal("TienThue");
            _tenPhuCap = dr.GetString("TenPhuCap");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maKyPhuCap = dr.GetInt32("MaKyPhuCap");
            _tinhDangPhi = dr.GetBoolean("TinhDangPhi");
            _thanhToan = dr.GetBoolean("ThanhToan");
            _dienGiai = dr.GetString("DienGiai");
            _maPhieuChi = dr.GetString("MaPhieuChi");
            _SoQuyetDinh = dr.GetString("SoQuyetDinh");
            _ngayLap = dr.GetSmartDate("NgayLap");
            _UserID = dr.GetInt32("UserID");
            _maChiThuLao = dr.GetInt64("MaChiThuLao");
		}
   
		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;                   
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_PhuCapNhanVien";

                    AddInsertParameters(cm);

                    cm.ExecuteNonQuery();
                    _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                }//using
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            _soTien = _phuCap;
        
            //các dữ liệu config
              decimal _PhuCapAnTruaKCT = 0;
            ERP_Library.Default_Ngay d = ERP_Library.Default_Ngay.GetDefault_Ngay();
            _PhuCapAnTruaKCT = d.PhuCapAnTrua;
            if (_maBoPhan != 0)
            {
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            }
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaKyPhuCap", _maKyPhuCap);
            cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@TinhThueTNCN", _tinhThueTNCN);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@TenPhuCap", _tenPhuCap);

            cm.Parameters.AddWithValue("@SoQuyetDinh", _SoQuyetDinh);
            cm.Parameters.AddWithValue("@NgayLap",_ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            cm.Parameters.Add("@MaChiTiet", SqlDbType.Int);
            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            // them cot so tien chiu thue
            if (_maLoaiPhuCap == 9)// phu cấp ăn trưa
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", _soTien - _PhuCapAnTruaKCT);
            }
            else if (_maLoaiPhuCap == 21)// ngoai gio ngay thuong
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * Convert.ToDecimal(0.5) / Convert.ToDecimal(1.5), 0));
            }
            else if (_maLoaiPhuCap == 22)//ngoài gio t7,cn
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien / Convert.ToDecimal(2), 0));
            }
            else if (_maLoaiPhuCap == 23)// ngoai gio ngay le
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * Convert.ToDecimal(2) / Convert.ToDecimal(3), 0));
            }
            else
            {
                foreach (LoaiPhuCapChild loaipc in LoaiPhuCapList.GetLoaiPhuCapList())
                    if (_maLoaiPhuCap == loaipc.MaLoaiPhuCap)
                    {
                        cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * loaipc.PTThuNhapTinhThue / 100, 0));
                    }
            }

            if (_maChiThuLao != 0)
            {
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            }
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);

            if (_PhanLoai != 0)
            {
                cm.Parameters.AddWithValue("@PhanLoai", _PhanLoai);
            }
            else
                cm.Parameters.AddWithValue("@PhanLoai", DBNull.Value);

            cm.Parameters["@MaChiTiet"].Direction =  ParameterDirection.Output;

        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_Update_PhuCapNhanVien";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            _soTien = _phuCap;
            //các dữ liệu config
            decimal _PhuCapAnTruaKCT = 0;
            ERP_Library.Default_Ngay d = ERP_Library.Default_Ngay.GetDefault_Ngay();
            _PhuCapAnTruaKCT = d.PhuCapAnTrua;
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaKyPhuCap", _maKyPhuCap);
            cm.Parameters.AddWithValue("@PhuCap", _phuCap);
            cm.Parameters.AddWithValue("@ThueSuat", _thueSuat);
            cm.Parameters.AddWithValue("@TienThue", _tienThue);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@TinhThueTNCN", _tinhThueTNCN);
            cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            cm.Parameters.AddWithValue("@TenPhuCap", _tenPhuCap);
            cm.Parameters.AddWithValue("@SoQuyetDinh", _SoQuyetDinh);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaPhieuChi", _maPhieuChi);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@TinhDangPhi", _tinhDangPhi);
            cm.Parameters.AddWithValue("@ThanhToan", _thanhToan);
            cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            // them cot so tien chiu thue
            if (_maLoaiPhuCap == 9)// phu cấp ăn trưa
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", _soTien - _PhuCapAnTruaKCT);
            }
            else if (_maLoaiPhuCap == 21)// ngoai gio ngay thuong
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * Convert.ToDecimal(0.5) / Convert.ToDecimal(1.5), 0));
            }
            else if (_maLoaiPhuCap == 22)//ngoài gio t7,cn
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien / Convert.ToDecimal(2), 0));
            }
            else if (_maLoaiPhuCap == 23)// ngoai gio ngay le
            {
                cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * Convert.ToDecimal(2) / Convert.ToDecimal(3), 0));
            }
            else
            {
                foreach (LoaiPhuCapChild loaipc in LoaiPhuCapList.GetLoaiPhuCapList())
                    if (_maLoaiPhuCap == loaipc.MaLoaiPhuCap)
                    {
                        cm.Parameters.AddWithValue("@SoTienChiuThue", Math.Round(_soTien * loaipc.PTThuNhapTinhThue / 100, 0));
                    }
            }

            if (_maChiThuLao != 0)
            {
                cm.Parameters.AddWithValue("@MaChiThuLao", _maChiThuLao);
            }
            else
                cm.Parameters.AddWithValue("@MaChiThuLao", DBNull.Value);

            if (_PhanLoai != 0)
            {
                cm.Parameters.AddWithValue("@PhanLoai", _PhanLoai);
            }
            else
                cm.Parameters.AddWithValue("@PhanLoai", DBNull.Value);


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

			ExecuteDelete(tr, new Criteria(_maChiTiet));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
    }
}

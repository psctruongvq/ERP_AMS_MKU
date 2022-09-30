
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ImportChungTuHVT : Csla.BusinessBase<ImportChungTuHVT>
	{
		#region Business Properties and Methods

		//declare members
		private long _id = 0;
		private string _soChungTu = string.Empty;
        private Nullable<DateTime> _ngayLap = null;
		private decimal _soTien = 0;
		private int _tiGia = 0;
		private decimal _thanhTien = 0;
		private string _dienGiaiBT = string.Empty;
        private string _dienGiaiCT = string.Empty;
		private int _loaiChungTu = 0;
		private int _maBoPhan = 0;
		private string _boPhan = string.Empty;
		private string _khachHangNgoaiDai = string.Empty;
		private string _nguoiDangNhap = string.Empty;
		private string _diaChi = string.Empty;
		private string _khachHangTrongDai = string.Empty;
		private string _diaChi1 = string.Empty;
		private string _tKNo = string.Empty;
		private string _tKCo = string.Empty;
		private decimal _soTienButToan = 0;
		private decimal _soTienTieuMuc = 0;
		private string _mucNganSach = string.Empty;
        private string _dienGiaiMuc = string.Empty;
        private bool _IsSaved = false;
        private string _fileName = string.Empty;

        
		[System.ComponentModel.DataObjectField(true, true)]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public bool IsSaved
        {
            get
            {
                return _IsSaved;
            }
            set
            {
                if (!_IsSaved.Equals(value))
                {
                    _IsSaved = value;
                    PropertyHasChanged("IsSaved");
                }
            }
        }
		public long Id
		{
			get
			{
				return _id;
			}
		}

		public string SoChungTu
		{
			get
			{
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

		public Nullable<DateTime> NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
					_ngayLap = value;
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
        private bool _isSave = true;

        public bool IsSave
        {
            get { return _isSave; }
            set { _isSave = value;
            PropertyHasChanged("IsSave");
            }
        }
		public int TiGia
		{
			get
			{
				return _tiGia;
			}
			set
			{
				if (!_tiGia.Equals(value))
				{
					_tiGia = value;
					PropertyHasChanged("TiGia");
				}
			}
		}

		public decimal ThanhTien
		{
			get
			{
				return _thanhTien;
			}
			set
			{
				if (!_thanhTien.Equals(value))
				{
					_thanhTien = value;
					PropertyHasChanged("ThanhTien");
				}
			}
		}

		public string DienGiaiBT
		{
			get
			{
				return _dienGiaiBT;
			}
			set
			{
				if (value == null) value = string.Empty;
                if (!_dienGiaiBT.Equals(value))
				{
                    _dienGiaiBT = value;
					PropertyHasChanged("DienGiaiBT");
				}
			}
		}

        public string DienGiaiCT
        {
            get
            {
                return _dienGiaiCT;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienGiaiCT.Equals(value))
                {
                    _dienGiaiCT = value;
                    PropertyHasChanged("DienGiaiCT");
                }
            }
        }

		public int LoaiChungTu
		{
			get
			{
				return _loaiChungTu;
			}
			set
			{
				if (!_loaiChungTu.Equals(value))
				{
					_loaiChungTu = value;
					PropertyHasChanged("LoaiChungTu");
				}
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

		public string BoPhan
		{
			get
			{
				return _boPhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_boPhan.Equals(value))
				{
					_boPhan = value;
					PropertyHasChanged("BoPhan");
				}
			}
		}

		public string KhachHangNgoaiDai
		{
			get
			{
				return _khachHangNgoaiDai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_khachHangNgoaiDai.Equals(value))
				{
					_khachHangNgoaiDai = value;
					PropertyHasChanged("KhachHangNgoaiDai");
				}
			}
		}

		public string NguoiDangNhap
		{
			get
			{
				return _nguoiDangNhap;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_nguoiDangNhap.Equals(value))
				{
					_nguoiDangNhap = value;
					PropertyHasChanged("NguoiDangNhap");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				return _diaChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public string KhachHangTrongDai
		{
			get
			{
				return _khachHangTrongDai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_khachHangTrongDai.Equals(value))
				{
					_khachHangTrongDai = value;
					PropertyHasChanged("KhachHangTrongDai");
				}
			}
		}

		public string DiaChi1
		{
			get
			{
				return _diaChi1;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_diaChi1.Equals(value))
				{
					_diaChi1 = value;
					PropertyHasChanged("DiaChi1");
				}
			}
		}

		public string TKNo
		{
			get
			{
				return _tKNo;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tKNo.Equals(value))
				{
					_tKNo = value;
					PropertyHasChanged("TKNo");
				}
			}
		}

		public string TKCo
		{
			get
			{
				return _tKCo;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tKCo.Equals(value))
				{
					_tKCo = value;
					PropertyHasChanged("TKCo");
				}
			}
		}

		public decimal SoTienButToan
		{
			get
			{
				return _soTienButToan;
			}
			set
			{
				if (!_soTienButToan.Equals(value))
				{
					_soTienButToan = value;
					PropertyHasChanged("SoTienButToan");
				}
			}
		}

		public decimal SoTienTieuMuc
		{
			get
			{
				return _soTienTieuMuc;
			}
			set
			{
				if (!_soTienTieuMuc.Equals(value))
				{
					_soTienTieuMuc = value;
					PropertyHasChanged("SoTienTieuMuc");
				}
			}
		}

		public string MucNganSach
		{
			get
			{
				return _mucNganSach;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_mucNganSach.Equals(value))
				{
					_mucNganSach = value;
					PropertyHasChanged("MucNganSach");
				}
			}
		}

        public string DienGiaiMuc
        {
            get
            {
                return _dienGiaiMuc;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienGiaiMuc.Equals(value))
                {
                    _dienGiaiMuc = value;
                    PropertyHasChanged("DiengGiaiMuc");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _id;
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
		private ImportChungTuHVT()
		{ /* require use of factory method */ }

		public static ImportChungTuHVT NewImportChungTuHVT()
		{
            ImportChungTuHVT item = new ImportChungTuHVT();
            item.MarkAsChild();
            return item;
		}

		public static ImportChungTuHVT GetImportChungTuHVT(long id)
		{
			return DataPortal.Fetch<ImportChungTuHVT>(new Criteria(id));
		}
      
		public static void DeleteImportChungTuHVT(long id)
		{
			DataPortal.Delete(new Criteria(id));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ImportChungTuHVT NewImportChungTuHVTChild()
		{
			ImportChungTuHVT child = new ImportChungTuHVT();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ImportChungTuHVT GetImportChungTuHVT(SafeDataReader dr)
		{
			ImportChungTuHVT child =  new ImportChungTuHVT();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static ImportChungTuHVT GetImportChungTuHVTBySoChungTu(SafeDataReader dr)
        {
            ImportChungTuHVT child = new ImportChungTuHVT();
            child.MarkAsChild();
           // child.MarkOld();
            child._soChungTu = dr.GetString("SoChungTu");
            object ngayLap = dr.GetValue("NgayLap");
            if (ngayLap != null)
                child._ngayLap = (DateTime)ngayLap;
            else
                child._ngayLap = null;            
            child._soTien = dr.GetDecimal("SoTien");
            child._tiGia = dr.GetInt32("TiGia");
            child._thanhTien = dr.GetDecimal("SoTien");
            //child._dienGiaiBT = dr.GetString("DienGiaiBT");
            child._loaiChungTu = dr.GetInt32("LoaiChungTu");
            child._maBoPhan = dr.GetInt32("MaBoPhan");
            child._boPhan = dr.GetString("BoPhan");
            child._khachHangNgoaiDai = dr.GetString("KhachHangNgoaiDai");
            child._nguoiDangNhap = dr.GetString("NguoiDangNhap");
            child._diaChi = dr.GetString("DiaChi");
            child._khachHangTrongDai = dr.GetString("KhachHangTrongDai");
            child._diaChi1 = dr.GetString("DiaChi1");
            child._dienGiaiCT = dr.GetString("DienGiaiCT");
            child._dienGiaiBT = dr.GetString("DienGiaiBT");
            child._dienGiaiMuc = dr.GetString("DienGiaiMuc");
            child.SoTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            child._soTienButToan = dr.GetDecimal("SoTienButToan");
            child._mucNganSach = dr.GetString("MucNganSach");
            child.TKCo = dr.GetString("TKCO");
            child.TKNo = dr.GetString("TKNO");
            return child;
        }
        internal static ImportChungTuHVT GetImportChungTuHVTByButToan(SafeDataReader dr)
        {
            ImportChungTuHVT child = new ImportChungTuHVT();
            child.MarkAsChild();
          //  child.MarkOld();
            child._soChungTu = dr.GetString("SoChungTu");
            child._tKNo = dr.GetString("TKNo");
            child._tKCo = dr.GetString("TKCo");
            child._soTienButToan = dr.GetDecimal("SoTienButToan");
            child._dienGiaiBT = dr.GetString("DienGiaiBT");
            
            return child;
        }
        internal static ImportChungTuHVT GetImportChungTuHVTByMucNganSach(SafeDataReader dr)
        {
            ImportChungTuHVT child = new ImportChungTuHVT();
            child.MarkAsChild();
        //    child.MarkOld();
            child._soChungTu = dr.GetString("SoChungTu");
            child._tKNo = dr.GetString("TKNo");
            child._tKCo = dr.GetString("TKCo");
            child._soTienButToan = dr.GetDecimal("SoTienButToan");
            child._soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            child._mucNganSach = dr.GetString("MucNganSach");
            child._dienGiaiMuc = dr.GetString("DienGiaiMuc");
            return child;
        }
        internal static ImportChungTuHVT GetImportChungTuByDanhSach(SafeDataReader dr)
        {
            ImportChungTuHVT child = new ImportChungTuHVT();
            child.MarkAsChild();
            child.FileName = dr.GetString("TenDanhSach");
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long Id;

			public Criteria(long id)
			{
				this.Id = id;
			}
		}
      
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
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
				cm.CommandText = "SelectImportChungTuHTV";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

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
			DataPortal_Delete(new Criteria(_id));
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
				cm.CommandText = "DeleteImportChungTuHTV";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

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
			_id = dr.GetInt64("ID");
			_soChungTu = dr.GetString("SoChungTu");
            object ngayLap = dr.GetValue("NgayLap");
            if (ngayLap != null)
                _ngayLap = (DateTime)ngayLap;
            else
                _ngayLap = null;    
			_soTien = dr.GetDecimal("SoTien");
			_tiGia = dr.GetInt32("TiGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_dienGiaiBT = dr.GetString("DienGiaiBT");
			_loaiChungTu = dr.GetInt32("LoaiChungTu");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_boPhan = dr.GetString("BoPhan");
			_khachHangNgoaiDai = dr.GetString("KhachHangNgoaiDai");
			_nguoiDangNhap = dr.GetString("NguoiDangNhap");
			_diaChi = dr.GetString("DiaChi");
			_khachHangTrongDai = dr.GetString("KhachHangTrongDai");
			_diaChi1 = dr.GetString("DiaChi1");
			_tKNo = dr.GetString("TKNo");
			_tKCo = dr.GetString("TKCo");
			_soTienButToan = dr.GetDecimal("SoTienButToan");
			_soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
			_mucNganSach = dr.GetString("MucNganSach");
            _dienGiaiCT = dr.GetString("DienGiaiCT");
            _fileName = dr.GetString("TenDanhSach");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ImportChungTuHVTList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ImportChungTuHVTList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InsertImportChungTuHTV";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_id = (long)cm.Parameters["@ID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ImportChungTuHVTList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if(_ngayLap==null)
                cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);
            else
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
	
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_tiGia != 0)
				cm.Parameters.AddWithValue("@TiGia", _tiGia);
			else
				cm.Parameters.AddWithValue("@TiGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_dienGiaiBT.Length > 0)
				cm.Parameters.AddWithValue("@DienGiaiBT", _dienGiaiBT);
			else
				cm.Parameters.AddWithValue("@DienGiaiBT", DBNull.Value);
			if (_loaiChungTu != 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_boPhan.Length > 0)
				cm.Parameters.AddWithValue("@BoPhan", _boPhan);
			else
				cm.Parameters.AddWithValue("@BoPhan", DBNull.Value);
			if (_khachHangNgoaiDai.Length > 0)
				cm.Parameters.AddWithValue("@KhachHangNgoaiDai", _khachHangNgoaiDai);
			else
				cm.Parameters.AddWithValue("@KhachHangNgoaiDai", DBNull.Value);
			if (_nguoiDangNhap.Length > 0)
				cm.Parameters.AddWithValue("@NguoiDangNhap", _nguoiDangNhap);
			else
				cm.Parameters.AddWithValue("@NguoiDangNhap", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_khachHangTrongDai.Length > 0)
				cm.Parameters.AddWithValue("@KhachHangTrongDai", _khachHangTrongDai);
			else
				cm.Parameters.AddWithValue("@KhachHangTrongDai", DBNull.Value);
			if (_diaChi1.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi1", _diaChi1);
			else
				cm.Parameters.AddWithValue("@DiaChi1", DBNull.Value);
			if (_tKNo.Length > 0)
				cm.Parameters.AddWithValue("@TKNo", _tKNo);
			else
				cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
			if (_tKCo.Length > 0)
				cm.Parameters.AddWithValue("@TKCo", _tKCo);
			else
				cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
			if (_soTienButToan != 0)
				cm.Parameters.AddWithValue("@SoTienButToan", _soTienButToan);
			else
				cm.Parameters.AddWithValue("@SoTienButToan", DBNull.Value);
			if (_soTienTieuMuc != 0)
				cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
			else
				cm.Parameters.AddWithValue("@SoTienTieuMuc", DBNull.Value);
			if (_mucNganSach.Length > 0)
				cm.Parameters.AddWithValue("@MucNganSach", _mucNganSach);
			else
				cm.Parameters.AddWithValue("@MucNganSach", DBNull.Value);
            if (_dienGiaiCT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiCT", _dienGiaiCT);
            else
                cm.Parameters.AddWithValue("@DienGiaiCT", DBNull.Value);
            if (_dienGiaiMuc.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiMuc", _dienGiaiMuc);
            else
                cm.Parameters.AddWithValue("@DienGiaiMuc", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayImport", DateTime.Today);
            cm.Parameters.AddWithValue("@TenDanhSach", _fileName);
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters["@ID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ImportChungTuHVTList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ImportChungTuHVTList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateImportChungTuHTV";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ImportChungTuHVTList parent)
		{
			cm.Parameters.AddWithValue("@ID", _id);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);

            if (_ngayLap == null)
                cm.Parameters.AddWithValue("@NgayLap", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_tiGia != 0)
				cm.Parameters.AddWithValue("@TiGia", _tiGia);
			else
				cm.Parameters.AddWithValue("@TiGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_dienGiaiBT.Length > 0)
				cm.Parameters.AddWithValue("@DienGiaiBT", _dienGiaiBT);
			else
				cm.Parameters.AddWithValue("@DienGiaiBT", DBNull.Value);
			if (_loaiChungTu != 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_boPhan.Length > 0)
				cm.Parameters.AddWithValue("@BoPhan", _boPhan);
			else
				cm.Parameters.AddWithValue("@BoPhan", DBNull.Value);
			if (_khachHangNgoaiDai.Length > 0)
				cm.Parameters.AddWithValue("@KhachHangNgoaiDai", _khachHangNgoaiDai);
			else
				cm.Parameters.AddWithValue("@KhachHangNgoaiDai", DBNull.Value);
			if (_nguoiDangNhap.Length > 0)
				cm.Parameters.AddWithValue("@NguoiDangNhap", _nguoiDangNhap);
			else
				cm.Parameters.AddWithValue("@NguoiDangNhap", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_khachHangTrongDai.Length > 0)
				cm.Parameters.AddWithValue("@KhachHangTrongDai", _khachHangTrongDai);
			else
				cm.Parameters.AddWithValue("@KhachHangTrongDai", DBNull.Value);
			if (_diaChi1.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi1", _diaChi1);
			else
				cm.Parameters.AddWithValue("@DiaChi1", DBNull.Value);
			if (_tKNo.Length > 0)
				cm.Parameters.AddWithValue("@TKNo", _tKNo);
			else
				cm.Parameters.AddWithValue("@TKNo", DBNull.Value);
			if (_tKCo.Length > 0)
				cm.Parameters.AddWithValue("@TKCo", _tKCo);
			else
				cm.Parameters.AddWithValue("@TKCo", DBNull.Value);
			if (_soTienButToan != 0)
				cm.Parameters.AddWithValue("@SoTienButToan", _soTienButToan);
			else
				cm.Parameters.AddWithValue("@SoTienButToan", DBNull.Value);
			if (_soTienTieuMuc != 0)
				cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
			else
				cm.Parameters.AddWithValue("@SoTienTieuMuc", DBNull.Value);
			if (_mucNganSach.Length > 0)
				cm.Parameters.AddWithValue("@MucNganSach", _mucNganSach);
			else
				cm.Parameters.AddWithValue("@MucNganSach", DBNull.Value);
            if (_dienGiaiCT.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiCT", _dienGiaiCT);
            else
                cm.Parameters.AddWithValue("@DienGiaiCT", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_id));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

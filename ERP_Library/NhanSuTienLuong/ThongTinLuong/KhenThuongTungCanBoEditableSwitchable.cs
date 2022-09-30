
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhenThuongTungCanBo : Csla.BusinessBase<KhenThuongTungCanBo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKhenThuong = 0;
		private long _maNhanVien = 0;
		private int _maHinhThucKhenThuong = 0;
		private int _maDanhHieu = 0;
		private string _soQuyetDinh = string.Empty;
		private int _capQuyetDinh = 0;
		private DateTime _ngayCapQuyetDinh = DateTime.Today.Date;
		private string _nguoiCapQiuyetDinh = string.Empty;
		private short _nangLuongTruocHan = 0;
		private string _ghiChu = string.Empty;
		private int _maNguoiLap = 0;
		private DateTime _ngayLap = DateTime.Today.Date;
		private decimal _soTien = 0;
		private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;

       
        private string _TenCapQuyetDinh = string.Empty;
        private string _TenDanhHieu = string.Empty;
        private string _TenHinhThucKhenThuong = string.Empty;
        private string _TenNhanVien = string.Empty;
       
        public string TenNhanVien
        {
            get {
                _TenNhanVien = TenNV.GetTenNhanVien(_maNhanVien).TenNhanVien;
                return _TenNhanVien; }
            set { _TenNhanVien = value; }
        }
        public string TenHinhThucKhenThuong
        {
            get { _TenHinhThucKhenThuong = HinhThucKhenThuong.GetHinhThucKhenThuong(_maHinhThucKhenThuong).TenKhenThuong;
                return _TenHinhThucKhenThuong; }
            set { _TenHinhThucKhenThuong = value; }
        }
        public string TenDanhHieu
        {
            get {
                _TenDanhHieu = DanhHieu.GetDanhHieu(_maDanhHieu).TenDanhHieu;
                return _TenDanhHieu; }
            set { _TenDanhHieu = value; }
        }
        public string TenCapQuyetDinh
        {
            get {
                _TenCapQuyetDinh = ERP_Library.CapQuyetDinh.GetCapQuyetDinh(_capQuyetDinh).TenCapQuyetDinh;
                return _TenCapQuyetDinh; }
            set { _TenCapQuyetDinh = value; }
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKhenThuong
		{
			get
			{
				return _maKhenThuong;
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
                    _TenNhanVien = TenNV.GetTenNhanVien(_maNhanVien).TenNhanVien;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaHinhThucKhenThuong
		{
			get
			{
				return _maHinhThucKhenThuong;
			}
			set
			{
				if (!_maHinhThucKhenThuong.Equals(value))
				{
					_maHinhThucKhenThuong = value;
                    _TenHinhThucKhenThuong = HinhThucKhenThuong.GetHinhThucKhenThuong(_maHinhThucKhenThuong).TenKhenThuong;
					PropertyHasChanged("MaHinhThucKhenThuong");
				}
			}
		}

		public int MaDanhHieu
		{
			get
			{
				return _maDanhHieu;
			}
			set
			{
				if (!_maDanhHieu.Equals(value))
				{
					_maDanhHieu = value;
                    _TenDanhHieu = DanhHieu.GetDanhHieu(_maDanhHieu).TenDanhHieu;
					PropertyHasChanged("MaDanhHieu");
				}
			}
		}

		public string SoQuyetDinh
		{
			get
			{
				return _soQuyetDinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public int CapQuyetDinh
		{
			get
			{
				return _capQuyetDinh;
			}
			set
			{
				if (!_capQuyetDinh.Equals(value))
				{
					_capQuyetDinh = value;
                    _TenCapQuyetDinh = ERP_Library.CapQuyetDinh.GetCapQuyetDinh(_capQuyetDinh).TenCapQuyetDinh;
					PropertyHasChanged("CapQuyetDinh");
				}
			}
		}

		public DateTime NgayCapQuyetDinh
		{
			get
			{
				return _ngayCapQuyetDinh;
			}
			set
			{
				if (!_ngayCapQuyetDinh.Equals(value))
				{
					_ngayCapQuyetDinh = value;
					PropertyHasChanged("NgayCapQuyetDinh");
				}
			}
		}

		public string NguoiCapQiuyetDinh
		{
			get
			{
				return _nguoiCapQiuyetDinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_nguoiCapQiuyetDinh.Equals(value))
				{
					_nguoiCapQiuyetDinh = value;
					PropertyHasChanged("NguoiCapQiuyetDinh");
				}
			}
		}

		public short NangLuongTruocHan
		{
			get
			{
				return _nangLuongTruocHan;
			}
			set
			{
				if (!_nangLuongTruocHan.Equals(value))
				{
					_nangLuongTruocHan = value;
					PropertyHasChanged("NangLuongTruocHan");
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

		public int MaNguoiLap
		{
			get
			{
				return _maNguoiLap;
			}
			set
			{
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
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

		public string TenBoPhan
		{
			get
			{
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
 
		protected override object GetIdValue()
		{
			return _maKhenThuong;
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
			// SoQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 20));
			//
			// NguoiCapQiuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiCapQiuyetDinh", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private KhenThuongTungCanBo()
		{ /* require use of factory method */ }

		public static KhenThuongTungCanBo NewKhenThuongTungCanBo()
		{
			return DataPortal.Create<KhenThuongTungCanBo>();
		}
        public static KhenThuongTungCanBo NewKhenThuongTungCanBo(long maNhanVien)
        {
            KhenThuongTungCanBo item = new KhenThuongTungCanBo();
            item.MarkAsChild();
            item.MaNhanVien = maNhanVien;
            return item;
        }
		public static KhenThuongTungCanBo GetKhenThuongTungCanBo(int maKhenThuong)
		{
			return DataPortal.Fetch<KhenThuongTungCanBo>(new Criteria(maKhenThuong));
		}

		public static void DeleteKhenThuongTungCanBo(int maKhenThuong)
		{
			DataPortal.Delete(new Criteria(maKhenThuong));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KhenThuongTungCanBo NewKhenThuongTungCanBoChild()
		{
			KhenThuongTungCanBo child = new KhenThuongTungCanBo();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KhenThuongTungCanBo GetKhenThuongTungCanBo(SafeDataReader dr)
		{
			KhenThuongTungCanBo child =  new KhenThuongTungCanBo();
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
			public int MaKhenThuong;

			public Criteria(int maKhenThuong)
			{
				this.MaKhenThuong = maKhenThuong;
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
				cm.CommandText = "SelecttblnsKhenThuongTungCanBo";

				cm.Parameters.AddWithValue("@MaKhenThuong", criteria.MaKhenThuong);

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
			DataPortal_Delete(new Criteria(_maKhenThuong));
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
				cm.CommandText = "DeletetblnsKhenThuongTungCanBo";

				cm.Parameters.AddWithValue("@MaKhenThuong", criteria.MaKhenThuong);

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
			_maKhenThuong = dr.GetInt32("MaKhenThuong");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maHinhThucKhenThuong = dr.GetInt32("MaHinhThucKhenThuong");
			_maDanhHieu = dr.GetInt32("MaDanhHieu");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_capQuyetDinh = dr.GetInt32("CapQuyetDinh");
			_ngayCapQuyetDinh = dr.GetDateTime("NgayCapQuyetDinh");
			_nguoiCapQiuyetDinh = dr.GetString("NguoiCapQiuyetDinh");
			_nangLuongTruocHan = dr.GetInt16("NangLuongTruocHan");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_ngayLap = dr.GetDateTime("NgayLap");
			_soTien = dr.GetDecimal("SoTien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KhenThuongTungCanBoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KhenThuongTungCanBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblnsKhenThuongTungCanBo";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maKhenThuong = (int)cm.Parameters["@MaKhenThuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KhenThuongTungCanBoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucKhenThuong", _maHinhThucKhenThuong);
			if (_maDanhHieu != 0)
				cm.Parameters.AddWithValue("@MaDanhHieu", _maDanhHieu);
			else
				cm.Parameters.AddWithValue("@MaDanhHieu", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_capQuyetDinh != 0)
				cm.Parameters.AddWithValue("@CapQuyetDinh", _capQuyetDinh);
			else
				cm.Parameters.AddWithValue("@CapQuyetDinh", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayCapQuyetDinh", _ngayCapQuyetDinh);
				if (_nguoiCapQiuyetDinh.Length > 0)
					cm.Parameters.AddWithValue("@NguoiCapQiuyetDinh", _nguoiCapQiuyetDinh);
				else
					cm.Parameters.AddWithValue("@NguoiCapQiuyetDinh", DBNull.Value);
				if (_nangLuongTruocHan != 0)
					cm.Parameters.AddWithValue("@NangLuongTruocHan", _nangLuongTruocHan);
				else
					cm.Parameters.AddWithValue("@NangLuongTruocHan", DBNull.Value);
				if (_ghiChu.Length > 0)
					cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
				else
					cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
				if (_maNguoiLap != 0)
					cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
				else
					cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
					cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
					if (_soTien != 0)
						cm.Parameters.AddWithValue("@SoTien", _soTien);
					else
						cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
					if (_maBoPhan != 0)
						cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
					else
						cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
					if (_tenBoPhan.Length > 0)
						cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
					else
						cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters["@MaKhenThuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KhenThuongTungCanBoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KhenThuongTungCanBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsKhenThuongTungCanBo";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KhenThuongTungCanBoList parent)
		{
			cm.Parameters.AddWithValue("@MaKhenThuong", _maKhenThuong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucKhenThuong", _maHinhThucKhenThuong);
			if (_maDanhHieu != 0)
				cm.Parameters.AddWithValue("@MaDanhHieu", _maDanhHieu);
			else
				cm.Parameters.AddWithValue("@MaDanhHieu", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_capQuyetDinh != 0)
				cm.Parameters.AddWithValue("@CapQuyetDinh", _capQuyetDinh);
			else
				cm.Parameters.AddWithValue("@CapQuyetDinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCapQuyetDinh", _ngayCapQuyetDinh);
			if (_nguoiCapQiuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@NguoiCapQiuyetDinh", _nguoiCapQiuyetDinh);
			else
				cm.Parameters.AddWithValue("@NguoiCapQiuyetDinh", DBNull.Value);
			if (_nangLuongTruocHan != 0)
				cm.Parameters.AddWithValue("@NangLuongTruocHan", _nangLuongTruocHan);
			else
				cm.Parameters.AddWithValue("@NangLuongTruocHan", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maKhenThuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

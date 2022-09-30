
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BHXH03A : Csla.BusinessBase<BHXH03A>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMauBH03A = 0;
		private int _kyTinhBaoHiem = 0;
		private long _maNhanVien = 0;
		private int _maTheBHYT = 0;
		private int _maSoBaoHiemXH = 0;
		private decimal _heSoLuong = 0;
		private decimal _heSoPhuCap = 0;
		private decimal _heSoVuotKhung = 0;
		private decimal _heSoThamNien = 0;
		private decimal _heSoKhuVuc = 0;
		private decimal _heSoLuongMoi = 0;
		private decimal _heSoPhuCapMoi = 0;
		private decimal _heSoVuotKhungMoi = 0;
		private decimal _heSoThamNienMoi = 0;
		private decimal _heSoKhuVucMoi = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Now.Date);
        private SmartDate _denNgay = new SmartDate(DateTime.Now.Date);
		private int _tyLeDieuChinh = 0;
		private bool _traThe = false;
		private string _ghiChu = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _soSoBHXH = string.Empty;
        private string _soTheBHYT = string.Empty;
       
		[System.ComponentModel.DataObjectField(true, true)]
       
		public int MaMauBH03A
		{
			get
			{
				return _maMauBH03A;
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

		public int MaTheBHYT
		{
			get
			{
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

		public decimal HeSoLuongMoi
		{
			get
			{
				return _heSoLuongMoi;
			}
			set
			{
				if (!_heSoLuongMoi.Equals(value))
				{
					_heSoLuongMoi = value;
					PropertyHasChanged("HeSoLuongMoi");
				}
			}
		}

		public decimal HeSoPhuCapMoi
		{
			get
			{
				return _heSoPhuCapMoi;
			}
			set
			{
				if (!_heSoPhuCapMoi.Equals(value))
				{
					_heSoPhuCapMoi = value;
					PropertyHasChanged("HeSoPhuCapMoi");
				}
			}
		}

		public decimal HeSoVuotKhungMoi
		{
			get
			{
				return _heSoVuotKhungMoi;
			}
			set
			{
				if (!_heSoVuotKhungMoi.Equals(value))
				{
					_heSoVuotKhungMoi = value;
					PropertyHasChanged("HeSoVuotKhungMoi");
				}
			}
		}

		public decimal HeSoThamNienMoi
		{
			get
			{
				return _heSoThamNienMoi;
			}
			set
			{
				if (!_heSoThamNienMoi.Equals(value))
				{
					_heSoThamNienMoi = value;
					PropertyHasChanged("HeSoThamNienMoi");
				}
			}
		}

		public decimal HeSoKhuVucMoi
		{
			get
			{
				return _heSoKhuVucMoi;
			}
			set
			{
				if (!_heSoKhuVucMoi.Equals(value))
				{
					_heSoKhuVucMoi = value;
					PropertyHasChanged("HeSoKhuVucMoi");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged("TuNgay");
                }
            }
		}
	
		public DateTime DenNgay
		{
			get
			{
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
		}
	
		public int TyLeDieuChinh
		{
			get
			{
				return _tyLeDieuChinh;
			}
			set
			{
				if (!_tyLeDieuChinh.Equals(value))
				{
					_tyLeDieuChinh = value;
					PropertyHasChanged("TyLeDieuChinh");
				}
			}
		}

		public bool TraThe
		{
			get
			{
				return _traThe;
			}
			set
			{
				if (!_traThe.Equals(value))
				{
					_traThe = value;
					PropertyHasChanged("TraThe");
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
			return _maMauBH03A;
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
			// GhiChu
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private BHXH03A()
		{ /* require use of factory method */ }

		public static BHXH03A NewBHXH03A()
		{
			return DataPortal.Create<BHXH03A>();
		}
        public static BHXH03A NewBHXH03A(long maNhanVien,int maKyTinhBaoHiem,int maQuyetDinhNangLuong,DateTime tuNgay,DateTime denNgay,string ghiChu)
        {
            BHXH03A item = new BHXH03A();
            NhanVien nv = NhanVien.GetNhanVien(maNhanVien);
            SoBaoHiemXaHoi bhxh = SoBaoHiemXaHoi.GetSoBaoHiemXaHoi(maNhanVien);
            TheBaoHiemYTe bhyt = TheBaoHiemYTe.GetTheBaoHiemYTe(maNhanVien);
            BaoHiemThatNghiep bhtn = BaoHiemThatNghiep.GetBaoHiemThatNghiep(maNhanVien);
            QuyetDinhNangLuong nangLuong = QuyetDinhNangLuong.GetQuyetDinhNangLuong(maQuyetDinhNangLuong);

            item.MarkAsChild();
            item.MaNhanVien = maNhanVien;
            item.KyTinhBaoHiem = maKyTinhBaoHiem;
            item.MaTheBHYT = bhyt.MaTheBHYT;
            item.MaSoBaoHiemXH = bhxh.MaSoBaoHiemXH;
            item.TuNgay = tuNgay;
            item.DenNgay = denNgay;
            item.GhiChu = ghiChu;
            if (nangLuong.MaQuyetDinh == 0)
            {
                item.HeSoLuong = nv.HeSoLuongBaoHiem;
                item.HeSoPhuCap = nv.HeSoPhuCapChucVu;
                item.HeSoVuotKhung = nv.HeSoVuotKhung;
                item.HeSoLuongMoi = nv.HeSoLuongBaoHiem;
                item.HeSoPhuCapMoi = nv.HeSoPhuCapChucVu;
                item.HeSoVuotKhungMoi = nv.HeSoVuotKhung;

            }
            else
            {
                item.HeSoLuong = nangLuong.HeSoBaoHiemCu;
                //item.HeSoPhuCap = nangLuong.HSP
                item.HeSoVuotKhung = nangLuong.HSVKCu;
                item.HeSoLuongMoi = nangLuong.HeSoBaoHiemMoi;
                //item.HeSoPhuCapMoi = nv.HeSoPhuCapChucVu;
                item.HeSoVuotKhungMoi = nangLuong.HSVKMoi;
            }
            return item;
        }

		public static BHXH03A GetBHXH03A(int maMauBH03A)
		{
			return DataPortal.Fetch<BHXH03A>(new Criteria(maMauBH03A));
		}

		public static void DeleteBHXH03A(int maMauBH03A)
		{
			DataPortal.Delete(new Criteria(maMauBH03A));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BHXH03A NewBHXH03AChild()
		{
			BHXH03A child = new BHXH03A();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BHXH03A GetBHXH03A(SafeDataReader dr)
		{
			BHXH03A child =  new BHXH03A();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static BHXH03A GetBHXH03AGetDS(SafeDataReader dr)
        {
            BHXH03A item = new BHXH03A();
            item.MarkAsChild();
            item.MaNhanVien = dr.GetInt64("MaNhanVien");
            item.TenNhanVien = dr.GetString("TenNhanVien");
            item.GhiChu = dr.GetString("SoQuyetDinh");
            item.TuNgay = dr.GetDateTime("NgayHieuLuc");
            item.MaTheBHYT = dr.GetInt32("MaQuyetDinh");
            return item;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaMauBH03A;

			public Criteria(int maMauBH03A)
			{
				this.MaMauBH03A = maMauBH03A;
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
                cm.CommandText = "spd_SelecttblnsBHXH03A";

				cm.Parameters.AddWithValue("@MaMauBH03A", criteria.MaMauBH03A);

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
			DataPortal_Delete(new Criteria(_maMauBH03A));
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
                cm.CommandText = "spd_DeletetblnsBHXH03A";

				cm.Parameters.AddWithValue("@MaMauBH03A", criteria.MaMauBH03A);

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
			_maMauBH03A = dr.GetInt32("MaMauBH03A");
			_kyTinhBaoHiem = dr.GetInt32("KyTinhBaoHiem");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maTheBHYT = dr.GetInt32("MaTheBHYT");
			_maSoBaoHiemXH = dr.GetInt32("MaSoBaoHiemXH");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_heSoPhuCap = dr.GetDecimal("HeSoPhuCap");
			_heSoVuotKhung = dr.GetDecimal("HeSoVuotKhung");
			_heSoThamNien = dr.GetDecimal("HeSoThamNien");
			_heSoKhuVuc = dr.GetDecimal("HeSoKhuVuc");
			_heSoLuongMoi = dr.GetDecimal("HeSoLuongMoi");
			_heSoPhuCapMoi = dr.GetDecimal("HeSoPhuCapMoi");
			_heSoVuotKhungMoi = dr.GetDecimal("HeSoVuotKhungMoi");
			_heSoThamNienMoi = dr.GetDecimal("HeSoThamNienMoi");
			_heSoKhuVucMoi = dr.GetDecimal("HeSoKhuVucMoi");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_tyLeDieuChinh = dr.GetInt32("TyLeDieuChinh");
			_traThe = dr.GetBoolean("TraThe");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BHXH03AList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BHXH03AList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsBHXH03A";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maMauBH03A = (int)cm.Parameters["@MaMauBH03A"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BHXH03AList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_kyTinhBaoHiem != 0)
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", _kyTinhBaoHiem);
			else
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maTheBHYT != 0)
				cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
			else
				cm.Parameters.AddWithValue("@MaTheBHYT", DBNull.Value);
			if (_maSoBaoHiemXH != 0)
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			else
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoPhuCap != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCap", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			if (_heSoThamNien != 0)
				cm.Parameters.AddWithValue("@HeSoThamNien", _heSoThamNien);
			else
				cm.Parameters.AddWithValue("@HeSoThamNien", DBNull.Value);
			if (_heSoKhuVuc != 0)
				cm.Parameters.AddWithValue("@HeSoKhuVuc", _heSoKhuVuc);
			else
				cm.Parameters.AddWithValue("@HeSoKhuVuc", DBNull.Value);
			if (_heSoLuongMoi != 0)
				cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
			else
				cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
			if (_heSoPhuCapMoi != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapMoi", _heSoPhuCapMoi);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapMoi", DBNull.Value);
			if (_heSoVuotKhungMoi != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", _heSoVuotKhungMoi);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", DBNull.Value);
			if (_heSoThamNienMoi != 0)
				cm.Parameters.AddWithValue("@HeSoThamNienMoi", _heSoThamNienMoi);
			else
				cm.Parameters.AddWithValue("@HeSoThamNienMoi", DBNull.Value);
			if (_heSoKhuVucMoi != 0)
				cm.Parameters.AddWithValue("@HeSoKhuVucMoi", _heSoKhuVucMoi);
			else
				cm.Parameters.AddWithValue("@HeSoKhuVucMoi", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_tyLeDieuChinh != 0)
				cm.Parameters.AddWithValue("@TyLeDieuChinh", _tyLeDieuChinh);
			else
				cm.Parameters.AddWithValue("@TyLeDieuChinh", DBNull.Value);
			if (_traThe != false)
				cm.Parameters.AddWithValue("@TraThe", _traThe);
			else
				cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaMauBH03A", _maMauBH03A);
			cm.Parameters["@MaMauBH03A"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BHXH03AList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BHXH03AList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBHXH03A";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BHXH03AList parent)
		{
			cm.Parameters.AddWithValue("@MaMauBH03A", _maMauBH03A);
			if (_kyTinhBaoHiem != 0)
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", _kyTinhBaoHiem);
			else
				cm.Parameters.AddWithValue("@KyTinhBaoHiem", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maTheBHYT != 0)
				cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
			else
				cm.Parameters.AddWithValue("@MaTheBHYT", DBNull.Value);
			if (_maSoBaoHiemXH != 0)
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			else
				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", DBNull.Value);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_heSoPhuCap != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCap", _heSoPhuCap);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCap", DBNull.Value);
			if (_heSoVuotKhung != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhung", _heSoVuotKhung);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhung", DBNull.Value);
			if (_heSoThamNien != 0)
				cm.Parameters.AddWithValue("@HeSoThamNien", _heSoThamNien);
			else
				cm.Parameters.AddWithValue("@HeSoThamNien", DBNull.Value);
			if (_heSoKhuVuc != 0)
				cm.Parameters.AddWithValue("@HeSoKhuVuc", _heSoKhuVuc);
			else
				cm.Parameters.AddWithValue("@HeSoKhuVuc", DBNull.Value);
			if (_heSoLuongMoi != 0)
				cm.Parameters.AddWithValue("@HeSoLuongMoi", _heSoLuongMoi);
			else
				cm.Parameters.AddWithValue("@HeSoLuongMoi", DBNull.Value);
			if (_heSoPhuCapMoi != 0)
				cm.Parameters.AddWithValue("@HeSoPhuCapMoi", _heSoPhuCapMoi);
			else
				cm.Parameters.AddWithValue("@HeSoPhuCapMoi", DBNull.Value);
			if (_heSoVuotKhungMoi != 0)
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", _heSoVuotKhungMoi);
			else
				cm.Parameters.AddWithValue("@HeSoVuotKhungMoi", DBNull.Value);
			if (_heSoThamNienMoi != 0)
				cm.Parameters.AddWithValue("@HeSoThamNienMoi", _heSoThamNienMoi);
			else
				cm.Parameters.AddWithValue("@HeSoThamNienMoi", DBNull.Value);
			if (_heSoKhuVucMoi != 0)
				cm.Parameters.AddWithValue("@HeSoKhuVucMoi", _heSoKhuVucMoi);
			else
				cm.Parameters.AddWithValue("@HeSoKhuVucMoi", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_tyLeDieuChinh != 0)
				cm.Parameters.AddWithValue("@TyLeDieuChinh", _tyLeDieuChinh);
			else
				cm.Parameters.AddWithValue("@TyLeDieuChinh", DBNull.Value);
			if (_traThe != false)
				cm.Parameters.AddWithValue("@TraThe", _traThe);
			else
				cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maMauBH03A));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

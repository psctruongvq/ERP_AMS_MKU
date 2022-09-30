
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_ToKhaiThue : Csla.BusinessBase<CT_ToKhaiThue>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maHangHoa = 0;
		private decimal _donGia = 0;
		private double _khoiLuong = 0;
		private int _maDonViTinh = 0;
		private decimal _thanhTien = 0;
		private double _phanTramThueNK = 0;
		private decimal _thueSuatNK = 0;
		private double _phanTramThueVAT = 0;
		private decimal _thueSuatVAT = 0;
		private double _phanTramThueTTDB = 0;
		private decimal _thueSuatTTDB = 0;
		private double _phanTramThuKhac = 0;
		private decimal _soTienThuKhac = 0;
		private int _maToKhaiThue = 0;

        // khai báo thêm
        private string _tenHangHoa = string.Empty;
        private string _tenDonViTinh = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaHangHoa
		{
			get
			{
				CanReadProperty("MaHangHoa", true);
				return _maHangHoa;
			}
			set
			{
				CanWriteProperty("MaHangHoa", true);
				if (!_maHangHoa.Equals(value))
				{
					_maHangHoa = value;
					PropertyHasChanged("MaHangHoa");
				}
			}
		}

		public decimal DonGia
		{
			get
			{
				CanReadProperty("DonGia", true);
				return _donGia;
			}
			set
			{
				CanWriteProperty("DonGia", true);
				if (!_donGia.Equals(value))
				{
					_donGia = value;
					PropertyHasChanged("DonGia");
				}
			}
		}

		public double KhoiLuong
		{
			get
			{
				CanReadProperty("KhoiLuong", true);
				return _khoiLuong;
			}
			set
			{
				CanWriteProperty("KhoiLuong", true);
				if (!_khoiLuong.Equals(value))
				{
					_khoiLuong = value;
					PropertyHasChanged("KhoiLuong");
				}
			}
		}

		public int MaDonViTinh
		{
			get
			{
				CanReadProperty("MaDonViTinh", true);
				return _maDonViTinh;
			}
			set
			{
				CanWriteProperty("MaDonViTinh", true);
				if (!_maDonViTinh.Equals(value))
				{
					_maDonViTinh = value;
					PropertyHasChanged("MaDonViTinh");
				}
			}
		}

		public decimal ThanhTien
		{
			get
			{
				CanReadProperty("ThanhTien", true);
				return _thanhTien;
			}
			set
			{
				CanWriteProperty("ThanhTien", true);
				if (!_thanhTien.Equals(value))
				{
					_thanhTien = value;
					PropertyHasChanged("ThanhTien");
				}
			}
		}

		public double PhanTramThueNK
		{
			get
			{
				CanReadProperty("PhanTramThueNK", true);
				return _phanTramThueNK;
			}
			set
			{
				CanWriteProperty("PhanTramThueNK", true);
				if (!_phanTramThueNK.Equals(value))
				{
					_phanTramThueNK = value;
                    _thueSuatNK = (decimal)_phanTramThueNK * _thanhTien / 100;
					PropertyHasChanged("PhanTramThueNK");
				}
			}
		}

		public decimal ThueSuatNK
		{
			get
			{
				CanReadProperty("ThueSuatNK", true);
				return _thueSuatNK;
			}
			set
			{
				CanWriteProperty("ThueSuatNK", true);
				if (!_thueSuatNK.Equals(value))
				{
					_thueSuatNK = value;
					PropertyHasChanged("ThueSuatNK");
				}
			}
		}

		public double PhanTramThueVAT
		{
			get
			{
				CanReadProperty("PhanTramThueVAT", true);
				return _phanTramThueVAT;
			}
			set
			{
				CanWriteProperty("PhanTramThueVAT", true);
				if (!_phanTramThueVAT.Equals(value))
				{
					_phanTramThueVAT = value;
                    _thueSuatVAT = (decimal)_phanTramThueVAT * _thanhTien / 100;
					PropertyHasChanged("PhanTramThueVAT");
				}
			}
		}

		public decimal ThueSuatVAT
		{
			get
			{
				CanReadProperty("ThueSuatVAT", true);
				return _thueSuatVAT;
			}
			set
			{
				CanWriteProperty("ThueSuatVAT", true);
				if (!_thueSuatVAT.Equals(value))
				{
					_thueSuatVAT = value;
					PropertyHasChanged("ThueSuatVAT");
				}
			}
		}

		public double PhanTramThueTTDB
		{
			get
			{
				CanReadProperty("PhanTramThueTTDB", true);
				return _phanTramThueTTDB;
			}
			set
			{
				CanWriteProperty("PhanTramThueTTDB", true);
				if (!_phanTramThueTTDB.Equals(value))
				{
					_phanTramThueTTDB = value;
                    _thueSuatTTDB = (decimal)_phanTramThueTTDB * _thanhTien / 100;
					PropertyHasChanged("PhanTramThueTTDB");
				}
			}
		}

		public decimal ThueSuatTTDB
		{
			get
			{
				CanReadProperty("ThueSuatTTDB", true);
				return _thueSuatTTDB;
			}
			set
			{
				CanWriteProperty("ThueSuatTTDB", true);
				if (!_thueSuatTTDB.Equals(value))
				{
					_thueSuatTTDB = value;
					PropertyHasChanged("ThueSuatTTDB");
				}
			}
		}

		public double PhanTramThuKhac
		{
			get
			{
				CanReadProperty("PhanTramThuKhac", true);
				return _phanTramThuKhac;
			}
			set
			{
				CanWriteProperty("PhanTramThuKhac", true);
				if (!_phanTramThuKhac.Equals(value))
				{
					_phanTramThuKhac = value;
                    _soTienThuKhac = (decimal)_phanTramThuKhac * _thanhTien / 100;
					PropertyHasChanged("PhanTramThuKhac");
				}
			}
		}

		public decimal SoTienThuKhac
		{
			get
			{
				CanReadProperty("SoTienThuKhac", true);
				return _soTienThuKhac;
			}
			set
			{
				CanWriteProperty("SoTienThuKhac", true);
				if (!_soTienThuKhac.Equals(value))
				{
					_soTienThuKhac = value;
					PropertyHasChanged("SoTienThuKhac");
				}
			}
		}

		public int MaToKhaiThue
		{
			get
			{
				CanReadProperty("MaToKhaiThue", true);
				return _maToKhaiThue;
			}
			set
			{
				CanWriteProperty("MaToKhaiThue", true);
				if (!_maToKhaiThue.Equals(value))
				{
					_maToKhaiThue = value;
					PropertyHasChanged("MaToKhaiThue");
				}
			}
		}

        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                return _tenHangHoa;
            }
            set
            {
                CanWriteProperty("TenHangHoa", true);
                if (!_tenHangHoa.Equals(value))
                {
                    _tenHangHoa = value;
                    PropertyHasChanged("TenHangHoa");
                }
            }
        }


        public string TenDonViTinh
        {
            get
            {
                CanReadProperty("TenDonViTinh", true);
                return _tenDonViTinh;
            }
            set
            {
                CanWriteProperty("TenDonViTinh", true);
                if (!_tenDonViTinh.Equals(value))
                {
                    _tenDonViTinh = value;
                    PropertyHasChanged("TenDonViTinh");
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

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in CT_ToKhaiThue
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("KhoiLuong", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThueNK", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("ThueSuatNK", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThueVAT", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("ThueSuatVAT", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThueTTDB", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("ThueSuatTTDB", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThuKhac", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("SoTienThuKhac", "CT_ToKhaiThueReadGroup");
			//AuthorizationRules.AllowRead("MaToKhaiThue", "CT_ToKhaiThueReadGroup");

			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("KhoiLuong", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThueNK", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("ThueSuatNK", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThueVAT", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("ThueSuatVAT", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThueTTDB", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("ThueSuatTTDB", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThuKhac", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienThuKhac", "CT_ToKhaiThueWriteGroup");
			//AuthorizationRules.AllowWrite("MaToKhaiThue", "CT_ToKhaiThueWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_ToKhaiThue NewCT_ToKhaiThue()
		{
			return new CT_ToKhaiThue();
		}

        internal static CT_ToKhaiThue NewCT_ToKhaiThue(CT_HoaDon ct_HoaDon)
        {
            return new CT_ToKhaiThue(ct_HoaDon);
        }

		internal static CT_ToKhaiThue GetCT_ToKhaiThue(SafeDataReader dr)
		{
			return new CT_ToKhaiThue(dr);
		}

		private CT_ToKhaiThue()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

        private CT_ToKhaiThue(CT_HoaDon ct_HoaDon)
        {            
            this._tenHangHoa = ct_HoaDon.TenHangHoa;
            this._donGia = ct_HoaDon.DonGia;
            this._thanhTien = ct_HoaDon.ThanhTien;            
            this._maHangHoa = ct_HoaDon.MaHangHoa;            
            ValidationRules.CheckRules();
            MarkAsChild();
        }

		private CT_ToKhaiThue(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

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
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_donGia = dr.GetDecimal("DonGia");
			_khoiLuong = dr.GetDouble("KhoiLuong");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_phanTramThueNK = dr.GetDouble("PhanTramThueNK");
			_thueSuatNK = dr.GetDecimal("ThueSuatNK");
			_phanTramThueVAT = dr.GetDouble("PhanTramThueVAT");
			_thueSuatVAT = dr.GetDecimal("ThueSuatVAT");
			_phanTramThueTTDB = dr.GetDouble("PhanTramThueTTDB");
			_thueSuatTTDB = dr.GetDecimal("ThueSuatTTDB");
			_phanTramThuKhac = dr.GetDouble("PhanTramThuKhac");
			_soTienThuKhac = dr.GetDecimal("SoTienThuKhac");
			_maToKhaiThue = dr.GetInt32("MaToKhaiThue");
            _tenDonViTinh = dr.GetString("TenDonViTinh");
            _tenHangHoa= dr.GetString("TenHangHoa");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ToKhaiThue parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ToKhaiThue parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_ToKhaiThue";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ToKhaiThue parent)
		{
            _maToKhaiThue = parent.MaToKhai;
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);			
				cm.Parameters.AddWithValue("@DonGia", _donGia);						
				cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);			
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);			
			
				cm.Parameters.AddWithValue("@PhanTramThueNK", _phanTramThueNK);			
			
				cm.Parameters.AddWithValue("@ThueSuatNK", _thueSuatNK);		
				
				cm.Parameters.AddWithValue("@PhanTramThueVAT", _phanTramThueVAT);	
	
				cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);	
			
				cm.Parameters.AddWithValue("@PhanTramThueTTDB", _phanTramThueTTDB);			
			
				cm.Parameters.AddWithValue("@ThueSuatTTDB", _thueSuatTTDB);			
			
				cm.Parameters.AddWithValue("@PhanTramThuKhac", _phanTramThuKhac);			
			
				cm.Parameters.AddWithValue("@SoTienThuKhac", _soTienThuKhac);
			
			if (_maToKhaiThue != 0)
				cm.Parameters.AddWithValue("@MaToKhaiThue", _maToKhaiThue);
			else
				cm.Parameters.AddWithValue("@MaToKhaiThue", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ToKhaiThue parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ToKhaiThue parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_ToKhaiThue";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ToKhaiThue parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_khoiLuong != 0)
				cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);
			else
				cm.Parameters.AddWithValue("@KhoiLuong", DBNull.Value);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_phanTramThueNK != 0)
				cm.Parameters.AddWithValue("@PhanTramThueNK", _phanTramThueNK);
			else
				cm.Parameters.AddWithValue("@PhanTramThueNK", DBNull.Value);
			if (_thueSuatNK != 0)
				cm.Parameters.AddWithValue("@ThueSuatNK", _thueSuatNK);
			else
				cm.Parameters.AddWithValue("@ThueSuatNK", DBNull.Value);
			if (_phanTramThueVAT != 0)
				cm.Parameters.AddWithValue("@PhanTramThueVAT", _phanTramThueVAT);
			else
				cm.Parameters.AddWithValue("@PhanTramThueVAT", DBNull.Value);
			if (_thueSuatVAT != 0)
				cm.Parameters.AddWithValue("@ThueSuatVAT", _thueSuatVAT);
			else
				cm.Parameters.AddWithValue("@ThueSuatVAT", DBNull.Value);
			if (_phanTramThueTTDB != 0)
				cm.Parameters.AddWithValue("@PhanTramThueTTDB", _phanTramThueTTDB);
			else
				cm.Parameters.AddWithValue("@PhanTramThueTTDB", DBNull.Value);
			if (_thueSuatTTDB != 0)
				cm.Parameters.AddWithValue("@ThueSuatTTDB", _thueSuatTTDB);
			else
				cm.Parameters.AddWithValue("@ThueSuatTTDB", DBNull.Value);
			if (_phanTramThuKhac != 0)
				cm.Parameters.AddWithValue("@PhanTramThuKhac", _phanTramThuKhac);
			else
				cm.Parameters.AddWithValue("@PhanTramThuKhac", DBNull.Value);
			if (_soTienThuKhac != 0)
				cm.Parameters.AddWithValue("@SoTienThuKhac", _soTienThuKhac);
			else
				cm.Parameters.AddWithValue("@SoTienThuKhac", DBNull.Value);
			if (_maToKhaiThue != 0)
				cm.Parameters.AddWithValue("@MaToKhaiThue", _maToKhaiThue);
			else
				cm.Parameters.AddWithValue("@MaToKhaiThue", DBNull.Value);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_ToKhaiThue";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

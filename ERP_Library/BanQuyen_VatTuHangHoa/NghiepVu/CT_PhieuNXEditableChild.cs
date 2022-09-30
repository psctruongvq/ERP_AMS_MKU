
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuNX : Csla.BusinessBase<CT_PhieuNX>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private long _maPhieuNhapXuat = 0;
		private int _maHangHoa = 0;
		private int _maDonViTinh = 0;
		private decimal _soLuong = 0;
		private decimal _donGia = 0;
		private decimal _thanhTien = 0;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public long MaPhieuNhapXuat
		{
			get
			{
				CanReadProperty("MaPhieuNhapXuat", true);
				return _maPhieuNhapXuat;
			}
			set
			{
				CanWriteProperty("MaPhieuNhapXuat", true);
				if (!_maPhieuNhapXuat.Equals(value))
				{
					_maPhieuNhapXuat = value;
					PropertyHasChanged("MaPhieuNhapXuat");
				}
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

		public decimal SoLuong
		{
			get
			{
				CanReadProperty("SoLuong", true);
				return _soLuong;
			}
			set
			{
				CanWriteProperty("SoLuong", true);
				if (!_soLuong.Equals(value))
				{
					_soLuong = value;
                    _thanhTien = _donGia * _soLuong;
					PropertyHasChanged("SoLuong");
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
                    _thanhTien = _donGia * _soLuong;
					PropertyHasChanged("DonGia");
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
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in CT_PhieuNX
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_PhieuNXReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "CT_PhieuNXReadGroup");

			//AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_PhieuNXWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "CT_PhieuNXWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_PhieuNX NewCT_PhieuNX()
		{
			return new CT_PhieuNX();
		}
        
		internal static CT_PhieuNX GetCT_PhieuNX(SafeDataReader dr)
		{
			return new CT_PhieuNX(dr);
		}

		private CT_PhieuNX()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

      

		private CT_PhieuNX(SafeDataReader dr)
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
			_maChiTiet = dr.GetInt64("MaChiTiet");
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
			_soLuong = dr.GetDecimal("SoLuong");
			_donGia = dr.GetDecimal("DonGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuNX";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhapXuat = parent.MaPhieuNhapXuat;
			cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuNX";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
			else
				cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_PhieuNX";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

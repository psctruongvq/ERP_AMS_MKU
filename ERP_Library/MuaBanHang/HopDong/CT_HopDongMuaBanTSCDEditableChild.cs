
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_MuaBanTSCD : Csla.BusinessBase<CT_MuaBanTSCD>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private long _maHopDong = 0;
		private int _maTaiSanCoDinh = 0;
		private int _maDonViTinh = 0;
		private int _maQuocGia = 0;
		private int _soLuong = 0;
		private decimal _dongGia = 0;
		private decimal _thanhTien = 0;
        private string _tenTaiSanCoDinh = string.Empty;
        private string _tenLoaiTaiSanCoDinh = string.Empty; 

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
			}
			set
			{
				CanWriteProperty("MaHopDong", true);
				if (!_maHopDong.Equals(value))
				{
					_maHopDong = value;
					PropertyHasChanged("MaHopDong");
				}
			}
		}

		public int MaTaiSanCoDinh
		{
			get
			{
				CanReadProperty("MaTaiSanCoDinh", true);
				return _maTaiSanCoDinh;
			}
			set
			{
				CanWriteProperty("MaTaiSanCoDinh", true);
				if (!_maTaiSanCoDinh.Equals(value))
				{
					_maTaiSanCoDinh = value;
					PropertyHasChanged("MaTaiSanCoDinh");
				}
			}
		}

        public string TenTaiSanCoDinh
        {
            get
            {
                CanReadProperty("TenTaiSanCoDinh", true);
                return _tenTaiSanCoDinh;
            }
            set
            {
                CanWriteProperty("TenTaiSanCoDinh", true);
                if (!_tenTaiSanCoDinh.Equals(value))
                {
                    _tenTaiSanCoDinh = value;
                    PropertyHasChanged("TenTaiSanCoDinh");
                }
            }
        }

        public string TenLoaiTaiSanCoDinh
        {
            get
            {
                CanReadProperty("TenLoaiTaiSanCoDinh", true);
                return _tenLoaiTaiSanCoDinh;
            }
            set
            {
                CanWriteProperty("TenLoaiTaiSanCoDinh", true);
                if (!_tenLoaiTaiSanCoDinh.Equals(value))
                {
                    _tenLoaiTaiSanCoDinh = value;
                    PropertyHasChanged("TenLoaiTaiSanCoDinh");
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

		public int MaQuocGia
		{
			get
			{
				CanReadProperty("MaQuocGia", true);
				return _maQuocGia;
			}
			set
			{
				CanWriteProperty("MaQuocGia", true);
				if (!_maQuocGia.Equals(value))
				{
					_maQuocGia = value;
					PropertyHasChanged("MaQuocGia");
				}
			}
		}

		public int SoLuong
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
                    _thanhTien = _dongGia * _soLuong;
					PropertyHasChanged("SoLuong");
				}
			}
		}

		public decimal DongGia
		{
			get
			{
				CanReadProperty("DongGia", true);
				return _dongGia;
			}
			set
			{
				CanWriteProperty("DongGia", true);
				if (!_dongGia.Equals(value))
				{
					_dongGia = value;
                    _thanhTien = _dongGia * _soLuong;
					PropertyHasChanged("DongGia");
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
			//TODO: Define authorization rules in CT_MuaBanTSCD
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaTaiSanCoDinh", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaQuocGia", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("DongGia", "CT_MuaBanTSCDReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_MuaBanTSCDReadGroup");

			//AuthorizationRules.AllowWrite("MaHopDong", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiSanCoDinh", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuocGia", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("DongGia", "CT_MuaBanTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_MuaBanTSCDWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_MuaBanTSCD NewCT_MuaBanTSCD()
		{
			return new CT_MuaBanTSCD();
		}

		internal static CT_MuaBanTSCD GetCT_MuaBanTSCD(SafeDataReader dr)
		{
			return new CT_MuaBanTSCD(dr);
		}

		public CT_MuaBanTSCD()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_MuaBanTSCD(SafeDataReader dr)
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
			_maHopDong = dr.GetInt64("MaHopDong");
			_maTaiSanCoDinh = dr.GetInt32("MaTaiSanCoDinh");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
			_maQuocGia = dr.GetInt32("MaQuocGia");
			_soLuong = dr.GetInt32("SoLuong");
			_dongGia = dr.GetDecimal("DongGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
            _tenLoaiTaiSanCoDinh = dr.GetString("TenLoaiTaiSan");
            _tenTaiSanCoDinh = dr.GetString("TenTSCD");

		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HopDongMuaBan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HopDongMuaBan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_MuaBanTSCD";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHopDong = parent.MaHopDong;
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
           
			cm.Parameters.AddWithValue("@MaTaiSanCoDinh", _maTaiSanCoDinh);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_maQuocGia != 0)
				cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			else
				cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_dongGia != 0)
				cm.Parameters.AddWithValue("@DongGia", _dongGia);
			else
				cm.Parameters.AddWithValue("@DongGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HopDongMuaBan parent)
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

		private void ExecuteUpdate(SqlTransaction tr, HopDongMuaBan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_MuaBanTSCD";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			cm.Parameters.AddWithValue("@MaTaiSanCoDinh", _maTaiSanCoDinh);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_maQuocGia != 0)
				cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			else
				cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_dongGia != 0)
				cm.Parameters.AddWithValue("@DongGia", _dongGia);
			else
				cm.Parameters.AddWithValue("@DongGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_MuaBanTSCD";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

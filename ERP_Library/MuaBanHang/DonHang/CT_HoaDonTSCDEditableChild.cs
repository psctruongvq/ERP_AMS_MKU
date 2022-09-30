
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HoaDonTSCD : Csla.BusinessBase<CT_HoaDonTSCD>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private int _maTaiSanCoDinh = 0;
		private int _soLuong = 0;
		private decimal _donGia = 0;
		private decimal _thanhTien = 0;
		private long _maHoaDon = 0;
		private int _maDonViTinh = 0;
        private string _tenTaiSanCoDinh;
        private string _tenLoaiTaiSan;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
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
                    _thanhTien = _soLuong * _donGia;
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
                    _thanhTien = _soLuong * _donGia;
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

		public long MaHoaDon
		{
			get
			{
				CanReadProperty("MaHoaDon", true);
				return _maHoaDon;
			}
			set
			{
				CanWriteProperty("MaHoaDon", true);
				if (!_maHoaDon.Equals(value))
				{
					_maHoaDon = value;
					PropertyHasChanged("MaHoaDon");
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
                                
                _tenTaiSanCoDinh = value;
                PropertyHasChanged("TenTaiSanCoDinh");
				
			}
		}

        public string TenLoaiTaiSan
        {
            get
            {
                CanReadProperty("TenLoaiTaiSan", true);
                return _tenLoaiTaiSan;
            }
            set
            {
                CanWriteProperty("TenLoaiTaiSan", true);
                _tenLoaiTaiSan = value;
                PropertyHasChanged("TenLoaiTaiSan");

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
			//TODO: Define authorization rules in CT_HoaDonTSCD
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaTaiSanCoDinh", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaHoaDon", "CT_HoaDonTSCDReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_HoaDonTSCDReadGroup");

			//AuthorizationRules.AllowWrite("MaTaiSanCoDinh", "CT_HoaDonTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_HoaDonTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_HoaDonTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_HoaDonTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("MaHoaDon", "CT_HoaDonTSCDWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_HoaDonTSCDWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_HoaDonTSCD NewCT_HoaDonTSCD()
		{
			return new CT_HoaDonTSCD();
		}

		internal static CT_HoaDonTSCD GetCT_HoaDonTSCD(SafeDataReader dr)
		{
			return new CT_HoaDonTSCD(dr);
		}

        public static CT_HoaDonTSCD NewCT_HoaDonTSCD(CT_MuaBanTSCD _ctMuaBanTSCD)
        {
            return new CT_HoaDonTSCD(_ctMuaBanTSCD);
        }

        public static CT_HoaDonTSCD NewCT_HoaDonTSCD(TSCDCaBiet _TSCDCB)
        {
            return new CT_HoaDonTSCD(_TSCDCB);
        } 

		public CT_HoaDonTSCD()
		{			
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_HoaDonTSCD(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}

        public CT_HoaDonTSCD(CT_MuaBanTSCD _ctMuaBanTSCD)
        {
            _maTaiSanCoDinh= _ctMuaBanTSCD.MaTaiSanCoDinh;
            _tenTaiSanCoDinh = _ctMuaBanTSCD.TenTaiSanCoDinh;
            _donGia = _ctMuaBanTSCD.DongGia;
            _thanhTien = _ctMuaBanTSCD.ThanhTien;
            _maDonViTinh = _ctMuaBanTSCD.MaDonViTinh;
            _tenLoaiTaiSan = _ctMuaBanTSCD.TenLoaiTaiSanCoDinh;
            _tenTaiSanCoDinh = _ctMuaBanTSCD.TenTaiSanCoDinh;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public CT_HoaDonTSCD(TSCDCaBiet _TSCDCB)
        {
            //_TaiSanCoDinhList = TaiSanCoDinhCaBietList.GetTSCDCaBietCanThanhLy0_DieuChuyen1(0);
            _maTaiSanCoDinh = _TSCDCB.TaiSanCoDinh.MaTSCD;
            _tenTaiSanCoDinh = _TSCDCB.TaiSanCoDinh.TenTSCD;
            _donGia = _TSCDCB.NguyenGiaConLai;
            _soLuong = 1;
            _thanhTien = _donGia * _soLuong;
            if (_TSCDCB.TaiSanCoDinh.MaDonViTinh != 0)
                _maDonViTinh = _TSCDCB.TaiSanCoDinh.MaDonViTinh;
            else
                _maDonViTinh = DonViTinhList.GetDonViTinhList()[0].MaDonViTinh;
            _tenLoaiTaiSan = _TSCDCB.TaiSanCoDinh.TenLoaiTaiSan;
            ValidationRules.CheckRules();
            MarkAsChild();
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
			_maTaiSanCoDinh = dr.GetInt32("MaTaiSanCoDinh");
			_soLuong = dr.GetInt32("SoLuong");
			_donGia = dr.GetDecimal("DonGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_maHoaDon = dr.GetInt64("MaHoaDon");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
            _tenTaiSanCoDinh = dr.GetString("TenTSCD");
            _tenLoaiTaiSan = dr.GetString("TenLoaiTaiSan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HoaDon parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HoaDon parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_HoaDonTSCD";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HoaDon parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHoaDon = parent.MaHoaDon; 
			//cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaTaiSanCoDinh", _maTaiSanCoDinh);
			cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			cm.Parameters.AddWithValue("@DonGia", _donGia);
			cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HoaDon parent)
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

		private void ExecuteUpdate(SqlTransaction tr, HoaDon parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_HoaDonTSCD";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
		{
            _maHoaDon = parent.MaHoaDon; 
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaTaiSanCoDinh", _maTaiSanCoDinh);
			cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			cm.Parameters.AddWithValue("@DonGia", _donGia);
			cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_HoaDonTSCD";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

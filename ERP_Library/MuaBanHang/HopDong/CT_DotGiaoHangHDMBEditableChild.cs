
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_DotGiaoHangHDMB : Csla.BusinessBase<CT_DotGiaoHangHDMB>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private int _maDotGiaoHang = 0;
		private int _maHangHoa = 0;
        private short _soLuong = 0;
		private decimal _donGia = 0;
		private decimal _thanhTien = 0;
        private int _maDonViTinh = 0;
        private double _khoiLuong = 0;
        
        private string _tenHangHoa = string.Empty;
        private string _tenDonViTinh = string.Empty;        
        private string _tenLoaiHangHoa = string.Empty;
        private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
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
        
        public string TenLoaiHangHoa
        {
            get
            {
                CanReadProperty("TenLoaiHangHoa", true);
                return _tenLoaiHangHoa;
            }
            set
            {
                CanWriteProperty("TenLoaiHangHoa", true);
                if (!_tenLoaiHangHoa.Equals(value))
                {
                    _tenLoaiHangHoa = value;
                    PropertyHasChanged("TenLoaiHangHoa");
                }
            }
        }

      
		public int MaDotGiaoHang
		{
			get
			{
				CanReadProperty("MaDotGiaoHang", true);
				return _maDotGiaoHang;
			}
			set
			{
				CanWriteProperty("MaDotGiaoHang", true);
				if (!_maDotGiaoHang.Equals(value))
				{
					_maDotGiaoHang = value;
					PropertyHasChanged("MaDotGiaoHang");
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

		public short SoLuong
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
                    _thanhTien = (decimal)_soLuong * _donGia;
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
                    _thanhTien = (decimal)_soLuong* _donGia;
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
                    _thanhTien = (decimal)_khoiLuong * _donGia;
                    PropertyHasChanged("KhoiLuong");
                }
            }
        }

        public String DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
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
			//TODO: Define authorization rules in CT_DotGiaoHangHDMB
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaDotGiaoHang", "CT_DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_DotGiaoHangHDMBReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_DotGiaoHangHDMBReadGroup");

			//AuthorizationRules.AllowWrite("MaDotGiaoHang", "CT_DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_DotGiaoHangHDMBWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_DotGiaoHangHDMBWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_DotGiaoHangHDMB NewCT_DotGiaoHangHDMB()
		{
			return new CT_DotGiaoHangHDMB();
		}

        public static CT_DotGiaoHangHDMB NewCT_DotGiaoHangHDMB(CT_HopDongMuaBan ct_HopDongMuaBan)
        {
            return new CT_DotGiaoHangHDMB(ct_HopDongMuaBan);
        }

		internal static CT_DotGiaoHangHDMB GetCT_DotGiaoHangHDMB(SafeDataReader dr)
		{
            CT_DotGiaoHangHDMB child = new CT_DotGiaoHangHDMB();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
			//return new CT_DotGiaoHangHDMB(dr);
		}

		private CT_DotGiaoHangHDMB()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}


        private CT_DotGiaoHangHDMB(CT_HopDongMuaBan ct_HopDongMuaBan )
        {
            _maHangHoa = ct_HopDongMuaBan.MaHangHoa;
            _soLuong = ct_HopDongMuaBan.SoLuong;
            _donGia = ct_HopDongMuaBan.DonGia;
            _thanhTien = ct_HopDongMuaBan.ThanhTien;
            _maDonViTinh = ct_HopDongMuaBan.MaDonViTinh;            
            _khoiLuong = ct_HopDongMuaBan.KhoiLuong;
            _dienGiai = ct_HopDongMuaBan.DienGiai;
            _tenDonViTinh = ct_HopDongMuaBan.TenDonViTinh;
            _tenHangHoa = ct_HopDongMuaBan.TenHangHoa;
            
		
            ValidationRules.CheckRules();
            MarkAsChild();
        }


		private CT_DotGiaoHangHDMB(SafeDataReader dr)
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
            try
            {
                _maChiTiet = dr.GetInt32("MaChiTiet");
                _maDotGiaoHang = dr.GetInt32("MaDotGiaoHang");
                _maHangHoa = dr.GetInt32("MaHangHoa");
                _soLuong = dr.GetInt16("SoLuong");
                _donGia = dr.GetDecimal("DonGia");
                _thanhTien = dr.GetDecimal("ThanhTien");
                _maDonViTinh = dr.GetInt32("MaDonViTinh");
                _khoiLuong = dr.GetDouble("KhoiLuong");                
                _tenHangHoa = dr.GetString("TenHangHoa");
                _tenDonViTinh = dr.GetString("TenDonViTinh");                
                _tenLoaiHangHoa = dr.GetString("TenLoaiHangHoa");
                _dienGiai = dr.GetString("DienGiai");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DotGiaoHangHDMB parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DotGiaoHangHDMB parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_DotGiaoHangHDMB";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DotGiaoHangHDMB parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maDotGiaoHang = parent.MaChiTiet;
			cm.Parameters.AddWithValue("@MaDotGiaoHang", parent.MaChiTiet);
            if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);			
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);			
				cm.Parameters.AddWithValue("@DonGia", _donGia);						
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);			
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);            
                cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DotGiaoHangHDMB parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DotGiaoHangHDMB parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_DotGiaoHangHDMB";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DotGiaoHangHDMB parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaDotGiaoHang", parent.MaChiTiet);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);			
			
				cm.Parameters.AddWithValue("@DonGia", _donGia);

                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            
                cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);
           
            
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
                cm.CommandText = "spd_DeletetblCT_DotGiaoHangHDMB";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
}

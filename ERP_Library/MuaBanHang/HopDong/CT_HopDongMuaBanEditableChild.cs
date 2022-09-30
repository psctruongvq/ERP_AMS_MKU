
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HopDongMuaBan : Csla.BusinessBase<CT_HopDongMuaBan>
	{
		#region Business Properties and Methods
		//declare members

		private int _mactHopdong = 0;
		private long _maHopDong = 0;
		private int _maHangHoa = 0;
		private short _soLuong = 0;
		private decimal _donGia = 0;
		private int _chietKhau = 0;
        private int _maDonViTinh = 0;
        private double _khoiLuong = 0;                
        private decimal _thanhTien = 0;        
        private string _maQuanLy = string.Empty;
        private string _dienGiai = string.Empty;
        private string _tenHangHoa = string.Empty;
        private string _tenDonViTinh = string.Empty;        
        private string _tenLoaiHangHoa = string.Empty;


		[System.ComponentModel.DataObjectField(true, true)]
		public int MactHopdong
		{
			get
			{
				CanReadProperty("MactHopdong", true);
				return _mactHopdong;
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


        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
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
                    //HangHoa hangHoa = ERP_Library.HangHoa.GetHangHoa(_maHangHoa);                   
                    //_maDonViTinh = hangHoa.MaDonViTinh;
                    //_tenDonViTinh = DonViTinh.GetDonViTinh(_maDonViTinh).TenDonViTinh;                    

                    //_dGTienDa = ERP_Library.HangHoa.GetHangHoa(_maHangHoa).TienDa;                   
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
                    _thanhTien = (_donGia * (decimal)_soLuong);
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
                    _thanhTien = (_donGia * (decimal)_soLuong);
					PropertyHasChanged("DonGia");
				}
			}
		}

		public int ChietKhau
		{
			get
			{
				CanReadProperty("ChietKhau", true);
				return _chietKhau;
			}
			set
			{
				CanWriteProperty("ChietKhau", true);
				if (!_chietKhau.Equals(value))
				{
					_chietKhau = value;
					PropertyHasChanged("ChietKhau");
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
                    _thanhTien = (_donGia * (decimal)_khoiLuong);
                    PropertyHasChanged("KhoiLuong");
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
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }
 

		protected override object GetIdValue()
		{
			return _mactHopdong;
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
			//TODO: Define authorization rules in CT_HopDongMuaBan
			//AuthorizationRules.AllowRead("MactHopdong", "CT_HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "CT_HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_HopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("ChietKhau", "CT_HopDongMuaBanReadGroup");

			//AuthorizationRules.AllowWrite("MaHopDong", "CT_HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_HopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("ChietKhau", "CT_HopDongMuaBanWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_HopDongMuaBan NewCT_HopDongMuaBan()
		{
			return new CT_HopDongMuaBan();
		}

        public static CT_HopDongMuaBan NewCT_HopDongMuaBan(CT_HopDongMuaBan ctHopDongMuaBan)
        {
            return new CT_HopDongMuaBan(ctHopDongMuaBan);
        }

		internal static CT_HopDongMuaBan GetCT_HopDongMuaBan(SafeDataReader dr)
		{
			return new CT_HopDongMuaBan(dr);
		}

		public CT_HopDongMuaBan()
		{
			ValidationRules.CheckRules();
			MarkAsChild();
		}

        public CT_HopDongMuaBan(CT_HopDongMuaBan ctHopDongMuaBan)
        {
            _chietKhau = ctHopDongMuaBan.ChietKhau;            
            _donGia = ctHopDongMuaBan.DonGia;
            _tenHangHoa = ctHopDongMuaBan.TenHangHoa;
            _khoiLuong = ctHopDongMuaBan.KhoiLuong;
            _mactHopdong = ctHopDongMuaBan.MactHopdong;            
            _maDonViTinh = ctHopDongMuaBan.MaDonViTinh;
            _maHangHoa = ctHopDongMuaBan.MaHangHoa;
            _maHopDong = ctHopDongMuaBan.MaHopDong;
            _maQuanLy = ctHopDongMuaBan.MaQuanLy;
            _soLuong = ctHopDongMuaBan.SoLuong;
            _thanhTien = ctHopDongMuaBan.ThanhTien;
            _tenDonViTinh = ctHopDongMuaBan.TenDonViTinh;
            _dienGiai = ctHopDongMuaBan._dienGiai;
            MarkAsChild();
        }

		private CT_HopDongMuaBan(SafeDataReader dr)
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
			_mactHopdong = dr.GetInt32("MaCT_HopDong");
			_maHopDong = dr.GetInt64("MaHopDong");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_soLuong = dr.GetInt16("SoLuong");
			_donGia = dr.GetDecimal("DonGia");
			_chietKhau = dr.GetInt32("ChietKhau");
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _khoiLuong = dr.GetDouble("KhoiLuong");
            _dienGiai = dr.GetString("DienGiai");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _tenDonViTinh= dr.GetString("TenDonViTinh");            
            _tenLoaiHangHoa= dr.GetString("TenLoaiHangHoa");

          //  _maHangHoa = dr.GetString("MaQuanLy");
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
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblCT_HopDongMuaBan";

                    AddInsertParameters(cm, parent);

                    cm.ExecuteNonQuery();

                    _mactHopdong = (int)cm.Parameters["@MaCT_HopDong"].Value;
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHopDong = parent.MaHopDong;
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            
				cm.Parameters.AddWithValue("@DonGia", _donGia);
            
				cm.Parameters.AddWithValue("@ChietKhau", _chietKhau);
            
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            
                cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);
          
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
     
			cm.Parameters.AddWithValue("@MaCT_HopDong", _mactHopdong);
			cm.Parameters["@MaCT_HopDong"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblCT_HopDongMuaBan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			cm.Parameters.AddWithValue("@MaCT_HopDong", _mactHopdong);
			cm.Parameters.AddWithValue("@MaHopDong", parent.MaHopDong);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            //if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            //else
            //    cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            //if (_donGia != 0)
				cm.Parameters.AddWithValue("@DonGia", _donGia);
            //else
            //    cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            //if (_chietKhau != 0)
				cm.Parameters.AddWithValue("@ChietKhau", _chietKhau);
            //else
            //    cm.Parameters.AddWithValue("@ChietKhau", DBNull.Value);
            if (_maDonViTinh != 0)
                cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
            
                cm.Parameters.AddWithValue("@KhoiLuong", _khoiLuong);          
          
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
          
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
                cm.CommandText = "spd_DeletetblCT_HopDongMuaBan";

				cm.Parameters.AddWithValue("@MaCT_HopDong", this._mactHopdong);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HoaDon : Csla.BusinessBase<CT_HoaDon>
	{
		#region Business Properties and Methods
        
		//declare members
		private long _mactHoadon = 0;
		private long _maHoaDon = 0;
		private int _maHangHoa = 0;
		private int _soLuong = 0;
		private decimal _donGia = 0;
		private decimal _thanhTien = 0;
		private int _maDonViTinh = 0;		
        private string _dienGiai = string.Empty;
        private string _tenHangHoa = string.Empty;
        private string _tenDonViTinh = string.Empty;        
             
		[System.ComponentModel.DataObjectField(true, true)]

        #region methods

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
        
        public long MactHoadon
		{
			get
			{
				CanReadProperty("MactHoadon", true);
				return _mactHoadon;
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
                    //HangHoa = HangHoa.GetHangHoa(_maHangHoa);
					PropertyHasChanged("MaHangHoa");
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
                    _thanhTien = ((decimal)_soLuong * _donGia); 
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
                    _thanhTien = ((decimal)_soLuong * _donGia ) ; 
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

        #endregion        


        protected override object GetIdValue()
		{
			return _mactHoadon;
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
			//TODO: Define authorization rules in CT_HoaDon
			//AuthorizationRules.AllowRead("MactHoadon", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("MaHoaDon", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("DonGia", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("KhoiLuongVang", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("MaDonViKhoiLuong", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("DGTienCong", "CT_HoaDonReadGroup");
			//AuthorizationRules.AllowRead("DGTienDa", "CT_HoaDonReadGroup");

			//AuthorizationRules.AllowWrite("MaHoaDon", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("DonGia", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("KhoiLuongVang", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViKhoiLuong", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("DGTienCong", "CT_HoaDonWriteGroup");
			//AuthorizationRules.AllowWrite("DGTienDa", "CT_HoaDonWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CT_HoaDon NewCT_HoaDon()
		{
			return new CT_HoaDon();
		}       
         
		internal static CT_HoaDon GetCT_HoaDon(SafeDataReader dr)
		{
			return new CT_HoaDon(dr);
		}

		public CT_HoaDon()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_HoaDon(SafeDataReader dr)
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
			_mactHoadon = dr.GetInt64("MaCT_HoaDon");
			_maHoaDon = dr.GetInt64("MaHoaDon");
			_maHangHoa = dr.GetInt32("MaHangHoa");
            _soLuong = dr.GetInt32("SoLuong");
			_donGia = dr.GetDecimal("DonGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_maDonViTinh= dr.GetInt32("MaDonViTinh");			
            _dienGiai = dr.GetString("DienGiai");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _tenDonViTinh = dr.GetString("TenDonViTinh");

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
                cm.CommandText = "spd_InserttblCT_HoaDon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactHoadon = (long)cm.Parameters["@MaCT_HoaDon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HoaDon parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHoaDon = parent.MaHoaDon; 
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			cm.Parameters.AddWithValue("@DonGia", _donGia);
		    cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);		
            if(_maDonViTinh!=0)
			    cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            else
                cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);			
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);						
			cm.Parameters.AddWithValue("@MaCT_HoaDon", _mactHoadon);
			cm.Parameters["@MaCT_HoaDon"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblCT_HoaDon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
		{
			cm.Parameters.AddWithValue("@MaCT_HoaDon", _mactHoadon);
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			cm.Parameters.AddWithValue("@DonGia", _donGia);			
			cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);			
			cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);						
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
                cm.CommandText = "spd_DeletetblCT_HoaDon";

				cm.Parameters.AddWithValue("@MaCT_HoaDon", this._mactHoadon);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
}

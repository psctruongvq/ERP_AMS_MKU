
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_KHCapPhatVatTu : Csla.BusinessBase<CT_KHCapPhatVatTu>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactKehoachcapphat = 0;
		private int _maKeHoachCapPhatVattu = 0;
		private int _maHangHoa = 0;
		private decimal _soLuongDeXuatSD = 0;
		private string _dienGiai = string.Empty;
		private decimal _soLuongDeNghi = 0;
		private decimal _donGiaTamTinh = 0;
		private decimal _thanhTienTamTinh = 0;
		private decimal _soLuongTHNamTruoc = 0;
        private decimal _soLuongKHNamTruoc = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactKehoachcapphat
		{
			get
			{
				CanReadProperty("MactKehoachcapphat", true);
				return _mactKehoachcapphat;
			}
		}

		public int MaKeHoachCapPhatVattu
		{
			get
			{
				CanReadProperty("MaKeHoachCapPhatVattu", true);
				return _maKeHoachCapPhatVattu;
			}
			set
			{
				CanWriteProperty("MaKeHoachCapPhatVattu", true);
				if (!_maKeHoachCapPhatVattu.Equals(value))
				{
					_maKeHoachCapPhatVattu = value;
					PropertyHasChanged("MaKeHoachCapPhatVattu");
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

		public decimal SoLuongDeXuatSD
		{
			get
			{
				CanReadProperty("SoLuongDeXuatSD", true);
				return _soLuongDeXuatSD;
			}
			set
			{
				CanWriteProperty("SoLuongDeXuatSD", true);
				if (!_soLuongDeXuatSD.Equals(value))
				{
					_soLuongDeXuatSD = value;
					PropertyHasChanged("SoLuongDeXuatSD");
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

		public decimal SoLuongDeNghi
		{
			get
			{
				CanReadProperty("SoLuongDeNghi", true);
				return _soLuongDeNghi;
			}
			set
			{
				CanWriteProperty("SoLuongDeNghi", true);
				if (!_soLuongDeNghi.Equals(value))
				{
					_soLuongDeNghi = value;
                    _thanhTienTamTinh = _soLuongDeNghi * _donGiaTamTinh;
					PropertyHasChanged("SoLuongDeNghi");
				}
			}
		}

		public decimal DonGiaTamTinh
		{
			get
			{
				CanReadProperty("DonGiaTamTinh", true);
				return _donGiaTamTinh;
			}
			set
			{
				CanWriteProperty("DonGiaTamTinh", true);
				if (!_donGiaTamTinh.Equals(value))
				{
					_donGiaTamTinh = value;
                    _thanhTienTamTinh = _soLuongDeNghi * _donGiaTamTinh;
					PropertyHasChanged("DonGiaTamTinh");
				}
			}
		}

		public decimal ThanhTienTamTinh
		{
			get
			{
				CanReadProperty("ThanhTienTamTinh", true);
				return _thanhTienTamTinh;
			}
			set
			{
				CanWriteProperty("ThanhTienTamTinh", true);
				if (!_thanhTienTamTinh.Equals(value))
				{
					_thanhTienTamTinh = value;
					PropertyHasChanged("ThanhTienTamTinh");
				}
			}
		}

		public decimal SoLuongTHNamTruoc
		{
			get
			{
				CanReadProperty("SoLuongTHNamTruoc", true);
				return _soLuongTHNamTruoc;
			}
			set
			{
				CanWriteProperty("SoLuongTHNamTruoc", true);
				if (!_soLuongTHNamTruoc.Equals(value))
				{
					_soLuongTHNamTruoc = value;
					PropertyHasChanged("SoLuongTHNamTruoc");
				}
			}
		}
        public decimal SoLuongKHNamTruoc
        {
            get
            {
                CanReadProperty("SoLuongKHNamTruoc", true);
                return _soLuongKHNamTruoc;
            }
            set
            {
                CanWriteProperty("SoLuongKHNamTruoc", true);
                if (!_soLuongKHNamTruoc.Equals(value))
                {
                    _soLuongKHNamTruoc = value;
                    PropertyHasChanged("SoLuongKHNamTruoc");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _mactKehoachcapphat;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
			//TODO: Define authorization rules in CT_KHCapPhatVatTu
			//AuthorizationRules.AllowRead("MactKehoachcapphat", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("MaKeHoachCapPhatVattu", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("SoLuongDeXuatSD", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("SoLuongDeNghi", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("DonGiaTamTinh", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("ThanhTienTamTinh", "CT_KHCapPhatVatTuReadGroup");
			//AuthorizationRules.AllowRead("SoLuongTHNamTruoc", "CT_KHCapPhatVatTuReadGroup");

			//AuthorizationRules.AllowWrite("MaKeHoachCapPhatVattu", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongDeXuatSD", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongDeNghi", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("DonGiaTamTinh", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTienTamTinh", "CT_KHCapPhatVatTuWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongTHNamTruoc", "CT_KHCapPhatVatTuWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_KHCapPhatVatTu NewCT_KHCapPhatVatTu()
		{
			return new CT_KHCapPhatVatTu();
		}

		internal static CT_KHCapPhatVatTu GetCT_KHCapPhatVatTu(SafeDataReader dr)
		{
			return new CT_KHCapPhatVatTu(dr);
		}

		private CT_KHCapPhatVatTu()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_KHCapPhatVatTu(SafeDataReader dr)
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
			_mactKehoachcapphat = dr.GetInt32("MaCT_KeHoachCapPhat");
			_maKeHoachCapPhatVattu = dr.GetInt32("MaKeHoachCapPhatVattu");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_soLuongDeXuatSD = dr.GetDecimal("SoLuongDeXuatSD");
			_dienGiai = dr.GetString("DienGiai");
			_soLuongDeNghi = dr.GetDecimal("SoLuongDeNghi");
			_donGiaTamTinh = dr.GetDecimal("DonGiaTamTinh");
			_thanhTienTamTinh = dr.GetDecimal("ThanhTienTamTinh");
			_soLuongTHNamTruoc = dr.GetDecimal("SoLuongTHNamTruoc");
            _soLuongKHNamTruoc = dr.GetDecimal("SoLuongKHNamTruoc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KHCapPhatVatTu parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KHCapPhatVatTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KeHoachCapPhatVatTu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactKehoachcapphat = (int)cm.Parameters["@MaCT_KeHoachCapPhat"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KHCapPhatVatTu parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maKeHoachCapPhatVattu = parent.MakeHoachCapPhat;
			if (_maKeHoachCapPhatVattu != 0)
				cm.Parameters.AddWithValue("@MaKeHoachCapPhatVattu", _maKeHoachCapPhatVattu);
			else
				cm.Parameters.AddWithValue("@MaKeHoachCapPhatVattu", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_soLuongDeXuatSD != 0)
				cm.Parameters.AddWithValue("@SoLuongDeXuatSD", _soLuongDeXuatSD);
			else
				cm.Parameters.AddWithValue("@SoLuongDeXuatSD", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soLuongDeNghi != 0)
				cm.Parameters.AddWithValue("@SoLuongDeNghi", _soLuongDeNghi);
			else
				cm.Parameters.AddWithValue("@SoLuongDeNghi", DBNull.Value);
			if (_donGiaTamTinh != 0)
				cm.Parameters.AddWithValue("@DonGiaTamTinh", _donGiaTamTinh);
			else
				cm.Parameters.AddWithValue("@DonGiaTamTinh", DBNull.Value);
			if (_thanhTienTamTinh != 0)
				cm.Parameters.AddWithValue("@ThanhTienTamTinh", _thanhTienTamTinh);
			else
				cm.Parameters.AddWithValue("@ThanhTienTamTinh", DBNull.Value);
			if (_soLuongTHNamTruoc != 0)
				cm.Parameters.AddWithValue("@SoLuongTHNamTruoc", _soLuongTHNamTruoc);
			else
				cm.Parameters.AddWithValue("@SoLuongTHNamTruoc", DBNull.Value);
            if (_soLuongKHNamTruoc != 0)
                cm.Parameters.AddWithValue("@SoLuongKHNamTruoc", _soLuongKHNamTruoc);
            else
                cm.Parameters.AddWithValue("@SoLuongKHNamTruoc", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_KeHoachCapPhat", _mactKehoachcapphat);
			cm.Parameters["@MaCT_KeHoachCapPhat"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KHCapPhatVatTu parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KHCapPhatVatTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KeHoachCapPhatVatTu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KHCapPhatVatTu parent)
		{
			cm.Parameters.AddWithValue("@MaCT_KeHoachCapPhat", _mactKehoachcapphat);
			if (_maKeHoachCapPhatVattu != 0)
				cm.Parameters.AddWithValue("@MaKeHoachCapPhatVattu", _maKeHoachCapPhatVattu);
			else
				cm.Parameters.AddWithValue("@MaKeHoachCapPhatVattu", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_soLuongDeXuatSD != 0)
				cm.Parameters.AddWithValue("@SoLuongDeXuatSD", _soLuongDeXuatSD);
			else
				cm.Parameters.AddWithValue("@SoLuongDeXuatSD", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soLuongDeNghi != 0)
				cm.Parameters.AddWithValue("@SoLuongDeNghi", _soLuongDeNghi);
			else
				cm.Parameters.AddWithValue("@SoLuongDeNghi", DBNull.Value);
			if (_donGiaTamTinh != 0)
				cm.Parameters.AddWithValue("@DonGiaTamTinh", _donGiaTamTinh);
			else
				cm.Parameters.AddWithValue("@DonGiaTamTinh", DBNull.Value);
			if (_thanhTienTamTinh != 0)
				cm.Parameters.AddWithValue("@ThanhTienTamTinh", _thanhTienTamTinh);
			else
				cm.Parameters.AddWithValue("@ThanhTienTamTinh", DBNull.Value);
			if (_soLuongTHNamTruoc != 0)
				cm.Parameters.AddWithValue("@SoLuongTHNamTruoc", _soLuongTHNamTruoc);
			else
				cm.Parameters.AddWithValue("@SoLuongTHNamTruoc", DBNull.Value);
            if (_soLuongKHNamTruoc != 0)
                cm.Parameters.AddWithValue("@SoLuongKHNamTruoc", _soLuongKHNamTruoc);
            else
                cm.Parameters.AddWithValue("@SoLuongKHNamTruoc", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_KeHoachCapPhatVatTu";

				cm.Parameters.AddWithValue("@MaCT_KeHoachCapPhat", this._mactKehoachcapphat);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

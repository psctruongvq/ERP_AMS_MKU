
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhieuLinhNhienLieu : Csla.BusinessBase<CT_PhieuLinhNhienLieu>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactPhieulinhnhienlieu = 0;
		private long _maPhieuLinhNhienLieu = 0;
		private int _maHangHoa = 0;
        private int _maDonViTinh = DonViTinh.GetDonViTinh("lit").MaDonViTinh;  //14 default là lít
		private decimal _soLuongYeuCau = 0;
		private decimal _soLuongXuat = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactPhieulinhnhienlieu
		{
			get
			{
				CanReadProperty("MactPhieulinhnhienlieu", true);
				return _mactPhieulinhnhienlieu;
			}
		}

		public long MaPhieuLinhNhienLieu
		{
			get
			{
				CanReadProperty("MaPhieuLinhNhienLieu", true);
				return _maPhieuLinhNhienLieu;
			}
			set
			{
				CanWriteProperty("MaPhieuLinhNhienLieu", true);
				if (!_maPhieuLinhNhienLieu.Equals(value))
				{
					_maPhieuLinhNhienLieu = value;
					PropertyHasChanged("MaPhieuLinhNhienLieu");
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

		public decimal SoLuongYeuCau
		{
			get
			{
				CanReadProperty("SoLuongYeuCau", true);
				return _soLuongYeuCau;
			}
			set
			{
				CanWriteProperty("SoLuongYeuCau", true);
				if (!_soLuongYeuCau.Equals(value))
				{
					_soLuongYeuCau = value;
                    _soLuongXuat = _soLuongYeuCau;  //Thang
					PropertyHasChanged("SoLuongYeuCau");
				}
			}
		}

		public decimal SoLuongXuat
		{
			get
			{
				CanReadProperty("SoLuongXuat", true);
				return _soLuongXuat;
			}
			set
			{
				CanWriteProperty("SoLuongXuat", true);
				if (!_soLuongXuat.Equals(value))
				{
					_soLuongXuat = value;
					PropertyHasChanged("SoLuongXuat");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
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
			return _mactPhieulinhnhienlieu;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1000));
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
			//TODO: Define authorization rules in CT_PhieuLinhNhienLieu
			//AuthorizationRules.AllowRead("MactPhieulinhnhienlieu", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuLinhNhienLieu", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaDonViTinh", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("SoLuongYeuCau", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("SoLuongXuat", "CT_PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "CT_PhieuLinhNhienLieuReadGroup");

			//AuthorizationRules.AllowWrite("MaPhieuLinhNhienLieu", "CT_PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViTinh", "CT_PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongYeuCau", "CT_PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongXuat", "CT_PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "CT_PhieuLinhNhienLieuWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_PhieuLinhNhienLieu NewCT_PhieuLinhNhienLieu()
		{
			return new CT_PhieuLinhNhienLieu();
		}

		internal static CT_PhieuLinhNhienLieu GetCT_PhieuLinhNhienLieu(SafeDataReader dr)
		{
			return new CT_PhieuLinhNhienLieu(dr);
		}

		private CT_PhieuLinhNhienLieu()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_PhieuLinhNhienLieu(SafeDataReader dr)
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
			_mactPhieulinhnhienlieu = dr.GetInt32("MaCT_PhieuLinhNhienLieu");
			_maPhieuLinhNhienLieu = dr.GetInt64("MaPhieuLinhNhienLieu");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_maDonViTinh = dr.GetInt32("MaDonViTinh");
			_soLuongYeuCau = dr.GetDecimal("SoLuongYeuCau");
			_soLuongXuat = dr.GetDecimal("SoLuongXuat");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhieuLinhNhienLieu parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhieuLinhNhienLieu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhieuLinhNhienLieu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactPhieulinhnhienlieu = (int)cm.Parameters["@MaCT_PhieuLinhNhienLieu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhieuLinhNhienLieu parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuLinhNhienLieu = parent.MaPhieuLinhNhienLieu;
			if (_maPhieuLinhNhienLieu != 0)
				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
			else
				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_soLuongYeuCau != 0)
				cm.Parameters.AddWithValue("@SoLuongYeuCau", _soLuongYeuCau);
			else
				cm.Parameters.AddWithValue("@SoLuongYeuCau", DBNull.Value);
			if (_soLuongXuat != 0)
				cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
			else
				cm.Parameters.AddWithValue("@SoLuongXuat", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_PhieuLinhNhienLieu", _mactPhieulinhnhienlieu);
			cm.Parameters["@MaCT_PhieuLinhNhienLieu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhieuLinhNhienLieu parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhieuLinhNhienLieu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhieuLinhNhienLieu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhieuLinhNhienLieu parent)
		{
			cm.Parameters.AddWithValue("@MaCT_PhieuLinhNhienLieu", _mactPhieulinhnhienlieu);
			if (_maPhieuLinhNhienLieu != 0)
				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
			else
				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maDonViTinh != 0)
				cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
			else
				cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
			if (_soLuongYeuCau != 0)
				cm.Parameters.AddWithValue("@SoLuongYeuCau", _soLuongYeuCau);
			else
				cm.Parameters.AddWithValue("@SoLuongYeuCau", DBNull.Value);
			if (_soLuongXuat != 0)
				cm.Parameters.AddWithValue("@SoLuongXuat", _soLuongXuat);
			else
				cm.Parameters.AddWithValue("@SoLuongXuat", DBNull.Value);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCT_PhieuLinhNhienLieu";

				cm.Parameters.AddWithValue("@MaCT_PhieuLinhNhienLieu", this._mactPhieulinhnhienlieu);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

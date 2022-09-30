
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietButToan : Csla.BusinessBase<ChiTietButToan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private int _maButToan = 0;
		private int _maHangHoa = 0;
		private int _maLoaiVang = 0;
		private int _soLuong = 0;
		private double _khoiLuongVang = 0;
		private double _khoiLuongQ10 = 0;
		private decimal _tuoiVang = 0;
        private string _tenHangHoa = string.Empty;
        private string _tenLoaiVang = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaButToan
		{
			get
			{
				CanReadProperty("MaButToan", true);
				return _maButToan;
			}
			set
			{
				CanWriteProperty("MaButToan", true);
				if (!_maButToan.Equals(value))
				{
					_maButToan = value;
					PropertyHasChanged("MaButToan");
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

		public int MaLoaiVang
		{
			get
			{
				CanReadProperty("MaLoaiVang", true);
				return _maLoaiVang;
			}
			set
			{
				CanWriteProperty("MaLoaiVang", true);
				if (!_maLoaiVang.Equals(value))
				{
					_maLoaiVang = value;
					PropertyHasChanged("MaLoaiVang");
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
					PropertyHasChanged("SoLuong");
				}
			}
		}

		public double KhoiLuongVang
		{
			get
			{
				CanReadProperty("KhoiLuongVang", true);
				return _khoiLuongVang;
			}
			set
			{
				CanWriteProperty("KhoiLuongVang", true);
				if (!_khoiLuongVang.Equals(value))
				{
					_khoiLuongVang = value;
					PropertyHasChanged("KhoiLuongVang");
				}
			}
		}

		public double KhoiLuongQ10
		{
			get
			{
				CanReadProperty("KhoiLuongQ10", true);
				return _khoiLuongQ10;
			}
			set
			{
				CanWriteProperty("KhoiLuongQ10", true);
				if (!_khoiLuongQ10.Equals(value))
				{
					_khoiLuongQ10 = value;
					PropertyHasChanged("KhoiLuongQ10");
				}
			}
		}

		public decimal TuoiVang
		{
			get
			{
				CanReadProperty("TuoiVang", true);
				return _tuoiVang;
			}
			set
			{
				CanWriteProperty("TuoiVang", true);
				if (!_tuoiVang.Equals(value))
				{
					_tuoiVang = value;
					PropertyHasChanged("TuoiVang");
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

        public string TenLoaiVang 
        {
            get
            {
                CanReadProperty("TenLoaiVang", true);
                return _tenLoaiVang;
            }
            set
            {
                CanWriteProperty("TenLoaiVang", true);
                if (!_tenLoaiVang.Equals(value))
                {
                    _tenLoaiVang = value;
                    PropertyHasChanged("TenLoaiVang");
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
			//TODO: Define authorization rules in ChiTietButToan
			//AuthorizationRules.AllowRead("MaChiTiet", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("MaButToan", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiVang", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("SoLuong", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("KhoiLuongVang", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("KhoiLuongQ10", "ChiTietButToanReadGroup");
			//AuthorizationRules.AllowRead("TuoiVang", "ChiTietButToanReadGroup");

			//AuthorizationRules.AllowWrite("MaButToan", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiVang", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuong", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("KhoiLuongVang", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("KhoiLuongQ10", "ChiTietButToanWriteGroup");
			//AuthorizationRules.AllowWrite("TuoiVang", "ChiTietButToanWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods       
             

		internal static ChiTietButToan NewChiTietButToan()
		{
			return new ChiTietButToan();
		}

		internal static ChiTietButToan GetChiTietButToan(SafeDataReader dr)
		{
			return new ChiTietButToan(dr);
		}

		private ChiTietButToan()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

       
		private ChiTietButToan(SafeDataReader dr)
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
			_maButToan = dr.GetInt32("MaButToan");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_maLoaiVang = dr.GetInt32("MaLoaiVang");
			_soLuong = dr.GetInt32("SoLuong");
			_khoiLuongVang = dr.GetDouble("KhoiLuongVang");
			_khoiLuongQ10 = dr.GetDouble("KhoiLuongQ10");
			_tuoiVang = dr.GetDecimal("TuoiVang");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _tenLoaiVang= dr.GetString("TenLoaiVang"); 
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ButToan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ButToan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChiTietButToan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ButToan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maButToan = parent.MaButToan;
			if (_maButToan != 0)
				cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			else
				cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maLoaiVang != 0)
				cm.Parameters.AddWithValue("@MaLoaiVang", _maLoaiVang);
			else
				cm.Parameters.AddWithValue("@MaLoaiVang", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_khoiLuongVang != 0)
				cm.Parameters.AddWithValue("@KhoiLuongVang", _khoiLuongVang);
			else
				cm.Parameters.AddWithValue("@KhoiLuongVang", DBNull.Value);
			if (_khoiLuongQ10 != 0)
				cm.Parameters.AddWithValue("@KhoiLuongQ10", _khoiLuongQ10);
			else
				cm.Parameters.AddWithValue("@KhoiLuongQ10", DBNull.Value);
			if (_tuoiVang != 0)
				cm.Parameters.AddWithValue("@TuoiVang", _tuoiVang);
			else
				cm.Parameters.AddWithValue("@TuoiVang", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ButToan parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ButToan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChiTietButToan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ButToan parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maButToan != 0)
				cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			else
				cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maLoaiVang != 0)
				cm.Parameters.AddWithValue("@MaLoaiVang", _maLoaiVang);
			else
				cm.Parameters.AddWithValue("@MaLoaiVang", DBNull.Value);
			if (_soLuong != 0)
				cm.Parameters.AddWithValue("@SoLuong", _soLuong);
			else
				cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
			if (_khoiLuongVang != 0)
				cm.Parameters.AddWithValue("@KhoiLuongVang", _khoiLuongVang);
			else
				cm.Parameters.AddWithValue("@KhoiLuongVang", DBNull.Value);
			if (_khoiLuongQ10 != 0)
				cm.Parameters.AddWithValue("@KhoiLuongQ10", _khoiLuongQ10);
			else
				cm.Parameters.AddWithValue("@KhoiLuongQ10", DBNull.Value);
			if (_tuoiVang != 0)
				cm.Parameters.AddWithValue("@TuoiVang", _tuoiVang);
			else
				cm.Parameters.AddWithValue("@TuoiVang", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblChiTietButToan";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

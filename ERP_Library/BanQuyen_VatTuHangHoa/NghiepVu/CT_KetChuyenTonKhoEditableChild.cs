
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_KetChuyenTonKho : Csla.BusinessBase<CT_KetChuyenTonKho>
	{
		#region Business Properties and Methods

		//declare members
		private long _mactKetchuyen = 0;
		private int _maHangHoa = 0;
        private string _tenHangHoa = string.Empty;//M
		private decimal _soLuongTon = 0;
		private decimal _giaTriTon = 0;
		private long _maKetChuyen = 0;
		private string _dienGiai = string.Empty;
        

		[System.ComponentModel.DataObjectField(true, true)]
		public long MactKetchuyen
		{
			get
			{
				CanReadProperty("MactKetchuyen", true);
				return _mactKetchuyen;
			}
		}

		public int MaHangHoa
		{
			get
			{
				CanReadProperty("MaHangHoa", true);
                if (_maHangHoa != 0)
                {
                    //_tenHangHoa=HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa;                    
                }
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
                //_tenHangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa;
			}
		}
        public String TenHangHoa
        {
            get
            {
                
                return _tenHangHoa;
            }
        }

		public decimal SoLuongTon
		{
			get
			{
				CanReadProperty("SoLuongTon", true);
				return _soLuongTon;
			}
			set
			{
				CanWriteProperty("SoLuongTon", true);
				if (!_soLuongTon.Equals(value))
				{
					_soLuongTon = value;
					PropertyHasChanged("SoLuongTon");
				}
			}
		}

		public decimal GiaTriTon
		{
			get
			{
				CanReadProperty("GiaTriTon", true);
				return _giaTriTon;
			}
			set
			{
				CanWriteProperty("GiaTriTon", true);
				if (!_giaTriTon.Equals(value))
				{
					_giaTriTon = value;
					PropertyHasChanged("GiaTriTon");
				}
			}
		}

		public long MaKetChuyen
		{
			get
			{
				CanReadProperty("MaKetChuyen", true);
				return _maKetChuyen;
			}
			set
			{
				CanWriteProperty("MaKetChuyen", true);
				if (!_maKetChuyen.Equals(value))
				{
					_maKetChuyen = value;
					PropertyHasChanged("MaKetChuyen");
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
			return _mactKetchuyen;
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
			//TODO: Define authorization rules in CT_KetChuyenTonKho
			//AuthorizationRules.AllowRead("MactKetchuyen", "CT_KetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "CT_KetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("SoLuongTon", "CT_KetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("GiaTriTon", "CT_KetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKetChuyen", "CT_KetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "CT_KetChuyenTonKhoReadGroup");

			//AuthorizationRules.AllowWrite("MaHangHoa", "CT_KetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("SoLuongTon", "CT_KetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("GiaTriTon", "CT_KetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaKetChuyen", "CT_KetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "CT_KetChuyenTonKhoWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_KetChuyenTonKho NewCT_KetChuyenTonKho()
		{
			return new CT_KetChuyenTonKho();
		}

		internal static CT_KetChuyenTonKho GetCT_KetChuyenTonKho(SafeDataReader dr, bool kieu)
		{
			return new CT_KetChuyenTonKho(dr, kieu);
		}

		private CT_KetChuyenTonKho()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_KetChuyenTonKho(SafeDataReader dr, bool kieu)
		{
			MarkAsChild();
			Fetch(dr,kieu);
		}
		#endregion //Factory Methods


		#region Data Access

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr, bool _kieu)
		{
			FetchObject(dr);
            if (_kieu == false)
                MarkNew();
            else
			    MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_mactKetchuyen = dr.GetInt64("MaCT_KetChuyen");
			_maHangHoa = dr.GetInt32("MaHangHoa");
            //_tenHangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_maHangHoa).TenHangHoa;//M
            _tenHangHoa = dr.GetString("TenHangHoa");
			_soLuongTon = dr.GetDecimal("SoLuongTon");
			_giaTriTon = dr.GetDecimal("GiaTriTon");
			_maKetChuyen = dr.GetInt64("MaKetChuyen");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KyKetChuyenTonKho parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KyKetChuyenTonKho parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KetChuyenTonKho";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactKetchuyen = (long)cm.Parameters["@MaCT_KetChuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KyKetChuyenTonKho parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maKetChuyen = parent.MaKetChuyen;
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			cm.Parameters.AddWithValue("@SoLuongTon", _soLuongTon);
			cm.Parameters.AddWithValue("@GiaTriTon", _giaTriTon);
			cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_KetChuyen", _mactKetchuyen);
			cm.Parameters["@MaCT_KetChuyen"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KyKetChuyenTonKho parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KyKetChuyenTonKho parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KetChuyenTonKho";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KyKetChuyenTonKho parent)
		{
			cm.Parameters.AddWithValue("@MaCT_KetChuyen", _mactKetchuyen);
			cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			cm.Parameters.AddWithValue("@SoLuongTon", _soLuongTon);
			cm.Parameters.AddWithValue("@GiaTriTon", _giaTriTon);
			cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
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
                cm.CommandText = "spd_DeletetblCT_KetChuyenTonKho";

				cm.Parameters.AddWithValue("@MaCT_KetChuyen", this._mactKetchuyen);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

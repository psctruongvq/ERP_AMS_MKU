
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_HopDongMuaBanNgoaiTe : Csla.BusinessBase<CT_HopDongMuaBanNgoaiTe>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private decimal _nguyenTe = 0;
		private int _maLoaiTien = 0;
		private decimal _tyGia = 0;
		private decimal _thanhTienVND = 0;
		private long _maHopDong = 0;
        private LoaiTien _loaiTien =  LoaiTien.NewLoaiTien();
        

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public decimal NguyenTe
		{
			get
			{
				CanReadProperty("NguyenTe", true);
				return _nguyenTe;
			}
			set
			{
				CanWriteProperty("NguyenTe", true);
				if (!_nguyenTe.Equals(value))
				{
					_nguyenTe = value;
                    if (_tyGia != 0)
                        _thanhTienVND = _nguyenTe * _tyGia;
					PropertyHasChanged("NguyenTe");
				}
			}
		}

		public int MaLoaiTien
		{
			get
			{
				CanReadProperty("MaLoaiTien", true);
				return _maLoaiTien;
			}
			set
			{
				CanWriteProperty("MaLoaiTien", true);
				if (!_maLoaiTien.Equals(value))
				{
					_maLoaiTien = value;
                    LoaiTien = LoaiTien.GetLoaiTien(_maLoaiTien);
					PropertyHasChanged("MaLoaiTien");
				}
			}
		}

		public decimal TyGia
		{
			get
			{
				CanReadProperty("TyGia", true);
				return _tyGia;
			}
			set
			{
				CanWriteProperty("TyGia", true);
				if (!_tyGia.Equals(value))
				{
					_tyGia = value;
                    if (_nguyenTe != 0)
                        _thanhTienVND = _nguyenTe * _tyGia;
					PropertyHasChanged("TyGia");
				}
			}
		}

		public decimal ThanhTienVND
		{
			get
			{
				CanReadProperty("ThanhTienVND", true);
				return _thanhTienVND;
			}
			set
			{
				CanWriteProperty("ThanhTienVND", true);
				if (!_thanhTienVND.Equals(value))
				{
					_thanhTienVND = value;
					PropertyHasChanged("ThanhTienVND");
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

        public LoaiTien LoaiTien
        {
            get
            {
                CanReadProperty("LoaiTien", true);
                return _loaiTien;
            }
            set
            {
                CanWriteProperty("LoaiTien", true);
                if (!_loaiTien.Equals(value))
                {
                    _loaiTien = value;
                    _tyGia = (decimal)_loaiTien.TiGiaQuyDoi;
                    if (_tyGia != 0)
                        _thanhTienVND = _tyGia * _nguyenTe;
                    PropertyHasChanged("LoaiTien");
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
			//TODO: Define authorization rules in CT_HopDongMuaBanNgoaiTe
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_HopDongMuaBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NguyenTe", "CT_HopDongMuaBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTien", "CT_HopDongMuaBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("TyGia", "CT_HopDongMuaBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("ThanhTienVND", "CT_HopDongMuaBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "CT_HopDongMuaBanNgoaiTeReadGroup");

			//AuthorizationRules.AllowWrite("NguyenTe", "CT_HopDongMuaBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTien", "CT_HopDongMuaBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("TyGia", "CT_HopDongMuaBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTienVND", "CT_HopDongMuaBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("MaHopDong", "CT_HopDongMuaBanNgoaiTeWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_HopDongMuaBanNgoaiTe NewCT_HopDongMuaBanNgoaiTe()
		{
			return new CT_HopDongMuaBanNgoaiTe();
		}

		internal static CT_HopDongMuaBanNgoaiTe GetCT_HopDongMuaBanNgoaiTe(SafeDataReader dr)
		{
			return new CT_HopDongMuaBanNgoaiTe(dr);
		}

		public CT_HopDongMuaBanNgoaiTe()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_HopDongMuaBanNgoaiTe(SafeDataReader dr)
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
			_nguyenTe = dr.GetDecimal("NguyenTe");
			_maLoaiTien = dr.GetInt32("MaLoaiTien");
			_tyGia = dr.GetDecimal("TyGia");
			_thanhTienVND = dr.GetDecimal("ThanhTienVND");
			_maHopDong = dr.GetInt64("MaHopDong");
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
                cm.CommandText = "spd_InserttblCT_HopDongMuaBanNgoaiTe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maHopDong = parent.MaHopDong;
			if (_nguyenTe != 0)
				cm.Parameters.AddWithValue("@NguyenTe", _nguyenTe);
			else
				cm.Parameters.AddWithValue("@NguyenTe", DBNull.Value);
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_thanhTienVND != 0)
				cm.Parameters.AddWithValue("@ThanhTienVND", _thanhTienVND);
			else
				cm.Parameters.AddWithValue("@ThanhTienVND", DBNull.Value);
			if (_maHopDong != 0)
				cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			else
				cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
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
				cm.CommandText = "UpdateCT_HopDongMuaBanNgoaiTe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HopDongMuaBan parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_nguyenTe != 0)
				cm.Parameters.AddWithValue("@NguyenTe", _nguyenTe);
			else
				cm.Parameters.AddWithValue("@NguyenTe", DBNull.Value);
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_thanhTienVND != 0)
				cm.Parameters.AddWithValue("@ThanhTienVND", _thanhTienVND);
			else
				cm.Parameters.AddWithValue("@ThanhTienVND", DBNull.Value);
			if (_maHopDong != 0)
				cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			else
				cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
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
				cm.CommandText = "DeleteCT_HopDongMuaBanNgoaiTe";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

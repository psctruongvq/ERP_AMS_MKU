
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_PhanBoChiPhiCCDC : Csla.BusinessBase<CT_PhanBoChiPhiCCDC>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private int _maPhanBo = 0;
		private int _maCongCuDungCu = 0;
		private decimal _phanTram = 0;
		private decimal _soTienPhanBo = 0;
        private string _tenHangHoa = string.Empty;
        private decimal _nguyenGia = 0;
        private decimal _chiPhiConLai = 0;
        private string _maQuanLy = string.Empty;
        private string _tenBoPhan = string.Empty;

        private decimal _GiaTriConLaiSauPhanBo = 0;
        private string _SoChungTu = string.Empty;
        private int _thoiGianPhanBo = 12;
        private SmartDate _NgayChungTu=new SmartDate(DateTime.MinValue);

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaPhanBo
		{
			get
			{
				CanReadProperty("MaPhanBo", true);
				return _maPhanBo;
			}
			set
			{
				CanWriteProperty("MaPhanBo", true);
				if (!_maPhanBo.Equals(value))
				{
					_maPhanBo = value;
					PropertyHasChanged("MaPhanBo");
				}
			}
		}

		public int MaCongCuDungCu
		{
			get
			{
				CanReadProperty("MaCongCuDungCu", true);
				return _maCongCuDungCu;
			}
			set
			{
				CanWriteProperty("MaCongCuDungCu", true);
				if (!_maCongCuDungCu.Equals(value))
				{
					_maCongCuDungCu = value;
					PropertyHasChanged("MaCongCuDungCu");
				}
			}
		}

		public decimal PhanTram
		{
			get
			{
				CanReadProperty("PhanTram", true);
				return _phanTram;
			}
			set
			{
				CanWriteProperty("PhanTram", true);
				if (!_phanTram.Equals(value))
				{
					_phanTram = value;
                    //_soTienPhanBo = Math.Round(_phanTram * _nguyenGia / 100);
					PropertyHasChanged("PhanTram");
				}
			}
		}

		public decimal SoTienPhanBo
		{
			get
			{
				CanReadProperty("SoTienPhanBo", true);
				return _soTienPhanBo;
			}
			set
			{
				CanWriteProperty("SoTienPhanBo", true);
				if (!_soTienPhanBo.Equals(value))
				{
					_soTienPhanBo = value;
                    _GiaTriConLaiSauPhanBo = _chiPhiConLai - _soTienPhanBo;
					PropertyHasChanged("SoTienPhanBo");
				}
			}
		}


        public decimal ChiPhiConLai
        {
            get
            {
                CanReadProperty("ChiPhiConLai", true);
                return _chiPhiConLai;
            }
            set
            {
                CanWriteProperty("ChiPhiConLai", true);
                if (!_chiPhiConLai.Equals(value))
                {
                    _chiPhiConLai = value;
                    _GiaTriConLaiSauPhanBo = _chiPhiConLai - _soTienPhanBo;
                    PropertyHasChanged("ChiPhiConLai");
                }
            }
        }

        public decimal GiaTriConLaiSauPhanBo
        {
            get
            {
                CanReadProperty("GiaTriConLaiSauPhanBo", true);
                return _GiaTriConLaiSauPhanBo;
            }
        }

        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                return _tenHangHoa;
            }
            
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }

        }

        public decimal NguyenGia
        {
            get
            {
                CanReadProperty("NguyenGia", true);
                return _nguyenGia;
            }

        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }

        }

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _SoChungTu;
            }
        }

        public DateTime? NgayChungTu
        {
            get
            {
                CanReadProperty("NgayChungTu", true);
                if (_NgayChungTu.Date == DateTime.MinValue)
                    return null;
                return _NgayChungTu.Date;
            }
        }

        public int ThoiGianPhanBo
        {
            get
            {
                CanReadProperty("ThoiGianPhanBo", true);
                return _thoiGianPhanBo;
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
			//TODO: Define authorization rules in CT_PhanBoChiPhiCCDC
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBo", "CT_PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("MaCongCuDungCu", "CT_PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("PhanTram", "CT_PhanBoChiPhiCCDCReadGroup");
			//AuthorizationRules.AllowRead("SoTienPhanBo", "CT_PhanBoChiPhiCCDCReadGroup");

			//AuthorizationRules.AllowWrite("MaPhanBo", "CT_PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongCuDungCu", "CT_PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTram", "CT_PhanBoChiPhiCCDCWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienPhanBo", "CT_PhanBoChiPhiCCDCWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_PhanBoChiPhiCCDC NewCT_PhanBoChiPhiCCDC()
		{
			return new CT_PhanBoChiPhiCCDC();
		}

		internal static CT_PhanBoChiPhiCCDC GetCT_PhanBoChiPhiCCDC(SafeDataReader dr, bool kieu)
		{
            return new CT_PhanBoChiPhiCCDC(dr, kieu);
		}

		private CT_PhanBoChiPhiCCDC()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_PhanBoChiPhiCCDC(SafeDataReader dr, bool kieu)
		{
			MarkAsChild();
			Fetch(dr, kieu);
		}
		#endregion //Factory Methods

		#region Data Access

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr, bool kieu)
		{
			FetchObject(dr);
            if (kieu == false)
                MarkNew();
			else MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maChiTiet = dr.GetInt64("MaChiTiet");
			_maPhanBo = dr.GetInt32("MaPhanBo");
			_maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
			_phanTram = dr.GetDecimal("PhanTram");
			_soTienPhanBo = dr.GetDecimal("SoTienPhanBo");
            _nguyenGia = dr.GetDecimal("NguyenGia");
            _tenHangHoa = dr.GetString("TenHangHoa");
            _chiPhiConLai = dr.GetDecimal("ChiPhiConLai");
            _maQuanLy= dr.GetString("MaQuanLy");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _thoiGianPhanBo = dr.GetInt32("ThoiGianPhanBo");
            _GiaTriConLaiSauPhanBo = _chiPhiConLai - _soTienPhanBo;

            _SoChungTu = dr.GetString("SoChungTu");
            _NgayChungTu = dr.GetSmartDate("NgayChungTu", _NgayChungTu.EmptyIsMin); ;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhanBoChiPhiCCDC parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhanBoChiPhiCCDC parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_PhanBoChiPhiCCDC";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhanBoChiPhiCCDC parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maPhanBo = parent.MaPhanBo;
			if (_maPhanBo != 0)
				cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
			else
				cm.Parameters.AddWithValue("@MaPhanBo", DBNull.Value);
			if (_maCongCuDungCu != 0)
				cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
			else
				cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
			if (_phanTram != 0)
				cm.Parameters.AddWithValue("@PhanTram", _phanTram);
			else
				cm.Parameters.AddWithValue("@PhanTram", DBNull.Value);
			if (_soTienPhanBo != 0)
				cm.Parameters.AddWithValue("@SoTienPhanBo", _soTienPhanBo);
			else
				cm.Parameters.AddWithValue("@SoTienPhanBo", DBNull.Value);
            cm.Parameters.AddWithValue("@ChiPhiConLai", _chiPhiConLai);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhanBoChiPhiCCDC parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhanBoChiPhiCCDC parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_PhanBoChiPhiCCDC";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhanBoChiPhiCCDC parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maPhanBo != 0)
				cm.Parameters.AddWithValue("@MaPhanBo", _maPhanBo);
			else
				cm.Parameters.AddWithValue("@MaPhanBo", DBNull.Value);
			if (_maCongCuDungCu != 0)
				cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
			else
				cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
			if (_phanTram != 0)
				cm.Parameters.AddWithValue("@PhanTram", _phanTram);
			else
				cm.Parameters.AddWithValue("@PhanTram", DBNull.Value);
			if (_soTienPhanBo != 0)
				cm.Parameters.AddWithValue("@SoTienPhanBo", _soTienPhanBo);
			else
				cm.Parameters.AddWithValue("@SoTienPhanBo", DBNull.Value);
            cm.Parameters.AddWithValue("@ChiPhiConLai", _chiPhiConLai);
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
                cm.CommandText = "spd_DeletetblCT_PhanBoChiPhiCCDC";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

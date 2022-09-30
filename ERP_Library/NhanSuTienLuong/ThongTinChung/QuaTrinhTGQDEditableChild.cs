
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhTGQD : Csla.BusinessBase<QuaTrinhTGQD>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactQuatrinhtgqd = 0;
		private long _maNhanVien = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
		private int _maQuanHam = 0;
		private int _maChucVu = 0;
		private string _donVi = string.Empty;
		private string _congViec = string.Empty;
		private long _maNguoiLap = 0;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _loai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactQuatrinhtgqd
		{
			get
			{
				CanReadProperty("MactQuatrinhtgqd", true);
				return _mactQuatrinhtgqd;
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged("TuNgay");
                }
            }
		}

		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
		}
		
		public int MaQuanHam
		{
			get
			{
				CanReadProperty("MaQuanHam", true);
				return _maQuanHam;
			}
			set
			{
				CanWriteProperty("MaQuanHam", true);
				if (!_maQuanHam.Equals(value))
				{
					_maQuanHam = value;
					PropertyHasChanged("MaQuanHam");
				}
			}
		}

		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
				return _maChucVu;
			}
			set
			{
				CanWriteProperty("MaChucVu", true);
				if (!_maChucVu.Equals(value))
				{
					_maChucVu = value;
					PropertyHasChanged("MaChucVu");
				}
			}
		}

		public string DonVi
		{
			get
			{
				CanReadProperty("DonVi", true);
				return _donVi;
			}
			set
			{
				CanWriteProperty("DonVi", true);
				if (value == null) value = string.Empty;
				if (!_donVi.Equals(value))
				{
					_donVi = value;
					PropertyHasChanged("DonVi");
				}
			}
		}

		public string CongViec
		{
			get
			{
				CanReadProperty("CongViec", true);
				return _congViec;
			}
			set
			{
				CanWriteProperty("CongViec", true);
				if (value == null) value = string.Empty;
				if (!_congViec.Equals(value))
				{
					_congViec = value;
					PropertyHasChanged("CongViec");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
               // _tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_maNguoiLap).TenDangNhap;
                return _tenNguoiLap;
            }
        }


		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}
		
		public string Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (value == null) value = string.Empty;
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _mactQuatrinhtgqd;
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
			// DonVi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DonVi", 200));
			//
			// CongViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongViec", 500));
			//
			// NgayLap
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
			//
			// Loai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Loai", 100));
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
			//TODO: Define authorization rules in QuaTrinhTGQD
			//AuthorizationRules.AllowRead("MactQuatrinhtgqd", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHam", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("DonVi", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("CongViec", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhTGQDReadGroup");
			//AuthorizationRules.AllowRead("Loai", "QuaTrinhTGQDReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHam", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("DonVi", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("CongViec", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhTGQDWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "QuaTrinhTGQDWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static QuaTrinhTGQD NewQuaTrinhTGQD()
		{
			return new QuaTrinhTGQD();
		}

		public static QuaTrinhTGQD GetQuaTrinhTGQD(SafeDataReader dr)
		{
			return new QuaTrinhTGQD(dr);
		}

		private QuaTrinhTGQD()
		{

			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private QuaTrinhTGQD(SafeDataReader dr)
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
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_mactQuatrinhtgqd = dr.GetInt32("MaCT_QuaTrinhTGQD");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_maQuanHam = dr.GetInt32("MaQuanHam");
			_maChucVu = dr.GetInt32("MaChucVu");
			_donVi = dr.GetString("DonVi");
			_congViec = dr.GetString("CongViec");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_loai = dr.GetString("Loai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuaTrinhTGQD";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_mactQuatrinhtgqd = (int)cm.Parameters["@MaCT_QuaTrinhTGQD"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_maQuanHam != 0)
				cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
			else
				cm.Parameters.AddWithValue("@MaQuanHam", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_donVi.Length > 0)
				cm.Parameters.AddWithValue("@DonVi", _donVi);
			else
				cm.Parameters.AddWithValue("@DonVi", DBNull.Value);
			if (_congViec.Length > 0)
				cm.Parameters.AddWithValue("@CongViec", _congViec);
			else
				cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_loai.Length > 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", _mactQuatrinhtgqd);
			cm.Parameters["@MaCT_QuaTrinhTGQD"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuaTrinhTGQD";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", _mactQuatrinhtgqd);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_maQuanHam != 0)
				cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
			else
				cm.Parameters.AddWithValue("@MaQuanHam", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_donVi.Length > 0)
				cm.Parameters.AddWithValue("@DonVi", _donVi);
			else
				cm.Parameters.AddWithValue("@DonVi", DBNull.Value);
			if (_congViec.Length > 0)
				cm.Parameters.AddWithValue("@CongViec", _congViec);
			else
				cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_loai.Length > 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhTGQD";

				cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", this._mactQuatrinhtgqd);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

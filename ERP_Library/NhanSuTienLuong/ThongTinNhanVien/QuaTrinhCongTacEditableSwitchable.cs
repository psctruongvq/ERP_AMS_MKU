
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhCongTac : Csla.BusinessBase<QuaTrinhCongTac>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuaTrinhCongTac = 0;
		private long _maNhanVien = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private string _coQuanCongTac = string.Empty;
        private string _chucVu = string.Empty;
		private string _diaChiCoQuan = string.Empty;
		private decimal _phuCap = 0;
		private int _lyDoNghiViec = 0;
		private string _chuThich = string.Empty;
		private long _maNguoiLap = 1;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuaTrinhCongTac
		{
			get
			{
				CanReadProperty("MaQuaTrinhCongTac", true);
				return _maQuaTrinhCongTac;
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

		public string CoQuanCongTac
		{
			get
			{
				CanReadProperty("CoQuanCongTac", true);
				return _coQuanCongTac;
			}
			set
			{
				CanWriteProperty("CoQuanCongTac", true);
                if (value == null) value = string.Empty;
				if (!_coQuanCongTac.Equals(value))
				{
					_coQuanCongTac = value;
					PropertyHasChanged("CoQuanCongTac");
				}
			}
		}

		public string ChucVu
		{
			get
			{
				CanReadProperty("ChucVu", true);
				return _chucVu;
			}
			set
			{
				CanWriteProperty("ChucVu", true);
                if (value == null) value = string.Empty;
				if (!_chucVu.Equals(value))
				{
					_chucVu = value;
					PropertyHasChanged("ChucVu");
				}
			}
		}

		public string DiaChiCoQuan
		{
			get
			{
				CanReadProperty("DiaChiCoQuan", true);
				return _diaChiCoQuan;
			}
			set
			{
				CanWriteProperty("DiaChiCoQuan", true);
				if (value == null) value = string.Empty;
				if (!_diaChiCoQuan.Equals(value))
				{
					_diaChiCoQuan = value;
					PropertyHasChanged("DiaChiCoQuan");
				}
			}
		}

		public decimal PhuCap
		{
			get
			{
				CanReadProperty("PhuCap", true);
				return _phuCap;
			}
			set
			{
				CanWriteProperty("PhuCap", true);
				if (!_phuCap.Equals(value))
				{
					_phuCap = value;
					PropertyHasChanged("PhuCap");
				}
			}
		}

		public int LyDoNghiViec
		{
			get
			{
				CanReadProperty("LyDoNghiViec", true);
				return _lyDoNghiViec;
			}
			set
			{
				CanWriteProperty("LyDoNghiViec", true);
				if (!_lyDoNghiViec.Equals(value))
				{
					_lyDoNghiViec = value;
					PropertyHasChanged("LyDoNghiViec");
				}
			}
		}

		public string ChuThich
		{
			get
			{
				CanReadProperty("ChuThich", true);
				return _chuThich;
			}
			set
			{
				CanWriteProperty("ChuThich", true);
				if (value == null) value = string.Empty;
				if (!_chuThich.Equals(value))
				{
					_chuThich = value;
					PropertyHasChanged("ChuThich");
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
                //_tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_maNguoiLap).TenDangNhap;
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
 
		protected override object GetIdValue()
		{
			return _maQuaTrinhCongTac;
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
			// DiaChiCoQuan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChiCoQuan", 500));
			//
			// ChuThich
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuThich", 4000));
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
			//TODO: Define authorization rules in QuaTrinhCongTac
			//AuthorizationRules.AllowRead("MaQuaTrinhCongTac", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("CoQuanCongTac", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("ChucVu", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("DiaChiCoQuan", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("PhuCap", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("LyDoNghiViec", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("ChuThich", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhCongTacReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhCongTacReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("CoQuanCongTac", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("ChucVu", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChiCoQuan", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("PhuCap", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("LyDoNghiViec", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("ChuThich", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhCongTacWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhCongTacWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhCongTac
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhCongTac
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhCongTac
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhCongTac
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhCongTacDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhCongTac()
		{ /* require use of factory method */ }

		public static QuaTrinhCongTac NewQuaTrinhCongTac()
		{
            QuaTrinhCongTac item = new QuaTrinhCongTac();
            item.MarkAsChild();
            return item;
		}

        public static QuaTrinhCongTac NewQuaTrinhCongTac(long maNhanVien)
        {
            QuaTrinhCongTac _QuaTrinhCongTac = new QuaTrinhCongTac();
            _QuaTrinhCongTac.MaNhanVien = maNhanVien;
            return _QuaTrinhCongTac;
        }

		public static QuaTrinhCongTac GetQuaTrinhCongTac(int maQuaTrinhCongTac)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhCongTac");
			return DataPortal.Fetch<QuaTrinhCongTac>(new Criteria(maQuaTrinhCongTac));
		}

		public static void DeleteQuaTrinhCongTac(int maQuaTrinhCongTac)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhCongTac");
			DataPortal.Delete(new Criteria(maQuaTrinhCongTac));
		}

		public override QuaTrinhCongTac Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhCongTac");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhCongTac");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhCongTac");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhCongTac NewQuaTrinhCongTacChild()
		{
			QuaTrinhCongTac child = new QuaTrinhCongTac();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhCongTac GetQuaTrinhCongTac(SafeDataReader dr)
		{
			QuaTrinhCongTac child =  new QuaTrinhCongTac();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaQuaTrinhCongTac;

			public Criteria(int maQuaTrinhCongTac)
			{
				this.MaQuaTrinhCongTac = maQuaTrinhCongTac;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsQuaTrinhCongTac";

				cm.Parameters.AddWithValue("@MaQuaTrinhCongTac", criteria.MaQuaTrinhCongTac);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maQuaTrinhCongTac));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsQuaTrinhCongTac";

				cm.Parameters.AddWithValue("@MaQuaTrinhCongTac", criteria.MaQuaTrinhCongTac);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

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
			_maQuaTrinhCongTac = dr.GetInt32("MaQuaTrinhCongTac");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_coQuanCongTac = dr.GetString("CoQuanCongTac");
			_chucVu = dr.GetString("ChucVu");
			_diaChiCoQuan = dr.GetString("DiaChiCoQuan");
			_phuCap = dr.GetDecimal("PhuCap");
			_lyDoNghiViec = dr.GetInt32("LyDoNghiViec");
			_chuThich = dr.GetString("ChuThich");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuaTrinhCongTac";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuaTrinhCongTac = (int)cm.Parameters["@MaQuaTrinhCongTac"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_coQuanCongTac.Length > 0)
				cm.Parameters.AddWithValue("@CoQuanCongTac", _coQuanCongTac);
            else
                cm.Parameters.AddWithValue("@CoQuanCongTac", DBNull.Value);
			if (_chucVu.Length > 0)
				cm.Parameters.AddWithValue("@ChucVu", _chucVu);
			else
                cm.Parameters.AddWithValue("@ChucVu", DBNull.Value);
			if (_diaChiCoQuan.Length > 0)
				cm.Parameters.AddWithValue("@DiaChiCoQuan", _diaChiCoQuan);
			else
				cm.Parameters.AddWithValue("@DiaChiCoQuan", DBNull.Value);
			cm.Parameters.AddWithValue("@PhuCap", _phuCap);
			cm.Parameters.AddWithValue("@LyDoNghiViec", _lyDoNghiViec);
			if (_chuThich.Length > 0)
				cm.Parameters.AddWithValue("@ChuThich", _chuThich);
			else
				cm.Parameters.AddWithValue("@ChuThich", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaQuaTrinhCongTac", _maQuaTrinhCongTac);
			cm.Parameters["@MaQuaTrinhCongTac"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuaTrinhCongTac";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuaTrinhCongTac", _maQuaTrinhCongTac);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_coQuanCongTac.Length > 0)
				cm.Parameters.AddWithValue("@CoQuanCongTac", _coQuanCongTac);
			else
				cm.Parameters.AddWithValue("@CoQuanCongTac", DBNull.Value);
			if (_chucVu.Length > 0)
				cm.Parameters.AddWithValue("@ChucVu", _chucVu);
			else
				cm.Parameters.AddWithValue("@ChucVu", DBNull.Value);
			if (_diaChiCoQuan.Length > 0)
				cm.Parameters.AddWithValue("@DiaChiCoQuan", _diaChiCoQuan);
			else
				cm.Parameters.AddWithValue("@DiaChiCoQuan", DBNull.Value);
			cm.Parameters.AddWithValue("@PhuCap", _phuCap);
			if (_lyDoNghiViec != 0)
				cm.Parameters.AddWithValue("@LyDoNghiViec", _lyDoNghiViec);
			else
				cm.Parameters.AddWithValue("@LyDoNghiViec", DBNull.Value);
			if (_chuThich.Length > 0)
				cm.Parameters.AddWithValue("@ChuThich", _chuThich);
			else
				cm.Parameters.AddWithValue("@ChuThich", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(tr, new Criteria(_maQuaTrinhCongTac));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

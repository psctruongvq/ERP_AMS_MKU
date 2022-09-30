
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThamGiaQuanDoi : Csla.BusinessBase<ThamGiaQuanDoi>
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
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _loai = string.Empty;
        private string _tenNguoiLap = string.Empty;

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
			//TODO: Define authorization rules in ThamGiaQuanDoi
			//AuthorizationRules.AllowRead("MactQuatrinhtgqd", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("MaQuanHam", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("DonVi", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("CongViec", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ThamGiaQuanDoiReadGroup");
			//AuthorizationRules.AllowRead("Loai", "ThamGiaQuanDoiReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanHam", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("DonVi", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("CongViec", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ThamGiaQuanDoiWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "ThamGiaQuanDoiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThamGiaQuanDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThamGiaQuanDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThamGiaQuanDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThamGiaQuanDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThamGiaQuanDoiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThamGiaQuanDoi()
		{ /* require use of factory method */ }

		public static ThamGiaQuanDoi NewThamGiaQuanDoi()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThamGiaQuanDoi");
			return DataPortal.Create<ThamGiaQuanDoi>();
		}

        public static ThamGiaQuanDoi NewThamGiaQuanDoi(long maNhanVien)
        {
            ThamGiaQuanDoi _ThamGiaQuanDoi = new ThamGiaQuanDoi();
            _ThamGiaQuanDoi.MaNhanVien = maNhanVien;
            return _ThamGiaQuanDoi;
        }

		public static ThamGiaQuanDoi GetThamGiaQuanDoi(int mactQuatrinhtgqd)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThamGiaQuanDoi");
			return DataPortal.Fetch<ThamGiaQuanDoi>(new Criteria(mactQuatrinhtgqd));
		}

		public static void DeleteThamGiaQuanDoi(int mactQuatrinhtgqd)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThamGiaQuanDoi");
			DataPortal.Delete(new Criteria(mactQuatrinhtgqd));
		}

		public override ThamGiaQuanDoi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThamGiaQuanDoi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThamGiaQuanDoi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThamGiaQuanDoi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThamGiaQuanDoi NewThamGiaQuanDoiChild()
		{
			ThamGiaQuanDoi child = new ThamGiaQuanDoi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThamGiaQuanDoi GetThamGiaQuanDoi(SafeDataReader dr)
		{
			ThamGiaQuanDoi child =  new ThamGiaQuanDoi();
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
			public int MactQuatrinhtgqd;

			public Criteria(int mactQuatrinhtgqd)
			{
				this.MactQuatrinhtgqd = mactQuatrinhtgqd;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhTGQD";

				cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", criteria.MactQuatrinhtgqd);

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
			DataPortal_Delete(new Criteria(_mactQuatrinhtgqd));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhTGQD";

				cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", criteria.MactQuatrinhtgqd);

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
                cm.CommandText = "spd_InserttblnsQuaTrinhTGQD";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactQuatrinhtgqd = (int)cm.Parameters["@MaCT_QuaTrinhTGQD"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
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
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblnsQuaTrinhTGQD";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCT_QuaTrinhTGQD", _mactQuatrinhtgqd);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
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
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_mactQuatrinhtgqd));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

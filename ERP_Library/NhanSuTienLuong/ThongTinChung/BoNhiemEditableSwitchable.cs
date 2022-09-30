
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoNhiem : Csla.BusinessBase<BoNhiem>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBoNhiem = 0;
		private long _maNhanVien = 0;
		private int _quyetDinh = 0;
		private int _maChucDanhMoi = 0;
		private int _maChucVuMoi = 0;
		private int _maChuyenMonNVMoi = 0;
		private string _soQuyetDinh = string.Empty;
		private SmartDate _ngayKy = new SmartDate(DateTime.Today);
		private SmartDate _ngayHieuLuc = new SmartDate(DateTime.Today);
		private long _nguoiKy = 0;
		private long _nguoiLap = 0;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaBoNhiem
		{
			get
			{
				CanReadProperty("MaBoNhiem", true);
				return _maBoNhiem;
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

		public int QuyetDinh
		{
			get
			{
				CanReadProperty("QuyetDinh", true);
				return _quyetDinh;
			}
			set
			{
				CanWriteProperty("QuyetDinh", true);
				if (!_quyetDinh.Equals(value))
				{
					_quyetDinh = value;
					PropertyHasChanged("QuyetDinh");
				}
			}
		}

		public int MaChucDanhMoi
		{
			get
			{
				CanReadProperty("MaChucDanhMoi", true);
				return _maChucDanhMoi;
			}
			set
			{
				CanWriteProperty("MaChucDanhMoi", true);
				if (!_maChucDanhMoi.Equals(value))
				{
					_maChucDanhMoi = value;
					PropertyHasChanged("MaChucDanhMoi");
				}
			}
		}

		public int MaChucVuMoi
		{
			get
			{
				CanReadProperty("MaChucVuMoi", true);
				return _maChucVuMoi;
			}
			set
			{
				CanWriteProperty("MaChucVuMoi", true);
				if (!_maChucVuMoi.Equals(value))
				{
					_maChucVuMoi = value;
					PropertyHasChanged("MaChucVuMoi");
				}
			}
		}

		public int MaChuyenMonNVMoi
		{
			get
			{
				CanReadProperty("MaChuyenMonNVMoi", true);
				return _maChuyenMonNVMoi;
			}
			set
			{
				CanWriteProperty("MaChuyenMonNVMoi", true);
				if (!_maChuyenMonNVMoi.Equals(value))
				{
					_maChuyenMonNVMoi = value;
					PropertyHasChanged("MaChuyenMonNVMoi");
				}
			}
		}

		public string SoQuyetDinh
		{
			get
			{
				CanReadProperty("SoQuyetDinh", true);
				return _soQuyetDinh;
			}
			set
			{
				CanWriteProperty("SoQuyetDinh", true);
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public DateTime NgayKy
		{
			get
			{
				CanReadProperty("NgayKy", true);
				return _ngayKy.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
		}		

		public DateTime NgayHieuLuc
		{
			get
			{
				CanReadProperty("NgayHieuLuc", true);
				return _ngayHieuLuc.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayHieuLuc.Equals(value))
                {
                    _ngayHieuLuc = new SmartDate(value);
                    PropertyHasChanged("NgayHieuLuc");
                }
            }
		}
		
		public long NguoiKy
		{
			get
			{
				CanReadProperty("NguoiKy", true);
				return _nguoiKy;
			}
			set
			{
				CanWriteProperty("NguoiKy", true);
				if (!_nguoiKy.Equals(value))
				{
					_nguoiKy = value;
					PropertyHasChanged("NguoiKy");
				}
			}
		}

		public long NguoiLap
		{
			get
			{
				CanReadProperty("NguoiLap", true);
				return _nguoiLap;
			}
			set
			{
				CanWriteProperty("NguoiLap", true);
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
                //_tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_nguoiLap).TenDangNhap;
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
			return _maBoNhiem;
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
			// SoQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
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
			//TODO: Define authorization rules in BoNhiem
			//AuthorizationRules.AllowRead("MaBoNhiem", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("QuyetDinh", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanhMoi", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuMoi", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNVMoi", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayKy", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayKyString", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLuc", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLucString", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "BoNhiemReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "BoNhiemReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("QuyetDinh", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanhMoi", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuMoi", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNVMoi", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("SoQuyetDinh", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKyString", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHieuLucString", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "BoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "BoNhiemWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoNhiemViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoNhiemAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoNhiemEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoNhiemDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoNhiem()
		{ /* require use of factory method */ }

		public static BoNhiem NewBoNhiem(int maBoNhiem)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoNhiem");
            return DataPortal.Create<BoNhiem>(new Criteria(maBoNhiem));
		}

        public static BoNhiem NewBoNhiem(long maNhanVien)
        {
            BoNhiem _BoNhiem = new BoNhiem();
            _BoNhiem.MaNhanVien = maNhanVien;
            return _BoNhiem;
        }

		public static BoNhiem GetBoNhiem(int maBoNhiem)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoNhiem");
			return DataPortal.Fetch<BoNhiem>(new Criteria(maBoNhiem));
		}

		public static void DeleteBoNhiem(int maBoNhiem)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoNhiem");
			DataPortal.Delete(new Criteria(maBoNhiem));
		}

		public override BoNhiem Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoNhiem");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoNhiem");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoNhiem");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BoNhiem(int maBoNhiem)
		{
			this._maBoNhiem = maBoNhiem;
		}

		internal static BoNhiem NewBoNhiemChild(int maBoNhiem)
		{
			BoNhiem child = new BoNhiem(maBoNhiem);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoNhiem GetBoNhiem(SafeDataReader dr)
		{
			BoNhiem child =  new BoNhiem();
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
			public int MaBoNhiem;

			public Criteria(int maBoNhiem)
			{
				this.MaBoNhiem = maBoNhiem;
			}
		}

        private class CriteriaAll
        {            

            public CriteriaAll()
            {                
            }
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maBoNhiem = criteria.MaBoNhiem;
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
				cm.CommandText = "spd_SelecttblnsBoNhiem";

				cm.Parameters.AddWithValue("@MaBoNhiem", criteria.MaBoNhiem);

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
			DataPortal_Delete(new Criteria(_maBoNhiem));
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
				cm.CommandText = "spd_DeletetblnsBoNhiem";

				cm.Parameters.AddWithValue("@MaBoNhiem", criteria.MaBoNhiem);

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
			_maBoNhiem = dr.GetInt32("MaBoNhiem");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_quyetDinh = dr.GetInt32("QuyetDinh");
			_maChucDanhMoi = dr.GetInt32("MaChucDanhMoi");
			_maChucVuMoi = dr.GetInt32("MaChucVuMoi");
			_maChuyenMonNVMoi = dr.GetInt32("MaChuyenMonNVMoi");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
			_ngayHieuLuc = dr.GetSmartDate("NgayHieuLuc", _ngayHieuLuc.EmptyIsMin);
			_nguoiKy = dr.GetInt64("NguoiKy");
			_nguoiLap = dr.GetInt64("NguoiLap");
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
				cm.CommandText = "spd_InserttblnsBoNhiem";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
               _maBoNhiem = (int)cm.Parameters["@MaBoNhiem"].Value; 

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBoNhiem", _maBoNhiem);
            cm.Parameters["@MaBoNhiem"].Direction =ParameterDirection.Output;
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_quyetDinh != 0)
				cm.Parameters.AddWithValue("@QuyetDinh", _quyetDinh);
			else
				cm.Parameters.AddWithValue("@QuyetDinh", DBNull.Value);
			if (_maChucDanhMoi != 0)
				cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
			else
				cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
			if (_maChucVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
			if (_maChuyenMonNVMoi != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNVMoi", _maChuyenMonNVMoi);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNVMoi", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
			cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
			if (_nguoiKy != 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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
				cm.CommandText = "spd_UpdatetblnsBoNhiem";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBoNhiem", _maBoNhiem);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_quyetDinh != 0)
				cm.Parameters.AddWithValue("@QuyetDinh", _quyetDinh);
			else
				cm.Parameters.AddWithValue("@QuyetDinh", DBNull.Value);
			if (_maChucDanhMoi != 0)
				cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
			else
				cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
			if (_maChucVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
			if (_maChuyenMonNVMoi != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNVMoi", _maChuyenMonNVMoi);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNVMoi", DBNull.Value);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
			cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
			if (_nguoiKy != 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maBoNhiem));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

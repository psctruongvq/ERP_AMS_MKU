
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThoiViec : Csla.BusinessBase<ThoiViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThoiViec = 0;
        private long _maNhanVien = 0;
        private string _maQlNhanvien = string.Empty;
		private int _maLoaiQuyetDinh = 0;
		private int _maLyDoThoiViec = 0;
		private string _soQuyetDinh = string.Empty;
        private SmartDate _ngayHieuLuc = new SmartDate(DateTime.Today.Date);
		private SmartDate _ngayKy = new SmartDate(DateTime.Today.Date);
        private long _nguoiKy = 0;
		private int _maChucVuNguoiKy = 0;
		private decimal _troCapThoiViec = 0;
		private decimal _troCapKhac = 0;
		private string _ghiChu = string.Empty;
		private long _maNguoiLap = 98;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private string _tenNhanVien = string.Empty;
        private string _tenLoaiQuyetDinh = string.Empty;
        private string _tenLyDoThoiViec = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaThoiViec
		{
			get
			{
				CanReadProperty("MaThoiViec", true);
				return _maThoiViec;
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

		public int MaLoaiQuyetDinh
		{
			get
			{
				CanReadProperty("MaLoaiQuyetDinh", true);
				return _maLoaiQuyetDinh;
			}
			set
			{
				CanWriteProperty("MaLoaiQuyetDinh", true);
				if (!_maLoaiQuyetDinh.Equals(value))
				{
					_maLoaiQuyetDinh = value;
					PropertyHasChanged("MaLoaiQuyetDinh");
				}
			}
		}

		public int MaLyDoThoiViec
		{
			get
			{
				CanReadProperty("MaLyDoThoiViec", true);
				return _maLyDoThoiViec;
			}
			set
			{
				CanWriteProperty("MaLyDoThoiViec", true);
				if (!_maLyDoThoiViec.Equals(value))
				{
					_maLyDoThoiViec = value;
					PropertyHasChanged("MaLyDoThoiViec");
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

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _maQlNhanvien;
            }           
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien.ToString();
            }
        }

        public string TenLoaiQuyetDinh
        {
            get
            {
                CanReadProperty("TenLoaiQuyetDinh", true);

                return LoaiQuyetDinh.GetLoaiQuyetDinh(_maLoaiQuyetDinh).TenLoaiQuyetDinh.ToString();
            }
        }

        public string TenLyDoThoiViec
        {
            get
            {
                CanReadProperty("TenLyDoThoiViec", true);
                return LyDoThoiViec.GetLyDoThoiViec(_maLyDoThoiViec).LyDo.ToString();
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

		public int MaChucVuNguoiKy
		{
			get
			{
				CanReadProperty("MaChucVuNguoiKy", true);
				return _maChucVuNguoiKy;
			}
			set
			{
				CanWriteProperty("MaChucVuNguoiKy", true);
				if (!_maChucVuNguoiKy.Equals(value))
				{
					_maChucVuNguoiKy = value;
					PropertyHasChanged("MaChucVuNguoiKy");
				}
			}
		}

		public decimal TroCapThoiViec
		{
			get
			{
				CanReadProperty("TroCapThoiViec", true);
				return _troCapThoiViec;
			}
			set
			{
				CanWriteProperty("TroCapThoiViec", true);
				if (!_troCapThoiViec.Equals(value))
				{
					_troCapThoiViec = value;
					PropertyHasChanged("TroCapThoiViec");
				}
			}
		}

		public decimal TroCapKhac
		{
			get
			{
				CanReadProperty("TroCapKhac", true);
				return _troCapKhac;
			}
			set
			{
				CanWriteProperty("TroCapKhac", true);
				if (!_troCapKhac.Equals(value))
				{
					_troCapKhac = value;
					PropertyHasChanged("TroCapKhac");
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
			return _maThoiViec;
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
			ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 20));
			//
			// NgayHieuLuc
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayHieuLucString");
			//
			// NgayKy
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayKyString");			
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
			//
			// NgayLap
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in ThoiViec
			//AuthorizationRules.AllowRead("MaThoiViec", "ThoiViecReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiQuyetDinh", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("MaLyDoThoiViec", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLuc", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayHieuLucString", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayKy", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayKyString", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuNguoiKy", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("TroCapThoiViec", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("TroCapKhac", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ThoiViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ThoiViecReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiQuyetDinh", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaLyDoThoiViec", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("SoQuyetDinh", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHieuLucString", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKyString", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuNguoiKy", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("TroCapThoiViec", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("TroCapKhac", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "ThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ThoiViecWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThoiViecDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThoiViec()
		{ /* require use of factory method */ }

		public static ThoiViec NewThoiViec()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThoiViec");
			return DataPortal.Create<ThoiViec>();
		}

        public static ThoiViec NewThoiViec(long MaNhanVien)
        {
            ThoiViec _ThoiViec = new ThoiViec();
            _ThoiViec.MaNhanVien = MaNhanVien;
            return _ThoiViec;
        }

		public static ThoiViec GetThoiViec(int maThoiViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThoiViec");
			return DataPortal.Fetch<ThoiViec>(new Criteria(maThoiViec));
		}

		public static void DeleteThoiViec(int maThoiViec)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThoiViec");
			DataPortal.Delete(new Criteria(maThoiViec));
		}

		public override ThoiViec Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThoiViec");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThoiViec");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThoiViec");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThoiViec NewThoiViecChild()
		{
			ThoiViec child = new ThoiViec();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThoiViec GetThoiViec(SafeDataReader dr)
		{
			ThoiViec child =  new ThoiViec();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static ThoiViec GetSoQuyetDinh(SafeDataReader dr)
        {
            ThoiViec child = new ThoiViec();
            child.SoQuyetDinh = dr.GetString("SoQuyetDinh");
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaThoiViec;

			public Criteria(int maThoiViec)
			{
				this.MaThoiViec = maThoiViec;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{			
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
                cm.CommandText = "spd_SelecttblnsTH_TV_ChamDutHDLD";

				cm.Parameters.AddWithValue("@MaThoiViec", criteria.MaThoiViec);

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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
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
			DataPortal_Delete(new Criteria(_maThoiViec));
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
                cm.CommandText = "spd_DeletetblnsTH_TV_ChamDutHDLD";

				cm.Parameters.AddWithValue("@MaThoiViec", criteria.MaThoiViec);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

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
			_maThoiViec = dr.GetInt32("MaThoiViec");
			_maLoaiQuyetDinh = dr.GetInt32("MaLoaiQuyetDinh");
			_maLyDoThoiViec = dr.GetInt32("MaLyDoThoiViec");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_ngayHieuLuc = dr.GetSmartDate("NgayHieuLuc", _ngayHieuLuc.EmptyIsMin);
			_ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
			_nguoiKy = dr.GetInt64("NguoiKy");
			_maChucVuNguoiKy = dr.GetInt32("MaChucVuNguoiKy");
			_troCapThoiViec = dr.GetDecimal("TroCapThoiViec");
			_troCapKhac = dr.GetDecimal("TroCapKhac");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			//_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maQlNhanvien = dr.GetString("MaQLNhanVien");
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
                cm.CommandText = "spd_InserttblnsTH_TV_ChamDutHDLD";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maThoiViec = (int)cm.Parameters["@MaThoiViec"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            cm.Parameters.AddWithValue("@MaLyDoThoiViec", _maLyDoThoiViec);
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            cm.Parameters.AddWithValue("@MaChucVuNguoiKy", _maChucVuNguoiKy);
            cm.Parameters.AddWithValue("@TroCapThoiViec", _troCapThoiViec);
            cm.Parameters.AddWithValue("@TroCapKhac", _troCapKhac);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaThoiViec", _maThoiViec);
            cm.Parameters.AddWithValue("@TinhTrang", 1);
			cm.Parameters["@MaThoiViec"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTH_TV_ChamDutHDLD";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaThoiViec", _maThoiViec);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaLoaiQuyetDinh", _maLoaiQuyetDinh);
            cm.Parameters.AddWithValue("@MaLyDoThoiViec", _maLyDoThoiViec);
            cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            cm.Parameters.AddWithValue("@NgayHieuLuc", _ngayHieuLuc.DBValue);
            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            cm.Parameters.AddWithValue("@MaChucVuNguoiKy", _maChucVuNguoiKy);
            cm.Parameters.AddWithValue("@TroCapThoiViec", _troCapThoiViec);
            cm.Parameters.AddWithValue("@TroCapKhac", _troCapKhac);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TinhTrang", 1);
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

			ExecuteDelete(tr, new Criteria(_maThoiViec));
			MarkNew();
		}
		#endregion //Data Access - Delete

        #region KiemTraSoHopDong

        public static int KiemTraSoQuyetDinh(string soQuyetDinh)
        {
            int giaTri = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoQuyetDinh";
                    cm.Parameters.AddWithValue("@SoQuyetDinh", soQuyetDinh);
                    cm.Parameters.AddWithValue("@GiaTri", giaTri);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    giaTri = (int)cm.Parameters["@GiaTri"].Value;
                }
            }//us

            return giaTri;
        }

        #endregion

		#endregion //Data Access
        public static void Thoiviec(long manhanvien, int MaloaiQD,int Malydo,string SoQD, DateTime NgayHL, DateTime Ngayky,long NguoiKy,int Machucvu,decimal TCThoiViec,decimal TCKhac,string Ghichu,long MaNguoiLap, DateTime NgayLap,int tinhtrang)
        {

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsThoiViecList";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@maloaiQD", MaloaiQD);
                    cm.Parameters.AddWithValue("@malydo", Malydo);
                    cm.Parameters.AddWithValue("@SoQd", SoQD);
                    cm.Parameters.AddWithValue("@NgayHL", NgayHL.Date);
                    cm.Parameters.AddWithValue("@Ngayky", Ngayky.Date);
                    cm.Parameters.AddWithValue("@Nguoiky", NguoiKy);
                    cm.Parameters.AddWithValue("@maChucvu", Machucvu);
                    cm.Parameters.AddWithValue("@TCThoiviec", TCThoiViec);
                    cm.Parameters.AddWithValue("@TCKhac", TCKhac);
                    cm.Parameters.AddWithValue("@Ghichu", Ghichu);
                    cm.Parameters.AddWithValue("@manguoilap", MaNguoiLap);
                    cm.Parameters.AddWithValue("@NgayLap", NgayLap.Date);
                    cm.Parameters.AddWithValue("@Tinhtrang", tinhtrang);  
                    cm.ExecuteNonQuery();

                    if (TTNhanVienRutGon.GetTTNhanVienRutGon(manhanvien).MaBoPhan == 26 && Security.CurrentUser.Info.MaBoPhan != 26 && Database.DatabaseNumber != 26)//HTVC
                    {
                        cm.Parameters.Clear();
                        cm.CommandType = CommandType.StoredProcedure;

                        cm.CommandText = "spd_InserttblnsThoiViecList_HTVC";
                        cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                        cm.Parameters.AddWithValue("@maloaiQD", MaloaiQD);
                        cm.Parameters.AddWithValue("@malydo", Malydo);
                        cm.Parameters.AddWithValue("@SoQd", SoQD);
                        cm.Parameters.AddWithValue("@NgayHL", NgayHL.Date);
                        cm.Parameters.AddWithValue("@Ngayky", Ngayky.Date);
                        cm.Parameters.AddWithValue("@Nguoiky", NguoiKy);
                        cm.Parameters.AddWithValue("@maChucvu", Machucvu);
                        cm.Parameters.AddWithValue("@TCThoiviec", TCThoiViec);
                        cm.Parameters.AddWithValue("@TCKhac", TCKhac);
                        cm.Parameters.AddWithValue("@Ghichu", Ghichu);
                        cm.Parameters.AddWithValue("@manguoilap", MaNguoiLap);
                        cm.Parameters.AddWithValue("@NgayLap", NgayLap.Date);
                        cm.Parameters.AddWithValue("@Tinhtrang", tinhtrang);  
                        cm.ExecuteNonQuery();
                    }
                    else if (TTNhanVienRutGon.GetTTNhanVienRutGon(manhanvien).MaBoPhan == 18 && Security.CurrentUser.Info.MaBoPhan != 18 && Database.DatabaseNumber != 18)//TTDV
                    {
                        cm.Parameters.Clear();
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblnsThoiViecList_TTDV";
                        cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                        cm.Parameters.AddWithValue("@maloaiQD", MaloaiQD);
                        cm.Parameters.AddWithValue("@malydo", Malydo);
                        cm.Parameters.AddWithValue("@SoQd", SoQD);
                        cm.Parameters.AddWithValue("@NgayHL", NgayHL.Date);
                        cm.Parameters.AddWithValue("@Ngayky", Ngayky.Date);
                        cm.Parameters.AddWithValue("@Nguoiky", NguoiKy);
                        cm.Parameters.AddWithValue("@maChucvu", Machucvu);
                        cm.Parameters.AddWithValue("@TCThoiviec", TCThoiViec);
                        cm.Parameters.AddWithValue("@TCKhac", TCKhac);
                        cm.Parameters.AddWithValue("@Ghichu", Ghichu);
                        cm.Parameters.AddWithValue("@manguoilap", MaNguoiLap);
                        cm.Parameters.AddWithValue("@NgayLap", NgayLap.Date);
                        cm.Parameters.AddWithValue("@Tinhtrang", tinhtrang);  
                        cm.ExecuteNonQuery();
                    }
                    else if (TTNhanVienRutGon.GetTTNhanVienRutGon(manhanvien).MaBoPhan == 22 && Security.CurrentUser.Info.MaBoPhan != 22 && Database.DatabaseNumber != 22)//TFS
                    {
                        cm.Parameters.Clear();
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblnsThoiViecList_TFS";
                        cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                        cm.Parameters.AddWithValue("@maloaiQD", MaloaiQD);
                        cm.Parameters.AddWithValue("@malydo", Malydo);
                        cm.Parameters.AddWithValue("@SoQd", SoQD);
                        cm.Parameters.AddWithValue("@NgayHL", NgayHL.Date);
                        cm.Parameters.AddWithValue("@Ngayky", Ngayky.Date);
                        cm.Parameters.AddWithValue("@Nguoiky", NguoiKy);
                        cm.Parameters.AddWithValue("@maChucvu", Machucvu);
                        cm.Parameters.AddWithValue("@TCThoiviec", TCThoiViec);
                        cm.Parameters.AddWithValue("@TCKhac", TCKhac);
                        cm.Parameters.AddWithValue("@Ghichu", Ghichu);
                        cm.Parameters.AddWithValue("@manguoilap", MaNguoiLap);
                        cm.Parameters.AddWithValue("@NgayLap", NgayLap.Date);
                        cm.Parameters.AddWithValue("@Tinhtrang", tinhtrang);  
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
     
        public static void PhucHoiNV(long manhanvien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsNhanVienPhucHoiNhanVienNghi";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.ExecuteNonQuery();
                }
            }
        }
        public static void PhucHoiNVResetNgayThamnien(long manhanvien,DateTime NgayVao, DateTime NgayThamNien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsNhanVienPhucHoiNhanVienNghiByNgayvao";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@NgayVaolam", NgayVao);
                    cm.Parameters.AddWithValue("@NgayTinhTN", NgayThamNien);
                    cm.ExecuteNonQuery();
                }
            }
        }
	}
}

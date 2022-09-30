
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyLuatTheoNhanVien : Csla.BusinessBase<KyLuatTheoNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKyLuat = 0;
		private long _maNhanVien = 0;
		private int _maHinhThucKyLuat = 0;
		private int _maCapQuyetDinh = 0;
		private string _soQuyetDinh = string.Empty;
		private SmartDate _ngayQuyetDinh = new SmartDate(DateTime.Today);
        private SmartDate _tGBDKyLuat = new SmartDate(DateTime.Today);
        private SmartDate _tGKTKyLuat = new SmartDate(DateTime.Today);
		private string _nguoiKy = string.Empty;
		private short _giamLuongDenHan = 0;
        private SmartDate _ngayLapQuyetDinh = new SmartDate(DateTime.Today);
		private long _maNguoiLap = 0;
		private string _ghiChu = string.Empty;
        
        private string _TenNhanVien = string.Empty;
        private string _MaQLNhanVien = string.Empty;
        
        private string _tenCapQuyetDinh = string.Empty;
        private string _TenHinhThucKyLuat= string.Empty;

        //----------------
        public string TenHinhThucKyLuat
        {
            get
            {
                CanReadProperty("TenHinhThucKyLuat", true);
                _TenHinhThucKyLuat = (HinhThucKyLuat.GetHinhThucKyLuat(_maHinhThucKyLuat)).TenKyLyat;
                return _TenHinhThucKyLuat;
            }
            set
            {
                CanWriteProperty("TenHinhThucKyLuat", true);
                if (value == null) value = string.Empty;
                if (!_TenHinhThucKyLuat.Equals(value))
                {
                    _TenHinhThucKyLuat = value;
                    PropertyHasChanged("TenHinhThucKyLuat");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                _TenNhanVien = (TenNV.GetTenNhanVien(_maNhanVien)).TenNhanVien;
                return _TenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_TenNhanVien.Equals(value))
                {
                    _TenNhanVien = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                _MaQLNhanVien = (TenNV.GetTenNhanVien(_maNhanVien)).MaQLNhanVien;
                return _MaQLNhanVien;
            }
            set
            {
                CanWriteProperty("MaQLNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_MaQLNhanVien.Equals(value))
                {
                    _MaQLNhanVien = value;
                    PropertyHasChanged("MaQLNhanVien");
                }
            }
        }        

        public string TenCapQuyetDinh
        {
            get
            {
                CanReadProperty("TenCapQuyetDinh", true);
                _tenCapQuyetDinh = CapQuyetDinh.GetCapQuyetDinh(_maCapQuyetDinh).TenCapQuyetDinh;
                return _tenCapQuyetDinh;
            }
            set
            {
                CanWriteProperty("TenCapQuyetDinh", true);
                if (value == null) value = string.Empty;
                if (!_tenCapQuyetDinh.Equals(value))
                {
                    _tenCapQuyetDinh = value;
                    PropertyHasChanged("TenCapQuyetDinh");
                }
            }
        }

        //----------------
		public int MaKyLuat
		{
			get
			{
				CanReadProperty("MaKyLuat", true);
				return _maKyLuat;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]

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

		public int MaHinhThucKyLuat
		{
			get
			{
				CanReadProperty("MaHinhThucKyLuat", true);
				return _maHinhThucKyLuat;
			}
			set
			{
				CanWriteProperty("MaHinhThucKyLuat", true);
				if (!_maHinhThucKyLuat.Equals(value))
				{
					_maHinhThucKyLuat = value;
					PropertyHasChanged("MaHinhThucKyLuat");
				}
			}
		}

		public int MaCapQuyetDinh
		{
			get
			{
				CanReadProperty("MaCapQuyetDinh", true);
				return _maCapQuyetDinh;
			}
			set
			{
				CanWriteProperty("MaCapQuyetDinh", true);
				if (!_maCapQuyetDinh.Equals(value))
				{
					_maCapQuyetDinh = value;
                    _tenCapQuyetDinh = CapQuyetDinh.GetCapQuyetDinh(_maCapQuyetDinh).TenCapQuyetDinh;
					PropertyHasChanged("MaCapQuyetDinh");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
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
                if (!_soQuyetDinh.Equals(value))
                {
                    _soQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
                }
            }
		}

		public DateTime NgayQuyetDinh
		{
			get
			{
				CanReadProperty("NgayQuyetDinh", true);
				return _ngayQuyetDinh.Date;
			}
            set
            {
                CanWriteProperty("NgayQuyetDinh", true);
                if (!_ngayQuyetDinh.Equals(value))
                {
                    _ngayQuyetDinh = new SmartDate(value);
                    PropertyHasChanged("NgayQuyetDinh");
                }
            }
		}
		
		public DateTime TGBDKyLuat
		{
			get
			{
				CanReadProperty("TGBDKyLuat", true);
				return _tGBDKyLuat.Date;
			}
            set
            {
                CanWriteProperty("TGBDKyLuat", true);
                if (!_tGBDKyLuat.Equals(value))
                {
                    _tGBDKyLuat = new SmartDate(value);
                    PropertyHasChanged("TGBDKyLuat");
                }
            }
		}
		
		public DateTime TGKTKyLuat
		{
			get
			{
				CanReadProperty("TGKTKyLuat", true);
				return _tGKTKyLuat.Date;
			}
            set
            {
                CanWriteProperty("TGKTKyLuat", true);
                if (!_tGKTKyLuat.Equals(value))
                {
                    _tGKTKyLuat = new SmartDate(value);
                    PropertyHasChanged("TGKTKyLuat");
                }
            }
		}
		
		public string NguoiKy
		{
			get
			{
				CanReadProperty("NguoiKy", true);
				return _nguoiKy;
			}
			set
			{
				CanWriteProperty("NguoiKy", true);
				if (value == null) value = string.Empty;
				if (!_nguoiKy.Equals(value))
				{
					_nguoiKy = value;
					PropertyHasChanged("NguoiKy");
				}
			}
		}

		public short GiamLuongDenHan
		{
			get
			{
				CanReadProperty("GiamLuongDenHan", true);
				return _giamLuongDenHan;
			}
			set
			{
				CanWriteProperty("GiamLuongDenHan", true);
				if (!_giamLuongDenHan.Equals(value))
				{
					_giamLuongDenHan = value;
					PropertyHasChanged("GiamLuongDenHan");
				}
			}
		}

		public DateTime NgayLapQuyetDinh
		{
			get
			{
				CanReadProperty("NgayLapQuyetDinh", true);
				return _ngayLapQuyetDinh.Date;
			}
            set
            {
                CanWriteProperty("NgayLapQuyetDinh", true);
                if (!_ngayLapQuyetDinh.Equals(value))
                {
                    _ngayLapQuyetDinh = new SmartDate(value);
                    PropertyHasChanged("NgayLapQuyetDinh");
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
			return string.Format("{0}:{1}", _maNhanVien, _soQuyetDinh);
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
            //ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinh");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
            ////
            //// NgayQuyetDinh
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayQuyetDinhString");
            ////
            //// NguoiKy
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 250));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1024));
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
			//TODO: Define authorization rules in KyLuatTheoNhanVien
			//AuthorizationRules.AllowRead("MaKyLuat", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucKyLuat", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaCapQuyetDinh", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoQuyetDinh", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayQuyetDinh", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayQuyetDinhString", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TGBDKyLuat", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TGBDKyLuatString", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TGKTKyLuat", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TGKTKyLuatString", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GiamLuongDenHan", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLapQuyetDinh", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLapQuyetDinhString", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "KyLuatTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "KyLuatTheoNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaHinhThucKyLuat", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaCapQuyetDinh", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayQuyetDinhString", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TGBDKyLuatString", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TGKTKyLuatString", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GiamLuongDenHan", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapQuyetDinhString", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "KyLuatTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "KyLuatTheoNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyLuatTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyLuatTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyLuatTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyLuatTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyLuatTheoNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyLuatTheoNhanVien()
		{ /* require use of factory method */ }

        public static KyLuatTheoNhanVien NewKyLuatTheoNhanVien(long maNhanVien)
        {
            KyLuatTheoNhanVien obj = new KyLuatTheoNhanVien();
            obj.MaNhanVien = maNhanVien;
            obj.MarkAsChild();
            return obj;
        }

		public static KyLuatTheoNhanVien NewKyLuatTheoNhanVien(long maNhanVien, string soQuyetDinh)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyLuatTheoNhanVien");
			return DataPortal.Create<KyLuatTheoNhanVien>(new Criteria(maNhanVien, soQuyetDinh));
		}

		public static KyLuatTheoNhanVien GetKyLuatTheoNhanVien(long maNhanVien, string soQuyetDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyLuatTheoNhanVien");
			return DataPortal.Fetch<KyLuatTheoNhanVien>(new Criteria(maNhanVien, soQuyetDinh));
		}
        public static int KiemTraNVKyLuat(long MaNhanVien, DateTime ngayKiemTra)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraNhanVienKyLuat";
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                   cm.Parameters.AddWithValue("@NgayKiemTra", ngayKiemTra);    
                    cm.Parameters.AddWithValue("@GiaTri", gt);
                    cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    gt = (int)cm.Parameters["@GiaTri"].Value;
                }

                return gt;
            }//using
        }
		public static void DeleteKyLuatTheoNhanVien(long maNhanVien, string soQuyetDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyLuatTheoNhanVien");
			DataPortal.Delete(new Criteria(maNhanVien, soQuyetDinh));
		}

		public override KyLuatTheoNhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyLuatTheoNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyLuatTheoNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KyLuatTheoNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        //private KyLuatTheoNhanVien(maNhanVien, soQuyetDinh)
        //{
        //    this._maNhanVien = maNhanVien;
        //    this._soQuyetDinh = soQuyetDinh;
        //}

		internal static KyLuatTheoNhanVien NewKyLuatTheoNhanVienChild(long maNhanVien, string soQuyetDinh)
		{
			KyLuatTheoNhanVien child = new KyLuatTheoNhanVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KyLuatTheoNhanVien GetKyLuatTheoNhanVien(SafeDataReader dr)
		{
			KyLuatTheoNhanVien child =  new KyLuatTheoNhanVien();
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
			public long MaNhanVien;
			public string SoQuyetDinh;

			public Criteria(long maNhanVien, string soQuyetDinh)
			{
				this.MaNhanVien = maNhanVien;
				this.SoQuyetDinh = soQuyetDinh;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
			_soQuyetDinh = criteria.SoQuyetDinh;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsKyLuatTungNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				cm.Parameters.AddWithValue("@SoQuyetDinh", criteria.SoQuyetDinh);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maNhanVien, _soQuyetDinh));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsKyLuatTungNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				cm.Parameters.AddWithValue("@SoQuyetDinh", criteria.SoQuyetDinh);

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
			_maKyLuat = dr.GetInt32("MaKyLuat");
			_maNhanVien = dr.GetInt64("MaNhanVien");
            _TenNhanVien = dr.GetString("Tennhanvien");
            _MaQLNhanVien = dr.GetString("maQLnhanvien");
			_maHinhThucKyLuat = dr.GetInt32("MaHinhThucKyLuat");
            _TenHinhThucKyLuat = HinhThucKyLuat.GetHinhThucKyLuat(_maHinhThucKyLuat).TenKyLyat;
			_maCapQuyetDinh = dr.GetInt32("MaCapQuyetDinh");
          //  _tenCapQuyetDinh = ChucVu.GetChucVu(_maCapQuyetDinh).TenChucVu;
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_ngayQuyetDinh = dr.GetSmartDate("NgayQuyetDinh", _ngayQuyetDinh.EmptyIsMin);
			_tGBDKyLuat = dr.GetSmartDate("TGBDKyLuat", _tGBDKyLuat.EmptyIsMin);
			_tGKTKyLuat = dr.GetSmartDate("TGKTKyLuat", _tGKTKyLuat.EmptyIsMin);
			_nguoiKy = dr.GetString("NguoiKy");
			_giamLuongDenHan = dr.GetInt16("GiamLuongDenHan");
			_ngayLapQuyetDinh = dr.GetSmartDate("NgayLapQuyetDinh", _ngayLapQuyetDinh.EmptyIsMin);
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsKyLuatTungNhanVien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKyLuat = (int)cm.Parameters["@MaKyLuat"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucKyLuat", _maHinhThucKyLuat);
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh.DBValue);
			cm.Parameters.AddWithValue("@TGBDKyLuat", _tGBDKyLuat.DBValue);
			cm.Parameters.AddWithValue("@TGKTKyLuat", _tGKTKyLuat.DBValue);
			if (_nguoiKy.Length > 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_giamLuongDenHan != 0)
				cm.Parameters.AddWithValue("@GiamLuongDenHan", _giamLuongDenHan);
			else
				cm.Parameters.AddWithValue("@GiamLuongDenHan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapQuyetDinh", _ngayLapQuyetDinh.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			cm.Parameters["@MaKyLuat"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsKyLuatTungNhanVien";

				AddUpdateParameters(cm);
                try
                {
                    cm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaHinhThucKyLuat", _maHinhThucKyLuat);
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh.DBValue);
			cm.Parameters.AddWithValue("@TGBDKyLuat", _tGBDKyLuat.DBValue);
			cm.Parameters.AddWithValue("@TGKTKyLuat", _tGKTKyLuat.DBValue);
			if (_nguoiKy.Length > 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_giamLuongDenHan != 0)
				cm.Parameters.AddWithValue("@GiamLuongDenHan", _giamLuongDenHan);
			else
				cm.Parameters.AddWithValue("@GiamLuongDenHan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapQuyetDinh", _ngayLapQuyetDinh.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maNhanVien, _soQuyetDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
        public static void QuyetDinh(long manhanvien, int Mahinhthuc,  string SoQD, int CapQD, DateTime NgayCapQD,DateTime TGBD,DateTime TGKT, string Nguoicap, string GhiChu, long manguoilap, DateTime Ngaylap)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsKyluatCanboList";
                    cm.Parameters.AddWithValue("@manhanvien", manhanvien);
                    cm.Parameters.AddWithValue("@Mahinhthuc", Mahinhthuc);
                    cm.Parameters.AddWithValue("@SoQD", SoQD);
                    cm.Parameters.AddWithValue("@CapQD", CapQD);
                    cm.Parameters.AddWithValue("@NgayCapQD", NgayCapQD);
                    cm.Parameters.AddWithValue("@TGBD", TGBD);
                    cm.Parameters.AddWithValue("@TGKT", TGKT);
                    cm.Parameters.AddWithValue("@NguoiCap", Nguoicap);
                    cm.Parameters.AddWithValue("@GhiChu", GhiChu);
                    cm.Parameters.AddWithValue("@manguoiLap", manguoilap);
                    cm.Parameters.AddWithValue("@Ngaylap", Ngaylap);
                    cm.ExecuteNonQuery();
                }
            }
        }
	}
}

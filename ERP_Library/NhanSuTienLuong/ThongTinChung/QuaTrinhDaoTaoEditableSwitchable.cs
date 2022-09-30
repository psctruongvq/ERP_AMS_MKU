
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhDaoTao : Csla.BusinessBase<QuaTrinhDaoTao>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuaTrinhDaoTao = 0;
		private long _maNhanVien = 0;
		private int _namTotNghiep = 0;
		private string _xepLoai = string.Empty;
		private SmartDate _ngayCap = new SmartDate(false);
		private bool _vanbangChungchi = false;
		private string _tenvanbangChungchi = string.Empty;
		private string _nguoiKy = string.Empty;
		private string _sovanbangChungchi = string.Empty;
		private string _ghiChu = string.Empty;
		private int _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _tenNhanVien = string.Empty;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private string _tenBoPhan = string.Empty;
        private bool _daNopBang = false;
        private int _maTruongDaoTao = 0;
        private bool _chuyenTTNhanVien = false;
		[System.ComponentModel.DataObjectField(true, true)]
        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                _tenNhanVien = TenNV.GetTenNhanVien(_maNhanVien).TenNhanVien;
                return _tenNhanVien;
            }
            set
            {
                CanWriteProperty("TenNhanVien", true);
                if (value == null) value = string.Empty;
                if (!_tenNhanVien.Equals(value))
                {
                    _xepLoai = value;
                    PropertyHasChanged("TenNhanVien");
                }
            }
        }

        public int MaQuaTrinhDaoTao
        {
            get
            {
                CanReadProperty("MaQuaTrinhDaoTao", true);
                return _maQuaTrinhDaoTao;
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
                    _tenBoPhan = TenNV.GetTenNhanVien(_maNhanVien).TenBoPhan;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }
        public string TenBoPhan
        {
            get
            {
                _tenBoPhan = TenNV.GetTenNhanVien(_maNhanVien).TenBoPhan;
                return _tenBoPhan;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }
        public int MaQuocGiaCap
        {
            get
            {
                CanReadProperty("MaQuocGiaCap", true);
                return _maQuocGiaCap;
            }
            set
            {
                CanWriteProperty("MaQuocGiaCap", true);
                if (!_maQuocGiaCap.Equals(value))
                {
                    _maQuocGiaCap = value;
                    PropertyHasChanged("MaQuocGiaCap");
                }
            }
        }
        public int MaTruongDaoTao
        {
            get
            {
                CanReadProperty("MaTruongDaoTao", true);
                return _maTruongDaoTao;
            }
            set
            {
                CanWriteProperty("MaTruongDaoTao", true);
                if (!_maTruongDaoTao.Equals(value))
                {
                    _maTruongDaoTao = value;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }

        public int NamTotNghiep
        {
            get
            {
                CanReadProperty("NamTotNghiep", true);
                return _namTotNghiep;
            }
            set
            {
                CanWriteProperty("NamTotNghiep", true);
                if (!_namTotNghiep.Equals(value))
                {
                    _namTotNghiep = value;
                    PropertyHasChanged("NamTotNghiep");
                }
            }
        }

        public string XepLoai
        {
            get
            {
                CanReadProperty("XepLoai", true);
                return _xepLoai;
            }
            set
            {
                CanWriteProperty("XepLoai", true);
                if (value == null) value = string.Empty;
                if (!_xepLoai.Equals(value))
                {
                    _xepLoai = value;
                    PropertyHasChanged("XepLoai");
                }
            }
        }

        public DateTime NgayCap
        {
            get
            {
                CanReadProperty("NgayCap", true);
                return _ngayCap.Date;
            }
            set
            {
                CanWriteProperty("NgayCap", true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = new SmartDate(value);
                    PropertyHasChanged("NgayCap");
                }
            }
        }

        public bool VanbangChungchi
        {
            get
            {
                CanReadProperty("VanbangChungchi", true);
                return _vanbangChungchi;
            }
            set
            {
                CanWriteProperty("VanbangChungchi", true);
                if (!_vanbangChungchi.Equals(value))
                {
                    _vanbangChungchi = value;
                    PropertyHasChanged("VanbangChungchi");
                }
            }
        }
          public bool DaNopBang
        {
            get
            {
                CanReadProperty("DaNopBang", true);
                return _daNopBang;
            }
            set
            {
                CanWriteProperty("DaNopBang", true);
                if (!_daNopBang.Equals(value))
                {
                    _daNopBang = value;
                    PropertyHasChanged("DaNopBang");
                }
            }
        }
        
        public string TenvanbangChungchi
        {
            get
            {
                CanReadProperty("TenvanbangChungchi", true);
                return _tenvanbangChungchi;
            }
            set
            {
                CanWriteProperty("TenvanbangChungchi", true);
                if (value == null) value = string.Empty;
                if (!_tenvanbangChungchi.Equals(value))
                {
                    _tenvanbangChungchi = value;
                    PropertyHasChanged("TenvanbangChungchi");
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

        public string SovanbangChungchi
        {
            get
            {
                CanReadProperty("SovanbangChungchi", true);
                return _sovanbangChungchi;
            }
            set
            {
                CanWriteProperty("SovanbangChungchi", true);
                if (value == null) value = string.Empty;
                if (!_sovanbangChungchi.Equals(value))
                {
                    _sovanbangChungchi = value;
                    PropertyHasChanged("SovanbangChungchi");
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

        public int MaNguoiLap
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
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }
        public int LoaiVanBang
        {
            get
            {
                CanReadProperty("LoaiVanBang", true);
                return _loaiVanBang;
            }
            set
            {
                CanWriteProperty("LoaiVanBang", true);
                if (!_loaiVanBang.Equals(value))
                {
                    _loaiVanBang = value;
                    PropertyHasChanged("LoaiVanBang");
                }
            }
        }

        public bool ChuyenTTNhanVien
        {
            get
            {
                CanReadProperty("ChuyenTTNhanVien", true);
                return _chuyenTTNhanVien;
            }
            set
            {
                CanWriteProperty("ChuyenTTNhanVien", true);
                if (!_chuyenTTNhanVien.Equals(value))
                {
                    _chuyenTTNhanVien = value;
                    PropertyHasChanged("ChuyenTTNhanVien");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maQuaTrinhDaoTao;
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
			// XepLoai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("XepLoai", 50));
			//
			// TenvanbangChungchi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenvanbangChungchi", 500));
			//
			// NguoiKy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 100));
			//
			// SovanbangChungchi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SovanbangChungchi", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
			//TODO: Define authorization rules in QuaTrinhDaoTaoMoi
			//AuthorizationRules.AllowRead("MaQuaTrinhDaoTao", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NamTotNghiep", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("XepLoai", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NgayCap", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NgayCapString", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("VanbangChungchi", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("TenvanbangChungchi", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NguoiKy", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("SovanbangChungchi", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhDaoTaoMoiReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhDaoTaoMoiReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("NamTotNghiep", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("XepLoai", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayCapString", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("VanbangChungchi", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("TenvanbangChungchi", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiKy", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("SovanbangChungchi", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhDaoTaoMoiWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhDaoTaoMoiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhDaoTaoMoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhDaoTaoMoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhDaoTaoMoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhDaoTaoMoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhDaoTaoMoiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhDaoTao()
		{ /* require use of factory method */ }

		public static QuaTrinhDaoTao NewQuaTrinhDaoTaoMoi()
		{
            QuaTrinhDaoTao item = new QuaTrinhDaoTao();
            item.MarkAsChild();
            return item;
		}

        public static QuaTrinhDaoTao NewQuaTrinhDaoTaoMoi(long maNV)
        {
            QuaTrinhDaoTao kq = new QuaTrinhDaoTao();
            kq.MaNhanVien = maNV;
            return kq;
        }

		public static QuaTrinhDaoTao GetQuaTrinhDaoTaoMoi(int maQuaTrinhDaoTao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhDaoTaoMoi");
			return DataPortal.Fetch<QuaTrinhDaoTao>(new Criteria(maQuaTrinhDaoTao));
		}

		public static void DeleteQuaTrinhDaoTaoMoi(int maQuaTrinhDaoTao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhDaoTaoMoi");
			DataPortal.Delete(new Criteria(maQuaTrinhDaoTao));
		}

		public override QuaTrinhDaoTao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhDaoTaoMoi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhDaoTaoMoi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhDaoTaoMoi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhDaoTao NewQuaTrinhDaoTaoMoiChild()
		{
			QuaTrinhDaoTao child = new QuaTrinhDaoTao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhDaoTao GetQuaTrinhDaoTaoMoi(SafeDataReader dr)
		{
			QuaTrinhDaoTao child =  new QuaTrinhDaoTao();
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
			public int MaQuaTrinhDaoTao;

			public Criteria(int maQuaTrinhDaoTao)
			{
				this.MaQuaTrinhDaoTao = maQuaTrinhDaoTao;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhDaoTao";

				cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", criteria.MaQuaTrinhDaoTao);

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
			DataPortal_Delete(new Criteria(_maQuaTrinhDaoTao));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhDaoTao";

				cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", criteria.MaQuaTrinhDaoTao);

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
			_maQuaTrinhDaoTao = dr.GetInt32("MaQuaTrinhDaoTao");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_namTotNghiep = dr.GetInt32("NamTotNghiep");
			_xepLoai = dr.GetString("XepLoai");
			_ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
			_vanbangChungchi = dr.GetBoolean("VanBang_ChungChi");
			_tenvanbangChungchi = dr.GetString("TenVanBang_ChungChi");
			_nguoiKy = dr.GetString("NguoiKy");
			_sovanbangChungchi = dr.GetString("SoVanBang_ChungChi");
			_ghiChu = dr.GetString("GhiChu");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _loaiVanBang = dr.GetInt32("LoaiVanBang");
            _maQuocGiaCap = dr.GetInt32("MaQuocGiaCap");
            _daNopBang = dr.GetBoolean("DaNopBang");
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            _chuyenTTNhanVien=dr.GetBoolean("ChuyenTTNhanVien");
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
                cm.CommandText = "spd_InserttblnsQuaTrinhDaoTao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuaTrinhDaoTao = (int)cm.Parameters["@MaQuaTrinhDaoTao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NamTotNghiep", _namTotNghiep);
			cm.Parameters.AddWithValue("@XepLoai", _xepLoai);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
			cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
			if (_tenvanbangChungchi.Length > 0)
				cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
			else
				cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
			if (_nguoiKy.Length > 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_sovanbangChungchi.Length > 0)
				cm.Parameters.AddWithValue("@SoVanBang_ChungChi", _sovanbangChungchi);
			else
				cm.Parameters.AddWithValue("@SoVanBang_ChungChi", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", _maQuaTrinhDaoTao);
            cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            cm.Parameters.AddWithValue("@DaNopBang",_daNopBang);
            cm.Parameters.AddWithValue("@ChuyenTTNhanVien", _chuyenTTNhanVien);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
			cm.Parameters["@MaQuaTrinhDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuaTrinhDaoTao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuaTrinhDaoTao", _maQuaTrinhDaoTao);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NamTotNghiep", _namTotNghiep);
			cm.Parameters.AddWithValue("@XepLoai", _xepLoai);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
			cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
			if (_tenvanbangChungchi.Length > 0)
				cm.Parameters.AddWithValue("@TenVanBang_ChungChi", _tenvanbangChungchi);
			else
				cm.Parameters.AddWithValue("@TenVanBang_ChungChi", DBNull.Value);
			if (_nguoiKy.Length > 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_sovanbangChungchi.Length > 0)
				cm.Parameters.AddWithValue("@SoVanBang_ChungChi", _sovanbangChungchi);
			else
				cm.Parameters.AddWithValue("@SoVanBang_ChungChi", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@DaNopBang", _daNopBang);
            cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            cm.Parameters.AddWithValue("@ChuyenTTNhanVien", _chuyenTTNhanVien);
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

			ExecuteDelete(cn, new Criteria(_maQuaTrinhDaoTao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

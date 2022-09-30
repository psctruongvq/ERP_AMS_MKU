
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhTrichNop : Csla.BusinessBase<QuaTrinhTrichNop>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuaTrinhTrichNop = 0;
		private long _maNhanVien = 0;
        private DateTime _ngayTrichNop = DateTime.Today;
		private int _maLoaiTrichNop = 0;
		private int _maHinhThucTrichNop = 0;
		private decimal _heSoTrichNopV1 = 0;
		private decimal _heSoTrichNopV2 = 0;
		private decimal _tongTien = 0;
		private string _dienGiai = string.Empty;
        private string _tenLoaiTrichNop = string.Empty;
        private string _tenHinhThucTrichNop = string.Empty;
		private int _maNguoiLap = 0;
        private string _tenNguoiLap = string.Empty;
		private DateTime _ngayLap = DateTime.Today;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuaTrinhTrichNop
		{
			get
			{
				CanReadProperty("MaQuaTrinhTrichNop", true);
				return _maQuaTrinhTrichNop;
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

		public DateTime NgayTrichNop
		{
			get
			{
				CanReadProperty("NgayTrichNop", true);
				return _ngayTrichNop.Date;
			}
            set
            {
                CanWriteProperty("NgayTrichNop", true);
                if (!_ngayTrichNop.Equals(value))
                {
                    _ngayTrichNop = value;
                    PropertyHasChanged("NgayTrichNop");
                }
            }
		}

		public int MaLoaiTrichNop
		{
			get
			{
				CanReadProperty("MaLoaiTrichNop", true);
				return _maLoaiTrichNop;
			}
			set
			{
				CanWriteProperty("MaLoaiTrichNop", true);
				if (!_maLoaiTrichNop.Equals(value))
				{
					_maLoaiTrichNop = value;
					PropertyHasChanged("MaLoaiTrichNop");
				}
			}
		}

        public string TenLoaiTrichNop
        {
            get
            {
                CanReadProperty("TenLoaiTrichNop", true);
                _tenLoaiTrichNop = (LoaiTrichNop.GetLoaiTrichNop(MaLoaiTrichNop)).TenLoaiTrichNop.ToString();
                return _tenLoaiTrichNop;
            }
        }

		public int MaHinhThucTrichNop
		{
			get
			{
				CanReadProperty("MaHinhThucTrichNop", true);
				return _maHinhThucTrichNop;
			}
			set
			{
				CanWriteProperty("MaHinhThucTrichNop", true);
				if (!_maHinhThucTrichNop.Equals(value))
				{
					_maHinhThucTrichNop = value;
					PropertyHasChanged("MaHinhThucTrichNop");
				}
			}
		}

        public string TenHinhThucTrichNop
        {
            get
            {
                CanReadProperty("TenHinhThucTrichNop", true);
                _tenHinhThucTrichNop = (HinhThucTrichNop.GetHinhThucTrichNop(MaHinhThucTrichNop)).TenHinhThuc.ToString();
                return _tenHinhThucTrichNop;
            }
        }

		public decimal HeSoTrichNopV1
		{
			get
			{
				CanReadProperty("HeSoTrichNopV1", true);
				return _heSoTrichNopV1;
			}
			set
			{
				CanWriteProperty("HeSoTrichNopV1", true);
				if (!_heSoTrichNopV1.Equals(value))
				{
					_heSoTrichNopV1 = value;
                    //_tongTien = (ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien)).LuongCB * _heSoTrichNopV1 + (ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien)).LuongKD * _heSoTrichNopV2;
                    PropertyHasChanged("HeSoTrichNopV1");
                    
				}
			}
		}


		public decimal HeSoTrichNopV2
		{
			get
			{
				CanReadProperty("HeSoTrichNopV2", true);
				return _heSoTrichNopV2;
			}
			set
			{
				CanWriteProperty("HeSoTrichNopV2", true);
				if (!_heSoTrichNopV2.Equals(value))
				{
					_heSoTrichNopV2 = value;
                    //_tongTien = (ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien)).LuongCB * _heSoTrichNopV1+(ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien)).LuongKD * _heSoTrichNopV2;
					PropertyHasChanged("HeSoTrichNopV2");
				}
			}
		}

		public decimal TongTien
		{
			get
			{
				CanReadProperty("TongTien", true);
				return _tongTien;
			}
			set
			{
				CanWriteProperty("TongTien", true);
				if (!_tongTien.Equals(value))
				{
                    _tongTien = value;
					PropertyHasChanged("TongTien");
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
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
		}

		protected override object GetIdValue()
		{
			return _maQuaTrinhTrichNop;
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

            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
			//
			// NgayLap
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in QuaTrinhTrichNop
			//AuthorizationRules.AllowRead("MaQuaTrinhTrichNop", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("NgayTrichNop", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("NgayTrichNopString", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTrichNop", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucTrichNop", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("HeSoTrichNopV1", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("HeSoTrichNopV2", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("TongTien", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhTrichNopReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhTrichNopReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTrichNopString", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTrichNop", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("MaHinhThucTrichNop", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoTrichNopV1", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoTrichNopV2", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("TongTien", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhTrichNopWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhTrichNopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhTrichNop()
		{ /* require use of factory method */ }

		public static QuaTrinhTrichNop NewQuaTrinhTrichNop()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhTrichNop");
			return DataPortal.Create<QuaTrinhTrichNop>();
		}

        public static QuaTrinhTrichNop NewQuaTrinhTrichNop(long maNhanVien)
        {
            QuaTrinhTrichNop _QuaTrinhTrichNop = new QuaTrinhTrichNop();
            _QuaTrinhTrichNop.MaNhanVien = maNhanVien;
            return _QuaTrinhTrichNop;
        }

		public static QuaTrinhTrichNop GetQuaTrinhTrichNop(int maQuaTrinhTrichNop)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhTrichNop");
			return DataPortal.Fetch<QuaTrinhTrichNop>(new Criteria(maQuaTrinhTrichNop));
		}

		public static void DeleteQuaTrinhTrichNop(int maQuaTrinhTrichNop)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhTrichNop");
			DataPortal.Delete(new Criteria(maQuaTrinhTrichNop));
		}

		public override QuaTrinhTrichNop Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhTrichNop");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhTrichNop");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhTrichNop");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhTrichNop NewQuaTrinhTrichNopChild()
		{
			QuaTrinhTrichNop child = new QuaTrinhTrichNop();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhTrichNop GetQuaTrinhTrichNop(SafeDataReader dr)
		{
			QuaTrinhTrichNop child =  new QuaTrinhTrichNop();
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
			public int MaQuaTrinhTrichNop;

			public Criteria(int maQuaTrinhTrichNop)
			{
				this.MaQuaTrinhTrichNop = maQuaTrinhTrichNop;
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhTrichNop";

				cm.Parameters.AddWithValue("@MaQuaTrinhTrichNop", criteria.MaQuaTrinhTrichNop);

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

				ExecuteInsert(cn, null);

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
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maQuaTrinhTrichNop));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhTrichNop";

				cm.Parameters.AddWithValue("@MaQuaTrinhTrichNop", criteria.MaQuaTrinhTrichNop);

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
			_maQuaTrinhTrichNop = dr.GetInt32("MaQuaTrinhTrichNop");
			_maNhanVien = dr.GetInt64("MaNhanVien");
            _ngayTrichNop = dr.GetDateTime("NgayTrichNop");
			_maLoaiTrichNop = dr.GetInt32("MaLoaiTrichNop");
			_maHinhThucTrichNop = dr.GetInt32("MaHinhThucTrichNop");
			_heSoTrichNopV1 = dr.GetDecimal("HeSoTrichNopV1");
			_heSoTrichNopV2 = dr.GetDecimal("HeSoTrichNopV2");
			_tongTien = dr.GetDecimal("TongTien");
			_dienGiai = dr.GetString("DienGiai");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, QuaTrinhTrichNopList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, QuaTrinhTrichNopList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuaTrinhTrichNop";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuaTrinhTrichNop = (int)cm.Parameters["@MaQuaTrinhTrichNop"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuaTrinhTrichNopList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent

            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayTrichNop", _ngayTrichNop.ToShortDateString());
			cm.Parameters.AddWithValue("@MaLoaiTrichNop", _maLoaiTrichNop);
			cm.Parameters.AddWithValue("@MaHinhThucTrichNop", _maHinhThucTrichNop);
			cm.Parameters.AddWithValue("@HeSoTrichNopV1", _heSoTrichNopV1);
			cm.Parameters.AddWithValue("@HeSoTrichNopV2", _heSoTrichNopV2);
			cm.Parameters.AddWithValue("@TongTien", _tongTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.ToShortDateString());
			cm.Parameters.AddWithValue("@MaQuaTrinhTrichNop", _maQuaTrinhTrichNop);
			cm.Parameters["@MaQuaTrinhTrichNop"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, QuaTrinhTrichNopList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, QuaTrinhTrichNopList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuaTrinhTrichNop";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuaTrinhTrichNopList parent)
		{
			cm.Parameters.AddWithValue("@MaQuaTrinhTrichNop", _maQuaTrinhTrichNop);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayTrichNop", _ngayTrichNop.ToShortDateString());
			cm.Parameters.AddWithValue("@MaLoaiTrichNop", _maLoaiTrichNop);
			cm.Parameters.AddWithValue("@MaHinhThucTrichNop", _maHinhThucTrichNop);
			cm.Parameters.AddWithValue("@HeSoTrichNopV1", _heSoTrichNopV1);
			cm.Parameters.AddWithValue("@HeSoTrichNopV2", _heSoTrichNopV2);
			cm.Parameters.AddWithValue("@TongTien", _tongTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.ToShortDateString());
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

			ExecuteDelete(cn, new Criteria(_maQuaTrinhTrichNop));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

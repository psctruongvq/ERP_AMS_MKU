
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GiayBanNgoaiTe : Csla.BusinessBase<GiayBanNgoaiTe>
	{
		#region Business Properties and Methods
        //ok
		//declare members
		private long _maPhieu = 0;
		private string _soDeNghi = string.Empty;
		private int _nganHangMua = 0;
		private int _nganHangBan = 0;
		private string _tieuDe = string.Empty;
		private decimal _soTien = 0;
		private int _loaiTien = 0;
		private int _mucDichThanhToan = 0;
		private string _soKheUoc = string.Empty;
		private DateTime _ngaySoSach = new DateTime();
		private string _soTienBangChu = string.Empty;
		private decimal _tyGia = 0;
		private DateTime _ngayLap = DateTime.Now.Date;
		private int _userID = 0;
		private SmartDate _ngaySua = new SmartDate(false);
		private string _loaiMatHang = string.Empty;
        private DateTime? _ngayXacNhan = null;

        //-----Child Object
        DeNghi_GiayBanNgoaiTeList _deNghi_GiayBanNgoaiTeList = DeNghi_GiayBanNgoaiTeList.NewDeNghi_GiayBanNgoaiTeList();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaPhieu
		{
			get
			{
				CanReadProperty("MaPhieu", true);
				return _maPhieu;
			}
		}

		public string SoDeNghi
		{
			get
			{
				CanReadProperty("SoDeNghi", true);
				return _soDeNghi;
			}
			set
			{
				CanWriteProperty("SoDeNghi", true);
				if (value == null) value = string.Empty;
				if (!_soDeNghi.Equals(value))
				{
					_soDeNghi = value;
					PropertyHasChanged("SoDeNghi");
				}
			}
		}

		public int NganHangMua
		{
			get
			{
                CanReadProperty("NganHangMua", true);
				return _nganHangMua;
			}
			set
			{
                CanWriteProperty("NganHangMua", true);
				if (!_nganHangMua.Equals(value))
				{
					_nganHangMua = value;
                    PropertyHasChanged("NganHangMua");
				}
			}
		}

		public int NganHangBan
		{
			get
			{
				CanReadProperty("NganHangBan", true);
				return _nganHangBan;
			}
			set
			{
				CanWriteProperty("NganHangBan", true);
				if (!_nganHangBan.Equals(value))
				{
					_nganHangBan = value;
					PropertyHasChanged("NganHangBan");
				}
			}
		}

        public DateTime? NgayXacNhan
        {
            get
            {
                CanReadProperty("NgayXacNhan", true);
                if (_ngayXacNhan == DateTime.MinValue)
                {
                    _ngayXacNhan = null;
                }
                return _ngayXacNhan;
            }
            set
            {
                CanWriteProperty("NgayXacNhan", true);
                if (!_ngayXacNhan.Equals(value))
                {
                    if (value == null)
                        _ngayXacNhan = null;
                    else if (value != DateTime.MinValue & value != DateTime.MaxValue & ((DateTime)value).Year != 1753)
                    {
                        _ngayXacNhan = value;
                        PropertyHasChanged("NgayXacNhan");
                    }
                    PropertyHasChanged("NgayXacNhan");
                }
            }
        }

		public string TieuDe
		{
			get
			{
				CanReadProperty("TieuDe", true);
                if (_tieuDe == string.Empty)
                    _tieuDe = "BP. KINH DOANH TIỀN TỆ - P. DỊCH VỤ KH DOANH NGHIỆP SGD1";
				return _tieuDe;
			}
			set
			{
				CanWriteProperty("TieuDe", true);
                if (value == null || value == string.Empty) 
                    value = "BP. KINH DOANH TIỀN TỆ - P. DỊCH VỤ KH DOANH NGHIỆP SGD1";
				if (!_tieuDe.Equals(value))
				{
					_tieuDe = value;
					PropertyHasChanged("TieuDe");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public int LoaiTien
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
					PropertyHasChanged("LoaiTien");
				}
			}
		}

		public int MucDichThanhToan
		{
			get
			{
				CanReadProperty("MucDichThanhToan", true);
				return _mucDichThanhToan;
			}
			set
			{
				CanWriteProperty("MucDichThanhToan", true);
				if (!_mucDichThanhToan.Equals(value))
				{
					_mucDichThanhToan = value;
					PropertyHasChanged("MucDichThanhToan");
				}
			}
		}

		public string SoKheUoc
		{
			get
			{
				CanReadProperty("SoKheUoc", true);
				return _soKheUoc;
			}
			set
			{
				CanWriteProperty("SoKheUoc", true);
				if (value == null) value = string.Empty;
				if (!_soKheUoc.Equals(value))
				{
					_soKheUoc = value;
					PropertyHasChanged("SoKheUoc");
				}
			}
		}

		public DateTime NgaySoSach
		{
			get
			{
				CanReadProperty("NgaySoSach", true);
				return _ngaySoSach.Date;
			}
            set
            {
                CanWriteProperty("NgaySoSach", true);
                if (!_ngaySoSach.Equals(value))
                {
                    _ngaySoSach = value;
                    PropertyHasChanged("NgaySoSach");
                }
            }
		}

        public string SoTienBangChu
		{
			get
			{
				CanReadProperty("SoTienBangChu", true);
				return _soTienBangChu;
			}
			set
			{
				CanWriteProperty("SoTienBangChu", true);
				if (value == null) value = string.Empty;
				if (!_soTienBangChu.Equals(value))
				{
					_soTienBangChu = value;
					PropertyHasChanged("SoTienBangChu");
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
					PropertyHasChanged("TyGia");
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
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
		}

		public int UserID
		{
			get
			{
				CanReadProperty("UserID", true);
				return _userID;
			}
			set
			{
				CanWriteProperty("UserID", true);
				if (!_userID.Equals(value))
				{
					_userID = value;
					PropertyHasChanged("UserID");
				}
			}
		}

		public DateTime NgaySua
		{
			get
			{
				CanReadProperty("NgaySua", true);
				return _ngaySua.Date;
			}
		}

		public string NgaySuaString
		{
			get
			{
				CanReadProperty("NgaySuaString", true);
				return _ngaySua.Text;
			}
			set
			{
				CanWriteProperty("NgaySuaString", true);
				if (value == null) value = string.Empty;
				if (!_ngaySua.Equals(value))
				{
					_ngaySua.Text = value;
					PropertyHasChanged("NgaySuaString");
				}
			}
		}

		public string LoaiMatHang
		{
			get
			{
				CanReadProperty("LoaiMatHang", true);
				return _loaiMatHang;
			}
			set
			{
				CanWriteProperty("LoaiMatHang", true);
				if (value == null) value = string.Empty;
				if (!_loaiMatHang.Equals(value))
				{
					_loaiMatHang = value;
					PropertyHasChanged("LoaiMatHang");
				}
			}
		}

        public DeNghi_GiayBanNgoaiTeList DeNghi_GiayBanNTList
        {
            get
            {
                CanReadProperty("DeNghi_GiayBanNTList", true);
                return _deNghi_GiayBanNgoaiTeList;
            }
            set
            {
                CanWriteProperty("DeNghi_GiayBanNTList", true);
                if (!_deNghi_GiayBanNgoaiTeList.Equals(value))
                {
                    _deNghi_GiayBanNgoaiTeList = value;
                    PropertyHasChanged("DeNghi_GiayBanNTList");
                }
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _deNghi_GiayBanNgoaiTeList.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _deNghi_GiayBanNgoaiTeList.IsDirty; }
        }
 
		protected override object GetIdValue()
		{
			return _maPhieu;
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
			// SoDeNghi
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoDeNghi", 50));
            ////
            //// SoKheUoc
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoKheUoc", 200));
            ////
            //// LoaiMatHang
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiMatHang", 500));
		}

		protected override void AddBusinessRules()
		{
            //AddCommonRules();
            //AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in GiayBanNgoaiTe
			//AuthorizationRules.AllowRead("MaPhieu", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("SoDeNghi", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("GiayBanNgoaiTe", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NganHangBan", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("TieuDe", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("LoaiTien", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("MucDichThanhToan", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("SoKheUoc", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgaySoSach", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgaySoSachString", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("SoTienBangChu", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("TyGia", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("UserID", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgaySua", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("NgaySuaString", "GiayBanNgoaiTeReadGroup");
			//AuthorizationRules.AllowRead("LoaiMatHang", "GiayBanNgoaiTeReadGroup");

			//AuthorizationRules.AllowWrite("SoDeNghi", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("GiayBanNgoaiTe", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("NganHangBan", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("TieuDe", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiTien", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("MucDichThanhToan", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("SoKheUoc", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySoSachString", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienBangChu", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("TyGia", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("UserID", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySuaString", "GiayBanNgoaiTeWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiMatHang", "GiayBanNgoaiTeWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GiayBanNgoaiTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GiayBanNgoaiTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GiayBanNgoaiTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GiayBanNgoaiTe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiayBanNgoaiTeDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GiayBanNgoaiTe()
		{ 
            /* require use of factory method */
            MarkAsChild();
        }

		public static GiayBanNgoaiTe NewGiayBanNgoaiTe()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayBanNgoaiTe");
			return DataPortal.Create<GiayBanNgoaiTe>();
		}

		public static GiayBanNgoaiTe GetGiayBanNgoaiTe(long maPhieu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GiayBanNgoaiTe");
			return DataPortal.Fetch<GiayBanNgoaiTe>(new Criteria(maPhieu));
		}

		public static void DeleteGiayBanNgoaiTe(long maPhieu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayBanNgoaiTe");
			DataPortal.Delete(new Criteria(maPhieu));
		}

		public override GiayBanNgoaiTe Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiayBanNgoaiTe");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiayBanNgoaiTe");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a GiayBanNgoaiTe");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static GiayBanNgoaiTe NewGiayBanNgoaiTeChild()
		{
			GiayBanNgoaiTe child = new GiayBanNgoaiTe();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static GiayBanNgoaiTe GetGiayBanNgoaiTe(SafeDataReader dr)
		{
			GiayBanNgoaiTe child =  new GiayBanNgoaiTe();
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
			public long MaPhieu;

			public Criteria(long maPhieu)
			{
				this.MaPhieu = maPhieu;
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
                cm.CommandText = "spd_SelecttblGiayBanNgoaiTe";

				cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maPhieu));
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
                cm.CommandText = "spd_DeletetblGiayBanNgoaiTe";

				cm.Parameters.AddWithValue("@MaPhieu", criteria.MaPhieu);

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
			_maPhieu = dr.GetInt64("MaPhieu");
			_soDeNghi = dr.GetString("SoDeNghi");
			_nganHangMua = dr.GetInt32("NganHangMua");
			_nganHangBan = dr.GetInt32("NganHangBan");
			_tieuDe = dr.GetString("TieuDe");
			_soTien = dr.GetDecimal("SoTien");
			_loaiTien = dr.GetInt32("LoaiTien");
			_mucDichThanhToan = dr.GetInt32("MucDichThanhToan");
			_soKheUoc = dr.GetString("SoKheUoc");
            _ngaySoSach = dr.GetDateTime("NgaySoSach");
			_soTienBangChu = dr.GetString("SoTienBangChu");
			_tyGia = dr.GetDecimal("TyGia");
			_ngayLap = dr.GetDateTime("NgayLap");
			_userID = dr.GetInt32("UserID");
			_ngaySua = dr.GetSmartDate("NgaySua", _ngaySua.EmptyIsMin);
			_loaiMatHang = dr.GetString("LoaiMatHang");
            _ngayXacNhan = dr.GetDateTime("NgayXacNhan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _deNghi_GiayBanNgoaiTeList = DeNghi_GiayBanNgoaiTeList.GetDeNghi_GiayBanNgoaiTeList(_maPhieu);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, GiayBanNgoaiTeList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, GiayBanNgoaiTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblGiayBanNgoaiTe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhieu = (long)cm.Parameters["@MaPhieu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, GiayBanNgoaiTeList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soDeNghi.Length > 0)
				cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
			else
				cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
			if (_nganHangMua != 0)
                cm.Parameters.AddWithValue("@NganHangMua", _nganHangMua);
			else
                cm.Parameters.AddWithValue("@NganHangMua", DBNull.Value);
			if (_nganHangBan != 0)
				cm.Parameters.AddWithValue("@NganHangBan", _nganHangBan);
			else
				cm.Parameters.AddWithValue("@NganHangBan", DBNull.Value);
			if (_tieuDe.Length > 0)
				cm.Parameters.AddWithValue("@TieuDe", _tieuDe);
			else
				cm.Parameters.AddWithValue("@TieuDe", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_loaiTien != 0)
				cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
			else
				cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
			if (_mucDichThanhToan != 0)
				cm.Parameters.AddWithValue("@MucDichThanhToan", _mucDichThanhToan);
			else
				cm.Parameters.AddWithValue("@MucDichThanhToan", DBNull.Value);
			if (_soKheUoc.Length > 0)
				cm.Parameters.AddWithValue("@SoKheUoc", _soKheUoc);
			else
				cm.Parameters.AddWithValue("@SoKheUoc", DBNull.Value);
            if (_ngaySoSach != DateTime.MinValue)
			    cm.Parameters.AddWithValue("@NgaySoSach", _ngaySoSach);
            else
                cm.Parameters.AddWithValue("@NgaySoSach", DBNull.Value);
			if (_soTienBangChu.Length > 0)
				cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
			else
				cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgaySua", DateTime.Now);
			if (_loaiMatHang.Length > 0)
				cm.Parameters.AddWithValue("@LoaiMatHang", _loaiMatHang);
			else
				cm.Parameters.AddWithValue("@LoaiMatHang", DBNull.Value);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
			cm.Parameters["@MaPhieu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, GiayBanNgoaiTeList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, GiayBanNgoaiTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblGiayBanNgoaiTe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, GiayBanNgoaiTeList parent)
		{
			cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
			if (_soDeNghi.Length > 0)
				cm.Parameters.AddWithValue("@SoDeNghi", _soDeNghi);
			else
				cm.Parameters.AddWithValue("@SoDeNghi", DBNull.Value);
			if (_nganHangMua != 0)
                cm.Parameters.AddWithValue("@NganHangMua", _nganHangMua);
			else
                cm.Parameters.AddWithValue("@NganHangMua", DBNull.Value);
			if (_nganHangBan != 0)
				cm.Parameters.AddWithValue("@NganHangBan", _nganHangBan);
			else
				cm.Parameters.AddWithValue("@NganHangBan", DBNull.Value);
			if (_tieuDe.Length > 0)
				cm.Parameters.AddWithValue("@TieuDe", _tieuDe);
			else
				cm.Parameters.AddWithValue("@TieuDe", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_loaiTien != 0)
				cm.Parameters.AddWithValue("@LoaiTien", _loaiTien);
			else
				cm.Parameters.AddWithValue("@LoaiTien", DBNull.Value);
			if (_mucDichThanhToan != 0)
				cm.Parameters.AddWithValue("@MucDichThanhToan", _mucDichThanhToan);
			else
				cm.Parameters.AddWithValue("@MucDichThanhToan", DBNull.Value);
			if (_soKheUoc.Length > 0)
				cm.Parameters.AddWithValue("@SoKheUoc", _soKheUoc);
			else
				cm.Parameters.AddWithValue("@SoKheUoc", DBNull.Value);
            if (_ngaySoSach != DateTime.MinValue)
                cm.Parameters.AddWithValue("@NgaySoSach", _ngaySoSach);
            else
                cm.Parameters.AddWithValue("@NgaySoSach", DBNull.Value);
			if (_soTienBangChu.Length > 0)
				cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
			else
				cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@NgaySua", DateTime.Now);
			if (_loaiMatHang.Length > 0)
				cm.Parameters.AddWithValue("@LoaiMatHang", _loaiMatHang);
			else
				cm.Parameters.AddWithValue("@LoaiMatHang", DBNull.Value);
            if (_ngayXacNhan != null)
                cm.Parameters.AddWithValue("@NgayXacNhan", _ngayXacNhan);
            else
                cm.Parameters.AddWithValue("@NgayXacNhan", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _deNghi_GiayBanNgoaiTeList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

            _deNghi_GiayBanNgoaiTeList.Clear();
            _deNghi_GiayBanNgoaiTeList.Update(tr,this);
			ExecuteDelete(tr, new Criteria(_maPhieu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        public string GetMaDNBNT()
        {
            string strMaUNC = "DN";//string.Empty;
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{
            //    cn.Open();
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_LayMaUNCNganHang";
            //        cm.Parameters.AddWithValue("@MaNganHang", _nganHangBan);

            //        strMaUNC = Convert.ToString(cm.ExecuteScalar());
            //    }

            //    cn.Close();
            //}
            return strMaUNC;
        }

        public static bool KiemTraSoDeNghi(string SoDeNghi, long MaPhieu)
        {
            bool bFound = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoChungTu_DeNghiBanNT";
                    cm.Parameters.AddWithValue("@SoChungTu", SoDeNghi);
                    cm.Parameters.AddWithValue("@MaPhieu", MaPhieu);

                    int sodong = Convert.ToInt32(cm.ExecuteScalar());
                    if (sodong > 0)
                        bFound = true;
                }

                cn.Close();
            }
            return bFound;
        }

        public string GetSoChungTu(ref int iSoChungTu)
        {
            string strSoChungTu = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoChungTuMax_DeNghiBanNT";
                    cm.Parameters.AddWithValue("@MaNganHang", _nganHangMua);
                    cm.Parameters.AddWithValue("@Nam", _ngayLap.Year);

                    //Do công ty khác nhau cung sử dụng 1 TK ngân hàng nên phải lấy thêm từng công ty
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

                    iSoChungTu = Convert.ToInt32(cm.ExecuteScalar());
                }
                cn.Close();
            }
            iSoChungTu++;
            if (iSoChungTu.ToString().Length == 1)
                strSoChungTu = "000" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 2)
                strSoChungTu = "00" + iSoChungTu.ToString();
            else if (iSoChungTu.ToString().Length == 3)
                strSoChungTu = "0" + iSoChungTu.ToString();
            else
                strSoChungTu = iSoChungTu.ToString();

            return strSoChungTu;
        }
	}
}

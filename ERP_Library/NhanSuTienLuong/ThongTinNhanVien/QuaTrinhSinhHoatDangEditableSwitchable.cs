
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuaTrinhSinhHoatDang : Csla.BusinessBase<QuaTrinhSinhHoatDang>
	{
		#region Business Properties and Methods

		//declare members
        private int _mactSinhhoatdang = 0;
        private long _maNhanVien = 0;
        private SmartDate _tuNgay = new SmartDate(false);
        private SmartDate _denNgay = new SmartDate(false);
        private string _noiSinhHoat = string.Empty;
        private int _maChucVuDang = 0;
        private string _diaChiNoiSH = string.Empty;
        private string _ghiChu = string.Empty;
        private int _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private string _nguoiGioiThieu1 = string.Empty;
        private string _nguoiGioiThieu2 = string.Empty;
        private SmartDate _ngayChinhThuc = new SmartDate(false);
        private string _chiBo = string.Empty;
        private SmartDate _ngayTuyenDungCongChuc = new SmartDate(false);
        private string _coQuanTuyenDung = string.Empty;
        private string _hoanCanhKinhTeBanThan = string.Empty;
        private string _quaTrinhHoatDong = string.Empty;
        private string _khenThuong = string.Empty;
        private string _soHuyHieuDang = string.Empty;
        private string _danhHieuDuocPhong = string.Empty;
        private string _kyLuat = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
        public int MactSinhhoatdang
        {
            get
            {
                CanReadProperty("MactSinhhoatdang", true);
                return _mactSinhhoatdang;
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
        }

        public string TuNgayString
        {
            get
            {
                CanReadProperty("TuNgayString", true);
                return _tuNgay.Text;
            }
            set
            {
                CanWriteProperty("TuNgayString", true);
                if (value == null) value = string.Empty;
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay.Text = value;
                    PropertyHasChanged("TuNgayString");
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
        }

        public string DenNgayString
        {
            get
            {
                CanReadProperty("DenNgayString", true);
                return _denNgay.Text;
            }
            set
            {
                CanWriteProperty("DenNgayString", true);
                if (value == null) value = string.Empty;
                if (!_denNgay.Equals(value))
                {
                    _denNgay.Text = value;
                    PropertyHasChanged("DenNgayString");
                }
            }
        }

        public string NoiSinhHoat
        {
            get
            {
                CanReadProperty("NoiSinhHoat", true);
                return _noiSinhHoat;
            }
            set
            {
                CanWriteProperty("NoiSinhHoat", true);
                if (value == null) value = string.Empty;
                if (!_noiSinhHoat.Equals(value))
                {
                    _noiSinhHoat = value;
                    PropertyHasChanged("NoiSinhHoat");
                }
            }
        }

        public int MaChucVuDang
        {
            get
            {
                CanReadProperty("MaChucVuDang", true);
                return _maChucVuDang;
            }
            set
            {
                CanWriteProperty("MaChucVuDang", true);
                if (!_maChucVuDang.Equals(value))
                {
                    _maChucVuDang = value;
                    PropertyHasChanged("MaChucVuDang");
                }
            }
        }

        public string DiaChiNoiSH
        {
            get
            {
                CanReadProperty("DiaChiNoiSH", true);
                return _diaChiNoiSH;
            }
            set
            {
                CanWriteProperty("DiaChiNoiSH", true);
                if (value == null) value = string.Empty;
                if (!_diaChiNoiSH.Equals(value))
                {
                    _diaChiNoiSH = value;
                    PropertyHasChanged("DiaChiNoiSH");
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

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
        }

        public string NgayLapString
        {
            get
            {
                CanReadProperty("NgayLapString", true);
                return _ngayLap.Text;
            }
            set
            {
                CanWriteProperty("NgayLapString", true);
                if (value == null) value = string.Empty;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap.Text = value;
                    PropertyHasChanged("NgayLapString");
                }
            }
        }

        public string NguoiGioiThieu1
        {
            get
            {
                CanReadProperty("NguoiGioiThieu1", true);
                return _nguoiGioiThieu1;
            }
            set
            {
                CanWriteProperty("NguoiGioiThieu1", true);
                if (value == null) value = string.Empty;
                if (!_nguoiGioiThieu1.Equals(value))
                {
                    _nguoiGioiThieu1 = value;
                    PropertyHasChanged("NguoiGioiThieu1");
                }
            }
        }

        public string NguoiGioiThieu2
        {
            get
            {
                CanReadProperty("NguoiGioiThieu2", true);
                return _nguoiGioiThieu2;
            }
            set
            {
                CanWriteProperty("NguoiGioiThieu2", true);
                if (value == null) value = string.Empty;
                if (!_nguoiGioiThieu2.Equals(value))
                {
                    _nguoiGioiThieu2 = value;
                    PropertyHasChanged("NguoiGioiThieu2");
                }
            }
        }

        public DateTime NgayChinhThuc
        {
            get
            {
                CanReadProperty("NgayChinhThuc", true);
                return _ngayChinhThuc.Date;
            }
        }

        public string NgayChinhThucString
        {
            get
            {
                CanReadProperty("NgayChinhThucString", true);
                return _ngayChinhThuc.Text;
            }
            set
            {
                CanWriteProperty("NgayChinhThucString", true);
                if (value == null) value = string.Empty;
                if (!_ngayChinhThuc.Equals(value))
                {
                    _ngayChinhThuc.Text = value;
                    PropertyHasChanged("NgayChinhThucString");
                }
            }
        }

        public string ChiBo
        {
            get
            {
                CanReadProperty("ChiBo", true);
                return _chiBo;
            }
            set
            {
                CanWriteProperty("ChiBo", true);
                if (value == null) value = string.Empty;
                if (!_chiBo.Equals(value))
                {
                    _chiBo = value;
                    PropertyHasChanged("ChiBo");
                }
            }
        }

        public DateTime NgayTuyenDungCongChuc
        {
            get
            {
                CanReadProperty("NgayTuyenDungCongChuc", true);
                return _ngayTuyenDungCongChuc.Date;
            }
        }

        public string NgayTuyenDungCongChucString
        {
            get
            {
                CanReadProperty("NgayTuyenDungCongChucString", true);
                return _ngayTuyenDungCongChuc.Text;
            }
            set
            {
                CanWriteProperty("NgayTuyenDungCongChucString", true);
                if (value == null) value = string.Empty;
                if (!_ngayTuyenDungCongChuc.Equals(value))
                {
                    _ngayTuyenDungCongChuc.Text = value;
                    PropertyHasChanged("NgayTuyenDungCongChucString");
                }
            }
        }

        public string CoQuanTuyenDung
        {
            get
            {
                CanReadProperty("CoQuanTuyenDung", true);
                return _coQuanTuyenDung;
            }
            set
            {
                CanWriteProperty("CoQuanTuyenDung", true);
                if (value == null) value = string.Empty;
                if (!_coQuanTuyenDung.Equals(value))
                {
                    _coQuanTuyenDung = value;
                    PropertyHasChanged("CoQuanTuyenDung");
                }
            }
        }

        public string HoanCanhKinhTeBanThan
        {
            get
            {
                CanReadProperty("HoanCanhKinhTeBanThan", true);
                return _hoanCanhKinhTeBanThan;
            }
            set
            {
                CanWriteProperty("HoanCanhKinhTeBanThan", true);
                if (value == null) value = string.Empty;
                if (!_hoanCanhKinhTeBanThan.Equals(value))
                {
                    _hoanCanhKinhTeBanThan = value;
                    PropertyHasChanged("HoanCanhKinhTeBanThan");
                }
            }
        }

        public string QuaTrinhHoatDong
        {
            get
            {
                CanReadProperty("QuaTrinhHoatDong", true);
                return _quaTrinhHoatDong;
            }
            set
            {
                CanWriteProperty("QuaTrinhHoatDong", true);
                if (value == null) value = string.Empty;
                if (!_quaTrinhHoatDong.Equals(value))
                {
                    _quaTrinhHoatDong = value;
                    PropertyHasChanged("QuaTrinhHoatDong");
                }
            }
        }

        public string KhenThuong
        {
            get
            {
                CanReadProperty("KhenThuong", true);
                return _khenThuong;
            }
            set
            {
                CanWriteProperty("KhenThuong", true);
                if (value == null) value = string.Empty;
                if (!_khenThuong.Equals(value))
                {
                    _khenThuong = value;
                    PropertyHasChanged("KhenThuong");
                }
            }
        }

        public string SoHuyHieuDang
        {
            get
            {
                CanReadProperty("SoHuyHieuDang", true);
                return _soHuyHieuDang;
            }
            set
            {
                CanWriteProperty("SoHuyHieuDang", true);
                if (value == null) value = string.Empty;
                if (!_soHuyHieuDang.Equals(value))
                {
                    _soHuyHieuDang = value;
                    PropertyHasChanged("SoHuyHieuDang");
                }
            }
        }

        public string DanhHieuDuocPhong
        {
            get
            {
                CanReadProperty("DanhHieuDuocPhong", true);
                return _danhHieuDuocPhong;
            }
            set
            {
                CanWriteProperty("DanhHieuDuocPhong", true);
                if (value == null) value = string.Empty;
                if (!_danhHieuDuocPhong.Equals(value))
                {
                    _danhHieuDuocPhong = value;
                    PropertyHasChanged("DanhHieuDuocPhong");
                }
            }
        }

        public string KyLuat
        {
            get
            {
                CanReadProperty("KyLuat", true);
                return _kyLuat;
            }
            set
            {
                CanWriteProperty("KyLuat", true);
                if (value == null) value = string.Empty;
                if (!_kyLuat.Equals(value))
                {
                    _kyLuat = value;
                    PropertyHasChanged("KyLuat");
                }
            }
        }
		
		protected override object GetIdValue()
		{
			return _mactSinhhoatdang;
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
			// NoiSinhHoat
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiSinhHoat", 200));
			//
			// DiaChiNoiSH
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChiNoiSH", 200));
			//
			// GhiChu
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
			//
			// NgayLap
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in QuaTrinhSinhHoatDang
			//AuthorizationRules.AllowRead("MactSinhhoatdang", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("NoiSinhHoat", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuDang", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("DiaChiNoiSH", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "QuaTrinhSinhHoatDangReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhSinhHoatDangReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("NoiSinhHoat", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuDang", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChiNoiSH", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhSinhHoatDangWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhSinhHoatDangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuaTrinhSinhHoatDang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuaTrinhSinhHoatDang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuaTrinhSinhHoatDang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuaTrinhSinhHoatDang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuaTrinhSinhHoatDangDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuaTrinhSinhHoatDang()
		{ /* require use of factory method */ }

		public static QuaTrinhSinhHoatDang NewQuaTrinhSinhHoatDang()
		{
            QuaTrinhSinhHoatDang item = new QuaTrinhSinhHoatDang();
            item.MarkAsChild();
            return item;
		}

        public static QuaTrinhSinhHoatDang NewQuaTrinhSinhHoatDang(long maNhanVien)
        {
            QuaTrinhSinhHoatDang _QuaTrinhSinhHoatDang = new QuaTrinhSinhHoatDang();
            _QuaTrinhSinhHoatDang.MaNhanVien = maNhanVien;
            return _QuaTrinhSinhHoatDang;
        }

		public static QuaTrinhSinhHoatDang GetQuaTrinhSinhHoatDang(int mactSinhhoatdang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuaTrinhSinhHoatDang");
			return DataPortal.Fetch<QuaTrinhSinhHoatDang>(new Criteria(mactSinhhoatdang));
		}

		public static void DeleteQuaTrinhSinhHoatDang(int mactSinhhoatdang)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhSinhHoatDang");
			DataPortal.Delete(new Criteria(mactSinhhoatdang));
		}

		public override QuaTrinhSinhHoatDang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhSinhHoatDang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuaTrinhSinhHoatDang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuaTrinhSinhHoatDang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuaTrinhSinhHoatDang NewQuaTrinhSinhHoatDangChild()
		{
			QuaTrinhSinhHoatDang child = new QuaTrinhSinhHoatDang();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuaTrinhSinhHoatDang GetQuaTrinhSinhHoatDang(SafeDataReader dr)
		{
			QuaTrinhSinhHoatDang child =  new QuaTrinhSinhHoatDang();
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
			public int MactSinhhoatdang;

			public Criteria(int mactSinhhoatdang)
			{
				this.MactSinhhoatdang = mactSinhhoatdang;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
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
                cm.CommandText = "spd_SelecttblnsQuaTrinhSinhHoatDang";

				cm.Parameters.AddWithValue("@MaCT_SinhHoatDang", criteria.MactSinhhoatdang);

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
			DataPortal_Delete(new Criteria(_mactSinhhoatdang));
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
                cm.CommandText = "spd_DeletetblnsQuaTrinhSinhHoatDang";

				cm.Parameters.AddWithValue("@MaCT_SinhHoatDang", criteria.MactSinhhoatdang);

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
            _mactSinhhoatdang = dr.GetInt32("MaCT_SinhHoatDang");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _noiSinhHoat = dr.GetString("NoiSinhHoat");
            _maChucVuDang = dr.GetInt32("MaChucVuDang");
            _diaChiNoiSH = dr.GetString("DiaChiNoiSH");
            _ghiChu = dr.GetString("GhiChu");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _nguoiGioiThieu1 = dr.GetString("NguoiGioiThieu1");
            _nguoiGioiThieu2 = dr.GetString("NguoiGioiThieu2");
            _ngayChinhThuc = dr.GetSmartDate("NgayChinhThuc", _ngayChinhThuc.EmptyIsMin);
            _chiBo = dr.GetString("ChiBo");
            _ngayTuyenDungCongChuc = dr.GetSmartDate("NgayTuyenDungCongChuc", _ngayTuyenDungCongChuc.EmptyIsMin);
            _coQuanTuyenDung = dr.GetString("CoQuanTuyenDung");
            _hoanCanhKinhTeBanThan = dr.GetString("HoanCanhKinhTeBanThan");
            _quaTrinhHoatDong = dr.GetString("QuaTrinhHoatDong");
            _khenThuong = dr.GetString("KhenThuong");
            _soHuyHieuDang = dr.GetString("SoHuyHieuDang");
            _danhHieuDuocPhong = dr.GetString("DanhHieuDuocPhong");
            _kyLuat = dr.GetString("KyLuat");
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
                cm.CommandText = "spd_InserttblnsQuaTrinhSinhHoatDang";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactSinhhoatdang = (int)cm.Parameters["@MaCT_SinhHoatDang"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_noiSinhHoat.Length > 0)
                cm.Parameters.AddWithValue("@NoiSinhHoat", _noiSinhHoat);
            else
                cm.Parameters.AddWithValue("@NoiSinhHoat", DBNull.Value);
            if (_maChucVuDang != 0)
                cm.Parameters.AddWithValue("@MaChucVuDang", _maChucVuDang);
            else
                cm.Parameters.AddWithValue("@MaChucVuDang", DBNull.Value);
            if (_diaChiNoiSH.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNoiSH", _diaChiNoiSH);
            else
                cm.Parameters.AddWithValue("@DiaChiNoiSH", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_nguoiGioiThieu1.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", _nguoiGioiThieu1);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu2.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", _nguoiGioiThieu2);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChinhThuc", _ngayChinhThuc.DBValue);
            if (_chiBo.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo", _chiBo);
            else
                cm.Parameters.AddWithValue("@ChiBo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTuyenDungCongChuc", _ngayTuyenDungCongChuc.DBValue);
            if (_coQuanTuyenDung.Length > 0)
                cm.Parameters.AddWithValue("@CoQuanTuyenDung", _coQuanTuyenDung);
            else
                cm.Parameters.AddWithValue("@CoQuanTuyenDung", DBNull.Value);
            if (_hoanCanhKinhTeBanThan.Length > 0)
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", _hoanCanhKinhTeBanThan);
            else
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", DBNull.Value);
            if (_quaTrinhHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@QuaTrinhHoatDong", _quaTrinhHoatDong);
            else
                cm.Parameters.AddWithValue("@QuaTrinhHoatDong", DBNull.Value);
            if (_khenThuong.Length > 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_soHuyHieuDang.Length > 0)
                cm.Parameters.AddWithValue("@SoHuyHieuDang", _soHuyHieuDang);
            else
                cm.Parameters.AddWithValue("@SoHuyHieuDang", DBNull.Value);
            if (_danhHieuDuocPhong.Length > 0)
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", _danhHieuDuocPhong);
            else
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", DBNull.Value);
            if (_kyLuat.Length > 0)
                cm.Parameters.AddWithValue("@KyLuat", _kyLuat);
            else
                cm.Parameters.AddWithValue("@KyLuat", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaCT_SinhHoatDang", _mactSinhhoatdang);
            cm.Parameters["@NewMaCT_SinhHoatDang"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuaTrinhSinhHoatDang";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@MaCT_SinhHoatDang", _mactSinhhoatdang);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_noiSinhHoat.Length > 0)
                cm.Parameters.AddWithValue("@NoiSinhHoat", _noiSinhHoat);
            else
                cm.Parameters.AddWithValue("@NoiSinhHoat", DBNull.Value);
            if (_maChucVuDang != 0)
                cm.Parameters.AddWithValue("@MaChucVuDang", _maChucVuDang);
            else
                cm.Parameters.AddWithValue("@MaChucVuDang", DBNull.Value);
            if (_diaChiNoiSH.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiNoiSH", _diaChiNoiSH);
            else
                cm.Parameters.AddWithValue("@DiaChiNoiSH", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_nguoiGioiThieu1.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", _nguoiGioiThieu1);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu1", DBNull.Value);
            if (_nguoiGioiThieu2.Length > 0)
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", _nguoiGioiThieu2);
            else
                cm.Parameters.AddWithValue("@NguoiGioiThieu2", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayChinhThuc", _ngayChinhThuc.DBValue);
            if (_chiBo.Length > 0)
                cm.Parameters.AddWithValue("@ChiBo", _chiBo);
            else
                cm.Parameters.AddWithValue("@ChiBo", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayTuyenDungCongChuc", _ngayTuyenDungCongChuc.DBValue);
            if (_coQuanTuyenDung.Length > 0)
                cm.Parameters.AddWithValue("@CoQuanTuyenDung", _coQuanTuyenDung);
            else
                cm.Parameters.AddWithValue("@CoQuanTuyenDung", DBNull.Value);
            if (_hoanCanhKinhTeBanThan.Length > 0)
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", _hoanCanhKinhTeBanThan);
            else
                cm.Parameters.AddWithValue("@HoanCanhKinhTeBanThan", DBNull.Value);
            if (_quaTrinhHoatDong.Length > 0)
                cm.Parameters.AddWithValue("@QuaTrinhHoatDong", _quaTrinhHoatDong);
            else
                cm.Parameters.AddWithValue("@QuaTrinhHoatDong", DBNull.Value);
            if (_khenThuong.Length > 0)
                cm.Parameters.AddWithValue("@KhenThuong", _khenThuong);
            else
                cm.Parameters.AddWithValue("@KhenThuong", DBNull.Value);
            if (_soHuyHieuDang.Length > 0)
                cm.Parameters.AddWithValue("@SoHuyHieuDang", _soHuyHieuDang);
            else
                cm.Parameters.AddWithValue("@SoHuyHieuDang", DBNull.Value);
            if (_danhHieuDuocPhong.Length > 0)
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", _danhHieuDuocPhong);
            else
                cm.Parameters.AddWithValue("@DanhHieuDuocPhong", DBNull.Value);
            if (_kyLuat.Length > 0)
                cm.Parameters.AddWithValue("@KyLuat", _kyLuat);
            else
                cm.Parameters.AddWithValue("@KyLuat", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_mactSinhhoatdang));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

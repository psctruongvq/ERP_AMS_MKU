
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
// a long test
namespace ERP_Library
{ 
   //thuyên
	[Serializable()]
    public class ButToanPhieuNhapXuatCCDC : Csla.BusinessBase<ButToanPhieuNhapXuatCCDC>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToan = 0;
		private int _noTaiKhoan = 0;
		private int _coTaiKhoan = 0;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;
		private long _maDoiTuongNo = 0;
		private long _maDoiTuongCo = 0;
		private int _maDinhKhoan = 0;
		private int _maCongTy = 0;
		private int _maSoQuy = 0;
        private int _maTieuMuc = 0;
        private int _maPhieuNhapXuat =0 ;
        private string _soHieuTaiKhoanNo = string.Empty;
        private string _soHieuTaiKhoanCo = string.Empty;

		//declare child member(s)
        private ButToan_MucNganSachCCDC _butToan_MucNganSach = ButToan_MucNganSachCCDC.NewButToan_MucNganSach();
        private ChungTu_HoaDonCCDCList _chungTu_HoaDonList = ChungTu_HoaDonCCDCList.NewChungTu_HoaDonList();
        private ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaButToan
		{
			get
			{
				CanReadProperty("MaButToan", true);
				return _maButToan;
			}
		}

		public int NoTaiKhoan
		{
			get
			{
				CanReadProperty("NoTaiKhoan", true);
				return _noTaiKhoan;
                
			}
			set
			{
				CanWriteProperty("NoTaiKhoan", true);
				if (!_noTaiKhoan.Equals(value))
				{
					_noTaiKhoan = value;
					PropertyHasChanged("NoTaiKhoan");

                    _soHieuTaiKhoanNo = HeThongTaiKhoan.GetHeThongTaiKhoanByMaTaiKhoan(_noTaiKhoan).SoHieuTK;
				}
			}
		}

		public int CoTaiKhoan
		{
			get
			{
				CanReadProperty("CoTaiKhoan", true);
				return _coTaiKhoan;
			}
			set
			{
				CanWriteProperty("CoTaiKhoan", true);
				if (!_coTaiKhoan.Equals(value))
				{
					_coTaiKhoan = value;
					PropertyHasChanged("CoTaiKhoan");
                    _soHieuTaiKhoanCo = HeThongTaiKhoan.GetHeThongTaiKhoanByMaTaiKhoan(_coTaiKhoan).SoHieuTK;
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

		public long MaDoiTuongNo
		{
			get
			{
				CanReadProperty("MaDoiTuongNo", true);
				return _maDoiTuongNo;
			}
			set
			{
				CanWriteProperty("MaDoiTuongNo", true);
				if (!_maDoiTuongNo.Equals(value))
				{
					_maDoiTuongNo = value;
					PropertyHasChanged("MaDoiTuongNo");
				}
			}
		}

		public long MaDoiTuongCo
		{
			get
			{
				CanReadProperty("MaDoiTuongCo", true);
				return _maDoiTuongCo;
			}
			set
			{
				CanWriteProperty("MaDoiTuongCo", true);
				if (!_maDoiTuongCo.Equals(value))
				{
					_maDoiTuongCo = value;
					PropertyHasChanged("MaDoiTuongCo");
				}
			}
		}

		public int MaDinhKhoan
		{
			get
			{
				CanReadProperty("MaDinhKhoan", true);
				return _maDinhKhoan;
			}
			set
			{
				CanWriteProperty("MaDinhKhoan", true);
				if (!_maDinhKhoan.Equals(value))
				{
					_maDinhKhoan = value;
					PropertyHasChanged("MaDinhKhoan");
				}
			}
		}

		public int MaCongTy
		{
			get
			{
				CanReadProperty("MaCongTy", true);
				return _maCongTy;
			}
			set
			{
				CanWriteProperty("MaCongTy", true);
				if (!_maCongTy.Equals(value))
				{
					_maCongTy = value;
					PropertyHasChanged("MaCongTy");
				}
			}
		}

		public int MaSoQuy
		{
			get
			{
				CanReadProperty("MaSoQuy", true);
				return _maSoQuy;
			}
			set
			{
				CanWriteProperty("MaSoQuy", true);
				if (!_maSoQuy.Equals(value))
				{
					_maSoQuy = value;
					PropertyHasChanged("MaSoQuy");
				}
			}
		}

        public int MaTieuMuc        
        {
            get
            {
                CanReadProperty("MaTieuMuc", true);
                return _butToan_MucNganSach.MaTieuMuc;
            }
            set
            {
                CanWriteProperty("MaTieuMuc", true);
                if (!_maTieuMuc.Equals(value))
                {
                    _maTieuMuc = value;
                    _butToan_MucNganSach.MaTieuMuc = _maTieuMuc;
                    PropertyHasChanged("MaTieuMuc");
                }
            }
        }

        public string SoHieuTaiKhoanNo
        {
            get
            {
                CanReadProperty("SoHieuTaiKhoanNo", true);
                return _soHieuTaiKhoanNo;
            }
            
        }

        public string SoHieuTaiKhoanCo
        {
            get
            {
                CanReadProperty("SoHieuTaiKhoanCo", true);
                return _soHieuTaiKhoanCo;
            }

        }

        int _IDKhoanMuc;
        public int IDKhoanMuc
        {
            get
            {
                CanReadProperty(true);
                return _IDKhoanMuc;
            }
            set
            {
                CanWriteProperty(true);
                if (!_IDKhoanMuc.Equals(value))
                {
                    _IDKhoanMuc = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaDonVi;
        public int MaDonVi
        {
            get
            {
                CanReadProperty(true);
                return _MaDonVi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDonVi.Equals(value))
                {
                    _MaDonVi = value;
                    PropertyHasChanged();
                }
            }
        }

        public ButToan_MucNganSachCCDC ButToan_MucNganSach
		{
			get
			{
				CanReadProperty("ButToan_MucNganSach", true);
				return _butToan_MucNganSach;
			}
		}

        public ChungTu_HoaDonCCDCList ChungTu_HoaDonList
        {
            get
            {
                CanReadProperty("ChungTu_HoaDonList", true);
                return _chungTu_HoaDonList;
            }
            set
            {
                CanWriteProperty("ChungTu_HoaDonList", true);
                _chungTu_HoaDonList = value;

                PropertyHasChanged("ChungTu_HoaDonList");

            }
        }

        public ChungTu_ChiPhiSanXuatList ChungTu_ChiPhiSanXuatList
        {
            get
            {
                CanReadProperty("ChungTu_ChiPhiSanXuatList", true);
                return _chungTu_ChiPhiSanXuatList;
            }
            set
            {
                CanWriteProperty("ChungTu_ChiPhiSanXuatList", true);
                _chungTu_ChiPhiSanXuatList = value;

                PropertyHasChanged("ChungTu_ChiPhiSanXuatList");

            }
        }
 
		public override bool IsValid
		{
            get { return base.IsValid && _butToan_MucNganSach.IsValid && _chungTu_HoaDonList.IsValid && _chungTu_ChiPhiSanXuatList.IsValid; }
		}

		public override bool IsDirty
		{
            get { return base.IsDirty || _butToan_MucNganSach.IsDirty || _chungTu_HoaDonList.IsDirty || _chungTu_ChiPhiSanXuatList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maButToan;
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
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
			//TODO: Define authorization rules in ButToanPhieuNhapXuat
			//AuthorizationRules.AllowRead("ButToan_MucNganSach", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaButToan", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NoTaiKhoan", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("CoTaiKhoan", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTuongNo", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTuongCo", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaDinhKhoan", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "ButToanPhieuNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaSoQuy", "ButToanPhieuNhapXuatReadGroup");

			//AuthorizationRules.AllowWrite("NoTaiKhoan", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("CoTaiKhoan", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTuongNo", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTuongCo", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaDinhKhoan", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "ButToanPhieuNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaSoQuy", "ButToanPhieuNhapXuatWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ButToanPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToanPhieuNhapXuatViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ButToanPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToanPhieuNhapXuatAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ButToanPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToanPhieuNhapXuatEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ButToanPhieuNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToanPhieuNhapXuatDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ButToanPhieuNhapXuatCCDC()
        { /* require use of factory method */  MarkAsChild(); }
        public ButToanPhieuNhapXuatCCDC(ButToanPhieuNhapXuatCCDC btPhieuNhapXuat)
        {

            _noTaiKhoan=btPhieuNhapXuat.NoTaiKhoan;
            _coTaiKhoan=btPhieuNhapXuat.CoTaiKhoan;
            _soTien=btPhieuNhapXuat.SoTien;
            _dienGiai=btPhieuNhapXuat.DienGiai;
            _maDoiTuongCo=btPhieuNhapXuat.MaDoiTuongCo;
            _maDoiTuongNo=btPhieuNhapXuat.MaDoiTuongNo;
            _maCongTy=btPhieuNhapXuat.MaCongTy;
            _maSoQuy=btPhieuNhapXuat.MaSoQuy;
            _maTieuMuc=btPhieuNhapXuat.MaTieuMuc;
            MarkAsChild();
        }

        public static ButToanPhieuNhapXuatCCDC NewButToanPhieuNhapXuat()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ButToanPhieuNhapXuat");
            return DataPortal.Create<ButToanPhieuNhapXuatCCDC>();
		}

        public static ButToanPhieuNhapXuatCCDC GetButToanPhieuNhapXuat(int maButToan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ButToanPhieuNhapXuat");
            return DataPortal.Fetch<ButToanPhieuNhapXuatCCDC>(new Criteria(maButToan));
		}

		public static void DeleteButToanPhieuNhapXuat(int maButToan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ButToanPhieuNhapXuat");
			DataPortal.Delete(new Criteria(maButToan));
		}

        public override ButToanPhieuNhapXuatCCDC Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ButToanPhieuNhapXuat");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ButToanPhieuNhapXuat");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ButToanPhieuNhapXuat");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        internal static ButToanPhieuNhapXuatCCDC NewButToanPhieuNhapXuatChild()
		{
            ButToanPhieuNhapXuatCCDC child = new ButToanPhieuNhapXuatCCDC();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        internal static ButToanPhieuNhapXuatCCDC GetButToanPhieuNhapXuat(SafeDataReader dr)
		{
            ButToanPhieuNhapXuatCCDC child = new ButToanPhieuNhapXuatCCDC();
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
			public int MaButToan;

			public Criteria(int maButToan)
			{
				this.MaButToan = maButToan;
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
				cm.CommandText = "GetButToanPhieuNhapXuat";

				cm.Parameters.AddWithValue("@MaButToan", criteria.MaButToan);

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
			DataPortal_Delete(new Criteria(_maButToan));
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
                    _butToan_MucNganSach.DeleteSelf(tr);
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
                cm.CommandText = "spd_DeletetblButToan";

				cm.Parameters.AddWithValue("@MaButToan", criteria.MaButToan);

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
			_maButToan = dr.GetInt32("MaButToan");
			_noTaiKhoan = dr.GetInt32("NoTaiKhoan");
			_coTaiKhoan = dr.GetInt32("CoTaiKhoan");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
			_maDoiTuongNo = dr.GetInt64("MaDoiTuongNo");
			_maDoiTuongCo = dr.GetInt64("MaDoiTuongCo");
			_maDinhKhoan = dr.GetInt32("MaDinhKhoan");
			_maCongTy = dr.GetInt32("MaCongTy");
			_maSoQuy = dr.GetInt32("MaSoQuy");
            _IDKhoanMuc = dr.GetInt32("IDKhoanMuc");
            _MaDonVi = dr.GetInt32("MaDonVi");
            _soHieuTaiKhoanNo = HeThongTaiKhoan.GetHeThongTaiKhoanByMaTaiKhoan(_noTaiKhoan).SoHieuTK;
            _soHieuTaiKhoanCo = HeThongTaiKhoan.GetHeThongTaiKhoanByMaTaiKhoan(_coTaiKhoan).SoHieuTK;
		}

		private void FetchChildren(SafeDataReader dr)
		{

            _butToan_MucNganSach = ButToan_MucNganSachCCDC.GetButToan_MucNganSachByMaButToan(this.MaButToan);
            if (_butToan_MucNganSach.MaButToanMucNganSach == 0)
                _butToan_MucNganSach = ButToan_MucNganSachCCDC.NewButToan_MucNganSach();
            else _maTieuMuc = _butToan_MucNganSach.MaTieuMuc;
            _chungTu_HoaDonList = ChungTu_HoaDonCCDCList.GetChungTu_HoaDonListByMaBuToan(_maButToan);

            _chungTu_ChiPhiSanXuatList = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatByButToanList(_maButToan);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblButToan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToan = (int)cm.Parameters["@MaButToan"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maDinhKhoan = parent.MaDinhKhoan;            
			if (_noTaiKhoan != 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan != 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuongNo != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
			if (_maDoiTuongCo != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			if (_maCongTy != 0)
				cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			else
				cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
			if (_maSoQuy != 0)
				cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
			else
				cm.Parameters.AddWithValue("@MaSoQuy", DBNull.Value);
            if (_IDKhoanMuc != 0)
                cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
            else
                cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);
            if (_MaDonVi != 0)
                cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
            else
                cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters["@MaButToan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatCCDC parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblButToan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
		{
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			if (_noTaiKhoan != 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan != 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuongNo != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongNo", _maDoiTuongNo);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongNo", DBNull.Value);
			if (_maDoiTuongCo != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongCo", _maDoiTuongCo);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongCo", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			if (_maCongTy != 0)
				cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			else
				cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
			if (_maSoQuy != 0)
				cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
			else
				cm.Parameters.AddWithValue("@MaSoQuy", DBNull.Value);
            if (_IDKhoanMuc != 0)
                cm.Parameters.AddWithValue("@IDKhoanMuc", _IDKhoanMuc);
            else
                cm.Parameters.AddWithValue("@IDKhoanMuc", DBNull.Value);
            if (_MaDonVi != 0)
                cm.Parameters.AddWithValue("@MaDonVi", _MaDonVi);
            else
                cm.Parameters.AddWithValue("@MaDonVi", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            if (_butToan_MucNganSach.IsNew)
                _butToan_MucNganSach.Insert(tr, this);
            else _butToan_MucNganSach.Update(tr, this);

            _chungTu_HoaDonList.DataPortal_Update(tr,this);

            _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr,0 , "", this.MaButToan);

		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _butToan_MucNganSach.DeleteSelf(tr);
            _chungTu_HoaDonList.Clear();
            _chungTu_HoaDonList.Update(tr,this);
            _chungTu_ChiPhiSanXuatList.Clear();
            _chungTu_ChiPhiSanXuatList.DataPortal_Update(tr, 0,"", this.MaButToan);
			ExecuteDelete(tr, new Criteria(_maButToan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

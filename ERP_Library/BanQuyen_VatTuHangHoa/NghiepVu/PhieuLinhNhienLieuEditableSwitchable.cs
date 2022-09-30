
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//23/04/2013
namespace ERP_Library
{ 
	[Serializable()] 
	public class PhieuLinhNhienLieu : Csla.BusinessBase<PhieuLinhNhienLieu>
	{
		#region Business Properties and Methods

		//declare members
		private long _maPhieuLinhNhienLieu = 0;
		private string _soChungTu = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
        private int _maNguoiLap = 0;
        //private int _maKho = KhoBQ_VT.GetKhoBQ_VT("KNL").MaKho;     //1; //Thang
        private int _maKho = 0;//M
        private string _diaChi = string.Empty;
		private int _maNguoiNhan = 0;
		private string _lyDoXuat = string.Empty;
		private string _dienGiai = string.Empty;
        private DateTime _ngayHetHan = DateTime.Today;
        //private int _maBoPhanNhan = BoPhan.GetBoPhan("DV23").MaBoPhan;   //23; //Thang
        private int _maBoPhanNhan = 0;   //M
		private byte _tinhTrang = 1;
		private long _maPhieuNhapXuat = 0;
        private int _iDXe = 0;
        private string _tinhTrangString = string.Empty;
        private bool _Chon = false;
        private byte _loai = 1;
        private decimal _tongSoLuongDuyet = 0;//M
        private string _soPhieuXuat = string.Empty;
		int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

		public bool Chon
        {
            get { return _Chon; }
            set { _Chon = value; }
        }
		//declare child member(s)
		private CT_PhieuLinhNhienLieuList _cT_PhieuLinhNhienLieuList = CT_PhieuLinhNhienLieuList.NewCT_PhieuLinhNhienLieuList();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaPhieuLinhNhienLieu
		{
			get
			{
				CanReadProperty("MaPhieuLinhNhienLieu", true);
				return _maPhieuLinhNhienLieu;
			}
		}

		public string SoChungTu
		{
			get
			{
				CanReadProperty("SoChungTu", true);
				return _soChungTu;
			}
			set
			{
				CanWriteProperty("SoChungTu", true);
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap;
			}
            set
            {                
                CanWriteProperty("NgayLap", true);
                _ngayLap = value;

                //_ngayHetHan = _ngayLap.AddDays(-_ngayLap.Date.Day + 1).AddMonths(1);
                //if (_ngayHetHan.DayOfWeek == DayOfWeek.Saturday)
                //    _ngayHetHan = _ngayHetHan.AddDays(1);
                //if (_ngayHetHan.DayOfWeek == DayOfWeek.Sunday)
                //    _ngayHetHan = _ngayHetHan.AddDays(1);
                PropertyHasChanged("NgayLap");                
            }
		}

        public DateTime NgayHetHan
        {
            get
            {
                CanReadProperty("NgayHetHan", true);
                //if (_ngayHetHan.Equals(_ngayLap))
                //{
                //    _ngayHetHan = _ngayLap.AddDays(-_ngayLap.Date.Day + 1).AddMonths(1);
                //    if (_ngayHetHan.DayOfWeek == DayOfWeek.Saturday)
                //        _ngayHetHan = _ngayHetHan.AddDays(1);
                //    if (_ngayHetHan.DayOfWeek == DayOfWeek.Sunday)
                //        _ngayHetHan = _ngayHetHan.AddDays(1);
                //}
                return _ngayHetHan;
            }
            set
            {
                CanWriteProperty("NgayHetHan", true);
                _ngayHetHan = value;
                PropertyHasChanged("NgayHetHan");
            }
        }


        //public string NgayLapString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayLapString", true);
        //        return _ngayLap.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayLapString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayLap.Equals(value))
        //        {
        //            _ngayLap.Text = value;
        //            PropertyHasChanged("NgayLapString");
        //        }
        //    }
        //}

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

		public int MaKho
		{
			get
			{
				CanReadProperty("MaKho", true);
                _diaChi = KhoBQ_VT.GetKhoBQ_VT(_maKho, maCongTy).MaDiaChi;
				return _maKho;
			}
			set
			{
				CanWriteProperty("MaKho", true);
				if (!_maKho.Equals(value))
				{
					_maKho = value;
					PropertyHasChanged("MaKho");
				}
                _diaChi = KhoBQ_VT.GetKhoBQ_VT(_maKho, maCongTy).MaDiaChi;
			}
		}
        public string DiaChi
		{
			get
			{
				return _diaChi;
			}
            set
            {
                    _diaChi = value;    
            }
        }
		public int MaNguoiNhan
		{
			get
			{
				CanReadProperty("MaNguoiNhan", true);
				return _maNguoiNhan;
			}
			set
			{
				CanWriteProperty("MaNguoiNhan", true);
				if (!_maNguoiNhan.Equals(value))
				{
					_maNguoiNhan = value;
					PropertyHasChanged("MaNguoiNhan");
				}
			}
		}

		public string LyDoXuat
		{
			get
			{
				CanReadProperty("LyDoXuat", true);
				return _lyDoXuat;
			}
			set
			{
				CanWriteProperty("LyDoXuat", true);
				if (value == null) value = string.Empty;
				if (!_lyDoXuat.Equals(value))
				{
					_lyDoXuat = value;
					PropertyHasChanged("LyDoXuat");
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

		

        //public string NgayHetHanString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayHetHanString", true);
        //        return _ngayHetHan.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayHetHanString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayHetHan.Equals(value))
        //        {
        //            _ngayHetHan.Text = value;
        //            PropertyHasChanged("NgayHetHanString");
        //        }
        //    }
        //}

		public int MaBoPhanNhan
		{
			get
			{
				CanReadProperty("MaBoPhanNhan", true);
				return _maBoPhanNhan;
			}
			set
			{
				CanWriteProperty("MaBoPhanNhan", true);
				if (!_maBoPhanNhan.Equals(value))
				{
					_maBoPhanNhan = value;
					PropertyHasChanged("MaBoPhanNhan");
				}
			}
		}

		public byte TinhTrang
		{
			get
			{
				CanReadProperty("TinhTrang", true);
				return _tinhTrang;
			}
			set
			{
				CanWriteProperty("TinhTrang", true);
				if (!_tinhTrang.Equals(value))
				{
					_tinhTrang = value;
                    if (_tinhTrang == 0)
                        _tinhTrangString = "Chưa làm phiếu xuất";
                    if (_tinhTrang == 1)
                        _tinhTrangString = "Đã làm phiếu xuất";
					PropertyHasChanged("TinhTrang");
				}
			}
		}

		public long MaPhieuNhapXuat
		{
			get
			{
				CanReadProperty("MaPhieuNhapXuat", true);
				return _maPhieuNhapXuat;
                
			}
			set
			{
				CanWriteProperty("MaPhieuNhapXuat", true);
				if (!_maPhieuNhapXuat.Equals(value))
				{
					_maPhieuNhapXuat = value;
					PropertyHasChanged("MaPhieuNhapXuat");
				}
			}
		}
        public int IDXe
        {
            get
            {
                CanReadProperty("IDXe", true);
                return _iDXe;
            }
            set
            {
                CanWriteProperty("IDXe", true);
                if (!_iDXe.Equals(value))
                {
                    _iDXe = value;
                    PropertyHasChanged("IDXe");
                }
            }
        }

        public byte Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }
        public decimal TongSoLuongDuyet
        {
            get
            {
                CanReadProperty("TongSoLuongDuyet", true);
                return _tongSoLuongDuyet;
            }
            set
            {
                CanWriteProperty("TongSoLuongDuyet", true);
                if (!_tongSoLuongDuyet.Equals(value))
                {
                    _tongSoLuongDuyet = value;
                    PropertyHasChanged("TongSoLuongDuyet");
                }
            }
        }

        public string TinhTrangString
        {
            get
            {
                CanReadProperty("TinhTrangString", true);
                return _tinhTrangString;
            }
           
        }

        public string SoPhieuXuat
        {
            get
            {
                return _soPhieuXuat;
            }

        }

		public CT_PhieuLinhNhienLieuList CT_PhieuLinhNhienLieuList
		{
			get
			{
				CanReadProperty("CT_PhieuLinhNhienLieuList", true);
				return _cT_PhieuLinhNhienLieuList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_PhieuLinhNhienLieuList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_PhieuLinhNhienLieuList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maPhieuLinhNhienLieu;
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// LyDoXuat
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDoXuat", 1000));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
			//TODO: Define authorization rules in PhieuLinhNhienLieu
			//AuthorizationRules.AllowRead("CT_PhieuLinhNhienLieuList", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuLinhNhienLieu", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("SoChungTu", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaKho", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiNhan", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("LyDoXuat", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("NgayHetHan", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("NgayHetHanString", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanNhan", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "PhieuLinhNhienLieuReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "PhieuLinhNhienLieuReadGroup");

			//AuthorizationRules.AllowWrite("SoChungTu", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaKho", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiNhan", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("LyDoXuat", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHetHanString", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanNhan", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "PhieuLinhNhienLieuWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "PhieuLinhNhienLieuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhieuLinhNhienLieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhieuLinhNhienLieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhieuLinhNhienLieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhieuLinhNhienLieu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhieuLinhNhienLieuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhieuLinhNhienLieu()
		{ /* require use of factory method */ }

		public static PhieuLinhNhienLieu NewPhieuLinhNhienLieu()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhieuLinhNhienLieu");
			return DataPortal.Create<PhieuLinhNhienLieu>();
		}

		public static PhieuLinhNhienLieu GetPhieuLinhNhienLieu(long maPhieuLinhNhienLieu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhieuLinhNhienLieu");
			return DataPortal.Fetch<PhieuLinhNhienLieu>(new Criteria(maPhieuLinhNhienLieu));
		}

		public static void DeletePhieuLinhNhienLieu(long maPhieuLinhNhienLieu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhieuLinhNhienLieu");
			DataPortal.Delete(new Criteria(maPhieuLinhNhienLieu));
		}

		public override PhieuLinhNhienLieu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhieuLinhNhienLieu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhieuLinhNhienLieu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhieuLinhNhienLieu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhieuLinhNhienLieu NewPhieuLinhNhienLieuChild()
		{
			PhieuLinhNhienLieu child = new PhieuLinhNhienLieu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhieuLinhNhienLieu GetPhieuLinhNhienLieu(SafeDataReader dr)
		{
			PhieuLinhNhienLieu child =  new PhieuLinhNhienLieu();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
        internal static PhieuLinhNhienLieu GetPhieuLinhNhienLieuKhongChild(SafeDataReader dr)
        {
            PhieuLinhNhienLieu child = new PhieuLinhNhienLieu();
            child.MarkAsChild();
            child.FetchKhongChild(dr);
            return child;
        }
		#endregion //Child Factory Methods
        #region
        public static void DeletePhieuLinhNhienLieu(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {//B
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    phieuLinhNhienLieu._cT_PhieuLinhNhienLieuList.Clear();
                    phieuLinhNhienLieu._cT_PhieuLinhNhienLieuList.Update(tr, phieuLinhNhienLieu);

                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblPhieuLinhNhienLieu";

                        cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", phieuLinhNhienLieu.MaPhieuLinhNhienLieu);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }//E
        #endregion
		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MaPhieuLinhNhienLieu;

			public Criteria(long maPhieuLinhNhienLieu)
			{
				this.MaPhieuLinhNhienLieu = maPhieuLinhNhienLieu;
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
                cm.CommandText = "spd_SelecttblPhieuLinhNhienLieu";

				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", criteria.MaPhieuLinhNhienLieu);

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
			DataPortal_Delete(new Criteria(_maPhieuLinhNhienLieu));
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
                    _cT_PhieuLinhNhienLieuList.Clear();
                    _cT_PhieuLinhNhienLieuList.Update(tr, this);
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
                cm.CommandText = "spd_DeletetblPhieuLinhNhienLieu";

				cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", criteria.MaPhieuLinhNhienLieu);

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
        private void FetchKhongChild(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();
        }
		private void FetchObject(SafeDataReader dr)
		{
			_maPhieuLinhNhienLieu = dr.GetInt64("MaPhieuLinhNhienLieu");
			_soChungTu = dr.GetString("SoChungTu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_maKho = dr.GetInt32("MaKho");
            _diaChi = KhoBQ_VT.GetKhoBQ_VT(_maKho, maCongTy).MaDiaChi;
			_maNguoiNhan = dr.GetInt32("MaNguoiNhan");
			_lyDoXuat = dr.GetString("LyDoXuat");
			_dienGiai = dr.GetString("DienGiai");
            _ngayHetHan = dr.GetDateTime("NgayHetHan");
			_maBoPhanNhan = dr.GetInt32("MaBoPhanNhan");
			_tinhTrang = dr.GetByte("TinhTrang");
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _soPhieuXuat = PhieuNhapXuat.LaySoPhieu(_maPhieuNhapXuat);
            _iDXe = dr.GetInt32("IDXe");
            _loai = dr.GetByte("Loai");
            _tongSoLuongDuyet = dr.GetDecimal("TongSoLuongDuyet");
		}

		private void FetchChildren(SafeDataReader dr)
		{			
			_cT_PhieuLinhNhienLieuList = CT_PhieuLinhNhienLieuList.GetCT_PhieuLinhNhienLieuList(this.MaPhieuLinhNhienLieu);
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
                cm.CommandText = "spd_InserttblPhieuLinhNhienLieu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maPhieuLinhNhienLieu = (long)cm.Parameters["@MaPhieuLinhNhienLieu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);      
			if (_maKho != 0)
				cm.Parameters.AddWithValue("@MaKho", _maKho);
			else
				cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiNhan", _maNguoiNhan);
			if (_lyDoXuat.Length > 0)
				cm.Parameters.AddWithValue("@LyDoXuat", _lyDoXuat);
			else
				cm.Parameters.AddWithValue("@LyDoXuat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan);
			if (_maBoPhanNhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhanNhan", DBNull.Value);
			if (_tinhTrang != 0)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_iDXe != 0)
                cm.Parameters.AddWithValue("@IDXe", _iDXe);
            else
                cm.Parameters.AddWithValue("@IDXe", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@TongSoLuongDuyet", _tongSoLuongDuyet);
			cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
			cm.Parameters["@MaPhieuLinhNhienLieu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhieuLinhNhienLieu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);      
			if (_maKho != 0)
				cm.Parameters.AddWithValue("@MaKho", _maKho);
			else
				cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNguoiNhan", _maNguoiNhan);
			if (_lyDoXuat.Length > 0)
				cm.Parameters.AddWithValue("@LyDoXuat", _lyDoXuat);
			else
				cm.Parameters.AddWithValue("@LyDoXuat", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan);
			if (_maBoPhanNhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanNhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhanNhan", DBNull.Value);
			if (_tinhTrang != 0)
				cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
			else
				cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_iDXe != 0)
                cm.Parameters.AddWithValue("@IDXe", _iDXe);
            else
                cm.Parameters.AddWithValue("@IDXe", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            cm.Parameters.AddWithValue("@TongSoLuongDuyet", _tongSoLuongDuyet);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_PhieuLinhNhienLieuList.Update(tr, this);
		}
		#endregion //Data Access - Update

        #region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_PhieuLinhNhienLieuList.Clear();
            _cT_PhieuLinhNhienLieuList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_maPhieuLinhNhienLieu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
        
        #region Set So Phieu
        public static string SetSoChungTu(DateTime _ngayLap, int _userID, byte _loai)
        {
            string _soChungTu = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoChungTuPhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@UserID", _userID);
                    cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                    cm.Parameters.AddWithValue("@Loai", _loai);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _soChungTu = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _soChungTu;
        }

        public static int CheckSoChungTu(long _maPhieuLinhNhienLieu, string _soChungTu)
        {
            int _isOld;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckSoChungTuPhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", _maPhieuLinhNhienLieu);
                    cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
                    SqlParameter isOld = new SqlParameter("@isOld", SqlDbType.Int);
                    isOld.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(isOld);
                    cm.ExecuteNonQuery();
                    _isOld = (int)isOld.Value;
                }
            }//us
            return _isOld;

        }
        #endregion
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoThuLao : Csla.BusinessBase<PhanBoThuLao>
	{
		#region Business Properties and Methods

		//declare members
		private long _maPhanBoThuLao = 0;
		private string _maPhanBoThuLaoQL = string.Empty;
		private int _maChuongTrinh = 0;
		private string _maChuongTrinhQL = string.Empty;
        private string _tenChuongTrinh = string.Empty;
        private string _tenCongViec = string.Empty;
        private string _tenBoPhan = string.Empty;
		private int _maChiTietGiayXacNhan = 0;
		private int _maGiayXacNhanChuongTrinh = 0;
		private int _nguoiLap = 0;
		private decimal _soTien = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private string _ghiChu = string.Empty;
		private int _maKyTinhLuong = 0;
		private int _maBoPhanDi = 0;
        private int _giatri = 0;
        private string _ghiChuChiTietPBTL = string.Empty;
        private Boolean _daDuyet = false;

        private ChiTietPhanBoThuLaoList _chiTietPhanBoThuLaoList = ChiTietPhanBoThuLaoList .NewChiTietPhanBoThuLaoList();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaPhanBoThuLao
		{
			get
			{
				CanReadProperty("MaPhanBoThuLao", true);
				return _maPhanBoThuLao;
			}
		}

        public int GiaTri
        {
            get
            {
                CanReadProperty("GiaTri", true);
                return _giatri;
            }
        }
        public bool DaDuyet
        {
            get
            {
                CanReadProperty("DaDuyet", true);
                return _daDuyet;
            }
            set
            {
                CanWriteProperty("DaDuyet", true);
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged("DaDuyet");
                }
            }
        }
		public string MaPhanBoThuLaoQL
		{
			get
			{
				CanReadProperty("MaPhanBoThuLaoQL", true);
				return _maPhanBoThuLaoQL;
			}
			set
			{
				CanWriteProperty("MaPhanBoThuLaoQL", true);
				if (value == null) value = string.Empty;
				if (!_maPhanBoThuLaoQL.Equals(value))
				{
					_maPhanBoThuLaoQL = value;
					PropertyHasChanged("MaPhanBoThuLaoQL");
				}
			}
		}

		public int MaChuongTrinh
		{
			get
			{
				CanReadProperty("MaChuongTrinh", true);
				return _maChuongTrinh;
			}
			set
			{
				CanWriteProperty("MaChuongTrinh", true);
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

		public string MaChuongTrinhQL
		{
			get
			{
				CanReadProperty("MaChuongTrinhQL", true);
				return _maChuongTrinhQL;
			}
			set
			{
				CanWriteProperty("MaChuongTrinhQL", true);
				if (value == null) value = string.Empty;
				if (!_maChuongTrinhQL.Equals(value))
				{
					_maChuongTrinhQL = value;
					PropertyHasChanged("MaChuongTrinhQL");
				}
			}
		}
        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
                }
            }
        }
        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
                }
            }
        }
        public string TenCongViec
        {
            get
            {
                CanReadProperty("TenCongViec", true);
                return _tenCongViec;
            }
            set
            {
                CanWriteProperty("TenCongViec", true);
                if (value == null) value = string.Empty;
                if (!_tenCongViec.Equals(value))
                {
                    _tenCongViec = value;
                    PropertyHasChanged("TenCongViec");
                }
            }
        }

		public int MaChiTietGiayXacNhan
		{
			get
			{
				CanReadProperty("MaChiTietGiayXacNhan", true);
				return _maChiTietGiayXacNhan;
			}
			set
			{
				CanWriteProperty("MaChiTietGiayXacNhan", true);
				if (!_maChiTietGiayXacNhan.Equals(value))
				{
					_maChiTietGiayXacNhan = value;
					PropertyHasChanged("MaChiTietGiayXacNhan");
				}
			}
		}

		public int MaGiayXacNhanChuongTrinh
		{
			get
			{
				CanReadProperty("MaGiayXacNhanChuongTrinh", true);
				return _maGiayXacNhanChuongTrinh;
			}
			set
			{
				CanWriteProperty("MaGiayXacNhanChuongTrinh", true);
				if (!_maGiayXacNhanChuongTrinh.Equals(value))
				{
					_maGiayXacNhanChuongTrinh = value;
					PropertyHasChanged("MaGiayXacNhanChuongTrinh");
				}
			}
		}

		public int NguoiLap
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
        public string GhiChuChiTietPBTL
        {
            get
            {
                CanReadProperty("GhiChuChiTietPBTL", true);
                return _ghiChuChiTietPBTL;
            }
            set
            {
                CanWriteProperty("GhiChuChiTietPBTL", true);
                if (value == null) value = string.Empty;
                if (!_ghiChuChiTietPBTL.Equals(value))
                {
                    _ghiChuChiTietPBTL = value;
                    PropertyHasChanged("GhiChuChiTietPBTL");
                }
            }
        }
		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
				}
			}
		}

		public int MaBoPhanDi
		{
			get
			{
				CanReadProperty("MaBoPhanDi", true);
				return _maBoPhanDi;
			}
			set
			{
				CanWriteProperty("MaBoPhanDi", true);
				if (!_maBoPhanDi.Equals(value))
				{
					_maBoPhanDi = value;
					PropertyHasChanged("MaBoPhanDi");
				}
			}
		}
 		public ChiTietPhanBoThuLaoList ChiTietPhanBoThuLaoList
		{
			get
			{
				return _chiTietPhanBoThuLaoList;
			}
            set
            {
                if (!ChiTietPhanBoThuLaoList.Equals(value))
                {
                    _chiTietPhanBoThuLaoList= value;
                    PropertyHasChanged("ChiTietPhanBoThuLaoList ");
                }
            }
		}
        public override bool IsValid
		{
			get { return base.IsValid && _chiTietPhanBoThuLaoList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _chiTietPhanBoThuLaoList.IsDirty; }
		}
		protected override object GetIdValue()
		{
			return _maPhanBoThuLao;
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
			// MaPhanBoThuLaoQL
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaPhanBoThuLaoQL");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanBoThuLaoQL", 50));
			//
			// MaChuongTrinhQL
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaChuongTrinhQL");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChuongTrinhQL", 50));
		
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
			//TODO: Define authorization rules in PhanBoThuLao
			//AuthorizationRules.AllowRead("MaPhanBoThuLao", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBoThuLaoQL", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinh", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaChuongTrinhQL", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaChiTietGiayXacNhan", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaGiayXacNhanChuongTrinh", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "PhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanDi", "PhanBoThuLaoReadGroup");

			//AuthorizationRules.AllowWrite("MaPhanBoThuLaoQL", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuongTrinh", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuongTrinhQL", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChiTietGiayXacNhan", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaGiayXacNhanChuongTrinh", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "PhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanDi", "PhanBoThuLaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoThuLaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoThuLao()
		{ /* require use of factory method */
           
        }

        private PhanBoThuLao(string maPhanBoQL)
        {
            _maPhanBoThuLaoQL = maPhanBoQL;
        }

        public static PhanBoThuLao NewPhanBoThuLao()
        {
            return new PhanBoThuLao();
        }

        public static PhanBoThuLao NewPhanBoThuLaoKhoiTao(string maPhanBoQL)
        {
            return new PhanBoThuLao(maPhanBoQL);
        }

		public static PhanBoThuLao GetPhanBoThuLao(long maPhanBoThuLao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLao");
			return DataPortal.Fetch<PhanBoThuLao>(new Criteria(maPhanBoThuLao));
		}

        public static PhanBoThuLao GetPhanBoThuLaoByMaChiTiet(long maChiTietPhanBoThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLao");
            return DataPortal.Fetch<PhanBoThuLao>(new CriteriaByMaChiTiet(maChiTietPhanBoThuLao));
        }

        public static PhanBoThuLao GetPhanBoThuLaoByMaPhanBoThuLao(long maPhanBoThuLao, long maChiTietPhanBoThuLao)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanBoThuLao");
            return DataPortal.Fetch<PhanBoThuLao>(new CriteriaByMaPhanBoThuLao(maPhanBoThuLao, maChiTietPhanBoThuLao));
        }

		public static void DeletePhanBoThuLao(long maPhanBoThuLao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLao");
			DataPortal.Delete(new Criteria(maPhanBoThuLao));
		}

		public override PhanBoThuLao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoThuLao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoThuLao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanBoThuLao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhanBoThuLao NewPhanBoThuLaoChild()
		{
			PhanBoThuLao child = new PhanBoThuLao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanBoThuLao GetPhanBoThuLao(SafeDataReader dr)
		{
			PhanBoThuLao child =  new PhanBoThuLao();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static PhanBoThuLao GetPhanBoThuLao(SafeDataReader dr, int loai)
        {
            PhanBoThuLao child = new PhanBoThuLao();
            child.MarkAsChild();
            child.Fetch(dr,loai);
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class CriteriaByMaPhanBoThuLao
		{
			public long MaPhanBoThuLao;
            public long MaChiTietPhanBoThuLao;

            public CriteriaByMaPhanBoThuLao(long maPhanBoThuLao, long maChiTietPhanBoThuLao)
			{
				this.MaPhanBoThuLao = maPhanBoThuLao;
                this.MaChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
			}
		}

        private class Criteria
        {
            public long MaPhanBoThuLao;

            public Criteria(long maPhanBoThuLao)
            {
                this.MaPhanBoThuLao = maPhanBoThuLao;
            }
        }

        private class CriteriaByMaChiTiet
        {
            public long MaChiTietPhanBoThuLao;

            public CriteriaByMaChiTiet(long maChiTietPhanBoThuLao)
            {
                this.MaChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
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
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                if(criteria is CriteriaByMaPhanBoThuLao)
                {
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoByMaPhanBoThuLao";

				cm.Parameters.AddWithValue("@MaPhanBoThuLao",((CriteriaByMaPhanBoThuLao)criteria).MaPhanBoThuLao);
                cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", ((CriteriaByMaPhanBoThuLao)criteria).MaChiTietPhanBoThuLao);
                }

                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLao";

                    cm.Parameters.AddWithValue("@MaPhanBoThuLao", ((Criteria)criteria).MaPhanBoThuLao);
                }

                if (criteria is CriteriaByMaChiTiet)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsPhanBoThuLaoByMaChiTiet";

                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", ((CriteriaByMaChiTiet)criteria).MaChiTietPhanBoThuLao);
                }

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
			DataPortal_Delete(new Criteria(_maPhanBoThuLao));
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
				cm.CommandText = "Spd_DeletetblnsPhanBoThuLao";

				cm.Parameters.AddWithValue("@MaPhanBoThuLao", criteria.MaPhanBoThuLao);

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

        private void Fetch(SafeDataReader dr, int loai)
        {
            FetchObject(dr,loai);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

		private void FetchObject(SafeDataReader dr)
		{
            _giatri = dr.GetInt32("GiaTri");
            if (_giatri == 1)
            {
                _maPhanBoThuLao = dr.GetInt32("MaPhanBoThuLao");
            }
            else
            {
                _maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");  
            }
			_maPhanBoThuLaoQL = dr.GetString("MaPhanBoThuLaoQL");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_maChuongTrinhQL = dr.GetString("MaChuongTrinhQL");
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            _maGiayXacNhanChuongTrinh = dr.GetInt32("MaGiayXacNhanChuongTrinh");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_soTien = dr.GetDecimal("SoTien");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_ghiChu = dr.GetString("GhiChu");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_maBoPhanDi = dr.GetInt32("MaBoPhanDi");
            _daDuyet = dr.GetBoolean("DaDuyet");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _tenBoPhan = dr.GetString("TenBoPhan");
		}

        private void FetchObject(SafeDataReader dr, int loai)
        {
            _giatri = dr.GetInt32("GiaTri");
            if (_giatri == 1)
            {
                _maPhanBoThuLao = dr.GetInt32("MaPhanBoThuLao");
            }
            else
            {
                _maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");
            }
            _maPhanBoThuLaoQL = dr.GetString("MaPhanBoThuLaoQL");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _maChuongTrinhQL = dr.GetString("MaChuongTrinhQL");
            _maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            _maGiayXacNhanChuongTrinh = dr.GetInt32("MaGiayXacNhanChuongTrinh");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _soTien = dr.GetDecimal("SoTien");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _ghiChuChiTietPBTL = dr.GetString("GhiChuChiTietPBTL");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maBoPhanDi = dr.GetInt32("MaBoPhanDi");
            _tenCongViec = dr.GetString("TenCongViec");
        }
		private void FetchChildren(SafeDataReader dr)
		{
            _chiTietPhanBoThuLaoList = ChiTietPhanBoThuLaoList.GetChiTietPhanBoThuLaoList(_maPhanBoThuLao);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhanBoThuLaoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhanBoThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_InserttblnsPhanBoThuLao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhanBoThuLao = (long)cm.Parameters["@MaPhanBoThuLao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhanBoThuLaoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoQL", _maPhanBoThuLaoQL);
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			cm.Parameters.AddWithValue("@MaChuongTrinhQL", _maChuongTrinhQL);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
			cm.Parameters.AddWithValue("@MaGiayXacNhanChuongTrinh", _maGiayXacNhanChuongTrinh);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			if (_maBoPhanDi != 0)
				cm.Parameters.AddWithValue("@MaBoPhanDi", _maBoPhanDi);
			else
				cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			cm.Parameters["@MaPhanBoThuLao"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhanBoThuLaoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhanBoThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_UpdatetblnsPhanBoThuLao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhanBoThuLaoList parent)
		{
			cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaPhanBoThuLaoQL", _maPhanBoThuLaoQL);
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			cm.Parameters.AddWithValue("@MaChuongTrinhQL", _maChuongTrinhQL);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
			cm.Parameters.AddWithValue("@MaGiayXacNhanChuongTrinh", _maGiayXacNhanChuongTrinh);
			cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			if (_maBoPhanDi != 0)
				cm.Parameters.AddWithValue("@MaBoPhanDi", _maBoPhanDi);
			else
				cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
         _chiTietPhanBoThuLaoList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
 
         _chiTietPhanBoThuLaoList.Clear();
         UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maPhanBoThuLao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
        #region LayMaPhanBoLonNhat
        internal static string LayMaPhanBoLonNhat()
        {
            string giaTriTraVe = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaPhanBoLonNhat";
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTri", SqlDbType.VarChar, 30);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    if (prmGiaTriTraVe.Value != null)
                    {
                        giaTriTraVe = (string)prmGiaTriTraVe.Value;
                    }
                }
            }//us
            return giaTriTraVe;
        }
        #endregion

        #region LayMaBoPhanQuanLy
        internal static string LayMaBoPhanQuanLy()
        {
            string _maBoPhanQuanLy = "";
            BoPhan _boPhan = BoPhan.GetBoPhan( ERP_Library.Security.CurrentUser.Info.MaBoPhan);

            _maBoPhanQuanLy = _boPhan.MaBoPhanQL;

            return _maBoPhanQuanLy;
        }
        #endregion

        #region MaPhanBoThuLao-MaQuanLy
        public static string MaPhanBoThuLaoQuanLy()
        {
            string MaPhanBoLonNhat;
            int temp=0;
            string GiaTriTraVe;

            MaPhanBoLonNhat = LayMaPhanBoLonNhat();

            if (MaPhanBoLonNhat != "")
            {
                try
                {
                    temp = Convert.ToInt32(MaPhanBoLonNhat.Substring(0, 4));
                }
                catch (Exception ex)
                {
                    temp = 0;
                }
                temp = temp + 1;
                if (temp < 10)
                {
                    GiaTriTraVe = "000" + temp.ToString();
                }
                else if (temp < 100)
                {
                    GiaTriTraVe = "00" + temp.ToString();
                }
                else if (temp < 1000)
                {
                    GiaTriTraVe = "0" + temp.ToString();
                }
                else if (temp < 10000)
                {
                    GiaTriTraVe = "0" + temp.ToString();
                }
                else
                {
                    GiaTriTraVe = temp.ToString();
                }
                
                string chuoixuly="";
                chuoixuly = GiaTriTraVe + "/" + LayMaBoPhanQuanLy() + "/" + DateTime.Now.Year;
                GiaTriTraVe = chuoixuly;

                return GiaTriTraVe;
            }
            else
                return "";
        }
        #endregion
	}

}

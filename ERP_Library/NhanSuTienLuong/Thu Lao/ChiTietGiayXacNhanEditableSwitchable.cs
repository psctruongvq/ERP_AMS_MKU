
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhan : Csla.BusinessBase<ChiTietGiayXacNhan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTietGiayXacNhan = 0;
		private int _maGiayXacNhan = 0;
		private int _maBoPhanDen = 0;
        private string _tenBoPhanDen = string.Empty;
	//	private int _databaseNumber = 0;
		private decimal _soTien = 0;
        private SmartDate _ngayHoanTat = new SmartDate(DateTime.Today.Date);
		private bool _hoanTat = false;
		//private decimal _soTienConLai = 0;
        private string _ghiChu = string.Empty;
        private string _tenGiayXacNhan = string.Empty;
     
        private int _maBoPhanDi = 0;
        private string _tenBoPhanDi = string.Empty;
        private bool _duocNhapHo = false;
        private bool _kinhPhiBan = false;
        private DateTime _ngayLap = DateTime.Today.Date;
        private decimal _soTienConLai = 0;

    
     
		//declare child member(s)
		private ChiTietGiayXacNhan_NhanVienList _chiTietGiayXacNhan_NhanVienList = ChiTietGiayXacNhan_NhanVienList.NewChiTietGiayXacNhan_NhanVienList();
        private GiayXacNhan_TrackingList _giayXacNhanTracking_List = GiayXacNhan_TrackingList.NewGiayXacNhan_TrackingList();
		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTietGiayXacNhan
		{
			get
			{
               
				return _maChiTietGiayXacNhan;
			}
		}

		public int MaGiayXacNhan
		{
			get
			{

                //_ngayLap = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(_maGiayXacNhan).NgayLap;
				return _maGiayXacNhan;
			}
			set
			{
				if (!_maGiayXacNhan.Equals(value))
				{
					_maGiayXacNhan = value;
                 //   _ngayLap = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(_maGiayXacNhan).NgayLap;
					PropertyHasChanged("MaGiayXacNhan");
				}
			}
		}
        public string TenGiayXacNhan
        {
            get
            {
                
                return _tenGiayXacNhan;
            }
            set
            {
                CanWriteProperty("TenGiayXacNhan", true);
                if (value == null) value = string.Empty;
                if (!_tenGiayXacNhan.Equals(value))
                {
                    _tenGiayXacNhan = value;
                    PropertyHasChanged("TenGiayXacNhan");
                }
            }
        }
       
		public int MaBoPhanDen
		{
			get
			{
				return _maBoPhanDen;
			}
			set
			{
				if (!_maBoPhanDen.Equals(value))
				{
					_maBoPhanDen = value;
                    _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
					PropertyHasChanged("MaBoPhanDen");
				}
			}
		}
        public string TenBoPhanDen
        {
            get
            {
                CanReadProperty("TenBoPhanDen", true);
                _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
                return _tenBoPhanDen;
            }
            set
            {
                CanWriteProperty("TenBoPhanDen", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhanDen.Equals(value))
                {
                    _tenBoPhanDen = BoPhan.GetBoPhan(_maBoPhanDen).TenBoPhan;
                    _tenBoPhanDen = value;
                    PropertyHasChanged("TenBoPhanDen");
                }
            }
        }
	
		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}
        public decimal SoTienConLai
        {
            get {
                return _soTienConLai ;
                 }
           
        }

		public DateTime NgayHoanTat
		{
			get
			{
				return _ngayHoanTat.Date;
			}
            set
            {
                CanWriteProperty("NgayHoanTat", true);
                if (!_ngayHoanTat.Equals(value))
                {
                    _ngayHoanTat = new SmartDate(value);
                    PropertyHasChanged("NgayHoanTat");
                }
            }
		}

	
		public bool HoanTat
		{
			get
			{
				return _hoanTat;
			}
			set
			{
				if (!_hoanTat.Equals(value))
				{
					_hoanTat = value;
					PropertyHasChanged("HoanTat");
				}
			}
		}
        /*
		public decimal SoTienConLai
		{
			get
			{
				return _soTienConLai;
			}
			set
			{
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
				}
			}
		}
        */
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
        public int MaBoPhanDi
        {
            get
            {
                return _maBoPhanDi;
            }
            set
            {
                if (!_maBoPhanDi.Equals(value))
                {
                    _maBoPhanDi = value;
                    PropertyHasChanged("MaBoPhanDi");
                }
            }
        }

        public string TenBoPhanDi
        {
            get
            {
                return _tenBoPhanDi;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenBoPhanDi.Equals(value))
                {
                    _tenBoPhanDi = value;
                    PropertyHasChanged("TenBoPhanDi");
                }
            }
        }

    
		public ChiTietGiayXacNhan_NhanVienList ChiTietGiayXacNhan_NhanVienList
		{
			get
			{
				return _chiTietGiayXacNhan_NhanVienList;
			}
            set
            {
               
                    _chiTietGiayXacNhan_NhanVienList = value;
               
                
            }
		}
        public DateTime NgayLap
        {
            get {

                return _ngayLap;//
            }
            
        }
        public bool DuocNhapHo
        {
            get
            {
                return _duocNhapHo;
            }
            set
            {
                if (!_duocNhapHo.Equals(value))
                {
                    _duocNhapHo = value;
                    PropertyHasChanged("DuocNhapHo");
                }
            }
        }
        public bool KinhPhiBan
        {
            get
            {
                return _kinhPhiBan;
            }
            set
            {
                if (!_kinhPhiBan.Equals(value))
                {
                    _kinhPhiBan = value;
                    PropertyHasChanged("KinhPhiBan");
                }
            }
        }
     	public override bool IsValid
		{
			get { return base.IsValid && _chiTietGiayXacNhan_NhanVienList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _chiTietGiayXacNhan_NhanVienList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maChiTietGiayXacNhan;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiTietGiayXacNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietGiayXacNhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiTietGiayXacNhan()
		{ /* require use of factory method */ }

        public static ChiTietGiayXacNhan NewChiTietGiayXacNhan()
        {
            ChiTietGiayXacNhan item = new ChiTietGiayXacNhan();
            item.MarkAsChild();
            return item;
        }
        public static ChiTietGiayXacNhan NewChiTietGiayXacNhan(int index,string name)
        {

             ChiTietGiayXacNhan item=new ChiTietGiayXacNhan();
             item.TenGiayXacNhan = name;
             
             return item;
        }
        public static ChiTietGiayXacNhan NewChiTietGiayXacNhan(int MaGiayXacNhan)
		{
            ChiTietGiayXacNhan item = new ChiTietGiayXacNhan();
            item.MaGiayXacNhan = MaGiayXacNhan;
            item.MarkAsChild();
            return item;
            //if (!CanAddObject())
            //    throw new System.Security.SecurityException("User not authorized to add a ChiTietGiayXacNhan");
            //return DataPortal.Create<ChiTietGiayXacNhan>(new Criteria(maChiTietGiayXacNhan));
		}

		public static ChiTietGiayXacNhan GetChiTietGiayXacNhan(int maChiTietGiayXacNhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiTietGiayXacNhan");
			return DataPortal.Fetch<ChiTietGiayXacNhan>(new Criteria(maChiTietGiayXacNhan));
		}

        public static ChiTietGiayXacNhan GetChiTietGiayXacNhanByGiayXacNhan(int maGiayXacNhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietGiayXacNhan");
            return DataPortal.Fetch<ChiTietGiayXacNhan>(new CriteriaByGiayXacNhan(maGiayXacNhan));
        }

        public static ChiTietGiayXacNhan GetChiTietGiayXacNhanByGiayXacNhan_BoPhan(int maGiayXacNhan, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietGiayXacNhan");
            return DataPortal.Fetch<ChiTietGiayXacNhan>(new CriteriaByGiayXacNhan_BoPhan(maGiayXacNhan,maBoPhan));
        }

		public static void DeleteChiTietGiayXacNhan(int maChiTietGiayXacNhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiTietGiayXacNhan");
			DataPortal.Delete(new Criteria(maChiTietGiayXacNhan));
		}
        /*
        /// <summary>
        /// Hàm cập nhật số tiền Chuyển Khoản còn lại của Nhân Viên.
        /// </summary>
        /// <param name="maChiTietGiayXacNhan">Mã Chi Tiết Giấy Xác Nhận</param>
        /// <param name="dataBaseNumberGXN">DatabaseNumber của GXN</param>
        /// <param name="dataBaseNumber">DatabaseNumber của người cập nhật</param>
        /// <param name="soTienDaNhap">Tổng số tiền đã nhập cho nhân viên</param>
        public static void UpdateSoTienChuyenKhoanChiTietGiayXacNhan(int maChiTietGiayXacNhan, int dataBaseNumberGXN, int dataBaseNumber, decimal soTienDaNhap)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateSoTienChiTietGiayXacNhan";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                cm.Parameters.AddWithValue("@DataBaseNumberGXN", dataBaseNumberGXN);
                cm.Parameters.AddWithValue("@DatabaseNumber", dataBaseNumber);
                cm.Parameters.AddWithValue("@SoTienDaNhap", soTienDaNhap);

                cm.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Hàm cập nhật số tiền Tiền Mặt còn lại của Nhân Viên.
        /// </summary>
        /// <param name="maChiTietGiayXacNhan">Mã Chi Tiết Giấy Xác Nhận</param>
        /// <param name="dataBaseNumberGXN">DatabaseNumber của GXN</param>
        /// <param name="dataBaseNumber">DatabaseNumber của người cập nhật</param>
        /// <param name="soTienDaNhap">Tổng số tiền đã nhập cho nhân viên</param>
        public static void UpdateSoTienTienMatChiTietGiayXacNhan(int maChiTietGiayXacNhan,int dataBaseNumberGXN,int dataBaseNumber,decimal soTienDaNhap)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateSoTien_TienMatChiTietGiayXacNhan";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                cm.Parameters.AddWithValue("@DataBaseNumberGXN", dataBaseNumberGXN);
                cm.Parameters.AddWithValue("@DatabaseNumber", dataBaseNumber);
                cm.Parameters.AddWithValue("@SoTienDaNhapTienMat", soTienDaNhap);
                
                cm.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Hàm cập nhật số tiền còn lại của Nhân Viên Ngoài Đài.
        /// </summary>
        /// <param name="maChiTietGiayXacNhan">Mã Chi Tiết Giấy Xác Nhận</param>
        /// <param name="dataBaseNumberGXN">DatabaseNumber của GXN</param>
        /// <param name="dataBaseNumber">DatabaseNumber của người cập nhật</param>
        /// <param name="soTienDaNhap">Tổng số tiền đã nhập cho nhân viên Ngoài Đài</param>
        public static void UpdateSoTienNhanVienNgoaiDaiGXN(int maChiTietGiayXacNhan, int dataBaseNumberGXN, int dataBaseNumber, decimal soTienDaNhap)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateSoTienChiTietGiayXacNhan_NgoaiDai";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
                cm.Parameters.AddWithValue("@DataBaseNumberGXN", dataBaseNumberGXN);
                cm.Parameters.AddWithValue("@DatabaseNumber", dataBaseNumber);
                cm.Parameters.AddWithValue("@SoTienDaNhap", soTienDaNhap);         
                cm.ExecuteNonQuery();

            }
        }
       */
        /// <summary>
        /// Cập nhật trạng thái Chi Tiết Giấy Xác Nhận, Chi Tiết Giấy Xác Nhận Tracking.
        /// </summary>
        /// <param name="maChiTietGiayXacNhan">Mã Chi Tiết Giấy Xác Nhận</param>
        /// <param name="dataBaseNumberGXN">DatabaseNumber của GXN</param>       
        /// <param name="trangThai">Trạng thái cần cập nhật</param>
        public static void UpdateTrangThaiChiTietGXN(int maChiTietGiayXacNhan, bool trangThai)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdateTrangThaiChiTietGXN";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
             
                cm.Parameters.AddWithValue("@trangThai", trangThai);

                cm.ExecuteNonQuery();

            }
        }
        public static bool KiemTraGiayXacNhanTonTai(int maBoPhanNhan, int maChiTietGiayXacNhan)
        {
          
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "KiemTraGiayXacNhanTonTai";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);
               
                cm.Parameters.AddWithValue("@kq", kq);
                cm.Parameters["@kq"].Direction = ParameterDirection.Output;
                //cm.Parameters["@kq"].Direction = ParameterDirection.ReturnValue;
                cm.ExecuteNonQuery();
                kq = (int)cm.Parameters["@kq"].Value;
            }
            if (kq > 0)
                return true;
            else
                return false;
        }

        public static decimal KiemTraSoTienHopLe( int maChiTietGiayXacNhan)
        {

            decimal kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[KiemTraSoTienHopLe]";
                cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", maChiTietGiayXacNhan);

                cm.Parameters.AddWithValue("@kq", kq);//Convert.ToDecimal( 0));
                cm.Parameters["@kq"].Direction = ParameterDirection.Output;
                //cm.Parameters["@kq"].Direction = ParameterDirection.ReturnValue;
                cm.ExecuteNonQuery();
                kq = Convert.ToDecimal( cm.Parameters["@kq"].Value);
            }

            return kq;
        }
    
		public override ChiTietGiayXacNhan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiTietGiayXacNhan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiTietGiayXacNhan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChiTietGiayXacNhan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ChiTietGiayXacNhan(int maChiTietGiayXacNhan)
		{
			this._maChiTietGiayXacNhan = maChiTietGiayXacNhan;
		}

		internal static ChiTietGiayXacNhan NewChiTietGiayXacNhanChild(int maChiTietGiayXacNhan)
		{
			ChiTietGiayXacNhan child = new ChiTietGiayXacNhan(maChiTietGiayXacNhan);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChiTietGiayXacNhan GetChiTietGiayXacNhan(SafeDataReader dr)
		{
			ChiTietGiayXacNhan child =  new ChiTietGiayXacNhan();
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
			public int MaChiTietGiayXacNhan;
            public Criteria()
            {
                
            }
			public Criteria(int maChiTietGiayXacNhan)
			{
				this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
			}

		}
        private class CriteriaByGiayXacNhan
        {
            public int _maGiayXacNhan;
            public CriteriaByGiayXacNhan(int maGiayXacNhan)
            {
                _maGiayXacNhan = maGiayXacNhan;
            }

        }

        private class CriteriaByGiayXacNhan_BoPhan
        {
            public int _maGiayXacNhan;
            public int _maBoPhan;

            public CriteriaByGiayXacNhan_BoPhan(int maGiayXacNhan,int maBoPhan)
            {
                _maGiayXacNhan = maGiayXacNhan;
                _maBoPhan = maBoPhan;
            }

        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChiTietGiayXacNhan = criteria.MaChiTietGiayXacNhan;
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
				cm.Transaction = tr;
                cm.CommandTimeout = 0;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", ((Criteria)criteria).MaChiTietGiayXacNhan);
                }

                if (criteria is CriteriaByGiayXacNhan)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanByGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((CriteriaByGiayXacNhan)criteria)._maGiayXacNhan);
                }


                if (criteria is CriteriaByGiayXacNhan_BoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhanByGiayXacNhan_BoPhan";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", ((CriteriaByGiayXacNhan_BoPhan)criteria)._maGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByGiayXacNhan_BoPhan)criteria)._maBoPhan);
                    //cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                 
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
			DataPortal_Delete(new Criteria(_maChiTietGiayXacNhan));
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
                if (_hoanTat != true)
                {
                    if (ChiTietGiayXacNhan.KiemTraGiayXacNhanTonTai(_maBoPhanDen, _maChiTietGiayXacNhan))
                    {
                        return;

                    }
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DeletetblnsChiTietGiayXacNhan";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", criteria.MaChiTietGiayXacNhan);
                    cm.ExecuteNonQuery();


                    cm.Parameters.Clear();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_UpdatetblnsGiayXacNhan_TrackingTrangThai";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", criteria.MaChiTietGiayXacNhan);
                  
                    cm.ExecuteNonQuery();
                }
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
			_maChiTietGiayXacNhan = dr.GetInt32("MaChiTietGiayXacNhan");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
         //decimal i= GiayXacNhan_Tracking.SoTienConLaiGXN(_maChiTietGiayXacNhan);
			_maGiayXacNhan = dr.GetInt32("MaGiayXacNhan");
			_maBoPhanDen = dr.GetInt32("MaBoPhanDen");
            _tenBoPhanDen = dr.GetString("TenBoPhanDen");
          
			_soTien = dr.GetDecimal("SoTien");
			_ngayHoanTat = dr.GetSmartDate("NgayHoanTat", _ngayHoanTat.EmptyIsMin);
			_hoanTat = dr.GetBoolean("HoanTat");
		
            _ghiChu = dr.GetString("GhiChu");
            _maBoPhanDi = dr.GetInt32("MaBoPhanDi");
            _tenBoPhanDi = dr.GetString("TenBoPhanDi");
            _tenGiayXacNhan = dr.GetString("TenGiayXacNhan");
            _duocNhapHo = dr.GetBoolean("DuocNhapHo");
            _kinhPhiBan = dr.GetBoolean("KinhPhiBan");
            //_soTienConLai = GiayXacNhan_Tracking.SoTienConLaiGXN(_maChiTietGiayXacNhan);
            _ngayLap = dr.GetDateTime("NgayLap");
            //_ngayLap = GiayXacNhan_Tracking.GetGiayXacNhan_Tracking(_maGiayXacNhan).NgayLapGXN;
          //  _ngayLap = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(_maGiayXacNhan).NgayLap; 
		}

		private void FetchChildren(SafeDataReader dr)
		{
           // while (dr.Read())
           //     this.Add(ChiTietGiayXacNhan.GetChiTietGiayXacNhan(dr));

            _chiTietGiayXacNhan_NhanVienList = ChiTietGiayXacNhan_NhanVienList.GetChiTietGiayXacNhan_NhanVienList(_maChiTietGiayXacNhan);
  		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, GiayXacNhanChuongTrinh parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, GiayXacNhanChuongTrinh parent)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsChiTietGiayXacNhan";

                    AddInsertParameters(cm, parent);

                    cm.ExecuteNonQuery();
                    _maChiTietGiayXacNhan = (int)cm.Parameters["@MaChiTietGiayXacNhan"].Value;


                    //GiayXacNhanTracking-Inserst
                    cm.Parameters.Clear();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblnsGiayXacNhan_Tracking";
                    AddInsertParametersTracking(cm, parent);
                    cm.ExecuteNonQuery();
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AddInsertParametersTracking(SqlCommand cm, GiayXacNhanChuongTrinh parent)
        {
            cm.Parameters.AddWithValue("@MaGiayXacNhan", parent.MaGiayXacNhan);
            if (parent.TenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", parent.TenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            if (parent.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienDaNhapNV", 0);

            cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", 0);
            cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", 0);
            
            cm.Parameters.AddWithValue("@SoTienConLai", 0);
         
            cm.Parameters.AddWithValue("@MaBoPhanGui", parent.MaDonViXacNhanDi);
            if (parent.TenDonViXacNhanDi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanGui", parent.TenDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanDen);
            if (_tenBoPhanDen.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanDen);
            else
                cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
            if (parent.MaChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", parent.MaChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (parent.TenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", parent.TenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLapGXN", parent.NgayLap);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Now.Date);

            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@TrackingID", 0);
            cm.Parameters["@TrackingID"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
        }
        private void AddInsertParameters(SqlCommand cm, GiayXacNhanChuongTrinh parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (_tenBoPhanDen.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanDen", _tenBoPhanDen);
            else
                cm.Parameters.AddWithValue("@TenBoPhanDen", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            cm.Parameters["@MaChiTietGiayXacNhan"].Direction = ParameterDirection.Output;
            if (parent.MaGiayXacNhan != 0)
				cm.Parameters.AddWithValue("@MaGiayXacNhan", parent.MaGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
			if (_maBoPhanDen != 0)
				cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
			else
				cm.Parameters.AddWithValue("@MaBoPhanDen", DBNull.Value);
			
			
			
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
			if (_hoanTat != false)
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			else
				cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
            
            //if (_soTienConLai != 0)
            //    cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            //else
             cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            if (parent.MaDonViXacNhanDi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDi", parent.MaDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
            if (parent.TenDonViXacNhanDi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanDi", parent.TenDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanDi", DBNull.Value);
            if (parent.TenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", parent.TenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            cm.Parameters.AddWithValue("@KinhPhiBan", _kinhPhiBan);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, GiayXacNhanChuongTrinh parent)
        {
            if (_hoanTat == true) return;

            
                ExecuteUpdate(tr, parent);
                MarkOld();
          

            //update child object(s)
            UpdateChildren(tr);

        }

        private void ExecuteUpdate(SqlTransaction tr, GiayXacNhanChuongTrinh parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                //if (ChiTietGiayXacNhan.KiemTraGiayXacNhanTonTai(_maBoPhanDen, _maChiTietGiayXacNhan))
                //{
                //    return;

                //}
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChiTietGiayXacNhan";
				AddUpdateParameters(cm, parent);
                cm.ExecuteNonQuery();
                //GiayXacNhanTracking-Insert
                cm.Parameters.Clear();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsGiayXacNhan_Tracking_byChiTietGXN";
                AddUpdateParametersTracking(cm, parent);
                cm.ExecuteNonQuery();
				

			}//using
		}
        private void AddUpdateParametersTracking(SqlCommand cm, GiayXacNhanChuongTrinh parent)
        {
            cm.Parameters.AddWithValue("@SoTienDaNhapNVTienMat", 0);
            cm.Parameters.AddWithValue("@MaGiayXacNhan", parent.MaGiayXacNhan);
            if (parent.TenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", parent.TenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            if (parent.SoTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienDaNhapNV", 0);

            cm.Parameters.AddWithValue("@SoTienDaNhapNVNgoaiDai", 0);

            cm.Parameters.AddWithValue("@SoTienConLai", 0);
         
            cm.Parameters.AddWithValue("@MaBoPhanGui", parent.MaDonViXacNhanDi);
            if (parent.TenDonViXacNhanDi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanGui", parent.TenDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanGui", DBNull.Value);
            cm.Parameters.AddWithValue("@MaBoPhanNhan", _maBoPhanDen);
            if (_tenBoPhanDen.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanNhan", _tenBoPhanDen);
            else
                cm.Parameters.AddWithValue("@TenBoPhanNhan", DBNull.Value);
            if (parent.MaChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", parent.MaChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (parent.TenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", parent.TenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLapGXN", parent.NgayLap);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Now.Date);

            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@TinhTrang", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@TrackingID", 0);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
        }
        private void AddUpdateParameters(SqlCommand cm, GiayXacNhanChuongTrinh parent)
		{
            if (_tenBoPhanDen.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanDen", _tenBoPhanDen);
            else
                cm.Parameters.AddWithValue("@TenBoPhanDen", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan", _maChiTietGiayXacNhan);
            if (parent.MaGiayXacNhan != 0)
                cm.Parameters.AddWithValue("@MaGiayXacNhan", parent.MaGiayXacNhan);
			else
				cm.Parameters.AddWithValue("@MaGiayXacNhan", DBNull.Value);
			if (_maBoPhanDen != 0)
				cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
			else
				cm.Parameters.AddWithValue("@MaBoPhanDen", DBNull.Value);
			
         
			
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
			
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			
            //if (_soTienConLai != 0)
            //    cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
            //else
            cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
            cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            if (_maBoPhanDi != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDi", parent.MaDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDi", DBNull.Value);
            if (parent.TenDonViXacNhanDi.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhanDi", parent.TenDonViXacNhanDi);
            else
                cm.Parameters.AddWithValue("@TenBoPhanDi", DBNull.Value);
            if (parent.TenGiayXacNhan.Length > 0)
                cm.Parameters.AddWithValue("@TenGiayXacNhan", parent.TenGiayXacNhan);
            else
                cm.Parameters.AddWithValue("@TenGiayXacNhan", DBNull.Value);
            cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
            cm.Parameters.AddWithValue("@KinhPhiBan", _kinhPhiBan);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_chiTietGiayXacNhan_NhanVienList.Update(tr, this);
           // _giayXacNhanTracking_List.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty ) return;
			if (IsNew) return;
                     
                        
            _chiTietGiayXacNhan_NhanVienList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maChiTietGiayXacNhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

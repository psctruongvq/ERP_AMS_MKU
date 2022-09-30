
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class HopDong : Csla.BusinessBase<HopDong>
	{
		#region Business Properties and Methods

		//declare members
		private long _maHopDong = 0;
		private string _maHopDongQL = string.Empty;
		private string _tenHopDong = string.Empty;
		private long _maDoiTac = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private SmartDate _tuNgay = new SmartDate(false);
		private SmartDate _ngayHetHan = new SmartDate(false);
        private long _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
		//private int _maNguoiLap = 0;
		private byte _tinhTrang = 0;
        //private string _dienThoai = string.Empty;
        private byte[] _flieDinhKem = new byte[0];
        private long _nguoiLienLac = 0;
        private long _maNguoiKy = 0;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private string _ghiChu = string.Empty;
        private byte _daThanhToan = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
			}
		}

		public string MaHopDongQL
		{
			get
			{
				CanReadProperty("MaHopDongQL", true);
				return _maHopDongQL;
			}
			set
			{
				CanWriteProperty("MaHopDongQL", true);
				if (value == null) value = string.Empty;
				if (!_maHopDongQL.Equals(value))
				{
					_maHopDongQL = value;
					PropertyHasChanged("MaHopDongQL");
				}
			}
		}

		public string TenHopDong
		{
			get
			{
				CanReadProperty("TenHopDong", true);
				return _tenHopDong;
			}
			set
			{
				CanWriteProperty("TenHopDong", true);
				if (value == null) value = string.Empty;
				if (!_tenHopDong.Equals(value))
				{
					_tenHopDong = value;
					PropertyHasChanged("TenHopDong");
				}
			}
		}

		public long MaDoiTac
		{
			get
			{
				CanReadProperty("MaDoiTac", true);
				return _maDoiTac;
			}
			set
			{
				CanWriteProperty("MaDoiTac", true);
				if (!_maDoiTac.Equals(value))
				{
					_maDoiTac = value;
					PropertyHasChanged("MaDoiTac");
				}
			}
		}

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty(true);
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime NgayHetHan
        {
            get
            {
                CanReadProperty(true);
                return _ngayHetHan.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayHetHan.Equals(value))
                {
                    _ngayHetHan = new SmartDate(value);
                    PropertyHasChanged();
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
					PropertyHasChanged("TinhTrang");
				}
			}
		}

        public byte[] FileDinhKem
        {
            get
            {
                CanReadProperty("FileDinhKem", true);
                return _flieDinhKem;
            }
            set
            {
                CanWriteProperty("FileDinhKem", true);
                if (!_flieDinhKem.Equals(value))
                {
                    _flieDinhKem = value;
                    PropertyHasChanged("FileDinhKem");
                }
            }
        }

        public long NguoiLienLac
        {
            get
            {
                CanReadProperty("NguoiLienLac", true);
                return _nguoiLienLac;
            }
            set
            {
                CanWriteProperty("NguoiLienLac", true);
                if (!_nguoiLienLac.Equals(value))
                {
                    _nguoiLienLac = value;
                    PropertyHasChanged("NguoiLienLac");
                }
            }
        }

        public long MaNguoiKy
        {
            get
            {
                CanReadProperty("MaNguoiKy", true);
                return _maNguoiKy;
            }
            set
            {
                CanWriteProperty("MaNguoiKy", true);
                if (!_maNguoiKy.Equals(value))
                {
                    _maNguoiKy = value;
                    PropertyHasChanged("MaNguoiKy");
                }
            }
        }

        public DateTime NgayKy
        {
            get
            {
                CanReadProperty(true);
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged();
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

        public byte DaThanhToan
        {
            get
            {
                CanReadProperty("DaThanhToan", true);
                return _daThanhToan;
            }
            set
            {
                CanWriteProperty("DaThanhToan", true);
                if (!_daThanhToan.Equals(value))
                {
                    _daThanhToan = value;
                    PropertyHasChanged("DaThanhToan");
                }
            }
        }
        
		protected override object GetIdValue()
		{
			return _maHopDong;
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
			// MaHopDongQL
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaHopDongQL");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaHopDongQL", 20));
            ////
            //// TenHopDong
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenHopDong");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHopDong", 500));
            ////
            //// NgayLap
            ////
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
			//TODO: Define authorization rules in HopDong
			//AuthorizationRules.AllowRead("MaHopDong", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("MaHopDongQL", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("TenHopDong", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("NgayHetHan", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("NgayHetHanString", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "HopDongReadGroup");
			//AuthorizationRules.AllowRead("TinhTrang", "HopDongReadGroup");

			//AuthorizationRules.AllowWrite("MaHopDongQL", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("TenHopDong", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHetHanString", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTrang", "HopDongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HopDongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HopDong()
		{ /* require use of factory method */ }

		public static HopDong NewHopDong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDong");
			return DataPortal.Create<HopDong>();
		}

		public static HopDong GetHopDong(long maHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HopDong");
			return DataPortal.Fetch<HopDong>(new Criteria(maHopDong));
		}

		public static void DeleteHopDong(long maHopDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDong");
			DataPortal.Delete(new Criteria(maHopDong));
		}

		public override HopDong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HopDong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HopDong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HopDong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HopDong NewHopDongChild()
		{
			HopDong child = new HopDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HopDong GetHopDong(SafeDataReader dr)
		{
			HopDong child =  new HopDong();
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
			public long MaHopDong;

			public Criteria(long maHopDong)
			{
				this.MaHopDong = maHopDong;
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
				catch(Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblHopDong";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        //FetchChildren(dr);
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
					ExecuteInsert(tr);

					//update child object(s)
					//UpdateChildren(tr);

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
					//UpdateChildren(tr);

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
			DataPortal_Delete(new Criteria(_maHopDong));
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
                cm.CommandText = "spd_DeletetblHopDong";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
			//FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maHopDong = dr.GetInt64("MaHopDong");
			_maHopDongQL = dr.GetString("MaHopDongQL");
			_tenHopDong = dr.GetString("TenHopDong");
			_maDoiTac = dr.GetInt64("MaDoiTac");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _ngayLap = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_ngayHetHan = dr.GetSmartDate("NgayHetHan", _ngayHetHan.EmptyIsMin);
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_tinhTrang = dr.GetByte("TinhTrang");
            _flieDinhKem = (byte[])dr["FileDinhKem"];
            _nguoiLienLac = dr.GetInt64("NguoiLienLac");
            _maNguoiKy = dr.GetInt64("MaNguoiKy");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _ghiChu = dr.GetString("GhiChu");
            _daThanhToan = dr.GetByte("DaThanhToan");
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
			//UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHopDong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHopDong = (long)cm.Parameters["@MaHopDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
			cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            if(_maDoiTac == 0)
			    cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else
                cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
            if(_maNguoiLap ==0 )
			    cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else 
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            //cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
            cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);            
			cm.Parameters["@MaHopDong"].Direction = ParameterDirection.Output;
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
			//UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHopDong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			cm.Parameters.AddWithValue("@MaHopDongQL", _maHopDongQL);
			cm.Parameters.AddWithValue("@TenHopDong", _tenHopDong);
            if(_maDoiTac ==0 )
			    cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
            else cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@NgayHetHan", _ngayHetHan.DBValue);
			cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
            //cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            cm.Parameters.AddWithValue("@FileDinhKem", _flieDinhKem);
            cm.Parameters.AddWithValue("@NguoiLienLac", _nguoiLienLac);
            cm.Parameters.AddWithValue("@DaThanhToan", _daThanhToan);
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

			ExecuteDelete(tr, new Criteria(_maHopDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

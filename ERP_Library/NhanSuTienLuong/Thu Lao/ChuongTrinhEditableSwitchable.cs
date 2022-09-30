//1
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class ChuongTrinh : Csla.BusinessBase<ChuongTrinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChuongTrinh = 0;
		private string _maQL = string.Empty;
		private string _tenChuongTrinh = string.Empty;
		private SmartDate _ngaySanXuat = new SmartDate(DateTime.Today);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.Today);
		private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private int _maChuongTrinhCha = 0;
        private string _tenChuongTrinhCha = string.Empty;
        private int _maNguon = 0;
        private string _tenNguon = string.Empty;
        private bool _hoanTat = false;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private bool _dungChung = false;
        private decimal _phanTramThueTNCN = 100;
        private int _maPhanCap = 1;

        
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChuongTrinh
		{
			get
			{
				CanReadProperty("MaChuongTrinh", true);
				return _maChuongTrinh;
			}
           
		}
        public int MaChuongTrinhCha
        {
            get
            {
                CanReadProperty("MaChuongTrinhCha", true);
                return _maChuongTrinhCha;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCha", true);
                if (!_maChuongTrinhCha.Equals(value))
                {
                    _maChuongTrinhCha = value;
                    PropertyHasChanged("MaChuongTrinhCha");
                }
            }
        }
        public int MaPhanCap
        {
            get { return _maPhanCap; }
            set { _maPhanCap = value; PropertyHasChanged("MaPhanCap"); }
        }
		public string MaQL
		{
			get
			{
				CanReadProperty("MaQL", true);
				return _maQL;
			}
			set
			{
				CanWriteProperty("MaQL", true);
				if (value == null) value = string.Empty;
				if (!_maQL.Equals(value))
				{
					_maQL = value;
					PropertyHasChanged("MaQL");
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

		public DateTime NgaySanXuat
		{
			get
			{
				CanReadProperty("NgaySanXuat", true);
				return _ngaySanXuat.Date;
			}
            set
            {
                CanWriteProperty("NgaySanXuat", true);
                if (!_ngaySanXuat.Equals(value))
                {
                    _ngaySanXuat = new SmartDate(value);
                    PropertyHasChanged("NgaySanXuat");
                }
            }
		}

	

		public DateTime NgayKetThuc
		{
			get
			{
				CanReadProperty("NgayKetThuc", true);
				return _ngayKetThuc.Date;
			}
            set
            {
                CanWriteProperty("NgayKetThuc", true);
                if (!_ngayKetThuc.Equals(value))
                {
                    _ngayKetThuc = new SmartDate(value);
                    PropertyHasChanged("NgayKetThuc");
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

        public string TenChuongTrinhCha
        {
            get
            {
                CanReadProperty("TenChuongTrinhCha", true);
                return _tenChuongTrinhCha;
                    
            }
            set
            {
                CanWriteProperty("TenChuongTrinhCha", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinhCha.Equals(value))
                {
                    _tenChuongTrinhCha = value;
                    PropertyHasChanged("TenChuongTrinhCha");
                }
            }
        }
        public int MaNguon
        {
            get
            {
                CanReadProperty("MaNguon", true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty("MaNguon", true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    _tenNguon = Nguon.GetNguon(_maNguon).TenNguon;
                    PropertyHasChanged("MaNguon");
                }
            }
        }
        public string TenNguon
        {
            get
            {                          
                return _tenNguon;

            }
            set
            {
                CanWriteProperty("TenNguon", true);
                if (value == null) value = string.Empty;
                if (!_tenNguon.Equals(value))
                {
                    _tenNguon = value;
                    PropertyHasChanged("TenNguon");
                }
            }
        }
        public bool HoanTat
        {
            get
            {
                CanReadProperty("HoanTat", true);
                return _hoanTat;
            }
            set
            {
                CanWriteProperty("HoanTat", true);
                if (!_hoanTat.Equals(value))
                {
                    _hoanTat = value;
                    PropertyHasChanged("HoanTat");
                }
            }
        }
        public bool DungChung
        {
            get
            {
                CanReadProperty("DungChung", true);
                return _dungChung;
            }
            set
            {
                CanWriteProperty("DungChung", true);
                if (!_dungChung.Equals(value))
                {
                    _dungChung = value;
                    PropertyHasChanged("DungChung");
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

        public decimal PhanTramThueTNCN
        {
            get
            {
                return _phanTramThueTNCN;
            }
            set
            {
                if (!_phanTramThueTNCN.Equals(value))
                {
                    _phanTramThueTNCN = value;
                    PropertyHasChanged();
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maChuongTrinh;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// MaQL
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 30));
            ////
            //// TenChuongTrinh
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 50));
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
			//TODO: Define authorization rules in ChuongTrinh
			//AuthorizationRules.AllowRead("MaChuongTrinh", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaQL", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("TenChuongTrinh", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgaySanXuat", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgaySanXuatString", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThuc", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucString", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ChuongTrinhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ChuongTrinhReadGroup");

			//AuthorizationRules.AllowWrite("MaQL", "ChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("TenChuongTrinh", "ChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySanXuatString", "ChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThucString", "ChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "ChuongTrinhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ChuongTrinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChuongTrinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuongTrinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChuongTrinh()
		{ /* require use of factory method */ }
        private ChuongTrinh(int maChuongTrinh, string tenChuongTrinh)
        { /* require use of factory method */
            this._maChuongTrinh = maChuongTrinh;
            this._tenChuongTrinh = tenChuongTrinh;
        }

        public static ChuongTrinh NewChuongTrinh( string tenChuongTrinh)
        {
            ChuongTrinh i = new ChuongTrinh();
            i._tenChuongTrinh = tenChuongTrinh;
            return i;
        }
		public static ChuongTrinh NewChuongTrinh()
		{
            ChuongTrinh item = new ChuongTrinh();
          //  item.MarkAsChild();
            item.MarkNew();
            return item;
		}

		public static ChuongTrinh GetChuongTrinh(int maChuongTrinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh");
			return DataPortal.Fetch<ChuongTrinh>(new Criteria(maChuongTrinh));
		}
        public static ChuongTrinh GetChuongTrinhByDNTT(long maPhieu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinh");
            return DataPortal.Fetch<ChuongTrinh>(new CriteriaByDNTT(maPhieu));
        }
		public static void DeleteChuongTrinh(int maChuongTrinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinh");
			DataPortal.Delete(new Criteria(maChuongTrinh));
		}
          public static ChuongTrinh ChuongTrinhList_Con(int hoanTat, int maCongTy,int maChuongTrinhCha)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChuongTrinhList");
            return DataPortal.Fetch<ChuongTrinh>(new FilterCriteriaByMaChuongTrinhCha(hoanTat, maCongTy, maChuongTrinhCha));
        }
       
		public override ChuongTrinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuongTrinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuongTrinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChuongTrinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChuongTrinh NewChuongTrinhChild()
		{
			ChuongTrinh child = new ChuongTrinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChuongTrinh GetChuongTrinh(SafeDataReader dr)
		{
			ChuongTrinh child =  new ChuongTrinh();
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
			public int MaChuongTrinh;

			public Criteria(int maChuongTrinh)
			{
				this.MaChuongTrinh = maChuongTrinh;
			}
		}
        private class CriteriaByDatabase
        {
            public int MaChuongTrinh;
            public int DatabaseNumber;
            public CriteriaByDatabase(int maChuongTrinh,int databaseNumber)
            {
                this.MaChuongTrinh = maChuongTrinh;
                this.DatabaseNumber = databaseNumber;
            }
        }

		#endregion //Criteria
        private class CriteriaByDNTT
        {
            public long MaPhieu;

            public CriteriaByDNTT(long maPhieu)
            {
                this.MaPhieu = maPhieu;
            }
        }
        private class FilterCriteriaByMaChuongTrinhCha
        {
            public int HoanTat;
            public int MaCongTy;
            public int MaChuongTrinhCha;
            public FilterCriteriaByMaChuongTrinhCha(int hoanTat, int maCongTy, int maChuongTrinhCha)
            {
                this.HoanTat = hoanTat;
                this.MaCongTy = maCongTy;
                this.MaChuongTrinhCha = maChuongTrinhCha;
            }
        }
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
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinh";
                    cm.Parameters.AddWithValue("@MaChuongTrinh",((Criteria) criteria).MaChuongTrinh);
                }
                else if (criteria is CriteriaByDNTT)
                {

                    cm.CommandText = "spd_LayChuongTrinhByDNTT";
                    cm.Parameters.AddWithValue("@MaPhieu", ((CriteriaByDNTT)criteria).MaPhieu);

                }
                else if (criteria is FilterCriteriaByMaChuongTrinhCha)
                {
                    cm.CommandText = "spd_SelecttblnsChuongTrinhByMaCha";
                    cm.Parameters.AddWithValue("@HoanTat", ((FilterCriteriaByMaChuongTrinhCha)criteria).HoanTat);
                    cm.Parameters.AddWithValue("@MaChuongTrinhCha", ((FilterCriteriaByMaChuongTrinhCha)criteria).MaChuongTrinhCha);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maChuongTrinh));
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
                cm.CommandText = "spd_DeletetblnsChuongTrinh";

				cm.Parameters.AddWithValue("@MaChuongTrinh", criteria.MaChuongTrinh);

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
		//	FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
            try
            {
                _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
                _maQL = dr.GetString("MaQL");
                _tenChuongTrinh = dr.GetString("TenChuongTrinh");
                _ngaySanXuat = dr.GetSmartDate("NgaySanXuat", _ngaySanXuat.EmptyIsMin);
                _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
                _maNguoiLap = dr.GetInt64("MaNguoiLap");
                _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
                _maChuongTrinhCha = dr.GetInt32("MaChuongTrinhCha");
                _tenChuongTrinhCha = dr.GetString("TenChuongTrinhCha");
                _maNguon = dr.GetInt32("MaNguon");
                _tenNguon = dr.GetString("TenNguon");
                _hoanTat = dr.GetBoolean("HoanTat");
                _maCongTy = dr.GetInt32("MaCongTy");
                _dungChung = dr.GetBoolean("DungChung");
                _phanTramThueTNCN = dr.GetDecimal("PhanTramThueTNCN");
                _maPhanCap = dr.GetInt32("MaPhanCap");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChuongTrinhList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChuongTrinh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChuongTrinh = (int)cm.Parameters["@MaChuongTrinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChuongTrinhList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQL.Length > 0)
				cm.Parameters.AddWithValue("@MaQL", _maQL);
			else
				cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgaySanXuat", _ngaySanXuat.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			cm.Parameters["@MaChuongTrinh"].Direction = ParameterDirection.Output;
            if (_maChuongTrinhCha != 0)
                cm.Parameters.AddWithValue("MaChuongTrinhCha", _maChuongTrinhCha);
            else
                cm.Parameters.AddWithValue("MaChuongTrinhCha", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);
            _tenNguon = Nguon.GetNguon(_maNguon).TenNguon;
            if (_tenNguon.Length > 0)
                cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            else
                cm.Parameters.AddWithValue("@TenNguon", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@PhanTramThueTNCN", _phanTramThueTNCN);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChuongTrinhList parent)
		{
			if (!IsDirty) return;
            if (_maNguoiLap != ERP_Library.Security.CurrentUser.Info.UserID)
                return;
			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, ChuongTrinhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChuongTrinh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChuongTrinhList parent)
		{
			cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			if (_maQL.Length > 0)
				cm.Parameters.AddWithValue("@MaQL", _maQL);
			else
				cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgaySanXuat", _ngaySanXuat.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maChuongTrinhCha != 0)
                cm.Parameters.AddWithValue("MaChuongTrinhCha", _maChuongTrinhCha);
            else
                cm.Parameters.AddWithValue("MaChuongTrinhCha", DBNull.Value);
            if (_maNguon != 0)
                cm.Parameters.AddWithValue("MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("MaNguon", DBNull.Value);
            _tenNguon = Nguon.GetNguon(_maNguon).TenNguon;
            if (_tenNguon.Length > 0)
                cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            else
                cm.Parameters.AddWithValue("@TenNguon", DBNull.Value);
            if (_hoanTat!=false)
                cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
            else
                cm.Parameters.AddWithValue("@HoanTat",false);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("MaCongTy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@PhanTramThueTNCN", _phanTramThueTNCN);
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
            if (_maNguoiLap != ERP_Library.Security.CurrentUser.Info.UserID )
                return;
			ExecuteDelete(tr, new Criteria(_maChuongTrinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

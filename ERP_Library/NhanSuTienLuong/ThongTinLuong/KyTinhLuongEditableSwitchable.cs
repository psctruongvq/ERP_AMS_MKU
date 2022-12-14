
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class KyTinhLuong : Csla.BusinessBase<KyTinhLuong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKy = 0;
		private string _tenKy = string.Empty;
		private SmartDate _ngayBatDau = new SmartDate(DateTime.Today);
		private SmartDate _ngayKetThuc = new SmartDate(DateTime.Today);
		private byte _thang = 0;
		private bool _khoaSo = false;
		private int _nam = 0;
    
        private bool _dungChung = false;
     
        private int _SoNgay = 0;
        private bool _KhoaSoKy1 = false;
        private bool _KhoaSoKy2 = false;
        private bool _TruThueTNCN = true;
        private bool _KhoaSoKy3 = false;
        private Nullable<DateTime> _ngayKhoaThuLao = null;
        private Nullable<int> _maKyChinh;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKy
		{
			get
			{
				CanReadProperty("MaKy", true);
				return _maKy;
			}
            set
            {
                CanWriteProperty("MaKy", true);
                if (!_maKy.Equals(value))
                {
                    _maKy = value;
                    PropertyHasChanged();
                }
            }
		}

		public string TenKy
		{
			get
			{
				CanReadProperty("TenKy", true);
				return _tenKy;
			}
			set
			{
				CanWriteProperty("TenKy", true);
				if (value == null) value = string.Empty;
				if (!_tenKy.Equals(value))
				{
					_tenKy = value;
					PropertyHasChanged("TenKy");
				}
			}

		}

		public DateTime NgayBatDau
		{
			get
			{
				CanReadProperty("NgayBatDau", true);
				return _ngayBatDau.Date;
			}
            set
            {
                CanWriteProperty("NgayBatDau", true);
                
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau = new SmartDate(value);
                    PropertyHasChanged("NgayBatDau");
                    CapNhatSoNgay();
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
                    CapNhatSoNgay();
                }
            }
		}

		public byte Thang
		{
			get
			{
				CanReadProperty("Thang", true);
				return _thang;
			}
			set
			{
				CanWriteProperty("Thang", true);
				if (!_thang.Equals(value))
				{
					_thang = value;
					PropertyHasChanged("Thang");
				}
			}
		}

		public bool KhoaSo
		{
			get
			{
				CanReadProperty("KhoaSo", true);
				return _khoaSo;
			}
			set
			{
				CanWriteProperty("KhoaSo", true);
				if (!_khoaSo.Equals(value))
				{
					_khoaSo = value;
					PropertyHasChanged("KhoaSo");
				}
			}
		}

		public int Nam
		{
			get
			{
				CanReadProperty("Nam", true);
				return _nam;
			}
			set
			{
				CanWriteProperty("Nam", true);
				if (!_nam.Equals(value))
				{
					_nam = value;
					PropertyHasChanged("Nam");
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

        public bool KhoaSoKy1
        {
            get
            {
                CanReadProperty();
                return _KhoaSoKy1;
            }
            set
            {
                CanWriteProperty();
                if (!_KhoaSoKy1.Equals(value))
                {
                    _KhoaSoKy1 = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool KhoaSoKy2
        {
            get
            {
                CanReadProperty();
                return _KhoaSoKy2;
            }
            set
            {
                CanWriteProperty();
                if (!_KhoaSoKy2.Equals(value))
                {
                    _KhoaSoKy2 = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool KhoaSoKy3
        {
            get
            {
                CanReadProperty();
                return _KhoaSoKy3;
            }
            set
            {
                CanWriteProperty();
                if (!_KhoaSoKy3.Equals(value))
                {
                    _KhoaSoKy3 = value;
                    PropertyHasChanged();
                }
            }
        }

        public int SoNgay
        {
            get
            {
                CanReadProperty();
                return _SoNgay;
            }
            set
            {
                CanWriteProperty();
                if (!_SoNgay.Equals(value))
                {
                    _SoNgay = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool TruThueTNCN
        {
            get
            {
                CanReadProperty();
                return _TruThueTNCN;
            }
            set
            {
                CanWriteProperty();
                if (!_TruThueTNCN.Equals(value))
                {
                    _TruThueTNCN = value;
                    PropertyHasChanged();
                }
            }
        }

        public Nullable<DateTime> NgayKhoaThuLao
        {
            get
            {
                return _ngayKhoaThuLao;
            }
            set
            {
                if (!_ngayKhoaThuLao.Equals(value))
                {
                    _ngayKhoaThuLao = value;
                    PropertyHasChanged();
                }
            }
        }

        public Nullable<int> MaKyChinh
        {
            get
            {
                return _maKyChinh;
            }
            set
            {
                if (!_maKyChinh.Equals(value))
                {
                    _maKyChinh = value;
                    PropertyHasChanged();
                }
            }
        }

        private void CapNhatSoNgay()
        {
            //kiểm tra ngày holiday
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = "Select Ngay From tblnsNgayHoliday";
            cm.CommandType = CommandType.Text;
            System.Collections.Generic.List<DateTime> d = new System.Collections.Generic.List<DateTime>();
            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            {
                while (dr.Read())
                {
                    d.Add(dr.GetDateTime("Ngay"));
                }
            }
            cn.Close();
            //không tính thứ 7 và chủ nhật
            int i = 0;
            if (_ngayBatDau.Date <= _ngayKetThuc.Date)
            {
                for (DateTime ngay = _ngayBatDau.Date; ngay <= _ngayKetThuc.Date; ngay = ngay.AddDays(1))
                {
                    if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!d.Contains(ngay))
                            i++;
                    }
                }
            }

            _SoNgay = i;
            PropertyHasChanged("SoNgay");
        }

		protected override object GetIdValue()
		{
			return _maKy;
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
			// TenKy
			//
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKy", 50));
			//
			// NgayBatDau
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayBatDauString");
			//
			// NgayKetThuc
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "NgayKetThucString");
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
			//TODO: Define authorization rules in KyTinhLuong
			//AuthorizationRules.AllowRead("MaKy", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("TenKy", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDau", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDauString", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThuc", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThucString", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("Thang", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("KhoaSo", "KyTinhLuongReadGroup");
			//AuthorizationRules.AllowRead("Nam", "KyTinhLuongReadGroup");

			//AuthorizationRules.AllowWrite("TenKy", "KyTinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayBatDauString", "KyTinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThucString", "KyTinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("Thang", "KyTinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("KhoaSo", "KyTinhLuongWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "KyTinhLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyTinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyTinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyTinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyTinhLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyTinhLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KyTinhLuong()
		{ /* require use of factory method */ }

		public static KyTinhLuong NewKyTinhLuong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyTinhLuong");
			return DataPortal.Create<KyTinhLuong>();
		}

		public static KyTinhLuong GetKyTinhLuong(int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyTinhLuong");
			return DataPortal.Fetch<KyTinhLuong>(new Criteria(maKy));
		}

        public static int KiemTraChuyenKhoan(int maKy)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraChuyenKhoan";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@KQ", 100);
                    cm.Parameters["@KQ"].Direction = ParameterDirection.Output;                 
                    cm.ExecuteNonQuery();
                    int kq = (int)cm.Parameters["@KQ"].Value;
                    return kq;


                }//using
            }
           
        }

        public static KyTinhLuong GetKyTinhLuong_Ngay(DateTime Ngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyTinhLuong");
            return DataPortal.Fetch<KyTinhLuong>(new Criteria_Ngay(Ngay));
        }

		public static void DeleteKyTinhLuong(int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyTinhLuong");
			DataPortal.Delete(new Criteria(maKy));
		}

		public override KyTinhLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyTinhLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyTinhLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KyTinhLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KyTinhLuong NewKyTinhLuongChild()
		{
			KyTinhLuong child = new KyTinhLuong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KyTinhLuong GetKyTinhLuong(SafeDataReader dr)
		{
			KyTinhLuong child =  new KyTinhLuong();
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
			public int MaKy;

			public Criteria(int maKy)
			{
				this.MaKy = maKy;
			}
		}

        [Serializable()]
        private class Criteria_Ngay
        {
            public DateTime Ngay;

            public Criteria_Ngay(DateTime ngay)
            {
                this.Ngay = ngay;
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
		private void DataPortal_Fetch(Object criteria)
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
				catch (Exception ex)
				{
                    throw ex;
                    tr.Rollback();
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsKyTinhLuong";

                    cm.Parameters.AddWithValue("@MaKy", ((Criteria)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);

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
                }
                else if (criteria is Criteria_Ngay)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsKyTinhLuong_Ngay";

                    cm.Parameters.AddWithValue("@Ngay", ((Criteria_Ngay)criteria).Ngay);

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
			DataPortal_Delete(new Criteria(_maKy));
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
                cm.CommandText = "spd_DeletetblnsKyTinhLuong";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
            _maKy = dr.GetInt32("MaKy");
            _tenKy = dr.GetString("TenKy");
            _ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
            _ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
            _thang = dr.GetByte("Thang");
            _khoaSo = dr.GetBoolean("KhoaSo");
            _nam = dr.GetInt32("Nam");
        
            _dungChung = dr.GetBoolean("DungChung");
        
            _KhoaSoKy1 = dr.GetBoolean("KhoaKy1");
            _KhoaSoKy2 = dr.GetBoolean("KhoaKy2");
            _TruThueTNCN = dr.GetBoolean("TruThueTNCN");
            _SoNgay = dr.GetInt32("SoNgay");
            _KhoaSoKy3 = dr.GetBoolean("KhoaKy3");
            object d = dr.GetValue("NgayKhoaThuLao");
            if (d == null)
                _ngayKhoaThuLao = null;
            else
                _ngayKhoaThuLao = Convert.ToDateTime(d);
            _maKyChinh = (Nullable<int>)dr.GetValue("MaKyChinh");
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
                cm.CommandText = "spd_InserttblnsKyTinhLuong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKy = (int)cm.Parameters["@MaKy"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TenKy", _tenKy);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
			cm.Parameters.AddWithValue("@Thang", _thang);
            cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);			
			
            cm.Parameters.AddWithValue("@Nam", _nam);
          	cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@SoNgay", _SoNgay);
            cm.Parameters.AddWithValue("@KhoaKy1", _KhoaSoKy1);
            cm.Parameters.AddWithValue("@KhoaKy2", _KhoaSoKy2);
            cm.Parameters.AddWithValue("@TruThueTNCN", _TruThueTNCN);
			cm.Parameters["@MaKy"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@KhoaKy3", _KhoaSoKy3);
            if (_ngayKhoaThuLao.HasValue)
                cm.Parameters.AddWithValue("@NgayKhoaThuLao", _ngayKhoaThuLao.Value);
            else
                cm.Parameters.AddWithValue("@NgayKhoaThuLao", DBNull.Value);
            if (_maKyChinh.HasValue)
                cm.Parameters.AddWithValue("@MaKyChinh", _maKyChinh.Value);
            else
                cm.Parameters.AddWithValue("@MaKyChinh", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
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
                cm.CommandText = "spd_UpdatetblnsKyTinhLuong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@TenKy", _tenKy);
            cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
            cm.Parameters.AddWithValue("@Thang", _thang);
            cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);

            cm.Parameters.AddWithValue("@Nam", _nam);
             cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@DungChung", _dungChung);
            cm.Parameters.AddWithValue("@SoNgay", _SoNgay);
            cm.Parameters.AddWithValue("@KhoaKy1", _KhoaSoKy1);
            cm.Parameters.AddWithValue("@KhoaKy2", _KhoaSoKy2);
            cm.Parameters.AddWithValue("@TruThueTNCN", _TruThueTNCN);
            cm.Parameters.AddWithValue("@KhoaKy3", _KhoaSoKy3);
            if (_ngayKhoaThuLao.HasValue)
                cm.Parameters.AddWithValue("@NgayKhoaThuLao", _ngayKhoaThuLao.Value);
            else
                cm.Parameters.AddWithValue("@NgayKhoaThuLao", DBNull.Value);
            if (_maKyChinh.HasValue)
                cm.Parameters.AddWithValue("@MaKyChinh", _maKyChinh.Value);
            else
                cm.Parameters.AddWithValue("@MaKyChinh", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
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

			ExecuteDelete(tr, new Criteria(_maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

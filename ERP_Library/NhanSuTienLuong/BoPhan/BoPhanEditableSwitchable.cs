//
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] ///
	public class BoPhan : Csla.BusinessBase<BoPhan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBoPhan = 0;
		private string _maBoPhanQL = string.Empty;
		private string _tenBoPhan = string.Empty;
		private SmartDate _ngayTao = new SmartDate(false);
		private int _maBoPhanCha = 0;
		private int _maLoaiBoPhan = 0;
		private int _maCongTy = 0;
      
        private bool _KhongTinhLuong = false;
        private bool _KhauHaoHaoMon = false;
        private int _maPhanCap = 0;
        private bool _chon = false;
        private int _taiKhoanKHHM = 0;
        private int _taiKhoanPBCP = 0;//bo sung 05/11/2020
        public bool Chon
        {
            get { return _chon; }
            set { _chon = value; }
        }

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBoPhan
		{
			get
			{
				CanReadProperty("MaBoPhan", true);
				return _maBoPhan;
			}
		}

		public string MaBoPhanQL
		{
			get
			{
				CanReadProperty("MaBoPhanQL", true);
				return _maBoPhanQL;
			}
			set
			{
				CanWriteProperty("MaBoPhanQL", true);
				if (value == null) value = string.Empty;
				if (!_maBoPhanQL.Equals(value))
				{
					_maBoPhanQL = value;
					PropertyHasChanged("MaBoPhanQL");
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

		public DateTime NgayTao
		{
			get
			{
				CanReadProperty("NgayTao", true);
				return _ngayTao.Date;
			}
            set
            {
                CanWriteProperty("NgayTao", true);
                if (!_ngayTao.Equals(value))
                {
                    _ngayTao = new SmartDate(value);
                    PropertyHasChanged("NgayTao");
                }
            }
		}

		public int MaBoPhanCha
		{
			get
			{
				CanReadProperty("MaBoPhanCha", true);
				return _maBoPhanCha;
			}
			set
			{
				CanWriteProperty("MaBoPhanCha", true);
				if (!_maBoPhanCha.Equals(value))
				{
					_maBoPhanCha = value;
					PropertyHasChanged("MaBoPhanCha");
				}
			}
		}

		public int MaLoaiBoPhan
		{
			get
			{
				CanReadProperty("MaLoaiBoPhan", true);
				return _maLoaiBoPhan;
			}
			set
			{
				CanWriteProperty("MaLoaiBoPhan", true);
				if (!_maLoaiBoPhan.Equals(value))
				{
					_maLoaiBoPhan = value;
					PropertyHasChanged("MaLoaiBoPhan");
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

        public int TaiKhoanKHHM
        {
            get
            {
                CanReadProperty("TaiKhoanKHHM", true);
                return _taiKhoanKHHM;
            }
            set
            {
                CanWriteProperty("TaiKhoanKHHM", true);
                if (!_taiKhoanKHHM.Equals(value))
                {
                    _taiKhoanKHHM = value;
                    PropertyHasChanged("TaiKhoanKHHM");
                }
            }
        }
        // bo sung 05/11/2020
        public int TaiKhoanPBCP
        {
            get
            {
                CanReadProperty("TaiKhoanPBCP", true);
                return _taiKhoanPBCP;
            }
            set
            {
                CanWriteProperty("TaiKhoanPBCP", true);
                if (!_taiKhoanPBCP.Equals(value))
                {
                    _taiKhoanPBCP = value;
                    PropertyHasChanged("TaiKhoanPBCP");
                }
            }
        }

        public bool KhongTinhLuong
        {
            get
            {
                CanReadProperty("KhongTinhLuong", true);
                return _KhongTinhLuong;
            }
            set
            {
                CanWriteProperty("KhongTinhLuong", true);
                if (!_KhongTinhLuong.Equals(value))
                {
                    _KhongTinhLuong = value;
                    PropertyHasChanged("KhongTinhLuong");
                }
            }
        }

        public bool KhauHaoHaoMon
        {
            get
            {
                CanReadProperty("KhauHaoHaoMon", true);
                return _KhauHaoHaoMon;
            }
            set
            {
                CanWriteProperty("KhauHaoHaoMon", true);
                if (!_KhauHaoHaoMon.Equals(value))
                {
                    _KhauHaoHaoMon = value;
                    PropertyHasChanged("KhauHaoHaoMon");
                }
            }
        }
        public int MaPhanCap
        {
            get
            {
                CanReadProperty("MaPhanCap", true);
                return _maPhanCap;
            }
            set
            {
                CanWriteProperty("MaPhanCap", true);
                if (!_maPhanCap.Equals(value))
                {
                    _maPhanCap = value;
                    PropertyHasChanged("MaPhanCap");
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maBoPhan;
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
            // MaBoPhanQL
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaBoPhanQL");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaBoPhanQL", 50));
            //
            // TenBoPhan
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "TenBoPhan");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
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
			//TODO: Define authorization rules in BoPhan
			//AuthorizationRules.AllowRead("MaBoPhan", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanQL", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhan", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanCha", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiBoPhan", "BoPhanReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "BoPhanReadGroup");

			//AuthorizationRules.AllowWrite("MaBoPhanQL", "BoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhan", "BoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTaoString", "BoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanCha", "BoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiBoPhan", "BoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "BoPhanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhan()
		{ /* require use of factory method */ }
        private BoPhan(string Ten)
        {
            this.TenBoPhan = Ten;
        }

		public static BoPhan NewBoPhan()
		{
            BoPhan i = new BoPhan();
            i.MarkAsChild();
            return i;
		}

        public static BoPhan NewBoPhanDocLap()
        {
            BoPhan i = new BoPhan();
            return i;
        }
        public static BoPhan NewBoPhan(int maBoPhan,string TenBoPhan)
        {
            return new BoPhan(TenBoPhan);
        }

        public static BoPhan NewBoPhan( string TenBoPhan)
        {
            return new BoPhan(TenBoPhan);
        }
        public static BoPhan GetBoPhanKeCaBoPhanMoRong(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new CriteriaKeCaBoPhanMoRong(maBoPhan));
        }
		public static BoPhan GetBoPhan(int maBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhan");
			return DataPortal.Fetch<BoPhan>(new Criteria(maBoPhan));
		}

        public static BoPhan GetBoPhan(string maBoPhanQL)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhan");
			return DataPortal.Fetch<BoPhan>(new Criteria_MaBoPhanQL(maBoPhanQL));
		}
        //public static BoPhan GetBoPhan(string maBoPhanQL)
        //{
        //    if (!CanGetObject())
        //        throw new System.Security.SecurityException("User not authorized to view a BoPhan");
        //    return DataPortal.Fetch<BoPhan>(new Criteria(maBoPhanQL));
        //}
        public static BoPhan GetBoPhanCha(int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new CriteriaByCha(maBoPhan));
        }
        public static BoPhan GetBoPhan_LoaiBoPhan(int maLoaiBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new Criteria_LoaiBoPhan(maLoaiBoPhan));
        }
        public static BoPhan GetBoPhan_NhanVien(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new Criteria_BoPhanNhanVien(maNhanVien));
        }
        public static BoPhan GetBoPhan_TenBoPhan(string tenBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new Criteria_TenBoPhan(tenBoPhan));
        }
        public static BoPhan GetBoPhan_MaBoPhanQL(string MaBoPhanQL)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Fetch<BoPhan>(new Criteria_MaBoPhanQL(MaBoPhanQL));
        }
        public static BoPhan Update(BoPhan bp)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BoPhan");
            return DataPortal.Update<BoPhan>(bp);
        }
        public static void DinhViBoPhan(int maBoPhan,int maBoPhanCha, int maLoaiBoPhan)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_DinhViBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    if(maBoPhanCha!=0)
                    cm.Parameters.AddWithValue("@MaBoPhanCha", maBoPhanCha);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhanCha", DBNull.Value);
                    cm.Parameters.AddWithValue("@MaLoaiBoPhan", maLoaiBoPhan);
                    cm.ExecuteNonQuery();
                }

            }
        }
		public static void DeleteBoPhan(int maBoPhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhan");
			DataPortal.Delete(new Criteria(maBoPhan));
		}
        
		public override BoPhan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoPhan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BoPhan NewBoPhanChild()
		{
			BoPhan child = new BoPhan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoPhan GetBoPhan(SafeDataReader dr)
		{
			BoPhan child =  new BoPhan();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class CriteriaKeCaBoPhanMoRong
		{
			public int MaBoPhan = 0;

            public CriteriaKeCaBoPhanMoRong(int maBoPhan)
			{
				this.MaBoPhan = maBoPhan;
			}
          
		}
        [Serializable()]
        private class Criteria
        {
            public int MaBoPhan = 0;

            public Criteria(int maBoPhan)
            {
                this.MaBoPhan = maBoPhan;
            }

        }
        [Serializable()]
        private class CriteriaByCha
		{
			public int MaBoPhan;

            public CriteriaByCha(int maBoPhan)
			{
				this.MaBoPhan = maBoPhan;
			}
		}
      
        [Serializable()]
        private class Criteria_BoPhanNhanVien
        {
            public long MaNhanVien;

            public Criteria_BoPhanNhanVien(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
            }
        }
        [Serializable()]
        private class Criteria_LoaiBoPhan
        {
            public int MaLoaiBoPhan;

            public Criteria_LoaiBoPhan(int maLoaiBoPhan)
            {
                this.MaLoaiBoPhan = maLoaiBoPhan;
            }
        }

        [Serializable()]
        private class Criteria_TenBoPhan
        {
            public string TenBoPhan;

            public Criteria_TenBoPhan(string tenBoPhan)
            {
                this.TenBoPhan = tenBoPhan;
            }
        }
    
		#endregion //Criteria

        [Serializable()]
        private class Criteria_MaBoPhanQL
        {
            public string MaBoPhanQL;

            public Criteria_MaBoPhanQL(string maBoPhanQL)
            {
                this.MaBoPhanQL = maBoPhanQL;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is CriteriaKeCaBoPhanMoRong)//cuong
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelectBoPhan";

                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaKeCaBoPhanMoRong)criteria).MaBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            FetchObject(dr);
                            // ValidationRules.CheckRules();
                            //load child object(s)
                            FetchChildren(dr);
                        }
                    }
                }
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan";

                    cm.Parameters.AddWithValue("@MaBoPhan", ((Criteria)criteria).MaBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        if (dr.Read())
                        {
                            FetchObject(dr);
                            // ValidationRules.CheckRules();
                            //load child object(s)
                            FetchChildren(dr);
                        }
                    }
                }
                else if (criteria is CriteriaByCha)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhanByBoPhanCha";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((CriteriaByCha)criteria).MaBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();
                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
                else if (criteria is Criteria_TenBoPhan)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[sp_SelecttblnsBoPhan_By_TenBoPhan]";

                    cm.Parameters.AddWithValue("@TenBoPhan", ((Criteria_TenBoPhan)criteria).TenBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }

                else if (criteria is Criteria_BoPhanNhanVien)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetBoPhanByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((Criteria_BoPhanNhanVien)criteria).MaNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                    }
                }
                else if (criteria is Criteria_LoaiBoPhan)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_SelecttblnsBoPhan_LoaiBoPhan";

                    cm.Parameters.AddWithValue("@MaLoaiBoPhan", ((Criteria_LoaiBoPhan)criteria).MaLoaiBoPhan);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                } 
                else if(criteria is Criteria_MaBoPhanQL)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "sp_SelecttblnsBoPhanByMaBoPhanQL";
                    cm.CommandText = "spd_GetBoPhanByMaBoPhanQL";
                    cm.Parameters.AddWithValue("@MaBoPhanQL", ((Criteria_MaBoPhanQL)criteria).MaBoPhanQL);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
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
			DataPortal_Delete(new Criteria(_maBoPhan));
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
                cm.CommandText = "sp_DeletetblnsBoPhan";

				cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

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
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maBoPhanQL = dr.GetString("MaBoPhanQL");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
			_maBoPhanCha = dr.GetInt32("MaBoPhanCha");
			_maLoaiBoPhan = dr.GetInt32("MaLoaiBoPhan");
			_maCongTy = dr.GetInt32("MaCongTy");        
            _KhongTinhLuong = dr.GetBoolean("KhongTinhLuong");
            _KhauHaoHaoMon= dr.GetBoolean("KhauHaoHaoMon");
            _maPhanCap = dr.GetInt32("MaPhanCap");
            _taiKhoanPBCP = dr.GetInt32("TaiKhoanPBCP");
            _taiKhoanKHHM = dr.GetInt32("TaiKhoanKHHM");
            _chon = false;
		}
        
		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, BoPhanList parent)
		{
			if (!IsDirty) return;
			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, BoPhanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsBoPhan";

				AddInsertParameters(cm, parent);
				cm.ExecuteNonQuery();

				_maBoPhan = (int)cm.Parameters["@MaBoPhan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BoPhanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			if (_maBoPhanCha != 0)
				cm.Parameters.AddWithValue("@MaBoPhanCha", _maBoPhanCha);
			else
				cm.Parameters.AddWithValue("@MaBoPhanCha", DBNull.Value);
			if (_maLoaiBoPhan != 0)
				cm.Parameters.AddWithValue("@MaLoaiBoPhan", _maLoaiBoPhan);
			else
				cm.Parameters.AddWithValue("@MaLoaiBoPhan", DBNull.Value);
			if (_maCongTy != 0)
				cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			else
				cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);            
       
            cm.Parameters.AddWithValue("@KhauHaoHaoMon", _KhauHaoHaoMon);
            cm.Parameters.AddWithValue("@KhongTinhLuong", _KhongTinhLuong);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters["@MaBoPhan"].Direction = ParameterDirection.Output;
            if (_maPhanCap != 0)
                cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            else
                cm.Parameters.AddWithValue("@MaPhanCap", DBNull.Value);
            if (_taiKhoanKHHM != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKHHM", _taiKhoanKHHM);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKHHM", DBNull.Value);
            // bo sung 05/11/2020
            if (_taiKhoanPBCP != 0)
                cm.Parameters.AddWithValue("@TaiKhoanPBCP", _taiKhoanPBCP);
            else
                cm.Parameters.AddWithValue("@TaiKhoanPBCP", DBNull.Value);
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, BoPhanList parent)
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

		private void ExecuteUpdate(SqlConnection cn, BoPhanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsBoPhan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}
        public static void UpdateBoPhan(int maBoPhan,string maQLBP,string tenBoPhan,DateTime ngayTao,int maLoaiBoPhan,int maCongTy, bool KhongTinhLuong,int maPhanCap, int taiKhoanKHHM)
        {

            using (SqlConnection cnn = new SqlConnection(Database.ERP_Connection))
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                using (SqlCommand cm = cnn.CreateCommand())
                {
                    SqlParameter param ;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_UpdatetblnsBoPhan1";
                    param = cm.Parameters.Add("@MaBoPhan",SqlDbType.Int);
                    param.Value = maBoPhan;
                    param = cm.Parameters.Add("@MaBoPhanQL",SqlDbType.NVarChar);
                    param.Value = maQLBP;
                    param = cm.Parameters.Add("@TenBoPhan", SqlDbType.NVarChar);
                    param.Value = tenBoPhan;
                    param = cm.Parameters.Add("@NgayTao", SqlDbType.DateTime);
                    param.Value = ngayTao;
                    param = cm.Parameters.Add("@MaLoaiBoPhan", SqlDbType.Int);
                    param.Value = maLoaiBoPhan;
                    param = cm.Parameters.Add("@MaCongTy", SqlDbType.Int);
                    param.Value =maCongTy;
                    //param = cm.Parameters.Add("@TangCaGianCa", SqlDbType.TinyInt);
                    //param.Value = tangCaGianCa;
                    cm.Parameters.AddWithValue("@KhongTinhLuong", KhongTinhLuong);                   
                    //param = cm.Parameters.Add("@SoGioTangCa", SqlDbType.Decimal);
                    //param.Value = soGioTangCa;
                    //param = cm.Parameters.Add("@SoGioGianCa", SqlDbType.Decimal);
                    if (maPhanCap != 0)
                        cm.Parameters.AddWithValue("@MaPhanCap", maPhanCap);
                    else
                        cm.Parameters.AddWithValue("@MaPhanCap", DBNull.Value);
                    if (taiKhoanKHHM != 0)
                        cm.Parameters.AddWithValue("@TaiKhoanKHHM", taiKhoanKHHM);
                    else
                        cm.Parameters.AddWithValue("@TaiKhoanKHHM", DBNull.Value);
                    cm.ExecuteNonQuery();
                    cnn.Close();
                }//using
            }           
           
        }
		private void AddUpdateParameters(SqlCommand cm, BoPhanList parent)
		{
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			if (_maBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaBoPhanQL", _maBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaBoPhanQL", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
            if (_maBoPhanCha != 0)
                cm.Parameters.AddWithValue("@MaBoPhanCha", _maBoPhanCha);
            else
                cm.Parameters.AddWithValue("@MaBoPhanCha", DBNull.Value);
            if (_maLoaiBoPhan != 0)
				cm.Parameters.AddWithValue("@MaLoaiBoPhan", _maLoaiBoPhan);
			else
				cm.Parameters.AddWithValue("@MaLoaiBoPhan", DBNull.Value);
			if (_maCongTy != 0)
				cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			else
				cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
          
            cm.Parameters.AddWithValue("@KhongTinhLuong", _KhongTinhLuong);
            cm.Parameters.AddWithValue("@KhauHaoHaoMon", _KhauHaoHaoMon);
            if (_maPhanCap != 0)
                cm.Parameters.AddWithValue("@MaPhanCap", _maPhanCap);
            else
                cm.Parameters.AddWithValue("@MaPhanCap", DBNull.Value);
            if (_taiKhoanKHHM != 0)
                cm.Parameters.AddWithValue("@TaiKhoanKHHM", _taiKhoanKHHM);
            else
                cm.Parameters.AddWithValue("@TaiKhoanKHHM", DBNull.Value);
            // bo sung 05/11/2020
            if (_taiKhoanPBCP != 0)
                cm.Parameters.AddWithValue("@TaiKhoanPBCP", _taiKhoanPBCP);
            else
                cm.Parameters.AddWithValue("@TaiKhoanPBCP", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maBoPhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
	}
}

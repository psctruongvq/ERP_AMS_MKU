
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KiemKeTonKho : Csla.BusinessBase<KiemKeTonKho>
	{
		#region Business Properties and Methods

		//declare members
		private long _maKiemKe = 0;
		private string _soPhieu = string.Empty;
		private int _maKy = 0;
		private long _maNhanVien = 0;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _maNguoiLap = 0;
		private int _maKho = 0;
		private string _dienGiai = string.Empty;
        

		//declare child member(s)
		private CT_KiemKeTonKhoList _cT_KiemKeTonKhoList = CT_KiemKeTonKhoList.NewCT_KiemKeTonKhoList();

        [System.ComponentModel.DataObjectField(true, true)]
       
		public long MaKiemKe
		{
			get
			{
				CanReadProperty("MaKiemKe", true);
				return _maKiemKe;
			}
		}

		public string SoPhieu
		{
			get
			{
				CanReadProperty("SoPhieu", true);
				return _soPhieu;
			}
			set
			{
				CanWriteProperty("SoPhieu", true);
				if (value == null) value = string.Empty;
				if (!_soPhieu.Equals(value))
				{
					_soPhieu = value;
					PropertyHasChanged("SoPhieu");
				}
			}
		}

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
					PropertyHasChanged("MaKy");
				}
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
                _ngayLap = new SmartDate(value);

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

		public CT_KiemKeTonKhoList CT_KiemKeTonKhoList
		{
			get
			{
				CanReadProperty("CT_KiemKeTonKhoList", true);
				return _cT_KiemKeTonKhoList;
			}
            set
            {
                CanWriteProperty("CT_KiemKeTonKhoList", true);

                if (!_cT_KiemKeTonKhoList.Equals(value))
                {
                    _cT_KiemKeTonKhoList = value;
                    PropertyHasChanged("CT_KiemKeTonKhoList");
                }
            }
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_KiemKeTonKhoList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_KiemKeTonKhoList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maKiemKe;
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
			// SoPhieu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoPhieu", 50));
			//
			// NgayLap
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in KiemKeTonKho
			//AuthorizationRules.AllowRead("CT_KiemKeTonKhoList", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKiemKe", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("SoPhieu", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKho", "KiemKeTonKhoReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "KiemKeTonKhoReadGroup");

			//AuthorizationRules.AllowWrite("SoPhieu", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaKy", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaKho", "KiemKeTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "KiemKeTonKhoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KiemKeTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KiemKeTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KiemKeTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KiemKeTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KiemKeTonKhoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KiemKeTonKho()
		{ /* require use of factory method */ }

		public static KiemKeTonKho NewKiemKeTonKho()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KiemKeTonKho");
			return DataPortal.Create<KiemKeTonKho>();
		}

        public static KiemKeTonKho NewKiemKeTonKho(int maKho, int maKy)
        {

            KiemKeTonKho kiemKeTonKho = new KiemKeTonKho();
            kiemKeTonKho.MaKho = maKho;
            kiemKeTonKho.MaKy = maKy;
            kiemKeTonKho.CT_KiemKeTonKhoList = CT_KiemKeTonKhoList.GetCT_KiemKeTonKhoList(maKho, maKy);

            return kiemKeTonKho;
                 
        }

		public static KiemKeTonKho GetKiemKeTonKho(long maKiemKe)
		{            
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KiemKeTonKho");
			return DataPortal.Fetch<KiemKeTonKho>(new Criteria(maKiemKe));
		}

        public static KiemKeTonKho GetKiemKeTonKho(int maKho, int maKy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KiemKeTonKho");
            return DataPortal.Fetch<KiemKeTonKho>(new Criteria(maKho,maKy));
        }

		public static void DeleteKiemKeTonKho(long maKiemKe)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KiemKeTonKho");
			DataPortal.Delete(new Criteria(maKiemKe));
		}

		public override KiemKeTonKho Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KiemKeTonKho");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KiemKeTonKho");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KiemKeTonKho");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KiemKeTonKho NewKiemKeTonKhoChild()
		{
			KiemKeTonKho child = new KiemKeTonKho();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        internal static KiemKeTonKho GetKiemKeTonKho(SafeDataReader dr)
        {
            KiemKeTonKho child = new KiemKeTonKho();
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
			public long MaKiemKe;

			public Criteria(long maKiemKe)
			{
				this.MaKiemKe = maKiemKe;
			}

            public int MaKho;
            public int MaKy;
            public Criteria(int maKho, int maKy)
            {
                this.MaKho = maKho;
                this.MaKy = maKy;
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
                cm.CommandText = "spd_SelecttblKiemKeTonKho";

                cm.Parameters.AddWithValue("@MaKiemKe", criteria.MaKiemKe);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					//FetchChildren(dr);            
                    if (criteria.MaKiemKe != 0)
                        FetchChildren(criteria.MaKiemKe);
                    else
                        FetchChildren(criteria.MaKho, criteria.MaKy);
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
			DataPortal_Delete(new Criteria(_maKiemKe));
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
                    _cT_KiemKeTonKhoList.Clear();
                    _cT_KiemKeTonKhoList.Update(tr, this);
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
                cm.CommandText = "spd_DeletetblKiemKeTonKho";

				cm.Parameters.AddWithValue("@MaKiemKe", criteria.MaKiemKe);

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
			//FetchChildren(dr);            
            if (_maKiemKe != 0)
                FetchChildren(_maKiemKe);
            else
                FetchChildren(_maKho, _maKy);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maKiemKe = dr.GetInt64("MaKiemKe");
			_soPhieu = dr.GetString("SoPhieu");
			_maKy = dr.GetInt32("MaKy");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
			_maKho = dr.GetInt32("MaKho");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}

        private void FetchChildren(long maKiemKe)
        {
            _cT_KiemKeTonKhoList = CT_KiemKeTonKhoList.GetCT_KiemKeTonKhoList(maKiemKe);
        }
        
        private void FetchChildren(int maKho, int maKy)
		{
            _cT_KiemKeTonKhoList = CT_KiemKeTonKhoList.GetCT_KiemKeTonKhoList(maKho, maKy);
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
                cm.CommandText = "spd_InserttblKiemKeTonKho";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKiemKe = (long)cm.Parameters["@MaKiemKe"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_soPhieu.Length > 0)
				cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
			else
				cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);  
			if (_maKho != 0)
				cm.Parameters.AddWithValue("@MaKho", _maKho);
			else
				cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKiemKe", _maKiemKe);
			cm.Parameters["@MaKiemKe"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKiemKeTonKho";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKiemKe", _maKiemKe);
			if (_soPhieu.Length > 0)
				cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
			else
				cm.Parameters.AddWithValue("@SoPhieu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);  
			if (_maKho != 0)
				cm.Parameters.AddWithValue("@MaKho", _maKho);
			else
				cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_KiemKeTonKhoList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _cT_KiemKeTonKhoList.Clear();
            _cT_KiemKeTonKhoList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_maKiemKe));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        #region Set So Phieu
        public static string SetSoChungTu(DateTime _ngayLap)
        {
            string _soChungTu = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SetSoChungTuKiemKeTonKho";
                    cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.VarChar, 50);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _soChungTu = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return _soChungTu;
        }
        public static bool CheckSoPhieuKiemKe(long _maKiemKe, string _soPhieu, bool _laMoi)
        {
            bool Kt = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraSoPhieuKiemKeTrung";
                    cm.Parameters.AddWithValue("@MaKiemKe", _maKiemKe);
                    cm.Parameters.AddWithValue("@SoPhieu", _soPhieu);
                    cm.Parameters.AddWithValue("@LaMoi", _laMoi);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    Kt = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return Kt;

        }
        #endregion 

	}
}

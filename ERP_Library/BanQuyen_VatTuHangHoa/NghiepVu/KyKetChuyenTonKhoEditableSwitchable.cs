
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//12/06/2014
namespace ERP_Library
{ 
	[Serializable()] 
	public class KyKetChuyenTonKho : Csla.BusinessBase<KyKetChuyenTonKho>
	{
		#region Business Properties and Methods

		//declare members
		private long _maKetChuyen = 0;
		private int _maKho = 0;
		private int _maKy = 0;
		private string _dienGiai = string.Empty;
		private long _nguoiLap = 0;
		private SmartDate _ngayKetChuyen = new SmartDate(false);

		//declare child member(s)
		private CT_KetChuyenTonKhoList _cT_KetChuyenTonKhoList = CT_KetChuyenTonKhoList.NewCT_KetChuyenTonKhoList();

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaKetChuyen
		{
			get
			{
				CanReadProperty("MaKetChuyen", true);
				return _maKetChuyen;
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

		public long NguoiLap
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

		public DateTime NgayKetChuyen
		{
			get
			{
				CanReadProperty("NgayKetChuyen", true);
				return _ngayKetChuyen.Date;
			}
		}

		public string NgayKetChuyenString
		{
			get
			{
				CanReadProperty("NgayKetChuyenString", true);
				return _ngayKetChuyen.Text;
			}
			set
			{
				CanWriteProperty("NgayKetChuyenString", true);
				if (value == null) value = string.Empty;
				if (!_ngayKetChuyen.Equals(value))
				{
					_ngayKetChuyen.Text = value;
					PropertyHasChanged("NgayKetChuyenString");
				}
			}
		}

		public CT_KetChuyenTonKhoList CT_KetChuyenTonKhoList
		{
			get
			{
				CanReadProperty("CT_KetChuyenTonKhoList", true);
				return _cT_KetChuyenTonKhoList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _cT_KetChuyenTonKhoList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _cT_KetChuyenTonKhoList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maKetChuyen;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
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
			//TODO: Define authorization rules in KyKetChuyenTonKho
			//AuthorizationRules.AllowRead("CT_KetChuyenTonKhoList", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKetChuyen", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKho", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("NgayKetChuyen", "KyKetChuyenTonKhoReadGroup");
			//AuthorizationRules.AllowRead("NgayKetChuyenString", "KyKetChuyenTonKhoReadGroup");

			//AuthorizationRules.AllowWrite("MaKho", "KyKetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("MaKy", "KyKetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "KyKetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "KyKetChuyenTonKhoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetChuyenString", "KyKetChuyenTonKhoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KyKetChuyenTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KyKetChuyenTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KyKetChuyenTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KyKetChuyenTonKho
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KyKetChuyenTonKhoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods

		private KyKetChuyenTonKho()
		{ /* require use of factory method */ }

		public static KyKetChuyenTonKho NewKyKetChuyenTonKho()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyKetChuyenTonKho");
			return DataPortal.Create<KyKetChuyenTonKho>();
		}

		public static KyKetChuyenTonKho GetKyKetChuyenTonKho(long maKetChuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KyKetChuyenTonKho");
			return DataPortal.Fetch<KyKetChuyenTonKho>(new Criteria(maKetChuyen));
		}

        public static KyKetChuyenTonKho GetKyKetChuyenTonKho(int maKy, int maKho)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a KyKetChuyenTonKho");
            return DataPortal.Fetch<KyKetChuyenTonKho>(new CriteriaByKyAndKho(maKy, maKho));
        }

		public static void DeleteKyKetChuyenTonKho(long maKetChuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyKetChuyenTonKho");
			DataPortal.Delete(new Criteria(maKetChuyen));
		}

		public override KyKetChuyenTonKho Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KyKetChuyenTonKho");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KyKetChuyenTonKho");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KyKetChuyenTonKho");

			return base.Save();
		}

        public static KyKetChuyenTonKho NewKyKetChuyenTonKho(int maKy, int maKho)
        {
            KyKetChuyenTonKho _kyKetChuyenTonKho = new KyKetChuyenTonKho();
            _kyKetChuyenTonKho.MaKy = maKy;
            _kyKetChuyenTonKho.MaKho = maKho;
            _kyKetChuyenTonKho._cT_KetChuyenTonKhoList = CT_KetChuyenTonKhoList.GetCT_KetChuyenTonKhoList(maKho);
            return _kyKetChuyenTonKho;

        }

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KyKetChuyenTonKho NewKyKetChuyenTonKhoChild()
		{
			KyKetChuyenTonKho child = new KyKetChuyenTonKho();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KyKetChuyenTonKho GetKyKetChuyenTonKho(SafeDataReader dr)
		{
			KyKetChuyenTonKho child =  new KyKetChuyenTonKho();
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
			public long MaKetChuyen;

			public Criteria(long maKetChuyen)
			{
				this.MaKetChuyen = maKetChuyen;
			}
		}

        private class CriteriaByKyAndKho
        {
            public int MaKy;
            public int MaKho;

            public CriteriaByKyAndKho(int maKy, int maKho)
            {
                this.MaKy = maKy;
                this.MaKho = maKho;
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
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenTonKho";
                    cm.Parameters.AddWithValue("@MaKetChuyen", ((Criteria)criteria).MaKetChuyen);
                    cm.Parameters.AddWithValue("@MaCongTy", Security.CurrentUser.Info.MaCongTy);
                }
                else if (criteria is CriteriaByKyAndKho)
                {
                    cm.CommandText = "spd_SelecttblKyKetChuyenTonKhoByMaKyAndMaKho";
                    cm.Parameters.AddWithValue("@MaKy", ((CriteriaByKyAndKho)criteria).MaKy);
                    cm.Parameters.AddWithValue("@MaKho", ((CriteriaByKyAndKho)criteria).MaKho);
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
			DataPortal_Delete(new Criteria(_maKetChuyen));
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
                cm.CommandText = "spd_DeletetblKyKetChuyenTonKho";

				cm.Parameters.AddWithValue("@MaKetChuyen", criteria.MaKetChuyen);

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
			_maKetChuyen = dr.GetInt64("MaKetChuyen");
			_maKho = dr.GetInt32("MaKho");
			_maKy = dr.GetInt32("MaKy");
			_dienGiai = dr.GetString("DienGiai");
			_nguoiLap = dr.GetInt64("NguoiLap");
			_ngayKetChuyen = dr.GetSmartDate("NgayKetChuyen", _ngayKetChuyen.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
			_cT_KetChuyenTonKhoList = CT_KetChuyenTonKhoList.GetCT_KetChuyenTonKhoList(this.MaKetChuyen);
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
                cm.CommandText = "spd_InserttblKyKetChuyenTonKho";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKetChuyen = (long)cm.Parameters["@MaKetChuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKho", _maKho);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiLap", Security.CurrentUser.Info.UserID);  			
			cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
			cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
			cm.Parameters["@MaKetChuyen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKyKetChuyenTonKho";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
			cm.Parameters.AddWithValue("@MaKho", _maKho);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NguoiLap", Security.CurrentUser.Info.UserID);  
			cm.Parameters.AddWithValue("@NgayKetChuyen", _ngayKetChuyen.DBValue);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_cT_KetChuyenTonKhoList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maKetChuyen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access

        #region Set So Phieu
        public static bool KiemTraKyKetChuyen(int MaKy, int MaKho)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKyKetChuyenTonKho";
                    cm.Parameters.AddWithValue("@MaKho", MaKho);
                    cm.Parameters.AddWithValue("@MaKy", MaKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion
        #region lay ngay ket thuc cua ky
        public static DateTime GetNgayKetThucCuaKy(int maKy)
        {
            DateTime giaTriTraVe=DateTime.Today.Date;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetNgayKetThucCuaKy";
                    cm.Parameters.AddWithValue("@MaKy", maKy);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.DateTime);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (DateTime)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion 
        #region KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen
        public static bool KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(DateTime ngay,int maKho)
        {
            bool giaTriTraVe = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen";
                    cm.Parameters.AddWithValue("Ngay", ngay);
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@DaKetChuyen", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return giaTriTraVe;
        }
        #endregion
    }
}

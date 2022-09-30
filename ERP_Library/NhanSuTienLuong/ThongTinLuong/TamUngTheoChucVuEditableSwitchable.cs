
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUngTheoChucVu : Csla.BusinessBase<TamUngTheoChucVu>
	{
		#region Business Properties and Methods

		//declare members
		private long _maTamUngTheoCV = 0;
		private int _maChucVu = 0;
		private decimal _soTien = 0;
		private string _ghiChu = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _maKyTinhLuong = 0;
        //ivate TamUngTheoNhanVien _tamUngTheoNV = null;
        private string _tenChucVu = string.Empty;
        private string _tenKy = string.Empty;
		[System.ComponentModel.DataObjectField(true, false)]
		public long MaTamUngTheoCV
		{
			get
			{
				CanReadProperty("MaTamUngTheoCV", true);
				return _maTamUngTheoCV;
			}
		}

		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
                TenChucVu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
				return _maChucVu;
			}
			set
			{
				CanWriteProperty("MaChucVu", true);
				if (!_maChucVu.Equals(value))
				{
					_maChucVu = value;
                    TenChucVu = ChucVu.GetChucVu(_maChucVu).TenChucVu;
					PropertyHasChanged("MaChucVu");
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
        public string TenChucVu
        {
            get
            {
                CanReadProperty("TenChucVu", true);

                return _tenChucVu;
            }
            set
            {
                CanWriteProperty("TenChucVu", true);
                if (value == null) value = string.Empty;
                if (!_tenChucVu.Equals(value))
                {
                    _tenChucVu = value;
                    PropertyHasChanged("TenChucVu");
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

        

		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
                TenKy = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong).TenKy;
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
                    //_tamUngTheoNV.MaKyTinhLuong = MaKyTinhLuong;
                    TenKy = KyTinhLuong.GetKyTinhLuong(_maKyTinhLuong).TenKy;

					PropertyHasChanged("MaKyTinhLuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTamUngTheoCV;
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
			// GhiChu
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
			//
			// NgayLap
			//
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
			//TODO: Define authorization rules in TamUngTheoChucVu
			//AuthorizationRules.AllowRead("MaTamUngTheoCV", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "TamUngTheoChucVuReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "TamUngTheoChucVuReadGroup");

			//AuthorizationRules.AllowWrite("MaChucVu", "TamUngTheoChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "TamUngTheoChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "TamUngTheoChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "TamUngTheoChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "TamUngTheoChucVuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TamUngTheoChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TamUngTheoChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TamUngTheoChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TamUngTheoChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoChucVuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TamUngTheoChucVu()
		{ /* require use of factory method */ }

        public static TamUngTheoChucVu NewTamUngTheoChucVu(long maTamUngTheoCV)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoChucVu");
            return DataPortal.Create<TamUngTheoChucVu>(new Criteria(maTamUngTheoCV));
		}
        public static TamUngTheoChucVu NewTamUngTheoChucVu1(long maTamUngTheoCV,int MaChucVu,int MaKy)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a TamUngTheoChucVu");
            return DataPortal.Create<TamUngTheoChucVu>(new CriteriaMaCVMaKy(maTamUngTheoCV,MaChucVu,MaKy));
        }
		public static TamUngTheoChucVu GetTamUngTheoChucVu(long maTamUngTheoCV)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TamUngTheoChucVu");
			return DataPortal.Fetch<TamUngTheoChucVu>(new Criteria(maTamUngTheoCV));
		}

		public static void DeleteTamUngTheoChucVu(long maTamUngTheoCV)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TamUngTheoChucVu");
			DataPortal.Delete(new Criteria(maTamUngTheoCV));
		}

		public override TamUngTheoChucVu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TamUngTheoChucVu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoChucVu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TamUngTheoChucVu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TamUngTheoChucVu(long maTamUngTheoCV)
		{
			this._maTamUngTheoCV = maTamUngTheoCV;
		}

		internal static TamUngTheoChucVu NewTamUngTheoChucVuChild(long maTamUngTheoCV)
		{
			TamUngTheoChucVu child = new TamUngTheoChucVu(maTamUngTheoCV);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TamUngTheoChucVu GetTamUngTheoChucVu(SafeDataReader dr)
		{
			TamUngTheoChucVu child =  new TamUngTheoChucVu();
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
			public long MaTamUngTheoCV;
           
            public Criteria(long maTamUngTheoCV)
			{
				this.MaTamUngTheoCV = maTamUngTheoCV;
               
			}
		}
        [Serializable()]
		private class CriteriaMaCVMaKy
		{
			public long MaTamUngTheoCV;
            public int MaKy;
            public int MaChucVu;

            public CriteriaMaCVMaKy(long maTamUngTheoCV,int maChucVu,int MaKy)
			{
				this.MaTamUngTheoCV = maTamUngTheoCV;
                this.MaChucVu = MaChucVu;
                this.MaKy = MaKy;
			}
		}
        
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maTamUngTheoCV = criteria.MaTamUngTheoCV;
            
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
				cm.CommandText = "sp_SelecttblnsTamUngTheoChucVu";

				cm.Parameters.AddWithValue("@MaTamUngTheoCV", criteria.MaTamUngTheoCV);

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
			DataPortal_Delete(new Criteria(_maTamUngTheoCV));
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
				cm.CommandText = "sp_DeletetblnsTamUngTheoChucVu";

				cm.Parameters.AddWithValue("@MaTamUngTheoCV", criteria.MaTamUngTheoCV);

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
			_maTamUngTheoCV = dr.GetInt64("MaTamUngTheoCV");
			_maChucVu = dr.GetInt32("MaChucVu");
			_soTien = dr.GetDecimal("SoTien");
			_ghiChu = dr.GetString("GhiChu");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _tenChucVu = dr.GetString("TenChucVu");
            _tenKy = dr.GetString("TenKy");    
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TamUngTheoChucVuList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TamUngTheoChucVuList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsTamUngTheoChucVu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maTamUngTheoCV = (long)cm.Parameters["@MaTamUngTheoCV"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TamUngTheoChucVuList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaTamUngTheoCV", _maTamUngTheoCV);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            cm.Parameters["@MaTamUngTheoCV"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TamUngTheoChucVuList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TamUngTheoChucVuList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "sp_UpdatetblnsTamUngTheoChucVu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TamUngTheoChucVuList parent)
		{
			cm.Parameters.AddWithValue("@MaTamUngTheoCV", _maTamUngTheoCV);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{//
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maTamUngTheoCV));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class VanBan : Csla.BusinessBase<VanBan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maVanBan = 0;
		private long _maChungTu = 0;
		private string _maChungTuCu = string.Empty;
		private long _maLoaiVanBan = 0;
		private string _tenVanBan = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);
		private string _duongDan = string.Empty;
		private string _dienGiai = string.Empty;
		private long _userId = 0;
        private int _idx = 0;
        private string _tenVanBanCT = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaVanBan
		{
			get
			{
				CanReadProperty("MaVanBan", true);
                return _maVanBan;
			}
		}

		public long MaChungTu
		{
			get
			{
				CanReadProperty("MaChungTu", true);
				return _maChungTu;
			}
			set
			{
				CanWriteProperty("MaChungTu", true);
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
				}
			}
		}

        public int Idx
        {
            get
            {
                CanReadProperty("Idx", true);
                return _idx;
            }
            set
            {
                CanWriteProperty("Idx", true);
                if (!_idx.Equals(value))
                {
                    _idx = value;
                    PropertyHasChanged("Idx");
                }
            }
        }

		public string MaChungTuCu
		{
			get
			{
				CanReadProperty("MaChungTuCu", true);
				return _maChungTuCu;
			}
			set
			{
				CanWriteProperty("MaChungTuCu", true);
				if (value == null) value = string.Empty;
				if (!_maChungTuCu.Equals(value))
				{
					_maChungTuCu = value;
					PropertyHasChanged("MaChungTuCu");
				}
			}
		}

		public long MaLoaiVanBan
		{
			get
			{
				CanReadProperty("MaLoaiVanBan", true);
				return _maLoaiVanBan;
			}
			set
			{
				CanWriteProperty("MaLoaiVanBan", true);
				if (!_maLoaiVanBan.Equals(value))
				{
					_maLoaiVanBan = value;
					PropertyHasChanged("MaLoaiVanBan");
				}
			}
		}

		public string TenVanBan
		{
			get
			{
				CanReadProperty("TenVanBan", true);
				return _tenVanBan;
			}
			set
			{
				CanWriteProperty("TenVanBan", true);
				if (value == null) value = string.Empty;
				if (!_tenVanBan.Equals(value))
				{
					_tenVanBan = value;
					PropertyHasChanged("TenVanBan");
				}
			}
		}

        public string TenVanBanCT
        {
            get
            {
                CanReadProperty("TenVanBanCT", true);
                return _tenVanBanCT;
            }
            set
            {
                CanWriteProperty("TenVanBanCT", true);
                if (value == null) value = string.Empty;
                if (!_tenVanBanCT.Equals(value))
                {
                    _tenVanBanCT = value;
                    PropertyHasChanged("TenVanBanCT");
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
                if (value == null) value = DateTime.Now.Date;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
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

		public string DuongDan
		{
			get
			{
				CanReadProperty("DuongDan", true);
				return _duongDan;
			}
			set
			{
				CanWriteProperty("DuongDan", true);
				if (value == null) value = string.Empty;
				if (!_duongDan.Equals(value))
				{
					_duongDan = value;
					PropertyHasChanged("DuongDan");
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

		public long UserId
		{
			get
			{
				CanReadProperty("UserId", true);
				return _userId;
			}
			set
			{
				CanWriteProperty("UserId", true);
				if (!_userId.Equals(value))
				{
					_userId = value;
					PropertyHasChanged("UserId");
				}
			}
		}
 
		protected override object GetIdValue()
		{
            return _maVanBan;
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
			// MaChungTuCu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChungTuCu", 50));
			//
			// TenVanBan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVanBan", 50));
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
			//TODO: Define authorization rules in VanBan
			//AuthorizationRules.AllowRead("MaThongTinVanBan", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("MaChungTuCu", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiVanBan", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("TenVanBan", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("DuongDan", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "VanBanReadGroup");
			//AuthorizationRules.AllowRead("UserId", "VanBanReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaChungTuCu", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiVanBan", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("TenVanBan", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("DuongDan", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "VanBanWriteGroup");
			//AuthorizationRules.AllowWrite("UserId", "VanBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in VanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in VanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in VanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in VanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("VanBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private VanBan()
		{ /* require use of factory method */ }

		public static VanBan NewVanBan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a VanBan");
			return DataPortal.Create<VanBan>();
		}

		public static VanBan GetVanBan(long maThongTinVanBan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a VanBan");
			return DataPortal.Fetch<VanBan>(new Criteria(maThongTinVanBan));
		}

		public static void DeleteVanBan(long maThongTinVanBan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a VanBan");
			DataPortal.Delete(new Criteria(maThongTinVanBan));
		}

		public override VanBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a VanBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a VanBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a VanBan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static VanBan NewVanBanChild()
		{
			VanBan child = new VanBan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static VanBan GetVanBan(SafeDataReader dr)
		{
			VanBan child =  new VanBan();
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
			public long MaVanBan;

			public Criteria(long maThongTinVanBan)
			{
				this.MaVanBan = maThongTinVanBan;
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
                cm.CommandText = "spd_SelecttblVanBan";

				cm.Parameters.AddWithValue("@MaVanBan", criteria.MaVanBan);

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
            DataPortal_Delete(new Criteria(_maVanBan));
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
                cm.CommandText = "spd_DeletetblVanBan";

				cm.Parameters.AddWithValue("@MaVanBan", criteria.MaVanBan);

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
            _maVanBan = dr.GetInt64("MaVanBan");
			_maChungTu = dr.GetInt64("MaChungTu");
			_maChungTuCu = dr.GetString("MaChungTuCu");
			_maLoaiVanBan = dr.GetInt64("MaLoaiVanBan");
			_tenVanBan = dr.GetString("TenVanBan");
            _tenVanBanCT = dr.GetString("TenVanBanCT");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_duongDan = dr.GetString("DuongDan");
			_dienGiai = dr.GetString("DienGiai");
			_userId = dr.GetInt64("UserId");
            _idx = dr.GetInt32("Idx");
		}
		

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, VanBanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, VanBanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblVanBan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

                _maVanBan = (long)cm.Parameters["@MaVanBan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, VanBanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_maChungTuCu.Length > 0)
				cm.Parameters.AddWithValue("@MaChungTuCu", _maChungTuCu);
			else
				cm.Parameters.AddWithValue("@MaChungTuCu", DBNull.Value);
			if (_maLoaiVanBan != 0)
				cm.Parameters.AddWithValue("@MaLoaiVanBan", _maLoaiVanBan);
			else
				cm.Parameters.AddWithValue("@MaLoaiVanBan", DBNull.Value);
			if (_tenVanBan.Length > 0)
				cm.Parameters.AddWithValue("@TenVanBan", _tenVanBan);
			else
				cm.Parameters.AddWithValue("@TenVanBan", DBNull.Value);
            if (_tenVanBanCT.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBanCT", _tenVanBanCT);
            else
                cm.Parameters.AddWithValue("@TenVanBanCT", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_duongDan.Length > 0)
				cm.Parameters.AddWithValue("@DuongDan", _duongDan);
			else
				cm.Parameters.AddWithValue("@DuongDan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_userId != 0)
				cm.Parameters.AddWithValue("@UserId", _userId);
			else
				cm.Parameters.AddWithValue("@UserId", DBNull.Value);

            cm.Parameters.AddWithValue("@Idx", _idx);

            cm.Parameters.AddWithValue("@MaVanBan", _maVanBan);
            cm.Parameters["@MaVanBan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, VanBanList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, VanBanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblVanBan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, VanBanList parent)
		{
			cm.Parameters.AddWithValue("@MaVanBan", _maVanBan);
			if (_maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_maChungTuCu.Length > 0)
				cm.Parameters.AddWithValue("@MaChungTuCu", _maChungTuCu);
			else
				cm.Parameters.AddWithValue("@MaChungTuCu", DBNull.Value);
			if (_maLoaiVanBan != 0)
				cm.Parameters.AddWithValue("@MaLoaiVanBan", _maLoaiVanBan);
			else
				cm.Parameters.AddWithValue("@MaLoaiVanBan", DBNull.Value);
			if (_tenVanBan.Length > 0)
				cm.Parameters.AddWithValue("@TenVanBan", _tenVanBan);
			else
				cm.Parameters.AddWithValue("@TenVanBan", DBNull.Value);
            if (_tenVanBanCT.Length > 0)
                cm.Parameters.AddWithValue("@TenVanBanCT", _tenVanBanCT);
            else
                cm.Parameters.AddWithValue("@TenVanBanCT", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_duongDan.Length > 0)
				cm.Parameters.AddWithValue("@DuongDan", _duongDan);
			else
				cm.Parameters.AddWithValue("@DuongDan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_userId != 0)
				cm.Parameters.AddWithValue("@UserId", _userId);
			else
				cm.Parameters.AddWithValue("@UserId", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maVanBan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

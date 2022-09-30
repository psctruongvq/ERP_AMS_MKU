using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiVanBan : Csla.BusinessBase<LoaiVanBan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maLoaiVanBan = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaivanBan = string.Empty;
		private string _dienGiai = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);
		private int _userId = 0;
		private long _maLoaiCha = 0;

        [System.ComponentModel.DataObjectField(true, true)]
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

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

        public bool Chon
        {
            get;
            set;
        }   

		public string TenLoaivanBan
		{
			get
			{
				CanReadProperty("TenLoaivanBan", true);
				return _tenLoaivanBan;
			}
			set
			{
				CanWriteProperty("TenLoaivanBan", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaivanBan.Equals(value))
				{
					_tenLoaivanBan = value;
					PropertyHasChanged("TenLoaivanBan");
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

		public int UserId
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

		public long MaLoaiCha
		{
			get
			{
				CanReadProperty("MaLoaiCha", true);
				return _maLoaiCha;
			}
			set
			{
				CanWriteProperty("MaLoaiCha", true);
				if (!_maLoaiCha.Equals(value))
				{
					_maLoaiCha = value;
					PropertyHasChanged("MaLoaiCha");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiVanBan;
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
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenLoaivanBan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaivanBan", 100));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 200));
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
			//TODO: Define authorization rules in LoaiVanBan
			//AuthorizationRules.AllowRead("MaLoaiVanBan", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("TenLoaivanBan", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("UserId", "LoaiVanBanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiCha", "LoaiVanBanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiVanBanWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaivanBan", "LoaiVanBanWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "LoaiVanBanWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "LoaiVanBanWriteGroup");
			//AuthorizationRules.AllowWrite("UserId", "LoaiVanBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiCha", "LoaiVanBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiVanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiVanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiVanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiVanBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiVanBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiVanBan()
        { /* require use of factory method */ MarkAsChild(); }

		public static LoaiVanBan NewLoaiVanBan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiVanBan");
			return DataPortal.Create<LoaiVanBan>();
		}
        public static LoaiVanBan NewLoaiVanBan(int maLoaiVanBan, string maQuanLy ,string tenLoaiVanBan)
        {
            LoaiVanBan lvb = new LoaiVanBan();
            lvb.MaLoaiVanBan = 0;
            lvb.TenLoaivanBan = tenLoaiVanBan;
            lvb.MaQuanLy = maQuanLy;
            return lvb;
        }

		public static LoaiVanBan GetLoaiVanBan(long maLoaiVanBan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiVanBan");
			return DataPortal.Fetch<LoaiVanBan>(new Criteria(maLoaiVanBan));
		}

		public static void DeleteLoaiVanBan(long maLoaiVanBan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiVanBan");
			DataPortal.Delete(new Criteria(maLoaiVanBan));
		}

		public override LoaiVanBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiVanBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiVanBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiVanBan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiVanBan NewLoaiVanBanChild()
		{
			LoaiVanBan child = new LoaiVanBan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiVanBan GetLoaiVanBan(SafeDataReader dr)
		{
			LoaiVanBan child =  new LoaiVanBan();
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
			public long MaLoaiVanBan;

			public Criteria(long maLoaiVanBan)
			{
				this.MaLoaiVanBan = maLoaiVanBan;
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
                cm.CommandText = "spd_SelecttblLoaiVanBan";

				cm.Parameters.AddWithValue("@MaLoaiVanBan", criteria.MaLoaiVanBan);

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
			DataPortal_Delete(new Criteria(_maLoaiVanBan));
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
                cm.CommandText = "spd_DeletetblLoaiVanBan";

				cm.Parameters.AddWithValue("@MaLoaiVanBan", criteria.MaLoaiVanBan);

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
			_maLoaiVanBan = dr.GetInt64("MaLoaiVanBan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaivanBan = dr.GetString("TenLoaivanBan");
			_dienGiai = dr.GetString("DienGiai");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_userId = dr.GetInt32("UserId");
			_maLoaiCha = dr.GetInt64("MaLoaiCha");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiVanBanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiVanBanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblLoaiVanBan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maLoaiVanBan = (long)cm.Parameters["@MaLoaiVanBan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiVanBanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenLoaivanBan.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaivanBan", _tenLoaivanBan);
			else
				cm.Parameters.AddWithValue("@TenLoaivanBan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_userId != 0)
				cm.Parameters.AddWithValue("@UserId", _userId);
			else
				cm.Parameters.AddWithValue("@UserId", DBNull.Value);
			if (_maLoaiCha != 0)
				cm.Parameters.AddWithValue("@MaLoaiCha", _maLoaiCha);
			else
				cm.Parameters.AddWithValue("@MaLoaiCha", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiVanBan", _maLoaiVanBan);
			cm.Parameters["@MaLoaiVanBan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiVanBanList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiVanBanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblLoaiVanBan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiVanBanList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiVanBan", _maLoaiVanBan);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenLoaivanBan.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaivanBan", _tenLoaivanBan);
			else
				cm.Parameters.AddWithValue("@TenLoaivanBan", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_userId != 0)
				cm.Parameters.AddWithValue("@UserId", _userId);
			else
				cm.Parameters.AddWithValue("@UserId", DBNull.Value);
			if (_maLoaiCha != 0)
				cm.Parameters.AddWithValue("@MaLoaiCha", _maLoaiCha);
			else
				cm.Parameters.AddWithValue("@MaLoaiCha", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiVanBan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

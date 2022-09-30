using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongViec : Csla.BusinessBase<CongViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCongViec = 0;
		private string _maQuanLy = string.Empty;
		private string _tenCongViec = string.Empty;
		private int _nguoiLap = 0;
		private SmartDate _ngayLap = new SmartDate(false);

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCongViec
		{
			get
			{
				CanReadProperty("MaCongViec", true);
				return _maCongViec;
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

		public string TenCongViec
		{
			get
			{
				CanReadProperty("TenCongViec", true);
				return _tenCongViec;
			}
			set
			{
				CanWriteProperty("TenCongViec", true);
				if (value == null) value = string.Empty;
				if (!_tenCongViec.Equals(value))
				{
					_tenCongViec = value;
					PropertyHasChanged("TenCongViec");
				}
			}
		}

		public int NguoiLap
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

		
 
		protected override object GetIdValue()
		{
			return _maCongViec;
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
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenCongViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongViec", 500));
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
			//TODO: Define authorization rules in CongViec
			//AuthorizationRules.AllowRead("MaCongViec", "CongViecReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "CongViecReadGroup");
			//AuthorizationRules.AllowRead("TenCongViec", "CongViecReadGroup");
			//AuthorizationRules.AllowRead("NguoiLap", "CongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "CongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "CongViecReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "CongViecWriteGroup");
			//AuthorizationRules.AllowWrite("TenCongViec", "CongViecWriteGroup");
			//AuthorizationRules.AllowWrite("NguoiLap", "CongViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "CongViecWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongViecViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongViecAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongViecEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongViecDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CongViec()
		{ /* require use of factory method */ }

        public static CongViec NewCongViec(int maCongviec, string tenCongViec)
        {
            return new CongViec(maCongviec, tenCongViec);
        }

        private CongViec(int maCongViec, string tenCongViec)
        {
            _maCongViec = maCongViec;
            _tenCongViec = tenCongViec;
        }
		public static CongViec NewCongViec()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongViec");
			return DataPortal.Create<CongViec>();
		}

		public static CongViec GetCongViec(int maCongViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongViec");
			return DataPortal.Fetch<CongViec>(new Criteria(maCongViec));
		}

		public static void DeleteCongViec(int maCongViec)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongViec");
			DataPortal.Delete(new Criteria(maCongViec));
		}

		public override CongViec Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongViec");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongViec");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CongViec");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongViec NewCongViecChild()
		{
			CongViec child = new CongViec();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongViec GetCongViec(SafeDataReader dr)
		{
			CongViec child =  new CongViec();
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
			public int MaCongViec;

			public Criteria(int maCongViec)
			{
				this.MaCongViec = maCongViec;
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
				cm.CommandText = "Spd_SelecttblnsCongViec";

				cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);

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
			DataPortal_Delete(new Criteria(_maCongViec));
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
				cm.CommandText = "Spd_DeletetblnsCongViec";

				cm.Parameters.AddWithValue("@MaCongViec", criteria.MaCongViec);

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
			_maCongViec = dr.GetInt32("MaCongViec");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenCongViec = dr.GetString("TenCongViec");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongViecList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_InserttblnsCongViec";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maCongViec = (int)cm.Parameters["@MaCongViec"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongViecList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters["@MaCongViec"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongViecList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, CongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_UpdatetblnsCongViec";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongViecList parent)
		{
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(tr, new Criteria(_maCongViec));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

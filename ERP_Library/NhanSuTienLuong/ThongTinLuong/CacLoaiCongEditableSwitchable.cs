
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CacLoaiCong : Csla.BusinessBase<CacLoaiCong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCacLoaiCong = 0;
		private string _maCacLoaiCongQL = string.Empty;
		private string _tenCacLoaiCong = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCacLoaiCong
		{
			get
			{
				CanReadProperty("MaCacLoaiCong", true);
				return _maCacLoaiCong;
			}
		}

		public string MaCacLoaiCongQL
		{
			get
			{
				CanReadProperty("MaCacLoaiCongQL", true);
				return _maCacLoaiCongQL;
			}
			set
			{
				CanWriteProperty("MaCacLoaiCongQL", true);
				if (value == null) value = string.Empty;
				if (!_maCacLoaiCongQL.Equals(value))
				{
					_maCacLoaiCongQL = value;
					PropertyHasChanged("MaCacLoaiCongQL");
				}
			}
		}

		public string TenCacLoaiCong
		{
			get
			{
				CanReadProperty("TenCacLoaiCong", true);
				return _tenCacLoaiCong;
			}
			set
			{
				CanWriteProperty("TenCacLoaiCong", true);
				if (value == null) value = string.Empty;
				if (!_tenCacLoaiCong.Equals(value))
				{
					_tenCacLoaiCong = value;
					PropertyHasChanged("TenCacLoaiCong");
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
			return _maCacLoaiCong;
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
			// MaCacLoaiCongQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaCacLoaiCongQL", 50));
			//
			// TenCacLoaiCong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCacLoaiCong", 200));
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
			//TODO: Define authorization rules in CacLoaiCong
			//AuthorizationRules.AllowRead("MaCacLoaiCong", "CacLoaiCongReadGroup");
			//AuthorizationRules.AllowRead("MaCacLoaiCongQL", "CacLoaiCongReadGroup");
			//AuthorizationRules.AllowRead("TenCacLoaiCong", "CacLoaiCongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "CacLoaiCongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "CacLoaiCongReadGroup");

			//AuthorizationRules.AllowWrite("MaCacLoaiCongQL", "CacLoaiCongWriteGroup");
			//AuthorizationRules.AllowWrite("TenCacLoaiCong", "CacLoaiCongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "CacLoaiCongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CacLoaiCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CacLoaiCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CacLoaiCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CacLoaiCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CacLoaiCongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CacLoaiCong()
		{ /* require use of factory method */ }

		public static CacLoaiCong NewCacLoaiCong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CacLoaiCong");
			return DataPortal.Create<CacLoaiCong>();
		}

		public static CacLoaiCong GetCacLoaiCong(int maCacLoaiCong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CacLoaiCong");
			return DataPortal.Fetch<CacLoaiCong>(new Criteria(maCacLoaiCong));
		}

		public static void DeleteCacLoaiCong(int maCacLoaiCong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CacLoaiCong");
			DataPortal.Delete(new Criteria(maCacLoaiCong));
		}

		public override CacLoaiCong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CacLoaiCong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CacLoaiCong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CacLoaiCong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CacLoaiCong NewCacLoaiCongChild()
		{
			CacLoaiCong child = new CacLoaiCong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CacLoaiCong GetCacLoaiCong(SafeDataReader dr)
		{
			CacLoaiCong child =  new CacLoaiCong();
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
			public int MaCacLoaiCong;

			public Criteria(int maCacLoaiCong)
			{
				this.MaCacLoaiCong = maCacLoaiCong;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsCacLoaiCong";

				cm.Parameters.AddWithValue("@MaCacLoaiCong", criteria.MaCacLoaiCong);

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
			DataPortal_Delete(new Criteria(_maCacLoaiCong));
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
				cm.CommandText = "DeleteCacLoaiCong";

				cm.Parameters.AddWithValue("@MaCacLoaiCong", criteria.MaCacLoaiCong);

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
			_maCacLoaiCong = dr.GetInt32("MaCacLoaiCong");
			_maCacLoaiCongQL = dr.GetString("MaCacLoaiCongQL");
			_tenCacLoaiCong = dr.GetString("TenCacLoaiCong");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, CacLoaiCongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, CacLoaiCongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddCacLoaiCong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maCacLoaiCong = (int)cm.Parameters["@NewMaCacLoaiCong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CacLoaiCongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maCacLoaiCongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaCacLoaiCongQL", _maCacLoaiCongQL);
			else
				cm.Parameters.AddWithValue("@MaCacLoaiCongQL", DBNull.Value);
			if (_tenCacLoaiCong.Length > 0)
				cm.Parameters.AddWithValue("@TenCacLoaiCong", _tenCacLoaiCong);
			else
				cm.Parameters.AddWithValue("@TenCacLoaiCong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@NewMaCacLoaiCong", _maCacLoaiCong);
			cm.Parameters["@NewMaCacLoaiCong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, CacLoaiCongList parent)
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

		private void ExecuteUpdate(SqlConnection cn, CacLoaiCongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateCacLoaiCong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CacLoaiCongList parent)
		{
			cm.Parameters.AddWithValue("@MaCacLoaiCong", _maCacLoaiCong);
			if (_maCacLoaiCongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaCacLoaiCongQL", _maCacLoaiCongQL);
			else
				cm.Parameters.AddWithValue("@MaCacLoaiCongQL", DBNull.Value);
			if (_tenCacLoaiCong.Length > 0)
				cm.Parameters.AddWithValue("@TenCacLoaiCong", _tenCacLoaiCong);
			else
				cm.Parameters.AddWithValue("@TenCacLoaiCong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(cn, new Criteria(_maCacLoaiCong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

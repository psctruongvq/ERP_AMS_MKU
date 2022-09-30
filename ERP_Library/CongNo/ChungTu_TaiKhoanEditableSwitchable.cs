
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TaiKhoan : Csla.BusinessBase<ChungTu_TaiKhoan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChungTu = 0;
		private int _maTaiKhoanCT = 0;
		private string _soTaiKhoanCT = string.Empty;
		private int _maTaiKhoanKH = 0;
		private string _soTaiKhoanKH = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
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

		public int MaTaiKhoanCT
		{
			get
			{
				CanReadProperty("MaTaiKhoanCT", true);
				return _maTaiKhoanCT;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanCT", true);
				if (!_maTaiKhoanCT.Equals(value))
				{
					_maTaiKhoanCT = value;
					PropertyHasChanged("MaTaiKhoanCT");
				}
			}
		}

		public string SoTaiKhoanCT
		{
			get
			{
				CanReadProperty("SoTaiKhoanCT", true);
				return _soTaiKhoanCT;
			}
			set
			{
				CanWriteProperty("SoTaiKhoanCT", true);
				if (value == null) value = string.Empty;
				if (!_soTaiKhoanCT.Equals(value))
				{
					_soTaiKhoanCT = value;
					PropertyHasChanged("SoTaiKhoanCT");
				}
			}
		}

		public int MaTaiKhoanKH
		{
			get
			{
				CanReadProperty("MaTaiKhoanKH", true);
				return _maTaiKhoanKH;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanKH", true);
				if (!_maTaiKhoanKH.Equals(value))
				{
					_maTaiKhoanKH = value;
					PropertyHasChanged("MaTaiKhoanKH");
				}
			}
		}

		public string SoTaiKhoanKH
		{
			get
			{
				CanReadProperty("SoTaiKhoanKH", true);
				return _soTaiKhoanKH;
			}
			set
			{
				CanWriteProperty("SoTaiKhoanKH", true);
				if (value == null) value = string.Empty;
				if (!_soTaiKhoanKH.Equals(value))
				{
					_soTaiKhoanKH = value;
					PropertyHasChanged("SoTaiKhoanKH");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChungTu;
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
			// SoTaiKhoanCT
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoTaiKhoanCT");
			//
			// SoTaiKhoanKH
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoTaiKhoanKH");
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
			//TODO: Define authorization rules in ChungTu_TaiKhoan
			//AuthorizationRules.AllowRead("MaChungTu", "ChungTu_TaiKhoanReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanCT", "ChungTu_TaiKhoanReadGroup");
			//AuthorizationRules.AllowRead("SoTaiKhoanCT", "ChungTu_TaiKhoanReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanKH", "ChungTu_TaiKhoanReadGroup");
			//AuthorizationRules.AllowRead("SoTaiKhoanKH", "ChungTu_TaiKhoanReadGroup");

			//AuthorizationRules.AllowWrite("MaTaiKhoanCT", "ChungTu_TaiKhoanWriteGroup");
			//AuthorizationRules.AllowWrite("SoTaiKhoanCT", "ChungTu_TaiKhoanWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanKH", "ChungTu_TaiKhoanWriteGroup");
			//AuthorizationRules.AllowWrite("SoTaiKhoanKH", "ChungTu_TaiKhoanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_TaiKhoan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_TaiKhoan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_TaiKhoan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_TaiKhoan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_TaiKhoanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_TaiKhoan()
		{ /* require use of factory method */ }

		public static ChungTu_TaiKhoan NewChungTu_TaiKhoan(long maChungTu)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_TaiKhoan");
			return DataPortal.Create<ChungTu_TaiKhoan>(new Criteria(maChungTu));
		}

		public static ChungTu_TaiKhoan GetChungTu_TaiKhoan(long maChungTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTu_TaiKhoan");
			return DataPortal.Fetch<ChungTu_TaiKhoan>(new Criteria(maChungTu));
		}

		public static void DeleteChungTu_TaiKhoan(long maChungTu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_TaiKhoan");
			DataPortal.Delete(new Criteria(maChungTu));
		}

		public override ChungTu_TaiKhoan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_TaiKhoan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_TaiKhoan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChungTu_TaiKhoan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ChungTu_TaiKhoan(long maChungTu)
		{
			this._maChungTu = maChungTu;
		}

		internal static ChungTu_TaiKhoan NewChungTu_TaiKhoanChild(long maChungTu)
		{
			ChungTu_TaiKhoan child = new ChungTu_TaiKhoan(maChungTu);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTu_TaiKhoan GetChungTu_TaiKhoan(SafeDataReader dr)
		{
			ChungTu_TaiKhoan child =  new ChungTu_TaiKhoan();
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
			public long MaChungTu;

			public Criteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChungTu = criteria.MaChungTu;
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
                cm.CommandText = "spd_SelecttblcnChungTu_TaiKhoan";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			DataPortal_Delete(new Criteria(_maChungTu));
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
				cm.CommandText = "DeleteChungTu_TaiKhoan";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			_maChungTu = dr.GetInt64("MaChungTu");
			_maTaiKhoanCT = dr.GetInt32("MaTaiKhoanCT");
			_soTaiKhoanCT = dr.GetString("SoTaiKhoanCT");
			_maTaiKhoanKH = dr.GetInt32("MaTaiKhoanKH");
			_soTaiKhoanKH = dr.GetString("SoTaiKhoanKH");
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
                cm.CommandText = "spd_InserttblcnChungTu_TaiKhoan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaTaiKhoanCT", _maTaiKhoanCT);
			cm.Parameters.AddWithValue("@SoTaiKhoanCT", _soTaiKhoanCT);
			cm.Parameters.AddWithValue("@MaTaiKhoanKH", _maTaiKhoanKH);
			cm.Parameters.AddWithValue("@SoTaiKhoanKH", _soTaiKhoanKH);
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
                cm.CommandText = "spd_UpdatetblcnChungTu_TaiKhoan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaTaiKhoanCT", _maTaiKhoanCT);
			cm.Parameters.AddWithValue("@SoTaiKhoanCT", _soTaiKhoanCT);
			cm.Parameters.AddWithValue("@MaTaiKhoanKH", _maTaiKhoanKH);
			cm.Parameters.AddWithValue("@SoTaiKhoanKH", _soTaiKhoanKH);
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

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiBoPhan : Csla.BusinessBase<LoaiBoPhan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiBoPhan = 0;
		private string _maLoaiBoPhanQL = string.Empty;
		private string _tenLoaiBoPhan = string.Empty;
		private SmartDate _ngayTao = new SmartDate(true);

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiBoPhan
		{
			get
			{
				CanReadProperty("MaLoaiBoPhan", true);
				return _maLoaiBoPhan;
			}
		}

		public string MaLoaiBoPhanQL
		{
			get
			{
				CanReadProperty("MaLoaiBoPhanQL", true);
				return _maLoaiBoPhanQL;
			}
			set
			{
				CanWriteProperty("MaLoaiBoPhanQL", true);
				if (value == null) value = string.Empty;
				if (!_maLoaiBoPhanQL.Equals(value))
				{
					_maLoaiBoPhanQL = value;
					PropertyHasChanged("MaLoaiBoPhanQL");
				}
			}
		}

		public string TenLoaiBoPhan
		{
			get
			{
				CanReadProperty("TenLoaiBoPhan", true);
				return _tenLoaiBoPhan;
			}
			set
			{
				CanWriteProperty("TenLoaiBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiBoPhan.Equals(value))
				{
					_tenLoaiBoPhan = value;
					PropertyHasChanged("TenLoaiBoPhan");
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

		protected override object GetIdValue()
		{
			return _maLoaiBoPhan;
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
			// MaLoaiBoPhanQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiBoPhanQL", 50));
			//
			// TenLoaiBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiBoPhan", 200));
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
			//TODO: Define authorization rules in LoaiBoPhan
			//AuthorizationRules.AllowRead("MaLoaiBoPhan", "LoaiBoPhanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiBoPhanQL", "LoaiBoPhanReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiBoPhan", "LoaiBoPhanReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "LoaiBoPhanReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "LoaiBoPhanReadGroup");

			//AuthorizationRules.AllowWrite("MaLoaiBoPhanQL", "LoaiBoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiBoPhan", "LoaiBoPhanWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTaoString", "LoaiBoPhanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiBoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiBoPhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiBoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiBoPhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiBoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiBoPhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiBoPhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiBoPhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiBoPhan()
		{ /* require use of factory method */ }

		public static LoaiBoPhan NewLoaiBoPhan(int maLoaiBoPhan)
		{
            LoaiBoPhan i = new LoaiBoPhan();
            i.MarkAsChild();
            return i;
		}

		public static LoaiBoPhan GetLoaiBoPhan(int maLoaiBoPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiBoPhan");
			return DataPortal.Fetch<LoaiBoPhan>(new Criteria(maLoaiBoPhan));
		}

		public static void DeleteLoaiBoPhan(int maLoaiBoPhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiBoPhan");
			DataPortal.Delete(new Criteria(maLoaiBoPhan));
		}

		public override LoaiBoPhan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiBoPhan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiBoPhan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiBoPhan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private LoaiBoPhan(int maLoaiBoPhan)
		{
			this._maLoaiBoPhan = maLoaiBoPhan;
		}

		internal static LoaiBoPhan NewLoaiBoPhanChild(int maLoaiBoPhan)
		{
			LoaiBoPhan child = new LoaiBoPhan(maLoaiBoPhan);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiBoPhan GetLoaiBoPhan(SafeDataReader dr)
		{
			LoaiBoPhan child =  new LoaiBoPhan();
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
			public int MaLoaiBoPhan;

			public Criteria(int maLoaiBoPhan)
			{
				this.MaLoaiBoPhan = maLoaiBoPhan;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiBoPhan = criteria.MaLoaiBoPhan;
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
                cm.CommandText = "sp_SelecttblnsLoaiBoPhan";

				cm.Parameters.AddWithValue("@MaLoaiBoPhan", criteria.MaLoaiBoPhan);

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
			DataPortal_Delete(new Criteria(_maLoaiBoPhan));
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
				cm.CommandText = "DeleteLoaiBoPhan";

				cm.Parameters.AddWithValue("@MaLoaiBoPhan", criteria.MaLoaiBoPhan);

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
			_maLoaiBoPhan = dr.GetInt32("MaLoaiBoPhan");
			_maLoaiBoPhanQL = dr.GetString("MaLoaiBoPhanQL");
			_tenLoaiBoPhan = dr.GetString("TenLoaiBoPhan");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, LoaiBoPhanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, LoaiBoPhanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddLoaiBoPhan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiBoPhanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaLoaiBoPhan", _maLoaiBoPhan);
			if (_maLoaiBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiBoPhanQL", _maLoaiBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiBoPhanQL", DBNull.Value);
			if (_tenLoaiBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiBoPhan", _tenLoaiBoPhan);
			else
				cm.Parameters.AddWithValue("@TenLoaiBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, LoaiBoPhanList parent)
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

		private void ExecuteUpdate(SqlConnection cn, LoaiBoPhanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateLoaiBoPhan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiBoPhanList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiBoPhan", _maLoaiBoPhan);
			if (_maLoaiBoPhanQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiBoPhanQL", _maLoaiBoPhanQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiBoPhanQL", DBNull.Value);
			if (_tenLoaiBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiBoPhan", _tenLoaiBoPhan);
			else
				cm.Parameters.AddWithValue("@TenLoaiBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
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

			ExecuteDelete(cn, new Criteria(_maLoaiBoPhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

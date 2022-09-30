
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TieuNhomNganSach : Csla.BusinessBase<TieuNhomNganSach>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTieuNhom = 0;
		private string _maTieuNhomQL = string.Empty;
		private string _tenTieuNhom = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTieuNhom
		{
			get
			{
				CanReadProperty("MaTieuNhom", true);
				return _maTieuNhom;
			}
		}

		public string MaTieuNhomQL
		{
			get
			{
				CanReadProperty("MaTieuNhomQL", true);
				return _maTieuNhomQL;
			}
			set
			{
				CanWriteProperty("MaTieuNhomQL", true);
				if (value == null) value = string.Empty;
				if (!_maTieuNhomQL.Equals(value))
				{
					_maTieuNhomQL = value;
					PropertyHasChanged("MaTieuNhomQL");
				}
			}
		}

		public string TenTieuNhom
		{
			get
			{
				CanReadProperty("TenTieuNhom", true);
				return _tenTieuNhom;
			}
			set
			{
				CanWriteProperty("TenTieuNhom", true);
				if (value == null) value = string.Empty;
				if (!_tenTieuNhom.Equals(value))
				{
					_tenTieuNhom = value;
					PropertyHasChanged("TenTieuNhom");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTieuNhom;
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
			// MaTieuNhomQL
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaTieuNhomQL");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTieuNhomQL", 50));
			//
			// TenTieuNhom
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenTieuNhom");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTieuNhom", 4000));
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
			//TODO: Define authorization rules in TieuNhomNganSach
			//AuthorizationRules.AllowRead("MaTieuNhom", "TieuNhomNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaTieuNhomQL", "TieuNhomNganSachReadGroup");
			//AuthorizationRules.AllowRead("TenTieuNhom", "TieuNhomNganSachReadGroup");

			//AuthorizationRules.AllowWrite("MaTieuNhomQL", "TieuNhomNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("TenTieuNhom", "TieuNhomNganSachWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TieuNhomNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TieuNhomNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TieuNhomNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TieuNhomNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuNhomNganSachDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TieuNhomNganSach()
		{ /* require use of factory method */ }

		public static TieuNhomNganSach NewTieuNhomNganSach()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuNhomNganSach");
			return DataPortal.Create<TieuNhomNganSach>();
		}

		public static TieuNhomNganSach GetTieuNhomNganSach(int maTieuNhom)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TieuNhomNganSach");
			return DataPortal.Fetch<TieuNhomNganSach>(new Criteria(maTieuNhom));
		}

		public static void DeleteTieuNhomNganSach(int maTieuNhom)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TieuNhomNganSach");
			DataPortal.Delete(new Criteria(maTieuNhom));
		}

		public override TieuNhomNganSach Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TieuNhomNganSach");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuNhomNganSach");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TieuNhomNganSach");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TieuNhomNganSach NewTieuNhomNganSachChild()
		{
			TieuNhomNganSach child = new TieuNhomNganSach();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TieuNhomNganSach GetTieuNhomNganSach(SafeDataReader dr)
		{
			TieuNhomNganSach child =  new TieuNhomNganSach();
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
			public int MaTieuNhom;

			public Criteria(int maTieuNhom)
			{
				this.MaTieuNhom = maTieuNhom;
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
                cm.CommandText = "spd_SelecttblTieuNhomNganSach";

				cm.Parameters.AddWithValue("@MaTieuNhom", criteria.MaTieuNhom);

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
			DataPortal_Delete(new Criteria(_maTieuNhom));
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
                cm.CommandText = "spd_DeletetblTieuNhomNganSach";

				cm.Parameters.AddWithValue("@MaTieuNhom", criteria.MaTieuNhom);

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
			_maTieuNhom = dr.GetInt32("MaTieuNhom");
			_maTieuNhomQL = dr.GetString("MaTieuNhomQL");
			_tenTieuNhom = dr.GetString("TenTieuNhom");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, TieuNhomNganSachList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, TieuNhomNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblTieuNhomNganSach";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTieuNhom = (int)cm.Parameters["@MaTieuNhom"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TieuNhomNganSachList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaTieuNhomQL", _maTieuNhomQL);
			cm.Parameters.AddWithValue("@TenTieuNhom", _tenTieuNhom);
			cm.Parameters.AddWithValue("@MaTieuNhom", _maTieuNhom);
			cm.Parameters["@MaTieuNhom"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, TieuNhomNganSachList parent)
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

		private void ExecuteUpdate(SqlConnection cn, TieuNhomNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblTieuNhomNganSach";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TieuNhomNganSachList parent)
		{
			cm.Parameters.AddWithValue("@MaTieuNhom", _maTieuNhom);
			cm.Parameters.AddWithValue("@MaTieuNhomQL", _maTieuNhomQL);
			cm.Parameters.AddWithValue("@TenTieuNhom", _tenTieuNhom);
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

			ExecuteDelete(cn, new Criteria(_maTieuNhom));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

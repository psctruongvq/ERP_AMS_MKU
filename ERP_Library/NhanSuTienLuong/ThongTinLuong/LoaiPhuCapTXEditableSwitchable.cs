
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiPhuCapTX : Csla.BusinessBase<LoaiPhuCapTX>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiPhuCapTX = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiPhuCapTX = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiPhuCapTX
		{
			get
			{
				CanReadProperty("MaLoaiPhuCapTX", true);
				return _maLoaiPhuCapTX;
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

		public string TenLoaiPhuCapTX
		{
			get
			{
				CanReadProperty("TenLoaiPhuCapTX", true);
				return _tenLoaiPhuCapTX;
			}
			set
			{
				CanWriteProperty("TenLoaiPhuCapTX", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiPhuCapTX.Equals(value))
				{
					_tenLoaiPhuCapTX = value;
					PropertyHasChanged("TenLoaiPhuCapTX");
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
 
		protected override object GetIdValue()
		{
			return _maLoaiPhuCapTX;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenLoaiPhuCapTX
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiPhuCapTX");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiPhuCapTX", 200));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in LoaiPhuCapTX
			//AuthorizationRules.AllowRead("MaLoaiPhuCapTX", "LoaiPhuCapTXReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiPhuCapTXReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiPhuCapTX", "LoaiPhuCapTXReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "LoaiPhuCapTXReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiPhuCapTXWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiPhuCapTX", "LoaiPhuCapTXWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "LoaiPhuCapTXWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiPhuCapTX
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapTXViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiPhuCapTX
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapTXAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiPhuCapTX
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapTXEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiPhuCapTX
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiPhuCapTXDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiPhuCapTX()
		{ /* require use of factory method */ }

		public static LoaiPhuCapTX NewLoaiPhuCapTX()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiPhuCapTX");
			return DataPortal.Create<LoaiPhuCapTX>();
		}

		public static LoaiPhuCapTX GetLoaiPhuCapTX(int maLoaiPhuCapTX)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiPhuCapTX");
			return DataPortal.Fetch<LoaiPhuCapTX>(new Criteria(maLoaiPhuCapTX));
		}

		public static void DeleteLoaiPhuCapTX(int maLoaiPhuCapTX)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiPhuCapTX");
			DataPortal.Delete(new Criteria(maLoaiPhuCapTX));
		}

		public override LoaiPhuCapTX Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiPhuCapTX");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiPhuCapTX");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiPhuCapTX");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiPhuCapTX NewLoaiPhuCapTXChild()
		{
			LoaiPhuCapTX child = new LoaiPhuCapTX();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiPhuCapTX GetLoaiPhuCapTX(SafeDataReader dr)
		{
			LoaiPhuCapTX child =  new LoaiPhuCapTX();
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
			public int MaLoaiPhuCapTX;

			public Criteria(int maLoaiPhuCapTX)
			{
				this.MaLoaiPhuCapTX = maLoaiPhuCapTX;
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
                cm.CommandText = "spd_SelecttblnsLoaiPhuCapTX";

				cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", criteria.MaLoaiPhuCapTX);

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
			DataPortal_Delete(new Criteria(_maLoaiPhuCapTX));
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
                cm.CommandText = "spd_DeletetblnsLoaiPhuCapTX";

				cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", criteria.MaLoaiPhuCapTX);

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
			_maLoaiPhuCapTX = dr.GetInt32("MaLoaiPhuCapTX");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiPhuCapTX = dr.GetString("TenLoaiPhuCapTX");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, LoaiPhuCapTXList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, LoaiPhuCapTXList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLoaiPhuCapTX";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maLoaiPhuCapTX = (int)cm.Parameters["@MaLoaiPhuCapTX"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiPhuCapTXList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiPhuCapTX", _tenLoaiPhuCapTX);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", _maLoaiPhuCapTX);
			cm.Parameters["@MaLoaiPhuCapTX"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, LoaiPhuCapTXList parent)
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

		private void ExecuteUpdate(SqlConnection cn, LoaiPhuCapTXList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLoaiPhuCapTX";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiPhuCapTXList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", _maLoaiPhuCapTX);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiPhuCapTX", _tenLoaiPhuCapTX);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maLoaiPhuCapTX));
			MarkNew();
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
}

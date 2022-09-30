
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiTangCa : Csla.BusinessBase<LoaiTangCa>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiTangCa = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiTangCa = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiTangCa
		{
			get
			{
				CanReadProperty("MaLoaiTangCa", true);
				return _maLoaiTangCa;
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

		public string TenLoaiTangCa
		{
			get
			{
				CanReadProperty("TenLoaiTangCa", true);
				return _tenLoaiTangCa;
			}
			set
			{
				CanWriteProperty("TenLoaiTangCa", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiTangCa.Equals(value))
				{
					_tenLoaiTangCa = value;
					PropertyHasChanged("TenLoaiTangCa");
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
			return _maLoaiTangCa;
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
			// TenLoaiTangCa
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiTangCa");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiTangCa", 500));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
			//TODO: Define authorization rules in LoaiTangCa
			//AuthorizationRules.AllowRead("MaLoaiTangCa", "LoaiTangCaReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiTangCaReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiTangCa", "LoaiTangCaReadGroup");
			//AuthorizationRules.AllowRead("PhanTram", "LoaiTangCaReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "LoaiTangCaReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiTangCaWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiTangCa", "LoaiTangCaWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTram", "LoaiTangCaWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "LoaiTangCaWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiTangCa
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTangCaViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiTangCa
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTangCaAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiTangCa
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTangCaEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiTangCa
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTangCaDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiTangCa()
		{ /* require use of factory method */ }

		public static LoaiTangCa NewLoaiTangCa()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTangCa");
			return DataPortal.Create<LoaiTangCa>();
		}

		public static LoaiTangCa GetLoaiTangCa(int maLoaiTangCa)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiTangCa");
			return DataPortal.Fetch<LoaiTangCa>(new Criteria(maLoaiTangCa));
		}

		public static void DeleteLoaiTangCa(int maLoaiTangCa)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTangCa");
			DataPortal.Delete(new Criteria(maLoaiTangCa));
		}

		public override LoaiTangCa Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTangCa");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTangCa");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiTangCa");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiTangCa NewLoaiTangCaChild()
		{
			LoaiTangCa child = new LoaiTangCa();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiTangCa GetLoaiTangCa(SafeDataReader dr)
		{
			LoaiTangCa child =  new LoaiTangCa();
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
			public int MaLoaiTangCa;

			public Criteria(int maLoaiTangCa)
			{
				this.MaLoaiTangCa = maLoaiTangCa;
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
                cm.CommandText = "spd_SelecttblnsLoaiTangCa";

				cm.Parameters.AddWithValue("@MaLoaiTangCa", criteria.MaLoaiTangCa);

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

				ExecuteInsert(cn);

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
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maLoaiTangCa));
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
				cm.CommandText = "DeleteLoaiTangCa";

				cm.Parameters.AddWithValue("@MaLoaiTangCa", criteria.MaLoaiTangCa);

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
			_maLoaiTangCa = dr.GetInt32("MaLoaiTangCa");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiTangCa = dr.GetString("TenLoaiTangCa");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLoaiTangCa";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiTangCa = (int)cm.Parameters["@MaLoaiTangCa"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTangCa", _tenLoaiTangCa);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
			cm.Parameters["@MaLoaiTangCa"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLoaiTangCa";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiTangCa", _maLoaiTangCa);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTangCa", _tenLoaiTangCa);
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

			ExecuteDelete(cn, new Criteria(_maLoaiTangCa));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

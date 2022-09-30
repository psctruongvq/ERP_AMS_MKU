
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomChucvu : Csla.BusinessBase<NhomChucvu>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNhomChucVu = 0;
		private string _maQuanLy = string.Empty;
		private string _tenNhomChucVu = string.Empty;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhomChucVu
		{
			get
			{
				CanReadProperty("MaNhomChucVu", true);
				return _maNhomChucVu;
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

		public string TenNhomChucVu
		{
			get
			{
				CanReadProperty("TenNhomChucVu", true);
				return _tenNhomChucVu;
			}
			set
			{
				CanWriteProperty("TenNhomChucVu", true);
				if (value == null) value = string.Empty;
				if (!_tenNhomChucVu.Equals(value))
				{
					_tenNhomChucVu = value;
					PropertyHasChanged("TenNhomChucVu");
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
 
		protected override object GetIdValue()
		{
			return _maNhomChucVu;
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
			// TenNhomChucVu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNhomChucVu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomChucVu", 500));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in NhomChucvu
			//AuthorizationRules.AllowRead("MaNhomChucVu", "NhomChucvuReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NhomChucvuReadGroup");
			//AuthorizationRules.AllowRead("TenNhomChucVu", "NhomChucvuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "NhomChucvuReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NhomChucvuWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhomChucVu", "NhomChucvuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "NhomChucvuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomChucvu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucvuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomChucvu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucvuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomChucvu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucvuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomChucvu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucvuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhomChucvu()
		{ /* require use of factory method */ }

		public static NhomChucvu NewNhomChucvu()
		{
            NhomChucvu item = new NhomChucvu();
            item.MarkAsChild();
            return item;
		}

		public static NhomChucvu GetNhomChucvu(int maNhomChucVu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhomChucvu");
			return DataPortal.Fetch<NhomChucvu>(new Criteria(maNhomChucVu));
		}

		public static void DeleteNhomChucvu(int maNhomChucVu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomChucvu");
			DataPortal.Delete(new Criteria(maNhomChucVu));
		}

		public override NhomChucvu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomChucvu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomChucvu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhomChucvu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhomChucvu NewNhomChucvuChild()
		{
			NhomChucvu child = new NhomChucvu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhomChucvu GetNhomChucvu(SafeDataReader dr)
		{
			NhomChucvu child =  new NhomChucvu();
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
			public int MaNhomChucVu;

			public Criteria(int maNhomChucVu)
			{
				this.MaNhomChucVu = maNhomChucVu;
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
                cm.CommandText = "spd_SelecttblnsNhomChucVu";

				cm.Parameters.AddWithValue("@MaNhomChucVu", criteria.MaNhomChucVu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
			DataPortal_Delete(new Criteria(_maNhomChucVu));
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
                cm.CommandText = "spd_DeletetblnsNhomChucVu";

				cm.Parameters.AddWithValue("@MaNhomChucVu", criteria.MaNhomChucVu);

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
			_maNhomChucVu = dr.GetInt32("MaNhomChucVu");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenNhomChucVu = dr.GetString("TenNhomChucVu");
			_dienGiai = dr.GetString("DienGiai");
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
                cm.CommandText = "spd_InserttblnsNhomChucVu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNhomChucVu = (int)cm.Parameters["@MaNhomChucVu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenNhomChucVu", _tenNhomChucVu);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomChucVu", _maNhomChucVu);
			cm.Parameters["@MaNhomChucVu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNhomChucVu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhomChucVu", _maNhomChucVu);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenNhomChucVu", _tenNhomChucVu);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maNhomChucVu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

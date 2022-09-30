
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomChucDanh : Csla.BusinessBase<NhomChucDanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNhomChucDanh = 0;
		private string _maQuanLy = string.Empty;
		private string _tenNhomChucDanh = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhomChucDanh
		{
			get
			{
				CanReadProperty("MaNhomChucDanh", true);
				return _maNhomChucDanh;
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

		public string TenNhomChucDanh
		{
			get
			{
				CanReadProperty("TenNhomChucDanh", true);
				return _tenNhomChucDanh;
			}
			set
			{
				CanWriteProperty("TenNhomChucDanh", true);
				if (value == null) value = string.Empty;
				if (!_tenNhomChucDanh.Equals(value))
				{
					_tenNhomChucDanh = value;
					PropertyHasChanged("TenNhomChucDanh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNhomChucDanh;
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
			// TenNhomChucDanh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomChucDanh", 500));
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
			//TODO: Define authorization rules in NhomChucDanh
			//AuthorizationRules.AllowRead("MaNhomChucDanh", "NhomChucDanhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NhomChucDanhReadGroup");
			//AuthorizationRules.AllowRead("TenNhomChucDanh", "NhomChucDanhReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NhomChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhomChucDanh", "NhomChucDanhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucDanhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucDanhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucDanhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomChucDanhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhomChucDanh()
		{ /* require use of factory method */ }

		public static NhomChucDanh NewNhomChucDanh()
		{
            NhomChucDanh item = new NhomChucDanh();
            item.MarkAsChild();
            return item;
		}

		public static NhomChucDanh GetNhomChucDanh(int maNhomChucDanh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhomChucDanh");
			return DataPortal.Fetch<NhomChucDanh>(new Criteria(maNhomChucDanh));
		}

		public static void DeleteNhomChucDanh(int maNhomChucDanh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomChucDanh");
			DataPortal.Delete(new Criteria(maNhomChucDanh));
		}

		public override NhomChucDanh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomChucDanh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomChucDanh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhomChucDanh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhomChucDanh NewNhomChucDanhChild()
		{
			NhomChucDanh child = new NhomChucDanh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhomChucDanh GetNhomChucDanh(SafeDataReader dr)
		{
			NhomChucDanh child =  new NhomChucDanh();
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
			public int MaNhomChucDanh;

			public Criteria(int maNhomChucDanh)
			{
				this.MaNhomChucDanh = maNhomChucDanh;
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
                cm.CommandText = "spd_SelecttblnsNhomChucDanh";

				cm.Parameters.AddWithValue("@MaNhomChucDanh", criteria.MaNhomChucDanh);

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
			DataPortal_Delete(new Criteria(_maNhomChucDanh));
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
                cm.CommandText = "spd_DeletetblnsNhomChucDanh";

				cm.Parameters.AddWithValue("@MaNhomChucDanh", criteria.MaNhomChucDanh);

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
			_maNhomChucDanh = dr.GetInt32("MaNhomChucDanh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenNhomChucDanh = dr.GetString("TenNhomChucDanh");
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
                cm.CommandText = "spd_InserttblnsNhomChucDanh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNhomChucDanh = (int)cm.Parameters["@MaNhomChucDanh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenNhomChucDanh.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomChucDanh", _tenNhomChucDanh);
			else
				cm.Parameters.AddWithValue("@TenNhomChucDanh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomChucDanh", _maNhomChucDanh);
			cm.Parameters["@MaNhomChucDanh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNhomChucDanh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhomChucDanh", _maNhomChucDanh);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenNhomChucDanh.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomChucDanh", _tenNhomChucDanh);
			else
				cm.Parameters.AddWithValue("@TenNhomChucDanh", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maNhomChucDanh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

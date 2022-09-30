
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomNgachLuongBaoHiem : Csla.BusinessBase<NhomNgachLuongBaoHiem>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNhomNgachLuongBaoHiem = 0;
		private string _maQL = string.Empty;
		private string _tenNhomNgachLuongBaoHiem = string.Empty;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhomNgachLuongBaoHiem
		{
			get
			{
				CanReadProperty("MaNhomNgachLuongBaoHiem", true);
				return _maNhomNgachLuongBaoHiem;
			}
		}

		public string MaQL
		{
			get
			{
				CanReadProperty("MaQL", true);
				return _maQL;
			}
			set
			{
				CanWriteProperty("MaQL", true);
				if (value == null) value = string.Empty;
				if (!_maQL.Equals(value))
				{
					_maQL = value;
					PropertyHasChanged("MaQL");
				}
			}
		}

		public string TenNhomNgachLuongBaoHiem
		{
			get
			{
				CanReadProperty("TenNhomNgachLuongBaoHiem", true);
				return _tenNhomNgachLuongBaoHiem;
			}
			set
			{
				CanWriteProperty("TenNhomNgachLuongBaoHiem", true);
				if (value == null) value = string.Empty;
				if (!_tenNhomNgachLuongBaoHiem.Equals(value))
				{
					_tenNhomNgachLuongBaoHiem = value;
					PropertyHasChanged("TenNhomNgachLuongBaoHiem");
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
			return _maNhomNgachLuongBaoHiem;
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
			// MaQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQL", 50));
			//
			// TenNhomNgachLuongBaoHiem
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomNgachLuongBaoHiem", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 50));
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
			//TODO: Define authorization rules in NhomNgachLuongBaoHiem
			//AuthorizationRules.AllowRead("MaNhomNgachLuongBaoHiem", "NhomNgachLuongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("MaQL", "NhomNgachLuongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("TenNhomNgachLuongBaoHiem", "NhomNgachLuongBaoHiemReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "NhomNgachLuongBaoHiemReadGroup");

			//AuthorizationRules.AllowWrite("MaQL", "NhomNgachLuongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhomNgachLuongBaoHiem", "NhomNgachLuongBaoHiemWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "NhomNgachLuongBaoHiemWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomNgachLuongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongBaoHiemViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomNgachLuongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongBaoHiemAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomNgachLuongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongBaoHiemEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomNgachLuongBaoHiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomNgachLuongBaoHiemDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhomNgachLuongBaoHiem()
		{ /* require use of factory method */ }

		public static NhomNgachLuongBaoHiem NewNhomNgachLuongBaoHiem()
		{
            NhomNgachLuongBaoHiem item = new NhomNgachLuongBaoHiem();
            item.MarkAsChild();
            return item;
		}

		public static NhomNgachLuongBaoHiem GetNhomNgachLuongBaoHiem(int maNhomNgachLuongBaoHiem)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhomNgachLuongBaoHiem");
			return DataPortal.Fetch<NhomNgachLuongBaoHiem>(new Criteria(maNhomNgachLuongBaoHiem));
		}

		public static void DeleteNhomNgachLuongBaoHiem(int maNhomNgachLuongBaoHiem)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomNgachLuongBaoHiem");
			DataPortal.Delete(new Criteria(maNhomNgachLuongBaoHiem));
		}

		public override NhomNgachLuongBaoHiem Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomNgachLuongBaoHiem");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomNgachLuongBaoHiem");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhomNgachLuongBaoHiem");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhomNgachLuongBaoHiem NewNhomNgachLuongBaoHiemChild()
		{
			NhomNgachLuongBaoHiem child = new NhomNgachLuongBaoHiem();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhomNgachLuongBaoHiem GetNhomNgachLuongBaoHiem(SafeDataReader dr)
		{
			NhomNgachLuongBaoHiem child =  new NhomNgachLuongBaoHiem();
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
			public int MaNhomNgachLuongBaoHiem;

			public Criteria(int maNhomNgachLuongBaoHiem)
			{
				this.MaNhomNgachLuongBaoHiem = maNhomNgachLuongBaoHiem;
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
                cm.CommandText = "spd_SelecttblnsNhomNgachLuongBaoHiem";

				cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", criteria.MaNhomNgachLuongBaoHiem);

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
			DataPortal_Delete(new Criteria(_maNhomNgachLuongBaoHiem));
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
                cm.CommandText = "spd_DeletetblnsNhomNgachLuongBaoHiem";

				cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", criteria.MaNhomNgachLuongBaoHiem);

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
			_maNhomNgachLuongBaoHiem = dr.GetInt32("MaNhomNgachLuongBaoHiem");
			_maQL = dr.GetString("MaQL");
			_tenNhomNgachLuongBaoHiem = dr.GetString("TenNhomNgachLuongBaoHiem");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhomNgachLuongBaoHiemList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhomNgachLuongBaoHiemList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhomNgachLuongBaoHiem";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNhomNgachLuongBaoHiem = (int)cm.Parameters["@MaNhomNgachLuongBaoHiem"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhomNgachLuongBaoHiemList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQL.Length > 0)
				cm.Parameters.AddWithValue("@MaQL", _maQL);
			else
				cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
			if (_tenNhomNgachLuongBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomNgachLuongBaoHiem", _tenNhomNgachLuongBaoHiem);
			else
				cm.Parameters.AddWithValue("@TenNhomNgachLuongBaoHiem", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _maNhomNgachLuongBaoHiem);
			cm.Parameters["@MaNhomNgachLuongBaoHiem"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhomNgachLuongBaoHiemList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhomNgachLuongBaoHiemList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhomNgachLuongBaoHiem";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhomNgachLuongBaoHiemList parent)
		{
			cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _maNhomNgachLuongBaoHiem);
			if (_maQL.Length > 0)
				cm.Parameters.AddWithValue("@MaQL", _maQL);
			else
				cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
			if (_tenNhomNgachLuongBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomNgachLuongBaoHiem", _tenNhomNgachLuongBaoHiem);
			else
				cm.Parameters.AddWithValue("@TenNhomNgachLuongBaoHiem", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNhomNgachLuongBaoHiem));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

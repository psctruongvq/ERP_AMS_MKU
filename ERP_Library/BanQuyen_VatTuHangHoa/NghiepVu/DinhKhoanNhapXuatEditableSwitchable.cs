
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DinhKhoanNhapXuat : Csla.BusinessBase<DinhKhoanNhapXuat>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDinhKhoan = 0;
		private bool _ghiMucNganSach = false;
		private bool _laMotNoNhieuCo = false;
		private bool _noCo = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDinhKhoan
		{
			get
			{
				CanReadProperty("MaDinhKhoan", true);
				return _maDinhKhoan;
			}
		}

		public bool GhiMucNganSach
		{
			get
			{
				CanReadProperty("GhiMucNganSach", true);
				return _ghiMucNganSach;
			}
			set
			{
				CanWriteProperty("GhiMucNganSach", true);
				if (!_ghiMucNganSach.Equals(value))
				{
					_ghiMucNganSach = value;
					PropertyHasChanged("GhiMucNganSach");
				}
			}
		}

		public bool LaMotNoNhieuCo
		{
			get
			{
				CanReadProperty("LaMotNoNhieuCo", true);
				return _laMotNoNhieuCo;
			}
			set
			{
				CanWriteProperty("LaMotNoNhieuCo", true);
				if (!_laMotNoNhieuCo.Equals(value))
				{
					_laMotNoNhieuCo = value;
					PropertyHasChanged("LaMotNoNhieuCo");
				}
			}
		}

		public bool NoCo
		{
			get
			{
				CanReadProperty("NoCo", true);
				return _noCo;
			}
			set
			{
				CanWriteProperty("NoCo", true);
				if (!_noCo.Equals(value))
				{
					_noCo = value;
					PropertyHasChanged("NoCo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDinhKhoan;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

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
			//TODO: Define authorization rules in DinhKhoanNhapXuat
			//AuthorizationRules.AllowRead("MaDinhKhoan", "DinhKhoanNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("GhiMucNganSach", "DinhKhoanNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("LaMotNoNhieuCo", "DinhKhoanNhapXuatReadGroup");
			//AuthorizationRules.AllowRead("NoCo", "DinhKhoanNhapXuatReadGroup");

			//AuthorizationRules.AllowWrite("GhiMucNganSach", "DinhKhoanNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("LaMotNoNhieuCo", "DinhKhoanNhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("NoCo", "DinhKhoanNhapXuatWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DinhKhoanNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DinhKhoanNhapXuatViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DinhKhoanNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DinhKhoanNhapXuatAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DinhKhoanNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DinhKhoanNhapXuatEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DinhKhoanNhapXuat
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DinhKhoanNhapXuatDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DinhKhoanNhapXuat()
		{ /* require use of factory method */ }

		public static DinhKhoanNhapXuat NewDinhKhoanNhapXuat()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DinhKhoanNhapXuat");
			return DataPortal.Create<DinhKhoanNhapXuat>();
		}

		public static DinhKhoanNhapXuat GetDinhKhoanNhapXuat(int maDinhKhoan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DinhKhoanNhapXuat");
			return DataPortal.Fetch<DinhKhoanNhapXuat>(new Criteria(maDinhKhoan));
		}

		public static void DeleteDinhKhoanNhapXuat(int maDinhKhoan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DinhKhoanNhapXuat");
			DataPortal.Delete(new Criteria(maDinhKhoan));
		}

		public override DinhKhoanNhapXuat Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DinhKhoanNhapXuat");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DinhKhoanNhapXuat");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DinhKhoanNhapXuat");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DinhKhoanNhapXuat NewDinhKhoanNhapXuatChild()
		{
			DinhKhoanNhapXuat child = new DinhKhoanNhapXuat();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DinhKhoanNhapXuat GetDinhKhoanNhapXuat(SafeDataReader dr)
		{
			DinhKhoanNhapXuat child =  new DinhKhoanNhapXuat();
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
			public int MaDinhKhoan;

			public Criteria(int maDinhKhoan)
			{
				this.MaDinhKhoan = maDinhKhoan;
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
                cm.CommandText = "spd_LoadMaCaBiet_DinhKhoan";

				cm.Parameters.AddWithValue("@MaDinhKhoan", criteria.MaDinhKhoan);

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
			DataPortal_Delete(new Criteria(_maDinhKhoan));
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
                cm.CommandText = "spd_Delete_DinhKhoan";

				cm.Parameters.AddWithValue("@MaDinhKhoan", criteria.MaDinhKhoan);

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
			_maDinhKhoan = dr.GetInt32("MaDinhKhoan");
			_ghiMucNganSach = dr.GetBoolean("GhiMucNganSach");
			_laMotNoNhieuCo = dr.GetBoolean("LaMotNoNhieuCo");
			_noCo = dr.GetBoolean("NoCo");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_DinhKhoan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maDinhKhoan = (int)cm.Parameters["@MaDinhKhoan"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_ghiMucNganSach != false)
				cm.Parameters.AddWithValue("@GhiMucNganSach", _ghiMucNganSach);
			else
				cm.Parameters.AddWithValue("@GhiMucNganSach", DBNull.Value);
			if (_laMotNoNhieuCo != false)
				cm.Parameters.AddWithValue("@LaMotNoNhieuCo", _laMotNoNhieuCo);
			else
				cm.Parameters.AddWithValue("@LaMotNoNhieuCo", DBNull.Value);
			if (_noCo != false)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			cm.Parameters["@MaDinhKhoan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_DinhKhoanNhapXuat";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			cm.Parameters.AddWithValue("@MaDinhKhoan", _maDinhKhoan);
			if (_ghiMucNganSach != false)
				cm.Parameters.AddWithValue("@GhiMucNganSach", _ghiMucNganSach);
			else
				cm.Parameters.AddWithValue("@GhiMucNganSach", DBNull.Value);
			if (_laMotNoNhieuCo != false)
				cm.Parameters.AddWithValue("@LaMotNoNhieuCo", _laMotNoNhieuCo);
			else
				cm.Parameters.AddWithValue("@LaMotNoNhieuCo", DBNull.Value);
			if (_noCo != false)
				cm.Parameters.AddWithValue("@NoCo", _noCo);
			else
				cm.Parameters.AddWithValue("@NoCo", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maDinhKhoan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()]
    public class NhomHHDVMuaVao : Csla.BusinessBase<NhomHHDVMuaVao>
	{
		#region Business Properties and Methods

		//declare members
		private byte _id = 0;
		private string _maQL = string.Empty;
		private string _tenNhomHHDVMuaVao = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public byte Id
		{
			get
			{
				CanReadProperty("Id", true);
				return _id;
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

		public string TenNhomHHDVMuaVao
		{
			get
			{
				CanReadProperty("TenNhomHHDVMuaVao", true);
				return _tenNhomHHDVMuaVao;
			}
			set
			{
				CanWriteProperty("TenNhomHHDVMuaVao", true);
				if (value == null) value = string.Empty;
				if (!_tenNhomHHDVMuaVao.Equals(value))
				{
					_tenNhomHHDVMuaVao = value;
					PropertyHasChanged("TenNhomHHDVMuaVao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _id;
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
			//TODO: Define authorization rules in NhomHHDVMuaVao
			//AuthorizationRules.AllowRead("Id", "NhomHHDVMuaVaoReadGroup");
			//AuthorizationRules.AllowRead("MaQL", "NhomHHDVMuaVaoReadGroup");
			//AuthorizationRules.AllowRead("TenNhomHHDVMuaVao", "NhomHHDVMuaVaoReadGroup");

			//AuthorizationRules.AllowWrite("MaQL", "NhomHHDVMuaVaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhomHHDVMuaVao", "NhomHHDVMuaVaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomHHDVMuaVao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomHHDVMuaVao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomHHDVMuaVao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomHHDVMuaVao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomHHDVMuaVaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
        private NhomHHDVMuaVao()
		{ /* require use of factory method */ }

        public static NhomHHDVMuaVao NewNhomHHDVMuaVao()
		{
			if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHHDVMuaVao");
            return DataPortal.Create<NhomHHDVMuaVao>();
		}

        public static NhomHHDVMuaVao GetNhomHHDVMuaVao(byte id)
		{
			if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a NhomHHDVMuaVao");
            return DataPortal.Fetch<NhomHHDVMuaVao>(new Criteria(id));
		}

        public override NhomHHDVMuaVao Save()
		{
			if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a NhomHHDVMuaVao");
			else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a NhomHHDVMuaVao");
			else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a NhomHHDVMuaVao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        internal static NhomHHDVMuaVao NewNhomHHDVMuaVaoChild()
		{
            NhomHHDVMuaVao child = new NhomHHDVMuaVao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        internal static NhomHHDVMuaVao GetNhomHHDVMuaVao(SafeDataReader dr)
		{
            NhomHHDVMuaVao child = new NhomHHDVMuaVao();
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
			public byte Id;

			public Criteria(byte id)
			{
                this.Id = id;
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
                cm.CommandText = "spd_SelecttblNhomHHDVMuaVao";

				cm.Parameters.AddWithValue("@id", criteria.Id);

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
			DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "spd_DeletetblNhomHHDVMuaVao";

				cm.Parameters.AddWithValue("@id", criteria.Id);

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
            _id = dr.GetByte("Id");
            _maQL = dr.GetString("MaQL");
            _tenNhomHHDVMuaVao = dr.GetString("TenNhomHHDVMuaVao");
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
                cm.CommandText = "spd_InserttbNhomHHDVMuaVao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_id = (byte)cm.Parameters["@id"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenNhomHHDVMuaVao.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomHHDVMuaVao", _tenNhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@TenNhomHHDVMuaVao", DBNull.Value);
            cm.Parameters.AddWithValue("@NewId", _id);
            cm.Parameters["@NewId"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblNhomHHDVMuaVao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
            cm.Parameters.AddWithValue("@Id", _id);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenNhomHHDVMuaVao.Length > 0)
                cm.Parameters.AddWithValue("@TenNhomHHDVMuaVao", _tenNhomHHDVMuaVao);
            else
                cm.Parameters.AddWithValue("@TenNhomHHDVMuaVao", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_id));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

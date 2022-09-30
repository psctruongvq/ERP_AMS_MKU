
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_QuyetDinh : Csla.BusinessBase<ChungTu_QuyetDinh>
	{
		#region Business Properties and Methods

		//declare members
		private long _machungtuQuyetdinh = 0;
		private long _maChungTu = 0;
		private long _maQuyetDinh = 0;
		private int _loai = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MachungtuQuyetdinh
		{
			get
			{
				CanReadProperty("MachungtuQuyetdinh", true);
				return _machungtuQuyetdinh;
			}
		}

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

		public long MaQuyetDinh
		{
			get
			{
				CanReadProperty("MaQuyetDinh", true);
				return _maQuyetDinh;
			}
			set
			{
				CanWriteProperty("MaQuyetDinh", true);
				if (!_maQuyetDinh.Equals(value))
				{
					_maQuyetDinh = value;
					PropertyHasChanged("MaQuyetDinh");
				}
			}
		}

		public int Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _machungtuQuyetdinh;
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
			//TODO: Define authorization rules in ChungTu_QuyetDinh
			//AuthorizationRules.AllowRead("MachungtuQuyetdinh", "ChungTu_QuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "ChungTu_QuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuyetDinh", "ChungTu_QuyetDinhReadGroup");
			//AuthorizationRules.AllowRead("Loai", "ChungTu_QuyetDinhReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "ChungTu_QuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuyetDinh", "ChungTu_QuyetDinhWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "ChungTu_QuyetDinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_QuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_QuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_QuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_QuyetDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_QuyetDinh()
		{ /* require use of factory method */ }

        public ChungTu_QuyetDinh(long machungTu, long maquyetDinh, int loai)
        { /* require use of factory method */
            this._maChungTu = machungTu;
            this._maQuyetDinh = maquyetDinh;
            this._loai = loai;
        }

		public static ChungTu_QuyetDinh NewChungTu_QuyetDinh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_QuyetDinh");
			return DataPortal.Create<ChungTu_QuyetDinh>();
		}

		public static ChungTu_QuyetDinh GetChungTu_QuyetDinh(long machungtuQuyetdinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTu_QuyetDinh");
			return DataPortal.Fetch<ChungTu_QuyetDinh>(new Criteria(machungtuQuyetdinh));
		}

		public static void DeleteChungTu_QuyetDinh(long machungtuQuyetdinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_QuyetDinh");
			DataPortal.Delete(new Criteria(machungtuQuyetdinh));
		}

		public override ChungTu_QuyetDinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTu_QuyetDinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_QuyetDinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChungTu_QuyetDinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTu_QuyetDinh NewChungTu_QuyetDinhChild()
		{
			ChungTu_QuyetDinh child = new ChungTu_QuyetDinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTu_QuyetDinh GetChungTu_QuyetDinh(SafeDataReader dr)
		{
			ChungTu_QuyetDinh child =  new ChungTu_QuyetDinh();
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
			public long MachungtuQuyetdinh;

			public Criteria(long machungtuQuyetdinh)
			{
				this.MachungtuQuyetdinh = machungtuQuyetdinh;
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
				cm.CommandText = "GetChungTu_QuyetDinh";

				cm.Parameters.AddWithValue("@MaChungTu_QuyetDinh", criteria.MachungtuQuyetdinh);

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
					ExecuteInsert(tr, 0);

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
						ExecuteUpdate(tr, 0);
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
			DataPortal_Delete(new Criteria(_machungtuQuyetdinh));
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
				cm.CommandText = "DeleteChungTu_QuyetDinh";

				cm.Parameters.AddWithValue("@MaChungTu_QuyetDinh", criteria.MachungtuQuyetdinh);

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
			_machungtuQuyetdinh = dr.GetInt64("MaChungTu_QuyetDinh");
			_maChungTu = dr.GetInt64("MaChungTu");
			_maQuyetDinh = dr.GetInt64("MaQuyetDinh");
			_loai = dr.GetInt32("Loai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, long MaChungTu)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, MaChungTu);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, long MaChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblcnChungTu_QuyetDinh";

				AddInsertParameters(cm, MaChungTu);

				cm.ExecuteNonQuery();

				_machungtuQuyetdinh = (long)cm.Parameters["@MaChungTu_QuyetDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, long MaChungTu)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
			cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@MaChungTu_QuyetDinh", _machungtuQuyetdinh);
			cm.Parameters["@MaChungTu_QuyetDinh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, long MaChungTu)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, MaChungTu);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, long MaChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnChungTu_QuyetDinh";

				AddUpdateParameters(cm, MaChungTu);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, long MaChungTu)
		{
			cm.Parameters.AddWithValue("@MaChungTu_QuyetDinh", _machungtuQuyetdinh);
			cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
			cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
			cm.Parameters.AddWithValue("@Loai", _loai);
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

			ExecuteDelete(tr, new Criteria(_machungtuQuyetdinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

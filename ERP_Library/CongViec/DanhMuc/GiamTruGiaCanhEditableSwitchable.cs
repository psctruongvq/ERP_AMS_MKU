
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GiamTruGiaCanh : Csla.BusinessBase<GiamTruGiaCanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maGiaCanh = 0;
		private string _maQLGiaCanh = string.Empty;
		private string _tenGiaCanh = string.Empty;
		private decimal _soTienGiamTru = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaGiaCanh
		{
			get
			{
				CanReadProperty("MaGiaCanh", true);
				return _maGiaCanh;
			}
		}

		public string MaQLGiaCanh
		{
			get
			{
				CanReadProperty("MaQLGiaCanh", true);
				return _maQLGiaCanh;
			}
			set
			{
				CanWriteProperty("MaQLGiaCanh", true);
				if (value == null) value = string.Empty;
				if (!_maQLGiaCanh.Equals(value))
				{
					_maQLGiaCanh = value;
					PropertyHasChanged("MaQLGiaCanh");
				}
			}
		}

		public string TenGiaCanh
		{
			get
			{
				CanReadProperty("TenGiaCanh", true);
				return _tenGiaCanh;
			}
			set
			{
				CanWriteProperty("TenGiaCanh", true);
				if (value == null) value = string.Empty;
				if (!_tenGiaCanh.Equals(value))
				{
					_tenGiaCanh = value;
					PropertyHasChanged("TenGiaCanh");
				}
			}
		}

		public decimal SoTienGiamTru
		{
			get
			{
				CanReadProperty("SoTienGiamTru", true);
				return _soTienGiamTru;
			}
			set
			{
				CanWriteProperty("SoTienGiamTru", true);
				if (!_soTienGiamTru.Equals(value))
				{
					_soTienGiamTru = value;
					PropertyHasChanged("SoTienGiamTru");
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
			return _maGiaCanh;
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
			// MaQLGiaCanh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQLGiaCanh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLGiaCanh", 50));
			//
			// TenGiaCanh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenGiaCanh", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 100));
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
			//TODO: Define authorization rules in GiamTruGiaCanh
			//AuthorizationRules.AllowRead("MaGiaCanh", "GiamTruGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("MaQLGiaCanh", "GiamTruGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("TenGiaCanh", "GiamTruGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("SoTienGiamTru", "GiamTruGiaCanhReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "GiamTruGiaCanhReadGroup");

			//AuthorizationRules.AllowWrite("MaQLGiaCanh", "GiamTruGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("TenGiaCanh", "GiamTruGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienGiamTru", "GiamTruGiaCanhWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "GiamTruGiaCanhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GiamTruGiaCanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiamTruGiaCanhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GiamTruGiaCanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiamTruGiaCanhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GiamTruGiaCanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiamTruGiaCanhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GiamTruGiaCanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GiamTruGiaCanhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GiamTruGiaCanh()
		{ /* require use of factory method */ }

		public static GiamTruGiaCanh NewGiamTruGiaCanh()
		{
            GiamTruGiaCanh child = new GiamTruGiaCanh();
            child.MarkAsChild();
            return child;
		}

		public static GiamTruGiaCanh GetGiamTruGiaCanh(int maGiaCanh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GiamTruGiaCanh");
			return DataPortal.Fetch<GiamTruGiaCanh>(new Criteria(maGiaCanh));
		}

		public static void DeleteGiamTruGiaCanh(int maGiaCanh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiamTruGiaCanh");
			DataPortal.Delete(new Criteria(maGiaCanh));
		}

		public override GiamTruGiaCanh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GiamTruGiaCanh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GiamTruGiaCanh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a GiamTruGiaCanh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static GiamTruGiaCanh NewGiamTruGiaCanhChild()
		{
			GiamTruGiaCanh child = new GiamTruGiaCanh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static GiamTruGiaCanh GetGiamTruGiaCanh(SafeDataReader dr)
		{
			GiamTruGiaCanh child =  new GiamTruGiaCanh();
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
			public int MaGiaCanh;

			public Criteria(int maGiaCanh)
			{
				this.MaGiaCanh = maGiaCanh;
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
                cm.CommandText = "spd_SelecttblnsGiamTruGiaCanh";

				cm.Parameters.AddWithValue("@MaGiaCanh", criteria.MaGiaCanh);

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
			DataPortal_Delete(new Criteria(_maGiaCanh));
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
                cm.CommandText = "spd_DeletetblnsGiamTruGiaCanh";

				cm.Parameters.AddWithValue("@MaGiaCanh", criteria.MaGiaCanh);

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
			_maGiaCanh = dr.GetInt32("MaGiaCanh");
			_maQLGiaCanh = dr.GetString("MaQLGiaCanh");
			_tenGiaCanh = dr.GetString("TenGiaCanh");
			_soTienGiamTru = dr.GetDecimal("SoTienGiamTru");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, GiamTruGiaCanhList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, GiamTruGiaCanhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsGiamTruGiaCanh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maGiaCanh = (int)cm.Parameters["@MaGiaCanh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, GiamTruGiaCanhList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQLGiaCanh", _maQLGiaCanh);
			if (_tenGiaCanh.Length > 0)
				cm.Parameters.AddWithValue("@TenGiaCanh", _tenGiaCanh);
			else
				cm.Parameters.AddWithValue("@TenGiaCanh", DBNull.Value);
			if (_soTienGiamTru != 0)
				cm.Parameters.AddWithValue("@SoTienGiamTru", _soTienGiamTru);
			else
				cm.Parameters.AddWithValue("@SoTienGiamTru", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaGiaCanh", _maGiaCanh);
			cm.Parameters["@MaGiaCanh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, GiamTruGiaCanhList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, GiamTruGiaCanhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsGiamTruGiaCanh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, GiamTruGiaCanhList parent)
		{
			cm.Parameters.AddWithValue("@MaGiaCanh", _maGiaCanh);
			cm.Parameters.AddWithValue("@MaQLGiaCanh", _maQLGiaCanh);
			if (_tenGiaCanh.Length > 0)
				cm.Parameters.AddWithValue("@TenGiaCanh", _tenGiaCanh);
			else
				cm.Parameters.AddWithValue("@TenGiaCanh", DBNull.Value);
			if (_soTienGiamTru != 0)
				cm.Parameters.AddWithValue("@SoTienGiamTru", _soTienGiamTru);
			else
				cm.Parameters.AddWithValue("@SoTienGiamTru", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maGiaCanh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

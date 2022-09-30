using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCao : Csla.BusinessBase<BaoCao>
	{
		#region Business Properties and Methods

		//declare members
		private int _stt = 0;
		private string _tenBaoCao = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int Stt
		{
			get
			{
				CanReadProperty("Stt", true);
				return _stt;
			}
		}

		public string TenBaoCao
		{
			get
			{
				CanReadProperty("TenBaoCao", true);
				return _tenBaoCao;
			}
			set
			{
				CanWriteProperty("TenBaoCao", true);
				if (value == null) value = string.Empty;
				if (!_tenBaoCao.Equals(value))
				{
					_tenBaoCao = value;
					PropertyHasChanged("TenBaoCao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _stt;
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
			// TenBaoCao
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenBaoCao");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBaoCao", 4000));
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
			//TODO: Define authorization rules in BaoCao
			//AuthorizationRules.AllowRead("Stt", "BaoCaoReadGroup");
			//AuthorizationRules.AllowRead("TenBaoCao", "BaoCaoReadGroup");

			//AuthorizationRules.AllowWrite("TenBaoCao", "BaoCaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BaoCao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCao()
		{ /* require use of factory method */ }

		public static BaoCao NewBaoCao(int stt)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCao");
			return DataPortal.Create<BaoCao>(new Criteria(stt));
		}

		public static BaoCao GetBaoCao(int stt)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCao");
			return DataPortal.Fetch<BaoCao>(new Criteria(stt));
		}

		public static void DeleteBaoCao(int stt)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCao");
			DataPortal.Delete(new Criteria(stt));
		}

		public override BaoCao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BaoCao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BaoCao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BaoCao(int stt)
		{
			this._stt = stt;
		}

		internal static BaoCao NewBaoCaoChild(int stt)
		{
			BaoCao child = new BaoCao(stt);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BaoCao GetBaoCao(SafeDataReader dr)
		{
			BaoCao child =  new BaoCao();
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
			public int Stt;

			public Criteria(int stt)
			{
				this.Stt = stt;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_stt = criteria.Stt;
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
				cm.CommandText = "GetBaoCao";

				cm.Parameters.AddWithValue("@STT", criteria.Stt);

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
			DataPortal_Delete(new Criteria(_stt));
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
				cm.CommandText = "DeleteBaoCao";

				cm.Parameters.AddWithValue("@STT", criteria.Stt);

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
			_stt = dr.GetInt32("STT");
			_tenBaoCao = dr.GetString("TenBaoCao");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BaoCaoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BaoCaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddBaoCao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BaoCaoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@STT", _stt);
			cm.Parameters.AddWithValue("@TenBaoCao", _tenBaoCao);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BaoCaoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BaoCaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateBaoCao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BaoCaoList parent)
		{
			cm.Parameters.AddWithValue("@STT", _stt);
			cm.Parameters.AddWithValue("@TenBaoCao", _tenBaoCao);
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

			ExecuteDelete(tr, new Criteria(_stt));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

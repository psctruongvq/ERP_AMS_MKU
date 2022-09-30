
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuGiamTruGiaCanh : Csla.BusinessBase<ChungTuGiamTruGiaCanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChungTu = 0;
		private string _tenChungTu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChungTu
		{
			get
			{
				return _maChungTu;
			}
		}

		public string TenChungTu
		{
			get
			{
				return _tenChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChungTu.Equals(value))
				{
					_tenChungTu = value;
					PropertyHasChanged("TenChungTu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChungTu;
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
			// TenChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChungTu", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTuGiamTruGiaCanh()
		{ /* require use of factory method */ }

		public static ChungTuGiamTruGiaCanh NewChungTuGiamTruGiaCanh()
		{
            ChungTuGiamTruGiaCanh item = new ChungTuGiamTruGiaCanh();
            item.MarkAsChild();
            return item;
		}

		public static ChungTuGiamTruGiaCanh GetChungTuGiamTruGiaCanh(int maChungTu)
		{
			return DataPortal.Fetch<ChungTuGiamTruGiaCanh>(new Criteria(maChungTu));
		}

		public static void DeleteChungTuGiamTruGiaCanh(int maChungTu)
		{
			DataPortal.Delete(new Criteria(maChungTu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTuGiamTruGiaCanh NewChungTuGiamTruGiaCanhChild()
		{
			ChungTuGiamTruGiaCanh child = new ChungTuGiamTruGiaCanh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTuGiamTruGiaCanh GetChungTuGiamTruGiaCanh(SafeDataReader dr)
		{
			ChungTuGiamTruGiaCanh child =  new ChungTuGiamTruGiaCanh();
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
			public int MaChungTu;

			public Criteria(int maChungTu)
			{
				this.MaChungTu = maChungTu;
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
				cm.CommandText = "SelecttblnsChungTuGiamTruGiaCanh";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			DataPortal_Delete(new Criteria(_maChungTu));
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
				cm.CommandText = "DeletetblnsChungTuGiamTruGiaCanh";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			_maChungTu = dr.GetInt32("MaChungTu");
			_tenChungTu = dr.GetString("TenChungTu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTuGiamTruGiaCanhList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTuGiamTruGiaCanhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsChungTuGiamTruGiaCanh";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChungTu = (int)cm.Parameters["@MaChungTu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTuGiamTruGiaCanhList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenChungTu.Length > 0)
				cm.Parameters.AddWithValue("@TenChungTu", _tenChungTu);
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChungTuGiamTruGiaCanhList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChungTuGiamTruGiaCanhList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsChungTuGiamTruGiaCanh";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTuGiamTruGiaCanhList parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_tenChungTu.Length > 0)
				cm.Parameters.AddWithValue("@TenChungTu", _tenChungTu);
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

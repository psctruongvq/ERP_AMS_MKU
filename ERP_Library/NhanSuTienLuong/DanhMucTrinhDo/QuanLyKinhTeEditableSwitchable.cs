
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanLyKinhTe : Csla.BusinessBase<QuanLyKinhTe>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuanLyKinhTe = 0;
		private string _maQuanLy = string.Empty;
		private string _tenQuanLyKinhTe = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuanLyKinhTe
		{
			get
			{
				CanReadProperty("MaQuanLyKinhTe", true);
				return _maQuanLyKinhTe;
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
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public string TenQuanLyKinhTe
		{
			get
			{
				CanReadProperty("TenQuanLyKinhTe", true);
				return _tenQuanLyKinhTe;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenQuanLyKinhTe.Equals(value))
				{
					_tenQuanLyKinhTe = value;
					PropertyHasChanged("TenQuanLyKinhTe");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuanLyKinhTe;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenQuanLyKinhTe
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanLyKinhTe", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private QuanLyKinhTe()
		{ /* require use of factory method */ }

		public static QuanLyKinhTe NewQuanLyKinhTe()
		{
			return DataPortal.Create<QuanLyKinhTe>();
		}
        public static QuanLyKinhTe NewQuanLyKinhTe(int maQL,string tenQL)
        {
            return new QuanLyKinhTe(maQL, tenQL);
        }
        public QuanLyKinhTe(int maQL, string tenQL)
        {
            this._maQuanLyKinhTe = maQL;
            this._tenQuanLyKinhTe = tenQL;
        }
		public static QuanLyKinhTe GetQuanLyKinhTe(int maQuanLyKinhTe)
		{
			return DataPortal.Fetch<QuanLyKinhTe>(new Criteria(maQuanLyKinhTe));
		}

		public static void DeleteQuanLyKinhTe(int maQuanLyKinhTe)
		{
			DataPortal.Delete(new Criteria(maQuanLyKinhTe));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanLyKinhTe NewQuanLyKinhTeChild()
		{
			QuanLyKinhTe child = new QuanLyKinhTe();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanLyKinhTe GetQuanLyKinhTe(SafeDataReader dr)
		{
			QuanLyKinhTe child =  new QuanLyKinhTe();
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
			public int MaQuanLyKinhTe;

			public Criteria(int maQuanLyKinhTe)
			{
				this.MaQuanLyKinhTe = maQuanLyKinhTe;
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
                cm.CommandText = "spd_SelecttblnsQuanLyKinhTe";

				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", criteria.MaQuanLyKinhTe);

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
			DataPortal_Delete(new Criteria(_maQuanLyKinhTe));
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
                cm.CommandText = "spd_DeletetblnsQuanLyKinhTe";

				cm.Parameters.AddWithValue("@MaQuanLyKinhTe", criteria.MaQuanLyKinhTe);

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
			_maQuanLyKinhTe = dr.GetInt32("MaQuanLyKinhTe");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenQuanLyKinhTe = dr.GetString("TenQuanLyKinhTe");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, QuanLyKinhTeList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, QuanLyKinhTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuanLyKinhTe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuanLyKinhTe = (int)cm.Parameters["@MaQuanLyKinhTe"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuanLyKinhTeList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanLyKinhTe.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanLyKinhTe", _tenQuanLyKinhTe);
			else
				cm.Parameters.AddWithValue("@TenQuanLyKinhTe", DBNull.Value);
			cm.Parameters.AddWithValue("@MaQuanLyKinhTe", _maQuanLyKinhTe);
			cm.Parameters["@MaQuanLyKinhTe"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, QuanLyKinhTeList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, QuanLyKinhTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuanLyKinhTe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuanLyKinhTeList parent)
		{
			cm.Parameters.AddWithValue("@MaQuanLyKinhTe", _maQuanLyKinhTe);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanLyKinhTe.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanLyKinhTe", _tenQuanLyKinhTe);
			else
				cm.Parameters.AddWithValue("@TenQuanLyKinhTe", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maQuanLyKinhTe));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanLyNhaNuoc : Csla.BusinessBase<QuanLyNhaNuoc>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuaLyNhaNuoc = 0;
		private string _maQuanLy = string.Empty;
		private string _tenQuanLyNhaNuoc = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuaLyNhaNuoc
		{
			get
			{
				CanReadProperty("MaQuaLyNhaNuoc", true);
				return _maQuaLyNhaNuoc;
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

		public string TenQuanLyNhaNuoc
		{
			get
			{
				CanReadProperty("TenQuanLyNhaNuoc", true);
				return _tenQuanLyNhaNuoc;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenQuanLyNhaNuoc.Equals(value))
				{
					_tenQuanLyNhaNuoc = value;
					PropertyHasChanged("TenQuanLyNhaNuoc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuaLyNhaNuoc;
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
			// TenQuanLyNhaNuoc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanLyNhaNuoc", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private QuanLyNhaNuoc()
		{ /* require use of factory method */ }
        public QuanLyNhaNuoc(int maQL, string tenQL)
        {
            this._maQuaLyNhaNuoc = maQL;
            this._tenQuanLyNhaNuoc = tenQL;
            MarkAsChild();
        }
		public static QuanLyNhaNuoc NewQuanLyNhaNuoc()
		{
			return DataPortal.Create<QuanLyNhaNuoc>();
		}
        public static QuanLyNhaNuoc NewQuanLyNhaNuoc(int maQuanLyNN,string tenQLNN)
        {
            return new QuanLyNhaNuoc(maQuanLyNN, tenQLNN);
        }
		public static QuanLyNhaNuoc GetQuanLyNhaNuoc(int maQuaLyNhaNuoc)
		{
			return DataPortal.Fetch<QuanLyNhaNuoc>(new Criteria(maQuaLyNhaNuoc));
		}

		public static void DeleteQuanLyNhaNuoc(int maQuaLyNhaNuoc)
		{
			DataPortal.Delete(new Criteria(maQuaLyNhaNuoc));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanLyNhaNuoc NewQuanLyNhaNuocChild()
		{
			QuanLyNhaNuoc child = new QuanLyNhaNuoc();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanLyNhaNuoc GetQuanLyNhaNuoc(SafeDataReader dr)
		{
			QuanLyNhaNuoc child =  new QuanLyNhaNuoc();
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
			public int MaQuaLyNhaNuoc;

			public Criteria(int maQuaLyNhaNuoc)
			{
				this.MaQuaLyNhaNuoc = maQuaLyNhaNuoc;
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
                cm.CommandText = "spd_SelecttblnsQuanLyNhaNuoc";

				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", criteria.MaQuaLyNhaNuoc);

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
			DataPortal_Delete(new Criteria(_maQuaLyNhaNuoc));
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
                cm.CommandText = "spd_DeletetblnsQuanLyNhaNuoc";

				cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", criteria.MaQuaLyNhaNuoc);

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
			_maQuaLyNhaNuoc = dr.GetInt32("MaQuaLyNhaNuoc");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenQuanLyNhaNuoc = dr.GetString("TenQuanLyNhaNuoc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, QuanLyNhaNuocList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, QuanLyNhaNuocList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuanLyNhaNuoc";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maQuaLyNhaNuoc = (int)cm.Parameters["@MaQuaLyNhaNuoc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuanLyNhaNuocList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanLyNhaNuoc.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanLyNhaNuoc", _tenQuanLyNhaNuoc);
			else
				cm.Parameters.AddWithValue("@TenQuanLyNhaNuoc", DBNull.Value);
			cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", _maQuaLyNhaNuoc);
			cm.Parameters["@MaQuaLyNhaNuoc"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, QuanLyNhaNuocList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, QuanLyNhaNuocList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuanLyNhaNuoc";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuanLyNhaNuocList parent)
		{
			cm.Parameters.AddWithValue("@MaQuaLyNhaNuoc", _maQuaLyNhaNuoc);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanLyNhaNuoc.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanLyNhaNuoc", _tenQuanLyNhaNuoc);
			else
				cm.Parameters.AddWithValue("@TenQuanLyNhaNuoc", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maQuaLyNhaNuoc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

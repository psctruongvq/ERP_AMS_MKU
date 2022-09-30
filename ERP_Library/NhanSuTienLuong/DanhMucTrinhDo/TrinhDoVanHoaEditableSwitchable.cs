
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoVanHoa : Csla.BusinessBase<TrinhDoVanHoa>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDoVanHoa = 0;
		private string _tenTrinhVanHoa = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDoVanHoa
		{
			get
			{
				CanReadProperty("MaTrinhDoVanHoa", true);
				return _maTrinhDoVanHoa;
			}
		}

		public string TenTrinhVanHoa
		{
			get
			{
				CanReadProperty("TenTrinhVanHoa", true);
				return _tenTrinhVanHoa;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenTrinhVanHoa.Equals(value))
				{
					_tenTrinhVanHoa = value;
					PropertyHasChanged("TenTrinhVanHoa");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTrinhDoVanHoa;
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
			// TenTrinhVanHoa
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTrinhVanHoa", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private TrinhDoVanHoa()
		{ /* require use of factory method */ }

		public static TrinhDoVanHoa NewTrinhDoVanHoa()
		{
			return DataPortal.Create<TrinhDoVanHoa>();
		}

		public static TrinhDoVanHoa GetTrinhDoVanHoa(int maTrinhDoVanHoa)
		{
			return DataPortal.Fetch<TrinhDoVanHoa>(new Criteria(maTrinhDoVanHoa));
		}

		public static void DeleteTrinhDoVanHoa(int maTrinhDoVanHoa)
		{
			DataPortal.Delete(new Criteria(maTrinhDoVanHoa));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TrinhDoVanHoa NewTrinhDoVanHoaChild()
		{
			TrinhDoVanHoa child = new TrinhDoVanHoa();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrinhDoVanHoa GetTrinhDoVanHoa(SafeDataReader dr)
		{
			TrinhDoVanHoa child =  new TrinhDoVanHoa();
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
			public int MaTrinhDoVanHoa;

			public Criteria(int maTrinhDoVanHoa)
			{
				this.MaTrinhDoVanHoa = maTrinhDoVanHoa;
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
                cm.CommandText = "spd_SelecttblnsTrinhDoVanHoa";

				cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", criteria.MaTrinhDoVanHoa);

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
			DataPortal_Delete(new Criteria(_maTrinhDoVanHoa));
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
                cm.CommandText = "spd_DeletetblnsTrinhDoVanHoa";

				cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", criteria.MaTrinhDoVanHoa);

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
			_maTrinhDoVanHoa = dr.GetInt32("MaTrinhDoVanHoa");
			_tenTrinhVanHoa = dr.GetString("TenTrinhVanHoa");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TrinhDoVanHoaList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TrinhDoVanHoaList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsTrinhDoVanHoa";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTrinhDoVanHoa = (int)cm.Parameters["@MaTrinhDoVanHoa"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TrinhDoVanHoaList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenTrinhVanHoa.Length > 0)
				cm.Parameters.AddWithValue("@TenTrinhVanHoa", _tenTrinhVanHoa);
			else
				cm.Parameters.AddWithValue("@TenTrinhVanHoa", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", _maTrinhDoVanHoa);
			cm.Parameters["@MaTrinhDoVanHoa"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TrinhDoVanHoaList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TrinhDoVanHoaList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsTrinhDoVanHoa";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TrinhDoVanHoaList parent)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoVanHoa", _maTrinhDoVanHoa);
			if (_tenTrinhVanHoa.Length > 0)
				cm.Parameters.AddWithValue("@TenTrinhVanHoa", _tenTrinhVanHoa);
			else
				cm.Parameters.AddWithValue("@TenTrinhVanHoa", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maTrinhDoVanHoa));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

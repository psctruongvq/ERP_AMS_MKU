
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NoiDangKyKCB : Csla.BusinessBase<NoiDangKyKCB>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNoiDangKyKCB = 0;
		private string _maQLBenhVienKCB = string.Empty;
		private string _tenBenhVienKCB = string.Empty;
		private string _maQLTinhThanhKCB = string.Empty;
		private string _tenTinhThanhKCB = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNoiDangKyKCB
		{
			get
			{
				return _maNoiDangKyKCB;
			}
		}

		public string MaQLBenhVienKCB
		{
			get
			{
				return _maQLBenhVienKCB;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQLBenhVienKCB.Equals(value))
				{
					_maQLBenhVienKCB = value;
					PropertyHasChanged("MaQLBenhVienKCB");
				}
			}
		}

		public string TenBenhVienKCB
		{
			get
			{
				return _tenBenhVienKCB;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBenhVienKCB.Equals(value))
				{
					_tenBenhVienKCB = value;
					PropertyHasChanged("TenBenhVienKCB");
				}
			}
		}

		public string MaQLTinhThanhKCB
		{
			get
			{
				return _maQLTinhThanhKCB;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQLTinhThanhKCB.Equals(value))
				{
					_maQLTinhThanhKCB = value;
					PropertyHasChanged("MaQLTinhThanhKCB");
				}
			}
		}

		public string TenTinhThanhKCB
		{
			get
			{
				return _tenTinhThanhKCB;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenTinhThanhKCB.Equals(value))
				{
					_tenTinhThanhKCB = value;
					PropertyHasChanged("TenTinhThanhKCB");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				return _ghiChu;
			}
			set
			{
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
			return _maNoiDangKyKCB;
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
			// MaQLBenhVienKCB
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLBenhVienKCB", 50));
			//
			// TenBenhVienKCB
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBenhVienKCB", 50));
			//
			// MaQLTinhThanhKCB
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLTinhThanhKCB", 50));
			//
			// TenTinhThanhKCB
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTinhThanhKCB", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private NoiDangKyKCB()
		{ /* require use of factory method */ }

		public static NoiDangKyKCB NewNoiDangKyKCB()
		{
            NoiDangKyKCB child = new NoiDangKyKCB();
            child.MarkAsChild();
            return child;
		}

		public static NoiDangKyKCB GetNoiDangKyKCB(int maNoiDangKyKCB)
		{
			return DataPortal.Fetch<NoiDangKyKCB>(new Criteria(maNoiDangKyKCB));
		}

		public static void DeleteNoiDangKyKCB(int maNoiDangKyKCB)
		{
			DataPortal.Delete(new Criteria(maNoiDangKyKCB));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NoiDangKyKCB NewNoiDangKyKCBChild()
		{
			NoiDangKyKCB child = new NoiDangKyKCB();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NoiDangKyKCB GetNoiDangKyKCB(SafeDataReader dr)
		{
			NoiDangKyKCB child =  new NoiDangKyKCB();
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
			public int MaNoiDangKyKCB;

			public Criteria(int maNoiDangKyKCB)
			{
				this.MaNoiDangKyKCB = maNoiDangKyKCB;
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
                cm.CommandText = "spd_SelecttblnsNoiDangKyKCB";

				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", criteria.MaNoiDangKyKCB);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //	ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maNoiDangKyKCB));
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
                cm.CommandText = "spd_DeletetblnsNoiDangKyKCB";

				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", criteria.MaNoiDangKyKCB);

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
			_maNoiDangKyKCB = dr.GetInt32("MaNoiDangKyKCB");
			_maQLBenhVienKCB = dr.GetString("MaQLBenhVienKCB");
			_tenBenhVienKCB = dr.GetString("TenBenhVienKCB");
			_maQLTinhThanhKCB = dr.GetString("MaQLTinhThanhKCB");
			_tenTinhThanhKCB = dr.GetString("TenTinhThanhKCB");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NoiDangKyKCBList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NoiDangKyKCBList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNoiDangKyKCB";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNoiDangKyKCB = (int)cm.Parameters["@MaNoiDangKyKCB"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NoiDangKyKCBList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQLBenhVienKCB.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBenhVienKCB", _maQLBenhVienKCB);
			else
				cm.Parameters.AddWithValue("@MaQLBenhVienKCB", DBNull.Value);
			if (_tenBenhVienKCB.Length > 0)
				cm.Parameters.AddWithValue("@TenBenhVienKCB", _tenBenhVienKCB);
			else
				cm.Parameters.AddWithValue("@TenBenhVienKCB", DBNull.Value);
			if (_maQLTinhThanhKCB.Length > 0)
				cm.Parameters.AddWithValue("@MaQLTinhThanhKCB", _maQLTinhThanhKCB);
			else
				cm.Parameters.AddWithValue("@MaQLTinhThanhKCB", DBNull.Value);
			if (_tenTinhThanhKCB.Length > 0)
				cm.Parameters.AddWithValue("@TenTinhThanhKCB", _tenTinhThanhKCB);
			else
				cm.Parameters.AddWithValue("@TenTinhThanhKCB", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNoiDangKyKCB", _maNoiDangKyKCB);
			cm.Parameters["@MaNoiDangKyKCB"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NoiDangKyKCBList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NoiDangKyKCBList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNoiDangKyKCB";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NoiDangKyKCBList parent)
		{
			cm.Parameters.AddWithValue("@MaNoiDangKyKCB", _maNoiDangKyKCB);
			if (_maQLBenhVienKCB.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBenhVienKCB", _maQLBenhVienKCB);
			else
				cm.Parameters.AddWithValue("@MaQLBenhVienKCB", DBNull.Value);
			if (_tenBenhVienKCB.Length > 0)
				cm.Parameters.AddWithValue("@TenBenhVienKCB", _tenBenhVienKCB);
			else
				cm.Parameters.AddWithValue("@TenBenhVienKCB", DBNull.Value);
			if (_maQLTinhThanhKCB.Length > 0)
				cm.Parameters.AddWithValue("@MaQLTinhThanhKCB", _maQLTinhThanhKCB);
			else
				cm.Parameters.AddWithValue("@MaQLTinhThanhKCB", DBNull.Value);
			if (_tenTinhThanhKCB.Length > 0)
				cm.Parameters.AddWithValue("@TenTinhThanhKCB", _tenTinhThanhKCB);
			else
				cm.Parameters.AddWithValue("@TenTinhThanhKCB", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNoiDangKyKCB));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

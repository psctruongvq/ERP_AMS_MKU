
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToan_MucNganSachImport : Csla.BusinessBase<ButToan_MucNganSachImport>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToanMucNganSach = 0;
		private int _maButToan = 0;
		private string _maTieuMuc = string.Empty;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaButToanMucNganSach
		{
			get
			{
				return _maButToanMucNganSach;
			}
		}

		public int MaButToan
		{
			get
			{
				return _maButToan;
			}
			set
			{
				if (!_maButToan.Equals(value))
				{
					_maButToan = value;
					PropertyHasChanged("MaButToan");
				}
			}
		}

		public string MaTieuMuc
		{
			get
			{
				return _maTieuMuc;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maTieuMuc.Equals(value))
				{
					_maTieuMuc = value;
					PropertyHasChanged("MaTieuMuc");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				return _dienGiai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maButToanMucNganSach;
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
			// MaTieuMuc
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaTieuMuc");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTieuMuc", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ButToan_MucNganSachImport()
		{ /* require use of factory method */ }

		public static ButToan_MucNganSachImport NewButToan_MucNganSachImport()
		{
			return DataPortal.Create<ButToan_MucNganSachImport>();
		}

		public static ButToan_MucNganSachImport GetButToan_MucNganSachImport(int maButToanMucNganSach)
		{
			return DataPortal.Fetch<ButToan_MucNganSachImport>(new Criteria(maButToanMucNganSach));
		}

		public static void DeleteButToan_MucNganSachImport(int maButToanMucNganSach)
		{
			DataPortal.Delete(new Criteria(maButToanMucNganSach));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ButToan_MucNganSachImport NewButToan_MucNganSachImportChild()
		{
			ButToan_MucNganSachImport child = new ButToan_MucNganSachImport();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ButToan_MucNganSachImport GetButToan_MucNganSachImport(SafeDataReader dr)
		{
			ButToan_MucNganSachImport child =  new ButToan_MucNganSachImport();
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
			public int MaButToanMucNganSach;

			public Criteria(int maButToanMucNganSach)
			{
				this.MaButToanMucNganSach = maButToanMucNganSach;
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
				cm.CommandText = "SelecttblButToan_MucNganSachImport";

				cm.Parameters.AddWithValue("@MaButToanMucNganSach", criteria.MaButToanMucNganSach);

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
			DataPortal_Delete(new Criteria(_maButToanMucNganSach));
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
				cm.CommandText = "DeletetblButToan_MucNganSachImport";

				cm.Parameters.AddWithValue("@MaButToanMucNganSach", criteria.MaButToanMucNganSach);

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
			_maButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
			_maButToan = dr.GetInt32("MaButToan");
			_maTieuMuc = dr.GetString("MaTieuMuc");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ButToan_MucNganSachImportList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ButToan_MucNganSachImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblButToan_MucNganSachImport";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ButToan_MucNganSachImportList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			cm.Parameters["@MaButToanMucNganSach"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ButToan_MucNganSachImportList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ButToan_MucNganSachImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblButToan_MucNganSachImport";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ButToan_MucNganSachImportList parent)
		{
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maButToanMucNganSach));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

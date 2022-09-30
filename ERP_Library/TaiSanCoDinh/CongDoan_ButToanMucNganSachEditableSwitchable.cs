
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongDoan_ButToanMucNganSach : Csla.BusinessBase<CongDoan_ButToanMucNganSach>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToanMucNganSach = 0;
		private int _maButToan = 0;
		private int _maTieuMuc = 0;
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

		public int MaTieuMuc
		{
			get
			{
				return _maTieuMuc;
			}
			set
			{
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

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private CongDoan_ButToanMucNganSach()
		{ /* require use of factory method */ }

		public static CongDoan_ButToanMucNganSach NewCongDoan_ButToanMucNganSach()
		{
			return DataPortal.Create<CongDoan_ButToanMucNganSach>();
		}

		public static CongDoan_ButToanMucNganSach GetCongDoan_ButToanMucNganSach(int maButToanMucNganSach)
		{
			return DataPortal.Fetch<CongDoan_ButToanMucNganSach>(new Criteria(maButToanMucNganSach));
		}

		public static void DeleteCongDoan_ButToanMucNganSach(int maButToanMucNganSach)
		{
			DataPortal.Delete(new Criteria(maButToanMucNganSach));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongDoan_ButToanMucNganSach NewCongDoan_ButToanMucNganSachChild()
		{
			CongDoan_ButToanMucNganSach child = new CongDoan_ButToanMucNganSach();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongDoan_ButToanMucNganSach GetCongDoan_ButToanMucNganSach(SafeDataReader dr)
		{
			CongDoan_ButToanMucNganSach child =  new CongDoan_ButToanMucNganSach();
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
				cm.CommandText = "SelecttblCongDoan_ButToanMucNganSach";

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
				cm.CommandText = "DeletetblCongDoan_ButToanMucNganSach";

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
			_maTieuMuc = dr.GetInt32("MaTieuMuc");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, CongDoan_ButToan parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, CongDoan_ButToan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblCongDoan_ButToanMucNganSach";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, CongDoan_ButToan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (parent.MaButToan!= 0)
				cm.Parameters.AddWithValue("@MaButToan", parent.MaButToan);
			else
				cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
			if (_maTieuMuc != 0)
				cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			else
				cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			cm.Parameters["@MaButToanMucNganSach"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, CongDoan_ButToan parent)
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

        private void ExecuteUpdate(SqlTransaction tr, CongDoan_ButToan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblCongDoan_ButToanMucNganSach";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, CongDoan_ButToan parent)
		{
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			if (parent.MaButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", parent.MaButToan);
			else
				cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
			if (_maTieuMuc != 0)
				cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			else
				cm.Parameters.AddWithValue("@MaTieuMuc", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiThuChiCongDoan : Csla.BusinessBase<LoaiThuChiCongDoan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiThuChi = 0;
		private string _tenLoaiThuChi = string.Empty;
		private bool _loaiThu = false;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiThuChi
		{
			get
			{
				return _maLoaiThuChi;
			}
		}

		public string TenLoaiThuChi
		{
			get
			{
				return _tenLoaiThuChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenLoaiThuChi.Equals(value))
				{
					_tenLoaiThuChi = value;
					PropertyHasChanged("TenLoaiThuChi");
				}
			}
		}

		public bool LoaiThu
		{
			get
			{
				return _loaiThu;
			}
			set
			{
				if (!_loaiThu.Equals(value))
				{
					_loaiThu = value;
					PropertyHasChanged("LoaiThu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiThuChi;
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
		private LoaiThuChiCongDoan()
		{ /* require use of factory method */ }

		public static LoaiThuChiCongDoan NewLoaiThuChiCongDoan(int maLoaiThuChi)
		{
			return DataPortal.Create<LoaiThuChiCongDoan>(new Criteria(maLoaiThuChi));
		}

		public static LoaiThuChiCongDoan GetLoaiThuChiCongDoan(int maLoaiThuChi)
		{
			return DataPortal.Fetch<LoaiThuChiCongDoan>(new Criteria(maLoaiThuChi));
		}

		public static void DeleteLoaiThuChiCongDoan(int maLoaiThuChi)
		{
			DataPortal.Delete(new Criteria(maLoaiThuChi));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private LoaiThuChiCongDoan(int maLoaiThuChi)
		{
			this._maLoaiThuChi = maLoaiThuChi;
		}

		internal static LoaiThuChiCongDoan NewLoaiThuChiCongDoanChild(int maLoaiThuChi)
		{
			LoaiThuChiCongDoan child = new LoaiThuChiCongDoan(maLoaiThuChi);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiThuChiCongDoan GetLoaiThuChiCongDoan(SafeDataReader dr)
		{
			LoaiThuChiCongDoan child =  new LoaiThuChiCongDoan();
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
			public int MaLoaiThuChi;

			public Criteria(int maLoaiThuChi)
			{
				this.MaLoaiThuChi = maLoaiThuChi;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiThuChi = criteria.MaLoaiThuChi;
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
				cm.CommandText = "SelecttblLoaiThuChiCongDoan";

				cm.Parameters.AddWithValue("@MaLoaiThuChi", criteria.MaLoaiThuChi);

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
			DataPortal_Delete(new Criteria(_maLoaiThuChi));
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
				cm.CommandText = "DeletetblLoaiThuChiCongDoan";

				cm.Parameters.AddWithValue("@MaLoaiThuChi", criteria.MaLoaiThuChi);

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
			_maLoaiThuChi = dr.GetInt32("MaLoaiThuChi");
			_tenLoaiThuChi = dr.GetString("TenLoaiThuChi");
			_loaiThu = dr.GetBoolean("LoaiThu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiThuChiCongDoanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiThuChiCongDoanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblLoaiThuChiCongDoan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiThuChiCongDoanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
			if (_tenLoaiThuChi.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiThuChi", _tenLoaiThuChi);
			else
				cm.Parameters.AddWithValue("@TenLoaiThuChi", DBNull.Value);
			if (_loaiThu != false)
				cm.Parameters.AddWithValue("@LoaiThu", _loaiThu);
			else
				cm.Parameters.AddWithValue("@LoaiThu", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiThuChiCongDoanList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiThuChiCongDoanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblLoaiThuChiCongDoan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiThuChiCongDoanList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
			if (_tenLoaiThuChi.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiThuChi", _tenLoaiThuChi);
			else
				cm.Parameters.AddWithValue("@TenLoaiThuChi", DBNull.Value);
			if (_loaiThu != false)
				cm.Parameters.AddWithValue("@LoaiThu", _loaiThu);
			else
				cm.Parameters.AddWithValue("@LoaiThu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiThuChi));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

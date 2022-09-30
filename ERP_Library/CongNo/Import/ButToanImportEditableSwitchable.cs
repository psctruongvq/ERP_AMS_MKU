
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToanImport : Csla.BusinessBase<ButToanImport>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToan = 0;
		private string _noTaiKhoan = string.Empty;
		private string _coTaiKhoan = string.Empty;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;
		private long _maChungTu = 0;
        private ButToanImport_ChiPhiHD _butToanImport_ChiPhiHD = ButToanImport_ChiPhiHD.NewButToanImport_ChiPhiHD();

        public ButToanImport_ChiPhiHD ButToanImport_ChiPhiHD
        {
            get { return _butToanImport_ChiPhiHD; }
            set { _butToanImport_ChiPhiHD = value; PropertyHasChanged(); }
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaButToan
		{
			get
			{
				return _maButToan;
			}
		}

		public string NoTaiKhoan
		{
			get
			{
				return _noTaiKhoan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_noTaiKhoan.Equals(value))
				{
					_noTaiKhoan = value;
					PropertyHasChanged("NoTaiKhoan");
				}
			}
		}

		public string CoTaiKhoan
		{
			get
			{
				return _coTaiKhoan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_coTaiKhoan.Equals(value))
				{
					_coTaiKhoan = value;
					PropertyHasChanged("CoTaiKhoan");
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

		public long MaChungTu
		{
			get
			{
				return _maChungTu;
			}
			set
			{
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maButToan;
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
			// NoTaiKhoan
			//
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoTaiKhoan", 10));
            ////
            //// CoTaiKhoan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CoTaiKhoan", 10));
            ////
            //// DienGiai
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ButToanImport()
		{ /* require use of factory method */ }

		public static ButToanImport NewButToanImport()
		{
			return DataPortal.Create<ButToanImport>();
		}

		public static ButToanImport GetButToanImport(int maButToan)
		{
			return DataPortal.Fetch<ButToanImport>(new Criteria(maButToan));
		}

		public static void DeleteButToanImport(int maButToan)
		{
			DataPortal.Delete(new Criteria(maButToan));
		}
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty||_butToanImport_ChiPhiHD.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid||_butToanImport_ChiPhiHD.IsValid;
            }
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ButToanImport NewButToanImportChild()
		{
			ButToanImport child = new ButToanImport();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ButToanImport GetButToanImport(SafeDataReader dr)
		{
			ButToanImport child =  new ButToanImport();
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
			public int MaButToan;

			public Criteria(int maButToan)
			{
				this.MaButToan = maButToan;
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
				cm.CommandText = "SelecttblButToanImport";

				cm.Parameters.AddWithValue("@MaButToan", criteria.MaButToan);

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
			DataPortal_Delete(new Criteria(_maButToan));
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
				cm.CommandText = "DeletetblButToanImport";

				cm.Parameters.AddWithValue("@MaButToan", criteria.MaButToan);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maButToan = dr.GetInt32("MaButToan");
			_noTaiKhoan = dr.GetString("NoTaiKhoan");
			_coTaiKhoan = dr.GetString("CoTaiKhoan");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
			_maChungTu = dr.GetInt64("MaChungTu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _butToanImport_ChiPhiHD = ButToanImport_ChiPhiHD.GetButToanImport_ChiPhiHDByButToan(_maButToan);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ButToanImportList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ButToanImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblButToanImport";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToan = (int)cm.Parameters["@MaButToan"].Value;
                _butToanImport_ChiPhiHD.Insert(tr, this);
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ButToanImportList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_noTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters["@MaButToan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ButToanImportList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ButToanImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblButToanImport";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();
                _butToanImport_ChiPhiHD.Update(tr, this);
			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ButToanImportList parent)
		{
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			if (_noTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
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

			ExecuteDelete(tr, new Criteria(_maButToan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

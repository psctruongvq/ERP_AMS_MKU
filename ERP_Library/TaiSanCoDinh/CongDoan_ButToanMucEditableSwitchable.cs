
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongDoan_ButToan : Csla.BusinessBase<CongDoan_ButToan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToan = 0;
		private int _maChungTu = 0;
		private int _noTaiKhoan = 0;
		private int _coTaiKhoan = 0;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;
        private DateTime _ngayLap = DateTime.Now.Date;

      
        //private CongDoan_ButToanMucNganSachList _congDoan_ButToanMucNganSachList = CongDoan_ButToanMucNganSachList.NewCongDoan_ButToanMucNganSachList();

        //public CongDoan_ButToanMucNganSachList CongDoan_ButToanMucNganSachList
        //{
        //    get { return _congDoan_ButToanMucNganSachList; }
        //    set { _congDoan_ButToanMucNganSachList = value;
        //    PropertyHasChanged("CongDoan_ButToanMucNganSachList");
        //    }
        //}
		[System.ComponentModel.DataObjectField(true, true)]
        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value;
            PropertyHasChanged("NgayLap");
            }
        }
		public int MaButToan
		{
			get
			{
				return _maButToan;
			}
		}

		public int MaChungTu
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

		public int NoTaiKhoan
		{
			get
			{
				return _noTaiKhoan;
			}
			set
			{
				if (!_noTaiKhoan.Equals(value))
				{
					_noTaiKhoan = value;
					PropertyHasChanged("NoTaiKhoan");
				}
			}
		}

		public int CoTaiKhoan
		{
			get
			{
				return _coTaiKhoan;
			}
			set
			{
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

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty ;//|| _congDoan_ButToanMucNganSachList.IsDirty;
            }
        }
		private CongDoan_ButToan()
		{ /* require use of factory method */ }

		public static CongDoan_ButToan NewCongDoan_ButToan()
		{
            CongDoan_ButToan item = new CongDoan_ButToan();
            item.MarkAsChild();
            return item;
		}

		public static CongDoan_ButToan GetCongDoan_ButToan(int maButToan)
		{
			return DataPortal.Fetch<CongDoan_ButToan>(new Criteria(maButToan));
		}

		public static void DeleteCongDoan_ButToan(int maButToan)
		{
			DataPortal.Delete(new Criteria(maButToan));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongDoan_ButToan NewCongDoan_ButToanChild()
		{
			CongDoan_ButToan child = new CongDoan_ButToan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongDoan_ButToan GetCongDoan_ButToan(SafeDataReader dr)
		{
			CongDoan_ButToan child =  new CongDoan_ButToan();
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
				cm.CommandText = "SelecttblCongDoan_ButToan";

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
				cm.CommandText = "DeletetblCongDoan_ButToan";

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
			//FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maButToan = dr.GetInt32("MaButToan");
			_maChungTu = dr.GetInt32("MaChungTu");
			_noTaiKhoan = dr.GetInt32("NoTaiKhoan");
			_coTaiKhoan = dr.GetInt32("CoTaiKhoan");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
            _ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblCongDoan_ButToan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToan = (int)cm.Parameters["@MaButToan"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, CongDoan_ChungTu parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_noTaiKhoan != 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan != 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            cm.Parameters.AddWithValue("@NgayLap", parent.NgayLap);
			cm.Parameters["@MaButToan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblCongDoan_ButToan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, CongDoan_ChungTu parent)
		{
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (_noTaiKhoan != 0)
				cm.Parameters.AddWithValue("@NoTaiKhoan", _noTaiKhoan);
			else
				cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
			if (_coTaiKhoan != 0)
				cm.Parameters.AddWithValue("@CoTaiKhoan", _coTaiKhoan);
			else
				cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", parent.NgayLap);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
          //  _congDoan_ButToanMucNganSachList.Update(tr, this);
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

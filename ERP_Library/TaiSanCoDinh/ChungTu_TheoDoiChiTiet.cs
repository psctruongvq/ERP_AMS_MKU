
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TheoDoiChiTiet : Csla.BusinessBase<ChungTu_TheoDoiChiTiet>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactTheodoichitiet = 0;
		private int _maTheoDoi = 0;
		private decimal _soTienChungTu = 0;
		private decimal _soTienDaThanhToan = 0;
		private decimal _soTienThanhToan = 0;
		private decimal _soTienConLai = 0;
		private string _dienGiai = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactTheodoichitiet
		{
			get
			{
				return _mactTheodoichitiet;
			}
		}

		public int MaTheoDoi
		{
			get
			{
				return _maTheoDoi;
			}
			set
			{
				if (!_maTheoDoi.Equals(value))
				{
					_maTheoDoi = value;
					PropertyHasChanged("MaTheoDoi");
				}
			}
		}

		public decimal SoTienChungTu
		{
			get
			{
				return _soTienChungTu;
			}
			set
			{
				if (!_soTienChungTu.Equals(value))
				{
					_soTienChungTu = value;
					PropertyHasChanged("SoTienChungTu");
				}
			}
		}

		public decimal SoTienDaThanhToan
		{
			get
			{
				return _soTienDaThanhToan;
			}
			set
			{
				if (!_soTienDaThanhToan.Equals(value))
				{
					_soTienDaThanhToan = value;
					PropertyHasChanged("SoTienDaThanhToan");
				}
			}
		}

		public decimal SoTienThanhToan
		{
			get
			{
				return _soTienThanhToan;
			}
			set
			{
				if (!_soTienThanhToan.Equals(value))
				{
					_soTienThanhToan = value;
					PropertyHasChanged("SoTienThanhToan");
				}
			}
		}

		public decimal SoTienConLai
		{
			get
			{
				return _soTienConLai;
			}
			set
			{
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
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

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _mactTheodoichitiet;
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
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTu_TheoDoiChiTiet()
		{ /* require use of factory method */ }

		public static ChungTu_TheoDoiChiTiet NewChungTu_TheoDoiChiTiet()
		{
            ChungTu_TheoDoiChiTiet item = new ChungTu_TheoDoiChiTiet();
            item.MarkAsChild();
            return item;
		}

		public static ChungTu_TheoDoiChiTiet GetChungTu_TheoDoiChiTiet(int mactTheodoichitiet)
		{
			return DataPortal.Fetch<ChungTu_TheoDoiChiTiet>(new Criteria(mactTheodoichitiet));
		}

		public static void DeleteChungTu_TheoDoiChiTiet(int mactTheodoichitiet)
		{
			DataPortal.Delete(new Criteria(mactTheodoichitiet));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTu_TheoDoiChiTiet NewChungTu_TheoDoiChiTietChild()
		{
			ChungTu_TheoDoiChiTiet child = new ChungTu_TheoDoiChiTiet();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTu_TheoDoiChiTiet GetChungTu_TheoDoiChiTiet(SafeDataReader dr)
		{
			ChungTu_TheoDoiChiTiet child =  new ChungTu_TheoDoiChiTiet();
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
			public int MactTheodoichitiet;

			public Criteria(int mactTheodoichitiet)
			{
				this.MactTheodoichitiet = mactTheodoichitiet;
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
				cm.CommandText = "SelecttblChungTu_TheoDoiChiTiet";

				cm.Parameters.AddWithValue("@MaCT_TheoDoiChiTiet", criteria.MactTheodoichitiet);

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
					ExecuteInsert(tr);

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
						ExecuteUpdate(tr);
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
			DataPortal_Delete(new Criteria(_mactTheodoichitiet));
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
				cm.CommandText = "DeletetblChungTu_TheoDoiChiTiet";

				cm.Parameters.AddWithValue("@MaCT_TheoDoiChiTiet", criteria.MactTheodoichitiet);

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
			_mactTheodoichitiet = dr.GetInt32("MaCT_TheoDoiChiTiet");
			_maTheoDoi = dr.GetInt32("MaTheoDoi");
			_soTienChungTu = dr.GetDecimal("SoTienChungTu");
			_soTienDaThanhToan = dr.GetDecimal("SoTienDaThanhToan");
			_soTienThanhToan = dr.GetDecimal("SoTienThanhToan");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
			_dienGiai = dr.GetString("DienGiai");
			_ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChungTu_TheoDoiChiTiet";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactTheodoichitiet = (int)cm.Parameters["@MaCT_TheoDoiChiTiet"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maTheoDoi != 0)
                cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi);
			else
				cm.Parameters.AddWithValue("@MaTheoDoi", DBNull.Value);
			if (_soTienChungTu != 0)
				cm.Parameters.AddWithValue("@SoTienChungTu", _soTienChungTu);
			else
				cm.Parameters.AddWithValue("@SoTienChungTu", DBNull.Value);
			if (_soTienDaThanhToan != 0)
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
			else
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", DBNull.Value);
			if (_soTienThanhToan != 0)
				cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
			else
				cm.Parameters.AddWithValue("@SoTienThanhToan", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
		
			cm.Parameters.AddWithValue("@MaCT_TheoDoiChiTiet", _mactTheodoichitiet);
			cm.Parameters["@MaCT_TheoDoiChiTiet"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChungTu_TheoDoiChiTiet";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCT_TheoDoiChiTiet", _mactTheodoichitiet);
            if (_maTheoDoi != 0)
                cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi);
            else
                cm.Parameters.AddWithValue("@MaTheoDoi", DBNull.Value);
			if (_soTienChungTu != 0)
				cm.Parameters.AddWithValue("@SoTienChungTu", _soTienChungTu);
			else
				cm.Parameters.AddWithValue("@SoTienChungTu", DBNull.Value);
			if (_soTienDaThanhToan != 0)
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", _soTienDaThanhToan);
			else
				cm.Parameters.AddWithValue("@SoTienDaThanhToan", DBNull.Value);
			if (_soTienThanhToan != 0)
				cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienThanhToan);
			else
				cm.Parameters.AddWithValue("@SoTienThanhToan", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
		
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			
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

			ExecuteDelete(tr, new Criteria(_mactTheodoichitiet));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

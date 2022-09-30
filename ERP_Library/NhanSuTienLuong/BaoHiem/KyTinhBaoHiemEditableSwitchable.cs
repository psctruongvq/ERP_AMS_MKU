
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyTinhBaoHiem : Csla.BusinessBase<KyTinhBaoHiem>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKyTinhBaoHiem = 0;
		private string _tenKyTinhBaoHiem = string.Empty;
		private int _thang = 0;
		private int _nam = 0;
		private SmartDate _ThoiGianHienHanh = new SmartDate(DateTime.Today.Date);
		private long _maNguoiLap = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKyTinhBaoHiem
		{
			get
			{
				return _maKyTinhBaoHiem;
			}
		}

		public string TenKyTinhBaoHiem
		{
			get
			{
				return _tenKyTinhBaoHiem;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenKyTinhBaoHiem.Equals(value))
				{
					_tenKyTinhBaoHiem = value;
					PropertyHasChanged("TenKyTinhBaoHiem");
				}
			}
		}

		public int Thang
		{
			get
			{
				return _thang;
			}
			set
			{
				if (!_thang.Equals(value))
				{
					_thang = value;
					PropertyHasChanged("Thang");
				}
			}
		}

		public int Nam
		{
			get
			{
				return _nam;
			}
			set
			{
				if (!_nam.Equals(value))
				{
					_nam = value;
					PropertyHasChanged("Nam");
				}
			}
		}

        public DateTime ThoiGianHienHanh
		{
			get
			{
				return _ThoiGianHienHanh.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ThoiGianHienHanh.Equals(value))
                {
                    _ThoiGianHienHanh = new SmartDate(value);
                    PropertyHasChanged("ThoiGianHienHanh");
                }
            }
		}

		public long MaNguoiLap
		{
			get
			{
				return _maNguoiLap;
			}
			set
			{
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maKyTinhBaoHiem;
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
			// TenKyTinhBaoHiem
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKyTinhBaoHiem", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private KyTinhBaoHiem()
		{ /* require use of factory method */ }

		public static KyTinhBaoHiem NewKyTinhBaoHiem()
		{
            KyTinhBaoHiem child = new KyTinhBaoHiem();
            child.MarkAsChild();
            return child;
		}

		public static KyTinhBaoHiem GetKyTinhBaoHiem(int maKyTinhBaoHiem)
		{
			return DataPortal.Fetch<KyTinhBaoHiem>(new Criteria(maKyTinhBaoHiem));
		}

		public static void DeleteKyTinhBaoHiem(int maKyTinhBaoHiem)
		{
			DataPortal.Delete(new Criteria(maKyTinhBaoHiem));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KyTinhBaoHiem NewKyTinhBaoHiemChild()
		{
			KyTinhBaoHiem child = new KyTinhBaoHiem();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KyTinhBaoHiem GetKyTinhBaoHiem(SafeDataReader dr)
		{
			KyTinhBaoHiem child =  new KyTinhBaoHiem();
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
			public int MaKyTinhBaoHiem;

			public Criteria(int maKyTinhBaoHiem)
			{
				this.MaKyTinhBaoHiem = maKyTinhBaoHiem;
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
                cm.CommandText = "spd_SelecttblnsKyTinhBaoHiem";

				cm.Parameters.AddWithValue("@MaKyTinhBaoHiem", criteria.MaKyTinhBaoHiem);

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
			DataPortal_Delete(new Criteria(_maKyTinhBaoHiem));
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
                cm.CommandText = "spd_DeletetblnsKyTinhBaoHiem";

				cm.Parameters.AddWithValue("@MaKyTinhBaoHiem", criteria.MaKyTinhBaoHiem);

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
			_maKyTinhBaoHiem = dr.GetInt32("MaKyTinhBaoHiem");
			_tenKyTinhBaoHiem = dr.GetString("TenKyTinhBaoHiem");
			_thang = dr.GetInt32("Thang");
			_nam = dr.GetInt32("Nam");
			_ThoiGianHienHanh = dr.GetSmartDate("ThoiGianHienHanh", _ThoiGianHienHanh.EmptyIsMin);
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KyTinhBaoHiemList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KyTinhBaoHiemList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsKyTinhBaoHiem";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maKyTinhBaoHiem = (int)cm.Parameters["@MaKyTinhBaoHiem"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KyTinhBaoHiemList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenKyTinhBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@TenKyTinhBaoHiem", _tenKyTinhBaoHiem);
			else
				cm.Parameters.AddWithValue("@TenKyTinhBaoHiem", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			cm.Parameters.AddWithValue("@ThoiGianHienHanh", _ThoiGianHienHanh.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyTinhBaoHiem", _maKyTinhBaoHiem);
			cm.Parameters["@MaKyTinhBaoHiem"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KyTinhBaoHiemList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KyTinhBaoHiemList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsKyTinhBaoHiem";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KyTinhBaoHiemList parent)
		{
			cm.Parameters.AddWithValue("@MaKyTinhBaoHiem", _maKyTinhBaoHiem);
			if (_tenKyTinhBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@TenKyTinhBaoHiem", _tenKyTinhBaoHiem);
			else
				cm.Parameters.AddWithValue("@TenKyTinhBaoHiem", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			cm.Parameters.AddWithValue("@ThoiGianHienHanh", _ThoiGianHienHanh.DBValue);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maKyTinhBaoHiem));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

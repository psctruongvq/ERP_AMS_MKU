
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomCongViec : Csla.BusinessBase<NhomCongViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNhomDoiTuong = 0;
		private string _maNhomDoiTuongQL = string.Empty;
		private string _tenNhomDoiTuong = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhomDoiTuong
		{
			get
			{
				return _maNhomDoiTuong;
			}
		}

		public string MaNhomDoiTuongQL
		{
			get
			{
				return _maNhomDoiTuongQL;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maNhomDoiTuongQL.Equals(value))
				{
					_maNhomDoiTuongQL = value;
					PropertyHasChanged("MaNhomDoiTuongQL");
				}
			}
		}

		public string TenNhomDoiTuong
		{
			get
			{
				return _tenNhomDoiTuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNhomDoiTuong.Equals(value))
				{
					_tenNhomDoiTuong = value;
					PropertyHasChanged("TenNhomDoiTuong");
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

		public int MaCongTy
		{
			get
			{
				return _maCongTy;
			}
			set
			{
				if (!_maCongTy.Equals(value))
				{
					_maCongTy = value;
					PropertyHasChanged("MaCongTy");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNhomDoiTuong;
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
			// MaNhomDoiTuongQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNhomDoiTuongQL", 50));
			//
			// TenNhomDoiTuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomDoiTuong", 2000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private NhomCongViec()
		{ /* require use of factory method */ }

		public static NhomCongViec NewNhomCongViec()
		{
            NhomCongViec it = new NhomCongViec();
            it.MarkAsChild();
            return it;
		}
        public static NhomCongViec NewNhomCongViec(string p)
        {
            NhomCongViec it = new NhomCongViec();
            it.TenNhomDoiTuong = p;
            it.MarkAsChild();
            return it;
        }

		public static NhomCongViec GetNhomCongViec(int maNhomDoiTuong)
		{
			return DataPortal.Fetch<NhomCongViec>(new Criteria(maNhomDoiTuong));
		}

		public static void DeleteNhomCongViec(int maNhomDoiTuong)
		{
			DataPortal.Delete(new Criteria(maNhomDoiTuong));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhomCongViec NewNhomCongViecChild()
		{
			NhomCongViec child = new NhomCongViec();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhomCongViec GetNhomCongViec(SafeDataReader dr)
		{
			NhomCongViec child =  new NhomCongViec();
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
			public int MaNhomDoiTuong;

			public Criteria(int maNhomDoiTuong)
			{
				this.MaNhomDoiTuong = maNhomDoiTuong;
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
				cm.CommandText = "SelecttblcnNhomDoiTuong";

				cm.Parameters.AddWithValue("@MaNhomDoiTuong", criteria.MaNhomDoiTuong);

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
			DataPortal_Delete(new Criteria(_maNhomDoiTuong));
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
				cm.CommandText = "DeletetblcnNhomDoiTuong";

				cm.Parameters.AddWithValue("@MaNhomDoiTuong", criteria.MaNhomDoiTuong);

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
			_maNhomDoiTuong = dr.GetInt32("MaNhomDoiTuong");
			_maNhomDoiTuongQL = dr.GetString("MaNhomDoiTuongQL");
			_tenNhomDoiTuong = dr.GetString("TenNhomDoiTuong");
			_ngayLap = dr.GetDateTime("NgayLap");
			_maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhomCongViecList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhomCongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblcnNhomDoiTuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNhomDoiTuong = (int)cm.Parameters["@MaNhomDoiTuong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhomCongViecList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maNhomDoiTuongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaNhomDoiTuongQL", _maNhomDoiTuongQL);
			else
				cm.Parameters.AddWithValue("@MaNhomDoiTuongQL", DBNull.Value);
			if (_tenNhomDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomDoiTuong", _tenNhomDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenNhomDoiTuong", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_maCongTy != 0)
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
				else
					cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomDoiTuong", _maNhomDoiTuong);
			cm.Parameters["@MaNhomDoiTuong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhomCongViecList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhomCongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblcnNhomDoiTuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhomCongViecList parent)
		{
			cm.Parameters.AddWithValue("@MaNhomDoiTuong", _maNhomDoiTuong);
			if (_maNhomDoiTuongQL.Length > 0)
				cm.Parameters.AddWithValue("@MaNhomDoiTuongQL", _maNhomDoiTuongQL);
			else
				cm.Parameters.AddWithValue("@MaNhomDoiTuongQL", DBNull.Value);
			if (_tenNhomDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomDoiTuong", _tenNhomDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenNhomDoiTuong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
			else
				cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNhomDoiTuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

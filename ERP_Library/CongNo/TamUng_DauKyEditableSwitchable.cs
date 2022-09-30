
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;




namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUng_DauKy : Csla.BusinessBase<TamUng_DauKy>
	{
		#region Business Properties and Methods

		//declare members
		private int _id = 0;
		private long _maDoiTuong = 0;
		private decimal _soDuThuDauKy = 0;
		private decimal _soDuChiDauKy = 0;
		private int _nguoiLap = Security.CurrentUser.Info.UserID;
		private DateTime _ngayLap = DateTime.Today.Date;
		private string _ghiChu = string.Empty;
        private int _maChuongTrinh = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public int Id
		{
			get
			{
				return _id;
			}
		}

		public long MaDoiTuong
		{
			get
			{
				return _maDoiTuong;
			}
			set
			{
				if (!_maDoiTuong.Equals(value))
				{
					_maDoiTuong = value;
					PropertyHasChanged("MaDoiTuong");
				}
			}
		}

		public decimal SoDuThuDauKy
		{
			get
			{
				return _soDuThuDauKy;
			}
			set
			{
				if (!_soDuThuDauKy.Equals(value))
				{
					_soDuThuDauKy = value;
					PropertyHasChanged("SoDuThuDauKy");
				}
			}
		}

		public decimal SoDuChiDauKy
		{
			get
			{
				return _soDuChiDauKy;
			}
			set
			{
				if (!_soDuChiDauKy.Equals(value))
				{
					_soDuChiDauKy = value;
					PropertyHasChanged("SoDuChiDauKy");
				}
			}
		}
        public int MaChuongTrinh
        {
            get
            {
                return _maChuongTrinh;
            }
            set
            {
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    PropertyHasChanged("MaChuongTrinh");
                }
            }
        }
		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
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
			return _id;
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
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private TamUng_DauKy()
		{ /* require use of factory method */ }

		public static TamUng_DauKy NewTamUng_DauKy()
		{
            TamUng_DauKy item = new TamUng_DauKy();
            item.MarkAsChild();
            return item;
		}

		public static TamUng_DauKy GetTamUng_DauKy(int id)
		{
			return DataPortal.Fetch<TamUng_DauKy>(new Criteria(id));
		}

		public static void DeleteTamUng_DauKy(int id)
		{
			DataPortal.Delete(new Criteria(id));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TamUng_DauKy NewTamUng_DauKyChild()
		{
			TamUng_DauKy child = new TamUng_DauKy();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TamUng_DauKy GetTamUng_DauKy(SafeDataReader dr)
		{
			TamUng_DauKy child =  new TamUng_DauKy();
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
			public int Id;

			public Criteria(int id)
			{
				this.Id = id;
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
				cm.CommandText = "SelecttblTamUng_SoDuDauKy";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_id));
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
				cm.CommandText = "DeletetblTamUng_SoDuDauKy";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

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
			_id = dr.GetInt32("ID");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_soDuThuDauKy = dr.GetDecimal("SoDuThuDauKy");
			_soDuChiDauKy = dr.GetDecimal("SoDuChiDauKy");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_ngayLap = dr.GetDateTime("NgayLap");
			_ghiChu = dr.GetString("GhiChu");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TamUng_DauKyList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TamUng_DauKyList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblTamUng_SoDuDauKy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_id = (int)cm.Parameters["@ID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TamUng_DauKyList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			if (_soDuThuDauKy != 0)
				cm.Parameters.AddWithValue("@SoDuThuDauKy", _soDuThuDauKy);
			else
				cm.Parameters.AddWithValue("@SoDuThuDauKy", DBNull.Value);
			if (_soDuChiDauKy != 0)
				cm.Parameters.AddWithValue("@SoDuChiDauKy", _soDuChiDauKy);
			else
				cm.Parameters.AddWithValue("@SoDuChiDauKy", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_ghiChu.Length > 0)
					cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
				else
					cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters["@ID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TamUng_DauKyList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TamUng_DauKyList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblTamUng_SoDuDauKy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TamUng_DauKyList parent)
		{
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			if (_soDuThuDauKy != 0)
				cm.Parameters.AddWithValue("@SoDuThuDauKy", _soDuThuDauKy);
			else
				cm.Parameters.AddWithValue("@SoDuThuDauKy", DBNull.Value);
			if (_soDuChiDauKy != 0)
				cm.Parameters.AddWithValue("@SoDuChiDauKy", _soDuChiDauKy);
			else
				cm.Parameters.AddWithValue("@SoDuChiDauKy", DBNull.Value);
			if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
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

			ExecuteDelete(tr, new Criteria(_id));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

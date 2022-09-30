
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class SoQuy : Csla.BusinessBase<SoQuy>
	{
		#region Business Properties and Methods

		//declare members
		private int _maSoQuy = 0;
		private string _maQuanLy = string.Empty;
		private string _tenSoQuy = string.Empty;
        private DateTime _ngayLap = DateTime.Today.Date;
		private int _maBoPhan = 0;
		private int _nguoiLap = 0;

        private decimal _soDuDauKyNo = 0;
        private decimal _soDuDauKyCo = 0;
        private decimal _luyKeDauKyNo = 0;
        private decimal _luyKeDauKyCo = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public decimal SoDuDauKyNo
        {
            get
            {
                return _soDuDauKyNo;
            }
            set
            {
                if (!_soDuDauKyNo.Equals(value))
                {
                    _soDuDauKyNo = value;
                    PropertyHasChanged("SoDuDauKyNo");
                }
            }
        }

        public decimal SoDuDauKyCo
        {
            get
            {
                return _soDuDauKyCo;
            }
            set
            {
                if (!_soDuDauKyCo.Equals(value))
                {
                    _soDuDauKyCo = value;
                    PropertyHasChanged("SoDuDauKyCo");
                }
            }
        }

        public decimal LuyKeDauKyNo
        {
            get
            {
                return _luyKeDauKyNo;
            }
            set
            {
                if (!_luyKeDauKyNo.Equals(value))
                {
                    _luyKeDauKyNo = value;
                    PropertyHasChanged("LuyKeDauKyNo");
                }
            }
        }

        public decimal LuyKeDauKyCo
        {
            get
            {
                return _luyKeDauKyCo;
            }
            set
            {
                if (!_luyKeDauKyCo.Equals(value))
                {
                    _luyKeDauKyCo = value;
                    PropertyHasChanged("LuyKeDauKyCo");
                }
            }
        }
        private DateTime _ngaySoDu = DateTime.Today.Date;

        public DateTime NgaySoDu
        {
            get { return _ngaySoDu; }
            set { _ngaySoDu = value; PropertyHasChanged(); }
        }
		
		public int MaSoQuy
		{
			get
			{
				return _maSoQuy;
			}
		}

		public string MaQuanLy
		{
			get
			{
				return _maQuanLy;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public string TenSoQuy
		{
			get
			{
				return _tenSoQuy;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenSoQuy.Equals(value))
				{
					_tenSoQuy = value;
					PropertyHasChanged("TenSoQuy");
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
                _ngayLap = value;
            }
		}

	
		public int MaBoPhan
		{
			get
			{
				return _maBoPhan;
			}
			set
			{
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
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
 
		protected override object GetIdValue()
		{
			return _maSoQuy;
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
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenSoQuy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenSoQuy", 200));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private SoQuy()
		{ /* require use of factory method */ }

		public static SoQuy NewSoQuy()
		{
            SoQuy item = new SoQuy();
            item.MarkAsChild();
            return item;
		}
        public static SoQuy NewSoQuy(string p)
        {
            SoQuy item = new SoQuy();
            item.TenSoQuy = p;
            item.MarkAsChild();
            return item;
        }
		public static SoQuy GetSoQuy(int maSoQuy)
		{
			return DataPortal.Fetch<SoQuy>(new Criteria(maSoQuy));
		}

		public static void DeleteSoQuy(int maSoQuy)
		{
			DataPortal.Delete(new Criteria(maSoQuy));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static SoQuy NewSoQuyChild()
		{
			SoQuy child = new SoQuy();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static SoQuy GetSoQuy(SafeDataReader dr)
		{
			SoQuy child =  new SoQuy();
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
			public int MaSoQuy;

			public Criteria(int maSoQuy)
			{
				this.MaSoQuy = maSoQuy;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
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
                cm.CommandText = "SelecttblSoQuy";

				cm.Parameters.AddWithValue("@MaSoQuy", criteria.MaSoQuy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maSoQuy));
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
				cm.CommandText = "DeleteSoQuy";

				cm.Parameters.AddWithValue("@MaSoQuy", criteria.MaSoQuy);

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
			_maSoQuy = dr.GetInt32("MaSoQuy");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenSoQuy = dr.GetString("TenSoQuy");
			_ngayLap = dr.GetDateTime("NgayLap");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_nguoiLap = dr.GetInt32("NguoiLap");
            _soDuDauKyNo = dr.GetDecimal("SoDuDauKyNo");
            _soDuDauKyCo = dr.GetDecimal("SoDuDauKyCo");
            _luyKeDauKyNo = dr.GetDecimal("LuyKeDauKyNo");
            _luyKeDauKyCo = dr.GetDecimal("LuyKeDauKyCo");
            _ngaySoDu = dr.GetDateTime("NgaySoDu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, SoQuyList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, SoQuyList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblSoQuy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maSoQuy = (int)cm.Parameters["@MaSoQuy"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, SoQuyList parent)
        {

            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            cm.Parameters.AddWithValue("@LuyKeDauKyNo", _luyKeDauKyNo);
            cm.Parameters.AddWithValue("@LuyKeDauKyCo", _luyKeDauKyCo);
            cm.Parameters.AddWithValue("@NgaySoDu", _ngaySoDu);
            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
            if (_tenSoQuy.Length > 0)
                cm.Parameters.AddWithValue("@TenSoQuy", _tenSoQuy);
            else
                cm.Parameters.AddWithValue("@TenSoQuy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
            cm.Parameters["@MaSoQuy"].Direction = ParameterDirection.Output;
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, SoQuyList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, SoQuyList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblSoQuy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, SoQuyList parent)
        {
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            
			cm.Parameters.AddWithValue("@MaSoQuy", _maSoQuy);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenSoQuy.Length > 0)
				cm.Parameters.AddWithValue("@TenSoQuy", _tenSoQuy);
			else
				cm.Parameters.AddWithValue("@TenSoQuy", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@SoDuDauKyNo", _soDuDauKyNo);
            cm.Parameters.AddWithValue("@SoDuDauKyCo", _soDuDauKyCo);
            cm.Parameters.AddWithValue("@LuyKeDauKyNo", _luyKeDauKyNo);
            cm.Parameters.AddWithValue("@LuyKeDauKyCo", _luyKeDauKyCo);
        
            cm.Parameters.AddWithValue("@NgaySoDu", _ngaySoDu);
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

			ExecuteDelete(tr, new Criteria(_maSoQuy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

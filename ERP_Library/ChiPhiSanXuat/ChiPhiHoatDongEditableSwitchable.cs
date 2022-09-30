
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiPhiHoatDong : Csla.BusinessBase<ChiPhiHoatDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiPhiHD = 0;
		private string _maChiPhiHDQL = string.Empty;
		private string _tenChiPhiHD = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = 0;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
		private bool _suDung = true;
		private int _maHoatDong = 0;
        private int _maCongTy = 0;

       
		[System.ComponentModel.DataObjectField(true, true)]
        public int MaCongTy
        {
            get { return _maCongTy; }
            set { _maCongTy = value; PropertyHasChanged("MaCongTy"); }
        }
		public int MaChiPhiHD
		{
			get
			{
				return _maChiPhiHD;
			}
		}

		public string MaChiPhiHDQL
		{
			get
			{
				return _maChiPhiHDQL;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maChiPhiHDQL.Equals(value))
				{
					_maChiPhiHDQL = value;
					PropertyHasChanged("MaChiPhiHDQL");
				}
			}
		}

		public string TenChiPhiHD
		{
			get
			{
				return _tenChiPhiHD;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChiPhiHD.Equals(value))
				{
					_tenChiPhiHD = value;
					PropertyHasChanged("TenChiPhiHD");
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

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}

		public bool SuDung
		{
			get
			{
				return _suDung;
			}
			set
			{
				if (!_suDung.Equals(value))
				{
					_suDung = value;
					PropertyHasChanged("SuDung");
				}
			}
		}

		public int MaHoatDong
		{
			get
			{
				return _maHoatDong;
			}
			set
			{
				if (!_maHoatDong.Equals(value))
				{
					_maHoatDong = value;
                    PropertyHasChanged("MaHoatDong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChiPhiHD;
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
			// MaChiPhiHDQL
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChiPhiHDQL", 50));
			//
			// TenChiPhiHD
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChiPhiHD", 2000));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 200));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChiPhiHoatDong()
		{ /* require use of factory method */ }

		public static ChiPhiHoatDong NewChiPhiHoatDong()
		{
            ChiPhiHoatDong item = new ChiPhiHoatDong();
            item.MarkAsChild();
            return item;
		}
        public static ChiPhiHoatDong NewChiPhiHoatDong(string p)
        {
            ChiPhiHoatDong item = new ChiPhiHoatDong();
            item._tenChiPhiHD = p;
            item.MarkAsChild();
            return item;
        }
		public static ChiPhiHoatDong GetChiPhiHoatDong(int maChiPhiHD)
		{
			return DataPortal.Fetch<ChiPhiHoatDong>(new Criteria(maChiPhiHD));
		}

		public static void DeleteChiPhiHoatDong(int maChiPhiHD)
		{
			DataPortal.Delete(new Criteria(maChiPhiHD));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChiPhiHoatDong NewChiPhiHoatDongChild()
		{
			ChiPhiHoatDong child = new ChiPhiHoatDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChiPhiHoatDong GetChiPhiHoatDong(SafeDataReader dr)
		{
			ChiPhiHoatDong child =  new ChiPhiHoatDong();
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
			public int MaChiPhiHD;

			public Criteria(int maChiPhiHD)
			{
				this.MaChiPhiHD = maChiPhiHD;
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
				cm.CommandText = "SelecttblChiPhiHoatDong";

				cm.Parameters.AddWithValue("@MaChiPhiHD", criteria.MaChiPhiHD);

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
			DataPortal_Delete(new Criteria(_maChiPhiHD));
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
				cm.CommandText = "DeletetblChiPhiHoatDong";

				cm.Parameters.AddWithValue("@MaChiPhiHD", criteria.MaChiPhiHD);

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
			_maChiPhiHD = dr.GetInt32("MaChiPhiHD");
			_maChiPhiHDQL = dr.GetString("MaChiPhiHDQL");
			_tenChiPhiHD = dr.GetString("TenChiPhiHD");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_suDung = dr.GetBoolean("SuDung");
			_maHoatDong = dr.GetInt32("MaHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChiPhiHoatDongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChiPhiHoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChiPhiHoatDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiPhiHD = (int)cm.Parameters["@MaChiPhiHD"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChiPhiHoatDongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
			if (_maChiPhiHDQL.Length > 0)
				cm.Parameters.AddWithValue("@MaChiPhiHDQL", _maChiPhiHDQL);
			else
				cm.Parameters.AddWithValue("@MaChiPhiHDQL", DBNull.Value);
			if (_tenChiPhiHD.Length > 0)
				cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
			else
				cm.Parameters.AddWithValue("@TenChiPhiHD", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
				if (_maBoPhan != 0)
					cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
				else
					cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
				if (_tenBoPhan.Length > 0)
					cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
				else
					cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
				if (_suDung != false)
					cm.Parameters.AddWithValue("@SuDung", _suDung);
				else
					cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
				if (_maHoatDong != 0)
					cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
				else
					cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
                cm.Parameters.AddWithValue("@MaCongTy",_maCongTy);
			cm.Parameters.AddWithValue("@MaChiPhiHD", _maChiPhiHD);
			cm.Parameters["@MaChiPhiHD"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChiPhiHoatDongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChiPhiHoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChiPhiHoatDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChiPhiHoatDongList parent)
		{
            _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
			cm.Parameters.AddWithValue("@MaChiPhiHD", _maChiPhiHD);
			if (_maChiPhiHDQL.Length > 0)
				cm.Parameters.AddWithValue("@MaChiPhiHDQL", _maChiPhiHDQL);
			else
				cm.Parameters.AddWithValue("@MaChiPhiHDQL", DBNull.Value);
			if (_tenChiPhiHD.Length > 0)
				cm.Parameters.AddWithValue("@TenChiPhiHD", _tenChiPhiHD);
			else
				cm.Parameters.AddWithValue("@TenChiPhiHD", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_tenBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
			else
				cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
			if (_suDung != false)
				cm.Parameters.AddWithValue("@SuDung", _suDung);
			else
				cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
			if (_maHoatDong != 0)
				cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
			else
				cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
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

			ExecuteDelete(tr, new Criteria(_maChiPhiHD));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhoaSo_User : Csla.BusinessBase<KhoaSo_User>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKhoaSo = 0;
		private int _maKy = 0;
		private int _userID = 0;
        private bool _khoaSo = false; 
        private bool _khoaSoThue = false;
        private string _tenDangNhap = string.Empty;

        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap
        {
            get { return _tenDangNhap; }
           
        }

        
        private DateTime _ngayBatDau = DateTime.Today.Date;
        [DisplayName("Ngày bắt đầu")]
        public DateTime NgayBatDau
        {
            get { return _ngayBatDau; }
           
        }

        private DateTime _ngayKetThuc = DateTime.Today.Date;
        [DisplayName("Ngày kết thúc")]
        public DateTime NgayKetThuc
        {
            get { return _ngayKetThuc; }
            
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKhoaSo
		{
			get
			{
				return _maKhoaSo;
			}
		}

		public int MaKy
		{
			get
			{
                _ngayBatDau = Ky.GetKy(_maKy).NgayBatDau;
                _ngayKetThuc = Ky.GetKy(_maKy).NgayKetThuc;
				return _maKy;
			}
			set
			{
				if (!_maKy.Equals(value))
				{
					_maKy = value;
                    _ngayBatDau = Ky.GetKy(_maKy).NgayBatDau;
                    _ngayKetThuc = Ky.GetKy(_maKy).NgayKetThuc;
					PropertyHasChanged("MaKy");
				}
			}
		}

		public int UserID
		{
			get
			{
                _tenDangNhap = ERP_Library.Security.UserItem.GetUserItem(_userID).TenDangNhap;
				return _userID;
			}
			set
			{
				if (!_userID.Equals(value))
				{
					_userID = value;
                    _tenDangNhap = ERP_Library.Security.UserItem.GetUserItem(_userID).TenDangNhap;
					PropertyHasChanged("UserID");
				}
			}
		}

        [DisplayName("Khóa sổ")]
		public bool KhoaSo
		{
			get
			{
				return _khoaSo;
			}
			set
			{
				if (!_khoaSo.Equals(value))
				{
					_khoaSo = value;
					PropertyHasChanged("KhoaSo");
				}
			}
		}

        [DisplayName("Khóa sổ thuế")]
        public bool KhoaSoThue
        {
            get
            {
                return _khoaSoThue;
            }
            set
            {
                if (!_khoaSoThue.Equals(value))
                {
                    _khoaSoThue = value;
                    PropertyHasChanged("KhoaSoThue");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maKhoaSo;
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
		private KhoaSo_User()
		{ /* require use of factory method */ }

		public static KhoaSo_User NewKhoaSo_User()
		{
			return DataPortal.Create<KhoaSo_User>();
		}

		public static KhoaSo_User GetKhoaSo_User(int maKhoaSo)
		{
			return DataPortal.Fetch<KhoaSo_User>(new Criteria(maKhoaSo));
		}

		public static void DeleteKhoaSo_User(int maKhoaSo)
		{
			DataPortal.Delete(new Criteria(maKhoaSo));
		}

        public static KhoaSo_User GetKhoaSo_User_ByMaKyUserID(int maKy, int userID)
        {
            return DataPortal.Fetch<KhoaSo_User>(new Criteria_MaKyUserID(maKy,userID));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static KhoaSo_User NewKhoaSo_UserChild()
		{
			KhoaSo_User child = new KhoaSo_User();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KhoaSo_User GetKhoaSo_User(SafeDataReader dr)
		{
			KhoaSo_User child =  new KhoaSo_User();
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
			public int MaKhoaSo;

			public Criteria(int maKhoaSo)
			{
				this.MaKhoaSo = maKhoaSo;
			}
		}

        private class Criteria_MaKyUserID
        {
            public int MaKy;
            public int UserID;
            public Criteria_MaKyUserID(int _maKy,int _userID)
            {
                this.MaKy = _maKy;
                this.UserID = _userID;
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
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SelecttblKhoaSo_User";

                    cm.Parameters.AddWithValue("@MaKhoaSo", ((Criteria)criteria).MaKhoaSo);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
                else if (criteria is Criteria_MaKyUserID)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SelecttblKhoaSo_User_ByMaKyUserID";

                    cm.Parameters.AddWithValue("@MaKy", ((Criteria_MaKyUserID)criteria).MaKy);
                    cm.Parameters.AddWithValue("@UserID", ((Criteria_MaKyUserID)criteria).UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                            ValidationRules.CheckRules();

                            //load child object(s)
                            FetchChildren(dr);
                        }
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
			DataPortal_Delete(new Criteria(_maKhoaSo));
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
				cm.CommandText = "DeletetblKhoaSo_User";

				cm.Parameters.AddWithValue("@MaKhoaSo", criteria.MaKhoaSo);

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
			_maKhoaSo = dr.GetInt32("MaKhoaSo");
			_maKy = dr.GetInt32("MaKy");
			_userID = dr.GetInt32("UserID");
            _tenDangNhap = ERP_Library.Security.UserItem.GetUserItem(_userID).TenDangNhap;
			_khoaSo = dr.GetBoolean("KhoaSo");
            _khoaSoThue = dr.GetBoolean("KhoaSoThue");
            _ngayBatDau = Ky.GetKy(_maKy).NgayBatDau;
            _ngayKetThuc = Ky.GetKy(_maKy).NgayKetThuc;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KhoaSo_UserList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KhoaSo_UserList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblKhoaSo_User";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maKhoaSo = (int)cm.Parameters["@MaKhoaSo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KhoaSo_UserList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_userID != 0)
				cm.Parameters.AddWithValue("@UserID", _userID);
			else
				cm.Parameters.AddWithValue("@UserID", DBNull.Value);
			if (_khoaSo != false)
				cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
			else
				cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            if (_khoaSoThue != false)
                cm.Parameters.AddWithValue("@KhoaSoThue", _khoaSoThue);
            else
                cm.Parameters.AddWithValue("@KhoaSoThue",DBNull.Value);
			cm.Parameters.AddWithValue("@MaKhoaSo", _maKhoaSo);
			cm.Parameters["@MaKhoaSo"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KhoaSo_UserList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KhoaSo_UserList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblKhoaSo_User";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KhoaSo_UserList parent)
		{
			cm.Parameters.AddWithValue("@MaKhoaSo", _maKhoaSo);
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_userID != 0)
				cm.Parameters.AddWithValue("@UserID", _userID);
			else
				cm.Parameters.AddWithValue("@UserID", DBNull.Value);
			if (_khoaSo != false)
				cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
			else
				cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            if (_khoaSoThue != false)
                cm.Parameters.AddWithValue("@KhoaSoThue", _khoaSoThue);
            else
                cm.Parameters.AddWithValue("@KhoaSoThue", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maKhoaSo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

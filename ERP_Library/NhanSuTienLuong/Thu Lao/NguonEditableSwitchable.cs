
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Nguon : Csla.BusinessBase<Nguon>
	{
		#region Business Properties and Methods

		//declare members
        private int _maNguon = 0;
        private string _tenNguon = string.Empty;
        private int _maBoPhan = 0;
        private string _maNguonQuanLy = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _maNguoiLap = 0;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _maHoatDong = 0;
        private int _maCongTy = 0;
        private bool _chon = false;

		[System.ComponentModel.DataObjectField(true, true)]
        public int MaNguon
        {
            get
            {
                return _maNguon;
            }
        }

        public string TenNguon
        {
            get
            {
                return _tenNguon;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_tenNguon.Equals(value))
                {
                    _tenNguon = value;
                    PropertyHasChanged("TenNguon");
                }
            }
        }
        public int MaHoatDong
        {
            get { return _maHoatDong; }
            set { _maHoatDong = value; PropertyHasChanged("MaHoatDong"); }
        }
        public int MaCongTy
        {
            get { return _maCongTy; }
            set { _maCongTy = value; PropertyHasChanged("MaCongTy"); }
        }

        public string MaNguonQuanLy
        {
            get
            {
                return _maNguonQuanLy;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_maNguonQuanLy.Equals(value))
                {
                    _maNguonQuanLy = value;
                    PropertyHasChanged("MaNguonQuanLy");
                }
            }
        }
        public int MaBoPhan
        {
            get
            {
                _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                return _maBoPhan;
            }

        }
        public string TenBoPhan
        {
            get
            {
                _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
                return _tenBoPhan;
            }
          
        }

        public int MaNguoiLap
        {
            get
            {
                _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
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

        
        public bool Chon
        {
            get
            {

                return _chon;
            }
            set
            {
                _chon = value;
            }
        }
 
 
		protected override object GetIdValue()
		{
			return _maNguon;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
            ////
            //// TenNguon
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenNguon");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguon", 4000));
            ////
            //// SoHieuTK
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTK", 15));
            ////
            //// MaNguonQuanLy
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNguonQuanLy", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private Nguon()
		{ /* require use of factory method */ }

		public static Nguon NewNguon()
		{
            Nguon item = new Nguon();
            item.MarkAsChild();
            return item;
		}
        public static Nguon NewNguon(string tenNguon)
        {
            Nguon iten = new Nguon();
            iten.TenNguon = tenNguon;
            return iten;
        }
		public static Nguon GetNguon(int maNguon)
		{
			return DataPortal.Fetch<Nguon>(new Criteria(maNguon));
		}
        public static Nguon GetNguon(int maNguon,int dbNumber)
        {
            return DataPortal.Fetch<Nguon>(new CriteriaByDatabase(maNguon,dbNumber));
        }

		public static void DeleteNguon(int maNguon)
		{
			DataPortal.Delete(new Criteria(maNguon));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static Nguon NewNguonChild()
		{
			Nguon child = new Nguon();
		//	child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Nguon GetNguon(SafeDataReader dr)
		{
			Nguon child =  new Nguon();
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
			public int MaNguon;

			public Criteria(int maNguon)
			{
				this.MaNguon = maNguon;
			}
		}
        private class CriteriaByDatabase
        {
            public int MaNguon;
            public int DBNumber;
            public CriteriaByDatabase(int maNguon,int dbNumber)
            {
                this.MaNguon = maNguon;
                this.DBNumber = dbNumber;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "usp_SelecttblNguon";
                    cm.Parameters.AddWithValue("@MaNguon",((Criteria)criteria).MaNguon);
                }
                else if (criteria is CriteriaByDatabase)
                {
                    cm.CommandText = "usp_SelecttblNguon";
                    cm.Parameters.AddWithValue("@MaNguon", ((CriteriaByDatabase)criteria).MaNguon);
                    cm.Parameters.AddWithValue("@DatabaseNumber", ((CriteriaByDatabase)criteria).DBNumber);
                }
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
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maNguon));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_DeletetblNguon";

				cm.Parameters.AddWithValue("@MaNguon", criteria.MaNguon);

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
            _maNguon = dr.GetInt32("MaNguon");
            _tenNguon = dr.GetString("TenNguon");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNguonQuanLy = dr.GetString("MaNguonQuanLy");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maNguoiLap = dr.GetInt32("MaNguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maHoatDong = dr.GetInt32("MaHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, NguonList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, NguonList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_InserttblNguon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNguon = (int)cm.Parameters["@MaNguon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NguonList parent)
        {//TODO: if parent use identity key, fix fk member with value from parent
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            _maBoPhan=  ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            _ngayLap = DateTime.Today.Date;
            cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNguonQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaNguonQuanLy", _maNguonQuanLy);
            else
                cm.Parameters.AddWithValue("@MaNguonQuanLy", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);

            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            cm.Parameters["@MaNguon"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, NguonList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, NguonList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "usp_UpdatetblNguon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NguonList parent)
		{
            _tenBoPhan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;
            _maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            _ngayLap = DateTime.Today.Date;
            cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNguonQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaNguonQuanLy", _maNguonQuanLy);
            else
                cm.Parameters.AddWithValue("@MaNguonQuanLy", DBNull.Value);
            if (_tenBoPhan.Length > 0)
                cm.Parameters.AddWithValue("@TenBoPhan", _tenBoPhan);
            else
                cm.Parameters.AddWithValue("@TenBoPhan", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            if (_maHoatDong != 0)
                cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
            else
                cm.Parameters.AddWithValue("@MaHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maNguon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

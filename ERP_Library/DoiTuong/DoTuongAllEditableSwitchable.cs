
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTuongAll  : Csla.BusinessBase<DoiTuongAll >
	{
		#region Business Properties and Methods

		//declare members
		private long _maDoiTuong = 0;
		private string _maQLDoiTuong = string.Empty;
		private string _tenDoiTuong = string.Empty;
		private string _maSoThue = string.Empty; 
        private string _diaChi = string.Empty;
        private int _maTaiKhoan = 0;
        private int _maLoaiDoiTuong = 0;
        private string _tenCongTy = string.Empty;
        public int MaLoaiDoiTuong
        {
            get { return _maLoaiDoiTuong; }
            set { _maLoaiDoiTuong = value; }
        }
       
        private bool _check = false;

        private bool _daCo = false;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaDoiTuong
		{
			get
			{
				CanReadProperty("MaDoiTuong", true);
				return _maDoiTuong;
			}
		}
        public int MaTaiKhoan
        {
            get { return _maTaiKhoan; }
            set { _maTaiKhoan = value; }
        }
		public string MaQLDoiTuong
		{
			get
			{
				CanReadProperty("MaQLDoiTuong", true);
				return _maQLDoiTuong;
			}
			set
			{
				CanWriteProperty("MaQLDoiTuong", true);
				if (value == null) value = string.Empty;
				if (!_maQLDoiTuong.Equals(value))
				{
					_maQLDoiTuong = value;
					PropertyHasChanged("MaQLDoiTuong");
				}
			}
		}

		public string TenDoiTuong
		{
			get
			{
				CanReadProperty("TenDoiTuong", true);
				return _tenDoiTuong;
			}
			set
			{
				CanWriteProperty("TenDoiTuong", true);
				if (value == null) value = string.Empty;
				if (!_tenDoiTuong.Equals(value))
				{
					_tenDoiTuong = value;
					PropertyHasChanged("TenDoiTuong");
				}
			}
		}

		public string MaSoThue
		{
			get
			{
				CanReadProperty("MaSoThue", true);
				return _maSoThue;
			}
			set
			{
				CanWriteProperty("MaSoThue", true);
				if (value == null) value = string.Empty;
				if (!_maSoThue.Equals(value))
				{
					_maSoThue = value;
					PropertyHasChanged("MaSoThue");
				}
			}
		}
        public string DiaChi
        {
            get
            {
                CanReadProperty("DiaChi", true);
                return _diaChi;
            }
            set
            {
                CanWriteProperty("DiaChi", true);
                if (value == null) value = string.Empty;
                if (!_diaChi.Equals(value))
                {
                    _diaChi = value;
                    PropertyHasChanged("DiaChi");
                }
            }

        }
        public string TenCongTy
        {
            get
            {
                CanReadProperty("TenCongTy", true);
                return _tenCongTy;
            }
            set
            {
                CanWriteProperty("TenCongTy", true);
                if (value == null) value = string.Empty;
                if (!_tenCongTy.Equals(value))
                {
                    _tenCongTy = value;
                    PropertyHasChanged("TenCongTy");
                }
            }

        }
        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        }
        public bool DaCo
        {
            get { return _daCo; }
            set { _daCo = value; }
        }
        protected override object GetIdValue()
        {
            return _maDoiTuong;
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
            //// MaQLDoiTuong
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLDoiTuong", 50));
            ////
            //// TenDoiTuong
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuong", 500));
            ////
            //// MaSoThue
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSoThue", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in DoiTuongAll 
			//AuthorizationRules.AllowRead("MaDoiTuong", "DoiTuongAll ReadGroup");
			//AuthorizationRules.AllowRead("MaQLDoiTuong", "DoiTuongAll ReadGroup");
			//AuthorizationRules.AllowRead("TenDoiTuong", "DoiTuongAll ReadGroup");
			//AuthorizationRules.AllowRead("MaSoThue", "DoiTuongAll ReadGroup");

			//AuthorizationRules.AllowWrite("MaQLDoiTuong", "DoiTuongAll WriteGroup");
			//AuthorizationRules.AllowWrite("TenDoiTuong", "DoiTuongAll WriteGroup");
			//AuthorizationRules.AllowWrite("MaSoThue", "DoiTuongAll WriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DoiTuongAll 
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongAll ViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DoiTuongAll 
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongAll AddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DoiTuongAll 
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongAll EditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DoiTuongAll 
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DoiTuongAll DeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules
       
		#region Factory Methods
		private DoiTuongAll ()
		{ /* require use of factory method */ }

        public static DoiTuongAll NewDoiTuongAll()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DoiTuongAll ");
            return DataPortal.Create<DoiTuongAll>(new Criteria1());
            
        }

		public static DoiTuongAll  NewDoiTuongAll (long maDoiTuong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTuongAll ");
			return DataPortal.Create<DoiTuongAll >(new Criteria(maDoiTuong));
		}
        public static DoiTuongAll NewDoiTuongAll(string tenDoiTuong)
        {
            DoiTuongAll item = new DoiTuongAll();
            item.TenDoiTuong = tenDoiTuong;
            item.MarkAsChild();
            return item;
        }
		public static DoiTuongAll  GetDoiTuongAll (long maDoiTuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DoiTuongAll ");
			return DataPortal.Fetch<DoiTuongAll >(new Criteria(maDoiTuong));
		}

		public static void DeleteDoiTuongAll (long maDoiTuong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DoiTuongAll ");
			DataPortal.Delete(new Criteria(maDoiTuong));
		}

		public override DoiTuongAll  Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DoiTuongAll ");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DoiTuongAll ");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DoiTuongAll ");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DoiTuongAll ( long maDoiTuong)
		{
			this._maDoiTuong = maDoiTuong;
		}

		internal static DoiTuongAll  NewDoiTuongAllChild(long maDoiTuong)
		{
			DoiTuongAll  child = new DoiTuongAll (maDoiTuong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DoiTuongAll  GetDoiTuongAll (SafeDataReader dr)
		{
			DoiTuongAll  child =  new DoiTuongAll ();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}

        internal static DoiTuongAll GetDoiTuongAll_CongTy(SafeDataReader dr)
        {
            DoiTuongAll child = new DoiTuongAll();
            child.MarkAsChild();
            child._maDoiTuong = dr.GetInt64("MaDoiTuong");
            child._maQLDoiTuong = dr.GetString("MaQLDoiTuong");
            child._tenDoiTuong = dr.GetString("TenDoiTuong");
            child._maSoThue = dr.GetString("MaSoThue");
            child._diaChi = dr.GetString("DiaChi");
            child._maLoaiDoiTuong = (int)dr.GetValue("Loai");
            child._tenCongTy = dr.GetString("TenCongTy");
            return child;
        }

        internal static DoiTuongAll GetDoiTuongAllByMaTaiKhoan(SafeDataReader dr)
        {
            DoiTuongAll child = new DoiTuongAll();
            child.MarkAsChild();
            child._maDoiTuong = dr.GetInt64("MaDoiTuong");
            child._maQLDoiTuong = dr.GetString("MaQLDoiTuong");
            child._tenDoiTuong = dr.GetString("TenDoiTuong");
            child._maSoThue = dr.GetString("MaSoThue");
            child._diaChi = dr.GetString("DiaChi");
            child._maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            child.MarkOld();
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]

        private class Criteria1
        {
            public Criteria1()
            {
            }
        }

		private class Criteria
		{
			public long MaDoiTuong;

			public Criteria(long maDoiTuong)
			{
				this.MaDoiTuong = maDoiTuong;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maDoiTuong = criteria.MaDoiTuong;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectALLDoiTuong ";

				cm.Parameters.AddWithValue("@MaDoiTuong", criteria.MaDoiTuong);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
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
			DataPortal_Delete(new Criteria(_maDoiTuong));
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
				cm.CommandText = "DeleteDoiTuongAll ";

				cm.Parameters.AddWithValue("@MaDoiTuong", criteria.MaDoiTuong);

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
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_maQLDoiTuong = dr.GetString("MaQLDoiTuong");
			_tenDoiTuong = dr.GetString("TenDoiTuong");
			_maSoThue = dr.GetString("MaSoThue");
            _diaChi = dr.GetString("DiaChi");
            _maLoaiDoiTuong = (int)dr.GetValue("Loai");
            
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, DoiTuongAllList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, DoiTuongAllList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddDoiTuongAll ";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTuongAllList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			if (_maQLDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@MaQLDoiTuong", _maQLDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaQLDoiTuong", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, DoiTuongAllList parent)
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

		private void ExecuteUpdate(SqlConnection cn, DoiTuongAllList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateDoiTuongAll ";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTuongAllList parent)
		{
			cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			if (_maQLDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@MaQLDoiTuong", _maQLDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaQLDoiTuong", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_maSoThue.Length > 0)
				cm.Parameters.AddWithValue("@MaSoThue", _maSoThue);
			else
				cm.Parameters.AddWithValue("@MaSoThue", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maDoiTuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

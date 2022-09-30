
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{ 
	[Serializable()] 
	public class MenuItem : Csla.BusinessBase<MenuItem>
	{
		#region Business Properties and Methods

		//declare members
		private int _menuID = 0;
		private string _tenChucNang = string.Empty;
		private int _parentID = 0;
		private byte[] _hinhAnh;
        private int _stt = 0;
        private bool _an = false;
        private int _maChucNang = 0;
        private string _tenform = "";
        private string _tenfunction = "";

		[System.ComponentModel.DataObjectField(true, false)]
		public int MenuID
		{
			get
			{
				return _menuID;
			}
		}

        public int MaChucNang
        {
            get
            {
                return _maChucNang;
            }
            set
            {
                if (!_maChucNang.Equals(value))
                {
                    _maChucNang = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenChucNang
		{
			get
			{
				return _tenChucNang;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChucNang.Equals(value))
				{
					_tenChucNang = value;
					PropertyHasChanged("TenChucNang");
				}
			}
		}

		public int ParentID
		{
			get
			{
				return _parentID;
			}
			set
			{
				if (!_parentID.Equals(value))
				{
					_parentID = value;
					PropertyHasChanged("ParentID");
				}
			}
		}

		public byte[] HinhAnh
		{
			get
			{
				return _hinhAnh;
			}
            set
            {
                _hinhAnh = value;
                PropertyHasChanged("HinhAnh");

            }
		}

        public int STT
        {
            get
            {
                return _stt;
            }
            set
            {
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool An
        {
            get
            {
                return _an;
            }
            set
            {
                if (!_an.Equals(value))
                {
                    _an = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenForm
        {
            get
            {
                return _tenform;
            }
            set
            {
                if (!_tenform.Equals(value))
                {
                    _tenform = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenFunction
        {
            get
            {
                return _tenfunction;
            }
            set
            {
                if (!_tenfunction.Equals(value))
                {
                    _tenfunction = value;
                    PropertyHasChanged();
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _menuID;
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
			// TenChucNang
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenChucNang");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucNang", 100));
            ValidationRules.AddRule(CommonRules.IntegerMinValue, new CommonRules.IntegerMinValueRuleArgs("MaChucNang", 1));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		public MenuItem()
		{ /* require use of factory method */ }

		public static MenuItem NewMenuItem(int menuID)
		{
			return DataPortal.Create<MenuItem>(new Criteria(menuID));
		}

		public static MenuItem GetMenuItem(int menuID)
		{
			return DataPortal.Fetch<MenuItem>(new Criteria(menuID));
		}

        public static MenuItem GetMenuItemByMaChucNang(int MaChucNang)
        {
            return DataPortal.Fetch<MenuItem>(new CriteriaMaChucNang(MaChucNang));
        }

		public static void DeleteMenuItem(int menuID)
		{
			DataPortal.Delete(new Criteria(menuID));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private MenuItem(int menuID)
		{
			this._menuID = menuID;
		}

		internal static MenuItem NewMenuItemChild(int menuID)
		{
			MenuItem child = new MenuItem(menuID);
            child.MaChucNang = menuID;
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static MenuItem GetMenuItem(SafeDataReader dr)
		{
			MenuItem child =  new MenuItem();
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
			public int MenuID;

			public Criteria(int menuID)
			{
				this.MenuID = menuID;
			}
		}

        [Serializable()]
        private class CriteriaMaChucNang
        {
            public int MaChucNang;

            public CriteriaMaChucNang(int maChucNang)
            {
                MaChucNang = maChucNang;
            }
        }
        #endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_menuID = criteria.MenuID;
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
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "app_Select_MenuItem";
                    cm.Parameters.AddWithValue("@MenuID", ((Criteria)criteria).MenuID);
                }
                else
                {
                    cm.CommandText = "app_Select_MenuItemByMaChucNang";
                    cm.Parameters.AddWithValue("@MaChucNang", ((CriteriaMaChucNang)criteria).MaChucNang);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
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
			DataPortal_Delete(new Criteria(_menuID));
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
				cm.CommandText = "app_Delete_MenuItem";

				cm.Parameters.AddWithValue("@MenuID", criteria.MenuID);

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
			_menuID = dr.GetInt32("MenuID");
			_tenChucNang = dr.GetString("TenChucNang");
			_parentID = dr.GetInt32("ParentID");
			_hinhAnh = (byte[])dr["HinhAnh"];
            _stt = dr.GetInt32("STT");
            _an = dr.GetBoolean("An");
            _maChucNang = dr.GetInt32("MaChucNang");
            _tenform = dr.GetString("TenForm");
            _tenfunction = dr.GetString("TenFunction");
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
				cm.CommandText = "app_Insert_MenuItem";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
                _menuID = Convert.ToInt32(cm.Parameters["@MenuID"].Value);
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MenuID", _menuID);
            cm.Parameters["@MenuID"].Direction = ParameterDirection.Output;
			cm.Parameters.AddWithValue("@TenChucNang", _tenChucNang);
			if (_parentID != 0)
				cm.Parameters.AddWithValue("@ParentID", _parentID);
			else
				cm.Parameters.AddWithValue("@ParentID", DBNull.Value);
            if (_hinhAnh == null)
                cm.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@HinhAnh", _hinhAnh);
            cm.Parameters["@HinhAnh"].SqlDbType = SqlDbType.Image;
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@An", _an);
            cm.Parameters.AddWithValue("@TenForm", _tenform);
            cm.Parameters.AddWithValue("@MaChucNang", _maChucNang);
            cm.Parameters.AddWithValue("@TenFunction", _tenfunction);
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
				cm.CommandText = "app_Update_MenuItem";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MenuID", _menuID);
			cm.Parameters.AddWithValue("@TenChucNang", _tenChucNang);
			if (_parentID != 0)
				cm.Parameters.AddWithValue("@ParentID", _parentID);
			else
				cm.Parameters.AddWithValue("@ParentID", DBNull.Value);

            if (_hinhAnh == null)
                cm.Parameters.AddWithValue("@HinhAnh", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@HinhAnh", _hinhAnh);
            cm.Parameters["@HinhAnh"].SqlDbType = SqlDbType.Image;
            cm.Parameters.AddWithValue("@STT", _stt);
            cm.Parameters.AddWithValue("@An", _an);
            cm.Parameters.AddWithValue("@TenForm", _tenform);
            cm.Parameters.AddWithValue("@MaChucNang", _maChucNang);
            cm.Parameters.AddWithValue("@TenFunction", _tenfunction);
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

			ExecuteDelete(tr, new Criteria(_menuID));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

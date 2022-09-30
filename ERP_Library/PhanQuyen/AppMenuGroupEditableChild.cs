using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class AppMenuGroup : Csla.BusinessBase<AppMenuGroup>
	{
        #region Business Properties and Methods

        //declare members
        private string _title = string.Empty;
        private string _maPhanHeQL = string.Empty;
        private int _parentID = 0;// _parentID trong tbl  AppMenus
        private int _iD =0;// _iD trong tbl  AppMenus
        private bool _chon = false;

        private int _menuID = 0;
		private int _groupID = 0;
		private string _ghiChu = string.Empty;
		private bool _xem = false;
		private bool _them = false;
		private bool _sua = false;
		private bool _xoa = false;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MenuID
		{
			get
			{
				CanReadProperty("MenuID", true);
				return _menuID;
			}
            set
            {
                CanWriteProperty("MenuID", true);
                if (!_menuID.Equals(value))
                {
                    _menuID = value;
                    PropertyHasChanged("MenuID");
                }
            }
        }
        public int ParentID
        {
            get
            {
                CanReadProperty("ParentID", true);
                return _parentID;
            }
            set
            {
                CanWriteProperty("ParentID", true);
                if (!_parentID.Equals(value))
                {
                    _parentID = value;
                    PropertyHasChanged("ParentID");
                }
            }
        }
        public int ID
        {
            get
            {
                CanReadProperty("ID", true);
                return _iD;
            }
            set
            {
                CanWriteProperty("ID", true);
                if (!_iD.Equals(value))
                {
                    _iD = value;
                    PropertyHasChanged("ID");
                }
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
		public int GroupID
		{
			get
			{
				CanReadProperty("GroupID", true);
				return _groupID;
			}
            set
            {
                CanWriteProperty("GroupID", true);
                if (!_groupID.Equals(value))
                {
                    _groupID = value;
                    PropertyHasChanged("GroupID");
                }
            }
        }

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}

        public bool Chon
        {
            get
            {
                CanReadProperty("Chon", true);
                return _chon;
            }
            set
            {
                CanWriteProperty("Chon", true);
                if (!_chon.Equals(value))
                {
                    _chon = value;
                    PropertyHasChanged("Chon");
                }
            }
        }
        public bool Xem
		{
			get
			{
				CanReadProperty("Xem", true);
				return _xem;
			}
			set
			{
				CanWriteProperty("Xem", true);
				if (!_xem.Equals(value))
				{
					_xem = value;
					PropertyHasChanged("Xem");
				}
			}
		}

		public bool Them
		{
			get
			{
				CanReadProperty("Them", true);
				return _them;
			}
			set
			{
				CanWriteProperty("Them", true);
				if (!_them.Equals(value))
				{
					_them = value;
					PropertyHasChanged("Them");
				}
			}
		}

		public bool Sua
		{
			get
			{
				CanReadProperty("Sua", true);
				return _sua;
			}
			set
			{
				CanWriteProperty("Sua", true);
				if (!_sua.Equals(value))
				{
					_sua = value;
					PropertyHasChanged("Sua");
				}
			}
		}

		public bool Xoa
		{
			get
			{
				CanReadProperty("Xoa", true);
				return _xoa;
			}
			set
			{
				CanWriteProperty("Xoa", true);
				if (!_xoa.Equals(value))
				{
					_xoa = value;
					PropertyHasChanged("Xoa");
				}
			}
		}
        public string Title
        {
            get
            {
                CanReadProperty("Title", true);
                return _title;
            }
            set
            {
                CanWriteProperty("Title", true);
                if (value == null) value = string.Empty;
                if (!_title.Equals(value))
                {
                    _title = value;
                    PropertyHasChanged("Title");
                }
            }
        }
        public string MaPhanHeQL
        {
            get
            {
                CanReadProperty("MaPhanHeQL", true);
                return _maPhanHeQL;
            }
            set
            {
                CanWriteProperty("MaPhanHeQL", true);
                if (value == null) value = string.Empty;
                if (!_maPhanHeQL.Equals(value))
                {
                    _maPhanHeQL = value;
                    PropertyHasChanged("MaPhanHeQL");
                }
            }
        }

        protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _menuID, _groupID);
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
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
			//TODO: Define authorization rules in AppMenuGroup
			//AuthorizationRules.AllowRead("MenuID", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("GroupID", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("Xem", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("Them", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("Sua", "AppMenuGroupReadGroup");
			//AuthorizationRules.AllowRead("Xoa", "AppMenuGroupReadGroup");

			//AuthorizationRules.AllowWrite("GhiChu", "AppMenuGroupWriteGroup");
			//AuthorizationRules.AllowWrite("Xem", "AppMenuGroupWriteGroup");
			//AuthorizationRules.AllowWrite("Them", "AppMenuGroupWriteGroup");
			//AuthorizationRules.AllowWrite("Sua", "AppMenuGroupWriteGroup");
			//AuthorizationRules.AllowWrite("Xoa", "AppMenuGroupWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static AppMenuGroup NewAppMenuGroup(int menuID, int groupID)
		{
			return new AppMenuGroup(menuID, groupID);
		}

		internal static AppMenuGroup GetAppMenuGroup(SafeDataReader dr)
		{
			return new AppMenuGroup(dr);
		}

		private AppMenuGroup(int menuID, int groupID)
		{
			this._menuID = menuID;
			this._groupID = groupID;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private AppMenuGroup(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

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
            _parentID = dr.GetInt32("ParentID");
            _iD = dr.GetInt32("ID");
			_menuID = dr.GetInt32("MenuID");
			_groupID = dr.GetInt32("GroupID");
			_ghiChu = dr.GetString("GhiChu");
            _chon = dr.GetBoolean("Chon");
            _xem = dr.GetBoolean("Xem");
			_them = dr.GetBoolean("Them");
			_sua = dr.GetBoolean("Sua");
			_xoa = dr.GetBoolean("Xoa");
            _title = dr.GetString("Title");
            _maPhanHeQL = dr.GetString("MaPhanHeQL");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, app_groups parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			//UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, app_groups parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblAppMenuGroup";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MenuID", _menuID);
			cm.Parameters.AddWithValue("@GroupID", _groupID);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_chon != false)
				cm.Parameters.AddWithValue("@Xem", _chon);
			else
				cm.Parameters.AddWithValue("@Xem", DBNull.Value);
			if (_them != false)
				cm.Parameters.AddWithValue("@Them", _them);
			else
				cm.Parameters.AddWithValue("@Them", DBNull.Value);
			if (_sua != false)
				cm.Parameters.AddWithValue("@Sua", _sua);
			else
				cm.Parameters.AddWithValue("@Sua", DBNull.Value);
			if (_xoa != false)
				cm.Parameters.AddWithValue("@Xoa", _xoa);
			else
				cm.Parameters.AddWithValue("@Xoa", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, app_groups parent)
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

		private void ExecuteUpdate(SqlConnection cn, app_groups parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MenuID", _menuID);
			cm.Parameters.AddWithValue("@GroupID", _groupID);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_xem != false)
				cm.Parameters.AddWithValue("@Xem", _xem);
			else
				cm.Parameters.AddWithValue("@Xem", DBNull.Value);
			if (_them != false)
				cm.Parameters.AddWithValue("@Them", _them);
			else
				cm.Parameters.AddWithValue("@Them", DBNull.Value);
			if (_sua != false)
				cm.Parameters.AddWithValue("@Sua", _sua);
			else
				cm.Parameters.AddWithValue("@Sua", DBNull.Value);
			if (_xoa != false)
				cm.Parameters.AddWithValue("@Xoa", _xoa);
			else
				cm.Parameters.AddWithValue("@Xoa", DBNull.Value);
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

			ExecuteDelete(cn);
			MarkNew();
		}

		private void ExecuteDelete(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "";

				cm.Parameters.AddWithValue("@MenuID", this._menuID);
				cm.Parameters.AddWithValue("@GroupID", this._groupID);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_Website_Email : Csla.BusinessBase<CongTy_Website_Email>
	{
		#region Business Properties and Methods

        private int _maChiTiet = 0;
        private int _maCongTy = 0;
        private bool _active = false;
        private string _website = string.Empty;
        private string _email = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public bool Active
        {
            get
            {
                CanReadProperty("Active", true);
                return _active;
            }
            set
            {
                CanWriteProperty("Active", true);
                if (!_active.Equals(value))
                {
                    _active = value;
                    PropertyHasChanged("Active");
                }
            }
        }

        public string Website
        {
            get
            {
                CanReadProperty("Website", true);
                return _website;
            }
            set
            {
                CanWriteProperty("Website", true);
                if (value == null) value = string.Empty;
                if (!_website.Equals(value))
                {
                    _website = value;
                    PropertyHasChanged("Website");
                }
            }
        }

        public string Email
        {
            get
            {
                CanReadProperty("Email", true);
                return _email;
            }
            set
            {
                CanWriteProperty("Email", true);
                if (value == null) value = string.Empty;
                if (!_email.Equals(value))
                {
                    _email = value;
                    PropertyHasChanged("Email");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maChiTiet;
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
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 50));
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
			//TODO: Define authorization rules in CongTy_Website_Email
			//AuthorizationRules.AllowRead("DiaChi", "CongTy_Website_EmailReadGroup");
			//AuthorizationRules.AllowRead("Loai", "CongTy_Website_EmailReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "CongTy_Website_EmailReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "CongTy_Website_EmailReadGroup");
			//AuthorizationRules.AllowRead("MaWebsiteEmail", "CongTy_Website_EmailReadGroup");

			//AuthorizationRules.AllowWrite("DiaChi", "CongTy_Website_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "CongTy_Website_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "CongTy_Website_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("MaWebsiteEmail", "CongTy_Website_EmailWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CongTy_Website_Email NewCongTy_Website_Email()
		{
			return new CongTy_Website_Email();
		}

		public static CongTy_Website_Email GetCongTy_Website_Email(SafeDataReader dr)
		{
			return new CongTy_Website_Email(dr);
		}

		private CongTy_Website_Email()
		{
			//this._maChiTiet = maChiTiet;
			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CongTy_Website_Email(SafeDataReader dr)
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
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maCongTy = dr.GetInt32("MaCongTy");
            _active = dr.GetBoolean("Active");
            _website = dr.GetString("Website");
            _email = dr.GetString("Email");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongTy parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongTy parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongTy_Website_Email";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
               // _maWebsiteEmail = (int)cm.Parameters["@MaWebsiteEmail"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongTy parent)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", parent.MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_website.Length > 0)
                cm.Parameters.AddWithValue("@Website", _website);
            else
                cm.Parameters.AddWithValue("@Website", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
			
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongTy parent)
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

		private void ExecuteUpdate(SqlTransaction tr, CongTy parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongTy_Website_Email";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongTy parent)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", parent.MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_website.Length > 0)
                cm.Parameters.AddWithValue("@Website", _website);
            else
                cm.Parameters.AddWithValue("@Website", DBNull.Value);
            if (_email.Length > 0)
                cm.Parameters.AddWithValue("@Email", _email);
            else
                cm.Parameters.AddWithValue("@Email", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
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

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCongTy_Website_Email";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

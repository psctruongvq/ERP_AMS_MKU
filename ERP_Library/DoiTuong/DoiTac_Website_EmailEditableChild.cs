
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_Website_Email : Csla.BusinessBase<DoiTac_Website_Email>
	{
		#region Business Properties and Methods

		//declare members
		private int _maWebsiteEmail = 0;
		private string _diaChi = string.Empty;
		private Boolean _loai = true;
		private int _maChiTiet = 0;
		private long _maDoiTac = 0;

		public int MaWebsiteEmail
		{
			get
			{
				CanReadProperty("MaWebsiteEmail", true);
				return _maWebsiteEmail;
			}
			set
			{
				CanWriteProperty("MaWebsiteEmail", true);
				if (!_maWebsiteEmail.Equals(value))
				{
					_maWebsiteEmail = value;
					PropertyHasChanged("MaWebsiteEmail");
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

		public Boolean Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public long MaDoiTac
		{
			get
			{
				CanReadProperty("MaDoiTac", true);
				return _maDoiTac;
			}
			set
			{
				CanWriteProperty("MaDoiTac", true);
				if (!_maDoiTac.Equals(value))
				{
					_maDoiTac = value;
					PropertyHasChanged("MaDoiTac");
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
			//TODO: Define authorization rules in DoiTac_WebsiteEmail
			//AuthorizationRules.AllowRead("MaWebsiteEmail", "DoiTac_WebsiteEmailReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "DoiTac_WebsiteEmailReadGroup");
			//AuthorizationRules.AllowRead("Loai", "DoiTac_WebsiteEmailReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "DoiTac_WebsiteEmailReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "DoiTac_WebsiteEmailReadGroup");

			//AuthorizationRules.AllowWrite("MaWebsiteEmail", "DoiTac_WebsiteEmailWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "DoiTac_WebsiteEmailWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "DoiTac_WebsiteEmailWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "DoiTac_WebsiteEmailWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static DoiTac_Website_Email NewDoiTac_WebsiteEmail()
		{
			return new DoiTac_Website_Email();
		}

		public static DoiTac_Website_Email GetDoiTac_Website_Email(SafeDataReader dr)
		{
			return new DoiTac_Website_Email(dr);
		}

		public DoiTac_Website_Email()
		{
			//this._maChiTiet = maChiTiet;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		public DoiTac_Website_Email(SafeDataReader dr)
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
			_maWebsiteEmail = dr.GetInt32("MaWebsiteEmail");
			_diaChi = dr.GetString("DiaChi");			
            _loai = dr.GetBoolean("loai");
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maDoiTac = dr.GetInt64("MaDoiTac");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DoiTac parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDoiTac_Website_Email";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maWebsiteEmail = (int)cm.Parameters["@MaWebsiteEmail"].Value;
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaWebsiteEmail", _maWebsiteEmail);
            cm.Parameters["@MaWebsiteEmail"].Direction = ParameterDirection.Output;

			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", false);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
			
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DoiTac parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDoiTac_Website_Email";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaWebsiteEmail", _maWebsiteEmail);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", false);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			
			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
			
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
                cm.CommandText = "spd_DeletetblDoiTac_Website_Email";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

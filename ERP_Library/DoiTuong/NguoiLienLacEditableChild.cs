
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguoiLienLac : Csla.BusinessBase<NguoiLienLac>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNguoiLienLac = 0;
		private string _tenNguoiLienLac = string.Empty;
		private string _dienThoai = string.Empty;
		private string _email = string.Empty;
		private long _maDoiTac = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNguoiLienLac
		{
			get
			{
				CanReadProperty("MaNguoiLienLac", true);
				return _maNguoiLienLac;
			}
		}

		public string TenNguoiLienLac
		{
			get
			{
				CanReadProperty("TenNguoiLienLac", true);
				return _tenNguoiLienLac;
			}
			set
			{
				CanWriteProperty("TenNguoiLienLac", true);
				if (value == null) value = string.Empty;
				if (!_tenNguoiLienLac.Equals(value))
				{
					_tenNguoiLienLac = value;
					PropertyHasChanged("TenNguoiLienLac");
				}
			}
		}

		public string DienThoai
		{
			get
			{
				CanReadProperty("DienThoai", true);
				return _dienThoai;
			}
			set
			{
				CanWriteProperty("DienThoai", true);
				if (value == null) value = string.Empty;
				if (!_dienThoai.Equals(value))
				{
					_dienThoai = value;
					PropertyHasChanged("DienThoai");
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
			return _maNguoiLienLac;
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
			// TenNguoiLienLac
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNguoiLienLac");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguoiLienLac", 500));
			//
			// DienThoai
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DienThoai");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 20));
			//
			// Email
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Email");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Email", 50));
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
			//TODO: Define authorization rules in NguoiLienLac
			//AuthorizationRules.AllowRead("MaNguoiLienLac", "NguoiLienLacReadGroup");
			//AuthorizationRules.AllowRead("TenNguoiLienLac", "NguoiLienLacReadGroup");
			//AuthorizationRules.AllowRead("DienThoai", "NguoiLienLacReadGroup");
			//AuthorizationRules.AllowRead("Email", "NguoiLienLacReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "NguoiLienLacReadGroup");

			//AuthorizationRules.AllowWrite("TenNguoiLienLac", "NguoiLienLacWriteGroup");
			//AuthorizationRules.AllowWrite("DienThoai", "NguoiLienLacWriteGroup");
			//AuthorizationRules.AllowWrite("Email", "NguoiLienLacWriteGroup");
			//AuthorizationRules.AllowWrite("MaDoiTac", "NguoiLienLacWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static NguoiLienLac NewNguoiLienLac()
		{
			return new NguoiLienLac();
		}

		internal static NguoiLienLac GetNguoiLienLac(SafeDataReader dr)
		{
			return new NguoiLienLac(dr);
		}

		public NguoiLienLac()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NguoiLienLac(SafeDataReader dr)
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
			_maNguoiLienLac = dr.GetInt32("MaNguoiLienLac");
			_tenNguoiLienLac = dr.GetString("TenNguoiLienLac");
			_dienThoai = dr.GetString("DienThoai");
			_email = dr.GetString("Email");
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
                cm.CommandText = "spd_InserttblNguoiLienLac";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNguoiLienLac = (int)cm.Parameters["@MaNguoiLienLac"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);

            cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
			cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			cm.Parameters.AddWithValue("@Email", _email);
			
			cm.Parameters.AddWithValue("@MaNguoiLienLac", _maNguoiLienLac);
			cm.Parameters["@MaNguoiLienLac"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblNguoiLienLac";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaNguoiLienLac", _maNguoiLienLac);
			cm.Parameters.AddWithValue("@TenNguoiLienLac", _tenNguoiLienLac);
			cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			cm.Parameters.AddWithValue("@Email", _email);
			cm.Parameters.AddWithValue("@MaDoiTac",parent.MaDoiTac);
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
                cm.CommandText = "spd_DeletetblNguoiLienLac";

				cm.Parameters.AddWithValue("@MaNguoiLienLac", this._maNguoiLienLac);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_Email : Csla.BusinessBase<NhanVien_Email>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private long _maNhanVien = 0;
		private int _maDiaChiWebsite = 0;
		private string _diaChi = string.Empty;
		private bool _loai = true;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaDiaChiWebsite
		{
			get
			{
				CanReadProperty("MaDiaChiWebsite", true);
				return _maDiaChiWebsite;
			}
			set
			{
				CanWriteProperty("MaDiaChiWebsite", true);
				if (!_maDiaChiWebsite.Equals(value))
				{
					_maDiaChiWebsite = value;
					PropertyHasChanged("MaDiaChiWebsite");
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

		public bool Loai
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
			//TODO: Define authorization rules in NhanVien_Email
			//AuthorizationRules.AllowRead("MaChiTiet", "NhanVien_EmailReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_EmailReadGroup");
			//AuthorizationRules.AllowRead("MaDiaChiWebsite", "NhanVien_EmailReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "NhanVien_EmailReadGroup");
			//AuthorizationRules.AllowRead("Loai", "NhanVien_EmailReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "NhanVien_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("MaDiaChiWebsite", "NhanVien_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "NhanVien_EmailWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "NhanVien_EmailWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static NhanVien_Email NewNhanVien_Email()
		{
			return new NhanVien_Email();
		}

		public static NhanVien_Email GetNhanVien_Email(SafeDataReader dr)
		{
			return new NhanVien_Email(dr);
		}

		private NhanVien_Email()
		{			
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_Email(SafeDataReader dr)
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
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maDiaChiWebsite = dr.GetInt32("MaDiaChiWebsite");
			_diaChi = dr.GetString("DiaChi");
			_loai = dr.GetBoolean("Loai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVien parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhanVien_Email";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                _maDiaChiWebsite = (int)cm.Parameters["@MaWebsiteEmail"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@MaWebsiteEmail", _maDiaChiWebsite);
            cm.Parameters["@MaWebsiteEmail"].Direction = ParameterDirection.Output;
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVien parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVien parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhanVien_Email";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            cm.Parameters.AddWithValue("@MaWebsiteEmail", _maDiaChiWebsite);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_loai != false)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblnsNhanVien_Email";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

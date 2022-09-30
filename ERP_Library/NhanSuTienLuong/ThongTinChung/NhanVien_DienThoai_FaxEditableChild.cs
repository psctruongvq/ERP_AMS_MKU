
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_DienThoai_Fax : Csla.BusinessBase<NhanVien_DienThoai_Fax>
	{
		#region Business Properties and Methods

		//declare members
		private string _soDTFax = string.Empty;
		private bool _loai = false;
		private int _maChiTiet = 0;
		private long _maNhanVien = 0;
		private int _maDienThoaiFax = 0;
        private bool _active = false;

		public string SoDTFax
		{
			get
			{
				CanReadProperty("SoDTFax", true);
				return _soDTFax;
			}
			set
			{
				CanWriteProperty("SoDTFax", true);
				if (value == null) value = string.Empty;
				if (!_soDTFax.Equals(value))
				{
					_soDTFax = value;
					PropertyHasChanged("SoDTFax");
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

		public int MaDienThoaiFax
		{
			get
			{
				CanReadProperty("MaDienThoaiFax", true);
				return _maDienThoaiFax;
			}
			set
			{
				CanWriteProperty("MaDienThoaiFax", true);
				if (!_maDienThoaiFax.Equals(value))
				{
					_maDienThoaiFax = value;
					PropertyHasChanged("MaDienThoaiFax");
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
			// SoDTFax
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoDTFax");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoDTFax", 20));
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
			//TODO: Define authorization rules in NhanVien_DienThoai_Fax
			//AuthorizationRules.AllowRead("SoDTFax", "NhanVien_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("Loai", "NhanVien_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "NhanVien_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaDienThoaiFax", "NhanVien_DienThoai_FaxReadGroup");
            //AuthorizationRules.AllowRead("Active", "NhanVien_DienThoai_FaxReadGroup");

			//AuthorizationRules.AllowWrite("SoDTFax", "NhanVien_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "NhanVien_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "NhanVien_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("MaDienThoaiFax", "NhanVien_DienThoai_FaxWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "NhanVien_DienThoai_FaxWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static NhanVien_DienThoai_Fax NewNhanVien_DienThoai_Fax()
		{
			return new NhanVien_DienThoai_Fax();
		}

		public static NhanVien_DienThoai_Fax GetNhanVien_DienThoai_Fax(SafeDataReader dr)
		{
			return new NhanVien_DienThoai_Fax(dr);
		}

		private NhanVien_DienThoai_Fax()
		{			
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_DienThoai_Fax(SafeDataReader dr)
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
			_soDTFax = dr.GetString("SoDTFax");
			_loai = dr.GetBoolean("Loai");
			_maChiTiet = dr.GetInt32("MaChiTiet");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maDienThoaiFax = dr.GetInt32("MaDienThoaiFax");
            _active = dr.GetBoolean("Active");
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
                cm.CommandText = "spd_InserttbNhanVien_DienThoai_Fax";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                _maDienThoaiFax = (int)cm.Parameters["@MaDienThoaiFax"].Value;


			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@SoDTFax", _soDTFax);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@MaDienThoaiFax", _maDienThoaiFax);
            cm.Parameters["@MaDienThoaiFax"].Direction = ParameterDirection.Output;
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", false);
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
                cm.CommandText = "spd_UpdatetblNhanVien_DienThoai_Fax";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@SoDTFax", _soDTFax);
			cm.Parameters.AddWithValue("@Loai", _loai);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			cm.Parameters.AddWithValue("@MaDienThoaiFax", _maDienThoaiFax);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", false);
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
                cm.CommandText = "spd_DeletetblNhanVien_DienThoai_Fax";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

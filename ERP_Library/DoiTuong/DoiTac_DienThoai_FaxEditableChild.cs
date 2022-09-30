
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_DienThoai_Fax : Csla.BusinessBase<DoiTac_DienThoai_Fax>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private long _maDoiTac = 0;
		private int _maDienThoaiFax = 0;
		private string _soDTFax = string.Empty;
		private bool _loai = false;
        private bool _active = true;

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
			//TODO: Define authorization rules in DoiTac_DienThoai_Fax
			//AuthorizationRules.AllowRead("MaChiTiet", "DoiTac_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "DoiTac_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaDienThoaiFax", "DoiTac_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("SoDTFax", "DoiTac_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("Loai", "DoiTac_DienThoai_FaxReadGroup");
            //AuthorizationRules.AllowRead("Active", "DoiTac_DienThoai_FaxReadGroup");

			//AuthorizationRules.AllowWrite("MaDoiTac", "DoiTac_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("MaDienThoaiFax", "DoiTac_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("SoDTFax", "DoiTac_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "DoiTac_DienThoai_FaxWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "DoiTac_DienThoai_FaxWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static DoiTac_DienThoai_Fax NewDoiTac_DienThoai_Fax()
		{
			return new DoiTac_DienThoai_Fax();
		}

		public static DoiTac_DienThoai_Fax GetDoiTac_DienThoai_Fax(SafeDataReader dr)
		{
			return new DoiTac_DienThoai_Fax(dr);
		}

		public DoiTac_DienThoai_Fax()
		{			
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		public DoiTac_DienThoai_Fax(SafeDataReader dr)
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
			_maDoiTac = dr.GetInt64("MaDoiTac");
			_maDienThoaiFax = dr.GetInt32("MaDienThoaiFax");
			_soDTFax = dr.GetString("SoDTFax");
			_loai = dr.GetBoolean("Loai");
            _active = dr.GetBoolean("Active");
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
                cm.CommandText = "spd_InserttblDoiTac_DienThoai_Fax";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
                _maDienThoaiFax = (int)cm.Parameters["@MaDTFax"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
			
			cm.Parameters.AddWithValue("@MaDTFax", _maDienThoaiFax);
            cm.Parameters["@MaDTFax"].Direction = ParameterDirection.Output;
			
			cm.Parameters.AddWithValue("@SoDTFax", _soDTFax);
			cm.Parameters.AddWithValue("@Loai", _loai);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", false);
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
                cm.CommandText = "spd_UpdatetblDoiTac_DienThoai_Fax";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			
			cm.Parameters.AddWithValue("@MaDoiTac", parent.MaDoiTac);
			
			cm.Parameters.AddWithValue("@MaDTFax", _maDienThoaiFax);
			
			cm.Parameters.AddWithValue("@SoDTFax", _soDTFax);
			cm.Parameters.AddWithValue("@Loai", _loai);
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
                cm.CommandText = "spd_DeletetblDoiTac_DienThoai_Fax";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

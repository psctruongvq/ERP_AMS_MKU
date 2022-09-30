
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_DienThoai_Fax : Csla.BusinessBase<CongTy_DienThoai_Fax>
	{
		#region Business Properties and Methods

        private int _maChiTiet = 0;
        private int _maCongTy = 0;
        private bool _active = false;
        private string _dienThoai = string.Empty;
        private string _fax = string.Empty;

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

        public string Fax
        {
            get
            {
                CanReadProperty("Fax", true);
                return _fax;
            }
            set
            {
                CanWriteProperty("Fax", true);
                if (value == null) value = string.Empty;
                if (!_fax.Equals(value))
                {
                    _fax = value;
                    PropertyHasChanged("Fax");
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
			//TODO: Define authorization rules in CongTy_DienThoai_Fax
			//AuthorizationRules.AllowRead("SoDTFax", "CongTy_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("Loai", "CongTy_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "CongTy_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "CongTy_DienThoai_FaxReadGroup");
			//AuthorizationRules.AllowRead("MaDienThoaiFax", "CongTy_DienThoai_FaxReadGroup");
            //AuthorizationRules.AllowRead("Active", "CongTy_DienThoai_FaxReadGroup");

			//AuthorizationRules.AllowWrite("SoDTFax", "CongTy_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "CongTy_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "CongTy_DienThoai_FaxWriteGroup");
			//AuthorizationRules.AllowWrite("MaDienThoaiFax", "CongTy_DienThoai_FaxWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "CongTy_DienThoai_FaxWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static CongTy_DienThoai_Fax NewCongTy_DienThoai_Fax()
		{
			return new CongTy_DienThoai_Fax();
		}

		public static CongTy_DienThoai_Fax GetCongTy_DienThoai_Fax(SafeDataReader dr)
		{
			return new CongTy_DienThoai_Fax(dr);
		}

		public CongTy_DienThoai_Fax()
		{
			//this._maChiTiet = maChiTiet;
			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		public CongTy_DienThoai_Fax(SafeDataReader dr)
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
            _dienThoai = dr.GetString("DienThoai");
            _fax = dr.GetString("Fax");
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
                cm.CommandText = "spd_InserttblDienThoai_Fax_CongTy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
             //   _maDienThoaiFax = (int)cm.Parameters["@MaDienThoaiFax"].Value;

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
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_fax.Length > 0)
                cm.Parameters.AddWithValue("@Fax", _fax);
            else
                cm.Parameters.AddWithValue("@Fax", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblDienThoai_Fax_CongTy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongTy parent)
		{
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (parent.MaCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", parent.MaCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_fax.Length > 0)
                cm.Parameters.AddWithValue("@Fax", _fax);
            else
                cm.Parameters.AddWithValue("@Fax", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDienThoai_Fax_CongTy";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

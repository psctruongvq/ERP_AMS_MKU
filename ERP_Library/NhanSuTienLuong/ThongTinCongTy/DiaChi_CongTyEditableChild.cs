
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DiaChi_CongTy : Csla.BusinessBase<DiaChi_CongTy>
	{
		#region Business Properties and Methods

		//declare members
        private int _maChiTiet = 0;
        private int _maCongTy = 0;
        private bool _active = false;
        private string _diaChi = string.Empty;
        private int _maTinhThanh = 0;

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

        public int MaTinhThanh
        {
            get
            {
                CanReadProperty("MaTinhThanh", true);
                return _maTinhThanh;
            }
            set
            {
                CanWriteProperty("MaTinhThanh", true);
                if (!_maTinhThanh.Equals(value))
                {
                    _maTinhThanh = value;
                    PropertyHasChanged("MaTinhThanh");
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
			// TenDiaChi
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "TenDiaChi");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDiaChi", 500));
            ////
            //// QuanHuyen
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuanHuyen");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHuyen", 50));
            ////
            //// TinhTP
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TinhTP");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TinhTP", 50));
            ////
            //// QuocGia
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "QuocGia");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuocGia", 50));
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
			//TODO: Define authorization rules in DiaChi_CongTy
			//AuthorizationRules.AllowRead("TenDiaChi", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("QuanHuyen", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("TinhTP", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("QuocGia", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("MaChiTiet", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("MaDiaChi", "DiaChi_CongTyReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "DiaChi_CongTyReadGroup");
            //AuthorizationRules.AllowRead("Active", "DiaChi_CongTyReadGroup");

			//AuthorizationRules.AllowWrite("TenDiaChi", "DiaChi_CongTyWriteGroup");
			//AuthorizationRules.AllowWrite("QuanHuyen", "DiaChi_CongTyWriteGroup");
			//AuthorizationRules.AllowWrite("TinhTP", "DiaChi_CongTyWriteGroup");
			//AuthorizationRules.AllowWrite("QuocGia", "DiaChi_CongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaDiaChi", "DiaChi_CongTyWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "DiaChi_CongTyWriteGroup");
            //AuthorizationRules.AllowWrite("Active", "DiaChi_CongTyWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static DiaChi_CongTy NewDiaChi_CongTy()
		{
			return new DiaChi_CongTy();
		}

		public static DiaChi_CongTy GetDiaChi_CongTy(SafeDataReader dr)
		{
			return new DiaChi_CongTy(dr);
		}

		public DiaChi_CongTy()
		{
			//this._maChiTiet = maChiTiet;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		public DiaChi_CongTy(SafeDataReader dr)
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
            try
            {
                _maChiTiet = dr.GetInt32("MaChiTiet");
                _maCongTy = dr.GetInt32("MaCongTy");
                _active = dr.GetBoolean("Active");
                _diaChi = dr.GetString("DiaChi");
                _maTinhThanh = dr.GetInt32("MaTinhThanh");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                cm.CommandText = "spd_InserttblDiaChi_CongTy";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
               

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
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblDiaChi_CongTy";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongTy parent)
		{
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_active != false)
                cm.Parameters.AddWithValue("@Active", _active);
            else
                cm.Parameters.AddWithValue("@Active", DBNull.Value);
            if (_diaChi.Length > 0)
                cm.Parameters.AddWithValue("@DiaChi", _diaChi);
            else
                cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
            if (_maTinhThanh != 0)
                cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
            else
                cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDiaChi_CongTy";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_NgoaiNgu : Csla.BusinessBase<NhanVien_NgoaiNgu>
	{
		#region Business Properties and Methods

		//declare members
        private int _manhanvienNgoaingu = 0;
        private long _maNhanVien = 0;
        private int _maNgoaiNgu = 0;
        private int _maTrinhDoNN = 0;
        private string _tenNgoaiNgu = string.Empty;
        private string _tenTrinhDoNN = string.Empty;
        private bool _ngoaiNguChinh = false;

       
        [System.ComponentModel.DataObjectField(true, true)]
        public string TenNgoaiNgu
        {
            get {
                _tenNgoaiNgu = NgoaiNgu.GetNgoaiNgu(_maNgoaiNgu).TenNgoaiNgu;
                return _tenNgoaiNgu; 
            }
            set { _tenNgoaiNgu = value; }
        }
        public string TenTrinhDoNN
        {
            get {
                _tenTrinhDoNN = TrinhDoNgoaiNguClass.GetTrinhDoNgoaiNguClass(_maTrinhDoNN).TrinhDoNgoaiNgu;
                return _tenTrinhDoNN; }
            set { _tenTrinhDoNN = value; }
        }
        public int ManhanvienNgoaingu
        {
            get
            {
                return _manhanvienNgoaingu;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int MaNgoaiNgu
        {
            get
            {
                return _maNgoaiNgu;
            }
            set
            {
                if (!_maNgoaiNgu.Equals(value))
                {
                    _maNgoaiNgu = value;
                    PropertyHasChanged("MaNgoaiNgu");
                }
            }
        }

        public int MaTrinhDoNN
        {
            get
            {
                return _maTrinhDoNN;
            }
            set
            {
                if (!_maTrinhDoNN.Equals(value))
                {
                    _maTrinhDoNN = value;
                    PropertyHasChanged("MaTrinhDoNN");
                }
            }
        }
        public bool NgoaiNguChinh
        {
            get
            {
                CanReadProperty("NgoaiNguChinh", true);
                return _ngoaiNguChinh; }
            set {
                _ngoaiNguChinh = value;
                PropertyHasChanged("NgoaiNguChinh");
            }
        }
        protected override object GetIdValue()
        {
            return _manhanvienNgoaingu;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuocGia", 50));
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
			
		}

		#endregion //Authorization Rules

		#region Factory Methods
        
        public static NhanVien_NgoaiNgu NewNhanVien_NgoaiNgu()
        {
            return new NhanVien_NgoaiNgu();
        }

		public static NhanVien_NgoaiNgu NewNhanVien_NgoaiNgu(long maNhanVien)
        {
            NhanVien_NgoaiNgu _NhanVien_NgoaiNgu = new NhanVien_NgoaiNgu();
            _NhanVien_NgoaiNgu.MaNhanVien = maNhanVien;
            return _NhanVien_NgoaiNgu;
        }

		public static NhanVien_NgoaiNgu GetNhanVien_NgoaiNgu(SafeDataReader dr)
		{
            NhanVien_NgoaiNgu child = new NhanVien_NgoaiNgu();
            child._manhanvienNgoaingu = dr.GetInt32("MaNhanVien_NgoaiNgu");
            child._maNhanVien = dr.GetInt64("MaNhanVien");
            child._maNgoaiNgu = dr.GetInt32("MaNgoaiNgu");
            child._maTrinhDoNN = dr.GetInt32("MaTrinhDoNN");
            child._ngoaiNguChinh = dr.GetBoolean("NgoaiNguChinh");
            child.MarkOld();
            return child;
		}

		private NhanVien_NgoaiNgu()
		{			
			//ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_NgoaiNgu(SafeDataReader dr)
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
            _manhanvienNgoaingu = dr.GetInt32("MaNhanVien_NgoaiNgu");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maNgoaiNgu = dr.GetInt32("MaNgoaiNgu");
            _maTrinhDoNN = dr.GetInt32("MaTrinhDoNN");
            _ngoaiNguChinh = dr.GetBoolean("NgoaiNguChinh");
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
                cm.CommandText = "spd_InserttblnsNhanVien_NgoaiNgu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _manhanvienNgoaingu = (int)cm.Parameters["@MaNhanVien_NgoaiNgu"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maNgoaiNgu != 0)
                cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            else
                cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoNN != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoNN", DBNull.Value);
            cm.Parameters.AddWithValue("@NgoaiNguChinh", _ngoaiNguChinh);
            cm.Parameters.AddWithValue("@MaNhanVien_NgoaiNgu", _manhanvienNgoaingu);
            cm.Parameters["@MaNhanVien_NgoaiNgu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNhanVien_NgoaiNgu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
            cm.Parameters.AddWithValue("@MaNhanVien_NgoaiNgu", _manhanvienNgoaingu);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maNgoaiNgu != 0)
                cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            else
                cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoNN != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoNN", DBNull.Value);
            cm.Parameters.AddWithValue("@NgoaiNguChinh", _ngoaiNguChinh);
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
                cm.CommandText = "spd_DeletetblnsNhanVien_NgoaiNgu";

                cm.Parameters.AddWithValue("@MaNhanVien_NgoaiNgu", this._manhanvienNgoaingu);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

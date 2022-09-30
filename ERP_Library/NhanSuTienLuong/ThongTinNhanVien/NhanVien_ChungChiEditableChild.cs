
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ChungChi : Csla.BusinessBase<NhanVien_ChungChi>
	{
		#region Business Properties and Methods

		//declare members
		private int _manhanvienChungchi = 0;
		private long _maNhanVien = 0;
		private string _tenChungChi = string.Empty;
		private DateTime _ngayCap = DateTime.Today;
		private string _noiCap = string.Empty;
		private string _ghiChu = string.Empty;
        private bool _chungChiChinh = false;
		[System.ComponentModel.DataObjectField(true, true)]
		public int ManhanvienChungchi
		{
			get
			{
				return _manhanvienChungchi;
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

		public string TenChungChi
		{
			get
			{
				return _tenChungChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChungChi.Equals(value))
				{
					_tenChungChi = value;
					PropertyHasChanged("TenChungChi");
				}
			}
		}

		public DateTime NgayCap
		{
			get
			{
				return _ngayCap;
			}
			set
			{
				if (!_ngayCap.Equals(value))
				{
					_ngayCap = value;
                    
					PropertyHasChanged("NgayCap");
				}
			}
		}

		public string NoiCap
		{
			get
			{
				return _noiCap;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_noiCap.Equals(value))
				{
					_noiCap = value;
					PropertyHasChanged("NoiCap");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				return _ghiChu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
        public bool ChungChiChinh
        {
            get
            {
                return _chungChiChinh;
            }
            set
            {
                if (!_chungChiChinh.Equals(value))
                {
                    _chungChiChinh = value;
                    PropertyHasChanged("ChungChiChinh");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _manhanvienChungchi;
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
			// TenChungChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChungChi", 50));
			//
			// NoiCap
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiCap", 50));
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

		#region Factory Methods
		public static NhanVien_ChungChi NewNhanVien_ChungChi()
		{
			return new NhanVien_ChungChi();
		}

		internal static NhanVien_ChungChi GetNhanVien_ChungChi(SafeDataReader dr)
		{
			return new NhanVien_ChungChi(dr);
		}

		private NhanVien_ChungChi()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhanVien_ChungChi(SafeDataReader dr)
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
			_manhanvienChungchi = dr.GetInt32("MaNhanVien_ChungChi");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenChungChi = dr.GetString("TenChungChi");
			_ngayCap = dr.GetDateTime("NgayCap");
			_noiCap = dr.GetString("NoiCap");
			_ghiChu = dr.GetString("GhiChu");
            _chungChiChinh=dr.GetBoolean("ChungChiChinh");
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
				cm.CommandText = "InserttblnsNhanVien_ChungChi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_manhanvienChungchi = (int)cm.Parameters["@MaNhanVien_ChungChi"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, NhanVien parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tenChungChi.Length > 0)
				cm.Parameters.AddWithValue("@TenChungChi", _tenChungChi);
			else
				cm.Parameters.AddWithValue("@TenChungChi", DBNull.Value);
			
				cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
			
			if (_noiCap.Length > 0)
				cm.Parameters.AddWithValue("@NoiCap", _noiCap);
			else
				cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@ChungChiChinh", _chungChiChinh);
			cm.Parameters.AddWithValue("@MaNhanVien_ChungChi", _manhanvienChungchi);
			cm.Parameters["@MaNhanVien_ChungChi"].Direction = ParameterDirection.Output;
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
				cm.CommandText = "UpdatetblnsNhanVien_ChungChi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, NhanVien parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien_ChungChi", _manhanvienChungchi);
            if (parent.MaNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", parent.MaNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_tenChungChi.Length > 0)
				cm.Parameters.AddWithValue("@TenChungChi", _tenChungChi);
			else
				cm.Parameters.AddWithValue("@TenChungChi", DBNull.Value);
			
				cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
		
			if (_noiCap.Length > 0)
				cm.Parameters.AddWithValue("@NoiCap", _noiCap);
			else
				cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@ChungChiChinh", _chungChiChinh);
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
				cm.CommandText = "DeletetblnsNhanVien_ChungChi";

				cm.Parameters.AddWithValue("@MaNhanVien_ChungChi", this._manhanvienChungchi);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

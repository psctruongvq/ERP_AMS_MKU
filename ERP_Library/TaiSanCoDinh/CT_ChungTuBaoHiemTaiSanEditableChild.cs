
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_ChungTuBaoHiemTaiSan : BusinessBase<CT_ChungTuBaoHiemTaiSan>
	{
		#region Business Properties and Methods

		//declare members
		private long _ID = 0;
		private long _maTSCDCB = 0;	
		private decimal _giaTriBaoHiem = 0;
		private long _maChungTu = 0;
	
		[System.ComponentModel.DataObjectField(true, true)]
		public long ID
		{
			get
			{
				CanReadProperty("ID", true);
				return _ID;
			}
		}

		public long MaTSCDCB
		{
			get
			{
				CanReadProperty("MaTSCDCB", true);
				return _maTSCDCB;
			}
			set
			{
				CanWriteProperty("MaTSCDCB", true);
				if (!_maTSCDCB.Equals(value))
				{
					_maTSCDCB = value;
					PropertyHasChanged("MaTSCDCB");
				}
			}
		}

		public long MaChungTu
		{
			get
			{
				CanReadProperty("MaChungTu", true);
				return _maChungTu;
			}
			set
			{
				CanWriteProperty("MaChungTu", true);
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
				}
			}
		}
		
		public decimal GiaTriBaoHiem
		{
			get
			{
				CanReadProperty("GiaTriBaoHiem", true);
				return _giaTriBaoHiem;
			}
			set
			{
				CanWriteProperty("GiaTriBaoHiem", true);
				if (!_giaTriBaoHiem.Equals(value))
				{
					_giaTriBaoHiem = value;               
					PropertyHasChanged("GiaTriBaoHiem");
				}
			}
		}
		
		protected override object GetIdValue()
		{
			return _ID;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{			
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
			//TODO: Define authorization rules in CT_ChungTuBaoHiemTaiSan			
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static CT_ChungTuBaoHiemTaiSan NewCT_ChungTuBaoHiemTaiSan()
		{
			return new CT_ChungTuBaoHiemTaiSan();
		}
        
		internal static CT_ChungTuBaoHiemTaiSan GetCT_ChungTuBaoHiemTaiSan(SafeDataReader dr)
		{
			return new CT_ChungTuBaoHiemTaiSan(dr);
		}

		private CT_ChungTuBaoHiemTaiSan()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private CT_ChungTuBaoHiemTaiSan(SafeDataReader dr)
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
			_ID = dr.GetInt64("ID");
			_maTSCDCB = dr.GetInt32("MaTSCDCB");			
			_giaTriBaoHiem = dr.GetDecimal("GiaTriBaoHiem");
			_maChungTu = dr.GetInt64("MaChungTu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTuBaoHiemTaiSan parent)
		{
			if (!IsDirty) return;
			ExecuteInsert(tr, parent);
			MarkOld();
			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTuBaoHiemTaiSan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_ChungTuBaoHiemTaiSan";

				AddInsertParameters(cm, parent);
				cm.ExecuteNonQuery();
				_ID = (long)cm.Parameters["@ID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTuBaoHiemTaiSan parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maChungTu = parent.ID;
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaTSCDCB", _maTSCDCB);			
			if (_giaTriBaoHiem != 0)
				cm.Parameters.AddWithValue("@GiaTriBaoHiem", _giaTriBaoHiem);
			else
				cm.Parameters.AddWithValue("@GiaTriBaoHiem", DBNull.Value);		
			cm.Parameters.AddWithValue("@ID", _ID);
			cm.Parameters["@ID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChungTuBaoHiemTaiSan parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChungTuBaoHiemTaiSan parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_ChungTuBaoHiemTaiSan";

				AddUpdateParameters(cm, parent);
				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTuBaoHiemTaiSan parent)
		{
			cm.Parameters.AddWithValue("@ID", _ID);
			cm.Parameters.AddWithValue("@MaTSCDCB", _maTSCDCB);
			cm.Parameters.AddWithValue("@MaChungTu", parent.ID);
			if (_giaTriBaoHiem != 0)
				cm.Parameters.AddWithValue("@GiaTriBaoHiem", _giaTriBaoHiem);
			else
				cm.Parameters.AddWithValue("@GiaTriBaoHiem", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_ChungTuBaoHiemTaiSan";

				cm.Parameters.AddWithValue("@ID", this._ID);
				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

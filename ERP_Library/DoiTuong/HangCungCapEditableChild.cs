
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HangCungCap : Csla.BusinessBase<HangCungCap>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHangCungCap = 0;
		private long _maNhaCungCap = 0;
		private int _maHangHoa = 0;
		private string _tenHangHoa = string.Empty;
		private string _maQLHangHoa = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaHangCungCap
		{
			get
			{
				CanReadProperty("MaHangCungCap", true);
				return _maHangCungCap;
			}
		}

		public long MaNhaCungCap
		{
			get
			{
				CanReadProperty("MaNhaCungCap", true);
				return _maNhaCungCap;
			}
			set
			{
				CanWriteProperty("MaNhaCungCap", true);
				if (!_maNhaCungCap.Equals(value))
				{
					_maNhaCungCap = value;
					PropertyHasChanged("MaNhaCungCap");
				}
			}
		}

		public int MaHangHoa
		{
			get
			{
				CanReadProperty("MaHangHoa", true);
				return _maHangHoa;
			}
			set
			{
				CanWriteProperty("MaHangHoa", true);
				if (!_maHangHoa.Equals(value))
				{
					_maHangHoa = value;
					PropertyHasChanged("MaHangHoa");
				}
			}
		}

		public string TenHangHoa
		{
			get
			{
				CanReadProperty("TenHangHoa", true);
				return _tenHangHoa;
			}
			set
			{
				CanWriteProperty("TenHangHoa", true);
				if (value == null) value = string.Empty;
				if (!_tenHangHoa.Equals(value))
				{
					_tenHangHoa = value;
					PropertyHasChanged("TenHangHoa");
				}
			}
		}

		public string MaQLHangHoa
		{
			get
			{
				CanReadProperty("MaQLHangHoa", true);
				return _maQLHangHoa;
			}
			set
			{
				CanWriteProperty("MaQLHangHoa", true);
				if (value == null) value = string.Empty;
				if (!_maQLHangHoa.Equals(value))
				{
					_maQLHangHoa = value;
					PropertyHasChanged("MaQLHangHoa");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHangCungCap;
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
			// TenHangHoa
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenHangHoa");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHangHoa", 500));
			//
			// MaQLHangHoa
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLHangHoa", 50));
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
			//TODO: Define authorization rules in HangCungCap
			//AuthorizationRules.AllowRead("MaHangCungCap", "HangCungCapReadGroup");
			//AuthorizationRules.AllowRead("MaNhaCungCap", "HangCungCapReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "HangCungCapReadGroup");
			//AuthorizationRules.AllowRead("TenHangHoa", "HangCungCapReadGroup");
			//AuthorizationRules.AllowRead("MaQLHangHoa", "HangCungCapReadGroup");

			//AuthorizationRules.AllowWrite("MaNhaCungCap", "HangCungCapWriteGroup");
			//AuthorizationRules.AllowWrite("MaHangHoa", "HangCungCapWriteGroup");
			//AuthorizationRules.AllowWrite("TenHangHoa", "HangCungCapWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLHangHoa", "HangCungCapWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		public static HangCungCap NewHangCungCap()
		{
			return new HangCungCap();
		}

		public static HangCungCap GetHangCungCap(SafeDataReader dr)
		{
			return new HangCungCap(dr);
		}

		public HangCungCap()
		{
			//this._maHangCungCap = maHangCungCap;
			ValidationRules.CheckRules();
			MarkAsChild();
		}

		public HangCungCap(SafeDataReader dr)
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
			_maHangCungCap = dr.GetInt32("MaHangCungCap");
			_maNhaCungCap = dr.GetInt64("MaNhaCungCap");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_tenHangHoa = dr.GetString("TenHangHoa");
			_maQLHangHoa = dr.GetString("MaQLHangHoa");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhaCungCap parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhaCungCap parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHangCungCap";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maHangCungCap = (int)cm.Parameters["@MaHangCungCap"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhaCungCap parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaHangCungCap", _maHangCungCap);
            cm.Parameters["@MaHangCungCap"].Direction = ParameterDirection.Output;
			
			cm.Parameters.AddWithValue("@MaNhaCungCap", parent.MaNhaCungCap);
			
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            //cm.Parameters.AddWithValue("@TenHangHoa", _tenHangHoa);
            //if (_maQLHangHoa.Length > 0)
            //    cm.Parameters.AddWithValue("@MaQLHangHoa", _maQLHangHoa);
            //else
            //    cm.Parameters.AddWithValue("@MaQLHangHoa", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhaCungCap parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhaCungCap parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHangCungCap";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhaCungCap parent)
		{
			cm.Parameters.AddWithValue("@MaHangCungCap", _maHangCungCap);
			
			cm.Parameters.AddWithValue("@MaNhaCungCap", parent.MaNhaCungCap);
			
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            //cm.Parameters.AddWithValue("@TenHangHoa", _tenHangHoa);
            //if (_maQLHangHoa.Length > 0)
            //    cm.Parameters.AddWithValue("@MaQLHangHoa", _maQLHangHoa);
            //else
            //    cm.Parameters.AddWithValue("@MaQLHangHoa", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblHangCungCap";

				cm.Parameters.AddWithValue("@MaHangCungCap", this._maHangCungCap);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

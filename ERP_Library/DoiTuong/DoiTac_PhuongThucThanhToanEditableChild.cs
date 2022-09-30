
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DoiTac_PhuongThucThanhToan : Csla.BusinessBase<DoiTac_PhuongThucThanhToan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChiTiet = 0;
		private long _maDoiTac = 0;
		private int _maPhuongThucThanhToan = 0;

		[System.ComponentModel.DataObjectField(true, true)]
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

		public int MaPhuongThucThanhToan
		{
			get
			{
				CanReadProperty("MaPhuongThucThanhToan", true);
				return _maPhuongThucThanhToan;
			}
			set
			{
				CanWriteProperty("MaPhuongThucThanhToan", true);
				if (!_maPhuongThucThanhToan.Equals(value))
				{
					_maPhuongThucThanhToan = value;
					PropertyHasChanged("MaPhuongThucThanhToan");
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
			//TODO: Define authorization rules in DoiTac_PhuongThucThanhToan
			//AuthorizationRules.AllowRead("MaChiTiet", "DoiTac_PhuongThucThanhToanReadGroup");
			//AuthorizationRules.AllowRead("MaDoiTac", "DoiTac_PhuongThucThanhToanReadGroup");
			//AuthorizationRules.AllowRead("MaPhuongThucThanhToan", "DoiTac_PhuongThucThanhToanReadGroup");

			//AuthorizationRules.AllowWrite("MaDoiTac", "DoiTac_PhuongThucThanhToanWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhuongThucThanhToan", "DoiTac_PhuongThucThanhToanWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static DoiTac_PhuongThucThanhToan NewDoiTac_PhuongThucThanhToan()
		{
			return new DoiTac_PhuongThucThanhToan();
		}

		internal static DoiTac_PhuongThucThanhToan GetDoiTac_PhuongThucThanhToan(SafeDataReader dr)
		{
			return new DoiTac_PhuongThucThanhToan(dr);
		}

		public DoiTac_PhuongThucThanhToan()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private DoiTac_PhuongThucThanhToan(SafeDataReader dr)
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
			_maPhuongThucThanhToan = dr.GetInt32("MaPhuongThucThanhToan");
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
                cm.CommandText = "spd_InserttblDoiTac_PhuongPhucThanhToan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maDoiTac = parent.MaDoiTac;
			if (_maDoiTac != 0)
				cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
			else
				cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			if (_maPhuongThucThanhToan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblDoiTac_PhuongPhucThanhToan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			if (_maDoiTac != 0)
				cm.Parameters.AddWithValue("@MaDoiTac", _maDoiTac);
			else
				cm.Parameters.AddWithValue("@MaDoiTac", DBNull.Value);
			if (_maPhuongThucThanhToan != 0)
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", _maPhuongThucThanhToan);
			else
				cm.Parameters.AddWithValue("@MaPhuongThucThanhToan", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblDoiTac_PhuongPhucThanhToan";

				cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

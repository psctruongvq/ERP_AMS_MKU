
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TongHopTHKPVaQuyetToanKPDaSuDung : Csla.BusinessBase<TongHopTHKPVaQuyetToanKPDaSuDung>
	{
		#region Business Properties and Methods

		//declare members
		private int _maMucTaiKhoan = 0;
		private string _tenMucTaiKhoan = string.Empty;
		private string _tenMucTaiKhoanCha = string.Empty;
		private string _tenNguon = string.Empty;
		private decimal _soPhatSinh = 0;
		private decimal _luyKe = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaMucTaiKhoan
		{
			get
			{
				CanReadProperty("MaMucTaiKhoan", true);
				return _maMucTaiKhoan;
			}
		}

		public string TenMucTaiKhoan
		{
			get
			{
				CanReadProperty("TenMucTaiKhoan", true);
				return _tenMucTaiKhoan;
			}
			set
			{
				CanWriteProperty("TenMucTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_tenMucTaiKhoan.Equals(value))
				{
					_tenMucTaiKhoan = value;
					PropertyHasChanged("TenMucTaiKhoan");
				}
			}
		}

		public string TenMucTaiKhoanCha
		{
			get
			{
				CanReadProperty("TenMucTaiKhoanCha", true);
				return _tenMucTaiKhoanCha;
			}
			set
			{
				CanWriteProperty("TenMucTaiKhoanCha", true);
				if (value == null) value = string.Empty;
				if (!_tenMucTaiKhoanCha.Equals(value))
				{
					_tenMucTaiKhoanCha = value;
					PropertyHasChanged("TenMucTaiKhoanCha");
				}
			}
		}

		public string TenNguon
		{
			get
			{
				CanReadProperty("TenNguon", true);
				return _tenNguon;
			}
			set
			{
				CanWriteProperty("TenNguon", true);
				if (value == null) value = string.Empty;
				if (!_tenNguon.Equals(value))
				{
					_tenNguon = value;
					PropertyHasChanged("TenNguon");
				}
			}
		}

		public decimal SoPhatSinh
		{
			get
			{
				CanReadProperty("SoPhatSinh", true);
				return _soPhatSinh;
			}
			set
			{
				CanWriteProperty("SoPhatSinh", true);
				if (!_soPhatSinh.Equals(value))
				{
					_soPhatSinh = value;
					PropertyHasChanged("SoPhatSinh");
				}
			}
		}

		public decimal LuyKe
		{
			get
			{
				CanReadProperty("LuyKe", true);
				return _luyKe;
			}
			set
			{
				CanWriteProperty("LuyKe", true);
				if (!_luyKe.Equals(value))
				{
					_luyKe = value;
					PropertyHasChanged("LuyKe");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maMucTaiKhoan;
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
			// TenMucTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucTaiKhoan", 1000));
			//
			// TenMucTaiKhoanCha
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMucTaiKhoanCha", 1000));
			//
			// TenNguon
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNguon");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNguon", 4000));
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
			//TODO: Define authorization rules in TongHopTHKPVaQuyetToanKPDaSuDung
			//AuthorizationRules.AllowRead("MaMucTaiKhoan", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");
			//AuthorizationRules.AllowRead("TenMucTaiKhoan", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");
			//AuthorizationRules.AllowRead("TenMucTaiKhoanCha", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");
			//AuthorizationRules.AllowRead("TenNguon", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");
			//AuthorizationRules.AllowRead("SoPhatSinh", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");
			//AuthorizationRules.AllowRead("LuyKe", "TongHopTHKPVaQuyetToanKPDaSuDungReadGroup");

			//AuthorizationRules.AllowWrite("TenMucTaiKhoan", "TongHopTHKPVaQuyetToanKPDaSuDungWriteGroup");
			//AuthorizationRules.AllowWrite("TenMucTaiKhoanCha", "TongHopTHKPVaQuyetToanKPDaSuDungWriteGroup");
			//AuthorizationRules.AllowWrite("TenNguon", "TongHopTHKPVaQuyetToanKPDaSuDungWriteGroup");
			//AuthorizationRules.AllowWrite("SoPhatSinh", "TongHopTHKPVaQuyetToanKPDaSuDungWriteGroup");
			//AuthorizationRules.AllowWrite("LuyKe", "TongHopTHKPVaQuyetToanKPDaSuDungWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TongHopTHKPVaQuyetToanKPDaSuDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TongHopTHKPVaQuyetToanKPDaSuDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TongHopTHKPVaQuyetToanKPDaSuDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TongHopTHKPVaQuyetToanKPDaSuDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TongHopTHKPVaQuyetToanKPDaSuDungDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TongHopTHKPVaQuyetToanKPDaSuDung()
		{ /* require use of factory method */ }

		public static TongHopTHKPVaQuyetToanKPDaSuDung NewTongHopTHKPVaQuyetToanKPDaSuDung(int maMucTaiKhoan)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TongHopTHKPVaQuyetToanKPDaSuDung");
			return DataPortal.Create<TongHopTHKPVaQuyetToanKPDaSuDung>(new Criteria(maMucTaiKhoan));
		}

		public static TongHopTHKPVaQuyetToanKPDaSuDung GetTongHopTHKPVaQuyetToanKPDaSuDung(int maMucTaiKhoan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TongHopTHKPVaQuyetToanKPDaSuDung");
			return DataPortal.Fetch<TongHopTHKPVaQuyetToanKPDaSuDung>(new Criteria(maMucTaiKhoan));
		}

		public static void DeleteTongHopTHKPVaQuyetToanKPDaSuDung(int maMucTaiKhoan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TongHopTHKPVaQuyetToanKPDaSuDung");
			DataPortal.Delete(new Criteria(maMucTaiKhoan));
		}

		public override TongHopTHKPVaQuyetToanKPDaSuDung Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TongHopTHKPVaQuyetToanKPDaSuDung");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TongHopTHKPVaQuyetToanKPDaSuDung");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TongHopTHKPVaQuyetToanKPDaSuDung");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TongHopTHKPVaQuyetToanKPDaSuDung(int maMucTaiKhoan)
		{
			this._maMucTaiKhoan = maMucTaiKhoan;
		}

		internal static TongHopTHKPVaQuyetToanKPDaSuDung NewTongHopTHKPVaQuyetToanKPDaSuDungChild(int maMucTaiKhoan)
		{
			TongHopTHKPVaQuyetToanKPDaSuDung child = new TongHopTHKPVaQuyetToanKPDaSuDung(maMucTaiKhoan);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TongHopTHKPVaQuyetToanKPDaSuDung GetTongHopTHKPVaQuyetToanKPDaSuDung(SafeDataReader dr)
		{
			TongHopTHKPVaQuyetToanKPDaSuDung child =  new TongHopTHKPVaQuyetToanKPDaSuDung();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaMucTaiKhoan;

			public Criteria(int maMucTaiKhoan)
			{
				this.MaMucTaiKhoan = maMucTaiKhoan;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maMucTaiKhoan = criteria.MaMucTaiKhoan;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "GetTongHopTHKPVaQuyetToanKPDaSuDung";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maMucTaiKhoan));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeleteTongHopTHKPVaQuyetToanKPDaSuDung";

				cm.Parameters.AddWithValue("@MaMucTaiKhoan", criteria.MaMucTaiKhoan);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

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
			_maMucTaiKhoan = dr.GetInt32("MaMucTaiKhoan");
			_tenMucTaiKhoan = dr.GetString("TenMucTaiKhoan");
			_tenMucTaiKhoanCha = dr.GetString("TenMucTaiKhoanCha");
			_tenNguon = dr.GetString("TenNguon");
			_soPhatSinh = dr.GetDecimal("SoPhatSinh");
			_luyKe = dr.GetDecimal("LuyKe");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddTongHopTHKPVaQuyetToanKPDaSuDung";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
			if (_tenMucTaiKhoanCha.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoanCha", _tenMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoanCha", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
			if (_soPhatSinh != 0)
				cm.Parameters.AddWithValue("@SoPhatSinh", _soPhatSinh);
			else
				cm.Parameters.AddWithValue("@SoPhatSinh", DBNull.Value);
			if (_luyKe != 0)
				cm.Parameters.AddWithValue("@LuyKe", _luyKe);
			else
				cm.Parameters.AddWithValue("@LuyKe", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateTongHopTHKPVaQuyetToanKPDaSuDung";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaMucTaiKhoan", _maMucTaiKhoan);
			if (_tenMucTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", _tenMucTaiKhoan);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoan", DBNull.Value);
			if (_tenMucTaiKhoanCha.Length > 0)
				cm.Parameters.AddWithValue("@TenMucTaiKhoanCha", _tenMucTaiKhoanCha);
			else
				cm.Parameters.AddWithValue("@TenMucTaiKhoanCha", DBNull.Value);
			cm.Parameters.AddWithValue("@TenNguon", _tenNguon);
			if (_soPhatSinh != 0)
				cm.Parameters.AddWithValue("@SoPhatSinh", _soPhatSinh);
			else
				cm.Parameters.AddWithValue("@SoPhatSinh", DBNull.Value);
			if (_luyKe != 0)
				cm.Parameters.AddWithValue("@LuyKe", _luyKe);
			else
				cm.Parameters.AddWithValue("@LuyKe", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maMucTaiKhoan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiThueThuNhap : Csla.BusinessBase<LoaiThueThuNhap>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThueThuNhap = 0;
		private decimal _tienToiThieu = 0;
		private decimal _tienToiDa = 0;
		private decimal _phanTramThue = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaThueThuNhap
		{
			get
			{
				CanReadProperty("MaThueThuNhap", true);
				return _maThueThuNhap;
			}
		}

		public decimal TienToiThieu
		{
			get
			{
				CanReadProperty("TienToiThieu", true);
				return _tienToiThieu;
			}
			set
			{
				CanWriteProperty("TienToiThieu", true);
				if (!_tienToiThieu.Equals(value))
				{
					_tienToiThieu = value;
					PropertyHasChanged("TienToiThieu");
				}
			}
		}

		public decimal TienToiDa
		{
			get
			{
				CanReadProperty("TienToiDa", true);
				return _tienToiDa;
			}
			set
			{
				CanWriteProperty("TienToiDa", true);
				if (!_tienToiDa.Equals(value))
				{
					_tienToiDa = value;
					PropertyHasChanged("TienToiDa");
				}
			}
		}

		public decimal PhanTramThue
		{
			get
			{
				CanReadProperty("PhanTramThue", true);
				return _phanTramThue;
			}
			set
			{
				CanWriteProperty("PhanTramThue", true);
				if (!_phanTramThue.Equals(value))
				{
					_phanTramThue = value;
					PropertyHasChanged("PhanTramThue");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maThueThuNhap;
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
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in LoaiThueThuNhap
			//AuthorizationRules.AllowRead("MaThueThuNhap", "LoaiThueThuNhapReadGroup");
			//AuthorizationRules.AllowRead("TienToiThieu", "LoaiThueThuNhapReadGroup");
			//AuthorizationRules.AllowRead("TienToiDa", "LoaiThueThuNhapReadGroup");
			//AuthorizationRules.AllowRead("PhanTramThue", "LoaiThueThuNhapReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "LoaiThueThuNhapReadGroup");

			//AuthorizationRules.AllowWrite("TienToiThieu", "LoaiThueThuNhapWriteGroup");
			//AuthorizationRules.AllowWrite("TienToiDa", "LoaiThueThuNhapWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramThue", "LoaiThueThuNhapWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "LoaiThueThuNhapWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiThueThuNhap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiThueThuNhapViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiThueThuNhap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiThueThuNhapAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiThueThuNhap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiThueThuNhapEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiThueThuNhap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiThueThuNhapDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiThueThuNhap()
		{ /* require use of factory method */ }

		public static LoaiThueThuNhap NewLoaiThueThuNhap()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiThueThuNhap");
			return DataPortal.Create<LoaiThueThuNhap>();
		}

		public static LoaiThueThuNhap GetLoaiThueThuNhap(int maThueThuNhap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiThueThuNhap");
			return DataPortal.Fetch<LoaiThueThuNhap>(new Criteria(maThueThuNhap));
		}

		public static void DeleteLoaiThueThuNhap(int maThueThuNhap)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiThueThuNhap");
			DataPortal.Delete(new Criteria(maThueThuNhap));
		}

		public override LoaiThueThuNhap Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiThueThuNhap");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiThueThuNhap");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiThueThuNhap");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiThueThuNhap NewLoaiThueThuNhapChild()
		{
			LoaiThueThuNhap child = new LoaiThueThuNhap();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiThueThuNhap GetLoaiThueThuNhap(SafeDataReader dr)
		{
			LoaiThueThuNhap child =  new LoaiThueThuNhap();
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
			public int MaThueThuNhap;

			public Criteria(int maThueThuNhap)
			{
				this.MaThueThuNhap = maThueThuNhap;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
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
                cm.CommandText = "spd_SelecttblnsLoaiThueThuNhap";

				cm.Parameters.AddWithValue("@MaThueThuNhap", criteria.MaThueThuNhap);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
			DataPortal_Delete(new Criteria(_maThueThuNhap));
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
                cm.CommandText = "spd_DeletetblnsLoaiThueThuNhap";

				cm.Parameters.AddWithValue("@MaThueThuNhap", criteria.MaThueThuNhap);

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
			_maThueThuNhap = dr.GetInt32("MaThueThuNhap");
			_tienToiThieu = dr.GetDecimal("TienToiThieu");
			_tienToiDa = dr.GetDecimal("TienToiDa");
			_phanTramThue = dr.GetDecimal("PhanTramThue");
			_ghiChu = dr.GetString("GhiChu");
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
                cm.CommandText = "spd_InserttblnsLoaiThueThuNhap";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maThueThuNhap = (int)cm.Parameters["@MaThueThuNhap"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tienToiThieu != 0)
				cm.Parameters.AddWithValue("@TienToiThieu", _tienToiThieu);
			else
				cm.Parameters.AddWithValue("@TienToiThieu", DBNull.Value);
			if (_tienToiDa != 0)
				cm.Parameters.AddWithValue("@TienToiDa", _tienToiDa);
			else
				cm.Parameters.AddWithValue("@TienToiDa", DBNull.Value);
			if (_phanTramThue != 0)
				cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
			else
				cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaThueThuNhap", _maThueThuNhap);
			cm.Parameters["@MaThueThuNhap"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLoaiThueThuNhap";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaThueThuNhap", _maThueThuNhap);
			if (_tienToiThieu != 0)
				cm.Parameters.AddWithValue("@TienToiThieu", _tienToiThieu);
			else
				cm.Parameters.AddWithValue("@TienToiThieu", DBNull.Value);
			if (_tienToiDa != 0)
				cm.Parameters.AddWithValue("@TienToiDa", _tienToiDa);
			else
				cm.Parameters.AddWithValue("@TienToiDa", DBNull.Value);
			if (_phanTramThue != 0)
				cm.Parameters.AddWithValue("@PhanTramThue", _phanTramThue);
			else
				cm.Parameters.AddWithValue("@PhanTramThue", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maThueThuNhap));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

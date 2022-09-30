
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiCongViec : Csla.BusinessBase<LoaiCongViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiCongViec = 0;
		private int _maLoaiLuong = 0;
		private string _maLoaiCongViecQL = string.Empty;
		private string _tenLoaiCongViec = string.Empty;
		private SmartDate _ngayTao = new SmartDate(false);
		private decimal _dinhMuc = 0;
		private double _phanTramDinhMuc = 0;
		private decimal _congDinhMuc = 0;
		private int _chiTietDinhMuc = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaLoaiCongViec
		{
			get
			{
				CanReadProperty("MaLoaiCongViec", true);
				return _maLoaiCongViec;
			}
           
		}

		public int MaLoaiLuong
		{
			get
			{
				CanReadProperty("MaLoaiLuong", true);
				return _maLoaiLuong;
			}
			set
			{
				CanWriteProperty("MaLoaiLuong", true);
				if (!_maLoaiLuong.Equals(value))
				{
					_maLoaiLuong = value;
					PropertyHasChanged("MaLoaiLuong");
				}
			}
		}

		public string MaLoaiCongViecQL
		{
			get
			{
				CanReadProperty("MaLoaiCongViecQL", true);
				return _maLoaiCongViecQL;
			}
			set
			{
				CanWriteProperty("MaLoaiCongViecQL", true);
				if (value == null) value = string.Empty;
				if (!_maLoaiCongViecQL.Equals(value))
				{
					_maLoaiCongViecQL = value;
					PropertyHasChanged("MaLoaiCongViecQL");
				}
			}
		}

		public string TenLoaiCongViec
		{
			get
			{
				CanReadProperty("TenLoaiCongViec", true);
				return _tenLoaiCongViec;
			}
			set
			{
				CanWriteProperty("TenLoaiCongViec", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiCongViec.Equals(value))
				{
					_tenLoaiCongViec = value;
					PropertyHasChanged("TenLoaiCongViec");
				}
			}
		}

		public DateTime NgayTao
		{
			get
			{
				CanReadProperty("NgayTao", true);
				return _ngayTao.Date;
			}
            set
            {
                CanWriteProperty("NgayTao", true);
                if (!_ngayTao.Equals(value))
                {
                    _ngayTao = new SmartDate(value);
                    PropertyHasChanged("NgayTao");
                }
            }
		}

		

		public decimal DinhMuc
		{
			get
			{
				CanReadProperty("DinhMuc", true);
				return _dinhMuc;
			}
			set
			{
				CanWriteProperty("DinhMuc", true);
				if (!_dinhMuc.Equals(value))
				{
					_dinhMuc = value;
					PropertyHasChanged("DinhMuc");
				}
			}
		}

		public double PhanTramDinhMuc
		{
			get
			{
				CanReadProperty("PhanTramDinhMuc", true);
				return _phanTramDinhMuc;
			}
			set
			{
				CanWriteProperty("PhanTramDinhMuc", true);
				if (!_phanTramDinhMuc.Equals(value))
				{
					_phanTramDinhMuc = value;
					PropertyHasChanged("PhanTramDinhMuc");
				}
			}
		}

		public decimal CongDinhMuc
		{
			get
			{
				CanReadProperty("CongDinhMuc", true);
				return _congDinhMuc;
			}
			set
			{
				CanWriteProperty("CongDinhMuc", true);
				if (!_congDinhMuc.Equals(value))
				{
					_congDinhMuc = value;
					PropertyHasChanged("CongDinhMuc");
				}
			}
		}

		public int ChiTietDinhMuc
		{
			get
			{
				CanReadProperty("ChiTietDinhMuc", true);
				return _chiTietDinhMuc;
			}
			set
			{
				CanWriteProperty("ChiTietDinhMuc", true);
				if (!_chiTietDinhMuc.Equals(value))
				{
					_chiTietDinhMuc = value;
					PropertyHasChanged("ChiTietDinhMuc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLoaiCongViec;
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
			// MaLoaiCongViecQL
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaLoaiCongViecQL", 50));
			//
			// TenLoaiCongViec
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiCongViec", 2000));
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
			//TODO: Define authorization rules in LoaiCongViec
			//AuthorizationRules.AllowRead("MaLoaiCongViec", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiLuong", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiCongViecQL", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiCongViec", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("DinhMuc", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("PhanTramDinhMuc", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("CongDinhMuc", "LoaiCongViecReadGroup");
			//AuthorizationRules.AllowRead("ChiTietDinhMuc", "LoaiCongViecReadGroup");

			//AuthorizationRules.AllowWrite("MaLoaiLuong", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiCongViecQL", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiCongViec", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTaoString", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("DinhMuc", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramDinhMuc", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("CongDinhMuc", "LoaiCongViecWriteGroup");
			//AuthorizationRules.AllowWrite("ChiTietDinhMuc", "LoaiCongViecWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiCongViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiCongViecDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiCongViec()
		{ /* require use of factory method */ }

		public static LoaiCongViec NewLoaiCongViec(int maLoaiCongViec)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiCongViec");
			return DataPortal.Create<LoaiCongViec>(new Criteria(maLoaiCongViec));
		}

		public static LoaiCongViec GetLoaiCongViec(int maLoaiCongViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiCongViec");
			return DataPortal.Fetch<LoaiCongViec>(new Criteria(maLoaiCongViec));
		}

		public static void DeleteLoaiCongViec(int maLoaiCongViec)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiCongViec");
			DataPortal.Delete(new Criteria(maLoaiCongViec));
		}

		public override LoaiCongViec Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiCongViec");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiCongViec");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiCongViec");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private LoaiCongViec(int maLoaiCongViec)
		{
			this._maLoaiCongViec = maLoaiCongViec;
		}

		internal static LoaiCongViec NewLoaiCongViecChild(int maLoaiCongViec)
		{
			LoaiCongViec child = new LoaiCongViec(maLoaiCongViec);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiCongViec GetLoaiCongViec(SafeDataReader dr)
		{
			LoaiCongViec child =  new LoaiCongViec();
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
			public int MaLoaiCongViec;

			public Criteria(int maLoaiCongViec)
			{
				this.MaLoaiCongViec = maLoaiCongViec;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maLoaiCongViec = criteria.MaLoaiCongViec;
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
                cm.CommandText = "sp_SelecttblnsLoaiCongViec";

				cm.Parameters.AddWithValue("@MaLoaiCongViec", criteria.MaLoaiCongViec);

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
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maLoaiCongViec));
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
                cm.CommandText = "sp_DeletetblnsLoaiCongViec";

				cm.Parameters.AddWithValue("@MaLoaiCongViec", criteria.MaLoaiCongViec);

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
			_maLoaiCongViec = dr.GetInt32("MaLoaiCongViec");
			_maLoaiLuong = dr.GetInt32("MaLoaiLuong");
			_maLoaiCongViecQL = dr.GetString("MaLoaiCongViecQL");
			_tenLoaiCongViec = dr.GetString("TenLoaiCongViec");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
			_dinhMuc = dr.GetDecimal("DinhMuc");
			_phanTramDinhMuc = dr.GetDouble("PhanTramDinhMuc");
			_congDinhMuc = dr.GetDecimal("CongDinhMuc");
			_chiTietDinhMuc = dr.GetInt32("ChiTietDinhMuc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, LoaiCongViecList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, LoaiCongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsLoaiCongViec";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                //_maLoaiCongViec=(int)cm.Parameters["MaLoaiCongViec"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, LoaiCongViecList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaLoaiCongViec", _maLoaiCongViec);
            cm.Parameters["@MaLoaiCongViec"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			if (_maLoaiCongViecQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiCongViecQL", _maLoaiCongViecQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiCongViecQL", DBNull.Value);
			if (_tenLoaiCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiCongViec", _tenLoaiCongViec);
			else
				cm.Parameters.AddWithValue("@TenLoaiCongViec", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			if (_dinhMuc != 0)
				cm.Parameters.AddWithValue("@DinhMuc", _dinhMuc);
			else
				cm.Parameters.AddWithValue("@DinhMuc", DBNull.Value);
			if (_phanTramDinhMuc != 0)
				cm.Parameters.AddWithValue("@PhanTramDinhMuc", _phanTramDinhMuc);
			else
				cm.Parameters.AddWithValue("@PhanTramDinhMuc", DBNull.Value);
			if (_congDinhMuc != 0)
				cm.Parameters.AddWithValue("@CongDinhMuc", _congDinhMuc);
			else
				cm.Parameters.AddWithValue("@CongDinhMuc", DBNull.Value);
			if (_chiTietDinhMuc != 0)
				cm.Parameters.AddWithValue("@ChiTietDinhMuc", _chiTietDinhMuc);
			else
				cm.Parameters.AddWithValue("@ChiTietDinhMuc", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, LoaiCongViecList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, LoaiCongViecList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsLoaiCongViec";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, LoaiCongViecList parent)
		{
			cm.Parameters.AddWithValue("@MaLoaiCongViec", _maLoaiCongViec);
			if (_maLoaiLuong != 0)
				cm.Parameters.AddWithValue("@MaLoaiLuong", _maLoaiLuong);
			else
				cm.Parameters.AddWithValue("@MaLoaiLuong", DBNull.Value);
			if (_maLoaiCongViecQL.Length > 0)
				cm.Parameters.AddWithValue("@MaLoaiCongViecQL", _maLoaiCongViecQL);
			else
				cm.Parameters.AddWithValue("@MaLoaiCongViecQL", DBNull.Value);
			if (_tenLoaiCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiCongViec", _tenLoaiCongViec);
			else
				cm.Parameters.AddWithValue("@TenLoaiCongViec", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			if (_dinhMuc != 0)
				cm.Parameters.AddWithValue("@DinhMuc", _dinhMuc);
			else
				cm.Parameters.AddWithValue("@DinhMuc", DBNull.Value);
			if (_phanTramDinhMuc != 0)
				cm.Parameters.AddWithValue("@PhanTramDinhMuc", _phanTramDinhMuc);
			else
				cm.Parameters.AddWithValue("@PhanTramDinhMuc", DBNull.Value);
			if (_congDinhMuc != 0)
				cm.Parameters.AddWithValue("@CongDinhMuc", _congDinhMuc);
			else
				cm.Parameters.AddWithValue("@CongDinhMuc", DBNull.Value);
			if (_chiTietDinhMuc != 0)
				cm.Parameters.AddWithValue("@ChiTietDinhMuc", _chiTietDinhMuc);
			else
				cm.Parameters.AddWithValue("@ChiTietDinhMuc", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiCongViec));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class GhepCongNhan : Csla.BusinessBase<GhepCongNhan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maGhepCongNhan = 0;
		private long _maNhanVienChinh = 0;
		private long _maNhanVienPhu = 0;
		private SmartDate _ngay = new SmartDate(DateTime.Today);
		private int _maKyTinhLuong = 0;
		private string _ghiChu = string.Empty;
		private decimal _phanTramHuong = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaGhepCongNhan
		{
			get
			{
				CanReadProperty("MaGhepCongNhan", true);
				return _maGhepCongNhan;
			}
		}

		public long MaNhanVienChinh
		{
			get
			{
				CanReadProperty("MaNhanVienChinh", true);
				return _maNhanVienChinh;
			}
			set
			{
				CanWriteProperty("MaNhanVienChinh", true);
				if (!_maNhanVienChinh.Equals(value))
				{
					_maNhanVienChinh = value;
					PropertyHasChanged("MaNhanVienChinh");
				}
			}
		}

		public long MaNhanVienPhu
		{
			get
			{
				CanReadProperty("MaNhanVienPhu", true);
				return _maNhanVienPhu;
			}
			set
			{
				CanWriteProperty("MaNhanVienPhu", true);
				if (!_maNhanVienPhu.Equals(value))
				{
					_maNhanVienPhu = value;
					PropertyHasChanged("MaNhanVienPhu");
				}
			}
		}

		public DateTime Ngay
		{
			get
			{
				CanReadProperty("Ngay", true);
				return _ngay.Date;
			}
            set
            {
                CanWriteProperty("Ngay", true);
                if (!_ngay.Equals(value))
                {
                    _ngay = new SmartDate(value);
                    PropertyHasChanged("Ngay");
                }
            }
		}

		
		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
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

		public decimal PhanTramHuong
		{
			get
			{
				CanReadProperty("PhanTramHuong", true);
				return _phanTramHuong;
			}
			set
			{
				CanWriteProperty("PhanTramHuong", true);
				if (!_phanTramHuong.Equals(value))
				{
					_phanTramHuong = value;
					PropertyHasChanged("PhanTramHuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maGhepCongNhan;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
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
			//TODO: Define authorization rules in GhepCongNhan
			//AuthorizationRules.AllowRead("MaGhepCongNhan", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVienChinh", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVienPhu", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("Ngay", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("NgayString", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "GhepCongNhanReadGroup");
			//AuthorizationRules.AllowRead("PhanTramHuong", "GhepCongNhanReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVienChinh", "GhepCongNhanWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVienPhu", "GhepCongNhanWriteGroup");
			//AuthorizationRules.AllowWrite("NgayString", "GhepCongNhanWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "GhepCongNhanWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "GhepCongNhanWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramHuong", "GhepCongNhanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in GhepCongNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in GhepCongNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in GhepCongNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in GhepCongNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("GhepCongNhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private GhepCongNhan()
		{ /* require use of factory method */ }

		public static GhepCongNhan NewGhepCongNhan(long maGhepCongNhan)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GhepCongNhan");
			return DataPortal.Create<GhepCongNhan>(new Criteria(maGhepCongNhan));
		}

		public static GhepCongNhan GetGhepCongNhan(long maGhepCongNhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a GhepCongNhan");
			return DataPortal.Fetch<GhepCongNhan>(new Criteria(maGhepCongNhan));
		}

		public static void DeleteGhepCongNhan(long maGhepCongNhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GhepCongNhan");
			DataPortal.Delete(new Criteria(maGhepCongNhan));
		}

		public override GhepCongNhan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a GhepCongNhan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a GhepCongNhan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a GhepCongNhan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private GhepCongNhan(long maGhepCongNhan)
		{
			this._maGhepCongNhan = maGhepCongNhan;
		}

		internal static GhepCongNhan NewGhepCongNhanChild(long maGhepCongNhan)
		{
			GhepCongNhan child = new GhepCongNhan(maGhepCongNhan);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static GhepCongNhan GetGhepCongNhan(SafeDataReader dr)
		{
			GhepCongNhan child =  new GhepCongNhan();
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
			public long MaGhepCongNhan;

			public Criteria(long maGhepCongNhan)
			{
				this.MaGhepCongNhan = maGhepCongNhan;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maGhepCongNhan = criteria.MaGhepCongNhan;
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
				cm.CommandText = "sp_SelecttblGhepCongNhan";
				cm.Parameters.AddWithValue("@MaGhepCongNhan", criteria.MaGhepCongNhan);                
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
			DataPortal_Delete(new Criteria(_maGhepCongNhan));
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
				cm.CommandText = "sp_DeletetblGhepCongNhan";

				cm.Parameters.AddWithValue("@MaGhepCongNhan", criteria.MaGhepCongNhan);

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
			_maGhepCongNhan = dr.GetInt64("MaGhepCongNhan");
			_maNhanVienChinh = dr.GetInt64("MaNhanVienChinh");
			_maNhanVienPhu = dr.GetInt64("MaNhanVienPhu");
			_ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_ghiChu = dr.GetString("GhiChu");
			_phanTramHuong = dr.GetDecimal("PhanTramHuong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, GhepCongNhanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, GhepCongNhanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "sp_InserttblGhepCongNhan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();
                _maGhepCongNhan = (long)cm.Parameters["@MaGhepCongNhan"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, GhepCongNhanList parent)
		{
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhanVienChinh != 0)
                cm.Parameters.AddWithValue("@MaNhanVienChinh", _maNhanVienChinh);
            else
                cm.Parameters.AddWithValue("@MaNhanVienChinh", DBNull.Value);
            if (_maNhanVienPhu != 0)
                cm.Parameters.AddWithValue("@MaNhanVienPhu", _maNhanVienPhu);
            else
                cm.Parameters.AddWithValue("@MaNhanVienPhu", DBNull.Value);
            cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_phanTramHuong != 0)
                cm.Parameters.AddWithValue("@PhanTramHuong", _phanTramHuong);
            else
                cm.Parameters.AddWithValue("@PhanTramHuong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaGhepCongNhan", _maGhepCongNhan);
            cm.Parameters["@MaGhepCongNhan"].Direction = ParameterDirection.Output;

		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, GhepCongNhanList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, GhepCongNhanList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "sp_UpdatetblGhepCongNhan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, GhepCongNhanList parent)
		{
			cm.Parameters.AddWithValue("@MaGhepCongNhan", _maGhepCongNhan);
			if (_maNhanVienChinh != 0)
				cm.Parameters.AddWithValue("@MaNhanVienChinh", _maNhanVienChinh);
			else
				cm.Parameters.AddWithValue("@MaNhanVienChinh", DBNull.Value);
			if (_maNhanVienPhu != 0)
				cm.Parameters.AddWithValue("@MaNhanVienPhu", _maNhanVienPhu);
			else
				cm.Parameters.AddWithValue("@MaNhanVienPhu", DBNull.Value);
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			if (_phanTramHuong != 0)
				cm.Parameters.AddWithValue("@PhanTramHuong", _phanTramHuong);
			else
				cm.Parameters.AddWithValue("@PhanTramHuong", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maGhepCongNhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

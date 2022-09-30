
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyLuong : Csla.BusinessBase<QuyLuong>
	{
		#region Business Properties and Methods

		//declare members
		private string _maQuyLuong = string.Empty;
		private int _maChiNhanh = 0;
		private decimal _soTien = 0;
		private SmartDate _ngayTao = new SmartDate(false);
		private int _maKyTinhLuong = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public string MaQuyLuong
		{
			get
			{
				CanReadProperty("MaQuyLuong", true);
				return _maQuyLuong;
			}
		}

		public int MaChiNhanh
		{
			get
			{
				CanReadProperty("MaChiNhanh", true);
				return _maChiNhanh;
			}
			set
			{
				CanWriteProperty("MaChiNhanh", true);
				if (!_maChiNhanh.Equals(value))
				{
					_maChiNhanh = value;
					PropertyHasChanged("MaChiNhanh");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
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
		}

		public string NgayTaoString
		{
			get
			{
				CanReadProperty("NgayTaoString", true);
				return _ngayTao.Text;
			}
			set
			{
				CanWriteProperty("NgayTaoString", true);
				if (value == null) value = string.Empty;
				if (!_ngayTao.Equals(value))
				{
					_ngayTao.Text = value;
					PropertyHasChanged("NgayTaoString");
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
 
		protected override object GetIdValue()
		{
			return _maQuyLuong;
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
			// MaQuyLuong
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQuyLuong");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuyLuong", 10));
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
			//TODO: Define authorization rules in QuyLuong
			//AuthorizationRules.AllowRead("MaQuyLuong", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("MaChiNhanh", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTao", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("NgayTaoString", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "QuyLuongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "QuyLuongReadGroup");

			//AuthorizationRules.AllowWrite("MaChiNhanh", "QuyLuongWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "QuyLuongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayTaoString", "QuyLuongWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "QuyLuongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "QuyLuongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuyLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyLuongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyLuongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyLuongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyLuong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyLuongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuyLuong()
		{ /* require use of factory method */ }

		public static QuyLuong NewQuyLuong(string maQuyLuong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyLuong");
			return DataPortal.Create<QuyLuong>(new Criteria(maQuyLuong));
		}

		public static QuyLuong GetQuyLuong(string maQuyLuong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyLuong");
			return DataPortal.Fetch<QuyLuong>(new Criteria(maQuyLuong));
		}

		public static void DeleteQuyLuong(string maQuyLuong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyLuong");
			DataPortal.Delete(new Criteria(maQuyLuong));
		}

		public override QuyLuong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuyLuong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyLuong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuyLuong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private QuyLuong(string maQuyLuong)
		{
			this._maQuyLuong = maQuyLuong;
		}

		internal static QuyLuong NewQuyLuongChild(string maQuyLuong)
		{
			QuyLuong child = new QuyLuong(maQuyLuong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuyLuong GetQuyLuong(SafeDataReader dr)
		{
			QuyLuong child =  new QuyLuong();
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
			public string MaQuyLuong;

			public Criteria(string maQuyLuong)
			{
				this.MaQuyLuong = maQuyLuong;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maQuyLuong = criteria.MaQuyLuong;
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
				cm.CommandText = "sp_SelecttblnsQuyLuong";

				cm.Parameters.AddWithValue("@MaQuyLuong", criteria.MaQuyLuong);

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
			DataPortal_Delete(new Criteria(_maQuyLuong));
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
				cm.CommandText = "sp_DeletetblnsQuyLuong";

				cm.Parameters.AddWithValue("@MaQuyLuong", criteria.MaQuyLuong);

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
			_maQuyLuong = dr.GetString("MaQuyLuong");
			_maChiNhanh = dr.GetInt32("MaChiNhanh");
			_soTien = dr.GetDecimal("SoTien");
			_ngayTao = dr.GetSmartDate("NgayTao", _ngayTao.EmptyIsMin);
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, QuyLuongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, QuyLuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "sp_InserttblnsQuyLuong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, QuyLuongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuyLuong", _maQuyLuong);
			if (_maChiNhanh != 0)
				cm.Parameters.AddWithValue("@MaChiNhanh", _maChiNhanh);
			else
				cm.Parameters.AddWithValue("@MaChiNhanh", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, QuyLuongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, QuyLuongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "sp_UpdatetblnsQuyLuong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, QuyLuongList parent)
		{
			cm.Parameters.AddWithValue("@MaQuyLuong", _maQuyLuong);
			if (_maChiNhanh != 0)
				cm.Parameters.AddWithValue("@MaChiNhanh", _maChiNhanh);
			else
				cm.Parameters.AddWithValue("@MaChiNhanh", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayTao", _ngayTao.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maQuyLuong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

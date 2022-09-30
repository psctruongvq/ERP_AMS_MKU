
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhSachNghiLam : Csla.BusinessBase<DanhSachNghiLam>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
		private int _phepDiDuong = 0;
		private string _lyDo = string.Empty;
		private string _loaiNghi = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
		}

		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
			set
			{
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public string TuNgayString
		{
			get
			{
				CanReadProperty("TuNgayString", true);
				return _tuNgay.Text;
			}
		}

		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
		}

		public string DenNgayString
		{
			get
			{
				CanReadProperty("DenNgayString", true);
				return _denNgay.Text;
			}
			set
			{
				CanWriteProperty("DenNgayString", true);
				if (value == null) value = string.Empty;
				if (!_denNgay.Equals(value))
				{
					_denNgay.Text = value;
					PropertyHasChanged("DenNgayString");
				}
			}
		}

		public int PhepDiDuong
		{
			get
			{
				CanReadProperty("PhepDiDuong", true);
				return _phepDiDuong;
			}
			set
			{
				CanWriteProperty("PhepDiDuong", true);
				if (!_phepDiDuong.Equals(value))
				{
					_phepDiDuong = value;
					PropertyHasChanged("PhepDiDuong");
				}
			}
		}

		public string LyDo
		{
			get
			{
				CanReadProperty("LyDo", true);
				return _lyDo;
			}
			set
			{
				CanWriteProperty("LyDo", true);
				if (value == null) value = string.Empty;
				if (!_lyDo.Equals(value))
				{
					_lyDo = value;
					PropertyHasChanged("LyDo");
				}
			}
		}

		public string LoaiNghi
		{
			get
			{
				CanReadProperty("LoaiNghi", true);
				return _loaiNghi;
			}
			set
			{
				CanWriteProperty("LoaiNghi", true);
				if (value == null) value = string.Empty;
				if (!_loaiNghi.Equals(value))
				{
					_loaiNghi = value;
					PropertyHasChanged("LoaiNghi");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return string.Format("{0}:{1}", _maNhanVien, _tuNgay);
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// TuNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TuNgayString");
			//
			// DenNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DenNgayString");
			//
			// LyDo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 200));
			//
			// LoaiNghi
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "LoaiNghi");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiNghi", 20));
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
			//TODO: Define authorization rules in DanhSachNghiLam
			//AuthorizationRules.AllowRead("MaNhanVien", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("PhepDiDuong", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("LyDo", "DanhSachNghiLamReadGroup");
			//AuthorizationRules.AllowRead("LoaiNghi", "DanhSachNghiLamReadGroup");

			//AuthorizationRules.AllowWrite("TenNhanVien", "DanhSachNghiLamWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "DanhSachNghiLamWriteGroup");
			//AuthorizationRules.AllowWrite("PhepDiDuong", "DanhSachNghiLamWriteGroup");
			//AuthorizationRules.AllowWrite("LyDo", "DanhSachNghiLamWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiNghi", "DanhSachNghiLamWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DanhSachNghiLam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DanhSachNghiLam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DanhSachNghiLam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DanhSachNghiLam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachNghiLamDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanhSachNghiLam()
		{ /* require use of factory method */ }

		public static DanhSachNghiLam NewDanhSachNghiLam(long maNhanVien, SmartDate tuNgay)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhSachNghiLam");
			return DataPortal.Create<DanhSachNghiLam>(new Criteria(maNhanVien, tuNgay));
		}

		public static DanhSachNghiLam GetDanhSachNghiLam(long maNhanVien, SmartDate tuNgay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DanhSachNghiLam");
			return DataPortal.Fetch<DanhSachNghiLam>(new Criteria(maNhanVien, tuNgay));
		}

		public static void DeleteDanhSachNghiLam(long maNhanVien, SmartDate tuNgay)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhSachNghiLam");
			DataPortal.Delete(new Criteria(maNhanVien, tuNgay));
		}

		public override DanhSachNghiLam Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhSachNghiLam");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhSachNghiLam");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DanhSachNghiLam");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DanhSachNghiLam(long maNhanVien, SmartDate tuNgay)
		{
			this._maNhanVien = maNhanVien;
			this._tuNgay = tuNgay;
		}

		internal static DanhSachNghiLam NewDanhSachNghiLamChild(long maNhanVien, SmartDate tuNgay)
		{
			DanhSachNghiLam child = new DanhSachNghiLam(maNhanVien, tuNgay);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DanhSachNghiLam GetDanhSachNghiLam(SafeDataReader dr)
		{
			DanhSachNghiLam child =  new DanhSachNghiLam();
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
			public long MaNhanVien;
			public SmartDate TuNgay;

			public Criteria(long maNhanVien, SmartDate tuNgay)
			{
				this.MaNhanVien = maNhanVien;
				this.TuNgay = tuNgay;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
			_tuNgay = criteria.TuNgay;
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
				cm.CommandText = "spd_SelecttblDanhSachNghiLam";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay.DBValue);

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
			DataPortal_Delete(new Criteria(_maNhanVien, _tuNgay));
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
				cm.CommandText = "spd_DeletetblDanhSachNghiLam";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
				cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay.DBValue);

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
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_phepDiDuong = dr.GetInt32("PhepDiDuong");
			_lyDo = dr.GetString("LyDo");
			_loaiNghi = dr.GetString("LoaiNghi");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DanhSachNghiLamList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DanhSachNghiLamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblDanhSachNghiLam";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DanhSachNghiLamList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			cm.Parameters.AddWithValue("@PhepDiDuong", _phepDiDuong);
			cm.Parameters.AddWithValue("@LyDo", _lyDo);
			cm.Parameters.AddWithValue("@LoaiNghi", _loaiNghi);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DanhSachNghiLamList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DanhSachNghiLamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblDanhSachNghiLam";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DanhSachNghiLamList parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			cm.Parameters.AddWithValue("@PhepDiDuong", _phepDiDuong);
			cm.Parameters.AddWithValue("@LyDo", _lyDo);
			cm.Parameters.AddWithValue("@LoaiNghi", _loaiNghi);
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

			ExecuteDelete(tr, new Criteria(_maNhanVien, _tuNgay));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

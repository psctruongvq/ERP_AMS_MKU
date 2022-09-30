
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DieuChuyenTam : Csla.BusinessBase<DieuChuyenTam>
	{
		#region Business Properties and Methods

		//declare members
		private long _maDieuChuyen = 0;
		private string _maDieuChuyenQL = string.Empty;
        private string _tenNhanVien = string.Empty;
		private int _maBoPhan = 0;
		private SmartDate _ngay = new SmartDate(DateTime.Today);
		private int _maCongViec = 0;
		private long _maNhanVien = 0;
		private int _maKyTinhLuong = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaDieuChuyen
		{
			get
			{
				CanReadProperty("MaDieuChuyen", true);
				return _maDieuChuyen;
			}
		}

		public string MaDieuChuyenQL
		{
			get
			{
				CanReadProperty("MaDieuChuyenQL", true);
				return _maDieuChuyenQL;
			}
			set
			{
				CanWriteProperty("MaDieuChuyenQL", true);
				if (value == null) value = string.Empty;
				if (!_maDieuChuyenQL.Equals(value))
				{
					_maDieuChuyenQL = value;
					PropertyHasChanged("MaDieuChuyenQL");
				}
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
		public int MaBoPhan
		{
			get
			{
				CanReadProperty("MaBoPhan", true);
				return _maBoPhan;
			}
			set
			{
				CanWriteProperty("MaBoPhan", true);
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
					PropertyHasChanged("MaBoPhan");
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

		public int MaCongViec
		{
			get
			{
				CanReadProperty("MaCongViec", true);
				return _maCongViec;
			}
			set
			{
				CanWriteProperty("MaCongViec", true);
				if (!_maCongViec.Equals(value))
				{
					_maCongViec = value;
					PropertyHasChanged("MaCongViec");
				}
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
                TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
                    TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
					PropertyHasChanged("MaNhanVien");
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
 
		protected override object GetIdValue()
		{
			return _maDieuChuyen;
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
			// MaDieuChuyenQL
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaDieuChuyenQL", 50));
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
			//TODO: Define authorization rules in DieuChuyenTam
			//AuthorizationRules.AllowRead("MaDieuChuyen", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("MaDieuChuyenQL", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhan", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("Ngay", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("NgayString", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "DieuChuyenTamReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "DieuChuyenTamReadGroup");

			//AuthorizationRules.AllowWrite("MaDieuChuyenQL", "DieuChuyenTamWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhan", "DieuChuyenTamWriteGroup");
			//AuthorizationRules.AllowWrite("NgayString", "DieuChuyenTamWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongViec", "DieuChuyenTamWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "DieuChuyenTamWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "DieuChuyenTamWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DieuChuyenTam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DieuChuyenTam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DieuChuyenTam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DieuChuyenTam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTamDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DieuChuyenTam()
		{ /* require use of factory method */ }

		public static DieuChuyenTam NewDieuChuyenTam(long maDieuChuyen)
		{
            //if (!CanAddObject())
            //    throw new System.Security.SecurityException("User not authorized to add a DieuChuyenTam");
            ////return DataPortal.Create<DieuChuyenTam>(new Criteria(maDieuChuyen));
            //return DataPortal.Create<DieuChuyenTam>(new Criteria(maDieuChuyen));
            DieuChuyenTam dct = new DieuChuyenTam();
            return dct;
		}

		public static DieuChuyenTam GetDieuChuyenTam(long maDieuChuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DieuChuyenTam");
			return DataPortal.Fetch<DieuChuyenTam>(new Criteria(maDieuChuyen));
		}

		public static void DeleteDieuChuyenTam(long maDieuChuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenTam");
			DataPortal.Delete(new Criteria(maDieuChuyen));
		}

		public override DieuChuyenTam Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenTam");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChuyenTam");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DieuChuyenTam");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DieuChuyenTam NewDieuChuyenTamChild()
		{
			DieuChuyenTam child = new DieuChuyenTam();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DieuChuyenTam GetDieuChuyenTam(SafeDataReader dr)
		{
			DieuChuyenTam child =  new DieuChuyenTam();
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
			public long MaDieuChuyen;
            
			public Criteria(long maDieuChuyen)
			{
				this.MaDieuChuyen = maDieuChuyen;
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
                cm.CommandText = "sp_SelecttblnsDieuChuyenTam";

				cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

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
			DataPortal_Delete(new Criteria(_maDieuChuyen));
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
                cm.CommandText = "sp_DeletetblnsDieuChuyenTam";

				cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

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
			_maDieuChuyen = dr.GetInt64("MaDieuChuyen");
			_maDieuChuyenQL = dr.GetString("MaDieuChuyenQL");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
			_maCongViec = dr.GetInt32("MaCongViec");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DieuChuyenTamList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DieuChuyenTamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsDieuChuyenTam";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maDieuChuyen = (long)cm.Parameters["@MaDieuChuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DieuChuyenTamList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maDieuChuyenQL.Length > 0)
				cm.Parameters.AddWithValue("@MaDieuChuyenQL", _maDieuChuyenQL);
			else
				cm.Parameters.AddWithValue("@MaDieuChuyenQL", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            cm.Parameters.AddWithValue("@MaBoPhanGoc", TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).MaBoPhan);
			cm.Parameters["@MaDieuChuyen"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DieuChuyenTamList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DieuChuyenTamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsDieuChuyenTam";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DieuChuyenTamList parent)
		{
			cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
			if (_maDieuChuyenQL.Length > 0)
				cm.Parameters.AddWithValue("@MaDieuChuyenQL", _maDieuChuyenQL);
			else
				cm.Parameters.AddWithValue("@MaDieuChuyenQL", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
			//if (_maNhanVien != 0)
			//	cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			//else
				//cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			//cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
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

			ExecuteDelete(tr, new Criteria(_maDieuChuyen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

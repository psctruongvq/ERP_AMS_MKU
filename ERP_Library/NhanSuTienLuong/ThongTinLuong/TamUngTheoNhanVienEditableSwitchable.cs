
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUngTheoNhanVien : Csla.BusinessBase<TamUngTheoNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maTamUngTheoNV = 0;
		private long _maNhanVien = 0;
		private int _maChucVu = 0;
		private decimal _soTien = 0;
		private string _ghiChu = string.Empty;
        private string _tenNhanVien = string.Empty;
		private SmartDate _ngayLap = new SmartDate(DateTime.Today);
		private int _maKyTinhLuong = 0;
        private decimal _soCongThucTe = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public long MaTamUngTheoNV
		{
			get
			{
				CanReadProperty("MaTamUngTheoNV", true);
				return _maTamUngTheoNV;
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
                   // TenNhanVien = NhanVien.GetNhanVien(_maNhanVien).TenNhanVien;
                    TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                    //MaChucVu = NhanVien.GetNhanVien(_maNhanVien).MaChucVu;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
                
				return _maChucVu;
			}
			set
			{
				CanWriteProperty("MaChucVu", true);
				if (!_maChucVu.Equals(value))
				{                    
					_maChucVu = value;
					PropertyHasChanged("MaChucVu");
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
        public decimal SoCongThucTe
        {
            get
            {
                CanReadProperty("SoCongThucTe", true);                 
                 return _soCongThucTe;
            }
            set
            {
                CanWriteProperty("SoCongThucTe", true);
                if (!_soCongThucTe.Equals(value))
                {
                    _soCongThucTe = value;
                    PropertyHasChanged("SoCongThucTe");
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

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    _soCongThucTe = GetSoCongThucTe(_maNhanVien, _maKyTinhLuong, NgayLap);
                    PropertyHasChanged("NgayLap");
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
			return _maTamUngTheoNV;
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
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 200));
			//
			// NgayLap
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "NgayLapString");
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
			//TODO: Define authorization rules in TamUngTheoNhanVien
			//AuthorizationRules.AllowRead("MaTamUngTheoNV", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "TamUngTheoNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "TamUngTheoNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "TamUngTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "TamUngTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "TamUngTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "TamUngTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "TamUngTheoNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "TamUngTheoNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TamUngTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TamUngTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TamUngTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TamUngTheoNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TamUngTheoNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TamUngTheoNhanVien()
		{ /* require use of factory method */ }

		public static TamUngTheoNhanVien NewTamUngTheoNhanVien()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoNhanVien");
			return DataPortal.Create<TamUngTheoNhanVien>();
		}

		public static TamUngTheoNhanVien GetTamUngTheoNhanVien(long maTamUngTheoNV)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TamUngTheoNhanVien");
			return DataPortal.Fetch<TamUngTheoNhanVien>(new Criteria(maTamUngTheoNV));
		}

		public static void DeleteTamUngTheoNhanVien(long maTamUngTheoNV)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TamUngTheoNhanVien");
			DataPortal.Delete(new Criteria(maTamUngTheoNV));
		}
        public static decimal GetSoCongThucTe(long maNhanVien, int maKyTinhLuong, DateTime denNgay)
        {
            decimal tongNgayCong = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SoNgayCongNV";
                        cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cm.Parameters.AddWithValue("@MaKy", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        cm.Parameters.AddWithValue("@TongNgayCong", tongNgayCong);
                        cm.Parameters["@TongNgayCong"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        tongNgayCong = (decimal)cm.Parameters["@TongNgayCong"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return tongNgayCong;
            }
        }
        public static int KiemTraNVTonTai(long maNhanVien, int maKyTinhLuong, int maChucVu)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraNhanVienTonTaiTamUng";
                        cm.Parameters.AddWithValue("@maNV", maNhanVien);
                        cm.Parameters.AddWithValue("@MaKy", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaChucVu", maChucVu);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
		public override TamUngTheoNhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TamUngTheoNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TamUngTheoNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TamUngTheoNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TamUngTheoNhanVien NewTamUngTheoNhanVienChild()
		{
			TamUngTheoNhanVien child = new TamUngTheoNhanVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TamUngTheoNhanVien GetTamUngTheoNhanVien(SafeDataReader dr)
		{
			TamUngTheoNhanVien child =  new TamUngTheoNhanVien();
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
			public long MaTamUngTheoNV;

			public Criteria(long maTamUngTheoNV)
			{
				this.MaTamUngTheoNV = maTamUngTheoNV;
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
                cm.CommandText = "sp_SelecttblnsTamUngTheoNhanVien";

				cm.Parameters.AddWithValue("@MaTamUngTheoNV", criteria.MaTamUngTheoNV);

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
			DataPortal_Delete(new Criteria(_maTamUngTheoNV));
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
                cm.CommandText = "sp_DeletetblnsTamUngTheoNhanVien";

				cm.Parameters.AddWithValue("@MaTamUngTheoNV", criteria.MaTamUngTheoNV);

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
			_maTamUngTheoNV = dr.GetInt64("MaTamUngTheoNV");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maChucVu = dr.GetInt32("MaChucVu");
			_soTien = dr.GetDecimal("SoTien");
			_ghiChu = dr.GetString("GhiChu");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _soCongThucTe = dr.GetDecimal("SoCongThucTe");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TamUngTheoNhanVienList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TamUngTheoNhanVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsTamUngTheoNhanVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTamUngTheoNV = (long)cm.Parameters["@MaTamUngTheoNV"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TamUngTheoNhanVienList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaChucVu", ChucVu.GetChucVuTheoNhanVien(_maNhanVien).MaChucVu);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTamUngTheoNV", _maTamUngTheoNV);
            cm.Parameters.AddWithValue("@SoCongThucTe", _soCongThucTe);
			cm.Parameters["@MaTamUngTheoNV"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TamUngTheoNhanVienList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TamUngTheoNhanVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsTamUngTheoNhanVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TamUngTheoNhanVienList parent)
		{
			cm.Parameters.AddWithValue("@MaTamUngTheoNV", _maTamUngTheoNV);
			//cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			//cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            //if (_maKyTinhLuong != 0)
            //    cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            //else
            //    cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
           // cm.Parameters.AddWithValue("@SoCongThucTe", _soCongThucTe);
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

			ExecuteDelete(tr, new Criteria(_maTamUngTheoNV));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

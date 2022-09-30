
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhamChuaBenh : Csla.BusinessBase<KhamChuaBenh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKhamChuaBenh = 0;
		private long _maNhanVien = 0;
		private string _soKhamChuaBenh = string.Empty;
		private SmartDate _ngayLapSo = new SmartDate(DateTime.Today);
		private string _noiDungKham = string.Empty;
		private double _chieuCao = 0;
		private double _canNang = 0;
		private short _loaiSucKhoe = 0;
		private string _noiKham = string.Empty;
		private string _ketLuan = string.Empty;
		private long _maNguoiLap = 1;
        private string _tenNguoiLap = string.Empty;

		private SmartDate _ngayLap = new SmartDate(DateTime.Today);

		[System.ComponentModel.DataObjectField(true, true)]

		public int MaKhamChuaBenh
		{
			get
			{
				CanReadProperty("MaKhamChuaBenh", true);
				return _maKhamChuaBenh;
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public string SoKhamChuaBenh
		{
			get
			{
				CanReadProperty("SoKhamChuaBenh", true);
				return _soKhamChuaBenh;
			}
			set
			{
				CanWriteProperty("SoKhamChuaBenh", true);
				if (value == null) value = string.Empty;
				if (!_soKhamChuaBenh.Equals(value))
				{
					_soKhamChuaBenh = value;
					PropertyHasChanged("SoKhamChuaBenh");
				}
			}
		}

		public DateTime NgayLapSo
		{
			get
			{
				CanReadProperty("NgayLapSo", true);
				return _ngayLapSo.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayLapSo.Equals(value))
                {
                    _ngayLapSo = new SmartDate(value);
                    PropertyHasChanged("NgayLapSo");
                }
            }
		}		

		public string NoiDungKham
		{
			get
			{
				CanReadProperty("NoiDungKham", true);
				return _noiDungKham;
			}
			set
			{
				CanWriteProperty("NoiDungKham", true);
				if (value == null) value = string.Empty;
				if (!_noiDungKham.Equals(value))
				{
					_noiDungKham = value;
					PropertyHasChanged("NoiDungKham");
				}
			}
		}

		public double ChieuCao
		{
			get
			{
				CanReadProperty("ChieuCao", true);
				return _chieuCao;
			}
			set
			{
				CanWriteProperty("ChieuCao", true);
				if (!_chieuCao.Equals(value))
				{
					_chieuCao = value;
					PropertyHasChanged("ChieuCao");
				}
			}
		}

		public double CanNang
		{
			get
			{
				CanReadProperty("CanNang", true);
				return _canNang;
			}
			set
			{
				CanWriteProperty("CanNang", true);
				if (!_canNang.Equals(value))
				{
					_canNang = value;
					PropertyHasChanged("CanNang");
				}
			}
		}

		public short LoaiSucKhoe
		{
			get
			{
				CanReadProperty("LoaiSucKhoe", true);
				return _loaiSucKhoe;
			}
			set
			{
				CanWriteProperty("LoaiSucKhoe", true);
				if (!_loaiSucKhoe.Equals(value))
				{
					_loaiSucKhoe = value;
					PropertyHasChanged("LoaiSucKhoe");
				}
			}
		}

		public string NoiKham
		{
			get
			{
				CanReadProperty("NoiKham", true);
				return _noiKham;
			}
			set
			{
				CanWriteProperty("NoiKham", true);
				if (value == null) value = string.Empty;
				if (!_noiKham.Equals(value))
				{
					_noiKham = value;
					PropertyHasChanged("NoiKham");
				}
			}
		}

		public string KetLuan
		{
			get
			{
				CanReadProperty("KetLuan", true);
				return _ketLuan;
			}
			set
			{
				CanWriteProperty("KetLuan", true);
				if (value == null) value = string.Empty;
				if (!_ketLuan.Equals(value))
				{
					_ketLuan = value;
					PropertyHasChanged("KetLuan");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty("TenNguoiLap", true);
               // _tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_maNguoiLap).TenDangNhap;
                return _tenNguoiLap;
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
                    PropertyHasChanged("NgayLap");
                }
            }
		}
		
		protected override object GetIdValue()
		{
			return _maKhamChuaBenh;
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
			// SoKhamChuaBenh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoKhamChuaBenh", 50));
			//
			// NoiDungKham
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDungKham", 500));
			//
			// NoiKham
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiKham", 500));
			//
			// KetLuan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("KetLuan", 500));
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
			//TODO: Define authorization rules in KhamChuaBenh
			//AuthorizationRules.AllowRead("MaKhamChuaBenh", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("SoKhamChuaBenh", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapSo", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapSoString", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NoiDungKham", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("ChieuCao", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("CanNang", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("LoaiSucKhoe", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NoiKham", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("KetLuan", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "KhamChuaBenhReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "KhamChuaBenhReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("SoKhamChuaBenh", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapSoString", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("NoiDungKham", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("ChieuCao", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("CanNang", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiSucKhoe", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("NoiKham", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("KetLuan", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "KhamChuaBenhWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "KhamChuaBenhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhamChuaBenh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhamChuaBenh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhamChuaBenh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhamChuaBenh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhamChuaBenhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhamChuaBenh()
		{ /* require use of factory method */ }

		public static KhamChuaBenh NewKhamChuaBenh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhamChuaBenh");
			return DataPortal.Create<KhamChuaBenh>();
		}

        public static KhamChuaBenh NewKhamChuaBenh(long maNhanVien)
        {
            KhamChuaBenh _KhamChuaBenh = new KhamChuaBenh();
            _KhamChuaBenh.MaNhanVien = maNhanVien;
            return _KhamChuaBenh;
        }

		public static KhamChuaBenh GetKhamChuaBenh(int maKhamChuaBenh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhamChuaBenh");
			return DataPortal.Fetch<KhamChuaBenh>(new Criteria(maKhamChuaBenh));
		}

		public static void DeleteKhamChuaBenh(int maKhamChuaBenh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhamChuaBenh");
			DataPortal.Delete(new Criteria(maKhamChuaBenh));
		}

		public override KhamChuaBenh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhamChuaBenh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhamChuaBenh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KhamChuaBenh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KhamChuaBenh NewKhamChuaBenhChild()
		{
			KhamChuaBenh child = new KhamChuaBenh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KhamChuaBenh GetKhamChuaBenh(SafeDataReader dr)
		{
			KhamChuaBenh child =  new KhamChuaBenh();
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
			public int MaKhamChuaBenh;

			public Criteria(int maKhamChuaBenh)
			{
				this.MaKhamChuaBenh = maKhamChuaBenh;
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
                cm.CommandText = "spd_SelecttblnsThongTinKhamChuaBenh";

				cm.Parameters.AddWithValue("@MaKhamChuaBenh", criteria.MaKhamChuaBenh);

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
			DataPortal_Delete(new Criteria(_maKhamChuaBenh));
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
                cm.CommandText = "spd_DeletetblnsThongTinKhamChuaBenh";

				cm.Parameters.AddWithValue("@MaKhamChuaBenh", criteria.MaKhamChuaBenh);

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
			_maKhamChuaBenh = dr.GetInt32("MaKhamChuaBenh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_soKhamChuaBenh = dr.GetString("SoKhamChuaBenh");
			_ngayLapSo = dr.GetSmartDate("NgayLapSo", _ngayLapSo.EmptyIsMin);
			_noiDungKham = dr.GetString("NoiDungKham");
			_chieuCao = dr.GetDouble("ChieuCao");
			_canNang = dr.GetDouble("CanNang");
			_loaiSucKhoe = dr.GetInt16("LoaiSucKhoe");
			_noiKham = dr.GetString("NoiKham");
			_ketLuan = dr.GetString("KetLuan");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
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
                cm.CommandText = "spd_InserttblnsThongTinKhamChuaBenh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKhamChuaBenh = (int)cm.Parameters["@MaKhamChuaBenh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_soKhamChuaBenh.Length > 0)
				cm.Parameters.AddWithValue("@SoKhamChuaBenh", _soKhamChuaBenh);
			else
				cm.Parameters.AddWithValue("@SoKhamChuaBenh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapSo", _ngayLapSo.DBValue);
			if (_noiDungKham.Length > 0)
				cm.Parameters.AddWithValue("@NoiDungKham", _noiDungKham);
			else
				cm.Parameters.AddWithValue("@NoiDungKham", DBNull.Value);
			if (_chieuCao != 0)
				cm.Parameters.AddWithValue("@ChieuCao", _chieuCao);
			else
				cm.Parameters.AddWithValue("@ChieuCao", DBNull.Value);
			if (_canNang != 0)
				cm.Parameters.AddWithValue("@CanNang", _canNang);
			else
				cm.Parameters.AddWithValue("@CanNang", DBNull.Value);
			cm.Parameters.AddWithValue("@LoaiSucKhoe", _loaiSucKhoe);
			if (_noiKham.Length > 0)
				cm.Parameters.AddWithValue("@NoiKham", _noiKham);
			else
				cm.Parameters.AddWithValue("@NoiKham", DBNull.Value);
			if (_ketLuan.Length > 0)
				cm.Parameters.AddWithValue("@KetLuan", _ketLuan);
			else
				cm.Parameters.AddWithValue("@KetLuan", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			cm.Parameters.AddWithValue("@MaKhamChuaBenh", _maKhamChuaBenh);
			cm.Parameters["@MaKhamChuaBenh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsThongTinKhamChuaBenh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKhamChuaBenh", _maKhamChuaBenh);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_soKhamChuaBenh.Length > 0)
				cm.Parameters.AddWithValue("@SoKhamChuaBenh", _soKhamChuaBenh);
			else
				cm.Parameters.AddWithValue("@SoKhamChuaBenh", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLapSo", _ngayLapSo.DBValue);
			if (_noiDungKham.Length > 0)
				cm.Parameters.AddWithValue("@NoiDungKham", _noiDungKham);
			else
				cm.Parameters.AddWithValue("@NoiDungKham", DBNull.Value);
			if (_chieuCao != 0)
				cm.Parameters.AddWithValue("@ChieuCao", _chieuCao);
			else
				cm.Parameters.AddWithValue("@ChieuCao", DBNull.Value);
			if (_canNang != 0)
				cm.Parameters.AddWithValue("@CanNang", _canNang);
			else
				cm.Parameters.AddWithValue("@CanNang", DBNull.Value);
			cm.Parameters.AddWithValue("@LoaiSucKhoe", _loaiSucKhoe);
			if (_noiKham.Length > 0)
				cm.Parameters.AddWithValue("@NoiKham", _noiKham);
			else
				cm.Parameters.AddWithValue("@NoiKham", DBNull.Value);
			if (_ketLuan.Length > 0)
				cm.Parameters.AddWithValue("@KetLuan", _ketLuan);
			else
				cm.Parameters.AddWithValue("@KetLuan", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(tr, new Criteria(_maKhamChuaBenh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

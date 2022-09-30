
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CT_QuyetDinhBoNhiem : Csla.BusinessBase<CT_QuyetDinhBoNhiem>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTiet = 0;
		private int _maQuyetDinh = 0;
		private long _maNhanVien = 0;
        private string _MaQlNhanVien = string.Empty;
        private string _Tennhanvien = string.Empty;
		private int _maDonViCu = 0;        
		private int _maPhongBanCu = 0;
        private string _TenBophanCu = string.Empty;
		private int _maChucDanhCu = 0;
        private string _TenChucdanhcu = string.Empty;
		private int _maChucVuCu = 0;
        private string _TenChucvucu = string.Empty;
		private int _maChuyenMonNghiepVuCu = 0;
        private string _Tenchuyenmonnghiepvucu = string.Empty;
		private int _maDonViMoi = 0;
		private int _maPhongBanMoi = 0;        
		private int _maChucDanhMoi = 0;        
		private int _maChucVuMoi = 0;        
		private int _maChuyenMonNghiepVuMoi = 0;
        

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTiet
		{
			get
			{
				CanReadProperty("MaChiTiet", true);
				return _maChiTiet;
			}
		}

		public int MaQuyetDinh
		{
			get
			{
				CanReadProperty("MaQuyetDinh", true);
				return _maQuyetDinh;
			}
			set
			{
				CanWriteProperty("MaQuyetDinh", true);
				if (!_maQuyetDinh.Equals(value))
				{
					_maQuyetDinh = value;
					PropertyHasChanged("MaQuyetDinh");
				}
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

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _MaQlNhanVien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaQlNhanVien.Equals(value))
                {
                    _MaQlNhanVien=value;
                    PropertyHasChanged();
                }
            }
        }
        

        public string TenNhanVien
        {
            get
            {
                CanReadProperty(true);
                return _Tennhanvien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Tennhanvien.Equals(value))
                {
                    _Tennhanvien = value;
                    PropertyHasChanged();
                }
            }
        }

		public int MaDonViCu
		{
			get
			{
				CanReadProperty("MaDonViCu", true);
				return _maDonViCu;
			}
			set
			{
				CanWriteProperty("MaDonViCu", true);
				if (!_maDonViCu.Equals(value))
				{
					_maDonViCu = value;
					PropertyHasChanged("MaDonViCu");
				}
			}
		}

		public int MaPhongBanCu
		{
			get
			{
				CanReadProperty("MaPhongBanCu", true);
				return _maPhongBanCu;
			}
			set
			{
				CanWriteProperty("MaPhongBanCu", true);
				if (!_maPhongBanCu.Equals(value))
				{
					_maPhongBanCu = value;
					PropertyHasChanged("MaPhongBanCu");
				}
			}
		}

        public string TenBoPhanCu
        {
            get
            {
                CanReadProperty(true);
                return _TenBophanCu;
            }
            set
            {
                CanWriteProperty(true);
                if(!_TenBophanCu.Equals(value))
                {
                    _TenBophanCu = value;
                    PropertyHasChanged();
                }
            }
        }

		public int MaChucDanhCu
		{
			get
			{
				CanReadProperty("MaChucDanhCu", true);
				return _maChucDanhCu;
			}
			set
			{
				CanWriteProperty("MaChucDanhCu", true);
				if (!_maChucDanhCu.Equals(value))
				{
					_maChucDanhCu = value;
					PropertyHasChanged("MaChucDanhCu");
				}
			}
		}

        public string TenChucDanhCu
        {
            get
            {
                CanReadProperty(true);
                return _TenChucdanhcu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenChucdanhcu.Equals(value))
                {
                    _TenChucdanhcu = value;
                    PropertyHasChanged();
                }
            }
        }

		public int MaChucVuCu
		{
			get
			{
				CanReadProperty("MaChucVuCu", true);
				return _maChucVuCu;
			}
			set
			{
				CanWriteProperty("MaChucVuCu", true);
				if (!_maChucVuCu.Equals(value))
				{
					_maChucVuCu = value;
					PropertyHasChanged("MaChucVuCu");
				}
			}
		}

        public string TenChucVuCu
        {
            get
            {
                CanReadProperty(true);
                return _TenChucvucu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenChucvucu.Equals(value))
                {
                    _TenChucvucu = value;
                    PropertyHasChanged();
                }
            }
        }

		public int MaChuyenMonNghiepVuCu
		{
			get
			{
				CanReadProperty("MaChuyenMonNghiepVuCu", true);
				return _maChuyenMonNghiepVuCu;
			}
			set
			{
				CanWriteProperty("MaChuyenMonNghiepVuCu", true);
				if (!_maChuyenMonNghiepVuCu.Equals(value))
				{
					_maChuyenMonNghiepVuCu = value;
					PropertyHasChanged("MaChuyenMonNghiepVuCu");
				}
			}
		}

        public string TenChuyenMonNghiepVuCu
        {
            get
            {
                CanReadProperty(true);
                return _Tenchuyenmonnghiepvucu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Tenchuyenmonnghiepvucu.Equals(value))
                {
                    _Tenchuyenmonnghiepvucu = value;
                    PropertyHasChanged();
                }
            }
        }

		public int MaDonViMoi
		{
			get
			{
				CanReadProperty("MaDonViMoi", true);
				return _maDonViMoi;
			}
			set
			{
				CanWriteProperty("MaDonViMoi", true);
				if (!_maDonViMoi.Equals(value))
				{
					_maDonViMoi = value;
					PropertyHasChanged("MaDonViMoi");
				}
			}
		}

		public int MaPhongBanMoi
		{
			get
			{
				CanReadProperty("MaPhongBanMoi", true);
				return _maPhongBanMoi;
			}
			set
			{
				CanWriteProperty("MaPhongBanMoi", true);
				if (!_maPhongBanMoi.Equals(value))
				{
					_maPhongBanMoi = value;
					PropertyHasChanged("MaPhongBanMoi");
				}
			}
		}        

		public int MaChucDanhMoi
		{
			get
			{
				CanReadProperty("MaChucDanhMoi", true);
				return _maChucDanhMoi;
			}
			set
			{
				CanWriteProperty("MaChucDanhMoi", true);
				if (!_maChucDanhMoi.Equals(value))
				{
					_maChucDanhMoi = value;
					PropertyHasChanged("MaChucDanhMoi");
				}
			}
		}        

		public int MaChucVuMoi
		{
			get
			{
				CanReadProperty("MaChucVuMoi", true);
				return _maChucVuMoi;
			}
			set
			{
				CanWriteProperty("MaChucVuMoi", true);
				if (!_maChucVuMoi.Equals(value))
				{
					_maChucVuMoi = value;
					PropertyHasChanged("MaChucVuMoi");
				}
			}
		}       

		public int MaChuyenMonNghiepVuMoi
		{
			get
			{
				CanReadProperty("MaChuyenMonNghiepVuMoi", true);
				return _maChuyenMonNghiepVuMoi;
			}
			set
			{
				CanWriteProperty("MaChuyenMonNghiepVuMoi", true);
				if (!_maChuyenMonNghiepVuMoi.Equals(value))
				{
					_maChuyenMonNghiepVuMoi = value;
					PropertyHasChanged("MaChuyenMonNghiepVuMoi");
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
			//TODO: Define authorization rules in CT_QuyetDinhBoNhiem
			//AuthorizationRules.AllowRead("MaChiTiet", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaQuyetDinh", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaDonViCu", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBanCu", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanhCu", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuCu", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNghiepVuCu", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaDonViMoi", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaPhongBanMoi", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucDanhMoi", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChucVuMoi", "CT_QuyetDinhBoNhiemReadGroup");
			//AuthorizationRules.AllowRead("MaChuyenMonNghiepVuMoi", "CT_QuyetDinhBoNhiemReadGroup");

			//AuthorizationRules.AllowWrite("MaQuyetDinh", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViCu", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBanCu", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanhCu", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuCu", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNghiepVuCu", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViMoi", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongBanMoi", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucDanhMoi", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVuMoi", "CT_QuyetDinhBoNhiemWriteGroup");
			//AuthorizationRules.AllowWrite("MaChuyenMonNghiepVuMoi", "CT_QuyetDinhBoNhiemWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CT_QuyetDinhBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CT_QuyetDinhBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CT_QuyetDinhBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CT_QuyetDinhBoNhiem
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CT_QuyetDinhBoNhiemDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CT_QuyetDinhBoNhiem()
		{ /* require use of factory method */ }

		public static CT_QuyetDinhBoNhiem NewCT_QuyetDinhBoNhiem()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_QuyetDinhBoNhiem");
			return DataPortal.Create<CT_QuyetDinhBoNhiem>();
		}

		public static CT_QuyetDinhBoNhiem GetCT_QuyetDinhBoNhiem(long maChiTiet)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CT_QuyetDinhBoNhiem");
			return DataPortal.Fetch<CT_QuyetDinhBoNhiem>(new Criteria(maChiTiet));
		}

		public static void DeleteCT_QuyetDinhBoNhiem(long maChiTiet)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CT_QuyetDinhBoNhiem");
			DataPortal.Delete(new Criteria(maChiTiet));
		}

		public override CT_QuyetDinhBoNhiem Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CT_QuyetDinhBoNhiem");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CT_QuyetDinhBoNhiem");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CT_QuyetDinhBoNhiem");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CT_QuyetDinhBoNhiem NewCT_QuyetDinhBoNhiemChild()
		{
			CT_QuyetDinhBoNhiem child = new CT_QuyetDinhBoNhiem();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CT_QuyetDinhBoNhiem GetCT_QuyetDinhBoNhiem(SafeDataReader dr)
		{
			CT_QuyetDinhBoNhiem child =  new CT_QuyetDinhBoNhiem();
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
			public long MaChiTiet;

			public Criteria(long maChiTiet)
			{
				this.MaChiTiet = maChiTiet;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
            MarkAsChild();
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
				cm.CommandText = "spd_SelecttblnsQuyetDinhBoNhiemCT";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			DataPortal_Delete(new Criteria(_maChiTiet));
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
				cm.CommandText = "spd_DeletetblnsQuyetDinhBoNhiem_CT";

				cm.Parameters.AddWithValue("@MaChiTiet", criteria.MaChiTiet);

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
			_maChiTiet = dr.GetInt64("MaChiTiet");
			_maQuyetDinh = dr.GetInt32("MaQuyetDinh");
			_maNhanVien = dr.GetInt64("MaNhanVien");
            _MaQlNhanVien = dr.GetString("MaQLNhanVien");
            _Tennhanvien = dr.GetString("TenNhanVien");
			_maDonViCu = dr.GetInt32("MaDonViCu");
			_maPhongBanCu = dr.GetInt32("MaPhongBanCu");
            _TenBophanCu = dr.GetString("TenBophanCu");
			_maChucDanhCu = dr.GetInt32("MaChucDanhCu");
            _TenChucdanhcu = dr.GetString("TenChucDanhCu");
			_maChucVuCu = dr.GetInt32("MaChucVuCu");
            _TenChucvucu = dr.GetString("TenChucVuCu");
			_maChuyenMonNghiepVuCu = dr.GetInt32("MaChuyenMonNghiepVuCu");
            _Tenchuyenmonnghiepvucu = dr.GetString("TenChuyenMonNghiepVuCu");
			_maDonViMoi = dr.GetInt32("MaDonViMoi");
			_maPhongBanMoi = dr.GetInt32("MaPhongBanMoi");
			_maChucDanhMoi = dr.GetInt32("MaChucDanhMoi");
			_maChucVuMoi = dr.GetInt32("MaChucVuMoi");
			_maChuyenMonNghiepVuMoi = dr.GetInt32("MaChuyenMonNghiepVuMoi");

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
        internal void Insert(SqlTransaction tr, QuyetDinhBoNhiem parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, QuyetDinhBoNhiem parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_InserttblnsQuyetDinhBoNhiem_CT";

				AddInsertParameters(cm,parent);

				cm.ExecuteNonQuery();

				_maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
			}//using
		}
        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsQuyetDinhBoNhiem_CT";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, QuyetDinhBoNhiem parent)
		{
			cm.Parameters.AddWithValue("@MaQuyetDinh", parent.MaQuyetDinh);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maDonViCu != 0)
				cm.Parameters.AddWithValue("@MaDonViCu", _maDonViCu);
			else
				cm.Parameters.AddWithValue("@MaDonViCu", DBNull.Value);
			if (_maPhongBanCu != 0)
				cm.Parameters.AddWithValue("@MaPhongBanCu", _maPhongBanCu);
			else
				cm.Parameters.AddWithValue("@MaPhongBanCu", DBNull.Value);
			if (_maChucDanhCu != 0)
				cm.Parameters.AddWithValue("@MaChucDanhCu", _maChucDanhCu);
			else
				cm.Parameters.AddWithValue("@MaChucDanhCu", DBNull.Value);
			if (_maChucVuCu != 0)
				cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
			else
				cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
			if (_maChuyenMonNghiepVuCu != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", _maChuyenMonNghiepVuCu);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", DBNull.Value);
			if (_maDonViMoi != 0)
				cm.Parameters.AddWithValue("@MaDonViMoi", _maDonViMoi);
			else
				cm.Parameters.AddWithValue("@MaDonViMoi", DBNull.Value);
			if (_maPhongBanMoi != 0)
				cm.Parameters.AddWithValue("@MaPhongBanMoi", _maPhongBanMoi);
			else
				cm.Parameters.AddWithValue("@MaPhongBanMoi", DBNull.Value);
			if (_maChucDanhMoi != 0)
				cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
			else
				cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
			if (_maChucVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
			if (_maChuyenMonNghiepVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", _maChuyenMonNghiepVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
			cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
		}
        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maDonViCu != 0)
                cm.Parameters.AddWithValue("@MaDonViCu", _maDonViCu);
            else
                cm.Parameters.AddWithValue("@MaDonViCu", DBNull.Value);
            if (_maPhongBanCu != 0)
                cm.Parameters.AddWithValue("@MaPhongBanCu", _maPhongBanCu);
            else
                cm.Parameters.AddWithValue("@MaPhongBanCu", DBNull.Value);
            if (_maChucDanhCu != 0)
                cm.Parameters.AddWithValue("@MaChucDanhCu", _maChucDanhCu);
            else
                cm.Parameters.AddWithValue("@MaChucDanhCu", DBNull.Value);
            if (_maChucVuCu != 0)
                cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
            else
                cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
            if (_maChuyenMonNghiepVuCu != 0)
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", _maChuyenMonNghiepVuCu);
            else
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", DBNull.Value);
            if (_maDonViMoi != 0)
                cm.Parameters.AddWithValue("@MaDonViMoi", _maDonViMoi);
            else
                cm.Parameters.AddWithValue("@MaDonViMoi", DBNull.Value);
            if (_maPhongBanMoi != 0)
                cm.Parameters.AddWithValue("@MaPhongBanMoi", _maPhongBanMoi);
            else
                cm.Parameters.AddWithValue("@MaPhongBanMoi", DBNull.Value);
            if (_maChucDanhMoi != 0)
                cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
            else
                cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
            if (_maChucVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
            if (_maChuyenMonNghiepVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", _maChuyenMonNghiepVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, QuyetDinhBoNhiem parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr,parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}
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

        private void ExecuteUpdate(SqlTransaction tr, QuyetDinhBoNhiem parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblnsQuyetDinhBoNhiem_CT";

				AddUpdateParameters(cm,parent);

				cm.ExecuteNonQuery();

			}//using
		}
        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsQuyetDinhBoNhiem_CT";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }
        private void AddUpdateParameters(SqlCommand cm, QuyetDinhBoNhiem parent)
		{
			cm.Parameters.AddWithValue("@MaChiTiet",_maChiTiet);
			cm.Parameters.AddWithValue("@MaQuyetDinh",parent.MaQuyetDinh);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maDonViCu != 0)
				cm.Parameters.AddWithValue("@MaDonViCu", _maDonViCu);
			else
				cm.Parameters.AddWithValue("@MaDonViCu", DBNull.Value);
			if (_maPhongBanCu != 0)
				cm.Parameters.AddWithValue("@MaPhongBanCu", _maPhongBanCu);
			else
				cm.Parameters.AddWithValue("@MaPhongBanCu", DBNull.Value);
			if (_maChucDanhCu != 0)
				cm.Parameters.AddWithValue("@MaChucDanhCu", _maChucDanhCu);
			else
				cm.Parameters.AddWithValue("@MaChucDanhCu", DBNull.Value);
			if (_maChucVuCu != 0)
				cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
			else
				cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
			if (_maChuyenMonNghiepVuCu != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", _maChuyenMonNghiepVuCu);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", DBNull.Value);
			if (_maDonViMoi != 0)
				cm.Parameters.AddWithValue("@MaDonViMoi", _maDonViMoi);
			else
				cm.Parameters.AddWithValue("@MaDonViMoi", DBNull.Value);
			if (_maPhongBanMoi != 0)
				cm.Parameters.AddWithValue("@MaPhongBanMoi", _maPhongBanMoi);
			else
				cm.Parameters.AddWithValue("@MaPhongBanMoi", DBNull.Value);
			if (_maChucDanhMoi != 0)
				cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
			else
				cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
			if (_maChucVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
			if (_maChuyenMonNghiepVuMoi != 0)
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", _maChuyenMonNghiepVuMoi);
			else
				cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", DBNull.Value);
		}

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_maDonViCu != 0)
                cm.Parameters.AddWithValue("@MaDonViCu", _maDonViCu);
            else
                cm.Parameters.AddWithValue("@MaDonViCu", DBNull.Value);
            if (_maPhongBanCu != 0)
                cm.Parameters.AddWithValue("@MaPhongBanCu", _maPhongBanCu);
            else
                cm.Parameters.AddWithValue("@MaPhongBanCu", DBNull.Value);
            if (_maChucDanhCu != 0)
                cm.Parameters.AddWithValue("@MaChucDanhCu", _maChucDanhCu);
            else
                cm.Parameters.AddWithValue("@MaChucDanhCu", DBNull.Value);
            if (_maChucVuCu != 0)
                cm.Parameters.AddWithValue("@MaChucVuCu", _maChucVuCu);
            else
                cm.Parameters.AddWithValue("@MaChucVuCu", DBNull.Value);
            if (_maChuyenMonNghiepVuCu != 0)
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", _maChuyenMonNghiepVuCu);
            else
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuCu", DBNull.Value);
            if (_maDonViMoi != 0)
                cm.Parameters.AddWithValue("@MaDonViMoi", _maDonViMoi);
            else
                cm.Parameters.AddWithValue("@MaDonViMoi", DBNull.Value);
            if (_maPhongBanMoi != 0)
                cm.Parameters.AddWithValue("@MaPhongBanMoi", _maPhongBanMoi);
            else
                cm.Parameters.AddWithValue("@MaPhongBanMoi", DBNull.Value);
            if (_maChucDanhMoi != 0)
                cm.Parameters.AddWithValue("@MaChucDanhMoi", _maChucDanhMoi);
            else
                cm.Parameters.AddWithValue("@MaChucDanhMoi", DBNull.Value);
            if (_maChucVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChucVuMoi", _maChucVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChucVuMoi", DBNull.Value);
            if (_maChuyenMonNghiepVuMoi != 0)
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", _maChuyenMonNghiepVuMoi);
            else
                cm.Parameters.AddWithValue("@MaChuyenMonNghiepVuMoi", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChiTiet));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiPhiThucHien : Csla.BusinessBase<ChiPhiThucHien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiPhiThucHien = 0;
		private long _mactChiphisanxuat = 0;
		private long _maChungTu = 0;
		private string _tenChungTu = string.Empty;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private long _maDoiTuong = 0;
		private string _tenDoiTuong = string.Empty;
		private string _diaChi = string.Empty;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = 0;
        private int _maLoaiChiPhiSanXuat = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiPhiThucHien
		{
			get
			{
				return _maChiPhiThucHien;
			}
		}

		public long MactChiphisanxuat
		{
			get
			{
				return _mactChiphisanxuat;
			}
			set
			{
				if (!_mactChiphisanxuat.Equals(value))
				{
					_mactChiphisanxuat = value;
					PropertyHasChanged("MactChiphisanxuat");
				}
			}
		}
        public int MaLoaiChiPhiSanXuat
        {
            get
            {
                return _maLoaiChiPhiSanXuat;
            }
            set
            {
                if (!_maLoaiChiPhiSanXuat.Equals(value))
                {
                    _maLoaiChiPhiSanXuat = value;
                    PropertyHasChanged("MaLoaiChiPhiSanXuat");
                }
            }
        }
		public long MaChungTu
		{
			get
			{
				return _maChungTu;
			}
			set
			{
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
				}
			}
		}

		public string TenChungTu
		{
			get
			{
				return _tenChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChungTu.Equals(value))
				{
					_tenChungTu = value;
					PropertyHasChanged("TenChungTu");
				}
			}
		}

		public int MaChuongTrinh
		{
			get
			{
				return _maChuongTrinh;
			}
			set
			{
				if (!_maChuongTrinh.Equals(value))
				{
					_maChuongTrinh = value;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

		public string TenChuongTrinh
		{
			get
			{
				return _tenChuongTrinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenChuongTrinh.Equals(value))
				{
					_tenChuongTrinh = value;
					PropertyHasChanged("TenChuongTrinh");
				}
			}
		}

		public long MaDoiTuong
		{
			get
			{
				return _maDoiTuong;
			}
			set
			{
				if (!_maDoiTuong.Equals(value))
				{
					_maDoiTuong = value;
					PropertyHasChanged("MaDoiTuong");
				}
			}
		}

		public string TenDoiTuong
		{
			get
			{
				return _tenDoiTuong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenDoiTuong.Equals(value))
				{
					_tenDoiTuong = value;
					PropertyHasChanged("TenDoiTuong");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				return _diaChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				return _dienGiai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
				}
			}
		}

		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChiPhiThucHien;
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

		#region Factory Methods
		private ChiPhiThucHien()
		{ /* require use of factory method */ }

		public static ChiPhiThucHien NewChiPhiThucHien()
		{
            ChiPhiThucHien item = new ChiPhiThucHien();
            item.MarkAsChild();
            return item;
		}

		public static ChiPhiThucHien GetChiPhiThucHien(long maChiPhiThucHien)
		{
			return DataPortal.Fetch<ChiPhiThucHien>(new Criteria(maChiPhiThucHien));
		}

		public static void DeleteChiPhiThucHien(long maChiPhiThucHien)
		{
			DataPortal.Delete(new Criteria(maChiPhiThucHien));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChiPhiThucHien NewChiPhiThucHienChild()
		{
			ChiPhiThucHien child = new ChiPhiThucHien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChiPhiThucHien GetChiPhiThucHien(SafeDataReader dr)
		{
			ChiPhiThucHien child =  new ChiPhiThucHien();
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
			public long MaChiPhiThucHien;

			public Criteria(long maChiPhiThucHien)
			{
				this.MaChiPhiThucHien = maChiPhiThucHien;
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
				cm.CommandText = "SelecttblChiPhiThucHien";

				cm.Parameters.AddWithValue("@MaChiPhiThucHien", criteria.MaChiPhiThucHien);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
 
		#endregion //Data Access - Insert

		#region Data Access - Update
   

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maChiPhiThucHien));
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
				cm.CommandText = "DeletetblChiPhiThucHien";

				cm.Parameters.AddWithValue("@MaChiPhiThucHien", criteria.MaChiPhiThucHien);

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
			_maChiPhiThucHien = dr.GetInt64("MaChiPhiThucHien");
			_mactChiphisanxuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
			_maChungTu = dr.GetInt64("MaChungTu");
			_tenChungTu = dr.GetString("TenChungTu");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_tenDoiTuong = dr.GetString("TenDoiTuong");
			_diaChi = dr.GetString("DiaChi");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
            _maLoaiChiPhiSanXuat = dr.GetInt32("MaLoaiChiPhiSanXuat");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr,long maChungTu,string soChungTu,long maCT_ChiPhiSanXuat,int maChuongTrinh,string tenChuongTrinh)
		{
            _maChungTu = maChungTu;
            _tenChungTu = soChungTu;
            _mactChiphisanxuat = maCT_ChiPhiSanXuat;
            _maChuongTrinh = maChuongTrinh;
            _tenChuongTrinh = tenChuongTrinh;
			if (!IsDirty) return;
			ExecuteInsert(tr,  maChungTu, soChungTu);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, long maChungTu, string soChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChiPhiThucHien";
				AddInsertParameters(cm,  maChungTu, soChungTu);
				cm.ExecuteNonQuery();
				_maChiPhiThucHien = (long)cm.Parameters["@MaChiPhiThucHien"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, long maChungTu, string soChungTu)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_mactChiphisanxuat != 0)
				cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
			else
				cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
			if (maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@TenChungTu", soChungTu);
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
                if (_maLoaiChiPhiSanXuat != 0)
                    cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", _maLoaiChiPhiSanXuat);
                else
                    cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChiPhiThucHien", _maChiPhiThucHien);
			cm.Parameters["@MaChiPhiThucHien"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, long maChungTu, string soChungTu,long maCT_ChiPhiSanXuat,int maChuongTrinh,string tenChuongTrinh)
		{

            _maChungTu = maChungTu;
            _tenChungTu = soChungTu;
            _mactChiphisanxuat = maCT_ChiPhiSanXuat;
            _maChuongTrinh = maChuongTrinh;
            _tenChuongTrinh = tenChuongTrinh;
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr,  maChungTu, soChungTu);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr, long maChungTu, string soChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChiPhiThucHien";

				AddUpdateParameters(cm,  maChungTu, soChungTu);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, long maChungTu, string soChungTu)
		{
			cm.Parameters.AddWithValue("@MaChiPhiThucHien", _maChiPhiThucHien);
			if (_mactChiphisanxuat != 0)
				cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _mactChiphisanxuat);
			else
				cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
			if (maChungTu != 0)
				cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@TenChungTu", soChungTu );
			else
				cm.Parameters.AddWithValue("@TenChungTu", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maLoaiChiPhiSanXuat != 0)
                cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", _maLoaiChiPhiSanXuat);
            else
                cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChiPhiThucHien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

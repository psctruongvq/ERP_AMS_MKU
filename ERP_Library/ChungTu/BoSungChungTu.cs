using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using ERP_Library;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoSungChungTu : Csla.BusinessBase<BoSungChungTu>
	{
		#region Business Properties and Methods

        //declare members
        private long _maChungTu = 0;
        private int _maTaiKhoanNH = 0;
        private int _maTaiKhoanNHGiaoDich = 0;
        private int _maTaiKhoanNHDoiTac = 0;
        private SmartDate _ngayXacNhanUNC = new SmartDate(DateTime.MinValue);
        private byte _mucDichMuaNgoaiTe = 0;
        private string _nDMucDichMuaNgoaiTe = string.Empty;
        private byte _phuongThucMuaNgoaiTe = 0;
        private byte _loaiChuyenTienNN = 0;
        private byte _loaiPhiChuyenTienNN = 1;
        private string _tenNganHang = string.Empty;
        private string _tenNganHangDoiTac = string.Empty;
        private int _maNganHangTrungGian = 0;
        private string _soTaiKhoanNHDoiTac = string.Empty;
        [System.ComponentModel.DataObjectField(true, false)]
        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
        }

        public int MaTaiKhoanNH
        {
            get
            {
                CanReadProperty("MaTaiKhoanNH", true);
                if(_maTaiKhoanNH != 0)
                    TenNganHang = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.GetTaiKhoanNganHangCongTyChild(_maTaiKhoanNH).TenNganHang;
                return _maTaiKhoanNH;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanNH", true);
                if (!_maTaiKhoanNH.Equals(value))
                {
                    _maTaiKhoanNH = value; 
                    TenNganHang = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild.GetTaiKhoanNganHangCongTyChild(_maTaiKhoanNH).TenNganHang;
                    PropertyHasChanged("MaTaiKhoanNH");
                }
            }
        }

        public int MaTaiKhoanNHGiaoDich
        {
            get
            {
                CanReadProperty("MaTaiKhoanNHGiaoDich", true);
                return _maTaiKhoanNHGiaoDich;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanNHGiaoDich", true);
                if (!_maTaiKhoanNHGiaoDich.Equals(value))
                {
                    _maTaiKhoanNHGiaoDich = value;
                    PropertyHasChanged("MaTaiKhoanNHGiaoDich");
                }
            }
        }

        public int MaTaiKhoanNHDoiTac
        {
            get
            {
                CanReadProperty("MaTaiKhoanNHDoiTac", true);
                if (_maTaiKhoanNHDoiTac != 0)
                    TenNganHangDoiTac = TK_NganHang.GetTK_NganHangByMaTKNgaHang(_maTaiKhoanNHDoiTac).TenNganHang;
                return _maTaiKhoanNHDoiTac;
            }
            set
            {
                CanWriteProperty("MaTaiKhoanNHDoiTac", true);
                if (!_maTaiKhoanNHDoiTac.Equals(value))
                {
                    _maTaiKhoanNHDoiTac = value;
                    if (MaTaiKhoanNHDoiTac != 0)
                        TenNganHangDoiTac = TK_NganHang.GetTK_NganHangByMaTKNgaHang(_maTaiKhoanNHDoiTac).TenNganHang;
                    PropertyHasChanged("MaTaiKhoanNHDoiTac");
                }
            }
        }

        public DateTime? NgayXacNhanUNC
        {
            get
            {
                CanReadProperty("NgayXacNhanUNC", true);
                if (_ngayXacNhanUNC.Date == DateTime.MinValue)
                    return null;
                return _ngayXacNhanUNC.Date;
            }
            set
            {
                CanWriteProperty("NgayXacNhanUNC", true);
                if (!_ngayXacNhanUNC.Equals(value))
                {
                    if (value == null)
                        _ngayXacNhanUNC = new SmartDate(DateTime.MinValue);
                    else
                        _ngayXacNhanUNC = new SmartDate(value.Value.Date);

                    PropertyHasChanged();
                }
            }

        }

        public byte MucDichMuaNgoaiTe
        {
            get
            {
                CanReadProperty("MucDichMuaNgoaiTe", true);
                return _mucDichMuaNgoaiTe;
            }
            set
            {
                CanWriteProperty("MucDichMuaNgoaiTe", true);
                if (!_mucDichMuaNgoaiTe.Equals(value))
                {
                    _mucDichMuaNgoaiTe = value;
                    PropertyHasChanged("MucDichMuaNgoaiTe");
                }
            }
        }

        public string NDMucDichMuaNgoaiTe
        {
            get
            {
                CanReadProperty("NDMucDichMuaNgoaiTe", true);
                return _nDMucDichMuaNgoaiTe;
            }
            set
            {
                CanWriteProperty("NDMucDichMuaNgoaiTe", true);
                if (value == null) value = string.Empty;
                if (!_nDMucDichMuaNgoaiTe.Equals(value))
                {
                    _nDMucDichMuaNgoaiTe = value;
                    PropertyHasChanged("NDMucDichMuaNgoaiTe");
                }
            }
        }

        public byte PhuongThucMuaNgoaiTe
        {
            get
            {
                CanReadProperty("PhuongThucMuaNgoaiTe", true);
                return _phuongThucMuaNgoaiTe;
            }
            set
            {
                CanWriteProperty("PhuongThucMuaNgoaiTe", true);
                if (!_phuongThucMuaNgoaiTe.Equals(value))
                {
                    _phuongThucMuaNgoaiTe = value;
                    PropertyHasChanged("PhuongThucMuaNgoaiTe");
                }
            }
        }

        public byte LoaiChuyenTienNN
        {
            get
            {
                CanReadProperty("LoaiChuyenTienNN", true);
                return _loaiChuyenTienNN;
            }
            set
            {
                CanWriteProperty("LoaiChuyenTienNN", true);
                if (!_loaiChuyenTienNN.Equals(value))
                {
                    _loaiChuyenTienNN = value;
                    PropertyHasChanged("LoaiChuyenTienNN");
                }
            }
        }

        public byte LoaiPhiChuyenTienNN
        {
            get
            {
                CanReadProperty("LoaiPhiChuyenTienNN", true);
                return _loaiPhiChuyenTienNN;
            }
            set
            {
                CanWriteProperty("LoaiPhiChuyenTienNN", true);
                if (!_loaiPhiChuyenTienNN.Equals(value))
                {
                    _loaiPhiChuyenTienNN = value;
                    PropertyHasChanged("LoaiPhiChuyenTienNN");
                }
            }
        }
        public string TenNganHang
        {
            get
            {
                CanReadProperty("TenNganHang", true);
                return _tenNganHang;
            }
            set
            {
                CanWriteProperty("TenNganHang", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHang.Equals(value))
                {
                    _tenNganHang = value;
                    PropertyHasChanged("TenNganHang");
                }
            }
        }

        public string TenNganHangDoiTac
        {
            get
            {
                CanReadProperty("TenNganHangDoiTac", true);
                return _tenNganHangDoiTac;
            }
            set
            {
                CanWriteProperty("TenNganHangDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_tenNganHangDoiTac.Equals(value))
                {
                    _tenNganHangDoiTac = value;
                    PropertyHasChanged("TenNganHangDoiTac");
                }
            }
        }

        public int MaNganHangTrungGian
        {
            get
            {
                CanReadProperty("MaNganHangTrungGian", true);
                return _maNganHangTrungGian;
            }
            set
            {
                CanWriteProperty("MaNganHangTrungGian", true);
                if (!_maNganHangTrungGian.Equals(value))
                {
                    _maNganHangTrungGian = value;
                    PropertyHasChanged("MaNganHangTrungGian");
                }
            }
        }

        public string SoTaiKhoanNHDoiTac
        {
            get
            {
                CanReadProperty("SoTaiKhoanNHDoiTac", true);
                return _soTaiKhoanNHDoiTac;
            }
            set
            {
                CanWriteProperty("SoTaiKhoanNHDoiTac", true);
                if (value == null) value = string.Empty;
                if (!_soTaiKhoanNHDoiTac.Equals(value))
                {
                    _soTaiKhoanNHDoiTac = value;
                    PropertyHasChanged("SoTaiKhoanNHDoiTac");
                }
            }
        }

		protected override object GetIdValue()
		{
			return _maChungTu;
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
			//TODO: Define authorization rules in BoSungChungTu
			//AuthorizationRules.AllowRead("MaChungTu", "BoSungChungTuReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanNH", "BoSungChungTuReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanNHGiaoDich", "BoSungChungTuReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanNHDoiTac", "BoSungChungTuReadGroup");

			//AuthorizationRules.AllowWrite("MaTaiKhoanNH", "BoSungChungTuWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanNHGiaoDich", "BoSungChungTuWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanNHDoiTac", "BoSungChungTuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoSungChungTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoSungChungTuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoSungChungTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoSungChungTuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoSungChungTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoSungChungTuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoSungChungTu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoSungChungTuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoSungChungTu()
		{ /* require use of factory method */ }

		public static BoSungChungTu NewBoSungChungTu(long maChungTu)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoSungChungTu");
			return DataPortal.Create<BoSungChungTu>(new Criteria(maChungTu));
		}

		public static BoSungChungTu GetBoSungChungTu(long maChungTu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoSungChungTu");
			return DataPortal.Fetch<BoSungChungTu>(new Criteria(maChungTu));
		}

		public static void DeleteBoSungChungTu(long maChungTu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoSungChungTu");
			DataPortal.Delete(new Criteria(maChungTu));
		}

		public override BoSungChungTu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoSungChungTu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoSungChungTu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoSungChungTu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        private BoSungChungTu(long maChungTu)
		{
			this._maChungTu = maChungTu;
		}

		internal static BoSungChungTu NewBoSungChungTuChild(long maChungTu)
		{
			BoSungChungTu child = new BoSungChungTu(maChungTu);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoSungChungTu GetBoSungChungTu(SafeDataReader dr)
		{
			BoSungChungTu child =  new BoSungChungTu();
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
			public long MaChungTu;

			public Criteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChungTu = criteria.MaChungTu;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblBoSungChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                    }
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

				ExecuteInsert(tr, null);

				//update child object(s)
				UpdateChildren(tr);
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

				if (base.IsDirty)
				{
					ExecuteUpdate(tr, null);
				}

				//update child object(s)
				UpdateChildren(tr);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maChungTu));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
            SqlTransaction tr;
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                tr = cn.BeginTransaction();
				ExecuteDelete(tr, criteria);

			}//using

		}

        public void DataPortal_Delete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblBoSungChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);

                cm.ExecuteNonQuery();
            }//using
        }

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblBoSungChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
            _maChungTu = dr.GetInt64("MaChungTu");
            _maTaiKhoanNH = dr.GetInt32("MaTaiKhoanNH");
            _maTaiKhoanNHGiaoDich = dr.GetInt32("MaTaiKhoanNHGiaoDich");
            _maTaiKhoanNHDoiTac = dr.GetInt32("MaTaiKhoanNHDoiTac");
            _ngayXacNhanUNC = dr.GetSmartDate("NgayXacNhanUNC", _ngayXacNhanUNC.EmptyIsMin);
            _mucDichMuaNgoaiTe = dr.GetByte("MucDichMuaNgoaiTe");
            _nDMucDichMuaNgoaiTe = dr.GetString("NDMucDichMuaNgoaiTe");
            _phuongThucMuaNgoaiTe = dr.GetByte("PhuongThucMuaNgoaiTe");
            _loaiChuyenTienNN = dr.GetByte("LoaiChuyenTienNN");
            _loaiPhiChuyenTienNN = dr.GetByte("LoaiPhiChuyenTienNN");
            _tenNganHang = dr.GetString("TenNganHang");
            _tenNganHangDoiTac = dr.GetString("TenNganHangDoiTac");
            _maNganHangTrungGian = dr.GetInt32("MaNganHangTrungGian");
            _soTaiKhoanNHDoiTac = dr.GetString("SoTaiKhoanNHDoiTac");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTu parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblBoSungChungTu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTu parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maChungTu = parent.MaChungTu;
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            if (_maTaiKhoanNH != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNH", _maTaiKhoanNH);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNH", DBNull.Value);
            if (_maTaiKhoanNHGiaoDich != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNHGiaoDich", _maTaiKhoanNHGiaoDich);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNHGiaoDich", DBNull.Value);
            if (_maTaiKhoanNHDoiTac != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNHDoiTac", _maTaiKhoanNHDoiTac);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNHDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayXacNhanUNC", _ngayXacNhanUNC.DBValue);
            if (_mucDichMuaNgoaiTe != 0)
                cm.Parameters.AddWithValue("@MucDichMuaNgoaiTe", _mucDichMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@MucDichMuaNgoaiTe", DBNull.Value);
            if (_nDMucDichMuaNgoaiTe.Length > 0)
                cm.Parameters.AddWithValue("@NDMucDichMuaNgoaiTe", _nDMucDichMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@NDMucDichMuaNgoaiTe", DBNull.Value);
            if (_phuongThucMuaNgoaiTe != 0)
                cm.Parameters.AddWithValue("@PhuongThucMuaNgoaiTe", _phuongThucMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@PhuongThucMuaNgoaiTe", DBNull.Value);
            if (_loaiChuyenTienNN != 0)
                cm.Parameters.AddWithValue("@LoaiChuyenTienNN", _loaiChuyenTienNN);
            else
                cm.Parameters.AddWithValue("@LoaiChuyenTienNN", DBNull.Value);
            if (_loaiPhiChuyenTienNN != 0)
                cm.Parameters.AddWithValue("@LoaiPhiChuyenTienNN", _loaiPhiChuyenTienNN);
            else
                cm.Parameters.AddWithValue("@LoaiPhiChuyenTienNN", DBNull.Value);

            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenNganHangDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHangDoiTac", _tenNganHangDoiTac);
            else
                cm.Parameters.AddWithValue("@TenNganHangDoiTac", DBNull.Value);
            if (_maNganHangTrungGian != 0)
                cm.Parameters.AddWithValue("@MaNganHangTrungGian", _maNganHangTrungGian);
            else
                cm.Parameters.AddWithValue("@MaNganHangTrungGian", DBNull.Value);
            if (_soTaiKhoanNHDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoanNHDoiTac", _soTaiKhoanNHDoiTac);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoanNHDoiTac", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTu parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
                cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblBoSungChungTu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTu parent)
		{
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            if (_maTaiKhoanNH != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNH", _maTaiKhoanNH);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNH", DBNull.Value);
            if (_maTaiKhoanNHGiaoDich != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNHGiaoDich", _maTaiKhoanNHGiaoDich);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNHGiaoDich", DBNull.Value);
            if (_maTaiKhoanNHDoiTac != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoanNHDoiTac", _maTaiKhoanNHDoiTac);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoanNHDoiTac", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayXacNhanUNC", _ngayXacNhanUNC.DBValue);
            if (_mucDichMuaNgoaiTe != 0)
                cm.Parameters.AddWithValue("@MucDichMuaNgoaiTe", _mucDichMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@MucDichMuaNgoaiTe", DBNull.Value);
            if (_nDMucDichMuaNgoaiTe.Length > 0)
                cm.Parameters.AddWithValue("@NDMucDichMuaNgoaiTe", _nDMucDichMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@NDMucDichMuaNgoaiTe", DBNull.Value);
            if (_phuongThucMuaNgoaiTe != 0)
                cm.Parameters.AddWithValue("@PhuongThucMuaNgoaiTe", _phuongThucMuaNgoaiTe);
            else
                cm.Parameters.AddWithValue("@PhuongThucMuaNgoaiTe", DBNull.Value);
            if (_loaiChuyenTienNN != 0)
                cm.Parameters.AddWithValue("@LoaiChuyenTienNN", _loaiChuyenTienNN);
            else
                cm.Parameters.AddWithValue("@LoaiChuyenTienNN", DBNull.Value);
            if (_loaiPhiChuyenTienNN != 0)
                cm.Parameters.AddWithValue("@LoaiPhiChuyenTienNN", _loaiPhiChuyenTienNN);
            else
                cm.Parameters.AddWithValue("@LoaiPhiChuyenTienNN", DBNull.Value);

            if (_tenNganHang.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHang", _tenNganHang);
            else
                cm.Parameters.AddWithValue("@TenNganHang", DBNull.Value);
            if (_tenNganHangDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@TenNganHangDoiTac", _tenNganHangDoiTac);
            else
                cm.Parameters.AddWithValue("@TenNganHangDoiTac", DBNull.Value);
            if (_maNganHangTrungGian != 0)
                cm.Parameters.AddWithValue("@MaNganHangTrungGian", _maNganHangTrungGian);
            else
                cm.Parameters.AddWithValue("@MaNganHangTrungGian", DBNull.Value);
            if (_soTaiKhoanNHDoiTac.Length > 0)
                cm.Parameters.AddWithValue("@SoTaiKhoanNHDoiTac", _soTaiKhoanNHDoiTac);
            else
                cm.Parameters.AddWithValue("@SoTaiKhoanNHDoiTac", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DSHopDongMuaBan : Csla.BusinessBase<DSHopDongMuaBan>
	{
		#region Business Properties and Methods

		//declare members
		private long _maHopDong = 0;
		private string _soHopDong = string.Empty;
		private int _maBangBaoGia = 0;
		private decimal _tongTien = 0;
        private int _maLoaiHopDong = 0;
		private int _maLoaiTien = 0;
		private double _phanTramKyQuy = 0;
		private decimal _soTienDatCoc = 0;
		private decimal _phiGiaoDich = 0;
		private double _laiSuat = 0;
		private string _vietBangChu = string.Empty;
		private bool _daThu = false;
		private bool _daChi = false;
        private string _tenLoaiTien = string.Empty;
        private bool _muaBan = false;
        private bool _hdTrongNgoaiDai = false;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);

        private ChungTu_QuyetDinhList _ChungTu_QuyetDinhList = ChungTu_QuyetDinhList.NewChungTu_QuyetDinhList();

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
			}
		}

		public string SoHopDong
		{
			get
			{
				CanReadProperty("SoHopDong", true);
				return _soHopDong;
			}
			set
			{
				CanWriteProperty("SoHopDong", true);
				if (value == null) value = string.Empty;
				if (!_soHopDong.Equals(value))
				{
					_soHopDong = value;
					PropertyHasChanged("SoHopDong");
				}
			}
		}

		public int MaBangBaoGia
		{
			get
			{
				CanReadProperty("MaBangBaoGia", true);
				return _maBangBaoGia;
			}
			set
			{
				CanWriteProperty("MaBangBaoGia", true);
				if (!_maBangBaoGia.Equals(value))
				{
					_maBangBaoGia = value;
					PropertyHasChanged("MaBangBaoGia");
				}
			}
		}

		public decimal TongTien
		{
			get
			{
				CanReadProperty("TongTien", true);
				return _tongTien;
			}
			set
			{
				CanWriteProperty("TongTien", true);
				if (!_tongTien.Equals(value))
				{
					_tongTien = value;
					PropertyHasChanged("TongTien");
				}
			}
		}

		public int MaLoaiHopDong
		{
			get
			{
                CanReadProperty("MaLoaiHopDong", true);
                return _maLoaiHopDong;
			}
			set
			{
                CanWriteProperty("MaLoaiHopDong", true);
                if (!_maLoaiHopDong.Equals(value))
				{
                    _maLoaiHopDong = value;
                    PropertyHasChanged("MaLoaiHopDong");
				}
			}
		}

		public int MaLoaiTien
		{
			get
			{
				CanReadProperty("MaLoaiTien", true);
				return _maLoaiTien;
			}
			set
			{
				CanWriteProperty("MaLoaiTien", true);
				if (!_maLoaiTien.Equals(value))
				{
					_maLoaiTien = value;
					PropertyHasChanged("MaLoaiTien");
				}
			}
		}

        public string TenLoaiTien
        {
            get
            {
                CanReadProperty("TenLoaiTien", true);
                _tenLoaiTien = ERP_Library.LoaiTien.GetLoaiTien(_maLoaiTien).TenLoaiTien;
                return _tenLoaiTien;
            }
        }

		public double PhanTramKyQuy
		{
			get
			{
				CanReadProperty("PhanTramKyQuy", true);
				return _phanTramKyQuy;
			}
			set
			{
				CanWriteProperty("PhanTramKyQuy", true);
				if (!_phanTramKyQuy.Equals(value))
				{
					_phanTramKyQuy = value;
					PropertyHasChanged("PhanTramKyQuy");
				}
			}
		}

		public decimal SoTienDatCoc
		{
			get
			{
				CanReadProperty("SoTienDatCoc", true);
				return _soTienDatCoc;
			}
			set
			{
				CanWriteProperty("SoTienDatCoc", true);
				if (!_soTienDatCoc.Equals(value))
				{
					_soTienDatCoc = value;
					PropertyHasChanged("SoTienDatCoc");
				}
			}
		}

		public decimal PhiGiaoDich
		{
			get
			{
				CanReadProperty("PhiGiaoDich", true);
				return _phiGiaoDich;
			}
			set
			{
				CanWriteProperty("PhiGiaoDich", true);
				if (!_phiGiaoDich.Equals(value))
				{
					_phiGiaoDich = value;
					PropertyHasChanged("PhiGiaoDich");
				}
			}
		}

		public double LaiSuat
		{
			get
			{
				CanReadProperty("LaiSuat", true);
				return _laiSuat;
			}
			set
			{
				CanWriteProperty("LaiSuat", true);
				if (!_laiSuat.Equals(value))
				{
					_laiSuat = value;
					PropertyHasChanged("LaiSuat");
				}
			}
		}

		public string VietBangChu
		{
			get
			{
				CanReadProperty("VietBangChu", true);
				return _vietBangChu;
			}
			set
			{
				CanWriteProperty("VietBangChu", true);
				if (value == null) value = string.Empty;
				if (!_vietBangChu.Equals(value))
				{
					_vietBangChu = value;
					PropertyHasChanged("VietBangChu");
				}
			}
		}

		public bool DaThu
		{
			get
			{
				CanReadProperty("DaThu", true);
				return _daThu;
			}
			set
			{
				CanWriteProperty("DaThu", true);
				if (!_daThu.Equals(value))
				{
					_daThu = value;
					PropertyHasChanged("DaThu");
				}
			}
		}

		public bool DaChi
		{
			get
			{
				CanReadProperty("DaChi", true);
				return _daChi;
			}
			set
			{
				CanWriteProperty("DaChi", true);
				if (!_daChi.Equals(value))
				{
					_daChi = value;
					PropertyHasChanged("DaChi");
				}
			}
		}

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                _tuNgay = new SmartDate(HopDongMuaBan.GetHopDongMuaBan(_maHopDong).TuNgay);
                return _tuNgay.Date;
            }
        }

        public bool MuaBan
        {
            get
            {
                CanReadProperty("MuaBan", true);
                return _muaBan;
            }
            set
            {
                CanWriteProperty("MuaBan", true);
                if (!_muaBan.Equals(value))
                {
                    _muaBan = value;
                    PropertyHasChanged("MuaBan");
                }
            }
        }

        public bool HDTrongNgoaiDai
        {
            get
            {
                CanReadProperty("HDTrongNgoaiDai", true);
                return _hdTrongNgoaiDai;
            }
            set
            {
                CanWriteProperty("HDTrongNgoaiDai", true);
                if (!_hdTrongNgoaiDai.Equals(value))
                {
                    _hdTrongNgoaiDai = value;
                    PropertyHasChanged("HDTrongNgoaiDai");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maHopDong;
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
			// SoHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHopDong", 20));
			//
			// VietBangChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 500));
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
			//TODO: Define authorization rules in DSHopDongMuaBan
			//AuthorizationRules.AllowRead("MaHopDong", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("SoHopDong", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaBangBaoGia", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("TongTien", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("Loai", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiTien", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("PhanTramKyQuy", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("SoTienDatCoc", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("PhiGiaoDich", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("LaiSuat", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("VietBangChu", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("DaThu", "DSHopDongMuaBanReadGroup");
			//AuthorizationRules.AllowRead("DaChi", "DSHopDongMuaBanReadGroup");

			//AuthorizationRules.AllowWrite("SoHopDong", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaBangBaoGia", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("TongTien", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("Loai", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiTien", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramKyQuy", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienDatCoc", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("PhiGiaoDich", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("LaiSuat", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("VietBangChu", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("DaThu", "DSHopDongMuaBanWriteGroup");
			//AuthorizationRules.AllowWrite("DaChi", "DSHopDongMuaBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DSHopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DSHopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DSHopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DSHopDongMuaBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DSHopDongMuaBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DSHopDongMuaBan()
		{ /* require use of factory method */ }

		public static DSHopDongMuaBan NewDSHopDongMuaBan(long maHopDong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSHopDongMuaBan");
			return DataPortal.Create<DSHopDongMuaBan>(new Criteria(maHopDong));
		}

		public static DSHopDongMuaBan GetDSHopDongMuaBan(long maHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DSHopDongMuaBan");
			return DataPortal.Fetch<DSHopDongMuaBan>(new Criteria(maHopDong));
		}

		public static void DeleteDSHopDongMuaBan(long maHopDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DSHopDongMuaBan");
			DataPortal.Delete(new Criteria(maHopDong));
		}

		public override DSHopDongMuaBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DSHopDongMuaBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DSHopDongMuaBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DSHopDongMuaBan");

			return base.Save();
		}

        public static decimal TongTienTraCham(long MaHopDong, DateTime NgayThu)
        {
            decimal tongtien = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TienLaiTraCham_MuaBan";
                        cm.Parameters.AddWithValue("@MaHopDong", MaHopDong);
                        cm.Parameters.AddWithValue("@NgayThu", NgayThu);
                        cm.Parameters.AddWithValue("@TongTien", Convert.ToDecimal(0));
                        cm.Parameters["@TongTien"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        tongtien = (decimal)cm.Parameters["@TongTien"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return tongtien;
            }//using
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		private DSHopDongMuaBan(long maHopDong)
		{
			this._maHopDong = maHopDong;
		}

		internal static DSHopDongMuaBan NewDSHopDongMuaBanChild(long maHopDong)
		{
			DSHopDongMuaBan child = new DSHopDongMuaBan(maHopDong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DSHopDongMuaBan GetDSHopDongMuaBan(SafeDataReader dr)
		{
			DSHopDongMuaBan child =  new DSHopDongMuaBan();
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
			public long MaHopDong;

			public Criteria(long maHopDong)
			{
				this.MaHopDong = maHopDong;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maHopDong = criteria.MaHopDong;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		[Transactional(TransactionalTypes.TransactionScope)] 
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
				cm.CommandText = "GetDSHopDongMuaBan";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
		[Transactional(TransactionalTypes.TransactionScope)] 
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		[Transactional(TransactionalTypes.TransactionScope)] 
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					//ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		[Transactional(TransactionalTypes.TransactionScope)] 
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maHopDong));
		}

		[Transactional(TransactionalTypes.TransactionScope)] 
		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeleteDSHopDongMuaBan";

				cm.Parameters.AddWithValue("@MaHopDong", criteria.MaHopDong);

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
			_maHopDong = dr.GetInt64("MaHopDong");
			_soHopDong = dr.GetString("SoHopDong");
			_maBangBaoGia = dr.GetInt32("MaBangBaoGia");
			_tongTien = dr.GetDecimal("TongTien");
			_maLoaiHopDong = dr.GetInt32("MaLoaiHopDong");
			_maLoaiTien = dr.GetInt32("MaLoaiTien");
			_phanTramKyQuy = dr.GetDouble("PhanTramKyQuy");
			_soTienDatCoc = dr.GetDecimal("SoTienDatCoc");
			_phiGiaoDich = dr.GetDecimal("PhiGiaoDich");
			_laiSuat = dr.GetDouble("LaiSuat");
			_vietBangChu = dr.GetString("VietBangChu");
			_daThu = dr.GetBoolean("DaThu");
			_daChi = dr.GetBoolean("DaChi");
            _muaBan = dr.GetBoolean("MuaBan");
            _hdTrongNgoaiDai = dr.GetBoolean("HDTrongNgoaiDai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, DSHopDongMuaBanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, DSHopDongMuaBanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddDSHopDongMuaBan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DSHopDongMuaBanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			if (_soHopDong.Length > 0)
				cm.Parameters.AddWithValue("@SoHopDong", _soHopDong);
			else
				cm.Parameters.AddWithValue("@SoHopDong", DBNull.Value);
			if (_maBangBaoGia != 0)
				cm.Parameters.AddWithValue("@MaBangBaoGia", _maBangBaoGia);
			else
				cm.Parameters.AddWithValue("@MaBangBaoGia", DBNull.Value);
			if (_tongTien != 0)
				cm.Parameters.AddWithValue("@TongTien", _tongTien);
			else
				cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
			if (_maLoaiHopDong != 0)
				cm.Parameters.AddWithValue("@MaLoaiHopDong", _maLoaiHopDong);
			else
				cm.Parameters.AddWithValue("@MaLoaiHopDong", DBNull.Value);
			if (_maLoaiTien != 0)
				cm.Parameters.AddWithValue("@MaLoaiTien", _maLoaiTien);
			else
				cm.Parameters.AddWithValue("@MaLoaiTien", DBNull.Value);
			if (_phanTramKyQuy != 0)
				cm.Parameters.AddWithValue("@PhanTramKyQuy", _phanTramKyQuy);
			else
				cm.Parameters.AddWithValue("@PhanTramKyQuy", DBNull.Value);
			if (_soTienDatCoc != 0)
				cm.Parameters.AddWithValue("@SoTienDatCoc", _soTienDatCoc);
			else
				cm.Parameters.AddWithValue("@SoTienDatCoc", DBNull.Value);
			if (_phiGiaoDich != 0)
				cm.Parameters.AddWithValue("@PhiGiaoDich", _phiGiaoDich);
			else
				cm.Parameters.AddWithValue("@PhiGiaoDich", DBNull.Value);
			if (_laiSuat != 0)
				cm.Parameters.AddWithValue("@LaiSuat", _laiSuat);
			else
				cm.Parameters.AddWithValue("@LaiSuat", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			cm.Parameters.AddWithValue("@DaThu", _daThu);
			cm.Parameters.AddWithValue("@DaChi", _daChi);
            cm.Parameters.AddWithValue("@MuaBan", _muaBan);
            cm.Parameters.AddWithValue("@HDTrongNgoaiDai", _hdTrongNgoaiDai);
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
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "spd_UpdatetblHopDongMuaBan_Trang";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

                _ChungTu_QuyetDinhList.MaQuyetDinh = _maHopDong;
                ChungTu_QuyetDinh _ChungTu_QuyetDinh = _ChungTu_QuyetDinh = new ChungTu_QuyetDinh(ChungTu_QuyetDinhList.MaChungTu, _maHopDong, 6);
                if (ChungTu_QuyetDinhList.MaChungTu != 0)
                {
                    _ChungTu_QuyetDinhList.Add(_ChungTu_QuyetDinh);
                    _ChungTu_QuyetDinhList.ApplyEdit();
                    _ChungTu_QuyetDinhList.DataPortal_Update(tr, ChungTu_QuyetDinhList.MaChungTu);
                }

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			cm.Parameters.AddWithValue("@DaThu", _daThu);
			cm.Parameters.AddWithValue("@DaChi", _daChi);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maHopDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

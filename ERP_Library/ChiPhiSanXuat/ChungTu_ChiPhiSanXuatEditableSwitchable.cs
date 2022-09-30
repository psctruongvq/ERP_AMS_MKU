
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_ChiPhiSanXuat : Csla.BusinessBase<ChungTu_ChiPhiSanXuat>
	{
		#region Business Properties and Methods

		//declare members
		private long _maCTChiPhiSanXuat = 0;
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private int _maChuongTrinh = 0;
		private string _tenChuongTrinh = string.Empty;
		private decimal _soTien = 0;
		private int _maLoaiChiPhi = 0;

        private ChiPhiThucHienList _chiPhiThucHienList = ChiPhiThucHienList.NewChiPhiThucHienList();
        private ChiThuLaoList _chiThuLaoList = ChiThuLaoList.NewChiThuLaoList();
        private ButtoanMucNganSachList _buttoanMucNganSachList = ButtoanMucNganSachList.NewButtoanMucNganSachList();
        private int _maButToan = 0;
        private int _isUpdate = 0;
        private int _maTaiKhoan = 0;
        private int _maBoPhan = 0;
        private int _maLoaiChi = 0;
		[System.ComponentModel.DataObjectField(true, true)]
        public int IsUpdate
        {
            get { return _isUpdate; }
            set { _isUpdate = value; }
        }

		public long MactChiphisanxuat
		{
			get
			{
				return _maCTChiPhiSanXuat;
			}


               set
			{
                if (!_maCTChiPhiSanXuat.Equals(value))
				{
                    _maCTChiPhiSanXuat = value;
                    PropertyHasChanged("MaCTChiphisanxuat");
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
        public int MaButToan
        {
            get
            {
                return _maButToan;
            }
            set
            {
                if (!_maButToan.Equals(value))
                {
                    _maButToan = value;
                    PropertyHasChanged("MaButToan");
                }
            }
        }
        public int MaTaiKhoan
        {
            get
            {
                return _maTaiKhoan;
            }
            set
            {
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }
		public string SoChungTu
		{
			get
			{
				return _soChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
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
                    _tenChuongTrinh = ChuongTrinh.GetChuongTrinh(_maChuongTrinh).TenChuongTrinh;
					PropertyHasChanged("MaChuongTrinh");
				}
			}
		}

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public int MaLoaiChi
        {
            get
            {
                return _maLoaiChi;
            }
            set
            {
                if (!_maLoaiChi.Equals(value))
                {
                    _maLoaiChi = value;
                    PropertyHasChanged("MaLoaiChi");
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

		public int MaLoaiChiPhi
		{
			get
			{
				return _maLoaiChiPhi;
			}
			set
			{
				if (!_maLoaiChiPhi.Equals(value))
				{
					_maLoaiChiPhi = value;
					PropertyHasChanged("MaLoaiChiPhi");
				}
			}
		}

        public ButtoanMucNganSachList ButtoanMucNganSachList
        {
            get
            {
                CanReadProperty(true);
                return _buttoanMucNganSachList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_buttoanMucNganSachList.Equals(value))
                {
                    _buttoanMucNganSachList = value;
                    PropertyHasChanged();
                }
            }
        }

        public ChiPhiThucHienList ChiPhiThucHienList
        {
            get { return _chiPhiThucHienList; }
            set { _chiPhiThucHienList = value; }
        }

        public ChiThuLaoList ChiThuLaoList
        {
            get { return _chiThuLaoList; }
            set { _chiThuLaoList = value; }
        }
       
		protected override object GetIdValue()
		{
			return _maCTChiPhiSanXuat;
		}
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _chiPhiThucHienList.IsDirty || _chiThuLaoList.IsDirty || _buttoanMucNganSachList.IsDirty;

            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _chiPhiThucHienList.IsValid || _chiThuLaoList.IsValid || _buttoanMucNganSachList.IsValid;

            }
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// TenChuongTrinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTu_ChiPhiSanXuat()
		{ /* require use of factory method */ }

        #region Ban Quyen Vat Tu
        public ChungTu_ChiPhiSanXuat(int maChuongTrinh, decimal soTien)
        {
            _maChuongTrinh = maChuongTrinh;
            _soTien = soTien;
            ValidationRules.CheckRules();
            MarkAsChild();
        }
        #endregion//Ban Quyen Vat Tu

        public static ChungTu_ChiPhiSanXuat NewChungTu_ChiPhiSanXuat()
		{
            ChungTu_ChiPhiSanXuat item = new ChungTu_ChiPhiSanXuat();
            item.MarkAsChild();
            return item;
		}


        public static ChungTu_ChiPhiSanXuat GetChungTu_ChiPhiSanXuat(long mactChiphisanxuat)
		{
			return DataPortal.Fetch<ChungTu_ChiPhiSanXuat>(new Criteria(mactChiphisanxuat));
		}

        public static ChungTu_ChiPhiSanXuat GetChungTu_ChiPhiSanXuatBySoChungTu(string soChungTu)
        {
            return DataPortal.Fetch<ChungTu_ChiPhiSanXuat>(new CriteriaBySoChungTu(soChungTu));
        }

		public static void DeleteChungTu_ChiPhiSanXuat(long mactChiphisanxuat)
		{
			DataPortal.Delete(new Criteria(mactChiphisanxuat));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTu_ChiPhiSanXuat NewChungTu_ChiPhiSanXuatChild()
		{
			ChungTu_ChiPhiSanXuat child = new ChungTu_ChiPhiSanXuat();
			
			child.MarkAsChild();
			return child;
		}
        internal static ChungTu_ChiPhiSanXuat NewChungTu_ChiPhiSanXuatChild( ChiThuLaoList chiThuLaoList)
        {
            ChungTu_ChiPhiSanXuat child = new ChungTu_ChiPhiSanXuat();
            
            child.MarkAsChild();
            return child;
        }
		internal static ChungTu_ChiPhiSanXuat GetChungTu_ChiPhiSanXuat(SafeDataReader dr)
		{
			ChungTu_ChiPhiSanXuat child =  new ChungTu_ChiPhiSanXuat();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
       

        internal static ChungTu_ChiPhiSanXuat GetChungTu_ChiPhiSanXuatUpdateDataTemp(SafeDataReader dr)
        {
            ChungTu_ChiPhiSanXuat child = new ChungTu_ChiPhiSanXuat();
            child._maButToan = dr.GetInt32("ButToanChungTu");
            child._maChungTu = dr.GetInt64("MaChungTu");
            child._soChungTu = dr.GetString("SoChungTu");
            child._maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            child._tenChuongTrinh = dr.GetString("TenChuongTrinh");
            child._soTien = dr.GetDecimal("SoTien");
            child._maCTChiPhiSanXuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
            child._isUpdate = 2;
            child.MarkNew();
            return child;
        }
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public long MactChiphisanxuat;

			public Criteria(long mactChiphisanxuat)
			{
				this.MactChiphisanxuat = mactChiphisanxuat;
			}
		}

        [Serializable()]
        private class CriteriaBySoChungTu
        {
            public string SoChungTu;

            public CriteriaBySoChungTu(string soChungTu)
            {
                this.SoChungTu = soChungTu;
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
		private void DataPortal_Fetch(object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
                cm.CommandTimeout = 0;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "SelecttblCT_ChiPhiSanXuat";
                    cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", ((Criteria)criteria).MactChiphisanxuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);
                        FetchChildren(dr);
                    }
                }
                else if (criteria is CriteriaBySoChungTu)
                {
                    cm.CommandText = "[SelecttblCT_ChiPhiSanXuat_BySoChungTu]";
                    cm.Parameters.AddWithValue("@SoChungTu", ((CriteriaBySoChungTu)criteria).SoChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        FetchObject(dr);                       
                    }
                }

				
			}//using
		}

		#endregion //Data Access - Fetch	

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maCTChiPhiSanXuat));
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
				cm.CommandText = "DeletetblCT_ChiPhiSanXuat";

				cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", criteria.MactChiphisanxuat);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();			
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maCTChiPhiSanXuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
			_maChungTu = dr.GetInt64("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_maChuongTrinh = dr.GetInt32("MaChuongTrinh");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_soTien = dr.GetDecimal("SoTien");
			_maLoaiChiPhi = dr.GetInt32("MaLoaiChiPhi");
            _maButToan = dr.GetInt32("MaButToan");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _chiPhiThucHienList = ERP_Library.ChiPhiThucHienList.GetChiPhiThucHienList(_maCTChiPhiSanXuat);
            _chiThuLaoList = ERP_Library.ChiThuLaoList.GetChiThuLaoListByChiPhiSanXuat(_maCTChiPhiSanXuat);
            _buttoanMucNganSachList = ButtoanMucNganSachList.GetButtoanMucNganSachListByChiPhiSanXuat(_maCTChiPhiSanXuat);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, long maChungTu,string soChungTu,int maButToan)
		{
            if (maButToan == 0)
                maButToan = _maButToan;
            else
                _maButToan = maButToan;
            if (maChungTu == 0)
            {
                maChungTu = _maChungTu;
                soChungTu = _soChungTu;
            }
            else
            {
                _maChungTu = maChungTu;
                _soChungTu = soChungTu;
            }
            
			if (!IsDirty) return;
            ExecuteInsert(tr, maChungTu, soChungTu, maButToan);
			MarkOld();			
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, long maChungTu, string soChungTu, int maButToan)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblCT_ChiPhiSanXuat";
                AddInsertParameters(cm, maChungTu, soChungTu, maButToan);
				cm.ExecuteNonQuery();
				_maCTChiPhiSanXuat = (long)cm.Parameters["@MaCT_ChiPhiSanXuat"].Value;
			}//using
		}
        private void AddInsertParameters(SqlCommand cm, long maChungTu, string soChungTu, int maButToan)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (maButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", maButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maLoaiChiPhi != 0)
				cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
			else
				cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _maCTChiPhiSanXuat);
			cm.Parameters["@MaCT_ChiPhiSanXuat"].Direction = ParameterDirection.Output;
            if (_maTaiKhoan >0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
		}


        public void ExecuteInsertDataTemp(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                  
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "InserttblCT_ChiPhiSanXuat1";
                        AddInsertParametersTemp(cm);
                        cm.ExecuteNonQuery();
                        _maCTChiPhiSanXuat = (long)cm.Parameters["@MaCT_ChiPhiSanXuat"].Value;
                  
                    ExecuteInsertCPTH(tr);

                }//using
            }
            catch (Exception ex)
            { throw ex; }
            
        }
        private void ExecuteInsertCPTH(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblChiPhiThucHien1";
                AddInsertParametersCPTH(cm);
                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParametersCPTH(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maCTChiPhiSanXuat != 0)
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _maCTChiPhiSanXuat);
            else
                cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@TenChungTu", _soChungTu);
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

            cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);

            cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);

            cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);

            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@IsUpdate", 2);
            cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", DateTime.Today.Date);
            cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            cm.Parameters.AddWithValue("@MaLoaiChiPhiSanXuat", 1);            
            cm.Parameters.AddWithValue("@MaChiPhiThucHien", 0);
            cm.Parameters["@MaChiPhiThucHien"].Direction = ParameterDirection.Output;
            //if (_maTaiKhoan > 0)
            //    cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            //else
            //    cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
        }
	
        private void AddInsertParametersTemp(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maLoaiChiPhi != 0)
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
            else
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
            if (_isUpdate != 0)
                cm.Parameters.AddWithValue("@IsUpdate", 2);
            else
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _maCTChiPhiSanXuat);
            cm.Parameters["@MaCT_ChiPhiSanXuat"].Direction = ParameterDirection.Output;
            if (_maTaiKhoan > 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
        }
	
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, long maChungTu, string soChungTu, int maButToan)
		{
            //if (!IsDirty)
            //    return;
            if (maButToan == 0)
                maButToan = _maButToan;
            else
                _maButToan = maButToan;
            if (maChungTu == 0)
            {
                maChungTu = _maChungTu;
                soChungTu = _soChungTu;
            }
            else
            {
                _maChungTu = maChungTu;
                _soChungTu = soChungTu;
            }
            
            ExecuteUpdate(tr, maChungTu, soChungTu, maButToan);
				MarkOld();
			
			UpdateChildren(tr);
		}
        private void ExecuteUpdate(SqlTransaction tr, long maChungTu, string soChungTu, int maButToan)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblCT_ChiPhiSanXuat";

                AddUpdateParameters(cm, maChungTu, soChungTu, maButToan);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, long maChungTu, string soChungTu, int maButToan)
		{
			cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _maCTChiPhiSanXuat);
            if (_maButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", maButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_maChuongTrinh != 0)
				cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
			else
				cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maLoaiChiPhi != 0)
				cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
			else
				cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
            if (_maTaiKhoan > 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
		}


        public void ExecuteUpdateTemp(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblCT_ChiPhiSanXuat";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", _maCTChiPhiSanXuat);
            if (_maButToan != 0)
                cm.Parameters.AddWithValue("@MaButToan", _maButToan);
            else
                cm.Parameters.AddWithValue("@MaButToan", DBNull.Value);
            if (_maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_tenChuongTrinh.Length > 0)
                cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
            else
                cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
            if (_soTien != 0)
                cm.Parameters.AddWithValue("@SoTien", _soTien);
            else
                cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
            if (_maLoaiChiPhi != 0)
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", _maLoaiChiPhi);
            else
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
            if (_isUpdate != 0)
                cm.Parameters.AddWithValue("@IsUpdate", _isUpdate);
            else
                cm.Parameters.AddWithValue("@MaLoaiChiPhi", DBNull.Value);
            if (_maTaiKhoan > 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
        }
     
		private void UpdateChildren(SqlTransaction tr)
		{
            _chiPhiThucHienList.DataPortal_Update(tr, _maChungTu, _soChungTu,_maCTChiPhiSanXuat,_maChuongTrinh,_tenChuongTrinh);
            _chiThuLaoList.DataPortal_Update(tr, _maChungTu, _soChungTu, _maCTChiPhiSanXuat, _maChuongTrinh, _tenChuongTrinh);
            _buttoanMucNganSachList.DataPortal_Update(tr, _maCTChiPhiSanXuat, _maButToan);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
            //if (!IsDirty) return;
            //if (IsNew) return;
            _chiPhiThucHienList.Clear();
            _chiThuLaoList.Clear();
            _buttoanMucNganSachList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maCTChiPhiSanXuat));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class CongDoan_ChungTu : Csla.BusinessBase<CongDoan_ChungTu>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private decimal _soTien = 0;
		private DateTime _ngayLap = DateTime.Today.Date;
		private string _dienGiai = string.Empty;
		private long _maDoiTuong = 0;
		private int _maCongViec = 0;
		private int _maLoaiThuChi = 0;
		private int _maNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private CongDoan_ButToanList _congDoan_ButToanList = CongDoan_ButToanList.NewCongDoan_ButToanList();
        private CongDoanChungTu_TheoDoi _chungTuTheoDoi = CongDoanChungTu_TheoDoi.NewCongDoanChungTu_TheoDoi();
        private int _maLoaiThuChiCongDoan = 0;
        private CongDoan_DeNghiChuyenKhoanList _congDoan_DeNghiList = CongDoan_DeNghiChuyenKhoanList.NewCongDoan_DeNghiChuyenKhoanList();
        private CongDoan_GiayBaoCoList _congDoan_GiayBCList = CongDoan_GiayBaoCoList.NewCongDoan_GiayBaoCoList();
        private CongDoan_GiayRutTienList _congDoan_GiayRTList = CongDoan_GiayRutTienList.NewCongDoan_GiayRutTienList();

        private int _loaiChungTuDiKem = 0;
        private string _tenLoaiThuChi = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
        public CongDoanChungTu_TheoDoi ChungTuTheoDoi
        {
            get { return _chungTuTheoDoi; }
            set { _chungTuTheoDoi = value; }
        }
        public int MaLoaiThuChiCongDoan
        {
            get { return _maLoaiThuChiCongDoan; }
            set { _maLoaiThuChiCongDoan = value; PropertyHasChanged("MaLoaiThuChiCongDoan"); }
        }
        public string TenLoaiThuChi
        {
            get
            {
                if (_maLoaiThuChi == 2)
                    _tenLoaiThuChi = "Phiếu Thu";
                else if (_maLoaiThuChi == 3)
                    _tenLoaiThuChi = "Phiếu Chi";
                else if (_maLoaiThuChi == 16)
                    _tenLoaiThuChi = "Bảng Kê";
                return _tenLoaiThuChi;
            }

        }
        public CongDoan_ButToanList CongDoan_ButToanList
        {
            get { return _congDoan_ButToanList; }
            set
            {
                _congDoan_ButToanList = value;
                PropertyHasChanged("CongDoan_ButToanList");
            }
        }
		public int MaChungTu
		{
			get
			{
				return _maChungTu;
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

		public int MaCongViec
		{
			get
			{
				return _maCongViec;
			}
			set
			{
				if (!_maCongViec.Equals(value))
				{
					_maCongViec = value;
					PropertyHasChanged("MaCongViec");
				}
			}
		}

		public int MaLoaiThuChi
		{
			get
			{
				return _maLoaiThuChi;
			}
			set
			{
				if (!_maLoaiThuChi.Equals(value))
				{
					_maLoaiThuChi = value;
					PropertyHasChanged("MaLoaiThuChi");
				}
			}
		}

		public int MaNguoiLap
		{
			get
			{
                return ERP_Library.Security.CurrentUser.Info.UserID;
			}
			set
			{
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public int LoaiChungTuDiKem
        {
            get
            {
                CanReadProperty("LoaiChungTuDiKem", true);
                return _loaiChungTuDiKem;
            }
            set
            {
                CanWriteProperty("LoaiChungTuDiKem", true);
                if (!_loaiChungTuDiKem.Equals(value))
                {
                    _loaiChungTuDiKem = value;
                    PropertyHasChanged("LoaiChungTuDiKem");
                }
            }
        }

        public CongDoan_DeNghiChuyenKhoanList CongDoan_DeNghiList
        {
            get
            {
                CanReadProperty("CongDoan_DeNghiList", true);
                return _congDoan_DeNghiList;
            }
        }

         public CongDoan_GiayBaoCoList CongDoan_GiayBCList
        {
            get
            {
                CanReadProperty("CongDoan_GiayBCList", true);
                return _congDoan_GiayBCList;
            }
        }

        public CongDoan_GiayRutTienList CongDoan_GiayRTList
        {
            get
            {
                CanReadProperty("CongDoan_GiayRTList", true);
                return _congDoan_GiayRTList;
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
			//
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _congDoan_ButToanList.IsDirty || _congDoan_DeNghiList.IsDirty || _congDoan_GiayBCList.IsDirty || _congDoan_GiayRTList.IsDirty;
            }
        }
		private CongDoan_ChungTu()
		{ /* require use of factory method */ }

		public static CongDoan_ChungTu NewCongDoan_ChungTu(int maLoaiChungTu, int nam)
		{
            CongDoan_ChungTu item = new CongDoan_ChungTu();
            item.SoChungTu = CongDoan_ChungTu.LaySoChungTuMax(maLoaiChungTu, nam);
            return item;
		}
        public static CongDoan_ChungTu NewCongDoan_ChungTu()
        {
            CongDoan_ChungTu item = new CongDoan_ChungTu();            
            return item;
        }
		public static CongDoan_ChungTu GetCongDoan_ChungTu(int maChungTu)
		{
			return DataPortal.Fetch<CongDoan_ChungTu>(new Criteria(maChungTu));
		}

		public static void DeleteCongDoan_ChungTu(int maChungTu)
		{
			DataPortal.Delete(new Criteria(maChungTu));
		}

        public static Boolean KiemTraSoChungTu(string SoChungTu, CongDoan_ChungTu _ChungTu)
        {
            int count = 0;
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    
                    cm.CommandText = "spd_KiemSoChungTuCongDoan";
                    cm.Parameters.AddWithValue("@SoChungTu", SoChungTu);
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    
                    count = (int)cm.ExecuteScalar();
                }
            }
            
            if (count == 1)
            {
                kq = true;
            }
            return kq;
        }

        public static string LaySoChungTuMax(int maLoaiChungTu, int Nam)
        {
            string strSoMoi = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = System.Data.CommandType.Text;
              
                cm.CommandText = "select (isnull(Max(Left(SoChungTu,4)),0)+1)as SoCTMax from tblCongDoan_ChungTu where MaLoaiThuChi=@MaLoaiChungTu and MaNguoiLap=@MaNguoiLap and year(NgayLap)=@Nam";
                cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiChungTu);
                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9 && (maLoaiChungTu == 2 || maLoaiChungTu == 3))
                {
                    cm.Parameters.AddWithValue("@MaNguoiLap", 43);
                }
                else
                {
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                }
                   
                cm.Parameters.AddWithValue("@Nam", Nam);
                
                strSoMoi = Convert.ToString(cm.ExecuteScalar());
                cn.Close();
            }
            int len = strSoMoi.Length;

            string nam = DateTime.Today.Year.ToString();
            while (len < 4)
            {
                strSoMoi = "0" + strSoMoi;
                len = strSoMoi.Length;
            }
            if (maLoaiChungTu == 2)
                strSoMoi = strSoMoi + "T/CĐ/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 3)
                strSoMoi = strSoMoi + "C/CĐ/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);
            else if (maLoaiChungTu == 16)
                strSoMoi = strSoMoi + "K/CĐ/" + ERP_Library.Security.CurrentUser.Info.MaQLUser + "/" + (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan)).MaBoPhanQL.Substring(0, 4);          
            return strSoMoi + "/" + DateTime.Today.Year.ToString();
        }

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongDoan_ChungTu NewCongDoan_ChungTuChild()
		{
			CongDoan_ChungTu child = new CongDoan_ChungTu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongDoan_ChungTu GetCongDoan_ChungTu(SafeDataReader dr)
		{
			CongDoan_ChungTu child =  new CongDoan_ChungTu();
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
			public int MaChungTu;

			public Criteria(int maChungTu)
			{
				this.MaChungTu = maChungTu;
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
				cm.CommandText = "SelecttblCongDoan_ChungTu";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
					//tr.Rollback();
					throw;
				}
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
				cm.CommandText = "DeletetblCongDoan_ChungTu";

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
			_maChungTu = dr.GetInt32("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_soTien = dr.GetDecimal("SoTien");
			_ngayLap = dr.GetDateTime("NgayLap");
			_dienGiai = dr.GetString("DienGiai");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_maCongViec = dr.GetInt32("MaCongViec");
			_maLoaiThuChi = dr.GetInt32("MaLoaiThuChi");
			_maNguoiLap = dr.GetInt32("MaNguoiLap");
            _maLoaiThuChiCongDoan = dr.GetInt32("MaLoaiThuChiCongDoan");
            _loaiChungTuDiKem = dr.GetInt32("LoaiChungTu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            _congDoan_ButToanList = CongDoan_ButToanList.GetCongDoan_ButToanList(_maChungTu);
            _chungTuTheoDoi = CongDoanChungTu_TheoDoi.GetCongDoanChungTu_TheoDoiByChungTu(_maChungTu);
            _congDoan_DeNghiList = CongDoan_DeNghiChuyenKhoanList.GetCongDoan_DeNghiChuyenKhoanList(_maChungTu);
            _congDoan_GiayBCList = CongDoan_GiayBaoCoList.GetCongDoan_GiayBaoCoList(_maChungTu);
            _congDoan_GiayRTList = CongDoan_GiayRutTienList.GetCongDoan_GiayRutTienList(_maChungTu);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();
           
			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblCongDoan_ChungTu";
                cm.Parameters.AddWithValue("@MaLoaiThuChiCongDoan", _maLoaiThuChiCongDoan);
				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChungTu = (int)cm.Parameters["@MaChungTu"].Value;
                if (_maLoaiThuChi != 16)
                    _chungTuTheoDoi.Insert(tr, this);
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongDoan_ChungTu parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
			if (_maLoaiThuChi != 0)
				cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
			else
				cm.Parameters.AddWithValue("@MaLoaiThuChi", DBNull.Value);
                
            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            
			cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
                if (_maLoaiThuChi != 16)
                    _chungTuTheoDoi.Update(tr, this);
			}
            
			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, CongDoan_ChungTu parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblCongDoan_ChungTu";
                cm.Parameters.AddWithValue("@MaLoaiThuChiCongDoan", _maLoaiThuChiCongDoan);
				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

                if (_maLoaiThuChi != 16)
                    _chungTuTheoDoi.Update(tr, this);

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongDoan_ChungTu parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_maCongViec != 0)
				cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			else
				cm.Parameters.AddWithValue("@MaCongViec", DBNull.Value);
			if (_maLoaiThuChi != 0)
				cm.Parameters.AddWithValue("@MaLoaiThuChi", _maLoaiThuChi);
			else
				cm.Parameters.AddWithValue("@MaLoaiThuChi", DBNull.Value);
            
			cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _congDoan_ButToanList.Update(tr, this);
            _congDoan_DeNghiList.Update(tr, this);
            _congDoan_GiayBCList.Update(tr, this);
            _congDoan_GiayRTList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            
            _chungTuTheoDoi.Dataportal_Delete(tr);
            _congDoan_DeNghiList.Clear();
            _congDoan_DeNghiList.Update(tr, this);
            _congDoan_GiayBCList.Clear();
            _congDoan_GiayBCList.Update(tr, this);
            _congDoan_GiayRTList.Clear();
            _congDoan_GiayRTList.Update(tr, this);
			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

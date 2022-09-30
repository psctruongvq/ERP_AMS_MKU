
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_TheoDoi : Csla.BusinessBase<ChungTu_TheoDoi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTheoDoi = 0;
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private DateTime _ngayLapChungTu = DateTime.Today.Date;
		private decimal _soTienChungTu = 0;
		private string _dienGiaiChungTu = string.Empty;
		private int _nguoiLapChungTu = 0;
		private decimal _soTienDaChi = 0;
        private decimal _soTienDaThu = 0;
        private string _phieuChi = string.Empty;
        private string _phieuThu = string.Empty;
        private string _bangKe = string.Empty;
        private decimal _soTienSeThanhToan = 0;
		private decimal _soTienConLai = 0;
        private string _loaiThuChi = string.Empty;
        private string _tenDoiTuong = string.Empty;

        private decimal _SoTienThuChi = 0;

        public string TenDoiTuong
        {
            get {
                
                
                return _tenDoiTuong; }
           
        }
        private ChungTu_TheoDoiChiTietList _chungTuTheoDoiList = ChungTu_TheoDoiChiTietList.NewChungTu_TheoDoiChiTietList();
        public string LoaiThuChi
        {
            get {
               
                return _loaiThuChi;
                }
            
        }
        private DateTime _ngayChiTien = DateTime.Today.Date;

        
		private int _nguoiChiTien =ERP_Library.Security.CurrentUser.Info.UserID;
		private bool _hoanTat = false;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
        public string PhieuThu
        {
            get
            {
                return _phieuThu;
            }
            
        }
        public string PhieuChi
        {
            get
            {
                return _phieuChi;
            }

        }
        public string BangKe
        {
            get
            {
                return _bangKe;
            }

        }
        public DateTime NgayChiTien
        {
            get {
                CanReadProperty("NgayChiTien", true);
                return _ngayChiTien; }
            set
            {
                _ngayChiTien = value;
                PropertyHasChanged("NgayChiTien");
            }
        }
        public decimal SoTienSeThanhToan
        {
            get
            {
                CanReadProperty("SoTienSeThanhToan", true);
                return _soTienSeThanhToan;
            }
            set
            {
                CanWriteProperty("SoTienSeThanhToan", true);
                if (!_soTienSeThanhToan.Equals(value))
                {
                    _soTienSeThanhToan = value;
                    PropertyHasChanged("SoTienSeThanhToan");
                }
            }
        }
		public int MaTheoDoi
		{
			get
			{
				return _maTheoDoi;
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
        public ChungTu_TheoDoiChiTietList ChungTuTheoDoiList
        {
            get
            {
                return _chungTuTheoDoiList;
            }
            set
            {

                if (!_chungTuTheoDoiList.Equals(value))
                {
                    _chungTuTheoDoiList = value;
                    PropertyHasChanged("ChungTuTheoDoiList");
                }
            }
        }
		public DateTime NgayLapChungTu
		{
			get
			{
				return _ngayLapChungTu;
			}
			set
			{
				if (!_ngayLapChungTu.Equals(value))
				{
					_ngayLapChungTu = value;
					PropertyHasChanged("NgayLapChungTu");
				}
			}
		}

		public decimal SoTienChungTu
		{
			get
			{
				return _soTienChungTu;
			}
			set
			{
				if (!_soTienChungTu.Equals(value))
				{
					_soTienChungTu = value;
					PropertyHasChanged("SoTienChungTu");
				}
			}
		}

		public string DienGiaiChungTu
		{
			get
			{
				return _dienGiaiChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienGiaiChungTu.Equals(value))
				{
					_dienGiaiChungTu = value;
					PropertyHasChanged("DienGiaiChungTu");
				}
			}
		}

		public int NguoiLapChungTu
		{
			get
			{
				return _nguoiLapChungTu;
			}
			set
			{
				if (!_nguoiLapChungTu.Equals(value))
				{
					_nguoiLapChungTu = value;
					PropertyHasChanged("NguoiLapChungTu");
				}
			}
		}

		public decimal SoTienDaChi
		{
			get
			{
				return _soTienDaChi;
			}
			set
			{
				if (!_soTienDaChi.Equals(value))
				{
					_soTienDaChi = value;
					PropertyHasChanged("SoTienDaChi");
				}
			}
		}
        public decimal SoTienDaThu
        {
            get
            {
                return _soTienDaThu;
            }
            set
            {
                if (!_soTienDaThu.Equals(value))
                {
                    _soTienDaThu = value;
                    PropertyHasChanged("SoTienDaThu");
                }
            }
        }

		public decimal SoTienConLai
		{
			get
			{
				return _soTienConLai;
			}
			set
			{
				if (!_soTienConLai.Equals(value))
				{
					_soTienConLai = value;
					PropertyHasChanged("SoTienConLai");
				}
			}
		}

        public decimal SoTienThuChi
        {
            get
            {
                return _SoTienThuChi;
            }
            set
            {
                if (!_SoTienThuChi.Equals(value))
                {
                    _SoTienThuChi = value;
                    PropertyHasChanged("SoTienThuChi");
                }
            }
        }

	
		public int NguoiChiTien
		{
			get
			{
				return _nguoiChiTien;
			}
			set
			{
				if (!_nguoiChiTien.Equals(value))
				{
					_nguoiChiTien = value;
					PropertyHasChanged("NguoiChiTien");
				}
			}
		}

		public bool HoanTat
		{
			get
			{
				return _hoanTat;
			}
			set
			{
				if (!_hoanTat.Equals(value))
				{
					_hoanTat = value;
					PropertyHasChanged("HoanTat");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				return _ghiChu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTheoDoi;
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
		
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTu_TheoDoi()
		{ /* require use of factory method */ }

		public static ChungTu_TheoDoi NewChungTu_TheoDoi()
		{
			return DataPortal.Create<ChungTu_TheoDoi>();
		}

		public static ChungTu_TheoDoi GetChungTu_TheoDoi(int maTheoDoi)
		{
			return DataPortal.Fetch<ChungTu_TheoDoi>(new Criteria(maTheoDoi));
		}

		public static void DeleteChungTu_TheoDoi(int maTheoDoi)
		{
			DataPortal.Delete(new Criteria(maTheoDoi));
		}
        public static ChungTu_TheoDoi GetChungTu_TheoDoi(long maChungTu)
        {
            return DataPortal.Fetch<ChungTu_TheoDoi>(new CriteriaByChungTu(maChungTu));
        }
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTu_TheoDoi NewChungTu_TheoDoiChild()
		{
			ChungTu_TheoDoi child = new ChungTu_TheoDoi();
		//	child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTu_TheoDoi GetChungTu_TheoDoi(SafeDataReader dr)
		{
			ChungTu_TheoDoi child =  new ChungTu_TheoDoi();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
        private class CriteriaByChungTu
        {
            public long MaChungTu;
            public CriteriaByChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
		private class Criteria
		{
			public int MaTheoDoi;

			public Criteria(int maTheoDoi)
			{
				this.MaTheoDoi = maTheoDoi;
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
			//SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				//tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(cn, criteria);

					//tr.Commit();
				}
				catch
				{
					//tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "SelecttblChungTu_TheoDoi";
                    cm.Parameters.AddWithValue("@MaTheoDoi", ((Criteria)criteria).MaTheoDoi);
                }
                else if (criteria is CriteriaByChungTu)
                {

                    cm.CommandText = "SelecttblChungTu_TheoDoiByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((CriteriaByChungTu)criteria).MaChungTu);
                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                     

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
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maTheoDoi));
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
				cm.CommandText = "DeletetblChungTu_TheoDoi";

				cm.Parameters.AddWithValue("@MaTheoDoi", criteria.MaTheoDoi);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maTheoDoi = dr.GetInt32("MaTheoDoi");
			_maChungTu = dr.GetInt64("MaChungTu");
			
			_ngayLapChungTu = dr.GetDateTime("NgayLapChungTu");
			_soTienChungTu = dr.GetDecimal("SoTienChungTu");
			_dienGiaiChungTu = dr.GetString("DienGiaiChungTu");
			_nguoiLapChungTu = dr.GetInt32("NguoiLapChungTu");			
			_soTienConLai = dr.GetDecimal("SoTienConLai");
             _ngayChiTien = dr.GetDateTime("NgayChiTien");          
			_nguoiChiTien = dr.GetInt32("NguoiChiTien");
			_hoanTat = dr.GetBoolean("HoanTat");
			_ghiChu = dr.GetString("GhiChu");
            ChungTuRutGon ctrg=ChungTuRutGon.GetChungTuRutGon(_maChungTu);
            if (ctrg.MaLoaiChungTu == 2)
            {
                _loaiThuChi = "Phiếu Thu";
                _soTienDaThu = dr.GetDecimal("SoTienDaChi");
                _phieuThu = dr.GetString("SoChungTu");
            }
            else if (ctrg.MaLoaiChungTu == 3)
            {
                _loaiThuChi = "Phiếu Chi";
                _soTienDaChi = dr.GetDecimal("SoTienDaChi");
                _phieuChi = dr.GetString("SoChungTu");
            }
            else 
            {
                _loaiThuChi = "BangKe";
                _soTienDaChi = dr.GetDecimal("SoTienDaChi");
                _bangKe=dr.GetString("SoChungTu");
              
            }
           _tenDoiTuong = dr.GetString("TenDoiTuong");

           _SoTienThuChi = dr.GetDecimal("SoTienDaChi");
		}

		private void FetchChildren(SafeDataReader dr)
		{
            this._chungTuTheoDoiList = ChungTu_TheoDoiChiTietList.GetChungTu_TheoDoiChiTietList(_maTheoDoi);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		public void Insert(SqlTransaction tr, ChungTu  parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTu  parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChungTu_TheoDoi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTheoDoi = (int)cm.Parameters["@MaTheoDoi"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTu  parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (parent.SoChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", parent.SoChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLapChungTu", parent.NgayThucHien);
                if (parent.Tien.ThanhTien != 0)
                    cm.Parameters.AddWithValue("@SoTienChungTu", parent.Tien.ThanhTien);
				else
					cm.Parameters.AddWithValue("@SoTienChungTu", DBNull.Value);
				if (parent.DienGiai.Length > 0)
					cm.Parameters.AddWithValue("@DienGiaiChungTu", parent.DienGiai);
				else
					cm.Parameters.AddWithValue("@DienGiaiChungTu", DBNull.Value);
				if (parent.NguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLapChungTu", parent.NguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLapChungTu", DBNull.Value);
				
					cm.Parameters.AddWithValue("@SoTienDaChi", _soTienDaChi);
				
			
					cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);

                    cm.Parameters.AddWithValue("@NgayChiTien", DateTime.Today.Date);
					
					if (_nguoiChiTien != 0)
						cm.Parameters.AddWithValue("@NguoiChiTien", _nguoiChiTien);
					else
						cm.Parameters.AddWithValue("@NguoiChiTien", DBNull.Value);
					
						cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
					
					if (_ghiChu.Length > 0)
						cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
					else
						cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi);
			cm.Parameters["@MaTheoDoi"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		public  void Update(SqlTransaction tr, ChungTu  parent)
		{
			
				ExecuteUpdate(tr, parent);
				MarkOld();
			

			//update child object(s)
			UpdateChildren(tr);
		}
        public void Update(SqlTransaction tr)
        {
            if (!IsDirty)
                return;
            ExecuteUpdate(tr);
            MarkOld();
        }
        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblChungTu_TheoDoi1";
                cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi); 
                cm.Parameters.AddWithValue("@SoTienDaChi", _soTienDaChi);
                cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
                cm.Parameters.AddWithValue("@NgayChiTien", _ngayChiTien);
                if (_nguoiChiTien != 0)
                    cm.Parameters.AddWithValue("@NguoiChiTien", _nguoiChiTien);
                else
                    cm.Parameters.AddWithValue("@NguoiChiTien", DBNull.Value);
               
                    cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
               
                if (_ghiChu.Length > 0)
                    cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
                else
                    cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);

                cm.ExecuteNonQuery();

            }//using
        }
		private void ExecuteUpdate(SqlTransaction tr, ChungTu  parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChungTu_TheoDoi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTu  parent)
		{
			cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi);
            if (parent.MaChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", parent.MaChungTu);
            else
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (parent.SoChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", parent.SoChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLapChungTu", parent.NgayThucHien);
            if (parent.Tien.ThanhTien != 0)
                cm.Parameters.AddWithValue("@SoTienChungTu", parent.Tien.ThanhTien);
            else
                cm.Parameters.AddWithValue("@SoTienChungTu", DBNull.Value);
            if (parent.DienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiaiChungTu", parent.DienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiaiChungTu", DBNull.Value);
            if (parent.NguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLapChungTu", parent.NguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLapChungTu", DBNull.Value);

            cm.Parameters.AddWithValue("@SoTienDaChi", _soTienDaChi);

            cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);

            cm.Parameters.AddWithValue("@NgayChiTien",_ngayChiTien);
			if (_nguoiChiTien != 0)
				cm.Parameters.AddWithValue("@NguoiChiTien", _nguoiChiTien);
			else
				cm.Parameters.AddWithValue("@NguoiChiTien", DBNull.Value);
			
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
            _chungTuTheoDoiList.DataPortal_Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
        public void Dataportal_Delete(SqlTransaction tr)
        {

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeletetblChungTu_TheoDoi";

                cm.Parameters.AddWithValue("@MaTheoDoi", _maTheoDoi);

                cm.ExecuteNonQuery();
            }//using
        }
        public static void Dataportal_Delete(SqlTransaction tr,long maChungTu)
        {

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeletetblChungTu_TheoDoi";

                
                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);

                cm.ExecuteNonQuery();
            }//using
            
        }
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

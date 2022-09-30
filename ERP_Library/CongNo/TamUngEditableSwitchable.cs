
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TamUng : Csla.BusinessBase<TamUng>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTamUng = 0;
		private long _maDoiTuong = 0;
	//	private string _tenNhanVien = string.Empty;
		//private int _maBoPhan = 0;
		//private string _tenBoPhan = string.Empty;
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private int _loaiChungTu = 0;
		private int _loaiThuChi = 0;
		private decimal _soTien = 0;
		private string _soTienBangChu = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private string _dienGiai = string.Empty;
		private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private string _tenDoiTuong = string.Empty;
        private string _donViDoiTuong=string.Empty;
        private int _maChuongTrinh = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTamUng
		{
			get
			{
				return _maTamUng;
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
                if (!_tenDoiTuong.Equals(value))
                {
                    _tenDoiTuong = value;
                    PropertyHasChanged("TenDoiTuong");
                }
            }
        }
        public string DonViDoiTuong
        {
            get
            {
               
                return _donViDoiTuong;

            }
            set
            {
                if (!_donViDoiTuong.Equals(value))
                {
                    _donViDoiTuong = value;
                    PropertyHasChanged("DonViDoiTuong");
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
                  //  _soChungTu = ChungTu.GetChungTu(_maChungTu).SoChungTu;
					PropertyHasChanged("MaChungTu");
				}
			}
		}

		public string SoChungTu
		{
			get
			{
               // _soChungTu= ChungTu.GetChungTu(_maChungTu).SoChungTu;
                return _soChungTu;

			}
            set
            {
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
		}

		public int LoaiChungTu
		{
			get
			{
				return _loaiChungTu;
			}
			set
			{
				if (!_loaiChungTu.Equals(value))
				{
					_loaiChungTu = value;
					PropertyHasChanged("LoaiChungTu");
				}
			}
		}

		public int LoaiThuChi
		{
			get
			{
				return _loaiThuChi;
			}
			set
			{
				if (!_loaiThuChi.Equals(value))
				{
					_loaiThuChi = value;
					PropertyHasChanged("LoaiThuChi");
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
                    _soTienBangChu = HamDungChung.DocTien(SoTien);
					PropertyHasChanged("SoTien");
				}
			}
		}

		public string SoTienBangChu
		{
			get
			{
                _soTienBangChu = HamDungChung.DocTien(SoTien);
                return _soTienBangChu;
                    
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
		protected override object GetIdValue()
		{
			return _maTamUng;
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
			// TenNhanVien
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 50));
            ////
            //// TenBoPhan
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 50));
            ////
            //// SoChungTu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
            ////
            //// SoTienBangChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTienBangChu", 200));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private TamUng()
		{ /* require use of factory method */ }

		public static TamUng NewTamUng()
		{
            TamUng item = new TamUng();
            item.MarkAsChild();
            return item;
		}

		public static TamUng GetTamUng(int maTamUng)
		{
			return DataPortal.Fetch<TamUng>(new Criteria(maTamUng));
		}

		public static void DeleteTamUng(int maTamUng)
		{
			DataPortal.Delete(new Criteria(maTamUng));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TamUng NewTamUngChild()
		{
			TamUng child = new TamUng();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TamUng GetTamUng(SafeDataReader dr)
		{
			TamUng child =  new TamUng();
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
			public int MaTamUng;

			public Criteria(int maTamUng)
			{
				this.MaTamUng = maTamUng;
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
				cm.CommandText = "SelecttblTamUng";

				cm.Parameters.AddWithValue("@MaTamUng", criteria.MaTamUng);

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

    
		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maTamUng));
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
				cm.CommandText = "DeletetblTamUng";

				cm.Parameters.AddWithValue("@MaTamUng", criteria.MaTamUng);

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
			_maTamUng = dr.GetInt32("MaTamUng");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");			
			_maChungTu = dr.GetInt64("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_loaiChungTu = dr.GetInt32("LoaiChungTu");
			_loaiThuChi = dr.GetInt32("LoaiThuChi");
			_soTien = dr.GetDecimal("SoTien");
			_soTienBangChu = dr.GetString("SoTienBangChu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_dienGiai = dr.GetString("DienGiai");
			_nguoiLap = dr.GetInt32("NguoiLap");
            _tenDoiTuong = dr.GetString("TenDoiTuong");
            _donViDoiTuong = dr.GetString("DonViDoiTuong");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, long maChungTu,string soChungTu)
		{
			if (!IsDirty) return;

            ExecuteInsert(tr, maChungTu,soChungTu);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, long maChungTu,string soChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblTamUng";

				AddInsertParameters(cm, maChungTu,soChungTu);

				cm.ExecuteNonQuery();

				_maTamUng = (int)cm.Parameters["@MaTamUng"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, long maChungTu,string soChungTu)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
           
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);

            if (maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
			if (soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_tenDoiTuong.Length > 0)
                cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
            else
                cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
            if (_donViDoiTuong.Length > 0)
                cm.Parameters.AddWithValue("@DonViDoiTuong", _donViDoiTuong);
            else
                cm.Parameters.AddWithValue("@DonViDoiTuong", DBNull.Value);
			if (_loaiChungTu != 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_loaiThuChi != 0)
				cm.Parameters.AddWithValue("@LoaiThuChi", _loaiThuChi);
			else
				cm.Parameters.AddWithValue("@LoaiThuChi", DBNull.Value);
			
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			
			if (_soTienBangChu.Length > 0)
				cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
			else
				cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);

            if (_ngayLap.Year > 1900)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            else
            {
                ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
                if (ct.Count > 0)
                    cm.Parameters.AddWithValue("@NgayLap", ct[0].NgayThucHien);
            }

            if (_dienGiai.Length > 0)
					cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
				else
					cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
                if (_maChuongTrinh != 0)
                    cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
                else
                    cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTamUng", _maTamUng);
			cm.Parameters["@MaTamUng"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, long maChungTu,string soChungTu)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, maChungTu,soChungTu);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr, long maChungTu,string soChungTu)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblTamUng";

				AddUpdateParameters(cm, maChungTu, soChungTu);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, long maChungTu,string soChungTu)
		{
          
			cm.Parameters.AddWithValue("@MaTamUng", _maTamUng);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
                cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
            if (maChungTu != 0)
                cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
			else
				cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            if (soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			if (_loaiChungTu != 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_loaiThuChi != 0)
				cm.Parameters.AddWithValue("@LoaiThuChi", _loaiThuChi);
			else
				cm.Parameters.AddWithValue("@LoaiThuChi", DBNull.Value);
			
				cm.Parameters.AddWithValue("@SoTien", _soTien);
                if (_tenDoiTuong.Length > 0)
                    cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
                else
                    cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
                if (_donViDoiTuong.Length > 0)
                    cm.Parameters.AddWithValue("@DonViDoiTuong", _donViDoiTuong);
                else
                    cm.Parameters.AddWithValue("@DonViDoiTuong", DBNull.Value);
			if (_soTienBangChu.Length > 0)
				cm.Parameters.AddWithValue("@SoTienBangChu", _soTienBangChu);
			else
				cm.Parameters.AddWithValue("@SoTienBangChu", DBNull.Value);

            if (_ngayLap.Year > 1900)
                cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            else
            {
                ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
                if (ct.Count > 0)
                    cm.Parameters.AddWithValue("@NgayLap", ct[0].NgayThucHien);
            }

            if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
        public void Dataportal_Delete(SqlTransaction tr)
        {
            
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "DeletetblTamUng";

                cm.Parameters.AddWithValue("@MaTamUng", _maTamUng);

                cm.ExecuteNonQuery();
            }//using
        }
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

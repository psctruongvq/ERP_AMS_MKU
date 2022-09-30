
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinUngVien : Csla.BusinessBase<ThongTinUngVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maUngVien = 0;
		private string _hoTen = string.Empty;
		private int _maViTri = 0;
		private SmartDate _ngaySinh = new SmartDate(DateTime.Today);
		private int _noiSinh = 0;
        private string _ho = string.Empty;
        private string _ten = string.Empty;
        private int _loaiNV = 0;
		private string _diaChiLienLac = string.Empty;
		private string _dienThoai = string.Empty;
		private string _soCMND = string.Empty;
        private string _maQuanLy = string.Empty;
		private SmartDate _ngayCap = new SmartDate(DateTime.Today);
		private int _noiCap = 0;
		private int _trinhDoVanHoa = 0;
		private int _trinhDoTayNghe = 0;
        private decimal _soNamKinhNghiem = 0;
		private long _maTuyenDung = 0;
		private bool _trungTuyen = false;
        private SmartDate _ngayTrungTuyen = new SmartDate(DateTime.Today);
        private bool _gioiTinh = false;
        private bool _ChuyenThanhNV = false;
        private int _maBoPhan = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public long MaUngVien
		{
			get
			{
				CanReadProperty("MaUngVien", true);
				return _maUngVien;
			}
		}
        public string Ho
        {
            get
            {
                CanReadProperty("Ho", true);
                return _ho;
            }
            set
            {
                CanWriteProperty("Ho", true);
                if (value == null) value = string.Empty;
                if (!_ho.Equals(value))
                {
                    _ho = value;
                    PropertyHasChanged("Ho");
                }
            }
        }
        public string Ten
        {
            get
            {
                CanReadProperty("Ten", true);
                return _ten;
            }
            set
            {
                CanWriteProperty("Ten", true);
                if (value == null) value = string.Empty;
                if (!_ten.Equals(value))
                {
                    _ten = value;
                    PropertyHasChanged("Ten");
                }
            }
        }
		public string HoTen
		{
			get
			{
				CanReadProperty("HoTen", true);
				return _hoTen;
			}
            set
            {
                CanWriteProperty("HoTen", true);
                if (value == null) value = string.Empty;
                if (!_hoTen.Equals(value))
                {
                    _hoTen = value;
                    PropertyHasChanged("HoTen");
                }
            }
		
		}
       
		public int MaViTri
		{
			get
			{
				CanReadProperty("MaViTri", true);
				return _maViTri;
			}
			set
			{
				CanWriteProperty("MaViTri", true);
				if (!_maViTri.Equals(value))
				{
					_maViTri = value;
					PropertyHasChanged("MaViTri");
				}
			}
		}
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);                
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }
       
		public DateTime NgaySinh
		{
			get
			{
				CanReadProperty("NgaySinh", true);
				return _ngaySinh.Date;
			}
            set
            {
                CanWriteProperty("NgaySinh", true);
                if (!_ngaySinh.Equals(value))
                {
                    _ngaySinh = new SmartDate(value);
                    PropertyHasChanged("NgaySinh");
                }
            }
		}

        public int LoaiNV
        {
            get
            {
                CanReadProperty("LoaiNV", true);
                return _loaiNV;
            }
            set
            {
                CanWriteProperty("LoaiNV", true);
                if (!_loaiNV.Equals(value))
                {
                    _loaiNV = value;
                    PropertyHasChanged("LoaiNV");
                }
            }
        }
        public int NoiSinh
        {
            get
            {
                CanReadProperty("NoiSinh", true);
                return _noiSinh;
            }
            set
            {
                CanWriteProperty("NoiSinh", true);
                if (!_noiSinh.Equals(value))
                {
                    _noiSinh = value;
                    PropertyHasChanged("NoiSinh");
                }
            }
        }

		public string DiaChiLienLac
		{
			get
			{
				CanReadProperty("DiaChiLienLac", true);
				return _diaChiLienLac;
			}
			set
			{
				CanWriteProperty("DiaChiLienLac", true);
				if (value == null) value = string.Empty;
				if (!_diaChiLienLac.Equals(value))
				{
					_diaChiLienLac = value;
					PropertyHasChanged("DiaChiLienLac");
				}
			}
		}

		public string DienThoai
		{
			get
			{
				CanReadProperty("DienThoai", true);
				return _dienThoai;
			}
			set
			{
				CanWriteProperty("DienThoai", true);
				if (value == null) value = string.Empty;
				if (!_dienThoai.Equals(value))
				{
					_dienThoai = value;
					PropertyHasChanged("DienThoai");
				}
			}
		}
        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }
		public string SoCMND
		{
			get
			{
				CanReadProperty("SoCMND", true);
				return _soCMND;
			}
			set
			{
				CanWriteProperty("SoCMND", true);
				if (value == null) value = string.Empty;
				if (!_soCMND.Equals(value))
				{
					_soCMND = value;
					PropertyHasChanged("SoCMND");
				}
			}
		}

		public DateTime NgayCap
		{
			get
			{
				CanReadProperty("NgayCap", true);
				return _ngayCap.Date;
			}
            set
            {
                CanWriteProperty("NgayCap", true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = new SmartDate(value);
                    PropertyHasChanged("NgayCap");
                }
            }
		}

        public DateTime NgayTrungTuyen
        {
            get
            {
                CanReadProperty("NgayTrungTuyen", true);
                return _ngayTrungTuyen.Date;
            }
            set
            {
                CanWriteProperty("NgayTrungTuyen", true);
                if (!_ngayTrungTuyen.Equals(value))
                {
                    _ngayTrungTuyen = new SmartDate(value);
                    PropertyHasChanged("NgayTrungTuyen");
                }
            }
        }

	
		public int NoiCap
		{
			get
			{
				CanReadProperty("NoiCap", true);
				return _noiCap;
			}
			set
			{
				CanWriteProperty("NoiCap", true);
				if (!_noiCap.Equals(value))
				{
					_noiCap = value;
					PropertyHasChanged("NoiCap");
				}
			}
		}

		public int TrinhDoVanHoa
		{
			get
			{
				CanReadProperty("TrinhDoVanHoa", true);
				return _trinhDoVanHoa;
			}
			set
			{
				CanWriteProperty("TrinhDoVanHoa", true);
				if (!_trinhDoVanHoa.Equals(value))
				{
					_trinhDoVanHoa = value;
					PropertyHasChanged("TrinhDoVanHoa");
				}
			}
		}

		public int TrinhDoTayNghe
		{
			get
			{
				CanReadProperty("TrinhDoTayNghe", true);
				return _trinhDoTayNghe;
			}
			set
			{
				CanWriteProperty("TrinhDoTayNghe", true);
				if (!_trinhDoTayNghe.Equals(value))
				{
					_trinhDoTayNghe = value;
					PropertyHasChanged("TrinhDoTayNghe");
				}
			}
		}

		public decimal SoNamKinhNghiem
		{
			get
			{
				CanReadProperty("SoNamKinhNghiem", true);
				return _soNamKinhNghiem;
			}
			set
			{
				CanWriteProperty("SoNamKinhNghiem", true);
				
				if (!_soNamKinhNghiem.Equals(value))
				{
					_soNamKinhNghiem = value;
					PropertyHasChanged("SoNamKinhNghiem");
				}
			}
		}

		public long MaTuyenDung
		{
			get
			{
				CanReadProperty("MaTuyenDung", true);
				return _maTuyenDung;
			}
			set
			{
				CanWriteProperty("MaTuyenDung", true);
				if (!_maTuyenDung.Equals(value))
				{
					_maTuyenDung = value;
                    MaViTri = ThongTinTuyenDung.GetThongTinTuyenDung(_maTuyenDung).MaViTri;
					PropertyHasChanged("MaTuyenDung");
				}
			}
		}

		public bool TrungTuyen
		{
			get
			{
				CanReadProperty("TrungTuyen", true);
				return _trungTuyen;
			}
			set
			{
				CanWriteProperty("TrungTuyen", true);
				if (!_trungTuyen.Equals(value))
				{
					_trungTuyen = value;
					PropertyHasChanged("TrungTuyen");
				}
			}
		}
        public bool GioiTinh
        {
            get
            {
                CanReadProperty("GioiTinh", true);
                return _gioiTinh;
            }
            set
            {
                CanWriteProperty("GioiTinh", true);
                if (!_gioiTinh.Equals(value))
                {
                    _gioiTinh = value;
                    PropertyHasChanged("GioiTinh");
                }
            }
        }
        public bool ChuyenThanhNV
        {
            get
            {
                CanReadProperty("ChuyenThanhNV", true);
                return _ChuyenThanhNV;
            }
            set
            {
                CanWriteProperty("ChuyenThanhNV", true);
                if (!_ChuyenThanhNV.Equals(value))
                {
                    _ChuyenThanhNV = value;
                    PropertyHasChanged("ChuyenThanhNV");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maUngVien;
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
			// HoTen
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HoTen", 50));
			//
			// NoiSinh
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiSinh", 100));
			//
			// DiaChiLienLac
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChiLienLac", 100));
			//
			// DienThoai
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 10));
			//
			// SoCMND
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoCMND", 50));
			//
			// SoNamKinhNghiem
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoNamKinhNghiem", 10));
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
			//TODO: Define authorization rules in ThongTinUngVien
			//AuthorizationRules.AllowRead("MaUngVien", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("HoTen", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("MaViTri", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NgaySinh", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NgaySinhString", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NoiSinh", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("DiaChiLienLac", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("DienThoai", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("SoCMND", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NgayCap", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NgayCapString", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("NoiCap", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("TrinhDoVanHoa", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("TrinhDoTayNghe", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("SoNamKinhNghiem", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("MaTuyenDung", "ThongTinUngVienReadGroup");
			//AuthorizationRules.AllowRead("TrungTuyen", "ThongTinUngVienReadGroup");

			//AuthorizationRules.AllowWrite("HoTen", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaViTri", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgaySinhString", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("NoiSinh", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChiLienLac", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("DienThoai", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoCMND", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayCapString", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("NoiCap", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("TrinhDoVanHoa", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("TrinhDoTayNghe", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoNamKinhNghiem", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaTuyenDung", "ThongTinUngVienWriteGroup");
			//AuthorizationRules.AllowWrite("TrungTuyen", "ThongTinUngVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinUngVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinUngVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinUngVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinUngVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinUngVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinUngVien()
		{ /* require use of factory method */ }

		public static ThongTinUngVien NewThongTinUngVien(long maTuyenDung)
        {
           
            ThongTinUngVien child = new ThongTinUngVien();

            child.MaTuyenDung = maTuyenDung;
            child.MarkAsChild();
            return child;
		}

		public static ThongTinUngVien GetThongTinUngVien(long maUngVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinUngVien");
			return DataPortal.Fetch<ThongTinUngVien>(new Criteria(maUngVien));
		}

		public static void DeleteThongTinUngVien(long maUngVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinUngVien");
			DataPortal.Delete(new Criteria(maUngVien));
		}
        public static void ChuyenUngVienThanhNV(long _maUngVien, string _maQuanLy, string _hoTen, int _maBoPhan, bool _gioiTinh, string _soCMND, DateTime _ngayCap, int _noiCap, DateTime _ngaySinh, int _noiSinh,string _diaChiTam)
        {
         
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
               
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        
                        cm.CommandType = CommandType.StoredProcedure;
                        //sp_InserttblnsUngVienTrungTuyenThanhNV
                        cm.CommandText = "sp_InserttblnsUngVienTrungTuyenThanhNV";
                        //cm.CommandText = "sp_UpdatetblnsUngVienTrungTuyenThanhNV";

                        cm.Parameters.AddWithValue("@MaUngVien", _maUngVien);                                                
         
                        cm.Parameters.AddWithValue("@MaQLNhanVien", _maQuanLy);
                        cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh);
                        cm.Parameters.AddWithValue("@MaNoiSinh", _noiSinh);                  
                        cm.Parameters.AddWithValue("@TenNhanVien", _hoTen);
                        if(_maBoPhan!=0)
                            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                        else
                            cm.Parameters.AddWithValue("@MaBoPhan",DBNull.Value);
                        cm.Parameters.AddWithValue("@MaTayNghe", DBNull.Value);
                        cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
                        cm.Parameters.AddWithValue("@CMND", _soCMND);
                        cm.Parameters.AddWithValue("@NgayCap", _ngayCap);
                        if(_noiCap!=0)
                            cm.Parameters.AddWithValue("@MaNoiCap", _noiCap);
                        else
                            cm.Parameters.AddWithValue("@MaNoiCap", DBNull.Value);
                        cm.Parameters.AddWithValue("@DiaChiNhanVienTam", _diaChiTam);

                        cm.Parameters.AddWithValue("@MaNguoiLap", Security.CurrentUser.Info.UserID);                       
                        cm.ExecuteNonQuery();                       

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
              
            }//using
       
        }
        private void AddParamaterChuyennhanVien(SqlCommand cm)
        {
           
        }
		public override ThongTinUngVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinUngVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinUngVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThongTinUngVien");

			return base.Save();
		}
      
		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThongTinUngVien NewThongTinUngVienChild()
		{
			ThongTinUngVien child = new ThongTinUngVien();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThongTinUngVien GetThongTinUngVien(SafeDataReader dr)
		{
			ThongTinUngVien child =  new ThongTinUngVien();
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
			public long MaUngVien;

			public Criteria(long maUngVien)
			{
				this.MaUngVien = maUngVien;
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
                cm.CommandText = "sp_SelecttblnsThongTinUngVien";

				cm.Parameters.AddWithValue("@MaUngVien", criteria.MaUngVien);

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
			DataPortal_Delete(new Criteria(_maUngVien));
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
                cm.CommandText = "sp_DeletetblnsThongTinUngVien";

				cm.Parameters.AddWithValue("@MaUngVien", criteria.MaUngVien);

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
			_maUngVien = dr.GetInt64("MaUngVien");
			_hoTen = dr.GetString("HoTen");
			_maViTri = dr.GetInt32("MaViTri");
			_ngaySinh = dr.GetSmartDate("NgaySinh", _ngaySinh.EmptyIsMin);
			_noiSinh = dr.GetInt32("NoiSinh");
			_diaChiLienLac = dr.GetString("DiaChiLienLac");
			_dienThoai = dr.GetString("DienThoai");
			_soCMND = dr.GetString("SoCMND");
			_ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
			_noiCap = dr.GetInt32("NoiCap");
			_trinhDoVanHoa = dr.GetInt32("TrinhDoVanHoa");
			_trinhDoTayNghe = dr.GetInt32("TrinhDoTayNghe");
			_soNamKinhNghiem = dr.GetDecimal("SoNamKinhNghiem");
			_maTuyenDung = dr.GetInt64("MaTuyenDung");
			_trungTuyen = dr.GetBoolean("TrungTuyen");
            _ngayTrungTuyen = dr.GetSmartDate("NgayTrungTuyen",_ngayTrungTuyen.EmptyIsMin);
            _ChuyenThanhNV = dr.GetBoolean("ChuyenThanhNV");
            _gioiTinh = dr.GetBoolean("GioiTinh");
            _maQuanLy = dr.GetString("MaQuanLy");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _ho = dr.GetString("Ho");
            _ten = dr.GetString("Ten");
            _loaiNV = dr.GetInt32("LoaiNV");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ThongTinUngVienList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ThongTinUngVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsThongTinUngVien";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maUngVien = (long)cm.Parameters["@MaUngVien"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ThongTinUngVienList parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent

            cm.Parameters.AddWithValue("@Ho", _ho);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@HoTen", _ho + " " + _ten);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);

            if (_maViTri != 0)
                cm.Parameters.AddWithValue("@MaViTri", _maViTri);
            else
                cm.Parameters.AddWithValue("@MaViTri", DBNull.Value);
            cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
            if (_noiSinh != 0)
                cm.Parameters.AddWithValue("@NoiSinh", _noiSinh);
            else
                cm.Parameters.AddWithValue("@NoiSinh", DBNull.Value);
            if (_diaChiLienLac.Length > 0)
                cm.Parameters.AddWithValue("@DiaChiLienLac", _diaChiLienLac);
            else
                cm.Parameters.AddWithValue("@DiaChiLienLac", DBNull.Value);
            if (_dienThoai.Length > 0)
                cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
            else
                cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
            if (_soCMND.Length > 0)
                cm.Parameters.AddWithValue("@SoCMND", _soCMND);
            else
                cm.Parameters.AddWithValue("@SoCMND", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
            if (_noiCap != 0)
                cm.Parameters.AddWithValue("@NoiCap", _noiCap);
            else
                cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
            if (_trinhDoVanHoa != 0)
                cm.Parameters.AddWithValue("@TrinhDoVanHoa", _trinhDoVanHoa);
            else
                cm.Parameters.AddWithValue("@TrinhDoVanHoa", DBNull.Value);
            if (_trinhDoTayNghe != 0)
                cm.Parameters.AddWithValue("@TrinhDoTayNghe", _trinhDoTayNghe);
            else
                cm.Parameters.AddWithValue("@TrinhDoTayNghe", DBNull.Value);
            if (_soNamKinhNghiem != 0)
                cm.Parameters.AddWithValue("@SoNamKinhNghiem", _soNamKinhNghiem);
            else
                cm.Parameters.AddWithValue("@SoNamKinhNghiem", DBNull.Value);
            if (_maTuyenDung != 0)
                cm.Parameters.AddWithValue("@MaTuyenDung", _maTuyenDung);
            else
                cm.Parameters.AddWithValue("@MaTuyenDung", DBNull.Value);
            
                cm.Parameters.AddWithValue("@TrungTuyen", _trungTuyen);
          
            cm.Parameters.AddWithValue("@MaUngVien", _maUngVien);
            cm.Parameters.AddWithValue("@NgayTrungTuyen", _ngayTrungTuyen.DBValue);
            cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            cm.Parameters.AddWithValue("@ChuyenThanhNV", _ChuyenThanhNV);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters["@MaUngVien"].Direction = ParameterDirection.Output;
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ThongTinUngVienList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ThongTinUngVienList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsThongTinUngVien";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ThongTinUngVienList parent)
		{
			cm.Parameters.AddWithValue("@MaUngVien", _maUngVien);

            cm.Parameters.AddWithValue("@Ho", _ho);
            cm.Parameters.AddWithValue("@Ten", _ten);
            cm.Parameters.AddWithValue("@HoTen", _ho + " " + _ten);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
			if (_maViTri != 0)
				cm.Parameters.AddWithValue("@MaViTri", _maViTri);
			else
				cm.Parameters.AddWithValue("@MaViTri", DBNull.Value);
			cm.Parameters.AddWithValue("@NgaySinh", _ngaySinh.DBValue);
			if (_noiSinh!= 0)
				cm.Parameters.AddWithValue("@NoiSinh", _noiSinh);
			else
				cm.Parameters.AddWithValue("@NoiSinh", DBNull.Value);
			if (_diaChiLienLac.Length > 0)
				cm.Parameters.AddWithValue("@DiaChiLienLac", _diaChiLienLac);
			else
				cm.Parameters.AddWithValue("@DiaChiLienLac", DBNull.Value);
			if (_dienThoai.Length > 0)
				cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			else
				cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
			if (_soCMND.Length > 0)
				cm.Parameters.AddWithValue("@SoCMND", _soCMND);
			else
				cm.Parameters.AddWithValue("@SoCMND", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
			if (_noiCap != 0)
				cm.Parameters.AddWithValue("@NoiCap", _noiCap);
			else
				cm.Parameters.AddWithValue("@NoiCap", DBNull.Value);
			if (_trinhDoVanHoa != 0)
				cm.Parameters.AddWithValue("@TrinhDoVanHoa", _trinhDoVanHoa);
			else
				cm.Parameters.AddWithValue("@TrinhDoVanHoa", DBNull.Value);
			if (_trinhDoTayNghe != 0)
				cm.Parameters.AddWithValue("@TrinhDoTayNghe", _trinhDoTayNghe);
			else
				cm.Parameters.AddWithValue("@TrinhDoTayNghe", DBNull.Value);
			if (_soNamKinhNghiem!= 0)
				cm.Parameters.AddWithValue("@SoNamKinhNghiem", _soNamKinhNghiem);
			else
				cm.Parameters.AddWithValue("@SoNamKinhNghiem", DBNull.Value);
			if (_maTuyenDung != 0)
				cm.Parameters.AddWithValue("@MaTuyenDung", _maTuyenDung);
			else
				cm.Parameters.AddWithValue("@MaTuyenDung", DBNull.Value);
			
				cm.Parameters.AddWithValue("@TrungTuyen", _trungTuyen);
		
            cm.Parameters.AddWithValue("@NgayTrungTuyen", _ngayTrungTuyen.DBValue);
            cm.Parameters.AddWithValue("@GioiTinh", _gioiTinh);
            cm.Parameters.AddWithValue("@ChuyenThanhNV", _ChuyenThanhNV);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
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

			ExecuteDelete(tr, new Criteria(_maUngVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

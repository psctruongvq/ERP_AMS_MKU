
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChamCongNhanVien : Csla.BusinessBase<ChamCongNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private string _maQuanLy = string.Empty;
		private string _tenTo = string.Empty;
		private string _ca = string.Empty;
		private string _gioIn = string.Empty;
		private string _gioOut = string.Empty;
		private decimal _sogioHc = 0;
		private decimal _nt = 0;
		private decimal _ot = 0;
		private decimal _ots = 0;
		private decimal _soGio195 = 0;
		private decimal _soGio200 = 0;
		private decimal _soGio260 = 0;
		private decimal _soGio300 = 0;
		private SmartDate _ngay = new SmartDate(false);
		private decimal _absTime = 0;
		private int _maHinhThucNghi = 0;
		private string _tenHinhThucNghi = string.Empty;
		private bool _userModify = false;
        private bool _chamLai = false;
        private byte _suaDLChamCong = 0;
        private int _maCa = 0;
        private SmartDate _ngayLap = new SmartDate(false);
        private long _maNguoiLap = 0;

		[System.ComponentModel.DataObjectField(true, false)]

        public int MaCa
        {
            get
            {
                CanReadProperty("MaCa", true);
                return _maCa;
            }
            set
            {
                CanWriteProperty("MaCa", true);
                if (!_maCa.Equals(value))
                {
                    _maCa = value;
                    PropertyHasChanged("MaCa");
                }
            }
        }

        public byte SuaDLChamCong
        {
            get
            {
                CanReadProperty("SuaDLChamCong", true);
                return _suaDLChamCong;
            }
            set
            {
                CanWriteProperty("SuaDLChamCong", true);
                if (!_suaDLChamCong.Equals(value))
                {
                    _suaDLChamCong = value;
                    PropertyHasChanged("SuaDLChamCong");
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
		}

		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
			set
			{
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
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

		public string TenTo
		{
			get
			{
				CanReadProperty("TenTo", true);
				return _tenTo;
			}
			set
			{
				CanWriteProperty("TenTo", true);
				if (value == null) value = string.Empty;
				if (!_tenTo.Equals(value))
				{
					_tenTo = value;
					PropertyHasChanged("TenTo");
				}
			}
		}

		public string Ca
		{
			get
			{
				CanReadProperty("Ca", true);
				return _ca;
			}
			set
			{
				CanWriteProperty("Ca", true);
				if (value == null) value = string.Empty;
				if (!_ca.Equals(value))
				{
					_ca = value;
					PropertyHasChanged("Ca");
				}
			}
		}

		public string GioIn
		{
			get
			{
				CanReadProperty("GioIn", true);
				return _gioIn;
			}
			set
			{
				CanWriteProperty("GioIn", true);
				if (value == null) value = string.Empty;
				if (!_gioIn.Equals(value))
				{
					_gioIn = value;
                    _userModify = true;
					PropertyHasChanged("GioIn");
				}
			}
		}

		public string GioOut
		{
			get
			{
				CanReadProperty("GioOut", true);
				return _gioOut;
			}
			set
			{
				CanWriteProperty("GioOut", true);
				if (value == null) value = string.Empty;
				if (!_gioOut.Equals(value))
				{
					_gioOut = value;
                    _userModify = true;
					PropertyHasChanged("GioOut");
				}
			}
		}

		public decimal SogioHc
		{
			get
			{
				CanReadProperty("SogioHc", true);
				return _sogioHc;
			}
			set
			{
				CanWriteProperty("SogioHc", true);
				if (!_sogioHc.Equals(value))
				{
					_sogioHc = value;
                    _userModify = true;
					PropertyHasChanged("SogioHc");
				}
			}
		}

		public decimal Nt
		{
			get
			{
				CanReadProperty("Nt", true);
				return _nt;
			}
			set
			{
				CanWriteProperty("Nt", true);
				if (!_nt.Equals(value))
				{
					_nt = value;
					PropertyHasChanged("Nt");
				}
			}
		}

		public decimal Ot
		{
			get
			{
				CanReadProperty("Ot", true);
				return _ot;
			}
			set
			{
				CanWriteProperty("Ot", true);
				if (!_ot.Equals(value))
				{
					_ot = value;
					PropertyHasChanged("Ot");
				}
			}
		}

		public decimal Ots
		{
			get
			{
				CanReadProperty("Ots", true);
				return _ots;
			}
			set
			{
				CanWriteProperty("Ots", true);
				if (!_ots.Equals(value))
				{
					_ots = value;
					PropertyHasChanged("Ots");
				}
			}
		}

		public decimal SoGio195
		{
			get
			{
				CanReadProperty("SoGio195", true);
				return _soGio195;
			}
			set
			{
				CanWriteProperty("SoGio195", true);
				if (!_soGio195.Equals(value))
				{
					_soGio195 = value;
					PropertyHasChanged("SoGio195");
				}
			}
		}

		public decimal SoGio200
		{
			get
			{
				CanReadProperty("SoGio200", true);
				return _soGio200;
			}
			set
			{
				CanWriteProperty("SoGio200", true);
				if (!_soGio200.Equals(value))
				{
					_soGio200 = value;
					PropertyHasChanged("SoGio200");
				}
			}
		}

		public decimal SoGio260
		{
			get
			{
				CanReadProperty("SoGio260", true);
				return _soGio260;
			}
			set
			{
				CanWriteProperty("SoGio260", true);
				if (!_soGio260.Equals(value))
				{
					_soGio260 = value;
					PropertyHasChanged("SoGio260");
				}
			}
		}

		public decimal SoGio300
		{
			get
			{
				CanReadProperty("SoGio300", true);
				return _soGio300;
			}
			set
			{
				CanWriteProperty("SoGio300", true);
				if (!_soGio300.Equals(value))
				{
					_soGio300 = value;
					PropertyHasChanged("SoGio300");
				}
			}
		}

		public DateTime Ngay
		{
			get
			{
				CanReadProperty("Ngay", true);
                _ngay.FormatString="#dd/MM/yy";
				return _ngay.Date;
			}
            set
            {
                CanWriteProperty("Ngay", true);                
                if (!_ngay.Equals(value))
                {
                    _ngay = new SmartDate(value);
                    PropertyHasChanged("Ngay");
                }
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
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }

		public decimal AbsTime
		{
			get
			{
				CanReadProperty("AbsTime", true);
				return _absTime;
			}
			set
			{
				CanWriteProperty("AbsTime", true);
				if (!_absTime.Equals(value))
				{
					_absTime = value;
					PropertyHasChanged("AbsTime");
				}
			}
		}
        
		public int MaHinhThucNghi
		{
			get
			{
				CanReadProperty("MaHinhThucNghi", true);
				return _maHinhThucNghi;
			}
			set
			{
				CanWriteProperty("MaHinhThucNghi", true);
				if (!_maHinhThucNghi.Equals(value))
				{
					_maHinhThucNghi = value;
					PropertyHasChanged("MaHinhThucNghi");
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

		public string TenHinhThucNghi
		{
			get
			{
				CanReadProperty("TenHinhThucNghi", true);
				return _tenHinhThucNghi;
			}
			set
			{
				CanWriteProperty("TenHinhThucNghi", true);
				if (value == null) value = string.Empty;
				if (!_tenHinhThucNghi.Equals(value))
				{
					_tenHinhThucNghi = value;
					PropertyHasChanged("TenHinhThucNghi");
				}
			}
		}

		public bool UserModify
		{
			get
			{
				CanReadProperty("UserModify", true);
				return _userModify;
			}
			set
			{
				CanWriteProperty("UserModify", true);
				if (!_userModify.Equals(value))
				{
					_userModify = value;
					PropertyHasChanged("UserModify");
				}
			}
		}

        public bool ChamLai
        {
            get
            {
                CanReadProperty("ChamLai", true);
                return _chamLai;
            }
            set
            {
                CanWriteProperty("ChamLai", true);
                if (!_chamLai.Equals(value))
                {
                    _chamLai = value;
                    PropertyHasChanged("ChamLai");
                }
            }
        }
 
		protected override object GetIdValue()
		{
			return _maNhanVien;
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
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 200));
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenTo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTo", 200));
			//
			// Ca
			//
            //ValidationRules.AddRule(CommonRules.StringRequired, "Ca");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ca", 20));
			//
			// GioIn
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioIn", 20));
			//
			// GioOut
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioOut", 20));
			//
			// TenHinhThucNghi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHinhThucNghi", 100));
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
			//TODO: Define authorization rules in ChamCongNhanVien
			//AuthorizationRules.AllowRead("MaNhanVien", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenTo", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Ca", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GioIn", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GioOut", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SogioHc", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Nt", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Ot", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Ots", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoGio195", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoGio200", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoGio260", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("SoGio300", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Ngay", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayString", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("AbsTime", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaHinhThucNghi", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenHinhThucNghi", "ChamCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("UserModify", "ChamCongNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("TenNhanVien", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenTo", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Ca", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GioIn", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GioOut", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SogioHc", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Nt", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Ot", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Ots", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoGio195", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoGio200", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoGio260", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("SoGio300", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayString", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("AbsTime", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaHinhThucNghi", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenHinhThucNghi", "ChamCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("UserModify", "ChamCongNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChamCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChamCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChamCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChamCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChamCongNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChamCongNhanVien()
		{ /* require use of factory method */ }

        public static void setRandom(DateTime ngay,int cty,int pb,int to,int maCa,bool RaVao,int hh,int mm1,int mm2)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Random_InOut";
                    cm.Parameters.AddWithValue("@Ngay", ngay);
                    cm.Parameters.AddWithValue("@MaCongTy", cty);
                    cm.Parameters.AddWithValue("@MaPhongBan", pb);
                    cm.Parameters.AddWithValue("@MaTo", to);
                    cm.Parameters.AddWithValue("@In_Out", RaVao);
                    cm.Parameters.AddWithValue("@MaCa", maCa);
                    cm.Parameters.AddWithValue("@HH", hh);
                    cm.Parameters.AddWithValue("@MM1", mm1);
                    cm.Parameters.AddWithValue("@MM2", mm2);
                    try
                    {
                        cm.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }//using                                
            }//using
        }
        public static void setRandom_NhanVienNghi(DateTime ngay,int maCa,long maNV, bool RaVao, int hh, int mm1, int mm2,long maNguoiLap)
        {
            SqlTransaction tran;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tran = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tran.Connection.CreateCommand())
                    {
                        cm.Transaction = tran;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Random_InOut_NhanVienNghi";
                        cm.Parameters.AddWithValue("@Ngay", ngay);
                        cm.Parameters.AddWithValue("@MaCa", maCa);
                        cm.Parameters.AddWithValue("@MaNhanVien", maNV);
                        cm.Parameters.AddWithValue("@In_Out", RaVao);                        
                        cm.Parameters.AddWithValue("@HH", hh);
                        cm.Parameters.AddWithValue("@MM1", mm1);
                        cm.Parameters.AddWithValue("@MM2", mm2);
                        cm.Parameters.AddWithValue("@MaNguoiLap", maNguoiLap);
                        try
                        {
                            cm.ExecuteNonQuery();
                        }
                        catch (Exception ex) { throw ex; }
                    }//using                                
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }                
            }//using
        }

        public static void TinhCongBangTay(DateTime ngay,long maNhanVien,long nguoiLap,DateTime ngayLap,bool khoaSo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_ChamCongBangTay_TheoMaNhanVien";
                        cm.Parameters.AddWithValue("@Ngay", ngay);
                        cm.Parameters.AddWithValue("@MaNhanVien",maNhanVien);
                        cm.Parameters.AddWithValue("@MaNguoiLap", nguoiLap);
                        cm.Parameters.AddWithValue("@Date", ngayLap);
                        cm.Parameters.AddWithValue("@KhoaSo", khoaSo);
                        
                        cm.ExecuteNonQuery();
                    }//using                                
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void XuLyLuong(DateTime ngay, int cty, int pb, int to, long nguoiLap, DateTime ngayLap, bool khoaSo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TinhCongBangTay";
                        cm.Parameters.AddWithValue("@Ngay", ngay);
                        cm.Parameters.AddWithValue("@MaCongTy", cty);
                        cm.Parameters.AddWithValue("@MaPhongBan", pb);
                        cm.Parameters.AddWithValue("@MaTo", to);
                        cm.Parameters.AddWithValue("@MaNguoiLap", nguoiLap);
                        cm.Parameters.AddWithValue("@Date", ngayLap);
                        cm.Parameters.AddWithValue("@KhoaSo", khoaSo);
                        cm.ExecuteNonQuery();
                    }//using                                
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public static ChamCongNhanVien NewChamCongNhanVien(long maNhanVien)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChamCongNhanVien");
			return DataPortal.Create<ChamCongNhanVien>(new Criteria(maNhanVien));
		}

		public static ChamCongNhanVien GetChamCongNhanVien(long maNhanVien)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChamCongNhanVien");
			return DataPortal.Fetch<ChamCongNhanVien>(new Criteria(maNhanVien));
		}

		public static void DeleteChamCongNhanVien(long maNhanVien)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChamCongNhanVien");
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		public override ChamCongNhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChamCongNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChamCongNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChamCongNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ChamCongNhanVien(long maNhanVien)
		{
			this._maNhanVien = maNhanVien;
		}

		internal static ChamCongNhanVien NewChamCongNhanVienChild(long maNhanVien)
		{
			ChamCongNhanVien child = new ChamCongNhanVien(maNhanVien);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChamCongNhanVien GetChamCongNhanVien(SafeDataReader dr)
		{
			ChamCongNhanVien child =  new ChamCongNhanVien();
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
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maNhanVien = criteria.MaNhanVien;
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
				cm.CommandText = "GetChamCongNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maNhanVien));
		}

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
				cm.CommandText = "DeleteChamCongNhanVien";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _maQuanLy = dr.GetString("MaQuanLy");
                _tenTo = dr.GetString("TenTo");
                _ca = dr.GetString("Ca");
                _gioIn = dr.GetString("GioIn");
                _gioOut = dr.GetString("GioOut");
                _sogioHc = dr.GetDecimal("SoGio_HC");
                _nt = dr.GetDecimal("NT");
                _ot = dr.GetDecimal("OT");
                _ots = dr.GetDecimal("OTS");
                _soGio195 = dr.GetDecimal("SoGio195");
                _soGio200 = dr.GetDecimal("SoGio200");
                _soGio260 = dr.GetDecimal("SoGio260");
                _soGio300 = dr.GetDecimal("SoGio300");
                _ngay = dr.GetSmartDate("Ngay", _ngay.EmptyIsMin);
                _absTime = dr.GetDecimal("ABS_TIME");
                _maHinhThucNghi = dr.GetInt32("MaHinhThucNghi");
                _tenHinhThucNghi = dr.GetString("TenHinhThucNghi");
                _userModify = dr.GetBoolean("UserModify");
                _chamLai = dr.GetBoolean("ChamLai");
                _suaDLChamCong = dr.GetByte("SuaDLChamCong");
                _maCa = dr.GetInt32("MaCa");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddChamCongNhanVien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenTo.Length > 0)
				cm.Parameters.AddWithValue("@TenTo", _tenTo);
			else
				cm.Parameters.AddWithValue("@TenTo", DBNull.Value);
			cm.Parameters.AddWithValue("@Ca", _ca);
			if (_gioIn.Length > 0)
				cm.Parameters.AddWithValue("@GioIn", _gioIn);
			else
				cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
			if (_gioOut.Length > 0)
				cm.Parameters.AddWithValue("@GioOut", _gioOut);
			else
				cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
			if (_sogioHc != 0)
				cm.Parameters.AddWithValue("@SoGio_HC", _sogioHc);
			else
				cm.Parameters.AddWithValue("@SoGio_HC", DBNull.Value);
			if (_nt != 0)
				cm.Parameters.AddWithValue("@NT", _nt);
			else
				cm.Parameters.AddWithValue("@NT", DBNull.Value);
			if (_ot != 0)
				cm.Parameters.AddWithValue("@OT", _ot);
			else
				cm.Parameters.AddWithValue("@OT", DBNull.Value);
			if (_ots != 0)
				cm.Parameters.AddWithValue("@OTS", _ots);
			else
				cm.Parameters.AddWithValue("@OTS", DBNull.Value);
			if (_soGio195 != 0)
				cm.Parameters.AddWithValue("@SoGio195", _soGio195);
			else
				cm.Parameters.AddWithValue("@SoGio195", DBNull.Value);
			if (_soGio200 != 0)
				cm.Parameters.AddWithValue("@SoGio200", _soGio200);
			else
				cm.Parameters.AddWithValue("@SoGio200", DBNull.Value);
			if (_soGio260 != 0)
				cm.Parameters.AddWithValue("@SoGio260", _soGio260);
			else
				cm.Parameters.AddWithValue("@SoGio260", DBNull.Value);
			if (_soGio300 != 0)
				cm.Parameters.AddWithValue("@SoGio300", _soGio300);
			else
				cm.Parameters.AddWithValue("@SoGio300", DBNull.Value);
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
			if (_absTime != 0)
				cm.Parameters.AddWithValue("@ABS_TIME", _absTime);
			else
				cm.Parameters.AddWithValue("@ABS_TIME", DBNull.Value);
			if (_maHinhThucNghi != 0)
				cm.Parameters.AddWithValue("@MaHinhThucNghi", _maHinhThucNghi);
			else
				cm.Parameters.AddWithValue("@MaHinhThucNghi", DBNull.Value);
			if (_tenHinhThucNghi.Length > 0)
				cm.Parameters.AddWithValue("@TenHinhThucNghi", _tenHinhThucNghi);
			else
				cm.Parameters.AddWithValue("@TenHinhThucNghi", DBNull.Value);
			if (_userModify != false)
				cm.Parameters.AddWithValue("@UserModify", _userModify);
			else
				cm.Parameters.AddWithValue("@UserModify", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
                try
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChamCong_NhapBangTay";

                    AddUpdateParameters(cm);

                    cm.ExecuteNonQuery();
                }
                catch (Exception ex) 
                { 
                    throw ex; 
                }
			}
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);

            if (_gioIn.Length > 0)
				cm.Parameters.AddWithValue("@GioIn", _gioIn);
			else
				cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
			if (_gioOut.Length > 0)
				cm.Parameters.AddWithValue("@GioOut", _gioOut);
			else
				cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
			if (_maCa != 0)
                cm.Parameters.AddWithValue("@MaCa", _maCa);
			else
				cm.Parameters.AddWithValue("@MaCa", DBNull.Value);
			
			cm.Parameters.AddWithValue("@Ngay", _ngay.DBValue);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
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

			ExecuteDelete(cn, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

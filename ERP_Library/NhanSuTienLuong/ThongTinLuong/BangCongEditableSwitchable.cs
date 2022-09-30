using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
 
namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCong : Csla.BusinessBase<BangCong>
	{
		#region Business Properties and Methods   

		//declare members
		private long _maBangCong = 0;
        private long _maNhanVien = 0;
		private string _maQuanLy = string.Empty;
        private string _tenNhanVien= string.Empty;
		private SmartDate _ngayChamCong = new SmartDate(DateTime.Today);
		private string _gioIn = string.Empty;
		private string _gioOut = string.Empty;
        private string _inDung = string.Empty;
        private string _outDung = string.Empty;
		private decimal _soGio_HC = 0;
        private decimal _tCNgay = 0;
        private decimal _tCDem = 0;
        private decimal _tCNgayCN = 0;
        private decimal _tCDemCN = 0;
        private decimal _tCNgayLe = 0;
        private decimal _tCDemLe = 0;
        private int _soXuatAn = 0;
        private string _loaiCa = string.Empty;
        private string _loaiNgay = string.Empty;
		private bool _userModify = false;
        private bool _khoaSo = false;
		private byte _suaDLChamCong = 0;
        private string _lyDo = "";
        private int _maCa = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaBangCong
		{
			get
			{
				CanReadProperty("MaBangCong", true);
				return _maBangCong;
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
        public DateTime NgayChamCong
        {
            get
            {
                CanReadProperty("NgayChamCong", true);
                return _ngayChamCong.Date;
            }
            set
            {
                CanWriteProperty("NgayChamCong", true);

                if (!_ngayChamCong.Equals(value))
                {
                    _ngayChamCong = new SmartDate(value);
                    PropertyHasChanged("NgayChamCong");
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
					PropertyHasChanged("GioOut");
				}
			}
		}
        public string InDung
        {
            get
            {
                CanReadProperty("InDung", true);
                return _inDung;
            }
            set
            {
                CanWriteProperty("InDung", true);
                if (value == null) value = string.Empty;
                if (!_inDung.Equals(value))
                {
                    _inDung = value;
                    PropertyHasChanged("InDung");
                }
            }
        }
        public string OutDung
        {
            get
            {
                CanReadProperty("OutDung", true);
                return _outDung;
            }
            set
            {
                CanWriteProperty("OutDung", true);
                if (value == null) value = string.Empty;
                if (!_outDung.Equals(value))
                {
                    _outDung = value;
                    PropertyHasChanged("OutDung");
                }
            }
        }
		public decimal SoGio_HC
		{
			get
			{
				CanReadProperty("SoGio_HC", true);
				return _soGio_HC;
			}
			set
			{
				CanWriteProperty("SoGio_HC", true);
                if (!_soGio_HC.Equals(value))
				{
                    _soGio_HC = value;
					PropertyHasChanged("SoGio_HC");
				}
			}
		}
        public decimal TCNgay
        {
            get
            {
                CanReadProperty("TCNgay", true);
                return _tCNgay;
            }
            set
            {
                CanWriteProperty("TCNgay", true);
                if (!_tCNgay.Equals(value))
                {
                    _tCNgay = value;
                    PropertyHasChanged("TCNgay");
                }
            }
        }

        public decimal TCDem
        {
            get
            {
                CanReadProperty("TCDem", true);
                return _tCDem;
            }
            set
            {
                CanWriteProperty("TCDem", true);
                if (!_tCDem.Equals(value))
                {
                    _tCDem = value;
                    PropertyHasChanged("TCDem");
                }
            }
        }

        public decimal TCNgayCN
        {
            get
            {
                CanReadProperty("TCNgayCN", true);
                return _tCNgayCN;
            }
            set
            {
                CanWriteProperty("TCNgayCN", true);
                if (!_tCNgayCN.Equals(value))
                {
                    _tCNgayCN = value;
                    PropertyHasChanged("TCNgayCN");
                }
            }
        }
        public decimal TCDemCN
        {
            get
            {
                CanReadProperty("TCDemCN", true);
                return _tCDemCN;
            }
            set
            {
                CanWriteProperty("TCDemCN", true);
                if (!_tCDemCN.Equals(value))
                {
                    _tCDemCN = value;
                    PropertyHasChanged("TCDemCN");
                }
            }
        }
        public decimal TCNgayLe
        {
            get
            {
                CanReadProperty("TCNgayLe", true);
                return _tCNgayLe;
            }
            set
            {
                CanWriteProperty("TCNgayLe", true);
                if (!_tCNgayLe.Equals(value))
                {
                    _tCNgayLe = value;
                    PropertyHasChanged("TCNgayLe");
                }
            }
        }
        public decimal TCDemLe
        {
            get
            {
                CanReadProperty("TCDemLe", true);
                return _tCDemLe;
            }
            set
            {
                CanWriteProperty("TCDemLe", true);
                if (!_tCDemLe.Equals(value))
                {
                    _tCDemLe = value;
                    PropertyHasChanged("TCDemLe");
                }
            }
        }
 
        public int SoXuatAn
        {
            get
            {
                CanReadProperty("SoXuatAn", true);
                return _soXuatAn;
            }
            set
            {
                CanWriteProperty("SoXuatAn", true);
                if (!_soXuatAn.Equals(value))
                {
                    _soXuatAn = value;
                    PropertyHasChanged("SoXuatAn");
                }
            }
        }
       
        public string LoaiCa
        {
            get
            {
                CanReadProperty("LoaiCa", true);
                return _loaiCa;
            }
         }
        public string LoaiNgay
        {
            get
            {
                CanReadProperty("LoaiNgay", true);
                return _loaiNgay;
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
		public bool KhoaSo
		{
			get
			{
				CanReadProperty("KhoaSo", true);
				return _khoaSo;
			}
			set
			{
				CanWriteProperty("KhoaSo", true);
				if (!_khoaSo.Equals(value))
				{
					_khoaSo = value;
					PropertyHasChanged("KhoaSo");
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
        public string LyDo
        {
            get
            {
                CanReadProperty("LyDo", true);
                return _lyDo;
            }
            set
            {
                CanWriteProperty("LyDo", true);
                if (value == null) value = string.Empty;
                if (!_lyDo.Equals(value))
                {
                    _lyDo = value;
                    PropertyHasChanged("LyDo");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _maBangCong;
		}

        public int MaCa
        {
            get
            {
                CanReadProperty("MaCa", true);
                return _maCa;
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
            // GioIn
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioIn", 20));
            //
            // GioOut
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioOut", 20));
            //
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // TenNhanVien
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 200));
            //
            // MaQuanLyNhanVien
            //
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLyNhanVien", 20));
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
			//TODO: Define authorization rules in BangCong
			//AuthorizationRules.AllowRead("MaBangCong", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("MaCa", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCong", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCongString", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("GioIn", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("GioOut", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("SogioHc", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("UserModify", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("KhoaSo", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("LoaiNgay", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("SuaDLChamCong", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("TangCaNgay", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("TangCaDem", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("TangCaNgayCN", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianHanhChinh", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "BangCongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLyNhanVien", "BangCongReadGroup");

			//AuthorizationRules.AllowWrite("MaCa", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChamCongString", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("GioIn", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("GioOut", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("SogioHc", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("UserModify", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("KhoaSo", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiNgay", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("SuaDLChamCong", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("TangCaNgay", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("TangCaDem", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("TangCaNgayCN", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianHanhChinh", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "BangCongWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLyNhanVien", "BangCongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCong()
		{ /* require use of factory method */ }

		public static BangCong NewBangCong(long maBangCong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCong");
			return DataPortal.Create<BangCong>(new Criteria());
		}

		public static BangCong GetBangCong(long maBangCong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangCong");
			return DataPortal.Fetch<BangCong>(new Criteria());
		}
        
		public static void DeleteBangCong(long maBangCong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangCong");
			DataPortal.Delete(new Criteria());
		}

		public override BangCong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangCong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangCong");

			return base.Save();
		}

        public static void ChamCongNVBatThuong(double SoGio_HC ,double SoGio_TC,long MaNhanVien ,string MaQuanLyCa,DateTime NgayChamCong,DateTime NgayLap ,long MaNguoiLap,string NhaMay)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_ChamCongNVBatThuong";

                //AddUpdateParameters(cm, parent);
                cm.Parameters.AddWithValue("@SoGio_HC", SoGio_HC);
                cm.Parameters.AddWithValue("@SoGio_TC", SoGio_TC);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                cm.Parameters.AddWithValue("@MaQuanLyCa", MaQuanLyCa);
                cm.Parameters.AddWithValue("@NgayChamCong", NgayChamCong);
                cm.Parameters.AddWithValue("@NgayLap", NgayLap);
                cm.Parameters.AddWithValue("@MaNguoiLap", MaNguoiLap);
                cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }

        public static void SuaDLChamCongBangTay(DateTime NgayChamCong,long MaNhanVien,string NhaMay, int MaCa, long MaBangCong, string GioIn,string GioOut)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SuaDLChamCong_N";

                //AddUpdateParameters(cm, parent);
                cm.Parameters.AddWithValue("@NgayChamCong", NgayChamCong);
                cm.Parameters.AddWithValue("@MaCa", MaCa);
                cm.Parameters.AddWithValue("@NhaMay", NhaMay);
                cm.Parameters.AddWithValue("@MaBangCong", MaBangCong);
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                cm.Parameters.AddWithValue("@GioIn", GioIn);
                cm.Parameters.AddWithValue("@GioOut", GioOut);
                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();

            }//using
        }

        public static void TinhCongBangTay(DateTime ngayChamCong,string nhaMay, int boPhan, long maNguoiLap, DateTime ngayLap, bool khoaSo)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TinhCongBangTay_N";
                        cm.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);
                        //cm.Parameters.AddWithValue("@MaCa", ca);
                        cm.Parameters.AddWithValue("@NhaMay", nhaMay);
                        cm.Parameters.AddWithValue("@MaBoPhan", boPhan);
                        cm.Parameters.AddWithValue("@MaNguoiLap", maNguoiLap);
                        cm.Parameters.AddWithValue("@Date", ngayLap);
                        cm.Parameters.AddWithValue("@KhoaSo", khoaSo);
                        int i=cm.ExecuteNonQuery();
                    }//using                                
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void setRandom(DateTime ngay, int boPhan, int maCa, bool RaVao, int hh, int mm1, int mm2)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Random_InOut_N";
                    cm.Parameters.AddWithValue("@Ngay", ngay);
                    cm.Parameters.AddWithValue("@MaBoPhan", boPhan);
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

        public static int KiemTra_NgayChamCong_Ca(DateTime ngayChamCong, int maCa, int Result)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.Connection = cn;

                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTra_NgayChamCong_Ca";
                        cm.Parameters.AddWithValue("@NgayChamCong", ngayChamCong);
                        cm.Parameters.AddWithValue("@MaCa", maCa);
                        cm.Parameters.AddWithValue("@Result", Result);
                        cm.Parameters["@Result"].Direction = ParameterDirection.Output;
                        try
                        {
                            cm.ExecuteNonQuery();
                            cn.Close();
                            return Convert.ToInt32(cm.Parameters["@Result"].Value);

                        }
                        catch (Exception ex) { throw ex; }
                    }//using                                
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//using          
            
        }

        public static void setRandom_NhanVienNghi(DateTime ngay, int maCa, long maNV, bool RaVao, int hh, int mm1, int mm2, long maNguoiLap)
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
                        cm.CommandText = "spd_Random_InOut_NhanVienNghi_N";
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
                catch(Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }//using
        }

        public static void LuuInOut_NhapTay(string GioIn, string GioOut, long MaNhanVien,int MaCa,DateTime NgayChamCong)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LuuInOut_NhapTay";
                    cm.Parameters.AddWithValue("@NgayChamCong", Convert.ToDateTime(NgayChamCong.ToShortDateString()));
                    cm.Parameters.AddWithValue("@MaCa", @MaCa);
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@GioOut", GioOut);
                    cm.Parameters.AddWithValue("@GioIn", GioIn);
                    cm.ExecuteNonQuery();
                }


            }//using
        }

        public static void CopyDuLieuChamCong(DateTime ngayChamCong, DateTime choNgay, int maBoPhan,DateTime ngayLap,int maNguoiLap)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "sp_CopyDuLieuChamCong";
                    cm.Parameters.AddWithValue("@NgayChamCong", Convert.ToDateTime(ngayChamCong.ToShortDateString()));
                    cm.Parameters.AddWithValue("@ChoNgay", Convert.ToDateTime(choNgay.ToShortDateString()));
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaNguoiLap", maNguoiLap);
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.ExecuteNonQuery();
                }


            }//using
        }

        public static void InsertBangChamCong(DateTime NgayChamCong, int MaCa, string NhaMay)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 600;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TinhCong";
                    cm.Parameters.AddWithValue("@NgayChamCong", NgayChamCong.ToShortDateString());
                    cm.Parameters.AddWithValue("@MaCa", MaCa);
                    cm.Parameters.AddWithValue("@NhaMay", NhaMay);
                    //cm.Parameters.AddWithValue("@Date", NgayLap);
                    //cm.Parameters.AddWithValue("@KhoaSo", KhoaSo);

                    cm.ExecuteNonQuery();

                }
            }//using
        }

		#endregion //Factory Methods

		#region Child Factory Methods
		private BangCong(long maBangCong)
		{
			this._maBangCong = maBangCong;
		}
       
		internal static BangCong NewBangCongChild(long maBangCong)
		{
			BangCong child = new BangCong(maBangCong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangCong GetBangCong(SafeDataReader dr)
		{
			BangCong child =  new BangCong();
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
			public long MaBangCong;

			public Criteria()
			{
				//this.MaBangCong = maBangCong;
			}
            
        }
        #endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maBangCong = criteria.MaBangCong;
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
				cm.CommandType = CommandType.Text;
                cm.CommandText = "Select * from View_ChamCong where 1=1 ";
                               			
				//cm.Parameters.AddWithValue("@MaBangCong", criteria.MaBangCong);

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

				ExecuteInsert(cn, null);

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
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria());
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
				cm.CommandText = "DeleteBangCong";

				cm.Parameters.AddWithValue("@MaBangCong", criteria.MaBangCong);

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
            _maBangCong = dr.GetInt64("MaBangCong");
            _maCa = dr.GetInt32("MaCa");
            _maQuanLy = dr.GetString("MaQuanLy");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _ngayChamCong = dr.GetSmartDate("NgayChamCong", _ngayChamCong.EmptyIsMin);
            _gioIn = dr.GetString("GioIn");
            _gioOut = dr.GetString("GioOut");
            _inDung = dr.GetString("InDung");
            _outDung = dr.GetString("OutDung");
            _soGio_HC = dr.GetDecimal("SoGio_HC");
            _tCNgay = dr.GetDecimal("TCNgay");
            _tCDem = dr.GetDecimal("TCDem");
            _tCNgayCN = dr.GetDecimal("TCNgayCN");
            _tCDemCN = dr.GetDecimal("TCDemCN");
            _tCNgayLe = dr.GetDecimal("TCNgayLe");
            _tCDemLe = dr.GetDecimal("TCDemLe");
            _soXuatAn = dr.GetInt32("SoXuatAn");
            _loaiCa = dr.GetString("LoaiCa");
            _loaiNgay = dr.GetString("LoaiNgay");
            _userModify = dr.GetBoolean("UserModify");
            _khoaSo = dr.GetBoolean("KhoaSo");
            _suaDLChamCong = dr.GetByte("SuaDLChamCong");

            _lyDo = dr.GetString("LyDo");

        }

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, BangCongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, BangCongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddBangCong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BangCongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
        //    cm.Parameters.AddWithValue("@MaBangCong", _maBangCong);
        //    cm.Parameters.AddWithValue("@MaCa", _maCa);
        //    cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
        //    cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);
        //    if (_gioIn.Length > 0)
        //        cm.Parameters.AddWithValue("@GioIn", _gioIn);
        //    else
        //        cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
        //    if (_gioOut.Length > 0)
        //        cm.Parameters.AddWithValue("@GioOut", _gioOut);
        //    else
        //        cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
        //    if (_sogioHc != 0)
        //        cm.Parameters.AddWithValue("@SoGio_HC", _sogioHc);
        //    else
        //        cm.Parameters.AddWithValue("@SoGio_HC", DBNull.Value);
        //    if (_userModify != false)
        //        cm.Parameters.AddWithValue("@UserModify", _userModify);
        //    else
        //        cm.Parameters.AddWithValue("@UserModify", DBNull.Value);
        //    if (_maNguoiLap != 0)
        //        cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
        //    else
        //        cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
        //    cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
        //    if (_khoaSo != false)
        //        cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
        //    else
        //        cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
        //    if (_loaiNgay != 0)
        //        cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
        //    else
        //        cm.Parameters.AddWithValue("@LoaiNgay", DBNull.Value);
        //    if (_suaDLChamCong != 0)
        //        cm.Parameters.AddWithValue("@SuaDLChamCong", _suaDLChamCong);
        //    else
        //        cm.Parameters.AddWithValue("@SuaDLChamCong", DBNull.Value);
        //    if (_tangCaNgay != 0)
        //        cm.Parameters.AddWithValue("@TangCaNgay", _tangCaNgay);
        //    else
        //        cm.Parameters.AddWithValue("@TangCaNgay", DBNull.Value);
        //    if (_tangCaDem != 0)
        //        cm.Parameters.AddWithValue("@TangCaDem", _tangCaDem);
        //    else
        //        cm.Parameters.AddWithValue("@TangCaDem", DBNull.Value);
        //    if (_tangCaNgayCN != 0)
        //        cm.Parameters.AddWithValue("@TangCaNgayCN", _tangCaNgayCN);
        //    else
        //        cm.Parameters.AddWithValue("@TangCaNgayCN", DBNull.Value);
        //    if (_thoiGianHanhChinh != 0)
        //        cm.Parameters.AddWithValue("@ThoiGianHanhChinh", _thoiGianHanhChinh);
        //    else
        //        cm.Parameters.AddWithValue("@ThoiGianHanhChinh", DBNull.Value);
        //    cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
        //    if (_tenNhanVien.Length > 0)
        //        cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
        //    else
        //        cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
        //    if (_maQuanLyNhanVien.Length > 0)
        //        cm.Parameters.AddWithValue("@MaQuanLyNhanVien", _maQuanLyNhanVien);
        //    else
        //        cm.Parameters.AddWithValue("@MaQuanLyNhanVien", DBNull.Value);
        }
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, BangCongList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, BangCongList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_TinhCong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BangCongList parent)
		{
            cm.Parameters.AddWithValue("@MaBangCong", _maBangCong);
            //cm.Parameters.AddWithValue("@GioIn",_gioIn);
            //cm.Parameters.AddWithValue("@GioOut", _gioOut);

            //cm.Parameters.AddWithValue("@MaCa", _maCa);
            //cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            //cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);

            if (_gioIn.Length > 0)
                cm.Parameters.AddWithValue("@GioIn", _gioIn);
            else
                cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
            if (_gioOut.Length > 0)
                cm.Parameters.AddWithValue("@GioOut", _gioOut);
            else
                cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
            //if (_sogioHc != 0)
            //    cm.Parameters.AddWithValue("@SoGio_HC", _sogioHc);
            //else
            //    cm.Parameters.AddWithValue("@SoGio_HC", DBNull.Value);
            //if (_userModify != false)
            //    cm.Parameters.AddWithValue("@UserModify", _userModify);
            //else
            //    cm.Parameters.AddWithValue("@UserModify", DBNull.Value);
            //if (_maNguoiLap != 0)
            //    cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            //else
            //    cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
            //cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            //if (_khoaSo != false)
            //    cm.Parameters.AddWithValue("@KhoaSo", _khoaSo);
            //else
            //    cm.Parameters.AddWithValue("@KhoaSo", DBNull.Value);
            //if (_loaiNgay != 0)
            //    cm.Parameters.AddWithValue("@LoaiNgay", _loaiNgay);
            //else
            //    cm.Parameters.AddWithValue("@LoaiNgay", DBNull.Value);
            //if (_suaDLChamCong != 0)
            //    cm.Parameters.AddWithValue("@SuaDLChamCong", _suaDLChamCong);
            //else
            //    cm.Parameters.AddWithValue("@SuaDLChamCong", DBNull.Value);
            //if (_tangCaNgay != 0)
            //    cm.Parameters.AddWithValue("@TangCaNgay", _tangCaNgay);
            //else
            //    cm.Parameters.AddWithValue("@TangCaNgay", DBNull.Value);
            //if (_tangCaDem != 0)
            //    cm.Parameters.AddWithValue("@TangCaDem", _tangCaDem);
            //else
            //    cm.Parameters.AddWithValue("@TangCaDem", DBNull.Value);
            //if (_tangCaNgayCN != 0)
            //    cm.Parameters.AddWithValue("@TangCaNgayCN", _tangCaNgayCN);
            //else
            //    cm.Parameters.AddWithValue("@TangCaNgayCN", DBNull.Value);
            //if (_thoiGianHanhChinh != 0)
            //    cm.Parameters.AddWithValue("@ThoiGianHanhChinh", _thoiGianHanhChinh);
            //else
            //    cm.Parameters.AddWithValue("@ThoiGianHanhChinh", DBNull.Value);
            //cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            //if (_tenNhanVien.Length > 0)
            //    cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            //else
            //    cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            //if (_maQuanLyNhanVien.Length > 0)
            //    cm.Parameters.AddWithValue("@MaQuanLyNhanVien", _maQuanLyNhanVien);
            //else
            //    cm.Parameters.AddWithValue("@MaQuanLyNhanVien", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria());
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access       
 
    }
}

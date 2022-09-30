using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.ComponentModel;


namespace ERP_Library
{
    [TypeConverter(typeof(HeThongTaiKhoanTypeConverter))]
    public class HeThongTaiKhoan : BusinessBase<HeThongTaiKhoan>
    {
        protected override object GetIdValue()
        {
            return _maTaiKhoan;
        }

        #region Contructor
        private HeThongTaiKhoan()
        {
            //_DoiTuong = true;
            //_LoaiSoDuCo = true;
            //_LoaiSoDuNo = true;
            //_LoaiTK = LoaiTaiKhoan.NewLoaiTaiKhoan();
            //_SoDuCoDauNam = 0;
            //_SoDuNoDauNam = 0;
            //_SoHieuTK = String.Empty;
            //_TaiKhoanCha = string.Empty;
            //_TenTaiKhoan = String.Empty;
            //MarkAsChild();
        }
        #endregion

        #region rule
        protected override void AddBusinessRules()
        {
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "SoHieuTK");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringMaxLength,
               new Csla.Validation.CommonRules.MaxLengthRuleArgs("SoHieuTK", 11));
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenTaiKhoan");
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "LoaiTK");
        }

        #endregion

        #region Business Properties and Methods

		//declare members
		private int _maTaiKhoan = 0;
		private string _soHieuTK = string.Empty;
		private string _tenTaiKhoan = string.Empty;
		private int _maTaiKhoanCha = 0;
		private bool _coDoiTuongTheoDoi = false;
		private bool _loaiSoDuCo = false;
		private bool _loaiSoDuNo = false;
		private decimal _soDuNoDauNam = 0;
		private decimal _soDuCoDauNam = 0;		
		private byte _capTaiKhoan = 0;
        LoaiTaiKhoan _LoaiTK = LoaiTaiKhoan.NewLoaiTaiKhoan();

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTaiKhoan
		{
			get
			{
				CanReadProperty("MaTaiKhoan", true);
				return _maTaiKhoan;
			}
		}

		public string SoHieuTK
		{
			get
			{
				CanReadProperty("SoHieuTK", true);
				return _soHieuTK;
			}
			set
			{
				CanWriteProperty("SoHieuTK", true);
				if (value == null) value = string.Empty;
				if (!_soHieuTK.Equals(value))
				{
					_soHieuTK = value;
					PropertyHasChanged("SoHieuTK");
				}
			}
		}

		public string TenTaiKhoan
		{
			get
			{
				CanReadProperty("TenTaiKhoan", true);
				return _tenTaiKhoan;
			}
			set
			{
				CanWriteProperty("TenTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_tenTaiKhoan.Equals(value))
				{
					_tenTaiKhoan = value;
					PropertyHasChanged("TenTaiKhoan");
				}
			}
		}

		public int MaTaiKhoanCha
		{
			get
			{
				CanReadProperty("MaTaiKhoanCha", true);
				return _maTaiKhoanCha;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanCha", true);
				if (!_maTaiKhoanCha.Equals(value))
				{
					_maTaiKhoanCha = value;
					PropertyHasChanged("MaTaiKhoanCha");
				}
			}
		}

		public bool CoDoiTuongTheoDoi
		{
			get
			{
				CanReadProperty("CoDoiTuongTheoDoi", true);
				return _coDoiTuongTheoDoi;
			}
			set
			{
				CanWriteProperty("CoDoiTuongTheoDoi", true);
				if (!_coDoiTuongTheoDoi.Equals(value))
				{
					_coDoiTuongTheoDoi = value;
					PropertyHasChanged("CoDoiTuongTheoDoi");
				}
			}
		}

		public bool LoaiSoDuCo
		{
			get
			{
				CanReadProperty("LoaiSoDuCo", true);
				return _loaiSoDuCo;
			}
			set
			{
				CanWriteProperty("LoaiSoDuCo", true);
				if (!_loaiSoDuCo.Equals(value))
				{
					_loaiSoDuCo = value;
					PropertyHasChanged("LoaiSoDuCo");
				}
			}
		}

		public bool LoaiSoDuNo
		{
			get
			{
				CanReadProperty("LoaiSoDuNo", true);
				return _loaiSoDuNo;
			}
			set
			{
				CanWriteProperty("LoaiSoDuNo", true);
				if (!_loaiSoDuNo.Equals(value))
				{
					_loaiSoDuNo = value;
					PropertyHasChanged("LoaiSoDuNo");
				}
			}
		}

		public decimal SoDuNoDauNam
		{
			get
			{
				CanReadProperty("SoDuNoDauNam", true);
				return _soDuNoDauNam;
			}
			set
			{
				CanWriteProperty("SoDuNoDauNam", true);
				if (!_soDuNoDauNam.Equals(value))
				{
					_soDuNoDauNam = value;
					PropertyHasChanged("SoDuNoDauNam");
				}
			}
		}

		public decimal SoDuCoDauNam
		{
			get
			{
				CanReadProperty("SoDuCoDauNam", true);
				return _soDuCoDauNam;
			}
			set
			{
				CanWriteProperty("SoDuCoDauNam", true);
				if (!_soDuCoDauNam.Equals(value))
				{
					_soDuCoDauNam = value;
					PropertyHasChanged("SoDuCoDauNam");
				}
			}
		}

        
        public LoaiTaiKhoan LoaiTK
        {
            get
            {
                CanReadProperty(true);
                return _LoaiTK;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LoaiTK.Equals(value))
                {
                    _LoaiTK = value;
                    PropertyHasChanged();
                }
            }
        }
        
		public byte CapTaiKhoan
		{
			get
			{
				CanReadProperty("CapTaiKhoan", true);
				return _capTaiKhoan;
			}
			set
			{
				CanWriteProperty("CapTaiKhoan", true);
				if (!_capTaiKhoan.Equals(value))
				{
					_capTaiKhoan = value;
					PropertyHasChanged("CapTaiKhoan");
				}
			}
		}
 
		#endregion //Business Properties and Methods

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int SoHieuTK;

            public Criteria(int  soHieuTK)
            {
                SoHieuTK = soHieuTK;
            }
        }

        private class CriteriaTenTaiKhoan
        {
            // Add criteria here
            public string TenTaiKhoan;

            public CriteriaTenTaiKhoan(string tenTaiKhoan)
            {
                TenTaiKhoan = tenTaiKhoan;
            }
        }
         private class CriteriabyMaTaiKhoan
        {
            // Add criteria here
            public int MaTaiKhoan;

            public CriteriabyMaTaiKhoan(int maTaiKhoan)
            {
                MaTaiKhoan = maTaiKhoan;
            }
        }
        #endregion

        #region Static Methods
        //giống constructor

         public override HeThongTaiKhoan Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria( _maTaiKhoan));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    
         

        /// <summary>
        /// Constructor này dùng cho PhongBanList Load từng Phòng Ban lên
        /// </summary>
        /// <param name="dr">là SafeDataReader của PhongBanList Fetch ra</param>
        private HeThongTaiKhoan(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                _soHieuTK = dr.GetString("SoHieuTK");
                _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
                _coDoiTuongTheoDoi = dr.GetBoolean("CoDoiTuongTheoDoi");
                _loaiSoDuCo = dr.GetBoolean("LoaiSoDuCo");
                _loaiSoDuNo = dr.GetBoolean("LoaiSoDuNo");
                _soDuNoDauNam = dr.GetDecimal("SoDuNoDauNam");
                _soDuCoDauNam = dr.GetDecimal("SoDuCoDauNam");
                _LoaiTK = LoaiTaiKhoan.GetLoaiTaiKhoan(dr.GetInt32("MaLoaiTaiKhoan"));
                _capTaiKhoan = dr.GetByte("CapTaiKhoan");

                //Do tự set value cho ID
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static HeThongTaiKhoan NewHeThongTaiKhoan()
        {
            HeThongTaiKhoan taiKhoan = new HeThongTaiKhoan();
            taiKhoan._soHieuTK = String.Empty;
            taiKhoan._coDoiTuongTheoDoi = false;
            taiKhoan._loaiSoDuCo = false;
            taiKhoan._loaiSoDuNo = false;
            taiKhoan._LoaiTK = LoaiTaiKhoan.NewLoaiTaiKhoan();
            taiKhoan._soDuCoDauNam = 0;
            taiKhoan._soDuNoDauNam = 0;
            taiKhoan._maTaiKhoanCha = 0;
            taiKhoan._tenTaiKhoan = String.Empty;
            taiKhoan.MarkDirty();
            taiKhoan.ValidationRules.CheckRules();            
            return taiKhoan;

        }

        public static HeThongTaiKhoan NewHeThongTaiKhoan(String soHieuTK, Boolean doiTuong, Boolean loaiSoDuco, Boolean loaiSoDuNo, int loaiTK,Decimal soDuDauNamNo, Decimal SoDuDauNamCo, String tenTaiKhoan, String taiKhoanCha )
        {
                HeThongTaiKhoan taiKhoan = new HeThongTaiKhoan();
                taiKhoan._soHieuTK = String.Empty;
                taiKhoan._coDoiTuongTheoDoi = false;
                taiKhoan._loaiSoDuCo = false;
                taiKhoan._loaiSoDuNo = false;
                taiKhoan._LoaiTK = LoaiTaiKhoan.NewLoaiTaiKhoan();
                taiKhoan._soDuCoDauNam = 0;
                taiKhoan._soDuNoDauNam = 0;
                taiKhoan._maTaiKhoanCha = 0;
                taiKhoan._tenTaiKhoan = String.Empty;
                taiKhoan.MarkDirty();
                taiKhoan.ValidationRules.CheckRules();            
                return taiKhoan;
        }

        public static HeThongTaiKhoan GetHeThongTaiKhoan(int  SoHieuTK)
        {
            return (HeThongTaiKhoan)DataPortal.Fetch<HeThongTaiKhoan>(new Criteria(SoHieuTK));
        }

        public static HeThongTaiKhoan GetHeThongTaiKhoanByMaTaiKhoan(int MaTaiKhoan)
        {
            return (HeThongTaiKhoan)DataPortal.Fetch<HeThongTaiKhoan>(new CriteriabyMaTaiKhoan(MaTaiKhoan));
        }

        public static HeThongTaiKhoan GetHeThongTaiKhoan(string tenTaiKhoan)
        {
            return (HeThongTaiKhoan)DataPortal.Fetch<HeThongTaiKhoan>(new CriteriaTenTaiKhoan(tenTaiKhoan));
        }

        internal static HeThongTaiKhoan GetHeThongTaiKhoan(SafeDataReader dr)
        {
            return new HeThongTaiKhoan(dr);            
        }

        public static void DeleteHeThongTaiKhoan(int maTaiKhoan)
        {
            DataPortal.Delete(new Criteria(maTaiKhoan));
        }

        #endregion

        #region Data Access

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                //Criteria crit = (Criteria)criteria;
                
                if (criteria is Criteria)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadMacaBiet_TaiKhoan";
                            cm.Parameters.AddWithValue("@SOHIEUTK", ((Criteria)criteria).SoHieuTK);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                if (dr.Read())
                                {
                                    _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                                    _soHieuTK = dr.GetString("SoHieuTK");
                                    _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                                    _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
                                    _coDoiTuongTheoDoi = dr.GetBoolean("CoDoiTuongTheoDoi");
                                    _loaiSoDuCo = dr.GetBoolean("LoaiSoDuCo");
                                    _loaiSoDuNo = dr.GetBoolean("LoaiSoDuNo");
                                    _soDuNoDauNam = dr.GetDecimal("SoDuNoDauNam");
                                    _soDuCoDauNam = dr.GetDecimal("SoDuCoDauNam");
                                    _capTaiKhoan = dr.GetByte("CapTaiKhoan");
                                    _LoaiTK = LoaiTaiKhoan.GetLoaiTaiKhoan(dr.GetInt32("MaLoaiTaiKhoan"));
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                    }
                }
                else if (criteria is CriteriaTenTaiKhoan)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LaySoHieuTaiKhoan";
                            cm.Parameters.AddWithValue("@SoHieuTK", ((CriteriaTenTaiKhoan)criteria).TenTaiKhoan);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                if (dr.Read())
                                {
                                    _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                                    _soHieuTK = dr.GetString("SoHieuTK");
                                    _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                                    _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
                                    _coDoiTuongTheoDoi = dr.GetBoolean("CoDoiTuongTheoDoi");
                                    _loaiSoDuCo = dr.GetBoolean("LoaiSoDuCo");
                                    _loaiSoDuNo = dr.GetBoolean("LoaiSoDuNo");
                                    _soDuNoDauNam = dr.GetDecimal("SoDuNoDauNam");
                                    _soDuCoDauNam = dr.GetDecimal("SoDuCoDauNam");
                                    _capTaiKhoan = dr.GetByte("CapTaiKhoan");
                                    _LoaiTK = LoaiTaiKhoan.GetLoaiTaiKhoan(dr.GetInt32("MaLoaiTaiKhoan"));
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                    }
                }
                else if (criteria is CriteriabyMaTaiKhoan)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LayTaiKhoanTheoMa";
                            cm.Parameters.AddWithValue("@MaTaiKhoan", ((CriteriabyMaTaiKhoan)criteria).MaTaiKhoan);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                if (dr.Read())
                                {
                                    _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
                                    _soHieuTK = dr.GetString("SoHieuTK");
                                    _tenTaiKhoan = dr.GetString("TenTaiKhoan");
                                    _maTaiKhoanCha = dr.GetInt32("MaTaiKhoanCha");
                                    _coDoiTuongTheoDoi = dr.GetBoolean("CoDoiTuongTheoDoi");
                                    _loaiSoDuCo = dr.GetBoolean("LoaiSoDuCo");
                                    _loaiSoDuNo = dr.GetBoolean("LoaiSoDuNo");
                                    _soDuNoDauNam = dr.GetDecimal("SoDuNoDauNam");
                                    _soDuCoDauNam = dr.GetDecimal("SoDuCoDauNam");
                                    _capTaiKhoan = dr.GetByte("CapTaiKhoan");
                                    _LoaiTK = LoaiTaiKhoan.GetLoaiTaiKhoan(dr.GetInt32("MaLoaiTaiKhoan"));
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                    }
                }
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void DataPortal_Insert()
        {
            using ( SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_TaiKhoan";
                        cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
                        cm.Parameters.AddWithValue("@TenTaiKhoan", _tenTaiKhoan);
                        if (_maTaiKhoanCha == 0)
                        {
                            cm.Parameters.AddWithValue("@SoHieuTKCha", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@SoHieuTKCha", _maTaiKhoanCha);
                        }                        
                        //cm.Parameters.AddWithValue("@SoHieuTKCha", _TaiKhoanCha);
                        cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", _coDoiTuongTheoDoi);
                        cm.Parameters.AddWithValue("@LoaiSoDuCo", _loaiSoDuCo);
                        cm.Parameters.AddWithValue("@LoaiSoDuNo", _loaiSoDuNo);
                        cm.Parameters.AddWithValue("@SoDuNoDauNam", _soDuNoDauNam);
                        cm.Parameters.AddWithValue("@SoDuCoDauNam", _soDuCoDauNam);
                        cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", _LoaiTK.MaLoaiTK);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_TaiKhoan";
                        cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
                        cm.Parameters.AddWithValue("@TenTaiKhoan ", _tenTaiKhoan);
                        if (_maTaiKhoanCha == 0)
                        {
                            cm.Parameters.AddWithValue("@SoHieuTKCha", DBNull.Value);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@SoHieuTKCha", _maTaiKhoanCha);
                        }
                        //cm.Parameters.AddWithValue("@SoHieuTKCha", _TaiKhoanCha);
                        cm.Parameters.AddWithValue("@CoDoiTuongTheoDoi", _coDoiTuongTheoDoi);
                        cm.Parameters.AddWithValue("@LoaiSoDuCo", _loaiSoDuCo);
                        cm.Parameters.AddWithValue("@LoaiSoDuNo", _loaiSoDuNo);
                        cm.Parameters.AddWithValue("@SoDuNoDauNam", _soDuNoDauNam);
                        cm.Parameters.AddWithValue("@SoDuCoDauNam", _soDuCoDauNam);
                        cm.Parameters.AddWithValue("@MaLoaiTaiKhoan", _LoaiTK.MaLoaiTK);
                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_TaiKhoan";
                    cm.Parameters.AddWithValue("@SoHieuTK", _soHieuTK);
                    cm.ExecuteNonQuery();
                }
            }
        }     
              
        #endregion
    }
    #region Type Converter

    public class HeThongTaiKhoanTypeConverter : TypeConverter
    {

        //public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        //{
        //    in temp = (String)value;
        //    return HeThongTaiKhoan.GetHeThongTaiKhoan(temp);
        //}
        //public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        //{
        //    return ((HeThongTaiKhoan)context.Instance).MaHeThongTaiKhoan;
        //}


        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String))
            {
                return true;
            }            
            else return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String))
            {
                return true;
            }            
            else return false;
        }
    }
    #endregion
}

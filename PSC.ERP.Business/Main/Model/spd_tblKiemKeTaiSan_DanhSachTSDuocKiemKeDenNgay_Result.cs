//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//	  Code duoc tao boi DESKTOP-J5VELTF\DELL luc 10:47:32 ngay 24/12/2021
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace PSC_ERP_Business.Main.Model
{
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="PSC_ERPModel", Name="spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result Createspd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result(int id)
        {
            spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result = new spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result();
            spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result.ID = id;
            return spd_tblKiemKeTaiSan_DanhSachTSDuocKiemKeDenNgay_Result;
        }

        #endregion

    #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
    			int oldValue =  _iD;
    			bool stopChanging = false;
                On_ID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ID");
    			if(!stopChanging)
    			{
    				_iD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ID");
    				On_ID_Changed(oldValue, _iD);//\\
    			}
            }
        }
    	public static String ID_PropertyName { get { return "ID"; } }
        private int _iD;
        partial void On_ID_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_ID_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhongBan
        {
            get
            {
                return _maPhongBan;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhongBan;
    			bool stopChanging = false;
                On_MaPhongBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBan");
    			if(!stopChanging)
    			{
    				_maPhongBan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhongBan");
    				On_MaPhongBan_Changed(oldValue, _maPhongBan);//\\
    			}
            }
        }
    	public static String MaPhongBan_PropertyName { get { return "MaPhongBan"; } }
        private Nullable<int> _maPhongBan;
        partial void On_MaPhongBan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhongBan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieuTSCDCaBiet
        {
            get
            {
                return _soHieuTSCDCaBiet;
            }
            set
            {
    			string oldValue =  _soHieuTSCDCaBiet;
    			bool stopChanging = false;
                On_SoHieuTSCDCaBiet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieuTSCDCaBiet");
    			if(!stopChanging)
    			{
    				_soHieuTSCDCaBiet = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieuTSCDCaBiet");
    				On_SoHieuTSCDCaBiet_Changed(oldValue, _soHieuTSCDCaBiet);//\\
    			}
            }
        }
    	public static String SoHieuTSCDCaBiet_PropertyName { get { return "SoHieuTSCDCaBiet"; } }
        private string _soHieuTSCDCaBiet;
        partial void On_SoHieuTSCDCaBiet_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTSCDCaBiet_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaPhongBanQL
        {
            get
            {
                return _maPhongBanQL;
            }
            set
            {
    			string oldValue =  _maPhongBanQL;
    			bool stopChanging = false;
                On_MaPhongBanQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBanQL");
    			if(!stopChanging)
    			{
    				_maPhongBanQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaPhongBanQL");
    				On_MaPhongBanQL_Changed(oldValue, _maPhongBanQL);//\\
    			}
            }
        }
    	public static String MaPhongBanQL_PropertyName { get { return "MaPhongBanQL"; } }
        private string _maPhongBanQL;
        partial void On_MaPhongBanQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaPhongBanQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayKiemKe
        {
            get
            {
                return _ngayKiemKe;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayKiemKe;
    			bool stopChanging = false;
                On_NgayKiemKe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayKiemKe");
    			if(!stopChanging)
    			{
    				_ngayKiemKe = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayKiemKe");
    				On_NgayKiemKe_Changed(oldValue, _ngayKiemKe);//\\
    			}
            }
        }
    	public static String NgayKiemKe_PropertyName { get { return "NgayKiemKe"; } }
        private Nullable<System.DateTime> _ngayKiemKe;
        partial void On_NgayKiemKe_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayKiemKe_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
    			string oldValue =  _filePath;
    			bool stopChanging = false;
                On_FilePath_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("FilePath");
    			if(!stopChanging)
    			{
    				_filePath = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("FilePath");
    				On_FilePath_Changed(oldValue, _filePath);//\\
    			}
            }
        }
    	public static String FilePath_PropertyName { get { return "FilePath"; } }
        private string _filePath;
        partial void On_FilePath_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_FilePath_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			Nullable<int> oldValue =  _userID;
    			bool stopChanging = false;
                On_UserID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserID");
    			if(!stopChanging)
    			{
    				_userID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserID");
    				On_UserID_Changed(oldValue, _userID);//\\
    			}
            }
        }
    	public static String UserID_PropertyName { get { return "UserID"; } }
        private Nullable<int> _userID;
        partial void On_UserID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTSCDCaBiet
        {
            get
            {
                return _maTSCDCaBiet;
            }
            set
            {
    			Nullable<int> oldValue =  _maTSCDCaBiet;
    			bool stopChanging = false;
                On_MaTSCDCaBiet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTSCDCaBiet");
    			if(!stopChanging)
    			{
    				_maTSCDCaBiet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTSCDCaBiet");
    				On_MaTSCDCaBiet_Changed(oldValue, _maTSCDCaBiet);//\\
    			}
            }
        }
    	public static String MaTSCDCaBiet_PropertyName { get { return "MaTSCDCaBiet"; } }
        private Nullable<int> _maTSCDCaBiet;
        partial void On_MaTSCDCaBiet_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTSCDCaBiet_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChiTietTSCDCaBiet
        {
            get
            {
                return _maChiTietTSCDCaBiet;
            }
            set
            {
    			Nullable<int> oldValue =  _maChiTietTSCDCaBiet;
    			bool stopChanging = false;
                On_MaChiTietTSCDCaBiet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChiTietTSCDCaBiet");
    			if(!stopChanging)
    			{
    				_maChiTietTSCDCaBiet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChiTietTSCDCaBiet");
    				On_MaChiTietTSCDCaBiet_Changed(oldValue, _maChiTietTSCDCaBiet);//\\
    			}
            }
        }
    	public static String MaChiTietTSCDCaBiet_PropertyName { get { return "MaChiTietTSCDCaBiet"; } }
        private Nullable<int> _maChiTietTSCDCaBiet;
        partial void On_MaChiTietTSCDCaBiet_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChiTietTSCDCaBiet_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayQuet
        {
            get
            {
                return _ngayQuet;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayQuet;
    			bool stopChanging = false;
                On_NgayQuet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayQuet");
    			if(!stopChanging)
    			{
    				_ngayQuet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayQuet");
    				On_NgayQuet_Changed(oldValue, _ngayQuet);//\\
    			}
            }
        }
    	public static String NgayQuet_PropertyName { get { return "NgayQuet"; } }
        private Nullable<System.DateTime> _ngayQuet;
        partial void On_NgayQuet_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayQuet_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> DaQuet
        {
            get
            {
                return _daQuet;
            }
            set
            {
    			Nullable<bool> oldValue =  _daQuet;
    			bool stopChanging = false;
                On_DaQuet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DaQuet");
    			if(!stopChanging)
    			{
    				_daQuet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DaQuet");
    				On_DaQuet_Changed(oldValue, _daQuet);//\\
    			}
            }
        }
    	public static String DaQuet_PropertyName { get { return "DaQuet"; } }
        private Nullable<bool> _daQuet;
        partial void On_DaQuet_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_DaQuet_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Ten
        {
            get
            {
                return _ten;
            }
            set
            {
    			string oldValue =  _ten;
    			bool stopChanging = false;
                On_Ten_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Ten");
    			if(!stopChanging)
    			{
    				_ten = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Ten");
    				On_Ten_Changed(oldValue, _ten);//\\
    			}
            }
        }
    	public static String Ten_PropertyName { get { return "Ten"; } }
        private string _ten;
        partial void On_Ten_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Ten_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> LaTaiSan
        {
            get
            {
                return _laTaiSan;
            }
            set
            {
    			Nullable<bool> oldValue =  _laTaiSan;
    			bool stopChanging = false;
                On_LaTaiSan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LaTaiSan");
    			if(!stopChanging)
    			{
    				_laTaiSan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LaTaiSan");
    				On_LaTaiSan_Changed(oldValue, _laTaiSan);//\\
    			}
            }
        }
    	public static String LaTaiSan_PropertyName { get { return "LaTaiSan"; } }
        private Nullable<bool> _laTaiSan;
        partial void On_LaTaiSan_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_LaTaiSan_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NguyenGiaBanDau
        {
            get
            {
                return _nguyenGiaBanDau;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nguyenGiaBanDau;
    			bool stopChanging = false;
                On_NguyenGiaBanDau_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguyenGiaBanDau");
    			if(!stopChanging)
    			{
    				_nguyenGiaBanDau = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguyenGiaBanDau");
    				On_NguyenGiaBanDau_Changed(oldValue, _nguyenGiaBanDau);//\\
    			}
            }
        }
    	public static String NguyenGiaBanDau_PropertyName { get { return "NguyenGiaBanDau"; } }
        private Nullable<decimal> _nguyenGiaBanDau;
        partial void On_NguyenGiaBanDau_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NguyenGiaBanDau_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GiaTriMoiNhat
        {
            get
            {
                return _giaTriMoiNhat;
            }
            set
            {
    			Nullable<decimal> oldValue =  _giaTriMoiNhat;
    			bool stopChanging = false;
                On_GiaTriMoiNhat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GiaTriMoiNhat");
    			if(!stopChanging)
    			{
    				_giaTriMoiNhat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GiaTriMoiNhat");
    				On_GiaTriMoiNhat_Changed(oldValue, _giaTriMoiNhat);//\\
    			}
            }
        }
    	public static String GiaTriMoiNhat_PropertyName { get { return "GiaTriMoiNhat"; } }
        private Nullable<decimal> _giaTriMoiNhat;
        partial void On_GiaTriMoiNhat_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GiaTriMoiNhat_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GiaTriConLai
        {
            get
            {
                return _giaTriConLai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _giaTriConLai;
    			bool stopChanging = false;
                On_GiaTriConLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GiaTriConLai");
    			if(!stopChanging)
    			{
    				_giaTriConLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GiaTriConLai");
    				On_GiaTriConLai_Changed(oldValue, _giaTriConLai);//\\
    			}
            }
        }
    	public static String GiaTriConLai_PropertyName { get { return "GiaTriConLai"; } }
        private Nullable<decimal> _giaTriConLai;
        partial void On_GiaTriConLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GiaTriConLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgaySuDung
        {
            get
            {
                return _ngaySuDung;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngaySuDung;
    			bool stopChanging = false;
                On_NgaySuDung_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgaySuDung");
    			if(!stopChanging)
    			{
    				_ngaySuDung = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgaySuDung");
    				On_NgaySuDung_Changed(oldValue, _ngaySuDung);//\\
    			}
            }
        }
    	public static String NgaySuDung_PropertyName { get { return "NgaySuDung"; } }
        private Nullable<System.DateTime> _ngaySuDung;
        partial void On_NgaySuDung_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgaySuDung_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoSerial
        {
            get
            {
                return _soSerial;
            }
            set
            {
    			string oldValue =  _soSerial;
    			bool stopChanging = false;
                On_SoSerial_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoSerial");
    			if(!stopChanging)
    			{
    				_soSerial = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoSerial");
    				On_SoSerial_Changed(oldValue, _soSerial);//\\
    			}
            }
        }
    	public static String SoSerial_PropertyName { get { return "SoSerial"; } }
        private string _soSerial;
        partial void On_SoSerial_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoSerial_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> TaiSanThua
        {
            get
            {
                return _taiSanThua;
            }
            set
            {
    			Nullable<bool> oldValue =  _taiSanThua;
    			bool stopChanging = false;
                On_TaiSanThua_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiSanThua");
    			if(!stopChanging)
    			{
    				_taiSanThua = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiSanThua");
    				On_TaiSanThua_Changed(oldValue, _taiSanThua);//\\
    			}
            }
        }
    	public static String TaiSanThua_PropertyName { get { return "TaiSanThua"; } }
        private Nullable<bool> _taiSanThua;
        partial void On_TaiSanThua_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_TaiSanThua_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
    			string oldValue =  _ghiChu;
    			bool stopChanging = false;
                On_GhiChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChu");
    			if(!stopChanging)
    			{
    				_ghiChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChu");
    				On_GhiChu_Changed(oldValue, _ghiChu);//\\
    			}
            }
        }
    	public static String GhiChu_PropertyName { get { return "GhiChu"; } }
        private string _ghiChu;
        partial void On_GhiChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaViTri
        {
            get
            {
                return _maViTri;
            }
            set
            {
    			Nullable<int> oldValue =  _maViTri;
    			bool stopChanging = false;
                On_MaViTri_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaViTri");
    			if(!stopChanging)
    			{
    				_maViTri = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaViTri");
    				On_MaViTri_Changed(oldValue, _maViTri);//\\
    			}
            }
        }
    	public static String MaViTri_PropertyName { get { return "MaViTri"; } }
        private Nullable<int> _maViTri;
        partial void On_MaViTri_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaViTri_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaViTriQL
        {
            get
            {
                return _maViTriQL;
            }
            set
            {
    			string oldValue =  _maViTriQL;
    			bool stopChanging = false;
                On_MaViTriQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaViTriQL");
    			if(!stopChanging)
    			{
    				_maViTriQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaViTriQL");
    				On_MaViTriQL_Changed(oldValue, _maViTriQL);//\\
    			}
            }
        }
    	public static String MaViTriQL_PropertyName { get { return "MaViTriQL"; } }
        private string _maViTriQL;
        partial void On_MaViTriQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaViTriQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenViTri
        {
            get
            {
                return _tenViTri;
            }
            set
            {
    			string oldValue =  _tenViTri;
    			bool stopChanging = false;
                On_TenViTri_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenViTri");
    			if(!stopChanging)
    			{
    				_tenViTri = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenViTri");
    				On_TenViTri_Changed(oldValue, _tenViTri);//\\
    			}
            }
        }
    	public static String TenViTri_PropertyName { get { return "TenViTri"; } }
        private string _tenViTri;
        partial void On_TenViTri_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenViTri_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
    			Nullable<int> oldValue =  _maCongTy;
    			bool stopChanging = false;
                On_MaCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaCongTy");
    			if(!stopChanging)
    			{
    				_maCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaCongTy");
    				On_MaCongTy_Changed(oldValue, _maCongTy);//\\
    			}
            }
        }
    	public static String MaCongTy_PropertyName { get { return "MaCongTy"; } }
        private Nullable<int> _maCongTy;
        partial void On_MaCongTy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaCongTy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
    			string oldValue =  _tinhTrang;
    			bool stopChanging = false;
                On_TinhTrang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TinhTrang");
    			if(!stopChanging)
    			{
    				_tinhTrang = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TinhTrang");
    				On_TinhTrang_Changed(oldValue, _tinhTrang);//\\
    			}
            }
        }
    	public static String TinhTrang_PropertyName { get { return "TinhTrang"; } }
        private string _tinhTrang;
        partial void On_TinhTrang_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TinhTrang_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaViTriKiemKe
        {
            get
            {
                return _maViTriKiemKe;
            }
            set
            {
    			Nullable<int> oldValue =  _maViTriKiemKe;
    			bool stopChanging = false;
                On_MaViTriKiemKe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaViTriKiemKe");
    			if(!stopChanging)
    			{
    				_maViTriKiemKe = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaViTriKiemKe");
    				On_MaViTriKiemKe_Changed(oldValue, _maViTriKiemKe);//\\
    			}
            }
        }
    	public static String MaViTriKiemKe_PropertyName { get { return "MaViTriKiemKe"; } }
        private Nullable<int> _maViTriKiemKe;
        partial void On_MaViTriKiemKe_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaViTriKiemKe_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChuChung
        {
            get
            {
                return _ghiChuChung;
            }
            set
            {
    			string oldValue =  _ghiChuChung;
    			bool stopChanging = false;
                On_GhiChuChung_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChuChung");
    			if(!stopChanging)
    			{
    				_ghiChuChung = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChuChung");
    				On_GhiChuChung_Changed(oldValue, _ghiChuChung);//\\
    			}
            }
        }
    	public static String GhiChuChung_PropertyName { get { return "GhiChuChung"; } }
        private string _ghiChuChung;
        partial void On_GhiChuChung_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChuChung_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TrangthaiSauKiemKe
        {
            get
            {
                return _trangthaiSauKiemKe;
            }
            set
            {
    			string oldValue =  _trangthaiSauKiemKe;
    			bool stopChanging = false;
                On_TrangthaiSauKiemKe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TrangthaiSauKiemKe");
    			if(!stopChanging)
    			{
    				_trangthaiSauKiemKe = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TrangthaiSauKiemKe");
    				On_TrangthaiSauKiemKe_Changed(oldValue, _trangthaiSauKiemKe);//\\
    			}
            }
        }
    	public static String TrangthaiSauKiemKe_PropertyName { get { return "TrangthaiSauKiemKe"; } }
        private string _trangthaiSauKiemKe;
        partial void On_TrangthaiSauKiemKe_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TrangthaiSauKiemKe_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TinhTrangKiemKe
        {
            get
            {
                return _tinhTrangKiemKe;
            }
            set
            {
    			string oldValue =  _tinhTrangKiemKe;
    			bool stopChanging = false;
                On_TinhTrangKiemKe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TinhTrangKiemKe");
    			if(!stopChanging)
    			{
    				_tinhTrangKiemKe = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TinhTrangKiemKe");
    				On_TinhTrangKiemKe_Changed(oldValue, _tinhTrangKiemKe);//\\
    			}
            }
        }
    	public static String TinhTrangKiemKe_PropertyName { get { return "TinhTrangKiemKe"; } }
        private string _tinhTrangKiemKe;
        partial void On_TinhTrangKiemKe_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TinhTrangKiemKe_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DeXuatSauXuLy
        {
            get
            {
                return _deXuatSauXuLy;
            }
            set
            {
    			string oldValue =  _deXuatSauXuLy;
    			bool stopChanging = false;
                On_DeXuatSauXuLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DeXuatSauXuLy");
    			if(!stopChanging)
    			{
    				_deXuatSauXuLy = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DeXuatSauXuLy");
    				On_DeXuatSauXuLy_Changed(oldValue, _deXuatSauXuLy);//\\
    			}
            }
        }
    	public static String DeXuatSauXuLy_PropertyName { get { return "DeXuatSauXuLy"; } }
        private string _deXuatSauXuLy;
        partial void On_DeXuatSauXuLy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DeXuatSauXuLy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> isDaXuLy
        {
            get
            {
                return _isDaXuLy;
            }
            set
            {
    			Nullable<bool> oldValue =  _isDaXuLy;
    			bool stopChanging = false;
                On_isDaXuLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("isDaXuLy");
    			if(!stopChanging)
    			{
    				_isDaXuLy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("isDaXuLy");
    				On_isDaXuLy_Changed(oldValue, _isDaXuLy);//\\
    			}
            }
        }
    	public static String isDaXuLy_PropertyName { get { return "isDaXuLy"; } }
        private Nullable<bool> _isDaXuLy;
        partial void On_isDaXuLy_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_isDaXuLy_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieuCu
        {
            get
            {
                return _soHieuCu;
            }
            set
            {
    			string oldValue =  _soHieuCu;
    			bool stopChanging = false;
                On_SoHieuCu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieuCu");
    			if(!stopChanging)
    			{
    				_soHieuCu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieuCu");
    				On_SoHieuCu_Changed(oldValue, _soHieuCu);//\\
    			}
            }
        }
    	public static String SoHieuCu_PropertyName { get { return "SoHieuCu"; } }
        private string _soHieuCu;
        partial void On_SoHieuCu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuCu_Changed(string oldValue, string currentValue);

    #endregion

    }
}

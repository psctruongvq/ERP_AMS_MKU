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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ChungTuAll")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ChungTuAll : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ChungTuAll()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ChungTuAll object.
        /// </summary>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        /// <param name="soChungTu">Initial value of the SoChungTu property.</param>
        /// <param name="tKNO">Initial value of the TKNO property.</param>
        /// <param name="tKCo">Initial value of the TKCo property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        /// <param name="maButToan">Initial value of the MaButToan property.</param>
        public static v_ChungTuAll Createv_ChungTuAll(long maChungTu, string soChungTu, string tKNO, string tKCo, decimal soTien, int maBoPhan, int maButToan)
        {
            v_ChungTuAll v_ChungTuAll = new v_ChungTuAll();
            v_ChungTuAll.MaChungTu = maChungTu;
            v_ChungTuAll.SoChungTu = soChungTu;
            v_ChungTuAll.TKNO = tKNO;
            v_ChungTuAll.TKCo = tKCo;
            v_ChungTuAll.SoTien = soTien;
            v_ChungTuAll.MaBoPhan = maBoPhan;
            v_ChungTuAll.MaButToan = maButToan;
            return v_ChungTuAll;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
                if (_maChungTu != value)
                {
        			long oldValue =  _maChungTu;
        			bool stopChanging = false;
                    On_MaChungTu_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChungTu");
        			if(!stopChanging)
        			{
        				_maChungTu = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChungTu");
        				On_MaChungTu_Changed(oldValue, _maChungTu);//\\
        			}
                }
            }
        }
    	public static String MaChungTu_PropertyName { get { return "MaChungTu"; } }
        private long _maChungTu;
        partial void On_MaChungTu_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
            set
            {
                if (_soChungTu != value)
                {
        			string oldValue =  _soChungTu;
        			bool stopChanging = false;
                    On_SoChungTu_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("SoChungTu");
        			if(!stopChanging)
        			{
        				_soChungTu = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("SoChungTu");
        				On_SoChungTu_Changed(oldValue, _soChungTu);//\\
        			}
                }
            }
        }
    	public static String SoChungTu_PropertyName { get { return "SoChungTu"; } }
        private string _soChungTu;
        partial void On_SoChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayLap;
    			bool stopChanging = false;
                On_NgayLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayLap");
    			if(!stopChanging)
    			{
    				_ngayLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayLap");
    				On_NgayLap_Changed(oldValue, _ngayLap);//\\
    			}
            }
        }
    	public static String NgayLap_PropertyName { get { return "NgayLap"; } }
        private Nullable<System.DateTime> _ngayLap;
        partial void On_NgayLap_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayLap_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThanhTien
        {
            get
            {
                return _thanhTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thanhTien;
    			bool stopChanging = false;
                On_ThanhTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThanhTien");
    			if(!stopChanging)
    			{
    				_thanhTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThanhTien");
    				On_ThanhTien_Changed(oldValue, _thanhTien);//\\
    			}
            }
        }
    	public static String ThanhTien_PropertyName { get { return "ThanhTien"; } }
        private Nullable<decimal> _thanhTien;
        partial void On_ThanhTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThanhTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
            set
            {
    			string oldValue =  _dienGiai;
    			bool stopChanging = false;
                On_DienGiai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DienGiai");
    			if(!stopChanging)
    			{
    				_dienGiai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DienGiai");
    				On_DienGiai_Changed(oldValue, _dienGiai);//\\
    			}
            }
        }
    	public static String DienGiai_PropertyName { get { return "DienGiai"; } }
        private string _dienGiai;
        partial void On_DienGiai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DienGiai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TKNO
        {
            get
            {
                return _tKNO;
            }
            set
            {
                if (_tKNO != value)
                {
        			string oldValue =  _tKNO;
        			bool stopChanging = false;
                    On_TKNO_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TKNO");
        			if(!stopChanging)
        			{
        				_tKNO = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TKNO");
        				On_TKNO_Changed(oldValue, _tKNO);//\\
        			}
                }
            }
        }
    	public static String TKNO_PropertyName { get { return "TKNO"; } }
        private string _tKNO;
        partial void On_TKNO_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TKNO_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TKCo
        {
            get
            {
                return _tKCo;
            }
            set
            {
                if (_tKCo != value)
                {
        			string oldValue =  _tKCo;
        			bool stopChanging = false;
                    On_TKCo_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TKCo");
        			if(!stopChanging)
        			{
        				_tKCo = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TKCo");
        				On_TKCo_Changed(oldValue, _tKCo);//\\
        			}
                }
            }
        }
    	public static String TKCo_PropertyName { get { return "TKCo"; } }
        private string _tKCo;
        partial void On_TKCo_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TKCo_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (_soTien != value)
                {
        			decimal oldValue =  _soTien;
        			bool stopChanging = false;
                    On_SoTien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("SoTien");
        			if(!stopChanging)
        			{
        				_soTien = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("SoTien");
        				On_SoTien_Changed(oldValue, _soTien);//\\
        			}
                }
            }
        }
    	public static String SoTien_PropertyName { get { return "SoTien"; } }
        private decimal _soTien;
        partial void On_SoTien_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string KHTrong
        {
            get
            {
                return _kHTrong;
            }
            set
            {
    			string oldValue =  _kHTrong;
    			bool stopChanging = false;
                On_KHTrong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KHTrong");
    			if(!stopChanging)
    			{
    				_kHTrong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("KHTrong");
    				On_KHTrong_Changed(oldValue, _kHTrong);//\\
    			}
            }
        }
    	public static String KHTrong_PropertyName { get { return "KHTrong"; } }
        private string _kHTrong;
        partial void On_KHTrong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_KHTrong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DCTrong
        {
            get
            {
                return _dCTrong;
            }
            set
            {
    			string oldValue =  _dCTrong;
    			bool stopChanging = false;
                On_DCTrong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DCTrong");
    			if(!stopChanging)
    			{
    				_dCTrong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DCTrong");
    				On_DCTrong_Changed(oldValue, _dCTrong);//\\
    			}
            }
        }
    	public static String DCTrong_PropertyName { get { return "DCTrong"; } }
        private string _dCTrong;
        partial void On_DCTrong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DCTrong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string KHNgoai
        {
            get
            {
                return _kHNgoai;
            }
            set
            {
    			string oldValue =  _kHNgoai;
    			bool stopChanging = false;
                On_KHNgoai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KHNgoai");
    			if(!stopChanging)
    			{
    				_kHNgoai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("KHNgoai");
    				On_KHNgoai_Changed(oldValue, _kHNgoai);//\\
    			}
            }
        }
    	public static String KHNgoai_PropertyName { get { return "KHNgoai"; } }
        private string _kHNgoai;
        partial void On_KHNgoai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_KHNgoai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DCNgoai
        {
            get
            {
                return _dCNgoai;
            }
            set
            {
    			string oldValue =  _dCNgoai;
    			bool stopChanging = false;
                On_DCNgoai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DCNgoai");
    			if(!stopChanging)
    			{
    				_dCNgoai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DCNgoai");
    				On_DCNgoai_Changed(oldValue, _dCNgoai);//\\
    			}
            }
        }
    	public static String DCNgoai_PropertyName { get { return "DCNgoai"; } }
        private string _dCNgoai;
        partial void On_DCNgoai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DCNgoai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNguoiLap
        {
            get
            {
                return _maNguoiLap;
            }
            set
            {
    			Nullable<int> oldValue =  _maNguoiLap;
    			bool stopChanging = false;
                On_MaNguoiLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNguoiLap");
    			if(!stopChanging)
    			{
    				_maNguoiLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNguoiLap");
    				On_MaNguoiLap_Changed(oldValue, _maNguoiLap);//\\
    			}
            }
        }
    	public static String MaNguoiLap_PropertyName { get { return "MaNguoiLap"; } }
        private Nullable<int> _maNguoiLap;
        partial void On_MaNguoiLap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNguoiLap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (_maBoPhan != value)
                {
        			int oldValue =  _maBoPhan;
        			bool stopChanging = false;
                    On_MaBoPhan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaBoPhan");
        			if(!stopChanging)
        			{
        				_maBoPhan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaBoPhan");
        				On_MaBoPhan_Changed(oldValue, _maBoPhan);//\\
        			}
                }
            }
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private int _maBoPhan;
        partial void On_MaBoPhan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
            set
            {
    			string oldValue =  _tenBoPhan;
    			bool stopChanging = false;
                On_TenBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhan");
    			if(!stopChanging)
    			{
    				_tenBoPhan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhan");
    				On_TenBoPhan_Changed(oldValue, _tenBoPhan);//\\
    			}
            }
        }
    	public static String TenBoPhan_PropertyName { get { return "TenBoPhan"; } }
        private string _tenBoPhan;
        partial void On_TenBoPhan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaDinhKhoan
        {
            get
            {
                return _maDinhKhoan;
            }
            set
            {
    			Nullable<int> oldValue =  _maDinhKhoan;
    			bool stopChanging = false;
                On_MaDinhKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDinhKhoan");
    			if(!stopChanging)
    			{
    				_maDinhKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDinhKhoan");
    				On_MaDinhKhoan_Changed(oldValue, _maDinhKhoan);//\\
    			}
            }
        }
    	public static String MaDinhKhoan_PropertyName { get { return "MaDinhKhoan"; } }
        private Nullable<int> _maDinhKhoan;
        partial void On_MaDinhKhoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDinhKhoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaButToan
        {
            get
            {
                return _maButToan;
            }
            set
            {
                if (_maButToan != value)
                {
        			int oldValue =  _maButToan;
        			bool stopChanging = false;
                    On_MaButToan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaButToan");
        			if(!stopChanging)
        			{
        				_maButToan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaButToan");
        				On_MaButToan_Changed(oldValue, _maButToan);//\\
        			}
                }
            }
        }
    	public static String MaButToan_PropertyName { get { return "MaButToan"; } }
        private int _maButToan;
        partial void On_MaButToan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaButToan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhanDangNhap
        {
            get
            {
                return _maBoPhanDangNhap;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhanDangNhap;
    			bool stopChanging = false;
                On_MaBoPhanDangNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanDangNhap");
    			if(!stopChanging)
    			{
    				_maBoPhanDangNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhanDangNhap");
    				On_MaBoPhanDangNhap_Changed(oldValue, _maBoPhanDangNhap);//\\
    			}
            }
        }
    	public static String MaBoPhanDangNhap_PropertyName { get { return "MaBoPhanDangNhap"; } }
        private Nullable<int> _maBoPhanDangNhap;
        partial void On_MaBoPhanDangNhap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhanDangNhap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhanDangNhap
        {
            get
            {
                return _tenBoPhanDangNhap;
            }
            set
            {
    			string oldValue =  _tenBoPhanDangNhap;
    			bool stopChanging = false;
                On_TenBoPhanDangNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhanDangNhap");
    			if(!stopChanging)
    			{
    				_tenBoPhanDangNhap = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhanDangNhap");
    				On_TenBoPhanDangNhap_Changed(oldValue, _tenBoPhanDangNhap);//\\
    			}
            }
        }
    	public static String TenBoPhanDangNhap_PropertyName { get { return "TenBoPhanDangNhap"; } }
        private string _tenBoPhanDangNhap;
        partial void On_TenBoPhanDangNhap_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhanDangNhap_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiDoiTuong
        {
            get
            {
                return _maLoaiDoiTuong;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiDoiTuong;
    			bool stopChanging = false;
                On_MaLoaiDoiTuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiDoiTuong");
    			if(!stopChanging)
    			{
    				_maLoaiDoiTuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiDoiTuong");
    				On_MaLoaiDoiTuong_Changed(oldValue, _maLoaiDoiTuong);//\\
    			}
            }
        }
    	public static String MaLoaiDoiTuong_PropertyName { get { return "MaLoaiDoiTuong"; } }
        private Nullable<int> _maLoaiDoiTuong;
        partial void On_MaLoaiDoiTuong_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiDoiTuong_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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

        #endregion

    }
}

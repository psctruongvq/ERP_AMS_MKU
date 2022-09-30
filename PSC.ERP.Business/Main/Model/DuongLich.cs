//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//	  Code duoc tao boi DESKTOP-J5VELTF\DELL luc 10:47:31 ngay 24/12/2021
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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="DuongLich")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DuongLich : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public DuongLich()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new DuongLich object.
        /// </summary>
        /// <param name="maQLNhanVien">Initial value of the MaQLNhanVien property.</param>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="maNganHang">Initial value of the MaNganHang property.</param>
        public static DuongLich CreateDuongLich(string maQLNhanVien, long maNhanVien, int maNganHang)
        {
            DuongLich duongLich = new DuongLich();
            duongLich.MaQLNhanVien = maQLNhanVien;
            duongLich.MaNhanVien = maNhanVien;
            duongLich.MaNganHang = maNganHang;
            return duongLich;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
            set
            {
    			string oldValue =  _maBoPhanQL;
    			bool stopChanging = false;
                On_MaBoPhanQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanQL");
    			if(!stopChanging)
    			{
    				_maBoPhanQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaBoPhanQL");
    				On_MaBoPhanQL_Changed(oldValue, _maBoPhanQL);//\\
    			}
            }
        }
    	public static String MaBoPhanQL_PropertyName { get { return "MaBoPhanQL"; } }
        private string _maBoPhanQL;
        partial void On_MaBoPhanQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaBoPhanQL_Changed(string oldValue, string currentValue);
    
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
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set
            {
    			string oldValue =  _tenNhanVien;
    			bool stopChanging = false;
                On_TenNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhanVien");
    			if(!stopChanging)
    			{
    				_tenNhanVien = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNhanVien");
    				On_TenNhanVien_Changed(oldValue, _tenNhanVien);//\\
    			}
            }
        }
    	public static String TenNhanVien_PropertyName { get { return "TenNhanVien"; } }
        private string _tenNhanVien;
        partial void On_TenNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
            set
            {
                if (_maQLNhanVien != value)
                {
        			string oldValue =  _maQLNhanVien;
        			bool stopChanging = false;
                    On_MaQLNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaQLNhanVien");
        			if(!stopChanging)
        			{
        				_maQLNhanVien = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaQLNhanVien");
        				On_MaQLNhanVien_Changed(oldValue, _maQLNhanVien);//\\
        			}
                }
            }
        }
    	public static String MaQLNhanVien_PropertyName { get { return "MaQLNhanVien"; } }
        private string _maQLNhanVien;
        partial void On_MaQLNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (_maNhanVien != value)
                {
        			long oldValue =  _maNhanVien;
        			bool stopChanging = false;
                    On_MaNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNhanVien");
        			if(!stopChanging)
        			{
        				_maNhanVien = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNhanVien");
        				On_MaNhanVien_Changed(oldValue, _maNhanVien);//\\
        			}
                }
            }
        }
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private long _maNhanVien;
        partial void On_MaNhanVien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTien;
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
    	public static String SoTien_PropertyName { get { return "SoTien"; } }
        private Nullable<decimal> _soTien;
        partial void On_SoTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThuNhap;
    			bool stopChanging = false;
                On_TongThuNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThuNhap");
    			if(!stopChanging)
    			{
    				_tongThuNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThuNhap");
    				On_TongThuNhap_Changed(oldValue, _tongThuNhap);//\\
    			}
            }
        }
    	public static String TongThuNhap_PropertyName { get { return "TongThuNhap"; } }
        private Nullable<decimal> _tongThuNhap;
        partial void On_TongThuNhap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThuNhap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThuNhapChiuThue
        {
            get
            {
                return _thuNhapChiuThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thuNhapChiuThue;
    			bool stopChanging = false;
                On_ThuNhapChiuThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThuNhapChiuThue");
    			if(!stopChanging)
    			{
    				_thuNhapChiuThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThuNhapChiuThue");
    				On_ThuNhapChiuThue_Changed(oldValue, _thuNhapChiuThue);//\\
    			}
            }
        }
    	public static String ThuNhapChiuThue_PropertyName { get { return "ThuNhapChiuThue"; } }
        private Nullable<decimal> _thuNhapChiuThue;
        partial void On_ThuNhapChiuThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThuNhapChiuThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> BaoHiemBatBuoc
        {
            get
            {
                return _baoHiemBatBuoc;
            }
            set
            {
    			Nullable<decimal> oldValue =  _baoHiemBatBuoc;
    			bool stopChanging = false;
                On_BaoHiemBatBuoc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("BaoHiemBatBuoc");
    			if(!stopChanging)
    			{
    				_baoHiemBatBuoc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("BaoHiemBatBuoc");
    				On_BaoHiemBatBuoc_Changed(oldValue, _baoHiemBatBuoc);//\\
    			}
            }
        }
    	public static String BaoHiemBatBuoc_PropertyName { get { return "BaoHiemBatBuoc"; } }
        private Nullable<decimal> _baoHiemBatBuoc;
        partial void On_BaoHiemBatBuoc_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_BaoHiemBatBuoc_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThuNhapTinhThue
        {
            get
            {
                return _thuNhapTinhThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thuNhapTinhThue;
    			bool stopChanging = false;
                On_ThuNhapTinhThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThuNhapTinhThue");
    			if(!stopChanging)
    			{
    				_thuNhapTinhThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThuNhapTinhThue");
    				On_ThuNhapTinhThue_Changed(oldValue, _thuNhapTinhThue);//\\
    			}
            }
        }
    	public static String ThuNhapTinhThue_PropertyName { get { return "ThuNhapTinhThue"; } }
        private Nullable<decimal> _thuNhapTinhThue;
        partial void On_ThuNhapTinhThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThuNhapTinhThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoThuePhaiNop
        {
            get
            {
                return _soThuePhaiNop;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soThuePhaiNop;
    			bool stopChanging = false;
                On_SoThuePhaiNop_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoThuePhaiNop");
    			if(!stopChanging)
    			{
    				_soThuePhaiNop = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoThuePhaiNop");
    				On_SoThuePhaiNop_Changed(oldValue, _soThuePhaiNop);//\\
    			}
            }
        }
    	public static String SoThuePhaiNop_PropertyName { get { return "SoThuePhaiNop"; } }
        private Nullable<decimal> _soThuePhaiNop;
        partial void On_SoThuePhaiNop_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoThuePhaiNop_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueNLDDaNop
        {
            get
            {
                return _thueNLDDaNop;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueNLDDaNop;
    			bool stopChanging = false;
                On_ThueNLDDaNop_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueNLDDaNop");
    			if(!stopChanging)
    			{
    				_thueNLDDaNop = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueNLDDaNop");
    				On_ThueNLDDaNop_Changed(oldValue, _thueNLDDaNop);//\\
    			}
            }
        }
    	public static String ThueNLDDaNop_PropertyName { get { return "ThueNLDDaNop"; } }
        private Nullable<decimal> _thueNLDDaNop;
        partial void On_ThueNLDDaNop_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueNLDDaNop_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueNLDNopThem
        {
            get
            {
                return _thueNLDNopThem;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueNLDNopThem;
    			bool stopChanging = false;
                On_ThueNLDNopThem_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueNLDNopThem");
    			if(!stopChanging)
    			{
    				_thueNLDNopThem = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueNLDNopThem");
    				On_ThueNLDNopThem_Changed(oldValue, _thueNLDNopThem);//\\
    			}
            }
        }
    	public static String ThueNLDNopThem_PropertyName { get { return "ThueNLDNopThem"; } }
        private Nullable<decimal> _thueNLDNopThem;
        partial void On_ThueNLDNopThem_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueNLDNopThem_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueNLDTraLai
        {
            get
            {
                return _thueNLDTraLai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueNLDTraLai;
    			bool stopChanging = false;
                On_ThueNLDTraLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueNLDTraLai");
    			if(!stopChanging)
    			{
    				_thueNLDTraLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueNLDTraLai");
    				On_ThueNLDTraLai_Changed(oldValue, _thueNLDTraLai);//\\
    			}
            }
        }
    	public static String ThueNLDTraLai_PropertyName { get { return "ThueNLDTraLai"; } }
        private Nullable<decimal> _thueNLDTraLai;
        partial void On_ThueNLDTraLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueNLDTraLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string CMND
        {
            get
            {
                return _cMND;
            }
            set
            {
    			string oldValue =  _cMND;
    			bool stopChanging = false;
                On_CMND_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CMND");
    			if(!stopChanging)
    			{
    				_cMND = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("CMND");
    				On_CMND_Changed(oldValue, _cMND);//\\
    			}
            }
        }
    	public static String CMND_PropertyName { get { return "CMND"; } }
        private string _cMND;
        partial void On_CMND_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_CMND_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
            set
            {
    			string oldValue =  _soTaiKhoan;
    			bool stopChanging = false;
                On_SoTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTaiKhoan");
    			if(!stopChanging)
    			{
    				_soTaiKhoan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoTaiKhoan");
    				On_SoTaiKhoan_Changed(oldValue, _soTaiKhoan);//\\
    			}
            }
        }
    	public static String SoTaiKhoan_PropertyName { get { return "SoTaiKhoan"; } }
        private string _soTaiKhoan;
        partial void On_SoTaiKhoan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoTaiKhoan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenNganHang
        {
            get
            {
                return _tenNganHang;
            }
            set
            {
    			string oldValue =  _tenNganHang;
    			bool stopChanging = false;
                On_TenNganHang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNganHang");
    			if(!stopChanging)
    			{
    				_tenNganHang = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNganHang");
    				On_TenNganHang_Changed(oldValue, _tenNganHang);//\\
    			}
            }
        }
    	public static String TenNganHang_PropertyName { get { return "TenNganHang"; } }
        private string _tenNganHang;
        partial void On_TenNganHang_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNganHang_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNganHang
        {
            get
            {
                return _maNganHang;
            }
            set
            {
                if (_maNganHang != value)
                {
        			int oldValue =  _maNganHang;
        			bool stopChanging = false;
                    On_MaNganHang_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNganHang");
        			if(!stopChanging)
        			{
        				_maNganHang = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNganHang");
        				On_MaNganHang_Changed(oldValue, _maNganHang);//\\
        			}
                }
            }
        }
    	public static String MaNganHang_PropertyName { get { return "MaNganHang"; } }
        private int _maNganHang;
        partial void On_MaNganHang_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNganHang_Changed(int oldValue, int currentValue);

        #endregion

    }
}

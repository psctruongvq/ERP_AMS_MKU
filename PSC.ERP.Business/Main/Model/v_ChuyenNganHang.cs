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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ChuyenNganHang")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ChuyenNganHang : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ChuyenNganHang()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ChuyenNganHang object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="tienThue">Initial value of the TienThue property.</param>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        /// <param name="ngayLap">Initial value of the NgayLap property.</param>
        public static v_ChuyenNganHang Createv_ChuyenNganHang(long maNhanVien, decimal tienThue, int maBoPhan, System.DateTime ngayLap)
        {
            v_ChuyenNganHang v_ChuyenNganHang = new v_ChuyenNganHang();
            v_ChuyenNganHang.MaNhanVien = maNhanVien;
            v_ChuyenNganHang.TienThue = tienThue;
            v_ChuyenNganHang.MaBoPhan = maBoPhan;
            v_ChuyenNganHang.NgayLap = ngayLap;
            return v_ChuyenNganHang;
        }

        #endregion

        #region Primitive Properties
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
                if (_tienThue != value)
                {
        			decimal oldValue =  _tienThue;
        			bool stopChanging = false;
                    On_TienThue_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TienThue");
        			if(!stopChanging)
        			{
        				_tienThue = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("TienThue");
        				On_TienThue_Changed(oldValue, _tienThue);//\\
        			}
                }
            }
        }
    	public static String TienThue_PropertyName { get { return "TienThue"; } }
        private decimal _tienThue;
        partial void On_TienThue_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_TienThue_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienChuyenTrongDot
        {
            get
            {
                return _soTienChuyenTrongDot;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienChuyenTrongDot;
    			bool stopChanging = false;
                On_SoTienChuyenTrongDot_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienChuyenTrongDot");
    			if(!stopChanging)
    			{
    				_soTienChuyenTrongDot = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienChuyenTrongDot");
    				On_SoTienChuyenTrongDot_Changed(oldValue, _soTienChuyenTrongDot);//\\
    			}
            }
        }
    	public static String SoTienChuyenTrongDot_PropertyName { get { return "SoTienChuyenTrongDot"; } }
        private Nullable<decimal> _soTienChuyenTrongDot;
        partial void On_SoTienChuyenTrongDot_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienChuyenTrongDot_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
                if (_ngayLap != value)
                {
        			System.DateTime oldValue =  _ngayLap;
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
        }
    	public static String NgayLap_PropertyName { get { return "NgayLap"; } }
        private System.DateTime _ngayLap;
        partial void On_NgayLap_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_NgayLap_Changed(System.DateTime oldValue, System.DateTime currentValue);

        #endregion

    }
}
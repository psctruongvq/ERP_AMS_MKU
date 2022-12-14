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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="ChonNguonBCTHKinhPhiVaQuyetToanKP")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ChonNguonBCTHKinhPhiVaQuyetToanKP : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public ChonNguonBCTHKinhPhiVaQuyetToanKP()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new ChonNguonBCTHKinhPhiVaQuyetToanKP object.
        /// </summary>
        /// <param name="maNguon">Initial value of the MaNguon property.</param>
        /// <param name="tenNguon">Initial value of the TenNguon property.</param>
        public static ChonNguonBCTHKinhPhiVaQuyetToanKP CreateChonNguonBCTHKinhPhiVaQuyetToanKP(int maNguon, string tenNguon)
        {
            ChonNguonBCTHKinhPhiVaQuyetToanKP chonNguonBCTHKinhPhiVaQuyetToanKP = new ChonNguonBCTHKinhPhiVaQuyetToanKP();
            chonNguonBCTHKinhPhiVaQuyetToanKP.MaNguon = maNguon;
            chonNguonBCTHKinhPhiVaQuyetToanKP.TenNguon = tenNguon;
            return chonNguonBCTHKinhPhiVaQuyetToanKP;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNguon
        {
            get
            {
                return _maNguon;
            }
            set
            {
                if (_maNguon != value)
                {
        			int oldValue =  _maNguon;
        			bool stopChanging = false;
                    On_MaNguon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNguon");
        			if(!stopChanging)
        			{
        				_maNguon = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNguon");
        				On_MaNguon_Changed(oldValue, _maNguon);//\\
        			}
                }
            }
        }
    	public static String MaNguon_PropertyName { get { return "MaNguon"; } }
        private int _maNguon;
        partial void On_MaNguon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNguon_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNguon
        {
            get
            {
                return _tenNguon;
            }
            set
            {
                if (_tenNguon != value)
                {
        			string oldValue =  _tenNguon;
        			bool stopChanging = false;
                    On_TenNguon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenNguon");
        			if(!stopChanging)
        			{
        				_tenNguon = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenNguon");
        				On_TenNguon_Changed(oldValue, _tenNguon);//\\
        			}
                }
            }
        }
    	public static String TenNguon_PropertyName { get { return "TenNguon"; } }
        private string _tenNguon;
        partial void On_TenNguon_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNguon_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaNguonQuanLy
        {
            get
            {
                return _maNguonQuanLy;
            }
            set
            {
    			string oldValue =  _maNguonQuanLy;
    			bool stopChanging = false;
                On_MaNguonQuanLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNguonQuanLy");
    			if(!stopChanging)
    			{
    				_maNguonQuanLy = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaNguonQuanLy");
    				On_MaNguonQuanLy_Changed(oldValue, _maNguonQuanLy);//\\
    			}
            }
        }
    	public static String MaNguonQuanLy_PropertyName { get { return "MaNguonQuanLy"; } }
        private string _maNguonQuanLy;
        partial void On_MaNguonQuanLy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaNguonQuanLy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhan;
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
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private Nullable<int> _maBoPhan;
        partial void On_MaBoPhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> MaHoatDong
        {
            get
            {
                return _maHoatDong;
            }
            set
            {
    			Nullable<int> oldValue =  _maHoatDong;
    			bool stopChanging = false;
                On_MaHoatDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHoatDong");
    			if(!stopChanging)
    			{
    				_maHoatDong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHoatDong");
    				On_MaHoatDong_Changed(oldValue, _maHoatDong);//\\
    			}
            }
        }
    	public static String MaHoatDong_PropertyName { get { return "MaHoatDong"; } }
        private Nullable<int> _maHoatDong;
        partial void On_MaHoatDong_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaHoatDong_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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

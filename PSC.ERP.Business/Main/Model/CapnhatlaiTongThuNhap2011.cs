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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="CapnhatlaiTongThuNhap2011")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CapnhatlaiTongThuNhap2011 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public CapnhatlaiTongThuNhap2011()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new CapnhatlaiTongThuNhap2011 object.
        /// </summary>
        /// <param name="manhanvien">Initial value of the manhanvien property.</param>
        public static CapnhatlaiTongThuNhap2011 CreateCapnhatlaiTongThuNhap2011(long manhanvien)
        {
            CapnhatlaiTongThuNhap2011 capnhatlaiTongThuNhap2011 = new CapnhatlaiTongThuNhap2011();
            capnhatlaiTongThuNhap2011.manhanvien = manhanvien;
            return capnhatlaiTongThuNhap2011;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long manhanvien
        {
            get
            {
                return _manhanvien;
            }
            set
            {
                if (_manhanvien != value)
                {
        			long oldValue =  _manhanvien;
        			bool stopChanging = false;
                    On_manhanvien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("manhanvien");
        			if(!stopChanging)
        			{
        				_manhanvien = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("manhanvien");
        				On_manhanvien_Changed(oldValue, _manhanvien);//\\
        			}
                }
            }
        }
    	public static String manhanvien_PropertyName { get { return "manhanvien"; } }
        private long _manhanvien;
        partial void On_manhanvien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_manhanvien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> LuongKy1
        {
            get
            {
                return _luongKy1;
            }
            set
            {
    			Nullable<decimal> oldValue =  _luongKy1;
    			bool stopChanging = false;
                On_LuongKy1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LuongKy1");
    			if(!stopChanging)
    			{
    				_luongKy1 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LuongKy1");
    				On_LuongKy1_Changed(oldValue, _luongKy1);//\\
    			}
            }
        }
    	public static String LuongKy1_PropertyName { get { return "LuongKy1"; } }
        private Nullable<decimal> _luongKy1;
        partial void On_LuongKy1_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LuongKy1_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> LuongHeSo
        {
            get
            {
                return _luongHeSo;
            }
            set
            {
    			Nullable<decimal> oldValue =  _luongHeSo;
    			bool stopChanging = false;
                On_LuongHeSo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LuongHeSo");
    			if(!stopChanging)
    			{
    				_luongHeSo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LuongHeSo");
    				On_LuongHeSo_Changed(oldValue, _luongHeSo);//\\
    			}
            }
        }
    	public static String LuongHeSo_PropertyName { get { return "LuongHeSo"; } }
        private Nullable<decimal> _luongHeSo;
        partial void On_LuongHeSo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LuongHeSo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThuLao
        {
            get
            {
                return _thuLao;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thuLao;
    			bool stopChanging = false;
                On_ThuLao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThuLao");
    			if(!stopChanging)
    			{
    				_thuLao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThuLao");
    				On_ThuLao_Changed(oldValue, _thuLao);//\\
    			}
            }
        }
    	public static String ThuLao_PropertyName { get { return "ThuLao"; } }
        private Nullable<decimal> _thuLao;
        partial void On_ThuLao_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThuLao_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> PhuCap
        {
            get
            {
                return _phuCap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _phuCap;
    			bool stopChanging = false;
                On_PhuCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PhuCap");
    			if(!stopChanging)
    			{
    				_phuCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PhuCap");
    				On_PhuCap_Changed(oldValue, _phuCap);//\\
    			}
            }
        }
    	public static String PhuCap_PropertyName { get { return "PhuCap"; } }
        private Nullable<decimal> _phuCap;
        partial void On_PhuCap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_PhuCap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThamNien
        {
            get
            {
                return _thamNien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thamNien;
    			bool stopChanging = false;
                On_ThamNien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThamNien");
    			if(!stopChanging)
    			{
    				_thamNien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThamNien");
    				On_ThamNien_Changed(oldValue, _thamNien);//\\
    			}
            }
        }
    	public static String ThamNien_PropertyName { get { return "ThamNien"; } }
        private Nullable<decimal> _thamNien;
        partial void On_ThamNien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThamNien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<decimal> TongThuNhapChiuThue
        {
            get
            {
                return _tongThuNhapChiuThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThuNhapChiuThue;
    			bool stopChanging = false;
                On_TongThuNhapChiuThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThuNhapChiuThue");
    			if(!stopChanging)
    			{
    				_tongThuNhapChiuThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThuNhapChiuThue");
    				On_TongThuNhapChiuThue_Changed(oldValue, _tongThuNhapChiuThue);//\\
    			}
            }
        }
    	public static String TongThuNhapChiuThue_PropertyName { get { return "TongThuNhapChiuThue"; } }
        private Nullable<decimal> _tongThuNhapChiuThue;
        partial void On_TongThuNhapChiuThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThuNhapChiuThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}
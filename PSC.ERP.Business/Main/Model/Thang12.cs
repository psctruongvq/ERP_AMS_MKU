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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="Thang12")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Thang12 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public Thang12()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new Thang12 object.
        /// </summary>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        public static Thang12 CreateThang12(int maBoPhan)
        {
            Thang12 thang12 = new Thang12();
            thang12.MaBoPhan = maBoPhan;
            return thang12;
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
        public Nullable<long> MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVien;
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
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private Nullable<long> _maNhanVien;
        partial void On_MaNhanVien_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoThang
        {
            get
            {
                return _soThang;
            }
            set
            {
    			Nullable<int> oldValue =  _soThang;
    			bool stopChanging = false;
                On_SoThang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoThang");
    			if(!stopChanging)
    			{
    				_soThang = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoThang");
    				On_SoThang_Changed(oldValue, _soThang);//\\
    			}
            }
        }
    	public static String SoThang_PropertyName { get { return "SoThang"; } }
        private Nullable<int> _soThang;
        partial void On_SoThang_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoThang_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> DaNop
        {
            get
            {
                return _daNop;
            }
            set
            {
    			Nullable<decimal> oldValue =  _daNop;
    			bool stopChanging = false;
                On_DaNop_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DaNop");
    			if(!stopChanging)
    			{
    				_daNop = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DaNop");
    				On_DaNop_Changed(oldValue, _daNop);//\\
    			}
            }
        }
    	public static String DaNop_PropertyName { get { return "DaNop"; } }
        private Nullable<decimal> _daNop;
        partial void On_DaNop_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_DaNop_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongTienThue
        {
            get
            {
                return _tongTienThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongTienThue;
    			bool stopChanging = false;
                On_TongTienThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongTienThue");
    			if(!stopChanging)
    			{
    				_tongTienThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongTienThue");
    				On_TongTienThue_Changed(oldValue, _tongTienThue);//\\
    			}
            }
        }
    	public static String TongTienThue_PropertyName { get { return "TongTienThue"; } }
        private Nullable<decimal> _tongTienThue;
        partial void On_TongTienThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongTienThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}
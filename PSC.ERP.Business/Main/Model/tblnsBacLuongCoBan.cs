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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsBacLuongCoBan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsBacLuongCoBan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsBacLuongCoBan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsBacLuongCoBan object.
        /// </summary>
        /// <param name="maBacLuongCoBan">Initial value of the MaBacLuongCoBan property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        /// <param name="heSoLuong">Initial value of the HeSoLuong property.</param>
        /// <param name="maNgachLuongCB">Initial value of the MaNgachLuongCB property.</param>
        public static tblnsBacLuongCoBan CreatetblnsBacLuongCoBan(int maBacLuongCoBan, string maQuanLy, decimal heSoLuong, int maNgachLuongCB)
        {
            tblnsBacLuongCoBan tblnsBacLuongCoBan = new tblnsBacLuongCoBan();
            tblnsBacLuongCoBan.MaBacLuongCoBan = maBacLuongCoBan;
            tblnsBacLuongCoBan.MaQuanLy = maQuanLy;
            tblnsBacLuongCoBan.HeSoLuong = heSoLuong;
            tblnsBacLuongCoBan.MaNgachLuongCB = maNgachLuongCB;
            return tblnsBacLuongCoBan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBacLuongCoBan
        {
            get
            {
                return _maBacLuongCoBan;
            }
            set
            {
                if (_maBacLuongCoBan != value)
                {
        			int oldValue =  _maBacLuongCoBan;
        			bool stopChanging = false;
                    On_MaBacLuongCoBan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaBacLuongCoBan");
        			if(!stopChanging)
        			{
        				_maBacLuongCoBan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaBacLuongCoBan");
        				On_MaBacLuongCoBan_Changed(oldValue, _maBacLuongCoBan);//\\
        			}
                }
            }
        }
    	public static String MaBacLuongCoBan_PropertyName { get { return "MaBacLuongCoBan"; } }
        private int _maBacLuongCoBan;
        partial void On_MaBacLuongCoBan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBacLuongCoBan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
    			string oldValue =  _maQuanLy;
    			bool stopChanging = false;
                On_MaQuanLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuanLy");
    			if(!stopChanging)
    			{
    				_maQuanLy = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("MaQuanLy");
    				On_MaQuanLy_Changed(oldValue, _maQuanLy);//\\
    			}
            }
        }
    	public static String MaQuanLy_PropertyName { get { return "MaQuanLy"; } }
        private string _maQuanLy;
        partial void On_MaQuanLy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQuanLy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal HeSoLuong
        {
            get
            {
                return _heSoLuong;
            }
            set
            {
    			decimal oldValue =  _heSoLuong;
    			bool stopChanging = false;
                On_HeSoLuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HeSoLuong");
    			if(!stopChanging)
    			{
    				_heSoLuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HeSoLuong");
    				On_HeSoLuong_Changed(oldValue, _heSoLuong);//\\
    			}
            }
        }
    	public static String HeSoLuong_PropertyName { get { return "HeSoLuong"; } }
        private decimal _heSoLuong;
        partial void On_HeSoLuong_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_HeSoLuong_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNgachLuongCB
        {
            get
            {
                return _maNgachLuongCB;
            }
            set
            {
    			int oldValue =  _maNgachLuongCB;
    			bool stopChanging = false;
                On_MaNgachLuongCB_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNgachLuongCB");
    			if(!stopChanging)
    			{
    				_maNgachLuongCB = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNgachLuongCB");
    				On_MaNgachLuongCB_Changed(oldValue, _maNgachLuongCB);//\\
    			}
            }
        }
    	public static String MaNgachLuongCB_PropertyName { get { return "MaNgachLuongCB"; } }
        private int _maNgachLuongCB;
        partial void On_MaNgachLuongCB_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNgachLuongCB_Changed(int oldValue, int currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThoiGianNangBac
        {
            get
            {
                return _thoiGianNangBac;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thoiGianNangBac;
    			bool stopChanging = false;
                On_ThoiGianNangBac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiGianNangBac");
    			if(!stopChanging)
    			{
    				_thoiGianNangBac = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiGianNangBac");
    				On_ThoiGianNangBac_Changed(oldValue, _thoiGianNangBac);//\\
    			}
            }
        }
    	public static String ThoiGianNangBac_PropertyName { get { return "ThoiGianNangBac"; } }
        private Nullable<decimal> _thoiGianNangBac;
        partial void On_ThoiGianNangBac_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThoiGianNangBac_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DonViThoiGian
        {
            get
            {
                return _donViThoiGian;
            }
            set
            {
    			string oldValue =  _donViThoiGian;
    			bool stopChanging = false;
                On_DonViThoiGian_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DonViThoiGian");
    			if(!stopChanging)
    			{
    				_donViThoiGian = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DonViThoiGian");
    				On_DonViThoiGian_Changed(oldValue, _donViThoiGian);//\\
    			}
            }
        }
    	public static String DonViThoiGian_PropertyName { get { return "DonViThoiGian"; } }
        private string _donViThoiGian;
        partial void On_DonViThoiGian_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DonViThoiGian_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoThuTu
        {
            get
            {
                return _soThuTu;
            }
            set
            {
    			Nullable<int> oldValue =  _soThuTu;
    			bool stopChanging = false;
                On_SoThuTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoThuTu");
    			if(!stopChanging)
    			{
    				_soThuTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoThuTu");
    				On_SoThuTu_Changed(oldValue, _soThuTu);//\\
    			}
            }
        }
    	public static String SoThuTu_PropertyName { get { return "SoThuTu"; } }
        private Nullable<int> _soThuTu;
        partial void On_SoThuTu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoThuTu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBacLuongCoBan
        {
            get
            {
                return _tenBacLuongCoBan;
            }
            set
            {
    			string oldValue =  _tenBacLuongCoBan;
    			bool stopChanging = false;
                On_TenBacLuongCoBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBacLuongCoBan");
    			if(!stopChanging)
    			{
    				_tenBacLuongCoBan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBacLuongCoBan");
    				On_TenBacLuongCoBan_Changed(oldValue, _tenBacLuongCoBan);//\\
    			}
            }
        }
    	public static String TenBacLuongCoBan_PropertyName { get { return "TenBacLuongCoBan"; } }
        private string _tenBacLuongCoBan;
        partial void On_TenBacLuongCoBan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBacLuongCoBan_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsBacLuongCoBan_tblnsNgachLuongCoBan", "tblnsNgachLuongCoBan")]
        public tblnsNgachLuongCoBan tblnsNgachLuongCoBan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsBacLuongCoBan_tblnsNgachLuongCoBan", "tblnsNgachLuongCoBan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsNgachLuongCoBan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsBacLuongCoBan_tblnsNgachLuongCoBan", "tblnsNgachLuongCoBan").Value = value;
    				On_tblnsNgachLuongCoBan_Changed(this.tblnsNgachLuongCoBan);//\\//
    			}
    	    }
        }
    	public static String tblnsNgachLuongCoBan_ReferencePropertyName { get { return "tblnsNgachLuongCoBan"; } }
    	partial void On_tblnsNgachLuongCoBan_Changing(ref tblnsNgachLuongCoBan newValue, ref bool stopChanging);
    	partial void On_tblnsNgachLuongCoBan_Changed(tblnsNgachLuongCoBan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsNgachLuongCoBan> tblnsNgachLuongCoBanReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsBacLuongCoBan_tblnsNgachLuongCoBan", "tblnsNgachLuongCoBan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsBacLuongCoBan_tblnsNgachLuongCoBan", "tblnsNgachLuongCoBan", value);
                }
            }
        }

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD object.
        /// </summary>
        /// <param name="maChiTiet">Initial value of the MaChiTiet property.</param>
        public static tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD CreatetblCT_NVThanhLyvaDieuChuyenNgoaiTSCD(int maChiTiet)
        {
            tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD = new tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD();
            tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD.MaChiTiet = maChiTiet;
            return tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
            set
            {
                if (_maChiTiet != value)
                {
        			int oldValue =  _maChiTiet;
        			bool stopChanging = false;
                    On_MaChiTiet_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChiTiet");
        			if(!stopChanging)
        			{
        				_maChiTiet = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChiTiet");
        				On_MaChiTiet_Changed(oldValue, _maChiTiet);//\\
        			}
                }
            }
        }
    	public static String MaChiTiet_PropertyName { get { return "MaChiTiet"; } }
        private int _maChiTiet;
        partial void On_MaChiTiet_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChiTiet_Changed(int oldValue, int currentValue);
    
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
        public Nullable<int> MaNghiepVuThanhLy
        {
            get
            {
                return _maNghiepVuThanhLy;
            }
            set
            {
    			Nullable<int> oldValue =  _maNghiepVuThanhLy;
    			bool stopChanging = false;
                On_MaNghiepVuThanhLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNghiepVuThanhLy");
    			if(!stopChanging)
    			{
    				_maNghiepVuThanhLy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNghiepVuThanhLy");
    				On_MaNghiepVuThanhLy_Changed(oldValue, _maNghiepVuThanhLy);//\\
    			}
            }
        }
    	public static String MaNghiepVuThanhLy_PropertyName { get { return "MaNghiepVuThanhLy"; } }
        private Nullable<int> _maNghiepVuThanhLy;
        partial void On_MaNghiepVuThanhLy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNghiepVuThanhLy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChoDuyetTSCD
        {
            get
            {
                return _maChoDuyetTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _maChoDuyetTSCD;
    			bool stopChanging = false;
                On_MaChoDuyetTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChoDuyetTSCD");
    			if(!stopChanging)
    			{
    				_maChoDuyetTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChoDuyetTSCD");
    				On_MaChoDuyetTSCD_Changed(oldValue, _maChoDuyetTSCD);//\\
    			}
            }
        }
    	public static String MaChoDuyetTSCD_PropertyName { get { return "MaChoDuyetTSCD"; } }
        private Nullable<int> _maChoDuyetTSCD;
        partial void On_MaChoDuyetTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChoDuyetTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblDuyetTSCD")]
        public tblDuyetTSCD tblDuyetTSCD
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblDuyetTSCD").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblDuyetTSCD_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblDuyetTSCD").Value = value;
    				On_tblDuyetTSCD_Changed(this.tblDuyetTSCD);//\\//
    			}
    	    }
        }
    	public static String tblDuyetTSCD_ReferencePropertyName { get { return "tblDuyetTSCD"; } }
    	partial void On_tblDuyetTSCD_Changing(ref tblDuyetTSCD newValue, ref bool stopChanging);
    	partial void On_tblDuyetTSCD_Changed(tblDuyetTSCD currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblDuyetTSCD> tblDuyetTSCDReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblDuyetTSCD");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblDuyetTSCD", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblNVThanhLyvaDieuChuyenNgoaiTSCD", "tblNVThanhLyvaDieuChuyenNgoaiTSCD")]
        public tblNVThanhLyvaDieuChuyenNgoaiTSCD tblNVThanhLyvaDieuChuyenNgoaiTSCD
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblNVThanhLyvaDieuChuyenNgoaiTSCD", "tblNVThanhLyvaDieuChuyenNgoaiTSCD").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblNVThanhLyvaDieuChuyenNgoaiTSCD_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblNVThanhLyvaDieuChuyenNgoaiTSCD", "tblNVThanhLyvaDieuChuyenNgoaiTSCD").Value = value;
    				On_tblNVThanhLyvaDieuChuyenNgoaiTSCD_Changed(this.tblNVThanhLyvaDieuChuyenNgoaiTSCD);//\\//
    			}
    	    }
        }
    	public static String tblNVThanhLyvaDieuChuyenNgoaiTSCD_ReferencePropertyName { get { return "tblNVThanhLyvaDieuChuyenNgoaiTSCD"; } }
    	partial void On_tblNVThanhLyvaDieuChuyenNgoaiTSCD_Changing(ref tblNVThanhLyvaDieuChuyenNgoaiTSCD newValue, ref bool stopChanging);
    	partial void On_tblNVThanhLyvaDieuChuyenNgoaiTSCD_Changed(tblNVThanhLyvaDieuChuyenNgoaiTSCD currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblNVThanhLyvaDieuChuyenNgoaiTSCD> tblNVThanhLyvaDieuChuyenNgoaiTSCDReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblNVThanhLyvaDieuChuyenNgoaiTSCD", "tblNVThanhLyvaDieuChuyenNgoaiTSCD");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblNVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblNVThanhLyvaDieuChuyenNgoaiTSCD", "tblNVThanhLyvaDieuChuyenNgoaiTSCD", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet")]
        public tblTaiSanCoDinhCaBiet tblTaiSanCoDinhCaBiet
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiSanCoDinhCaBiet_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value = value;
    				On_tblTaiSanCoDinhCaBiet_Changed(this.tblTaiSanCoDinhCaBiet);//\\//
    			}
    	    }
        }
    	public static String tblTaiSanCoDinhCaBiet_ReferencePropertyName { get { return "tblTaiSanCoDinhCaBiet"; } }
    	partial void On_tblTaiSanCoDinhCaBiet_Changing(ref tblTaiSanCoDinhCaBiet newValue, ref bool stopChanging);
    	partial void On_tblTaiSanCoDinhCaBiet_Changed(tblTaiSanCoDinhCaBiet currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblTaiSanCoDinhCaBiet> tblTaiSanCoDinhCaBietReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet", value);
                }
            }
        }

        #endregion

    }
}
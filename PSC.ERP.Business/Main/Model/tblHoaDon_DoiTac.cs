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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblHoaDon_DoiTac")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblHoaDon_DoiTac : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblHoaDon_DoiTac()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblHoaDon_DoiTac object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="maHoaDon">Initial value of the MaHoaDon property.</param>
        public static tblHoaDon_DoiTac CreatetblHoaDon_DoiTac(long id, long maHoaDon)
        {
            tblHoaDon_DoiTac tblHoaDon_DoiTac = new tblHoaDon_DoiTac();
            tblHoaDon_DoiTac.ID = id;
            tblHoaDon_DoiTac.MaHoaDon = maHoaDon;
            return tblHoaDon_DoiTac;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long ID
        {
            get
            {
                return _iD;
            }
            set
            {
                if (_iD != value)
                {
        			long oldValue =  _iD;
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
        }
    	public static String ID_PropertyName { get { return "ID"; } }
        private long _iD;
        partial void On_ID_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_ID_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaHoaDon
        {
            get
            {
                return _maHoaDon;
            }
            set
            {
    			long oldValue =  _maHoaDon;
    			bool stopChanging = false;
                On_MaHoaDon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHoaDon");
    			if(!stopChanging)
    			{
    				_maHoaDon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHoaDon");
    				On_MaHoaDon_Changed(oldValue, _maHoaDon);//\\
    			}
            }
        }
    	public static String MaHoaDon_PropertyName { get { return "MaHoaDon"; } }
        private long _maHoaDon;
        partial void On_MaHoaDon_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaHoaDon_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenDoiTac
        {
            get
            {
                return _tenDoiTac;
            }
            set
            {
    			string oldValue =  _tenDoiTac;
    			bool stopChanging = false;
                On_TenDoiTac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenDoiTac");
    			if(!stopChanging)
    			{
    				_tenDoiTac = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenDoiTac");
    				On_TenDoiTac_Changed(oldValue, _tenDoiTac);//\\
    			}
            }
        }
    	public static String TenDoiTac_PropertyName { get { return "TenDoiTac"; } }
        private string _tenDoiTac;
        partial void On_TenDoiTac_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenDoiTac_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
    			string oldValue =  _diaChi;
    			bool stopChanging = false;
                On_DiaChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DiaChi");
    			if(!stopChanging)
    			{
    				_diaChi = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DiaChi");
    				On_DiaChi_Changed(oldValue, _diaChi);//\\
    			}
            }
        }
    	public static String DiaChi_PropertyName { get { return "DiaChi"; } }
        private string _diaChi;
        partial void On_DiaChi_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DiaChi_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MSThue
        {
            get
            {
                return _mSThue;
            }
            set
            {
    			string oldValue =  _mSThue;
    			bool stopChanging = false;
                On_MSThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MSThue");
    			if(!stopChanging)
    			{
    				_mSThue = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MSThue");
    				On_MSThue_Changed(oldValue, _mSThue);//\\
    			}
            }
        }
    	public static String MSThue_PropertyName { get { return "MSThue"; } }
        private string _mSThue;
        partial void On_MSThue_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MSThue_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string NguoiLienHe
        {
            get
            {
                return _nguoiLienHe;
            }
            set
            {
    			string oldValue =  _nguoiLienHe;
    			bool stopChanging = false;
                On_NguoiLienHe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguoiLienHe");
    			if(!stopChanging)
    			{
    				_nguoiLienHe = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("NguoiLienHe");
    				On_NguoiLienHe_Changed(oldValue, _nguoiLienHe);//\\
    			}
            }
        }
    	public static String NguoiLienHe_PropertyName { get { return "NguoiLienHe"; } }
        private string _nguoiLienHe;
        partial void On_NguoiLienHe_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_NguoiLienHe_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DienThoai
        {
            get
            {
                return _dienThoai;
            }
            set
            {
    			string oldValue =  _dienThoai;
    			bool stopChanging = false;
                On_DienThoai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DienThoai");
    			if(!stopChanging)
    			{
    				_dienThoai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DienThoai");
    				On_DienThoai_Changed(oldValue, _dienThoai);//\\
    			}
            }
        }
    	public static String DienThoai_PropertyName { get { return "DienThoai"; } }
        private string _dienThoai;
        partial void On_DienThoai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DienThoai_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHoaDon_DoiTac_tblHoaDon", "tblHoaDon")]
        public tblHoaDon tblHoaDon
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblHoaDon>("PSC_ERPModel.FK_tblHoaDon_DoiTac_tblHoaDon", "tblHoaDon").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblHoaDon_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblHoaDon>("PSC_ERPModel.FK_tblHoaDon_DoiTac_tblHoaDon", "tblHoaDon").Value = value;
    				On_tblHoaDon_Changed(this.tblHoaDon);//\\//
    			}
    	    }
        }
    	public static String tblHoaDon_ReferencePropertyName { get { return "tblHoaDon"; } }
    	partial void On_tblHoaDon_Changing(ref tblHoaDon newValue, ref bool stopChanging);
    	partial void On_tblHoaDon_Changed(tblHoaDon currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblHoaDon> tblHoaDonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblHoaDon>("PSC_ERPModel.FK_tblHoaDon_DoiTac_tblHoaDon", "tblHoaDon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblHoaDon>("PSC_ERPModel.FK_tblHoaDon_DoiTac_tblHoaDon", "tblHoaDon", value);
                }
            }
        }

        #endregion

    }
}

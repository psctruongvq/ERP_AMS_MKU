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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblChungTu_DiaChi")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblChungTu_DiaChi : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblChungTu_DiaChi()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblChungTu_DiaChi object.
        /// </summary>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        public static tblChungTu_DiaChi CreatetblChungTu_DiaChi(long maChungTu)
        {
            tblChungTu_DiaChi tblChungTu_DiaChi = new tblChungTu_DiaChi();
            tblChungTu_DiaChi.MaChungTu = maChungTu;
            return tblChungTu_DiaChi;
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

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_DiaChi_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_DiaChi_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_DiaChi_tblChungTu", "tblChungTu").Value = value;
    				On_tblChungTu_Changed(this.tblChungTu);//\\//
    			}
    	    }
        }
    	public static String tblChungTu_ReferencePropertyName { get { return "tblChungTu"; } }
    	partial void On_tblChungTu_Changing(ref tblChungTu newValue, ref bool stopChanging);
    	partial void On_tblChungTu_Changed(tblChungTu currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblChungTu> tblChungTuReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_DiaChi_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_DiaChi_tblChungTu", "tblChungTu", value);
                }
            }
        }

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblInMaVachTaiSanCoDinhCaBiet")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblInMaVachTaiSanCoDinhCaBiet : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblInMaVachTaiSanCoDinhCaBiet()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblInMaVachTaiSanCoDinhCaBiet object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static tblInMaVachTaiSanCoDinhCaBiet CreatetblInMaVachTaiSanCoDinhCaBiet(int id)
        {
            tblInMaVachTaiSanCoDinhCaBiet tblInMaVachTaiSanCoDinhCaBiet = new tblInMaVachTaiSanCoDinhCaBiet();
            tblInMaVachTaiSanCoDinhCaBiet.Id = id;
            return tblInMaVachTaiSanCoDinhCaBiet;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
        			int oldValue =  _id;
        			bool stopChanging = false;
                    On_Id_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("Id");
        			if(!stopChanging)
        			{
        				_id = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("Id");
        				On_Id_Changed(oldValue, _id);//\\
        			}
                }
            }
        }
    	public static String Id_PropertyName { get { return "Id"; } }
        private int _id;
        partial void On_Id_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_Id_Changed(int oldValue, int currentValue);
    
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

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblInMaVachTaiSanCoDinhCaBiet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet")]
        public tblTaiSanCoDinhCaBiet tblTaiSanCoDinhCaBiet
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblInMaVachTaiSanCoDinhCaBiet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiSanCoDinhCaBiet_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblInMaVachTaiSanCoDinhCaBiet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblInMaVachTaiSanCoDinhCaBiet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblInMaVachTaiSanCoDinhCaBiet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet", value);
                }
            }
        }

        #endregion

    }
}

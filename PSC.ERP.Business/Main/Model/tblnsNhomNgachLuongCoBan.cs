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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsNhomNgachLuongCoBan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsNhomNgachLuongCoBan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsNhomNgachLuongCoBan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsNhomNgachLuongCoBan object.
        /// </summary>
        /// <param name="maNhomNgachLuongCoBan">Initial value of the MaNhomNgachLuongCoBan property.</param>
        /// <param name="maQL">Initial value of the MaQL property.</param>
        /// <param name="tenNhomNgachLuongCoBan">Initial value of the TenNhomNgachLuongCoBan property.</param>
        public static tblnsNhomNgachLuongCoBan CreatetblnsNhomNgachLuongCoBan(int maNhomNgachLuongCoBan, string maQL, string tenNhomNgachLuongCoBan)
        {
            tblnsNhomNgachLuongCoBan tblnsNhomNgachLuongCoBan = new tblnsNhomNgachLuongCoBan();
            tblnsNhomNgachLuongCoBan.MaNhomNgachLuongCoBan = maNhomNgachLuongCoBan;
            tblnsNhomNgachLuongCoBan.MaQL = maQL;
            tblnsNhomNgachLuongCoBan.TenNhomNgachLuongCoBan = tenNhomNgachLuongCoBan;
            return tblnsNhomNgachLuongCoBan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNhomNgachLuongCoBan
        {
            get
            {
                return _maNhomNgachLuongCoBan;
            }
            set
            {
                if (_maNhomNgachLuongCoBan != value)
                {
        			int oldValue =  _maNhomNgachLuongCoBan;
        			bool stopChanging = false;
                    On_MaNhomNgachLuongCoBan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNhomNgachLuongCoBan");
        			if(!stopChanging)
        			{
        				_maNhomNgachLuongCoBan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNhomNgachLuongCoBan");
        				On_MaNhomNgachLuongCoBan_Changed(oldValue, _maNhomNgachLuongCoBan);//\\
        			}
                }
            }
        }
    	public static String MaNhomNgachLuongCoBan_PropertyName { get { return "MaNhomNgachLuongCoBan"; } }
        private int _maNhomNgachLuongCoBan;
        partial void On_MaNhomNgachLuongCoBan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNhomNgachLuongCoBan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQL
        {
            get
            {
                return _maQL;
            }
            set
            {
    			string oldValue =  _maQL;
    			bool stopChanging = false;
                On_MaQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQL");
    			if(!stopChanging)
    			{
    				_maQL = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("MaQL");
    				On_MaQL_Changed(oldValue, _maQL);//\\
    			}
            }
        }
    	public static String MaQL_PropertyName { get { return "MaQL"; } }
        private string _maQL;
        partial void On_MaQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNhomNgachLuongCoBan
        {
            get
            {
                return _tenNhomNgachLuongCoBan;
            }
            set
            {
    			string oldValue =  _tenNhomNgachLuongCoBan;
    			bool stopChanging = false;
                On_TenNhomNgachLuongCoBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhomNgachLuongCoBan");
    			if(!stopChanging)
    			{
    				_tenNhomNgachLuongCoBan = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("TenNhomNgachLuongCoBan");
    				On_TenNhomNgachLuongCoBan_Changed(oldValue, _tenNhomNgachLuongCoBan);//\\
    			}
            }
        }
    	public static String TenNhomNgachLuongCoBan_PropertyName { get { return "TenNhomNgachLuongCoBan"; } }
        private string _tenNhomNgachLuongCoBan;
        partial void On_TenNhomNgachLuongCoBan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhomNgachLuongCoBan_Changed(string oldValue, string currentValue);
    
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

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsNgachLuongCoBan_tblnsNhomNgachLuongCoBan", "tblnsNgachLuongCoBan")]
        public EntityCollection<tblnsNgachLuongCoBan> tblnsNgachLuongCoBans
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsNgachLuongCoBan_tblnsNhomNgachLuongCoBan", "tblnsNgachLuongCoBan");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsNgachLuongCoBans_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsNgachLuongCoBan>("PSC_ERPModel.FK_tblnsNgachLuongCoBan_tblnsNhomNgachLuongCoBan", "tblnsNgachLuongCoBan", value);
    					On_tblnsNgachLuongCoBans_Changed(this.tblnsNgachLuongCoBans);//\\//
    				}
    			}
            }
        }
    	public static String tblnsNgachLuongCoBans_EntityCollectionPropertyName { get { return "tblnsNgachLuongCoBans"; } }
    	partial void On_tblnsNgachLuongCoBans_Changing(ref EntityCollection<tblnsNgachLuongCoBan> newValue, ref bool stopChanging);
    	partial void On_tblnsNgachLuongCoBans_Changed(EntityCollection<tblnsNgachLuongCoBan> currentValue);

        #endregion

    }
}

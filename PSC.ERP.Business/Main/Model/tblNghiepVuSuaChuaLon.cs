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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblNghiepVuSuaChuaLon")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblNghiepVuSuaChuaLon : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblNghiepVuSuaChuaLon()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblNghiepVuSuaChuaLon object.
        /// </summary>
        /// <param name="maNghiepVuSuaChuaLon">Initial value of the MaNghiepVuSuaChuaLon property.</param>
        public static tblNghiepVuSuaChuaLon CreatetblNghiepVuSuaChuaLon(int maNghiepVuSuaChuaLon)
        {
            tblNghiepVuSuaChuaLon tblNghiepVuSuaChuaLon = new tblNghiepVuSuaChuaLon();
            tblNghiepVuSuaChuaLon.MaNghiepVuSuaChuaLon = maNghiepVuSuaChuaLon;
            return tblNghiepVuSuaChuaLon;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNghiepVuSuaChuaLon
        {
            get
            {
                return _maNghiepVuSuaChuaLon;
            }
            set
            {
                if (_maNghiepVuSuaChuaLon != value)
                {
        			int oldValue =  _maNghiepVuSuaChuaLon;
        			bool stopChanging = false;
                    On_MaNghiepVuSuaChuaLon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNghiepVuSuaChuaLon");
        			if(!stopChanging)
        			{
        				_maNghiepVuSuaChuaLon = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNghiepVuSuaChuaLon");
        				On_MaNghiepVuSuaChuaLon_Changed(oldValue, _maNghiepVuSuaChuaLon);//\\
        			}
                }
            }
        }
    	public static String MaNghiepVuSuaChuaLon_PropertyName { get { return "MaNghiepVuSuaChuaLon"; } }
        private int _maNghiepVuSuaChuaLon;
        partial void On_MaNghiepVuSuaChuaLon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNghiepVuSuaChuaLon_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> TuNgay
        {
            get
            {
                return _tuNgay;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _tuNgay;
    			bool stopChanging = false;
                On_TuNgay_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TuNgay");
    			if(!stopChanging)
    			{
    				_tuNgay = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TuNgay");
    				On_TuNgay_Changed(oldValue, _tuNgay);//\\
    			}
            }
        }
    	public static String TuNgay_PropertyName { get { return "TuNgay"; } }
        private Nullable<System.DateTime> _tuNgay;
        partial void On_TuNgay_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_TuNgay_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> DenNgay
        {
            get
            {
                return _denNgay;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _denNgay;
    			bool stopChanging = false;
                On_DenNgay_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DenNgay");
    			if(!stopChanging)
    			{
    				_denNgay = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DenNgay");
    				On_DenNgay_Changed(oldValue, _denNgay);//\\
    			}
            }
        }
    	public static String DenNgay_PropertyName { get { return "DenNgay"; } }
        private Nullable<System.DateTime> _denNgay;
        partial void On_DenNgay_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_DenNgay_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
    			Nullable<long> oldValue =  _maChungTu;
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
    	public static String MaChungTu_PropertyName { get { return "MaChungTu"; } }
        private Nullable<long> _maChungTu;
        partial void On_MaChungTu_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			Nullable<int> oldValue =  _userID;
    			bool stopChanging = false;
                On_UserID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserID");
    			if(!stopChanging)
    			{
    				_userID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserID");
    				On_UserID_Changed(oldValue, _userID);//\\
    			}
            }
        }
    	public static String UserID_PropertyName { get { return "UserID"; } }
        private Nullable<int> _userID;
        partial void On_UserID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> NguonMua
        {
            get
            {
                return _nguonMua;
            }
            set
            {
    			Nullable<bool> oldValue =  _nguonMua;
    			bool stopChanging = false;
                On_NguonMua_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguonMua");
    			if(!stopChanging)
    			{
    				_nguonMua = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguonMua");
    				On_NguonMua_Changed(oldValue, _nguonMua);//\\
    			}
            }
        }
    	public static String NguonMua_PropertyName { get { return "NguonMua"; } }
        private Nullable<bool> _nguonMua;
        partial void On_NguonMua_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_NguonMua_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNguon
        {
            get
            {
                return _maNguon;
            }
            set
            {
    			Nullable<int> oldValue =  _maNguon;
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
    	public static String MaNguon_PropertyName { get { return "MaNguon"; } }
        private Nullable<int> _maNguon;
        partial void On_MaNguon_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNguon_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuSuaChuaLon_tblNguon", "tblNguon")]
        public tblNguon tblNguon
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNguon>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblNguon", "tblNguon").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblNguon_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNguon>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblNguon", "tblNguon").Value = value;
    				On_tblNguon_Changed(this.tblNguon);//\\//
    			}
    	    }
        }
    	public static String tblNguon_ReferencePropertyName { get { return "tblNguon"; } }
    	partial void On_tblNguon_Changing(ref tblNguon newValue, ref bool stopChanging);
    	partial void On_tblNguon_Changed(tblNguon currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblNguon> tblNguonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNguon>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblNguon", "tblNguon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblNguon>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblNguon", "tblNguon", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuSuaChuaLon_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblChungTu", "tblChungTu").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_tblChungTu", "tblChungTu", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuSuaChuaLon_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_app_users", "app_users").Value = value;
    				On_app_users_Changed(this.app_users);//\\//
    			}
    	    }
        }
    	public static String app_users_ReferencePropertyName { get { return "app_users"; } }
    	partial void On_app_users_Changing(ref app_users newValue, ref bool stopChanging);
    	partial void On_app_users_Changed(app_users currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<app_users> app_usersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuSuaChuaLon_app_users", "app_users", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblCT_NghiepVuSuaChuaLon")]
        public EntityCollection<tblCT_NghiepVuSuaChuaLon> tblCT_NghiepVuSuaChuaLon
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblCT_NghiepVuSuaChuaLon");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NghiepVuSuaChuaLon_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblCT_NghiepVuSuaChuaLon", value);
    					On_tblCT_NghiepVuSuaChuaLon_Changed(this.tblCT_NghiepVuSuaChuaLon);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_NghiepVuSuaChuaLon_EntityCollectionPropertyName { get { return "tblCT_NghiepVuSuaChuaLon"; } }
    	partial void On_tblCT_NghiepVuSuaChuaLon_Changing(ref EntityCollection<tblCT_NghiepVuSuaChuaLon> newValue, ref bool stopChanging);
    	partial void On_tblCT_NghiepVuSuaChuaLon_Changed(EntityCollection<tblCT_NghiepVuSuaChuaLon> currentValue);

        #endregion

    }
}
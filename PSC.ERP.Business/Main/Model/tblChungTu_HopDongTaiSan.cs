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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblChungTu_HopDongTaiSan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblChungTu_HopDongTaiSan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblChungTu_HopDongTaiSan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblChungTu_HopDongTaiSan object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static tblChungTu_HopDongTaiSan CreatetblChungTu_HopDongTaiSan(long id)
        {
            tblChungTu_HopDongTaiSan tblChungTu_HopDongTaiSan = new tblChungTu_HopDongTaiSan();
            tblChungTu_HopDongTaiSan.ID = id;
            return tblChungTu_HopDongTaiSan;
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
        public string TenHopDong
        {
            get
            {
                return _tenHopDong;
            }
            set
            {
    			string oldValue =  _tenHopDong;
    			bool stopChanging = false;
                On_TenHopDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenHopDong");
    			if(!stopChanging)
    			{
    				_tenHopDong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenHopDong");
    				On_TenHopDong_Changed(oldValue, _tenHopDong);//\\
    			}
            }
        }
    	public static String TenHopDong_PropertyName { get { return "TenHopDong"; } }
        private string _tenHopDong;
        partial void On_TenHopDong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenHopDong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHopDong
        {
            get
            {
                return _soHopDong;
            }
            set
            {
    			string oldValue =  _soHopDong;
    			bool stopChanging = false;
                On_SoHopDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHopDong");
    			if(!stopChanging)
    			{
    				_soHopDong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHopDong");
    				On_SoHopDong_Changed(oldValue, _soHopDong);//\\
    			}
            }
        }
    	public static String SoHopDong_PropertyName { get { return "SoHopDong"; } }
        private string _soHopDong;
        partial void On_SoHopDong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHopDong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTien;
    			bool stopChanging = false;
                On_SoTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTien");
    			if(!stopChanging)
    			{
    				_soTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTien");
    				On_SoTien_Changed(oldValue, _soTien);//\\
    			}
            }
        }
    	public static String SoTien_PropertyName { get { return "SoTien"; } }
        private Nullable<decimal> _soTien;
        partial void On_SoTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayKy
        {
            get
            {
                return _ngayKy;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayKy;
    			bool stopChanging = false;
                On_NgayKy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayKy");
    			if(!stopChanging)
    			{
    				_ngayKy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayKy");
    				On_NgayKy_Changed(oldValue, _ngayKy);//\\
    			}
            }
        }
    	public static String NgayKy_PropertyName { get { return "NgayKy"; } }
        private Nullable<System.DateTime> _ngayKy;
        partial void On_NgayKy_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayKy_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaDoiTac
        {
            get
            {
                return _maDoiTac;
            }
            set
            {
    			Nullable<long> oldValue =  _maDoiTac;
    			bool stopChanging = false;
                On_MaDoiTac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTac");
    			if(!stopChanging)
    			{
    				_maDoiTac = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTac");
    				On_MaDoiTac_Changed(oldValue, _maDoiTac);//\\
    			}
            }
        }
    	public static String MaDoiTac_PropertyName { get { return "MaDoiTac"; } }
        private Nullable<long> _maDoiTac;
        partial void On_MaDoiTac_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaDoiTac_Changed(Nullable<long> oldValue, Nullable<long> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_HopDongTaiSan_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_HopDongTaiSan_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_HopDongTaiSan_tblChungTu", "tblChungTu").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_HopDongTaiSan_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_HopDongTaiSan_tblChungTu", "tblChungTu", value);
                }
            }
        }

        #endregion

    }
}
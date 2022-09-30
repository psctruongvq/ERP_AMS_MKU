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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblTienTe")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblTienTe : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblTienTe()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblTienTe object.
        /// </summary>
        /// <param name="maTienTe">Initial value of the MaTienTe property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        public static tblTienTe CreatetblTienTe(long maTienTe, decimal soTien)
        {
            tblTienTe tblTienTe = new tblTienTe();
            tblTienTe.MaTienTe = maTienTe;
            tblTienTe.SoTien = soTien;
            return tblTienTe;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaTienTe
        {
            get
            {
                return _maTienTe;
            }
            set
            {
                if (_maTienTe != value)
                {
        			long oldValue =  _maTienTe;
        			bool stopChanging = false;
                    On_MaTienTe_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTienTe");
        			if(!stopChanging)
        			{
        				_maTienTe = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTienTe");
        				On_MaTienTe_Changed(oldValue, _maTienTe);//\\
        			}
                }
            }
        }
    	public static String MaTienTe_PropertyName { get { return "MaTienTe"; } }
        private long _maTienTe;
        partial void On_MaTienTe_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaTienTe_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
    			decimal oldValue =  _soTien;
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
        private decimal _soTien;
        partial void On_SoTien_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiTien
        {
            get
            {
                return _maLoaiTien;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiTien;
    			bool stopChanging = false;
                On_MaLoaiTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiTien");
    			if(!stopChanging)
    			{
    				_maLoaiTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiTien");
    				On_MaLoaiTien_Changed(oldValue, _maLoaiTien);//\\
    			}
            }
        }
    	public static String MaLoaiTien_PropertyName { get { return "MaLoaiTien"; } }
        private Nullable<int> _maLoaiTien;
        partial void On_MaLoaiTien_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiTien_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThanhTien
        {
            get
            {
                return _thanhTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thanhTien;
    			bool stopChanging = false;
                On_ThanhTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThanhTien");
    			if(!stopChanging)
    			{
    				_thanhTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThanhTien");
    				On_ThanhTien_Changed(oldValue, _thanhTien);//\\
    			}
            }
        }
    	public static String ThanhTien_PropertyName { get { return "ThanhTien"; } }
        private Nullable<decimal> _thanhTien;
        partial void On_ThanhTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThanhTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string VietBangChu
        {
            get
            {
                return _vietBangChu;
            }
            set
            {
    			string oldValue =  _vietBangChu;
    			bool stopChanging = false;
                On_VietBangChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("VietBangChu");
    			if(!stopChanging)
    			{
    				_vietBangChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("VietBangChu");
    				On_VietBangChu_Changed(oldValue, _vietBangChu);//\\
    			}
            }
        }
    	public static String VietBangChu_PropertyName { get { return "VietBangChu"; } }
        private string _vietBangChu;
        partial void On_VietBangChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_VietBangChu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TiGiaQuyDoi
        {
            get
            {
                return _tiGiaQuyDoi;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tiGiaQuyDoi;
    			bool stopChanging = false;
                On_TiGiaQuyDoi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TiGiaQuyDoi");
    			if(!stopChanging)
    			{
    				_tiGiaQuyDoi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TiGiaQuyDoi");
    				On_TiGiaQuyDoi_Changed(oldValue, _tiGiaQuyDoi);//\\
    			}
            }
        }
    	public static String TiGiaQuyDoi_PropertyName { get { return "TiGiaQuyDoi"; } }
        private Nullable<decimal> _tiGiaQuyDoi;
        partial void On_TiGiaQuyDoi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TiGiaQuyDoi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblTienTe_tblLoaiTien", "tblLoaiTien")]
        public tblLoaiTien tblLoaiTien
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiTien>("PSC_ERPModel.FK_tblTienTe_tblLoaiTien", "tblLoaiTien").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblLoaiTien_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiTien>("PSC_ERPModel.FK_tblTienTe_tblLoaiTien", "tblLoaiTien").Value = value;
    				On_tblLoaiTien_Changed(this.tblLoaiTien);//\\//
    			}
    	    }
        }
    	public static String tblLoaiTien_ReferencePropertyName { get { return "tblLoaiTien"; } }
    	partial void On_tblLoaiTien_Changing(ref tblLoaiTien newValue, ref bool stopChanging);
    	partial void On_tblLoaiTien_Changed(tblLoaiTien currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblLoaiTien> tblLoaiTienReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiTien>("PSC_ERPModel.FK_tblTienTe_tblLoaiTien", "tblLoaiTien");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblLoaiTien>("PSC_ERPModel.FK_tblTienTe_tblLoaiTien", "tblLoaiTien", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblTienTe_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblTienTe_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblTienTe_tblChungTu", "tblChungTu").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblTienTe_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblTienTe_tblChungTu", "tblChungTu", value);
                }
            }
        }

        #endregion

    }
}

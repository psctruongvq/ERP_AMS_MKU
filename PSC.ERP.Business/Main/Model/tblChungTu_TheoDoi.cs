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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblChungTu_TheoDoi")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblChungTu_TheoDoi : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblChungTu_TheoDoi()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblChungTu_TheoDoi object.
        /// </summary>
        /// <param name="maTheoDoi">Initial value of the MaTheoDoi property.</param>
        public static tblChungTu_TheoDoi CreatetblChungTu_TheoDoi(int maTheoDoi)
        {
            tblChungTu_TheoDoi tblChungTu_TheoDoi = new tblChungTu_TheoDoi();
            tblChungTu_TheoDoi.MaTheoDoi = maTheoDoi;
            return tblChungTu_TheoDoi;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTheoDoi
        {
            get
            {
                return _maTheoDoi;
            }
            set
            {
                if (_maTheoDoi != value)
                {
        			int oldValue =  _maTheoDoi;
        			bool stopChanging = false;
                    On_MaTheoDoi_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTheoDoi");
        			if(!stopChanging)
        			{
        				_maTheoDoi = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTheoDoi");
        				On_MaTheoDoi_Changed(oldValue, _maTheoDoi);//\\
        			}
                }
            }
        }
    	public static String MaTheoDoi_PropertyName { get { return "MaTheoDoi"; } }
        private int _maTheoDoi;
        partial void On_MaTheoDoi_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTheoDoi_Changed(int oldValue, int currentValue);
    
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
        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
            set
            {
    			string oldValue =  _soChungTu;
    			bool stopChanging = false;
                On_SoChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoChungTu");
    			if(!stopChanging)
    			{
    				_soChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoChungTu");
    				On_SoChungTu_Changed(oldValue, _soChungTu);//\\
    			}
            }
        }
    	public static String SoChungTu_PropertyName { get { return "SoChungTu"; } }
        private string _soChungTu;
        partial void On_SoChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayLapChungTu
        {
            get
            {
                return _ngayLapChungTu;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayLapChungTu;
    			bool stopChanging = false;
                On_NgayLapChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayLapChungTu");
    			if(!stopChanging)
    			{
    				_ngayLapChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayLapChungTu");
    				On_NgayLapChungTu_Changed(oldValue, _ngayLapChungTu);//\\
    			}
            }
        }
    	public static String NgayLapChungTu_PropertyName { get { return "NgayLapChungTu"; } }
        private Nullable<System.DateTime> _ngayLapChungTu;
        partial void On_NgayLapChungTu_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayLapChungTu_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienChungTu
        {
            get
            {
                return _soTienChungTu;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienChungTu;
    			bool stopChanging = false;
                On_SoTienChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienChungTu");
    			if(!stopChanging)
    			{
    				_soTienChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienChungTu");
    				On_SoTienChungTu_Changed(oldValue, _soTienChungTu);//\\
    			}
            }
        }
    	public static String SoTienChungTu_PropertyName { get { return "SoTienChungTu"; } }
        private Nullable<decimal> _soTienChungTu;
        partial void On_SoTienChungTu_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienChungTu_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DienGiaiChungTu
        {
            get
            {
                return _dienGiaiChungTu;
            }
            set
            {
    			string oldValue =  _dienGiaiChungTu;
    			bool stopChanging = false;
                On_DienGiaiChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DienGiaiChungTu");
    			if(!stopChanging)
    			{
    				_dienGiaiChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DienGiaiChungTu");
    				On_DienGiaiChungTu_Changed(oldValue, _dienGiaiChungTu);//\\
    			}
            }
        }
    	public static String DienGiaiChungTu_PropertyName { get { return "DienGiaiChungTu"; } }
        private string _dienGiaiChungTu;
        partial void On_DienGiaiChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DienGiaiChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> NguoiLapChungTu
        {
            get
            {
                return _nguoiLapChungTu;
            }
            set
            {
    			Nullable<int> oldValue =  _nguoiLapChungTu;
    			bool stopChanging = false;
                On_NguoiLapChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguoiLapChungTu");
    			if(!stopChanging)
    			{
    				_nguoiLapChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguoiLapChungTu");
    				On_NguoiLapChungTu_Changed(oldValue, _nguoiLapChungTu);//\\
    			}
            }
        }
    	public static String NguoiLapChungTu_PropertyName { get { return "NguoiLapChungTu"; } }
        private Nullable<int> _nguoiLapChungTu;
        partial void On_NguoiLapChungTu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NguoiLapChungTu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienDaChi
        {
            get
            {
                return _soTienDaChi;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienDaChi;
    			bool stopChanging = false;
                On_SoTienDaChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienDaChi");
    			if(!stopChanging)
    			{
    				_soTienDaChi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienDaChi");
    				On_SoTienDaChi_Changed(oldValue, _soTienDaChi);//\\
    			}
            }
        }
    	public static String SoTienDaChi_PropertyName { get { return "SoTienDaChi"; } }
        private Nullable<decimal> _soTienDaChi;
        partial void On_SoTienDaChi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienDaChi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienConLai
        {
            get
            {
                return _soTienConLai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienConLai;
    			bool stopChanging = false;
                On_SoTienConLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienConLai");
    			if(!stopChanging)
    			{
    				_soTienConLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienConLai");
    				On_SoTienConLai_Changed(oldValue, _soTienConLai);//\\
    			}
            }
        }
    	public static String SoTienConLai_PropertyName { get { return "SoTienConLai"; } }
        private Nullable<decimal> _soTienConLai;
        partial void On_SoTienConLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienConLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayChiTien
        {
            get
            {
                return _ngayChiTien;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayChiTien;
    			bool stopChanging = false;
                On_NgayChiTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayChiTien");
    			if(!stopChanging)
    			{
    				_ngayChiTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayChiTien");
    				On_NgayChiTien_Changed(oldValue, _ngayChiTien);//\\
    			}
            }
        }
    	public static String NgayChiTien_PropertyName { get { return "NgayChiTien"; } }
        private Nullable<System.DateTime> _ngayChiTien;
        partial void On_NgayChiTien_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayChiTien_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> NguoiChiTien
        {
            get
            {
                return _nguoiChiTien;
            }
            set
            {
    			Nullable<int> oldValue =  _nguoiChiTien;
    			bool stopChanging = false;
                On_NguoiChiTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguoiChiTien");
    			if(!stopChanging)
    			{
    				_nguoiChiTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguoiChiTien");
    				On_NguoiChiTien_Changed(oldValue, _nguoiChiTien);//\\
    			}
            }
        }
    	public static String NguoiChiTien_PropertyName { get { return "NguoiChiTien"; } }
        private Nullable<int> _nguoiChiTien;
        partial void On_NguoiChiTien_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NguoiChiTien_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> HoanTat
        {
            get
            {
                return _hoanTat;
            }
            set
            {
    			Nullable<bool> oldValue =  _hoanTat;
    			bool stopChanging = false;
                On_HoanTat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HoanTat");
    			if(!stopChanging)
    			{
    				_hoanTat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HoanTat");
    				On_HoanTat_Changed(oldValue, _hoanTat);//\\
    			}
            }
        }
    	public static String HoanTat_PropertyName { get { return "HoanTat"; } }
        private Nullable<bool> _hoanTat;
        partial void On_HoanTat_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_HoanTat_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
    			string oldValue =  _ghiChu;
    			bool stopChanging = false;
                On_GhiChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChu");
    			if(!stopChanging)
    			{
    				_ghiChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChu");
    				On_GhiChu_Changed(oldValue, _ghiChu);//\\
    			}
            }
        }
    	public static String GhiChu_PropertyName { get { return "GhiChu"; } }
        private string _ghiChu;
        partial void On_GhiChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChu_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_TheoDoiChiTiet_tblChungTu_TheoDoi", "tblChungTu_TheoDoiChiTiet")]
        public EntityCollection<tblChungTu_TheoDoiChiTiet> tblChungTu_TheoDoiChiTiet
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChungTu_TheoDoiChiTiet>("PSC_ERPModel.FK_tblChungTu_TheoDoiChiTiet_tblChungTu_TheoDoi", "tblChungTu_TheoDoiChiTiet");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChungTu_TheoDoiChiTiet_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChungTu_TheoDoiChiTiet>("PSC_ERPModel.FK_tblChungTu_TheoDoiChiTiet_tblChungTu_TheoDoi", "tblChungTu_TheoDoiChiTiet", value);
    					On_tblChungTu_TheoDoiChiTiet_Changed(this.tblChungTu_TheoDoiChiTiet);//\\//
    				}
    			}
            }
        }
    	public static String tblChungTu_TheoDoiChiTiet_EntityCollectionPropertyName { get { return "tblChungTu_TheoDoiChiTiet"; } }
    	partial void On_tblChungTu_TheoDoiChiTiet_Changing(ref EntityCollection<tblChungTu_TheoDoiChiTiet> newValue, ref bool stopChanging);
    	partial void On_tblChungTu_TheoDoiChiTiet_Changed(EntityCollection<tblChungTu_TheoDoiChiTiet> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_TheoDoi_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_TheoDoi_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_TheoDoi_tblChungTu", "tblChungTu").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_TheoDoi_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_tblChungTu_TheoDoi_tblChungTu", "tblChungTu", value);
                }
            }
        }

        #endregion

    }
}

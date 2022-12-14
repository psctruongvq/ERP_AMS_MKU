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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblDuyetTSCD")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblDuyetTSCD : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblDuyetTSCD()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblDuyetTSCD object.
        /// </summary>
        /// <param name="maChoDuyet">Initial value of the MaChoDuyet property.</param>
        public static tblDuyetTSCD CreatetblDuyetTSCD(int maChoDuyet)
        {
            tblDuyetTSCD tblDuyetTSCD = new tblDuyetTSCD();
            tblDuyetTSCD.MaChoDuyet = maChoDuyet;
            return tblDuyetTSCD;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChoDuyet
        {
            get
            {
                return _maChoDuyet;
            }
            set
            {
                if (_maChoDuyet != value)
                {
        			int oldValue =  _maChoDuyet;
        			bool stopChanging = false;
                    On_MaChoDuyet_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChoDuyet");
        			if(!stopChanging)
        			{
        				_maChoDuyet = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChoDuyet");
        				On_MaChoDuyet_Changed(oldValue, _maChoDuyet);//\\
        			}
                }
            }
        }
    	public static String MaChoDuyet_PropertyName { get { return "MaChoDuyet"; } }
        private int _maChoDuyet;
        partial void On_MaChoDuyet_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChoDuyet_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> DaDuyet
        {
            get
            {
                return _daDuyet;
            }
            set
            {
    			Nullable<bool> oldValue =  _daDuyet;
    			bool stopChanging = false;
                On_DaDuyet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DaDuyet");
    			if(!stopChanging)
    			{
    				_daDuyet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DaDuyet");
    				On_DaDuyet_Changed(oldValue, _daDuyet);//\\
    			}
            }
        }
    	public static String DaDuyet_PropertyName { get { return "DaDuyet"; } }
        private Nullable<bool> _daDuyet;
        partial void On_DaDuyet_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_DaDuyet_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
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
        public Nullable<System.DateTime> NgayLapDS
        {
            get
            {
                return _ngayLapDS;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayLapDS;
    			bool stopChanging = false;
                On_NgayLapDS_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayLapDS");
    			if(!stopChanging)
    			{
    				_ngayLapDS = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayLapDS");
    				On_NgayLapDS_Changed(oldValue, _ngayLapDS);//\\
    			}
            }
        }
    	public static String NgayLapDS_PropertyName { get { return "NgayLapDS"; } }
        private Nullable<System.DateTime> _ngayLapDS;
        partial void On_NgayLapDS_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayLapDS_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserLap
        {
            get
            {
                return _userLap;
            }
            set
            {
    			Nullable<int> oldValue =  _userLap;
    			bool stopChanging = false;
                On_UserLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserLap");
    			if(!stopChanging)
    			{
    				_userLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserLap");
    				On_UserLap_Changed(oldValue, _userLap);//\\
    			}
            }
        }
    	public static String UserLap_PropertyName { get { return "UserLap"; } }
        private Nullable<int> _userLap;
        partial void On_UserLap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserLap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserDuyet
        {
            get
            {
                return _userDuyet;
            }
            set
            {
    			Nullable<int> oldValue =  _userDuyet;
    			bool stopChanging = false;
                On_UserDuyet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserDuyet");
    			if(!stopChanging)
    			{
    				_userDuyet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserDuyet");
    				On_UserDuyet_Changed(oldValue, _userDuyet);//\\
    			}
            }
        }
    	public static String UserDuyet_PropertyName { get { return "UserDuyet"; } }
        private Nullable<int> _userDuyet;
        partial void On_UserDuyet_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserDuyet_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayDuyet
        {
            get
            {
                return _ngayDuyet;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayDuyet;
    			bool stopChanging = false;
                On_NgayDuyet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayDuyet");
    			if(!stopChanging)
    			{
    				_ngayDuyet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayDuyet");
    				On_NgayDuyet_Changed(oldValue, _ngayDuyet);//\\
    			}
            }
        }
    	public static String NgayDuyet_PropertyName { get { return "NgayDuyet"; } }
        private Nullable<System.DateTime> _ngayDuyet;
        partial void On_NgayDuyet_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayDuyet_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> LoaiNghiepVu
        {
            get
            {
                return _loaiNghiepVu;
            }
            set
            {
    			Nullable<int> oldValue =  _loaiNghiepVu;
    			bool stopChanging = false;
                On_LoaiNghiepVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiNghiepVu");
    			if(!stopChanging)
    			{
    				_loaiNghiepVu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiNghiepVu");
    				On_LoaiNghiepVu_Changed(oldValue, _loaiNghiepVu);//\\
    			}
            }
        }
    	public static String LoaiNghiepVu_PropertyName { get { return "LoaiNghiepVu"; } }
        private Nullable<int> _loaiNghiepVu;
        partial void On_LoaiNghiepVu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LoaiNghiepVu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> DaThucHienNghiepVu
        {
            get
            {
                return _daThucHienNghiepVu;
            }
            set
            {
    			Nullable<bool> oldValue =  _daThucHienNghiepVu;
    			bool stopChanging = false;
                On_DaThucHienNghiepVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DaThucHienNghiepVu");
    			if(!stopChanging)
    			{
    				_daThucHienNghiepVu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DaThucHienNghiepVu");
    				On_DaThucHienNghiepVu_Changed(oldValue, _daThucHienNghiepVu);//\\
    			}
            }
        }
    	public static String DaThucHienNghiepVu_PropertyName { get { return "DaThucHienNghiepVu"; } }
        private Nullable<bool> _daThucHienNghiepVu;
        partial void On_DaThucHienNghiepVu_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_DaThucHienNghiepVu_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string UserWebLap
        {
            get
            {
                return _userWebLap;
            }
            set
            {
    			string oldValue =  _userWebLap;
    			bool stopChanging = false;
                On_UserWebLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserWebLap");
    			if(!stopChanging)
    			{
    				_userWebLap = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("UserWebLap");
    				On_UserWebLap_Changed(oldValue, _userWebLap);//\\
    			}
            }
        }
    	public static String UserWebLap_PropertyName { get { return "UserWebLap"; } }
        private string _userWebLap;
        partial void On_UserWebLap_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_UserWebLap_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string UserWebDuyet
        {
            get
            {
                return _userWebDuyet;
            }
            set
            {
    			string oldValue =  _userWebDuyet;
    			bool stopChanging = false;
                On_UserWebDuyet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserWebDuyet");
    			if(!stopChanging)
    			{
    				_userWebDuyet = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("UserWebDuyet");
    				On_UserWebDuyet_Changed(oldValue, _userWebDuyet);//\\
    			}
            }
        }
    	public static String UserWebDuyet_PropertyName { get { return "UserWebDuyet"; } }
        private string _userWebDuyet;
        partial void On_UserWebDuyet_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_UserWebDuyet_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaViTri
        {
            get
            {
                return _maViTri;
            }
            set
            {
    			Nullable<int> oldValue =  _maViTri;
    			bool stopChanging = false;
                On_MaViTri_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaViTri");
    			if(!stopChanging)
    			{
    				_maViTri = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaViTri");
    				On_MaViTri_Changed(oldValue, _maViTri);//\\
    			}
            }
        }
    	public static String MaViTri_PropertyName { get { return "MaViTri"; } }
        private Nullable<int> _maViTri;
        partial void On_MaViTri_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaViTri_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhongBan
        {
            get
            {
                return _maPhongBan;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhongBan;
    			bool stopChanging = false;
                On_MaPhongBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBan");
    			if(!stopChanging)
    			{
    				_maPhongBan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhongBan");
    				On_MaPhongBan_Changed(oldValue, _maPhongBan);//\\
    			}
            }
        }
    	public static String MaPhongBan_PropertyName { get { return "MaPhongBan"; } }
        private Nullable<int> _maPhongBan;
        partial void On_MaPhongBan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhongBan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuDieuChuyenNoiBo_tblDuyetTSCD", "tblCT_NghiepVuDieuChuyenNoiBo")]
        public EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> tblCT_NghiepVuDieuChuyenNoiBo
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenNoiBo_tblDuyetTSCD", "tblCT_NghiepVuDieuChuyenNoiBo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NghiepVuDieuChuyenNoiBo_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenNoiBo_tblDuyetTSCD", "tblCT_NghiepVuDieuChuyenNoiBo", value);
    					On_tblCT_NghiepVuDieuChuyenNoiBo_Changed(this.tblCT_NghiepVuDieuChuyenNoiBo);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_NghiepVuDieuChuyenNoiBo_EntityCollectionPropertyName { get { return "tblCT_NghiepVuDieuChuyenNoiBo"; } }
    	partial void On_tblCT_NghiepVuDieuChuyenNoiBo_Changing(ref EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> newValue, ref bool stopChanging);
    	partial void On_tblCT_NghiepVuDieuChuyenNoiBo_Changed(EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD")]
        public EntityCollection<tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD> tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD>("PSC_ERPModel.FK_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_tblDuyetTSCD", "tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD", value);
    					On_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Changed(this.tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_EntityCollectionPropertyName { get { return "tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD"; } }
    	partial void On_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Changing(ref EntityCollection<tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD> newValue, ref bool stopChanging);
    	partial void On_tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD_Changed(EntityCollection<tblCT_NVThanhLyvaDieuChuyenNgoaiTSCD> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblDanhSachTSCDChoDuyet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet")]
        public tblTaiSanCoDinhCaBiet tblTaiSanCoDinhCaBiet
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblDanhSachTSCDChoDuyet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiSanCoDinhCaBiet_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblDanhSachTSCDChoDuyet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblDanhSachTSCDChoDuyet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblDanhSachTSCDChoDuyet_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblDuyetTSCDHoacChiTietTSCD_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users", "app_users").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users", "app_users", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblDuyetTSCDHoacChiTietTSCD_app_users1", "app_users")]
        public app_users app_users1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users1", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users1", "app_users").Value = value;
    				On_app_users1_Changed(this.app_users1);//\\//
    			}
    	    }
        }
    	public static String app_users1_ReferencePropertyName { get { return "app_users1"; } }
    	partial void On_app_users1_Changing(ref app_users newValue, ref bool stopChanging);
    	partial void On_app_users1_Changed(app_users currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<app_users> app_users1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users1", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblDuyetTSCDHoacChiTietTSCD_app_users1", "app_users", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblCT_NghiepVuSuaChuaLon")]
        public EntityCollection<tblCT_NghiepVuSuaChuaLon> tblCT_NghiepVuSuaChuaLon
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblCT_NghiepVuSuaChuaLon");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NghiepVuSuaChuaLon_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblCT_NghiepVuSuaChuaLon", value);
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

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblGiayBaoCo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblGiayBaoCo : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblGiayBaoCo()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblGiayBaoCo object.
        /// </summary>
        /// <param name="maGiayBaoCo">Initial value of the MaGiayBaoCo property.</param>
        public static tblGiayBaoCo CreatetblGiayBaoCo(int maGiayBaoCo)
        {
            tblGiayBaoCo tblGiayBaoCo = new tblGiayBaoCo();
            tblGiayBaoCo.MaGiayBaoCo = maGiayBaoCo;
            return tblGiayBaoCo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaGiayBaoCo
        {
            get
            {
                return _maGiayBaoCo;
            }
            set
            {
                if (_maGiayBaoCo != value)
                {
        			int oldValue =  _maGiayBaoCo;
        			bool stopChanging = false;
                    On_MaGiayBaoCo_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaGiayBaoCo");
        			if(!stopChanging)
        			{
        				_maGiayBaoCo = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaGiayBaoCo");
        				On_MaGiayBaoCo_Changed(oldValue, _maGiayBaoCo);//\\
        			}
                }
            }
        }
    	public static String MaGiayBaoCo_PropertyName { get { return "MaGiayBaoCo"; } }
        private int _maGiayBaoCo;
        partial void On_MaGiayBaoCo_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaGiayBaoCo_Changed(int oldValue, int currentValue);
    
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
        public Nullable<System.DateTime> NgayNhan
        {
            get
            {
                return _ngayNhan;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayNhan;
    			bool stopChanging = false;
                On_NgayNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayNhan");
    			if(!stopChanging)
    			{
    				_ngayNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayNhan");
    				On_NgayNhan_Changed(oldValue, _ngayNhan);//\\
    			}
            }
        }
    	public static String NgayNhan_PropertyName { get { return "NgayNhan"; } }
        private Nullable<System.DateTime> _ngayNhan;
        partial void On_NgayNhan_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayNhan_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayLap;
    			bool stopChanging = false;
                On_NgayLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayLap");
    			if(!stopChanging)
    			{
    				_ngayLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayLap");
    				On_NgayLap_Changed(oldValue, _ngayLap);//\\
    			}
            }
        }
    	public static String NgayLap_PropertyName { get { return "NgayLap"; } }
        private Nullable<System.DateTime> _ngayLap;
        partial void On_NgayLap_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayLap_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
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
        public Nullable<int> UserId
        {
            get
            {
                return _userId;
            }
            set
            {
    			Nullable<int> oldValue =  _userId;
    			bool stopChanging = false;
                On_UserId_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserId");
    			if(!stopChanging)
    			{
    				_userId = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserId");
    				On_UserId_Changed(oldValue, _userId);//\\
    			}
            }
        }
    	public static String UserId_PropertyName { get { return "UserId"; } }
        private Nullable<int> _userId;
        partial void On_UserId_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserId_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> LapBangKe
        {
            get
            {
                return _lapBangKe;
            }
            set
            {
    			Nullable<int> oldValue =  _lapBangKe;
    			bool stopChanging = false;
                On_LapBangKe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LapBangKe");
    			if(!stopChanging)
    			{
    				_lapBangKe = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LapBangKe");
    				On_LapBangKe_Changed(oldValue, _lapBangKe);//\\
    			}
            }
        }
    	public static String LapBangKe_PropertyName { get { return "LapBangKe"; } }
        private Nullable<int> _lapBangKe;
        partial void On_LapBangKe_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LapBangKe_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> TaiKhoanNhan
        {
            get
            {
                return _taiKhoanNhan;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanNhan;
    			bool stopChanging = false;
                On_TaiKhoanNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanNhan");
    			if(!stopChanging)
    			{
    				_taiKhoanNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanNhan");
    				On_TaiKhoanNhan_Changed(oldValue, _taiKhoanNhan);//\\
    			}
            }
        }
    	public static String TaiKhoanNhan_PropertyName { get { return "TaiKhoanNhan"; } }
        private Nullable<int> _taiKhoanNhan;
        partial void On_TaiKhoanNhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanNhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TyGia
        {
            get
            {
                return _tyGia;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tyGia;
    			bool stopChanging = false;
                On_TyGia_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TyGia");
    			if(!stopChanging)
    			{
    				_tyGia = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TyGia");
    				On_TyGia_Changed(oldValue, _tyGia);//\\
    			}
            }
        }
    	public static String TyGia_PropertyName { get { return "TyGia"; } }
        private Nullable<decimal> _tyGia;
        partial void On_TyGia_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TyGia_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> LoaiTien
        {
            get
            {
                return _loaiTien;
            }
            set
            {
    			Nullable<int> oldValue =  _loaiTien;
    			bool stopChanging = false;
                On_LoaiTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiTien");
    			if(!stopChanging)
    			{
    				_loaiTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiTien");
    				On_LoaiTien_Changed(oldValue, _loaiTien);//\\
    			}
            }
        }
    	public static String LoaiTien_PropertyName { get { return "LoaiTien"; } }
        private Nullable<int> _loaiTien;
        partial void On_LoaiTien_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LoaiTien_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> madoitac
        {
            get
            {
                return _madoitac;
            }
            set
            {
    			Nullable<long> oldValue =  _madoitac;
    			bool stopChanging = false;
                On_madoitac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("madoitac");
    			if(!stopChanging)
    			{
    				_madoitac = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("madoitac");
    				On_madoitac_Changed(oldValue, _madoitac);//\\
    			}
            }
        }
    	public static String madoitac_PropertyName { get { return "madoitac"; } }
        private Nullable<long> _madoitac;
        partial void On_madoitac_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_madoitac_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> LoaiGBC
        {
            get
            {
                return _loaiGBC;
            }
            set
            {
    			Nullable<int> oldValue =  _loaiGBC;
    			bool stopChanging = false;
                On_LoaiGBC_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiGBC");
    			if(!stopChanging)
    			{
    				_loaiGBC = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiGBC");
    				On_LoaiGBC_Changed(oldValue, _loaiGBC);//\\
    			}
            }
        }
    	public static String LoaiGBC_PropertyName { get { return "LoaiGBC"; } }
        private Nullable<int> _loaiGBC;
        partial void On_LoaiGBC_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LoaiGBC_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_GiayBaoCo_tblGiayBaoCo", "tblChungTu_GiayBaoCo")]
        public EntityCollection<tblChungTu_GiayBaoCo> tblChungTu_GiayBaoCo
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChungTu_GiayBaoCo>("PSC_ERPModel.FK_tblChungTu_GiayBaoCo_tblGiayBaoCo", "tblChungTu_GiayBaoCo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChungTu_GiayBaoCo_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChungTu_GiayBaoCo>("PSC_ERPModel.FK_tblChungTu_GiayBaoCo_tblGiayBaoCo", "tblChungTu_GiayBaoCo", value);
    					On_tblChungTu_GiayBaoCo_Changed(this.tblChungTu_GiayBaoCo);//\\//
    				}
    			}
            }
        }
    	public static String tblChungTu_GiayBaoCo_EntityCollectionPropertyName { get { return "tblChungTu_GiayBaoCo"; } }
    	partial void On_tblChungTu_GiayBaoCo_Changing(ref EntityCollection<tblChungTu_GiayBaoCo> newValue, ref bool stopChanging);
    	partial void On_tblChungTu_GiayBaoCo_Changed(EntityCollection<tblChungTu_GiayBaoCo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblGiayBaoCo_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users", "app_users").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users", "app_users", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblGiayBaoCo_app_users1", "app_users")]
        public app_users app_users1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users1", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users1", "app_users").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users1", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblGiayBaoCo_app_users1", "app_users", value);
                }
            }
        }

        #endregion

    }
}
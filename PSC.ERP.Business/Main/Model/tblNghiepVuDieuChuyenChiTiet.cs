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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblNghiepVuDieuChuyenChiTiet")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblNghiepVuDieuChuyenChiTiet : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblNghiepVuDieuChuyenChiTiet()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblNghiepVuDieuChuyenChiTiet object.
        /// </summary>
        /// <param name="maNghiepVuDieuChuyenChiTiet">Initial value of the MaNghiepVuDieuChuyenChiTiet property.</param>
        /// <param name="userID">Initial value of the UserID property.</param>
        public static tblNghiepVuDieuChuyenChiTiet CreatetblNghiepVuDieuChuyenChiTiet(long maNghiepVuDieuChuyenChiTiet, int userID)
        {
            tblNghiepVuDieuChuyenChiTiet tblNghiepVuDieuChuyenChiTiet = new tblNghiepVuDieuChuyenChiTiet();
            tblNghiepVuDieuChuyenChiTiet.MaNghiepVuDieuChuyenChiTiet = maNghiepVuDieuChuyenChiTiet;
            tblNghiepVuDieuChuyenChiTiet.UserID = userID;
            return tblNghiepVuDieuChuyenChiTiet;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaNghiepVuDieuChuyenChiTiet
        {
            get
            {
                return _maNghiepVuDieuChuyenChiTiet;
            }
            set
            {
                if (_maNghiepVuDieuChuyenChiTiet != value)
                {
        			long oldValue =  _maNghiepVuDieuChuyenChiTiet;
        			bool stopChanging = false;
                    On_MaNghiepVuDieuChuyenChiTiet_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNghiepVuDieuChuyenChiTiet");
        			if(!stopChanging)
        			{
        				_maNghiepVuDieuChuyenChiTiet = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNghiepVuDieuChuyenChiTiet");
        				On_MaNghiepVuDieuChuyenChiTiet_Changed(oldValue, _maNghiepVuDieuChuyenChiTiet);//\\
        			}
                }
            }
        }
    	public static String MaNghiepVuDieuChuyenChiTiet_PropertyName { get { return "MaNghiepVuDieuChuyenChiTiet"; } }
        private long _maNghiepVuDieuChuyenChiTiet;
        partial void On_MaNghiepVuDieuChuyenChiTiet_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaNghiepVuDieuChuyenChiTiet_Changed(long oldValue, long currentValue);
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			int oldValue =  _userID;
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
        private int _userID;
        partial void On_UserID_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_UserID_Changed(int oldValue, int currentValue);
    
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
        public string MaQuanLyChungTu
        {
            get
            {
                return _maQuanLyChungTu;
            }
            set
            {
    			string oldValue =  _maQuanLyChungTu;
    			bool stopChanging = false;
                On_MaQuanLyChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuanLyChungTu");
    			if(!stopChanging)
    			{
    				_maQuanLyChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQuanLyChungTu");
    				On_MaQuanLyChungTu_Changed(oldValue, _maQuanLyChungTu);//\\
    			}
            }
        }
    	public static String MaQuanLyChungTu_PropertyName { get { return "MaQuanLyChungTu"; } }
        private string _maQuanLyChungTu;
        partial void On_MaQuanLyChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQuanLyChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayTaoChungTu
        {
            get
            {
                return _ngayTaoChungTu;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayTaoChungTu;
    			bool stopChanging = false;
                On_NgayTaoChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayTaoChungTu");
    			if(!stopChanging)
    			{
    				_ngayTaoChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayTaoChungTu");
    				On_NgayTaoChungTu_Changed(oldValue, _ngayTaoChungTu);//\\
    			}
            }
        }
    	public static String NgayTaoChungTu_PropertyName { get { return "NgayTaoChungTu"; } }
        private Nullable<System.DateTime> _ngayTaoChungTu;
        partial void On_NgayTaoChungTu_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayTaoChungTu_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string LyDoDieuChuyen
        {
            get
            {
                return _lyDoDieuChuyen;
            }
            set
            {
    			string oldValue =  _lyDoDieuChuyen;
    			bool stopChanging = false;
                On_LyDoDieuChuyen_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LyDoDieuChuyen");
    			if(!stopChanging)
    			{
    				_lyDoDieuChuyen = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("LyDoDieuChuyen");
    				On_LyDoDieuChuyen_Changed(oldValue, _lyDoDieuChuyen);//\\
    			}
            }
        }
    	public static String LyDoDieuChuyen_PropertyName { get { return "LyDoDieuChuyen"; } }
        private string _lyDoDieuChuyen;
        partial void On_LyDoDieuChuyen_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_LyDoDieuChuyen_Changed(string oldValue, string currentValue);
    
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
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenChiTiet_Table_tblDoiTac", "tblDoiTac")]
        public tblDoiTac tblDoiTac
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDoiTac>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_Table_tblDoiTac", "tblDoiTac").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblDoiTac_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDoiTac>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_Table_tblDoiTac", "tblDoiTac").Value = value;
    				On_tblDoiTac_Changed(this.tblDoiTac);//\\//
    			}
    	    }
        }
    	public static String tblDoiTac_ReferencePropertyName { get { return "tblDoiTac"; } }
    	partial void On_tblDoiTac_Changing(ref tblDoiTac newValue, ref bool stopChanging);
    	partial void On_tblDoiTac_Changed(tblDoiTac currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblDoiTac> tblDoiTacReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDoiTac>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_Table_tblDoiTac", "tblDoiTac");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblDoiTac>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_Table_tblDoiTac", "tblDoiTac", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuDieuChuyenChiTiet_tblNghiepVuDieuChuyenChiTiet", "tblCT_NghiepVuDieuChuyenChiTiet")]
        public EntityCollection<tblCT_NghiepVuDieuChuyenChiTiet> tblCT_NghiepVuDieuChuyenChiTiet
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NghiepVuDieuChuyenChiTiet>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenChiTiet_tblNghiepVuDieuChuyenChiTiet", "tblCT_NghiepVuDieuChuyenChiTiet");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NghiepVuDieuChuyenChiTiet_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NghiepVuDieuChuyenChiTiet>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenChiTiet_tblNghiepVuDieuChuyenChiTiet", "tblCT_NghiepVuDieuChuyenChiTiet", value);
    					On_tblCT_NghiepVuDieuChuyenChiTiet_Changed(this.tblCT_NghiepVuDieuChuyenChiTiet);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_NghiepVuDieuChuyenChiTiet_EntityCollectionPropertyName { get { return "tblCT_NghiepVuDieuChuyenChiTiet"; } }
    	partial void On_tblCT_NghiepVuDieuChuyenChiTiet_Changing(ref EntityCollection<tblCT_NghiepVuDieuChuyenChiTiet> newValue, ref bool stopChanging);
    	partial void On_tblCT_NghiepVuDieuChuyenChiTiet_Changed(EntityCollection<tblCT_NghiepVuDieuChuyenChiTiet> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenChiTiet_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_app_users", "app_users").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenChiTiet_app_users", "app_users", value);
                }
            }
        }

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="ChungTu_HoSoFileLuuTru")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ChungTu_HoSoFileLuuTru : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public ChungTu_HoSoFileLuuTru()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new ChungTu_HoSoFileLuuTru object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static ChungTu_HoSoFileLuuTru CreateChungTu_HoSoFileLuuTru(long id)
        {
            ChungTu_HoSoFileLuuTru chungTu_HoSoFileLuuTru = new ChungTu_HoSoFileLuuTru();
            chungTu_HoSoFileLuuTru.ID = id;
            return chungTu_HoSoFileLuuTru;
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
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
    			string oldValue =  _username;
    			bool stopChanging = false;
                On_Username_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Username");
    			if(!stopChanging)
    			{
    				_username = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Username");
    				On_Username_Changed(oldValue, _username);//\\
    			}
            }
        }
    	public static String Username_PropertyName { get { return "Username"; } }
        private string _username;
        partial void On_Username_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Username_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
    			string oldValue =  _password;
    			bool stopChanging = false;
                On_Password_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Password");
    			if(!stopChanging)
    			{
    				_password = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Password");
    				On_Password_Changed(oldValue, _password);//\\
    			}
            }
        }
    	public static String Password_PropertyName { get { return "Password"; } }
        private string _password;
        partial void On_Password_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Password_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string URL_HoSoChungTu
        {
            get
            {
                return _uRL_HoSoChungTu;
            }
            set
            {
    			string oldValue =  _uRL_HoSoChungTu;
    			bool stopChanging = false;
                On_URL_HoSoChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("URL_HoSoChungTu");
    			if(!stopChanging)
    			{
    				_uRL_HoSoChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("URL_HoSoChungTu");
    				On_URL_HoSoChungTu_Changed(oldValue, _uRL_HoSoChungTu);//\\
    			}
            }
        }
    	public static String URL_HoSoChungTu_PropertyName { get { return "URL_HoSoChungTu"; } }
        private string _uRL_HoSoChungTu;
        partial void On_URL_HoSoChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_URL_HoSoChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string URL_CongTy
        {
            get
            {
                return _uRL_CongTy;
            }
            set
            {
    			string oldValue =  _uRL_CongTy;
    			bool stopChanging = false;
                On_URL_CongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("URL_CongTy");
    			if(!stopChanging)
    			{
    				_uRL_CongTy = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("URL_CongTy");
    				On_URL_CongTy_Changed(oldValue, _uRL_CongTy);//\\
    			}
            }
        }
    	public static String URL_CongTy_PropertyName { get { return "URL_CongTy"; } }
        private string _uRL_CongTy;
        partial void On_URL_CongTy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_URL_CongTy_Changed(string oldValue, string currentValue);
    
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
        public string TenFile
        {
            get
            {
                return _tenFile;
            }
            set
            {
    			string oldValue =  _tenFile;
    			bool stopChanging = false;
                On_TenFile_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenFile");
    			if(!stopChanging)
    			{
    				_tenFile = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenFile");
    				On_TenFile_Changed(oldValue, _tenFile);//\\
    			}
            }
        }
    	public static String TenFile_PropertyName { get { return "TenFile"; } }
        private string _tenFile;
        partial void On_TenFile_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenFile_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenFileUp
        {
            get
            {
                return _tenFileUp;
            }
            set
            {
    			string oldValue =  _tenFileUp;
    			bool stopChanging = false;
                On_TenFileUp_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenFileUp");
    			if(!stopChanging)
    			{
    				_tenFileUp = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenFileUp");
    				On_TenFileUp_Changed(oldValue, _tenFileUp);//\\
    			}
            }
        }
    	public static String TenFileUp_PropertyName { get { return "TenFileUp"; } }
        private string _tenFileUp;
        partial void On_TenFileUp_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenFileUp_Changed(string oldValue, string currentValue);
    
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

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_ChungTu_HoSoFileLuuTru_tblChungTu", "tblChungTu")]
        public tblChungTu tblChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_ChungTu_HoSoFileLuuTru_tblChungTu", "tblChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_ChungTu_HoSoFileLuuTru_tblChungTu", "tblChungTu").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblChungTu>("PSC_ERPModel.FK_ChungTu_HoSoFileLuuTru_tblChungTu", "tblChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblChungTu>("PSC_ERPModel.FK_ChungTu_HoSoFileLuuTru_tblChungTu", "tblChungTu", value);
                }
            }
        }

        #endregion

    }
}
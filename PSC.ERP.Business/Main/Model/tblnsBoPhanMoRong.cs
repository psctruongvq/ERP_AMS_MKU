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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsBoPhanMoRong")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsBoPhanMoRong : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsBoPhanMoRong()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsBoPhanMoRong object.
        /// </summary>
        /// <param name="maBoPhanMoRong">Initial value of the MaBoPhanMoRong property.</param>
        public static tblnsBoPhanMoRong CreatetblnsBoPhanMoRong(int maBoPhanMoRong)
        {
            tblnsBoPhanMoRong tblnsBoPhanMoRong = new tblnsBoPhanMoRong();
            tblnsBoPhanMoRong.MaBoPhanMoRong = maBoPhanMoRong;
            return tblnsBoPhanMoRong;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBoPhanMoRong
        {
            get
            {
                return _maBoPhanMoRong;
            }
            set
            {
                if (_maBoPhanMoRong != value)
                {
        			int oldValue =  _maBoPhanMoRong;
        			bool stopChanging = false;
                    On_MaBoPhanMoRong_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaBoPhanMoRong");
        			if(!stopChanging)
        			{
        				_maBoPhanMoRong = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaBoPhanMoRong");
        				On_MaBoPhanMoRong_Changed(oldValue, _maBoPhanMoRong);//\\
        			}
                }
            }
        }
    	public static String MaBoPhanMoRong_PropertyName { get { return "MaBoPhanMoRong"; } }
        private int _maBoPhanMoRong;
        partial void On_MaBoPhanMoRong_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhanMoRong_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
    			string oldValue =  _maQuanLy;
    			bool stopChanging = false;
                On_MaQuanLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuanLy");
    			if(!stopChanging)
    			{
    				_maQuanLy = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQuanLy");
    				On_MaQuanLy_Changed(oldValue, _maQuanLy);//\\
    			}
            }
        }
    	public static String MaQuanLy_PropertyName { get { return "MaQuanLy"; } }
        private string _maQuanLy;
        partial void On_MaQuanLy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQuanLy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhanMoRong
        {
            get
            {
                return _tenBoPhanMoRong;
            }
            set
            {
    			string oldValue =  _tenBoPhanMoRong;
    			bool stopChanging = false;
                On_TenBoPhanMoRong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhanMoRong");
    			if(!stopChanging)
    			{
    				_tenBoPhanMoRong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhanMoRong");
    				On_TenBoPhanMoRong_Changed(oldValue, _tenBoPhanMoRong);//\\
    			}
            }
        }
    	public static String TenBoPhanMoRong_PropertyName { get { return "TenBoPhanMoRong"; } }
        private string _tenBoPhanMoRong;
        partial void On_TenBoPhanMoRong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhanMoRong_Changed(string oldValue, string currentValue);
    
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
        public Nullable<bool> KhauHaoHaoMon
        {
            get
            {
                return _khauHaoHaoMon;
            }
            set
            {
    			Nullable<bool> oldValue =  _khauHaoHaoMon;
    			bool stopChanging = false;
                On_KhauHaoHaoMon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhauHaoHaoMon");
    			if(!stopChanging)
    			{
    				_khauHaoHaoMon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhauHaoHaoMon");
    				On_KhauHaoHaoMon_Changed(oldValue, _khauHaoHaoMon);//\\
    			}
            }
        }
    	public static String KhauHaoHaoMon_PropertyName { get { return "KhauHaoHaoMon"; } }
        private Nullable<bool> _khauHaoHaoMon;
        partial void On_KhauHaoHaoMon_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhauHaoHaoMon_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhanCha
        {
            get
            {
                return _maBoPhanCha;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhanCha;
    			bool stopChanging = false;
                On_MaBoPhanCha_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanCha");
    			if(!stopChanging)
    			{
    				_maBoPhanCha = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhanCha");
    				On_MaBoPhanCha_Changed(oldValue, _maBoPhanCha);//\\
    			}
            }
        }
    	public static String MaBoPhanCha_PropertyName { get { return "MaBoPhanCha"; } }
        private Nullable<int> _maBoPhanCha;
        partial void On_MaBoPhanCha_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhanCha_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsBoPhanMoRong_NhanVien_tblnsBoPhanMoRong", "tblnsBoPhanMoRong_NhanVien")]
        public EntityCollection<tblnsBoPhanMoRong_NhanVien> tblnsBoPhanMoRong_NhanVien
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsBoPhanMoRong_NhanVien>("PSC_ERPModel.FK_tblnsBoPhanMoRong_NhanVien_tblnsBoPhanMoRong", "tblnsBoPhanMoRong_NhanVien");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsBoPhanMoRong_NhanVien_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsBoPhanMoRong_NhanVien>("PSC_ERPModel.FK_tblnsBoPhanMoRong_NhanVien_tblnsBoPhanMoRong", "tblnsBoPhanMoRong_NhanVien", value);
    					On_tblnsBoPhanMoRong_NhanVien_Changed(this.tblnsBoPhanMoRong_NhanVien);//\\//
    				}
    			}
            }
        }
    	public static String tblnsBoPhanMoRong_NhanVien_EntityCollectionPropertyName { get { return "tblnsBoPhanMoRong_NhanVien"; } }
    	partial void On_tblnsBoPhanMoRong_NhanVien_Changing(ref EntityCollection<tblnsBoPhanMoRong_NhanVien> newValue, ref bool stopChanging);
    	partial void On_tblnsBoPhanMoRong_NhanVien_Changed(EntityCollection<tblnsBoPhanMoRong_NhanVien> currentValue);

        #endregion

    }
}

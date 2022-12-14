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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsKyTinhLuong")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsKyTinhLuong : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsKyTinhLuong()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsKyTinhLuong object.
        /// </summary>
        /// <param name="maKy">Initial value of the MaKy property.</param>
        /// <param name="ngayBatDau">Initial value of the NgayBatDau property.</param>
        /// <param name="ngayKetThuc">Initial value of the NgayKetThuc property.</param>
        public static tblnsKyTinhLuong CreatetblnsKyTinhLuong(int maKy, System.DateTime ngayBatDau, System.DateTime ngayKetThuc)
        {
            tblnsKyTinhLuong tblnsKyTinhLuong = new tblnsKyTinhLuong();
            tblnsKyTinhLuong.MaKy = maKy;
            tblnsKyTinhLuong.NgayBatDau = ngayBatDau;
            tblnsKyTinhLuong.NgayKetThuc = ngayKetThuc;
            return tblnsKyTinhLuong;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaKy
        {
            get
            {
                return _maKy;
            }
            set
            {
                if (_maKy != value)
                {
        			int oldValue =  _maKy;
        			bool stopChanging = false;
                    On_MaKy_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaKy");
        			if(!stopChanging)
        			{
        				_maKy = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaKy");
        				On_MaKy_Changed(oldValue, _maKy);//\\
        			}
                }
            }
        }
    	public static String MaKy_PropertyName { get { return "MaKy"; } }
        private int _maKy;
        partial void On_MaKy_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaKy_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenKy
        {
            get
            {
                return _tenKy;
            }
            set
            {
    			string oldValue =  _tenKy;
    			bool stopChanging = false;
                On_TenKy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenKy");
    			if(!stopChanging)
    			{
    				_tenKy = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenKy");
    				On_TenKy_Changed(oldValue, _tenKy);//\\
    			}
            }
        }
    	public static String TenKy_PropertyName { get { return "TenKy"; } }
        private string _tenKy;
        partial void On_TenKy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenKy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime NgayBatDau
        {
            get
            {
                return _ngayBatDau;
            }
            set
            {
    			System.DateTime oldValue =  _ngayBatDau;
    			bool stopChanging = false;
                On_NgayBatDau_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayBatDau");
    			if(!stopChanging)
    			{
    				_ngayBatDau = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayBatDau");
    				On_NgayBatDau_Changed(oldValue, _ngayBatDau);//\\
    			}
            }
        }
    	public static String NgayBatDau_PropertyName { get { return "NgayBatDau"; } }
        private System.DateTime _ngayBatDau;
        partial void On_NgayBatDau_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_NgayBatDau_Changed(System.DateTime oldValue, System.DateTime currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime NgayKetThuc
        {
            get
            {
                return _ngayKetThuc;
            }
            set
            {
    			System.DateTime oldValue =  _ngayKetThuc;
    			bool stopChanging = false;
                On_NgayKetThuc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayKetThuc");
    			if(!stopChanging)
    			{
    				_ngayKetThuc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayKetThuc");
    				On_NgayKetThuc_Changed(oldValue, _ngayKetThuc);//\\
    			}
            }
        }
    	public static String NgayKetThuc_PropertyName { get { return "NgayKetThuc"; } }
        private System.DateTime _ngayKetThuc;
        partial void On_NgayKetThuc_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_NgayKetThuc_Changed(System.DateTime oldValue, System.DateTime currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<byte> Thang
        {
            get
            {
                return _thang;
            }
            set
            {
    			Nullable<byte> oldValue =  _thang;
    			bool stopChanging = false;
                On_Thang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Thang");
    			if(!stopChanging)
    			{
    				_thang = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Thang");
    				On_Thang_Changed(oldValue, _thang);//\\
    			}
            }
        }
    	public static String Thang_PropertyName { get { return "Thang"; } }
        private Nullable<byte> _thang;
        partial void On_Thang_Changing(Nullable<byte> currentValue, ref Nullable<byte> newValue, ref bool stopChanging);
        partial void On_Thang_Changed(Nullable<byte> oldValue, Nullable<byte> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhoaSo
        {
            get
            {
                return _khoaSo;
            }
            set
            {
    			Nullable<bool> oldValue =  _khoaSo;
    			bool stopChanging = false;
                On_KhoaSo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhoaSo");
    			if(!stopChanging)
    			{
    				_khoaSo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhoaSo");
    				On_KhoaSo_Changed(oldValue, _khoaSo);//\\
    			}
            }
        }
    	public static String KhoaSo_PropertyName { get { return "KhoaSo"; } }
        private Nullable<bool> _khoaSo;
        partial void On_KhoaSo_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhoaSo_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> Nam
        {
            get
            {
                return _nam;
            }
            set
            {
    			Nullable<int> oldValue =  _nam;
    			bool stopChanging = false;
                On_Nam_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Nam");
    			if(!stopChanging)
    			{
    				_nam = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Nam");
    				On_Nam_Changed(oldValue, _nam);//\\
    			}
            }
        }
    	public static String Nam_PropertyName { get { return "Nam"; } }
        private Nullable<int> _nam;
        partial void On_Nam_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_Nam_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> DungChung
        {
            get
            {
                return _dungChung;
            }
            set
            {
    			Nullable<bool> oldValue =  _dungChung;
    			bool stopChanging = false;
                On_DungChung_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DungChung");
    			if(!stopChanging)
    			{
    				_dungChung = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DungChung");
    				On_DungChung_Changed(oldValue, _dungChung);//\\
    			}
            }
        }
    	public static String DungChung_PropertyName { get { return "DungChung"; } }
        private Nullable<bool> _dungChung;
        partial void On_DungChung_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_DungChung_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhoaKy1
        {
            get
            {
                return _khoaKy1;
            }
            set
            {
    			Nullable<bool> oldValue =  _khoaKy1;
    			bool stopChanging = false;
                On_KhoaKy1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhoaKy1");
    			if(!stopChanging)
    			{
    				_khoaKy1 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhoaKy1");
    				On_KhoaKy1_Changed(oldValue, _khoaKy1);//\\
    			}
            }
        }
    	public static String KhoaKy1_PropertyName { get { return "KhoaKy1"; } }
        private Nullable<bool> _khoaKy1;
        partial void On_KhoaKy1_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhoaKy1_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhoaKy2
        {
            get
            {
                return _khoaKy2;
            }
            set
            {
    			Nullable<bool> oldValue =  _khoaKy2;
    			bool stopChanging = false;
                On_KhoaKy2_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhoaKy2");
    			if(!stopChanging)
    			{
    				_khoaKy2 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhoaKy2");
    				On_KhoaKy2_Changed(oldValue, _khoaKy2);//\\
    			}
            }
        }
    	public static String KhoaKy2_PropertyName { get { return "KhoaKy2"; } }
        private Nullable<bool> _khoaKy2;
        partial void On_KhoaKy2_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhoaKy2_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoNgay
        {
            get
            {
                return _soNgay;
            }
            set
            {
    			Nullable<int> oldValue =  _soNgay;
    			bool stopChanging = false;
                On_SoNgay_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoNgay");
    			if(!stopChanging)
    			{
    				_soNgay = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoNgay");
    				On_SoNgay_Changed(oldValue, _soNgay);//\\
    			}
            }
        }
    	public static String SoNgay_PropertyName { get { return "SoNgay"; } }
        private Nullable<int> _soNgay;
        partial void On_SoNgay_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoNgay_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> TruThueTNCN
        {
            get
            {
                return _truThueTNCN;
            }
            set
            {
    			Nullable<bool> oldValue =  _truThueTNCN;
    			bool stopChanging = false;
                On_TruThueTNCN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TruThueTNCN");
    			if(!stopChanging)
    			{
    				_truThueTNCN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TruThueTNCN");
    				On_TruThueTNCN_Changed(oldValue, _truThueTNCN);//\\
    			}
            }
        }
    	public static String TruThueTNCN_PropertyName { get { return "TruThueTNCN"; } }
        private Nullable<bool> _truThueTNCN;
        partial void On_TruThueTNCN_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_TruThueTNCN_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhoaKy3
        {
            get
            {
                return _khoaKy3;
            }
            set
            {
    			Nullable<bool> oldValue =  _khoaKy3;
    			bool stopChanging = false;
                On_KhoaKy3_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhoaKy3");
    			if(!stopChanging)
    			{
    				_khoaKy3 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhoaKy3");
    				On_KhoaKy3_Changed(oldValue, _khoaKy3);//\\
    			}
            }
        }
    	public static String KhoaKy3_PropertyName { get { return "KhoaKy3"; } }
        private Nullable<bool> _khoaKy3;
        partial void On_KhoaKy3_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhoaKy3_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayKhoaThuLao
        {
            get
            {
                return _ngayKhoaThuLao;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayKhoaThuLao;
    			bool stopChanging = false;
                On_NgayKhoaThuLao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayKhoaThuLao");
    			if(!stopChanging)
    			{
    				_ngayKhoaThuLao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayKhoaThuLao");
    				On_NgayKhoaThuLao_Changed(oldValue, _ngayKhoaThuLao);//\\
    			}
            }
        }
    	public static String NgayKhoaThuLao_PropertyName { get { return "NgayKhoaThuLao"; } }
        private Nullable<System.DateTime> _ngayKhoaThuLao;
        partial void On_NgayKhoaThuLao_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayKhoaThuLao_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaKyChinh
        {
            get
            {
                return _maKyChinh;
            }
            set
            {
    			Nullable<int> oldValue =  _maKyChinh;
    			bool stopChanging = false;
                On_MaKyChinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaKyChinh");
    			if(!stopChanging)
    			{
    				_maKyChinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaKyChinh");
    				On_MaKyChinh_Changed(oldValue, _maKyChinh);//\\
    			}
            }
        }
    	public static String MaKyChinh_PropertyName { get { return "MaKyChinh"; } }
        private Nullable<int> _maKyChinh;
        partial void On_MaKyChinh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaKyChinh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhan;
    			bool stopChanging = false;
                On_MaBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhan");
    			if(!stopChanging)
    			{
    				_maBoPhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhan");
    				On_MaBoPhan_Changed(oldValue, _maBoPhan);//\\
    			}
            }
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private Nullable<int> _maBoPhan;
        partial void On_MaBoPhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsBoPhan")]
        public tblnsBoPhan tblnsBoPhan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsBoPhan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsBoPhan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsBoPhan").Value = value;
    				On_tblnsBoPhan_Changed(this.tblnsBoPhan);//\\//
    			}
    	    }
        }
    	public static String tblnsBoPhan_ReferencePropertyName { get { return "tblnsBoPhan"; } }
    	partial void On_tblnsBoPhan_Changing(ref tblnsBoPhan newValue, ref bool stopChanging);
    	partial void On_tblnsBoPhan_Changed(tblnsBoPhan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsBoPhan> tblnsBoPhanReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsBoPhan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsBoPhan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsKhoaKyLuong_tblnsKyTinhLuong", "tblnsKhoaKyLuong")]
        public EntityCollection<tblnsKhoaKyLuong> tblnsKhoaKyLuongs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsKhoaKyLuong>("PSC_ERPModel.FK_tblnsKhoaKyLuong_tblnsKyTinhLuong", "tblnsKhoaKyLuong");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsKhoaKyLuongs_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsKhoaKyLuong>("PSC_ERPModel.FK_tblnsKhoaKyLuong_tblnsKyTinhLuong", "tblnsKhoaKyLuong", value);
    					On_tblnsKhoaKyLuongs_Changed(this.tblnsKhoaKyLuongs);//\\//
    				}
    			}
            }
        }
    	public static String tblnsKhoaKyLuongs_EntityCollectionPropertyName { get { return "tblnsKhoaKyLuongs"; } }
    	partial void On_tblnsKhoaKyLuongs_Changing(ref EntityCollection<tblnsKhoaKyLuong> newValue, ref bool stopChanging);
    	partial void On_tblnsKhoaKyLuongs_Changed(EntityCollection<tblnsKhoaKyLuong> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong1")]
        public EntityCollection<tblnsKyTinhLuong> tblnsKyTinhLuong1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong1");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsKyTinhLuong1_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong1", value);
    					On_tblnsKyTinhLuong1_Changed(this.tblnsKyTinhLuong1);//\\//
    				}
    			}
            }
        }
    	public static String tblnsKyTinhLuong1_EntityCollectionPropertyName { get { return "tblnsKyTinhLuong1"; } }
    	partial void On_tblnsKyTinhLuong1_Changing(ref EntityCollection<tblnsKyTinhLuong> newValue, ref bool stopChanging);
    	partial void On_tblnsKyTinhLuong1_Changed(EntityCollection<tblnsKyTinhLuong> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong")]
        public tblnsKyTinhLuong tblnsKyTinhLuong2
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsKyTinhLuong2_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong").Value = value;
    				On_tblnsKyTinhLuong2_Changed(this.tblnsKyTinhLuong2);//\\//
    			}
    	    }
        }
    	public static String tblnsKyTinhLuong2_ReferencePropertyName { get { return "tblnsKyTinhLuong2"; } }
    	partial void On_tblnsKyTinhLuong2_Changing(ref tblnsKyTinhLuong newValue, ref bool stopChanging);
    	partial void On_tblnsKyTinhLuong2_Changed(tblnsKyTinhLuong currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsKyTinhLuong> tblnsKyTinhLuong2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsKyTinhLuong", "tblnsKyTinhLuong", value);
                }
            }
        }

        #endregion

    }
}

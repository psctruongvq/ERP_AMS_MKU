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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsBoPhan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsBoPhan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsBoPhan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsBoPhan object.
        /// </summary>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        public static tblnsBoPhan CreatetblnsBoPhan(int maBoPhan)
        {
            tblnsBoPhan tblnsBoPhan = new tblnsBoPhan();
            tblnsBoPhan.MaBoPhan = maBoPhan;
            return tblnsBoPhan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (_maBoPhan != value)
                {
        			int oldValue =  _maBoPhan;
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
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private int _maBoPhan;
        partial void On_MaBoPhan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
            set
            {
    			string oldValue =  _maBoPhanQL;
    			bool stopChanging = false;
                On_MaBoPhanQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanQL");
    			if(!stopChanging)
    			{
    				_maBoPhanQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaBoPhanQL");
    				On_MaBoPhanQL_Changed(oldValue, _maBoPhanQL);//\\
    			}
            }
        }
    	public static String MaBoPhanQL_PropertyName { get { return "MaBoPhanQL"; } }
        private string _maBoPhanQL;
        partial void On_MaBoPhanQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaBoPhanQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
            set
            {
    			string oldValue =  _tenBoPhan;
    			bool stopChanging = false;
                On_TenBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhan");
    			if(!stopChanging)
    			{
    				_tenBoPhan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhan");
    				On_TenBoPhan_Changed(oldValue, _tenBoPhan);//\\
    			}
            }
        }
    	public static String TenBoPhan_PropertyName { get { return "TenBoPhan"; } }
        private string _tenBoPhan;
        partial void On_TenBoPhan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayTao
        {
            get
            {
                return _ngayTao;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayTao;
    			bool stopChanging = false;
                On_NgayTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayTao");
    			if(!stopChanging)
    			{
    				_ngayTao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayTao");
    				On_NgayTao_Changed(oldValue, _ngayTao);//\\
    			}
            }
        }
    	public static String NgayTao_PropertyName { get { return "NgayTao"; } }
        private Nullable<System.DateTime> _ngayTao;
        partial void On_NgayTao_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayTao_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiBoPhan
        {
            get
            {
                return _maLoaiBoPhan;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiBoPhan;
    			bool stopChanging = false;
                On_MaLoaiBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiBoPhan");
    			if(!stopChanging)
    			{
    				_maLoaiBoPhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiBoPhan");
    				On_MaLoaiBoPhan_Changed(oldValue, _maLoaiBoPhan);//\\
    			}
            }
        }
    	public static String MaLoaiBoPhan_PropertyName { get { return "MaLoaiBoPhan"; } }
        private Nullable<int> _maLoaiBoPhan;
        partial void On_MaLoaiBoPhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiBoPhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
    			Nullable<int> oldValue =  _maCongTy;
    			bool stopChanging = false;
                On_MaCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaCongTy");
    			if(!stopChanging)
    			{
    				_maCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaCongTy");
    				On_MaCongTy_Changed(oldValue, _maCongTy);//\\
    			}
            }
        }
    	public static String MaCongTy_PropertyName { get { return "MaCongTy"; } }
        private Nullable<int> _maCongTy;
        partial void On_MaCongTy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaCongTy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhongTinhLuong
        {
            get
            {
                return _khongTinhLuong;
            }
            set
            {
    			Nullable<bool> oldValue =  _khongTinhLuong;
    			bool stopChanging = false;
                On_KhongTinhLuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhongTinhLuong");
    			if(!stopChanging)
    			{
    				_khongTinhLuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhongTinhLuong");
    				On_KhongTinhLuong_Changed(oldValue, _khongTinhLuong);//\\
    			}
            }
        }
    	public static String KhongTinhLuong_PropertyName { get { return "KhongTinhLuong"; } }
        private Nullable<bool> _khongTinhLuong;
        partial void On_KhongTinhLuong_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhongTinhLuong_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
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
        public Nullable<int> MaPhanCap
        {
            get
            {
                return _maPhanCap;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhanCap;
    			bool stopChanging = false;
                On_MaPhanCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhanCap");
    			if(!stopChanging)
    			{
    				_maPhanCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhanCap");
    				On_MaPhanCap_Changed(oldValue, _maPhanCap);//\\
    			}
            }
        }
    	public static String MaPhanCap_PropertyName { get { return "MaPhanCap"; } }
        private Nullable<int> _maPhanCap;
        partial void On_MaPhanCap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhanCap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
            set
            {
    			Nullable<int> oldValue =  _nguoiLap;
    			bool stopChanging = false;
                On_NguoiLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguoiLap");
    			if(!stopChanging)
    			{
    				_nguoiLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguoiLap");
    				On_NguoiLap_Changed(oldValue, _nguoiLap);//\\
    			}
            }
        }
    	public static String NguoiLap_PropertyName { get { return "NguoiLap"; } }
        private Nullable<int> _nguoiLap;
        partial void On_NguoiLap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NguoiLap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.Guid> OidHRM
        {
            get
            {
                return _oidHRM;
            }
            set
            {
    			Nullable<System.Guid> oldValue =  _oidHRM;
    			bool stopChanging = false;
                On_OidHRM_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("OidHRM");
    			if(!stopChanging)
    			{
    				_oidHRM = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("OidHRM");
    				On_OidHRM_Changed(oldValue, _oidHRM);//\\
    			}
            }
        }
    	public static String OidHRM_PropertyName { get { return "OidHRM"; } }
        private Nullable<System.Guid> _oidHRM;
        partial void On_OidHRM_Changing(Nullable<System.Guid> currentValue, ref Nullable<System.Guid> newValue, ref bool stopChanging);
        partial void On_OidHRM_Changed(Nullable<System.Guid> oldValue, Nullable<System.Guid> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> NgungSuDung
        {
            get
            {
                return _ngungSuDung;
            }
            set
            {
    			Nullable<bool> oldValue =  _ngungSuDung;
    			bool stopChanging = false;
                On_NgungSuDung_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgungSuDung");
    			if(!stopChanging)
    			{
    				_ngungSuDung = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgungSuDung");
    				On_NgungSuDung_Changed(oldValue, _ngungSuDung);//\\
    			}
            }
        }
    	public static String NgungSuDung_PropertyName { get { return "NgungSuDung"; } }
        private Nullable<bool> _ngungSuDung;
        partial void On_NgungSuDung_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_NgungSuDung_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TaiKhoanKHHM
        {
            get
            {
                return _taiKhoanKHHM;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanKHHM;
    			bool stopChanging = false;
                On_TaiKhoanKHHM_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanKHHM");
    			if(!stopChanging)
    			{
    				_taiKhoanKHHM = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanKHHM");
    				On_TaiKhoanKHHM_Changed(oldValue, _taiKhoanKHHM);//\\
    			}
            }
        }
    	public static String TaiKhoanKHHM_PropertyName { get { return "TaiKhoanKHHM"; } }
        private Nullable<int> _taiKhoanKHHM;
        partial void On_TaiKhoanKHHM_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanKHHM_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TaiKhoanPBCP
        {
            get
            {
                return _taiKhoanPBCP;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanPBCP;
    			bool stopChanging = false;
                On_TaiKhoanPBCP_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanPBCP");
    			if(!stopChanging)
    			{
    				_taiKhoanPBCP = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanPBCP");
    				On_TaiKhoanPBCP_Changed(oldValue, _taiKhoanPBCP);//\\
    			}
            }
        }
    	public static String TaiKhoanPBCP_PropertyName { get { return "TaiKhoanPBCP"; } }
        private Nullable<int> _taiKhoanPBCP;
        partial void On_TaiKhoanPBCP_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanPBCP_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string KyHieuInMaVachGhiTang
        {
            get
            {
                return _kyHieuInMaVachGhiTang;
            }
            set
            {
    			string oldValue =  _kyHieuInMaVachGhiTang;
    			bool stopChanging = false;
                On_KyHieuInMaVachGhiTang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KyHieuInMaVachGhiTang");
    			if(!stopChanging)
    			{
    				_kyHieuInMaVachGhiTang = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("KyHieuInMaVachGhiTang");
    				On_KyHieuInMaVachGhiTang_Changed(oldValue, _kyHieuInMaVachGhiTang);//\\
    			}
            }
        }
    	public static String KyHieuInMaVachGhiTang_PropertyName { get { return "KyHieuInMaVachGhiTang"; } }
        private string _kyHieuInMaVachGhiTang;
        partial void On_KyHieuInMaVachGhiTang_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_KyHieuInMaVachGhiTang_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblcnChiThuLao_tblnsBoPhan", "tblcnChiThuLao")]
        public EntityCollection<tblcnChiThuLao> tblcnChiThuLaos
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblcnChiThuLao>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblcnChiThuLao");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblcnChiThuLaos_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblcnChiThuLao>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblcnChiThuLao", value);
    					On_tblcnChiThuLaos_Changed(this.tblcnChiThuLaos);//\\//
    				}
    			}
            }
        }
    	public static String tblcnChiThuLaos_EntityCollectionPropertyName { get { return "tblcnChiThuLaos"; } }
    	partial void On_tblcnChiThuLaos_Changing(ref EntityCollection<tblcnChiThuLao> newValue, ref bool stopChanging);
    	partial void On_tblcnChiThuLaos_Changed(EntityCollection<tblcnChiThuLao> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsKyTinhLuong")]
        public EntityCollection<tblnsKyTinhLuong> tblnsKyTinhLuongs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsKyTinhLuong");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsKyTinhLuongs_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsKyTinhLuong>("PSC_ERPModel.FK_tblnsKyTinhLuong_tblnsBoPhan", "tblnsKyTinhLuong", value);
    					On_tblnsKyTinhLuongs_Changed(this.tblnsKyTinhLuongs);//\\//
    				}
    			}
            }
        }
    	public static String tblnsKyTinhLuongs_EntityCollectionPropertyName { get { return "tblnsKyTinhLuongs"; } }
    	partial void On_tblnsKyTinhLuongs_Changing(ref EntityCollection<tblnsKyTinhLuong> newValue, ref bool stopChanging);
    	partial void On_tblnsKyTinhLuongs_Changed(EntityCollection<tblnsKyTinhLuong> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTuImport_tblnsBoPhan", "tblChungTuImport")]
        public EntityCollection<tblChungTuImport> tblChungTuImports
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChungTuImport>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblChungTuImport");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChungTuImports_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChungTuImport>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblChungTuImport", value);
    					On_tblChungTuImports_Changed(this.tblChungTuImports);//\\//
    				}
    			}
            }
        }
    	public static String tblChungTuImports_EntityCollectionPropertyName { get { return "tblChungTuImports"; } }
    	partial void On_tblChungTuImports_Changing(ref EntityCollection<tblChungTuImport> newValue, ref bool stopChanging);
    	partial void On_tblChungTuImports_Changed(EntityCollection<tblChungTuImport> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_DigitizingBag_tblnsBoPhan", "DigitizingBag")]
        public EntityCollection<DigitizingBag> DigitizingBags
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<DigitizingBag>("PSC_ERPModel.FK_DigitizingBag_tblnsBoPhan", "DigitizingBag");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_DigitizingBags_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<DigitizingBag>("PSC_ERPModel.FK_DigitizingBag_tblnsBoPhan", "DigitizingBag", value);
    					On_DigitizingBags_Changed(this.DigitizingBags);//\\//
    				}
    			}
            }
        }
    	public static String DigitizingBags_EntityCollectionPropertyName { get { return "DigitizingBags"; } }
    	partial void On_DigitizingBags_Changing(ref EntityCollection<DigitizingBag> newValue, ref bool stopChanging);
    	partial void On_DigitizingBags_Changed(EntityCollection<DigitizingBag> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblTaiSanCoDinhCaBiet_PhongBan_tblBoPhanERPNew", "tblTaiSanCoDinhCaBiet_PhongBan")]
        public EntityCollection<tblTaiSanCoDinhCaBiet_PhongBan> tblTaiSanCoDinhCaBiet_PhongBan
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblTaiSanCoDinhCaBiet_PhongBan>("PSC_ERPModel.FK_tblTaiSanCoDinhCaBiet_PhongBan_tblBoPhanERPNew", "tblTaiSanCoDinhCaBiet_PhongBan");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblTaiSanCoDinhCaBiet_PhongBan_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblTaiSanCoDinhCaBiet_PhongBan>("PSC_ERPModel.FK_tblTaiSanCoDinhCaBiet_PhongBan_tblBoPhanERPNew", "tblTaiSanCoDinhCaBiet_PhongBan", value);
    					On_tblTaiSanCoDinhCaBiet_PhongBan_Changed(this.tblTaiSanCoDinhCaBiet_PhongBan);//\\//
    				}
    			}
            }
        }
    	public static String tblTaiSanCoDinhCaBiet_PhongBan_EntityCollectionPropertyName { get { return "tblTaiSanCoDinhCaBiet_PhongBan"; } }
    	partial void On_tblTaiSanCoDinhCaBiet_PhongBan_Changing(ref EntityCollection<tblTaiSanCoDinhCaBiet_PhongBan> newValue, ref bool stopChanging);
    	partial void On_tblTaiSanCoDinhCaBiet_PhongBan_Changed(EntityCollection<tblTaiSanCoDinhCaBiet_PhongBan> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblNghiepVuDieuChuyenNoiBo")]
        public EntityCollection<tblNghiepVuDieuChuyenNoiBo> tblNghiepVuDieuChuyenNoiBoes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblNghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblNghiepVuDieuChuyenNoiBo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblNghiepVuDieuChuyenNoiBoes_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblNghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblNghiepVuDieuChuyenNoiBo", value);
    					On_tblNghiepVuDieuChuyenNoiBoes_Changed(this.tblNghiepVuDieuChuyenNoiBoes);//\\//
    				}
    			}
            }
        }
    	public static String tblNghiepVuDieuChuyenNoiBoes_EntityCollectionPropertyName { get { return "tblNghiepVuDieuChuyenNoiBoes"; } }
    	partial void On_tblNghiepVuDieuChuyenNoiBoes_Changing(ref EntityCollection<tblNghiepVuDieuChuyenNoiBo> newValue, ref bool stopChanging);
    	partial void On_tblNghiepVuDieuChuyenNoiBoes_Changed(EntityCollection<tblNghiepVuDieuChuyenNoiBo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblNghiepVuDieuChuyenNoiBo")]
        public EntityCollection<tblNghiepVuDieuChuyenNoiBo> tblNghiepVuDieuChuyenNoiBoes1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblNghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblNghiepVuDieuChuyenNoiBo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblNghiepVuDieuChuyenNoiBoes1_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblNghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblNghiepVuDieuChuyenNoiBo", value);
    					On_tblNghiepVuDieuChuyenNoiBoes1_Changed(this.tblNghiepVuDieuChuyenNoiBoes1);//\\//
    				}
    			}
            }
        }
    	public static String tblNghiepVuDieuChuyenNoiBoes1_EntityCollectionPropertyName { get { return "tblNghiepVuDieuChuyenNoiBoes1"; } }
    	partial void On_tblNghiepVuDieuChuyenNoiBoes1_Changing(ref EntityCollection<tblNghiepVuDieuChuyenNoiBo> newValue, ref bool stopChanging);
    	partial void On_tblNghiepVuDieuChuyenNoiBoes1_Changed(EntityCollection<tblNghiepVuDieuChuyenNoiBo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsBoPhan_tblTaiKhoan", "tblTaiKhoan")]
        public tblTaiKhoan tblTaiKhoan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblnsBoPhan_tblTaiKhoan", "tblTaiKhoan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiKhoan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblnsBoPhan_tblTaiKhoan", "tblTaiKhoan").Value = value;
    				On_tblTaiKhoan_Changed(this.tblTaiKhoan);//\\//
    			}
    	    }
        }
    	public static String tblTaiKhoan_ReferencePropertyName { get { return "tblTaiKhoan"; } }
    	partial void On_tblTaiKhoan_Changing(ref tblTaiKhoan newValue, ref bool stopChanging);
    	partial void On_tblTaiKhoan_Changed(tblTaiKhoan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblTaiKhoan> tblTaiKhoanReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblnsBoPhan_tblTaiKhoan", "tblTaiKhoan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblnsBoPhan_tblTaiKhoan", "tblTaiKhoan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_ChungTyLePhanBoKhauHaoTSCD_tblnsBoPhan", "tblCT_ChungTyLePhanBoKhauHaoTSCD")]
        public EntityCollection<tblCT_ChungTyLePhanBoKhauHaoTSCD> tblCT_ChungTyLePhanBoKhauHaoTSCD
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_ChungTyLePhanBoKhauHaoTSCD>("PSC_ERPModel.FK_tblCT_ChungTyLePhanBoKhauHaoTSCD_tblnsBoPhan", "tblCT_ChungTyLePhanBoKhauHaoTSCD");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_ChungTyLePhanBoKhauHaoTSCD_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_ChungTyLePhanBoKhauHaoTSCD>("PSC_ERPModel.FK_tblCT_ChungTyLePhanBoKhauHaoTSCD_tblnsBoPhan", "tblCT_ChungTyLePhanBoKhauHaoTSCD", value);
    					On_tblCT_ChungTyLePhanBoKhauHaoTSCD_Changed(this.tblCT_ChungTyLePhanBoKhauHaoTSCD);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_ChungTyLePhanBoKhauHaoTSCD_EntityCollectionPropertyName { get { return "tblCT_ChungTyLePhanBoKhauHaoTSCD"; } }
    	partial void On_tblCT_ChungTyLePhanBoKhauHaoTSCD_Changing(ref EntityCollection<tblCT_ChungTyLePhanBoKhauHaoTSCD> newValue, ref bool stopChanging);
    	partial void On_tblCT_ChungTyLePhanBoKhauHaoTSCD_Changed(EntityCollection<tblCT_ChungTyLePhanBoKhauHaoTSCD> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblKiemKeTaiSan_tblBoPhanERPNew1", "tblKiemKeTaiSan")]
        public EntityCollection<tblKiemKeTaiSan> tblKiemKeTaiSans
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblKiemKeTaiSan>("PSC_ERPModel.FK_tblKiemKeTaiSan_tblBoPhanERPNew1", "tblKiemKeTaiSan");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblKiemKeTaiSans_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblKiemKeTaiSan>("PSC_ERPModel.FK_tblKiemKeTaiSan_tblBoPhanERPNew1", "tblKiemKeTaiSan", value);
    					On_tblKiemKeTaiSans_Changed(this.tblKiemKeTaiSans);//\\//
    				}
    			}
            }
        }
    	public static String tblKiemKeTaiSans_EntityCollectionPropertyName { get { return "tblKiemKeTaiSans"; } }
    	partial void On_tblKiemKeTaiSans_Changing(ref EntityCollection<tblKiemKeTaiSan> newValue, ref bool stopChanging);
    	partial void On_tblKiemKeTaiSans_Changed(EntityCollection<tblKiemKeTaiSan> currentValue);

        #endregion

    }
}

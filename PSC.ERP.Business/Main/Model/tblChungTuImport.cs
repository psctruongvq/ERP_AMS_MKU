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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblChungTuImport")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblChungTuImport : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblChungTuImport()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblChungTuImport object.
        /// </summary>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        /// <param name="soChungTu">Initial value of the SoChungTu property.</param>
        public static tblChungTuImport CreatetblChungTuImport(long maChungTu, string soChungTu)
        {
            tblChungTuImport tblChungTuImport = new tblChungTuImport();
            tblChungTuImport.MaChungTu = maChungTu;
            tblChungTuImport.SoChungTu = soChungTu;
            return tblChungTuImport;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
                if (_maChungTu != value)
                {
        			long oldValue =  _maChungTu;
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
        }
    	public static String MaChungTu_PropertyName { get { return "MaChungTu"; } }
        private long _maChungTu;
        partial void On_MaChungTu_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
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
    				_soChungTu = StructuralObject.SetValidValue(value, false);
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
        public Nullable<bool> GhiSoCai
        {
            get
            {
                return _ghiSoCai;
            }
            set
            {
    			Nullable<bool> oldValue =  _ghiSoCai;
    			bool stopChanging = false;
                On_GhiSoCai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiSoCai");
    			if(!stopChanging)
    			{
    				_ghiSoCai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GhiSoCai");
    				On_GhiSoCai_Changed(oldValue, _ghiSoCai);//\\
    			}
            }
        }
    	public static String GhiSoCai_PropertyName { get { return "GhiSoCai"; } }
        private Nullable<bool> _ghiSoCai;
        partial void On_GhiSoCai_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_GhiSoCai_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaDoiTuong
        {
            get
            {
                return _maDoiTuong;
            }
            set
            {
    			Nullable<long> oldValue =  _maDoiTuong;
    			bool stopChanging = false;
                On_MaDoiTuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTuong");
    			if(!stopChanging)
    			{
    				_maDoiTuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTuong");
    				On_MaDoiTuong_Changed(oldValue, _maDoiTuong);//\\
    			}
            }
        }
    	public static String MaDoiTuong_PropertyName { get { return "MaDoiTuong"; } }
        private Nullable<long> _maDoiTuong;
        partial void On_MaDoiTuong_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaDoiTuong_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiChungTu
        {
            get
            {
                return _maLoaiChungTu;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiChungTu;
    			bool stopChanging = false;
                On_MaLoaiChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiChungTu");
    			if(!stopChanging)
    			{
    				_maLoaiChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiChungTu");
    				On_MaLoaiChungTu_Changed(oldValue, _maLoaiChungTu);//\\
    			}
            }
        }
    	public static String MaLoaiChungTu_PropertyName { get { return "MaLoaiChungTu"; } }
        private Nullable<int> _maLoaiChungTu;
        partial void On_MaLoaiChungTu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiChungTu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> MaDoiTuongThuChi
        {
            get
            {
                return _maDoiTuongThuChi;
            }
            set
            {
    			Nullable<int> oldValue =  _maDoiTuongThuChi;
    			bool stopChanging = false;
                On_MaDoiTuongThuChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTuongThuChi");
    			if(!stopChanging)
    			{
    				_maDoiTuongThuChi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTuongThuChi");
    				On_MaDoiTuongThuChi_Changed(oldValue, _maDoiTuongThuChi);//\\
    			}
            }
        }
    	public static String MaDoiTuongThuChi_PropertyName { get { return "MaDoiTuongThuChi"; } }
        private Nullable<int> _maDoiTuongThuChi;
        partial void On_MaDoiTuongThuChi_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDoiTuongThuChi_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MucNganSach
        {
            get
            {
                return _mucNganSach;
            }
            set
            {
    			Nullable<int> oldValue =  _mucNganSach;
    			bool stopChanging = false;
                On_MucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MucNganSach");
    			if(!stopChanging)
    			{
    				_mucNganSach = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MucNganSach");
    				On_MucNganSach_Changed(oldValue, _mucNganSach);//\\
    			}
            }
        }
    	public static String MucNganSach_PropertyName { get { return "MucNganSach"; } }
        private Nullable<int> _mucNganSach;
        partial void On_MucNganSach_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MucNganSach_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public string KhachHangNgoaiDai
        {
            get
            {
                return _khachHangNgoaiDai;
            }
            set
            {
    			string oldValue =  _khachHangNgoaiDai;
    			bool stopChanging = false;
                On_KhachHangNgoaiDai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhachHangNgoaiDai");
    			if(!stopChanging)
    			{
    				_khachHangNgoaiDai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("KhachHangNgoaiDai");
    				On_KhachHangNgoaiDai_Changed(oldValue, _khachHangNgoaiDai);//\\
    			}
            }
        }
    	public static String KhachHangNgoaiDai_PropertyName { get { return "KhachHangNgoaiDai"; } }
        private string _khachHangNgoaiDai;
        partial void On_KhachHangNgoaiDai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_KhachHangNgoaiDai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
    			string oldValue =  _diaChi;
    			bool stopChanging = false;
                On_DiaChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DiaChi");
    			if(!stopChanging)
    			{
    				_diaChi = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DiaChi");
    				On_DiaChi_Changed(oldValue, _diaChi);//\\
    			}
            }
        }
    	public static String DiaChi_PropertyName { get { return "DiaChi"; } }
        private string _diaChi;
        partial void On_DiaChi_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DiaChi_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string KhachHangTrongDai
        {
            get
            {
                return _khachHangTrongDai;
            }
            set
            {
    			string oldValue =  _khachHangTrongDai;
    			bool stopChanging = false;
                On_KhachHangTrongDai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhachHangTrongDai");
    			if(!stopChanging)
    			{
    				_khachHangTrongDai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("KhachHangTrongDai");
    				On_KhachHangTrongDai_Changed(oldValue, _khachHangTrongDai);//\\
    			}
            }
        }
    	public static String KhachHangTrongDai_PropertyName { get { return "KhachHangTrongDai"; } }
        private string _khachHangTrongDai;
        partial void On_KhachHangTrongDai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_KhachHangTrongDai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DiaChi1
        {
            get
            {
                return _diaChi1;
            }
            set
            {
    			string oldValue =  _diaChi1;
    			bool stopChanging = false;
                On_DiaChi1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DiaChi1");
    			if(!stopChanging)
    			{
    				_diaChi1 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DiaChi1");
    				On_DiaChi1_Changed(oldValue, _diaChi1);//\\
    			}
            }
        }
    	public static String DiaChi1_PropertyName { get { return "DiaChi1"; } }
        private string _diaChi1;
        partial void On_DiaChi1_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DiaChi1_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTuImPort_tblcnLoaiDoiTuong", "tblcnLoaiDoiTuong")]
        public tblcnLoaiDoiTuong tblcnLoaiDoiTuong
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnLoaiDoiTuong>("PSC_ERPModel.FK_tblChungTuImPort_tblcnLoaiDoiTuong", "tblcnLoaiDoiTuong").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblcnLoaiDoiTuong_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnLoaiDoiTuong>("PSC_ERPModel.FK_tblChungTuImPort_tblcnLoaiDoiTuong", "tblcnLoaiDoiTuong").Value = value;
    				On_tblcnLoaiDoiTuong_Changed(this.tblcnLoaiDoiTuong);//\\//
    			}
    	    }
        }
    	public static String tblcnLoaiDoiTuong_ReferencePropertyName { get { return "tblcnLoaiDoiTuong"; } }
    	partial void On_tblcnLoaiDoiTuong_Changing(ref tblcnLoaiDoiTuong newValue, ref bool stopChanging);
    	partial void On_tblcnLoaiDoiTuong_Changed(tblcnLoaiDoiTuong currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblcnLoaiDoiTuong> tblcnLoaiDoiTuongReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnLoaiDoiTuong>("PSC_ERPModel.FK_tblChungTuImPort_tblcnLoaiDoiTuong", "tblcnLoaiDoiTuong");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblcnLoaiDoiTuong>("PSC_ERPModel.FK_tblChungTuImPort_tblcnLoaiDoiTuong", "tblcnLoaiDoiTuong", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTuImport_tblLoaiChungTu", "tblLoaiChungTu")]
        public tblLoaiChungTu tblLoaiChungTu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiChungTu>("PSC_ERPModel.FK_tblChungTuImport_tblLoaiChungTu", "tblLoaiChungTu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblLoaiChungTu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiChungTu>("PSC_ERPModel.FK_tblChungTuImport_tblLoaiChungTu", "tblLoaiChungTu").Value = value;
    				On_tblLoaiChungTu_Changed(this.tblLoaiChungTu);//\\//
    			}
    	    }
        }
    	public static String tblLoaiChungTu_ReferencePropertyName { get { return "tblLoaiChungTu"; } }
    	partial void On_tblLoaiChungTu_Changing(ref tblLoaiChungTu newValue, ref bool stopChanging);
    	partial void On_tblLoaiChungTu_Changed(tblLoaiChungTu currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblLoaiChungTu> tblLoaiChungTuReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblLoaiChungTu>("PSC_ERPModel.FK_tblChungTuImport_tblLoaiChungTu", "tblLoaiChungTu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblLoaiChungTu>("PSC_ERPModel.FK_tblChungTuImport_tblLoaiChungTu", "tblLoaiChungTu", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTuImport_tblnsBoPhan", "tblnsBoPhan")]
        public tblnsBoPhan tblnsBoPhan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblnsBoPhan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsBoPhan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblnsBoPhan").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblnsBoPhan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblChungTuImport_tblnsBoPhan", "tblnsBoPhan", value);
                }
            }
        }

        #endregion

    }
}

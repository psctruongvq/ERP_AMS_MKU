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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblCT_NghiepVuSuaChuaLon")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblCT_NghiepVuSuaChuaLon : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblCT_NghiepVuSuaChuaLon()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblCT_NghiepVuSuaChuaLon object.
        /// </summary>
        /// <param name="maChiTietNghiepVuSuaChuaLon">Initial value of the MaChiTietNghiepVuSuaChuaLon property.</param>
        /// <param name="maNghiepVuSuaChuaLon">Initial value of the MaNghiepVuSuaChuaLon property.</param>
        /// <param name="maTSCDCaBiet">Initial value of the MaTSCDCaBiet property.</param>
        public static tblCT_NghiepVuSuaChuaLon CreatetblCT_NghiepVuSuaChuaLon(int maChiTietNghiepVuSuaChuaLon, int maNghiepVuSuaChuaLon, int maTSCDCaBiet)
        {
            tblCT_NghiepVuSuaChuaLon tblCT_NghiepVuSuaChuaLon = new tblCT_NghiepVuSuaChuaLon();
            tblCT_NghiepVuSuaChuaLon.MaChiTietNghiepVuSuaChuaLon = maChiTietNghiepVuSuaChuaLon;
            tblCT_NghiepVuSuaChuaLon.MaNghiepVuSuaChuaLon = maNghiepVuSuaChuaLon;
            tblCT_NghiepVuSuaChuaLon.MaTSCDCaBiet = maTSCDCaBiet;
            return tblCT_NghiepVuSuaChuaLon;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChiTietNghiepVuSuaChuaLon
        {
            get
            {
                return _maChiTietNghiepVuSuaChuaLon;
            }
            set
            {
                if (_maChiTietNghiepVuSuaChuaLon != value)
                {
        			int oldValue =  _maChiTietNghiepVuSuaChuaLon;
        			bool stopChanging = false;
                    On_MaChiTietNghiepVuSuaChuaLon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChiTietNghiepVuSuaChuaLon");
        			if(!stopChanging)
        			{
        				_maChiTietNghiepVuSuaChuaLon = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChiTietNghiepVuSuaChuaLon");
        				On_MaChiTietNghiepVuSuaChuaLon_Changed(oldValue, _maChiTietNghiepVuSuaChuaLon);//\\
        			}
                }
            }
        }
    	public static String MaChiTietNghiepVuSuaChuaLon_PropertyName { get { return "MaChiTietNghiepVuSuaChuaLon"; } }
        private int _maChiTietNghiepVuSuaChuaLon;
        partial void On_MaChiTietNghiepVuSuaChuaLon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChiTietNghiepVuSuaChuaLon_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNghiepVuSuaChuaLon
        {
            get
            {
                return _maNghiepVuSuaChuaLon;
            }
            set
            {
    			int oldValue =  _maNghiepVuSuaChuaLon;
    			bool stopChanging = false;
                On_MaNghiepVuSuaChuaLon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNghiepVuSuaChuaLon");
    			if(!stopChanging)
    			{
    				_maNghiepVuSuaChuaLon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNghiepVuSuaChuaLon");
    				On_MaNghiepVuSuaChuaLon_Changed(oldValue, _maNghiepVuSuaChuaLon);//\\
    			}
            }
        }
    	public static String MaNghiepVuSuaChuaLon_PropertyName { get { return "MaNghiepVuSuaChuaLon"; } }
        private int _maNghiepVuSuaChuaLon;
        partial void On_MaNghiepVuSuaChuaLon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNghiepVuSuaChuaLon_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTSCDCaBiet
        {
            get
            {
                return _maTSCDCaBiet;
            }
            set
            {
    			int oldValue =  _maTSCDCaBiet;
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
        private int _maTSCDCaBiet;
        partial void On_MaTSCDCaBiet_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTSCDCaBiet_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChoDuyetTSCD
        {
            get
            {
                return _maChoDuyetTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _maChoDuyetTSCD;
    			bool stopChanging = false;
                On_MaChoDuyetTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChoDuyetTSCD");
    			if(!stopChanging)
    			{
    				_maChoDuyetTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChoDuyetTSCD");
    				On_MaChoDuyetTSCD_Changed(oldValue, _maChoDuyetTSCD);//\\
    			}
            }
        }
    	public static String MaChoDuyetTSCD_PropertyName { get { return "MaChoDuyetTSCD"; } }
        private Nullable<int> _maChoDuyetTSCD;
        partial void On_MaChoDuyetTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChoDuyetTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NguyenGiaTruocSuaChua
        {
            get
            {
                return _nguyenGiaTruocSuaChua;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nguyenGiaTruocSuaChua;
    			bool stopChanging = false;
                On_NguyenGiaTruocSuaChua_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguyenGiaTruocSuaChua");
    			if(!stopChanging)
    			{
    				_nguyenGiaTruocSuaChua = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguyenGiaTruocSuaChua");
    				On_NguyenGiaTruocSuaChua_Changed(oldValue, _nguyenGiaTruocSuaChua);//\\
    			}
            }
        }
    	public static String NguyenGiaTruocSuaChua_PropertyName { get { return "NguyenGiaTruocSuaChua"; } }
        private Nullable<decimal> _nguyenGiaTruocSuaChua;
        partial void On_NguyenGiaTruocSuaChua_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NguyenGiaTruocSuaChua_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongTienSuaChua
        {
            get
            {
                return _tongTienSuaChua;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongTienSuaChua;
    			bool stopChanging = false;
                On_TongTienSuaChua_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongTienSuaChua");
    			if(!stopChanging)
    			{
    				_tongTienSuaChua = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongTienSuaChua");
    				On_TongTienSuaChua_Changed(oldValue, _tongTienSuaChua);//\\
    			}
            }
        }
    	public static String TongTienSuaChua_PropertyName { get { return "TongTienSuaChua"; } }
        private Nullable<decimal> _tongTienSuaChua;
        partial void On_TongTienSuaChua_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongTienSuaChua_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> ThoiGianSuDungCu
        {
            get
            {
                return _thoiGianSuDungCu;
            }
            set
            {
    			Nullable<int> oldValue =  _thoiGianSuDungCu;
    			bool stopChanging = false;
                On_ThoiGianSuDungCu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiGianSuDungCu");
    			if(!stopChanging)
    			{
    				_thoiGianSuDungCu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiGianSuDungCu");
    				On_ThoiGianSuDungCu_Changed(oldValue, _thoiGianSuDungCu);//\\
    			}
            }
        }
    	public static String ThoiGianSuDungCu_PropertyName { get { return "ThoiGianSuDungCu"; } }
        private Nullable<int> _thoiGianSuDungCu;
        partial void On_ThoiGianSuDungCu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_ThoiGianSuDungCu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> ThoiGianSuDung
        {
            get
            {
                return _thoiGianSuDung;
            }
            set
            {
    			Nullable<int> oldValue =  _thoiGianSuDung;
    			bool stopChanging = false;
                On_ThoiGianSuDung_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiGianSuDung");
    			if(!stopChanging)
    			{
    				_thoiGianSuDung = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiGianSuDung");
    				On_ThoiGianSuDung_Changed(oldValue, _thoiGianSuDung);//\\
    			}
            }
        }
    	public static String ThoiGianSuDung_PropertyName { get { return "ThoiGianSuDung"; } }
        private Nullable<int> _thoiGianSuDung;
        partial void On_ThoiGianSuDung_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_ThoiGianSuDung_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public string SoHoaDon
        {
            get
            {
                return _soHoaDon;
            }
            set
            {
    			string oldValue =  _soHoaDon;
    			bool stopChanging = false;
                On_SoHoaDon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHoaDon");
    			if(!stopChanging)
    			{
    				_soHoaDon = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHoaDon");
    				On_SoHoaDon_Changed(oldValue, _soHoaDon);//\\
    			}
            }
        }
    	public static String SoHoaDon_PropertyName { get { return "SoHoaDon"; } }
        private string _soHoaDon;
        partial void On_SoHoaDon_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHoaDon_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHopDong
        {
            get
            {
                return _soHopDong;
            }
            set
            {
    			string oldValue =  _soHopDong;
    			bool stopChanging = false;
                On_SoHopDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHopDong");
    			if(!stopChanging)
    			{
    				_soHopDong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHopDong");
    				On_SoHopDong_Changed(oldValue, _soHopDong);//\\
    			}
            }
        }
    	public static String SoHopDong_PropertyName { get { return "SoHopDong"; } }
        private string _soHopDong;
        partial void On_SoHopDong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHopDong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> Thue
        {
            get
            {
                return _thue;
            }
            set
            {
    			Nullable<int> oldValue =  _thue;
    			bool stopChanging = false;
                On_Thue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Thue");
    			if(!stopChanging)
    			{
    				_thue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Thue");
    				On_Thue_Changed(oldValue, _thue);//\\
    			}
            }
        }
    	public static String Thue_PropertyName { get { return "Thue"; } }
        private Nullable<int> _thue;
        partial void On_Thue_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_Thue_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TienSauThue
        {
            get
            {
                return _tienSauThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienSauThue;
    			bool stopChanging = false;
                On_TienSauThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienSauThue");
    			if(!stopChanging)
    			{
    				_tienSauThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienSauThue");
    				On_TienSauThue_Changed(oldValue, _tienSauThue);//\\
    			}
            }
        }
    	public static String TienSauThue_PropertyName { get { return "TienSauThue"; } }
        private Nullable<decimal> _tienSauThue;
        partial void On_TienSauThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienSauThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> ThoiGianDaKhauHaoTruocSCL
        {
            get
            {
                return _thoiGianDaKhauHaoTruocSCL;
            }
            set
            {
    			Nullable<int> oldValue =  _thoiGianDaKhauHaoTruocSCL;
    			bool stopChanging = false;
                On_ThoiGianDaKhauHaoTruocSCL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiGianDaKhauHaoTruocSCL");
    			if(!stopChanging)
    			{
    				_thoiGianDaKhauHaoTruocSCL = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiGianDaKhauHaoTruocSCL");
    				On_ThoiGianDaKhauHaoTruocSCL_Changed(oldValue, _thoiGianDaKhauHaoTruocSCL);//\\
    			}
            }
        }
    	public static String ThoiGianDaKhauHaoTruocSCL_PropertyName { get { return "ThoiGianDaKhauHaoTruocSCL"; } }
        private Nullable<int> _thoiGianDaKhauHaoTruocSCL;
        partial void On_ThoiGianDaKhauHaoTruocSCL_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_ThoiGianDaKhauHaoTruocSCL_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> ThoiGianTinhKhauHaoConLai
        {
            get
            {
                return _thoiGianTinhKhauHaoConLai;
            }
            set
            {
    			Nullable<int> oldValue =  _thoiGianTinhKhauHaoConLai;
    			bool stopChanging = false;
                On_ThoiGianTinhKhauHaoConLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiGianTinhKhauHaoConLai");
    			if(!stopChanging)
    			{
    				_thoiGianTinhKhauHaoConLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiGianTinhKhauHaoConLai");
    				On_ThoiGianTinhKhauHaoConLai_Changed(oldValue, _thoiGianTinhKhauHaoConLai);//\\
    			}
            }
        }
    	public static String ThoiGianTinhKhauHaoConLai_PropertyName { get { return "ThoiGianTinhKhauHaoConLai"; } }
        private Nullable<int> _thoiGianTinhKhauHaoConLai;
        partial void On_ThoiGianTinhKhauHaoConLai_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_ThoiGianTinhKhauHaoConLai_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblDungCuPhuTung_tblCT_NghiepVuSuaChuaLon", "tblBoSungDungCuPhuTung")]
        public EntityCollection<tblBoSungDungCuPhuTung> tblBoSungDungCuPhuTungs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblBoSungDungCuPhuTung>("PSC_ERPModel.FK_tblDungCuPhuTung_tblCT_NghiepVuSuaChuaLon", "tblBoSungDungCuPhuTung");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblBoSungDungCuPhuTungs_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblBoSungDungCuPhuTung>("PSC_ERPModel.FK_tblDungCuPhuTung_tblCT_NghiepVuSuaChuaLon", "tblBoSungDungCuPhuTung", value);
    					On_tblBoSungDungCuPhuTungs_Changed(this.tblBoSungDungCuPhuTungs);//\\//
    				}
    			}
            }
        }
    	public static String tblBoSungDungCuPhuTungs_EntityCollectionPropertyName { get { return "tblBoSungDungCuPhuTungs"; } }
    	partial void On_tblBoSungDungCuPhuTungs_Changing(ref EntityCollection<tblBoSungDungCuPhuTung> newValue, ref bool stopChanging);
    	partial void On_tblBoSungDungCuPhuTungs_Changed(EntityCollection<tblBoSungDungCuPhuTung> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblDuyetTSCD")]
        public tblDuyetTSCD tblDuyetTSCD
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblDuyetTSCD").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblDuyetTSCD_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblDuyetTSCD").Value = value;
    				On_tblDuyetTSCD_Changed(this.tblDuyetTSCD);//\\//
    			}
    	    }
        }
    	public static String tblDuyetTSCD_ReferencePropertyName { get { return "tblDuyetTSCD"; } }
    	partial void On_tblDuyetTSCD_Changing(ref tblDuyetTSCD newValue, ref bool stopChanging);
    	partial void On_tblDuyetTSCD_Changed(tblDuyetTSCD currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblDuyetTSCD> tblDuyetTSCDReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblDuyetTSCD");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblDuyetTSCD>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblDuyetTSCD", "tblDuyetTSCD", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblNghiepVuSuaChuaLon")]
        public tblNghiepVuSuaChuaLon tblNghiepVuSuaChuaLon
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblNghiepVuSuaChuaLon").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblNghiepVuSuaChuaLon_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblNghiepVuSuaChuaLon").Value = value;
    				On_tblNghiepVuSuaChuaLon_Changed(this.tblNghiepVuSuaChuaLon);//\\//
    			}
    	    }
        }
    	public static String tblNghiepVuSuaChuaLon_ReferencePropertyName { get { return "tblNghiepVuSuaChuaLon"; } }
    	partial void On_tblNghiepVuSuaChuaLon_Changing(ref tblNghiepVuSuaChuaLon newValue, ref bool stopChanging);
    	partial void On_tblNghiepVuSuaChuaLon_Changed(tblNghiepVuSuaChuaLon currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblNghiepVuSuaChuaLon> tblNghiepVuSuaChuaLonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblNghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblNghiepVuSuaChuaLon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblNghiepVuSuaChuaLon>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblNghiepVuSuaChuaLon", "tblNghiepVuSuaChuaLon", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuSuaChuaLon_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet")]
        public tblTaiSanCoDinhCaBiet tblTaiSanCoDinhCaBiet
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiSanCoDinhCaBiet_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiSanCoDinhCaBiet>("PSC_ERPModel.FK_tblCT_NghiepVuSuaChuaLon_tblTaiSanCoDinhCaBiet", "tblTaiSanCoDinhCaBiet", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChiTietBoPhanSuaChua_tblCT_NghiepVuSuaChuaLon", "tblChiTietBoPhanSuaChua")]
        public EntityCollection<tblChiTietBoPhanSuaChua> tblChiTietBoPhanSuaChuas
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChiTietBoPhanSuaChua>("PSC_ERPModel.FK_tblChiTietBoPhanSuaChua_tblCT_NghiepVuSuaChuaLon", "tblChiTietBoPhanSuaChua");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChiTietBoPhanSuaChuas_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChiTietBoPhanSuaChua>("PSC_ERPModel.FK_tblChiTietBoPhanSuaChua_tblCT_NghiepVuSuaChuaLon", "tblChiTietBoPhanSuaChua", value);
    					On_tblChiTietBoPhanSuaChuas_Changed(this.tblChiTietBoPhanSuaChuas);//\\//
    				}
    			}
            }
        }
    	public static String tblChiTietBoPhanSuaChuas_EntityCollectionPropertyName { get { return "tblChiTietBoPhanSuaChuas"; } }
    	partial void On_tblChiTietBoPhanSuaChuas_Changing(ref EntityCollection<tblChiTietBoPhanSuaChua> newValue, ref bool stopChanging);
    	partial void On_tblChiTietBoPhanSuaChuas_Changed(EntityCollection<tblChiTietBoPhanSuaChua> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChiTietNguyenGiaTSCD_tblCT_NghiepVuSuaChuaLon", "tblChiTietNguyenGiaTSCD")]
        public EntityCollection<tblChiTietNguyenGiaTSCD> tblChiTietNguyenGiaTSCDs
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChiTietNguyenGiaTSCD>("PSC_ERPModel.FK_tblChiTietNguyenGiaTSCD_tblCT_NghiepVuSuaChuaLon", "tblChiTietNguyenGiaTSCD");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChiTietNguyenGiaTSCDs_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChiTietNguyenGiaTSCD>("PSC_ERPModel.FK_tblChiTietNguyenGiaTSCD_tblCT_NghiepVuSuaChuaLon", "tblChiTietNguyenGiaTSCD", value);
    					On_tblChiTietNguyenGiaTSCDs_Changed(this.tblChiTietNguyenGiaTSCDs);//\\//
    				}
    			}
            }
        }
    	public static String tblChiTietNguyenGiaTSCDs_EntityCollectionPropertyName { get { return "tblChiTietNguyenGiaTSCDs"; } }
    	partial void On_tblChiTietNguyenGiaTSCDs_Changing(ref EntityCollection<tblChiTietNguyenGiaTSCD> newValue, ref bool stopChanging);
    	partial void On_tblChiTietNguyenGiaTSCDs_Changed(EntityCollection<tblChiTietNguyenGiaTSCD> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChiTietTaiSanCaBiet_tblCT_NghiepVuSuaChuaLon", "tblChiTietTaiSanCaBiet")]
        public EntityCollection<tblChiTietTaiSanCaBiet> tblChiTietTaiSanCaBiets
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChiTietTaiSanCaBiet>("PSC_ERPModel.FK_tblChiTietTaiSanCaBiet_tblCT_NghiepVuSuaChuaLon", "tblChiTietTaiSanCaBiet");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChiTietTaiSanCaBiets_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChiTietTaiSanCaBiet>("PSC_ERPModel.FK_tblChiTietTaiSanCaBiet_tblCT_NghiepVuSuaChuaLon", "tblChiTietTaiSanCaBiet", value);
    					On_tblChiTietTaiSanCaBiets_Changed(this.tblChiTietTaiSanCaBiets);//\\//
    				}
    			}
            }
        }
    	public static String tblChiTietTaiSanCaBiets_EntityCollectionPropertyName { get { return "tblChiTietTaiSanCaBiets"; } }
    	partial void On_tblChiTietTaiSanCaBiets_Changing(ref EntityCollection<tblChiTietTaiSanCaBiet> newValue, ref bool stopChanging);
    	partial void On_tblChiTietTaiSanCaBiets_Changed(EntityCollection<tblChiTietTaiSanCaBiet> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblLichSuSuaChuaTaiSan_tblCT_NghiepVuSuaChuaLon", "tblLichSuSuaChuaTaiSan")]
        public EntityCollection<tblLichSuSuaChuaTaiSan> tblLichSuSuaChuaTaiSans
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblLichSuSuaChuaTaiSan>("PSC_ERPModel.FK_tblLichSuSuaChuaTaiSan_tblCT_NghiepVuSuaChuaLon", "tblLichSuSuaChuaTaiSan");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblLichSuSuaChuaTaiSans_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblLichSuSuaChuaTaiSan>("PSC_ERPModel.FK_tblLichSuSuaChuaTaiSan_tblCT_NghiepVuSuaChuaLon", "tblLichSuSuaChuaTaiSan", value);
    					On_tblLichSuSuaChuaTaiSans_Changed(this.tblLichSuSuaChuaTaiSans);//\\//
    				}
    			}
            }
        }
    	public static String tblLichSuSuaChuaTaiSans_EntityCollectionPropertyName { get { return "tblLichSuSuaChuaTaiSans"; } }
    	partial void On_tblLichSuSuaChuaTaiSans_Changing(ref EntityCollection<tblLichSuSuaChuaTaiSan> newValue, ref bool stopChanging);
    	partial void On_tblLichSuSuaChuaTaiSans_Changed(EntityCollection<tblLichSuSuaChuaTaiSan> currentValue);

        #endregion

    }
}

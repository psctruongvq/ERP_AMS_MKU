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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblLenhChuyenTienNuocNgoai")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblLenhChuyenTienNuocNgoai : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblLenhChuyenTienNuocNgoai()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblLenhChuyenTienNuocNgoai object.
        /// </summary>
        /// <param name="maLenhCT">Initial value of the MaLenhCT property.</param>
        public static tblLenhChuyenTienNuocNgoai CreatetblLenhChuyenTienNuocNgoai(long maLenhCT)
        {
            tblLenhChuyenTienNuocNgoai tblLenhChuyenTienNuocNgoai = new tblLenhChuyenTienNuocNgoai();
            tblLenhChuyenTienNuocNgoai.MaLenhCT = maLenhCT;
            return tblLenhChuyenTienNuocNgoai;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaLenhCT
        {
            get
            {
                return _maLenhCT;
            }
            set
            {
                if (_maLenhCT != value)
                {
        			long oldValue =  _maLenhCT;
        			bool stopChanging = false;
                    On_MaLenhCT_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaLenhCT");
        			if(!stopChanging)
        			{
        				_maLenhCT = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaLenhCT");
        				On_MaLenhCT_Changed(oldValue, _maLenhCT);//\\
        			}
                }
            }
        }
    	public static String MaLenhCT_PropertyName { get { return "MaLenhCT"; } }
        private long _maLenhCT;
        partial void On_MaLenhCT_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaLenhCT_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string So
        {
            get
            {
                return _so;
            }
            set
            {
    			string oldValue =  _so;
    			bool stopChanging = false;
                On_So_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("So");
    			if(!stopChanging)
    			{
    				_so = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("So");
    				On_So_Changed(oldValue, _so);//\\
    			}
            }
        }
    	public static String So_PropertyName { get { return "So"; } }
        private string _so;
        partial void On_So_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_So_Changed(string oldValue, string currentValue);
    
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
        public Nullable<System.DateTime> NgayXacNhan
        {
            get
            {
                return _ngayXacNhan;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayXacNhan;
    			bool stopChanging = false;
                On_NgayXacNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayXacNhan");
    			if(!stopChanging)
    			{
    				_ngayXacNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayXacNhan");
    				On_NgayXacNhan_Changed(oldValue, _ngayXacNhan);//\\
    			}
            }
        }
    	public static String NgayXacNhan_PropertyName { get { return "NgayXacNhan"; } }
        private Nullable<System.DateTime> _ngayXacNhan;
        partial void On_NgayXacNhan_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayXacNhan_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> NganHangChuyen
        {
            get
            {
                return _nganHangChuyen;
            }
            set
            {
    			Nullable<int> oldValue =  _nganHangChuyen;
    			bool stopChanging = false;
                On_NganHangChuyen_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NganHangChuyen");
    			if(!stopChanging)
    			{
    				_nganHangChuyen = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NganHangChuyen");
    				On_NganHangChuyen_Changed(oldValue, _nganHangChuyen);//\\
    			}
            }
        }
    	public static String NganHangChuyen_PropertyName { get { return "NganHangChuyen"; } }
        private Nullable<int> _nganHangChuyen;
        partial void On_NganHangChuyen_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NganHangChuyen_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> NganHangNhan
        {
            get
            {
                return _nganHangNhan;
            }
            set
            {
    			Nullable<int> oldValue =  _nganHangNhan;
    			bool stopChanging = false;
                On_NganHangNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NganHangNhan");
    			if(!stopChanging)
    			{
    				_nganHangNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NganHangNhan");
    				On_NganHangNhan_Changed(oldValue, _nganHangNhan);//\\
    			}
            }
        }
    	public static String NganHangNhan_PropertyName { get { return "NganHangNhan"; } }
        private Nullable<int> _nganHangNhan;
        partial void On_NganHangNhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NganHangNhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoDeNghi
        {
            get
            {
                return _soDeNghi;
            }
            set
            {
    			Nullable<int> oldValue =  _soDeNghi;
    			bool stopChanging = false;
                On_SoDeNghi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoDeNghi");
    			if(!stopChanging)
    			{
    				_soDeNghi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoDeNghi");
    				On_SoDeNghi_Changed(oldValue, _soDeNghi);//\\
    			}
            }
        }
    	public static String SoDeNghi_PropertyName { get { return "SoDeNghi"; } }
        private Nullable<int> _soDeNghi;
        partial void On_SoDeNghi_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoDeNghi_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoChungTu
        {
            get
            {
                return _soChungTu;
            }
            set
            {
    			Nullable<int> oldValue =  _soChungTu;
    			bool stopChanging = false;
                On_SoChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoChungTu");
    			if(!stopChanging)
    			{
    				_soChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoChungTu");
    				On_SoChungTu_Changed(oldValue, _soChungTu);//\\
    			}
            }
        }
    	public static String SoChungTu_PropertyName { get { return "SoChungTu"; } }
        private Nullable<int> _soChungTu;
        partial void On_SoChungTu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoChungTu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> HinhThucChuyen
        {
            get
            {
                return _hinhThucChuyen;
            }
            set
            {
    			Nullable<int> oldValue =  _hinhThucChuyen;
    			bool stopChanging = false;
                On_HinhThucChuyen_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HinhThucChuyen");
    			if(!stopChanging)
    			{
    				_hinhThucChuyen = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HinhThucChuyen");
    				On_HinhThucChuyen_Changed(oldValue, _hinhThucChuyen);//\\
    			}
            }
        }
    	public static String HinhThucChuyen_PropertyName { get { return "HinhThucChuyen"; } }
        private Nullable<int> _hinhThucChuyen;
        partial void On_HinhThucChuyen_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_HinhThucChuyen_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public string SoTienBangChu
        {
            get
            {
                return _soTienBangChu;
            }
            set
            {
    			string oldValue =  _soTienBangChu;
    			bool stopChanging = false;
                On_SoTienBangChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienBangChu");
    			if(!stopChanging)
    			{
    				_soTienBangChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoTienBangChu");
    				On_SoTienBangChu_Changed(oldValue, _soTienBangChu);//\\
    			}
            }
        }
    	public static String SoTienBangChu_PropertyName { get { return "SoTienBangChu"; } }
        private string _soTienBangChu;
        partial void On_SoTienBangChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoTienBangChu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string NoiDungThanhToan
        {
            get
            {
                return _noiDungThanhToan;
            }
            set
            {
    			string oldValue =  _noiDungThanhToan;
    			bool stopChanging = false;
                On_NoiDungThanhToan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NoiDungThanhToan");
    			if(!stopChanging)
    			{
    				_noiDungThanhToan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("NoiDungThanhToan");
    				On_NoiDungThanhToan_Changed(oldValue, _noiDungThanhToan);//\\
    			}
            }
        }
    	public static String NoiDungThanhToan_PropertyName { get { return "NoiDungThanhToan"; } }
        private string _noiDungThanhToan;
        partial void On_NoiDungThanhToan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_NoiDungThanhToan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> LoaiPhiDichVu
        {
            get
            {
                return _loaiPhiDichVu;
            }
            set
            {
    			Nullable<int> oldValue =  _loaiPhiDichVu;
    			bool stopChanging = false;
                On_LoaiPhiDichVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiPhiDichVu");
    			if(!stopChanging)
    			{
    				_loaiPhiDichVu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiPhiDichVu");
    				On_LoaiPhiDichVu_Changed(oldValue, _loaiPhiDichVu);//\\
    			}
            }
        }
    	public static String LoaiPhiDichVu_PropertyName { get { return "LoaiPhiDichVu"; } }
        private Nullable<int> _loaiPhiDichVu;
        partial void On_LoaiPhiDichVu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LoaiPhiDichVu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> MaDoiTac
        {
            get
            {
                return _maDoiTac;
            }
            set
            {
    			Nullable<int> oldValue =  _maDoiTac;
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
        private Nullable<int> _maDoiTac;
        partial void On_MaDoiTac_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDoiTac_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> LoaiDeNghi
        {
            get
            {
                return _loaiDeNghi;
            }
            set
            {
    			Nullable<int> oldValue =  _loaiDeNghi;
    			bool stopChanging = false;
                On_LoaiDeNghi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiDeNghi");
    			if(!stopChanging)
    			{
    				_loaiDeNghi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiDeNghi");
    				On_LoaiDeNghi_Changed(oldValue, _loaiDeNghi);//\\
    			}
            }
        }
    	public static String LoaiDeNghi_PropertyName { get { return "LoaiDeNghi"; } }
        private Nullable<int> _loaiDeNghi;
        partial void On_LoaiDeNghi_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_LoaiDeNghi_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblChungTu_LenhChuyenTien_tblLenhChuyenTien", "tblChungTu_LenhChuyenTien")]
        public EntityCollection<tblChungTu_LenhChuyenTien> tblChungTu_LenhChuyenTien
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChungTu_LenhChuyenTien>("PSC_ERPModel.FK_tblChungTu_LenhChuyenTien_tblLenhChuyenTien", "tblChungTu_LenhChuyenTien");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChungTu_LenhChuyenTien_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChungTu_LenhChuyenTien>("PSC_ERPModel.FK_tblChungTu_LenhChuyenTien_tblLenhChuyenTien", "tblChungTu_LenhChuyenTien", value);
    					On_tblChungTu_LenhChuyenTien_Changed(this.tblChungTu_LenhChuyenTien);//\\//
    				}
    			}
            }
        }
    	public static String tblChungTu_LenhChuyenTien_EntityCollectionPropertyName { get { return "tblChungTu_LenhChuyenTien"; } }
    	partial void On_tblChungTu_LenhChuyenTien_Changing(ref EntityCollection<tblChungTu_LenhChuyenTien> newValue, ref bool stopChanging);
    	partial void On_tblChungTu_LenhChuyenTien_Changed(EntityCollection<tblChungTu_LenhChuyenTien> currentValue);

        #endregion

    }
}
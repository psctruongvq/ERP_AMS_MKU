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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblHangHoa")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblHangHoa : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblHangHoa()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblHangHoa object.
        /// </summary>
        /// <param name="maHangHoa">Initial value of the MaHangHoa property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        /// <param name="tenHangHoa">Initial value of the TenHangHoa property.</param>
        /// <param name="tinhTrang">Initial value of the TinhTrang property.</param>
        public static tblHangHoa CreatetblHangHoa(int maHangHoa, string maQuanLy, string tenHangHoa, bool tinhTrang)
        {
            tblHangHoa tblHangHoa = new tblHangHoa();
            tblHangHoa.MaHangHoa = maHangHoa;
            tblHangHoa.MaQuanLy = maQuanLy;
            tblHangHoa.TenHangHoa = tenHangHoa;
            tblHangHoa.TinhTrang = tinhTrang;
            return tblHangHoa;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaHangHoa
        {
            get
            {
                return _maHangHoa;
            }
            set
            {
                if (_maHangHoa != value)
                {
        			int oldValue =  _maHangHoa;
        			bool stopChanging = false;
                    On_MaHangHoa_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaHangHoa");
        			if(!stopChanging)
        			{
        				_maHangHoa = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaHangHoa");
        				On_MaHangHoa_Changed(oldValue, _maHangHoa);//\\
        			}
                }
            }
        }
    	public static String MaHangHoa_PropertyName { get { return "MaHangHoa"; } }
        private int _maHangHoa;
        partial void On_MaHangHoa_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaHangHoa_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
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
    				_maQuanLy = StructuralObject.SetValidValue(value, false);
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenHangHoa
        {
            get
            {
                return _tenHangHoa;
            }
            set
            {
    			string oldValue =  _tenHangHoa;
    			bool stopChanging = false;
                On_TenHangHoa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenHangHoa");
    			if(!stopChanging)
    			{
    				_tenHangHoa = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("TenHangHoa");
    				On_TenHangHoa_Changed(oldValue, _tenHangHoa);//\\
    			}
            }
        }
    	public static String TenHangHoa_PropertyName { get { return "TenHangHoa"; } }
        private string _tenHangHoa;
        partial void On_TenHangHoa_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenHangHoa_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaDonViTinh
        {
            get
            {
                return _maDonViTinh;
            }
            set
            {
    			Nullable<int> oldValue =  _maDonViTinh;
    			bool stopChanging = false;
                On_MaDonViTinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDonViTinh");
    			if(!stopChanging)
    			{
    				_maDonViTinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDonViTinh");
    				On_MaDonViTinh_Changed(oldValue, _maDonViTinh);//\\
    			}
            }
        }
    	public static String MaDonViTinh_PropertyName { get { return "MaDonViTinh"; } }
        private Nullable<int> _maDonViTinh;
        partial void On_MaDonViTinh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDonViTinh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaQuocGia
        {
            get
            {
                return _maQuocGia;
            }
            set
            {
    			Nullable<int> oldValue =  _maQuocGia;
    			bool stopChanging = false;
                On_MaQuocGia_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuocGia");
    			if(!stopChanging)
    			{
    				_maQuocGia = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaQuocGia");
    				On_MaQuocGia_Changed(oldValue, _maQuocGia);//\\
    			}
            }
        }
    	public static String MaQuocGia_PropertyName { get { return "MaQuocGia"; } }
        private Nullable<int> _maQuocGia;
        partial void On_MaQuocGia_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaQuocGia_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenHangSanXuat
        {
            get
            {
                return _tenHangSanXuat;
            }
            set
            {
    			string oldValue =  _tenHangSanXuat;
    			bool stopChanging = false;
                On_TenHangSanXuat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenHangSanXuat");
    			if(!stopChanging)
    			{
    				_tenHangSanXuat = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenHangSanXuat");
    				On_TenHangSanXuat_Changed(oldValue, _tenHangSanXuat);//\\
    			}
            }
        }
    	public static String TenHangSanXuat_PropertyName { get { return "TenHangSanXuat"; } }
        private string _tenHangSanXuat;
        partial void On_TenHangSanXuat_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenHangSanXuat_Changed(string oldValue, string currentValue);
    
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
        public Nullable<int> MaNhomHangHoa
        {
            get
            {
                return _maNhomHangHoa;
            }
            set
            {
    			Nullable<int> oldValue =  _maNhomHangHoa;
    			bool stopChanging = false;
                On_MaNhomHangHoa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNhomHangHoa");
    			if(!stopChanging)
    			{
    				_maNhomHangHoa = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNhomHangHoa");
    				On_MaNhomHangHoa_Changed(oldValue, _maNhomHangHoa);//\\
    			}
            }
        }
    	public static String MaNhomHangHoa_PropertyName { get { return "MaNhomHangHoa"; } }
        private Nullable<int> _maNhomHangHoa;
        partial void On_MaNhomHangHoa_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNhomHangHoa_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public bool TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
    			bool oldValue =  _tinhTrang;
    			bool stopChanging = false;
                On_TinhTrang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TinhTrang");
    			if(!stopChanging)
    			{
    				_tinhTrang = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TinhTrang");
    				On_TinhTrang_Changed(oldValue, _tinhTrang);//\\
    			}
            }
        }
    	public static String TinhTrang_PropertyName { get { return "TinhTrang"; } }
        private bool _tinhTrang;
        partial void On_TinhTrang_Changing(bool currentValue, ref bool newValue, ref bool stopChanging);
        partial void On_TinhTrang_Changed(bool oldValue, bool currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThoiLuong
        {
            get
            {
                return _thoiLuong;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thoiLuong;
    			bool stopChanging = false;
                On_ThoiLuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThoiLuong");
    			if(!stopChanging)
    			{
    				_thoiLuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThoiLuong");
    				On_ThoiLuong_Changed(oldValue, _thoiLuong);//\\
    			}
            }
        }
    	public static String ThoiLuong_PropertyName { get { return "ThoiLuong"; } }
        private Nullable<decimal> _thoiLuong;
        partial void On_ThoiLuong_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThoiLuong_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<int> PmCuMaTSCD
        {
            get
            {
                return _pmCuMaTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _pmCuMaTSCD;
    			bool stopChanging = false;
                On_PmCuMaTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PmCuMaTSCD");
    			if(!stopChanging)
    			{
    				_pmCuMaTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PmCuMaTSCD");
    				On_PmCuMaTSCD_Changed(oldValue, _pmCuMaTSCD);//\\
    			}
            }
        }
    	public static String PmCuMaTSCD_PropertyName { get { return "PmCuMaTSCD"; } }
        private Nullable<int> _pmCuMaTSCD;
        partial void On_PmCuMaTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_PmCuMaTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> PmCuMaLoaiTaiSan
        {
            get
            {
                return _pmCuMaLoaiTaiSan;
            }
            set
            {
    			Nullable<int> oldValue =  _pmCuMaLoaiTaiSan;
    			bool stopChanging = false;
                On_PmCuMaLoaiTaiSan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PmCuMaLoaiTaiSan");
    			if(!stopChanging)
    			{
    				_pmCuMaLoaiTaiSan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PmCuMaLoaiTaiSan");
    				On_PmCuMaLoaiTaiSan_Changed(oldValue, _pmCuMaLoaiTaiSan);//\\
    			}
            }
        }
    	public static String PmCuMaLoaiTaiSan_PropertyName { get { return "PmCuMaLoaiTaiSan"; } }
        private Nullable<int> _pmCuMaLoaiTaiSan;
        partial void On_PmCuMaLoaiTaiSan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_PmCuMaLoaiTaiSan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> PmCuMaNuocSX
        {
            get
            {
                return _pmCuMaNuocSX;
            }
            set
            {
    			Nullable<int> oldValue =  _pmCuMaNuocSX;
    			bool stopChanging = false;
                On_PmCuMaNuocSX_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PmCuMaNuocSX");
    			if(!stopChanging)
    			{
    				_pmCuMaNuocSX = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PmCuMaNuocSX");
    				On_PmCuMaNuocSX_Changed(oldValue, _pmCuMaNuocSX);//\\
    			}
            }
        }
    	public static String PmCuMaNuocSX_PropertyName { get { return "PmCuMaNuocSX"; } }
        private Nullable<int> _pmCuMaNuocSX;
        partial void On_PmCuMaNuocSX_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_PmCuMaNuocSX_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> PmCuMaDonViTinh
        {
            get
            {
                return _pmCuMaDonViTinh;
            }
            set
            {
    			Nullable<int> oldValue =  _pmCuMaDonViTinh;
    			bool stopChanging = false;
                On_PmCuMaDonViTinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PmCuMaDonViTinh");
    			if(!stopChanging)
    			{
    				_pmCuMaDonViTinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PmCuMaDonViTinh");
    				On_PmCuMaDonViTinh_Changed(oldValue, _pmCuMaDonViTinh);//\\
    			}
            }
        }
    	public static String PmCuMaDonViTinh_PropertyName { get { return "PmCuMaDonViTinh"; } }
        private Nullable<int> _pmCuMaDonViTinh;
        partial void On_PmCuMaDonViTinh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_PmCuMaDonViTinh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
    			string oldValue =  _model;
    			bool stopChanging = false;
                On_Model_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Model");
    			if(!stopChanging)
    			{
    				_model = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Model");
    				On_Model_Changed(oldValue, _model);//\\
    			}
            }
        }
    	public static String Model_PropertyName { get { return "Model"; } }
        private string _model;
        partial void On_Model_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Model_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TaiKhoanKho
        {
            get
            {
                return _taiKhoanKho;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanKho;
    			bool stopChanging = false;
                On_TaiKhoanKho_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanKho");
    			if(!stopChanging)
    			{
    				_taiKhoanKho = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanKho");
    				On_TaiKhoanKho_Changed(oldValue, _taiKhoanKho);//\\
    			}
            }
        }
    	public static String TaiKhoanKho_PropertyName { get { return "TaiKhoanKho"; } }
        private Nullable<int> _taiKhoanKho;
        partial void On_TaiKhoanKho_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanKho_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TaiKhoanChoPhanBo
        {
            get
            {
                return _taiKhoanChoPhanBo;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanChoPhanBo;
    			bool stopChanging = false;
                On_TaiKhoanChoPhanBo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanChoPhanBo");
    			if(!stopChanging)
    			{
    				_taiKhoanChoPhanBo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanChoPhanBo");
    				On_TaiKhoanChoPhanBo_Changed(oldValue, _taiKhoanChoPhanBo);//\\
    			}
            }
        }
    	public static String TaiKhoanChoPhanBo_PropertyName { get { return "TaiKhoanChoPhanBo"; } }
        private Nullable<int> _taiKhoanChoPhanBo;
        partial void On_TaiKhoanChoPhanBo_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanChoPhanBo_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TaiKhoanPhanBo
        {
            get
            {
                return _taiKhoanPhanBo;
            }
            set
            {
    			Nullable<int> oldValue =  _taiKhoanPhanBo;
    			bool stopChanging = false;
                On_TaiKhoanPhanBo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TaiKhoanPhanBo");
    			if(!stopChanging)
    			{
    				_taiKhoanPhanBo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TaiKhoanPhanBo");
    				On_TaiKhoanPhanBo_Changed(oldValue, _taiKhoanPhanBo);//\\
    			}
            }
        }
    	public static String TaiKhoanPhanBo_PropertyName { get { return "TaiKhoanPhanBo"; } }
        private Nullable<int> _taiKhoanPhanBo;
        partial void On_TaiKhoanPhanBo_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TaiKhoanPhanBo_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHangHoa_tblDonViTinh", "tblDonViTinh")]
        public tblDonViTinh tblDonViTinh
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDonViTinh>("PSC_ERPModel.FK_tblHangHoa_tblDonViTinh", "tblDonViTinh").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblDonViTinh_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDonViTinh>("PSC_ERPModel.FK_tblHangHoa_tblDonViTinh", "tblDonViTinh").Value = value;
    				On_tblDonViTinh_Changed(this.tblDonViTinh);//\\//
    			}
    	    }
        }
    	public static String tblDonViTinh_ReferencePropertyName { get { return "tblDonViTinh"; } }
    	partial void On_tblDonViTinh_Changing(ref tblDonViTinh newValue, ref bool stopChanging);
    	partial void On_tblDonViTinh_Changed(tblDonViTinh currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblDonViTinh> tblDonViTinhReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblDonViTinh>("PSC_ERPModel.FK_tblHangHoa_tblDonViTinh", "tblDonViTinh");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblDonViTinh>("PSC_ERPModel.FK_tblHangHoa_tblDonViTinh", "tblDonViTinh", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHangHoa_tblQuocGia", "tblQuocGia")]
        public tblQuocGia tblQuocGia
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblQuocGia>("PSC_ERPModel.FK_tblHangHoa_tblQuocGia", "tblQuocGia").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblQuocGia_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblQuocGia>("PSC_ERPModel.FK_tblHangHoa_tblQuocGia", "tblQuocGia").Value = value;
    				On_tblQuocGia_Changed(this.tblQuocGia);//\\//
    			}
    	    }
        }
    	public static String tblQuocGia_ReferencePropertyName { get { return "tblQuocGia"; } }
    	partial void On_tblQuocGia_Changing(ref tblQuocGia newValue, ref bool stopChanging);
    	partial void On_tblQuocGia_Changed(tblQuocGia currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblQuocGia> tblQuocGiaReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblQuocGia>("PSC_ERPModel.FK_tblHangHoa_tblQuocGia", "tblQuocGia");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblQuocGia>("PSC_ERPModel.FK_tblHangHoa_tblQuocGia", "tblQuocGia", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_HoaDon_tblHangHoa", "tblCT_HoaDon")]
        public EntityCollection<tblCT_HoaDon> tblCT_HoaDon
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_HoaDon>("PSC_ERPModel.FK_tblCT_HoaDon_tblHangHoa", "tblCT_HoaDon");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_HoaDon_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_HoaDon>("PSC_ERPModel.FK_tblCT_HoaDon_tblHangHoa", "tblCT_HoaDon", value);
    					On_tblCT_HoaDon_Changed(this.tblCT_HoaDon);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_HoaDon_EntityCollectionPropertyName { get { return "tblCT_HoaDon"; } }
    	partial void On_tblCT_HoaDon_Changing(ref EntityCollection<tblCT_HoaDon> newValue, ref bool stopChanging);
    	partial void On_tblCT_HoaDon_Changed(EntityCollection<tblCT_HoaDon> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCongCuDungCu_tblHangHoa", "tblCongCuDungCu")]
        public EntityCollection<tblCongCuDungCu> tblCongCuDungCus
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCongCuDungCu>("PSC_ERPModel.FK_tblCongCuDungCu_tblHangHoa", "tblCongCuDungCu");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCongCuDungCus_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCongCuDungCu>("PSC_ERPModel.FK_tblCongCuDungCu_tblHangHoa", "tblCongCuDungCu", value);
    					On_tblCongCuDungCus_Changed(this.tblCongCuDungCus);//\\//
    				}
    			}
            }
        }
    	public static String tblCongCuDungCus_EntityCollectionPropertyName { get { return "tblCongCuDungCus"; } }
    	partial void On_tblCongCuDungCus_Changing(ref EntityCollection<tblCongCuDungCu> newValue, ref bool stopChanging);
    	partial void On_tblCongCuDungCus_Changed(EntityCollection<tblCongCuDungCu> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHangHoa_tblTaiKhoan_ChoPhanBo", "tblTaiKhoan")]
        public tblTaiKhoan tblTaiKhoan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_ChoPhanBo", "tblTaiKhoan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiKhoan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_ChoPhanBo", "tblTaiKhoan").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_ChoPhanBo", "tblTaiKhoan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_ChoPhanBo", "tblTaiKhoan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHangHoa_tblTaiKhoan_Kho", "tblTaiKhoan")]
        public tblTaiKhoan tblTaiKhoan1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_Kho", "tblTaiKhoan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiKhoan1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_Kho", "tblTaiKhoan").Value = value;
    				On_tblTaiKhoan1_Changed(this.tblTaiKhoan1);//\\//
    			}
    	    }
        }
    	public static String tblTaiKhoan1_ReferencePropertyName { get { return "tblTaiKhoan1"; } }
    	partial void On_tblTaiKhoan1_Changing(ref tblTaiKhoan newValue, ref bool stopChanging);
    	partial void On_tblTaiKhoan1_Changed(tblTaiKhoan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblTaiKhoan> tblTaiKhoan1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_Kho", "tblTaiKhoan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_Kho", "tblTaiKhoan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblHangHoa_tblTaiKhoan_PhanBo", "tblTaiKhoan")]
        public tblTaiKhoan tblTaiKhoan2
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_PhanBo", "tblTaiKhoan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblTaiKhoan2_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_PhanBo", "tblTaiKhoan").Value = value;
    				On_tblTaiKhoan2_Changed(this.tblTaiKhoan2);//\\//
    			}
    	    }
        }
    	public static String tblTaiKhoan2_ReferencePropertyName { get { return "tblTaiKhoan2"; } }
    	partial void On_tblTaiKhoan2_Changing(ref tblTaiKhoan newValue, ref bool stopChanging);
    	partial void On_tblTaiKhoan2_Changed(tblTaiKhoan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblTaiKhoan> tblTaiKhoan2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_PhanBo", "tblTaiKhoan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblTaiKhoan>("PSC_ERPModel.FK_tblHangHoa_tblTaiKhoan_PhanBo", "tblTaiKhoan", value);
                }
            }
        }

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblcnChiThuLao")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblcnChiThuLao : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblcnChiThuLao()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblcnChiThuLao object.
        /// </summary>
        /// <param name="maChiThuLao">Initial value of the MaChiThuLao property.</param>
        /// <param name="soChungTu">Initial value of the SoChungTu property.</param>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        /// <param name="maBoPhanNhan">Initial value of the MaBoPhanNhan property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        public static tblcnChiThuLao CreatetblcnChiThuLao(long maChiThuLao, string soChungTu, long maChungTu, int maBoPhanNhan, decimal soTien)
        {
            tblcnChiThuLao tblcnChiThuLao = new tblcnChiThuLao();
            tblcnChiThuLao.MaChiThuLao = maChiThuLao;
            tblcnChiThuLao.SoChungTu = soChungTu;
            tblcnChiThuLao.MaChungTu = maChungTu;
            tblcnChiThuLao.MaBoPhanNhan = maBoPhanNhan;
            tblcnChiThuLao.SoTien = soTien;
            return tblcnChiThuLao;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaChiThuLao
        {
            get
            {
                return _maChiThuLao;
            }
            set
            {
                if (_maChiThuLao != value)
                {
        			long oldValue =  _maChiThuLao;
        			bool stopChanging = false;
                    On_MaChiThuLao_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChiThuLao");
        			if(!stopChanging)
        			{
        				_maChiThuLao = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChiThuLao");
        				On_MaChiThuLao_Changed(oldValue, _maChiThuLao);//\\
        			}
                }
            }
        }
    	public static String MaChiThuLao_PropertyName { get { return "MaChiThuLao"; } }
        private long _maChiThuLao;
        partial void On_MaChiThuLao_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaChiThuLao_Changed(long oldValue, long currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
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
    	public static String MaChungTu_PropertyName { get { return "MaChungTu"; } }
        private long _maChungTu;
        partial void On_MaChungTu_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBoPhanNhan
        {
            get
            {
                return _maBoPhanNhan;
            }
            set
            {
    			int oldValue =  _maBoPhanNhan;
    			bool stopChanging = false;
                On_MaBoPhanNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanNhan");
    			if(!stopChanging)
    			{
    				_maBoPhanNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhanNhan");
    				On_MaBoPhanNhan_Changed(oldValue, _maBoPhanNhan);//\\
    			}
            }
        }
    	public static String MaBoPhanNhan_PropertyName { get { return "MaBoPhanNhan"; } }
        private int _maBoPhanNhan;
        partial void On_MaBoPhanNhan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhanNhan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
    			decimal oldValue =  _soTien;
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
        private decimal _soTien;
        partial void On_SoTien_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(decimal oldValue, decimal currentValue);
    
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
        public Nullable<int> MaBoPhanGui
        {
            get
            {
                return _maBoPhanGui;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhanGui;
    			bool stopChanging = false;
                On_MaBoPhanGui_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanGui");
    			if(!stopChanging)
    			{
    				_maBoPhanGui = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhanGui");
    				On_MaBoPhanGui_Changed(oldValue, _maBoPhanGui);//\\
    			}
            }
        }
    	public static String MaBoPhanGui_PropertyName { get { return "MaBoPhanGui"; } }
        private Nullable<int> _maBoPhanGui;
        partial void On_MaBoPhanGui_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhanGui_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhanGui
        {
            get
            {
                return _tenBoPhanGui;
            }
            set
            {
    			string oldValue =  _tenBoPhanGui;
    			bool stopChanging = false;
                On_TenBoPhanGui_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhanGui");
    			if(!stopChanging)
    			{
    				_tenBoPhanGui = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhanGui");
    				On_TenBoPhanGui_Changed(oldValue, _tenBoPhanGui);//\\
    			}
            }
        }
    	public static String TenBoPhanGui_PropertyName { get { return "TenBoPhanGui"; } }
        private string _tenBoPhanGui;
        partial void On_TenBoPhanGui_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhanGui_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChuongTrinh
        {
            get
            {
                return _maChuongTrinh;
            }
            set
            {
    			Nullable<int> oldValue =  _maChuongTrinh;
    			bool stopChanging = false;
                On_MaChuongTrinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChuongTrinh");
    			if(!stopChanging)
    			{
    				_maChuongTrinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChuongTrinh");
    				On_MaChuongTrinh_Changed(oldValue, _maChuongTrinh);//\\
    			}
            }
        }
    	public static String MaChuongTrinh_PropertyName { get { return "MaChuongTrinh"; } }
        private Nullable<int> _maChuongTrinh;
        partial void On_MaChuongTrinh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChuongTrinh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenChuongTrinh
        {
            get
            {
                return _tenChuongTrinh;
            }
            set
            {
    			string oldValue =  _tenChuongTrinh;
    			bool stopChanging = false;
                On_TenChuongTrinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenChuongTrinh");
    			if(!stopChanging)
    			{
    				_tenChuongTrinh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenChuongTrinh");
    				On_TenChuongTrinh_Changed(oldValue, _tenChuongTrinh);//\\
    			}
            }
        }
    	public static String TenChuongTrinh_PropertyName { get { return "TenChuongTrinh"; } }
        private string _tenChuongTrinh;
        partial void On_TenChuongTrinh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenChuongTrinh_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienDaNhap
        {
            get
            {
                return _soTienDaNhap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienDaNhap;
    			bool stopChanging = false;
                On_SoTienDaNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienDaNhap");
    			if(!stopChanging)
    			{
    				_soTienDaNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienDaNhap");
    				On_SoTienDaNhap_Changed(oldValue, _soTienDaNhap);//\\
    			}
            }
        }
    	public static String SoTienDaNhap_PropertyName { get { return "SoTienDaNhap"; } }
        private Nullable<decimal> _soTienDaNhap;
        partial void On_SoTienDaNhap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienDaNhap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienDaNhapNgoaiDai
        {
            get
            {
                return _soTienDaNhapNgoaiDai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienDaNhapNgoaiDai;
    			bool stopChanging = false;
                On_SoTienDaNhapNgoaiDai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienDaNhapNgoaiDai");
    			if(!stopChanging)
    			{
    				_soTienDaNhapNgoaiDai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienDaNhapNgoaiDai");
    				On_SoTienDaNhapNgoaiDai_Changed(oldValue, _soTienDaNhapNgoaiDai);//\\
    			}
            }
        }
    	public static String SoTienDaNhapNgoaiDai_PropertyName { get { return "SoTienDaNhapNgoaiDai"; } }
        private Nullable<decimal> _soTienDaNhapNgoaiDai;
        partial void On_SoTienDaNhapNgoaiDai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienDaNhapNgoaiDai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienConLai
        {
            get
            {
                return _soTienConLai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienConLai;
    			bool stopChanging = false;
                On_SoTienConLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienConLai");
    			if(!stopChanging)
    			{
    				_soTienConLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienConLai");
    				On_SoTienConLai_Changed(oldValue, _soTienConLai);//\\
    			}
            }
        }
    	public static String SoTienConLai_PropertyName { get { return "SoTienConLai"; } }
        private Nullable<decimal> _soTienConLai;
        partial void On_SoTienConLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienConLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhanNhan
        {
            get
            {
                return _tenBoPhanNhan;
            }
            set
            {
    			string oldValue =  _tenBoPhanNhan;
    			bool stopChanging = false;
                On_TenBoPhanNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhanNhan");
    			if(!stopChanging)
    			{
    				_tenBoPhanNhan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhanNhan");
    				On_TenBoPhanNhan_Changed(oldValue, _tenBoPhanNhan);//\\
    			}
            }
        }
    	public static String TenBoPhanNhan_PropertyName { get { return "TenBoPhanNhan"; } }
        private string _tenBoPhanNhan;
        partial void On_TenBoPhanNhan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhanNhan_Changed(string oldValue, string currentValue);
    
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
        public Nullable<decimal> SoTienSeNhap
        {
            get
            {
                return _soTienSeNhap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienSeNhap;
    			bool stopChanging = false;
                On_SoTienSeNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienSeNhap");
    			if(!stopChanging)
    			{
    				_soTienSeNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienSeNhap");
    				On_SoTienSeNhap_Changed(oldValue, _soTienSeNhap);//\\
    			}
            }
        }
    	public static String SoTienSeNhap_PropertyName { get { return "SoTienSeNhap"; } }
        private Nullable<decimal> _soTienSeNhap;
        partial void On_SoTienSeNhap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienSeNhap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienSeNhapNgoaiDai
        {
            get
            {
                return _soTienSeNhapNgoaiDai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienSeNhapNgoaiDai;
    			bool stopChanging = false;
                On_SoTienSeNhapNgoaiDai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienSeNhapNgoaiDai");
    			if(!stopChanging)
    			{
    				_soTienSeNhapNgoaiDai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienSeNhapNgoaiDai");
    				On_SoTienSeNhapNgoaiDai_Changed(oldValue, _soTienSeNhapNgoaiDai);//\\
    			}
            }
        }
    	public static String SoTienSeNhapNgoaiDai_PropertyName { get { return "SoTienSeNhapNgoaiDai"; } }
        private Nullable<decimal> _soTienSeNhapNgoaiDai;
        partial void On_SoTienSeNhapNgoaiDai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienSeNhapNgoaiDai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<int> MaLoaiKinhPhi
        {
            get
            {
                return _maLoaiKinhPhi;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiKinhPhi;
    			bool stopChanging = false;
                On_MaLoaiKinhPhi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiKinhPhi");
    			if(!stopChanging)
    			{
    				_maLoaiKinhPhi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiKinhPhi");
    				On_MaLoaiKinhPhi_Changed(oldValue, _maLoaiKinhPhi);//\\
    			}
            }
        }
    	public static String MaLoaiKinhPhi_PropertyName { get { return "MaLoaiKinhPhi"; } }
        private Nullable<int> _maLoaiKinhPhi;
        partial void On_MaLoaiKinhPhi_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiKinhPhi_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaCT_ChiPhiSanXuat
        {
            get
            {
                return _maCT_ChiPhiSanXuat;
            }
            set
            {
    			Nullable<long> oldValue =  _maCT_ChiPhiSanXuat;
    			bool stopChanging = false;
                On_MaCT_ChiPhiSanXuat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaCT_ChiPhiSanXuat");
    			if(!stopChanging)
    			{
    				_maCT_ChiPhiSanXuat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaCT_ChiPhiSanXuat");
    				On_MaCT_ChiPhiSanXuat_Changed(oldValue, _maCT_ChiPhiSanXuat);//\\
    			}
            }
        }
    	public static String MaCT_ChiPhiSanXuat_PropertyName { get { return "MaCT_ChiPhiSanXuat"; } }
        private Nullable<long> _maCT_ChiPhiSanXuat;
        partial void On_MaCT_ChiPhiSanXuat_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaCT_ChiPhiSanXuat_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayThucHienChi
        {
            get
            {
                return _ngayThucHienChi;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayThucHienChi;
    			bool stopChanging = false;
                On_NgayThucHienChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayThucHienChi");
    			if(!stopChanging)
    			{
    				_ngayThucHienChi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayThucHienChi");
    				On_NgayThucHienChi_Changed(oldValue, _ngayThucHienChi);//\\
    			}
            }
        }
    	public static String NgayThucHienChi_PropertyName { get { return "NgayThucHienChi"; } }
        private Nullable<System.DateTime> _ngayThucHienChi;
        partial void On_NgayThucHienChi_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayThucHienChi_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoan
        {
            get
            {
                return _maTaiKhoan;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoan;
    			bool stopChanging = false;
                On_MaTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoan");
    			if(!stopChanging)
    			{
    				_maTaiKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoan");
    				On_MaTaiKhoan_Changed(oldValue, _maTaiKhoan);//\\
    			}
            }
        }
    	public static String MaTaiKhoan_PropertyName { get { return "MaTaiKhoan"; } }
        private Nullable<int> _maTaiKhoan;
        partial void On_MaTaiKhoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaChungTuKCCP
        {
            get
            {
                return _maChungTuKCCP;
            }
            set
            {
    			Nullable<long> oldValue =  _maChungTuKCCP;
    			bool stopChanging = false;
                On_MaChungTuKCCP_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChungTuKCCP");
    			if(!stopChanging)
    			{
    				_maChungTuKCCP = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChungTuKCCP");
    				On_MaChungTuKCCP_Changed(oldValue, _maChungTuKCCP);//\\
    			}
            }
        }
    	public static String MaChungTuKCCP_PropertyName { get { return "MaChungTuKCCP"; } }
        private Nullable<long> _maChungTuKCCP;
        partial void On_MaChungTuKCCP_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaChungTuKCCP_Changed(Nullable<long> oldValue, Nullable<long> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblcnChiThuLao_tblChiPhiSanXuat", "tblCT_ChiPhiSanXuat")]
        public tblCT_ChiPhiSanXuat tblCT_ChiPhiSanXuat
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblCT_ChiPhiSanXuat>("PSC_ERPModel.FK_tblcnChiThuLao_tblChiPhiSanXuat", "tblCT_ChiPhiSanXuat").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblCT_ChiPhiSanXuat_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblCT_ChiPhiSanXuat>("PSC_ERPModel.FK_tblcnChiThuLao_tblChiPhiSanXuat", "tblCT_ChiPhiSanXuat").Value = value;
    				On_tblCT_ChiPhiSanXuat_Changed(this.tblCT_ChiPhiSanXuat);//\\//
    			}
    	    }
        }
    	public static String tblCT_ChiPhiSanXuat_ReferencePropertyName { get { return "tblCT_ChiPhiSanXuat"; } }
    	partial void On_tblCT_ChiPhiSanXuat_Changing(ref tblCT_ChiPhiSanXuat newValue, ref bool stopChanging);
    	partial void On_tblCT_ChiPhiSanXuat_Changed(tblCT_ChiPhiSanXuat currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblCT_ChiPhiSanXuat> tblCT_ChiPhiSanXuatReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblCT_ChiPhiSanXuat>("PSC_ERPModel.FK_tblcnChiThuLao_tblChiPhiSanXuat", "tblCT_ChiPhiSanXuat");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblCT_ChiPhiSanXuat>("PSC_ERPModel.FK_tblcnChiThuLao_tblChiPhiSanXuat", "tblCT_ChiPhiSanXuat", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblcnChiThuLao_tblnsBoPhan", "tblnsBoPhan")]
        public tblnsBoPhan tblnsBoPhan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblnsBoPhan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsBoPhan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblnsBoPhan").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblnsBoPhan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblcnChiThuLao_tblnsBoPhan", "tblnsBoPhan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblChiThuLao_NhanVien")]
        public EntityCollection<tblChiThuLao_NhanVien> tblChiThuLao_NhanVien
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblChiThuLao_NhanVien>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblChiThuLao_NhanVien");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblChiThuLao_NhanVien_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblChiThuLao_NhanVien>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblChiThuLao_NhanVien", value);
    					On_tblChiThuLao_NhanVien_Changed(this.tblChiThuLao_NhanVien);//\\//
    				}
    			}
            }
        }
    	public static String tblChiThuLao_NhanVien_EntityCollectionPropertyName { get { return "tblChiThuLao_NhanVien"; } }
    	partial void On_tblChiThuLao_NhanVien_Changing(ref EntityCollection<tblChiThuLao_NhanVien> newValue, ref bool stopChanging);
    	partial void On_tblChiThuLao_NhanVien_Changed(EntityCollection<tblChiThuLao_NhanVien> currentValue);

        #endregion

    }
}
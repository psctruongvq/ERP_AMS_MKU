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
    [EdmComplexTypeAttribute(NamespaceName="PSC_ERPModel", Name="spd_DanhSachChiPhiSanXuatTheoThang_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class spd_DanhSachChiPhiSanXuatTheoThang_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new spd_DanhSachChiPhiSanXuatTheoThang_Result object.
        /// </summary>
        /// <param name="tenLoaiNhanVien">Initial value of the TenLoaiNhanVien property.</param>
        public static spd_DanhSachChiPhiSanXuatTheoThang_Result Createspd_DanhSachChiPhiSanXuatTheoThang_Result(string tenLoaiNhanVien)
        {
            spd_DanhSachChiPhiSanXuatTheoThang_Result spd_DanhSachChiPhiSanXuatTheoThang_Result = new spd_DanhSachChiPhiSanXuatTheoThang_Result();
            spd_DanhSachChiPhiSanXuatTheoThang_Result.TenLoaiNhanVien = tenLoaiNhanVien;
            return spd_DanhSachChiPhiSanXuatTheoThang_Result;
        }

        #endregion

    #region Primitive Properties
    
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
        public string MaChuongTrinhQL
        {
            get
            {
                return _maChuongTrinhQL;
            }
            set
            {
    			string oldValue =  _maChuongTrinhQL;
    			bool stopChanging = false;
                On_MaChuongTrinhQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChuongTrinhQL");
    			if(!stopChanging)
    			{
    				_maChuongTrinhQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaChuongTrinhQL");
    				On_MaChuongTrinhQL_Changed(oldValue, _maChuongTrinhQL);//\\
    			}
            }
        }
    	public static String MaChuongTrinhQL_PropertyName { get { return "MaChuongTrinhQL"; } }
        private string _maChuongTrinhQL;
        partial void On_MaChuongTrinhQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaChuongTrinhQL_Changed(string oldValue, string currentValue);
    
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
        public string MaGiayXacNhanQL
        {
            get
            {
                return _maGiayXacNhanQL;
            }
            set
            {
    			string oldValue =  _maGiayXacNhanQL;
    			bool stopChanging = false;
                On_MaGiayXacNhanQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaGiayXacNhanQL");
    			if(!stopChanging)
    			{
    				_maGiayXacNhanQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaGiayXacNhanQL");
    				On_MaGiayXacNhanQL_Changed(oldValue, _maGiayXacNhanQL);//\\
    			}
            }
        }
    	public static String MaGiayXacNhanQL_PropertyName { get { return "MaGiayXacNhanQL"; } }
        private string _maGiayXacNhanQL;
        partial void On_MaGiayXacNhanQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaGiayXacNhanQL_Changed(string oldValue, string currentValue);
    
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
        public Nullable<decimal> TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienThue;
    			bool stopChanging = false;
                On_TienThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienThue");
    			if(!stopChanging)
    			{
    				_tienThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienThue");
    				On_TienThue_Changed(oldValue, _tienThue);//\\
    			}
            }
        }
    	public static String TienThue_PropertyName { get { return "TienThue"; } }
        private Nullable<decimal> _tienThue;
        partial void On_TienThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<bool> LoaiNV
        {
            get
            {
                return _loaiNV;
            }
            set
            {
    			Nullable<bool> oldValue =  _loaiNV;
    			bool stopChanging = false;
                On_LoaiNV_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiNV");
    			if(!stopChanging)
    			{
    				_loaiNV = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiNV");
    				On_LoaiNV_Changed(oldValue, _loaiNV);//\\
    			}
            }
        }
    	public static String LoaiNV_PropertyName { get { return "LoaiNV"; } }
        private Nullable<bool> _loaiNV;
        partial void On_LoaiNV_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_LoaiNV_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenLoaiNhanVien
        {
            get
            {
                return _tenLoaiNhanVien;
            }
            set
            {
    			string oldValue =  _tenLoaiNhanVien;
    			bool stopChanging = false;
                On_TenLoaiNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenLoaiNhanVien");
    			if(!stopChanging)
    			{
    				_tenLoaiNhanVien = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("TenLoaiNhanVien");
    				On_TenLoaiNhanVien_Changed(oldValue, _tenLoaiNhanVien);//\\
    			}
            }
        }
    	public static String TenLoaiNhanVien_PropertyName { get { return "TenLoaiNhanVien"; } }
        private string _tenLoaiNhanVien;
        partial void On_TenLoaiNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenLoaiNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoDNCK
        {
            get
            {
                return _soDNCK;
            }
            set
            {
    			string oldValue =  _soDNCK;
    			bool stopChanging = false;
                On_SoDNCK_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoDNCK");
    			if(!stopChanging)
    			{
    				_soDNCK = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoDNCK");
    				On_SoDNCK_Changed(oldValue, _soDNCK);//\\
    			}
            }
        }
    	public static String SoDNCK_PropertyName { get { return "SoDNCK"; } }
        private string _soDNCK;
        partial void On_SoDNCK_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoDNCK_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayDeNghi
        {
            get
            {
                return _ngayDeNghi;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayDeNghi;
    			bool stopChanging = false;
                On_NgayDeNghi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayDeNghi");
    			if(!stopChanging)
    			{
    				_ngayDeNghi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayDeNghi");
    				On_NgayDeNghi_Changed(oldValue, _ngayDeNghi);//\\
    			}
            }
        }
    	public static String NgayDeNghi_PropertyName { get { return "NgayDeNghi"; } }
        private Nullable<System.DateTime> _ngayDeNghi;
        partial void On_NgayDeNghi_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayDeNghi_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);

    #endregion

    }
}

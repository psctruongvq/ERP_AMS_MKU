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
    [EdmComplexTypeAttribute(NamespaceName="PSC_ERPModel", Name="spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result object.
        /// </summary>
        /// <param name="tenNguoiLap">Initial value of the TenNguoiLap property.</param>
        public static spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result Createspd_DanhSachChungTuListByKetChuyenChiPhi_New_Result(string tenNguoiLap)
        {
            spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result = new spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result();
            spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result.TenNguoiLap = tenNguoiLap;
            return spd_DanhSachChungTuListByKetChuyenChiPhi_New_Result;
        }

        #endregion

    #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
    			Nullable<int> oldValue =  _maChungTu;
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
        private Nullable<int> _maChungTu;
        partial void On_MaChungTu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
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
    				_soChungTu = StructuralObject.SetValidValue(value, true);
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
        public Nullable<decimal> SoTienMucNganSach
        {
            get
            {
                return _soTienMucNganSach;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienMucNganSach;
    			bool stopChanging = false;
                On_SoTienMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienMucNganSach");
    			if(!stopChanging)
    			{
    				_soTienMucNganSach = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienMucNganSach");
    				On_SoTienMucNganSach_Changed(oldValue, _soTienMucNganSach);//\\
    			}
            }
        }
    	public static String SoTienMucNganSach_PropertyName { get { return "SoTienMucNganSach"; } }
        private Nullable<decimal> _soTienMucNganSach;
        partial void On_SoTienMucNganSach_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienMucNganSach_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienChiPhiSanXuat
        {
            get
            {
                return _soTienChiPhiSanXuat;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienChiPhiSanXuat;
    			bool stopChanging = false;
                On_SoTienChiPhiSanXuat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienChiPhiSanXuat");
    			if(!stopChanging)
    			{
    				_soTienChiPhiSanXuat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienChiPhiSanXuat");
    				On_SoTienChiPhiSanXuat_Changed(oldValue, _soTienChiPhiSanXuat);//\\
    			}
            }
        }
    	public static String SoTienChiPhiSanXuat_PropertyName { get { return "SoTienChiPhiSanXuat"; } }
        private Nullable<decimal> _soTienChiPhiSanXuat;
        partial void On_SoTienChiPhiSanXuat_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienChiPhiSanXuat_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTieuMucNganSach
        {
            get
            {
                return _tenTieuMucNganSach;
            }
            set
            {
    			string oldValue =  _tenTieuMucNganSach;
    			bool stopChanging = false;
                On_TenTieuMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTieuMucNganSach");
    			if(!stopChanging)
    			{
    				_tenTieuMucNganSach = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTieuMucNganSach");
    				On_TenTieuMucNganSach_Changed(oldValue, _tenTieuMucNganSach);//\\
    			}
            }
        }
    	public static String TenTieuMucNganSach_PropertyName { get { return "TenTieuMucNganSach"; } }
        private string _tenTieuMucNganSach;
        partial void On_TenTieuMucNganSach_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTieuMucNganSach_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenMucNganSach
        {
            get
            {
                return _tenMucNganSach;
            }
            set
            {
    			string oldValue =  _tenMucNganSach;
    			bool stopChanging = false;
                On_TenMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenMucNganSach");
    			if(!stopChanging)
    			{
    				_tenMucNganSach = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenMucNganSach");
    				On_TenMucNganSach_Changed(oldValue, _tenMucNganSach);//\\
    			}
            }
        }
    	public static String TenMucNganSach_PropertyName { get { return "TenMucNganSach"; } }
        private string _tenMucNganSach;
        partial void On_TenMucNganSach_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenMucNganSach_Changed(string oldValue, string currentValue);
    
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
        public string TKCO
        {
            get
            {
                return _tKCO;
            }
            set
            {
    			string oldValue =  _tKCO;
    			bool stopChanging = false;
                On_TKCO_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TKCO");
    			if(!stopChanging)
    			{
    				_tKCO = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TKCO");
    				On_TKCO_Changed(oldValue, _tKCO);//\\
    			}
            }
        }
    	public static String TKCO_PropertyName { get { return "TKCO"; } }
        private string _tKCO;
        partial void On_TKCO_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TKCO_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoanCo
        {
            get
            {
                return _maTaiKhoanCo;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoanCo;
    			bool stopChanging = false;
                On_MaTaiKhoanCo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoanCo");
    			if(!stopChanging)
    			{
    				_maTaiKhoanCo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoanCo");
    				On_MaTaiKhoanCo_Changed(oldValue, _maTaiKhoanCo);//\\
    			}
            }
        }
    	public static String MaTaiKhoanCo_PropertyName { get { return "MaTaiKhoanCo"; } }
        private Nullable<int> _maTaiKhoanCo;
        partial void On_MaTaiKhoanCo_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoanCo_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTieuMucNganSach
        {
            get
            {
                return _maTieuMucNganSach;
            }
            set
            {
    			Nullable<int> oldValue =  _maTieuMucNganSach;
    			bool stopChanging = false;
                On_MaTieuMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTieuMucNganSach");
    			if(!stopChanging)
    			{
    				_maTieuMucNganSach = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTieuMucNganSach");
    				On_MaTieuMucNganSach_Changed(oldValue, _maTieuMucNganSach);//\\
    			}
            }
        }
    	public static String MaTieuMucNganSach_PropertyName { get { return "MaTieuMucNganSach"; } }
        private Nullable<int> _maTieuMucNganSach;
        partial void On_MaTieuMucNganSach_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTieuMucNganSach_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaButToanMucNganSach
        {
            get
            {
                return _maButToanMucNganSach;
            }
            set
            {
    			Nullable<int> oldValue =  _maButToanMucNganSach;
    			bool stopChanging = false;
                On_MaButToanMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaButToanMucNganSach");
    			if(!stopChanging)
    			{
    				_maButToanMucNganSach = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaButToanMucNganSach");
    				On_MaButToanMucNganSach_Changed(oldValue, _maButToanMucNganSach);//\\
    			}
            }
        }
    	public static String MaButToanMucNganSach_PropertyName { get { return "MaButToanMucNganSach"; } }
        private Nullable<int> _maButToanMucNganSach;
        partial void On_MaButToanMucNganSach_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaButToanMucNganSach_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaButToanChiPhiSanXuat
        {
            get
            {
                return _maButToanChiPhiSanXuat;
            }
            set
            {
    			Nullable<int> oldValue =  _maButToanChiPhiSanXuat;
    			bool stopChanging = false;
                On_MaButToanChiPhiSanXuat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaButToanChiPhiSanXuat");
    			if(!stopChanging)
    			{
    				_maButToanChiPhiSanXuat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaButToanChiPhiSanXuat");
    				On_MaButToanChiPhiSanXuat_Changed(oldValue, _maButToanChiPhiSanXuat);//\\
    			}
            }
        }
    	public static String MaButToanChiPhiSanXuat_PropertyName { get { return "MaButToanChiPhiSanXuat"; } }
        private Nullable<int> _maButToanChiPhiSanXuat;
        partial void On_MaButToanChiPhiSanXuat_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaButToanChiPhiSanXuat_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> MaMucNganSach
        {
            get
            {
                return _maMucNganSach;
            }
            set
            {
    			Nullable<int> oldValue =  _maMucNganSach;
    			bool stopChanging = false;
                On_MaMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaMucNganSach");
    			if(!stopChanging)
    			{
    				_maMucNganSach = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaMucNganSach");
    				On_MaMucNganSach_Changed(oldValue, _maMucNganSach);//\\
    			}
            }
        }
    	public static String MaMucNganSach_PropertyName { get { return "MaMucNganSach"; } }
        private Nullable<int> _maMucNganSach;
        partial void On_MaMucNganSach_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaMucNganSach_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChiThuLao
        {
            get
            {
                return _maChiThuLao;
            }
            set
            {
    			Nullable<int> oldValue =  _maChiThuLao;
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
    	public static String MaChiThuLao_PropertyName { get { return "MaChiThuLao"; } }
        private Nullable<int> _maChiThuLao;
        partial void On_MaChiThuLao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChiThuLao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChiPhiThucHien
        {
            get
            {
                return _maChiPhiThucHien;
            }
            set
            {
    			Nullable<int> oldValue =  _maChiPhiThucHien;
    			bool stopChanging = false;
                On_MaChiPhiThucHien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChiPhiThucHien");
    			if(!stopChanging)
    			{
    				_maChiPhiThucHien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChiPhiThucHien");
    				On_MaChiPhiThucHien_Changed(oldValue, _maChiPhiThucHien);//\\
    			}
            }
        }
    	public static String MaChiPhiThucHien_PropertyName { get { return "MaChiPhiThucHien"; } }
        private Nullable<int> _maChiPhiThucHien;
        partial void On_MaChiPhiThucHien_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChiPhiThucHien_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaButToan
        {
            get
            {
                return _maButToan;
            }
            set
            {
    			Nullable<int> oldValue =  _maButToan;
    			bool stopChanging = false;
                On_MaButToan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaButToan");
    			if(!stopChanging)
    			{
    				_maButToan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaButToan");
    				On_MaButToan_Changed(oldValue, _maButToan);//\\
    			}
            }
        }
    	public static String MaButToan_PropertyName { get { return "MaButToan"; } }
        private Nullable<int> _maButToan;
        partial void On_MaButToan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaButToan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public string TenTaiKhoan
        {
            get
            {
                return _tenTaiKhoan;
            }
            set
            {
    			string oldValue =  _tenTaiKhoan;
    			bool stopChanging = false;
                On_TenTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTaiKhoan");
    			if(!stopChanging)
    			{
    				_tenTaiKhoan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTaiKhoan");
    				On_TenTaiKhoan_Changed(oldValue, _tenTaiKhoan);//\\
    			}
            }
        }
    	public static String TenTaiKhoan_PropertyName { get { return "TenTaiKhoan"; } }
        private string _tenTaiKhoan;
        partial void On_TenTaiKhoan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTaiKhoan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNguoiLap
        {
            get
            {
                return _tenNguoiLap;
            }
            set
            {
    			string oldValue =  _tenNguoiLap;
    			bool stopChanging = false;
                On_TenNguoiLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNguoiLap");
    			if(!stopChanging)
    			{
    				_tenNguoiLap = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("TenNguoiLap");
    				On_TenNguoiLap_Changed(oldValue, _tenNguoiLap);//\\
    			}
            }
        }
    	public static String TenNguoiLap_PropertyName { get { return "TenNguoiLap"; } }
        private string _tenNguoiLap;
        partial void On_TenNguoiLap_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNguoiLap_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaButToanMucNganSachNew
        {
            get
            {
                return _maButToanMucNganSachNew;
            }
            set
            {
    			Nullable<int> oldValue =  _maButToanMucNganSachNew;
    			bool stopChanging = false;
                On_MaButToanMucNganSachNew_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaButToanMucNganSachNew");
    			if(!stopChanging)
    			{
    				_maButToanMucNganSachNew = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaButToanMucNganSachNew");
    				On_MaButToanMucNganSachNew_Changed(oldValue, _maButToanMucNganSachNew);//\\
    			}
            }
        }
    	public static String MaButToanMucNganSachNew_PropertyName { get { return "MaButToanMucNganSachNew"; } }
        private Nullable<int> _maButToanMucNganSachNew;
        partial void On_MaButToanMucNganSachNew_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaButToanMucNganSachNew_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

    #endregion

    }
}

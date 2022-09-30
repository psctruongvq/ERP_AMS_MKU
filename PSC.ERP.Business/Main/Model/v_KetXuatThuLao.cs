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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_KetXuatThuLao")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_KetXuatThuLao : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_KetXuatThuLao()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_KetXuatThuLao object.
        /// </summary>
        /// <param name="maChuongTrinh">Initial value of the MaChuongTrinh property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        /// <param name="tienThue">Initial value of the TienThue property.</param>
        /// <param name="tienSauThue">Initial value of the TienSauThue property.</param>
        /// <param name="tenNguoiLap">Initial value of the TenNguoiLap property.</param>
        public static v_KetXuatThuLao Createv_KetXuatThuLao(int maChuongTrinh, decimal soTien, decimal tienThue, decimal tienSauThue, string tenNguoiLap)
        {
            v_KetXuatThuLao v_KetXuatThuLao = new v_KetXuatThuLao();
            v_KetXuatThuLao.MaChuongTrinh = maChuongTrinh;
            v_KetXuatThuLao.SoTien = soTien;
            v_KetXuatThuLao.TienThue = tienThue;
            v_KetXuatThuLao.TienSauThue = tienSauThue;
            v_KetXuatThuLao.TenNguoiLap = tenNguoiLap;
            return v_KetXuatThuLao;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChuongTrinh
        {
            get
            {
                return _maChuongTrinh;
            }
            set
            {
                if (_maChuongTrinh != value)
                {
        			int oldValue =  _maChuongTrinh;
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
        }
    	public static String MaChuongTrinh_PropertyName { get { return "MaChuongTrinh"; } }
        private int _maChuongTrinh;
        partial void On_MaChuongTrinh_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChuongTrinh_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaQL
        {
            get
            {
                return _maQL;
            }
            set
            {
    			string oldValue =  _maQL;
    			bool stopChanging = false;
                On_MaQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQL");
    			if(!stopChanging)
    			{
    				_maQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQL");
    				On_MaQL_Changed(oldValue, _maQL);//\\
    			}
            }
        }
    	public static String MaQL_PropertyName { get { return "MaQL"; } }
        private string _maQL;
        partial void On_MaQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQL_Changed(string oldValue, string currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (_soTien != value)
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
        }
    	public static String SoTien_PropertyName { get { return "SoTien"; } }
        private decimal _soTien;
        partial void On_SoTien_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
                if (_tienThue != value)
                {
        			decimal oldValue =  _tienThue;
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
        }
    	public static String TienThue_PropertyName { get { return "TienThue"; } }
        private decimal _tienThue;
        partial void On_TienThue_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_TienThue_Changed(decimal oldValue, decimal currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public decimal TienSauThue
        {
            get
            {
                return _tienSauThue;
            }
            set
            {
                if (_tienSauThue != value)
                {
        			decimal oldValue =  _tienSauThue;
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
        }
    	public static String TienSauThue_PropertyName { get { return "TienSauThue"; } }
        private decimal _tienSauThue;
        partial void On_TienSauThue_Changing(decimal currentValue, ref decimal newValue, ref bool stopChanging);
        partial void On_TienSauThue_Changed(decimal oldValue, decimal currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNguoiLap
        {
            get
            {
                return _tenNguoiLap;
            }
            set
            {
                if (_tenNguoiLap != value)
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
        public Nullable<long> MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVien;
    			bool stopChanging = false;
                On_MaNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNhanVien");
    			if(!stopChanging)
    			{
    				_maNhanVien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNhanVien");
    				On_MaNhanVien_Changed(oldValue, _maNhanVien);//\\
    			}
            }
        }
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private Nullable<long> _maNhanVien;
        partial void On_MaNhanVien_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set
            {
    			string oldValue =  _tenNhanVien;
    			bool stopChanging = false;
                On_TenNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhanVien");
    			if(!stopChanging)
    			{
    				_tenNhanVien = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNhanVien");
    				On_TenNhanVien_Changed(oldValue, _tenNhanVien);//\\
    			}
            }
        }
    	public static String TenNhanVien_PropertyName { get { return "TenNhanVien"; } }
        private string _tenNhanVien;
        partial void On_TenNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVien_Changed(string oldValue, string currentValue);
    
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

        #endregion

    }
}

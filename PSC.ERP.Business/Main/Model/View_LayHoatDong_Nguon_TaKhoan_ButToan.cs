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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="View_LayHoatDong_Nguon_TaKhoan_ButToan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class View_LayHoatDong_Nguon_TaKhoan_ButToan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public View_LayHoatDong_Nguon_TaKhoan_ButToan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new View_LayHoatDong_Nguon_TaKhoan_ButToan object.
        /// </summary>
        /// <param name="maMucNganSach">Initial value of the MaMucNganSach property.</param>
        /// <param name="maMucNganSachQL">Initial value of the MaMucNganSachQL property.</param>
        /// <param name="tenMucNganSach">Initial value of the TenMucNganSach property.</param>
        /// <param name="maTieuMuc">Initial value of the MaTieuMuc property.</param>
        /// <param name="maTieuMucQL">Initial value of the MaTieuMucQL property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        /// <param name="tenNguon">Initial value of the TenNguon property.</param>
        /// <param name="tenTaiKhoan">Initial value of the TenTaiKhoan property.</param>
        /// <param name="soHieuTK">Initial value of the SoHieuTK property.</param>
        /// <param name="maNguon">Initial value of the MaNguon property.</param>
        public static View_LayHoatDong_Nguon_TaKhoan_ButToan CreateView_LayHoatDong_Nguon_TaKhoan_ButToan(int maMucNganSach, string maMucNganSachQL, string tenMucNganSach, int maTieuMuc, string maTieuMucQL, decimal soTien, string tenNguon, string tenTaiKhoan, string soHieuTK, int maNguon)
        {
            View_LayHoatDong_Nguon_TaKhoan_ButToan view_LayHoatDong_Nguon_TaKhoan_ButToan = new View_LayHoatDong_Nguon_TaKhoan_ButToan();
            view_LayHoatDong_Nguon_TaKhoan_ButToan.MaMucNganSach = maMucNganSach;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.MaMucNganSachQL = maMucNganSachQL;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.TenMucNganSach = tenMucNganSach;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.MaTieuMuc = maTieuMuc;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.MaTieuMucQL = maTieuMucQL;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.SoTien = soTien;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.TenNguon = tenNguon;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.TenTaiKhoan = tenTaiKhoan;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.SoHieuTK = soHieuTK;
            view_LayHoatDong_Nguon_TaKhoan_ButToan.MaNguon = maNguon;
            return view_LayHoatDong_Nguon_TaKhoan_ButToan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaMucNganSach
        {
            get
            {
                return _maMucNganSach;
            }
            set
            {
                if (_maMucNganSach != value)
                {
        			int oldValue =  _maMucNganSach;
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
        }
    	public static String MaMucNganSach_PropertyName { get { return "MaMucNganSach"; } }
        private int _maMucNganSach;
        partial void On_MaMucNganSach_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaMucNganSach_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaMucNganSachQL
        {
            get
            {
                return _maMucNganSachQL;
            }
            set
            {
                if (_maMucNganSachQL != value)
                {
        			string oldValue =  _maMucNganSachQL;
        			bool stopChanging = false;
                    On_MaMucNganSachQL_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaMucNganSachQL");
        			if(!stopChanging)
        			{
        				_maMucNganSachQL = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaMucNganSachQL");
        				On_MaMucNganSachQL_Changed(oldValue, _maMucNganSachQL);//\\
        			}
                }
            }
        }
    	public static String MaMucNganSachQL_PropertyName { get { return "MaMucNganSachQL"; } }
        private string _maMucNganSachQL;
        partial void On_MaMucNganSachQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaMucNganSachQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenMucNganSach
        {
            get
            {
                return _tenMucNganSach;
            }
            set
            {
                if (_tenMucNganSach != value)
                {
        			string oldValue =  _tenMucNganSach;
        			bool stopChanging = false;
                    On_TenMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenMucNganSach");
        			if(!stopChanging)
        			{
        				_tenMucNganSach = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenMucNganSach");
        				On_TenMucNganSach_Changed(oldValue, _tenMucNganSach);//\\
        			}
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTieuMuc
        {
            get
            {
                return _maTieuMuc;
            }
            set
            {
                if (_maTieuMuc != value)
                {
        			int oldValue =  _maTieuMuc;
        			bool stopChanging = false;
                    On_MaTieuMuc_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTieuMuc");
        			if(!stopChanging)
        			{
        				_maTieuMuc = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTieuMuc");
        				On_MaTieuMuc_Changed(oldValue, _maTieuMuc);//\\
        			}
                }
            }
        }
    	public static String MaTieuMuc_PropertyName { get { return "MaTieuMuc"; } }
        private int _maTieuMuc;
        partial void On_MaTieuMuc_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTieuMuc_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTieuMuc
        {
            get
            {
                return _tenTieuMuc;
            }
            set
            {
    			string oldValue =  _tenTieuMuc;
    			bool stopChanging = false;
                On_TenTieuMuc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTieuMuc");
    			if(!stopChanging)
    			{
    				_tenTieuMuc = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTieuMuc");
    				On_TenTieuMuc_Changed(oldValue, _tenTieuMuc);//\\
    			}
            }
        }
    	public static String TenTieuMuc_PropertyName { get { return "TenTieuMuc"; } }
        private string _tenTieuMuc;
        partial void On_TenTieuMuc_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTieuMuc_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaTieuMucQL
        {
            get
            {
                return _maTieuMucQL;
            }
            set
            {
                if (_maTieuMucQL != value)
                {
        			string oldValue =  _maTieuMucQL;
        			bool stopChanging = false;
                    On_MaTieuMucQL_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTieuMucQL");
        			if(!stopChanging)
        			{
        				_maTieuMucQL = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaTieuMucQL");
        				On_MaTieuMucQL_Changed(oldValue, _maTieuMucQL);//\\
        			}
                }
            }
        }
    	public static String MaTieuMucQL_PropertyName { get { return "MaTieuMucQL"; } }
        private string _maTieuMucQL;
        partial void On_MaTieuMucQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaTieuMucQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> NoTaiKhoan
        {
            get
            {
                return _noTaiKhoan;
            }
            set
            {
    			Nullable<int> oldValue =  _noTaiKhoan;
    			bool stopChanging = false;
                On_NoTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NoTaiKhoan");
    			if(!stopChanging)
    			{
    				_noTaiKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NoTaiKhoan");
    				On_NoTaiKhoan_Changed(oldValue, _noTaiKhoan);//\\
    			}
            }
        }
    	public static String NoTaiKhoan_PropertyName { get { return "NoTaiKhoan"; } }
        private Nullable<int> _noTaiKhoan;
        partial void On_NoTaiKhoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_NoTaiKhoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<int> UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			Nullable<int> oldValue =  _userID;
    			bool stopChanging = false;
                On_UserID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserID");
    			if(!stopChanging)
    			{
    				_userID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserID");
    				On_UserID_Changed(oldValue, _userID);//\\
    			}
            }
        }
    	public static String UserID_PropertyName { get { return "UserID"; } }
        private Nullable<int> _userID;
        partial void On_UserID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenHoatDong
        {
            get
            {
                return _tenHoatDong;
            }
            set
            {
    			string oldValue =  _tenHoatDong;
    			bool stopChanging = false;
                On_TenHoatDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenHoatDong");
    			if(!stopChanging)
    			{
    				_tenHoatDong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenHoatDong");
    				On_TenHoatDong_Changed(oldValue, _tenHoatDong);//\\
    			}
            }
        }
    	public static String TenHoatDong_PropertyName { get { return "TenHoatDong"; } }
        private string _tenHoatDong;
        partial void On_TenHoatDong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenHoatDong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNguon
        {
            get
            {
                return _tenNguon;
            }
            set
            {
                if (_tenNguon != value)
                {
        			string oldValue =  _tenNguon;
        			bool stopChanging = false;
                    On_TenNguon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenNguon");
        			if(!stopChanging)
        			{
        				_tenNguon = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenNguon");
        				On_TenNguon_Changed(oldValue, _tenNguon);//\\
        			}
                }
            }
        }
    	public static String TenNguon_PropertyName { get { return "TenNguon"; } }
        private string _tenNguon;
        partial void On_TenNguon_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNguon_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenTaiKhoan
        {
            get
            {
                return _tenTaiKhoan;
            }
            set
            {
                if (_tenTaiKhoan != value)
                {
        			string oldValue =  _tenTaiKhoan;
        			bool stopChanging = false;
                    On_TenTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenTaiKhoan");
        			if(!stopChanging)
        			{
        				_tenTaiKhoan = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenTaiKhoan");
        				On_TenTaiKhoan_Changed(oldValue, _tenTaiKhoan);//\\
        			}
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SoHieuTK
        {
            get
            {
                return _soHieuTK;
            }
            set
            {
                if (_soHieuTK != value)
                {
        			string oldValue =  _soHieuTK;
        			bool stopChanging = false;
                    On_SoHieuTK_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("SoHieuTK");
        			if(!stopChanging)
        			{
        				_soHieuTK = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("SoHieuTK");
        				On_SoHieuTK_Changed(oldValue, _soHieuTK);//\\
        			}
                }
            }
        }
    	public static String SoHieuTK_PropertyName { get { return "SoHieuTK"; } }
        private string _soHieuTK;
        partial void On_SoHieuTK_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTK_Changed(string oldValue, string currentValue);
    
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
        public Nullable<int> MaNguoiLap
        {
            get
            {
                return _maNguoiLap;
            }
            set
            {
    			Nullable<int> oldValue =  _maNguoiLap;
    			bool stopChanging = false;
                On_MaNguoiLap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNguoiLap");
    			if(!stopChanging)
    			{
    				_maNguoiLap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNguoiLap");
    				On_MaNguoiLap_Changed(oldValue, _maNguoiLap);//\\
    			}
            }
        }
    	public static String MaNguoiLap_PropertyName { get { return "MaNguoiLap"; } }
        private Nullable<int> _maNguoiLap;
        partial void On_MaNguoiLap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNguoiLap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNguon
        {
            get
            {
                return _maNguon;
            }
            set
            {
                if (_maNguon != value)
                {
        			int oldValue =  _maNguon;
        			bool stopChanging = false;
                    On_MaNguon_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNguon");
        			if(!stopChanging)
        			{
        				_maNguon = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNguon");
        				On_MaNguon_Changed(oldValue, _maNguon);//\\
        			}
                }
            }
        }
    	public static String MaNguon_PropertyName { get { return "MaNguon"; } }
        private int _maNguon;
        partial void On_MaNguon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNguon_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTaiKhoanCapMot
        {
            get
            {
                return _tenTaiKhoanCapMot;
            }
            set
            {
    			string oldValue =  _tenTaiKhoanCapMot;
    			bool stopChanging = false;
                On_TenTaiKhoanCapMot_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTaiKhoanCapMot");
    			if(!stopChanging)
    			{
    				_tenTaiKhoanCapMot = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTaiKhoanCapMot");
    				On_TenTaiKhoanCapMot_Changed(oldValue, _tenTaiKhoanCapMot);//\\
    			}
            }
        }
    	public static String TenTaiKhoanCapMot_PropertyName { get { return "TenTaiKhoanCapMot"; } }
        private string _tenTaiKhoanCapMot;
        partial void On_TenTaiKhoanCapMot_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTaiKhoanCapMot_Changed(string oldValue, string currentValue);

        #endregion

    }
}
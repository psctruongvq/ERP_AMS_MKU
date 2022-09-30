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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ButToan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ButToan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ButToan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ButToan object.
        /// </summary>
        /// <param name="maButToan">Initial value of the MaButToan property.</param>
        /// <param name="soTien">Initial value of the SoTien property.</param>
        /// <param name="maDinhKhoan">Initial value of the MaDinhKhoan property.</param>
        public static v_ButToan Createv_ButToan(int maButToan, decimal soTien, int maDinhKhoan)
        {
            v_ButToan v_ButToan = new v_ButToan();
            v_ButToan.MaButToan = maButToan;
            v_ButToan.SoTien = soTien;
            v_ButToan.MaDinhKhoan = maDinhKhoan;
            return v_ButToan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaButToan
        {
            get
            {
                return _maButToan;
            }
            set
            {
                if (_maButToan != value)
                {
        			int oldValue =  _maButToan;
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
        }
    	public static String MaButToan_PropertyName { get { return "MaButToan"; } }
        private int _maButToan;
        partial void On_MaButToan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaButToan_Changed(int oldValue, int currentValue);
    
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
        public Nullable<int> CoTaiKhoan
        {
            get
            {
                return _coTaiKhoan;
            }
            set
            {
    			Nullable<int> oldValue =  _coTaiKhoan;
    			bool stopChanging = false;
                On_CoTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CoTaiKhoan");
    			if(!stopChanging)
    			{
    				_coTaiKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("CoTaiKhoan");
    				On_CoTaiKhoan_Changed(oldValue, _coTaiKhoan);//\\
    			}
            }
        }
    	public static String CoTaiKhoan_PropertyName { get { return "CoTaiKhoan"; } }
        private Nullable<int> _coTaiKhoan;
        partial void On_CoTaiKhoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_CoTaiKhoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<long> MaDoiTuongCo
        {
            get
            {
                return _maDoiTuongCo;
            }
            set
            {
    			Nullable<long> oldValue =  _maDoiTuongCo;
    			bool stopChanging = false;
                On_MaDoiTuongCo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTuongCo");
    			if(!stopChanging)
    			{
    				_maDoiTuongCo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTuongCo");
    				On_MaDoiTuongCo_Changed(oldValue, _maDoiTuongCo);//\\
    			}
            }
        }
    	public static String MaDoiTuongCo_PropertyName { get { return "MaDoiTuongCo"; } }
        private Nullable<long> _maDoiTuongCo;
        partial void On_MaDoiTuongCo_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaDoiTuongCo_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaDoiTuongNo
        {
            get
            {
                return _maDoiTuongNo;
            }
            set
            {
    			Nullable<long> oldValue =  _maDoiTuongNo;
    			bool stopChanging = false;
                On_MaDoiTuongNo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTuongNo");
    			if(!stopChanging)
    			{
    				_maDoiTuongNo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTuongNo");
    				On_MaDoiTuongNo_Changed(oldValue, _maDoiTuongNo);//\\
    			}
            }
        }
    	public static String MaDoiTuongNo_PropertyName { get { return "MaDoiTuongNo"; } }
        private Nullable<long> _maDoiTuongNo;
        partial void On_MaDoiTuongNo_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaDoiTuongNo_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaDinhKhoan
        {
            get
            {
                return _maDinhKhoan;
            }
            set
            {
                if (_maDinhKhoan != value)
                {
        			int oldValue =  _maDinhKhoan;
        			bool stopChanging = false;
                    On_MaDinhKhoan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaDinhKhoan");
        			if(!stopChanging)
        			{
        				_maDinhKhoan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaDinhKhoan");
        				On_MaDinhKhoan_Changed(oldValue, _maDinhKhoan);//\\
        			}
                }
            }
        }
    	public static String MaDinhKhoan_PropertyName { get { return "MaDinhKhoan"; } }
        private int _maDinhKhoan;
        partial void On_MaDinhKhoan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaDinhKhoan_Changed(int oldValue, int currentValue);
    
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
        public Nullable<int> MaSoQuy
        {
            get
            {
                return _maSoQuy;
            }
            set
            {
    			Nullable<int> oldValue =  _maSoQuy;
    			bool stopChanging = false;
                On_MaSoQuy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaSoQuy");
    			if(!stopChanging)
    			{
    				_maSoQuy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaSoQuy");
    				On_MaSoQuy_Changed(oldValue, _maSoQuy);//\\
    			}
            }
        }
    	public static String MaSoQuy_PropertyName { get { return "MaSoQuy"; } }
        private Nullable<int> _maSoQuy;
        partial void On_MaSoQuy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaSoQuy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaHopDong
        {
            get
            {
                return _maHopDong;
            }
            set
            {
    			Nullable<long> oldValue =  _maHopDong;
    			bool stopChanging = false;
                On_MaHopDong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHopDong");
    			if(!stopChanging)
    			{
    				_maHopDong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHopDong");
    				On_MaHopDong_Changed(oldValue, _maHopDong);//\\
    			}
            }
        }
    	public static String MaHopDong_PropertyName { get { return "MaHopDong"; } }
        private Nullable<long> _maHopDong;
        partial void On_MaHopDong_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaHopDong_Changed(Nullable<long> oldValue, Nullable<long> currentValue);

        #endregion

    }
}

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
    [EdmComplexTypeAttribute(NamespaceName="PSC_ERPModel", Name="spd_TSCD_LichSuTongQuatSuDungTaiSan_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class spd_TSCD_LichSuTongQuatSuDungTaiSan_Result : ComplexObject
    {
    #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> Ngay
        {
            get
            {
                return _ngay;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngay;
    			bool stopChanging = false;
                On_Ngay_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Ngay");
    			if(!stopChanging)
    			{
    				_ngay = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Ngay");
    				On_Ngay_Changed(oldValue, _ngay);//\\
    			}
            }
        }
    	public static String Ngay_PropertyName { get { return "Ngay"; } }
        private Nullable<System.DateTime> _ngay;
        partial void On_Ngay_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_Ngay_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTaiSan
        {
            get
            {
                return _tenTaiSan;
            }
            set
            {
    			string oldValue =  _tenTaiSan;
    			bool stopChanging = false;
                On_TenTaiSan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTaiSan");
    			if(!stopChanging)
    			{
    				_tenTaiSan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTaiSan");
    				On_TenTaiSan_Changed(oldValue, _tenTaiSan);//\\
    			}
            }
        }
    	public static String TenTaiSan_PropertyName { get { return "TenTaiSan"; } }
        private string _tenTaiSan;
        partial void On_TenTaiSan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTaiSan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieu
        {
            get
            {
                return _soHieu;
            }
            set
            {
    			string oldValue =  _soHieu;
    			bool stopChanging = false;
                On_SoHieu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieu");
    			if(!stopChanging)
    			{
    				_soHieu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieu");
    				On_SoHieu_Changed(oldValue, _soHieu);//\\
    			}
            }
        }
    	public static String SoHieu_PropertyName { get { return "SoHieu"; } }
        private string _soHieu;
        partial void On_SoHieu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GiaTriBanDau
        {
            get
            {
                return _giaTriBanDau;
            }
            set
            {
    			Nullable<decimal> oldValue =  _giaTriBanDau;
    			bool stopChanging = false;
                On_GiaTriBanDau_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GiaTriBanDau");
    			if(!stopChanging)
    			{
    				_giaTriBanDau = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GiaTriBanDau");
    				On_GiaTriBanDau_Changed(oldValue, _giaTriBanDau);//\\
    			}
            }
        }
    	public static String GiaTriBanDau_PropertyName { get { return "GiaTriBanDau"; } }
        private Nullable<decimal> _giaTriBanDau;
        partial void On_GiaTriBanDau_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GiaTriBanDau_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<decimal> LuyKeKhauHao
        {
            get
            {
                return _luyKeKhauHao;
            }
            set
            {
    			Nullable<decimal> oldValue =  _luyKeKhauHao;
    			bool stopChanging = false;
                On_LuyKeKhauHao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LuyKeKhauHao");
    			if(!stopChanging)
    			{
    				_luyKeKhauHao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LuyKeKhauHao");
    				On_LuyKeKhauHao_Changed(oldValue, _luyKeKhauHao);//\\
    			}
            }
        }
    	public static String LuyKeKhauHao_PropertyName { get { return "LuyKeKhauHao"; } }
        private Nullable<decimal> _luyKeKhauHao;
        partial void On_LuyKeKhauHao_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LuyKeKhauHao_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> LuyKeHaoMon
        {
            get
            {
                return _luyKeHaoMon;
            }
            set
            {
    			Nullable<decimal> oldValue =  _luyKeHaoMon;
    			bool stopChanging = false;
                On_LuyKeHaoMon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LuyKeHaoMon");
    			if(!stopChanging)
    			{
    				_luyKeHaoMon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LuyKeHaoMon");
    				On_LuyKeHaoMon_Changed(oldValue, _luyKeHaoMon);//\\
    			}
            }
        }
    	public static String LuyKeHaoMon_PropertyName { get { return "LuyKeHaoMon"; } }
        private Nullable<decimal> _luyKeHaoMon;
        partial void On_LuyKeHaoMon_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LuyKeHaoMon_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GiaTriHienTai
        {
            get
            {
                return _giaTriHienTai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _giaTriHienTai;
    			bool stopChanging = false;
                On_GiaTriHienTai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GiaTriHienTai");
    			if(!stopChanging)
    			{
    				_giaTriHienTai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GiaTriHienTai");
    				On_GiaTriHienTai_Changed(oldValue, _giaTriHienTai);//\\
    			}
            }
        }
    	public static String GiaTriHienTai_PropertyName { get { return "GiaTriHienTai"; } }
        private Nullable<decimal> _giaTriHienTai;
        partial void On_GiaTriHienTai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GiaTriHienTai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenPhongBanBanDau
        {
            get
            {
                return _tenPhongBanBanDau;
            }
            set
            {
    			string oldValue =  _tenPhongBanBanDau;
    			bool stopChanging = false;
                On_TenPhongBanBanDau_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenPhongBanBanDau");
    			if(!stopChanging)
    			{
    				_tenPhongBanBanDau = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenPhongBanBanDau");
    				On_TenPhongBanBanDau_Changed(oldValue, _tenPhongBanBanDau);//\\
    			}
            }
        }
    	public static String TenPhongBanBanDau_PropertyName { get { return "TenPhongBanBanDau"; } }
        private string _tenPhongBanBanDau;
        partial void On_TenPhongBanBanDau_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenPhongBanBanDau_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenPhongBanHienTai
        {
            get
            {
                return _tenPhongBanHienTai;
            }
            set
            {
    			string oldValue =  _tenPhongBanHienTai;
    			bool stopChanging = false;
                On_TenPhongBanHienTai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenPhongBanHienTai");
    			if(!stopChanging)
    			{
    				_tenPhongBanHienTai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenPhongBanHienTai");
    				On_TenPhongBanHienTai_Changed(oldValue, _tenPhongBanHienTai);//\\
    			}
            }
        }
    	public static String TenPhongBanHienTai_PropertyName { get { return "TenPhongBanHienTai"; } }
        private string _tenPhongBanHienTai;
        partial void On_TenPhongBanHienTai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenPhongBanHienTai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenLoaiNghiepVu
        {
            get
            {
                return _tenLoaiNghiepVu;
            }
            set
            {
    			string oldValue =  _tenLoaiNghiepVu;
    			bool stopChanging = false;
                On_TenLoaiNghiepVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenLoaiNghiepVu");
    			if(!stopChanging)
    			{
    				_tenLoaiNghiepVu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenLoaiNghiepVu");
    				On_TenLoaiNghiepVu_Changed(oldValue, _tenLoaiNghiepVu);//\\
    			}
            }
        }
    	public static String TenLoaiNghiepVu_PropertyName { get { return "TenLoaiNghiepVu"; } }
        private string _tenLoaiNghiepVu;
        partial void On_TenLoaiNghiepVu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenLoaiNghiepVu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChuLyDo
        {
            get
            {
                return _ghiChuLyDo;
            }
            set
            {
    			string oldValue =  _ghiChuLyDo;
    			bool stopChanging = false;
                On_GhiChuLyDo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChuLyDo");
    			if(!stopChanging)
    			{
    				_ghiChuLyDo = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChuLyDo");
    				On_GhiChuLyDo_Changed(oldValue, _ghiChuLyDo);//\\
    			}
            }
        }
    	public static String GhiChuLyDo_PropertyName { get { return "GhiChuLyDo"; } }
        private string _ghiChuLyDo;
        partial void On_GhiChuLyDo_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChuLyDo_Changed(string oldValue, string currentValue);

    #endregion

    }
}

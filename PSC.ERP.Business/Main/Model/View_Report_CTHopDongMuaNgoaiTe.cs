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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="View_Report_CTHopDongMuaNgoaiTe")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class View_Report_CTHopDongMuaNgoaiTe : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public View_Report_CTHopDongMuaNgoaiTe()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new View_Report_CTHopDongMuaNgoaiTe object.
        /// </summary>
        /// <param name="tenLoaiTien">Initial value of the TenLoaiTien property.</param>
        public static View_Report_CTHopDongMuaNgoaiTe CreateView_Report_CTHopDongMuaNgoaiTe(string tenLoaiTien)
        {
            View_Report_CTHopDongMuaNgoaiTe view_Report_CTHopDongMuaNgoaiTe = new View_Report_CTHopDongMuaNgoaiTe();
            view_Report_CTHopDongMuaNgoaiTe.TenLoaiTien = tenLoaiTien;
            return view_Report_CTHopDongMuaNgoaiTe;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThanhTienVND
        {
            get
            {
                return _thanhTienVND;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thanhTienVND;
    			bool stopChanging = false;
                On_ThanhTienVND_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThanhTienVND");
    			if(!stopChanging)
    			{
    				_thanhTienVND = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThanhTienVND");
    				On_ThanhTienVND_Changed(oldValue, _thanhTienVND);//\\
    			}
            }
        }
    	public static String ThanhTienVND_PropertyName { get { return "ThanhTienVND"; } }
        private Nullable<decimal> _thanhTienVND;
        partial void On_ThanhTienVND_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThanhTienVND_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
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
        public Nullable<decimal> NguyenTe
        {
            get
            {
                return _nguyenTe;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nguyenTe;
    			bool stopChanging = false;
                On_NguyenTe_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguyenTe");
    			if(!stopChanging)
    			{
    				_nguyenTe = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguyenTe");
    				On_NguyenTe_Changed(oldValue, _nguyenTe);//\\
    			}
            }
        }
    	public static String NguyenTe_PropertyName { get { return "NguyenTe"; } }
        private Nullable<decimal> _nguyenTe;
        partial void On_NguyenTe_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NguyenTe_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenLoaiTien
        {
            get
            {
                return _tenLoaiTien;
            }
            set
            {
                if (_tenLoaiTien != value)
                {
        			string oldValue =  _tenLoaiTien;
        			bool stopChanging = false;
                    On_TenLoaiTien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenLoaiTien");
        			if(!stopChanging)
        			{
        				_tenLoaiTien = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenLoaiTien");
        				On_TenLoaiTien_Changed(oldValue, _tenLoaiTien);//\\
        			}
                }
            }
        }
    	public static String TenLoaiTien_PropertyName { get { return "TenLoaiTien"; } }
        private string _tenLoaiTien;
        partial void On_TenLoaiTien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenLoaiTien_Changed(string oldValue, string currentValue);
    
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

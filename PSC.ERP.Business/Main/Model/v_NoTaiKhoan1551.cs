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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_NoTaiKhoan1551")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_NoTaiKhoan1551 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_NoTaiKhoan1551()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_NoTaiKhoan1551 object.
        /// </summary>
        /// <param name="soChungTu">Initial value of the SoChungTu property.</param>
        /// <param name="maChuongTrinh">Initial value of the MaChuongTrinh property.</param>
        /// <param name="maButToan">Initial value of the MaButToan property.</param>
        public static v_NoTaiKhoan1551 Createv_NoTaiKhoan1551(string soChungTu, int maChuongTrinh, int maButToan)
        {
            v_NoTaiKhoan1551 v_NoTaiKhoan1551 = new v_NoTaiKhoan1551();
            v_NoTaiKhoan1551.SoChungTu = soChungTu;
            v_NoTaiKhoan1551.MaChuongTrinh = maChuongTrinh;
            v_NoTaiKhoan1551.MaButToan = maButToan;
            return v_NoTaiKhoan1551;
        }

        #endregion

        #region Primitive Properties
    
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
        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
            set
            {
                if (_soChungTu != value)
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
        }
    	public static String SoChungTu_PropertyName { get { return "SoChungTu"; } }
        private string _soChungTu;
        partial void On_SoChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoChungTu_Changed(string oldValue, string currentValue);
    
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
        public string MaQLChuongTrinh
        {
            get
            {
                return _maQLChuongTrinh;
            }
            set
            {
    			string oldValue =  _maQLChuongTrinh;
    			bool stopChanging = false;
                On_MaQLChuongTrinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQLChuongTrinh");
    			if(!stopChanging)
    			{
    				_maQLChuongTrinh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQLChuongTrinh");
    				On_MaQLChuongTrinh_Changed(oldValue, _maQLChuongTrinh);//\\
    			}
            }
        }
    	public static String MaQLChuongTrinh_PropertyName { get { return "MaQLChuongTrinh"; } }
        private string _maQLChuongTrinh;
        partial void On_MaQLChuongTrinh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLChuongTrinh_Changed(string oldValue, string currentValue);
    
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
        public Nullable<decimal> SoTienNo
        {
            get
            {
                return _soTienNo;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienNo;
    			bool stopChanging = false;
                On_SoTienNo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienNo");
    			if(!stopChanging)
    			{
    				_soTienNo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienNo");
    				On_SoTienNo_Changed(oldValue, _soTienNo);//\\
    			}
            }
        }
    	public static String SoTienNo_PropertyName { get { return "SoTienNo"; } }
        private Nullable<decimal> _soTienNo;
        partial void On_SoTienNo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienNo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}
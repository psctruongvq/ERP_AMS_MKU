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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="HocSinhFromOtherDB")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class HocSinhFromOtherDB : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public HocSinhFromOtherDB()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new HocSinhFromOtherDB object.
        /// </summary>
        /// <param name="loai">Initial value of the Loai property.</param>
        public static HocSinhFromOtherDB CreateHocSinhFromOtherDB(int loai)
        {
            HocSinhFromOtherDB hocSinhFromOtherDB = new HocSinhFromOtherDB();
            hocSinhFromOtherDB.Loai = loai;
            return hocSinhFromOtherDB;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int Loai
        {
            get
            {
                return _loai;
            }
            set
            {
                if (_loai != value)
                {
        			int oldValue =  _loai;
        			bool stopChanging = false;
                    On_Loai_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("Loai");
        			if(!stopChanging)
        			{
        				_loai = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("Loai");
        				On_Loai_Changed(oldValue, _loai);//\\
        			}
                }
            }
        }
    	public static String Loai_PropertyName { get { return "Loai"; } }
        private int _loai;
        partial void On_Loai_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_Loai_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.Guid> Oid
        {
            get
            {
                return _oid;
            }
            set
            {
    			Nullable<System.Guid> oldValue =  _oid;
    			bool stopChanging = false;
                On_Oid_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Oid");
    			if(!stopChanging)
    			{
    				_oid = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Oid");
    				On_Oid_Changed(oldValue, _oid);//\\
    			}
            }
        }
    	public static String Oid_PropertyName { get { return "Oid"; } }
        private Nullable<System.Guid> _oid;
        partial void On_Oid_Changing(Nullable<System.Guid> currentValue, ref Nullable<System.Guid> newValue, ref bool stopChanging);
        partial void On_Oid_Changed(Nullable<System.Guid> oldValue, Nullable<System.Guid> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaHocSinh
        {
            get
            {
                return _maHocSinh;
            }
            set
            {
    			string oldValue =  _maHocSinh;
    			bool stopChanging = false;
                On_MaHocSinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHocSinh");
    			if(!stopChanging)
    			{
    				_maHocSinh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaHocSinh");
    				On_MaHocSinh_Changed(oldValue, _maHocSinh);//\\
    			}
            }
        }
    	public static String MaHocSinh_PropertyName { get { return "MaHocSinh"; } }
        private string _maHocSinh;
        partial void On_MaHocSinh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaHocSinh_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string HoTen
        {
            get
            {
                return _hoTen;
            }
            set
            {
    			string oldValue =  _hoTen;
    			bool stopChanging = false;
                On_HoTen_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HoTen");
    			if(!stopChanging)
    			{
    				_hoTen = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("HoTen");
    				On_HoTen_Changed(oldValue, _hoTen);//\\
    			}
            }
        }
    	public static String HoTen_PropertyName { get { return "HoTen"; } }
        private string _hoTen;
        partial void On_HoTen_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_HoTen_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.Guid> BoPhan
        {
            get
            {
                return _boPhan;
            }
            set
            {
    			Nullable<System.Guid> oldValue =  _boPhan;
    			bool stopChanging = false;
                On_BoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("BoPhan");
    			if(!stopChanging)
    			{
    				_boPhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("BoPhan");
    				On_BoPhan_Changed(oldValue, _boPhan);//\\
    			}
            }
        }
    	public static String BoPhan_PropertyName { get { return "BoPhan"; } }
        private Nullable<System.Guid> _boPhan;
        partial void On_BoPhan_Changing(Nullable<System.Guid> currentValue, ref Nullable<System.Guid> newValue, ref bool stopChanging);
        partial void On_BoPhan_Changed(Nullable<System.Guid> oldValue, Nullable<System.Guid> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenLop
        {
            get
            {
                return _tenLop;
            }
            set
            {
    			string oldValue =  _tenLop;
    			bool stopChanging = false;
                On_TenLop_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenLop");
    			if(!stopChanging)
    			{
    				_tenLop = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenLop");
    				On_TenLop_Changed(oldValue, _tenLop);//\\
    			}
            }
        }
    	public static String TenLop_PropertyName { get { return "TenLop"; } }
        private string _tenLop;
        partial void On_TenLop_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenLop_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaTruongHocSinh
        {
            get
            {
                return _maTruongHocSinh;
            }
            set
            {
    			string oldValue =  _maTruongHocSinh;
    			bool stopChanging = false;
                On_MaTruongHocSinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTruongHocSinh");
    			if(!stopChanging)
    			{
    				_maTruongHocSinh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaTruongHocSinh");
    				On_MaTruongHocSinh_Changed(oldValue, _maTruongHocSinh);//\\
    			}
            }
        }
    	public static String MaTruongHocSinh_PropertyName { get { return "MaTruongHocSinh"; } }
        private string _maTruongHocSinh;
        partial void On_MaTruongHocSinh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaTruongHocSinh_Changed(string oldValue, string currentValue);

        #endregion

    }
}

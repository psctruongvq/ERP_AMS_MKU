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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="luong_ky2")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class luong_ky2 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public luong_ky2()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new luong_ky2 object.
        /// </summary>
        /// <param name="maQLNhanVien">Initial value of the MaQLNhanVien property.</param>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        public static luong_ky2 Createluong_ky2(string maQLNhanVien, long maNhanVien)
        {
            luong_ky2 luong_ky2 = new luong_ky2();
            luong_ky2.MaQLNhanVien = maQLNhanVien;
            luong_ky2.MaNhanVien = maNhanVien;
            return luong_ky2;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
            set
            {
                if (_maQLNhanVien != value)
                {
        			string oldValue =  _maQLNhanVien;
        			bool stopChanging = false;
                    On_MaQLNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaQLNhanVien");
        			if(!stopChanging)
        			{
        				_maQLNhanVien = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaQLNhanVien");
        				On_MaQLNhanVien_Changed(oldValue, _maQLNhanVien);//\\
        			}
                }
            }
        }
    	public static String MaQLNhanVien_PropertyName { get { return "MaQLNhanVien"; } }
        private string _maQLNhanVien;
        partial void On_MaQLNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string CMND
        {
            get
            {
                return _cMND;
            }
            set
            {
    			string oldValue =  _cMND;
    			bool stopChanging = false;
                On_CMND_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CMND");
    			if(!stopChanging)
    			{
    				_cMND = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("CMND");
    				On_CMND_Changed(oldValue, _cMND);//\\
    			}
            }
        }
    	public static String CMND_PropertyName { get { return "CMND"; } }
        private string _cMND;
        partial void On_CMND_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_CMND_Changed(string oldValue, string currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (_maNhanVien != value)
                {
        			long oldValue =  _maNhanVien;
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
        }
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private long _maNhanVien;
        partial void On_MaNhanVien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TienLuong
        {
            get
            {
                return _tienLuong;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienLuong;
    			bool stopChanging = false;
                On_TienLuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienLuong");
    			if(!stopChanging)
    			{
    				_tienLuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienLuong");
    				On_TienLuong_Changed(oldValue, _tienLuong);//\\
    			}
            }
        }
    	public static String TienLuong_PropertyName { get { return "TienLuong"; } }
        private Nullable<decimal> _tienLuong;
        partial void On_TienLuong_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienLuong_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> LuongThamNien
        {
            get
            {
                return _luongThamNien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _luongThamNien;
    			bool stopChanging = false;
                On_LuongThamNien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LuongThamNien");
    			if(!stopChanging)
    			{
    				_luongThamNien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LuongThamNien");
    				On_LuongThamNien_Changed(oldValue, _luongThamNien);//\\
    			}
            }
        }
    	public static String LuongThamNien_PropertyName { get { return "LuongThamNien"; } }
        private Nullable<decimal> _luongThamNien;
        partial void On_LuongThamNien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LuongThamNien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="DSNhanVienNgoaiDaiSuDung")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DSNhanVienNgoaiDaiSuDung : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public DSNhanVienNgoaiDaiSuDung()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new DSNhanVienNgoaiDaiSuDung object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="tenNhanVien">Initial value of the TenNhanVien property.</param>
        public static DSNhanVienNgoaiDaiSuDung CreateDSNhanVienNgoaiDaiSuDung(long maNhanVien, string tenNhanVien)
        {
            DSNhanVienNgoaiDaiSuDung dSNhanVienNgoaiDaiSuDung = new DSNhanVienNgoaiDaiSuDung();
            dSNhanVienNgoaiDaiSuDung.MaNhanVien = maNhanVien;
            dSNhanVienNgoaiDaiSuDung.TenNhanVien = tenNhanVien;
            return dSNhanVienNgoaiDaiSuDung;
        }

        #endregion

        #region Primitive Properties
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set
            {
                if (_tenNhanVien != value)
                {
        			string oldValue =  _tenNhanVien;
        			bool stopChanging = false;
                    On_TenNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenNhanVien");
        			if(!stopChanging)
        			{
        				_tenNhanVien = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenNhanVien");
        				On_TenNhanVien_Changed(oldValue, _tenNhanVien);//\\
        			}
                }
            }
        }
    	public static String TenNhanVien_PropertyName { get { return "TenNhanVien"; } }
        private string _tenNhanVien;
        partial void On_TenNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVien_Changed(string oldValue, string currentValue);

        #endregion

    }
}

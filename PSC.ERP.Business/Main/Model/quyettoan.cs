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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="quyettoan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class quyettoan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public quyettoan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new quyettoan object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        public static quyettoan Createquyettoan(long maNhanVien)
        {
            quyettoan quyettoan = new quyettoan();
            quyettoan.MaNhanVien = maNhanVien;
            return quyettoan;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueNLDNopThem
        {
            get
            {
                return _thueNLDNopThem;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueNLDNopThem;
    			bool stopChanging = false;
                On_ThueNLDNopThem_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueNLDNopThem");
    			if(!stopChanging)
    			{
    				_thueNLDNopThem = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueNLDNopThem");
    				On_ThueNLDNopThem_Changed(oldValue, _thueNLDNopThem);//\\
    			}
            }
        }
    	public static String ThueNLDNopThem_PropertyName { get { return "ThueNLDNopThem"; } }
        private Nullable<decimal> _thueNLDNopThem;
        partial void On_ThueNLDNopThem_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueNLDNopThem_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

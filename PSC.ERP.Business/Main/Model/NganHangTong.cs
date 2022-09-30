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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="NganHangTong")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class NganHangTong : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public NganHangTong()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new NganHangTong object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        public static NganHangTong CreateNganHangTong(long maNhanVien)
        {
            NganHangTong nganHangTong = new NganHangTong();
            nganHangTong.MaNhanVien = maNhanVien;
            return nganHangTong;
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
        public Nullable<decimal> TienThue
        {
            get
            {
                return _tienThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienThue;
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
    	public static String TienThue_PropertyName { get { return "TienThue"; } }
        private Nullable<decimal> _tienThue;
        partial void On_TienThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongTien
        {
            get
            {
                return _tongTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongTien;
    			bool stopChanging = false;
                On_TongTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongTien");
    			if(!stopChanging)
    			{
    				_tongTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongTien");
    				On_TongTien_Changed(oldValue, _tongTien);//\\
    			}
            }
        }
    	public static String TongTien_PropertyName { get { return "TongTien"; } }
        private Nullable<decimal> _tongTien;
        partial void On_TongTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienConLai
        {
            get
            {
                return _soTienConLai;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienConLai;
    			bool stopChanging = false;
                On_SoTienConLai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienConLai");
    			if(!stopChanging)
    			{
    				_soTienConLai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienConLai");
    				On_SoTienConLai_Changed(oldValue, _soTienConLai);//\\
    			}
            }
        }
    	public static String SoTienConLai_PropertyName { get { return "SoTienConLai"; } }
        private Nullable<decimal> _soTienConLai;
        partial void On_SoTienConLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienConLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

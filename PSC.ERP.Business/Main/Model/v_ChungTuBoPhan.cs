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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ChungTuBoPhan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ChungTuBoPhan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ChungTuBoPhan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ChungTuBoPhan object.
        /// </summary>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        public static v_ChungTuBoPhan Createv_ChungTuBoPhan(long maChungTu, int maBoPhan)
        {
            v_ChungTuBoPhan v_ChungTuBoPhan = new v_ChungTuBoPhan();
            v_ChungTuBoPhan.MaChungTu = maChungTu;
            v_ChungTuBoPhan.MaBoPhan = maBoPhan;
            return v_ChungTuBoPhan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaChungTu
        {
            get
            {
                return _maChungTu;
            }
            set
            {
                if (_maChungTu != value)
                {
        			long oldValue =  _maChungTu;
        			bool stopChanging = false;
                    On_MaChungTu_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChungTu");
        			if(!stopChanging)
        			{
        				_maChungTu = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChungTu");
        				On_MaChungTu_Changed(oldValue, _maChungTu);//\\
        			}
                }
            }
        }
    	public static String MaChungTu_PropertyName { get { return "MaChungTu"; } }
        private long _maChungTu;
        partial void On_MaChungTu_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaChungTu_Changed(long oldValue, long currentValue);
    
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
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (_maBoPhan != value)
                {
        			int oldValue =  _maBoPhan;
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
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private int _maBoPhan;
        partial void On_MaBoPhan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
            set
            {
    			string oldValue =  _tenBoPhan;
    			bool stopChanging = false;
                On_TenBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenBoPhan");
    			if(!stopChanging)
    			{
    				_tenBoPhan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenBoPhan");
    				On_TenBoPhan_Changed(oldValue, _tenBoPhan);//\\
    			}
            }
        }
    	public static String TenBoPhan_PropertyName { get { return "TenBoPhan"; } }
        private string _tenBoPhan;
        partial void On_TenBoPhan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenBoPhan_Changed(string oldValue, string currentValue);

        #endregion

    }
}
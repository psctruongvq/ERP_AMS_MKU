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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="V_ButToanMucNganSach")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class V_ButToanMucNganSach : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public V_ButToanMucNganSach()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new V_ButToanMucNganSach object.
        /// </summary>
        /// <param name="maButToan">Initial value of the MaButToan property.</param>
        public static V_ButToanMucNganSach CreateV_ButToanMucNganSach(int maButToan)
        {
            V_ButToanMucNganSach v_ButToanMucNganSach = new V_ButToanMucNganSach();
            v_ButToanMucNganSach.MaButToan = maButToan;
            return v_ButToanMucNganSach;
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

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ckngay25")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ckngay25 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ckngay25()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ckngay25 object.
        /// </summary>
        /// <param name="maChungTu">Initial value of the MaChungTu property.</param>
        public static v_ckngay25 Createv_ckngay25(long maChungTu)
        {
            v_ckngay25 v_ckngay25 = new v_ckngay25();
            v_ckngay25.MaChungTu = maChungTu;
            return v_ckngay25;
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

        #endregion

    }
}
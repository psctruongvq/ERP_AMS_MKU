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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tamung")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tamung : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tamung()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tamung object.
        /// </summary>
        /// <param name="soChungTu">Initial value of the SoChungTu property.</param>
        public static tamung Createtamung(string soChungTu)
        {
            tamung tamung = new tamung();
            tamung.SoChungTu = soChungTu;
            return tamung;
        }

        #endregion

        #region Primitive Properties
    
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

        #endregion

    }
}

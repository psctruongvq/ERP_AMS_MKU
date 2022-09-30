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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="DienThoai_Fax")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DienThoai_Fax : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public DienThoai_Fax()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new DienThoai_Fax object.
        /// </summary>
        /// <param name="maChiTiet">Initial value of the MaChiTiet property.</param>
        /// <param name="soDTFax">Initial value of the SoDTFax property.</param>
        /// <param name="loai">Initial value of the Loai property.</param>
        public static DienThoai_Fax CreateDienThoai_Fax(int maChiTiet, string soDTFax, bool loai)
        {
            DienThoai_Fax dienThoai_Fax = new DienThoai_Fax();
            dienThoai_Fax.MaChiTiet = maChiTiet;
            dienThoai_Fax.SoDTFax = soDTFax;
            dienThoai_Fax.Loai = loai;
            return dienThoai_Fax;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
            set
            {
                if (_maChiTiet != value)
                {
        			int oldValue =  _maChiTiet;
        			bool stopChanging = false;
                    On_MaChiTiet_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChiTiet");
        			if(!stopChanging)
        			{
        				_maChiTiet = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChiTiet");
        				On_MaChiTiet_Changed(oldValue, _maChiTiet);//\\
        			}
                }
            }
        }
    	public static String MaChiTiet_PropertyName { get { return "MaChiTiet"; } }
        private int _maChiTiet;
        partial void On_MaChiTiet_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChiTiet_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaDoiTac
        {
            get
            {
                return _maDoiTac;
            }
            set
            {
    			Nullable<long> oldValue =  _maDoiTac;
    			bool stopChanging = false;
                On_MaDoiTac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTac");
    			if(!stopChanging)
    			{
    				_maDoiTac = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTac");
    				On_MaDoiTac_Changed(oldValue, _maDoiTac);//\\
    			}
            }
        }
    	public static String MaDoiTac_PropertyName { get { return "MaDoiTac"; } }
        private Nullable<long> _maDoiTac;
        partial void On_MaDoiTac_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaDoiTac_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaDienThoaiFax
        {
            get
            {
                return _maDienThoaiFax;
            }
            set
            {
    			Nullable<int> oldValue =  _maDienThoaiFax;
    			bool stopChanging = false;
                On_MaDienThoaiFax_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDienThoaiFax");
    			if(!stopChanging)
    			{
    				_maDienThoaiFax = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDienThoaiFax");
    				On_MaDienThoaiFax_Changed(oldValue, _maDienThoaiFax);//\\
    			}
            }
        }
    	public static String MaDienThoaiFax_PropertyName { get { return "MaDienThoaiFax"; } }
        private Nullable<int> _maDienThoaiFax;
        partial void On_MaDienThoaiFax_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDienThoaiFax_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SoDTFax
        {
            get
            {
                return _soDTFax;
            }
            set
            {
                if (_soDTFax != value)
                {
        			string oldValue =  _soDTFax;
        			bool stopChanging = false;
                    On_SoDTFax_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("SoDTFax");
        			if(!stopChanging)
        			{
        				_soDTFax = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("SoDTFax");
        				On_SoDTFax_Changed(oldValue, _soDTFax);//\\
        			}
                }
            }
        }
    	public static String SoDTFax_PropertyName { get { return "SoDTFax"; } }
        private string _soDTFax;
        partial void On_SoDTFax_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoDTFax_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public bool Loai
        {
            get
            {
                return _loai;
            }
            set
            {
                if (_loai != value)
                {
        			bool oldValue =  _loai;
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
        private bool _loai;
        partial void On_Loai_Changing(bool currentValue, ref bool newValue, ref bool stopChanging);
        partial void On_Loai_Changed(bool oldValue, bool currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> Active
        {
            get
            {
                return _active;
            }
            set
            {
    			Nullable<bool> oldValue =  _active;
    			bool stopChanging = false;
                On_Active_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Active");
    			if(!stopChanging)
    			{
    				_active = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Active");
    				On_Active_Changed(oldValue, _active);//\\
    			}
            }
        }
    	public static String Active_PropertyName { get { return "Active"; } }
        private Nullable<bool> _active;
        partial void On_Active_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_Active_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);

        #endregion

    }
}

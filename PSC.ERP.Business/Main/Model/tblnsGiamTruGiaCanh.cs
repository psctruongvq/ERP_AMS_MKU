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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsGiamTruGiaCanh")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsGiamTruGiaCanh : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsGiamTruGiaCanh()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsGiamTruGiaCanh object.
        /// </summary>
        /// <param name="maGiaCanh">Initial value of the MaGiaCanh property.</param>
        public static tblnsGiamTruGiaCanh CreatetblnsGiamTruGiaCanh(int maGiaCanh)
        {
            tblnsGiamTruGiaCanh tblnsGiamTruGiaCanh = new tblnsGiamTruGiaCanh();
            tblnsGiamTruGiaCanh.MaGiaCanh = maGiaCanh;
            return tblnsGiamTruGiaCanh;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaGiaCanh
        {
            get
            {
                return _maGiaCanh;
            }
            set
            {
                if (_maGiaCanh != value)
                {
        			int oldValue =  _maGiaCanh;
        			bool stopChanging = false;
                    On_MaGiaCanh_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaGiaCanh");
        			if(!stopChanging)
        			{
        				_maGiaCanh = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaGiaCanh");
        				On_MaGiaCanh_Changed(oldValue, _maGiaCanh);//\\
        			}
                }
            }
        }
    	public static String MaGiaCanh_PropertyName { get { return "MaGiaCanh"; } }
        private int _maGiaCanh;
        partial void On_MaGiaCanh_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaGiaCanh_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaQLGiaCanh
        {
            get
            {
                return _maQLGiaCanh;
            }
            set
            {
    			string oldValue =  _maQLGiaCanh;
    			bool stopChanging = false;
                On_MaQLGiaCanh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQLGiaCanh");
    			if(!stopChanging)
    			{
    				_maQLGiaCanh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQLGiaCanh");
    				On_MaQLGiaCanh_Changed(oldValue, _maQLGiaCanh);//\\
    			}
            }
        }
    	public static String MaQLGiaCanh_PropertyName { get { return "MaQLGiaCanh"; } }
        private string _maQLGiaCanh;
        partial void On_MaQLGiaCanh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLGiaCanh_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenGiaCanh
        {
            get
            {
                return _tenGiaCanh;
            }
            set
            {
    			string oldValue =  _tenGiaCanh;
    			bool stopChanging = false;
                On_TenGiaCanh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenGiaCanh");
    			if(!stopChanging)
    			{
    				_tenGiaCanh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenGiaCanh");
    				On_TenGiaCanh_Changed(oldValue, _tenGiaCanh);//\\
    			}
            }
        }
    	public static String TenGiaCanh_PropertyName { get { return "TenGiaCanh"; } }
        private string _tenGiaCanh;
        partial void On_TenGiaCanh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenGiaCanh_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoTienGiamTru
        {
            get
            {
                return _soTienGiamTru;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTienGiamTru;
    			bool stopChanging = false;
                On_SoTienGiamTru_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTienGiamTru");
    			if(!stopChanging)
    			{
    				_soTienGiamTru = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTienGiamTru");
    				On_SoTienGiamTru_Changed(oldValue, _soTienGiamTru);//\\
    			}
            }
        }
    	public static String SoTienGiamTru_PropertyName { get { return "SoTienGiamTru"; } }
        private Nullable<decimal> _soTienGiamTru;
        partial void On_SoTienGiamTru_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTienGiamTru_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
    			string oldValue =  _ghiChu;
    			bool stopChanging = false;
                On_GhiChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChu");
    			if(!stopChanging)
    			{
    				_ghiChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChu");
    				On_GhiChu_Changed(oldValue, _ghiChu);//\\
    			}
            }
        }
    	public static String GhiChu_PropertyName { get { return "GhiChu"; } }
        private string _ghiChu;
        partial void On_GhiChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChu_Changed(string oldValue, string currentValue);

        #endregion

    }
}

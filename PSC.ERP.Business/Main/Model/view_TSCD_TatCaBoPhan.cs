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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="view_TSCD_TatCaBoPhan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class view_TSCD_TatCaBoPhan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public view_TSCD_TatCaBoPhan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new view_TSCD_TatCaBoPhan object.
        /// </summary>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        public static view_TSCD_TatCaBoPhan Createview_TSCD_TatCaBoPhan(int maBoPhan)
        {
            view_TSCD_TatCaBoPhan view_TSCD_TatCaBoPhan = new view_TSCD_TatCaBoPhan();
            view_TSCD_TatCaBoPhan.MaBoPhan = maBoPhan;
            return view_TSCD_TatCaBoPhan;
        }

        #endregion

        #region Primitive Properties
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
            set
            {
    			string oldValue =  _maBoPhanQL;
    			bool stopChanging = false;
                On_MaBoPhanQL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanQL");
    			if(!stopChanging)
    			{
    				_maBoPhanQL = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaBoPhanQL");
    				On_MaBoPhanQL_Changed(oldValue, _maBoPhanQL);//\\
    			}
            }
        }
    	public static String MaBoPhanQL_PropertyName { get { return "MaBoPhanQL"; } }
        private string _maBoPhanQL;
        partial void On_MaBoPhanQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaBoPhanQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> KhauHaoHaoMon
        {
            get
            {
                return _khauHaoHaoMon;
            }
            set
            {
    			Nullable<bool> oldValue =  _khauHaoHaoMon;
    			bool stopChanging = false;
                On_KhauHaoHaoMon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("KhauHaoHaoMon");
    			if(!stopChanging)
    			{
    				_khauHaoHaoMon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("KhauHaoHaoMon");
    				On_KhauHaoHaoMon_Changed(oldValue, _khauHaoHaoMon);//\\
    			}
            }
        }
    	public static String KhauHaoHaoMon_PropertyName { get { return "KhauHaoHaoMon"; } }
        private Nullable<bool> _khauHaoHaoMon;
        partial void On_KhauHaoHaoMon_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_KhauHaoHaoMon_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhanCha
        {
            get
            {
                return _maBoPhanCha;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhanCha;
    			bool stopChanging = false;
                On_MaBoPhanCha_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhanCha");
    			if(!stopChanging)
    			{
    				_maBoPhanCha = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhanCha");
    				On_MaBoPhanCha_Changed(oldValue, _maBoPhanCha);//\\
    			}
            }
        }
    	public static String MaBoPhanCha_PropertyName { get { return "MaBoPhanCha"; } }
        private Nullable<int> _maBoPhanCha;
        partial void On_MaBoPhanCha_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhanCha_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> LaBoPhanMoRong
        {
            get
            {
                return _laBoPhanMoRong;
            }
            set
            {
    			Nullable<bool> oldValue =  _laBoPhanMoRong;
    			bool stopChanging = false;
                On_LaBoPhanMoRong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LaBoPhanMoRong");
    			if(!stopChanging)
    			{
    				_laBoPhanMoRong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LaBoPhanMoRong");
    				On_LaBoPhanMoRong_Changed(oldValue, _laBoPhanMoRong);//\\
    			}
            }
        }
    	public static String LaBoPhanMoRong_PropertyName { get { return "LaBoPhanMoRong"; } }
        private Nullable<bool> _laBoPhanMoRong;
        partial void On_LaBoPhanMoRong_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_LaBoPhanMoRong_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);

        #endregion

    }
}
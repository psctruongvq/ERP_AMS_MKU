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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="V_DanhSachChuongTrinhPhanCap")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class V_DanhSachChuongTrinhPhanCap : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public V_DanhSachChuongTrinhPhanCap()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new V_DanhSachChuongTrinhPhanCap object.
        /// </summary>
        /// <param name="maChuongTrinh">Initial value of the MaChuongTrinh property.</param>
        public static V_DanhSachChuongTrinhPhanCap CreateV_DanhSachChuongTrinhPhanCap(int maChuongTrinh)
        {
            V_DanhSachChuongTrinhPhanCap v_DanhSachChuongTrinhPhanCap = new V_DanhSachChuongTrinhPhanCap();
            v_DanhSachChuongTrinhPhanCap.MaChuongTrinh = maChuongTrinh;
            return v_DanhSachChuongTrinhPhanCap;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChuongTrinh
        {
            get
            {
                return _maChuongTrinh;
            }
            set
            {
                if (_maChuongTrinh != value)
                {
        			int oldValue =  _maChuongTrinh;
        			bool stopChanging = false;
                    On_MaChuongTrinh_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChuongTrinh");
        			if(!stopChanging)
        			{
        				_maChuongTrinh = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChuongTrinh");
        				On_MaChuongTrinh_Changed(oldValue, _maChuongTrinh);//\\
        			}
                }
            }
        }
    	public static String MaChuongTrinh_PropertyName { get { return "MaChuongTrinh"; } }
        private int _maChuongTrinh;
        partial void On_MaChuongTrinh_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChuongTrinh_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Cap4
        {
            get
            {
                return _cap4;
            }
            set
            {
    			string oldValue =  _cap4;
    			bool stopChanging = false;
                On_Cap4_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Cap4");
    			if(!stopChanging)
    			{
    				_cap4 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Cap4");
    				On_Cap4_Changed(oldValue, _cap4);//\\
    			}
            }
        }
    	public static String Cap4_PropertyName { get { return "Cap4"; } }
        private string _cap4;
        partial void On_Cap4_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Cap4_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Cap3
        {
            get
            {
                return _cap3;
            }
            set
            {
    			string oldValue =  _cap3;
    			bool stopChanging = false;
                On_Cap3_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Cap3");
    			if(!stopChanging)
    			{
    				_cap3 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Cap3");
    				On_Cap3_Changed(oldValue, _cap3);//\\
    			}
            }
        }
    	public static String Cap3_PropertyName { get { return "Cap3"; } }
        private string _cap3;
        partial void On_Cap3_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Cap3_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Cap2
        {
            get
            {
                return _cap2;
            }
            set
            {
    			string oldValue =  _cap2;
    			bool stopChanging = false;
                On_Cap2_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Cap2");
    			if(!stopChanging)
    			{
    				_cap2 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Cap2");
    				On_Cap2_Changed(oldValue, _cap2);//\\
    			}
            }
        }
    	public static String Cap2_PropertyName { get { return "Cap2"; } }
        private string _cap2;
        partial void On_Cap2_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Cap2_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Cap1
        {
            get
            {
                return _cap1;
            }
            set
            {
    			string oldValue =  _cap1;
    			bool stopChanging = false;
                On_Cap1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Cap1");
    			if(!stopChanging)
    			{
    				_cap1 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Cap1");
    				On_Cap1_Changed(oldValue, _cap1);//\\
    			}
            }
        }
    	public static String Cap1_PropertyName { get { return "Cap1"; } }
        private string _cap1;
        partial void On_Cap1_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Cap1_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChuongTrinhCha
        {
            get
            {
                return _maChuongTrinhCha;
            }
            set
            {
    			Nullable<int> oldValue =  _maChuongTrinhCha;
    			bool stopChanging = false;
                On_MaChuongTrinhCha_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChuongTrinhCha");
    			if(!stopChanging)
    			{
    				_maChuongTrinhCha = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChuongTrinhCha");
    				On_MaChuongTrinhCha_Changed(oldValue, _maChuongTrinhCha);//\\
    			}
            }
        }
    	public static String MaChuongTrinhCha_PropertyName { get { return "MaChuongTrinhCha"; } }
        private Nullable<int> _maChuongTrinhCha;
        partial void On_MaChuongTrinhCha_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChuongTrinhCha_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhanCap
        {
            get
            {
                return _maPhanCap;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhanCap;
    			bool stopChanging = false;
                On_MaPhanCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhanCap");
    			if(!stopChanging)
    			{
    				_maPhanCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhanCap");
    				On_MaPhanCap_Changed(oldValue, _maPhanCap);//\\
    			}
            }
        }
    	public static String MaPhanCap_PropertyName { get { return "MaPhanCap"; } }
        private Nullable<int> _maPhanCap;
        partial void On_MaPhanCap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhanCap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
    			Nullable<int> oldValue =  _maCongTy;
    			bool stopChanging = false;
                On_MaCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaCongTy");
    			if(!stopChanging)
    			{
    				_maCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaCongTy");
    				On_MaCongTy_Changed(oldValue, _maCongTy);//\\
    			}
            }
        }
    	public static String MaCongTy_PropertyName { get { return "MaCongTy"; } }
        private Nullable<int> _maCongTy;
        partial void On_MaCongTy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaCongTy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

    }
}

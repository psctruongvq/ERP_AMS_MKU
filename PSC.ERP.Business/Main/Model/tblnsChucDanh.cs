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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsChucDanh")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsChucDanh : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsChucDanh()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsChucDanh object.
        /// </summary>
        /// <param name="maChucDanh">Initial value of the MaChucDanh property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        public static tblnsChucDanh CreatetblnsChucDanh(int maChucDanh, string maQuanLy)
        {
            tblnsChucDanh tblnsChucDanh = new tblnsChucDanh();
            tblnsChucDanh.MaChucDanh = maChucDanh;
            tblnsChucDanh.MaQuanLy = maQuanLy;
            return tblnsChucDanh;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChucDanh
        {
            get
            {
                return _maChucDanh;
            }
            set
            {
                if (_maChucDanh != value)
                {
        			int oldValue =  _maChucDanh;
        			bool stopChanging = false;
                    On_MaChucDanh_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChucDanh");
        			if(!stopChanging)
        			{
        				_maChucDanh = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChucDanh");
        				On_MaChucDanh_Changed(oldValue, _maChucDanh);//\\
        			}
                }
            }
        }
    	public static String MaChucDanh_PropertyName { get { return "MaChucDanh"; } }
        private int _maChucDanh;
        partial void On_MaChucDanh_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChucDanh_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
    			string oldValue =  _maQuanLy;
    			bool stopChanging = false;
                On_MaQuanLy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuanLy");
    			if(!stopChanging)
    			{
    				_maQuanLy = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("MaQuanLy");
    				On_MaQuanLy_Changed(oldValue, _maQuanLy);//\\
    			}
            }
        }
    	public static String MaQuanLy_PropertyName { get { return "MaQuanLy"; } }
        private string _maQuanLy;
        partial void On_MaQuanLy_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQuanLy_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenChucDanh
        {
            get
            {
                return _tenChucDanh;
            }
            set
            {
    			string oldValue =  _tenChucDanh;
    			bool stopChanging = false;
                On_TenChucDanh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenChucDanh");
    			if(!stopChanging)
    			{
    				_tenChucDanh = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenChucDanh");
    				On_TenChucDanh_Changed(oldValue, _tenChucDanh);//\\
    			}
            }
        }
    	public static String TenChucDanh_PropertyName { get { return "TenChucDanh"; } }
        private string _tenChucDanh;
        partial void On_TenChucDanh_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenChucDanh_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNhomChucDanh
        {
            get
            {
                return _maNhomChucDanh;
            }
            set
            {
    			Nullable<int> oldValue =  _maNhomChucDanh;
    			bool stopChanging = false;
                On_MaNhomChucDanh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNhomChucDanh");
    			if(!stopChanging)
    			{
    				_maNhomChucDanh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNhomChucDanh");
    				On_MaNhomChucDanh_Changed(oldValue, _maNhomChucDanh);//\\
    			}
            }
        }
    	public static String MaNhomChucDanh_PropertyName { get { return "MaNhomChucDanh"; } }
        private Nullable<int> _maNhomChucDanh;
        partial void On_MaNhomChucDanh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNhomChucDanh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChucVu
        {
            get
            {
                return _maChucVu;
            }
            set
            {
    			Nullable<int> oldValue =  _maChucVu;
    			bool stopChanging = false;
                On_MaChucVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChucVu");
    			if(!stopChanging)
    			{
    				_maChucVu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChucVu");
    				On_MaChucVu_Changed(oldValue, _maChucVu);//\\
    			}
            }
        }
    	public static String MaChucVu_PropertyName { get { return "MaChucVu"; } }
        private Nullable<int> _maChucVu;
        partial void On_MaChucVu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChucVu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenViettat
        {
            get
            {
                return _tenViettat;
            }
            set
            {
    			string oldValue =  _tenViettat;
    			bool stopChanging = false;
                On_TenViettat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenViettat");
    			if(!stopChanging)
    			{
    				_tenViettat = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenViettat");
    				On_TenViettat_Changed(oldValue, _tenViettat);//\\
    			}
            }
        }
    	public static String TenViettat_PropertyName { get { return "TenViettat"; } }
        private string _tenViettat;
        partial void On_TenViettat_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenViettat_Changed(string oldValue, string currentValue);
    
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

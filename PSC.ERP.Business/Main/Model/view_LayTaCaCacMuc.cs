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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="view_LayTaCaCacMuc")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class view_LayTaCaCacMuc : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public view_LayTaCaCacMuc()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new view_LayTaCaCacMuc object.
        /// </summary>
        /// <param name="maMucNganSach">Initial value of the MaMucNganSach property.</param>
        /// <param name="maMucNganSachQL">Initial value of the MaMucNganSachQL property.</param>
        /// <param name="tenMucNganSach">Initial value of the TenMucNganSach property.</param>
        /// <param name="maTieuMuc">Initial value of the MaTieuMuc property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        public static view_LayTaCaCacMuc Createview_LayTaCaCacMuc(int maMucNganSach, string maMucNganSachQL, string tenMucNganSach, int maTieuMuc, string maQuanLy)
        {
            view_LayTaCaCacMuc view_LayTaCaCacMuc = new view_LayTaCaCacMuc();
            view_LayTaCaCacMuc.MaMucNganSach = maMucNganSach;
            view_LayTaCaCacMuc.MaMucNganSachQL = maMucNganSachQL;
            view_LayTaCaCacMuc.TenMucNganSach = tenMucNganSach;
            view_LayTaCaCacMuc.MaTieuMuc = maTieuMuc;
            view_LayTaCaCacMuc.MaQuanLy = maQuanLy;
            return view_LayTaCaCacMuc;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaMucNganSach
        {
            get
            {
                return _maMucNganSach;
            }
            set
            {
                if (_maMucNganSach != value)
                {
        			int oldValue =  _maMucNganSach;
        			bool stopChanging = false;
                    On_MaMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaMucNganSach");
        			if(!stopChanging)
        			{
        				_maMucNganSach = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaMucNganSach");
        				On_MaMucNganSach_Changed(oldValue, _maMucNganSach);//\\
        			}
                }
            }
        }
    	public static String MaMucNganSach_PropertyName { get { return "MaMucNganSach"; } }
        private int _maMucNganSach;
        partial void On_MaMucNganSach_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaMucNganSach_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaMucNganSachQL
        {
            get
            {
                return _maMucNganSachQL;
            }
            set
            {
                if (_maMucNganSachQL != value)
                {
        			string oldValue =  _maMucNganSachQL;
        			bool stopChanging = false;
                    On_MaMucNganSachQL_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaMucNganSachQL");
        			if(!stopChanging)
        			{
        				_maMucNganSachQL = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaMucNganSachQL");
        				On_MaMucNganSachQL_Changed(oldValue, _maMucNganSachQL);//\\
        			}
                }
            }
        }
    	public static String MaMucNganSachQL_PropertyName { get { return "MaMucNganSachQL"; } }
        private string _maMucNganSachQL;
        partial void On_MaMucNganSachQL_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaMucNganSachQL_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenMucNganSach
        {
            get
            {
                return _tenMucNganSach;
            }
            set
            {
                if (_tenMucNganSach != value)
                {
        			string oldValue =  _tenMucNganSach;
        			bool stopChanging = false;
                    On_TenMucNganSach_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenMucNganSach");
        			if(!stopChanging)
        			{
        				_tenMucNganSach = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenMucNganSach");
        				On_TenMucNganSach_Changed(oldValue, _tenMucNganSach);//\\
        			}
                }
            }
        }
    	public static String TenMucNganSach_PropertyName { get { return "TenMucNganSach"; } }
        private string _tenMucNganSach;
        partial void On_TenMucNganSach_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenMucNganSach_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTieuMuc
        {
            get
            {
                return _maTieuMuc;
            }
            set
            {
                if (_maTieuMuc != value)
                {
        			int oldValue =  _maTieuMuc;
        			bool stopChanging = false;
                    On_MaTieuMuc_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTieuMuc");
        			if(!stopChanging)
        			{
        				_maTieuMuc = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTieuMuc");
        				On_MaTieuMuc_Changed(oldValue, _maTieuMuc);//\\
        			}
                }
            }
        }
    	public static String MaTieuMuc_PropertyName { get { return "MaTieuMuc"; } }
        private int _maTieuMuc;
        partial void On_MaTieuMuc_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTieuMuc_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string MaQuanLy
        {
            get
            {
                return _maQuanLy;
            }
            set
            {
                if (_maQuanLy != value)
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
        public string TenTieuMuc
        {
            get
            {
                return _tenTieuMuc;
            }
            set
            {
    			string oldValue =  _tenTieuMuc;
    			bool stopChanging = false;
                On_TenTieuMuc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTieuMuc");
    			if(!stopChanging)
    			{
    				_tenTieuMuc = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTieuMuc");
    				On_TenTieuMuc_Changed(oldValue, _tenTieuMuc);//\\
    			}
            }
        }
    	public static String TenTieuMuc_PropertyName { get { return "TenTieuMuc"; } }
        private string _tenTieuMuc;
        partial void On_TenTieuMuc_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTieuMuc_Changed(string oldValue, string currentValue);

        #endregion

    }
}
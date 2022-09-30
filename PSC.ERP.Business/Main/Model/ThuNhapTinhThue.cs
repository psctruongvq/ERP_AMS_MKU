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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="ThuNhapTinhThue")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ThuNhapTinhThue : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public ThuNhapTinhThue()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new ThuNhapTinhThue object.
        /// </summary>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        public static ThuNhapTinhThue CreateThuNhapTinhThue(int maBoPhan)
        {
            ThuNhapTinhThue thuNhapTinhThue = new ThuNhapTinhThue();
            thuNhapTinhThue.MaBoPhan = maBoPhan;
            return thuNhapTinhThue;
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
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
            set
            {
    			string oldValue =  _tenNhanVien;
    			bool stopChanging = false;
                On_TenNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhanVien");
    			if(!stopChanging)
    			{
    				_tenNhanVien = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNhanVien");
    				On_TenNhanVien_Changed(oldValue, _tenNhanVien);//\\
    			}
            }
        }
    	public static String TenNhanVien_PropertyName { get { return "TenNhanVien"; } }
        private string _tenNhanVien;
        partial void On_TenNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThuNhap;
    			bool stopChanging = false;
                On_TongThuNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThuNhap");
    			if(!stopChanging)
    			{
    				_tongThuNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThuNhap");
    				On_TongThuNhap_Changed(oldValue, _tongThuNhap);//\\
    			}
            }
        }
    	public static String TongThuNhap_PropertyName { get { return "TongThuNhap"; } }
        private Nullable<decimal> _tongThuNhap;
        partial void On_TongThuNhap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThuNhap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongThuNhapTinhThue
        {
            get
            {
                return _tongThuNhapTinhThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThuNhapTinhThue;
    			bool stopChanging = false;
                On_TongThuNhapTinhThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThuNhapTinhThue");
    			if(!stopChanging)
    			{
    				_tongThuNhapTinhThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThuNhapTinhThue");
    				On_TongThuNhapTinhThue_Changed(oldValue, _tongThuNhapTinhThue);//\\
    			}
            }
        }
    	public static String TongThuNhapTinhThue_PropertyName { get { return "TongThuNhapTinhThue"; } }
        private Nullable<decimal> _tongThuNhapTinhThue;
        partial void On_TongThuNhapTinhThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThuNhapTinhThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueTNCN
        {
            get
            {
                return _thueTNCN;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueTNCN;
    			bool stopChanging = false;
                On_ThueTNCN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueTNCN");
    			if(!stopChanging)
    			{
    				_thueTNCN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueTNCN");
    				On_ThueTNCN_Changed(oldValue, _thueTNCN);//\\
    			}
            }
        }
    	public static String ThueTNCN_PropertyName { get { return "ThueTNCN"; } }
        private Nullable<decimal> _thueTNCN;
        partial void On_ThueTNCN_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueTNCN_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoNguoiPhuThuoc
        {
            get
            {
                return _soNguoiPhuThuoc;
            }
            set
            {
    			Nullable<int> oldValue =  _soNguoiPhuThuoc;
    			bool stopChanging = false;
                On_SoNguoiPhuThuoc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoNguoiPhuThuoc");
    			if(!stopChanging)
    			{
    				_soNguoiPhuThuoc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoNguoiPhuThuoc");
    				On_SoNguoiPhuThuoc_Changed(oldValue, _soNguoiPhuThuoc);//\\
    			}
            }
        }
    	public static String SoNguoiPhuThuoc_PropertyName { get { return "SoNguoiPhuThuoc"; } }
        private Nullable<int> _soNguoiPhuThuoc;
        partial void On_SoNguoiPhuThuoc_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoNguoiPhuThuoc_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThuNhapTinhThue1
        {
            get
            {
                return _thuNhapTinhThue1;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thuNhapTinhThue1;
    			bool stopChanging = false;
                On_ThuNhapTinhThue1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThuNhapTinhThue1");
    			if(!stopChanging)
    			{
    				_thuNhapTinhThue1 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThuNhapTinhThue1");
    				On_ThuNhapTinhThue1_Changed(oldValue, _thuNhapTinhThue1);//\\
    			}
            }
        }
    	public static String ThuNhapTinhThue1_PropertyName { get { return "ThuNhapTinhThue1"; } }
        private Nullable<decimal> _thuNhapTinhThue1;
        partial void On_ThuNhapTinhThue1_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThuNhapTinhThue1_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

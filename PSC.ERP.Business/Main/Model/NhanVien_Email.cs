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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="NhanVien_Email")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class NhanVien_Email : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public NhanVien_Email()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new NhanVien_Email object.
        /// </summary>
        /// <param name="maChiTiet">Initial value of the MaChiTiet property.</param>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="maDiaChiWebsite">Initial value of the MaDiaChiWebsite property.</param>
        public static NhanVien_Email CreateNhanVien_Email(int maChiTiet, long maNhanVien, int maDiaChiWebsite)
        {
            NhanVien_Email nhanVien_Email = new NhanVien_Email();
            nhanVien_Email.MaChiTiet = maChiTiet;
            nhanVien_Email.MaNhanVien = maNhanVien;
            nhanVien_Email.MaDiaChiWebsite = maDiaChiWebsite;
            return nhanVien_Email;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (_maNhanVien != value)
                {
        			long oldValue =  _maNhanVien;
        			bool stopChanging = false;
                    On_MaNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNhanVien");
        			if(!stopChanging)
        			{
        				_maNhanVien = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNhanVien");
        				On_MaNhanVien_Changed(oldValue, _maNhanVien);//\\
        			}
                }
            }
        }
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private long _maNhanVien;
        partial void On_MaNhanVien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaDiaChiWebsite
        {
            get
            {
                return _maDiaChiWebsite;
            }
            set
            {
                if (_maDiaChiWebsite != value)
                {
        			int oldValue =  _maDiaChiWebsite;
        			bool stopChanging = false;
                    On_MaDiaChiWebsite_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaDiaChiWebsite");
        			if(!stopChanging)
        			{
        				_maDiaChiWebsite = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaDiaChiWebsite");
        				On_MaDiaChiWebsite_Changed(oldValue, _maDiaChiWebsite);//\\
        			}
                }
            }
        }
    	public static String MaDiaChiWebsite_PropertyName { get { return "MaDiaChiWebsite"; } }
        private int _maDiaChiWebsite;
        partial void On_MaDiaChiWebsite_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaDiaChiWebsite_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
    			string oldValue =  _diaChi;
    			bool stopChanging = false;
                On_DiaChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DiaChi");
    			if(!stopChanging)
    			{
    				_diaChi = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DiaChi");
    				On_DiaChi_Changed(oldValue, _diaChi);//\\
    			}
            }
        }
    	public static String DiaChi_PropertyName { get { return "DiaChi"; } }
        private string _diaChi;
        partial void On_DiaChi_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DiaChi_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> Loai
        {
            get
            {
                return _loai;
            }
            set
            {
    			Nullable<bool> oldValue =  _loai;
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
    	public static String Loai_PropertyName { get { return "Loai"; } }
        private Nullable<bool> _loai;
        partial void On_Loai_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_Loai_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblChiThuLao_NhanVien")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblChiThuLao_NhanVien : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblChiThuLao_NhanVien()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblChiThuLao_NhanVien object.
        /// </summary>
        /// <param name="maThuLao_NhanVien">Initial value of the MaThuLao_NhanVien property.</param>
        /// <param name="loaiNhanVien">Initial value of the LoaiNhanVien property.</param>
        public static tblChiThuLao_NhanVien CreatetblChiThuLao_NhanVien(long maThuLao_NhanVien, byte loaiNhanVien)
        {
            tblChiThuLao_NhanVien tblChiThuLao_NhanVien = new tblChiThuLao_NhanVien();
            tblChiThuLao_NhanVien.MaThuLao_NhanVien = maThuLao_NhanVien;
            tblChiThuLao_NhanVien.LoaiNhanVien = loaiNhanVien;
            return tblChiThuLao_NhanVien;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaThuLao_NhanVien
        {
            get
            {
                return _maThuLao_NhanVien;
            }
            set
            {
                if (_maThuLao_NhanVien != value)
                {
        			long oldValue =  _maThuLao_NhanVien;
        			bool stopChanging = false;
                    On_MaThuLao_NhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaThuLao_NhanVien");
        			if(!stopChanging)
        			{
        				_maThuLao_NhanVien = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaThuLao_NhanVien");
        				On_MaThuLao_NhanVien_Changed(oldValue, _maThuLao_NhanVien);//\\
        			}
                }
            }
        }
    	public static String MaThuLao_NhanVien_PropertyName { get { return "MaThuLao_NhanVien"; } }
        private long _maThuLao_NhanVien;
        partial void On_MaThuLao_NhanVien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaThuLao_NhanVien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaChiThuLao
        {
            get
            {
                return _maChiThuLao;
            }
            set
            {
    			Nullable<long> oldValue =  _maChiThuLao;
    			bool stopChanging = false;
                On_MaChiThuLao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChiThuLao");
    			if(!stopChanging)
    			{
    				_maChiThuLao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChiThuLao");
    				On_MaChiThuLao_Changed(oldValue, _maChiThuLao);//\\
    			}
            }
        }
    	public static String MaChiThuLao_PropertyName { get { return "MaChiThuLao"; } }
        private Nullable<long> _maChiThuLao;
        partial void On_MaChiThuLao_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaChiThuLao_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
    			Nullable<int> oldValue =  _maNhanVien;
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
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private Nullable<int> _maNhanVien;
        partial void On_MaNhanVien_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaBoPhan_NV
        {
            get
            {
                return _maBoPhan_NV;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhan_NV;
    			bool stopChanging = false;
                On_MaBoPhan_NV_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhan_NV");
    			if(!stopChanging)
    			{
    				_maBoPhan_NV = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhan_NV");
    				On_MaBoPhan_NV_Changed(oldValue, _maBoPhan_NV);//\\
    			}
            }
        }
    	public static String MaBoPhan_NV_PropertyName { get { return "MaBoPhan_NV"; } }
        private Nullable<int> _maBoPhan_NV;
        partial void On_MaBoPhan_NV_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhan_NV_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        public Nullable<decimal> SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soTien;
    			bool stopChanging = false;
                On_SoTien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoTien");
    			if(!stopChanging)
    			{
    				_soTien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoTien");
    				On_SoTien_Changed(oldValue, _soTien);//\\
    			}
            }
        }
    	public static String SoTien_PropertyName { get { return "SoTien"; } }
        private Nullable<decimal> _soTien;
        partial void On_SoTien_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoTien_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public byte LoaiNhanVien
        {
            get
            {
                return _loaiNhanVien;
            }
            set
            {
    			byte oldValue =  _loaiNhanVien;
    			bool stopChanging = false;
                On_LoaiNhanVien_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiNhanVien");
    			if(!stopChanging)
    			{
    				_loaiNhanVien = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiNhanVien");
    				On_LoaiNhanVien_Changed(oldValue, _loaiNhanVien);//\\
    			}
            }
        }
    	public static String LoaiNhanVien_PropertyName { get { return "LoaiNhanVien"; } }
        private byte _loaiNhanVien;
        partial void On_LoaiNhanVien_Changing(byte currentValue, ref byte newValue, ref bool stopChanging);
        partial void On_LoaiNhanVien_Changed(byte oldValue, byte currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblcnChiThuLao")]
        public tblcnChiThuLao tblcnChiThuLao
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnChiThuLao>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblcnChiThuLao").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblcnChiThuLao_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnChiThuLao>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblcnChiThuLao").Value = value;
    				On_tblcnChiThuLao_Changed(this.tblcnChiThuLao);//\\//
    			}
    	    }
        }
    	public static String tblcnChiThuLao_ReferencePropertyName { get { return "tblcnChiThuLao"; } }
    	partial void On_tblcnChiThuLao_Changing(ref tblcnChiThuLao newValue, ref bool stopChanging);
    	partial void On_tblcnChiThuLao_Changed(tblcnChiThuLao currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblcnChiThuLao> tblcnChiThuLaoReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblcnChiThuLao>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblcnChiThuLao");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblcnChiThuLao>("PSC_ERPModel.FK_tblThuLao_NhanVien_tblcnChiThuLao", "tblcnChiThuLao", value);
                }
            }
        }

        #endregion

    }
}

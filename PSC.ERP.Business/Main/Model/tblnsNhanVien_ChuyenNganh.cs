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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsNhanVien_ChuyenNganh")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsNhanVien_ChuyenNganh : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsNhanVien_ChuyenNganh()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsNhanVien_ChuyenNganh object.
        /// </summary>
        /// <param name="maNhanVien_ChuyenNganh">Initial value of the MaNhanVien_ChuyenNganh property.</param>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        public static tblnsNhanVien_ChuyenNganh CreatetblnsNhanVien_ChuyenNganh(int maNhanVien_ChuyenNganh, long maNhanVien)
        {
            tblnsNhanVien_ChuyenNganh tblnsNhanVien_ChuyenNganh = new tblnsNhanVien_ChuyenNganh();
            tblnsNhanVien_ChuyenNganh.MaNhanVien_ChuyenNganh = maNhanVien_ChuyenNganh;
            tblnsNhanVien_ChuyenNganh.MaNhanVien = maNhanVien;
            return tblnsNhanVien_ChuyenNganh;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNhanVien_ChuyenNganh
        {
            get
            {
                return _maNhanVien_ChuyenNganh;
            }
            set
            {
                if (_maNhanVien_ChuyenNganh != value)
                {
        			int oldValue =  _maNhanVien_ChuyenNganh;
        			bool stopChanging = false;
                    On_MaNhanVien_ChuyenNganh_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNhanVien_ChuyenNganh");
        			if(!stopChanging)
        			{
        				_maNhanVien_ChuyenNganh = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNhanVien_ChuyenNganh");
        				On_MaNhanVien_ChuyenNganh_Changed(oldValue, _maNhanVien_ChuyenNganh);//\\
        			}
                }
            }
        }
    	public static String MaNhanVien_ChuyenNganh_PropertyName { get { return "MaNhanVien_ChuyenNganh"; } }
        private int _maNhanVien_ChuyenNganh;
        partial void On_MaNhanVien_ChuyenNganh_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNhanVien_ChuyenNganh_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
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
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private long _maNhanVien;
        partial void On_MaNhanVien_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoChuyenNganh
        {
            get
            {
                return _maTrinhDoChuyenNganh;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoChuyenNganh;
    			bool stopChanging = false;
                On_MaTrinhDoChuyenNganh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoChuyenNganh");
    			if(!stopChanging)
    			{
    				_maTrinhDoChuyenNganh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoChuyenNganh");
    				On_MaTrinhDoChuyenNganh_Changed(oldValue, _maTrinhDoChuyenNganh);//\\
    			}
            }
        }
    	public static String MaTrinhDoChuyenNganh_PropertyName { get { return "MaTrinhDoChuyenNganh"; } }
        private Nullable<int> _maTrinhDoChuyenNganh;
        partial void On_MaTrinhDoChuyenNganh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoChuyenNganh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> ChuyenNganhChinh
        {
            get
            {
                return _chuyenNganhChinh;
            }
            set
            {
    			Nullable<bool> oldValue =  _chuyenNganhChinh;
    			bool stopChanging = false;
                On_ChuyenNganhChinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ChuyenNganhChinh");
    			if(!stopChanging)
    			{
    				_chuyenNganhChinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ChuyenNganhChinh");
    				On_ChuyenNganhChinh_Changed(oldValue, _chuyenNganhChinh);//\\
    			}
            }
        }
    	public static String ChuyenNganhChinh_PropertyName { get { return "ChuyenNganhChinh"; } }
        private Nullable<bool> _chuyenNganhChinh;
        partial void On_ChuyenNganhChinh_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_ChuyenNganhChinh_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTruongDaoTao
        {
            get
            {
                return _maTruongDaoTao;
            }
            set
            {
    			Nullable<int> oldValue =  _maTruongDaoTao;
    			bool stopChanging = false;
                On_MaTruongDaoTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTruongDaoTao");
    			if(!stopChanging)
    			{
    				_maTruongDaoTao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTruongDaoTao");
    				On_MaTruongDaoTao_Changed(oldValue, _maTruongDaoTao);//\\
    			}
            }
        }
    	public static String MaTruongDaoTao_PropertyName { get { return "MaTruongDaoTao"; } }
        private Nullable<int> _maTruongDaoTao;
        partial void On_MaTruongDaoTao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTruongDaoTao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaHinhThucDaoTao
        {
            get
            {
                return _maHinhThucDaoTao;
            }
            set
            {
    			Nullable<int> oldValue =  _maHinhThucDaoTao;
    			bool stopChanging = false;
                On_MaHinhThucDaoTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHinhThucDaoTao");
    			if(!stopChanging)
    			{
    				_maHinhThucDaoTao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHinhThucDaoTao");
    				On_MaHinhThucDaoTao_Changed(oldValue, _maHinhThucDaoTao);//\\
    			}
            }
        }
    	public static String MaHinhThucDaoTao_PropertyName { get { return "MaHinhThucDaoTao"; } }
        private Nullable<int> _maHinhThucDaoTao;
        partial void On_MaHinhThucDaoTao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaHinhThucDaoTao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaQuaTrinhDaoTao
        {
            get
            {
                return _maQuaTrinhDaoTao;
            }
            set
            {
    			Nullable<int> oldValue =  _maQuaTrinhDaoTao;
    			bool stopChanging = false;
                On_MaQuaTrinhDaoTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuaTrinhDaoTao");
    			if(!stopChanging)
    			{
    				_maQuaTrinhDaoTao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaQuaTrinhDaoTao");
    				On_MaQuaTrinhDaoTao_Changed(oldValue, _maQuaTrinhDaoTao);//\\
    			}
            }
        }
    	public static String MaQuaTrinhDaoTao_PropertyName { get { return "MaQuaTrinhDaoTao"; } }
        private Nullable<int> _maQuaTrinhDaoTao;
        partial void On_MaQuaTrinhDaoTao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaQuaTrinhDaoTao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsNhanVien_ChuyenNganh_tblnsNhanVien", "tblnsNhanVien")]
        public tblnsNhanVien tblnsNhanVien
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsNhanVien_ChuyenNganh_tblnsNhanVien", "tblnsNhanVien").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsNhanVien_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsNhanVien_ChuyenNganh_tblnsNhanVien", "tblnsNhanVien").Value = value;
    				On_tblnsNhanVien_Changed(this.tblnsNhanVien);//\\//
    			}
    	    }
        }
    	public static String tblnsNhanVien_ReferencePropertyName { get { return "tblnsNhanVien"; } }
    	partial void On_tblnsNhanVien_Changing(ref tblnsNhanVien newValue, ref bool stopChanging);
    	partial void On_tblnsNhanVien_Changed(tblnsNhanVien currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsNhanVien> tblnsNhanVienReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsNhanVien_ChuyenNganh_tblnsNhanVien", "tblnsNhanVien");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsNhanVien_ChuyenNganh_tblnsNhanVien", "tblnsNhanVien", value);
                }
            }
        }

        #endregion

    }
}

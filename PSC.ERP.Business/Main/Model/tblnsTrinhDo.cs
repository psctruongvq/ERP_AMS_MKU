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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsTrinhDo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsTrinhDo : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsTrinhDo()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsTrinhDo object.
        /// </summary>
        /// <param name="maTrinhDo">Initial value of the MaTrinhDo property.</param>
        public static tblnsTrinhDo CreatetblnsTrinhDo(int maTrinhDo)
        {
            tblnsTrinhDo tblnsTrinhDo = new tblnsTrinhDo();
            tblnsTrinhDo.MaTrinhDo = maTrinhDo;
            return tblnsTrinhDo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTrinhDo
        {
            get
            {
                return _maTrinhDo;
            }
            set
            {
                if (_maTrinhDo != value)
                {
        			int oldValue =  _maTrinhDo;
        			bool stopChanging = false;
                    On_MaTrinhDo_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTrinhDo");
        			if(!stopChanging)
        			{
        				_maTrinhDo = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTrinhDo");
        				On_MaTrinhDo_Changed(oldValue, _maTrinhDo);//\\
        			}
                }
            }
        }
    	public static String MaTrinhDo_PropertyName { get { return "MaTrinhDo"; } }
        private int _maTrinhDo;
        partial void On_MaTrinhDo_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTrinhDo_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVien;
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
        private Nullable<long> _maNhanVien;
        partial void On_MaNhanVien_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoHocVan
        {
            get
            {
                return _maTrinhDoHocVan;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoHocVan;
    			bool stopChanging = false;
                On_MaTrinhDoHocVan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoHocVan");
    			if(!stopChanging)
    			{
    				_maTrinhDoHocVan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoHocVan");
    				On_MaTrinhDoHocVan_Changed(oldValue, _maTrinhDoHocVan);//\\
    			}
            }
        }
    	public static String MaTrinhDoHocVan_PropertyName { get { return "MaTrinhDoHocVan"; } }
        private Nullable<int> _maTrinhDoHocVan;
        partial void On_MaTrinhDoHocVan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoHocVan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaHocHam
        {
            get
            {
                return _maHocHam;
            }
            set
            {
    			Nullable<int> oldValue =  _maHocHam;
    			bool stopChanging = false;
                On_MaHocHam_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHocHam");
    			if(!stopChanging)
    			{
    				_maHocHam = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHocHam");
    				On_MaHocHam_Changed(oldValue, _maHocHam);//\\
    			}
            }
        }
    	public static String MaHocHam_PropertyName { get { return "MaHocHam"; } }
        private Nullable<int> _maHocHam;
        partial void On_MaHocHam_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaHocHam_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaHocVi
        {
            get
            {
                return _maHocVi;
            }
            set
            {
    			Nullable<int> oldValue =  _maHocVi;
    			bool stopChanging = false;
                On_MaHocVi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaHocVi");
    			if(!stopChanging)
    			{
    				_maHocVi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaHocVi");
    				On_MaHocVi_Changed(oldValue, _maHocVi);//\\
    			}
            }
        }
    	public static String MaHocVi_PropertyName { get { return "MaHocVi"; } }
        private Nullable<int> _maHocVi;
        partial void On_MaHocVi_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaHocVi_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLyLuanCT
        {
            get
            {
                return _maLyLuanCT;
            }
            set
            {
    			Nullable<int> oldValue =  _maLyLuanCT;
    			bool stopChanging = false;
                On_MaLyLuanCT_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLyLuanCT");
    			if(!stopChanging)
    			{
    				_maLyLuanCT = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLyLuanCT");
    				On_MaLyLuanCT_Changed(oldValue, _maLyLuanCT);//\\
    			}
            }
        }
    	public static String MaLyLuanCT_PropertyName { get { return "MaLyLuanCT"; } }
        private Nullable<int> _maLyLuanCT;
        partial void On_MaLyLuanCT_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLyLuanCT_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoTinhHoc
        {
            get
            {
                return _maTrinhDoTinhHoc;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoTinhHoc;
    			bool stopChanging = false;
                On_MaTrinhDoTinhHoc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoTinhHoc");
    			if(!stopChanging)
    			{
    				_maTrinhDoTinhHoc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoTinhHoc");
    				On_MaTrinhDoTinhHoc_Changed(oldValue, _maTrinhDoTinhHoc);//\\
    			}
            }
        }
    	public static String MaTrinhDoTinhHoc_PropertyName { get { return "MaTrinhDoTinhHoc"; } }
        private Nullable<int> _maTrinhDoTinhHoc;
        partial void On_MaTrinhDoTinhHoc_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoTinhHoc_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChuyenMonNghiepVu
        {
            get
            {
                return _maChuyenMonNghiepVu;
            }
            set
            {
    			Nullable<int> oldValue =  _maChuyenMonNghiepVu;
    			bool stopChanging = false;
                On_MaChuyenMonNghiepVu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChuyenMonNghiepVu");
    			if(!stopChanging)
    			{
    				_maChuyenMonNghiepVu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChuyenMonNghiepVu");
    				On_MaChuyenMonNghiepVu_Changed(oldValue, _maChuyenMonNghiepVu);//\\
    			}
            }
        }
    	public static String MaChuyenMonNghiepVu_PropertyName { get { return "MaChuyenMonNghiepVu"; } }
        private Nullable<int> _maChuyenMonNghiepVu;
        partial void On_MaChuyenMonNghiepVu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChuyenMonNghiepVu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoChuyenMon
        {
            get
            {
                return _maTrinhDoChuyenMon;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoChuyenMon;
    			bool stopChanging = false;
                On_MaTrinhDoChuyenMon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoChuyenMon");
    			if(!stopChanging)
    			{
    				_maTrinhDoChuyenMon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoChuyenMon");
    				On_MaTrinhDoChuyenMon_Changed(oldValue, _maTrinhDoChuyenMon);//\\
    			}
            }
        }
    	public static String MaTrinhDoChuyenMon_PropertyName { get { return "MaTrinhDoChuyenMon"; } }
        private Nullable<int> _maTrinhDoChuyenMon;
        partial void On_MaTrinhDoChuyenMon_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoChuyenMon_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaChuyenNganh
        {
            get
            {
                return _maChuyenNganh;
            }
            set
            {
    			Nullable<int> oldValue =  _maChuyenNganh;
    			bool stopChanging = false;
                On_MaChuyenNganh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChuyenNganh");
    			if(!stopChanging)
    			{
    				_maChuyenNganh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChuyenNganh");
    				On_MaChuyenNganh_Changed(oldValue, _maChuyenNganh);//\\
    			}
            }
        }
    	public static String MaChuyenNganh_PropertyName { get { return "MaChuyenNganh"; } }
        private Nullable<int> _maChuyenNganh;
        partial void On_MaChuyenNganh_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChuyenNganh_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoVanHoa
        {
            get
            {
                return _maTrinhDoVanHoa;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoVanHoa;
    			bool stopChanging = false;
                On_MaTrinhDoVanHoa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoVanHoa");
    			if(!stopChanging)
    			{
    				_maTrinhDoVanHoa = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoVanHoa");
    				On_MaTrinhDoVanHoa_Changed(oldValue, _maTrinhDoVanHoa);//\\
    			}
            }
        }
    	public static String MaTrinhDoVanHoa_PropertyName { get { return "MaTrinhDoVanHoa"; } }
        private Nullable<int> _maTrinhDoVanHoa;
        partial void On_MaTrinhDoVanHoa_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoVanHoa_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaQuaTrinhDaoTaoLyLuanCT
        {
            get
            {
                return _maQuaTrinhDaoTaoLyLuanCT;
            }
            set
            {
    			Nullable<int> oldValue =  _maQuaTrinhDaoTaoLyLuanCT;
    			bool stopChanging = false;
                On_MaQuaTrinhDaoTaoLyLuanCT_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuaTrinhDaoTaoLyLuanCT");
    			if(!stopChanging)
    			{
    				_maQuaTrinhDaoTaoLyLuanCT = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaQuaTrinhDaoTaoLyLuanCT");
    				On_MaQuaTrinhDaoTaoLyLuanCT_Changed(oldValue, _maQuaTrinhDaoTaoLyLuanCT);//\\
    			}
            }
        }
    	public static String MaQuaTrinhDaoTaoLyLuanCT_PropertyName { get { return "MaQuaTrinhDaoTaoLyLuanCT"; } }
        private Nullable<int> _maQuaTrinhDaoTaoLyLuanCT;
        partial void On_MaQuaTrinhDaoTaoLyLuanCT_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaQuaTrinhDaoTaoLyLuanCT_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaQuaTrinhDaoTaoTinHoc
        {
            get
            {
                return _maQuaTrinhDaoTaoTinHoc;
            }
            set
            {
    			Nullable<int> oldValue =  _maQuaTrinhDaoTaoTinHoc;
    			bool stopChanging = false;
                On_MaQuaTrinhDaoTaoTinHoc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuaTrinhDaoTaoTinHoc");
    			if(!stopChanging)
    			{
    				_maQuaTrinhDaoTaoTinHoc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaQuaTrinhDaoTaoTinHoc");
    				On_MaQuaTrinhDaoTaoTinHoc_Changed(oldValue, _maQuaTrinhDaoTaoTinHoc);//\\
    			}
            }
        }
    	public static String MaQuaTrinhDaoTaoTinHoc_PropertyName { get { return "MaQuaTrinhDaoTaoTinHoc"; } }
        private Nullable<int> _maQuaTrinhDaoTaoTinHoc;
        partial void On_MaQuaTrinhDaoTaoTinHoc_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaQuaTrinhDaoTaoTinHoc_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsNhanVien", "tblnsNhanVien")]
        public tblnsNhanVien tblnsNhanVien
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsNhanVien", "tblnsNhanVien").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsNhanVien_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsNhanVien", "tblnsNhanVien").Value = value;
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
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsNhanVien", "tblnsNhanVien");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsNhanVien", "tblnsNhanVien", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDoChuyenMon")]
        public tblnsTrinhDoChuyenMon tblnsTrinhDoChuyenMon
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDoChuyenMon").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsTrinhDoChuyenMon_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDoChuyenMon").Value = value;
    				On_tblnsTrinhDoChuyenMon_Changed(this.tblnsTrinhDoChuyenMon);//\\//
    			}
    	    }
        }
    	public static String tblnsTrinhDoChuyenMon_ReferencePropertyName { get { return "tblnsTrinhDoChuyenMon"; } }
    	partial void On_tblnsTrinhDoChuyenMon_Changing(ref tblnsTrinhDoChuyenMon newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoChuyenMon_Changed(tblnsTrinhDoChuyenMon currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsTrinhDoChuyenMon> tblnsTrinhDoChuyenMonReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDoChuyenMon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDoChuyenMon", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDoChuyenMon")]
        public tblnsTrinhDoChuyenMon tblnsTrinhDoChuyenMon1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDoChuyenMon").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsTrinhDoChuyenMon1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDoChuyenMon").Value = value;
    				On_tblnsTrinhDoChuyenMon1_Changed(this.tblnsTrinhDoChuyenMon1);//\\//
    			}
    	    }
        }
    	public static String tblnsTrinhDoChuyenMon1_ReferencePropertyName { get { return "tblnsTrinhDoChuyenMon1"; } }
    	partial void On_tblnsTrinhDoChuyenMon1_Changing(ref tblnsTrinhDoChuyenMon newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoChuyenMon1_Changed(tblnsTrinhDoChuyenMon currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsTrinhDoChuyenMon> tblnsTrinhDoChuyenMon1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDoChuyenMon");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsTrinhDoChuyenMon>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDoChuyenMon", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDoHocVan")]
        public tblnsTrinhDoHocVan tblnsTrinhDoHocVan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoHocVan>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDoHocVan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsTrinhDoHocVan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoHocVan>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDoHocVan").Value = value;
    				On_tblnsTrinhDoHocVan_Changed(this.tblnsTrinhDoHocVan);//\\//
    			}
    	    }
        }
    	public static String tblnsTrinhDoHocVan_ReferencePropertyName { get { return "tblnsTrinhDoHocVan"; } }
    	partial void On_tblnsTrinhDoHocVan_Changing(ref tblnsTrinhDoHocVan newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoHocVan_Changed(tblnsTrinhDoHocVan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsTrinhDoHocVan> tblnsTrinhDoHocVanReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoHocVan>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDoHocVan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsTrinhDoHocVan>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDoHocVan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoTinHoc", "tblnsTrinhDoTinHoc")]
        public tblnsTrinhDoTinHoc tblnsTrinhDoTinHoc
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoTinHoc>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoTinHoc", "tblnsTrinhDoTinHoc").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsTrinhDoTinHoc_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoTinHoc>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoTinHoc", "tblnsTrinhDoTinHoc").Value = value;
    				On_tblnsTrinhDoTinHoc_Changed(this.tblnsTrinhDoTinHoc);//\\//
    			}
    	    }
        }
    	public static String tblnsTrinhDoTinHoc_ReferencePropertyName { get { return "tblnsTrinhDoTinHoc"; } }
    	partial void On_tblnsTrinhDoTinHoc_Changing(ref tblnsTrinhDoTinHoc newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoTinHoc_Changed(tblnsTrinhDoTinHoc currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsTrinhDoTinHoc> tblnsTrinhDoTinHocReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsTrinhDoTinHoc>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoTinHoc", "tblnsTrinhDoTinHoc");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsTrinhDoTinHoc>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoTinHoc", "tblnsTrinhDoTinHoc", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsChuyenMonNghiepVu", "tblnsChuyenMonNghiepVu")]
        public tblnsChuyenMonNghiepVu tblnsChuyenMonNghiepVu
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenMonNghiepVu>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenMonNghiepVu", "tblnsChuyenMonNghiepVu").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsChuyenMonNghiepVu_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenMonNghiepVu>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenMonNghiepVu", "tblnsChuyenMonNghiepVu").Value = value;
    				On_tblnsChuyenMonNghiepVu_Changed(this.tblnsChuyenMonNghiepVu);//\\//
    			}
    	    }
        }
    	public static String tblnsChuyenMonNghiepVu_ReferencePropertyName { get { return "tblnsChuyenMonNghiepVu"; } }
    	partial void On_tblnsChuyenMonNghiepVu_Changing(ref tblnsChuyenMonNghiepVu newValue, ref bool stopChanging);
    	partial void On_tblnsChuyenMonNghiepVu_Changed(tblnsChuyenMonNghiepVu currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsChuyenMonNghiepVu> tblnsChuyenMonNghiepVuReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenMonNghiepVu>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenMonNghiepVu", "tblnsChuyenMonNghiepVu");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsChuyenMonNghiepVu>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenMonNghiepVu", "tblnsChuyenMonNghiepVu", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsChuyenNganhDaoTao")]
        public tblnsChuyenNganhDaoTao tblnsChuyenNganhDaoTao
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenNganhDaoTao>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsChuyenNganhDaoTao").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsChuyenNganhDaoTao_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenNganhDaoTao>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsChuyenNganhDaoTao").Value = value;
    				On_tblnsChuyenNganhDaoTao_Changed(this.tblnsChuyenNganhDaoTao);//\\//
    			}
    	    }
        }
    	public static String tblnsChuyenNganhDaoTao_ReferencePropertyName { get { return "tblnsChuyenNganhDaoTao"; } }
    	partial void On_tblnsChuyenNganhDaoTao_Changing(ref tblnsChuyenNganhDaoTao newValue, ref bool stopChanging);
    	partial void On_tblnsChuyenNganhDaoTao_Changed(tblnsChuyenNganhDaoTao currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsChuyenNganhDaoTao> tblnsChuyenNganhDaoTaoReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsChuyenNganhDaoTao>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsChuyenNganhDaoTao");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsChuyenNganhDaoTao>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsChuyenNganhDaoTao", value);
                }
            }
        }

        #endregion

    }
}

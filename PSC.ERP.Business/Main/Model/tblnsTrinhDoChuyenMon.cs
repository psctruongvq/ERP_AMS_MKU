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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsTrinhDoChuyenMon")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsTrinhDoChuyenMon : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsTrinhDoChuyenMon()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsTrinhDoChuyenMon object.
        /// </summary>
        /// <param name="maTrinhDoChuyenMon">Initial value of the MaTrinhDoChuyenMon property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        public static tblnsTrinhDoChuyenMon CreatetblnsTrinhDoChuyenMon(int maTrinhDoChuyenMon, string maQuanLy)
        {
            tblnsTrinhDoChuyenMon tblnsTrinhDoChuyenMon = new tblnsTrinhDoChuyenMon();
            tblnsTrinhDoChuyenMon.MaTrinhDoChuyenMon = maTrinhDoChuyenMon;
            tblnsTrinhDoChuyenMon.MaQuanLy = maQuanLy;
            return tblnsTrinhDoChuyenMon;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTrinhDoChuyenMon
        {
            get
            {
                return _maTrinhDoChuyenMon;
            }
            set
            {
                if (_maTrinhDoChuyenMon != value)
                {
        			int oldValue =  _maTrinhDoChuyenMon;
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
        }
    	public static String MaTrinhDoChuyenMon_PropertyName { get { return "MaTrinhDoChuyenMon"; } }
        private int _maTrinhDoChuyenMon;
        partial void On_MaTrinhDoChuyenMon_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTrinhDoChuyenMon_Changed(int oldValue, int currentValue);
    
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
        public string TenTrinhDo
        {
            get
            {
                return _tenTrinhDo;
            }
            set
            {
    			string oldValue =  _tenTrinhDo;
    			bool stopChanging = false;
                On_TenTrinhDo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTrinhDo");
    			if(!stopChanging)
    			{
    				_tenTrinhDo = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTrinhDo");
    				On_TenTrinhDo_Changed(oldValue, _tenTrinhDo);//\\
    			}
            }
        }
    	public static String TenTrinhDo_PropertyName { get { return "TenTrinhDo"; } }
        private string _tenTrinhDo;
        partial void On_TenTrinhDo_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTrinhDo_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenVietTat
        {
            get
            {
                return _tenVietTat;
            }
            set
            {
    			string oldValue =  _tenVietTat;
    			bool stopChanging = false;
                On_TenVietTat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenVietTat");
    			if(!stopChanging)
    			{
    				_tenVietTat = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenVietTat");
    				On_TenVietTat_Changed(oldValue, _tenVietTat);//\\
    			}
            }
        }
    	public static String TenVietTat_PropertyName { get { return "TenVietTat"; } }
        private string _tenVietTat;
        partial void On_TenVietTat_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenVietTat_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
            set
            {
    			string oldValue =  _dienGiai;
    			bool stopChanging = false;
                On_DienGiai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DienGiai");
    			if(!stopChanging)
    			{
    				_dienGiai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DienGiai");
    				On_DienGiai_Changed(oldValue, _dienGiai);//\\
    			}
            }
        }
    	public static String DienGiai_PropertyName { get { return "DienGiai"; } }
        private string _dienGiai;
        partial void On_DienGiai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DienGiai_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDo")]
        public EntityCollection<tblnsTrinhDo> tblnsTrinhDoes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsTrinhDoes_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon", "tblnsTrinhDo", value);
    					On_tblnsTrinhDoes_Changed(this.tblnsTrinhDoes);//\\//
    				}
    			}
            }
        }
    	public static String tblnsTrinhDoes_EntityCollectionPropertyName { get { return "tblnsTrinhDoes"; } }
    	partial void On_tblnsTrinhDoes_Changing(ref EntityCollection<tblnsTrinhDo> newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoes_Changed(EntityCollection<tblnsTrinhDo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDo")]
        public EntityCollection<tblnsTrinhDo> tblnsTrinhDoes1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsTrinhDoes1_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoChuyenMon1", "tblnsTrinhDo", value);
    					On_tblnsTrinhDoes1_Changed(this.tblnsTrinhDoes1);//\\//
    				}
    			}
            }
        }
    	public static String tblnsTrinhDoes1_EntityCollectionPropertyName { get { return "tblnsTrinhDoes1"; } }
    	partial void On_tblnsTrinhDoes1_Changing(ref EntityCollection<tblnsTrinhDo> newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoes1_Changed(EntityCollection<tblnsTrinhDo> currentValue);

        #endregion

    }
}

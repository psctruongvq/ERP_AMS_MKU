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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsTrinhDoHocVan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsTrinhDoHocVan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsTrinhDoHocVan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsTrinhDoHocVan object.
        /// </summary>
        /// <param name="maTrinhDoHocVan">Initial value of the MaTrinhDoHocVan property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        /// <param name="trinhDoHocVan">Initial value of the TrinhDoHocVan property.</param>
        public static tblnsTrinhDoHocVan CreatetblnsTrinhDoHocVan(int maTrinhDoHocVan, string maQuanLy, string trinhDoHocVan)
        {
            tblnsTrinhDoHocVan tblnsTrinhDoHocVan = new tblnsTrinhDoHocVan();
            tblnsTrinhDoHocVan.MaTrinhDoHocVan = maTrinhDoHocVan;
            tblnsTrinhDoHocVan.MaQuanLy = maQuanLy;
            tblnsTrinhDoHocVan.TrinhDoHocVan = trinhDoHocVan;
            return tblnsTrinhDoHocVan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTrinhDoHocVan
        {
            get
            {
                return _maTrinhDoHocVan;
            }
            set
            {
                if (_maTrinhDoHocVan != value)
                {
        			int oldValue =  _maTrinhDoHocVan;
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
        }
    	public static String MaTrinhDoHocVan_PropertyName { get { return "MaTrinhDoHocVan"; } }
        private int _maTrinhDoHocVan;
        partial void On_MaTrinhDoHocVan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTrinhDoHocVan_Changed(int oldValue, int currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TrinhDoHocVan
        {
            get
            {
                return _trinhDoHocVan;
            }
            set
            {
    			string oldValue =  _trinhDoHocVan;
    			bool stopChanging = false;
                On_TrinhDoHocVan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TrinhDoHocVan");
    			if(!stopChanging)
    			{
    				_trinhDoHocVan = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("TrinhDoHocVan");
    				On_TrinhDoHocVan_Changed(oldValue, _trinhDoHocVan);//\\
    			}
            }
        }
    	public static String TrinhDoHocVan_PropertyName { get { return "TrinhDoHocVan"; } }
        private string _trinhDoHocVan;
        partial void On_TrinhDoHocVan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TrinhDoHocVan_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDo")]
        public EntityCollection<tblnsTrinhDo> tblnsTrinhDoes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsTrinhDoes_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsTrinhDoHocVan", "tblnsTrinhDo", value);
    					On_tblnsTrinhDoes_Changed(this.tblnsTrinhDoes);//\\//
    				}
    			}
            }
        }
    	public static String tblnsTrinhDoes_EntityCollectionPropertyName { get { return "tblnsTrinhDoes"; } }
    	partial void On_tblnsTrinhDoes_Changing(ref EntityCollection<tblnsTrinhDo> newValue, ref bool stopChanging);
    	partial void On_tblnsTrinhDoes_Changed(EntityCollection<tblnsTrinhDo> currentValue);

        #endregion

    }
}
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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsChuyenNganhDaoTao")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsChuyenNganhDaoTao : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsChuyenNganhDaoTao()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsChuyenNganhDaoTao object.
        /// </summary>
        /// <param name="maChuyenNganhDaoTao">Initial value of the MaChuyenNganhDaoTao property.</param>
        /// <param name="maQuanLy">Initial value of the MaQuanLy property.</param>
        /// <param name="chuyenNganhDaoTao">Initial value of the ChuyenNganhDaoTao property.</param>
        public static tblnsChuyenNganhDaoTao CreatetblnsChuyenNganhDaoTao(int maChuyenNganhDaoTao, string maQuanLy, string chuyenNganhDaoTao)
        {
            tblnsChuyenNganhDaoTao tblnsChuyenNganhDaoTao = new tblnsChuyenNganhDaoTao();
            tblnsChuyenNganhDaoTao.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
            tblnsChuyenNganhDaoTao.MaQuanLy = maQuanLy;
            tblnsChuyenNganhDaoTao.ChuyenNganhDaoTao = chuyenNganhDaoTao;
            return tblnsChuyenNganhDaoTao;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaChuyenNganhDaoTao
        {
            get
            {
                return _maChuyenNganhDaoTao;
            }
            set
            {
                if (_maChuyenNganhDaoTao != value)
                {
        			int oldValue =  _maChuyenNganhDaoTao;
        			bool stopChanging = false;
                    On_MaChuyenNganhDaoTao_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaChuyenNganhDaoTao");
        			if(!stopChanging)
        			{
        				_maChuyenNganhDaoTao = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaChuyenNganhDaoTao");
        				On_MaChuyenNganhDaoTao_Changed(oldValue, _maChuyenNganhDaoTao);//\\
        			}
                }
            }
        }
    	public static String MaChuyenNganhDaoTao_PropertyName { get { return "MaChuyenNganhDaoTao"; } }
        private int _maChuyenNganhDaoTao;
        partial void On_MaChuyenNganhDaoTao_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaChuyenNganhDaoTao_Changed(int oldValue, int currentValue);
    
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
        public string ChuyenNganhDaoTao
        {
            get
            {
                return _chuyenNganhDaoTao;
            }
            set
            {
    			string oldValue =  _chuyenNganhDaoTao;
    			bool stopChanging = false;
                On_ChuyenNganhDaoTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ChuyenNganhDaoTao");
    			if(!stopChanging)
    			{
    				_chuyenNganhDaoTao = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("ChuyenNganhDaoTao");
    				On_ChuyenNganhDaoTao_Changed(oldValue, _chuyenNganhDaoTao);//\\
    			}
            }
        }
    	public static String ChuyenNganhDaoTao_PropertyName { get { return "ChuyenNganhDaoTao"; } }
        private string _chuyenNganhDaoTao;
        partial void On_ChuyenNganhDaoTao_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_ChuyenNganhDaoTao_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsTrinhDo")]
        public EntityCollection<tblnsTrinhDo> tblnsTrinhDoes
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsTrinhDo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblnsTrinhDoes_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblnsTrinhDo>("PSC_ERPModel.FK_tblnsTrinhDo_tblnsChuyenNganhDaoTao", "tblnsTrinhDo", value);
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

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="view_TSCD_TaiSanCoDinh")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class view_TSCD_TaiSanCoDinh : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public view_TSCD_TaiSanCoDinh()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new view_TSCD_TaiSanCoDinh object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static view_TSCD_TaiSanCoDinh Createview_TSCD_TaiSanCoDinh(int id)
        {
            view_TSCD_TaiSanCoDinh view_TSCD_TaiSanCoDinh = new view_TSCD_TaiSanCoDinh();
            view_TSCD_TaiSanCoDinh.ID = id;
            return view_TSCD_TaiSanCoDinh;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                if (_iD != value)
                {
        			int oldValue =  _iD;
        			bool stopChanging = false;
                    On_ID_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("ID");
        			if(!stopChanging)
        			{
        				_iD = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("ID");
        				On_ID_Changed(oldValue, _iD);//\\
        			}
                }
            }
        }
    	public static String ID_PropertyName { get { return "ID"; } }
        private int _iD;
        partial void On_ID_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_ID_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Ten
        {
            get
            {
                return _ten;
            }
            set
            {
    			string oldValue =  _ten;
    			bool stopChanging = false;
                On_Ten_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Ten");
    			if(!stopChanging)
    			{
    				_ten = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Ten");
    				On_Ten_Changed(oldValue, _ten);//\\
    			}
            }
        }
    	public static String Ten_PropertyName { get { return "Ten"; } }
        private string _ten;
        partial void On_Ten_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Ten_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
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
    				_maQuanLy = StructuralObject.SetValidValue(value, true);
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
        public string ModelTSCD
        {
            get
            {
                return _modelTSCD;
            }
            set
            {
    			string oldValue =  _modelTSCD;
    			bool stopChanging = false;
                On_ModelTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ModelTSCD");
    			if(!stopChanging)
    			{
    				_modelTSCD = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("ModelTSCD");
    				On_ModelTSCD_Changed(oldValue, _modelTSCD);//\\
    			}
            }
        }
    	public static String ModelTSCD_PropertyName { get { return "ModelTSCD"; } }
        private string _modelTSCD;
        partial void On_ModelTSCD_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_ModelTSCD_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TGSuDungToiDaTSCD
        {
            get
            {
                return _tGSuDungToiDaTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _tGSuDungToiDaTSCD;
    			bool stopChanging = false;
                On_TGSuDungToiDaTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TGSuDungToiDaTSCD");
    			if(!stopChanging)
    			{
    				_tGSuDungToiDaTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TGSuDungToiDaTSCD");
    				On_TGSuDungToiDaTSCD_Changed(oldValue, _tGSuDungToiDaTSCD);//\\
    			}
            }
        }
    	public static String TGSuDungToiDaTSCD_PropertyName { get { return "TGSuDungToiDaTSCD"; } }
        private Nullable<int> _tGSuDungToiDaTSCD;
        partial void On_TGSuDungToiDaTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TGSuDungToiDaTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TGSuDungToiTHieuTSCD
        {
            get
            {
                return _tGSuDungToiTHieuTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _tGSuDungToiTHieuTSCD;
    			bool stopChanging = false;
                On_TGSuDungToiTHieuTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TGSuDungToiTHieuTSCD");
    			if(!stopChanging)
    			{
    				_tGSuDungToiTHieuTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TGSuDungToiTHieuTSCD");
    				On_TGSuDungToiTHieuTSCD_Changed(oldValue, _tGSuDungToiTHieuTSCD);//\\
    			}
            }
        }
    	public static String TGSuDungToiTHieuTSCD_PropertyName { get { return "TGSuDungToiTHieuTSCD"; } }
        private Nullable<int> _tGSuDungToiTHieuTSCD;
        partial void On_TGSuDungToiTHieuTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TGSuDungToiTHieuTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNuocSxTSCD
        {
            get
            {
                return _maNuocSxTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _maNuocSxTSCD;
    			bool stopChanging = false;
                On_MaNuocSxTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNuocSxTSCD");
    			if(!stopChanging)
    			{
    				_maNuocSxTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNuocSxTSCD");
    				On_MaNuocSxTSCD_Changed(oldValue, _maNuocSxTSCD);//\\
    			}
            }
        }
    	public static String MaNuocSxTSCD_PropertyName { get { return "MaNuocSxTSCD"; } }
        private Nullable<int> _maNuocSxTSCD;
        partial void On_MaNuocSxTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNuocSxTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaDonViTinhTSCD
        {
            get
            {
                return _maDonViTinhTSCD;
            }
            set
            {
    			Nullable<int> oldValue =  _maDonViTinhTSCD;
    			bool stopChanging = false;
                On_MaDonViTinhTSCD_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDonViTinhTSCD");
    			if(!stopChanging)
    			{
    				_maDonViTinhTSCD = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDonViTinhTSCD");
    				On_MaDonViTinhTSCD_Changed(oldValue, _maDonViTinhTSCD);//\\
    			}
            }
        }
    	public static String MaDonViTinhTSCD_PropertyName { get { return "MaDonViTinhTSCD"; } }
        private Nullable<int> _maDonViTinhTSCD;
        partial void On_MaDonViTinhTSCD_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaDonViTinhTSCD_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> ParentID
        {
            get
            {
                return _parentID;
            }
            set
            {
    			Nullable<int> oldValue =  _parentID;
    			bool stopChanging = false;
                On_ParentID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ParentID");
    			if(!stopChanging)
    			{
    				_parentID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ParentID");
    				On_ParentID_Changed(oldValue, _parentID);//\\
    			}
            }
        }
    	public static String ParentID_PropertyName { get { return "ParentID"; } }
        private Nullable<int> _parentID;
        partial void On_ParentID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_ParentID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

    }
}

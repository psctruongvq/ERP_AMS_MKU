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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ChiLaiKhenThuong2012")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ChiLaiKhenThuong2012 : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ChiLaiKhenThuong2012()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ChiLaiKhenThuong2012 object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="maQLNhanVien">Initial value of the MaQLNhanVien property.</param>
        public static v_ChiLaiKhenThuong2012 Createv_ChiLaiKhenThuong2012(long maNhanVien, string maQLNhanVien)
        {
            v_ChiLaiKhenThuong2012 v_ChiLaiKhenThuong2012 = new v_ChiLaiKhenThuong2012();
            v_ChiLaiKhenThuong2012.MaNhanVien = maNhanVien;
            v_ChiLaiKhenThuong2012.MaQLNhanVien = maQLNhanVien;
            return v_ChiLaiKhenThuong2012;
        }

        #endregion

        #region Primitive Properties
    
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
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
            set
            {
                if (_maQLNhanVien != value)
                {
        			string oldValue =  _maQLNhanVien;
        			bool stopChanging = false;
                    On_MaQLNhanVien_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaQLNhanVien");
        			if(!stopChanging)
        			{
        				_maQLNhanVien = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("MaQLNhanVien");
        				On_MaQLNhanVien_Changed(oldValue, _maQLNhanVien);//\\
        			}
                }
            }
        }
    	public static String MaQLNhanVien_PropertyName { get { return "MaQLNhanVien"; } }
        private string _maQLNhanVien;
        partial void On_MaQLNhanVien_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLNhanVien_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string CMND
        {
            get
            {
                return _cMND;
            }
            set
            {
    			string oldValue =  _cMND;
    			bool stopChanging = false;
                On_CMND_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CMND");
    			if(!stopChanging)
    			{
    				_cMND = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("CMND");
    				On_CMND_Changed(oldValue, _cMND);//\\
    			}
            }
        }
    	public static String CMND_PropertyName { get { return "CMND"; } }
        private string _cMND;
        partial void On_CMND_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_CMND_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
            set
            {
    			string oldValue =  _maSoThue;
    			bool stopChanging = false;
                On_MaSoThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaSoThue");
    			if(!stopChanging)
    			{
    				_maSoThue = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaSoThue");
    				On_MaSoThue_Changed(oldValue, _maSoThue);//\\
    			}
            }
        }
    	public static String MaSoThue_PropertyName { get { return "MaSoThue"; } }
        private string _maSoThue;
        partial void On_MaSoThue_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaSoThue_Changed(string oldValue, string currentValue);
    
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
        public Nullable<decimal> HTNVCTD1
        {
            get
            {
                return _hTNVCTD1;
            }
            set
            {
    			Nullable<decimal> oldValue =  _hTNVCTD1;
    			bool stopChanging = false;
                On_HTNVCTD1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HTNVCTD1");
    			if(!stopChanging)
    			{
    				_hTNVCTD1 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HTNVCTD1");
    				On_HTNVCTD1_Changed(oldValue, _hTNVCTD1);//\\
    			}
            }
        }
    	public static String HTNVCTD1_PropertyName { get { return "HTNVCTD1"; } }
        private Nullable<decimal> _hTNVCTD1;
        partial void On_HTNVCTD1_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_HTNVCTD1_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> HTNVCTD2
        {
            get
            {
                return _hTNVCTD2;
            }
            set
            {
    			Nullable<decimal> oldValue =  _hTNVCTD2;
    			bool stopChanging = false;
                On_HTNVCTD2_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HTNVCTD2");
    			if(!stopChanging)
    			{
    				_hTNVCTD2 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HTNVCTD2");
    				On_HTNVCTD2_Changed(oldValue, _hTNVCTD2);//\\
    			}
            }
        }
    	public static String HTNVCTD2_PropertyName { get { return "HTNVCTD2"; } }
        private Nullable<decimal> _hTNVCTD2;
        partial void On_HTNVCTD2_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_HTNVCTD2_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TetDL
        {
            get
            {
                return _tetDL;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tetDL;
    			bool stopChanging = false;
                On_TetDL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TetDL");
    			if(!stopChanging)
    			{
    				_tetDL = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TetDL");
    				On_TetDL_Changed(oldValue, _tetDL);//\\
    			}
            }
        }
    	public static String TetDL_PropertyName { get { return "TetDL"; } }
        private Nullable<decimal> _tetDL;
        partial void On_TetDL_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TetDL_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ALD1
        {
            get
            {
                return _aLD1;
            }
            set
            {
    			Nullable<decimal> oldValue =  _aLD1;
    			bool stopChanging = false;
                On_ALD1_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ALD1");
    			if(!stopChanging)
    			{
    				_aLD1 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ALD1");
    				On_ALD1_Changed(oldValue, _aLD1);//\\
    			}
            }
        }
    	public static String ALD1_PropertyName { get { return "ALD1"; } }
        private Nullable<decimal> _aLD1;
        partial void On_ALD1_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ALD1_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ALD2
        {
            get
            {
                return _aLD2;
            }
            set
            {
    			Nullable<decimal> oldValue =  _aLD2;
    			bool stopChanging = false;
                On_ALD2_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ALD2");
    			if(!stopChanging)
    			{
    				_aLD2 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ALD2");
    				On_ALD2_Changed(oldValue, _aLD2);//\\
    			}
            }
        }
    	public static String ALD2_PropertyName { get { return "ALD2"; } }
        private Nullable<decimal> _aLD2;
        partial void On_ALD2_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ALD2_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> C30_04
        {
            get
            {
                return _c30_04;
            }
            set
            {
    			Nullable<decimal> oldValue =  _c30_04;
    			bool stopChanging = false;
                On_C30_04_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("C30_04");
    			if(!stopChanging)
    			{
    				_c30_04 = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("C30_04");
    				On_C30_04_Changed(oldValue, _c30_04);//\\
    			}
            }
        }
    	public static String C30_04_PropertyName { get { return "C30_04"; } }
        private Nullable<decimal> _c30_04;
        partial void On_C30_04_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_C30_04_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> LiXi
        {
            get
            {
                return _liXi;
            }
            set
            {
    			Nullable<decimal> oldValue =  _liXi;
    			bool stopChanging = false;
                On_LiXi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LiXi");
    			if(!stopChanging)
    			{
    				_liXi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LiXi");
    				On_LiXi_Changed(oldValue, _liXi);//\\
    			}
            }
        }
    	public static String LiXi_PropertyName { get { return "LiXi"; } }
        private Nullable<decimal> _liXi;
        partial void On_LiXi_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_LiXi_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GioTo
        {
            get
            {
                return _gioTo;
            }
            set
            {
    			Nullable<decimal> oldValue =  _gioTo;
    			bool stopChanging = false;
                On_GioTo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GioTo");
    			if(!stopChanging)
    			{
    				_gioTo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GioTo");
    				On_GioTo_Changed(oldValue, _gioTo);//\\
    			}
            }
        }
    	public static String GioTo_PropertyName { get { return "GioTo"; } }
        private Nullable<decimal> _gioTo;
        partial void On_GioTo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GioTo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}
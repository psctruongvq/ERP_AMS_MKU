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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="v_ChiLaiPhuCap")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class v_ChiLaiPhuCap : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public v_ChiLaiPhuCap()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new v_ChiLaiPhuCap object.
        /// </summary>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="maQLNhanVien">Initial value of the MaQLNhanVien property.</param>
        /// <param name="tenPhuCap">Initial value of the TenPhuCap property.</param>
        public static v_ChiLaiPhuCap Createv_ChiLaiPhuCap(long maNhanVien, string maQLNhanVien, string tenPhuCap)
        {
            v_ChiLaiPhuCap v_ChiLaiPhuCap = new v_ChiLaiPhuCap();
            v_ChiLaiPhuCap.MaNhanVien = maNhanVien;
            v_ChiLaiPhuCap.MaQLNhanVien = maQLNhanVien;
            v_ChiLaiPhuCap.TenPhuCap = tenPhuCap;
            return v_ChiLaiPhuCap;
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
        public Nullable<decimal> PhuCapKhongChiuThue
        {
            get
            {
                return _phuCapKhongChiuThue;
            }
            set
            {
    			Nullable<decimal> oldValue =  _phuCapKhongChiuThue;
    			bool stopChanging = false;
                On_PhuCapKhongChiuThue_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PhuCapKhongChiuThue");
    			if(!stopChanging)
    			{
    				_phuCapKhongChiuThue = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PhuCapKhongChiuThue");
    				On_PhuCapKhongChiuThue_Changed(oldValue, _phuCapKhongChiuThue);//\\
    			}
            }
        }
    	public static String PhuCapKhongChiuThue_PropertyName { get { return "PhuCapKhongChiuThue"; } }
        private Nullable<decimal> _phuCapKhongChiuThue;
        partial void On_PhuCapKhongChiuThue_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_PhuCapKhongChiuThue_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TinhLaiPhuCap
        {
            get
            {
                return _tinhLaiPhuCap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tinhLaiPhuCap;
    			bool stopChanging = false;
                On_TinhLaiPhuCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TinhLaiPhuCap");
    			if(!stopChanging)
    			{
    				_tinhLaiPhuCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TinhLaiPhuCap");
    				On_TinhLaiPhuCap_Changed(oldValue, _tinhLaiPhuCap);//\\
    			}
            }
        }
    	public static String TinhLaiPhuCap_PropertyName { get { return "TinhLaiPhuCap"; } }
        private Nullable<decimal> _tinhLaiPhuCap;
        partial void On_TinhLaiPhuCap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TinhLaiPhuCap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> Trong200Gio
        {
            get
            {
                return _trong200Gio;
            }
            set
            {
    			Nullable<decimal> oldValue =  _trong200Gio;
    			bool stopChanging = false;
                On_Trong200Gio_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Trong200Gio");
    			if(!stopChanging)
    			{
    				_trong200Gio = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Trong200Gio");
    				On_Trong200Gio_Changed(oldValue, _trong200Gio);//\\
    			}
            }
        }
    	public static String Trong200Gio_PropertyName { get { return "Trong200Gio"; } }
        private Nullable<decimal> _trong200Gio;
        partial void On_Trong200Gio_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_Trong200Gio_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenPhuCap
        {
            get
            {
                return _tenPhuCap;
            }
            set
            {
                if (_tenPhuCap != value)
                {
        			string oldValue =  _tenPhuCap;
        			bool stopChanging = false;
                    On_TenPhuCap_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenPhuCap");
        			if(!stopChanging)
        			{
        				_tenPhuCap = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenPhuCap");
        				On_TenPhuCap_Changed(oldValue, _tenPhuCap);//\\
        			}
                }
            }
        }
    	public static String TenPhuCap_PropertyName { get { return "TenPhuCap"; } }
        private string _tenPhuCap;
        partial void On_TenPhuCap_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenPhuCap_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiPhuCap
        {
            get
            {
                return _maLoaiPhuCap;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiPhuCap;
    			bool stopChanging = false;
                On_MaLoaiPhuCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiPhuCap");
    			if(!stopChanging)
    			{
    				_maLoaiPhuCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiPhuCap");
    				On_MaLoaiPhuCap_Changed(oldValue, _maLoaiPhuCap);//\\
    			}
            }
        }
    	public static String MaLoaiPhuCap_PropertyName { get { return "MaLoaiPhuCap"; } }
        private Nullable<int> _maLoaiPhuCap;
        partial void On_MaLoaiPhuCap_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiPhuCap_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NGNT
        {
            get
            {
                return _nGNT;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nGNT;
    			bool stopChanging = false;
                On_NGNT_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NGNT");
    			if(!stopChanging)
    			{
    				_nGNT = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NGNT");
    				On_NGNT_Changed(oldValue, _nGNT);//\\
    			}
            }
        }
    	public static String NGNT_PropertyName { get { return "NGNT"; } }
        private Nullable<decimal> _nGNT;
        partial void On_NGNT_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NGNT_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TienNGNT
        {
            get
            {
                return _tienNGNT;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienNGNT;
    			bool stopChanging = false;
                On_TienNGNT_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienNGNT");
    			if(!stopChanging)
    			{
    				_tienNGNT = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienNGNT");
    				On_TienNGNT_Changed(oldValue, _tienNGNT);//\\
    			}
            }
        }
    	public static String TienNGNT_PropertyName { get { return "TienNGNT"; } }
        private Nullable<decimal> _tienNGNT;
        partial void On_TienNGNT_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienNGNT_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NGTBCN
        {
            get
            {
                return _nGTBCN;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nGTBCN;
    			bool stopChanging = false;
                On_NGTBCN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NGTBCN");
    			if(!stopChanging)
    			{
    				_nGTBCN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NGTBCN");
    				On_NGTBCN_Changed(oldValue, _nGTBCN);//\\
    			}
            }
        }
    	public static String NGTBCN_PropertyName { get { return "NGTBCN"; } }
        private Nullable<decimal> _nGTBCN;
        partial void On_NGTBCN_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NGTBCN_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TeinNGTBCN
        {
            get
            {
                return _teinNGTBCN;
            }
            set
            {
    			Nullable<decimal> oldValue =  _teinNGTBCN;
    			bool stopChanging = false;
                On_TeinNGTBCN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TeinNGTBCN");
    			if(!stopChanging)
    			{
    				_teinNGTBCN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TeinNGTBCN");
    				On_TeinNGTBCN_Changed(oldValue, _teinNGTBCN);//\\
    			}
            }
        }
    	public static String TeinNGTBCN_PropertyName { get { return "TeinNGTBCN"; } }
        private Nullable<decimal> _teinNGTBCN;
        partial void On_TeinNGTBCN_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TeinNGTBCN_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NGNL
        {
            get
            {
                return _nGNL;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nGNL;
    			bool stopChanging = false;
                On_NGNL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NGNL");
    			if(!stopChanging)
    			{
    				_nGNL = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NGNL");
    				On_NGNL_Changed(oldValue, _nGNL);//\\
    			}
            }
        }
    	public static String NGNL_PropertyName { get { return "NGNL"; } }
        private Nullable<decimal> _nGNL;
        partial void On_NGNL_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NGNL_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TienNGNL
        {
            get
            {
                return _tienNGNL;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienNGNL;
    			bool stopChanging = false;
                On_TienNGNL_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienNGNL");
    			if(!stopChanging)
    			{
    				_tienNGNL = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienNGNL");
    				On_TienNGNL_Changed(oldValue, _tienNGNL);//\\
    			}
            }
        }
    	public static String TienNGNL_PropertyName { get { return "TienNGNL"; } }
        private Nullable<decimal> _tienNGNL;
        partial void On_TienNGNL_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienNGNL_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TienPhuCap
        {
            get
            {
                return _tienPhuCap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tienPhuCap;
    			bool stopChanging = false;
                On_TienPhuCap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TienPhuCap");
    			if(!stopChanging)
    			{
    				_tienPhuCap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TienPhuCap");
    				On_TienPhuCap_Changed(oldValue, _tienPhuCap);//\\
    			}
            }
        }
    	public static String TienPhuCap_PropertyName { get { return "TienPhuCap"; } }
        private Nullable<decimal> _tienPhuCap;
        partial void On_TienPhuCap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TienPhuCap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

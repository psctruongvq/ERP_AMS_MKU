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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="View_TaiKhoanCapBa")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class View_TaiKhoanCapBa : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public View_TaiKhoanCapBa()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new View_TaiKhoanCapBa object.
        /// </summary>
        /// <param name="maTaiKhoan">Initial value of the MaTaiKhoan property.</param>
        /// <param name="soHieuTK">Initial value of the SoHieuTK property.</param>
        /// <param name="tenTaiKhoan">Initial value of the TenTaiKhoan property.</param>
        public static View_TaiKhoanCapBa CreateView_TaiKhoanCapBa(int maTaiKhoan, string soHieuTK, string tenTaiKhoan)
        {
            View_TaiKhoanCapBa view_TaiKhoanCapBa = new View_TaiKhoanCapBa();
            view_TaiKhoanCapBa.MaTaiKhoan = maTaiKhoan;
            view_TaiKhoanCapBa.SoHieuTK = soHieuTK;
            view_TaiKhoanCapBa.TenTaiKhoan = tenTaiKhoan;
            return view_TaiKhoanCapBa;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaTaiKhoan
        {
            get
            {
                return _maTaiKhoan;
            }
            set
            {
                if (_maTaiKhoan != value)
                {
        			int oldValue =  _maTaiKhoan;
        			bool stopChanging = false;
                    On_MaTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaTaiKhoan");
        			if(!stopChanging)
        			{
        				_maTaiKhoan = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaTaiKhoan");
        				On_MaTaiKhoan_Changed(oldValue, _maTaiKhoan);//\\
        			}
                }
            }
        }
    	public static String MaTaiKhoan_PropertyName { get { return "MaTaiKhoan"; } }
        private int _maTaiKhoan;
        partial void On_MaTaiKhoan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaTaiKhoan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string SoHieuTK
        {
            get
            {
                return _soHieuTK;
            }
            set
            {
                if (_soHieuTK != value)
                {
        			string oldValue =  _soHieuTK;
        			bool stopChanging = false;
                    On_SoHieuTK_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("SoHieuTK");
        			if(!stopChanging)
        			{
        				_soHieuTK = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("SoHieuTK");
        				On_SoHieuTK_Changed(oldValue, _soHieuTK);//\\
        			}
                }
            }
        }
    	public static String SoHieuTK_PropertyName { get { return "SoHieuTK"; } }
        private string _soHieuTK;
        partial void On_SoHieuTK_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTK_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenTaiKhoan
        {
            get
            {
                return _tenTaiKhoan;
            }
            set
            {
                if (_tenTaiKhoan != value)
                {
        			string oldValue =  _tenTaiKhoan;
        			bool stopChanging = false;
                    On_TenTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("TenTaiKhoan");
        			if(!stopChanging)
        			{
        				_tenTaiKhoan = StructuralObject.SetValidValue(value, false);
        				ReportPropertyChanged("TenTaiKhoan");
        				On_TenTaiKhoan_Changed(oldValue, _tenTaiKhoan);//\\
        			}
                }
            }
        }
    	public static String TenTaiKhoan_PropertyName { get { return "TenTaiKhoan"; } }
        private string _tenTaiKhoan;
        partial void On_TenTaiKhoan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTaiKhoan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoanCha
        {
            get
            {
                return _maTaiKhoanCha;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoanCha;
    			bool stopChanging = false;
                On_MaTaiKhoanCha_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoanCha");
    			if(!stopChanging)
    			{
    				_maTaiKhoanCha = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoanCha");
    				On_MaTaiKhoanCha_Changed(oldValue, _maTaiKhoanCha);//\\
    			}
            }
        }
    	public static String MaTaiKhoanCha_PropertyName { get { return "MaTaiKhoanCha"; } }
        private Nullable<int> _maTaiKhoanCha;
        partial void On_MaTaiKhoanCha_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoanCha_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> CoDoiTuongTheoDoi
        {
            get
            {
                return _coDoiTuongTheoDoi;
            }
            set
            {
    			Nullable<bool> oldValue =  _coDoiTuongTheoDoi;
    			bool stopChanging = false;
                On_CoDoiTuongTheoDoi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CoDoiTuongTheoDoi");
    			if(!stopChanging)
    			{
    				_coDoiTuongTheoDoi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("CoDoiTuongTheoDoi");
    				On_CoDoiTuongTheoDoi_Changed(oldValue, _coDoiTuongTheoDoi);//\\
    			}
            }
        }
    	public static String CoDoiTuongTheoDoi_PropertyName { get { return "CoDoiTuongTheoDoi"; } }
        private Nullable<bool> _coDoiTuongTheoDoi;
        partial void On_CoDoiTuongTheoDoi_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_CoDoiTuongTheoDoi_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> LoaiSoDuCo
        {
            get
            {
                return _loaiSoDuCo;
            }
            set
            {
    			Nullable<bool> oldValue =  _loaiSoDuCo;
    			bool stopChanging = false;
                On_LoaiSoDuCo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiSoDuCo");
    			if(!stopChanging)
    			{
    				_loaiSoDuCo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiSoDuCo");
    				On_LoaiSoDuCo_Changed(oldValue, _loaiSoDuCo);//\\
    			}
            }
        }
    	public static String LoaiSoDuCo_PropertyName { get { return "LoaiSoDuCo"; } }
        private Nullable<bool> _loaiSoDuCo;
        partial void On_LoaiSoDuCo_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_LoaiSoDuCo_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> LoaiSoDuNo
        {
            get
            {
                return _loaiSoDuNo;
            }
            set
            {
    			Nullable<bool> oldValue =  _loaiSoDuNo;
    			bool stopChanging = false;
                On_LoaiSoDuNo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LoaiSoDuNo");
    			if(!stopChanging)
    			{
    				_loaiSoDuNo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LoaiSoDuNo");
    				On_LoaiSoDuNo_Changed(oldValue, _loaiSoDuNo);//\\
    			}
            }
        }
    	public static String LoaiSoDuNo_PropertyName { get { return "LoaiSoDuNo"; } }
        private Nullable<bool> _loaiSoDuNo;
        partial void On_LoaiSoDuNo_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_LoaiSoDuNo_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoDuNoDauNam
        {
            get
            {
                return _soDuNoDauNam;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soDuNoDauNam;
    			bool stopChanging = false;
                On_SoDuNoDauNam_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoDuNoDauNam");
    			if(!stopChanging)
    			{
    				_soDuNoDauNam = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoDuNoDauNam");
    				On_SoDuNoDauNam_Changed(oldValue, _soDuNoDauNam);//\\
    			}
            }
        }
    	public static String SoDuNoDauNam_PropertyName { get { return "SoDuNoDauNam"; } }
        private Nullable<decimal> _soDuNoDauNam;
        partial void On_SoDuNoDauNam_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoDuNoDauNam_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> SoDuCoDauNam
        {
            get
            {
                return _soDuCoDauNam;
            }
            set
            {
    			Nullable<decimal> oldValue =  _soDuCoDauNam;
    			bool stopChanging = false;
                On_SoDuCoDauNam_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoDuCoDauNam");
    			if(!stopChanging)
    			{
    				_soDuCoDauNam = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoDuCoDauNam");
    				On_SoDuCoDauNam_Changed(oldValue, _soDuCoDauNam);//\\
    			}
            }
        }
    	public static String SoDuCoDauNam_PropertyName { get { return "SoDuCoDauNam"; } }
        private Nullable<decimal> _soDuCoDauNam;
        partial void On_SoDuCoDauNam_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_SoDuCoDauNam_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaLoaiTaiKhoan
        {
            get
            {
                return _maLoaiTaiKhoan;
            }
            set
            {
    			Nullable<int> oldValue =  _maLoaiTaiKhoan;
    			bool stopChanging = false;
                On_MaLoaiTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaLoaiTaiKhoan");
    			if(!stopChanging)
    			{
    				_maLoaiTaiKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaLoaiTaiKhoan");
    				On_MaLoaiTaiKhoan_Changed(oldValue, _maLoaiTaiKhoan);//\\
    			}
            }
        }
    	public static String MaLoaiTaiKhoan_PropertyName { get { return "MaLoaiTaiKhoan"; } }
        private Nullable<int> _maLoaiTaiKhoan;
        partial void On_MaLoaiTaiKhoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaLoaiTaiKhoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<byte> CapTaiKhoan
        {
            get
            {
                return _capTaiKhoan;
            }
            set
            {
    			Nullable<byte> oldValue =  _capTaiKhoan;
    			bool stopChanging = false;
                On_CapTaiKhoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CapTaiKhoan");
    			if(!stopChanging)
    			{
    				_capTaiKhoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("CapTaiKhoan");
    				On_CapTaiKhoan_Changed(oldValue, _capTaiKhoan);//\\
    			}
            }
        }
    	public static String CapTaiKhoan_PropertyName { get { return "CapTaiKhoan"; } }
        private Nullable<byte> _capTaiKhoan;
        partial void On_CapTaiKhoan_Changing(Nullable<byte> currentValue, ref Nullable<byte> newValue, ref bool stopChanging);
        partial void On_CapTaiKhoan_Changed(Nullable<byte> oldValue, Nullable<byte> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoanChaCapMot
        {
            get
            {
                return _maTaiKhoanChaCapMot;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoanChaCapMot;
    			bool stopChanging = false;
                On_MaTaiKhoanChaCapMot_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoanChaCapMot");
    			if(!stopChanging)
    			{
    				_maTaiKhoanChaCapMot = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoanChaCapMot");
    				On_MaTaiKhoanChaCapMot_Changed(oldValue, _maTaiKhoanChaCapMot);//\\
    			}
            }
        }
    	public static String MaTaiKhoanChaCapMot_PropertyName { get { return "MaTaiKhoanChaCapMot"; } }
        private Nullable<int> _maTaiKhoanChaCapMot;
        partial void On_MaTaiKhoanChaCapMot_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoanChaCapMot_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieuTKChaCapMot
        {
            get
            {
                return _soHieuTKChaCapMot;
            }
            set
            {
    			string oldValue =  _soHieuTKChaCapMot;
    			bool stopChanging = false;
                On_SoHieuTKChaCapMot_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieuTKChaCapMot");
    			if(!stopChanging)
    			{
    				_soHieuTKChaCapMot = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieuTKChaCapMot");
    				On_SoHieuTKChaCapMot_Changed(oldValue, _soHieuTKChaCapMot);//\\
    			}
            }
        }
    	public static String SoHieuTKChaCapMot_PropertyName { get { return "SoHieuTKChaCapMot"; } }
        private string _soHieuTKChaCapMot;
        partial void On_SoHieuTKChaCapMot_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTKChaCapMot_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTKChaCapMot
        {
            get
            {
                return _tenTKChaCapMot;
            }
            set
            {
    			string oldValue =  _tenTKChaCapMot;
    			bool stopChanging = false;
                On_TenTKChaCapMot_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTKChaCapMot");
    			if(!stopChanging)
    			{
    				_tenTKChaCapMot = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTKChaCapMot");
    				On_TenTKChaCapMot_Changed(oldValue, _tenTKChaCapMot);//\\
    			}
            }
        }
    	public static String TenTKChaCapMot_PropertyName { get { return "TenTKChaCapMot"; } }
        private string _tenTKChaCapMot;
        partial void On_TenTKChaCapMot_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTKChaCapMot_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoanChaCapHai
        {
            get
            {
                return _maTaiKhoanChaCapHai;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoanChaCapHai;
    			bool stopChanging = false;
                On_MaTaiKhoanChaCapHai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoanChaCapHai");
    			if(!stopChanging)
    			{
    				_maTaiKhoanChaCapHai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoanChaCapHai");
    				On_MaTaiKhoanChaCapHai_Changed(oldValue, _maTaiKhoanChaCapHai);//\\
    			}
            }
        }
    	public static String MaTaiKhoanChaCapHai_PropertyName { get { return "MaTaiKhoanChaCapHai"; } }
        private Nullable<int> _maTaiKhoanChaCapHai;
        partial void On_MaTaiKhoanChaCapHai_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoanChaCapHai_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieuTKChaCapHai
        {
            get
            {
                return _soHieuTKChaCapHai;
            }
            set
            {
    			string oldValue =  _soHieuTKChaCapHai;
    			bool stopChanging = false;
                On_SoHieuTKChaCapHai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieuTKChaCapHai");
    			if(!stopChanging)
    			{
    				_soHieuTKChaCapHai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieuTKChaCapHai");
    				On_SoHieuTKChaCapHai_Changed(oldValue, _soHieuTKChaCapHai);//\\
    			}
            }
        }
    	public static String SoHieuTKChaCapHai_PropertyName { get { return "SoHieuTKChaCapHai"; } }
        private string _soHieuTKChaCapHai;
        partial void On_SoHieuTKChaCapHai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTKChaCapHai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTKChaCapHai
        {
            get
            {
                return _tenTKChaCapHai;
            }
            set
            {
    			string oldValue =  _tenTKChaCapHai;
    			bool stopChanging = false;
                On_TenTKChaCapHai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTKChaCapHai");
    			if(!stopChanging)
    			{
    				_tenTKChaCapHai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTKChaCapHai");
    				On_TenTKChaCapHai_Changed(oldValue, _tenTKChaCapHai);//\\
    			}
            }
        }
    	public static String TenTKChaCapHai_PropertyName { get { return "TenTKChaCapHai"; } }
        private string _tenTKChaCapHai;
        partial void On_TenTKChaCapHai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTKChaCapHai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTaiKhoanChaCapBa
        {
            get
            {
                return _maTaiKhoanChaCapBa;
            }
            set
            {
    			Nullable<int> oldValue =  _maTaiKhoanChaCapBa;
    			bool stopChanging = false;
                On_MaTaiKhoanChaCapBa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTaiKhoanChaCapBa");
    			if(!stopChanging)
    			{
    				_maTaiKhoanChaCapBa = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTaiKhoanChaCapBa");
    				On_MaTaiKhoanChaCapBa_Changed(oldValue, _maTaiKhoanChaCapBa);//\\
    			}
            }
        }
    	public static String MaTaiKhoanChaCapBa_PropertyName { get { return "MaTaiKhoanChaCapBa"; } }
        private Nullable<int> _maTaiKhoanChaCapBa;
        partial void On_MaTaiKhoanChaCapBa_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTaiKhoanChaCapBa_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoHieuTKChaCapBa
        {
            get
            {
                return _soHieuTKChaCapBa;
            }
            set
            {
    			string oldValue =  _soHieuTKChaCapBa;
    			bool stopChanging = false;
                On_SoHieuTKChaCapBa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoHieuTKChaCapBa");
    			if(!stopChanging)
    			{
    				_soHieuTKChaCapBa = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoHieuTKChaCapBa");
    				On_SoHieuTKChaCapBa_Changed(oldValue, _soHieuTKChaCapBa);//\\
    			}
            }
        }
    	public static String SoHieuTKChaCapBa_PropertyName { get { return "SoHieuTKChaCapBa"; } }
        private string _soHieuTKChaCapBa;
        partial void On_SoHieuTKChaCapBa_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTKChaCapBa_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenTKChaCapBa
        {
            get
            {
                return _tenTKChaCapBa;
            }
            set
            {
    			string oldValue =  _tenTKChaCapBa;
    			bool stopChanging = false;
                On_TenTKChaCapBa_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenTKChaCapBa");
    			if(!stopChanging)
    			{
    				_tenTKChaCapBa = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenTKChaCapBa");
    				On_TenTKChaCapBa_Changed(oldValue, _tenTKChaCapBa);//\\
    			}
            }
        }
    	public static String TenTKChaCapBa_PropertyName { get { return "TenTKChaCapBa"; } }
        private string _tenTKChaCapBa;
        partial void On_TenTKChaCapBa_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTKChaCapBa_Changed(string oldValue, string currentValue);

        #endregion

    }
}

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
    [EdmComplexTypeAttribute(NamespaceName="PSC_ERPModel", Name="sp_AllDoiTuong_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class sp_AllDoiTuong_Result : ComplexObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new sp_AllDoiTuong_Result object.
        /// </summary>
        /// <param name="maDoiTuong">Initial value of the MaDoiTuong property.</param>
        /// <param name="loai">Initial value of the Loai property.</param>
        public static sp_AllDoiTuong_Result Createsp_AllDoiTuong_Result(long maDoiTuong, int loai)
        {
            sp_AllDoiTuong_Result sp_AllDoiTuong_Result = new sp_AllDoiTuong_Result();
            sp_AllDoiTuong_Result.MaDoiTuong = maDoiTuong;
            sp_AllDoiTuong_Result.Loai = loai;
            return sp_AllDoiTuong_Result;
        }

        #endregion

    #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public long MaDoiTuong
        {
            get
            {
                return _maDoiTuong;
            }
            set
            {
    			long oldValue =  _maDoiTuong;
    			bool stopChanging = false;
                On_MaDoiTuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaDoiTuong");
    			if(!stopChanging)
    			{
    				_maDoiTuong = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaDoiTuong");
    				On_MaDoiTuong_Changed(oldValue, _maDoiTuong);//\\
    			}
            }
        }
    	public static String MaDoiTuong_PropertyName { get { return "MaDoiTuong"; } }
        private long _maDoiTuong;
        partial void On_MaDoiTuong_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_MaDoiTuong_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaQLDoiTuong
        {
            get
            {
                return _maQLDoiTuong;
            }
            set
            {
    			string oldValue =  _maQLDoiTuong;
    			bool stopChanging = false;
                On_MaQLDoiTuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQLDoiTuong");
    			if(!stopChanging)
    			{
    				_maQLDoiTuong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQLDoiTuong");
    				On_MaQLDoiTuong_Changed(oldValue, _maQLDoiTuong);//\\
    			}
            }
        }
    	public static String MaQLDoiTuong_PropertyName { get { return "MaQLDoiTuong"; } }
        private string _maQLDoiTuong;
        partial void On_MaQLDoiTuong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLDoiTuong_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenDoiTuong
        {
            get
            {
                return _tenDoiTuong;
            }
            set
            {
    			string oldValue =  _tenDoiTuong;
    			bool stopChanging = false;
                On_TenDoiTuong_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenDoiTuong");
    			if(!stopChanging)
    			{
    				_tenDoiTuong = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenDoiTuong");
    				On_TenDoiTuong_Changed(oldValue, _tenDoiTuong);//\\
    			}
            }
        }
    	public static String TenDoiTuong_PropertyName { get { return "TenDoiTuong"; } }
        private string _tenDoiTuong;
        partial void On_TenDoiTuong_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenDoiTuong_Changed(string oldValue, string currentValue);
    
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
        public Nullable<int> MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
    			Nullable<int> oldValue =  _maBoPhan;
    			bool stopChanging = false;
                On_MaBoPhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaBoPhan");
    			if(!stopChanging)
    			{
    				_maBoPhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaBoPhan");
    				On_MaBoPhan_Changed(oldValue, _maBoPhan);//\\
    			}
            }
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private Nullable<int> _maBoPhan;
        partial void On_MaBoPhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public int Loai
        {
            get
            {
                return _loai;
            }
            set
            {
    			int oldValue =  _loai;
    			bool stopChanging = false;
                On_Loai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Loai");
    			if(!stopChanging)
    			{
    				_loai = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Loai");
    				On_Loai_Changed(oldValue, _loai);//\\
    			}
            }
        }
    	public static String Loai_PropertyName { get { return "Loai"; } }
        private int _loai;
        partial void On_Loai_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_Loai_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DiaChi
        {
            get
            {
                return _diaChi;
            }
            set
            {
    			string oldValue =  _diaChi;
    			bool stopChanging = false;
                On_DiaChi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DiaChi");
    			if(!stopChanging)
    			{
    				_diaChi = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DiaChi");
    				On_DiaChi_Changed(oldValue, _diaChi);//\\
    			}
            }
        }
    	public static String DiaChi_PropertyName { get { return "DiaChi"; } }
        private string _diaChi;
        partial void On_DiaChi_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DiaChi_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
    			Nullable<int> oldValue =  _maCongTy;
    			bool stopChanging = false;
                On_MaCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaCongTy");
    			if(!stopChanging)
    			{
    				_maCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaCongTy");
    				On_MaCongTy_Changed(oldValue, _maCongTy);//\\
    			}
            }
        }
    	public static String MaCongTy_PropertyName { get { return "MaCongTy"; } }
        private Nullable<int> _maCongTy;
        partial void On_MaCongTy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaCongTy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> TinhTrang
        {
            get
            {
                return _tinhTrang;
            }
            set
            {
    			Nullable<int> oldValue =  _tinhTrang;
    			bool stopChanging = false;
                On_TinhTrang_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TinhTrang");
    			if(!stopChanging)
    			{
    				_tinhTrang = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TinhTrang");
    				On_TinhTrang_Changed(oldValue, _tinhTrang);//\\
    			}
            }
        }
    	public static String TinhTrang_PropertyName { get { return "TinhTrang"; } }
        private Nullable<int> _tinhTrang;
        partial void On_TinhTrang_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_TinhTrang_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

    #endregion

    }
}
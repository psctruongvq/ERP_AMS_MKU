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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblTiLeKhauHaoTheoTaiKhoan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblTiLeKhauHaoTheoTaiKhoan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblTiLeKhauHaoTheoTaiKhoan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblTiLeKhauHaoTheoTaiKhoan object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="soHieuTK">Initial value of the SoHieuTK property.</param>
        /// <param name="tenTaiKhoan">Initial value of the TenTaiKhoan property.</param>
        public static tblTiLeKhauHaoTheoTaiKhoan CreatetblTiLeKhauHaoTheoTaiKhoan(int id, string soHieuTK, string tenTaiKhoan)
        {
            tblTiLeKhauHaoTheoTaiKhoan tblTiLeKhauHaoTheoTaiKhoan = new tblTiLeKhauHaoTheoTaiKhoan();
            tblTiLeKhauHaoTheoTaiKhoan.ID = id;
            tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK = soHieuTK;
            tblTiLeKhauHaoTheoTaiKhoan.TenTaiKhoan = tenTaiKhoan;
            return tblTiLeKhauHaoTheoTaiKhoan;
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string SoHieuTK
        {
            get
            {
                return _soHieuTK;
            }
            set
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
    	public static String SoHieuTK_PropertyName { get { return "SoHieuTK"; } }
        private string _soHieuTK;
        partial void On_SoHieuTK_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoHieuTK_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string TenTaiKhoan
        {
            get
            {
                return _tenTaiKhoan;
            }
            set
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
    	public static String TenTaiKhoan_PropertyName { get { return "TenTaiKhoan"; } }
        private string _tenTaiKhoan;
        partial void On_TenTaiKhoan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenTaiKhoan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> PhanTram
        {
            get
            {
                return _phanTram;
            }
            set
            {
    			Nullable<decimal> oldValue =  _phanTram;
    			bool stopChanging = false;
                On_PhanTram_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PhanTram");
    			if(!stopChanging)
    			{
    				_phanTram = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PhanTram");
    				On_PhanTram_Changed(oldValue, _phanTram);//\\
    			}
            }
        }
    	public static String PhanTram_PropertyName { get { return "PhanTram"; } }
        private Nullable<decimal> _phanTram;
        partial void On_PhanTram_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_PhanTram_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayHieuLuc
        {
            get
            {
                return _ngayHieuLuc;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayHieuLuc;
    			bool stopChanging = false;
                On_NgayHieuLuc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayHieuLuc");
    			if(!stopChanging)
    			{
    				_ngayHieuLuc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayHieuLuc");
    				On_NgayHieuLuc_Changed(oldValue, _ngayHieuLuc);//\\
    			}
            }
        }
    	public static String NgayHieuLuc_PropertyName { get { return "NgayHieuLuc"; } }
        private Nullable<System.DateTime> _ngayHieuLuc;
        partial void On_NgayHieuLuc_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayHieuLuc_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> Nam
        {
            get
            {
                return _nam;
            }
            set
            {
    			Nullable<int> oldValue =  _nam;
    			bool stopChanging = false;
                On_Nam_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Nam");
    			if(!stopChanging)
    			{
    				_nam = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("Nam");
    				On_Nam_Changed(oldValue, _nam);//\\
    			}
            }
        }
    	public static String Nam_PropertyName { get { return "Nam"; } }
        private Nullable<int> _nam;
        partial void On_Nam_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_Nam_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			Nullable<int> oldValue =  _userID;
    			bool stopChanging = false;
                On_UserID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserID");
    			if(!stopChanging)
    			{
    				_userID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserID");
    				On_UserID_Changed(oldValue, _userID);//\\
    			}
            }
        }
    	public static String UserID_PropertyName { get { return "UserID"; } }
        private Nullable<int> _userID;
        partial void On_UserID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> NguyenGiaTon
        {
            get
            {
                return _nguyenGiaTon;
            }
            set
            {
    			Nullable<decimal> oldValue =  _nguyenGiaTon;
    			bool stopChanging = false;
                On_NguyenGiaTon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NguyenGiaTon");
    			if(!stopChanging)
    			{
    				_nguyenGiaTon = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NguyenGiaTon");
    				On_NguyenGiaTon_Changed(oldValue, _nguyenGiaTon);//\\
    			}
            }
        }
    	public static String NguyenGiaTon_PropertyName { get { return "NguyenGiaTon"; } }
        private Nullable<decimal> _nguyenGiaTon;
        partial void On_NguyenGiaTon_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_NguyenGiaTon_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);

        #endregion

    }
}

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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="view_TaiSanCoDinhCaBiet_PhongBan")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class view_TaiSanCoDinhCaBiet_PhongBan : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public view_TaiSanCoDinhCaBiet_PhongBan()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new view_TaiSanCoDinhCaBiet_PhongBan object.
        /// </summary>
        /// <param name="maPhanBoSuDung">Initial value of the MaPhanBoSuDung property.</param>
        public static view_TaiSanCoDinhCaBiet_PhongBan Createview_TaiSanCoDinhCaBiet_PhongBan(int maPhanBoSuDung)
        {
            view_TaiSanCoDinhCaBiet_PhongBan view_TaiSanCoDinhCaBiet_PhongBan = new view_TaiSanCoDinhCaBiet_PhongBan();
            view_TaiSanCoDinhCaBiet_PhongBan.MaPhanBoSuDung = maPhanBoSuDung;
            return view_TaiSanCoDinhCaBiet_PhongBan;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaPhanBoSuDung
        {
            get
            {
                return _maPhanBoSuDung;
            }
            set
            {
                if (_maPhanBoSuDung != value)
                {
        			int oldValue =  _maPhanBoSuDung;
        			bool stopChanging = false;
                    On_MaPhanBoSuDung_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaPhanBoSuDung");
        			if(!stopChanging)
        			{
        				_maPhanBoSuDung = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaPhanBoSuDung");
        				On_MaPhanBoSuDung_Changed(oldValue, _maPhanBoSuDung);//\\
        			}
                }
            }
        }
    	public static String MaPhanBoSuDung_PropertyName { get { return "MaPhanBoSuDung"; } }
        private int _maPhanBoSuDung;
        partial void On_MaPhanBoSuDung_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaPhanBoSuDung_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTSCDCaBiet
        {
            get
            {
                return _maTSCDCaBiet;
            }
            set
            {
    			Nullable<int> oldValue =  _maTSCDCaBiet;
    			bool stopChanging = false;
                On_MaTSCDCaBiet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTSCDCaBiet");
    			if(!stopChanging)
    			{
    				_maTSCDCaBiet = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTSCDCaBiet");
    				On_MaTSCDCaBiet_Changed(oldValue, _maTSCDCaBiet);//\\
    			}
            }
        }
    	public static String MaTSCDCaBiet_PropertyName { get { return "MaTSCDCaBiet"; } }
        private Nullable<int> _maTSCDCaBiet;
        partial void On_MaTSCDCaBiet_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTSCDCaBiet_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhongBan
        {
            get
            {
                return _maPhongBan;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhongBan;
    			bool stopChanging = false;
                On_MaPhongBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBan");
    			if(!stopChanging)
    			{
    				_maPhongBan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhongBan");
    				On_MaPhongBan_Changed(oldValue, _maPhongBan);//\\
    			}
            }
        }
    	public static String MaPhongBan_PropertyName { get { return "MaPhongBan"; } }
        private Nullable<int> _maPhongBan;
        partial void On_MaPhongBan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhongBan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayPhanBo
        {
            get
            {
                return _ngayPhanBo;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayPhanBo;
    			bool stopChanging = false;
                On_NgayPhanBo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayPhanBo");
    			if(!stopChanging)
    			{
    				_ngayPhanBo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayPhanBo");
    				On_NgayPhanBo_Changed(oldValue, _ngayPhanBo);//\\
    			}
            }
        }
    	public static String NgayPhanBo_PropertyName { get { return "NgayPhanBo"; } }
        private Nullable<System.DateTime> _ngayPhanBo;
        partial void On_NgayPhanBo_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayPhanBo_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayKetThuc
        {
            get
            {
                return _ngayKetThuc;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayKetThuc;
    			bool stopChanging = false;
                On_NgayKetThuc_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayKetThuc");
    			if(!stopChanging)
    			{
    				_ngayKetThuc = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayKetThuc");
    				On_NgayKetThuc_Changed(oldValue, _ngayKetThuc);//\\
    			}
            }
        }
    	public static String NgayKetThuc_PropertyName { get { return "NgayKetThuc"; } }
        private Nullable<System.DateTime> _ngayKetThuc;
        partial void On_NgayKetThuc_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayKetThuc_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
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
        public Nullable<int> MaChiTietDieuChuyenNoiBo
        {
            get
            {
                return _maChiTietDieuChuyenNoiBo;
            }
            set
            {
    			Nullable<int> oldValue =  _maChiTietDieuChuyenNoiBo;
    			bool stopChanging = false;
                On_MaChiTietDieuChuyenNoiBo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChiTietDieuChuyenNoiBo");
    			if(!stopChanging)
    			{
    				_maChiTietDieuChuyenNoiBo = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChiTietDieuChuyenNoiBo");
    				On_MaChiTietDieuChuyenNoiBo_Changed(oldValue, _maChiTietDieuChuyenNoiBo);//\\
    			}
            }
        }
    	public static String MaChiTietDieuChuyenNoiBo_PropertyName { get { return "MaChiTietDieuChuyenNoiBo"; } }
        private Nullable<int> _maChiTietDieuChuyenNoiBo;
        partial void On_MaChiTietDieuChuyenNoiBo_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaChiTietDieuChuyenNoiBo_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> PmCuMaPhongBan
        {
            get
            {
                return _pmCuMaPhongBan;
            }
            set
            {
    			Nullable<int> oldValue =  _pmCuMaPhongBan;
    			bool stopChanging = false;
                On_PmCuMaPhongBan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("PmCuMaPhongBan");
    			if(!stopChanging)
    			{
    				_pmCuMaPhongBan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("PmCuMaPhongBan");
    				On_PmCuMaPhongBan_Changed(oldValue, _pmCuMaPhongBan);//\\
    			}
            }
        }
    	public static String PmCuMaPhongBan_PropertyName { get { return "PmCuMaPhongBan"; } }
        private Nullable<int> _pmCuMaPhongBan;
        partial void On_PmCuMaPhongBan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_PmCuMaPhongBan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaViTri
        {
            get
            {
                return _maViTri;
            }
            set
            {
    			Nullable<int> oldValue =  _maViTri;
    			bool stopChanging = false;
                On_MaViTri_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaViTri");
    			if(!stopChanging)
    			{
    				_maViTri = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaViTri");
    				On_MaViTri_Changed(oldValue, _maViTri);//\\
    			}
            }
        }
    	public static String MaViTri_PropertyName { get { return "MaViTri"; } }
        private Nullable<int> _maViTri;
        partial void On_MaViTri_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaViTri_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

    }
}

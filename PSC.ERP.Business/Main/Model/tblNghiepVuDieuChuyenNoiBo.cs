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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblNghiepVuDieuChuyenNoiBo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblNghiepVuDieuChuyenNoiBo : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblNghiepVuDieuChuyenNoiBo()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblNghiepVuDieuChuyenNoiBo object.
        /// </summary>
        /// <param name="maNghiepVuDieuChuyenNoiBo">Initial value of the MaNghiepVuDieuChuyenNoiBo property.</param>
        /// <param name="ngayChungTu">Initial value of the NgayChungTu property.</param>
        public static tblNghiepVuDieuChuyenNoiBo CreatetblNghiepVuDieuChuyenNoiBo(int maNghiepVuDieuChuyenNoiBo, System.DateTime ngayChungTu)
        {
            tblNghiepVuDieuChuyenNoiBo tblNghiepVuDieuChuyenNoiBo = new tblNghiepVuDieuChuyenNoiBo();
            tblNghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo = maNghiepVuDieuChuyenNoiBo;
            tblNghiepVuDieuChuyenNoiBo.NgayChungTu = ngayChungTu;
            return tblNghiepVuDieuChuyenNoiBo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNghiepVuDieuChuyenNoiBo
        {
            get
            {
                return _maNghiepVuDieuChuyenNoiBo;
            }
            set
            {
                if (_maNghiepVuDieuChuyenNoiBo != value)
                {
        			int oldValue =  _maNghiepVuDieuChuyenNoiBo;
        			bool stopChanging = false;
                    On_MaNghiepVuDieuChuyenNoiBo_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNghiepVuDieuChuyenNoiBo");
        			if(!stopChanging)
        			{
        				_maNghiepVuDieuChuyenNoiBo = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNghiepVuDieuChuyenNoiBo");
        				On_MaNghiepVuDieuChuyenNoiBo_Changed(oldValue, _maNghiepVuDieuChuyenNoiBo);//\\
        			}
                }
            }
        }
    	public static String MaNghiepVuDieuChuyenNoiBo_PropertyName { get { return "MaNghiepVuDieuChuyenNoiBo"; } }
        private int _maNghiepVuDieuChuyenNoiBo;
        partial void On_MaNghiepVuDieuChuyenNoiBo_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNghiepVuDieuChuyenNoiBo_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaNhanVienBenGiao
        {
            get
            {
                return _maNhanVienBenGiao;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVienBenGiao;
    			bool stopChanging = false;
                On_MaNhanVienBenGiao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNhanVienBenGiao");
    			if(!stopChanging)
    			{
    				_maNhanVienBenGiao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNhanVienBenGiao");
    				On_MaNhanVienBenGiao_Changed(oldValue, _maNhanVienBenGiao);//\\
    			}
            }
        }
    	public static String MaNhanVienBenGiao_PropertyName { get { return "MaNhanVienBenGiao"; } }
        private Nullable<long> _maNhanVienBenGiao;
        partial void On_MaNhanVienBenGiao_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVienBenGiao_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaNhanVienBenNhan
        {
            get
            {
                return _maNhanVienBenNhan;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVienBenNhan;
    			bool stopChanging = false;
                On_MaNhanVienBenNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNhanVienBenNhan");
    			if(!stopChanging)
    			{
    				_maNhanVienBenNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNhanVienBenNhan");
    				On_MaNhanVienBenNhan_Changed(oldValue, _maNhanVienBenNhan);//\\
    			}
            }
        }
    	public static String MaNhanVienBenNhan_PropertyName { get { return "MaNhanVienBenNhan"; } }
        private Nullable<long> _maNhanVienBenNhan;
        partial void On_MaNhanVienBenNhan_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVienBenNhan_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime NgayChungTu
        {
            get
            {
                return _ngayChungTu;
            }
            set
            {
    			System.DateTime oldValue =  _ngayChungTu;
    			bool stopChanging = false;
                On_NgayChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayChungTu");
    			if(!stopChanging)
    			{
    				_ngayChungTu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayChungTu");
    				On_NgayChungTu_Changed(oldValue, _ngayChungTu);//\\
    			}
            }
        }
    	public static String NgayChungTu_PropertyName { get { return "NgayChungTu"; } }
        private System.DateTime _ngayChungTu;
        partial void On_NgayChungTu_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_NgayChungTu_Changed(System.DateTime oldValue, System.DateTime currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
    			string oldValue =  _ghiChu;
    			bool stopChanging = false;
                On_GhiChu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GhiChu");
    			if(!stopChanging)
    			{
    				_ghiChu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("GhiChu");
    				On_GhiChu_Changed(oldValue, _ghiChu);//\\
    			}
            }
        }
    	public static String GhiChu_PropertyName { get { return "GhiChu"; } }
        private string _ghiChu;
        partial void On_GhiChu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_GhiChu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhongBanGiao
        {
            get
            {
                return _maPhongBanGiao;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhongBanGiao;
    			bool stopChanging = false;
                On_MaPhongBanGiao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBanGiao");
    			if(!stopChanging)
    			{
    				_maPhongBanGiao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhongBanGiao");
    				On_MaPhongBanGiao_Changed(oldValue, _maPhongBanGiao);//\\
    			}
            }
        }
    	public static String MaPhongBanGiao_PropertyName { get { return "MaPhongBanGiao"; } }
        private Nullable<int> _maPhongBanGiao;
        partial void On_MaPhongBanGiao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhongBanGiao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaPhongBanNhan
        {
            get
            {
                return _maPhongBanNhan;
            }
            set
            {
    			Nullable<int> oldValue =  _maPhongBanNhan;
    			bool stopChanging = false;
                On_MaPhongBanNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaPhongBanNhan");
    			if(!stopChanging)
    			{
    				_maPhongBanNhan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaPhongBanNhan");
    				On_MaPhongBanNhan_Changed(oldValue, _maPhongBanNhan);//\\
    			}
            }
        }
    	public static String MaPhongBanNhan_PropertyName { get { return "MaPhongBanNhan"; } }
        private Nullable<int> _maPhongBanNhan;
        partial void On_MaPhongBanNhan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaPhongBanNhan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string SoChungTu
        {
            get
            {
                return _soChungTu;
            }
            set
            {
    			string oldValue =  _soChungTu;
    			bool stopChanging = false;
                On_SoChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoChungTu");
    			if(!stopChanging)
    			{
    				_soChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("SoChungTu");
    				On_SoChungTu_Changed(oldValue, _soChungTu);//\\
    			}
            }
        }
    	public static String SoChungTu_PropertyName { get { return "SoChungTu"; } }
        private string _soChungTu;
        partial void On_SoChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_SoChungTu_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MaQLChungTu
        {
            get
            {
                return _maQLChungTu;
            }
            set
            {
    			string oldValue =  _maQLChungTu;
    			bool stopChanging = false;
                On_MaQLChungTu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQLChungTu");
    			if(!stopChanging)
    			{
    				_maQLChungTu = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MaQLChungTu");
    				On_MaQLChungTu_Changed(oldValue, _maQLChungTu);//\\
    			}
            }
        }
    	public static String MaQLChungTu_PropertyName { get { return "MaQLChungTu"; } }
        private string _maQLChungTu;
        partial void On_MaQLChungTu_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MaQLChungTu_Changed(string oldValue, string currentValue);
    
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
        public string TenNhanVienBenGiao
        {
            get
            {
                return _tenNhanVienBenGiao;
            }
            set
            {
    			string oldValue =  _tenNhanVienBenGiao;
    			bool stopChanging = false;
                On_TenNhanVienBenGiao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhanVienBenGiao");
    			if(!stopChanging)
    			{
    				_tenNhanVienBenGiao = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNhanVienBenGiao");
    				On_TenNhanVienBenGiao_Changed(oldValue, _tenNhanVienBenGiao);//\\
    			}
            }
        }
    	public static String TenNhanVienBenGiao_PropertyName { get { return "TenNhanVienBenGiao"; } }
        private string _tenNhanVienBenGiao;
        partial void On_TenNhanVienBenGiao_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVienBenGiao_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string TenNhanVienBenNhan
        {
            get
            {
                return _tenNhanVienBenNhan;
            }
            set
            {
    			string oldValue =  _tenNhanVienBenNhan;
    			bool stopChanging = false;
                On_TenNhanVienBenNhan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TenNhanVienBenNhan");
    			if(!stopChanging)
    			{
    				_tenNhanVienBenNhan = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("TenNhanVienBenNhan");
    				On_TenNhanVienBenNhan_Changed(oldValue, _tenNhanVienBenNhan);//\\
    			}
            }
        }
    	public static String TenNhanVienBenNhan_PropertyName { get { return "TenNhanVienBenNhan"; } }
        private string _tenNhanVienBenNhan;
        partial void On_TenNhanVienBenNhan_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_TenNhanVienBenNhan_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string LyDoDieuChuyen
        {
            get
            {
                return _lyDoDieuChuyen;
            }
            set
            {
    			string oldValue =  _lyDoDieuChuyen;
    			bool stopChanging = false;
                On_LyDoDieuChuyen_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LyDoDieuChuyen");
    			if(!stopChanging)
    			{
    				_lyDoDieuChuyen = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("LyDoDieuChuyen");
    				On_LyDoDieuChuyen_Changed(oldValue, _lyDoDieuChuyen);//\\
    			}
            }
        }
    	public static String LyDoDieuChuyen_PropertyName { get { return "LyDoDieuChuyen"; } }
        private string _lyDoDieuChuyen;
        partial void On_LyDoDieuChuyen_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_LyDoDieuChuyen_Changed(string oldValue, string currentValue);
    
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
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string LyDo
        {
            get
            {
                return _lyDo;
            }
            set
            {
    			string oldValue =  _lyDo;
    			bool stopChanging = false;
                On_LyDo_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LyDo");
    			if(!stopChanging)
    			{
    				_lyDo = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("LyDo");
    				On_LyDo_Changed(oldValue, _lyDo);//\\
    			}
            }
        }
    	public static String LyDo_PropertyName { get { return "LyDo"; } }
        private string _lyDo;
        partial void On_LyDo_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_LyDo_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> HoanTat
        {
            get
            {
                return _hoanTat;
            }
            set
            {
    			Nullable<bool> oldValue =  _hoanTat;
    			bool stopChanging = false;
                On_HoanTat_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("HoanTat");
    			if(!stopChanging)
    			{
    				_hoanTat = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("HoanTat");
    				On_HoanTat_Changed(oldValue, _hoanTat);//\\
    			}
            }
        }
    	public static String HoanTat_PropertyName { get { return "HoanTat"; } }
        private Nullable<bool> _hoanTat;
        partial void On_HoanTat_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_HoanTat_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserIDNgDuyetCongTy
        {
            get
            {
                return _userIDNgDuyetCongTy;
            }
            set
            {
    			Nullable<int> oldValue =  _userIDNgDuyetCongTy;
    			bool stopChanging = false;
                On_UserIDNgDuyetCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserIDNgDuyetCongTy");
    			if(!stopChanging)
    			{
    				_userIDNgDuyetCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserIDNgDuyetCongTy");
    				On_UserIDNgDuyetCongTy_Changed(oldValue, _userIDNgDuyetCongTy);//\\
    			}
            }
        }
    	public static String UserIDNgDuyetCongTy_PropertyName { get { return "UserIDNgDuyetCongTy"; } }
        private Nullable<int> _userIDNgDuyetCongTy;
        partial void On_UserIDNgDuyetCongTy_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserIDNgDuyetCongTy_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayDuyetCongTy
        {
            get
            {
                return _ngayDuyetCongTy;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayDuyetCongTy;
    			bool stopChanging = false;
                On_NgayDuyetCongTy_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayDuyetCongTy");
    			if(!stopChanging)
    			{
    				_ngayDuyetCongTy = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayDuyetCongTy");
    				On_NgayDuyetCongTy_Changed(oldValue, _ngayDuyetCongTy);//\\
    			}
            }
        }
    	public static String NgayDuyetCongTy_PropertyName { get { return "NgayDuyetCongTy"; } }
        private Nullable<System.DateTime> _ngayDuyetCongTy;
        partial void On_NgayDuyetCongTy_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayDuyetCongTy_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserIDNgDuyetTapDoan
        {
            get
            {
                return _userIDNgDuyetTapDoan;
            }
            set
            {
    			Nullable<int> oldValue =  _userIDNgDuyetTapDoan;
    			bool stopChanging = false;
                On_UserIDNgDuyetTapDoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserIDNgDuyetTapDoan");
    			if(!stopChanging)
    			{
    				_userIDNgDuyetTapDoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserIDNgDuyetTapDoan");
    				On_UserIDNgDuyetTapDoan_Changed(oldValue, _userIDNgDuyetTapDoan);//\\
    			}
            }
        }
    	public static String UserIDNgDuyetTapDoan_PropertyName { get { return "UserIDNgDuyetTapDoan"; } }
        private Nullable<int> _userIDNgDuyetTapDoan;
        partial void On_UserIDNgDuyetTapDoan_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserIDNgDuyetTapDoan_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<System.DateTime> NgayDuyetTapDoan
        {
            get
            {
                return _ngayDuyetTapDoan;
            }
            set
            {
    			Nullable<System.DateTime> oldValue =  _ngayDuyetTapDoan;
    			bool stopChanging = false;
                On_NgayDuyetTapDoan_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgayDuyetTapDoan");
    			if(!stopChanging)
    			{
    				_ngayDuyetTapDoan = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgayDuyetTapDoan");
    				On_NgayDuyetTapDoan_Changed(oldValue, _ngayDuyetTapDoan);//\\
    			}
            }
        }
    	public static String NgayDuyetTapDoan_PropertyName { get { return "NgayDuyetTapDoan"; } }
        private Nullable<System.DateTime> _ngayDuyetTapDoan;
        partial void On_NgayDuyetTapDoan_Changing(Nullable<System.DateTime> currentValue, ref Nullable<System.DateTime> newValue, ref bool stopChanging);
        partial void On_NgayDuyetTapDoan_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblCT_NghiepVuDieuChuyenNoiBo_tblNghiepVuDieuChuyenNoiBo", "tblCT_NghiepVuDieuChuyenNoiBo")]
        public EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> tblCT_NghiepVuDieuChuyenNoiBo
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tblCT_NghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenNoiBo_tblNghiepVuDieuChuyenNoiBo", "tblCT_NghiepVuDieuChuyenNoiBo");
            }
            set
            {
                if ((value != null))
                {
    				bool stopChanging = false;
    				On_tblCT_NghiepVuDieuChuyenNoiBo_Changing(ref value, ref stopChanging);//\\//
    				if(!stopChanging)
    				{
    					((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tblCT_NghiepVuDieuChuyenNoiBo>("PSC_ERPModel.FK_tblCT_NghiepVuDieuChuyenNoiBo_tblNghiepVuDieuChuyenNoiBo", "tblCT_NghiepVuDieuChuyenNoiBo", value);
    					On_tblCT_NghiepVuDieuChuyenNoiBo_Changed(this.tblCT_NghiepVuDieuChuyenNoiBo);//\\//
    				}
    			}
            }
        }
    	public static String tblCT_NghiepVuDieuChuyenNoiBo_EntityCollectionPropertyName { get { return "tblCT_NghiepVuDieuChuyenNoiBo"; } }
    	partial void On_tblCT_NghiepVuDieuChuyenNoiBo_Changing(ref EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> newValue, ref bool stopChanging);
    	partial void On_tblCT_NghiepVuDieuChuyenNoiBo_Changed(EntityCollection<tblCT_NghiepVuDieuChuyenNoiBo> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblnsBoPhan")]
        public tblnsBoPhan tblnsBoPhan
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblnsBoPhan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsBoPhan_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblnsBoPhan").Value = value;
    				On_tblnsBoPhan_Changed(this.tblnsBoPhan);//\\//
    			}
    	    }
        }
    	public static String tblnsBoPhan_ReferencePropertyName { get { return "tblnsBoPhan"; } }
    	partial void On_tblnsBoPhan_Changing(ref tblnsBoPhan newValue, ref bool stopChanging);
    	partial void On_tblnsBoPhan_Changed(tblnsBoPhan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsBoPhan> tblnsBoPhanReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblnsBoPhan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew", "tblnsBoPhan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblnsBoPhan")]
        public tblnsBoPhan tblnsBoPhan1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblnsBoPhan").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsBoPhan1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblnsBoPhan").Value = value;
    				On_tblnsBoPhan1_Changed(this.tblnsBoPhan1);//\\//
    			}
    	    }
        }
    	public static String tblnsBoPhan1_ReferencePropertyName { get { return "tblnsBoPhan1"; } }
    	partial void On_tblnsBoPhan1_Changing(ref tblnsBoPhan newValue, ref bool stopChanging);
    	partial void On_tblnsBoPhan1_Changed(tblnsBoPhan currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsBoPhan> tblnsBoPhan1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblnsBoPhan");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsBoPhan>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblBoPhanERPNew1", "tblnsBoPhan", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien", "tblnsNhanVien")]
        public tblnsNhanVien tblnsNhanVien
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien", "tblnsNhanVien").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsNhanVien_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien", "tblnsNhanVien").Value = value;
    				On_tblnsNhanVien_Changed(this.tblnsNhanVien);//\\//
    			}
    	    }
        }
    	public static String tblnsNhanVien_ReferencePropertyName { get { return "tblnsNhanVien"; } }
    	partial void On_tblnsNhanVien_Changing(ref tblnsNhanVien newValue, ref bool stopChanging);
    	partial void On_tblnsNhanVien_Changed(tblnsNhanVien currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsNhanVien> tblnsNhanVienReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien", "tblnsNhanVien");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien", "tblnsNhanVien", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien1", "tblnsNhanVien")]
        public tblnsNhanVien tblnsNhanVien1
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien1", "tblnsNhanVien").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_tblnsNhanVien1_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien1", "tblnsNhanVien").Value = value;
    				On_tblnsNhanVien1_Changed(this.tblnsNhanVien1);//\\//
    			}
    	    }
        }
    	public static String tblnsNhanVien1_ReferencePropertyName { get { return "tblnsNhanVien1"; } }
    	partial void On_tblnsNhanVien1_Changing(ref tblnsNhanVien newValue, ref bool stopChanging);
    	partial void On_tblnsNhanVien1_Changed(tblnsNhanVien currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tblnsNhanVien> tblnsNhanVien1Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien1", "tblnsNhanVien");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tblnsNhanVien>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_tblnsNhanVien1", "tblnsNhanVien", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_tblNghiepVuDieuChuyenNoiBo_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_app_users", "app_users").Value = value;
    				On_app_users_Changed(this.app_users);//\\//
    			}
    	    }
        }
    	public static String app_users_ReferencePropertyName { get { return "app_users"; } }
    	partial void On_app_users_Changing(ref app_users newValue, ref bool stopChanging);
    	partial void On_app_users_Changed(app_users currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<app_users> app_usersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_tblNghiepVuDieuChuyenNoiBo_app_users", "app_users", value);
                }
            }
        }

        #endregion

    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//	  Code duoc tao boi DESKTOP-J5VELTF\DELL luc 10:47:31 ngay 24/12/2021
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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="colen")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class colen : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public colen()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new colen object.
        /// </summary>
        /// <param name="maBoPhan">Initial value of the MaBoPhan property.</param>
        /// <param name="maKyTinhLuong">Initial value of the MaKyTinhLuong property.</param>
        /// <param name="maNhanVien">Initial value of the MaNhanVien property.</param>
        /// <param name="ngayLap">Initial value of the NgayLap property.</param>
        /// <param name="nguoiLap">Initial value of the NguoiLap property.</param>
        public static colen Createcolen(int maBoPhan, int maKyTinhLuong, long maNhanVien, System.DateTime ngayLap, int nguoiLap)
        {
            colen colen = new colen();
            colen.MaBoPhan = maBoPhan;
            colen.MaKyTinhLuong = maKyTinhLuong;
            colen.MaNhanVien = maNhanVien;
            colen.NgayLap = ngayLap;
            colen.NguoiLap = nguoiLap;
            return colen;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (_maBoPhan != value)
                {
        			int oldValue =  _maBoPhan;
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
        }
    	public static String MaBoPhan_PropertyName { get { return "MaBoPhan"; } }
        private int _maBoPhan;
        partial void On_MaBoPhan_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaBoPhan_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
            set
            {
                if (_maKyTinhLuong != value)
                {
        			int oldValue =  _maKyTinhLuong;
        			bool stopChanging = false;
                    On_MaKyTinhLuong_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaKyTinhLuong");
        			if(!stopChanging)
        			{
        				_maKyTinhLuong = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaKyTinhLuong");
        				On_MaKyTinhLuong_Changed(oldValue, _maKyTinhLuong);//\\
        			}
                }
            }
        }
    	public static String MaKyTinhLuong_PropertyName { get { return "MaKyTinhLuong"; } }
        private int _maKyTinhLuong;
        partial void On_MaKyTinhLuong_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaKyTinhLuong_Changed(int oldValue, int currentValue);
    
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
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongThuNhap
        {
            get
            {
                return _tongThuNhap;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThuNhap;
    			bool stopChanging = false;
                On_TongThuNhap_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThuNhap");
    			if(!stopChanging)
    			{
    				_tongThuNhap = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThuNhap");
    				On_TongThuNhap_Changed(oldValue, _tongThuNhap);//\\
    			}
            }
        }
    	public static String TongThuNhap_PropertyName { get { return "TongThuNhap"; } }
        private Nullable<decimal> _tongThuNhap;
        partial void On_TongThuNhap_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThuNhap_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> GiamTru
        {
            get
            {
                return _giamTru;
            }
            set
            {
    			Nullable<decimal> oldValue =  _giamTru;
    			bool stopChanging = false;
                On_GiamTru_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("GiamTru");
    			if(!stopChanging)
    			{
    				_giamTru = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("GiamTru");
    				On_GiamTru_Changed(oldValue, _giamTru);//\\
    			}
            }
        }
    	public static String GiamTru_PropertyName { get { return "GiamTru"; } }
        private Nullable<decimal> _giamTru;
        partial void On_GiamTru_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_GiamTru_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueTNCN
        {
            get
            {
                return _thueTNCN;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueTNCN;
    			bool stopChanging = false;
                On_ThueTNCN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueTNCN");
    			if(!stopChanging)
    			{
    				_thueTNCN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueTNCN");
    				On_ThueTNCN_Changed(oldValue, _thueTNCN);//\\
    			}
            }
        }
    	public static String ThueTNCN_PropertyName { get { return "ThueTNCN"; } }
        private Nullable<decimal> _thueTNCN;
        partial void On_ThueTNCN_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueTNCN_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThueTamThu
        {
            get
            {
                return _thueTamThu;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thueTamThu;
    			bool stopChanging = false;
                On_ThueTamThu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThueTamThu");
    			if(!stopChanging)
    			{
    				_thueTamThu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThueTamThu");
    				On_ThueTamThu_Changed(oldValue, _thueTamThu);//\\
    			}
            }
        }
    	public static String ThueTamThu_PropertyName { get { return "ThueTamThu"; } }
        private Nullable<decimal> _thueTamThu;
        partial void On_ThueTamThu_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThueTamThu_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> ThuePhaiThu
        {
            get
            {
                return _thuePhaiThu;
            }
            set
            {
    			Nullable<decimal> oldValue =  _thuePhaiThu;
    			bool stopChanging = false;
                On_ThuePhaiThu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ThuePhaiThu");
    			if(!stopChanging)
    			{
    				_thuePhaiThu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("ThuePhaiThu");
    				On_ThuePhaiThu_Changed(oldValue, _thuePhaiThu);//\\
    			}
            }
        }
    	public static String ThuePhaiThu_PropertyName { get { return "ThuePhaiThu"; } }
        private Nullable<decimal> _thuePhaiThu;
        partial void On_ThuePhaiThu_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_ThuePhaiThu_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaChungTuDeNghi
        {
            get
            {
                return _maChungTuDeNghi;
            }
            set
            {
    			Nullable<long> oldValue =  _maChungTuDeNghi;
    			bool stopChanging = false;
                On_MaChungTuDeNghi_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaChungTuDeNghi");
    			if(!stopChanging)
    			{
    				_maChungTuDeNghi = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaChungTuDeNghi");
    				On_MaChungTuDeNghi_Changed(oldValue, _maChungTuDeNghi);//\\
    			}
            }
        }
    	public static String MaChungTuDeNghi_PropertyName { get { return "MaChungTuDeNghi"; } }
        private Nullable<long> _maChungTuDeNghi;
        partial void On_MaChungTuDeNghi_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaChungTuDeNghi_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
                if (_ngayLap != value)
                {
        			System.DateTime oldValue =  _ngayLap;
        			bool stopChanging = false;
                    On_NgayLap_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("NgayLap");
        			if(!stopChanging)
        			{
        				_ngayLap = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("NgayLap");
        				On_NgayLap_Changed(oldValue, _ngayLap);//\\
        			}
                }
            }
        }
    	public static String NgayLap_PropertyName { get { return "NgayLap"; } }
        private System.DateTime _ngayLap;
        partial void On_NgayLap_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_NgayLap_Changed(System.DateTime oldValue, System.DateTime currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
            set
            {
                if (_nguoiLap != value)
                {
        			int oldValue =  _nguoiLap;
        			bool stopChanging = false;
                    On_NguoiLap_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("NguoiLap");
        			if(!stopChanging)
        			{
        				_nguoiLap = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("NguoiLap");
        				On_NguoiLap_Changed(oldValue, _nguoiLap);//\\
        			}
                }
            }
        }
    	public static String NguoiLap_PropertyName { get { return "NguoiLap"; } }
        private int _nguoiLap;
        partial void On_NguoiLap_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_NguoiLap_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TamThuKhac
        {
            get
            {
                return _tamThuKhac;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tamThuKhac;
    			bool stopChanging = false;
                On_TamThuKhac_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TamThuKhac");
    			if(!stopChanging)
    			{
    				_tamThuKhac = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TamThuKhac");
    				On_TamThuKhac_Changed(oldValue, _tamThuKhac);//\\
    			}
            }
        }
    	public static String TamThuKhac_PropertyName { get { return "TamThuKhac"; } }
        private Nullable<decimal> _tamThuKhac;
        partial void On_TamThuKhac_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TamThuKhac_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<decimal> TongThu
        {
            get
            {
                return _tongThu;
            }
            set
            {
    			Nullable<decimal> oldValue =  _tongThu;
    			bool stopChanging = false;
                On_TongThu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("TongThu");
    			if(!stopChanging)
    			{
    				_tongThu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("TongThu");
    				On_TongThu_Changed(oldValue, _tongThu);//\\
    			}
            }
        }
    	public static String TongThu_PropertyName { get { return "TongThu"; } }
        private Nullable<decimal> _tongThu;
        partial void On_TongThu_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging);
        partial void On_TongThu_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
            set
            {
    			string oldValue =  _dienGiai;
    			bool stopChanging = false;
                On_DienGiai_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DienGiai");
    			if(!stopChanging)
    			{
    				_dienGiai = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("DienGiai");
    				On_DienGiai_Changed(oldValue, _dienGiai);//\\
    			}
            }
        }
    	public static String DienGiai_PropertyName { get { return "DienGiai"; } }
        private string _dienGiai;
        partial void On_DienGiai_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_DienGiai_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> DaThu
        {
            get
            {
                return _daThu;
            }
            set
            {
    			Nullable<bool> oldValue =  _daThu;
    			bool stopChanging = false;
                On_DaThu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("DaThu");
    			if(!stopChanging)
    			{
    				_daThu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("DaThu");
    				On_DaThu_Changed(oldValue, _daThu);//\\
    			}
            }
        }
    	public static String DaThu_PropertyName { get { return "DaThu"; } }
        private Nullable<bool> _daThu;
        partial void On_DaThu_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_DaThu_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> SoNPT
        {
            get
            {
                return _soNPT;
            }
            set
            {
    			Nullable<int> oldValue =  _soNPT;
    			bool stopChanging = false;
                On_SoNPT_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("SoNPT");
    			if(!stopChanging)
    			{
    				_soNPT = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("SoNPT");
    				On_SoNPT_Changed(oldValue, _soNPT);//\\
    			}
            }
        }
    	public static String SoNPT_PropertyName { get { return "SoNPT"; } }
        private Nullable<int> _soNPT;
        partial void On_SoNPT_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_SoNPT_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

    }
}

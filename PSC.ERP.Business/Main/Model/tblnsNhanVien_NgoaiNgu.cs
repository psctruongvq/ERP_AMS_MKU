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
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="tblnsNhanVien_NgoaiNgu")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblnsNhanVien_NgoaiNgu : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public tblnsNhanVien_NgoaiNgu()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new tblnsNhanVien_NgoaiNgu object.
        /// </summary>
        /// <param name="maNhanVien_NgoaiNgu">Initial value of the MaNhanVien_NgoaiNgu property.</param>
        public static tblnsNhanVien_NgoaiNgu CreatetblnsNhanVien_NgoaiNgu(int maNhanVien_NgoaiNgu)
        {
            tblnsNhanVien_NgoaiNgu tblnsNhanVien_NgoaiNgu = new tblnsNhanVien_NgoaiNgu();
            tblnsNhanVien_NgoaiNgu.MaNhanVien_NgoaiNgu = maNhanVien_NgoaiNgu;
            return tblnsNhanVien_NgoaiNgu;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public int MaNhanVien_NgoaiNgu
        {
            get
            {
                return _maNhanVien_NgoaiNgu;
            }
            set
            {
                if (_maNhanVien_NgoaiNgu != value)
                {
        			int oldValue =  _maNhanVien_NgoaiNgu;
        			bool stopChanging = false;
                    On_MaNhanVien_NgoaiNgu_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("MaNhanVien_NgoaiNgu");
        			if(!stopChanging)
        			{
        				_maNhanVien_NgoaiNgu = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("MaNhanVien_NgoaiNgu");
        				On_MaNhanVien_NgoaiNgu_Changed(oldValue, _maNhanVien_NgoaiNgu);//\\
        			}
                }
            }
        }
    	public static String MaNhanVien_NgoaiNgu_PropertyName { get { return "MaNhanVien_NgoaiNgu"; } }
        private int _maNhanVien_NgoaiNgu;
        partial void On_MaNhanVien_NgoaiNgu_Changing(int currentValue, ref int newValue, ref bool stopChanging);
        partial void On_MaNhanVien_NgoaiNgu_Changed(int oldValue, int currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<long> MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
    			Nullable<long> oldValue =  _maNhanVien;
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
    	public static String MaNhanVien_PropertyName { get { return "MaNhanVien"; } }
        private Nullable<long> _maNhanVien;
        partial void On_MaNhanVien_Changing(Nullable<long> currentValue, ref Nullable<long> newValue, ref bool stopChanging);
        partial void On_MaNhanVien_Changed(Nullable<long> oldValue, Nullable<long> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaNgoaiNgu
        {
            get
            {
                return _maNgoaiNgu;
            }
            set
            {
    			Nullable<int> oldValue =  _maNgoaiNgu;
    			bool stopChanging = false;
                On_MaNgoaiNgu_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaNgoaiNgu");
    			if(!stopChanging)
    			{
    				_maNgoaiNgu = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaNgoaiNgu");
    				On_MaNgoaiNgu_Changed(oldValue, _maNgoaiNgu);//\\
    			}
            }
        }
    	public static String MaNgoaiNgu_PropertyName { get { return "MaNgoaiNgu"; } }
        private Nullable<int> _maNgoaiNgu;
        partial void On_MaNgoaiNgu_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaNgoaiNgu_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaTrinhDoNN
        {
            get
            {
                return _maTrinhDoNN;
            }
            set
            {
    			Nullable<int> oldValue =  _maTrinhDoNN;
    			bool stopChanging = false;
                On_MaTrinhDoNN_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaTrinhDoNN");
    			if(!stopChanging)
    			{
    				_maTrinhDoNN = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaTrinhDoNN");
    				On_MaTrinhDoNN_Changed(oldValue, _maTrinhDoNN);//\\
    			}
            }
        }
    	public static String MaTrinhDoNN_PropertyName { get { return "MaTrinhDoNN"; } }
        private Nullable<int> _maTrinhDoNN;
        partial void On_MaTrinhDoNN_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaTrinhDoNN_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<bool> NgoaiNguChinh
        {
            get
            {
                return _ngoaiNguChinh;
            }
            set
            {
    			Nullable<bool> oldValue =  _ngoaiNguChinh;
    			bool stopChanging = false;
                On_NgoaiNguChinh_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NgoaiNguChinh");
    			if(!stopChanging)
    			{
    				_ngoaiNguChinh = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("NgoaiNguChinh");
    				On_NgoaiNguChinh_Changed(oldValue, _ngoaiNguChinh);//\\
    			}
            }
        }
    	public static String NgoaiNguChinh_PropertyName { get { return "NgoaiNguChinh"; } }
        private Nullable<bool> _ngoaiNguChinh;
        partial void On_NgoaiNguChinh_Changing(Nullable<bool> currentValue, ref Nullable<bool> newValue, ref bool stopChanging);
        partial void On_NgoaiNguChinh_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> MaQuaTrinhDaoTao
        {
            get
            {
                return _maQuaTrinhDaoTao;
            }
            set
            {
    			Nullable<int> oldValue =  _maQuaTrinhDaoTao;
    			bool stopChanging = false;
                On_MaQuaTrinhDaoTao_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MaQuaTrinhDaoTao");
    			if(!stopChanging)
    			{
    				_maQuaTrinhDaoTao = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("MaQuaTrinhDaoTao");
    				On_MaQuaTrinhDaoTao_Changed(oldValue, _maQuaTrinhDaoTao);//\\
    			}
            }
        }
    	public static String MaQuaTrinhDaoTao_PropertyName { get { return "MaQuaTrinhDaoTao"; } }
        private Nullable<int> _maQuaTrinhDaoTao;
        partial void On_MaQuaTrinhDaoTao_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_MaQuaTrinhDaoTao_Changed(Nullable<int> oldValue, Nullable<int> currentValue);

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    [TypeConverter(typeof(NuocSanXuatTypeConverter))]
    public class NuocSanXuat: BusinessBase<NuocSanXuat>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaNuocSX;
        }
        public override string ToString()
        {
            return _TenNuocSX;
        }
        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaNuocQL");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenNuocSX");
        }
        #endregion

        #region Properties

        int _MaNuocSX;
        public int MaNuocSX
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;
                    if (Parent == null) return 0;
                    NuocSanXuatList parent = (NuocSanXuatList)this.Parent;
                    int max = 0;
                    foreach (NuocSanXuat item in parent)
                    {
                        if (item.MaNuocSX > max)
                            max = item.MaNuocSX;
                    }
                    _MaNuocSX = max + 1;
                }
                return _MaNuocSX;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNuocSX.Equals(value))
                {
                    _MaNuocSX = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaNuocQL;
        public String MaNuocQL
        {
            get
            {
                CanReadProperty(true);
                return _MaNuocQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNuocQL.Equals(value))
                {
                    _MaNuocQL = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenNuocSX;
        public String TenNuocSX
        {
            get
            {
                CanReadProperty(true);
                return _TenNuocSX;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenNuocSX.Equals(value))
                {
                    _TenNuocSX = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenVietTat;
        public String TenVietTat
        {
            get
            {
                CanReadProperty(true);
                return _TenVietTat;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenVietTat.Equals(value))
                {
                    _TenVietTat = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai;
        public String DienGiai
        {
            get
            {
                CanReadProperty(true);
                return _DienGiai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DienGiai.Equals(value))
                {
                    _DienGiai = value;
                    PropertyHasChanged();
                }
            }
        }
        
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaNuocSX;

            public Criteria(int maNuocSX)
            {
                MaNuocSX = maNuocSX;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override NuocSanXuat Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNuocSX));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    

        private NuocSanXuat(SafeDataReader dr)
        {
            MarkAsChild();
            _MaNuocSX = dr.GetInt32("MaQuocGia");
            _MaNuocQL = dr.GetString("MaQuocGiaQuanLy");
            _TenNuocSX = dr.GetString("TenQuocGia");
            _TenVietTat = dr.GetString("TenVietTat");
            _DienGiai = dr.GetString("DienGiai");
            _idSet = true;
            MarkOld();
        }

        public static NuocSanXuat NewNuocSanXuat()
        {
            NuocSanXuat nsx = new NuocSanXuat();
            nsx.MaNuocSX = 0;
            nsx.TenNuocSX = String.Empty;
            nsx.MaNuocQL = String.Empty;
            nsx.TenVietTat = String.Empty;
            nsx.DienGiai = String.Empty;
            nsx.MarkDirty();
            nsx.ValidationRules.CheckRules();
            return nsx;
        }

        public static NuocSanXuat NewNuocSanXuat(string tenNuocSX, string maNuocQL)
        {
            NuocSanXuat nsx = new NuocSanXuat();            
            nsx._TenNuocSX = tenNuocSX;
            nsx._MaNuocQL = maNuocQL;
            nsx.MarkDirty();
            nsx.ValidationRules.CheckRules();
            return nsx;
        }

        public static NuocSanXuat GetNuocSanXuat(int manuocSX)
        {
            if (manuocSX == 0) return new NuocSanXuat();
            return (NuocSanXuat)DataPortal.Fetch<NuocSanXuat>(new Criteria(manuocSX));
        }

        internal static NuocSanXuat GetNuocSanXuat(SafeDataReader dr)
        {
            return new NuocSanXuat(dr);
        }

        public static void DeleteNuocSanXuat(int maNuocSX)
        {
            DataPortal.Delete(new Criteria(maNuocSX));
        }

        #endregion

        #region Constructors

        private NuocSanXuat()
        {
            // Prevent direct creation
            _MaNuocSX = 0;
            _TenNuocSX = String.Empty;
            _MaNuocQL = String.Empty;
            MarkAsChild();
        }

        #endregion

        #region Data Access

        #region load tất cả cả
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {

                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_QuocGia";
                        cm.Parameters.AddWithValue("@MaNuoc", crit.MaNuocSX);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaNuocSX = dr.GetInt32("MaQuocGia");
                                _MaNuocQL = dr.GetString("MaQuocGiaQuanLy");
                                _TenNuocSX = dr.GetString("TenQuocGia");
                                _TenVietTat = dr.GetString("TenVietTat");
                                _DienGiai = dr.GetString("DienGiai");
                                _idSet = true;
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_QuocGia";
                    cm.Parameters.AddWithValue("@MaNuocQL", _MaNuocQL);
                    cm.Parameters.AddWithValue("@TenNuoc", _TenNuocSX);
                    cm.Parameters.AddWithValue("@TenVietTat", _TenVietTat);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    cm.ExecuteNonQuery();
                }
            }
        }
        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_QuocGia";
                    cm.Parameters.AddWithValue("@MaNuoc", _MaNuocSX);
                    cm.Parameters.AddWithValue("@TenNuoc", _TenNuocSX);
                    cm.Parameters.AddWithValue("@MaNuocQL", _MaNuocQL);
                    cm.Parameters.AddWithValue("@TenVietTat", _TenVietTat);
                    cm.Parameters.AddWithValue("@DienGiai", _DienGiai);
                    cm.ExecuteNonQuery();
                    // make sure we're marked as an old object
                    MarkOld();
                }
            }
        }

        #region Delete

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_QuocGia";
                    cm.Parameters.AddWithValue("@MaNuoc", crit.MaNuocSX);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNuocSX));
        }
        #endregion
        #endregion

        #endregion
    }

    #region Type Converter

    public class NuocSanXuatTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return NuocSanXuat.GetNuocSanXuat((int)giatri);
        }
        
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((NuocSanXuat)value).MaNuocSX;
            }
            if (destinationType == typeof(String))
            {
                return ((NuocSanXuat)value).TenNuocSX;
            }
            if (destinationType == typeof(Object))
            {
                return ((NuocSanXuat)value).MaNuocQL;
            }

            return value;
        }
        
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return true;
            }
            else if (destinationType == typeof(String))
            {
                return true;
            }
            else if (destinationType == typeof(Object))
            {
                return true;
            }
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(Int32))
            {
                return true;
            }
            else return false;
        }
    }
    #endregion 
}

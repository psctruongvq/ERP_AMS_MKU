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
    [TypeConverter(typeof(NhomTaiSanTypeConverter))]
    public class NhomTaiSan: BusinessBase<NhomTaiSan>
    {
        private bool _idSet;

        protected override object GetIdValue()
        {
            return _MaNhom;
        }
        public override string ToString()
        {
            return _TenNhom;
        }

        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaNhomQuanLy");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenNhom");            
        }
        #endregion

        #region Properties

        int _MaNhom;
        public int MaNhom
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    NhomTaiSanList parent = (NhomTaiSanList)this.Parent;
                    int max = 0;
                    if (Parent == null) return 0;
                    foreach (NhomTaiSan item in parent)
                    {
                        if (item.MaNhom > max)
                            max = item.MaNhom;
                    }
                    _MaNhom = max + 1;
                }
                return _MaNhom;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNhom.Equals(value))
                {
                    _MaNhom = value;
                    PropertyHasChanged();
                }
            }
        }

        
        String _TenNhom;
        public String TenNhom
        {
            get
            {
                CanReadProperty(true);
                return _TenNhom;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenNhom.Equals(value))
                {
                    _TenNhom = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaNhomQuanLy;
        public String MaNhomQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _MaNhomQuanLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNhomQuanLy.Equals(value))
                {
                    _MaNhomQuanLy = value;
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
            public int MaNhom;

            public Criteria(int maNhom)
            {
                MaNhom = maNhom;
            }
        }

        #endregion

        #region Constructors

        private NhomTaiSan()
        {
            // Prevent direct creation
            _TenNhom = String.Empty;
            _MaNhomQuanLy = String.Empty;
            MarkAsChild();
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override NhomTaiSan Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNhom));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    

        private NhomTaiSan(SafeDataReader dr)
        {
            MarkAsChild();           
            _MaNhom = dr.GetInt32("MaNhomTaiSan");
            _TenNhom = dr.GetString("TenNhomTaiSan");
            _MaNhomQuanLy = dr.GetString("MaNhomQuanLy");
            _idSet = true;
            MarkOld();
        }

        public static NhomTaiSan NewNhomTaiSan()
        {
            NhomTaiSan nts = new NhomTaiSan();
            nts.TenNhom = String.Empty;
            nts.MaNhomQuanLy = String.Empty;
            nts.MarkDirty();
            nts.ValidationRules.CheckRules();
            return nts;
        }

        public static NhomTaiSan NewNhomTaiSan(string tenNhomTaiSan, string maNhomQuanLy)
        {
            NhomTaiSan nts = new NhomTaiSan();            
            nts._TenNhom = tenNhomTaiSan;
            nts._MaNhomQuanLy = maNhomQuanLy;
            nts.MarkDirty();
            nts.ValidationRules.CheckRules();    
            return nts;
        }

        public static NhomTaiSan GetNhomTaiSan(int maNhom)
        {
            if (maNhom == 0) return new NhomTaiSan();
            return (NhomTaiSan)DataPortal.Fetch<NhomTaiSan>(new Criteria(maNhom));
        }

        internal static NhomTaiSan GetNhomTaiSan(SafeDataReader dr)
        {
            return new NhomTaiSan(dr);
        }

        public static void DeleteNhomTaiSan(int maNhom)
        {
            DataPortal.Delete(new Criteria(maNhom));
        }

        #endregion

        #region Data Access

        #region load tất cả cả
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_NhomTaiSan";
                    cm.Parameters.AddWithValue("@MaNhomTaiSan", crit.MaNhom);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaNhom = dr.GetInt32("MaNhomTaiSan");
                            _TenNhom = dr.GetString("TenNhomTaiSan");
                            _MaNhomQuanLy = dr.GetString("MaNhomQuanLy");
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
                MarkOld();
            }
        }

        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NhomTaiSan";
                        cm.Parameters.AddWithValue("@TenNhomTaiSan", _TenNhom);
                        cm.Parameters.AddWithValue("@MaNhomQuanLy", _MaNhomQuanLy);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_NhomTaiSan";
                        cm.Parameters.AddWithValue("@MaNhomTaiSan", _MaNhom);
                        cm.Parameters.AddWithValue("@TenNhomTaiSan", _TenNhom);
                        cm.Parameters.AddWithValue("@MaNhomQuanLy", _MaNhomQuanLy);

                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
                    cm.CommandText = "spd_Delete_NhomTaiSan";
                    cm.Parameters.AddWithValue("@MaNhomTaiSan", crit.MaNhom);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNhom));
        }
        #endregion

        #endregion

        #endregion
    }
    #region Type Converter

    public class NhomTaiSanTypeConverter : TypeConverter
    {

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return NhomTaiSan.GetNhomTaiSan((int)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((NhomTaiSan)value).MaNhom;
            }
            if (destinationType == typeof(String))
            {
                return ((NhomTaiSan)value).TenNhom;
            }
            if (destinationType == typeof(Object))
            {
                return ((NhomTaiSan)value).MaNhom;
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

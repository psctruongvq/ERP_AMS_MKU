using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    [TypeConverter(typeof(LoaiTaiSanTypeConverter))]
    public class LoaiTaiSan:BusinessBase<LoaiTaiSan>
    {
        private bool _idSet;

        protected override object GetIdValue()
        {
            return _MaLoaiTaiSan;
        }
        public override string ToString()
        {
            return _TenLoaiTaiSan;
        }

        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaLoaiQuanLy");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenLoaiTaiSan");            
        }
        #endregion

        #region Properties

        int _MaLoaiTaiSan;
        public int MaLoaiTaiSan
        {
            get
            {
                CanReadProperty(true);
                //if (!_idSet)
                //{
                //    //generate a default id value
                //    _idSet = true;
                //    if (Parent == null) return 0;
                //    LoaiTaiSanList parent = (LoaiTaiSanList)this.Parent;
                //    //int max = 0;
                //    //foreach (LoaiTaiSan item in parent)
                //    //{
                //    //    if (item.MaLoaiTaiSan > max)
                //    //        max = item.MaLoaiTaiSan;
                //    //}
                //    //_MaLoaiTaiSan = max + 1;
                //}
                return _MaLoaiTaiSan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiTaiSan.Equals(value))
                {
                    _MaLoaiTaiSan = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenLoaiTaiSan;
        public String TenLoaiTaiSan
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiTaiSan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenLoaiTaiSan.Equals(value))
                {
                    _TenLoaiTaiSan = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaNhomTaiSan;
        public int MaNhomTaiSan
        {
            get
            {
                CanReadProperty(true);
                return _MaNhomTaiSan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNhomTaiSan.Equals(value))
                {
                    _MaNhomTaiSan = value;
                    PropertyHasChanged();
                }
            }
        }
        
        String _MaLoaiQuanLy;
        public String MaLoaiQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _MaLoaiQuanLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiQuanLy.Equals(value))
                {
                    _MaLoaiQuanLy = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaLoaiTaiSanCha;
        public int MaLoaiTaiSanCha
        {
            get
            {
                CanReadProperty(true);
                return _MaLoaiTaiSanCha;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiTaiSanCha.Equals(value))
                {
                    _MaLoaiTaiSanCha = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenNhomTaiSan;
        public String TenNhomTaiSan
        {
            get
            {
                CanReadProperty(true);
                return _TenNhomTaiSan;
            }            
        }

        String _TenLoaiTaiSanCha;
        public String TenLoaiTaiSanCha
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiTaiSanCha;
                //return LoaiTaiSan.GetLoaiTaiSan(_MaLoaiTaiSanCha)._TenLoaiTaiSan;
            }
        }
        
        #endregion

        #region constructor

        private LoaiTaiSan()
        {
            // Prevent direct creation
            _MaLoaiTaiSan = 0;
            _TenLoaiTaiSan = String.Empty;
            _MaNhomTaiSan = 0; 
            _MaLoaiQuanLy = String.Empty;
            _MaLoaiTaiSanCha = 0;
            _TenLoaiTaiSanCha = String.Empty;
            _TenNhomTaiSan = String.Empty;
            MarkAsChild();
        }
       
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaLoaiTaiSan;

            public Criteria(int maLoaiTaiSan)
            {
                MaLoaiTaiSan = maLoaiTaiSan;
            }
        }

        #endregion

        #region Static Methods

        public override LoaiTaiSan Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiTaiSan));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    
         
        private LoaiTaiSan(SafeDataReader dr)
        {
            MarkAsChild();           
            _MaLoaiTaiSan = dr.GetInt32("MaLoaiTaiSan");
            _TenLoaiTaiSan = dr.GetString("TenLoaiTaiSan");
            _TenNhomTaiSan= dr.GetString("TenNhomTaiSan");
            _MaNhomTaiSan= dr.GetInt32("MaNhomTaiSan");
            _MaLoaiQuanLy = dr.GetString("MaLoaiQuanLy");
            _MaLoaiTaiSanCha = dr.GetInt32("MaLoaiTaiSanCha");
            _TenLoaiTaiSanCha = dr.GetString("TenLoaiTaiSanCha");
            _idSet = true;
            MarkOld();
        }

        public static LoaiTaiSan NewLoaiTaiSan()
        {
            LoaiTaiSan lts = new LoaiTaiSan();
            lts.TenLoaiTaiSan = String.Empty;
            lts.MaNhomTaiSan = 0;
            lts.MaLoaiQuanLy = String.Empty;
            lts.MarkDirty();
            lts.ValidationRules.CheckRules();
            return lts;
        }

        public static LoaiTaiSan NewLoaiTaiSan(string tenLoaiTaiSan, string MaLoaiTaiSanQL, int maLoai)
        {
            LoaiTaiSan lts = new LoaiTaiSan();
            lts.TenLoaiTaiSan = tenLoaiTaiSan;
            lts.MaLoaiQuanLy = MaLoaiTaiSanQL;
            lts.MaLoaiTaiSan = maLoai;
            lts.MaLoaiTaiSan = 0;
            return lts;
        }

        public static LoaiTaiSan NewLoaiTaiSan(string tenLoaiTaiSan, int maNhomTaiSan, string maLoaiQuanLy, int MaLoaiTaiSanCha)
        {
            LoaiTaiSan lts = new LoaiTaiSan();
            lts._TenLoaiTaiSan = tenLoaiTaiSan;
            lts._MaNhomTaiSan = maNhomTaiSan;
            lts._MaLoaiQuanLy = maLoaiQuanLy;
            lts._MaLoaiTaiSanCha = MaLoaiTaiSanCha;
            lts.MarkDirty();
            lts.ValidationRules.CheckRules();
            return lts;
        }

        public static LoaiTaiSan GetLoaiTaiSan(int maLoaiTaiSan)
        {
            if (maLoaiTaiSan == 0) return new LoaiTaiSan();
            return (LoaiTaiSan)DataPortal.Fetch<LoaiTaiSan>(new Criteria(maLoaiTaiSan));
        }

        public static LoaiTaiSan GetLoaiTaiSan(SafeDataReader dr)
        {
            return new LoaiTaiSan(dr);            
        }

        public static void DeleteLoaiTaiSan(int maLoaiTaiSan)
        {
            DataPortal.Delete(new Criteria(maLoaiTaiSan));
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
                        cm.CommandText = "spd_LoadMaCaBiet_LoaiTaiSan";
                        cm.Parameters.AddWithValue("@MaLoaiTaiSan", crit.MaLoaiTaiSan);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaLoaiTaiSan = dr.GetInt32("MaLoaiTaiSan");
                                _TenLoaiTaiSan = dr.GetString("TenLoaiTaiSan");
                                _TenNhomTaiSan = dr.GetString("TenNhomTaiSan");
                                _MaNhomTaiSan = dr.GetInt32("MaNhomTaiSan");
                                _MaLoaiQuanLy = dr.GetString("MaLoaiQuanLy");
                                _MaLoaiTaiSanCha = dr.GetInt32("MaLoaiTaiSanCha");
                                _TenLoaiTaiSanCha = dr.GetString("TenLoaiTaiSanCha");
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
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_LoaiTaiSan";
                        cm.Parameters.AddWithValue("@MaLoaiTaiSan", _MaLoaiTaiSan);
                        cm.Parameters.AddWithValue("@TenLoaitaiSan", _TenLoaiTaiSan);
                        if(_MaNhomTaiSan !=0 )
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", _MaNhomTaiSan);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", DBNull.Value);
                        cm.Parameters.AddWithValue("@MaLoaiQuanLy", _MaLoaiQuanLy);
                        if(_MaLoaiTaiSanCha !=0)
                            cm.Parameters.AddWithValue("@MaLoaiTaiSanCha", _MaLoaiTaiSanCha);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTaiSanCha", DBNull.Value);
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
                        cm.CommandText = "spd_Update_LoaiTaiSan";
                        cm.Parameters.AddWithValue("@MaLoaiTaiSan", _MaLoaiTaiSan);
                        cm.Parameters.AddWithValue("@TenLoaiTaiSan", _TenLoaiTaiSan);
                        if (_MaNhomTaiSan != 0)
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", _MaNhomTaiSan);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", DBNull.Value);                        
                        cm.Parameters.AddWithValue("@MaLoaiQuanLy", _MaLoaiQuanLy);
                        cm.Parameters.AddWithValue("@MaLoaiTaiSanCha", _MaLoaiTaiSanCha);
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
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_LoaiTaiSan";
                        cm.Parameters.AddWithValue("@MaLoaiTaiSan", crit.MaLoaiTaiSan);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiTaiSan));
        }

        #endregion

        #endregion

        #endregion
    }
    #region Type Converter

    public class LoaiTaiSanTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return LoaiTaiSan.GetLoaiTaiSan((int)giatri);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((LoaiTaiSan)value).MaLoaiTaiSan;
            }
            if (destinationType == typeof(String))
            {
                return ((LoaiTaiSan)value).TenLoaiTaiSan;
            }
            if (destinationType == typeof(Object))
            {
                return ((LoaiTaiSan)value).MaLoaiTaiSan;
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

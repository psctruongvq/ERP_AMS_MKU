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
    [TypeConverter(typeof(TieuNhomTypeConverter))]
    public class TieuNhom: BusinessBase<TieuNhom>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaTieuNhom;
        }
        public override string ToString()
        {
            return _TenTieuNhom;
        }
        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaTieuNhomQL");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenTieuNhom");
        }
        #endregion

        #region Khai báo biến

        int _MaTieuNhom;
        public int MaTieuNhom
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;
                    int max = 0;
                    if (this.Parent == null) return 0;
                    TieuNhomNganSachList parent = (TieuNhomNganSachList)this.Parent;
                    foreach (TieuNhomNganSach item in parent)
                    {
                        if (item.MaTieuNhom > max)
                            max = item.MaTieuNhom;
                    }
                    _MaTieuNhom = max + 1;
                }
                return _MaTieuNhom;

            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTieuNhom.Equals(value))
                {
                    _MaTieuNhom = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaTieuNhomQL;
        public String MaTieuNhomQL
        {
            get
            {
                CanReadProperty(true);
                return _MaTieuNhomQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTieuNhomQL.Equals(value))
                {
                    _MaTieuNhomQL = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenTieuNhom;
        public String TenTieuNhom
        {
            get
            {
                CanReadProperty(true);
                return _TenTieuNhom;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTieuNhom.Equals(value))
                {
                    _TenTieuNhom = value;
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
            public int MaTieuNhom;

            public Criteria(int maTieuNhom)
            {
                MaTieuNhom = maTieuNhom;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override TieuNhom Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaTieuNhom));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    

        private TieuNhom(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaTieuNhom = dr.GetInt32("MaTieuNhom");
                _MaTieuNhomQL = dr.GetString("MaTieuNhomQL");
                _TenTieuNhom = dr.GetString("TenTieuNhom");
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static TieuNhom NewTieuNhom()
        {
            TieuNhom tn = new TieuNhom();
            tn.MaTieuNhom = 0;
            tn.MaTieuNhomQL = String.Empty;
            tn.TenTieuNhom = String.Empty;
            tn.MarkDirty();
            tn.ValidationRules.CheckRules();
            return tn;
        }

        public static TieuNhom NewTieuNhom(string maTieuNhomQL, string tenTieuNhom)
        {
            TieuNhom tn = new TieuNhom();
            tn._MaTieuNhomQL = maTieuNhomQL;
            tn._TenTieuNhom = tenTieuNhom;
            tn.MarkDirty();
            tn.ValidationRules.CheckRules();
            return tn;
        }

        public static TieuNhom GetTieuNhom(int maTieuNhom)
        {
            if (maTieuNhom == 0) return TieuNhom.NewTieuNhom();
            return (TieuNhom)DataPortal.Fetch<TieuNhom>(new Criteria(maTieuNhom));
        }

        public static TieuNhom GetTieuNhom(SafeDataReader dr)
        {
            return new TieuNhom(dr);
        }

        public static void DeleteTieuNhom(int maTieuNhom)
        {
            DataPortal.Delete(new Criteria(maTieuNhom));
        }

        #endregion

        #region Constructors

        private TieuNhom()
        {
            // Prevent direct creation
            _MaTieuNhom = 0;
            _MaTieuNhomQL = String.Empty;
            _TenTieuNhom = String.Empty;
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
                        cm.CommandText = "spd_LoadMaCaBiet_TieuNhomNganSach";
                        cm.Parameters.AddWithValue("@MaTieuNhom", crit.MaTieuNhom);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            _MaTieuNhom = dr.GetInt32("MaTieuNhom");
                            _MaTieuNhomQL = dr.GetString("MaTieuNhomQL");
                            _TenTieuNhom = dr.GetString("TenTieuNhom");
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
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
                        cm.CommandText = "spd_Insert_TieuNhomNganSach";
                        cm.Parameters.AddWithValue("@MaTieuNhom", _MaTieuNhom).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTieuNhomQL", _MaTieuNhomQL);
                        cm.Parameters.AddWithValue("@TenTieuNhom", _TenTieuNhom);
                        cm.ExecuteNonQuery();
                        MarkOld();
                        _MaTieuNhom = (Int32)cm.Parameters["@MaTieuNhom"].Value;
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
                        cm.CommandText = "spd_Update_TieuNhomNganSach";
                        cm.Parameters.AddWithValue("@MaTieuNhom", _MaTieuNhom);
                        cm.Parameters.AddWithValue("@TenTieuNhom", _TenTieuNhom);
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
                        cm.CommandText = "spd_Delete_TieuNhomNganSach";
                        cm.Parameters.AddWithValue("@MaTieuNhom", crit.MaTieuNhom);
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
            DataPortal_Delete(new Criteria(_MaTieuNhom));
        }
        #endregion

        #endregion

        #endregion
    }
    #region Type Converter

    public class TieuNhomTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return TieuNhom.GetTieuNhom((int)giatri);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return ((TieuNhom)value).MaTieuNhom;
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

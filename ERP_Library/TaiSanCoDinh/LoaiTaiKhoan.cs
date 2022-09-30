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
    [TypeConverter(typeof(LoaiTaiKhoanTypeConverter))]
    public class LoaiTaiKhoan :BusinessBase<LoaiTaiKhoan>
    {
        Boolean _idSet;
        protected override object GetIdValue()
        {
            return _MaLoaiTK;
        }

        public override string ToString()
        {
            return _TenLoaiTK;
        }
        #region Khai báo biến

        int _MaLoaiTK;
        public int MaLoaiTK
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    if (Parent == null) return 0;
                    LoaiTaiKhoanList parent = (LoaiTaiKhoanList)this.Parent;
                    int max = 0;
                    foreach (LoaiTaiKhoan item in parent)
                    {
                        if (item.MaLoaiTK > max)
                            max = item.MaLoaiTK;
                    }
                    _MaLoaiTK = max + 1;
                }
                return _MaLoaiTK;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiTK.Equals(value))
                {
                    _MaLoaiTK = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaLoaiTKQL;
        public String MaLoaiTKQL
        {
            get
            {
                CanReadProperty(true);
                return _MaLoaiTKQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiTKQL.Equals(value))
                {
                    _MaLoaiTKQL = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenLoaiTK;
        public String TenLoaiTK
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiTK;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenLoaiTK.Equals(value))
                {
                    _TenLoaiTK = value;
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
            public int MaLoaiTaiKhoan;

            public Criteria(int maLoaiTaiKhoan)
            {
                MaLoaiTaiKhoan = maLoaiTaiKhoan;
            }
        }

        #endregion

        #region Constructors

        private LoaiTaiKhoan()
        {
            _MaLoaiTK = 0;
            _MaLoaiTKQL = String.Empty;
            _TenLoaiTK = String.Empty;
            MarkAsChild();
        }

        #endregion 

        #region Static Methods

        public override LoaiTaiKhoan Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiTK));
        
        }
        public void Insert()
        {
            DataPortal_Insert();
        }
        public void Update()
        {
            DataPortal_Update();
        }    
         
        private LoaiTaiKhoan(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaLoaiTK = dr.GetInt32("MaLoaiTaiKhoan");
                _MaLoaiTKQL = dr.GetString("MaLoaiTKQL");
                _TenLoaiTK = dr.GetString("TenLoaiTaiKhoan");
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static LoaiTaiKhoan NewLoaiTaiKhoan()
        {
            return new LoaiTaiKhoan();
        }

        //giống constructor

        public static LoaiTaiKhoan NewLoaiTaiKhoan(string maLoaiTKQL, string tenLoaiTaiKhoan)
        {
            LoaiTaiKhoan ltk = new LoaiTaiKhoan();
            ltk._MaLoaiTKQL = maLoaiTKQL;
            ltk._TenLoaiTK = tenLoaiTaiKhoan;
            return ltk;
        }

        public static LoaiTaiKhoan GetLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            if (maLoaiTaiKhoan == 0) return new LoaiTaiKhoan();
            return (LoaiTaiKhoan)DataPortal.Fetch<LoaiTaiKhoan>(new Criteria(maLoaiTaiKhoan));
        }

        public static LoaiTaiKhoan GetLoaiTaiKhoan(SafeDataReader dr)
        {
            return new LoaiTaiKhoan(dr);
        }

        public static void DeleteLoaiTaiKhoan(int maLoaiTaiKhoan)
        {
            DataPortal.Delete(new Criteria(maLoaiTaiKhoan));
        }

        #endregion

        #region Data Access

        #region load tất cả cả

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                Criteria crit = (Criteria)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_LoaiTaiKhoan";
                        cm.Parameters.AddWithValue("@MaLoaiTK", crit.MaLoaiTaiKhoan);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            _MaLoaiTK = dr.GetInt32("MaLoaiTaiKhoan");
                            _MaLoaiTKQL = dr.GetString("MaLoaiTKQL");
                            _TenLoaiTK = dr.GetString("TenLoaiTaiKhoan");
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
                        }
                    }
                    MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    cm.CommandText = "spd_Insert_LoaiTaiKhoan";
                    cm.Parameters.AddWithValue("@MaLoaiTK", _MaLoaiTK).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@MaLoaiTK", _MaLoaiTKQL);
                    cm.Parameters.AddWithValue("@TenLoaiTK", _TenLoaiTK);
                    cm.ExecuteNonQuery();
                    MarkOld();
                    _MaLoaiTK = (int)cm.Parameters["MaLoaiTK"].Value;
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
                    cm.CommandText = "spd_Update_LoaiTaiKhoan";
                    cm.Parameters.AddWithValue("@MaLoaiTK", _MaLoaiTK);
                    cm.Parameters.AddWithValue("@MaLoaiTKQL", _MaLoaiTKQL);
                    cm.Parameters.AddWithValue("@TenLoaiTk", _TenLoaiTK);
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
                    cm.CommandText = "spd_Delete_LoaiTaiKhoan";
                    cm.Parameters.AddWithValue("@MaLoaiTK", crit.MaLoaiTaiKhoan);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiTK));
        }
        #endregion

        #endregion

        #endregion
    }
    #region Type Converter

    public class LoaiTaiKhoanTypeConverter : TypeConverter
    {

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return LoaiTaiKhoan.GetLoaiTaiKhoan((int)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((LoaiTaiKhoan)value).MaLoaiTK;
            }
            if (destinationType == typeof(String))
            {
                return ((LoaiTaiKhoan)value).TenLoaiTK;
            }
            if (destinationType == typeof(Object))
            {
                return ((LoaiTaiKhoan)value).MaLoaiTK;
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

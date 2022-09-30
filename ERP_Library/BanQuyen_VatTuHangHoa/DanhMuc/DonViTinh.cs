
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;
namespace ERP_Library
{
    //Th�nh
    [Serializable()]
    [TypeConverter(typeof(DonViTinhTypeConverter))]
    public class DonViTinh : Csla.BusinessBase<DonViTinh>
    {
        public override string ToString()
        {
            return _tenDonViTinh;
        }

        #region Business Properties and Methods

        //declare members
        private int _maDonViTinh = 0;
        private string _maQuanLy = string.Empty;
        private string _tenDonViTinh = string.Empty;
        private string _dienGiai = string.Empty;
        private bool _maTinhTrang = true;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaDonViTinh
        {
            get
            {
                CanReadProperty("MaDonViTinh", true);
                return _maDonViTinh;
            }
        }

        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }

        public string TenDonViTinh
        {
            get
            {
                CanReadProperty("TenDonViTinh", true);
                return _tenDonViTinh;
            }
            set
            {
                CanWriteProperty("TenDonViTinh", true);
                if (value == null) value = string.Empty;
                if (!_tenDonViTinh.Equals(value))
                {
                    _tenDonViTinh = value;
                    PropertyHasChanged("TenDonViTinh");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public bool MaTinhTrang
        {
            get
            {
                CanReadProperty("MaTinhTrang", true);
                return _maTinhTrang;
            }
            set
            {
                CanWriteProperty("MaTinhTrang", true);
                if (!_maTinhTrang.Equals(value))
                {
                    _maTinhTrang = value;
                    PropertyHasChanged("MaTinhTrang");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maDonViTinh;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //
            // MaQuanLy
            //
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in DonViTinh
            //AuthorizationRules.AllowRead("MaDonViTinh", "DonViTinhReadGroup");
            //AuthorizationRules.AllowRead("MaQuanLy", "DonViTinhReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "DonViTinhReadGroup");

            //AuthorizationRules.AllowWrite("MaQuanLy", "DonViTinhWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "DonViTinhWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static DonViTinh NewDonViTinh()
        {
            return new DonViTinh();
        }

        public static DonViTinh NewDonViTinh(int ma, string ten)
        {
            return new DonViTinh(ma,ten);
        }


        internal static DonViTinh GetDonViTinh(SafeDataReader dr)
        {
            return new DonViTinh(dr);
        }

        public static DonViTinh GetDonViTinh(int maDonViTinh)
        {
            //if (!CanGetObject())
            //    throw new System.Security.SecurityException("User not authorized to view a DonViTinh");
            return DataPortal.Fetch<DonViTinh>(new FilterCriteria(maDonViTinh));
        }

        public static DonViTinh GetDonViTinh(string maQuanLy)
        {
            //if (!CanGetObject())
            //    throw new System.Security.SecurityException("User not authorized to view a DonViTinh");
            return DataPortal.Fetch<DonViTinh>(new FilterCriteria(maQuanLy));
        }

        public static int GetMaDonViTinhByTen(string Ten)
        {
            int _kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetMaDonViTinhByTen";
                    cm.Parameters.AddWithValue("@TenDVT", Ten);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Int, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (int)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
        }

        private DonViTinh(int ma,string ten)
        {
            _maDonViTinh = ma;
            _tenDonViTinh = ten;
        }


        private DonViTinh()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private DonViTinh(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaDonViTinh;
            public string MaQuanLy;
            public FilterCriteria(int maDonViTinh)
            {
                MaDonViTinh = maDonViTinh;
            }
            public FilterCriteria(string maQuanLy)
            {
                MaQuanLy = maQuanLy;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            //RaiseListChangedEvents = false;
            
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandType = CommandType.StoredProcedure;
            if (criteria.MaDonViTinh != 0)
            {                
                cm.CommandText = "spd_SelecttblDonViTinh";
                cm.Parameters.AddWithValue("@MadonViTinh", criteria.MaDonViTinh);
            }
            else
            {                
                cm.CommandText = "spd_SelecttblDonViTinhByMaQuanLy";
                cm.Parameters.AddWithValue("@MaQuanLy", criteria.MaQuanLy);
            }

            SafeDataReader dr = new SafeDataReader(cm.ExecuteReader());
            while (dr.Read())
            {
                Fetch(dr);
            }

            //RaiseListChangedEvents = true;
        }

        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maDonViTinh = dr.GetInt32("MaDonViTinh");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenDonViTinh = dr.GetString("TenDonViTinh");
            _dienGiai = dr.GetString("DienGiai");
            _maTinhTrang = dr.GetBoolean("MaTinhTrang");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDonViTinh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maDonViTinh = (int)cm.Parameters["@MaDonViTinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            if (_tenDonViTinh.Length > 0)
                cm.Parameters.AddWithValue("@TenDonviTinh", _tenDonViTinh);
            else
                cm.Parameters.AddWithValue("@TenDonviTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTinhTrang", _maTinhTrang);
            cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            cm.Parameters["@MaDonViTinh"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDonViTinh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaDonViTinh", _maDonViTinh);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            if (_tenDonViTinh.Length > 0)
                cm.Parameters.AddWithValue("@TenDonviTinh", _tenDonViTinh);
            else
                cm.Parameters.AddWithValue("@TenDonviTinh", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaTinhTrang", _maTinhTrang);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr);
            MarkNew();
        }

        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblDonViTinh";

                cm.Parameters.AddWithValue("@MaDonViTinh", this._maDonViTinh);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
    #region Type Converter

    public class DonViTinhTypeConverter : TypeConverter
    {

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((DonViTinh)value).MaDonViTinh;
            }
            if (destinationType == typeof(String))
            {
                return ((DonViTinh)value).TenDonViTinh;
            }
            if (destinationType == typeof(Object))
            {
                return ((DonViTinh)value).MaDonViTinh;
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

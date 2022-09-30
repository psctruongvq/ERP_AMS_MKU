
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class GiayNghiPhepNuocNgoai_NuocDenListChild : Csla.BusinessBase<GiayNghiPhepNuocNgoai_NuocDenListChild>
    {
        private static int _IDNew = -1;
        #region Business Properties and Methods

        //declare members
        private int _maChiTietPhep = 0;
        private int _maNghiPhep = 0;
        private SmartDate _tuNgay = new SmartDate(DateTime.Today);
        private SmartDate _denNgay = new SmartDate(DateTime.Today);
        private Nullable<int> _maQuocGia = null;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTietPhep
        {
            get
            {
                CanReadProperty("MaChiTietPhep", true);
                return _maChiTietPhep;
            }
        }

        public int MaNghiPhep
        {
            get
            {
                CanReadProperty("MaNghiPhep", true);
                return _maNghiPhep;
            }
            set
            {
                CanWriteProperty("MaNghiPhep", true);
                if (!_maNghiPhep.Equals(value))
                {
                    _maNghiPhep = value;
                    PropertyHasChanged("MaNghiPhep");
                }
            }
        }

        public DateTime TuNgay
        {
            get
            {
                CanReadProperty("TuNgay", true);
                return _tuNgay.Date;
            }
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Date.Equals(value))
                {
                    _tuNgay.Date = value;
                    PropertyHasChanged("TuNgay");
                }
            }
        }

        public DateTime DenNgay
        {
            get
            {
                CanReadProperty("DenNgay", true);
                return _denNgay.Date;
            }
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Date.Equals(value))
                {
                    _denNgay.Date = value;
                    PropertyHasChanged("DenNgay");
                }
            }
        }

        public Nullable<int> MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                CanReadProperty("GhiChu", true);
                return _ghiChu;
            }
            set
            {
                CanWriteProperty("GhiChu", true);
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTietPhep;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
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
            //TODO: Define authorization rules in GiayNghiPhepNuocNgoai_NuocDenListChild
            //AuthorizationRules.AllowRead("MaChiTietPhep", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("MaNghiPhep", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("MaQuocGia", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "GiayNghiPhepNuocNgoai_NuocDenListChildReadGroup");

            //AuthorizationRules.AllowWrite("MaNghiPhep", "GiayNghiPhepNuocNgoai_NuocDenListChildWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "GiayNghiPhepNuocNgoai_NuocDenListChildWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "GiayNghiPhepNuocNgoai_NuocDenListChildWriteGroup");
            //AuthorizationRules.AllowWrite("MaQuocGia", "GiayNghiPhepNuocNgoai_NuocDenListChildWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "GiayNghiPhepNuocNgoai_NuocDenListChildWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static GiayNghiPhepNuocNgoai_NuocDenListChild NewGiayNghiPhepNuocNgoai_NuocDenListChild()
        {
            return new GiayNghiPhepNuocNgoai_NuocDenListChild();
        }

        internal static GiayNghiPhepNuocNgoai_NuocDenListChild GetGiayNghiPhepNuocNgoai_NuocDenListChild(SafeDataReader dr)
        {
            return new GiayNghiPhepNuocNgoai_NuocDenListChild(dr);
        }

        public GiayNghiPhepNuocNgoai_NuocDenListChild()
        {
            //ValidationRules.CheckRules();
            _maChiTietPhep = _IDNew;
            _IDNew -= 1;
            MarkAsChild();
        }

        private GiayNghiPhepNuocNgoai_NuocDenListChild(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
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
            _maChiTietPhep = dr.GetInt32("MaChiTietPhep");
            _maNghiPhep = dr.GetInt32("MaNghiPhep");
            _tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
            _denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
            _maQuocGia = dr.GetInt32("MaQuocGia");
            _ghiChu = dr.GetString("GhiChu");
            if (_maQuocGia == 0)
                _maQuocGia = null;
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, GiayNghiPhepNuocNgoai parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, GiayNghiPhepNuocNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_AddGiayNghiPhepNuocNgoai_NuocDenListChild";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietPhep = (int)cm.Parameters["@NewMaChiTietPhep"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, GiayNghiPhepNuocNgoai parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maNghiPhep = parent.MaNghiPhep;
            cm.Parameters.AddWithValue("@MaNghiPhep", _maNghiPhep);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewMaChiTietPhep", _maChiTietPhep);
            cm.Parameters["@NewMaChiTietPhep"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, GiayNghiPhepNuocNgoai parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, GiayNghiPhepNuocNgoai parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdateGiayNghiPhepNuocNgoai_NuocDenListChild";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, GiayNghiPhepNuocNgoai parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietPhep", _maChiTietPhep);
            cm.Parameters.AddWithValue("@MaNghiPhep", _maNghiPhep);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
            cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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
                cm.CommandText = "sp_DeleteGiayNghiPhepNuocNgoai_NuocDenListChild";

                cm.Parameters.AddWithValue("@MaChiTietPhep", this._maChiTietPhep);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NhanVien_NgayPhep : Csla.BusinessBase<NhanVien_NgayPhep>
    {
        #region Business Properties and Methods

        //declare members
        private int _nhanvienNgayphepid = 0;
        private Nullable<long> _maNhanVien = null;
        private int _ngayPhep = 0;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int NhanvienNgayphepid
        {
            get
            {
                CanReadProperty("NhanvienNgayphepid", true);
                return _nhanvienNgayphepid;
            }
        }

        public Nullable<long> MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public int NgayPhep
        {
            get
            {
                CanReadProperty("NgayPhep", true);
                return _ngayPhep;
            }
            set
            {
                CanWriteProperty("NgayPhep", true);
                if (!_ngayPhep.Equals(value))
                {
                    _ngayPhep = value;
                    PropertyHasChanged("NgayPhep");
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
            return _nhanvienNgayphepid;
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
            //TODO: Define authorization rules in NhanVien_NgayPhep
            //AuthorizationRules.AllowRead("NhanvienNgayphepid", "NhanVien_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "NhanVien_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("NgayPhep", "NhanVien_NgayPhepReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "NhanVien_NgayPhepReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "NhanVien_NgayPhepWriteGroup");
            //AuthorizationRules.AllowWrite("NgayPhep", "NhanVien_NgayPhepWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "NhanVien_NgayPhepWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static NhanVien_NgayPhep NewNhanVien_NgayPhep()
        {
            return new NhanVien_NgayPhep();
        }

        internal static NhanVien_NgayPhep GetNhanVien_NgayPhep(SafeDataReader dr)
        {
            return new NhanVien_NgayPhep(dr);
        }

        private NhanVien_NgayPhep()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private NhanVien_NgayPhep(SafeDataReader dr)
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
            _nhanvienNgayphepid = dr.GetInt32("NhanVien_NgayPhepID");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _ngayPhep = dr.GetInt32("NgayPhep");
            _ghiChu = dr.GetString("GhiChu");
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
                cm.CommandText = "sp_AddNhanVien_NgayPhep";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _nhanvienNgayphepid = (int)cm.Parameters["@NewNhanVien_NgayPhepID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NewNhanVien_NgayPhepID", _nhanvienNgayphepid);
            cm.Parameters["@NewNhanVien_NgayPhepID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "sp_UpdateNhanVien_NgayPhep";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@NhanVien_NgayPhepID", _nhanvienNgayphepid);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@NgayPhep", _ngayPhep);
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
                cm.CommandText = "sp_DeleteNhanVien_NgayPhep";

                cm.Parameters.AddWithValue("@NhanVien_NgayPhepID", this._nhanvienNgayphepid);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

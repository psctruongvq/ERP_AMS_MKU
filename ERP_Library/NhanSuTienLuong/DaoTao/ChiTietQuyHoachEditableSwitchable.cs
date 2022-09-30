using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietQuyHoach : Csla.BusinessBase<ChiTietQuyHoach>
    {
        #region Business Properties and Methods

        //declare members
        private int _maCTQuyHoach = 0;
        private int _maQuyHoach = 0;
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private string _boPhanNhanVien = string.Empty;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private DateTime _ngayQuyHoach;//BoSung - Get form QuyHoach
        private int _maChucVuQuyHoach = 0;
        private string _chucVuQuyHoach = string.Empty;
        private string _ghiChu = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCTQuyHoach
        {
            get
            {
                CanReadProperty("MaCTQuyHoach", true);
                return _maCTQuyHoach;
            }
        }

        public int MaQuyHoach
        {
            get
            {
                CanReadProperty("MaQuyHoach", true);
                return _maQuyHoach;
            }
            set
            {
                CanWriteProperty("MaQuyHoach", true);
                if (!_maQuyHoach.Equals(value))
                {
                    _maQuyHoach = value;
                    PropertyHasChanged("MaQuyHoach");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                if (_maNhanVien != 0)
                {
                    _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                    _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                    _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
                }
                return _maNhanVien;
            }
            set
            {
                CanWriteProperty("MaNhanVien", true);
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    if (_maNhanVien != 0)
                    {
                        _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                        _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                        _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
                    }
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }
        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
        }
        public string BoPhanNhanVien
        {
            get
            {
                return _boPhanNhanVien;
            }
        }

        public DateTime NgayLap
        {
            get
            {
                CanReadProperty("NgayLap", true);
                return _ngayLap.Date;
            }
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        public DateTime NgayQuyHoach
        {
            get
            {
                CanReadProperty("NgayQuyHoach", true);
                return _ngayQuyHoach.Date;
            }
        }

        //public string NgayLapString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayLapString", true);
        //        return _ngayLap.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayLapString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayLap.Equals(value))
        //        {
        //            _ngayLap.Text = value;
        //            PropertyHasChanged("NgayLapString");
        //        }
        //    }
        //}

        public int MaChucVuQuyHoach
        {
            get
            {
                CanReadProperty("MaChucVuQuyHoach", true);
                if(_maChucVuQuyHoach!=0)
                    _chucVuQuyHoach = ChucVu.GetChucVu(_maChucVuQuyHoach).TenChucVu;
                return _maChucVuQuyHoach;
            }
            set
            {
                CanWriteProperty("MaChucVuQuyHoach", true);
                if (!_maChucVuQuyHoach.Equals(value))
                {
                    _maChucVuQuyHoach = value;
                    if (_maChucVuQuyHoach != 0)
                        _chucVuQuyHoach = ChucVu.GetChucVu(_maChucVuQuyHoach).TenChucVu;
                    PropertyHasChanged("MaChucVuQuyHoach");
                }
            }
        }

        public string ChucVuQuyHoach
        {
            get
            {
                CanReadProperty("ChucVuQuyHoach", true);
                return _chucVuQuyHoach;
            }
            set
            {
                CanWriteProperty("ChucVuQuyHoach", true);
                if (value == null) value = string.Empty;
                if (!_chucVuQuyHoach.Equals(value))
                {
                    _chucVuQuyHoach = value;
                    PropertyHasChanged("ChucVuQuyHoach");
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
            return _maCTQuyHoach;
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
            //TODO: Define authorization rules in ChiTietQuyHoach
            //AuthorizationRules.AllowRead("MaCTQuyHoach", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("MaQuyHoach", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("TenNhanVien", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("MaChucVuQuyHoach", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("ChucVuQuyHoach", "ChiTietQuyHoachReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "ChiTietQuyHoachReadGroup");

            //AuthorizationRules.AllowWrite("MaQuyHoach", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("MaNhanVien", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("TenNhanVien", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("MaChucVuQuyHoach", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("ChucVuQuyHoach", "ChiTietQuyHoachWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "ChiTietQuyHoachWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChiTietQuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietQuyHoachViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChiTietQuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietQuyHoachAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChiTietQuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietQuyHoachEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChiTietQuyHoach
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChiTietQuyHoachDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChiTietQuyHoach()
        { /* require use of factory method */ }
        private ChiTietQuyHoach(long maNhanVien)
        {
            _maNhanVien = maNhanVien;
            if (_maNhanVien != 0)
            {
                _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            }
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private ChiTietQuyHoach(ChiTietQuyHoach ctquyhoach)
        {
            _maNhanVien = ctquyhoach.MaNhanVien;
            if (_maNhanVien != 0)
            {
                _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            }
            _maChucVuQuyHoach = ctquyhoach.MaChucVuQuyHoach;
            //_chucVuQuyHoach = ctquyhoach.ChucVuQuyHoach;
            _ghiChu = ctquyhoach.GhiChu;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        public static ChiTietQuyHoach NewChiTietQuyHoach()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChiTietQuyHoach");
            return DataPortal.Create<ChiTietQuyHoach>();
        }

        public static ChiTietQuyHoach NewChiTietQuyHoach(long maNhanVien)
        {
            return new ChiTietQuyHoach(maNhanVien);
        }

        public static ChiTietQuyHoach NewChiTietQuyHoach(ChiTietQuyHoach ctQuyHoach)
        {
            return new ChiTietQuyHoach(ctQuyHoach);
        }

        public static ChiTietQuyHoach GetChiTietQuyHoach(int maCTQuyHoach)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietQuyHoach");
            return DataPortal.Fetch<ChiTietQuyHoach>(new Criteria(maCTQuyHoach));
        }

        public static void DeleteChiTietQuyHoach(int maCTQuyHoach)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChiTietQuyHoach");
            DataPortal.Delete(new Criteria(maCTQuyHoach));
        }

        public override ChiTietQuyHoach Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a ChiTietQuyHoach");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChiTietQuyHoach");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a ChiTietQuyHoach");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChiTietQuyHoach NewChiTietQuyHoachChild()
        {
            ChiTietQuyHoach child = new ChiTietQuyHoach();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChiTietQuyHoach GetChiTietQuyHoach(SafeDataReader dr)
        {
            ChiTietQuyHoach child = new ChiTietQuyHoach();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaCTQuyHoach;

            public Criteria(int maCTQuyHoach)
            {
                this.MaCTQuyHoach = maCTQuyHoach;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetChiTietQuyHoach";

                cm.Parameters.AddWithValue("@MaCTQuyHoach", criteria.MaCTQuyHoach);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    ExecuteInsert(tr, null);

                    //update child object(s)
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw;
                }

            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    if (base.IsDirty)
                    {
                        ExecuteUpdate(tr, null);
                    }

                    //update child object(s)
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw;
                }

            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maCTQuyHoach));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw;
                }

            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsCTQuyHoach";

                cm.Parameters.AddWithValue("@MaCTQuyHoach", criteria.MaCTQuyHoach);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete

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
            _maCTQuyHoach = dr.GetInt32("MaCTQuyHoach");
            _maQuyHoach = dr.GetInt32("MaQuyHoach");
            if (_maQuyHoach != 0)
                _ngayQuyHoach = QuyHoach.GetQuyHoachWithoutChild(_maQuyHoach).NgayQuyHoach.Value;
            _maNhanVien = dr.GetInt64("MaNhanVien");
            if (_maNhanVien != 0)
            {
                _tenNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenNhanVien;
                _maQLNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).MaQLNhanVien;
                _boPhanNhanVien = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(_maNhanVien).TenBoPhan;
            }
            _tenNhanVien = dr.GetString("TenNhanVien");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maChucVuQuyHoach = dr.GetInt32("MaChucVuQuyHoach");
            _chucVuQuyHoach = dr.GetString("ChucVuQuyHoach");
            _ghiChu = dr.GetString("GhiChu");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, QuyHoach parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, QuyHoach parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsCTQuyHoach";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maCTQuyHoach = (int)cm.Parameters["@MaCTQuyHoach"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, QuyHoach parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maQuyHoach = parent.MaQuyHoach;
            if (_maQuyHoach != 0)
                cm.Parameters.AddWithValue("@MaQuyHoach", _maQuyHoach);
            else
                cm.Parameters.AddWithValue("@MaQuyHoach", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maChucVuQuyHoach != 0)
                cm.Parameters.AddWithValue("@MaChucVuQuyHoach", _maChucVuQuyHoach);
            else
                cm.Parameters.AddWithValue("@MaChucVuQuyHoach", DBNull.Value);
            if (_chucVuQuyHoach.Length > 0)
                cm.Parameters.AddWithValue("@ChucVuQuyHoach", _chucVuQuyHoach);
            else
                cm.Parameters.AddWithValue("@ChucVuQuyHoach", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCTQuyHoach", _maCTQuyHoach);
            cm.Parameters["@MaCTQuyHoach"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, QuyHoach parent)
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

        private void ExecuteUpdate(SqlTransaction tr, QuyHoach parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsCTQuyHoach";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, QuyHoach parent)
        {
            _maQuyHoach = parent.MaQuyHoach;
            cm.Parameters.AddWithValue("@MaCTQuyHoach", _maCTQuyHoach);
            if (_maQuyHoach != 0)
                cm.Parameters.AddWithValue("@MaQuyHoach", _maQuyHoach);
            else
                cm.Parameters.AddWithValue("@MaQuyHoach", DBNull.Value);
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_tenNhanVien.Length > 0)
                cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
            else
                cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maChucVuQuyHoach != 0)
                cm.Parameters.AddWithValue("@MaChucVuQuyHoach", _maChucVuQuyHoach);
            else
                cm.Parameters.AddWithValue("@MaChucVuQuyHoach", DBNull.Value);
            if (_chucVuQuyHoach.Length > 0)
                cm.Parameters.AddWithValue("@ChucVuQuyHoach", _chucVuQuyHoach);
            else
                cm.Parameters.AddWithValue("@ChucVuQuyHoach", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maCTQuyHoach));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

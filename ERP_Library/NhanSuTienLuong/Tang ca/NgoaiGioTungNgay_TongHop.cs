
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NgoaiGioTungNgay_TongHop : Csla.BusinessBase<NgoaiGioTungNgay_TongHop>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maNgoaiGio = 0;
        private int _maKyTinhLuong = 0;
        private int _maKyChamCong = 0;
        private int _maBoPhan = 0;
        private long _maNhanVien = 0;
        private string _tenNhanVien = "";
        private bool _daDuyet = false;

        //declare child member(s)
        private NgoaiGioTungNgay_ChiTietList _chiTiet = NgoaiGioTungNgay_ChiTietList.NewNgoaiGioTungNgay_ChiTietList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNgoaiGio
        {
            get
            {
                return _maNgoaiGio;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                return _maKyTinhLuong;
            }
            set
            {
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
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
            set
            {
                if (!_tenNhanVien.Equals(value))
                {
                    _tenNhanVien = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaKyChamCong
        {
            get
            {
                return _maKyChamCong;
            }
            set
            {
                if (!_maKyChamCong.Equals(value))
                {
                    _maKyChamCong = value;
                    PropertyHasChanged();
                }
            }
        }

        public bool DaDuyet
        {
            get
            {
                return _daDuyet;
            }
            set
            {
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        public NgoaiGioTungNgay_ChiTietList ChiTiet
        {
            get
            {
                return _chiTiet;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chiTiet.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiTiet.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maNgoaiGio;
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

        #region Factory Methods
        public NgoaiGioTungNgay_TongHop()
        { /* require use of factory method */ }

        public static NgoaiGioTungNgay_TongHop NewNgoaiGioTungNgay_TongHop()
        {
            return DataPortal.Create<NgoaiGioTungNgay_TongHop>();
        }

        public static NgoaiGioTungNgay_TongHop GetNgoaiGioTungNgay_TongHop(int maNgoaiGio)
        {
            return DataPortal.Fetch<NgoaiGioTungNgay_TongHop>(new Criteria(maNgoaiGio));
        }

        public static void DeleteNgoaiGioTungNgay_TongHop(int maNgoaiGio)
        {
            DataPortal.Delete(new Criteria(maNgoaiGio));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NgoaiGioTungNgay_TongHop NewNgoaiGioTungNgay_TongHopChild()
        {
            NgoaiGioTungNgay_TongHop child = new NgoaiGioTungNgay_TongHop();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NgoaiGioTungNgay_TongHop GetNgoaiGioTungNgay_TongHop(SafeDataReader dr)
        {
            NgoaiGioTungNgay_TongHop child = new NgoaiGioTungNgay_TongHop();
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
            public int MaNgoaiGio;

            public Criteria(int maNgoaiGio)
            {
                this.MaNgoaiGio = maNgoaiGio;
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
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_NgoaiGioTungNgay_TongHop";

                cm.Parameters.AddWithValue("@MaNgoaiGio", criteria.MaNgoaiGio);

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
                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
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
                        ExecuteUpdate(tr);
                    }

                    //update child object(s)
                    UpdateChildren(tr);

                    tr.Commit();
                }
                catch
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
            DataPortal_Delete(new Criteria(_maNgoaiGio));
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
                catch
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
                cm.CommandText = "spd_Delete_NgoaiGioTungNgay_TongHop";

                cm.Parameters.AddWithValue("@MaNgoaiGio", criteria.MaNgoaiGio);

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
            _maNgoaiGio = dr.GetInt32("MaNgoaiGio");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _maKyChamCong = dr.GetInt32("MaKyChamCong");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _daDuyet = dr.GetBoolean("DaDuyet");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            if (this.IsChild)
            {
                _chiTiet = NgoaiGioTungNgay_ChiTietList.GetNgoaiGioTungNgay_ChiTietList(_maNgoaiGio);
            }
            else
            {
                dr.NextResult();
                _chiTiet = NgoaiGioTungNgay_ChiTietList.GetNgoaiGioTungNgay_ChiTietList(dr);
            }
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

            CapNhatTongHop(tr);
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_NgoaiGioTungNgay_TongHop";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNgoaiGio = (int)cm.Parameters["@MaNgoaiGio"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaKyChamCong", _maKyChamCong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@MaNgoaiGio", _maNgoaiGio);
            cm.Parameters["@MaNgoaiGio"].Direction = ParameterDirection.Output;
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

            CapNhatTongHop(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_NgoaiGioTungNgay_TongHop";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNgoaiGio", _maNgoaiGio);
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaKyChamCong", _maKyChamCong);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chiTiet.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maNgoaiGio));
            MarkNew();

            CapNhatTongHop(tr);
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        private void CapNhatTongHop(SqlTransaction tr)
        {
            SqlCommand cm = tr.Connection.CreateCommand();
            cm.Connection = tr.Connection;
            cm.Transaction = tr;
            cm.CommandText = "spd_CapNhatChamNgoaiGioTongHop";
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            cm.Parameters.AddWithValue("@MaKyChamCong", _maKyChamCong);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.ExecuteNonQuery();
        }
    }
}

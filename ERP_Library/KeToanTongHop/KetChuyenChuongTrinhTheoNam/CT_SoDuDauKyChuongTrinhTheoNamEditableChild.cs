using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_SoDuDauKyChuongTrinhTheoNam : Csla.BusinessBase<CT_SoDuDauKyChuongTrinhTheoNam>
    {
        #region Business Properties and Methods

        //declare members
        //private decimal _soTienTon;
        private string _maQLChuongTrinh;
        private long _maChiTiet = 0;
        private int _maChuongTrinh = 0;
        private int _maTaiKhoan = 0;
        private decimal _soTienNo = 0;
        private decimal _soTienCo = 0;
        private int _maKyKetChuyen = 0;

        private decimal _NoDauKy = 0;
        private decimal _CoDauKy = 0;
        private decimal _LuyKeNo = 0;
        private decimal _LuyKeCo = 0;


        public string MaQLChuongTrinh
        {
            get { return _maQLChuongTrinh; }
            set
            {
                _maQLChuongTrinh = value;
            }
        }
        
        private string _tenChuongTrinh = string.Empty;
        public string TenChuongTrinh
        {
            get
            {
                return _tenChuongTrinh;
            }
        }
        private string _soHieuTK = string.Empty;
        public string SoHieuTK
        {
            get
            {
                return _soHieuTK;
            }
        }


        private string _tenTaiKhoan;
        public string TenTaiKhoan
        {
            get { return _tenTaiKhoan; }
        }


        //public decimal SoTienTon
        //{
        //    get { return _soTienTon; }
        //}
        

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }

        public int MaChuongTrinh
        {
            get
            {
                CanReadProperty("MaChuongTrinh", true);
                return _maChuongTrinh;
            }
            set
            {
                CanWriteProperty("MaChuongTrinh", true);
                if (!_maChuongTrinh.Equals(value))
                {
                    _maChuongTrinh = value;
                    #region BoSung
                    if (_maChuongTrinh != 0)
                    {
                        ChuongTrinh_New chuongtrinh = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh);
                        _maQLChuongTrinh = chuongtrinh.MaQL;
                        _tenChuongTrinh = chuongtrinh.TenChuongTrinh;
                    }
                    #endregion
                    PropertyHasChanged("MaChuongTrinh");
                }
            }
        }

        public int MaTaiKhoan
        {
            get
            {
                CanReadProperty("MaTaiKhoan", true);
                return _maTaiKhoan;
            }
            set
            {
                CanWriteProperty("MaTaiKhoan", true);
                if (!_maTaiKhoan.Equals(value))
                {
                    _maTaiKhoan = value;
                    #region BoSung
                    if (_maTaiKhoan != 0)
                    {
                        HeThongTaiKhoan1 taikhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoan);
                        _soHieuTK = taikhoan.SoHieuTK;
                        _tenTaiKhoan = taikhoan.TenTaiKhoan;
                    }
                    #endregion
                    PropertyHasChanged("MaTaiKhoan");
                }
            }
        }

        public decimal SoTienNo
        {
            get
            {
                CanReadProperty("SoTienNo", true);
                return _soTienNo;
            }
            set
            {
                CanWriteProperty("SoTienNo", true);
                if (!_soTienNo.Equals(value))
                {
                    _soTienNo = value;
                    //TinhSoTienTon();
                    PropertyHasChanged("SoTienNo");
                }
            }
        }

        public decimal SoTienCo
        {
            get
            {
                CanReadProperty("SoTienCo", true);
                return _soTienCo;
            }
            set
            {
                CanWriteProperty("SoTienCo", true);
                if (!_soTienCo.Equals(value))
                {
                    _soTienCo = value;
                    //TinhSoTienTon();
                    PropertyHasChanged("SoTienCo");
                }
            }
        }

        public int MaKyKetChuyen
        {
            get
            {
                CanReadProperty("MaKyKetChuyen", true);
                return _maKyKetChuyen;
            }
            set
            {
                CanWriteProperty("MaKyKetChuyen", true);
                if (!_maKyKetChuyen.Equals(value))
                {
                    _maKyKetChuyen = value;
                    PropertyHasChanged("MaKyKetChuyen");
                }
            }
        }

        public decimal NoDauKy
        {
            get
            {
                CanReadProperty("NoDauKy", true);
                return _NoDauKy;
            }
            set
            {
                CanWriteProperty("NoDauKy", true);
                if (!_NoDauKy.Equals(value))
                {
                    _NoDauKy = value;
                    PropertyHasChanged("NoDauKy");
                }
            }
        }

        public decimal CoDauKy
        {
            get
            {
                CanReadProperty("CoDauKy", true);
                return _CoDauKy;
            }
            set
            {
                CanWriteProperty("CoDauKy", true);
                if (!_CoDauKy.Equals(value))
                {
                    _CoDauKy = value;
                    PropertyHasChanged("CoDauKy");
                }
            }
        }
        public decimal LuyKeNo
        {
            get
            {
                CanReadProperty("LuyKeNo", true);
                return _LuyKeNo;
            }
            set
            {
                CanWriteProperty("LuyKeNo", true);
                if (!_LuyKeNo.Equals(value))
                {
                    _LuyKeNo = value;
                    PropertyHasChanged("LuyKeNo");
                }
            }
        }

        public decimal LuyKeCo
        {
            get
            {
                CanReadProperty("LuyKeCo", true);
                return _LuyKeCo;
            }
            set
            {
                CanWriteProperty("LuyKeCo", true);
                if (!_LuyKeCo.Equals(value))
                {
                    _LuyKeCo = value;
                    PropertyHasChanged("LuyKeCo");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            //TODO: Define authorization rules in CT_SoDuDauKyChuongTrinhTheoNam
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("MaChuongTrinh", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("MaBoPhan", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("SoTienNo", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("SoTienCo", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");
            //AuthorizationRules.AllowRead("MaKyKetChuyen", "CT_SoDuDauKyChuongTrinhTheoNamReadGroup");

            //AuthorizationRules.AllowWrite("MaChuongTrinh", "CT_SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("MaBoPhan", "CT_SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienNo", "CT_SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("SoTienCo", "CT_SoDuDauKyChuongTrinhTheoNamWriteGroup");
            //AuthorizationRules.AllowWrite("MaKyKetChuyen", "CT_SoDuDauKyChuongTrinhTheoNamWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_SoDuDauKyChuongTrinhTheoNam NewCT_SoDuDauKyChuongTrinhTheoNam()
        {
            return new CT_SoDuDauKyChuongTrinhTheoNam();
        }

        internal static CT_SoDuDauKyChuongTrinhTheoNam GetCT_SoDuDauKyChuongTrinhTheoNam(SafeDataReader dr)
        {
            return new CT_SoDuDauKyChuongTrinhTheoNam(dr);
        }

        private CT_SoDuDauKyChuongTrinhTheoNam()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_SoDuDauKyChuongTrinhTheoNam(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        #region BoSung
        //private void TinhSoTienTon()
        //{
        //    _soTienTon = _soTienNo - _soTienCo;
        //}
        #endregion//End BoSung
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
            _maChiTiet = dr.GetInt64("MaChiTiet");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
            _maTaiKhoan = dr.GetInt32("MaTaiKhoan");
            _soTienNo = dr.GetDecimal("SoTienNo");
            _soTienCo = dr.GetDecimal("SoTienCo");
            _maKyKetChuyen = dr.GetInt32("MaKyKetChuyen");
            _NoDauKy = dr.GetDecimal("NoDauKy");
            _CoDauKy = dr.GetDecimal("CoDauKy");
            _LuyKeNo = dr.GetDecimal("LuyKeNo");
            _LuyKeCo = dr.GetDecimal("LuyKeCo");

            //TinhSoTienTon();

            if(_maChuongTrinh!=0)
            {
                ChuongTrinh_New chuongtrinh = ChuongTrinh_New.GetChuongTrinh_New(_maChuongTrinh);
                _maQLChuongTrinh = chuongtrinh.MaQL;
                _tenChuongTrinh = chuongtrinh.TenChuongTrinh; 
            }
            if(_maTaiKhoan!=0)
            {
                HeThongTaiKhoan1 taikhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_maTaiKhoan);
                _soHieuTK = taikhoan.SoHieuTK;
                _tenTaiKhoan = taikhoan.TenTaiKhoan;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, SoDuDauKyChuongTrinhTheoNam parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, SoDuDauKyChuongTrinhTheoNam parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_SoDuDauKyChuongTrinhTheoNam";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTiet = (long)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, SoDuDauKyChuongTrinhTheoNam parent)
        {
            _maKyKetChuyen = parent.MaKyKetChuyen;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_soTienNo != 0)
                cm.Parameters.AddWithValue("@SoTienNo", _soTienNo);
            else
                cm.Parameters.AddWithValue("@SoTienNo", DBNull.Value);
            if (_soTienCo != 0)
                cm.Parameters.AddWithValue("@SoTienCo", _soTienCo);
            else
                cm.Parameters.AddWithValue("@SoTienCo", DBNull.Value);
            if (_maKyKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKyKetChuyen", _maKyKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKyKetChuyen", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);

            if (_NoDauKy != 0)
                cm.Parameters.AddWithValue("@NoDauKy", _NoDauKy);
            else
                cm.Parameters.AddWithValue("@NoDauKy", DBNull.Value);
            if (_CoDauKy != 0)
                cm.Parameters.AddWithValue("@CoDauKy", _CoDauKy);
            else
                cm.Parameters.AddWithValue("@CoDauKy", DBNull.Value);
            if (_LuyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _LuyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_LuyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _LuyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);

            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, SoDuDauKyChuongTrinhTheoNam parent)
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

        private void ExecuteUpdate(SqlTransaction tr, SoDuDauKyChuongTrinhTheoNam parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_SoDuDauKyChuongTrinhTheoNam";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, SoDuDauKyChuongTrinhTheoNam parent)
        {
            _maKyKetChuyen = parent.MaKyKetChuyen;

            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
            if (_maTaiKhoan != 0)
                cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
            else
                cm.Parameters.AddWithValue("@MaTaiKhoan", DBNull.Value);
            if (_soTienNo != 0)
                cm.Parameters.AddWithValue("@SoTienNo", _soTienNo);
            else
                cm.Parameters.AddWithValue("@SoTienNo", DBNull.Value);
            if (_soTienCo != 0)
                cm.Parameters.AddWithValue("@SoTienCo", _soTienCo);
            else
                cm.Parameters.AddWithValue("@SoTienCo", DBNull.Value);
            if (_maKyKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKyKetChuyen", _maKyKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKyKetChuyen", DBNull.Value);

            if (_NoDauKy != 0)
                cm.Parameters.AddWithValue("@NoDauKy", _NoDauKy);
            else
                cm.Parameters.AddWithValue("@NoDauKy", DBNull.Value);
            if (_CoDauKy != 0)
                cm.Parameters.AddWithValue("@CoDauKy", _CoDauKy);
            else
                cm.Parameters.AddWithValue("@CoDauKy", DBNull.Value);
            if (_LuyKeNo != 0)
                cm.Parameters.AddWithValue("@LuyKeNo", _LuyKeNo);
            else
                cm.Parameters.AddWithValue("@LuyKeNo", DBNull.Value);
            if (_LuyKeCo != 0)
                cm.Parameters.AddWithValue("@LuyKeCo", _LuyKeCo);
            else
                cm.Parameters.AddWithValue("@LuyKeCo", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_SoDuDauKyChuongTrinhTheoNam";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

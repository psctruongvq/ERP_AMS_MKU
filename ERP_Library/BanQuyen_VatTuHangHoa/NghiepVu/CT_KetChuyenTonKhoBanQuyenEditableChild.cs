
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//05_02_2013
namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenTonKhoBanQuyen : Csla.BusinessBase<CT_KetChuyenTonKhoBanQuyen>
    {
        #region Business Properties and Methods

        //declare members
        private long _mactKetchuyen = 0;
        private int _maHangHoa = 0;
        private long _maHopDong = 0;
        private decimal _soLuongTon = 0;
        private decimal _giaTriTon = 0;
        private long _maKetChuyenBQ = 0;
        private int _maChuongTrinhCon = 0;
        private int _maNguon = 0;
        private int _maChuongTrinh = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public long MactKetchuyen
        {
            get
            {
                CanReadProperty("MactKetchuyen", true);
                return _mactKetchuyen;
            }
        }

        public int MaHangHoa
        {
            get
            {
                CanReadProperty("MaHangHoa", true);
                return _maHangHoa;
            }
            set
            {
                CanWriteProperty("MaHangHoa", true);
                if (!_maHangHoa.Equals(value))
                {
                    _maHangHoa = value;
                    PropertyHasChanged("MaHangHoa");
                }
            }
        }

        public long MaHopDong
        {
            get
            {
                CanReadProperty("MaHopDong", true);
                return _maHopDong;
            }
            set
            {
                CanWriteProperty("MaHopDong", true);
                if (!_maHopDong.Equals(value))
                {
                    _maHopDong = value;
                    PropertyHasChanged("MaHopDong");
                }
            }
        }

        public decimal SoLuongTon
        {
            get
            {
                CanReadProperty("SoLuongTon", true);
                return _soLuongTon;
            }
            set
            {
                CanWriteProperty("SoLuongTon", true);
                if (!_soLuongTon.Equals(value))
                {
                    _soLuongTon = value;
                    PropertyHasChanged("SoLuongTon");
                }
            }
        }

        public decimal GiaTriTon
        {
            get
            {
                CanReadProperty("GiaTriTon", true);
                return _giaTriTon;
            }
            set
            {
                CanWriteProperty("GiaTriTon", true);
                if (!_giaTriTon.Equals(value))
                {
                    _giaTriTon = value;
                    PropertyHasChanged("GiaTriTon");
                }
            }
        }

        public long MaKetChuyenBQ
        {
            get
            {
                CanReadProperty("MaKetChuyenBQ", true);
                return _maKetChuyenBQ;
            }
            set
            {
                CanWriteProperty("MaKetChuyenBQ", true);
                if (!_maKetChuyenBQ.Equals(value))
                {
                    _maKetChuyenBQ = value;
                    PropertyHasChanged("MaKetChuyenBQ");
                }
            }
        }
        //
        public int MaChuongTrinhCon
        {
            get
            {
                CanReadProperty("MaChuongTrinhCon", true);
                return _maChuongTrinhCon;
            }
            set
            {
                CanWriteProperty("MaChuongTrinhCon", true);
                if (!_maChuongTrinhCon.Equals(value))
                {
                    _maChuongTrinhCon = value;
                    PropertyHasChanged("MaChuongTrinhCon");
                }
            }
        }
        public int MaNguon
        {
            get
            {
                CanReadProperty("MaNguon", true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty("MaNguon", true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    PropertyHasChanged("MaNguon");
                }
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
                    PropertyHasChanged("MaChuongTrinh");
                }
            }
        }
        //

        protected override object GetIdValue()
        {
            return _mactKetchuyen;
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
            //TODO: Define authorization rules in CT_KetChuyenTonKhoBanQuyen
            //AuthorizationRules.AllowRead("MactKetchuyen", "CT_KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaHopDong", "CT_KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("SoLuongTon", "CT_KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("GiaTriTon", "CT_KetChuyenTonKhoBanQuyenReadGroup");
            //AuthorizationRules.AllowRead("MaKetChuyenBQ", "CT_KetChuyenTonKhoBanQuyenReadGroup");

            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("MaHopDong", "CT_KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuongTon", "CT_KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("GiaTriTon", "CT_KetChuyenTonKhoBanQuyenWriteGroup");
            //AuthorizationRules.AllowWrite("MaKetChuyenBQ", "CT_KetChuyenTonKhoBanQuyenWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_KetChuyenTonKhoBanQuyen NewCT_KetChuyenTonKhoBanQuyen()
        {
            return new CT_KetChuyenTonKhoBanQuyen();
        }

        internal static CT_KetChuyenTonKhoBanQuyen GetCT_KetChuyenTonKhoBanQuyen(SafeDataReader dr, bool kieu)
        {
            return new CT_KetChuyenTonKhoBanQuyen(dr, kieu);
        }

        private CT_KetChuyenTonKhoBanQuyen()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_KetChuyenTonKhoBanQuyen(SafeDataReader dr, bool kieu)
        {
            MarkAsChild();
            Fetch(dr, kieu);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool _kieu)
        {
            FetchObject(dr);
            if (_kieu == false)
                MarkNew();
            else
                MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _mactKetchuyen = dr.GetInt64("MaCT_KetChuyen");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _maHopDong = dr.GetInt64("MaHopDong");
            _soLuongTon = dr.GetDecimal("SoLuongTon");
            _giaTriTon = dr.GetDecimal("GiaTriTon");
            _maKetChuyenBQ = dr.GetInt64("MaKetChuyenBQ");
            _maChuongTrinhCon = dr.GetInt32("MaChuongTrinhCon");
            _maNguon = dr.GetInt32("MaNguon");
            _maChuongTrinh = dr.GetInt32("MaChuongTrinh");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KetChuyenTonKhoBanQuyen parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KetChuyenTonKhoBanQuyen parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KetChuyenTonKhoBanQuyen";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _mactKetchuyen = (long)cm.Parameters["@MaCT_KetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KetChuyenTonKhoBanQuyen parent)
        {
            _maKetChuyenBQ = parent.MaKetChuyenBQ;
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_soLuongTon != 0)
                cm.Parameters.AddWithValue("@SoLuongTon", _soLuongTon);
            else
                cm.Parameters.AddWithValue("@SoLuongTon", DBNull.Value);
            if (_giaTriTon != 0)
                cm.Parameters.AddWithValue("@GiaTriTon", _giaTriTon);
            else
                cm.Parameters.AddWithValue("@GiaTriTon", DBNull.Value);
            if (_maKetChuyenBQ != 0)
                cm.Parameters.AddWithValue("@MaKetChuyenBQ", _maKetChuyenBQ);
            else
                cm.Parameters.AddWithValue("@MaKetChuyenBQ", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCT_KetChuyen", _mactKetchuyen);
            if (_maChuongTrinhCon != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);

            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh",DBNull.Value);

            cm.Parameters["@MaCT_KetChuyen"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KetChuyenTonKhoBanQuyen parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KetChuyenTonKhoBanQuyen parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KetChuyenTonKhoBanQuyen";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KetChuyenTonKhoBanQuyen parent)
        {
            cm.Parameters.AddWithValue("@MaCT_KetChuyen", _mactKetchuyen);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            if (_soLuongTon != 0)
                cm.Parameters.AddWithValue("@SoLuongTon", _soLuongTon);
            else
                cm.Parameters.AddWithValue("@SoLuongTon", DBNull.Value);
            if (_giaTriTon != 0)
                cm.Parameters.AddWithValue("@GiaTriTon", _giaTriTon);
            else
                cm.Parameters.AddWithValue("@GiaTriTon", DBNull.Value);
            if (_maKetChuyenBQ != 0)
                cm.Parameters.AddWithValue("@MaKetChuyenBQ", _maKetChuyenBQ);
            else
                cm.Parameters.AddWithValue("@MaKetChuyenBQ", DBNull.Value);
            if (_maChuongTrinhCon != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", _maChuongTrinhCon);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinhCon", DBNull.Value);

            if (_maNguon != 0)
                cm.Parameters.AddWithValue("@MaNguon", _maNguon);
            else
                cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);

            if (_maChuongTrinh != 0)
                cm.Parameters.AddWithValue("@MaChuongTrinh", _maChuongTrinh);
            else
                cm.Parameters.AddWithValue("@MaChuongTrinh", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_KetChuyenTonKhoBanQuyen";

                cm.Parameters.AddWithValue("@MaCT_KetChuyen", this._mactKetchuyen);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

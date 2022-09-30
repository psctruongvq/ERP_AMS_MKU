
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenSoDuCCDC : Csla.BusinessBase<CT_KetChuyenSoDuCCDC>
    {
        #region Business Properties and Methods

        //declare members
        private long _maChiTietKetChuyen = 0;
        private int _maKetChuyen = 0;
        private int _maHangHoa = 0;
        private int _soLuong = 0;
        private decimal _thanhTien = 0;
        private int _MaCCDC = 0;

        private string _TenHangHoa = string.Empty;
        private string _TenBoPhan = string.Empty;
        private string _tenKho = string.Empty;
        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChiTietKetChuyen
        {
            get
            {
                CanReadProperty("MaChiTietKetChuyen", true);
                return _maChiTietKetChuyen;
            }
        }

        public int MaKetChuyen
        {
            get
            {
                CanReadProperty("MaKetChuyen", true);
                return _maKetChuyen;
            }
            set
            {
                CanWriteProperty("MaKetChuyen", true);
                if (!_maKetChuyen.Equals(value))
                {
                    _maKetChuyen = value;
                    PropertyHasChanged("MaKetChuyen");
                }
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

        public int SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
                }
            }
        }

        public int MaCCDC
        {
            get
            {
                CanReadProperty("MaCCDC", true);
                return _MaCCDC;
            }
            set
            {
                CanWriteProperty("MaCCDC", true);
                if (!_MaCCDC.Equals(value))
                {
                    _MaCCDC = value;
                    if (_MaCCDC != 0)
                    {
                        _TenHangHoa = GetTenHangHoabyMaCCDC(_MaCCDC);
                    }
                    PropertyHasChanged("MaCCDC");
                }
            }
        }

        public string TenHangHoa
        {
            get
            {
                CanReadProperty("TenHangHoa", true);
                return _TenHangHoa;
            }
        }

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _TenBoPhan;
            }
        }
        public string TenKho
        {
            get
            {
                CanReadProperty("TenKho", true);
                return _tenKho;
            }
        }
        protected override object GetIdValue()
        {
            return _maChiTietKetChuyen;
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
            //TODO: Define authorization rules in CT_KetChuyenSoDuCCDC
            //AuthorizationRules.AllowRead("MaChiTietKetChuyen", "CT_KetChuyenSoDuCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaKetChuyen", "CT_KetChuyenSoDuCCDCReadGroup");
            //AuthorizationRules.AllowRead("MaHangHoa", "CT_KetChuyenSoDuCCDCReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CT_KetChuyenSoDuCCDCReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CT_KetChuyenSoDuCCDCReadGroup");

            //AuthorizationRules.AllowWrite("MaKetChuyen", "CT_KetChuyenSoDuCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("MaHangHoa", "CT_KetChuyenSoDuCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CT_KetChuyenSoDuCCDCWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CT_KetChuyenSoDuCCDCWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        internal static CT_KetChuyenSoDuCCDC NewCT_KetChuyenSoDuCCDC()
        {
            return new CT_KetChuyenSoDuCCDC();
        }

        internal static CT_KetChuyenSoDuCCDC GetCT_KetChuyenSoDuCCDC(SafeDataReader dr, bool kieu)
        {
            return new CT_KetChuyenSoDuCCDC(dr,kieu);
        }

        private CT_KetChuyenSoDuCCDC()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_KetChuyenSoDuCCDC(SafeDataReader dr, bool kieu)
        {
            MarkAsChild();
            Fetch(dr,kieu);
        }

        private string GetTenHangHoabyMaCCDC(int maCCDC)
        {
            string tenhanghoa = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTenHangHoabyCCDC";
                    cm.Parameters.AddWithValue("@MaCCDC", maCCDC);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.NVarChar, 1000);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    tenhanghoa = (string)prmGiaTriTraVe.Value;
                }
            }//us
            return tenhanghoa;
        }

        public static bool KiemTraCCDCChuaTonTaiTrongKy(int maCCDC, int nam)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraCCDCChuaTonTaiTrongKy";
                    cm.Parameters.AddWithValue("@MaCCDC", maCCDC);
                    cm.Parameters.AddWithValue("@Nam", nam);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    result = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return result;
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
            _maChiTietKetChuyen = dr.GetInt64("MaChiTietKetChuyen");
            _maKetChuyen = dr.GetInt32("MaKetChuyen");
            _maHangHoa = dr.GetInt32("MaHangHoa");
            _soLuong = dr.GetInt32("SoLuong");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _MaCCDC = dr.GetInt32("MaCCDC");
            _TenHangHoa = dr.GetString("TenHangHoa");
            _TenBoPhan = dr.GetString("TenBoPhan");
            _tenKho = dr.GetString("TenKho");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, KyKetChuyenSoDuCCDC parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, KyKetChuyenSoDuCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCT_KetChuyenSoDuCCDC";//\\

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _maChiTietKetChuyen = (long)cm.Parameters["@MaChiTietKetChuyen"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, KyKetChuyenSoDuCCDC parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maKetChuyen = parent.MaKetChuyen;
            if (_maKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);

            if (_MaCCDC != 0)
                cm.Parameters.AddWithValue("@MaCCDC", _MaCCDC);
            else
                cm.Parameters.AddWithValue("@MaCCDC", DBNull.Value);
            cm.Parameters.AddWithValue("@MaChiTietKetChuyen", _maChiTietKetChuyen);
            cm.Parameters["@MaChiTietKetChuyen"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, KyKetChuyenSoDuCCDC parent)
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

        private void ExecuteUpdate(SqlTransaction tr, KyKetChuyenSoDuCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCT_KetChuyenSoDuCCDC";//\\

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, KyKetChuyenSoDuCCDC parent)
        {
            cm.Parameters.AddWithValue("@MaChiTietKetChuyen", _maChiTietKetChuyen);
            if (_maKetChuyen != 0)
                cm.Parameters.AddWithValue("@MaKetChuyen", _maKetChuyen);
            else
                cm.Parameters.AddWithValue("@MaKetChuyen", DBNull.Value);
            if (_maHangHoa != 0)
                cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
            else
                cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_MaCCDC != 0)
                cm.Parameters.AddWithValue("@MaCCDC", _MaCCDC);
            else
                cm.Parameters.AddWithValue("@MaCCDC", DBNull.Value);
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
                cm.CommandText = "spd_DeletetblCT_KetChuyenSoDuCCDC";//\\

                cm.Parameters.AddWithValue("@MaChiTietKetChuyen", this._maChiTietKetChuyen);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}

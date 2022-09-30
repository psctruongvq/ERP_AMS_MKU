
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class LuongTruocDieuChinh : Csla.ReadOnlyBase<LuongTruocDieuChinh>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private decimal _hSPhu = 0;
        private decimal _hSChucVu = 0;
        private decimal _hSVuotKhung = 0;
        private decimal _luongV1 = 0;
        private decimal _bhxh = 0;
        private decimal _luongV2 = 0;
        private decimal _soTien = 0;
        private decimal _ptLuongV1 = 0;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public decimal HSPhu
        {
            get
            {
                return _hSPhu;
            }
        }

        public decimal HSChucVu
        {
            get
            {
                return _hSChucVu;
            }
        }

        public decimal HSVuotKhung
        {
            get
            {
                return _hSVuotKhung;
            }
        }

        public decimal LuongV1
        {
            get
            {
                return _luongV1;
            }
        }

        public decimal Bhxh
        {
            get
            {
                return _bhxh;
            }
        }

        public decimal LuongV2
        {
            get
            {
                return _luongV2;
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
        }

        public decimal PTLuongV1
        {
            get
            {
                return _ptLuongV1;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        private LuongTruocDieuChinh()
        { /* require use of factory method */ }

        public static LuongTruocDieuChinh GetLuongTruocDieuChinh(int maKyTinhLuong, long maNhanVien)
        {
            return DataPortal.Fetch<LuongTruocDieuChinh>(new Criteria(maKyTinhLuong, maNhanVien));
        }
        #endregion //Factory Methods


        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaNhanVien;
            public int MaKyTinhLuong;

            public Criteria(int maKyTinhLuong, long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
                this.MaKyTinhLuong = maKyTinhLuong;
            }
        }

        #endregion //Criteria

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
                cm.CommandText = "spd_Select_LuongTruocDieuChinh";
                cm.Parameters.AddWithValue("@MaKyTinhLuong", criteria.MaKyTinhLuong);
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);

                    //load child object(s)
                    FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _hSPhu = dr.GetDecimal("HSPhu");
            _hSChucVu = dr.GetDecimal("HSChucVu");
            _hSVuotKhung = dr.GetDecimal("HSVuotKhung");
            _luongV1 = dr.GetDecimal("LuongV1");
            _bhxh = dr.GetDecimal("BHXH");
            _luongV2 = dr.GetDecimal("LuongV2");
            _soTien = dr.GetDecimal("SoTien");
            _ptLuongV1 = dr.GetDecimal("PTLuongV1");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}

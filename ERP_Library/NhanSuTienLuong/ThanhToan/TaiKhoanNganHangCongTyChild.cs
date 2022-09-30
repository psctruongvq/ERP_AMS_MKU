
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class TaiKhoanNganHangCongTyChild : Csla.BusinessBase<TaiKhoanNganHangCongTyChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maChiTiet = 0;
        private string _tenNganHang = string.Empty;
        private string _soTaiKhoan = string.Empty;

        [System.ComponentModel.DataObjectField(true, false)]
        public int MaChiTiet
        {
            get
            {
                return _maChiTiet;
            }
        }

        public string TenNganHang
        {
            get
            {
                return _tenNganHang;
            }
        }

        public string SoTaiKhoan
        {
            get
            {
                return _soTaiKhoan;
            }
            set
            {
                _soTaiKhoan = value;
            }
        }

        protected override object GetIdValue()
        {
            return _maChiTiet;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static TaiKhoanNganHangCongTyChild GetTaiKhoanNganHangCongTyChild(SafeDataReader dr)
        {
            return new TaiKhoanNganHangCongTyChild(dr);
        }

        public static TaiKhoanNganHangCongTyChild GetTaiKhoanNganHangCongTyChild(int machiTiet)
        {
            TaiKhoanNganHangCongTyChild tk = new TaiKhoanNganHangCongTyChild();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTaiKhoanNganHangCongTyByMaChiTiet";
                    cm.Parameters.AddWithValue("@MaChiTiet", machiTiet);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            tk._maChiTiet = dr.GetInt32("MaChiTiet");
                            tk._tenNganHang = dr.GetString("TenNganHang");
                            tk._soTaiKhoan = dr.GetString("SoTaiKhoan");
                        }

                    }
                }
            }
            return tk;

        }

        private TaiKhoanNganHangCongTyChild(SafeDataReader dr)
        {
            Fetch(dr);
        }

        private TaiKhoanNganHangCongTyChild()
        {
        }

        public TaiKhoanNganHangCongTyChild(string sotaikhoan)
        {
            this.SoTaiKhoan = sotaikhoan;
            MarkAsChild();
        }

        public static TaiKhoanNganHangCongTyChild NewTaiKhoanNganHangCongTy(string sotaikhoan)
        {
            return new TaiKhoanNganHangCongTyChild(sotaikhoan);
        }
        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _tenNganHang = dr.GetString("TenNganHang");
            _soTaiKhoan = dr.GetString("SoTaiKhoan");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}

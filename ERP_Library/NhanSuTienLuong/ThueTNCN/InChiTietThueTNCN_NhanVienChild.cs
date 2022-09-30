namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using ERP_Library;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class InChiTietThueTNCN_NhanVienChild : ReadOnlyBase<InChiTietThueTNCN_NhanVienChild>
    {
        private InChiTietThueTNCN_ChiTietList _chitiet;
        private bool _ky3_12 = false;
        private long _maNhanVien = 0L;
        private string _maSoThue = string.Empty;
        private int _nam = 0;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private bool _tuQuyetToan;
        private int _denThang;
        private InChiTietThueTNCN_TongHopList _tonghop;

        private InChiTietThueTNCN_NhanVienChild(SafeDataReader dr, int Nam, bool Ky3_12, bool TuQuyetToan, int DenThang )
        {
            this._nam = Nam;
            this._ky3_12 = Ky3_12;
            this._tuQuyetToan = TuQuyetToan;
            this._denThang = DenThang;
            this.Fetch(dr);
        }

        private void Fetch(SafeDataReader dr)
        {
            this.FetchObject(dr);
            this.FetchChildren(dr);
        }


        private void FetchChildren(SafeDataReader dr)
        {
            SqlConnection connection = new SqlConnection(Database.ERP_Connection);
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 0;
                if (this._nam == 2010)
                {
                    command.CommandText = "[spd_Report_ChiTietQuyetToanThueTNCNDuPhong]";
                }
                else
                {
                    command.CommandText = "spd_Report_ChiTietQuyetToanThueTNCN";
                }

                command.Parameters.AddWithValue("@MaNhanVien", this._maNhanVien);
                command.Parameters.AddWithValue("@Nam", this._nam);
                command.Parameters.AddWithValue("@Ky3_12", this._ky3_12);
                command.Parameters.AddWithValue("@TuQuetToan", this._tuQuyetToan);
                command.Parameters.AddWithValue("@DenThang", this._denThang);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    this._tonghop = new InChiTietThueTNCN_TongHopList(reader);
                    reader.NextResult();
                    this._chitiet = new InChiTietThueTNCN_ChiTietList(reader);
                }
            }
            connection.Close();
        }


        private void FetchObject(SafeDataReader dr)
        {
            this._maNhanVien = dr.GetInt64("MaNhanVien");
            this._tenNhanVien = dr.GetString("TenNhanVien");
            this._maSoThue = dr.GetString("MaSoThue");
            this._tenBoPhan = dr.GetString("TenBoPhan");
        }

        protected override object GetIdValue()
        {
            return this._maNhanVien;
        }

        internal static InChiTietThueTNCN_NhanVienChild GetInChiTietThueTNCN_NhanVienChild(SafeDataReader dr, int Nam, bool Ky3_12, bool TuQuyetToan, int DenThang)
        {
            return new InChiTietThueTNCN_NhanVienChild(dr, Nam, Ky3_12, TuQuyetToan, DenThang);
        }

        public InChiTietThueTNCN_ChiTietList ChiTiet
        {
            get
            {
                return this._chitiet;
            }
        }

        [DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return this._maNhanVien;
            }
        }

        public string MaSoThue
        {
            get
            {
                return this._maSoThue;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return this._tenBoPhan;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return this._tenNhanVien;
            }
        }

        public InChiTietThueTNCN_TongHopList TongHop
        {
            get
            {
                return this._tonghop;
            }
        }
    }
}


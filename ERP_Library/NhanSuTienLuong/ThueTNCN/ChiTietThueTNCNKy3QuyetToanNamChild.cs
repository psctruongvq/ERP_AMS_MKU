namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;

    [Serializable]
    public class ChiTietThueTNCNKy3QuyetToanNamChild : ReadOnlyBase<ChiTietThueTNCNKy3QuyetToanNamChild>
    {
        private int _id = 0;
        private decimal _ky3Cong = 0M;
        private decimal _ky3Duochoan = 0M;
        private decimal _ky3Phaithu = 0M;
        private string _maBoPhanQL = string.Empty;
        private long _maNhanVien = 0L;
        private decimal _nldCong = 0M;
        private decimal _nldDuochoan = 0M;
        private decimal _nldPhaithu = 0M;
        private decimal _quyettoanCong = 0M;
        private decimal _quyettoanDuochoan = 0M;
        private decimal _quyettoanPhaithu = 0M;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;

        private ChiTietThueTNCNKy3QuyetToanNamChild(SafeDataReader dr)
        {
            this.Fetch(dr);
        }

        private void Fetch(SafeDataReader dr)
        {
            this.FetchObject(dr);
            this.FetchChildren(dr);
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }

        private void FetchObject(SafeDataReader dr)
        {
            this._id = dr.GetInt32("ID");
            this._maNhanVien = dr.GetInt64("MaNhanVien");
            this._tenNhanVien = dr.GetString("TenNhanVien");
            this._maBoPhanQL = dr.GetString("MaBoPhanQL");
            this._tenBoPhan = dr.GetString("TenBoPhan");
            this._ky3Phaithu = dr.GetDecimal("Ky3_PhaiThu");
            this._ky3Duochoan = dr.GetDecimal("Ky3_DuocHoan");
            this._ky3Cong = dr.GetDecimal("Ky3_Cong");
            this._quyettoanPhaithu = dr.GetDecimal("QuyetToan_PhaiThu");
            this._quyettoanDuochoan = dr.GetDecimal("QuyetToan_DuocHoan");
            this._quyettoanCong = dr.GetDecimal("QuyetToan_Cong");
            this._nldPhaithu = dr.GetDecimal("NLD_PhaiThu");
            this._nldDuochoan = dr.GetDecimal("NLD_DuocHoan");
            this._nldCong = dr.GetDecimal("NLD_Cong");
        }

        internal static ChiTietThueTNCNKy3QuyetToanNamChild GetChiTietThueTNCNKy3QuyetToanNamChild(SafeDataReader dr)
        {
            return new ChiTietThueTNCNKy3QuyetToanNamChild(dr);
        }

        protected override object GetIdValue()
        {
            return this._id;
        }

        [DataObjectField(true, false)]
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public decimal Ky3Cong
        {
            get
            {
                return this._ky3Cong;
            }
        }

        public decimal Ky3Duochoan
        {
            get
            {
                return this._ky3Duochoan;
            }
        }

        public decimal Ky3Phaithu
        {
            get
            {
                return this._ky3Phaithu;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return this._maBoPhanQL;
            }
        }

        public long MaNhanVien
        {
            get
            {
                return this._maNhanVien;
            }
        }

        public decimal NldCong
        {
            get
            {
                return this._nldCong;
            }
        }

        public decimal NldDuochoan
        {
            get
            {
                return this._nldDuochoan;
            }
        }

        public decimal NldPhaithu
        {
            get
            {
                return this._nldPhaithu;
            }
        }

        public decimal QuyettoanCong
        {
            get
            {
                return this._quyettoanCong;
            }
        }

        public decimal QuyettoanDuochoan
        {
            get
            {
                return this._quyettoanDuochoan;
            }
        }

        public decimal QuyettoanPhaithu
        {
            get
            {
                return this._quyettoanPhaithu;
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
    }
}


namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;

    [Serializable]
    public class DanhSachThuThueNVTuQuyetToanChild : ReadOnlyBase<DanhSachThuThueNVTuQuyetToanChild>
    {
        private decimal _duocHoan = 0M;
        private int _id = 0;
        private string _maBoPhanQL = string.Empty;
        private decimal _phaiThu = 0M;
        private string _tenBoPhan = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _thueTNCNKy2 = 0M;
        private decimal _thueTNCNKy3 = 0M;

        private DanhSachThuThueNVTuQuyetToanChild(SafeDataReader dr)
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
            this._maBoPhanQL = dr.GetString("MaBoPhanQL");
            this._tenBoPhan = dr.GetString("TenBoPhan");
            this._tenNhanVien = dr.GetString("TenNhanVien");
            this._thueTNCNKy3 = dr.GetDecimal("ThueTNCNKy3");
            this._thueTNCNKy2 = dr.GetDecimal("ThueTNCNKy2");
            this._phaiThu = dr.GetDecimal("PhaiThu");
            this._duocHoan = dr.GetDecimal("DuocHoan");
        }

        internal static DanhSachThuThueNVTuQuyetToanChild GetDanhSachThuThueNVTuQuyetToanChild(SafeDataReader dr)
        {
            return new DanhSachThuThueNVTuQuyetToanChild(dr);
        }

        protected override object GetIdValue()
        {
            return this._id;
        }

        public decimal DuocHoan
        {
            get
            {
                return this._duocHoan;
            }
        }

        [DataObjectField(true, false)]
        public int Id
        {
            get
            {
                return this._id;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return this._maBoPhanQL;
            }
        }

        public decimal PhaiThu
        {
            get
            {
                return this._phaiThu;
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

        public decimal ThueTNCNKy2
        {
            get
            {
                return this._thueTNCNKy2;
            }
        }

        public decimal ThueTNCNKy3
        {
            get
            {
                return this._thueTNCNKy3;
            }
        }
    }
}


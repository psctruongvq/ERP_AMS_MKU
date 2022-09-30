namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;

    [Serializable]
    public class TongHopQuyetToanThueChild : ReadOnlyBase<TongHopQuyetToanThueChild>
    {
        private decimal _baoHiemBatBuoc = 0M;
        private int _maBoPhan = 0;
        private string _maBoPhanQL = "";
        private int _soNguoiPhuThuoc = 0;
        private int _soNV = 0;
        private int _soThangGiamTru = 0;
        private decimal _soThueKhauTru = 0M;
        private decimal _soThueNopThua = 0M;
        private decimal _soThuePhaiNop = 0M;
        private string _tenBoPhan = "";
        private decimal _thueDaKhauTru = 0M;
        private decimal _thueNLDDaNop = 0M;
        private decimal _thueNLDNopThem = 0M;
        private decimal _thueNLDTraLai = 0M;
        private decimal _thuNhapChiuThue = 0M;
        private decimal _tNCTGiamThue = 0M;
        private decimal _tuThienNhanDao = 0M;

        private decimal _tongThuNhap = 0;

        private TongHopQuyetToanThueChild(SafeDataReader dr)
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
            this._maBoPhan = dr.GetInt32("MaBoPhan");
            this._maBoPhanQL = dr.GetString("MaBoPhanQL");
            this._tenBoPhan = dr.GetString("TenBoPhan");
            this._soNV = dr.GetInt32("SoNV");
            this._thuNhapChiuThue = dr.GetDecimal("ThuNhapChiuThue");
            this._soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            this._soThangGiamTru = dr.GetInt32("SoThangGiamTru");
            this._tuThienNhanDao = dr.GetDecimal("TuThienNhanDao");
            this._baoHiemBatBuoc = dr.GetDecimal("BaoHiemBatBuoc");
            this._tNCTGiamThue = dr.GetDecimal("TNCTGiamThue");
            this._thueDaKhauTru = dr.GetDecimal("ThueDaKhauTru");
            this._soThuePhaiNop = dr.GetDecimal("SoThuePhaiNop");
            this._soThueNopThua = dr.GetDecimal("SoThueNopThua");
            this._soThueKhauTru = dr.GetDecimal("SoThueKhauTru");
            this._thueNLDDaNop = dr.GetDecimal("ThueNLDDaNop");
            this._thueNLDNopThem = dr.GetDecimal("ThueNLDNopThem");
            this._thueNLDTraLai = dr.GetDecimal("ThueNLDTraLai");
            this._tongThuNhap = dr.GetDecimal("TongThuNhap");
        }

        protected override object GetIdValue()
        {
            return this._maBoPhan;
        }

        internal static TongHopQuyetToanThueChild GetTongHopQuyetToanThueChild(SafeDataReader dr)
        {
            return new TongHopQuyetToanThueChild(dr);
        }

        public decimal BaoHiemBatBuoc
        {
            get
            {
                return this._baoHiemBatBuoc;
            }
        }

        [DataObjectField(true, true)]
        public int MaBoPhan
        {
            get
            {
                return this._maBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return this._maBoPhanQL;
            }
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                return this._soNguoiPhuThuoc;
            }
        }

        public int SoNV
        {
            get
            {
                return this._soNV;
            }
        }

        public int SoThangGiamTru
        {
            get
            {
                return this._soThangGiamTru;
            }
        }

        public decimal SoThueKhauTru
        {
            get
            {
                return this._soThueKhauTru;
            }
        }

        public decimal SoThueNopThua
        {
            get
            {
                return this._soThueNopThua;
            }
        }

        public decimal SoThuePhaiNop
        {
            get
            {
                return this._soThuePhaiNop;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return this._tenBoPhan;
            }
        }

        public decimal ThueDaKhauTru
        {
            get
            {
                return this._thueDaKhauTru;
            }
        }

        public decimal ThueNLDDaNop
        {
            get
            {
                return this._thueNLDDaNop;
            }
        }

        public decimal ThueNLDNopThem
        {
            get
            {
                return this._thueNLDNopThem;
            }
        }

        public decimal ThueNLDTraLai
        {
            get
            {
                return this._thueNLDTraLai;
            }
        }

        public decimal ThuNhapChiuThue
        {
            get
            {
                return this._thuNhapChiuThue;
            }
        }

        public decimal TNCTGiamThue
        {
            get
            {
                return this._tNCTGiamThue;
            }
        }

        public decimal TuThienNhanDao
        {
            get
            {
                return this._tuThienNhanDao;
            }
        }

        public decimal TongThuNhap
        {
            get
            {
                return this._tongThuNhap;
            }
        }
    }
}


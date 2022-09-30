namespace ERP_Library

{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;

    [Serializable]
    public class InChiTietThueTNCN_ChiTietChild : ReadOnlyBase<InChiTietThueTNCN_ChiTietChild>
    {
        private decimal _baoHiem = 0M;
        private decimal _BHTN = 0M;
        private decimal _BHXH = 0M;
        private decimal _BHYT = 0M;
        private string _dienGiai = "";
        private int _soNguoiPhuThuoc = 0;
        private string _tenGroup = "";
        private decimal _thueTNCN = 0M;
        private decimal _thuNhapTruBH = 0M;
        private decimal _tongThuNhap = 0M;

        private InChiTietThueTNCN_ChiTietChild(SafeDataReader dr)
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
            this._dienGiai = dr.GetString("DienGiai");
            this._tongThuNhap = dr.GetDecimal("TongThuNhap");
            this._baoHiem = dr.GetDecimal("BaoHiem");
            this._thuNhapTruBH = dr.GetDecimal("ThuNhapTruBH");
            this._soNguoiPhuThuoc = dr.GetInt32("SoNguoiPhuThuoc");
            this._thueTNCN = dr.GetDecimal("ThueTNCN");
            this._tenGroup = dr.GetString("TenGroup");
            this._BHXH = dr.GetDecimal("BHXH");
            this._BHYT = dr.GetDecimal("BHYT");
            this._BHTN = dr.GetDecimal("BHTN");
        }

        protected override object GetIdValue()
        {
            return this._dienGiai;
        }

        internal static InChiTietThueTNCN_ChiTietChild GetInChiTietThueTNCN_ChiTietChild(SafeDataReader dr)
        {
            return new InChiTietThueTNCN_ChiTietChild(dr);
        }

        public decimal BaoHiem
        {
            get
            {
                return this._baoHiem;
            }
        }

        public decimal BHTN
        {
            get
            {
                return this._BHTN;
            }
        }

        public decimal BHXH
        {
            get
            {
                return this._BHXH;
            }
        }

        public decimal BHYT
        {
            get
            {
                return this._BHYT;
            }
        }

        [DataObjectField(true, false)]
        public string DienGiai
        {
            get
            {
                return this._dienGiai;
            }
        }

        public int SoNguoiPhuThuoc
        {
            get
            {
                return this._soNguoiPhuThuoc;
            }
        }

        public string TenGroup
        {
            get
            {
                return this._tenGroup;
            }
        }

        public decimal ThueTNCN
        {
            get
            {
                return this._thueTNCN;
            }
        }

        public decimal ThuNhapTruBH
        {
            get
            {
                return this._thuNhapTruBH;
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


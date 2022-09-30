namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;

    [Serializable]
    public class BangLuongQuyetToanThueChild : ReadOnlyBase<BangLuongQuyetToanThueChild>
    {
        private decimal _soTien = 0M;
        private int _thang = 0;

        private BangLuongQuyetToanThueChild(SafeDataReader dr)
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
            this._thang = dr.GetInt32("Thang");
            this._soTien = dr.GetDecimal("SoTien");
        }

        internal static BangLuongQuyetToanThueChild GetBangLuongQuyetToanThueChild(SafeDataReader dr)
        {
            return new BangLuongQuyetToanThueChild(dr);
        }

        protected override object GetIdValue()
        {
            return this._thang;
        }

        public decimal SoTien
        {
            get
            {
                return this._soTien;
            }
        }

        public int Thang
        {
            get
            {
                return this._thang;
            }
        }
    }
}


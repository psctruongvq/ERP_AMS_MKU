namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.ComponentModel;

    [Serializable]
    public class InChiTietThueTNCN_TongHopChild : ReadOnlyBase<InChiTietThueTNCN_TongHopChild>
    {
        private string _dienGiai = string.Empty;
        private bool _inDam = false;
        private string _maMuc = string.Empty;
        private decimal _soTien = 0M;
        private int _stt = 0;

        private InChiTietThueTNCN_TongHopChild(SafeDataReader dr)
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
            this._stt = dr.GetInt32("STT");
            this._maMuc = dr.GetString("MaMuc");
            this._dienGiai = dr.GetString("DienGiai");
            this._soTien = dr.GetDecimal("SoTien");
            this._inDam = dr.GetBoolean("InDam");
        }

        protected override object GetIdValue()
        {
            return this._stt;
        }

        internal static InChiTietThueTNCN_TongHopChild GetInChiTietThueTNCN_TongHopChild(SafeDataReader dr)
        {
            return new InChiTietThueTNCN_TongHopChild(dr);
        }


        public string DienGiai
        {
            get
            {
                return this._dienGiai;
            }
        }

        public bool InDam
        {
            get
            {
                return this._inDam;
            }
        }

        public string MaMuc
        {
            get
            {
                return this._maMuc;
            }
        }

        public decimal SoTien
        {
            get
            {
                return this._soTien;
            }
        }

        [DataObjectField(true, false)]
        public int Stt
        {
            get
            {
                return this._stt;
            }
        }
    }
}


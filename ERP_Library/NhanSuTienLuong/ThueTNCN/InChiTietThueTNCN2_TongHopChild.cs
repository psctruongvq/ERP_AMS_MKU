namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;

    [Serializable]
    public class InChiTietThueTNCN2_TongHopChild : ReadOnlyBase<InChiTietThueTNCN2_TongHopChild>
    {
        private string _dienGiai = string.Empty;
        private bool _inDam = false;
        private string _maMuc = string.Empty;
        private long _maNhanVien = 0L;
        private string _maSoThue = "";
        private decimal _soTien = 0M;
        private int _stt = 0;
        private string _tenBoPhan = "";
        private string _tenNhanVien = "";

        private InChiTietThueTNCN2_TongHopChild(SafeDataReader dr, long maNhanVien, string tenNhanVien, string tenBoPhan, string mst)
        {
            this._maNhanVien = maNhanVien;
            this._tenNhanVien = tenNhanVien;
            this._tenBoPhan = tenBoPhan;
            this._maSoThue = mst;
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
            return (this._maNhanVien.ToString() + ":" + this._stt.ToString());
        }

        internal static InChiTietThueTNCN2_TongHopChild GetInChiTietThueTNCN2_TongHopChild(SafeDataReader dr, long maNhanVien, string tenNhanVien, string tenBoPhan, string mst)
        {
            return new InChiTietThueTNCN2_TongHopChild(dr, maNhanVien, tenNhanVien, tenBoPhan, mst);
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

        public decimal SoTien
        {
            get
            {
                return this._soTien;
            }
        }

        public int Stt
        {
            get
            {
                return this._stt;
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


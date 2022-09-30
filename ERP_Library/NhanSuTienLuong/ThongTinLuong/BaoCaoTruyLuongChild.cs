
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BaoCaoTruyLuongChild : Csla.ReadOnlyBase<BaoCaoTruyLuongChild>
    {
        #region Business Properties and Methods

        //declare members
        private int _maQuyetDinh = 0;
        private int _maBoPhan = 0;
        private string _maBoPhanQL = string.Empty;
        private string _tenBoPhan = string.Empty;
        private long _maNhanVien = 0;
        private string _maQLNhanVien = string.Empty;
        private string _tenNhanVien = string.Empty;
        private decimal _heSoCu = 0;
        private decimal _pCCu = 0;
        private decimal _vKCu = 0;
        private decimal _heSoMoi = 0;
        private decimal _pCMoi = 0;
        private decimal _vKMoi = 0;
        private string _tuKy = string.Empty;
        private string _denKy = string.Empty;
        private int _soKy = 0;
        private decimal _chenhLechHeSo = 0;
        private decimal _luongDot1 = 0;
        private decimal _luongDot2 = 0;
        private decimal _bhxh = 0;
        private decimal _conLai = 0;

        public int MaQuyetDinh
        {
            get
            {
                return _maQuyetDinh;
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                return _maQLNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }

        public decimal HeSoCu
        {
            get
            {
                return _heSoCu;
            }
        }

        public decimal PCCu
        {
            get
            {
                return _pCCu;
            }
        }

        public decimal VKCu
        {
            get
            {
                return _vKCu;
            }
        }

        public decimal HeSoMoi
        {
            get
            {
                return _heSoMoi;
            }
        }

        public decimal PCMoi
        {
            get
            {
                return _pCMoi;
            }
        }

        public decimal VKMoi
        {
            get
            {
                return _vKMoi;
            }
        }

        public string TuKy
        {
            get
            {
                return _tuKy;
            }
        }

        public string DenKy
        {
            get
            {
                return _denKy;
            }
        }

        public int SoKy
        {
            get
            {
                return _soKy;
            }
        }

        public decimal ChenhLechHeSo
        {
            get
            {
                return _chenhLechHeSo;
            }
        }

        public decimal LuongDot1
        {
            get
            {
                return _luongDot1;
            }
        }

        public decimal LuongDot2
        {
            get
            {
                return _luongDot2;
            }
        }

        public decimal Bhxh
        {
            get
            {
                return _bhxh;
            }
        }

        public decimal ConLai
        {
            get
            {
                return _conLai;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static BaoCaoTruyLuongChild GetBaoCaoTruyLuongChild(SafeDataReader dr)
        {
            return new BaoCaoTruyLuongChild(dr);
        }

        private BaoCaoTruyLuongChild(SafeDataReader dr)
        {
            Fetch(dr);
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
            _maQuyetDinh = dr.GetInt32("MaQuyetDinh");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _maQLNhanVien = dr.GetString("MaQLNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _heSoCu = dr.GetDecimal("HeSoCu");
            _pCCu = dr.GetDecimal("PCCu");
            _vKCu = dr.GetDecimal("VKCu");
            _heSoMoi = dr.GetDecimal("HeSoMoi");
            _pCMoi = dr.GetDecimal("PCMoi");
            _vKMoi = dr.GetDecimal("VKMoi");
            DateTime d;
            d = dr.GetDateTime("TuKy");
            _tuKy = d.ToString("MM/yyyy");
            d = dr.GetDateTime("DenKy");
            _denKy = d.ToString("MM/yyyy");
            _soKy = dr.GetInt32("SoKy");
            _chenhLechHeSo = dr.GetDecimal("ChenhLechHeSo");
            _luongDot1 = dr.GetDecimal("LuongDot1");
            _luongDot2 = dr.GetDecimal("LuongDot2");
            _bhxh = dr.GetDecimal("BHXH");
            _conLai = dr.GetDecimal("ConLai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}


using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Report
{
    [Serializable()]
    public class InChiTietLuong_NhanVienChild : Csla.ReadOnlyBase<InChiTietLuong_NhanVienChild>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private string _maSoThue = string.Empty;
        private string _tenBoPhan = string.Empty;
        private int _maKyTinhLuong = 0;
        
        //private string _TieuDePhuCap=string.Empty;
        //public string _TieuDeThuLao = string.Empty;

        private InChiTietLuong_TongHopList _tonghop;
        private InChiTietLuong_ThuLaoList _thulao;
        private InChiTietLuong_PhuCapList _phucap;
        private InChiTietLuong_ThueTamThuList _thuetamthu;
        private InChiTietLuong_PhuCapList _dieuChinh;
        private InChiTietLuong_TienLuongList _tienLuong;

        [System.ComponentModel.DataObjectField(true, false)]
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }
   
        public string TenNhanVien
        {
            get
            {
                return _tenNhanVien;
            }
        }
        //public string TieuDePhuCap
        //{
        //    get
        //    {
        //        return _TieuDePhuCap;
        //    }
        //}
        //public string TieuDeThuLao
        //{
        //    get
        //    {
        //        return _TieuDeThuLao;
        //    }
        //}
        public string MaSoThue
        {
            get
            {
                return _maSoThue;
            }
        }

        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan;
            }
        }
        public InChiTietLuong_TongHopList TongHop
        {
            get
            {
                return _tonghop;
            }
        }

        public InChiTietLuong_ThuLaoList ThuLao
        {
            get
            {
                return _thulao;
            }
        }

        public InChiTietLuong_PhuCapList PhuCap
        {
            get
            {
                return _phucap;
            }
        }

        public InChiTietLuong_ThueTamThuList ThueTamThu
        {
            get
            {
                return _thuetamthu;
            }
        }

        public InChiTietLuong_PhuCapList DieuChinh
        {
            get
            {
                return _dieuChinh;
            }
        }

        public InChiTietLuong_TienLuongList TienLuong
        {
            get
            {
                return _tienLuong;
            }
        }

        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        internal static InChiTietLuong_NhanVienChild GetInChiTietLuong_NhanVienChild(SafeDataReader dr, int maKyTinhLuong, bool IsNew)
        {
            return new InChiTietLuong_NhanVienChild(dr, maKyTinhLuong, IsNew);
        }

        private InChiTietLuong_NhanVienChild(SafeDataReader dr,  int maKyTinhLuong, bool isNew)
        {
            _maKyTinhLuong = maKyTinhLuong;
            Fetch(dr, isNew);
        }


        #endregion //Factory Methods


        #region Data Access

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr, bool IsNew)
        {
            FetchObject(dr);

            //load child object(s)
            FetchChildren(dr, IsNew);
            
                
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _maSoThue = dr.GetString("MaSoThue");
            _tenBoPhan = dr.GetString("TenBoPhan");
            //_TieuDePhuCap = "CHI TIẾT PHỤ CẤP, KHEN THƯỞNG NHẬN TỪ NGÀY " + InChiTietLuong_NhanVienList.TuNgay.ToString("dd/MM/yyyy") + " ĐẾN NGÀY " + InChiTietLuong_NhanVienList.DenNgay.ToString("dd/MM/yyyy") + ": ";
            //_TieuDeThuLao = "CHI TIẾT THÙ LAO NHẬN TỪ NGÀY " + InChiTietLuong_NhanVienList.TuNgay.ToString("dd/MM/yyyy") + " ĐẾN NGÀY " + InChiTietLuong_NhanVienList.DenNgay.ToString("dd/MM/yyyy") + ": ";
        }

        private void FetchChildren(SafeDataReader dr, bool IsNew)
        {
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                if (IsNew && _maKyTinhLuong<=62)
                    cm.CommandText = "spd_Report_InChiTietLuong_HTV";
                else if (IsNew &&   _maKyTinhLuong> 62)
                    //cm.CommandText = "spd_Report_InChiTietLuong_HTV_New";
                    cm.CommandText = "spd_Report_InChiTietLuong_HTV_New_MaLoaiChi";
                else
                    cm.CommandText = "spd_Report_InChiTietLuong_HTV_CTV";
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
                cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                //cm.Parameters.AddWithValue("@TuNgay",InChiTietLuong_NhanVienList.TuNgay);
                //cm.Parameters.AddWithValue("@DenNgay", InChiTietLuong_NhanVienList.DenNgay);

                using (SafeDataReader dr2 = new SafeDataReader(cm.ExecuteReader()))
                {
                    _tonghop = new InChiTietLuong_TongHopList(dr2);

                    
                    dr2.NextResult();
                    _thulao = new InChiTietLuong_ThuLaoList(dr2);

                    dr2.NextResult();
                    _phucap = new InChiTietLuong_PhuCapList(dr2);

                    dr2.NextResult();
                    _thuetamthu = InChiTietLuong_ThueTamThuList.GetInChiTietLuong_ThueTamThuList(dr2);

                    dr2.NextResult();
                    _tienLuong = new InChiTietLuong_TienLuongList(dr2);


                }
            }
            cn.Close();
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    } 
}

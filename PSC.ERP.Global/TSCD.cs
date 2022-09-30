using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Global
{
    public class TSCD
    {
        public const String MaPhanHeTSCD = "TSCD";

        public const Int32 SizeOf_MaNhomTaiSanQuanLy = 1;
        public const Int32 SizeOf_MaLoaiTaiSanQuanLy_IncreasePart = 2;
        public const Int32 SizeOf_MaTSCDQuanLy_IncreasePart = 3;
        public const Int32 SizeOf_SoHieuTSCDCaBiet_IncreasePart = 5;
        public const Int32 SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart = 3;

        public const Int32 SizeOf_SoChungTuPhieuKeToanTaiSan_IncreasePart = 4;

        public const Int32 SizeOf_MaChungTuQLDieuChinhGiaTaiSan_IncreasePart = 4;
        public const Int32 SizeOf_MaChungTuQLSuaChuaLonTaiSan_IncreasePart = 4;
        public const Int32 SizeOf_MaChungTuQLGhiTangTaiSan_IncreasePart = 4;
        public const Int32 SizeOf_MaChungTuQLDieuChuyenNgoai_IncreasePart = 4;
        public const Int32 SizeOf_MaChungTuQLThanhLy_IncreasePart = 4;

        public const Int32 SizeOf_SoChungTuDieuChuyenNoiBo_IncreasePart = 4;
        public const Int32 SizeOf_SoChungTuNVNgungVaTaiSuDung_IncreasePart = 4;
        public const Int32 MaLoaiChungTuSuaChuaLonTSCD = 11;
        //
        public const String MaQLHopDongMuaSam = "HDMS";
        public const String MaQLHopDongDuAn = "HDDA";
        public const String BackupReportExtension = "PSCBKRPT";

        //        INSERT INTO dbo.tblLoaiHopDong
        //        ( MaQuanLy, TenLoaiHopDong )
        //VALUES  ( 'HDTS', -- MaQuanLy - varchar(50)
        //          N'Hợp đồng tài sản'  -- TenLoaiHopDong - nvarchar(500)
        //          )
        //public const Int32 MaLoaiHopDongTaiSan = 6;//định nghĩa trong tblLoaiHopDong




        //6 Hóa Đơn Mua Tài Sản, 7 Hóa Đơn Bán Tài Sản
        //public const Int32 MaLoaiHoaDonMuaTaiSan = 6;
        //public const Int32 MaLoaiHoaDonBanTaiSan = 7;


        public const Int32 MaLoaiChungTuDieuChuyenNgoai = 12;//định nghĩa trong tblLoaiChungTu


        //        INSERT INTO dbo.tblLoaiChungTu
        //        ( TenLoaiCT, MaLoaiCTQuanLy )
        //VALUES  ( N'Ghi Tăng Tài Sản', -- TenLoaiCT - nvarchar(4000)
        //          'GTTS'  -- MaLoaiCTQuanLy - varchar(50)
        //          )
        public const Int32 MaLoaiChungTuGhiTangTSCD = 17;//định nghĩa trong tblLoaiChungTu//cần insert vào database bên HTV với mã số 17



        //        INSERT INTO dbo.tblLoaiChungTu
        //        ( TenLoaiCT, MaLoaiCTQuanLy )
        //VALUES  ( N'Thanh lý tài sản', -- TenLoaiCT - nvarchar(4000)
        //          'TLTS'  -- MaLoaiCTQuanLy - varchar(50)
        //          )
        public const Int32 MaLoaiChungTuThanhLy = 18;//định nghĩa trong tblLoaiChungTu//cần insert vào database bên HTV với mã số 18


        //        INSERT INTO dbo.tblLoaiChungTu
        //        ( TenLoaiCT, MaLoaiCTQuanLy )
        //VALUES  ( N'Điều chỉnh giá trị tài sản', -- TenLoaiCT - nvarchar(4000)
        //          'DCGTTS'  -- MaLoaiCTQuanLy - varchar(50)
        //          )
        public const Int32 MaLoaiChungTuDieuChinhGiaTri = 19;//định nghĩa trong tblLoaiChungTu//cần insert vào database bên HTV với mã số 19

    }
}

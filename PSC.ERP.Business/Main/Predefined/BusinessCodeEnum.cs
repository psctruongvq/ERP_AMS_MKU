using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum BusinessCodeEnum
    {//không hiểu vui lòng đừng rename
        [Description("Tất cả")]
        ALL = 0,
        [Description("Danh sách bộ phận")]
        TSCD_BoPhan,
        [Description("Phân quyền menu")]
        TSCD_PhanQuyenMenu,
        [Description("Quản lý menu và chức năng")]
        TSCD_MenuAndFunctionManager,
        [Description("Ghi tăng tài sản")]
        TSCD_GhiTang,
        [Description("Thanh lý tài sản")]
        TSCD_ThanhLy,
        [Description("Điều chuyển ngoài tài sản")]
        TSCD_DieuChuyenNgoai,
        [Description("Điều chuyển chi tiết tài sản")]
        TSCD_DieuChuyenChiTietTaiSan,
        [Description("Đổi số serial tài sản")]
        TSCD_DoiSoSerialTaiSan,
        [Description("Điều chuyển nội bộ tài sản")]
        TSCD_DieuChuyenNoiBo,
        [Description("Sữa chữa lớn tài sản")]
        TSCD_SuaChuaLon,
        [Description("Điều chỉnh giá trị tài sản")]
        TSCD_DieuChinhGiaTri,
        [Description("Biểu mẫu báo cáo tài sản")]
        TSCD_Report,
        [Description("Chạy khấu hao hao mòn tài sản")]
        TSCD_ChayKHHM,
        [Description("In mã vạch tài sản")]
        TSCD_InMaVach,
        [Description("Lập tài sản chờ duyệt")]
        TSCD_LapTaiSanChoDuyet,
        [Description("Duyệt tài sản")]
        TSCD_DuyetTaiSan,
        [Description("Ngừng sử dụng tài sản")]
        TSCD_NgungSuDung,
        [Description("Tái sử dụng tài sản")]
        TSCD_TaiSuDung,
        [Description("Kiểm kê tài sản")]
        TSCD_KiemKe,
        [Description("Cây danh mục tài sản")]
        TSCD_CayTaiSan,
        [Description("Đơn vị tính")]
        TSCD_DonViTinh,
        [Description("Kỳ kế toán")]
        TSCD_KyKeToan,
        [Description("Quốc gia")]
        TSCD_QuocGia,
        [Description("Hóa đơn")]
        TSCD_HoaDon,
        [Description("Đăng ký tỉ lệ khấu hao hao mòn theo tài khoản")]
        TSCD_DangKyTiLeKHHMTheoTaiKhoan,
        [Description("Phân bổ chi phi CCDC chuyển từ tài sản")]
        CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan,

        [Description("Bảng Kê Thu Chi")]
        BangKe_ThuChi,

        [Description("Bảo Trì Bảo Dưỡng")]
        TSCD_BaoTriBaoDuong,
    }
}

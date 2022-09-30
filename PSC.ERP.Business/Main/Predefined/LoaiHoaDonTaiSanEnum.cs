using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum LoaiHoaDonEnum
    {
        HoaDonMuaHangDichVu =4,
        HoaDonMuaTaiSan = 6,
        HoaDonBanTaiSan = 7
    }
    /// <summary>
    /// 
    /// </summary>
    public class LoaiHoaDon
    {

        #region private Field

        Int32 _ma;
        String _name;

        public String TenLoaiHoaDon
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Int32 MaLoaiHoaDon
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<LoaiHoaDon> LoaiHoaDonList = new List<LoaiHoaDon> {
                new LoaiHoaDon(){MaLoaiHoaDon= (Int32)LoaiHoaDonEnum.HoaDonMuaHangDichVu, TenLoaiHoaDon = "Hóa đơn mua hàng dịch vụ"}
                ,new LoaiHoaDon(){MaLoaiHoaDon= (Int32)LoaiHoaDonEnum.HoaDonMuaTaiSan, TenLoaiHoaDon = "Hóa đơn mua tài sản"}
                ,new LoaiHoaDon(){MaLoaiHoaDon = (Int32)LoaiHoaDonEnum.HoaDonBanTaiSan, TenLoaiHoaDon = "Hóa đơn bán tài sản"}
                };
        #endregion

    }
}

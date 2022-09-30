using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum TinhTrangHoaDonEnum
    {
        ChuaHoanTat = 0,
        HoanTat = 1,
        HoanTat1Phan = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public class TinhTrangHoaDon
    {

        #region private Field

        Int32 _ma;
        String _name;

        public String Ten
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Int32 Ma
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<TinhTrangHoaDon> TinhTrangHoaDonList = new List<TinhTrangHoaDon> {
                new TinhTrangHoaDon(){Ma= (Int32)TinhTrangHoaDonEnum.ChuaHoanTat, Ten = "Chưa hoàn tất"}
                ,new TinhTrangHoaDon(){Ma= (Int32)TinhTrangHoaDonEnum.HoanTat, Ten = "Hoàn tất"}
                ,new TinhTrangHoaDon(){Ma = (Int32)TinhTrangHoaDonEnum.HoanTat1Phan, Ten = "Hoàn tất 1 phần"}
                };
        #endregion

    }
}

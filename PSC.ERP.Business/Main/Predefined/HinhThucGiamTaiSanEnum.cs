using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum HinhThucGiamTaiSanEnum
    {
        TatCa = 0,
        ThanhLy = 1,
        DieuChuyenNgoai=2,
        DieuChinhGiaTri=3,
    }
    /// <summary>
    /// 
    /// </summary>
    public class HinhThucGiamTaiSan
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
        public static List<HinhThucGiamTaiSan> HinhThucGiamTaiSanList = new List<HinhThucGiamTaiSan> {
                new HinhThucGiamTaiSan(){Ma= (Int32)HinhThucGiamTaiSanEnum.TatCa, Ten = "<<Tất cả>>"}
                ,new HinhThucGiamTaiSan(){Ma= (Int32)HinhThucGiamTaiSanEnum.ThanhLy, Ten = "Thanh lý"}
                ,new HinhThucGiamTaiSan(){Ma = (Int32)HinhThucGiamTaiSanEnum.DieuChuyenNgoai, Ten = "Điều chuyển ngoài"}
                ,new HinhThucGiamTaiSan(){Ma = (Int32)HinhThucGiamTaiSanEnum.DieuChinhGiaTri, Ten = "Điều chỉnh giá trị"}
                };
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum LoaiBaoCaoKHHMEnum
    {
        TatCa = 0,
        TaiSanConSuDung = 1,
        TaiSanThanhLy= 2,
        TaiSanDieuChuyenNgoai = 3,
        TaiSanTachHeThong = 4,
    }
    /// <summary>
    /// 
    /// </summary>
    public class LoaiBaoCaoKHHM
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
        public static List<LoaiBaoCaoKHHM> LoaiBaoCaoKHHMList = new List<LoaiBaoCaoKHHM> {
                new LoaiBaoCaoKHHM(){Ma= (Int32)LoaiBaoCaoKHHMEnum.TatCa, Ten = "<<Tất cả>>"}
                ,new LoaiBaoCaoKHHM(){Ma= (Int32)LoaiBaoCaoKHHMEnum.TaiSanConSuDung, Ten = "Tài sản còn sử dụng"}
                ,new LoaiBaoCaoKHHM(){Ma = (Int32)LoaiBaoCaoKHHMEnum.TaiSanThanhLy, Ten = "Tài sản thanh lý"}
                ,new LoaiBaoCaoKHHM(){Ma = (Int32)LoaiBaoCaoKHHMEnum.TaiSanDieuChuyenNgoai, Ten = "Tài sản điều chuyển ngoài"}
                ,new LoaiBaoCaoKHHM(){Ma = (Int32)LoaiBaoCaoKHHMEnum.TaiSanTachHeThong, Ten = "Tài sản tách hệ thống"}
                };
        #endregion

    }
}

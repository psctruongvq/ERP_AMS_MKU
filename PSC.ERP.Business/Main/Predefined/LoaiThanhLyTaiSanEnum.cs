using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum LoaiThanhLyTaiSanEnum
    {
        TatCa = 0,
        ThanhLy = 1,
        DieuChuyenNgoai=2,
        TachHeThong=3,
    }
    /// <summary>
    /// 
    /// </summary>
    public class LoaiThanhLyTaiSan
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
        public static List<LoaiThanhLyTaiSan> LoaiThanhLyTaiSanList = new List<LoaiThanhLyTaiSan> {
                new LoaiThanhLyTaiSan(){Ma= (Int32)LoaiThanhLyTaiSanEnum.TatCa, Ten = "<<Tất cả>>"}
                ,new LoaiThanhLyTaiSan(){Ma= (Int32)LoaiThanhLyTaiSanEnum.ThanhLy, Ten = "Thanh lý"}
                ,new LoaiThanhLyTaiSan(){Ma = (Int32)LoaiThanhLyTaiSanEnum.DieuChuyenNgoai, Ten = "Điều chuyển ngoài"}
                };
        #endregion

    }
}

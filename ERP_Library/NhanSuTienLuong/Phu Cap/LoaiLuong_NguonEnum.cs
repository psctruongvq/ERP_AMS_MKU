using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_Library
{
    /// <summary>
    /// 
    /// </summary>
    public class LoaiLuong_Nguon
    {

        #region private Field

        String _ma;
        String _name;

        public String Ten
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public String Ma
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<LoaiLuong_Nguon> LoaiLuongList = new List<LoaiLuong_Nguon> {
                new LoaiLuong_Nguon(){Ma= string.Empty, Ten = "<<Chọn>>"}
                ,new LoaiLuong_Nguon(){Ma= "LK1", Ten = "Lương kỳ 1"}
                ,new LoaiLuong_Nguon(){Ma= "LK2", Ten = "Lương kỳ 2"}
                };
        #endregion

    }
}

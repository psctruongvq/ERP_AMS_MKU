using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum CoKhongEnum
    {
        Khong = 0,
        Co = 1
    }
    /// <summary>
    /// 
    /// </summary>
    public class CoKhong
    {

        #region private Field

        Int32 _maInt32;
        String _name;

        public String Ten
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Int32 MaInt32
        {
            get { return _maInt32; }
            set { _maInt32 = value; }
        }
        public Boolean MaBoolean
        {
            get { return (_maInt32 == (Int32)CoKhongEnum.Co ? true : false); }
            set { _maInt32 = (Int32)(value == true ? CoKhongEnum.Co : CoKhongEnum.Khong); }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<CoKhong> CoKhongList = new List<CoKhong> {
            new CoKhong(){MaInt32= (Int32)CoKhongEnum.Khong, Ten = "Không"}
                ,new CoKhong(){MaInt32 = (Int32)CoKhongEnum.Co, Ten = "Có"}
                };
        #endregion

    }
}

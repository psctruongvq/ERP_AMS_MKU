using System;
using System.Collections.Generic;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum ThueSuatVATEnum
    {
        Khong = 0,
        Nam = 5,
        Muoi = 10
    }
    /// <summary>
    /// 
    /// </summary>
    public class ThueSuatVAT
    {

        #region private Field

        decimal _ma;
        String _name;

        public String Ten
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public decimal Ma
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<ThueSuatVAT> ThueSuatVATList = new List<ThueSuatVAT> {
                new ThueSuatVAT(){Ma= (Int32)ThueSuatVATEnum.Khong, Ten = "0"}
                ,new ThueSuatVAT(){Ma= (Int32)ThueSuatVATEnum.Nam, Ten = "5"}
                ,new ThueSuatVAT(){Ma = (Int32)ThueSuatVATEnum.Muoi, Ten = "10"}
                };
        #endregion

    }
}

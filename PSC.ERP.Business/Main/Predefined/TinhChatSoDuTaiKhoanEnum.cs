using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum TinhChatSoDuTaiKhoanEnum
    {
        No = 1,
        Co = 2
    }
    /// <summary>
    /// 
    /// </summary>
    public class TinhChatSoDuTaiKhoan
    {

        #region private Field

        Int32 _ma;
        String _name;

        public String TenTinhChatSoDuTaiKhoan
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Int32 MaTinhChatSoDuTaiKhoan
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<TinhChatSoDuTaiKhoan> TinhChatSoDuTaiKhoanList = new List<TinhChatSoDuTaiKhoan> {
                //new TinhChatSoDuTaiKhoan(){MaTinhChatSoDuTaiKhoan= 0, TenTinhChatSoDuTaiKhoan = "<<Không chọn>>"}
                //,
                new TinhChatSoDuTaiKhoan(){MaTinhChatSoDuTaiKhoan= (Int32)TinhChatSoDuTaiKhoanEnum.No, TenTinhChatSoDuTaiKhoan = "Nợ"}
                ,new TinhChatSoDuTaiKhoan(){MaTinhChatSoDuTaiKhoan = (Int32)TinhChatSoDuTaiKhoanEnum.Co, TenTinhChatSoDuTaiKhoan = "Có"}
                };
        #endregion

    }
}

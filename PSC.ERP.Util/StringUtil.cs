using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Util
{
    public class StringUtil
    {
        public static String UpperFirstChar(String str)
        {
            StringBuilder builder = new StringBuilder();

            //bo di ky tu dau tien
            String partOfStr = str.Substring(1, str.Length - 1);
            //lay ky tu dau tien va chuyen thanh ky tu hoa
            String upperFirstChar = str.Substring(0, 1).ToUpper();

            return upperFirstChar + partOfStr;
        }
    }
}

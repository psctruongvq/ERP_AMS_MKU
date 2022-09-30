using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Util
{
    public static class ByteArrayUtil
    {
        public static string BytesToString(byte[] bytes, System.Text.Encoding encoding)
        {
            return encoding.GetString(bytes, 0, bytes.Length);
        }
        public static byte[] StringToBytes(string s, System.Text.Encoding encoding)
        {
            return encoding.GetBytes(s);
        }
    }
}

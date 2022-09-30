using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common
{
    public static class StreamUtil
    {
        public static MemoryStream GetMemoryStreamFromBytesArray(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            return memoryStream;
        }

    }
}

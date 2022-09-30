using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace PSC_ERP_Digitizing.WebService
{
    public partial class DigitizingService
    {
        [WebMethod]
        public Int32 SplitFile(String publicKey, String token, String fileName, String maPhanHe)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                String filePath = "";
                if (maPhanHe == "SH")
                    filePath = Path.Combine(_sourceSoHoaDirectory, fileName);
                else if (maPhanHe == "NS")
                    filePath = Path.Combine(_sourceNhanSuDirectory, fileName);
                Int32 TotalFileParts = 0;
                string BaseFileName = Path.GetFileName(filePath);
                int BufferChunkSize = 1024 * 1024;//65536;
                using (FileStream FS = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    if (FS.Length < BufferChunkSize*10)
                    {
                        TotalFileParts = 1;
                    }
                    else
                    {
                        float PreciseFileParts = ((float)FS.Length / (float)BufferChunkSize);
                        TotalFileParts = (Int32)Math.Ceiling(PreciseFileParts);
                    }
                }
                return TotalFileParts;
            }
            else
            {
                //Xác thực không hợp lệ.
                SoapException se = new SoapException("Xác thực không hợp lệ",
                 SoapException.ClientFaultCode,
                 Context.Request.Url.AbsoluteUri,
                 new Exception("Xác thực không hợp lệ"));
                throw se;
            }
        }


        [WebMethod]
        public byte[] QuickHelper_DownloadSourceFileLarge_ByFileName(String publicKey, String token, String fileName, String maPhanHe, long offset)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                byte[] data = null;
                String filePath = "";
                if (maPhanHe == "SH")
                    filePath = Path.Combine(_sourceSoHoaDirectory, fileName);
                else if (maPhanHe == "NS")
                    filePath = Path.Combine(_sourceNhanSuDirectory, fileName);
                string BaseFileName = Path.GetFileName(filePath);
                int BufferChunkSize = 1024 * 1024;//65536;
                byte[] buffer = new byte[BufferChunkSize];
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        //fs.Position = offset;
                        int bytesRead = 0;
                        long offsetn = 0;
                        while (offsetn <= offset && offsetn != fs.Length)
                        {
                            bytesRead = fs.Read(buffer, 0, BufferChunkSize);
                            if (offsetn == offset)
                            {
                                data = buffer;
                            }
                            offsetn += bytesRead;
                        }
                    }
                    return data;
                }
                catch {
                    return null;
                }
            }
            else
            {
                //Xác thực không hợp lệ.
                SoapException se = new SoapException("Xác thực không hợp lệ",
                 SoapException.ClientFaultCode,
                 Context.Request.Url.AbsoluteUri,
                 new Exception("Xác thực không hợp lệ"));
                throw se;
            }
        }
    }
}
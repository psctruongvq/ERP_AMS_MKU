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
        public Boolean IO_ExistsFile(String publicKey, String token, String filePath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                Boolean exists = File.Exists(filePath);
                return exists;
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
        public Boolean IO_ExistsDir(String publicKey, String token, String dirPath)
        {
            if (Helper.TrustTest(publicKey, token))
            {
                Boolean exists = Directory.Exists(dirPath);
                return exists;
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